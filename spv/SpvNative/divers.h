//@doc Divers
//
// Project  : SPV
//
// Authors	: T. Aim�
// Date		: 24/6/99 -- Cr�ation
// Release	: 1.0
//
//@module Divers |
// Impl�mentation de diverses fonctions offrant des facilit�s.
//////////////////////////////////////////////////////////////////////

#include <afx.h>
//#include "Consultal.h"	// Pour variable TabColAff.

///////////////////////////////////////////////////////////////////////////////
//@func IsNumber
//
// V�rifie si une cha�ne de caract�res est un nombre, sachant qu'un
// nombre doit �tre reconnaissable par l'expression r�guli�re
// suivante :
//
//@rdesc Retourne le status du curseur :
//	@flag true  | Si l'ex�cution est compl�te.
//	@flag false | Si l'ex�cution a �chou�.
//
// Auteur T.A.
// Date : 24/07/99 -- Cr�ation
// Release : 1.0

bool IsNumber (const CString& String, bool Entier = false);
CString GetStrItem(int IdsStr);

////////////////////////////////////////////////
//
// lecture du CString pass� en param�tre, et 
// selon les valeurs Min / Max, extraction de
// la cha�ne de caract�res comprise entre les
// deux indices.
//
//		=> retourne la cha�ne de caract�res.
//
// JFL le 02/06/05
//
CString GetChaine(int Min, int Max, CString Line);


/*
///////////////////////////////////////////////////////////////////////////////
// Fonctions utilis�es pour initialiser les tableaux li�s aux filtres.
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

//fonction utilis�e pour r�soudre les probl�mes li�s � la pr�sence 
//d'apostrophe vis � vis de la manipulation des cha�nes avec SQL
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

//@access Red�finition d'op�rateurs
	CRichString& operator= (const CRichString&);	// Permet d'affecter un string NULL

//@access M�thodes publiques
public:
	//@cmember Remplace un caract�re par un autre dans la cha�ne.
	CRichString Replace (char Orig, char Dest);

	//@cmember Cette m�thode permet d'obtenir le prochain substring
	// de l'objet. Tous les substring sont s�par�s par le caract�re 'Separ'.
	// Au premier appel, on d�marre au d�but de la cha�ne.
	// Retourne NULL � la fin
	CString GetNextSubString (char Separ);
	//@cmember Si le string est dans le string Str ('string''ch''string' etc..) (�galit� attendue),
	// retourne le n� d'ordre (0, 1, 2 ..). Sinon, retourne -1
	int IsIn (CRichString Str, char Separ);
	//@cmember Si le string est contenu dans le string Str ('string''ch''string' etc..),
	// retourne le n� d'ordre (0, 1, 2 ..). Sinon, retourne -1
	int IsInApprox (CRichString Str, char Separ);
	//@cmember Supprime la sous-cha�ne d'ordre Idx (0, 1, 2 ..).
	CRichString Delete (int Idx, char ch);
	//@cmember Supprime tous les caract�res appartenant � une sous-cha�ne, de la cha�ne trait�e
	CRichString Delete (CString Str);
	//@cmember Extrait la sous-cha�ne d'ordre Idx (0, 1, 2 ..).
	CRichString Extract (int Idx, char ch);

	//@cmember enl�ve, par la droite, les caract�res �gaux � celui pass� en param�tre.
	// Le traitement s'arr�te au premier caract�re diff�rent.
	void RTrim (char c);
	//@cmember enl�ve, par la gauche, les caract�res �gaux � celui pass� en param�tre.
	// Le traitement s'arr�te au premier caract�re diff�rent.
	void LTrim (char c);

	// @cmember Donne le nombre d'occurences du caract�re c dans le CString
	int GetNbOccur (char c);

	//@cmember Cette m�thode permet de se repositionner au d�but de la cha�ne.
	void PosStart ();

	//@cmember Cette m�thode retourne la position en cours.
	int GetPos () {return Pos;};

//@access Donn�es prot�g�es
private :
	int Pos;	// Position � partir de laquelle on lance une recherche
};			// CRichString
