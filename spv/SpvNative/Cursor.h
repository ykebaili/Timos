//@doc Cursor
//
// Project  : SPV
//
// Authors	: T. Aimé & X. Leconte
// Date		: 9/6/98 -- Création
// Release	: 1.0
//
//@module cursor |
// Encapsulation de la notion et de la manipulation de curseur de 
// l'OCI Oracle, grâce a <c CCursor>.
//@xref <c CCursor> <c COracleError> <c CVarInfo>
//////////////////////////////////////////////////////////////////////

#ifndef CURSOR_H
#define CURSOR_H

#include <afxtempl.h>

#ifdef TEST_OCI
	#include "OraBdd.h"
#else 
	#include "Bdd.h"
#endif

//@const Indique l'état d'un curseur valide 
const int OK = 1; 
// valeur impérative, car tests : if (! **.Exec())

//@const Indique l'état d'un curseur non valide
const int KO = 0; 
// valeur impérative, car tests : if (! **.Exec())

//@const Interrogation réguliere par le serveur
const int CAVA = 3; 

//@const Valeur de retour de <mf CBdd::ExecInsert>, lorsqu'une clé est dupliquée
const int DUPLIC_KEY = 2;

//@const odefinps de l'OCI réalisé "par morceau"
const int PIECEWISE    = 0;	

//@const odefinps de l'OCI standard "en bloc"
const int NO_PIECEWISE = 1;	

//@const Aucune erreur !
const int ORA00000  = 0;

//@const Erreur violation d'une contrainte d'unicité
const int ORA00001	= 1;

//@const Erreur Ressource occupée
const int ORA00054	= 54;

//@const Une Colonne obligatoire est null en création
const int ORA01400  = 1400;

//@const Une Colonne obligatoire est null en modification
const int ORA01407  = 1407;

//@const Erreur violation d'une contrainte d'intégrité parent inexistant
const int ORA02291	= 2291;

//@const Erreur violation d'une contrainte d'intégrité enfant inexistant
const int ORA02292	= 2292;

//@const Ordre SQL inachevé
const int ORA03123  = 3123;

///////////////////////////////////////////////////////////////////////////////
// @class Cette classe est définie dans le cadre du traitement des 
// exceptions provoquées par l'OCI. c'est une classe vide, aucune
// donnée étant neccesaire au traitement de l'exception.

class COracleError {};


///////////////////////////////////////////////////////////////////////////////
// @class Cette classe permet de stocker les informations neccesaire 
// au lien entre variables C++ et variables OCI. Les informations
// sont obtenues lors du parsing de l'ordre SQL associé à un curseur.

class CVarInfo
{
//@access Constructeurs, destructeurs
public:
	//@cmember Construction d'un <c CVarInfo>.
	CVarInfo (CString &Name, CString &Size, char Type, UINT nArraySize);
	
	//@cmember Destruction d'un <c CVarInfo>.
	~CVarInfo ();

//@access Données publiques
public:
	//@cmember Nom du placeholder ou de la colonne.
	char m_Name[MAX_SQL_IDENT + 1]; 

	//@cmember Taille de la variable C++ associé;
	int	 m_Size;
	
	//@cmember Type de la variable pour l'OCI.
	int  m_OCIType;
	
	//@cmember Type de la variable pour C++.
	int  m_TypeC;

	//@cmember Buffer d'échange pour les CString.
	char* m_CStringBuf;

	//@cmember Pointeur sur la variable C++.
	void* m_pVar;

	//@cmember Zone d'information écrite par l'OCI.
	sb2  m_indp;

	//@cmember Pointeur sur zone d'information écrite par l'OCI pour les fetch multilignes.
	sb2* m_Tindp;

	//@cmember pointeur sur un tableau de pointeurs sur des chaînes de caractères
	// pour les select
	char* m_pTChar;

};

// @type CVarInfoList | Liste de pointeurs d'objet CVarInfo.
typedef CList<CVarInfo*, CVarInfo*> CVarInfoList;


///////////////////////////////////////////////////////////////////////////////
//@class Cette classe encapsule les mécanismes de l'OCI d'interface
// avec une base Oracle.

class CCursor
{
public:
//@access Constructeurs, destructeurs

	//@cmember Construction d'un <c CCursor>.	
	CCursor( CBdd *pDataBase, CString SQLString, ...);
	CCursor( CBdd *pDataBase, UINT IdSQLString, ...);

	//@cmember Destruction d'un <c CCursor>.	
	virtual ~CCursor();

//@access Méthodes statiques

	//@cmember retourne vrai si le curseur est actif et faux si le curseur
	// est en erreur
	bool IsOk ()
		{ return m_Status;};

	//@cmember Encapsulation de la commande oexec de l'OCI.
	bool Exec ();

	//@cmember Encapsulation de la commande oexec de l'OCI, si
	// aucune réponse n'est obtenue avant <p TimeOut> milli-secondes
	// la méthode rend quand même la main.
	bool Exec (DWORD TimeOut);

	//@cmember Encapsulation de la commande ofetch de l'OCI. Si le nombre de ligne à
	// rechercher est à 0, il faut prendre la valeur par défaut de m_ArraySize dans CBdd,
	// sinon, il faut prendre la valeur de ce paramètre.
	int  Fetch (UINT nNbLineToFetch = 0);
	
	//@cmember Variante de la méthode <mf CBdd::Exec> n'entrainant pas
	// l'affichage d'un message d'erreur en cas de clés dupliquées,
	// mais simplement KO.
	bool ExecInsert ();

	//@cmember Teste si la valeur retournée par l'OCI après un ofetch
	// où un oexec est NULL ou non.
	bool IsNull (char* ArgPtr);
	
	//@cmember Cette méthode permet de spécifier un nouveau message
	// en réponse à une erreur Oracle
	void CatchOraMess (int OracleMessId, CString* pMessage);

	//@cmember Récupère dans <p OraMess> le message Oracle décrivant 
	// l'état courant du curseur
	void GetOraMess (CString& OraMess);
	
	//@cmember Retourne l'Id Oracle de l'état courant du curseur
	int GetOraId ()
		{ return m_Cursor.rc;};

	//@cmember Affiche après une erreur Oracle une boite de message
	// explicative.
	void OCIMessageBox ();

//@access Données protégées
protected:

	//@cmember Texte de l'ordre SQL; on est en effet obligé de recopier localement
	// le CString de l'ordre, sinon Oracle donne l'erreur 972 au moment du oxec lorsqu'on
	// travaille en mode différé (en mode non différé ce pb ne se produit pas).
	char* m_TextSQL;

	//@cmember Base de données Oracle sur laquelle sera ouvert le curseur.
	CBdd* m_pBdd;

	//@cmember Curseur de l'OCI encapsulé.
	Cda_Def	m_Cursor;

	//@cmember Liste des informations nécessaires pour lier variables C++
	//et placeholder ou colonne de la requête SQL
	CVarInfoList m_VarInfoList;

	//@cmember Lorsque <m m_Status> vaut vrai le Curseur est actif,
	// sinon le curseur est en erreur.
	bool m_Status;

	//@cmember Nombre de lignes retournées pour un fetch si le curseur est un select
	UINT  m_nNbLine;

	//@cmember Nombre de lignes à rechercher en bdd en une seule fois par la fonction de
	// recherche de l'OCI Oracle
	UINT m_NbLineForFetch ();

	//@cmember Index de la dernière ligne retournée par le fetch (dans le tableau
	//de variable de taille m_ArraySize)
	UINT  m_nIndLine;

	CMap< int, int, CString*, CString*> m_CatchMessMap;

private:
	// Extraction de la chaine SQL des informations permettant 
	// le lien entre variables C++ et OCI.
	bool ExtractVarInfo (char* szSQL);

	// Etablissement du lien entre variables C++ et OCI
	void BindOCIVariables( CString& SQLString, va_list ArgList);

	// Lance proprement parlé l'execution de l'ordre SQL, Mode
	// pouvant être NON_BLOCKING ou BLOCKING
	bool Exec (int Mode, DWORD TimeOut);
};



//@ex L'exemple suivant montre comment utiliser les objets <c CCurseur> |
// L'ordre SQL brut sera le suivant :
// select sstring, string, charactere, long_num,
// float_num, double_num 
// from testoci where int_num = 1;
//
// Les variables C++ recevant le résultat sont déclarées
// de la façon suivante :
// CString SString;
// char    String[20];
// char    Character;
// long    LongNum;
// float   FloatNum;
// double  DoubleNum;
//
// L'entier sur lequel repose la sélection sera :
// int	   IntNum = 1;
// 
// L'utilisation du curseur sera la suivante 
// CCursor Cursor( &Bdd,
//	"select \
//		#20S#sstring, \
//		#20s#string, \
//		#c#charactere, \
//		#l#long_num, \
//		#f#float_num, \
//		#d#double_num \
//	from testoci where int_num = #i#:int",
// &SString, String, &Charactere,  &LongNum, &FloatNum, 
// &DoubleNum, &IntNum,);
//
// L'odre SQL est exécuté avec l'appel :
// Cursor.Exec();
//
// Chaque enregistrement répondant à la requête est 
// retrouvé par l'appel :
// Cursor.Fetch();


#endif // CURSOR_H
