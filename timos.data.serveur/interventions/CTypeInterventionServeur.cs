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
    /// Description rÃƒÆ’Ã‚Â©sumÃƒÆ’Ã‚Â©e 
    /// </summary>
	public class CTypeInterventionServeur : CObjetServeurAvecBlob
    {
        //-------------------------------------------------------------------
        public CTypeInterventionServeur(int nIdSession)
			:base ( nIdSession )
		{
		}

		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CTypeIntervention.c_nomTable;
		}

		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			
            try
			{
                CTypeIntervention typeInter = (CTypeIntervention)objet;

                // Verifie le champ "Libelle"
				if (typeInter.Libelle == "")
					result.EmpileErreur(I.T( "Intervention Type label cannot be empty|138"));
				if (!CObjetDonneeAIdNumerique.IsUnique(typeInter, CTypeIntervention.c_champLibelle, typeInter.Libelle))
                    result.EmpileErreur(I.T( "Intervention Type @1 already exists|10006"), typeInter.Libelle);
				if (typeInter.Code != "")
				{
					if (!CObjetDonneeAIdNumerique.IsUnique(typeInter, CTypeIntervention.c_champCode, typeInter.Code))
						result.EmpileErreur(I.T( "Another Intervention Type width code @1 already exists|144"), typeInter.Code);
				}
				if (typeInter.Mnemomnique != "")
				{
					if (!CObjetDonneeAIdNumerique.IsUnique(typeInter, CTypeIntervention.c_champMnemomnique, typeInter.Mnemomnique))
						result.EmpileErreur(I.T( "Another Intervention Type whith mnemomnic @1 already exists|145"), typeInter.Mnemomnique);
				}

				if ( typeInter.Contraintes.Count > 0 &&
					 typeInter.ProfilRessourceDefaut == null )
				{
					result.EmpileErreur(I.T( "Resource profile must be defined|200"));
				}
				if (typeInter.ProfilRessourceDefaut != null)
				{
					if (typeInter.ProfilRessourceDefaut.TypeElements != typeof(CRessourceMaterielle) ||
						typeInter.ProfilRessourceDefaut.TypeSource != typeof(CIntervention))
					{
						result.EmpileErreur(I.T("The default resource profile is incompatible|222"));
					}
				}

				if ( typeInter.ProfilPlanifieur != null && 
					(typeInter.ProfilPlanifieur.TypeElements != typeof(CDonneesActeurUtilisateur) ||
					 typeInter.ProfilPlanifieur.TypeSource != typeof(CIntervention) ))
					result.EmpileErreur(I.T( "The default planner profile is incompatible|223"));

				if (typeInter.ProfilPreplanifieur != null &&
					(typeInter.ProfilPreplanifieur.TypeElements != typeof(CDonneesActeurUtilisateur) ||
					 typeInter.ProfilPreplanifieur.TypeSource != typeof(CIntervention)))
					result.EmpileErreur(I.T( "The default preplanner profile is incompatible|224"));

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
            return typeof(CTypeIntervention);
		}


		
    }
}
