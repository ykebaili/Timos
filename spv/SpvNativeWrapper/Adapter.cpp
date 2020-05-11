#include "StdAfx.h"
#include <stdlib.h>
#include <string.h>
#include < vcclr.h >
#include "Adapter.h"
//using namespace System::Drawing;
using namespace System::IO;


/*
 * Constructeur par défaut
 */
CAdapter::CAdapter(void){}

/*
 * Adapte un String vers un pointeur sur un char
 * P1 : String
 * Return : Char *
 */
char * CAdapter::ConvertStringToSTR(String ^ sVal)
{
	if (sVal == nullptr) 
		return NULL;

	IntPtr pInter = System::Runtime::InteropServices::Marshal::StringToHGlobalAnsi(sVal);
	const char * sInter = static_cast<char*>(pInter.ToPointer());
	rsize_t iLen  = strlen(sInter)+1;
	char * sChaineRetour = new char[iLen];
	strcpy_s(sChaineRetour,iLen,sInter);
	System::Runtime::InteropServices::Marshal::FreeHGlobal(pInter);
	return sChaineRetour;
}



/*
 * Adapte une string native vers un String
 * P1 : Tableau de byte
 * P2 : longueur du tableau
 * Return tableau de byte
 */
String ^ CAdapter::ConvertPSTRToString(_PCSTR sVal)
{
	if (sVal == NULL)
		return nullptr;
	String ^ oRetour = gcnew String(sVal);
	return oRetour;
}

