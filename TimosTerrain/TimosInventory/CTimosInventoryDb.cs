using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common.memorydb;
using System.IO;
using sc2i.common;
using sc2i.win32.common;
using TimosInventory.data.releve;

namespace TimosInventory
{
    public static class CTimosInventoryDb
    {
        public static string c_cleFichierTimos = "TIMOS_INVENTORY_DATA";
        public static string c_cleFichierInventaire = "TIMOS_INVENTORY_SURVEY_DATA";
        
        private static CMemoryDb m_dbTimos = null;
        private static CReleveDb m_dbReleve = null;


        //-------------------------------------------------
        public static string GetNomFichierTimosData()
        {
            string strPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            if (strPath[strPath.Length - 1] != '\\')
                strPath += "\\";
            strPath += "TimosInventory\\TimosData.dat";
            CUtilRepertoire.AssureRepertoirePourFichier(strPath);
            return strPath;
        }

        //-------------------------------------------------
        public static string GetNomFichierSurvey()
        {
            string strPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            if (strPath[strPath.Length - 1] != '\\')
                strPath += "\\";
            strPath += "TimosInventory\\TimosSurvey.dat";
            CUtilRepertoire.AssureRepertoirePourFichier(strPath);
            return strPath;
        }

        //-------------------------------------------------
        public static CMemoryDb GetTimosDatas()
        {
            if ( m_dbTimos != null )
                return m_dbTimos;
            m_dbTimos = new CMemoryDb();
            if ( File.Exists ( GetNomFichierTimosData() ))
            {
                /*try
                {
                    m_dbTimos.ReadXml(GetNomFichierTimosData(), System.Data.XmlReadMode.Auto);
                }
                catch (Exception e)
                {
                    CResultAErreur result = CResultAErreur.True;
                    result.EmpileErreur(new CErreurException(e));
                    result.EmpileErreur(I.T("Can not read data|20007"));
                    CFormAlerte.Afficher(result.Erreur);
                    m_dbTimos = new CMemoryDb();
                }
            }*/

                DateTime dt = DateTime.Now;
                CResultAErreur result = CSerializerObjetInFile.ReadFromFile(m_dbTimos, c_cleFichierTimos, GetNomFichierTimosData() );
                TimeSpan sp = DateTime.Now - dt;
                System.Console.WriteLine("Read dbTimos : " + sp.TotalMilliseconds);
                if ( !result )
                {
                    result.EmpileErreur(I.T("Can not read data|20007"));
                    CFormAlerte.Afficher(result.Erreur);
                    m_dbTimos = new CMemoryDb();
                }
            }
            return m_dbTimos;
        }

        //-------------------------------------------------
        public static CReleveDb GetInventaireDatas()
        {
            if (m_dbReleve != null)
                return m_dbReleve;
            m_dbReleve = new CReleveDb(m_dbTimos);
            if (File.Exists(GetNomFichierSurvey()))
            {
                /*try
                {
                    m_dbReleve.ReadXml(GetNomFichierSurvey(), System.Data.XmlReadMode.Auto);
                }
                catch (Exception e)
                {
                    CResultAErreur result = CResultAErreur.True;
                    result.EmpileErreur(new CErreurException(e));
                    result.EmpileErreur(I.T("Can not read data|20007"));
                    CFormAlerte.Afficher(result.Erreur);
                    m_dbTimos = new CMemoryDb();
                }
                */
                DateTime dt = DateTime.Now;
                CResultAErreur result = CSerializerObjetInFile.ReadFromFile(m_dbReleve, c_cleFichierInventaire, GetNomFichierSurvey());
                TimeSpan sp = DateTime.Now - dt;
                System.Console.WriteLine("Read survey : " + sp.TotalMilliseconds);
                if (!result)
                {
                    result.EmpileErreur(I.T("Can not read data|20007"));
                    CFormAlerte.Afficher(result.Erreur);
                    m_dbReleve = new CReleveDb(m_dbTimos);
                }
            }
            return m_dbReleve;
        }

        //-------------------------------------------------
        public static void SetDbTimos(CMemoryDb db)
        {
            m_dbTimos = db;
            db.AcceptChanges();
            DateTime dt = DateTime.Now;
            GetInventaireDatas().TimosDb = db;
            //m_dbTimos.WriteXml(GetNomFichierTimosData(), System.Data.XmlWriteMode.WriteSchema);
            CSerializerObjetInFile.SaveToFile(m_dbTimos, c_cleFichierTimos, GetNomFichierTimosData());
            TimeSpan sp = DateTime.Now - dt;
            System.Console.WriteLine("Save dbTimos : " + sp.TotalMilliseconds);
        }

        //-------------------------------------------------
        public static void SetDbInventaire(CReleveDb db)
        {
            m_dbReleve = db;
            db.AcceptChanges();
            DateTime dt = DateTime.Now;
            CSerializerObjetInFile.SaveToFile(m_dbReleve, c_cleFichierInventaire, GetNomFichierSurvey());
            //m_dbReleve.WriteXml(GetNomFichierSurvey(), System.Data.XmlWriteMode.WriteSchema);
            db.AcceptChanges();
            TimeSpan sp = DateTime.Now - dt;
            System.Console.WriteLine("Save dbSurvey : " + sp.TotalMilliseconds);
        }
    }
}
