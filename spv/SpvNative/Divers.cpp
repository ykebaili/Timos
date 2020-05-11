//@doc Fonctions diverses bien pratiques
//
// REMARQUE : ce module est utilisé aussi dans le projet SpvMailSvc, merci
//            de reporter toutes modifications.
//.
// Project  : SPV
//
// Auteur	: T. Aimé
// Date		: 24/06/99 -- Création
// Version	: 1.0
//
// MAJ		: Ajout de fonctions d'init. pour les tableaux TabColAff[], TabOper[],
//			  TabType[] et TabGraveProg[] (filtrage).
// Auteur	: JFL
// Date		: 24/06/05
 
// #define  _CRT_SECURE_NO_DEPRECATE

#include "stdafx.h"

#include <afxpriv.h>
#include <afxcmn.h>	
#include <afxtempl.h>
#include <locale.h>

#include "divers.h"
//#include "Filtrage.h"
//#include "SpvList.h"	// Pour variable TCOLAFF.
//#include "cxion.h"

//extern TCOLAFF TabColAff [];
//extern CString TabOper  [8];
//extern CString TabType	 [5];
//extern CString TabGraveProg [3];

//extern CSpvCommandLineInfo CmdInfo;	// paramètres de connexion, param. de la ligne de commande
///////////////////////////////////////////////////////////////////////////////
//IsNumber
//

bool IsNumber
(const CString& String,		//@parm CString à vérifier
 bool Entier				//@parm Indicateur de nombre entier
)
{
	enum CState		// états de l'automate de reconnaissance
	{
		Start,      // états de départ
		IntPart,    // reconnaissance de la partie entière
		DecPart		// reconnaissance de la partie décimale
	} State;
	
	struct lconv* pConv = localeconv ();

	State = Start;
	int	nLength = String.GetLength ();

	for (int i = 0; i < nLength; i++)
	{
		char c = String[i];

		switch (State)
		{
			case Start :
				State = IntPart;
				if (c == '+' || c == '-')
					continue;
			
			case IntPart :
				if (c >= '0' && c <= '9')
					continue;
				else if (c != pConv->decimal_point[0])
					return false;
				else if (Entier)
					return false;
				
				State = DecPart;
				continue;

			case DecPart :
				if (c >= '0' && c <= '9')
					continue;
				else
					return false;
		}
	}
		
	return true;
}

///////////////////////////////////////////////////////////////////////////////
//
// Création XL + JFL 20/10/02
//
// Permet de rechercher une chaîne de caractères depuis
// le fichier ressource Spv.RC
//
// Retourne une chaîne CString.
//
CString GetStrItem(int IdsStr)
{
	CString s;

	s.LoadString (IdsStr);
	return s;
}


///////////////////////////////////////////////////////////////////////////////
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
CString GetChaine(int Min, int Max, CString Line)
{
	int i;
	char ch;
	CString Data;

	Data.Empty();

	for (i=Min;i<Max;i++)
	{
		ch = Line.GetAt(i);
		Data += ch;
	}

	return Data;
}



CString GetFileExtension(CString FileName)
{
	CString sFileExt;
	int nLastDot = FileName.ReverseFind('.');
	sFileExt.Format("%s",FileName.Right(FileName.GetLength() - nLastDot-1)); // Cut Out The Path

	return sFileExt;
}

// Get number of days of the current month
int GetNumberOfDays(int month, int year)
{
    int result;
    
    // Calculate number of days in the month
    if ( month != 2 )
    {
         // In the first half of the year
         if ( month <= 7 )
         {
              if ( month % 2 == 1 )
                   result = 31;
              else
                   result = 30;
         }
         // In the second half of the year
         else
         {
              if ( month % 2 == 0 )
                   result = 31;
              else
                   result = 30;
         }
    }
    else
    {
        // If year is leap year
        if ( year % 4 == 0 )
             result = 29;
        else
             result = 28;
    }
    
    return result;
}//GetNumberOfDays


bool StrToDate(CString stDate, COleDateTime& date)
{
	COleDateTime dateTest;
	CRichString rStr(stDate);

	int first = 1;
	int second = 1;
	int third = 1;

	int	hour = 0;
	int min = 0;
	int sec = 0;

	first = atoi(rStr.GetNextSubString ('/'));
	second = atoi(rStr.GetNextSubString ('/'));
	third = atoi(rStr.GetNextSubString (' '));

	hour = atoi(rStr.GetNextSubString (':'));
	min = atoi(rStr.GetNextSubString (':'));
	sec = atoi(rStr.GetNextSubString (':'));
	
	if(first<=0)
		return false;
	if(third<=0)
		return false;
	if(second>12 || second<=0)
		return false;
	if(hour<0 || hour>23)
		return false;
	if(min<0 || min>59)
		return false;
	if(sec<0 || sec>59)
		return false;

	/*
	if (CmdInfo.m_Language == SPV_STANDARD_ANGLAIS)
	{
		if(first>9999 || first<1980)
			return false;
		if(third>GetNumberOfDays(second, first))
			return false;

		dateTest.SetDateTime(first, second, third, hour, min, sec);
	}
	*/
	//else
	//{
		if(third>9999 || third<1980)
			return false;
		if(first>GetNumberOfDays(second, third))
			return false;
		dateTest.SetDateTime(third, second, first, hour, min, sec);
	//}

	if(dateTest.GetStatus()==COleDateTime::valid)
	{
		date = dateTest;
		return true;
	}
	else
		return false;
}//StrToDate

void InsertAfterComa(CString& targ,CString str,int ComaNum)
{
	int ComaPos = 0;
	CString TmpStr = targ;
	int PosInsert = 0;
	int tmpPos = 0;
	int k = 0;
	

	while(ComaPos!=ComaNum)
	{
		tmpPos = TmpStr.Find(',');
		TmpStr = TmpStr.Right(TmpStr.GetLength()-tmpPos-1);
		PosInsert+=(tmpPos+k);

		ComaPos ++;
		k++;

	}

	targ.Insert(PosInsert+1,str);

}

// Fonction gérant les apostrophes avant les insertions en bdd.
void Apos(CString& OldStr)
{
	CString tmpStr = (CString)OldStr;
	
	int pos1 = 0;
	int pos2 = 0;
	int k=0;

	while((pos1=tmpStr.Find("'"))>=0)
	{
		tmpStr=tmpStr.Right(tmpStr.GetLength()-pos1-1);
		pos2+=pos1+1;
		OldStr.Insert(pos2+k,"'");
		k++;
	}
}


/////////////////////////////////////////////////////////////////////////////
// CRichString dialog

//@mfunc Cette méthode permet d'obtenir le prochain substring
// de l'objet. Tous les substring sont séparés par le caractère 'Separ.
// Au premier appel, on démarre au début de la chaîne.
// Retourne NULL à la fin

CString CRichString::GetNextSubString (char Separ)
// Le séparateur doit être un caractère
{
	CString SDroit;		// Partie droite du string
	int	    Val;		// Position trouvée
	CString Sep (Separ);

	SDroit = Right (GetLength () - Pos);
	if ((Val = SDroit.Find (Sep)) >= 0)
		Pos += (Val +1);	// Pour sauter le séparateur
	else 
		Pos = GetLength ();

	return (SDroit.SpanExcluding (Sep));
}			// GetNextSubString



//////////////////////////////////////////////////////////////////////////////////////
// @mfunc Enlève, par la droite, les caractères égaux à celui passé en paramètre.
// Le traitement s'arrête au premier caractère différent.
//
// Pas de valeur de retour
//
// X.L. création le 25/01/01
//
void CRichString::RTrim (char c)
{
	char* pBuf = GetBuffer (0);

	for (size_t i = strlen (pBuf) - 1; i >= 0; i--)
	{
		if (*(pBuf + i) != c)
			break;

		*(pBuf + i) = '\0';
	}
	ReleaseBuffer ();
}		// RTrim


//////////////////////////////////////////////////////////////////////////////////////
// @mfunc Enlève, par la gauche, les caractères égaux à celui passé en paramètre.
// Le traitement s'arrête au premier caractère différent.
//
// Pas de valeur de retour
//
// JPB création le 13/12/04
//
void CRichString::LTrim (char c)
{
	unsigned int	  i, j;	// Banal
	char* pBuf = GetBuffer (0);

	for (i = 0; i < strlen (pBuf); i++)
	{
		if (*(pBuf + i) != c)
			break;
	}

	// En sortie, i représente le nb. de décalages gauche à faire
	for (j = 0; j < strlen (pBuf) -i; j++)
		*(pBuf + j) = *(pBuf + j + i);

	*(pBuf + j) = 0;

	ReleaseBuffer ();
}		// LTrim


//@mfunc Cette méthode permet de se repositionner au début de la chaîne.

void CRichString::PosStart ()
{
	Pos = 0;
}			// PosStart;


//////////////////////////////////////////////////////////////////////////////////////
// @mfunc Donne le nombre d'occurences du caractère passé en paramètre, dans le string
//
//@rdesc Retourne le nombre d'occurences
//
// X.L. création le 26/04/01
//
int CRichString::GetNbOccur (char c)
{
	int nNbOccur = 0;
	int nLength = GetLength ();

	for (int i = 0; i < nLength; i++)
		if (GetAt (i) == c)
			nNbOccur++;

	return nNbOccur;
}			// GetNbOccur
