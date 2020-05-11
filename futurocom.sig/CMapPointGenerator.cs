using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using sc2i.data.dynamic;
using sc2i.expression;
using sc2i.common.sig;
using sc2i.data;
using System.Data;
using sc2i.formulaire;

namespace futurocom.sig
{
    public class CMapPointGenerator : IMapItemGenertorFromEntities, 
        IElementAVariableInstance
    {
        private string m_strLibelle = "";
        private CFiltreDynamique m_filtreDynamique;
        private CMapDatabaseGenerator m_generateur = null;
        private C2iExpression m_formuleLatitude = null;
        private C2iExpression m_formuleLongitude = null;
        private List<CMapItemDessin> m_listeAlternativesDessin = new List<CMapItemDessin>();
        private CActionSur2iLink m_actionSurClick = null;

        private object m_currentGeneratedItem = null;

        //-------------------------------------------------------------
        public CMapPointGenerator()
        {
            Libelle = GeneratorName;

            CMapItemDessin dessin = new CMapItemDessin();
            dessin.MarkerType = EMapMarkerType.green;
            dessin.FormuleCondition = new C2iExpressionVrai();
            m_listeAlternativesDessin.Add(dessin);
        }

        //-------------------------------------------------------------
        public CMapPointGenerator(CMapDatabaseGenerator generateur)
        {
            m_generateur = generateur;
        }

        //-------------------------------------------------------------
        public string GeneratorName
        {
            get
            {
                return I.T("Points from entity|20001");
            }
        }


        
        //--------------------------------------------------------------------------
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

        

        //-------------------------------------------------------------
        [DynamicField("Map generator")]
        public CMapDatabaseGenerator Generator
        {
            get
            {
                return m_generateur;
            }
            set
            {
                m_generateur = value;
            }
        }

        //-------------------------------------------------------------
        public object CurrentGeneratedItem
        {
            get
            {
                return m_currentGeneratedItem;
            }
        }

        //-------------------------------------------------------------
        public CFiltreDynamique Filtre
        {
            get
            {
                if (m_filtreDynamique == null)
                    m_filtreDynamique = new CFiltreDynamique();
                m_filtreDynamique.ContexteDonnee = Generator.ContexteDonnee;
                m_filtreDynamique.ElementAVariablesExterne = m_generateur;
                return m_filtreDynamique;
            }
            set
            {
                m_filtreDynamique = value;
            }
        }

        //-------------------------------------------------------------
        public CActionSur2iLink ActionSurClick
        {
            get
            {
                return m_actionSurClick;
            }
            set
            {
                m_actionSurClick = value;
            }
        }

        //-------------------------------------------------------------
        public Type TypeElementsDessines
        {
            get
            {
                if (m_filtreDynamique != null)
                    return m_filtreDynamique.TypeElements;
                return null;
            }
        }



        //-------------------------------------------------------------
        public C2iExpression FormuleLatitude
        {
            get
            {
                return m_formuleLatitude;
            }
            set
            {
                m_formuleLatitude = value;
            }
        }

        //-------------------------------------------------------------
        public C2iExpression FormuleLongitude
        {
            get
            {
                return m_formuleLongitude;
            }
            set
            {
                m_formuleLongitude = value;
            }
        }

        //-------------------------------------------------------------
        public IEnumerable<CMapItemDessin> ItemsDessin
        {
            get
            {
                return m_listeAlternativesDessin.ToArray();
            }
            set
            {
                m_listeAlternativesDessin.Clear();
                int nIndex = 0;
                if (value != null)
                {
                    foreach (CMapItemDessin item in value)
                    {
                        item.Index = nIndex++;
                        m_listeAlternativesDessin.Add(item);
                    }
                }
            }
        }


        //-------------------------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //-------------------------------------------------------------
        public CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            serializer.TraiteString(ref m_strLibelle);

            if ( result )
                result = serializer.TraiteObject<CFiltreDynamique>(ref m_filtreDynamique);
            if (result)
                result = serializer.TraiteObject<C2iExpression>(ref m_formuleLatitude);
            if (result)
                result = serializer.TraiteObject<C2iExpression>(ref m_formuleLongitude);
            if (result)
                result = serializer.TraiteListe<CMapItemDessin>(m_listeAlternativesDessin, new object[] { this });
            if (result)
                result = serializer.TraiteObject<CActionSur2iLink>(ref m_actionSurClick);
            if (!result)
                return result;
            return result;
        }

        //-------------------------------------------------------------
        private int? GetIdChampOptimFromFormule(C2iExpression formule)
        {
            C2iExpressionChamp exp = formule as C2iExpressionChamp;
            if (exp != null)
            {
                //TESTDBKEYOK
                CDefinitionProprieteDynamiqueChampCustom prop = exp.DefinitionPropriete as CDefinitionProprieteDynamiqueChampCustom;
                if (prop != null)
                    return CChampCustom.GetIdFromDbKey(prop.DbKeyChamp);
            }
            return null;

        }
                

        //-------------------------------------------------------------
        public CResultAErreur GenereItems(CMapDatabase database, CContexteDonnee ctxDonnee)
        {
            CResultAErreur result = CResultAErreur.True;
            //Calcule les éléments à générer
            if (Filtre == null || Filtre.TypeElements == null)
                return result;
            if ( FormuleLatitude == null || FormuleLongitude == null )
                return result;
            result = Filtre.GetFiltreData();
            if (!result)
                return result;
            CFiltreData filtre = result.Data as CFiltreData;
            CListeObjetsDonnees lstObjets = new CListeObjetsDonnees(ctxDonnee, Filtre.TypeElements);
            lstObjets.Filtre = filtre;
            lstObjets.ModeSansTri = true;

            CMapLayer layer = null;
            if (lstObjets.Count > 0)
                layer = database.GetLayer(Generator.LayerId, true);
            else
                return result;

            int? nIdChampLatitude = null;
            int? nIdChampLongitude = null;
            Dictionary<int, double> dicValeursLatitude = new Dictionary<int, double>();
            Dictionary<int, double> dicValeursLongitude = new Dictionary<int, double>();

            if (typeof(IObjetDonneeAChamps).IsAssignableFrom(lstObjets.TypeObjets))
            {
                nIdChampLatitude = GetIdChampOptimFromFormule(FormuleLatitude);
                nIdChampLongitude = GetIdChampOptimFromFormule(FormuleLongitude);
                List<int> lst = new List<int>();
                if (nIdChampLatitude != null)
                    lst.Add(nIdChampLatitude.Value);
                if (nIdChampLongitude != null)
                    lst.Add(nIdChampLongitude.Value);
                if (lst.Count > 0)
                    CUtilElementAChamps.ReadChampsCustom(lstObjets, lst.ToArray());
                DataTable table = ctxDonnee.Tables[((IObjetDonneeAChamps)lstObjets[0]).GetNomTableRelationToChamps()];
                if (table != null && (nIdChampLatitude != null || nIdChampLatitude != null))
                {
                    string strCle = ((CObjetDonneeAIdNumerique)lstObjets[0]).GetChampId();
                    string strFiltre = "";
                    if (nIdChampLatitude != null)
                        strFiltre = CChampCustom.c_champId + "=" + nIdChampLatitude.Value;
                    if (nIdChampLongitude != null)
                    {
                        if (strFiltre.Length > 0)
                            strFiltre += " or ";
                        strFiltre += CChampCustom.c_champId + "=" + nIdChampLongitude.Value;
                    }
                    DataRow[] rows = table.Select(strFiltre);
                    foreach (DataRow row in table.Rows)
                    {
                        if ((int)row[CChampCustom.c_champId] == nIdChampLatitude)
                            dicValeursLatitude[(int)row[strCle]] = (double)row[CRelationElementAChamp_ChampCustom.c_champValeurDouble];
                        else if ((int)row[CChampCustom.c_champId] == nIdChampLongitude)
                            dicValeursLongitude[(int)row[strCle]] = (double)row[CRelationElementAChamp_ChampCustom.c_champValeurDouble];
                    }
                }
            }
            else
            {
                nIdChampLatitude = null;
                nIdChampLongitude = null;
            }


            foreach (object obj in lstObjets)
            {
                DateTime dt = DateTime.Now;
                m_currentGeneratedItem = obj;
                CContexteEvaluationExpression ctxEval = new CContexteEvaluationExpression(obj);
                double? fLat = null; 
                double? fLong = null;
                if (nIdChampLatitude != null)
                {
                    double fTmp = 0;
                    if (dicValeursLatitude.TryGetValue(((CObjetDonneeAIdNumerique)obj).Id, out fTmp))
                        fLat = fTmp;
                }
                else
                {
                    result = FormuleLatitude.Eval(ctxEval);
                    if (result)
                    {
                        try
                        {
                            fLat = Convert.ToDouble(result.Data);
                        }
                        catch { }
                    }
                }
                if (fLat != null)
                {
                    if (nIdChampLongitude != null)
                    {
                        double fTmp = 0;
                        if (dicValeursLongitude.TryGetValue(((CObjetDonneeAIdNumerique)obj).Id, out fTmp))
                            fLong = fTmp;
                    }
                    else
                    {
                        result = FormuleLongitude.Eval(ctxEval);
                        if (result)
                        {
                            try
                            {
                                fLong = Convert.ToDouble(result.Data);
                            }
                            catch { }
                        }
                    }
                }
                TimeSpan sp = DateTime.Now - dt;
                if (obj is CObjetDonnee)
                {
                    //Console.WriteLine("Coord "+((CObjetDonnee)obj).DescriptionElement + " : " + sp.TotalMilliseconds);
                }
                if (fLong != null && fLat != null)
                {
                    foreach (CMapItemDessin mapItemDessin in ItemsDessin)
                    {
                        if (mapItemDessin.GenereItem(
                            obj, 
                            fLat.Value, 
                            fLong.Value, 
                            layer))
                            break;
                    }
                }
                sp = DateTime.Now - dt;
                if (obj is CObjetDonnee)
                {
                    //Console.WriteLine(((CObjetDonnee)obj).DescriptionElement + " : " + sp.TotalMilliseconds);
                }
            }

            return result;
        }

        //--------------------------------------------------------------
        public void OnMapItemClick(IMapItem itemClicked)
        {
            if (ActionSurClick != null && Generator != null)
                Generator.ExecuteAction(ActionSurClick, itemClicked);
        }

        //--------------------------------------------------------------
        public CDefinitionProprieteDynamique[] GetProprietesInstance()
        {
            if (TypeElementsDessines != null)
            {
                return new CDefinitionProprieteDynamique[]
                {
                    new CDefinitionCurrentItemMapPoint(this)
                };
            }
            return new CDefinitionProprieteDynamique[0];
        }

        
    }
}
