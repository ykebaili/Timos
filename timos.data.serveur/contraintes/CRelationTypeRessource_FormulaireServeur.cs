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
    /// Description résumée.
    /// </summary>
    public class CRelationTypeRessource_FormulaireServeur : CObjetDonneeServeurAvecCache
    {
        //-------------------------------------------------------------------
        public CRelationTypeRessource_FormulaireServeur(int nIdSession)
			:base ( nIdSession )
		{
		}

		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CRelationTypeRessource_Formulaire.c_nomTable;
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
            return typeof(CRelationTypeRessource_Formulaire);
		}
		//-------------------------------------------------------------------
    }
}
