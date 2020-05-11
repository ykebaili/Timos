using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using futurocom.easyquery;
using sc2i.formulaire;
using sc2i.common;
using sc2i.common.sig;
using sc2i.data;
using System.Data;

namespace futurocom.sig
{
    public class CMapRouteFromQuery : IMapItemGenerator
    {

        private CMapDatabaseGenerator m_generateur = null;
        private string m_strLibelle = "";


        private CEasyQuery m_query = new CEasyQuery();
        private CListeQuerySource m_listeSources = new CListeQuerySource();


        private string m_strNomTableSource = "";
        private string m_strChampCleElement = "";
        private string m_strChampLatitude = "";
        private string m_strChampLongitude = "";
        private string m_strChampLibelle = "";

        private double m_fMetresEntrePoints = 100;

        //---------------------------------------------
        public CMapRouteFromQuery()
        {
            Libelle = GeneratorName;
        }

        //---------------------------------------------
        public CMapRouteFromQuery(CMapDatabaseGenerator generator)
            :this()
        {
            m_generateur = generator;
        }

        //---------------------------------------------
        public string GeneratorName
        {
            get
            {
                return I.T("Route from query|20023");
            }
        }

        //---------------------------------------------
        public string Libelle
        {
            get
            {
                return m_strLibelle;
            }
            set
            {
                m_strLibelle = value;
            }
        }

        //---------------------------------------------
        public string NomTableSource
        {
            get
            {
                return m_strNomTableSource;
            }
            set
            {
                m_strNomTableSource = value;
            }
        }

        //---------------------------------------------
        public string ChampCleElement
        {
            get
            {
                return m_strChampCleElement;
            }
            set
            {
                m_strChampCleElement = value;
            }
        }

        //---------------------------------------------
        public string ChampLatitude
        {
            get
            {
                return m_strChampLatitude;
            }
            set
            {
                m_strChampLatitude = value;
            }
        }

        //---------------------------------------------
        public string ChampLongitude
        {
            get
            {
                return m_strChampLongitude;
            }
            set
            {
                m_strChampLongitude = value;
            }
        }

        //---------------------------------------------
        public string ChampLibelle
        {
            get
            {
                return m_strChampLibelle;
            }
            set
            {
                m_strChampLibelle = value;
            }
        }

        //---------------------------------------------
        public double MetresEntrePoints
        {
            get
            {
                return m_fMetresEntrePoints;
            }
            set
            {
                m_fMetresEntrePoints = value;
            }
        }


        //---------------------------------------------
        public CMapDatabaseGenerator Generator
        {
            get
            {
                return m_generateur;
            }
            set
            {
                m_generateur = value;
                if (m_query != null)
                    m_query.ElementAVariablesExternes = m_generateur;
            }
        }

        //---------------------------------------------
        public CEasyQuery Query
        {
            get
            {
                if (m_query == null)
                    m_query = new CEasyQuery();
                m_query.Sources = m_listeSources.Sources;
                m_query.ElementAVariablesExternes = Generator;
                m_query.IContexteDonnee = Generator != null ? Generator.IContexteDonnee : null;
                return m_query;
            }
            set
            {
                m_query = value;
                if (value != null)
                    m_listeSources = value.ListeSources;
            }
        }

        //---------------------------------------------
        public IEnumerable<CEasyQuerySource> ListeSource
        {
            get{
                return m_listeSources.Sources;
            }
            set{
                CListeQuerySource lst = new CListeQuerySource();
                if ( value != null )
                {
                    foreach ( CEasyQuerySource src in value )
                        lst.AddSource ( src );
                }
                m_listeSources = lst;
                if ( m_query != null )
                    m_query.Sources = m_listeSources.Sources;
            }
        }

        public static double GetGpsDist(double fLong1, double fLat1, double fLong2, double fLat2)
        {
            double t1 = Math.Sin(fLat1) * Math.Sin(fLat2);
            double t2 = Math.Cos(fLat1) * Math.Cos(fLat2);
            double t3 = Math.Cos(fLong1 - fLong2);
            double t4 = t2 * t3;
            double t5 = t1 + t4;
            double fDistRad = Math.Atan(-t5 / Math.Sqrt(-t5 * t5 + 1)) + 2 * Math.Atan(1);
            double fDist = fDistRad * 3437.74677 * 1.1508 * 1.6093470878864446;
            return fDist;
        }


        //---------------------------------------------
        public CResultAErreur GenereItems(CMapDatabase database, CContexteDonnee ctxDonnee)
        {
            CResultAErreur result = CResultAErreur.True;
            //Calcule les éléments à générer
            DataTable table = Query.GetTable(NomTableSource, m_listeSources);
            double? fLastLat = null;
            double? fLastLong = null;
            CMapLayer layer = database.GetLayer(Generator.LayerId, true);
            if (table != null)
            {
                DataColumn colLat = null;
                DataColumn colLong = null;
                DataColumn colLib = null;
                DataColumn colElt = null;
                foreach (DataColumn col in table.Columns)
                {
                    if (col.ColumnName == ChampCleElement)
                        colElt = col;
                    if (col.ColumnName == ChampLatitude)
                        colLat = col;
                    if (col.ColumnName == ChampLibelle)
                        colLib = col;
                    if (col.ColumnName == ChampLongitude)
                        colLong = col;
                }
                if (colLong == null || colLat == null)
                {
                    result.EmpileErreur(I.T("Can not find columns @1 and @2 in data source|20024",
                        ChampLongitude,
                        ChampLatitude));
                }
                Dictionary<object, List<DataRow>> dicRowsParElement = new Dictionary<object, List<DataRow>>();
                if (colElt != null)
                {
                    object lastElt = null;
                    List<DataRow> lstRows = null;
                    foreach (DataRow row in table.Rows)
                    {
                        object v = row[colElt];
                        if (v != lastElt || lstRows == null)
                        {
                            lastElt = v;
                            if (!dicRowsParElement.TryGetValue(v, out lstRows))
                            {
                                lstRows = new List<DataRow>();
                                dicRowsParElement[v] = lstRows;
                            }
                        }
                        lstRows.Add(row);
                    }
                }
                else
                {
                    List<DataRow> lstRows = new List<DataRow>();
                    foreach (DataRow row in table.Rows)
                        lstRows.Add(row);
                    dicRowsParElement[DBNull.Value] = lstRows;
                }

                foreach (KeyValuePair<object, List<DataRow>> kv in dicRowsParElement)
                {
                    List<DataRow> lstRows = kv.Value;
                    List<SLatLong> lstPoints = new List<SLatLong>();
                    int nNb = kv.Value.Count;
                    int nIndex = 0;
                    foreach (DataRow row in kv.Value)
                    {
                        try
                        {
                            double fLat = Convert.ToDouble(row[colLat]);
                            double fLong = Convert.ToDouble(row[colLong]);
                            string strLabel = colLib != null ?row[colLib] as string:null;
                            if (strLabel == null || strLabel.Length == 0)
                                strLabel = "";
                            bool bPrendre = true;
                            if (strLabel == "" && fLastLong != null && fLastLat != null && MetresEntrePoints > 0)
                            {
                                //contrôle la distance
                                double fDist = GetGpsDist(fLastLong.Value, fLong, fLastLat.Value, fLat);
                                bPrendre = fDist >= MetresEntrePoints;
                            }
                            if (nIndex == nNb - 1)
                                bPrendre = true;
                            if (bPrendre)
                            {
                                fLastLat = fLat;
                                fLastLong = fLong;
                                SLatLong pt = new SLatLong(fLat, fLong);
                                lstPoints.Add(pt);
                            }
                            if (strLabel != null && strLabel.Trim().Length > 0)
                            {
                                CMapItemSimple item =new CMapItemSimple(layer, fLat, fLong, EMapMarkerType.blue_dot);
                                item.ToolTip = strLabel;
                                layer.AddItem(item);
                            }
                        }
                        catch { }
                    }
                    CMapItemPath path = new CMapItemPath(layer);
                    path.Points = lstPoints.ToArray();
                    layer.AddItem(path);
                }
            }
            return result;
        }

        //---------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //---------------------------------------------        
        public CResultAErreur Serialize(sc2i.common.C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;

            serializer.TraiteString(ref m_strLibelle);

            result = serializer.TraiteObject<CEasyQuery>(ref m_query);
            if (result)
                result = serializer.TraiteObject<CListeQuerySource>(ref m_listeSources);
            if (!result)
                return result;
            serializer.TraiteString(ref m_strNomTableSource);
            serializer.TraiteString(ref m_strChampCleElement);
            serializer.TraiteString(ref m_strChampLatitude);
            serializer.TraiteString(ref m_strChampLongitude);
            serializer.TraiteString(ref m_strChampLibelle);
            serializer.TraiteDouble(ref m_fMetresEntrePoints);
            return result;
        }
    }
}
