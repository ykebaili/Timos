using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;

using timos.data;
using timos.securite;

namespace timos.data.serveur
{
    /// <summary>
    /// Description résumée de CLienReseauServeur.
    /// </summary>
    public class CLienReseauServeur : CObjetServeur
    {
        //-------------------------------------------------------------------
        public CLienReseauServeur(int nIdSession)
            : base(nIdSession)
        {
        }

        //-------------------------------------------------------------------
        public override string GetNomTable()
        {
            return CLienReseau.c_nomTable;
        }



        public override CResultAErreur TraitementAvantSauvegarde(CContexteDonnee contexte)
        {
            
            CResultAErreur result = base.TraitementAvantSauvegarde(contexte);
			if (!result)
				return result;
			DataTable table = contexte.Tables[GetNomTable()];
			if (table == null)
				return result;
			ArrayList lstRows = new ArrayList(table.Rows);
            foreach (DataRow row in lstRows)
            {
                if (row.RowState == DataRowState.Added || row.RowState == DataRowState.Modified)
                {
                    CLienReseau lien = new CLienReseau(row);
                    //S'assure que le schéma existe (pour SPV);
                    if (lien.SchemaReseau == null)
                        lien.GetSchemaReseauADessiner(true);
                }
            }

            return result;
        }


        //-------------------------------------------------------------------
        public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
        {
            CResultAErreur result = CResultAErreur.True;

            try
            {
                CLienReseau lien = (CLienReseau)objet;

                // Verifie le champ "Libelle
                if (lien.Libelle == "")
                    result.EmpileErreur(I.T("Network link label cannot be empty|30004"));



                bool bTrouve = false;


                if (lien.Element1 == null)
                {
                    result.EmpileErreur(I.T("The linked element 1 cannot be null|30019"));
                }
                else
                {
                    if (lien.Element1.GetType() != lien.TypeLienReseau.TypeElement1)
                        result.EmpileErreur(I.T("The linked element 1 is not of the right type|30016"));

                    if (lien.Complement1 != null)
                    {
                        foreach (CObjetDonnee obj in lien.Element1.ComplementsPossibles)
                        {
                            if (obj == (CObjetDonnee)lien.Complement1)
                            {
                                bTrouve = true;
                                break;
                            }
                        }
                        if (!bTrouve)
                            result.EmpileErreur(I.T("Complementary element 1 does not belong to the possible complements of the element 1|30014"));
                    }
                }
                bTrouve = false;

                if (lien.Element2 == null)
                {
                    result.EmpileErreur(I.T("The linked element 2 cannot be null|30020"));
                }
                else
                {
                    if (lien.Element2.GetType() != lien.TypeLienReseau.TypeElement2)
                        result.EmpileErreur(I.T("The linked element 2 is not of the right type|30017"));

                    if (lien.Complement2 != null)
                    {


                        foreach (CObjetDonnee obj in lien.Element2.ComplementsPossibles)
                        {
                            if (obj == (CObjetDonnee)lien.Complement2)
                            {
                                bTrouve = true;
                                break;
                            }
                        }
                        if (!bTrouve)
                            result.EmpileErreur(I.T("Complementary element 2 does not belong to the possible complements of the element 2|30014"));

                    }
                }

                if (lien.Row.HasVersion(DataRowVersion.Original))
                {
                    //Si changement de l'élément 1
                    lien.VersionToReturn = DataRowVersion.Original;
                    IElementALiensReseau eltOriginal = lien.Element1;
                    lien.VersionToReturn = DataRowVersion.Current;
                    IElementALiensReseau eltNew = lien.Element1;
                    if ( eltNew != null && eltOriginal != null && eltNew.Equals (eltOriginal) )
                    {
                        //Vérifie qu'il n'y a pas de chemin sur l'élément 1
                        CListeObjetsDonnees lst = new CListeObjetsDonnees(objet.ContexteDonnee, typeof(CElementDeSchemaReseau));
                        lst.Filtre = new CFiltreData(CLienReseau.c_champId + "=@1", lien.Id);
                        bool bOk = true;
                        foreach (CElementDeSchemaReseau elt in lst)
                            if (elt.RacineChemin1 != null)
                            {
                                bOk = false;
                                break;
                            }
                        if ( !bOk )
                        {
                            result.EmpileErreur(I.T("The linked element 1 cannot be changed because the link is associted with a path|30022"));
                        }
                    }

                    //Si changement de l'élément 2
                    lien.VersionToReturn = DataRowVersion.Original;
                    eltOriginal = lien.Element2;
                    lien.VersionToReturn = DataRowVersion.Current;
                    eltNew = lien.Element2;
                    if ( eltNew != null && eltOriginal != null && eltNew.Equals (eltOriginal) )
                    {
                        //Vérifie qu'il n'y a pas de chemin sur l'élément 2
                        CListeObjetsDonnees lst = new CListeObjetsDonnees(objet.ContexteDonnee, typeof(CElementDeSchemaReseau));
                        lst.Filtre = new CFiltreData(CLienReseau.c_champId + "=@1", lien.Id);
                        bool bOk = true;
                        foreach (CElementDeSchemaReseau elt in lst)
                            if (elt.RacineChemin2 != null)
                            {
                                bOk = false;
                                break;
                            }
                        if ( !bOk )
                        {
                            result.EmpileErreur(I.T("The linked element 2 cannot be changed because the link is associted with a path|30023"));
                        }
                    }
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
            return typeof(CLienReseau);
        }
        //-------------------------------------------------------------------
    }
}
