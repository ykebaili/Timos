using System;
using System.Collections;
using System.Text;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;

using timos.data;
using timos.acteurs;
using System.Data;

namespace timos.data.serveur
{
    /// <summary>
    /// Description résumée de CActiviteActeurResumeServeur.
    /// </summary>
    public class CActiviteActeurResumeServeur : CObjetServeur
    {
        //-------------------------------------------------------------------
        public CActiviteActeurResumeServeur(int nIdSession)
			:base ( nIdSession )
		{
		}

		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CActiviteActeurResume.c_nomTable;
		}

		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			
            try
			{
                CActiviteActeurResume ActiviteActeurResume = (CActiviteActeurResume)objet;

		
			}
			catch ( Exception e )
			{
				result.EmpileErreur( new CErreurException ( e ) );
			}
            
			return result;
		}

		//-------------------------------------------------------------------
		public override Type GetTypeObjets()
		{
            return typeof(CActiviteActeurResume);
		}

		//-------------------------------------------------------------------
		public override CResultAErreur TraitementAvantSauvegarde(CContexteDonnee contexte)
		{
			CResultAErreur result = base.TraitementAvantSauvegarde(contexte);
			if (!result)
				return result;
			DataTable table = contexte.Tables[GetNomTable()];
			if (table == null)
				return result;
			ArrayList lstRows = new ArrayList(table.Rows);
			foreach (DataRow row in lstRows)
			{
				if (row.RowState == DataRowState.Modified || row.RowState == DataRowState.Added)
				{
					CActiviteActeurResume resume = new CActiviteActeurResume(row);

                    bool bOriginalReadOnly = false;
                    if (row.RowState == DataRowState.Modified)
                    {
                        DataRowVersion versionSave = resume.VersionToReturn;
                        resume.VersionToReturn = DataRowVersion.Original;
                        bOriginalReadOnly = resume.ReadOnly;
                        resume.VersionToReturn = versionSave;
                    }
                    if (resume.ReadOnly && bOriginalReadOnly)
                    {
                        result.EmpileErreur(I.T("The Member Activity Summary for : @1, at @2 cannot be modified (set to Read Only)|10001",
                            resume.Acteur.IdentiteCompleteAmelioree,
                            resume.Date.ToString("d")));
                        return result;
                    }
					if (resume.Activites.Count == 0)
					{
						result = resume.Delete();
						if (!result)
							return result;
					}


				}
			}
			return result;
		}

		
    }
}
