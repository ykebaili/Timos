//@doc Fonctions diverses bien pratiques
//
// REMARQUE : ce module est utilis� aussi dans le projet SpvMailSvc, merci
//            de reporter toutes modifications.
//.
// Project  : SPV
//
// Auteur	: T. Aim�
// Date		: 24/06/99 -- Cr�ation
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

//extern CSpvCommandLineInfo CmdInfo;	// param�tres de connexion, param. de la ligne de commande
///////////////////////////////////////////////////////////////////////////////
//IsNumber
//

bool IsNumber
(const CString& String,		//@parm CString � v�rifier
 bool Entier				//@parm Indicateur de nombre entier
)
{
	enum CState		// �tats de l'automate de reconnaissance
	{
		Start,      // �tats de d�part
		IntPart,    // reconnaissance de la partie enti�re
		DecPart		// reconnaissance de la partie d�cimale
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
// Cr�ation XL + JFL 20/10/02
//
// Permet de rechercher une cha�ne de caract�res depuis
// le fichier ressource Spv.RC
//
// Retourne une cha�ne CString.
//
CString GetStrItem(int IdsStr)
{
	CString s;

	s.LoadString (IdsStr);
	return s;
}


///////////////////////////////////////////////////////////////////////////////
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

// Fonction g�rant les apostrophes avant les insertions en bdd.
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

//@mfunc Cette m�thode permet d'obtenir le prochain substring
// de l'objet. Tous les substring sont s�par�s par le caract�re 'Separ.
// Au premier appel, on d�marre au d�but de la cha�ne.
// Retourne NULL � la fin

CString CRichString::GetNextSubString (char Separ)
// Le s�parateur doit �tre un caract�re
{
	CString SDroit;		// Partie droite du string
	int	    Val;		// Position trouv�e
	CString Sep (Separ);

	SDroit = Right (GetLength () - Pos);
	if ((Val = SDroit.Find (Sep)) >= 0)
		Pos += (Val +1);	// Pour sauter le s�parateur
	else 
		Pos = GetLength ();

	return (SDroit.SpanExcluding (Sep));
}			// GetNextSubString



//////////////////////////////////////////////////////////////////////////////////////
// @mfunc Enl�ve, par la droite, les caract�res �gaux � celui pass� en param�tre.
// Le traitement s'arr�te au premier caract�re diff�rent.
//
// Pas de valeur de retour
//
// X.L. cr�ation le 25/01/01
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
// @mfunc Enl�ve, par la gauche, les caract�res �gaux � celui pass� en param�tre.
// Le traitement s'arr�te au premier caract�re diff�rent.
//
// Pas de valeur de retour
//
// JPB cr�ation le 13/12/04
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

	// En sortie, i repr�sente le nb. de d�calages gauche � faire
	for (j = 0; j < strlen (pBuf) -i; j++)
		*(pBuf + j) = *(pBuf + j + i);

	*(pBuf + j) = 0;

	ReleaseBuffer ();
}		// LTrim


//@mfunc Cette m�thode permet de se repositionner au d�but de la cha�ne.

void CRichString::PosStart ()
{
	Pos = 0;
}			// PosStart;


//////////////////////////////////////////////////////////////////////////////////////
// @mfunc Donne le nombre d'occurences du caract�re pass� en param�tre, dans le string
//
//@rdesc Retourne le nombre d'occurences
//
// X.L. cr�ation le 26/04/01
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
