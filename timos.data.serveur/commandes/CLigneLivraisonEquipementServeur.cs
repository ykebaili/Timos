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
    /// Description rÃ©sumÃ©e de CLigneLivraisonEquipementServeur.
    /// </summary>
    public class CLigneLivraisonEquipementServeur : CObjetDonneeServeurAvecCache
    {
        //-------------------------------------------------------------------
#if PDA
		public CLigneLivraisonEquipementServeur()
			:base()
		{
		}
#endif
        //-------------------------------------------------------------------
        public CLigneLivraisonEquipementServeur(int nIdSession)
            : base(nIdSession)
        {
        }
        //-------------------------------------------------------------------
        public override string GetNomTable()
        {
            return CLigneLivraisonEquipement.c_nomTable;
        }
        //-------------------------------------------------------------------
        public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
        {
            CResultAErreur result = CResultAErreur.True;
            try
            {
                CLigneLivraisonEquipement LigneLivraisonEquipement = (CLigneLivraisonEquipement)objet;

                if (LigneLivraisonEquipement.LivraisonEquipement == null)
                    result.EmpileErreur(I.T("Delivery line must be associated to a delivry|20168"));
                if (LigneLivraisonEquipement.Equipement == null)
                    result.EmpileErreur(I.T("Delivery line must be associated to an equipment |20169"));
            }
            catch (Exception e)
            {
                result.EmpileErreur(new CErreurException(e));
            }
            return result;
        }
        //-------------------------------------------------------------------
        public override Type GetTypeObjets()
        {
            return typeof(CLigneLivraisonEquipement);
        }

        //-------------------------------------------------------------------
        public override CResultAErreur TraitementAvantSauvegarde(CContexteDonnee contexte)
        {
            CResultAErreur result = base.TraitementAvantSauvegarde(contexte);
            if (!result)
                return result;
            DataTable table = contexte.Tables[GetNomTable()];
            if (table == null)
                return null;
            ArrayList lst = new ArrayList(table.Rows);
            HashSet<CLivraisonEquipement> livraisonsPourValorisation = new HashSet<CLivraisonEquipement>();
            foreach (DataRow row in lst)
            {
                if (row.RowState == DataRowState.Modified || row.RowState == DataRowState.Added)
                {
                    CLigneLivraisonEquipement ligne = new CLigneLivraisonEquipement(row);
                    livraisonsPourValorisation.Add(ligne.LivraisonEquipement);
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
