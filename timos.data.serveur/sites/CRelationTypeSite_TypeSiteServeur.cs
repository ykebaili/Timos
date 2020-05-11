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
    /// Description rÃ©sumÃ©e de
    /// </summary>
    public class CRelationTypeSite_TypeSiteServeur : CObjetDonneeServeurAvecCache
    {
        //-------------------------------------------------------------------
        public CRelationTypeSite_TypeSiteServeur(int nIdSession)
			:base ( nIdSession )
		{
		}

		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CRelationTypeSite_TypeSite.c_nomTable;
		}

		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			
            try
			{
                CRelationTypeSite_TypeSite relation_type_site = (CRelationTypeSite_TypeSite)objet;

                // Verifie la propriÃ©tÃ© "TypeSiteContenant"
                if (relation_type_site.TypeSiteContenant == null)
                    result.EmpileErreur(I.T("The Containing Site Type cannot be empty|259"));

                // Verifie la propriÃ©tÃ© "TypeSiteContenu"
                if (relation_type_site.TypeSiteContenu == null)
                    result.EmpileErreur(I.T("The Contained Site Type cannot be empty|260"));

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
            return typeof(CRelationTypeSite_TypeSite);
		}
		//-------------------------------------------------------------------
    }
}
