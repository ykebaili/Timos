using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.acteurs;

using timos.securite;
using System.Collections.Generic;
using timos.data.projet;
using timos.data.serveur.projet;

namespace timos.data
{
    /// <summary>
    /// Description résumée de CProjetServeur.
    /// </summary>
    public class CProjetServeur : CObjetHierarchiqueServeur
    {
        //-------------------------------------------------------------------
#if PDA
		public CProjetServeur()
			:base()
		{
		}
#endif
        //-------------------------------------------------------------------
        public CProjetServeur(int nIdSession)
            : base(nIdSession)
        {
        }
        //-------------------------------------------------------------------
        public override string GetNomTable()
        {
            return CProjet.c_nomTable;
        }
        //-------------------------------------------------------------------
        public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
        {
            CResultAErreur result = CResultAErreur.True;
            try
            {
                CProjet proj = (CProjet)objet;

                if(proj.Libelle == null || proj.Libelle == "")
                    result.EmpileErreur(I.T( "The Project label cannot be empty|261"));
				if(proj.TypeProjet == null)
					result.EmpileErreur(I.T( "The Project must have a Project Type|385"));
                if (proj.DateDebutPlanifiee != null && proj.DateFinPlanifiee != null)
                {
                    if (proj.DateDebutPlanifiee != null && proj.DateFinPlanifiee != null)
                    {
                        int comparedate = DateTime.Compare((DateTime)proj.DateDebutPlanifiee, (DateTime)proj.DateFinPlanifiee);
                        if (comparedate > 0)
                            result.EmpileErreur(I.T("Planned Start Date of the project cannot be greater than Planned End Date|387"));
                    }
                    if (proj.DateDebutReel != null && proj.DateFinRelle != null)
                    {
                        int comparedate = DateTime.Compare((DateTime)proj.DateDebutReel, (DateTime)proj.DateFinRelle);
                        if (comparedate > 0)
                            result.EmpileErreur(I.T("Project True Start Date cannot be greater than True End Date|10002"));
                    }
                }
                if ( proj.Projet != null && proj.TypeProjet != null && proj.Projet.TypeProjet != null &&
                    !proj.TypeProjet.AccepteProjetsParentsDuType(proj.Projet.TypeProjet))
                {
                    result.EmpileErreur(I.T("Project @1 doesn't respect project type hierarchy contraints|20141",
                        proj.Libelle ));
                }
                if ( proj.Projet == null && proj.TypeProjet != null && proj.TypeProjet.NecessiteParent )
                {
                    result.EmpileErreur(I.T("Project @1 need a parent project|20142", proj.Libelle ));
                }
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
            return typeof(CProjet);
        }

        //-------------------------------------------------------------------
        public override CResultAErreur TraitementAvantSauvegarde(CContexteDonnee contexte)
        {
            CResultAErreur result = CResultAErreur.True;
            try
            {
                result = base.TraitementAvantSauvegarde(contexte);
            }
            catch (Exception e)
            {
                result.EmpileErreur(new CErreurException(e));
                return result;
            }
            if (!result)
                return result;
            DataTable table = contexte.Tables[GetNomTable()];
            if (table == null)
                return result;
            HashSet<CProjet> projetsARecalculer = new HashSet<CProjet>();
            HashSet<CMetaProjet> metaProjetsARecalculer = new HashSet<CMetaProjet>();
            bool bIsCalculatingAsynchrones = CGestionnaireProjetsAsynchrones.IsModeCalculProjet(contexte);
            List<int> lstProjetsAsynchrones = new List<int>();
            List<int> lstMetasProjetsAsynchrones = new List<int>();
            foreach (DataRow row in new ArrayList(table.Rows))
            {
                if (!bIsCalculatingAsynchrones)
                    GereProjetAsynchrone(row);
                if (row.RowState == DataRowState.Modified || row.RowState == DataRowState.Added)
                {
                    CProjet projet = new CProjet(row);

                    if (projet.ModeCalculDatesParentes == (int)EModeCalculDatesProjet.Suspended)
                        projet.ModeCalculDatesParentes = (int)EModeCalculDatesProjet.Automatic;
                    if (projet.IsNew())
                    {
                        result = CreateVersionRecursif(projet);
                        if (!result)
                            return result;
                        projetsARecalculer.Add(projet);
                    }
                    // Si les dates réelles (Début ou fin ) sont renseignées, alors on mes le flag Dates Auto à False
                    if ((projet.DateDebutReel != null || projet.DateFinRelle != null) && !projet.HasChilds())
                    {
                        projet.DateDebutAuto = false;
                    }

                    // Si les dates planifiées on changées, force le Parent de plus haut niveau à recalculer ses dates
                    if (!row.HasVersion(DataRowVersion.Original) ||
                        (row[CProjet.c_champDateDebutPlanifiee] != row[CProjet.c_champDateDebutPlanifiee, DataRowVersion.Original] ||
                        row[CProjet.c_champDateFinPlanifiee] != row[CProjet.c_champDateFinPlanifiee, DataRowVersion.Original] ||
                        row[CProjet.c_champDateDebutReel] != row[CProjet.c_champDateDebutReel, DataRowVersion.Original] ||
                        row[CProjet.c_champDateFinReel] != row[CProjet.c_champDateFinReel, DataRowVersion.Original] ||
                        row[CProjet.c_champPctAvancement] != row[CProjet.c_champPctAvancement, DataRowVersion.Original] ||
                        row[CProjet.c_champPoids] != row[CProjet.c_champPoids, DataRowVersion.Original])
                        )
                    {
                        foreach (CRelationMetaProjet_Projet rel in projet.RelationsMetaProjets)
                        {
                            if (rel.IsValide() && rel.MetaProjet.IsValide())
                            {
                                if (rel.MetaProjet.ModeUpdateAsynchrone && rel.MetaProjet.Row.RowState != DataRowState.Added || bIsCalculatingAsynchrones)
                                    lstMetasProjetsAsynchrones.Add(rel.MetaProjet.Id);
                                else
                                    metaProjetsARecalculer.Add(rel.MetaProjet);
                            }
                        }
                        if (projet.IsNew() && !projet.HasChilds())
                        {
                            projet.CalcWeight(false);
                            projet.CalcProgress(false);
                        }
                        projet = projet.Projet;
                        while (projet != null && projet.IsValide())
                        {
                            if (!projet.ModeUpdateAsynchrone || projet.Row.RowState == DataRowState.Added || bIsCalculatingAsynchrones)
                            {
                                projetsARecalculer.Add(projet);
                                projet = projet.Projet;
                            }
                            else
                            {
                                lstProjetsAsynchrones.Add(projet.Id);
                                break;
                            }
                        }
                    }

                }

                if (row.RowState == DataRowState.Deleted)
                {
                    CProjet projet = new CProjet(row);
                    projet.VersionToReturn = DataRowVersion.Original;
                    if (projet.Projet != null && projet.Projet.IsValide())
                    {
                        projetsARecalculer.Add(projet.Projet);
                    }
                }
            }
            //Tri les projets par profondeur (du plus profond au moins profond)


            List<CProjet> lstProjetsTries = new List<CProjet>();
            foreach (CProjet projet in projetsARecalculer)
                if (projet.Row.RowState != DataRowState.Deleted)
                    lstProjetsTries.Add(projet);
            try
            {
                lstProjetsTries.Sort(delegate(CProjet x, CProjet y)
                {
                    return -x.CodeSystemeComplet.Length.CompareTo(y.CodeSystemeComplet.Length);
                });
            }
            catch (Exception ex)
            {
                result.EmpileErreur(new CErreurException(ex));
                return result;
            }



            // Recalcul les dates PLANIFIEES des projets marqués A recalculés, et leur Avancement
            foreach (CProjet projet in lstProjetsTries)
            {
                if (projet.HasChilds())
                {
                    projet.UpdateDateDebutPlanifieeCalculeeFromChilds();
                    projet.UpdateDateFinPlanifieeCalculeeFromChilds();
                    projet.UpdateDateDebutReelleFromFils();
                    projet.UpdateDateFinReelleFromFils();
                }
                projet.UpdateWeight();
                projet.UpdateProgress();

            }
            foreach (CMetaProjet meta in metaProjetsARecalculer)
            {
                meta.UpdateDateDebutPlanifieeFromChilds(true);
                meta.UpdateDateFinPlanifieeFromChilds(true);
                meta.UpdateDateDebutReelleFromChilds(true);
                meta.UpdateDateFinReelleFromChilds(true);
                meta.CalcProgress(false);
            }
            if (!bIsCalculatingAsynchrones)
                CGestionnaireProjetsAsynchrones.ASyncCalc(IdSession, lstProjetsAsynchrones, lstMetasProjetsAsynchrones);
            return result;
        }

        //-------------------------------------------------------------------------------
        private void GereProjetAsynchrone ( DataRow row )
        {
            if (row.RowState == DataRowState.Modified && (bool)row[CProjet.c_champAsynchronousUpdate])
            {
                List<string> lstChampsAAnnuler = new List<string>();
                lstChampsAAnnuler.Add(CProjet.c_champDateDebutPlanifieeCalculee);
                lstChampsAAnnuler.Add(CProjet.c_champDateFinPlanifieeCalculee);
                lstChampsAAnnuler.Add(CProjet.c_champDateDebutReel);
                lstChampsAAnnuler.Add(CProjet.c_champDateFinReel);
                lstChampsAAnnuler.Add(CProjet.c_champPoidsFils);
                lstChampsAAnnuler.Add(CProjet.c_champAvancementsFils);
                lstChampsAAnnuler.Add(CProjet.c_champPctAvancement);
                if ((bool)row[CProjet.c_champDebutAuto])
                {
                    lstChampsAAnnuler.Add(CProjet.c_champDateDebutPlanifiee);
                    lstChampsAAnnuler.Add(CProjet.c_champDateFinPlanifiee);
                }
                foreach (string strChamp in lstChampsAAnnuler)
                    row[strChamp] = row[strChamp, DataRowVersion.Original];
                //Vérifie que la ligne est toujours en état modifié
                CStructureTable structure = CStructureTable.GetStructure(typeof(CProjet));
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

        //-------------------------------------------------------------------------------
        private CResultAErreur CreateVersionRecursif(CProjet projet)
        {
            CResultAErreur res = CResultAErreur.True;
            if (projet.Projet != null)
                res = CreateVersionRecursif(projet.Projet);
            if (!res)
                return res;
            if (projet.IsNew() && projet.TypeProjet != null && projet.TypeProjet.OptionVersion.Code == timos.data.projet.EOptionTypeProjetVersion.VersionAutomatique)
            {
                res = projet.CreateDataVersionInCurrentContext();
            }
            return res;
        }

    }
}
