using System;
using System.Collections;
using System.Text;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;

using timos.data;

namespace timos.data.serveur
{
    /// <summary>
    /// Description résumée 
    /// </summary>
    public class CRelationRessource_ChampCustomValeurServeur : CObjetDonneeServeurAvecCache
    {
        //-------------------------------------------------------------------
        public CRelationRessource_ChampCustomValeurServeur(int nIdSession)
			:base ( nIdSession )
		{
		}

        //-------------------------------------------------------------------
        public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
        {
            CResultAErreur result = CResultAErreur.True;
            return result;
        }

		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CRelationRessource_ChampCustomValeur.c_nomTable;
		}

		//-------------------------------------------------------------------
		public override Type GetTypeObjets()
		{
            return typeof(CRelationRessource_ChampCustomValeur);
		}
		//-------------------------------------------------------------------
    }
}
