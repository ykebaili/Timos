using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.data.dynamic.loader;
using sc2i.common;
using timos.acteurs;
using timos.securite;


using timos.data;

namespace timos.data.serveur
{
    /// <summary>
    /// Description résumée 
    /// </summary>
	public class CTypeActiviteActeurServeur : CObjetDonneeServeurAvecCache
    {
        //-------------------------------------------------------------------
        public CTypeActiviteActeurServeur(int nIdSession)
			:base ( nIdSession )
		{
		}

		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CTypeActiviteActeur.c_nomTable;
		}

		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			
            try
			{
                CTypeActiviteActeur typeActiviteActeur = (CTypeActiviteActeur)objet;


			}
			catch ( Exception e )
			{
				result.EmpileErreur( new CErreurException ( e ) );
			}
			return result;
		}

		//-------------------------------------------------------------------
		public override Type GetTypeObjets()
		{
            return typeof(CTypeActiviteActeur);
		}

    }
}
