using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.acteurs;

using timos.securite;
using System.Collections.Generic;
using timos.data.serveur.projet;

namespace timos.data.projet
{
    /// <summary>
    /// Description résumée de CMetaProjetServeur.
    /// </summary>
    public class CMetaProjetServeur : CObjetServeurAvecBlob
    {
        //-------------------------------------------------------------------
#if PDA
		public CMetaProjetServeur()
			:base()
		{
		}
#endif
        //-------------------------------------------------------------------
        public CMetaProjetServeur(int nIdSession)
            : base(nIdSession)
        {
        }
        //-------------------------------------------------------------------
        public override string GetNomTable()
        {
            return CMetaProjet.c_nomTable;
        }
        //-------------------------------------------------------------------
        public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
        {
            CResultAErreur result = CResultAErreur.True;
            try
            {
                CMetaProjet proj = (CMetaProjet)objet;

                if(proj.Libelle == null || proj.Libelle == "")
                    result.EmpileErreur(I.T( "The meta project label cannot be empty|20180"));
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
            return typeof(CMetaProjet);
        }

        //-------------------------------------------------------------------------------
        public override CResultAErreur TraitementAvantSauvegarde(CContexteDonnee contexte)
        {
            CResultAErreur result = base.TraitementAvantSauvegarde(contexte);
            if (!result)
                return result;
            result = SObjetHierarchiqueServeur.TraitementAvantSauvegarde(contexte, GetNomTable());
            DataTable table = contexte.Tables[GetNomTable()];
            if (table == null)
                return result ;
            ArrayList lst = new ArrayList(table.Rows);
            bool bIsCalculatingAsynchrone = CGestionnaireProjetsAsynchrones.IsModeCalculProjet(contexte);
            foreach (DataRow row in lst)
            {
                if (!bIsCalculatingAsynchrone)
                    GereMetaProjetAsynchrone(row);
            }
            return result;

        }

        //-------------------------------------------------------------------------------
        private void GereMetaProjetAsynchrone(DataRow row)
        {
            if (row.RowState == DataRowState.Modified && (bool)row[CMetaProjet.c_champAsynchronousUpdate])
            {
                List<string> lstChampsAAnnuler = new List<string>();
                lstChampsAAnnuler.Add(CMetaProjet.c_champDateDebutPlanifiee);
                lstChampsAAnnuler.Add(CMetaProjet.c_champDateFinPlanifiee);
                lstChampsAAnnuler.Add(CMetaProjet.c_champPctAvancement);
                lstChampsAAnnuler.Add(CMetaProjet.c_champPoidsFils);

                foreach (string strChamp in lstChampsAAnnuler)
                    row[strChamp] = row[strChamp, DataRowVersion.Original];
                //Vérifie que la ligne est toujours en état modifié
                CStructureTable structure = CStructureTable.GetStructure(typeof(CMetaProjet));
                bool bIsModified = false;
                foreach (CInfoChampTable champ in structure.Champs)
                {

                    if (champ.m_bIsInDB && row[champ.NomChamp] != row[champ.NomChamp, DataRowVersion.Original])
                    {
                        bIsModified = true;
                        break;
                    }
                }
                if (!bIsModified)
                    row.RejectChanges();
            }
            return;
        }


    }
}
