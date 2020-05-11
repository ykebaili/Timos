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
    public class CIntervention_ActiviteActeurServeur : CObjetDonneeServeurAvecCache
    {
        //-------------------------------------------------------------------
        public CIntervention_ActiviteActeurServeur(int nIdSession)
			:base ( nIdSession )
		{
		}

		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CIntervention_ActiviteActeur.c_nomTable;
		}

		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			
            try
			{
                CIntervention_ActiviteActeur relation = (CIntervention_ActiviteActeur)objet;
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
            return typeof(CIntervention_ActiviteActeur);
		}
		//-------------------------------------------------------------------
        public override CResultAErreur TraitementAvantSauvegarde(CContexteDonnee contexte)
        {
            CResultAErreur result =  base.TraitementAvantSauvegarde(contexte);
            if (!result)
                return result;
            DataTable table = contexte.Tables[GetNomTable()];
            if (table == null)
                return result;
            foreach (DataRow row in new ArrayList(table.Rows))
            {
                if (row.RowState == DataRowState.Deleted)
                {
                    CIntervention_ActiviteActeur rel = new CIntervention_ActiviteActeur(row);
                    rel.VersionToReturn = DataRowVersion.Original;
                    CActiviteActeur act = rel.ActiviteActeur;
                    if (act.Row.RowState != null && rel.DureeImputee != 0)
                    {
                        act.Duree -= rel.DureeImputee;
                    }
                    if (act.Duree == 0)
                        act.Delete(true);
                }
            }
            return result;


        }
    }
}
