using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.acteurs;

using timos.securite;
using System.Collections.Generic;

namespace timos.data.projet.besoin
{
    /// <summary>
    /// Description résumée de CBesoinQuantiteServeur.
    /// </summary>
    public class CBesoinQuantiteServeur : CObjetServeur
    {
        //-------------------------------------------------------------------
#if PDA
		public CBesoinQuantiteServeur()
			:base()
		{
		}
#endif
        //-------------------------------------------------------------------
        public CBesoinQuantiteServeur(int nIdSession)
            : base(nIdSession)
        {
        }
        //-------------------------------------------------------------------
        public override string GetNomTable()
        {
            return CBesoinQuantite.c_nomTable;
        }
        //-------------------------------------------------------------------
        public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
        {
            CResultAErreur result = CResultAErreur.True;
            try
            {
                CBesoinQuantite besoin = (CBesoinQuantite)objet;

                if(besoin.Libelle == null || besoin.Libelle == "")
                    result.EmpileErreur(I.T( "The need quantity label cannot be empty|20187"));
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
            return typeof(CBesoinQuantite);
        }
    }
}
