using System;
using System.Collections.Generic;
using System.Text;

namespace timos.data
{
    /// <summary>
    /// Classe qui sert à définir des constantes utilisées comme noms de menu et d'items
    /// dans la documentation
	/// c_m pour les Menus
	/// c_i pour les Items de Menus et Sous Items
	/// c_d pour les Diagrammes
	/// c_p pour les procédures
    /// c_e pour les exemples
    /// </summary>
    public class CDocLabels
	{
		#region Menus & Items
		//----------------------------------------------------------------------------------
        // Menu Paramétrage
        public const string c_mParametrage = "DOC_MENU_PARAM";
        // Items
        public const string c_iChampsCust= "DOC_ITEM_CHAMPSCUST";
        public const string c_iEtats = "DOC_ITEM_ETATS";
        public const string c_iEO = "DOC_ITEM_EO";
        public const string c_iCoordonnees = "DOC_ITEM_COORD";
        public const string c_iProcess = "DOC_ITEM_PROCESS";
        public const string c_iSecurite = "DOC_ITEM_SECURITE";
        

        //----------------------------------------------------------------------------------
        // Menu Patrimoine
        public const string c_mPatrimoine = "DOC_MENU_PATRIMOINE";
        // Items
        public const string c_iSite= "DOC_ITEM_SITE";
        public const string c_iStock = "DOC_ITEM_STOCK";
        public const string c_iEquipement = "DOC_ITEM_EQPT";
        public const string c_iActeur = "DOC_ITEM_ACTEUR";
        public const string c_iContrainte= "DOC_ITEM_CONT_RES";
        public const string c_iProjet = "DOC_ITEM_PROJET";
        public const string c_iDossier = "DOC_ITEM_DOSSIER";



        //----------------------------------------------------------------------------------
        // Menu Processus métiers
        public const string c_mProcessMetier = "DOC_MENU_METIER";
        // Items
        public const string c_iTicket = "DOC_ITEM_TICKET";
        public const string c_iIntervention = "DOC_ITEM_INTERVENTION";
        public const string c_iPlanif = "DOC_ITEM_PLANIF";
		#endregion

		#region Diagrammes
		public const string c_folderDiagrammes = @"Diagrammes\";

		public const string c_dCalendrier = "DOC_DIAG_CALENDRIER";
		public const string c_dCalendrierPath = c_folderDiagrammes + "Calendrier.JPG";

		public const string c_dEquipement = "DOC_DIAG_EQUIPEMENT";
		public const string c_dEquipementPath = c_folderDiagrammes + "Equipement.JPG";

		public const string c_dTypeEquipement = "DOC_DIAG_TEQUIPEMENT";
		public const string c_dTypeEquipementPath = c_folderDiagrammes + "TypeEquipement.JPG";

		public const string c_dSite = "DOC_DIAG_SITE";
		public const string c_dSitePath = c_folderDiagrammes + "Site.JPG";

		public const string c_dIntervention = "DOC_DIAG_INTERVENTION";
		public const string c_dInterventionPath = c_folderDiagrammes + "Intervention.JPG";

		public const string c_dTypePhase = "DOC_DIAG_TYPEPHASE";
		public const string c_dTypePhasePath = c_folderDiagrammes + "TypePhase.JPG";

		public const string c_dTicket = "DOC_DIAG_TICKET";
		public const string c_dTicketPath = c_folderDiagrammes + "Ticket.JPG";
		#endregion

        
        #region
        public const string c_folderImages = @"Images\";
        public const string c_eProcessResolutionTicket = "EX_PROCESS_RESOLUTION_TICKET";
        public const string c_eProcessResolutionTicketPath = c_folderImages + "Exemple de processus de résolution d'un Ticket.bmp";

        #endregion
    }
}
