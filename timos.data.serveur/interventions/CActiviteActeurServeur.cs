using System;
using System.Collections;
using System.Collections.Generic;
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
    /// Description résumée de CActiviteActeurServeur.
    /// </summary>
    public class CActiviteActeurServeur : CObjetServeur
    {
        //-------------------------------------------------------------------
        public CActiviteActeurServeur(int nIdSession)
			:base ( nIdSession )
		{
		}

		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CActiviteActeur.c_nomTable;
		}

		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			
            try
			{
                CActiviteActeur activiteActeur = (CActiviteActeur)objet;

		
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
            return typeof(CActiviteActeur);
		}


		///------------------------------------------------------------------------
		public override CResultAErreur TraitementAvantSauvegarde(CContexteDonnee contexte)
		{
			CResultAErreur result = base.TraitementAvantSauvegarde(contexte);
			if (!result)
				return result;
			DataTable table = contexte.Tables[GetNomTable()];
			if (table == null)
				return result;
			ArrayList lstRows = new ArrayList(table.Rows);
			Dictionary<CActiviteActeurResume, bool> listeARecalculer = new Dictionary<CActiviteActeurResume, bool>();
			foreach (DataRow row in lstRows)
			{
				if (row.RowState != DataRowState.Unchanged)
				{
					CActiviteActeur activite = new CActiviteActeur(row);
					CActiviteActeurResume resume = null;
					if (row.RowState == DataRowState.Deleted)
					{
                        DataRowVersion saveVersion = activite.VersionToReturn;
						activite.VersionToReturn = DataRowVersion.Original;
						resume = activite.ResumeActivite;
						if (resume != null && resume.IsValide())
							listeARecalculer[resume] = true;
                        activite.VersionToReturn = saveVersion;
					}
					else
					{
						resume = activite.ResumeActivite;
						if (resume != null)
						{
							listeARecalculer[resume] = true;
							if (resume.Date.Date != activite.Date.Date)
								resume = null;
						}
						if (resume == null)
						{
							//Cherche une activite pour cet acteur et ce jour
							resume = new CActiviteActeurResume(contexte);
							if (!resume.ReadIfExists(new CFiltreData(
								CActiviteActeurResume.c_champDate + ">=@1 and " +
								CActiviteActeurResume.c_champDate + "<@2 and " +
								CActeur.c_champId + "=@3",
								activite.Date.Date,
								activite.Date.Date.AddDays(1),
								activite.Acteur.Id)))
							{
								resume = new CActiviteActeurResume(contexte);
								resume.CreateNewInCurrentContexte();
								resume.Acteur = activite.Acteur;
								resume.Date = activite.Date.Date;
							}
							activite.SetResumeAssocie(resume);
							listeARecalculer[resume] = true;
						}
					}
				}
			}
            // Recalcul le cumul des heures des Activités résumés
			foreach (CActiviteActeurResume resume in listeARecalculer.Keys)
			{
				resume.Recalc();
			}
			return result;
		}

		
    }
}
