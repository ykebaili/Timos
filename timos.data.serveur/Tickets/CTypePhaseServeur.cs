using System;
using System.Collections;
using System.Collections.Generic;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;

using timos.acteurs;
using timos.securite;
using timos.data;

namespace timos.data.serveur
{
	/// <summary>
	/// Description résumée de CTypePhaseTicketServeur.
	/// </summary>
	public class CTypePhaseServeur : CObjetDonneeServeurAvecCache
	{
		//-------------------------------------------------------------------
#if PDA
		public CTypePhaseTicketServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CTypePhaseServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CTypePhase.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CTypePhase typPhase = (CTypePhase)objet;

				if ( typPhase.Libelle == "")
					result.EmpileErreur(I.T( "The phase type label cannot be empty|236"));

                // Vérifie le profil des Utilisateurs (Responsables de Phase) possibles
                if (typPhase.ProfilResponsableTicket != null)
                {
                    if (typPhase.ProfilResponsableTicket.TypeSource != typeof(CPhaseTicket))
                        result.EmpileErreur(I.T( "The element type on the profile of the person in charge is not a 'phase type'|237"));
                    if (typPhase.ProfilResponsableTicket.TypeElements != typeof(CDonneesActeurUtilisateur))
                        result.EmpileErreur(I.T("The source type  on the profile of the person in charge is  is not a 'User'|238"));
                }
                

				//Recupération des contacts
				List<CActeursSelonProfil> lstContacts = typPhase.ProfilsContacts;
				//Verification de la coohérence des positions des Contacts
				//lstContacts.Tri = CContactsSelonProfil.c_champOrdre;
				for (int i = 0; i < lstContacts.Count; i++)
				{
					CActeursSelonProfil contact = (CActeursSelonProfil)lstContacts[i];
					if (contact.Ordre != i)
						result.EmpileErreur(I.T( "The Contact @1 is at position @2 instead of position @3|203", contact.Profil.Libelle, contact.Ordre.ToString(), i.ToString()));

					//Verification qu'il n'y a pas de redondance
					foreach (CActeursSelonProfil contactcompar in lstContacts)
					{
						if (contact.Equals(contactcompar))
							continue;

						if(contact.Profil == contactcompar.Profil)
							result.EmpileErreur(I.T( "The Contact Profile @1 already exists|204", contact.Profil.Libelle));
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
			return typeof(CTypePhase);
		}
		//-------------------------------------------------------------------
	}
}
