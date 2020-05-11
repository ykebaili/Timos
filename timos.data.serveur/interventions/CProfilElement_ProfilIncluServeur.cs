using System;
using System.Collections;
using System.Text;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;

using timos.data;

namespace timos.data._ProfilIncluSiteServeur
{
    /// <summary>
    /// Description résumée de CProfilElement_ProfilIncluServeur.
    /// </summary>
    public class CProfilElement_ProfilIncluServeur : CObjetServeur
    {
        //-------------------------------------------------------------------
        public CProfilElement_ProfilIncluServeur(int nIdSession)
			:base ( nIdSession )
		{
		}

		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CProfilElement_ProfilInclu.c_nomTable;
		}

		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			
            try
			{
				CProfilElement_ProfilInclu rel = (CProfilElement_ProfilInclu)objet;

				if (rel.ModeInclusion == EModeInclusionProfilElement.Profil &&
					rel.ProfilInclu == null)
					result.EmpileErreur(I.T("The profile inclusion must be associated with a profile|213"));
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
            return typeof(CProfilElement_ProfilInclu);
		}

    }
}
