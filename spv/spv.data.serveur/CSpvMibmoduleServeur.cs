using System;
using System.Data;
using sc2i.data;
using sc2i.common;
using sc2i.data.serveur;
using spv.data;
using sc2i.documents;
using System.Collections.Generic;
using sc2i.multitiers.client;
using SpvNativeWrapper;

namespace spv.data.serveur
{
	public class CSpvMibmoduleServeur : CObjetServeur, ISpvMibModuleServeur
	{
		
		///////////////////////////////////////////////////////////////
		public CSpvMibmoduleServeur ( int nIdSession )
			:base(nIdSession)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public override string GetNomTable()
		{
			return CSpvMibmodule.c_nomTable;
		}
		
		///////////////////////////////////////////////////////////////
		public override CResultAErreur VerifieDonnees ( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				//TODO : Insérer la logique de vérification de donnée
			}
			catch ( Exception e )
			{
				result.EmpileErreur( new CErreurException ( e ) );
			}
			return result;
		}
		
		///////////////////////////////////////////////////////////////
		public override Type GetTypeObjets()
		{
			return typeof(CSpvMibmodule);
		}

        ///////////////////////////////////////////////////////////////
        public CResultAErreur Compile(int nIdMibModule)
        {
            CResultAErreur result = CResultAErreur.True;
            using (CContexteDonnee contexte = new CContexteDonnee(IdSession, true, false))
            {
                CSpvMibmodule mibModule = new CSpvMibmodule(contexte);
                if (!mibModule.ReadIfExists(nIdMibModule))
                {
                    result.EmpileErreur(I.T("Mib module @1 doesn't exists|20000", nIdMibModule.ToString()));
                    return result;
                }
                CDocumentGED doc = mibModule.DocumentGEDModuleMib;
                if (doc == null)
                {
                    result.EmpileErreur(I.T("Mib module @1 should be associated to a mib file|20001", mibModule.NomModuleOfficiel));
                    return result;
                }
                using (CProxyGED proxy = new CProxyGED(m_nIdSession, doc.ReferenceDoc))
                {
                    result = proxy.CopieFichierEnLocal();
                    if (!result)
                        return result;

                    CMibModuleWrapper mibModuleWrapper = new CMibModuleWrapper();
                    IDatabaseConnexion connexion = CSc2iDataServer.GetInstance().GetDatabaseConnexion(m_nIdSession, GetType());
                    string strConnexion = connexion.ConnexionString;
                    string strDatabase = "";
                    string strUser = "";
                    string strPassword = "";
                    string[] strRubriques = strConnexion.Split(';');
                    foreach (string strRubrique in strRubriques)
                    {
                        string[] strData = strRubrique.Split('=');
                        if (strData.Length == 2)
                        {
                            string strCle = strData[0].ToUpper().Trim();
                            if (strCle == "DATA SOURCE")
                                strDatabase = strData[1].Trim();
                            if (strCle == "USER ID")
                                strUser = strData[1].Trim();
                            if (strCle == "PASSWORD")
                                strPassword = strData[1].Trim();
                        }
                    }
                    if (strDatabase == "" || strUser == "" || strPassword == "")
                    {
                        result.EmpileErreur(I.T("Can not parse connexion string|20002"));
                        return result;
                    }
                            
                    string strConnexionOracle = strUser+"/"+strPassword+"@"+strDatabase;
                    mibModuleWrapper.Init(strConnexionOracle, proxy.NomFichierLocal,
                                          mibModule.NomModuleUtilisateur, Convert.ToInt32(mibModule.Id));

                    int nResult = mibModuleWrapper.Compile();
                    if (nResult < 0)
                    {
                        result.EmpileErreur(I.T("Failed to compile mib module @1|20003", mibModule.NomModuleOfficiel));
                        string strMess;
                        while ((strMess = mibModuleWrapper.GetNextErrMess()) != "")
                            result.EmpileErreur(strMess);

                        if (mibModuleWrapper.AreCompileErrors())
                            result.EmpileErreur(mibModuleWrapper.GetCompileErrors());

                        if (mibModuleWrapper.AreCompileLogs())
                            result.EmpileErreur(mibModuleWrapper.GetCompileLogs());
                        
                        return result;
                    }
                    else
                    {
                        List<IDonneeNotification> notifs = new List<IDonneeNotification>();
                        notifs.Add(new CDonneeNotificationAjoutEnregistrement(m_nIdSession, CSpvMibmodule.c_nomTable));
                        notifs.Add(new CDonneeNotificationAjoutEnregistrement(m_nIdSession, CSpvMibobj.c_nomTable));
                        CEnvoyeurNotification.EnvoieNotifications(notifs.ToArray());
                    }
                }

            }
            return result;
        }
    }
}
