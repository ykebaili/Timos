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
    /// Description résumée de CElementDeSchemaReseauServeur.
    /// </summary>
    public class CElementDeSchemaReseauServeur : CObjetServeurAvecBlob
    {
        //-------------------------------------------------------------------
        public CElementDeSchemaReseauServeur(int nIdSession)
            : base(nIdSession)
        {
        }

        //-------------------------------------------------------------------
        public override string GetNomTable()
        {
            return CElementDeSchemaReseau.c_nomTable;
        }

        //-------------------------------------------------------------------
        public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
        {
            CResultAErreur result = CResultAErreur.True;

            try
            {
                CElementDeSchemaReseau elt = (CElementDeSchemaReseau)objet;
                
                //S'agit-il d'un lien supportant ?
                if (elt.LienReseau != null && elt.SchemaReseau.LienReseau != null)
                {
                    if (!elt.SchemaReseau.LienReseau.TypeSupportantPossible(elt.LienReseau))
                    {
                        string strType1 = elt.SchemaReseau.LienReseau.TypeLienReseau != null ?
                            elt.SchemaReseau.LienReseau.TypeLienReseau.Libelle:
                            I.T("No type|20010");
                        string strType2 = elt.LienReseau.TypeLienReseau != null ?
                            elt.LienReseau.TypeLienReseau.Libelle:
                            I.T("No type|20010");
                        result.EmpileErreur(I.T("Link of type @1 can not be supported by link of type @2|30025",
                            elt.SchemaReseau.LienReseau.TypeLienReseau.Libelle,
                            elt.LienReseau.TypeLienReseau.Libelle ));
                    }
                    if (!elt.SchemaReseau.LienReseau.PeutEtreSupporte(elt.LienReseau))
                        result.EmpileErreur(I.T("Link @1 is supported by @2, and @2 is supported by @1|20042",
                            elt.SchemaReseau.LienReseau.Libelle,
                            elt.LienReseau.Libelle));
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
            return typeof(CElementDeSchemaReseau);
        }
        //-------------------------------------------------------------------
    }
}
