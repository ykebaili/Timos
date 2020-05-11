using System;
using System.Collections;
using System.Text;
using System.Collections.Generic;
using System.Data;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.data.dynamic.loader;
using sc2i.common;
using timos.acteurs;
using timos.securite;
using timos.data;
using sc2i.expression;
using sc2i.data.dynamic;


namespace timos.data.serveur
{
    /// <summary>
    /// Description rÃ©sumÃ©e de CProfilElementServeur.
    /// </summary>
    public class CProfilElementServeur : CObjetServeurAvecBlob
    {
        //-------------------------------------------------------------------
        public CProfilElementServeur(int nIdSession)
			:base ( nIdSession )
		{
		}

		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CProfilElement.c_nomTable;
		}

		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			
            try
			{
                CProfilElement profilElement = (CProfilElement)objet;

                // Verifie le champ "Libelle"
                if (profilElement.Libelle == "")
					result.EmpileErreur(I.T("The Profile label cannot be empty|214"));

				if (profilElement.UtiliseLeProfil(profilElement))
					result.EmpileErreur(I.T("Cyclic reference of profiles : impossible to validate Profile|215"));
				if ( profilElement.FormuleApplication == null ||
					profilElement.FormuleApplication.TypeDonnee.TypeDotNetNatif != typeof(bool) )
					result.EmpileErreur(I.T("The application condition must return a boolean|216"));
				if ( profilElement.FormuleIntegration == null ||
					profilElement.FormuleIntegration.TypeDonnee.TypeDotNetNatif != typeof(bool))
					result.EmpileErreur(I.T("The integration condition must return a boolean|217"));

				if (profilElement.ToutesLesCorrespondancesEO.Count != 0 && 
					profilElement.TypeElements != null &&
					profilElement.TypeSource != null)
				{
					CDefinitionProprieteDynamique propEO = profilElement.ProprieteCheminToEOElement;
					if (propEO == null)
					{
						if (!typeof(IElementAEO).IsAssignableFrom(profilElement.TypeElements))
						{
							result.EmpileErreur(I.T("The Organisational entities on elements of type @1 cannot be tested|218", DynamicClassAttribute.GetNomConvivial(profilElement.TypeElements)));
						}
					}
					else
					{
						if (!typeof(IElementAEO).IsAssignableFrom(propEO.TypeDonnee.TypeDotNetNatif))
						{
							result.EmpileErreur(I.T("The Organisational entities on elements of type @1 cannot be tested|218", DynamicClassAttribute.GetNomConvivial(propEO.TypeDonnee.TypeDotNetNatif)));
						}
					}
					

					C2iExpression formuleEltAEo = profilElement.FormuleElementAEOSource;
					if (formuleEltAEo != null)
					{
						if (!typeof(IElementAEO).IsAssignableFrom(formuleEltAEo.TypeDonnee.TypeDotNetNatif))
							result.EmpileErreur(I.T("The formula for the Source Element with Organisational Enity must return an element with an Organisational Entity|219"));
					}
					else
					{
						if (!typeof(IElementAEO).IsAssignableFrom(profilElement.TypeSource))
							result.EmpileErreur(I.T("The elements @1 are not related to Organisational Entities, the Organisational Entities cannot be used on these elements|220", DynamicClassAttribute.GetNomConvivial(profilElement.TypeSource)));
					}
				}
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
            return typeof(CProfilElement);
		}


		//-------------------------------------------------------------------
		public override CResultAErreur TraitementAvantSauvegarde(CContexteDonnee contexte)
		{
			 CResultAErreur result = base.TraitementAvantSauvegarde(contexte);
			if ( !result )
				return result;

			return SObjetHierarchiqueServeur.TraitementAvantSauvegarde ( contexte, GetNomTable() );
		}


	}
}
