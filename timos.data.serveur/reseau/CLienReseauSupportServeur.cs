using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.acteurs;
using timos.data;

using sc2i.workflow.serveur;

namespace timos.data.serveur
{
    public class CLienReseauSupportServeur : CObjetServeur
    {

        //-------------------------------------------------------------------
        public CLienReseauSupportServeur(int nIdSession)
            : base(nIdSession)
        {
        }



        public override CResultAErreur TraitementAvantSauvegarde(CContexteDonnee contexte)
		{
			CResultAErreur result = base.TraitementAvantSauvegarde(contexte);
			DataTable table = contexte.Tables[CLienReseauSupport.c_nomTable];
			if (table != null)
			{
				ArrayList lstRows = new ArrayList(table.Rows);
				foreach (DataRow row in lstRows)
				{
					if (row.RowState == DataRowState.Modified || row.RowState == DataRowState.Added)
					{
                        CLienReseauSupport sup = new CLienReseauSupport(row);
                       /* if(!sup.EstSupporte.CanSupport(sup.Supporte))
                        {
                            result.EmpileErreur("Impossible to add the link : the supported link @1 is supported by the supporting link @2|", sup.Supporte.Libelle,sup.EstSupporte.Libelle);
                            return result;
                        }*/
						

					}
				}
			}
			return result;

        }

        /// ////////////////////////////////////////////////////////////
        public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
        {
            CResultAErreur result = CResultAErreur.True;
            try
            {
                CLienReseauSupport relation = (CLienReseauSupport)objet;
                if (relation.EstSupporte == null)
                    result.EmpileErreur(I.T("The supporting link must be defined|30007"));
                else if (relation.Supporte == null)
                    result.EmpileErreur(I.T("The supported link must be defined|30008"));
                
                bool bTypeSuppotantPossible = false;
                foreach (CTypeLienReseau typSup in relation.Supporte.TypeLienReseau.TypesPeutEtreSupporte)
                {
                    if (typSup == relation.EstSupporte)
                    {
                        bTypeSuppotantPossible = true;
                        break;
                    }
                }
                if(bTypeSuppotantPossible==false)
                    result.EmpileErreur(I.T("The supporting link type does not belong to the possible types|30010"));

                  bool bTypeSupportePossible = false;
                foreach (CTypeLienReseau typSup in relation.EstSupporte.TypeLienReseau.TypesPeutSupporter)
                {
                    if (typSup == relation.Supporte)
                    {
                        bTypeSupportePossible = true;
                        break;
                    }
                }
                if(bTypeSupportePossible==false)
                    result.EmpileErreur(I.T("The supported link type does not belong to the possible types|30011"));
               
                
                // vérifie qu'il n'existe pas déjà une relation entre les deux liens
                if (relation.Supporte != null)
                {
                    CListeObjetsDonnees liste = new CListeObjetsDonnees(relation.ContexteDonnee,
                        typeof(CLienReseauSupport));
                    liste.Filtre = new CFiltreData(CLienReseauSupport.c_champIdSupporte + "=@1 and " +
                      CLienReseauSupport.c_champIdEstSupporte + "=@2",  relation.Supporte.Id,
                        relation.EstSupporte.Id);
                    if (liste.Count > 1)
                        result.EmpileErreur("A support relationship between the links already exists|30012");
                }

                // vérifie qu'il n'existe pas une relation réflexive entre les deux liens
                if ((relation.Supporte != null) && IsReflexive(relation.Supporte.Id, relation))
                    result.EmpileErreur("A link cannot be both supporting and supported link of the same link|30013");

             
                


       
            }
            catch (Exception e)
            {
                result.EmpileErreur(new CErreurException(e));
            }
            return result;
        }




        private bool IsReflexive(int idLienSupporte, CLienReseauSupport support)
        {
            CListeObjetsDonnees liste = new CListeObjetsDonnees(support.ContexteDonnee,
                    typeof(CLienReseauSupport));
            liste.Filtre = new CFiltreData(CLienReseauSupport.c_champIdSupporte + "=@1",
                support.EstSupporte.Id);
            if (liste.Count == 0)
                return false;
            foreach (CLienReseauSupport tmp in liste)
                if (tmp.EstSupporte.Id == idLienSupporte)
                    return true;
                else
                    if (IsReflexive(idLienSupporte, tmp))
                        return true;

            return false;
        }
        /// ////////////////////////////////////////////////////////////
        public override string GetNomTable()
        {
            return CLienReseauSupport.c_nomTable;
        }


        /// ////////////////////////////////////////////////////////////
        public override Type GetTypeObjets()
        {
            return typeof(CLienReseauSupport);
        }


    }
}
