using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using futurocom.snmp.entitesnmp;
using sc2i.common;
using futurocom.supervision;
using sc2i.common.memorydb;
using System.Data;
using futurocom.snmp.Proxy;
using System.Timers;
using System.IO;
using System.Reflection;
using futurocom.snmp.polling;

namespace futurocom.snmp.mediation
{
    
    /// <summary>
    /// Gère la configuration d'un service de médiation,
    /// tous les types d'alarmes,
    /// tous les types d'agent
    /// Les agents SNMP gerés
    /// </summary>
    public class CConfigurationServiceMediation : 
        MarshalByRefObject, 
        IBaseTypesAlarmes,
        IFournisseurElementsManquantsPourMemoryDb,
        IBaseFiltrageAlarmes
    {
        private enum EModeUpdateAFaire
        {
            None,//Pas de mise à jour en attente
            Partial,//Ne récuperer que les différence
            Full//Mise à jour totale demandée
        }

        private CMemoryDb m_database = new CMemoryDb();
        private int m_nIdLastSyncSessionConnue = -1;
        
        private EModeUpdateAFaire m_updateAFaire = EModeUpdateAFaire.None;

        private Timer m_timerMiseAJour = null;

        //----------------------------------------------------------
        public CConfigurationServiceMediation()
        {
            ReadConfig();
            CAppeleurFonctionAvecDelai.CallFonctionAvecDelai(this, "MettreAJour", 30000, true, true);
        }

        //----------------------------------------------------------
        public CMemoryDb DataBase
        {
            get
            {
                if (m_database == null)
                {
                    m_database = new CMemoryDb();
                    RegisterAllTypesInDb();
                }
                return m_database;
            }
        }

        //----------------------------------------------------------
        private void RegisterAllTypesInDb()
        {
            foreach (Assembly ass in CGestionnaireAssemblies.GetAssemblies())
            {
                foreach (Type tp in ass.GetTypes())
                {
                    if (typeof(CEntiteDeMemoryDb).IsAssignableFrom(tp) && !tp.IsAbstract)
                        m_database.GetTable(tp);
                }
            }
        }

        //----------------------------------------------------------
        public int LastSyncSessionConnue
        {
            get
            {
                return m_nIdLastSyncSessionConnue;
            }
        }

        //---------------------------------------------------
        private bool m_bUpdateEnCours = false;
        public void MettreAJour(bool bMAJTotale, bool bDiffere)
        {
            if (!bDiffere)
            {
                if (m_bUpdateEnCours)
                    return;
                try
                {
                    m_bUpdateEnCours = true;
                    IDonneeSynchronisationMediation donneesSynchro = CSnmpConnexion.DefaultInstance.GetDonneesPourSynchro(IdProxy, bMAJTotale?-1:m_nIdLastSyncSessionConnue);
                     if (donneesSynchro == null)
                        return;
                    CMemoryDb destDb = DataBase;
                    if (bMAJTotale)
                        destDb = new CMemoryDb();
                    CMemoryDb sourceDB = donneesSynchro.Database;
                    DateTime dt = DateTime.Now;
                    destDb.Importe(sourceDB);
                    TimeSpan sp = DateTime.Now - dt;
                    Console.WriteLine("Update médiation (full = " + bMAJTotale + ") : " + sp.TotalMilliseconds);

                    if (bMAJTotale)
                    {
                        m_database = destDb;
                        RegisterAllTypesInDb();
                    }
                    CServiceMediation.GetDefaultInstance().OnChangementDansBaseConfiguration();
                    m_nIdLastSyncSessionConnue = donneesSynchro.IdSyncSessionDesDonnees;
                    SaveConfig();
                    CServiceMediation.GetDefaultInstance().Trace.Write("Mediation service updated "+m_updateAFaire.ToString(), ALTRACE.TRACE, ALTRACE.DEBUG);
                    m_updateAFaire = EModeUpdateAFaire.None;
                    CSnmpPollingService.Configuration = this;
                    
                }
                catch (Exception e )
                { 
                }
                finally
                {
                    m_bUpdateEnCours = false;
                }
            }
            else
            {
                m_updateAFaire = bMAJTotale ? EModeUpdateAFaire.Full : EModeUpdateAFaire.Partial;
                if (m_timerMiseAJour == null)
                {
                    m_timerMiseAJour = new Timer(5000);
                    m_timerMiseAJour.Elapsed += new ElapsedEventHandler(m_timerMiseAJour_Elapsed);
                }
                m_timerMiseAJour.Start();
            }
        }

        //----------------------------------------------------------
        private void  m_timerMiseAJour_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (m_updateAFaire != EModeUpdateAFaire.None)
            {
                try
                {
                    m_timerMiseAJour.Stop();
                    MettreAJour(m_updateAFaire == EModeUpdateAFaire.Full, false);
                }
                catch
                {

                }
                finally
                {
                    m_timerMiseAJour.Start();
                }
            }
        } 
        
        //----------------------------------------------------------
        public int IdProxy
        {
            get
            {
                return CSnmpProxyConfiguration.GetInstance().IdProxyConfiguré;
            }
        }


        //----------------------------------------------------------
        public T GetEntite<T>(string strId)
            where T : CEntiteDeMemoryDb
        {
            return DataBase.GetEntite<T>(strId);
        }

        //----------------------------------------------------------
        public CResultAErreur RemoveEntite(Type tp, string strId)
        {
            return DataBase.RemoveEntite(tp, strId);
        }

        //----------------------------------------------------------
        public CResultAErreur UpdateEntite(CEntiteDeMemoryDb entite)
        {
            return DataBase.UpdateEntite(entite);
        }


        //----------------------------------------------------------
        public IEnumerable<CAgentSnmpPourSupervision> GetAgents(CTypeAgentPourSupervision typeAgent)
        {
            CListeEntitesDeMemoryDb<CAgentSnmpPourSupervision> lst = new CListeEntitesDeMemoryDb<CAgentSnmpPourSupervision>(DataBase, 
                new CFiltreMemoryDb ( CTypeAgentPourSupervision.c_champId+"=@1", typeAgent.Id ));
            return lst;
        }


        //----------------------------------------------------------
        public IEnumerable<CAgentSnmpPourSupervision> GetAgentsForIp(string strIp)
        {
            CListeEntitesDeMemoryDb<CAgentSnmpPourSupervision> lst = new CListeEntitesDeMemoryDb<CAgentSnmpPourSupervision>(DataBase,
                new CFiltreMemoryDb(CAgentSnmpPourSupervision.c_champIp + "=@1 or "+
                    CAgentSnmpPourSupervision.c_champTrapsIp+" like @2",
                    strIp,
                    "%,"+strIp+",%"));
            return lst;
        }


                    
        //----------------------------------------------------------
        public IEnumerable<CLocalTypeAlarme> TypesAlarmes
        {
            get { 
                CListeEntitesDeMemoryDb<CLocalTypeAlarme> lst = new CListeEntitesDeMemoryDb<CLocalTypeAlarme>(DataBase);
            return lst.ToArray();

            }
        }

        //----------------------------------------------------------
        public CLocalTypeAlarme GetTypeAlarme(string strIdTypeAlarme)
        {
            return DataBase.GetEntite<CLocalTypeAlarme>(strIdTypeAlarme);
        }


        #region IFournisseurElementsManquantsPourMemoryDb Membres

        //---------------------------------------------------------------------------------
        public CEntiteDeMemoryDb GetEntite(Type typeEntite, string strId, CMemoryDb db)
        {
            string strTable = DataBase.GetTableNameForType(typeEntite);
            if (strTable != null && DataBase.Tables[strTable] != null)
            {
                CEntiteDeMemoryDb ett = Activator.CreateInstance(typeEntite, DataBase) as CEntiteDeMemoryDb;
                if (ett.ReadIfExist(strId))
                {
                    return db.ImporteObjet(ett, true, false);
                }
            } 
            return null;
        }
        
        
        //---------------------------------------------------------------------------------
        private string GetConfigFileName()
        {
            string strRep = AppDomain.CurrentDomain.BaseDirectory;
            if (strRep[strRep.Length - 1] != '\\')
                strRep += "\\";
            strRep += "MEDIATION.DATA";
            return strRep;
        }

        //---------------------------------------------------------------------------------
        public Type[] TypesFournis
        {
            get 
            {
                List<Type> lstTypes = new List<Type>();
                foreach (DataTable table in DataBase.Tables)
                {
                    Type tp = DataBase.GetTypeForTable(table.TableName);
                    if (tp != null)
                        lstTypes.Add(tp);
                }
                return lstTypes.ToArray();
            }
        }

        #endregion

        //---------------------------------------------------------------------------------
        public CResultAErreur SaveConfig()
        {
            CResultAErreur result = CResultAErreur.True;

            string strFileTmp = GetConfigFileName()+".tmp";
            result = CSerializerObjetInFile.SaveToFile(DataBase, "FUT_MEDIATION_DATA", strFileTmp);
            if (result)
            {
                File.Delete(GetConfigFileName());
                File.Move(strFileTmp, GetConfigFileName());
            }
            return result;
        }

        //---------------------------------------------------------------------------------
        public CResultAErreur ReadConfig()
        {
            CResultAErreur result = CResultAErreur.True;
            CMemoryDb db = new CMemoryDb();

            result = CSerializerObjetInFile.ReadFromFile(db, "FUT_MEDIATION_DATA", GetConfigFileName());
            if (result)
            {
                m_database = db;
                RegisterAllTypesInDb();
            }
            return result;
        }

        #region IBaseFiltrageAlarmes Membres

        public IEnumerable<CLocalParametrageFiltrageAlarmes> ParametresFiltrage
        {
            get
            {
                CListeEntitesDeMemoryDb<CLocalParametrageFiltrageAlarmes> lst = new CListeEntitesDeMemoryDb<CLocalParametrageFiltrageAlarmes>(DataBase);
                return lst;
            }
        }

        #endregion
    }
}
