//@doc Divers
//
// Project  : SPV
//
// Authors	: T. Aimé
// Date		: 24/6/99 -- Création
// Release	: 1.0
//
//@module Divers |
// Implémentation de diverses fonctions offrant des facilités.
//////////////////////////////////////////////////////////////////////

#include <afx.h>
//#include "Consultal.h"	// Pour variable TabColAff.

///////////////////////////////////////////////////////////////////////////////
//@func IsNumber
//
// Vérifie si une chaîne de caractères est un nombre, sachant qu'un
// nombre doit être reconnaissable par l'expression régulière
// suivante :
//
//@rdesc Retourne le status du curseur :
//	@flag true  | Si l'exécution est complète.
//	@flag false | Si l'exécution a échoué.
//
// Auteur T.A.
// Date : 24/07/99 -- Création
// Release : 1.0

bool IsNumber (const CString& String, bool Entier = false);
CString GetStrItem(int IdsStr);

////////////////////////////////////////////////
//
// lecture du CString passé en paramètre, et 
// selon les valeurs Min / Max, extraction de
// la chaîne de caractères comprise entre les
// deux indices.
//
//		=> retourne la chaîne de caractères.
//
// JFL le 02/06/05
//
CString GetChaine(int Min, int Max, CString Line);


/*
///////////////////////////////////////////////////////////////////////////////
// Fonctions utilisées pour initialiser les tableaux liés aux filtres.
//
//		- TabColAff[], TabOper[], TabType[], TabGraveProg[]
//

//////////////////////////////////////////
// Permet de remplir la structure TCOLAFF
// depuis la fonction InitTabs().
//
bool AddStrTabColAff(TCOLAFF * pCelAff, char * ColName, char * ColAff, CString BddColumn);

/////////////////////////////////////
// Conversion IDS_MDxxxxx (Int) en
// char * afin d'utiliser la fonction
// -> AddStrTabColAff(..)
//
bool SetTabColAff(int M1, int M2, int i,CString BddColumn);


///////////////////////
// Init des tableaux : 
//		TabColAff[]
//		TabOper[]
//		TabType[]
//		TabGraveProg[]
//
bool InitTabs();	// Init.  globale depuis InitInstance() de l'application SPV.
*/

CString GetFileExtension(CString FileName);

bool    StrToDate(CString stDate, COleDateTime& date);
// Get number of days of the current month
int GetNumberOfDays(int month, int year);

void InsertAfterComa(CString& targ,CString str,int ComaNum);

//fonction utilisée pour résoudre les problèmes liés à la présence 
//d'apostrophe vis à vis de la manipulation des chaînes avec SQL
void Apos(CString& OldStr);

class CRichString : public CString
{
//@access Constructeurs, destructeurs
public:
	//@cmember Construction d'un <c User>.
	CRichString () : CString () {Pos=0;};
	CRichString (const CString& stringSrc) : CString (stringSrc) {Pos=0;};
	CRichString (TCHAR ch, int nRepeat = 1) : CString (ch, nRepeat=1) {Pos=0;};
	CRichString (LPCTSTR lpch, int nLength) : CString (lpch, nLength) {Pos=0;};
	CRichString (const unsigned char* psz) : CString (psz) {Pos=0;};
	CRichString (LPCWSTR lpsz) : CString (lpsz) {Pos=0;};
	CRichString (LPCSTR lpsz) : CString (lpsz) {Pos=0;};

//@access Redéfinition d'opérateurs
	CRichString& operator= (const CRichString&);	// Permet d'affecter un string NULL

//@access Méthodes publiques
public:
	//@cmember Remplace un caractère par un autre dans la chaîne.
	CRichString Replace (char Orig, char Dest);

	//@cmember Cette méthode permet d'obtenir le prochain substring
	// de l'objet. Tous les substring sont séparés par le caractère 'Separ'.
	// Au premier appel, on démarre au début de la chaîne.
	// Retourne NULL à la fin
	CString GetNextSubString (char Separ);
	//@cmember Si le string est dans le string Str ('string''ch''string' etc..) (égalité attendue),
	// retourne le n° d'ordre (0, 1, 2 ..). Sinon, retourne -1
	int IsIn (CRichString Str, char Separ);
	//@cmember Si le string est contenu dans le string Str ('string''ch''string' etc..),
	// retourne le n° d'ordre (0, 1, 2 ..). Sinon, retourne -1
	int IsInApprox (CRichString Str, char Separ);
	//@cmember Supprime la sous-chaîne d'ordre Idx (0, 1, 2 ..).
	CRichString Delete (int Idx, char ch);
	//@cmember Supprime tous les caractères appartenant à une sous-chaîne, de la chaîne traitée
	CRichString Delete (CString Str);
	//@cmember Extrait la sous-chaîne d'ordre Idx (0, 1, 2 ..).
	CRichString Extract (int Idx, char ch);

	//@cmember enlève, par la droite, les caractères égaux à celui passé en paramètre.
	// Le traitement s'arrête au premier caractère différent.
	void RTrim (char c);
	//@cmember enlève, par la gauche, les caractères égaux à celui passé en paramètre.
	// Le traitement s'arrête au premier caractère différent.
	void LTrim (char c);

	// @cmember Donne le nombre d'occurences du caractère c dans le CString
	int GetNbOccur (char c);

	//@cmember Cette méthode permet de se repositionner au début de la chaîne.
	void PosStart ();

	//@cmember Cette méthode retourne la position en cours.
	int GetPos () {return Pos;};

//@access Données protégées
private :
	int Pos;	// Position à partir de laquelle on lance une recherche
};			// CRichString
