using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using sc2i.doccode;
using timos.data;

// Les informations générales relatives à un assembly dépendent de 
// l'ensemble d'attributs suivant. Changez les valeurs de ces attributs pour modifier les informations
// associées à un assembly.
[assembly: AssemblyTitle("timos.data")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Futurocom")]
[assembly: AssemblyProduct("timos.data")]
[assembly: AssemblyCopyright("Copyright © Futurocom 2007")]
[assembly: AssemblyTrademark("Timos")]
[assembly: AssemblyCulture("")]

// L'affectation de la valeur false à ComVisible rend les types invisibles dans cet assembly 
// aux composants COM. Si vous devez accéder à un type dans cet assembly à partir de 
// COM, affectez la valeur true à l'attribut ComVisible sur ce type.
[assembly: ComVisible(false)]

// Le GUID suivant est pour l'ID de la typelib si ce projet est exposé à COM
[assembly: Guid("74994f47-cbe1-47c6-b756-37bd19ed0d29")]

// Les informations de version pour un assembly se composent des quatre valeurs suivantes :
//
//      Version principale
//      Version secondaire 
//      Numéro de build
//      Révision
//
// Vous pouvez spécifier toutes les valeurs ou indiquer les numéros de révision et de build par défaut 
// en utilisant '*', comme indiqué ci-dessous :
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]


//Documentation : Menu
//Veillez à ne pas utiliser deux fois le même id pour tous les elements Menus et MenuItem
[assembly: DocMenu(CDocLabels.c_mParametrage, "Paramétrage", "paramétrages", 0)]
[assembly: DocMenuItem(CDocLabels.c_iChampsCust, "Champs Custom", "Champs personnalisés, Formulaires...", CDocLabels.c_mParametrage, 2)]
[assembly: DocMenuItem(CDocLabels.c_iEtats, "Etats", "Etats Crystal Report...", CDocLabels.c_mParametrage, 0)]
[assembly: DocMenuItem(CDocLabels.c_iEO, "Entitées Organisationnelles", "EOs", CDocLabels.c_mParametrage, 3)]
[assembly: DocMenuItem(CDocLabels.c_iCoordonnees, "Coordonnées", "Système de Coordonnées", CDocLabels.c_mParametrage, 1)]
[assembly: DocMenuItem(CDocLabels.c_iProcess, "Processus - Evenements - Actions", "", CDocLabels.c_mParametrage, 4)]
[assembly: DocMenuItem(CDocLabels.c_iSecurite, "Securite", "Sécurité, Profils, Restrictions...", CDocLabels.c_mParametrage, 5)]


[assembly: DocMenu(CDocLabels.c_mPatrimoine, "Patrimoine", "Regroupe les entités à gérer", 1)]
[assembly: DocMenuItem(CDocLabels.c_iSite, "Sites", "Localisation", CDocLabels.c_mPatrimoine, 0)]
[assembly: DocMenuItem(CDocLabels.c_iStock, "Stock", "", CDocLabels.c_mPatrimoine, 1)]
[assembly: DocMenuItem(CDocLabels.c_iEquipement, "Equipement", "", CDocLabels.c_mPatrimoine, 2)]
[assembly: DocMenuItem(CDocLabels.c_iActeur, "Acteurs", "", CDocLabels.c_mPatrimoine, 3)]
[assembly: DocMenuItem(CDocLabels.c_iContrainte, "Contraintes - Ressources", "", CDocLabels.c_mPatrimoine, 4)]
[assembly: DocMenuItem(CDocLabels.c_iDossier, "Dossiers", "", CDocLabels.c_mPatrimoine, 6)]


[assembly: DocMenu(CDocLabels.c_mProcessMetier, "Processus métiers", "Processus à manager", 2)]
[assembly: DocMenuItem(CDocLabels.c_iIntervention, "Interventions", "Type d'intervention...", CDocLabels.c_mProcessMetier, 0)]
[assembly: DocMenuItem(CDocLabels.c_iTicket, "Tickets", "Types de tickets, Phases...", CDocLabels.c_mProcessMetier, 1)]
[assembly: DocMenuItem(CDocLabels.c_iPlanif, "Planification", "Agenda,  Calendrier...", CDocLabels.c_mProcessMetier, 2)]



//Ressources
//Les fichiers ressource doivent être copiés manuellement dans le répertoire de la documentation.
//[assembly: DocRessource(CDocLabels.c_dTypeEquipement, "Diagramme Type Equipement", "Diagramme du Type d'équipement", CDocLabels.c_dTypeEquipementPath, "", EDocRessourceType.Image)]
//[assembly: DocRessource(CDocLabels.c_dEquipement, "Diagramme", "Diagramme de l'équipement", CDocLabels.c_dEquipementPath, "", EDocRessourceType.Image)]
//[assembly: DocRessource(CDocLabels.c_dSite, "Diagramme", "Diagramme du site", CDocLabels.c_dSitePath, "", EDocRessourceType.Image)]
//[assembly: DocRessource(CDocLabels.c_dTicket, "Diagramme", "Diagramme du Ticket", CDocLabels.c_dTicketPath, "", EDocRessourceType.Image)]
//[assembly: DocRessource(CDocLabels.c_dTypePhase, "Diagramme", "Diagramme des Types de Phase pour les Tickets", CDocLabels.c_dTypePhasePath, "", EDocRessourceType.Image)]
//[assembly: DocRessource(CDocLabels.c_dIntervention, "Diagramme", "Diagramme des interventions", CDocLabels.c_dInterventionPath, "", EDocRessourceType.Image)]
//[assembly: DocRessource(CDocLabels.c_dCalendrier, "Diagramme", "Diagramme sur le Calendrier", CDocLabels.c_dCalendrierPath, "", EDocRessourceType.Image)]

//[assembly: DocRessource(CDocLabels.c_eProcessResolutionTicket, "Exemple de processus de résolution d'un Ticket", "", CDocLabels.c_eProcessResolutionTicketPath, "", EDocRessourceType.Image)]


//Liens vers les ressources
//Tout attribut en double est inutile > le lien ne peut être fait qu'une seule fois
[assembly: DocLienRessourceMenu("M2", "R1")]
[assembly: DocLienRessourceMenuItem("M2-2", "R1")]
[assembly: DocLienRessourceRessource("R1", "R1")]
[assembly: DocLienRessourceRessource("R1", "R1")]

