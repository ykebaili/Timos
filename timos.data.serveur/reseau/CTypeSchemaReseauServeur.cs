using System;
using System.Collections;
using System.Text;
using System.Data;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;

using timos.data;
using timos.securite;

namespace timos.data.serveur
{
    public class CTypeSchemaReseauServeur : CObjetServeur
    {

        //-------------------------------------------------------------------
        public CTypeSchemaReseauServeur(int nIdSession)
            : base(nIdSession)
        {
        }

        public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
        {
            CResultAErreur result = CResultAErreur.True;
            try
            {
                CTypeSchemaReseau type_Schema = (CTypeSchemaReseau)objet;
                // Verifie le champ "Libelle"
                if (type_Schema.Libelle == "")
                    result.EmpileErreur(I.T("The network diagram type label cannot be empty|30019"));
            }
            catch (Exception e)
            {
                result.EmpileErreur(new CErreurException(e));
            }
            return result;
        }

        //-------------------------------------------------------------------
        public override string GetNomTable()
        {
            return CTypeSchemaReseau.c_nomTable;
        }

        public override Type GetTypeObjets()
        {
            return typeof(CTypeSchemaReseau);
        }
    }
}
