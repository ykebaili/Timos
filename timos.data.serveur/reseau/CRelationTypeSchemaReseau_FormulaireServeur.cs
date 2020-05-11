using System;
using System.Collections.Generic;
using System.Text;


using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using sc2i.data.dynamic;
using sc2i.data.dynamic.loader;

namespace timos.data.serveur
{
    public class CRelationTypeSchemaReseau_FormulaireServeur : CObjetServeur
    {
        //-------------------------------------------------------------------
        public CRelationTypeSchemaReseau_FormulaireServeur(int nIdSession)
            : base(nIdSession)
        {
        }
        //-------------------------------------------------------------------
        public override string GetNomTable()
        {
            return CRelationTypeSchemaReseau_Formulaire.c_nomTable;
        }

        //-------------------------------------------------------------------
        public override Type GetTypeObjets()
        {
            return typeof(CRelationTypeSchemaReseau_Formulaire);
        }

        //-------------------------------------------------------------------
        public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
        {
            CResultAErreur result = CResultAErreur.True;
            return result;
        }
    }
}
