using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.acteurs;
using sc2i.multitiers.client;
using timos.securite;
using timos.acteurs.serveur;
using sc2i.workflow;
using timos.client;


namespace timos.securite.serveur
{
	/// <summary>
	/// Description résumée de CDonneesActeurUtilisateurServeur.
	/// </summary>
	public class CDonneesActeurUtilisateurServeur : CDonneesActeurServeur
	{
		//-------------------------------------------------------------------
#if PDA
		public CDonneesActeurUtilisateurServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CDonneesActeurUtilisateurServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CDonneesActeurUtilisateur.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
#if !PDA_DATA
			try
			{
				CDonneesActeurUtilisateur donnees = (CDonneesActeurUtilisateur)objet;

				if (donnees.Acteur == null)
					result.EmpileErreur(I.T("The User must be related to a Member|284"));

				
				/*if ( donnees.IdUserAd!="" )
					if ( CAdUser.GetUser(IdSession, donnees.IdUserAd) == null )
						result.EmpileErreur(I.T("The user '@1' n'existe pas|285",donnees.IdUserAd));*/
				if ( donnees.Login != "" )
				{
					if ( donnees.Password == "" )
						result.EmpileErreur(I.T("Enter the password|286"));
					if (!CObjetDonneeAIdNumerique.IsUnique(donnees, CDonneesActeurUtilisateur.c_champLogin, donnees.Login))
						result.EmpileErreur(I.T("This login is already used|287"));
				}

			}
			catch ( Exception e )
			{
				result.EmpileErreur( new CErreurException ( e ) );
			}
#endif
			return result;
		}
		//-------------------------------------------------------------------
		public override Type GetTypeObjets()
		{
			return typeof(CDonneesActeurUtilisateur);
		}

		//-------------------------------------------------------------------
		public override CResultAErreur TraitementAvantSauvegarde ( CContexteDonnee ds )
		{
			CResultAErreur result = base.TraitementAvantSauvegarde(ds);

            CDonneesActeurUtilisateur userConnecte = CDonneesActeurUtilisateur.GetUserForSession(ds.IdSession, ds);

            CSessionClient session = CSessionClient.GetSessionForIdSession(IdSession);

            // Un utilisateur ne peut pas affecter un Profil de Licence à un autre utilisateur,
            // si ce profil est plus fort que le sien
            CInfoLicenceUserProfil profil = (CInfoLicenceUserProfil)session.GetPropriete(CInfoLicenceUserProfil.c_nomIdentification);

            //envoie les notifications sur modification de données utilisateur
			DataTable table = ds.Tables[GetNomTable()];
			foreach ( DataRow row in table.Rows )
			{
                if (row.RowState != DataRowState.Unchanged)
                {
                    if (userConnecte != null)
                    {
                        // Vérifie premièrement que l'utilisateur connecté à le droit de gestion de utilisateurs
                        if (userConnecte.GetDonneeDroit(CDroitDeBase.c_droitBaseGestionUtilisateurs) == null)
                        {
                            result.EmpileErreur(I.T("You don't have System Right to Manage Application Users|10012"));
                            return result;
                        }
                    }
                }

				if ( row.RowState == DataRowState.Added || row.RowState == DataRowState.Modified )
				{
                    if (userConnecte != null)
                    {
                        // Verifie ensuite que l'utilisteur connecté tente de donner un droit qu'il n'a pas !
                        CDonneesActeurUtilisateur user = new CDonneesActeurUtilisateur(row);
                        foreach (CRelationActeurUtilisateur_Droit relDroit in user.RelationsDroits)
                        {
                            if (userConnecte.GetDonneeDroit(relDroit.Droit.Code) == null)
                            {
                                result.EmpileErreur(I.T("You don't have right to affect this system Right : @1|10019", relDroit.Droit.Libelle));
                                return result;
                            }
                        }
                        // Vérifie que l'utilisateur connecté ne tente pas d'affecter un profil de licence supérieur au sien
                        string strIdProfil = user.IdProfilLicence;
                        CInfoLicenceUserProfil profilModifie = CGestionnaireProfilLicenceSurClient.GetProfil(strIdProfil);
                        if (profil == null || profilModifie != null && profilModifie.Priorite > profil.Priorite)
                        {
                            result.EmpileErreur(I.T("You can not affect a Licence Profile greater than your Profile : @1|20140", profilModifie.Nom));
                        }
	                }
                    
                        
                    //TESTDBKEYOK
					CDonneeNotificationChangementDroitUtilisateur notDroit = new CDonneeNotificationChangementDroitUtilisateur(IdSession, CDbKey.CreateFromStringValue((string)row[CDonneesActeurUtilisateur.c_champIdUniversel]));
					CEnvoyeurNotification.EnvoieNotifications(new IDonneeNotification[] { notDroit });
				}
			}
			return result;
		}
	}
}
