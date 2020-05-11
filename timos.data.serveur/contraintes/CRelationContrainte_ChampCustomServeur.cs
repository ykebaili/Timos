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
    /// Description résumée de CRelationContrainte_ChampCustomServeur.
    /// </summary>
    public class CRelationContrainte_ChampCustomServeur : CObjetDonneeServeurAvecCache
    {
        //-------------------------------------------------------------------
        public CRelationContrainte_ChampCustomServeur(int nIdSession)
			:base ( nIdSession )
		{
		}

		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CRelationContrainte_ChampCustom.c_nomTable;
		}

		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
    		return result;
		}

		//-------------------------------------------------------------------
		public override Type GetTypeObjets()
		{
            return typeof(CRelationContrainte_ChampCustom);
		}
		//-------------------------------------------------------------------
    }
}
