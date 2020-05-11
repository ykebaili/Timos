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
    /// Description résumée de CTypeMetaProjetServeur.
    /// </summary>
    public class CTypeMetaProjetServeur : CObjetServeurAvecBlob
    {
        //-------------------------------------------------------------------
#if PDA
		public CTypeMetaProjetServeur()
			:base()
		{
		}
#endif
        //-------------------------------------------------------------------
        public CTypeMetaProjetServeur(int nIdSession)
            : base(nIdSession)
        {
        }
        //-------------------------------------------------------------------
        public override string GetNomTable()
        {
            return CTypeMetaProjet.c_nomTable;
        }
        //-------------------------------------------------------------------
        public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
        {
            CResultAErreur result = CResultAErreur.True;
            try
            {
                CTypeMetaProjet proj = (CTypeMetaProjet)objet;

                if(proj.Libelle == null || proj.Libelle == "")
                    result.EmpileErreur(I.T( "The meta project type label cannot be empty|20183"));
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
            return typeof(CTypeMetaProjet);
        }


    }
}
