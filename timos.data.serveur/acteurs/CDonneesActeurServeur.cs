using System;
using System.Data;
using System.Collections;


using sc2i.common;
using sc2i.data.serveur;
using sc2i.data;
using timos.acteurs;
using sc2i.multitiers.client;
using sc2i.workflow;

namespace timos.acteurs.serveur
{
	/// <summary>
	/// Description résumée de CDonneesActeurServeur.
	/// </summary>
	[AutoExec("Autoexec")]
	public abstract class CDonneesActeurServeur : CObjetServeur
	{
		//-------------------------------------------------------------------
#if PDA
		public CDonneesActeurServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CDonneesActeurServeur( int nIdSession )
		:base(nIdSession)
		{
			
		}

		public static void Autoexec()
		{
            // Autorise à envoyer des messages instantanés
            sc2i.data.CDroitUtilisateur.RegisterDroitUtilisateur(
                0,
                CDonneeNotificationMessageInstantane.c_droitEnvoiMessageInstantane,
                I.T("Sending instant Messages|271"),
                0,
                CDroitDeBaseSC2I.c_droitInterface,
                I.T("Allows the user to send instantaneous messages|272"),
                OptionsDroit.Aucune);

            // Rédaction de l'aide en ligne
            sc2i.data.CDroitUtilisateur.RegisterDroitUtilisateur(
                0, CDroitDeBase.c_droitBaseRedactionAide,
                I.T("Online help writer|10013"),
                0,
                CDroitDeBaseSC2I.c_droitAdministration,
                I.T("Allow user to write Timos online help|10014"),
                OptionsDroit.Aucune);

            // Modules de paramétrage
            sc2i.data.CDroitUtilisateur.RegisterDroitUtilisateur(
                0, CDroitDeBase.c_droitBaseModulesParametrage,
                I.T("Setting Modules management|10015"),
                0,
                CDroitDeBaseSC2I.c_droitAdministration, 
                I.T("Allow user to access the Setting Module management window|10016"),
                OptionsDroit.Aucune);

            // Gestion des Utilisateurs de l'application
            sc2i.data.CDroitUtilisateur.RegisterDroitUtilisateur(
                0, CDroitDeBase.c_droitBaseGestionUtilisateurs,
                I.T("Application Users management|10017"),
                0,
                CDroitDeBaseSC2I.c_droitAdministration,
                I.T("Allow user to create and modify Application Users and manage their profiles|10018"),
                OptionsDroit.Aucune);

            // Gestion des sessions (console d'administration)
            sc2i.data.CDroitUtilisateur.RegisterDroitUtilisateur(
                0,
                CDroitDeBase.c_droitBaseGestionSessions,
                I.T("Manage session|20178"),
                0,
                CDroitDeBaseSC2I.c_droitAdministration,
                I.T("Allow user to manage active sessions|20179"),
                OptionsDroit.Aucune);

            // Management des workflows
            sc2i.data.CDroitUtilisateur.RegisterDroitUtilisateur(
                0,
                CDroitDeBase.c_droitBaseGestionWorkflows,
                I.T("Manage workflows|20178"),
                0,
                CDroitDeBaseSC2I.c_droitAdministration,
                I.T("Allow user to interact with running workflows|20179"),
                OptionsDroit.Aucune);
		}

		//-------------------------------------------------------------------
		public override CResultAErreur TraitementAvantSauvegarde ( CContexteDonnee contexte )
		{
			CResultAErreur result =  CResultAErreur.True;
			DataTable table = contexte.Tables[GetNomTable()];
			Type tpDonnees =  CContexteDonnee.GetTypeForTable ( GetNomTable() );
			ArrayList lst = new ArrayList ( table.Rows );
			foreach ( DataRow row in lst )
			{
				//Interdit la création de doublons
				if ( row.RowState == DataRowState.Added )
				{
					CListeObjetsDonnees liste = new CListeObjetsDonnees ( contexte, GetTypeObjets() );
					liste.Filtre = new CFiltreData ( CActeur.c_champId+"=@1",
						row[CActeur.c_champId] );
					if ( liste.CountNoLoad != 0 )
					{
						//On supprime la ligne !!
						row.Delete();
					}
				}

				if ( row.RowState == DataRowState.Modified || row.RowState == DataRowState.Added )
				{
					CDonneesActeur objet = (CDonneesActeur)Activator.CreateInstance ( tpDonnees,new object[]{row} );
					CResultAErreur resultVerif = VerifieDonnees ( objet );
					objet.IsDonneeActeurValide = VerifieDonnees(objet);
				}
			}
			return result;
		}
	}
}
