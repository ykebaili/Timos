using System;
using System.Collections;
using System.Text;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;

using timos.data;
using System.Data;

namespace timos.data.serveur
{
    /// <summary>
    /// Description résumée 
    /// </summary>
    public class CIntervention_IntervenantServeur : CObjetDonneeServeurAvecCache
    {
        //-------------------------------------------------------------------
        public CIntervention_IntervenantServeur(int nIdSession)
			:base ( nIdSession )
		{
		}

		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CIntervention_Intervenant.c_nomTable;
		}

		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			
            try
			{
                CIntervention_Intervenant relation = (CIntervention_Intervenant)objet;
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
            return typeof(CIntervention_Intervenant);
		}
		//-------------------------------------------------------------------
		public override CResultAErreur TraitementAvantSauvegarde(CContexteDonnee contexte)
		{
			CResultAErreur result = base.TraitementAvantSauvegarde(contexte);
			DataTable table = contexte.Tables[GetNomTable()];
			foreach (DataRow row in new ArrayList(table.Rows))
			{
				if (row.RowState == DataRowState.Modified || row.RowState == DataRowState.Added)
				{
					CIntervention_Intervenant rel = new CIntervention_Intervenant(row);
					foreach (CFractionIntervention fraction in rel.Intervention.Fractions)
						fraction.ForceChangementSyncSession();
                    if (rel.RelationProfil == null && rel.Intervention != null && rel.Intervention.TypeIntervention != null &&
                        rel.Intervention.TypeIntervention.RelationsProfilsIntervenants.Count > 0)
                    {
                        rel.RelationProfil = rel.Intervention.TypeIntervention.RelationsProfilsIntervenants[0] as CTypeIntervention_ProfilIntervenant;
                    }
                    if (rel.Intervenant == null)
                        rel.Delete(true);
				}
			}
			return result;
		}
    }
}
