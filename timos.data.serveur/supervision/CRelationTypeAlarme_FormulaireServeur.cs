using System;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using sc2i.data.dynamic;
using sc2i.data.dynamic.loader;
using timos.acteurs;
using timos.securite;
using timos.data.supervision;
using System.Data;
using System.Collections;

namespace timos.data.serveur
{
	/// <summary>
	/// Description résumée de CRelationEntiteOrganisationnelle_FormulaireServeur.
	/// </summary>
	public class CRelationTypeAlarme_FormulaireServeur : CObjetDonneeServeurAvecCache
	{
		//-------------------------------------------------------------------
#if PDA
		public CRelationEntiteOrganisationnelle_FormulaireServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationTypeAlarme_FormulaireServeur(int nIdSession)
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CRelationTypeAlarme_Formulaire.c_nomTable;
		}
		
		//-------------------------------------------------------------------
		public override Type GetTypeObjets()
		{
			return typeof(CRelationTypeAlarme_Formulaire);
		}

		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
		{
			CResultAErreur result = CResultAErreur.True;
			return result;
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
            ArrayList lst = new ArrayList(table.Rows);
            foreach (DataRow row in lst)
            {
                if (row.RowState == DataRowState.Added || row.RowState == DataRowState.Modified || row.RowState == DataRowState.Deleted)
                {
                    CRelationTypeAlarme_ChampCustom rel = new CRelationTypeAlarme_ChampCustom(row);
                    if (row.RowState == DataRowState.Deleted)
                        rel.VersionToReturn = DataRowVersion.Original;
                    CTypeAlarme typeAlarme = rel.Definisseur as CTypeAlarme;
                    if (typeAlarme.Row.RowState == DataRowState.Unchanged)
                        typeAlarme.ForceChangementSyncSession();
                }
            }
            return result;
        }
	}
}
