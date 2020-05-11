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
    /// <summary>
    /// Description rÃ©sumÃ©e 
    /// </summary>
    public class CReleveSiteServeur : CObjetDonneeServeurAvecCache
    {
        //-------------------------------------------------------------------
        public CReleveSiteServeur(int nIdSession)
			:base ( nIdSession )
		{
		}

		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CReleveSite.c_nomTable;
		}

		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			
            try
			{
                CReleveSite releve = objet as CReleveSite;
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
            return typeof(CReleveSite);
		}
		//-------------------------------------------------------------------
    }
}
