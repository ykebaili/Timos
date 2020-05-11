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
    /// Description résumée de CSchemaReseauServeur.
    /// </summary>
    public class CSchemaReseauServeur : CObjetServeurAvecBlob
    {
        //-------------------------------------------------------------------
        public CSchemaReseauServeur(int nIdSession)
            : base(nIdSession)
        {
        }

        //-------------------------------------------------------------------
        public override string GetNomTable()
        {
            return CSchemaReseau.c_nomTable;
        }

        public override CResultAErreur BeforeSave(CContexteSauvegardeObjetsDonnees contexte, IDataAdapter adapter, DataRowState etatsAPrendreEnCompte)
        {
            return base.BeforeSave(contexte, adapter, etatsAPrendreEnCompte);
        }

        public override CResultAErreur TraitementAvantSauvegarde(CContexteDonnee contexte)
        {
            CResultAErreur result = base.TraitementAvantSauvegarde(contexte);
            if (!result)
                return result;

       /*     DataTable dt = contexte.Tables[CSchemaReseau.c_nomTable];
           ArrayList rows = new ArrayList(dt.Rows);
            foreach (DataRow row in rows)
            {
                
                if(row.RowState == DataRowState.Deleted)
                {
                    CSchemaReseau schema = new CSchemaReseau(row);

                    foreach (CSchemaReseau fils in schema.SchemaFils)
                    {
                      result =  fils.Delete();
                    }

                
                }
            }

            return result;*/
            return result;
        }


        //-------------------------------------------------------------------
        public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
        {
            CResultAErreur result = CResultAErreur.True;

            try
            {
                CSchemaReseau schema = (CSchemaReseau)objet;

                if (schema.Libelle == "")
                {
                    result.EmpileErreur(I.T("The network diagram label cannot be empty|30018"));

               

                }

                /*if (schema.LienReseau != null)
                {
                    CLienReseau lien = schema.LienReseau;
                    foreach (CElementDeSchemaReseau element in schema.ElementsDeSchema)
                    {

                        string strType = element.ElementAssocie.GetType().ToString();
                        CLienReseau lienreseau = element.ElementAssocie as CLienReseau;

                        if (lienreseau != null)
                        {
                           

                            if (!lien.PeutEtreSupporte(lienreseau))
                                result.EmpileErreur(I.T("Cyclic dependancy between supported and supporting links|30024"));

                            if (!lien.TypeSupportantPossible(lienreseau))
                                result.EmpileErreur(I.T("The supporting link '@1' type is not a possible type for the supported link|30025",lienreseau.Libelle));
                        }
                    }

                }*/
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
            return typeof(CSchemaReseau);
        }
        //-------------------------------------------------------------------
    }
}
