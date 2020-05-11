//@doc Cursor
//
// Project  : SPV
//
// Authors	: T. Aim� & X. Leconte
// Date		: 9/6/98 -- Cr�ation
// Release	: 1.0
//
//@module cursor |
// Encapsulation de la notion et de la manipulation de curseur de 
// l'OCI Oracle, gr�ce a <c CCursor>.
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

//@const Indique l'�tat d'un curseur valide 
const int OK = 1; 
// valeur imp�rative, car tests : if (! **.Exec())

//@const Indique l'�tat d'un curseur non valide
const int KO = 0; 
// valeur imp�rative, car tests : if (! **.Exec())

//@const Interrogation r�guliere par le serveur
const int CAVA = 3; 

//@const Valeur de retour de <mf CBdd::ExecInsert>, lorsqu'une cl� est dupliqu�e
const int DUPLIC_KEY = 2;

//@const odefinps de l'OCI r�alis� "par morceau"
const int PIECEWISE    = 0;	

//@const odefinps de l'OCI standard "en bloc"
const int NO_PIECEWISE = 1;	

//@const Aucune erreur !
const int ORA00000  = 0;

//@const Erreur violation d'une contrainte d'unicit�
const int ORA00001	= 1;

//@const Erreur Ressource occup�e
const int ORA00054	= 54;

//@const Une Colonne obligatoire est null en cr�ation
const int ORA01400  = 1400;

//@const Une Colonne obligatoire est null en modification
const int ORA01407  = 1407;

//@const Erreur violation d'une contrainte d'int�grit� parent inexistant
const int ORA02291	= 2291;

//@const Erreur violation d'une contrainte d'int�grit� enfant inexistant
const int ORA02292	= 2292;

//@const Ordre SQL inachev�
const int ORA03123  = 3123;

///////////////////////////////////////////////////////////////////////////////
// @class Cette classe est d�finie dans le cadre du traitement des 
// exceptions provoqu�es par l'OCI. c'est une classe vide, aucune
// donn�e �tant neccesaire au traitement de l'exception.

class COracleError {};


///////////////////////////////////////////////////////////////////////////////
// @class Cette classe permet de stocker les informations neccesaire 
// au lien entre variables C++ et variables OCI. Les informations
// sont obtenues lors du parsing de l'ordre SQL associ� � un curseur.

class CVarInfo
{
//@access Constructeurs, destructeurs
public:
	//@cmember Construction d'un <c CVarInfo>.
	CVarInfo (CString &Name, CString &Size, char Type, UINT nArraySize);
	
	//@cmember Destruction d'un <c CVarInfo>.
	~CVarInfo ();

//@access Donn�es publiques
public:
	//@cmember Nom du placeholder ou de la colonne.
	char m_Name[MAX_SQL_IDENT + 1]; 

	//@cmember Taille de la variable C++ associ�;
	int	 m_Size;
	
	//@cmember Type de la variable pour l'OCI.
	int  m_OCIType;
	
	//@cmember Type de la variable pour C++.
	int  m_TypeC;

	//@cmember Buffer d'�change pour les CString.
	char* m_CStringBuf;

	//@cmember Pointeur sur la variable C++.
	void* m_pVar;

	//@cmember Zone d'information �crite par l'OCI.
	sb2  m_indp;

	//@cmember Pointeur sur zone d'information �crite par l'OCI pour les fetch multilignes.
	sb2* m_Tindp;

	//@cmember pointeur sur un tableau de pointeurs sur des cha�nes de caract�res
	// pour les select
	char* m_pTChar;

};

// @type CVarInfoList | Liste de pointeurs d'objet CVarInfo.
typedef CList<CVarInfo*, CVarInfo*> CVarInfoList;


///////////////////////////////////////////////////////////////////////////////
//@class Cette classe encapsule les m�canismes de l'OCI d'interface
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

//@access M�thodes statiques

	//@cmember retourne vrai si le curseur est actif et faux si le curseur
	// est en erreur
	bool IsOk ()
		{ return m_Status;};

	//@cmember Encapsulation de la commande oexec de l'OCI.
	bool Exec ();

	//@cmember Encapsulation de la commande oexec de l'OCI, si
	// aucune r�ponse n'est obtenue avant <p TimeOut> milli-secondes
	// la m�thode rend quand m�me la main.
	bool Exec (DWORD TimeOut);

	//@cmember Encapsulation de la commande ofetch de l'OCI. Si le nombre de ligne �
	// rechercher est � 0, il faut prendre la valeur par d�faut de m_ArraySize dans CBdd,
	// sinon, il faut prendre la valeur de ce param�tre.
	int  Fetch (UINT nNbLineToFetch = 0);
	
	//@cmember Variante de la m�thode <mf CBdd::Exec> n'entrainant pas
	// l'affichage d'un message d'erreur en cas de cl�s dupliqu�es,
	// mais simplement KO.
	bool ExecInsert ();

	//@cmember Teste si la valeur retourn�e par l'OCI apr�s un ofetch
	// o� un oexec est NULL ou non.
	bool IsNull (char* ArgPtr);
	
	//@cmember Cette m�thode permet de sp�cifier un nouveau message
	// en r�ponse � une erreur Oracle
	void CatchOraMess (int OracleMessId, CString* pMessage);

	//@cmember R�cup�re dans <p OraMess> le message Oracle d�crivant 
	// l'�tat courant du curseur
	void GetOraMess (CString& OraMess);
	
	//@cmember Retourne l'Id Oracle de l'�tat courant du curseur
	int GetOraId ()
		{ return m_Cursor.rc;};

	//@cmember Affiche apr�s une erreur Oracle une boite de message
	// explicative.
	void OCIMessageBox ();

//@access Donn�es prot�g�es
protected:

	//@cmember Texte de l'ordre SQL; on est en effet oblig� de recopier localement
	// le CString de l'ordre, sinon Oracle donne l'erreur 972 au moment du oxec lorsqu'on
	// travaille en mode diff�r� (en mode non diff�r� ce pb ne se produit pas).
	char* m_TextSQL;

	//@cmember Base de donn�es Oracle sur laquelle sera ouvert le curseur.
	CBdd* m_pBdd;

	//@cmember Curseur de l'OCI encapsul�.
	Cda_Def	m_Cursor;

	//@cmember Liste des informations n�cessaires pour lier variables C++
	//et placeholder ou colonne de la requ�te SQL
	CVarInfoList m_VarInfoList;

	//@cmember Lorsque <m m_Status> vaut vrai le Curseur est actif,
	// sinon le curseur est en erreur.
	bool m_Status;

	//@cmember Nombre de lignes retourn�es pour un fetch si le curseur est un select
	UINT  m_nNbLine;

	//@cmember Nombre de lignes � rechercher en bdd en une seule fois par la fonction de
	// recherche de l'OCI Oracle
	UINT m_NbLineForFetch ();

	//@cmember Index de la derni�re ligne retourn�e par le fetch (dans le tableau
	//de variable de taille m_ArraySize)
	UINT  m_nIndLine;

	CMap< int, int, CString*, CString*> m_CatchMessMap;

private:
	// Extraction de la chaine SQL des informations permettant 
	// le lien entre variables C++ et OCI.
	bool ExtractVarInfo (char* szSQL);

	// Etablissement du lien entre variables C++ et OCI
	void BindOCIVariables( CString& SQLString, va_list ArgList);

	// Lance proprement parl� l'execution de l'ordre SQL, Mode
	// pouvant �tre NON_BLOCKING ou BLOCKING
	bool Exec (int Mode, DWORD TimeOut);
};



//@ex L'exemple suivant montre comment utiliser les objets <c CCurseur> |
// L'ordre SQL brut sera le suivant :
// select sstring, string, charactere, long_num,
// float_num, double_num 
// from testoci where int_num = 1;
//
// Les variables C++ recevant le r�sultat sont d�clar�es
// de la fa�on suivante :
// CString SString;
// char    String[20];
// char    Character;
// long    LongNum;
// float   FloatNum;
// double  DoubleNum;
//
// L'entier sur lequel repose la s�lection sera :
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
// L'odre SQL est ex�cut� avec l'appel :
// Cursor.Exec();
//
// Chaque enregistrement r�pondant � la requ�te est 
// retrouv� par l'appel :
// Cursor.Fetch();


#endif // CURSOR_H
