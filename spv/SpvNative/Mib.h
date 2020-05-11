//
//  Mib.h
//
//  Auteur	: Jean-Pierre BORG
//  Date	: 03/01/2004
//
//  Ce module définit le document associé à un module MIB
//
//

#ifndef MIB_H
#define MIB_H

#ifndef __AFXEXT_H__
#include <afxext.h>
#endif

// #include "BddDoc.h"
//#include "DrawDoc.h"
#include "Cursor.h"
#include "Item.h"

/*
#ifndef _EXPORT_IMPORT
   #define EXP_IMP __declspec(dllexport)
#else
   #define EXP_IMP __declspec(dllimport)
#endif
*/

const int	CMIBOBJ_ID			= 13;

#define MAX_ENUM   2048 // Taille max. allouée à une liste énumérée
#define LONG_ENUM	 40 // Longueur max. d'un nom autorisée dans une liste énumérée

const int MAX_COLS = 40;	// nombre max. de colonnes

class CListColorNoImage;

const CString READ_WRITE	= (CString) "read-write";
const CString WRITE_ONLY	= (CString) "write-only";

static HINSTANCE	hInstanceSafe;	// sauvegarde du contexte resource

///////////////////////////////////////////////////////////////////////////////
// @class Cette classe permet de définir les objets découverts lors de la compilation
// @base public | CDialog
//
// Description d'un objet de la MIB

class CMibObj : public CItem
{

	DECLARE_DYNCREATE (CMibObj)

//@access Données publiques
public:
	CString	m_Type;		// Type de l'objet décrit : 
						//		MI		identité module			("MODULE-IDENTITY")
						//		ID		identifieur				("MODULE-IDENTIFIER", "OBJECT-IDENTITY")
						//		ENT		référence entreprise
						//		VT		variable de table		("columnar")
						//		Entry	données de table		(index, VT ..)
						//		TAB		table
						//		VS		variable simple			("scalar")
						//		TRAP	Trap V1
						//		TRAP2	Trap V2
						//		OG		Groupe d'objets			("OBJECT-GROUP")
						//		NG		Groupe de notifications ("NOTIFICATION-GROUP")
						//		MC		Conformité				("MODULE-COMPLIANCE")
						//		AC		Possibilités de l'agent	("AGENT-CAPABILITIES")
						//		TC		Conventions textuelles	("TEXTUAL-CONVENTION")

	CString	m_SNMPName;	// Nom de l'objet (en MIB)
	CString m_TableName;// Nom de la table pour les variables de table
	CString m_SeqName;	// Nom de l'identifieur de la séquence

	//@cmember	variables permettant le stockage des informations de compilation
	int		m_NbEnum;				// Nb. d'énumérés de l'objet
	int		m_iEnum;				// Indice de l'énuméré stocké dans la CMAP
	CString m_TypeEnum;				// "VAL"	pour des listes de valeurs (INTEGER, BITS)
									// "VTRAP"	pour des listes de "variableBindings" d'un trap
									// "VOBJ"	pour les listes d'objets d'un groupe
	long	m_CodeEn [MAX_ENUM];	// Code de l'objet énuméré
	CString	m_NameEn [MAX_ENUM];	// Nom de l'objet énuméré

	CString	m_Access;		// Type d'accès autorisé
	CString	m_Augments;		// Index complémentaire de la table
	CString	m_Constraint;	// Contraintes associées à l'objet
	CString	m_DefVal;		// Valeur par défaut
	CString	m_DisplayHint;	// Indications pour l'affichage
	CString	m_Enterprise;	// N° IANA de l'entreprise identifiée par cet objet
	CString	m_Index;		// Index de la table
	CString	m_Info;			// Champ description
	int		m_LineNbr;		// N° de la ligne du fichier source où l'objet est défini
	CString	m_OID;			// OID
	CString	m_Reference;	// Champ référence
	CString	m_Status;		// Status de l'objet
	int		m_TrapNbr;		// N° de trap, si l'objet est un trap
	CString	m_TypeSNMP;		// Type SNMP
	CString	m_Unit;			// Unité

//@access Constructeurs, destructeurs
public:
	//@cmember Construction d'un <c CMibObj>.
	CMibObj ();

//@access Méthodes publiques
public:
	//@cmember crée le curseur permettant de charger les données du module MIB
	virtual CCursor* SelectOrder ();

	//@cmember crée le curseur permettant de modifier les données du module MIB
	virtual CCursor* UpdateOrder ();

	//@cmember Chargement d'un module MIB à partir de la Bdd
	virtual bool Load ();

	//@cmember Retourne l'OID de l'objet
	CString GetOid() {return m_OID;};

	//@cmember Retourne l'accessibilité de la variable
	CString GetAccess() {return m_Access;};

	//@cmember Retourne le nombre d'énumérés de la variable
	int GetNbEnum() {return m_NbEnum;};

	//@cmember Retourne l'énuméré d'un certain index
	bool GetEnum (int nIndex, long *plCode, CString *pstrName);

	//@cmember Renvoie les contraintes concernant l'objet c'est à dire
	//la longueur, la valeur min et la valeur max.
	bool GetConstraints (long *plMin, long *plMax, int *pnLength);

	//@cmember Détermine les valeurs min et max dans une contrainte
	void GetMinMax (CString strConstraint, long *plMin, long *plMax);

	//@mfunc Détermine les valeurs min et max dans un groupe
	//de la forme n..m ou n .. m
	void GetMinMaxOneGroupe (CString strGroupe,	long *plMin, long *plMax);

	//@mfunc Détermine la longueur du nombre en fonction
	//du type de l'objet, de son min et de son max
	int GetLength (long lMin, long lMax);

	//@cmember Renvoie le code correspondant au nom d'un énuméré
	bool GetCodeEnumFromName (CString strName, long *pCode);


//@access Données membres 
public:
	CString	m_Comment;		// Commentaire libre de l'utilisateur
	BOOL	m_Visible;		// true si l'objet est visible (défaut), false sinon

};			// CMibObj


///////////////////////////////////////////////////////////////////////////////
// @class Cette classe permet de définir les paramètres d'un module de MIB
// @base public | CItem
//
// Description d'un module de MIB

class AFX_EXT_CLASS CMibModule : public CItem
{
	DECLARE_DYNCREATE (CMibModule)

//@access Données publiques
public:
	//@cmember Compteur d'objets créés (pour test)
	int	 m_NbObj;		
	//@cmember Compteur d'objets supprimés (pour test)
	int	 m_NbObjSupp;		
	//@cmember Nb. erreurs de compilation
	int	 m_NbErr;		
	//@cmember Nb. warnings de compilation
	int	 m_NbWarn;		

	//@cmember Id de la famille à laquelle le site appartient
	long m_FamilleId;
	//@cmember Nom de la famille
	CString m_FamilleNom;

	//@cmember  Tableau dynamique complémentaire, donnant les informations 
	// sur les objets de la MIB
	// Clé	 : "nom SNMP/Type" de l'objet		(si Type != VT)
	// Clé	 : "nom SNMP/VT/nom de la table"	(si Type == VT)
	// Objet : "CMibObj *"
	CMapStringToOb m_Objs;

	//@cmember  Tableau dynamique complémentaire, donnant la valeur des énumérés
	// Clé	 : "nom SNMP/Type" de l'objet		(si Type != VT)
	// Clé	 : "nom SNMP/VT/nom de la table"	(si Type == VT)
	// Objet : "CMibObj *"
	CMapStringToString m_ObjsEnum;

//@access Données internes
protected:
	CString	m_Ligne;		// Ligne en cours d'analyse
	int		m_LigneLong;	// Longueur de la ligne
	int		m_LigneNum;		// N° de ligne 1..
	int		m_Pos;			// Index du début de recherche du mot suivant, dans la ligne
	CMibObj	 *  m_pObj;		// Pointeur sur l'objet en cours d'analyse
	CString	m_MotRendu;		// Lorsque on a lu un mot de trop (cas du SubTyping, pour lequel
							// on ne peut pas savoir quand on est au bout, il faut "rendre"
							// ce mot pour permettre à ReadWord de continuer

	//@cmember	Nom du fichier d'erreur
	CString m_FileErr;
	//@cmember	Nom du fichier contenant les résultats, en mode Debug
	CString m_FileLog;

	//@cmember	Handle des fichiers correspondants
	FILE * fInput;				
	//FILE * fErr;
	//FILE * fLog;

	//@cmember CString dans lequel on vient stocker les erreurs de compilation
	CString m_strErrComp;

	//@cmember CString dans lequel on vient stocker les infos de log
	CString m_strLogComp;

//@access Constructeurs, destructeurs
public:
	//@cmember Construction d'un <c CMibModule>.
	CMibModule ();
	//@cmember Destruction d'un <c CMibModule>.
	~CMibModule();

	//@cmember Cette méthode est appelée juste avant de lancer  
	// <mf CDialog::DoModal> de la feuille de propriétés, lors de la création
	// de l'item.
	virtual void InitCreate (long BddId, long ClassId);

//@access Méthodes publiques
public:
	//@cmember suppression du module MIB sélectionné
	virtual CCursor* EraseOrder ();

	//@cmember crée le curseur permettant de charger les données du module MIB
	virtual CCursor* SelectOrder ();

	//@cmember crée le curseur permettant de créer les données du module MIB
	virtual CCursor* CreateOrder ();

	//@cmember crée le curseur permettant de modifier les données du module MIB
	virtual CCursor* UpdateOrder ();

	//@cmember Copie les éléments autres que ceux de la saisie
	virtual bool CopySuite (long lBddIdOrg, long lBddIdCop);

	//@cmember Retourne le chemin d'accès au fichier module MIB
	CString GetPath ();

	//@cmember Initialise le chemin d'accès au fichier module MIB
	void SetPath (char * lpszPath) {m_Path = lpszPath;};

	//@cmember Initialise le nom du module
	void SetModuleName (char * lpszName) {m_Name = lpszName;};

	//@cmember Connexion à la BDD puis compilation
	int CMibModule::ConnectAndCompile(char *chaineConnexion);

	//@cmember Compilation du module MIB
	int Compile ();

	//@cmember Traitement externe des erreurs de compilation
	void ExternError();

	//@cmember Renvoie le message suivant la position
	char * GetNextErrMess();

	//@cmember Indique s'il y a des erreurs de compilation
	bool AreCompileErrors() {return m_strErrComp.GetLength() > 0;};

	//@cmember Indique s'il y a des logs de compilation
	bool AreCompileLogs() {return m_strLogComp.GetLength() > 0;};

	//@cmember Retourne les erreurs de compilation
	char* GetCompileErrors();

	//@cmember Retourne les logs de compilation
	char* GetCompileLogs();

	//@cmember Les différentes fonctions réalisant la compilation
private:
	CStringList m_ErrMessages;	// Stocke les messages d'erreur à afficher
	POSITION	m_posMess;		// Position pour le parcours de cette liste
	bool		m_bFin;			// Indicateur de fin de balayage
	char*		m_lpszErrMess;	// Pointeur temporaire sur un message d'erreur
	char*		m_lpszErrComp;	// pointeur temporaire sur les erreurs de compilation
	char*		m_lpszLogComp;	// Pointeur temporaire sur les logs de compilation
	void		InitErrMess();	// Initialisation de la liste des messages


	int mibStocke ();			// Stocke en BDD les résultats de la compilation
	CString	ReadLine();			// Lecture d'une ligne de texte
	CString	ReadWord  (CString CarSep, CString SepAtt);				// Lecture d'un mot
	void	Erreur (int NumErr, bool bErr, CString Comment = _T(""));	// Traitement err. de compil.

	bool	mibFile ();			// Analyse le fichier indiqué, pour trouver le module demandé
	bool	mibCompile ();		// Compile le module
	CString moduleIdentifier();  // Lit le nom du module importé
	bool	importedItems ();	// Lit les IMPORTS
	bool	moduleIdentity();	// Lit les MODULE_IDENTITY
	bool	definitions ();		// Boucle générale. Lit et dispatche les définitions d'objets

	bool 	objectIdentifier();
	bool	objectIdentity();
	bool	objectTypeTable();
	bool	objectTypeEntry();
	CString	indexValue();
	bool	objectType();
	CString defVal();
	bool	trapType();
	bool	notificationType();
	bool	objectGroup();
	bool	notificationGroup();
	bool	moduleCompliance();
	bool	agentCapabilities();
	bool	QuatrePoints();		// Analyse ::=
	bool	textualConvention();
	bool	rangeSpec();
	bool	sequence();
	bool	simpleOrEnumOrBit (CString);

	CString	chrStr ();			// Lit les chaînes de caractères entre "
	CString	oidValue ();		// Lit et analyse les OID

//@access Données membres 

	//@cmember variables d'échange avec l'écran de dialogue
	//{{AFX_DATA(CMibModule)
	CString m_Path;				// répertoire + nom du fic. MIB en ASN1
	CString	m_Comment;			// commentaire libre
	CString	m_SNMPName;			// nom du module
	CString	m_Version;			// version, entrée par l'opérateur
	int	m_SMI;					// 0 si non définie, sinon 1 ou 2
	CString	m_Date;				// date du module, telle qu'elle figure dans la MIB
	CString	m_CompilDate;		// date de la dernière compilation sans erreur
	//}}AFX_DATA

};			// CMibModule



/////////////////////////////////////////////////////////////////////////////

#endif //MIB_H
