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
    /// Description résumée de CBesoinDependanceServeur.
    /// </summary>
    public class CBesoinDependanceServeur : CObjetServeur
    {
        //-------------------------------------------------------------------
#if PDA
		public CBesoinDependanceServeur()
			:base()
		{
		}
#endif
        //-------------------------------------------------------------------
        public CBesoinDependanceServeur(int nIdSession)
            : base(nIdSession)
        {
        }
        //-------------------------------------------------------------------
        public override string GetNomTable()
        {
            return CBesoinDependance.c_nomTable;
        }
        //-------------------------------------------------------------------
        public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
        {
            CResultAErreur result = CResultAErreur.True;
            try
            {
                CBesoinDependance besoin = (CBesoinDependance)objet;
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
            return typeof(CBesoinDependance);
        }

    }
}
