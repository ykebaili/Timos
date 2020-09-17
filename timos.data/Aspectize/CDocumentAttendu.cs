using sc2i.data.dynamic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sc2i.common;
using sc2i.documents;
using sc2i.data;
using sc2i.data.dynamic.NommageEntite;

namespace timos.data.Aspectize
{
    public class CDocumentAttendu : IEntiteTimosWebApp
    {
        public const string c_nomTable = "DocumentsAttendus";

        public const string c_champId = "TimosId";
        public const string c_champLibelle = "Libelle";
        public const string c_champIdCategorie = "IdCategorie";
        public const string c_champNombreMin = "NombreMin";
        public const string c_champDateLastUpload = "DateLastUpload";


        DataRow m_row;
        CCaracteristiqueEntite m_caracteristic;

        public CDocumentAttendu(DataSet ds, CCaracteristiqueEntite carac)
        {
            m_caracteristic = carac;
            DataTable dt = ds.Tables[c_nomTable];
            if (dt == null)
                return;

            DataRow row = dt.NewRow();
            int nIdCarac = -1;
            string strLibelle = "";
            int nIdCategorie = -1;
            int nbMin = 0;
            DateTime? dateLastUpload = null;

            if (carac != null)
            {
                row[c_champId] = carac.Id;
                CCategorieGED categorie = CategorieGED;
                if (categorie != null)
                {
                    row[c_champLibelle] = carac.Libelle == "" ? categorie.Libelle : carac.Libelle;
                    row[c_champIdCategorie] = categorie.Id;
                }
                else
                {
                    row[c_champLibelle] = carac.Libelle;
                    row[c_champIdCategorie] = -1;
                }
                row[c_champNombreMin] = nbMin;
                if (dateLastUpload == null)
                    row[c_champDateLastUpload] = DBNull.Value;
                else
                    row[c_champDateLastUpload] = dateLastUpload.Value;
            }

            m_row = row;
            dt.Rows.Add(row);
        }

        public DataRow Row
        {
            get
            {
                return m_row;
            }
        }

        //------------------------------------------------------------------------------------------------
        public static DataTable GetStructureTable()
        {
            DataTable dt = new DataTable(c_nomTable);

            dt.Columns.Add(c_champId, typeof(int));
            dt.Columns.Add(c_champLibelle, typeof(string));
            dt.Columns.Add(c_champIdCategorie, typeof(int));
            dt.Columns.Add(c_champNombreMin, typeof(int));
            dt.Columns.Add(c_champDateLastUpload, typeof(DateTime));

            return dt;
        }

        //----------------------------------------------------------------------------------------------------
        public CResultAErreur FillDataSet(DataSet ds)
        {
            CResultAErreur result = CResultAErreur.True;
            if (CategorieGED == null)
                return result;

            CDocumentGED[] listeGED = CDocumentGED.GetListeDocumentsForElement(m_caracteristic).ToArray<CDocumentGED>();
            foreach (CDocumentGED ged in listeGED)
            {
                bool bOK = false;
                foreach (CRelationDocumentGED_Categorie relCat in ged.RelationsCategories)
                {
                    if (relCat.Categorie.Id == CategorieGED.Id)
                    {
                        bOK = true;
                        break;
                    }
                }
                if (bOK)
                {
                    CFichierAttache fichier = new CFichierAttache(ds, ged);
                    fichier.DocumentId = m_caracteristic.Id;

                }
            }

            return result;
        }

        //-----------------------------------------------------------------------------------------------------
        private CCategorieGED CategorieGED
        {
            get
            {
                if (m_caracteristic == null)
                    return null;

                try
                {
                    int nIdChampCategorieDocument = CTimosWebAppRegistre.IdChampCategorieDocuement; 
                   
                    if (nIdChampCategorieDocument > 0)
                    {
                        var valeurChamp = m_caracteristic.GetValeurChamp(nIdChampCategorieDocument);
                        if (valeurChamp is CCategorieGED)
                            return valeurChamp as CCategorieGED;
                    }
                }
                catch
                { }

                return null;
            }
        }
    }
}
