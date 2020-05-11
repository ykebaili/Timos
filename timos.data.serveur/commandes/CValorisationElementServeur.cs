using System;
using System.Collections;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.acteurs;
using timos.data.equipement.consommables;
using System.Data;
using timos.data.projet.besoin;

namespace timos.data.commandes.serveur
{
	/// <summary>
	/// Description rÃ©sumÃ©e de CValorisationElementServeur.
	/// </summary>
	public class CValorisationElementServeur : CObjetDonneeServeurAvecCache
	{
		//-------------------------------------------------------------------
#if PDA
		public CValorisationElementServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CValorisationElementServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CValorisationElement.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CValorisationElement valorisationElement = (CValorisationElement)objet;
                if (valorisationElement.ElementValorisé == null)
                {
                    result.EmpileErreur(I.T("Valuation must be linked to an equipment or a consumable type|20171"));
                }
                if (valorisationElement.LotValorisation == null)
                    result.EmpileErreur(I.T("Valuation must be linked to a valuation lot|20172"));
                if (valorisationElement.TypeEquipement != null)
                {
                    CListeObjetsDonnees lstTmp = new CListeObjetDonneeGenerique<CValorisationElement>(objet.ContexteDonnee);
                    lstTmp.Filtre = new CFiltreData(
                        CValorisationElement.c_champId + "<>@1 and " +
                        CTypeEquipement.c_champId + "=@2 and " +
                        CLotValorisation.c_champId + "=@3",
                        valorisationElement.Id,
                        valorisationElement.TypeEquipement.Id,
                        valorisationElement.LotValorisation.Id);
                    lstTmp.InterditLectureInDB = true;//On considère que c'est déjà lu pour optimiser
                    if ( lstTmp.Count > 0 )
                    {
                        result.EmpileErreur(I.T("Can not have multiple valuation for Equipment type @1 in lot @2|20190",
                            valorisationElement.TypeEquipement.Libelle,
                            valorisationElement.LotValorisation.Libelle));
                    }
                }
                if (valorisationElement.TypeConsommable != null)
                {
                    CListeObjetsDonnees lstTmp = new CListeObjetDonneeGenerique<CValorisationElement>(objet.ContexteDonnee);
                    lstTmp.Filtre = new CFiltreData(
                        CValorisationElement.c_champId + "<>@1 and " +
                        CTypeConsommable.c_champId + "=@2 and " +
                        CLotValorisation.c_champId + "=@3",
                        valorisationElement.Id,
                        valorisationElement.TypeConsommable.Id,
                        valorisationElement.LotValorisation.Id);
                    lstTmp.InterditLectureInDB = true;//On considère que c'est déjà lu pour optimiser
                    if (lstTmp.Count > 0)
                    {
                        result.EmpileErreur(I.T("Can not have multiple valuation for Consumable type @1 in lot @2|20191",
                            valorisationElement.TypeConsommable.Libelle,
                            valorisationElement.LotValorisation.Libelle));
                    }
                }

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
			return typeof(CValorisationElement);
		}
		//-------------------------------------------------------------------
        public override CResultAErreur TraitementAvantSauvegarde(CContexteDonnee contexte)
        {
            CResultAErreur result = base.TraitementAvantSauvegarde(contexte);
            if (!result)
                return result;
            DataTable table = contexte.Tables[CValorisationElement.c_nomTable];
            if (table == null)
                return result;
            ArrayList lst = new ArrayList(table.Rows);
            foreach (DataRow row in lst)
            {
                if (row.RowState != DataRowState.Unchanged)
                {
                    ///Cherche les impacts sur les couts
                    CValorisationElement valorisation = new CValorisationElement(row);
                    if (row.RowState == DataRowState.Deleted)
                        valorisation.VersionToReturn = DataRowVersion.Original;
                    CLotValorisation lot = valorisation.LotValorisation;
                    if (lot.Row.RowState == DataRowState.Deleted)
                        lot.VersionToReturn = DataRowVersion.Original;
                    foreach (CLivraisonLotValorisation livs in lot.RelationsLivraisons)
                    {
                        CLivraisonEquipement livraison = livs.Livraison;
                        if (livraison == null)
                            continue;
                        if (livraison.Row.RowState == DataRowState.Deleted)
                            livraison.VersionToReturn = DataRowVersion.Original;
                        CCommande commande = livraison.Commande;
                        if (commande == null || commande.Row.RowState == DataRowState.Deleted)
                            continue;//la commande a été supprimée
                        CListeObjetsDonnees lignes = commande.Lignes;
                        foreach (CLigneCommande ligne in lignes)
                        {
                            if (ligne.Row.RowState != DataRowState.Deleted)
                            {
                                CUtilElementACout.OnChangeCout(ligne, true, false);//changement du cout réel
                            }
                        }
                    }
                }
            }
            return result;
        }
	}
}
