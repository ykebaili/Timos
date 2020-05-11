//@doc ClassObj
//
// Project  : SPV
//
// Authors	: T. Aim� & X. Leconte & JP Borg
// Date		: 8/9/98 -- Cr�ation
// Release	: 1.0
//
//@module ClassObj |
// Tout objet de l'application doit pouvoir �tre stock� en base
// de donn�es et charg� donc instanci� dynamiquement. Pour que cela 
// soit possible, la classe de chaque objet devra �tre enregistr�e dans 
// l'ObjectRegistry de l'application. Ceci a pour effet d'associer un 
// identifiant � la classe de l'objet. Cette identifiant sera une 
// donn�e membre de l'objet et en tant que tel sera stock�e en base 
// de donn�e.
//@xref <c CObjectRegistery>

///////////////////////////////////////////////////////////////////////////////

#ifndef CLASSOBJ_H
#define CLASSOBJ_H

#include <afxtempl.h>
#include "UserRght.h"

//@access Constantes identifiant les classes dynamiques
// ATTENTION, NE PAS MODIFIER CELLES-CI CAR ELLES SONT ENREGISTREES EN BDD.

// Classes d�finies par JPB (1..999)
const int	CSUPERV_ID			= 1;		// Supervision
const int	CCONSULT_ID			= 2;		// Consultation
const int	CIMPR_ID			= 3;		// Impression
const int	CALARMG_ID			= 4;		// Alarme g�r�e
const int	CUSER_ID			= 5;		// Utilisateur
const int	CROLE_ID			= 6;		// R�le
const int	CPERIF_ID			= 7;		// P�riph�rique
const int	CACCSPV_ID			= 8;		// Connexion � un EDC 
const int	CSCRIPT_ID			= 9;		// Script  -- Rapports sur un script pr�cis
const int	CFAMSCRIPT_ID		= 10;		// Famille de Scripts
const int	CEXPORT_ID			= 11;		// Export de donn�es
const int	CMIBMODULE_ID		= 12;		// Module de MIB
const int	CMIBOBJ_ID			= 13;		// Objet de MIB
const int	CFAMMIB_ID			= 14;		// Famille de modules de MIBs
const int	CONGLET_ID			= 15;		// Onglet
const int	CFAMGRSITE_ID		= 16;		// Famille de groupe de sites
const int	CFAMIG_ID			= 17;		// Famille d'implantations g�ographiques
const int	CFAMCONSFICHE_ID	= 18;		// Famille de consultations de fiches

// Classes d�finies par XL (1000 .. 1999)
const int	CMODELSITE_ID		= 1000;		// Mod�le de site
const int	CSATELLITE_ID		= 1001;		// Satellite
const int	CMODELLIAI_ID		= 1002;		// Mod�le de liaison
const int	CTYPLIAI_ID			= 1003;		// Type de liaison
const int	CLIAI_SITE_ID		= 1004;		// Liaison
const int	CMODELPROG_ID		= 1005;		// Mod�le de programme
const int	CPROG_ID			= 1006;		// programme
const int	CFAMLIAI_ID			= 1007;		// Famille de liaison
const int	CSITE_ID			= 1008;		// Site
const int	CCONTACT_ID			= 1009;		// Contact
const int	CMODELSATELLITE_ID	= 1010;		// Mod�le de satellite
const int	CFAMEQT_ID			= 1011;		// Famille d'�quipement
const int	CFAMPROG_ID			= 1012;		// Famille de programme
const int	CFAMMODELCABL_ID	= 1013;		// Famille de mod�le de c�blage
const int	CMODELEQUIP_ID		= 1014;		// Mod�le d'�quipement
const int	CMODELCABL_ID		= 1015;		// Mod�le de c�blage
const int	CCABLEQU_ID			= 1016;		// C�blage inter-�quipements
const int	CSALLE_ID			= 1017;		// Salle
const int	CEQUIP_ID			= 1018;		// Equipement
const int	CACCES_ID			= 1019;		// Acc�s
const int	CCONSULTAL_ID		= 1020;		// Consultation d'historique d'alarmes
const int	CBUTTONBOX_ID		= 1021;		// Affichage de bo�te � bouton
const int	CDISCRI_ID			= 1022;		// Discriminateur
const int	CRACKHAM_ID			= 1023;		// Ev�nement rackham
const int	CTYPEQ_ID			= 1024;		// Type d'�quipement
const int	CMESS_ID			= 1025;		// Message s�rie
const int	CCLIENT_ID			= 1027;		// Client
const int	COPER_ID			= 1028;		// Op�rateur
const int	CFABRIC_ID			= 1029;		// Fabricant
const int	CCONSOLE_ID			= 1030;		// Console
const int	CFNCT_ID			= 1031;		// Fonction
const int   CEXT_ID				= 1032;     // Extr�mit�
const int	CBAIE_ID			= 1033;		// Baie
const int	CANTENNE_ID			= 1034;		// Antenne
const int	CFAMANT_ID			= 1035;		// Famille d'antenne
const int	CTYPANT_ID			= 1036;		// Type d'antenne
const int	CENTITE_ID			= 1037;		// Une entit� alarme s�rie
const int	CREPART_ID			= 1038;		// Un r�partiteur
const int	CFAMSITE_ID			= 1039;		// Famille de site
const int	CFAMREGL_ID			= 1040;		// Famille de r�glette
const int	CTYPREGL_ID			= 1041;		// Type de r�glette
const int   CBITALA_ID			= 1042;		// Bit d'alarme d'une entit� s�rie
const int	CTYPEQINC_ID		= 1043;		// Sous famille SNMP d'un type d'�quipement
const int	CFAMPREST_ID		= 1044;		// Famille de prestation
const int   CEQUIPSLOT_ID		= 1045;		// slot compl�mentaires d'un �quipement
const int	CFAMTYPPROG_ID		= 1046;		// Famille de type de prestation
const int	CTYPPROG_ID			= 1047;		// Type de prestation
const int	CFAMTOP_ID			= 1048;		// Famille de topologie
const int	CTOP_ID				= 1049;		// Topologie
const int	CFAMORDER_ID		= 1050;		// Famille de demande
const int	CORDER_ID			= 1051;		// Demande
const int	CFAMTYPSITE_ID		= 1052;		// Famille de type de sites		vs. 3231
const int	CTYPSITE_ID			= 1053;		// Type de sites				vs. 3232
const int   CVUERES_ID			= 1054;		// Comme CBUTTONBOX_ID mais pour le Vue Reseau
const int	CARCH_ID			= 1055;		// Archive
const int	CCONSFICHE_ID		= 1056;		// Consultation de fiche
const int	CFAMFLUX_ID			= 1057;		// Famille de prestation

// Classes d�finies par TA (2000 .. 2999)
const int CDRAW_OBJ_ID				= 2000;
const int CDRAW_RECTANGLE_ID		= 2001;
const int CDRAW_LINE_ID				= 2002;
const int CDRAW_ELLIPSE_ID			= 2003;
const int CDRAW_ROUND_RECT_ID		= 2004;
const int CDRAW_TEXT_ID				= 2005;
const int CDRAW_POLY_ID				= 2006;
const int CDRAW_GROUP_ID			= 2007;
const int CDRAW_ITEM_ID				= 2008;
const int CDRAW_OLE_ID				= 2009;
const int CDRAW_LINK_ID				= 2010;
const int CDRAW_ACCESS_ID			= 2011;
const int CDRAW_EDIT_ID				= 2012;
const int CDRAW_ITEM_SENS_ID		= 2013;
const int CDRAW_BUTTON_ID			= 2014;
const int CDRAW_TYPED_ITEM_ID		= 2015;
const int CDRAW_POLY_LINE_ID		= 2016;
const int CDRAW_POLY_SPLINE_ID		= 2017;
const int CDRAW_LABEL_ID			= 2018;

// suite des constantes pour le dessin � partir de 2050

const int CFICHECONTROL_CHECKBOX_ID		= 2019;
const int CFICHECONTROL_RADIOBUTTON_ID	= 2020;
const int CFICHECONTROL_SLIDER_ID		= 2021;
const int CFICHECONTROL_BUTTON_ID		= 2022;
const int CFICHECONTROL_GROUPBOX_ID		= 2023;
const int CFICHECONTROL_LISTDYN_ID		= 2024;
const int CFICHECONTROL_WRKF_ID			= 2025;
const int CFICHECONTROL_TABLE_ID		= 2026;

const int CBOUTON_ID				= 2030;
const int CLIAI_EQUIP_ID			= 2031;
const int CBINDDOC_ID				= 2032;		// Document attach�
const int CPROG_SITE_ID				= 2033;
const int CCABLEQ_EQUIP_ID			= 2034;
const int CACCES_TRANS_ID			= 2035;
const int CSYMB_LIBRARY_ID			= 2036;		// Librairie de symbole
const int CALARMCOUL_ID				= 2037;
const int CPROG_LIAI_ID				= 2038;
const int CMAILALRM_ID				= 2039;		// Liste de mailing d'alarmes
const int CACCES_GROUP_ID           = 2040;		// Acc�s group�s
const int CDRAW_LIST_POS			= 2041;		//Position du ListBox; VueResea, edition
const int CDRAW_PICTURE_ID			= 2042;
const int CTRAPBINDVAR_ID			= 2043;		// Binding variable d'un trap 
const int CDRAW_CABL_ATTCH			= 2044;		// Dessin du cablage attach� (de liaison ou de topo) dans des cablages des autres items (prestations, topologies, liaisons)
const int CDRAW_ACCESSGR_ID			= 2050;

// Classes des noeuds statiques (3000 .. 3999)
const int CO_SUPERVS_ID				= 3001;
const int CO_LISTS_ID				= 3002;
const int CO_GPROGS_ID				= 3003;
const int CO_JOURNS_ID				= 3004;
const int CO_CONSULTS_ID			= 3005;
const int CO_CONFIGS_ID				= 3006;
const int CO_MODELTYPE_ID			= 3007;
const int CO_LIBRARIES_SYMB_ID		= 3008;
const int CO_PRESTS_ID				= 3009;
const int CO_CABLS_ID				= 3010;
const int CO_CABLIAIS_ID			= 3012;
const int CO_CABPRESTS_ID			= 3013;
const int CO_CABTOPS_ID				= 3014;
const int CO_LIAIS_ID				= 3017;
const int CO_LIAIACCALS_ID			= 3020;
const int CO_TYPLIAIS_ID			= 3022;
const int CO_TYPEQS_ID				= 3023;
const int CO_TYPEQACCALS_ID			= 3025;
const int CO_EQUIPS_ID				= 3027;
const int CO_EQUIPTABS_ID			= 3028;
const int CO_FNCTS_ID				= 3030;
const int CO_MESSAGES_ID			= 3031;
const int CO_SITES_ID				= 3032;
const int CO_SITESALLES_ID			= 3035;
const int CO_SITEACCALS_ID			= 3036;
const int CO_SITEEXTS_ID			= 3037;
const int CO_SATS_ID				= 3041;
const int CO_TYPANTS_ID				= 3042;
const int CO_ANTENNES_ID			= 3043;
const int CO_INTERLOCS_ID			= 3046;
const int CO_CLIENTS_ID				= 3047;
const int CO_OPERS_ID				= 3048;
const int CO_FABRICS_ID				= 3049;
const int CO_SECURS_ID				= 3050;
const int CO_CONSOLES_ID			= 3051;
const int CO_ROLES_ID				= 3054;
const int CO_USERS_ID				= 3055;
const int CO_SALLEBAIES_ID			= 3058;
const int CO_SALLEREPARTS_ID		= 3059;
const int CO_TYPREGLS_ID			= 3060;
const int CO_TOUSTYPES_ID			= 3061;
const int CO_TYPEQSSFAMSNMPS_ID		= 3062;
const int CO_TOUTESPRESTS_ID		= 3063;
const int CO_TYPPROGS_ID			= 3064;
const int CO_PRESTNONTYPEES_ID		= 3065;
const int CO_PRESTTYPEES_ID			= 3066;
const int CO_TOUSTYPPROGS_ID		= 3067;
const int CO_VUE_RES_ID				= 3068;
const int CO_CONSFICHES_ID			= 3069;
const int CO_TOUTESCONSFICHES_ID	= 3070;
const int CO_FLUXS_ID				= 3071;
const int CO_TOUTESFLUXS_ID			= 3072;

const int CO_MAILALRM_ID			= 3075;

const int CO_TOUTESLIAIS_ID			= 3081;
const int CO_CABLTOUTESLIAIS_ID		= 3082;

const int CO_SCRIPTS_ID				= 3091;		// Rapports sur l'ensemble des scripts
const int CO_TOUSSCRIPTS_ID			= 3092;

const int CO_TOPS_ID				= 3100;		// Topologies
const int CO_TOUTESTOPS_ID			= 3101;		// Famille toutes topologies

const int CO_MIBS_ID				= 3102;		// Modules de MIBs
const int CO_TOUSMIBS_ID			= 3103;		// Famille tous modules de MIBs
const int CO_MIBVSCALS_ID			= 3104;		// Variables scalaires
const int CO_MIBTABS_ID				= 3105;		// Tables
const int CO_MIBTRAPS_ID			= 3106;		// Traps

const int CO_GRSITES_ID				= 3120;		// Groupes de diffusion		
const int CO_IGS_ID					= 3121;		// Implantations g�ographiques		
const int CO_CONSPSGEO_ID			= 3122;		// Consultation de PS par g�ographie (TDF)
const int CO_CONSPSCLIENT_ID		= 3123;		// Consultation de PS par client (TDF)

const int CO_MODELCABLS_ID			= 3210;		// Mod�les de c�blage
const int CO_TOUSMODELCABLS_ID		= 3211;		// Famille tous mod�les de c�blage

const int CO_ORDERS_ID				= 3220;		// Demandes clients
const int CO_TOUSORDERS_ID			= 3221;		// Famille toutes demandes

const int CO_TYPSITES_ID			= 3230;		// Types de sites
const int CO_TOUSTYPSITES_ID		= 3233;		// Tous types de sites

const int CO_VTOPS_ID				= 3240;		// Topologies (consultations TDF)
const int CO_VTOUTESTOPS_ID			= 3241;		// Famille toutes topologies (consultations TDF)
const int CO_VTOUTESPRESTS_ID		= 3242;		// Famille toutes prestations (consultations TDF)
const int CO_VTOUTESFLUXS_ID		= 3243;		// Famille toutes prestations (consultations TDF)

const int CO_SYSTEM_ID				= 3250;		// Syst�me

const int CO_MAX					= 3250;		// En cas d'ajout de constantes, augmenter CO_MAX
												// Aucune constante ne doit d�passer CO_MAX
												// (utilis� pour v�rifier que un pointeur pointe vers un objet valide
												//  voir par exemple CDrawView::OnEditClear).

///////////////////////////////////////////////////////////////////////////////
// @class Cette classe permet de cr�er dynamiquement un objet � 
// partir de l'identifiant de sa classe (<mf CObjectRegistery::CreateObject>)
// ainsi que de g�rer les droits d'acc�es aux instances de la classe.
// Cela suppose pr�alablement d'enregistrer la classe de l'objet
// (<mf CObjectRegistery::RegisterObject>).
 
class CObjectRegistery
{

//@access Constructeurs, destructeurs
public:
	//@cmember Construction d'un <c CObjectRegistery>. C'est dans le
	// constructeur que seront enregistr�s les objets. 
	CObjectRegistery ();

	//@cmember Destructeur d'un <c CObjectRegistery>.
	~CObjectRegistery () {};

//@access Acc�s donn�es membres
public:
	//@cmember Retourne le pointeur sur la <c CRuntimeClass> pour un
	// objet dont l'identifiant de classe est <p ClassId>.
	const CRuntimeClass* GetRuntimeClass (int ClassId)
	{
		CObjectInfo ObjectInfo;
		m_MapObjectInfo.Lookup (ClassId, ObjectInfo);
		return ObjectInfo.m_pRuntimeClass;
	};

	//@cmember Retourne le nom de la table principale en base de 
	// donn�es pour un objet dont l'identifiant de classe est 
	//<p ClassId>.
	const CString GetTableName (int ClassId)
	{
		CObjectInfo ObjectInfo;
		m_MapObjectInfo.Lookup (ClassId, ObjectInfo);
		return ObjectInfo.m_TableName;
	};

	//@cmember Retourne le nom de la classe identifi�e par <p ClassId>.
	const CString GetClassName (int ClassId)
	{
		CObjectInfo ObjectInfo;
		m_MapObjectInfo.Lookup (ClassId, ObjectInfo);
		return ObjectInfo.m_ClassName;
	};

	//@cmember Retourne l'index permettant d'associer des 
	// droits aux objets de la classe (Voir <mf CObjectRegistery::RightFor>).
	const int GetRightBase (int ClassId)
	{
		CObjectInfo ObjectInfo;
		if (!m_MapObjectInfo.Lookup (ClassId, ObjectInfo))
			return PRI_EMPTY;
		
		return ObjectInfo.m_RightBase;
	};

//@access M�thodes statiques
public:
	bool Init();
	//@cmember Enregistrement de la classe d'un objet.
	void RegisterObject (long ClassId, CRuntimeClass* RuntimeClass, 
			CString TableName, CString PrettyClassName, int RightBase);

	//@cmember Instancie un objet dont la classe est d�sign� par 
	// <p ClassId>.
	CObject* CreateObject (long ClassId)
	{ 
		CObjectInfo ObjectInfo;
		if (m_MapObjectInfo.Lookup (ClassId, ObjectInfo) == NULL)
			return NULL;
		else
			return (CObject*) (ObjectInfo.m_pRuntimeClass->CreateObject ());
	};

	//@cmember Retourne vrai si l'utilisateur dispose du droit de consulter
	// ou de modifier les instances interne ou externe de la classe identifi�e
	// par <p ClassId>.
	bool RightFor (int ClassId,	int ActIdx,	int LocationIdx, CItem * pFather = NULL);

	//@cmember Cette m�thode construit la cha�ne de  caract�res 
	// compos�e de la liste des nom des classes d'item contenu dans
	// la table nomm� en param�tre.
	void GetClassesNames ( const CString& TableName, CString& ClassesNames);

private:
	// Chaque entr�e de l'ObjectRegistery est contitu� d'un CObjectInfo
	class CObjectInfo
	{
		public:
			CObjectInfo (){};

			CObjectInfo ( CRuntimeClass* pRuntimeClass,
				CString TableName, CString ClassName, int RightBase)
				{ m_pRuntimeClass = pRuntimeClass; 
			m_TableName = TableName; m_ClassName = ClassName; m_RightBase = RightBase;};

		public:
			CRuntimeClass* m_pRuntimeClass;
			CString		   m_TableName;
			CString		   m_ClassName;
			int			   m_RightBase;
	};

	// L'ensemble des entr�es de l'ObjectRegistry
	CMap< int, int, CObjectInfo, CObjectInfo> m_MapObjectInfo;
};

//@globalv l'ObjectRegistery de l'application doit �tre accessible
// partout.
extern CObjectRegistery ObjectRegistery;


//@ex L'exemple suivant montre comment les classes de divers objets
// sont enregitr�es, au niveau du contructeur de l'ObjectRegistery. 
// Ainsi la classe CSite est enregistr�e avec pour identifiant de 
// classe 1; la table principale en base de donn�es pour les objets 
// de classe CSite sera la table de nom "SITE" et enfin les droits
// pour les instances de cette classe seront fournis par PRI_SITE
// (<mf CObjectRegistery::RightFor>)|
//
// CObjectRegistery::CObjectRegistery ()
// {
//	    RegisterObject( 1, RUNTIME_CLASS (CSite), "SITE", PRI_SITE);
//	    RegisterObject( 2, RUNTIME_CLASS (CModelSite), "MODELSITE", PRI_MODEL);
// };
	

#endif //CLASSITEM_H