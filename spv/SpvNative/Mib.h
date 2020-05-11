//
//  Mib.h
//
//  Auteur	: Jean-Pierre BORG
//  Date	: 03/01/2004
//
//  Ce module d�finit le document associ� � un module MIB
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

#define MAX_ENUM   2048 // Taille max. allou�e � une liste �num�r�e
#define LONG_ENUM	 40 // Longueur max. d'un nom autoris�e dans une liste �num�r�e

const int MAX_COLS = 40;	// nombre max. de colonnes

class CListColorNoImage;

const CString READ_WRITE	= (CString) "read-write";
const CString WRITE_ONLY	= (CString) "write-only";

static HINSTANCE	hInstanceSafe;	// sauvegarde du contexte resource

///////////////////////////////////////////////////////////////////////////////
// @class Cette classe permet de d�finir les objets d�couverts lors de la compilation
// @base public | CDialog
//
// Description d'un objet de la MIB

class CMibObj : public CItem
{

	DECLARE_DYNCREATE (CMibObj)

//@access Donn�es publiques
public:
	CString	m_Type;		// Type de l'objet d�crit : 
						//		MI		identit� module			("MODULE-IDENTITY")
						//		ID		identifieur				("MODULE-IDENTIFIER", "OBJECT-IDENTITY")
						//		ENT		r�f�rence entreprise
						//		VT		variable de table		("columnar")
						//		Entry	donn�es de table		(index, VT ..)
						//		TAB		table
						//		VS		variable simple			("scalar")
						//		TRAP	Trap V1
						//		TRAP2	Trap V2
						//		OG		Groupe d'objets			("OBJECT-GROUP")
						//		NG		Groupe de notifications ("NOTIFICATION-GROUP")
						//		MC		Conformit�				("MODULE-COMPLIANCE")
						//		AC		Possibilit�s de l'agent	("AGENT-CAPABILITIES")
						//		TC		Conventions textuelles	("TEXTUAL-CONVENTION")

	CString	m_SNMPName;	// Nom de l'objet (en MIB)
	CString m_TableName;// Nom de la table pour les variables de table
	CString m_SeqName;	// Nom de l'identifieur de la s�quence

	//@cmember	variables permettant le stockage des informations de compilation
	int		m_NbEnum;				// Nb. d'�num�r�s de l'objet
	int		m_iEnum;				// Indice de l'�num�r� stock� dans la CMAP
	CString m_TypeEnum;				// "VAL"	pour des listes de valeurs (INTEGER, BITS)
									// "VTRAP"	pour des listes de "variableBindings" d'un trap
									// "VOBJ"	pour les listes d'objets d'un groupe
	long	m_CodeEn [MAX_ENUM];	// Code de l'objet �num�r�
	CString	m_NameEn [MAX_ENUM];	// Nom de l'objet �num�r�

	CString	m_Access;		// Type d'acc�s autoris�
	CString	m_Augments;		// Index compl�mentaire de la table
	CString	m_Constraint;	// Contraintes associ�es � l'objet
	CString	m_DefVal;		// Valeur par d�faut
	CString	m_DisplayHint;	// Indications pour l'affichage
	CString	m_Enterprise;	// N� IANA de l'entreprise identifi�e par cet objet
	CString	m_Index;		// Index de la table
	CString	m_Info;			// Champ description
	int		m_LineNbr;		// N� de la ligne du fichier source o� l'objet est d�fini
	CString	m_OID;			// OID
	CString	m_Reference;	// Champ r�f�rence
	CString	m_Status;		// Status de l'objet
	int		m_TrapNbr;		// N� de trap, si l'objet est un trap
	CString	m_TypeSNMP;		// Type SNMP
	CString	m_Unit;			// Unit�

//@access Constructeurs, destructeurs
public:
	//@cmember Construction d'un <c CMibObj>.
	CMibObj ();

//@access M�thodes publiques
public:
	//@cmember cr�e le curseur permettant de charger les donn�es du module MIB
	virtual CCursor* SelectOrder ();

	//@cmember cr�e le curseur permettant de modifier les donn�es du module MIB
	virtual CCursor* UpdateOrder ();

	//@cmember Chargement d'un module MIB � partir de la Bdd
	virtual bool Load ();

	//@cmember Retourne l'OID de l'objet
	CString GetOid() {return m_OID;};

	//@cmember Retourne l'accessibilit� de la variable
	CString GetAccess() {return m_Access;};

	//@cmember Retourne le nombre d'�num�r�s de la variable
	int GetNbEnum() {return m_NbEnum;};

	//@cmember Retourne l'�num�r� d'un certain index
	bool GetEnum (int nIndex, long *plCode, CString *pstrName);

	//@cmember Renvoie les contraintes concernant l'objet c'est � dire
	//la longueur, la valeur min et la valeur max.
	bool GetConstraints (long *plMin, long *plMax, int *pnLength);

	//@cmember D�termine les valeurs min et max dans une contrainte
	void GetMinMax (CString strConstraint, long *plMin, long *plMax);

	//@mfunc D�termine les valeurs min et max dans un groupe
	//de la forme n..m ou n .. m
	void GetMinMaxOneGroupe (CString strGroupe,	long *plMin, long *plMax);

	//@mfunc D�termine la longueur du nombre en fonction
	//du type de l'objet, de son min et de son max
	int GetLength (long lMin, long lMax);

	//@cmember Renvoie le code correspondant au nom d'un �num�r�
	bool GetCodeEnumFromName (CString strName, long *pCode);


//@access Donn�es membres 
public:
	CString	m_Comment;		// Commentaire libre de l'utilisateur
	BOOL	m_Visible;		// true si l'objet est visible (d�faut), false sinon

};			// CMibObj


///////////////////////////////////////////////////////////////////////////////
// @class Cette classe permet de d�finir les param�tres d'un module de MIB
// @base public | CItem
//
// Description d'un module de MIB

class AFX_EXT_CLASS CMibModule : public CItem
{
	DECLARE_DYNCREATE (CMibModule)

//@access Donn�es publiques
public:
	//@cmember Compteur d'objets cr��s (pour test)
	int	 m_NbObj;		
	//@cmember Compteur d'objets supprim�s (pour test)
	int	 m_NbObjSupp;		
	//@cmember Nb. erreurs de compilation
	int	 m_NbErr;		
	//@cmember Nb. warnings de compilation
	int	 m_NbWarn;		

	//@cmember Id de la famille � laquelle le site appartient
	long m_FamilleId;
	//@cmember Nom de la famille
	CString m_FamilleNom;

	//@cmember  Tableau dynamique compl�mentaire, donnant les informations 
	// sur les objets de la MIB
	// Cl�	 : "nom SNMP/Type" de l'objet		(si Type != VT)
	// Cl�	 : "nom SNMP/VT/nom de la table"	(si Type == VT)
	// Objet : "CMibObj *"
	CMapStringToOb m_Objs;

	//@cmember  Tableau dynamique compl�mentaire, donnant la valeur des �num�r�s
	// Cl�	 : "nom SNMP/Type" de l'objet		(si Type != VT)
	// Cl�	 : "nom SNMP/VT/nom de la table"	(si Type == VT)
	// Objet : "CMibObj *"
	CMapStringToString m_ObjsEnum;

//@access Donn�es internes
protected:
	CString	m_Ligne;		// Ligne en cours d'analyse
	int		m_LigneLong;	// Longueur de la ligne
	int		m_LigneNum;		// N� de ligne 1..
	int		m_Pos;			// Index du d�but de recherche du mot suivant, dans la ligne
	CMibObj	 *  m_pObj;		// Pointeur sur l'objet en cours d'analyse
	CString	m_MotRendu;		// Lorsque on a lu un mot de trop (cas du SubTyping, pour lequel
							// on ne peut pas savoir quand on est au bout, il faut "rendre"
							// ce mot pour permettre � ReadWord de continuer

	//@cmember	Nom du fichier d'erreur
	CString m_FileErr;
	//@cmember	Nom du fichier contenant les r�sultats, en mode Debug
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

	//@cmember Cette m�thode est appel�e juste avant de lancer  
	// <mf CDialog::DoModal> de la feuille de propri�t�s, lors de la cr�ation
	// de l'item.
	virtual void InitCreate (long BddId, long ClassId);

//@access M�thodes publiques
public:
	//@cmember suppression du module MIB s�lectionn�
	virtual CCursor* EraseOrder ();

	//@cmember cr�e le curseur permettant de charger les donn�es du module MIB
	virtual CCursor* SelectOrder ();

	//@cmember cr�e le curseur permettant de cr�er les donn�es du module MIB
	virtual CCursor* CreateOrder ();

	//@cmember cr�e le curseur permettant de modifier les donn�es du module MIB
	virtual CCursor* UpdateOrder ();

	//@cmember Copie les �l�ments autres que ceux de la saisie
	virtual bool CopySuite (long lBddIdOrg, long lBddIdCop);

	//@cmember Retourne le chemin d'acc�s au fichier module MIB
	CString GetPath ();

	//@cmember Initialise le chemin d'acc�s au fichier module MIB
	void SetPath (char * lpszPath) {m_Path = lpszPath;};

	//@cmember Initialise le nom du module
	void SetModuleName (char * lpszName) {m_Name = lpszName;};

	//@cmember Connexion � la BDD puis compilation
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

	//@cmember Les diff�rentes fonctions r�alisant la compilation
private:
	CStringList m_ErrMessages;	// Stocke les messages d'erreur � afficher
	POSITION	m_posMess;		// Position pour le parcours de cette liste
	bool		m_bFin;			// Indicateur de fin de balayage
	char*		m_lpszErrMess;	// Pointeur temporaire sur un message d'erreur
	char*		m_lpszErrComp;	// pointeur temporaire sur les erreurs de compilation
	char*		m_lpszLogComp;	// Pointeur temporaire sur les logs de compilation
	void		InitErrMess();	// Initialisation de la liste des messages


	int mibStocke ();			// Stocke en BDD les r�sultats de la compilation
	CString	ReadLine();			// Lecture d'une ligne de texte
	CString	ReadWord  (CString CarSep, CString SepAtt);				// Lecture d'un mot
	void	Erreur (int NumErr, bool bErr, CString Comment = _T(""));	// Traitement err. de compil.

	bool	mibFile ();			// Analyse le fichier indiqu�, pour trouver le module demand�
	bool	mibCompile ();		// Compile le module
	CString moduleIdentifier();  // Lit le nom du module import�
	bool	importedItems ();	// Lit les IMPORTS
	bool	moduleIdentity();	// Lit les MODULE_IDENTITY
	bool	definitions ();		// Boucle g�n�rale. Lit et dispatche les d�finitions d'objets

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

	CString	chrStr ();			// Lit les cha�nes de caract�res entre "
	CString	oidValue ();		// Lit et analyse les OID

//@access Donn�es membres 

	//@cmember variables d'�change avec l'�cran de dialogue
	//{{AFX_DATA(CMibModule)
	CString m_Path;				// r�pertoire + nom du fic. MIB en ASN1
	CString	m_Comment;			// commentaire libre
	CString	m_SNMPName;			// nom du module
	CString	m_Version;			// version, entr�e par l'op�rateur
	int	m_SMI;					// 0 si non d�finie, sinon 1 ou 2
	CString	m_Date;				// date du module, telle qu'elle figure dans la MIB
	CString	m_CompilDate;		// date de la derni�re compilation sans erreur
	//}}AFX_DATA

};			// CMibModule



/////////////////////////////////////////////////////////////////////////////

#endif //MIB_H
