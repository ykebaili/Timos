using System;
using System.Collections;
using System.Text;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;

using timos.data;

namespace timos.data._TypeEOSiteServeur
{
    /// <summary>
    /// Description résumée de CProfilElement_TypeEOServeur.
    /// </summary>
    public class CProfilElement_TypeEOServeur : CObjetServeur
    {
        //-------------------------------------------------------------------
        public CProfilElement_TypeEOServeur(int nIdSession)
			:base ( nIdSession )
		{
		}

		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CProfilElement_TypeEO.c_nomTable;
		}

		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			
            try
			{
				CProfilElement_TypeEO rel = (CProfilElement_TypeEO)objet;
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
            return typeof(CProfilElement_TypeEO);
		}
		//-------------------------------------------------------------------
    }
}
