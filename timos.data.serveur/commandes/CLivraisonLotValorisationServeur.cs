using System;
using System.Collections;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.acteurs;
using System.Data;
using System.Collections.Generic;

namespace timos.data.commandes.serveur
{
	/// <summary>
	/// Description rÃ©sumÃ©e de CLivraisonLotValorisationServeur.
	/// </summary>
	public class CLivraisonLotValorisationServeur : CObjetDonneeServeurAvecCache
	{
		//-------------------------------------------------------------------
#if PDA
		public CLivraisonLotValorisationServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CLivraisonLotValorisationServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CLivraisonLotValorisation.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CLivraisonLotValorisation rel = (CLivraisonLotValorisation)objet;
                if ( rel.Livraison == null )
                    result.EmpileErreur(I.T("Link between delivery and valuation lot must be linked to a delivery|20173"));
                if ( rel.LotDeValorisation== null )
                    result.EmpileErreur(I.T("Link between delivery and valuation lot must be linked to a valuation lot|20174"));

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
			return typeof(CLivraisonLotValorisation);
		}
		
        //-------------------------------------------------------------------
        public override CResultAErreur TraitementAvantSauvegarde(CContexteDonnee contexte)
        {
            CResultAErreur result =  base.TraitementAvantSauvegarde(contexte);
            if (!result)
                return result;
            DataTable table = contexte.Tables[GetNomTable()];
            ArrayList lst = new ArrayList(table.Rows);
            HashSet<CLivraisonEquipement> livraisonsPourValorisation = new HashSet<CLivraisonEquipement>();
            foreach (DataRow row in lst)
            {
                if (row.RowState != DataRowState.Unchanged)
                {
                    CLivraisonLotValorisation livLot = new CLivraisonLotValorisation(row);
                    if (row.RowState == DataRowState.Deleted)
                        livLot.VersionToReturn = DataRowVersion.Original;
                    try
                    {
                        CLivraisonEquipement livraison = livLot.Livraison;
                        if (livraison.IsValide())
                            livraisonsPourValorisation.Add(livraison);
                    }
                    catch { }
                }
            }
            foreach (CLivraisonEquipement liv in livraisonsPourValorisation)
            {
                liv.AppliqueValorisation();
            }
            return result;
        }
	}
}
