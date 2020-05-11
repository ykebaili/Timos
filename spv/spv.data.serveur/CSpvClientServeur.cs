using System;
using System.Data;
using System.Collections;

using sc2i.data;
using sc2i.common;
using sc2i.data.serveur;
using spv.data;
using timos.data;
using timos.acteurs;

namespace spv.data.serveur
{
    [AutoExec("Autoexec")]
    public class CSpvClientServeur : CObjetServeur
	{

        public static void Autoexec()
        {
     //       RegisterPropagation();
            CGestionnaireHookTraitementAvantSauvegarde.RegisterHook(typeof(CDonneesActeurClient), PropagerCDonneesActeurClient);
            CGestionnaireHookTraitementAvantSauvegarde.RegisterHook(typeof(CActeur), PropagerModifsActeur);
        }

		///////////////////////////////////////////////////////////////
		public CSpvClientServeur ( int nIdSession )
			:base(nIdSession)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public override string GetNomTable()
		{
			return CSpvClient.c_nomTable;
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
			return typeof(CSpvClient);
		}

        ////////////////////////////////////////////////////////////////////
        public static void PropagerCDonneesActeurClient(CContexteDonnee contexte, Hashtable tableData, ref CResultAErreur result)
        {
            DataTable dt = contexte.Tables[CDonneesActeurClient.c_nomTable];
            if (dt != null)
            {
                ArrayList rows = new ArrayList(dt.Rows);
                CSpvClient spvClient;

                foreach (DataRow row in rows)
                {
                    if (row.RowState != DataRowState.Unchanged)
                    {
                        CDonneesActeurClient client = new CDonneesActeurClient(row);
                        switch (row.RowState)
                        {
                            case DataRowState.Added:
                            case DataRowState.Modified:
                                spvClient = CSpvClient.GetObjetSpvFromObjetTimosAvecCreation(client);
                                if (spvClient != null)
                                    spvClient.CopyFromObjetTimos(client);
                                break;

                            case DataRowState.Deleted:

                                spvClient = CSpvClient.GetObjetSpvFromObjetTimosAvecCreation(client);
                                if ((int)spvClient.Row[CSpvClient.c_champCLIENT_ID, DataRowVersion.Original] == CSpvClient.c_ClientSystemeId)
                                    result.EmpileErreur(I.T("'Client Système' could not be deleted|50019"));

                                break;

                            default:
                                break;
                        }
                    }
                }
            }
        }

        ////////////////////////////////////////////////////////////////////
        public static void PropagerModifsActeur(CContexteDonnee contexte, Hashtable tableData, ref CResultAErreur result)
        {
            DataTable table = contexte.Tables[CActeur.c_nomTable];
            if (table == null)
                return;
            ArrayList lst = new ArrayList(table.Rows);
            foreach (DataRow row in table.Rows)
            {
                if (row.RowState == DataRowState.Modified)
                {
                    CActeur acteur = new CActeur(row);
                    CDonneesActeurClient client = acteur.Client;
                    if (client != null)
                    {
                        CSpvClient spvClient = CSpvClient.GetObjetSpvFromObjetTimosAvecCreation(client);
                        if (spvClient != null)
                            spvClient.CopyFromObjetTimos(client);
                    }
                }
                else if (row.RowState == DataRowState.Deleted)
                {
                    CActeur acteur = new CActeur(row);
                    acteur.VersionToReturn = DataRowVersion.Original;
                    CDonneesActeurClient client = acteur.Client;
                    if (client != null)
                    {
                        CSpvClient spvClient = CSpvClient.GetObjetSpvFromObjetTimosAvecCreation(client);
                        if ((int)spvClient.Row[CSpvClient.c_champCLIENT_ID, DataRowVersion.Original] == CSpvClient.c_ClientSystemeId)
                            result.EmpileErreur(I.T("'Client Système' could not be deleted|50019"));
                    }
                }
            }
        }
	}
}
