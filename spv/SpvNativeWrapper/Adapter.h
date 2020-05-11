#pragma once
using namespace System;
//using namespace System::Drawing;
#include "Constantes.h"

ref class CAdapter
{
private:
	CAdapter(void); // Pas instanciable
public:
	static char *ConvertStringToSTR(String ^ sVal); // Converti un string en Const char *
//	static Image ^ ConvertPVOIDToImage(_PCVOID oByte, _CUINT iSize); // Converti un void en tableau de byte
	static String ^ ConvertPSTRToString(_PCSTR  sVal); // Converti un PSTR en String
};
