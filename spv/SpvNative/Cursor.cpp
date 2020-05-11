//@doc Cursor
//
// Project  : SPV
//
// Module   : Cursor
//
// Authors	: T. Aimé & X. Leconte
// Date		: 9/6/98 -- Création
// Release	: 1.0
// 
// Encapsulation de la notion et de la manipulation de curseur de 
// l'OCI Oracle.
// Corrections JPB 15/05/03. Pb d'allocations mémoire

//////////////////////////////////////////////////////////////////////

// TEST_OCI est défini pour le programme de test Test0001.exe
 

#include "stdafx.h"

//#include <afxwin.h>
#include <mmsystem.h>
#include <assert.h>

//#include "Cxion.h"
#include "Cursor.h"

		// pour classe CSpvCommandLineInfo

#ifdef _DEBUG
#undef THIS_FILE
static char THIS_FILE[]=__FILE__;
#define new DEBUG_NEW
#endif

class CSpvApp;
extern CSpvApp		theApp;		// l'application
//extern CSpvCommandLineInfo CmdInfo;	// paramètres de connexion, param. de la ligne de commande
extern HANDLE		hBddMutex;	// Mutex pour synchroniser les accès à CCursor, entre les threads

//extern CString CxionBdd;		// chaîne de connexion à la BDD
CString CxionBdd = "superv/fcom@fcom12";		// chaîne de connexion à la BDD
extern unsigned int ArraySize;	// Taille du tableau d'échange pour les curseurs

///////////////////////////////////////////////////////////////////////////////
// @mfunc Cette fonction construit un objet <c CVarInfo>

CVarInfo::CVarInfo
 (
	CString &Name,	//@parm Nom de la colonne ou du "Place Holder".
	CString &Size,  //@parm Taille au sens C++ de la variable associée
	char Type,		//@parm type de la variable C++ associée
	UINT nArraySize //@parm Taille des tableaux pour recherche en Bdd
)
{
	strcpy (m_Name, Name.GetBufferSetLength (MAX_SQL_IDENT));
//	strncpy (m_Name, Name.GetBufferSetLength (MAX_SQL_IDENT), MAX_SQL_IDENT);
	Name.ReleaseBuffer (); // MAX_SQL_IDENT

	m_CStringBuf = NULL;
	m_TypeC = Type;
	m_pVar = NULL;
	m_pTChar = NULL;
	m_Tindp = NULL;	// Pointeur sur la zone d'information écrite par l'OCI pour les fetch multilignes

	switch (m_TypeC)
	{
		case 'c' :
			m_OCIType = 3; m_Size = sizeof(char);
			if (m_Name [0] != ':')	// il s'agit d'une colonne pour un select
				m_pTChar = new char [nArraySize];
			break;
		case 'i' :
			m_OCIType = 3; m_Size = sizeof(int);
			if (m_Name [0] != ':')	// il s'agit d'une colonne pour un select
				m_pTChar = new char [nArraySize * sizeof (int)];
			break;
		case 'l' :
		case 'L':
			m_OCIType = 3; m_Size = sizeof(long);
			if (m_Name [0] != ':')	// il s'agit d'une colonne pour un select
				m_pTChar = new char [nArraySize * sizeof (long)];
			break;
		case 'f' :
			m_OCIType = 4; m_Size = sizeof(float);
			if (m_Name [0] != ':')	// il s'agit d'une colonne pour un select
				m_pTChar = new char [nArraySize * sizeof (float)];
			break;
		case 'd' :
			m_OCIType = 4; m_Size = sizeof(double);
			if (m_Name [0] != ':')	// il s'agit d'une colonne pour un select
				m_pTChar = new char [nArraySize * sizeof (double)];
			break;
		case 's' :
			m_OCIType = 5; m_Size = atoi (Size.GetBuffer (10));
			if (m_Name [0] != ':')	// il s'agit d'une colonne pour un select
			{
				m_pTChar = new char [nArraySize * m_Size];
				for (UINT i = 0; i < nArraySize * m_Size; i++)
					*(m_pTChar+i) = 0;
			}
			break;
		case 'S' :
			m_OCIType = 5; m_Size = atoi (Size.GetBuffer (10));
			m_CStringBuf = new char[m_Size + 1];
			if (m_Name [0] != ':')	// il s'agit d'une colonne pour un select
			{
				m_pTChar = new char [nArraySize * (m_Size + 1)];
				for (UINT j = 0; j < nArraySize * (m_Size + 1); j++)
					*(m_pTChar+j) = 0;
			}
			break;
		default : 
			assert (m_OCIType == false);
	}
	
	m_indp = 0;
	if (m_Name [0] != ':')	// il s'agit d'une colonne pour un select
	{
		assert (m_pTChar != NULL);
		m_Tindp = new sb2 [nArraySize];
		assert (m_Tindp != NULL);
		memset (m_Tindp, 0, sizeof (m_Tindp));
	}
}


///////////////////////////////////////////////////////////////////////////////
//@mfunc Cette fonction détruit un objet <c CVarInfo>.
//

CVarInfo::~CVarInfo()
{
	if (m_CStringBuf != NULL)
		delete [] m_CStringBuf;

	if (m_pTChar != NULL)
			delete [] m_pTChar;

	if (m_Tindp != NULL)
		delete [] m_Tindp;

}


//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

///////////////////////////////////////////////////////////////////////////////
//@mfunc Ces fonctions construisent un objet <c CCursor>.
//
// @syntax CCursor(CBdd *pDataBase, CString SQLString, ...);
// @syntax CCursor(CBdd *pDataBase, UINT IdSQLString, ...);
//
// @parm CBdd* | pDataBase | Base attachée au nouveau curseur.
// @parm CString | SQLString | Ordre SQL attaché au curseur.
// @parm UINT | IdSQLString | ID dans la string Table de l'ordre SQL 
//								attaché au curseur.
// @parmvar Un ou plusieur pointeur sur des variables C++ attaché 
//					à l'odre SQL.

CCursor::CCursor
(
	CBdd *pDataBase,
	CString SQLString,
	...				
)
{
	m_TextSQL = NULL;
	va_list ArgList;

	va_start (ArgList, pDataBase);
	va_arg (ArgList, void*);
	
	m_pBdd = pDataBase;
	BindOCIVariables (SQLString, ArgList);
}	


CCursor::CCursor
(
	CBdd *pDataBase,
	UINT IdSQLString,
	...
)
{
	CString SQLString;

	SQLString.LoadString (IdSQLString);

	m_TextSQL = NULL;
	va_list ArgList;

	va_start (ArgList, pDataBase);
	va_arg (ArgList, void*);
	
	m_pBdd = pDataBase;
	BindOCIVariables (SQLString, ArgList);
}	


///////////////////////////////////////////////////////////////////////////////
//@mfunc Cette fonction détruit un objet <c CCursor>.
//

CCursor::~CCursor()
{
	while (!m_VarInfoList.IsEmpty ())
	{
		CVarInfo* VarInfo = m_VarInfoList.RemoveHead();
		delete VarInfo;		
	}

	if (m_TextSQL != NULL)
		delete [] m_TextSQL;

	if (m_pBdd && m_pBdd->IsOpen())
		oclose (&m_Cursor);
}


///////////////////////////////////////////////////////////////////////////////
// Cette fonction réalise l'extraction des informations sur les 
// Placeholder et colonnes de la requête associée au curseur, et la
// construction d'une liste d'objets <c CVarInfo> (un pour chaque 
// pointeur de variables C).
//
// Retourne une des valeurs suivantes :
//	true   Si l'extraction est complète.
//	false  Si l'extraction a échoué.

bool CCursor::ExtractVarInfo
(
	char* szSQL	// Ordre SQL d'où vont être extraites les informations
)
{
	const int OUT_VAR			= 0;
	const int VAR_INFO			= 1;
	const int START_VAR_NAME	= 2;
	const int VAR_NAME			= 3;

	char* pc = szSQL;
	int State = OUT_VAR;
	CString Name = "";
	CString Size = "0";
	char Type	 = 0;

	for	 (; ; pc++)
	{
		switch (State)
		{
			case OUT_VAR :
				if  (*pc == '#') 
					// Debut d'un placeholder ou d'un nom de colonne
					State = VAR_INFO;
				else
				{
					// En dehors d'un placeholder ou d'un nom de colonne
					// La chaine szSQL est conservée.
					*szSQL = *pc;
					szSQL++;
				}

				break;

			case VAR_INFO :
				if  (*pc >= '0' && *pc <= '9')
				{
					// Constitution de la chaine représentant la taille 
					//  (ce qui est le cas uniquement pour une chaine 
					// de caractères).
					Size += *pc;
					break;
				}

				// récupération du type.
				Type = *pc;
				State = START_VAR_NAME;
				break;

			case START_VAR_NAME :
				if (*pc != '#')
					return (false);

				State = VAR_NAME;
				break;

			case VAR_NAME :
				// Lecture du nom de colonne ou du placeholder

				if  (*pc == ',' || *pc == ' ' || *pc == ')' ||
					 *pc == '\t'|| *pc == ';' || *pc == '\0')
				{
					// La lecture du nom de colonne ou du placeholder
					// est terminée, on ajoute un objet CVarInfo 
					// à la liste m_VarInfoList.
					m_VarInfoList.AddTail  (new CVarInfo (Name, Size, Type,
											m_pBdd -> GetArraySize ()));
					
					// On continue le parsing de szSQL
					State = OUT_VAR;
					Name = "";
					Size = "0";
					Type = 0;

				}
				else
					// Constitution du Placeholder ou de la colonne.
					Name += *pc;


				*szSQL = *pc;
				szSQL++;
				break;			
		}

		if  (*pc == '\0')
			// L'ensemble de la chaine à été scanné.
			return (true);
	}
}


///////////////////////////////////////////////////////////////////////////////
// Cettte fonction ouvre le curseur et réalise le "Binding" entre 
// variables Oracle et les variables C++, en encapsulant les fonctions :
// oopen, oparse, obndrv, odefinps.
//

void CCursor::BindOCIVariables
(
	CString &SQLString,	// Ordre SQL d'où vont être extraites 
						// les informations
	va_list ArgList		// Listes des variables C++ à lier.
)
{
	if (!m_pBdd || !m_pBdd->IsOpen())
	{
		m_Status = KO;
		return;
	}

	m_Status = OK;

	// Extraction des informations sur les Placeholder et colonnes de la 
	// requête associée au curseur, et construction d'une liste d'objets 
	// CVarInfo (un pour chaque pointeur de variables C).
	// Recopie locale de l'ordre pour pouvoir fonctionner en mode deffered
	m_TextSQL = new char [SQLString.GetLength () +1];
	strcpy (m_TextSQL, (LPCTSTR) SQLString.GetBuffer (SQLString.GetLength () +1));

	//char* szSQL = SQLString.GetBuffer (10);
	ASSERT (ExtractVarInfo (m_TextSQL));
	SQLString.ReleaseBuffer();

	// Ouverture du curseur
	if (oopen (&m_Cursor, &(m_pBdd -> lda), (text *) 0, -1, -1, (text *) 0, -1))
	{
		OCIMessageBox ();
		m_Status = KO;
		return;
	}

	// parsing de l'ordre SQL
	
	//if	(oparse (&m_Cursor, (text*) m_TextSQL, (sb4) -1, 
	//					(sword) PARSE_NO_DEFER, (ub4) VERSION_7))
	
	if	(oparse (&m_Cursor, (text*) m_TextSQL, (sb4) -1, 
						PARSE_DEFER, (ub4) VERSION_7))
	
	{
		OCIMessageBox ();
		m_Status = KO;
		return;
	}

	// Binding des variables
	va_list VarList = ArgList;
//	va_start (VarList);            // Initialize variable arguments. JPB ??
   
	POSITION Pos = m_VarInfoList.GetHeadPosition ();
	int ColonneNb = 0;

	while (Pos != NULL)
	{
		CVarInfo* VarInfo = m_VarInfoList.GetNext (Pos);

//		VarInfo->m_pVar = va_arg (VarList, void*);
//		ASSERT (VarInfo->m_pVar != NULL);
//		void* pVar = VarInfo->m_pVar;

		void * pVar = va_arg (VarList, void*);
		while (pVar==NULL || pVar==0)
				pVar = va_arg (VarList, void*);

		VarInfo->m_pVar=pVar;

		if (VarInfo->m_TypeC == 'S')
		{
			// Cas spécial pour les CString on utilise m_CStringBuf
			// pour les échanges avec l'OCI
			pVar = VarInfo->m_CStringBuf;
		}

		if  (VarInfo->m_Name[0] == ':')
		{
			// PlaceHolder nommé
			if (obndrv  (&m_Cursor, (text*) VarInfo->m_Name,(sword) -1,
						(ub1*) pVar, (sword) VarInfo->m_Size, 
						(sword) VarInfo->m_OCIType, (sword) -1, 
						(sb2*) &VarInfo->m_indp, (text *) 0, (sword) -1,
						(sword) -1))
			{
				OCIMessageBox ();
				m_Status = KO;
				return;
			}
		}

		else
		{
			// Variable de colonne
			ColonneNb++;
			pVar = VarInfo -> m_pTChar;

			if (odefinps (&m_Cursor, NO_PIECEWISE, ColonneNb, 
					(ub1*) pVar, (sword) VarInfo->m_Size,
					(sword) VarInfo->m_OCIType, (sword) -1, 
					(sb2*) &VarInfo->m_Tindp [0], (text *) 0, -1, -1,
					(ub2*) 0, (ub2 *) 0, (sb4) VarInfo -> m_Size, sizeof (sb2), 0, 0))
			{
				OCIMessageBox ();
				m_Status = KO;
				return;
			}
		}
	}
}


// Constantes permettant d'exécuter les commandes oexec et ofind
// de l'OCI en mode bloquant ou non bloquant.
const int BLOCKING = 0;
const int NON_BLOCKING = 1;

///////////////////////////////////////////////////////////////////////////////
//@mfunc cette fonction execute l'ordre SQL associé au curseur, c'est à
// dire encapsule la fonction oexec de l'OCI.
//
//@rdesc Retourne le status du curseur :
//	@flag OK  | Si l'exécution est complète.
//	@flag KO  | Si l'exécution a échoué.

bool CCursor::Exec ()
{
	return Exec (BLOCKING, 0);
}


///////////////////////////////////////////////////////////////////////////////
//@mfunc cette fonction execute l'ordre SQL associé au curseur, c'est à
// dire encapsule la fonction oexec de l'OCI.
//
//@rdesc Retourne le status du curseur :
//	@flag OK  | Si l'exécution est complète.
//	@flag KO  | Si l'exécution a échoué.

bool CCursor::Exec (DWORD TimeOut)
{
	return Exec (NON_BLOCKING, TimeOut);
}


///////////////////////////////////////////////////////////////////////////////
//
UINT Break (LPVOID pParam)
{
	int Res = obreak ((Lda_Def*)pParam);
	return Res;
}


///////////////////////////////////////////////////////////////////////////////
// Encapsule la fonction OCI obreak sous la forme d'une fonction
// callback
void CALLBACK BreakTimer
 (
	UINT uID, 
	UINT uMsg, 
	DWORD dwUser, 
	DWORD dw1, 
	DWORD dw2 
)
{
	AfxBeginThread (Break, (LPVOID)dwUser);
}


const int BLOCKED = -3123;

///////////////////////////////////////////////////////////////////////////////
// Cette fonction execute l'ordre SQL associé au curseur, c'est à
// dire encapsule la fonction oexec de l'OCI.
//
// Retourne le status du curseur :
//		OK  | Si l'exécution est complète.
//		KO  | Si l'exécution a échoué.

bool CCursor::Exec (int Mode, DWORD TimeOut)
{
	WaitForSingleObject (hBddMutex, INFINITE);

	m_nNbLine = m_nIndLine = 0;

	if (this == NULL)
	{
		m_Status = KO;
		ReleaseMutex (hBddMutex);
		return KO;
	}			// JPB

	if  (m_Status == KO)
	{
		ReleaseMutex (hBddMutex);
		return KO;
	}

	if (m_pBdd == NULL)
	{
		ReleaseMutex (hBddMutex);
		return KO;
	}			// JPB

	if (! m_pBdd->IsOpen())
	{
		if (! m_pBdd->Open (CxionBdd, ArraySize))
		{
			ReleaseMutex (hBddMutex);
			return KO;
		}

		// OutputDebugString ("BDD réouverte dans CCursor::Exec\n");
	}			// JPB

	POSITION Pos = m_VarInfoList.GetHeadPosition ();
	while (Pos != NULL)
	{
		CVarInfo* VarInfo = m_VarInfoList.GetNext (Pos);

		if (VarInfo->m_TypeC == 'S')
		{
			char* CStringBuf = 
					((CString*)VarInfo->m_pVar)->GetBufferSetLength (VarInfo->m_Size); 

			strcpy (VarInfo->m_CStringBuf, CStringBuf); // vs. strcpy JPB
			((CString*)VarInfo->m_pVar)->ReleaseBuffer (); // vs. ()  JPB 150503
		}

		if (VarInfo->m_TypeC == 'L')
		{
			if (*(long*)VarInfo->m_pVar == 0)
				// colonne null
				VarInfo->m_indp = -1;
			else
				VarInfo->m_indp = 0;	// Car l'exec peut être appelé plusieurs fois de
										// suite pour un même curseur d'insertion ou
										// d'update; il faut donc prévoir la remise à
										// colonne non NULL quand la dernière valeur 
										// à insérer est différente de 0.
		}
	}
		
	MMRESULT TimerId;

	if (Mode == NON_BLOCKING)
	{
		onbset (&m_pBdd->lda);
		TimerId = timeSetEvent (TimeOut, 1000, BreakTimer, 
									(DWORD)&m_pBdd->lda, TIME_ONESHOT);
	}

	while (oexec (&m_Cursor) == BLOCKED);
	
	if (m_Cursor.rc == ORA00000)
	{
		POSITION Pos = m_VarInfoList.GetHeadPosition ();
		while (Pos != NULL)
		{
			CVarInfo* VarInfo = m_VarInfoList.GetNext (Pos);

			if(	VarInfo->m_CStringBuf != NULL && VarInfo->m_pVar!=NULL && VarInfo->m_pVar!=0)
				*((CString*)VarInfo->m_pVar) = VarInfo->m_CStringBuf;
		}
	}
	else	
	{
		OCIMessageBox ();
		m_Status = KO;
	}

	if (Mode == NON_BLOCKING)
	{
		onbclr (&m_pBdd->lda);
		timeKillEvent (TimerId);
	}

	ReleaseMutex (hBddMutex);
	return (m_Status);
}		// Exec


///////////////////////////////////////////////////////////////////////////////
//@mfunc Cette fonction met à jour les variables C++ avec 
// l'enregistrement suivant, c'est à dire encapsule la fonction 
// ofetch de l'OCI. 
//
//@rdesc Retourne le status du curseur :
//	@flag OK  | Si l'exécution est complète.
//	@flag KO  | Si l'exécution a échoué.
//  @flag EOF | Si aucun enregistrement n'est disponible.

int CCursor::Fetch
(
 UINT nNbLineToFetch	// Nombre de lignes à rechercher en Bdd en un seul appel à la
						// fonction OCI. Si ce paramètre est à 0, il faut prendre la
						// valeur par défaut de Cbdd (m_ArraySize), sinon prendre cette
						// valeur
)
{
	WaitForSingleObject (hBddMutex, INFINITE);

	UINT nNbToFetch = nNbLineToFetch;
	UINT nNb = m_pBdd -> GetArraySize ();
	if (nNbToFetch <= 0 || nNbToFetch > nNb)
		nNbToFetch = nNb;

	int ret = m_Status;
	if  (m_Status == OK)
	{
		POSITION Pos = m_VarInfoList.GetHeadPosition();
//		va_start (m_VarInfoList);            // Initialize variable arguments. JPB ??

		while (Pos != NULL)
		{
			CVarInfo* VarInfo = m_VarInfoList.GetNext (Pos);

			if (VarInfo->m_TypeC == 'S')
			{
				char* CStringBuf = 
					((CString*)VarInfo->m_pVar)->GetBufferSetLength (VarInfo->m_Size); 

				strcpy (VarInfo->m_CStringBuf, CStringBuf);	// JPB
				((CString*)VarInfo->m_pVar)->ReleaseBuffer ();	// JPB
			}

			if (VarInfo->m_TypeC == 'L')
			{
				if (*(long*)VarInfo->m_pVar == 0)
					// Colonne null
					VarInfo->m_indp = -1;
				else
					VarInfo->m_indp = 0;	// Car l'exec peut être appelé plusieurs fois de
											// suite pour un même curseur d'insertion ou
											// d'update; il faut donc prévoir la remise à
											// colonne non NULL quand la dernière valeur 
											// à insérer est différente de 0.
			}
		}

		if ((m_nNbLine == m_nIndLine) && (m_nIndLine == 0 || m_nNbLine == nNbToFetch))
		{
			int nOldNb = m_Cursor.rpc;
			// C'est le premier fetch ou le précédent a retourné la ligne du tableau
			// d'indice le plus élevé, donc il faut refaire une recherche en bdd
			if (ofen (&m_Cursor, nNbToFetch))
			{
				if (m_Cursor.rc == 1403)	// plus de quoi remplir tout le buffer
				{
					m_nNbLine = m_Cursor.rpc - nOldNb;	
					m_nIndLine = 0;
				}
				else if (m_Cursor.rc == 1002)
					ret = EOF;
				else
				{
					OCIMessageBox ();
					ret = m_Status = KO;
				}
			}

			else
			{
				m_nNbLine = m_Cursor.rpc - nOldNb;
				m_nIndLine = 0;
			}
		}

		if (m_Status = OK)
		{
			if (m_nIndLine == m_nNbLine)	// Plus d'enregistrements
				ret = EOF;
			else if (m_nNbLine > 0)			// Renvoyer la ligne d'indice m_nIndLine
			{
				POSITION Pos = m_VarInfoList.GetHeadPosition ();
				while (Pos != NULL)
				{
					CVarInfo* VarInfo = m_VarInfoList.GetNext (Pos);

					if (VarInfo -> m_Name [0] != ':' &&			// c'est une colonne
						(VarInfo->m_Tindp [m_nIndLine] >= 0 ||	// colonne non à NULL -- vs != -1 JPB
						 VarInfo -> m_TypeC == 'S' || VarInfo -> m_TypeC == 's'))
					{
						switch (VarInfo -> m_TypeC)
						{
							case 'c' :
								*((char*) (VarInfo -> m_pVar)) = 
									*(VarInfo -> m_pTChar+m_nIndLine);
								break;
							case 'i' :
								*((int*) (VarInfo -> m_pVar)) = 
									*((int*) (VarInfo -> m_pTChar)+m_nIndLine);
								break;
							case 'l' :
							case 'L':
								*((long*) (VarInfo -> m_pVar)) = 
									*((long*) (VarInfo -> m_pTChar)+m_nIndLine);
								break;
							case 'f' :
								*((float*) (VarInfo -> m_pVar)) = 
									*((float*) (VarInfo -> m_pTChar)+m_nIndLine);
								break;
							case 'd' :
								*((double*) (VarInfo -> m_pVar)) = 
									*((double*) (VarInfo -> m_pTChar)+m_nIndLine);
								break;
							case 's' :
								strcpy ((char*) VarInfo -> m_pVar, 
									VarInfo -> m_pTChar+(m_nIndLine*VarInfo->m_Size));
								break;
							case 'S':
								char* CStringBuf = 
								((CString*)VarInfo->m_pVar)->
									GetBufferSetLength (VarInfo->m_Size);
					
								//strcpy (CStringBuf, VarInfo->m_CStringBuf);
								strcpy (CStringBuf, 
									VarInfo->m_pTChar+(m_nIndLine*(VarInfo->m_Size))); // JPB
								((CString*)VarInfo->m_pVar)->ReleaseBuffer ();	// JPB		
								//*((CString*)VarInfo->m_pVar) = VarInfo->m_CStringBuf;
								break;
						}	// fin du switch
					}		// fin du if
			
					// Modif JPB le 01/10/01. Les null avec #L# n'étaient pas traités !!
					if (VarInfo -> m_Name [0] != ':' &&			// c'est une colonne
						VarInfo -> m_Tindp [m_nIndLine] < 0 &&	// colonne à NULL -- vs. == -1 JPB
						VarInfo -> m_TypeC != 'S'	 &&			// 0x53
						VarInfo -> m_TypeC != 's')				// 0x73
					{
						switch (VarInfo -> m_TypeC)
						{
							case 'c' :
								*((char*) (VarInfo -> m_pVar))	= 0;
								break;
							case 'i' :
								*((int*) (VarInfo -> m_pVar))	= 0;
								break;
							case 'l' :
							case 'L':
								*((long*) (VarInfo -> m_pVar))	= 0;
								break;
							case 'f' :
								*((float*) (VarInfo -> m_pVar)) = 0;
								break;
							case 'd' :
								*((double*) (VarInfo -> m_pVar))= 0;
								break;
						}	// fin du switch
					}		// fin du if

					if (VarInfo -> m_Name [0] != ':')	// colonne de select
						VarInfo->m_indp = VarInfo->m_Tindp [m_nIndLine];
				}
				m_nIndLine++;
			}
		}
	}

	ReleaseMutex (hBddMutex);
	return (ret);
}		// Fetch


///////////////////////////////////////////////////////////////////////////////
//@mfunc cette fonction execute l'ordre SQL associé au curseur. Par
// rapport a <mf CBdd::Exec> si l'ordre est une insertion la méthode
// retourne KO si l'insertion n'a pas eu lieu à cause d'une clé
// dupliquée, mais ne provoque pas de message oracle.
//
//@rdesc Retourne le status du curseur :
//	@flag OK  | Si l'exécution est complète.
//	@flag KO  | Si l'exécution a échoué.

bool CCursor::ExecInsert ()
{
	WaitForSingleObject (hBddMutex, INFINITE);

	if (this == NULL)
	{
		m_Status = KO;
		ReleaseMutex (hBddMutex);
		return KO;
	}			// JPB

	if  (m_Status == OK)
	{
		POSITION Pos = m_VarInfoList.GetHeadPosition ();
		while (Pos != NULL)
		{
			CVarInfo* VarInfo = m_VarInfoList.GetNext (Pos);

			if (VarInfo->m_TypeC == 'S')
			{
				char* CStringBuf = 
					((CString*)VarInfo->m_pVar)->GetBufferSetLength (VarInfo->m_Size); 

				strcpy (VarInfo->m_CStringBuf, CStringBuf);	// JPB
				((CString*)VarInfo->m_pVar)->ReleaseBuffer ();	// JPB
			}

			if (VarInfo->m_TypeC == 'L')
			{
				if (*(long*)VarInfo->m_pVar == 0)
					// Colonne null
					VarInfo->m_indp = -1;
			}
		}
		
		if (oexec (&m_Cursor))
		{
			if (m_Cursor.rc != 1)
			{
				OCIMessageBox ();
				m_Status = KO;
			}
			else
			{
				ReleaseMutex (hBddMutex);
				return DUPLIC_KEY;
			}
		}

		if (m_Status == OK)
		{
			POSITION Pos = m_VarInfoList.GetHeadPosition ();
			while (Pos != NULL)
			{
				CVarInfo* VarInfo = m_VarInfoList.GetNext (Pos);

				if(	VarInfo->m_CStringBuf != NULL)
					*((CString*)VarInfo->m_pVar) = VarInfo->m_CStringBuf;
			}
		}
	}

	ReleaseMutex (hBddMutex);
	return (m_Status);
}		// ExecInsert


///////////////////////////////////////////////////////////////////////////////
//@mfunc Cette fonction indique si la colonne <p ColumnName> a reçu une valeur 
// non null suite au Fetch. Si <p ColumnName> n'est pas un nom de colonne
// une erreur se produit...
//
//@rdesc Retourne le status du curseur :
//	@flag true  | Si la valeur de la colonne est null.
//	@flag false | Si la valeur de la colonne n'est pas null.
	
bool CCursor::IsNull
(
	char* ColumnName  //@parm Nom d'une colonne du curseur.
)
{
	// ColumnName ne doit pas être null
	ASSERT (ColumnName != NULL);

	POSITION Pos = m_VarInfoList.GetHeadPosition ();
	while (Pos != NULL)
	{
		CVarInfo* VarInfo = m_VarInfoList.GetNext (Pos);
		if (strcmp (VarInfo->m_Name, ColumnName) == 0)
			return (VarInfo->m_indp < 0);
	}
	
	// Erreur ColumnName ne fait pas partie de la liste des colonnes
	// retournées.
	ASSERT (ColumnName == NULL);
	return (false);
}


///////////////////////////////////////////////////////////////////////////////
//@mfunc Cette méthode permet de spécifier un nouveau message
// <p pMess> en réponse à l'erreur oracle d'indice <p MessId>
//
void CCursor::CatchOraMess 
(
	int      OracleMessId, 
	CString* pMessage
)
{
	m_CatchMessMap.SetAt (OracleMessId, pMessage);
}


///////////////////////////////////////////////////////////////////////////////
//@mfunc Récupère dans <p OraMess> le message Oracle décrivant 
// l'état courant du curseur
//
void CCursor::GetOraMess
(
	CString& OraMess
)
{
	sword	n;					// nb de caractères du message
	char	msg [ORAMESS_SIZE]; // buffer pour récupérer le message Oracle 

	n = oerhms(&m_Cursor, m_Cursor.rc, (text *) msg, (sword) sizeof (msg));
	if (n>0)
		OraMess = msg;
	else
		OraMess = "";
}


///////////////////////////////////////////////////////////////////////////////
//@mfunc Cette fonction affiche les messages fournis par Oracle,
// suite à une erreur.
//

void CCursor::OCIMessageBox ()
{

#ifndef TEST_OCI

	CString* pStringMess;

	if (m_CatchMessMap.Lookup (m_Cursor.rc, pStringMess))
	{
		ASSERT (pStringMess != NULL);

		if (!pStringMess->IsEmpty ())
			AfxMessageBox (*pStringMess, MB_ICONSTOP | MB_OK);

		// Lecture des paramètres en ligne de commande
//		theApp.ParseCommandLine (CmdInfo);

		//if (CmdInfo.m_Debug)
		//{
			sword	n;					// nb de caractères du message
			char	msg [ORAMESS_SIZE]; // buffer pour récupérer le message Oracle 

			n = oerhms(&m_Cursor, m_Cursor.rc, (text *) msg, (sword) sizeof (msg));
			AfxMessageBox (msg, MB_ICONSTOP | MB_OK);
		//}
	}

	else
	{
		sword	n;					// nb de caractères du message
		char	msg [ORAMESS_SIZE]; // buffer pour récupérer le message Oracle 

		// Messages Oracle à modifier ou supprimer
		if (m_Cursor.rc == 1086)
			return;		// ORA-1086 : point de sauvegarde 'SAVE_DOC'
						// n'a jamais été établi

		if (m_pBdd->bConnecte &&
			(m_Cursor.rc == 1012 ||	// ORA-1012  Session abandonnée
			 m_Cursor.rc == 3114))	// ORA-3114	 Perte de connexion
		{
			m_pBdd->Close();
			m_pBdd->Open (m_pBdd->m_Connexion, m_pBdd->m_ArraySize);
			// OutputDebugString ("Fermeture et réouverture BDD dans CCursor::OCIMessageBox\n");		
							// essai de rétablissement de la connexion

			for (int i=0; i<10; i++)
			{
				Sleep (10);
				if (m_pBdd->IsOpen())
					return;
			}
		}

		n = oerhms(&m_Cursor, m_Cursor.rc, (text *) msg, (sword) sizeof (msg));
		AfxMessageBox (msg, MB_ICONSTOP | MB_OK);
	}

#endif
}
