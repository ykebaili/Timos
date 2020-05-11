using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.acteurs;

using timos.securite;
using System.Collections.Generic;

namespace timos.data.projet
{
    /// <summary>
    /// Description résumée de CRelationMetaProjet_ProjetServeur.
    /// </summary>
    public class CRelationMetaProjet_ProjetServeur : CObjetServeur
    {
        //-------------------------------------------------------------------
#if PDA
		public CRelationMetaProjet_ProjetServeur()
			:base()
		{
		}
#endif
        //-------------------------------------------------------------------
        public CRelationMetaProjet_ProjetServeur(int nIdSession)
            : base(nIdSession)
        {
        }
        //-------------------------------------------------------------------
        public override string GetNomTable()
        {
            return CRelationMetaProjet_Projet.c_nomTable;
        }
        //-------------------------------------------------------------------
        public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
        {
            CResultAErreur result = CResultAErreur.True;
            try
            {
                CRelationMetaProjet_Projet proj = (CRelationMetaProjet_Projet)objet;

                if(proj.Projet == null )
                    result.EmpileErreur(I.T( "Meta project link must be associated to a project|20181"));
                if (proj.MetaProjet == null)
                    result.EmpileErreur(I.T("Meta project link must be associated to a meta project|20182"));
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
            return typeof(CRelationMetaProjet_Projet);
        }

        //--------------------------------------------------------
        public override CResultAErreur TraitementAvantSauvegarde(CContexteDonnee contexte)
        {
            CResultAErreur result =  base.TraitementAvantSauvegarde(contexte);
            if (!result)
                return result;
            DataTable table = contexte.Tables[GetNomTable()];
            if (table == null)
                return result;
            HashSet<CMetaProjet> lstMetaProjetsARecalculer = new HashSet<CMetaProjet>();
            foreach (DataRow row in new ArrayList(table.Rows))
            {
                if (row.RowState == DataRowState.Added || row.RowState == DataRowState.Modified)
                {
                    CRelationMetaProjet_Projet rel = new CRelationMetaProjet_Projet(row);
                    if (rel != null && rel.MetaProjet != null && rel.MetaProjet.IsValide())
                        lstMetaProjetsARecalculer.Add(rel.MetaProjet);
                }
                if (row.RowState == DataRowState.Deleted)
                {
                    if (row.HasVersion(DataRowVersion.Original))
                    {
                        CRelationMetaProjet_Projet rel = new CRelationMetaProjet_Projet(row);
                        rel.VersionToReturn = DataRowVersion.Original;
                        try
                        {
                            CMetaProjet meta = rel.MetaProjet;
                            if (meta != null && meta.IsValide())
                                lstMetaProjetsARecalculer.Add(meta);
                        }
                        catch { }
                    }
                }
            }
            foreach (CMetaProjet meta in lstMetaProjetsARecalculer)
            {
                meta.UpdateDateDebutPlanifieeFromChilds(false);
                meta.UpdateDateFinPlanifieeFromChilds(false);
                meta.CalcProgress(false);
            }
            return result;


        }


    }
}
