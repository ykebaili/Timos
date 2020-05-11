using System;
using System.Collections;
using System.Data;
using sc2i.data;
using sc2i.common;
using sc2i.data.serveur;
using spv.data;

namespace spv.data.serveur
{
	public class CSpvMessalrmServeur : CObjetServeur
	{
		
		///////////////////////////////////////////////////////////////
		public CSpvMessalrmServeur ( int nIdSession )
			:base(nIdSession)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public override string GetNomTable()
		{
			return CSpvMessalrm.c_nomTable;
		}

        ///////////////////////////////////////////////////////////////
        public override bool ActivateQueryCache
        {
            get
            {
                return false;
            }
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
			return typeof(CSpvMessalrm);
		}


		public override CResultAErreur BeforeSave(CContexteSauvegardeObjetsDonnees contexte, IDataAdapter adapter, DataRowState etatsAPrendreEnCompte)
		{
			CResultAErreur result = base.BeforeSave(contexte, adapter, etatsAPrendreEnCompte);
			if (!result)
				return result;

			DataTable table = contexte.ContexteDonnee.Tables[GetNomTable()];
			if (table == null)
				return result;

			ArrayList lstRows = new System.Collections.ArrayList(table.Rows);
			foreach (DataRow row in lstRows)
			{

				if (row.RowState == DataRowState.Added)
				{
					// Remplacement dans le message de la chaîne de caractère
					// CSpvMessalrm.c_CompleterMessId par l'ID du message
					CSpvMessalrm spvMessalrm = new CSpvMessalrm(row);
					string strMess = spvMessalrm.MessalrmMessage;
					int nPos = strMess.IndexOf(CSpvMessalrm.c_CompleterMessId);
					if (nPos < 0)
					{
						result.EmpileErreur(I.T("MessAlrm format not compliant"));
						return result;
					}

					strMess = spvMessalrm.MessalrmMessage.Substring(0, nPos)
							+ spvMessalrm.Id.ToString()
							+ spvMessalrm.MessalrmMessage.Substring(nPos + CSpvMessalrm.c_CompleterMessId.Length);

					spvMessalrm.MessalrmMessage = strMess;
				}
			}
			return result;
		}
	}
}
