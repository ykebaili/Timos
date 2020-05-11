using System;
using System.Data;
using sc2i.data;
using sc2i.common;
using sc2i.data.serveur;
using spv.data;
using System.Collections;

namespace spv.data.serveur
{
	public class CSpvAccesAlarmeServeur : CObjetServeur
	{
		
		///////////////////////////////////////////////////////////////
        public CSpvAccesAlarmeServeur(int nIdSession)
			:base(nIdSession)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public override string GetNomTable()
		{
			return CSpvAccesAlarme.c_nomTable;
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
			return typeof(CSpvAccesAlarme);
		}


        ///////////////////////////////////////////////////////////////
        public override CResultAErreur TraitementAvantSauvegarde(CContexteDonnee contexte)
        {
            CResultAErreur result = base.TraitementAvantSauvegarde(contexte);
            if (!result)
                return result;

            DataTable table = contexte.Tables[GetNomTable()];
            if (table == null)
                return result;

            ArrayList lstRows = new System.Collections.ArrayList(table.Rows);
            foreach (DataRow row in lstRows)
            {
                if (row.RowState == DataRowState.Added || row.RowState == DataRowState.Modified)
                {
                    CSpvAccesAlarme spvAccesAlarme = new CSpvAccesAlarme(row);
                    //spvAccesAlarme.CalculeUnicite();

                    if (row.RowState == DataRowState.Added &&
                        spvAccesAlarme.CategorieAccesAlarme == ECategorieAccesAlarme.TrapSnmp &&
                        spvAccesAlarme.Acces_AccescsOne.Count <= 0)
                    {
                        result = spvAccesAlarme.GenAccesAccescForTrap();
                        if (!result)
                            return result;
                    }
                }
            }

            return result;
        }


        protected override CFiltreData GetMyFiltreSysteme()
        {
            return new CFiltreData(CSpvTypeAccesAlarme.c_champACCES_CATEGORIE + " IN (@1, @2, @3, @4, @5)",
                  ECategorieAccesAlarme.AlarmeGSite, ECategorieAccesAlarme.CommandeCommut,
                  ECategorieAccesAlarme.EntreeBoucle, ECategorieAccesAlarme.SortieBoucle,
                  ECategorieAccesAlarme.TrapSnmp);
        }

	}
}
