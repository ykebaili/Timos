using System;
using System.Collections;
using System.Text;
using System.Data;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;

using timos.data;
using timos.securite;
using System.Collections.Generic;

namespace timos.data.serveur
{
    /// <summary>
    /// Description rÃ©sumÃ©e 
    /// </summary>
    public class CReleveEquipementServeur : CObjetDonneeServeurAvecCache
    {
        //-------------------------------------------------------------------
        public CReleveEquipementServeur(int nIdSession)
			:base ( nIdSession )
		{
		}

		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CReleveEquipement.c_nomTable;
		}

		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			
            try
			{
                CReleveEquipement releve = objet as CReleveEquipement;
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
            return typeof(CReleveEquipement);
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
            HashSet<CReleveSite> relevesToCalc = new HashSet<CReleveSite>();
            ArrayList lst = new ArrayList();
            foreach (DataRow row in new ArrayList(table.Rows))
            {
                if (row.RowState == DataRowState.Added || row.RowState == DataRowState.Modified)
                {
                }
            }

            return result;
        }
		

    }
}
