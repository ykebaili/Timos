//
// Mib.cpp : implementation file
//  Auteur	: Jean-Pierre BORG
//  Date	: 03/01/2004
//
//  Ce module définit le document associé à un module MIB
//
#define	WINVER	0x0400

#include "stdafx.h"
#include "assert.h"
#include <direct.h>
#include "divers.h"

 
//#include "spvexplo.h"
#include "Mib.h"

//#include "user.h"			// pour classe CRichString
//#include "ListColor.h"		// pour classe CListColor
//#include "FcomSnmp4_0.h"	// pour classe CFcomSnmp

extern AFX_EXTENSION_MODULE MibBrowserDLL;

extern CBdd Bdd;

// #define ASN_OCTET_STR	((u_char)0x04)

#ifdef _Debug
#define new Debug_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

#define DEEPMAX		10			// Profondeur max. d'analyse
#define MAX_IMPORTS 1024		// Nb. max. d'items importés pour un moduleIdentifier
#define SEPXLS	'\t'			// Tab code hexa 09

bool Debug1 = true;
bool Debug2 = false;

class CItem;
class CMibObj;

static int Tabs []  = {50};		// Affichage de la liste des énumérés

static CString lOid [MAX_COLS];	// Table des OID (sans index) à interroger
static CString lVal [MAX_COLS];	// Table des résultats ramenés
static CString lNom [MAX_COLS];	// Table des noms de colonnes

CTime	DOper;					// Date et heure de l'opération (Compile ou compile all)
CMapStringToOb Modules;			// Liste des appelants. Permet de détecter les boucles !!
bool	bCompileAll;			// TRUE si CompileAll lancé : on n'affiche pas les messages d'erreur

///////////////////////////////////////////////////////////////////////////////////////////
//		Fonctions globales
//

//
//	 Convertit en un int une chaîne de caractères, représentant un nombre écrit en binaire.
//	 Retourne -1 en cas d'erreur
//
int  btoi (CString s)
{
	int  l;		// nb. chiffres du nombre
	int	 i;		// index
	int	 r;		// résultat
	unsigned long p;	// puissances de 2

	l = s.GetLength();

	for (i=l-1, r=0, p=1; i>=0; i--, p *= 2)
		if (s [i] >= '0' && s [i] <= '1')
			r = r + (s [i] - '0')*p;
		else
			return -1;

	return r;
}		// btoi


//
//	 Convertit en un int une chaîne de caractères, représentant un nombre écrit en hexa.
//	 Nombre limité à 32000
//	 Retourne -1 en cas d'erreur
//
int  xtoi (CString s)
{
	int  l;		// nb. chiffres du nombre
	int	 i;		// index
	int	 r;		// résultat
	unsigned long p;	// puissances de 16

	s.MakeUpper();
	l = s.GetLength();

	for (i=l-1, r=0, p=1; i>=0; i--, p *= 16)
		if (s [i] >= '0' && s [i] <= '9')
			r = r + (s [i] - '0')*p;
		else if (s [i] >= 'A' && s [i] <= 'F')
			r = r + (s [i] - 'A' + 10)*p;
		else
			return -1;

	return r;
}		// xtoi


/////////////////////////////////////////////////////////////////////////////
// CMibModule
//
/////////////////////////////////////////////////////////////////////////////

IMPLEMENT_DYNCREATE (CMibModule, CItem);

///////////////////////////////////////////////////////////////////////////////
//@mfunc Echange des données entre boîte de dialogue et variables membres
//		 pour une consultation



//////////////////////////////////////////////////////////////////////////////
//
//		Méthodes générales
//
// JPB Dec 2003
//

CMibModule::CMibModule()
{
	//{{AFX_DATA_INIT(CMibModule)
	m_Comment	= _T("");
	m_CompilDate= _T("");
	m_ClassId	= 0;
	m_Date		= _T("");
	m_FamilleId = 0l;
	m_FamilleNom= _T("");
	m_Ligne		= _T("");
	m_LigneLong	= 0;
	m_LigneNum	= 0;
	m_MotRendu	= _T("");
	m_Name		= _T("");
	m_NbErr		= 0;
	m_NbObj		= 0;
	m_NbObjSupp = 0;
	m_NbWarn	= 0;
	m_pObj		= NULL;
	m_Path		= _T("");
	m_Pos		= 0;
	m_SMI		= 0;
	m_SNMPName	= _T("");
	m_Version	= _T("");
	m_lpszErrMess = 0;
	m_lpszErrComp = 0;
	m_lpszLogComp = 0;
	m_strErrComp = _T("");
	m_strLogComp = _T("");
	//}}AFX_DATA_INIT
}


CMibModule::~CMibModule()
{
	CString s;			// banal
	CMibObj * pObj;		// banal

	// On supprime les enregistrements restants
	POSITION Pos = m_Objs.GetStartPosition ();
	while (Pos != NULL)
	{
		pObj = NULL;
		m_Objs.GetNextAssoc (Pos, s, (CObject *&) pObj);
		if (pObj != NULL)
		{
			delete pObj;
			m_NbObjSupp++;
		}
	}
	m_Objs.RemoveAll ();

	m_ObjsEnum.RemoveAll ();

	if (m_lpszErrMess != 0)
	{
		delete [] m_lpszErrMess;
		m_lpszErrMess = 0;
	}

	if (m_lpszErrComp != 0)
	{
		delete [] m_lpszErrComp;
		m_lpszErrComp = 0;
	}

	if (m_lpszLogComp != 0)
	{
		delete [] m_lpszLogComp;
		m_lpszLogComp = 0;
	}
}


//@mfunc Renvoie le message suivant la position
char * CMibModule::GetNextErrMess()
{
	if (m_bFin)
	{
		m_bFin = false;
		m_posMess = 0;
		return "";
	}

	if (m_posMess == 0)
	{
		m_posMess = m_ErrMessages.GetHeadPosition();
		if (m_posMess == 0)
		{
			m_bFin = true;
			return "";
		}
	}

	CString strMess = m_ErrMessages.GetNext (m_posMess);
	if (m_posMess == 0)
		m_bFin = true;

	if (m_lpszErrMess != 0)
		delete [] m_lpszErrMess;

	m_lpszErrMess = new char[strMess.GetLength() + 1];
	strcpy (m_lpszErrMess, (LPCTSTR) strMess);
	return m_lpszErrMess;
}


//@mfunc Retourne les erreurs de compilation
char* CMibModule::GetCompileErrors()
{
	if (m_lpszErrComp != 0)
		delete [] m_lpszErrComp;

	m_lpszErrComp = new char[m_strErrComp.GetLength() + 1];
	strcpy (m_lpszErrComp, (LPCTSTR) m_strErrComp);
	return m_lpszErrComp;
}

//@mfunc Retourne les logs de compilation
char* CMibModule::GetCompileLogs()
{
	if (m_lpszLogComp != 0)
		delete [] m_lpszLogComp;

	m_lpszLogComp = new char[m_strLogComp.GetLength() + 1];
	strcpy (m_lpszLogComp, (LPCTSTR) m_strLogComp);
	return m_lpszLogComp;
}

///////////////////////////////////////////////////////////////////////////////
//@mfunc Retourne le chemin d'accès au script
//

CString CMibModule::GetPath()
{
	return (m_Path);
}		// GetPath


/////////////////////////////////////////////////////////////////////////////
// CMibModule message handlers

///////////////////////////////////////////////////////////////////////////////
//@mfunc Ordre de création des données en BDD pour un module MIB
//		 Voir la fonction Store locale
//
CCursor * CMibModule::CreateOrder ()
{
	return (new CCursor (&Bdd,
						 "insert into MIBMODULE  \
								 (MIBMODULE_ID,  \
								  MIBMODULE_NOM, \
								  MIBMODULE_CLASSID,\
								  MIBMODULE_FIC,\
								  MIBMODULE_COMMENT, \
								  FAMILLE_ID, \
								  MIBMODULE_CPTDOC, \
								  MIBMODULE_NAME,	\
								  MIBMODULE_VERSION,\
								  MIBMODULE_DATE,	\
								  MIBMODULE_SMI,	\
								  MIBMODULE_COMPILDATE \
								  )\
								  VALUES (SEQ_MIBMODULE.NEXTVAL, \
								  #129S#:m_Name,\
								  #l#:m_ClassId,\
								  #129S#:m_Path,\
								  #129S#:m_Comment, \
								  #L#:m_FamilleId, \
								  0, #129S#:m_SNMPName, #41S#:m_Version, #41S#:m_Date, \
								  #i#:m_SMI, #41S#:m_CompilDate)",
						 &m_Name, &m_ClassId, &m_Path, &m_Comment, &m_FamilleId,
						 &m_SNMPName, &m_Version, &m_Date, &m_SMI, &m_CompilDate)); 
}			// CreateOrder


///////////////////////////////////////////////////////////////////////////////
//@mfunc Ordre de mise à jour des données en BDD, voir la fonction Store locale.
//
CCursor * CMibModule::UpdateOrder ()
{
	return (new CCursor (&Bdd,
						 "update MIBMODULE \
							set MIBMODULE_NOM  = #129S#:m_Name,	\
								MIBMODULE_FIC  = #129S#:m_Path,	\
								MIBMODULE_COMMENT    = #129S#:m_Comment, \
								FAMILLE_ID	   = #L#:m_FamilleId, \
								MIBMODULE_NAME = #129S#:m_SNMPName,\
								MIBMODULE_VERSION    = #41S#:m_Version,  \
								MIBMODULE_DATE = #41S#:m_Date,	\
								MIBMODULE_SMI  = #i#:m_SMI,		\
								MIBMODULE_COMPILDATE = #41S#:m_CompilDate\
							where MIBMODULE_ID	  = #L#:m_BddId",
						 &m_Name, &m_Path, &m_Comment, &m_FamilleId,
						 &m_SNMPName, &m_Version, &m_Date, &m_SMI, &m_CompilDate, &m_BddId));
}			// UpdateOrder


///////////////////////////////////////////////////////////////////////////////
//@mfunc Recherche en BDD des données d'un module MIB 
//
//@rdesc Un pointeur sur le curseur Select. Le curseur étant créé sur le tas,
// Il est de la responsabilité de l'appelant de libérer la mémoire correspondante
// après usage
//
CCursor * CMibModule::SelectOrder ()
{
	CString SelectOrder;    // Ordre SELECT

	SelectOrder = "select #129S#MIBMODULE_NOM, #129S#MIBMODULE_FIC, #129S#MIBMODULE_COMMENT, \
					#L#MIBMODULE.FAMILLE_ID, #41S#FAMILLE_NOM, #129S#MIBMODULE_NAME, \
					#41S#MIBMODULE_VERSION, #41S#MIBMODULE_DATE, #i#MIBMODULE_SMI,	\
					#41S#MIBMODULE_COMPILDATE	\
						from MIBMODULE, FAMILLE where MIBMODULE_ID = #L#:m_BddId \
							 and FAMILLE.FAMILLE_ID (+) = MIBMODULE.FAMILLE_ID";

	if (m_State == Modification || m_State == Copie)
		SelectOrder += " FOR UPDATE OF mibmodule_nom NOWAIT";

	return (new CCursor (&Bdd, SelectOrder, &m_Name, &m_Path, &m_Comment, &m_FamilleId,
						 &m_FamilleNom, &m_SNMPName, &m_Version, &m_Date, &m_SMI, &m_CompilDate, 
						 &m_BddId));
}			// SelectOrder


///////////////////////////////////////////////////////////////////////////////
//@mfunc Copie des dépendances d'un module MIB vers un autre dans la duplication
//
//@rdesc Une des valeurs suivantes
//	@flag	true  | si succès
//	@flag	false | si échec
//
bool CMibModule::CopySuite (long lBddIdOrg, long lBddIdItemCop)
{
	long lBddIdCop;

	if (! Bdd.CurValSeq ("mibmodule", lBddIdCop))
		return false;

	CCursor CurCop (&Bdd, "BEGIN\
								CopMibModule (#l#:lBddIdOrg, #l#:lBddIdCop);\
						   END;",
					&lBddIdOrg, &lBddIdCop);

	if (CurCop.Exec () != OK)
		return false;

	return true;
}			// CopySuite


///////////////////////////////////////////////////////////////////////////////
//@mfunc Ordre de suppression d'un module MIB
//
//@rdesc Un pointeur sur le curseur de suppression. Le curseur étant créé sur le tas,
// Il est de la responsabilité de l'appelant de libérer la mémoire correspondante
// après usage
//

CCursor* CMibModule::EraseOrder ()
{
	return ( new CCursor (m_pBdd,
		"BEGIN\
			DelMibModule (#l#:m_BddId);\
		 END;", &m_BddId));
}			// EraseOrder


///////////////////////////////////////////////////////////////////////////////
//@mfunc Initialisation avant la création d'un script à partir du Dialog
//
// Retour : néant
//
// Auteur G.G.
// Date : 12/09/03 -- Création
// Release : 1.0

void CMibModule::InitCreate (long BddId, long ClassId)
{
	// Identification de la famille de mib
	// L'ID du père est en fait l'ID de la famille à partir de laquelle, dans
	// l'explorateur, on fait la demande de création du script.

	m_FamilleId = BddId;
	CCursor CurSel (&Bdd, "SELECT #41S#famille_nom\
				FROM famille\
				WHERE famille_id = #l#:BddId", &m_FamilleNom, &BddId);
		
		if (CurSel.Exec ())
			CurSel.Fetch ();
}		// InitCreate


void CMibModule::InitErrMess()
{
	m_posMess = 0;
	m_ErrMessages.RemoveAll();
	m_bFin = false;
	if (m_lpszErrMess != 0)
	{
		delete [] m_lpszErrMess;
		m_lpszErrMess = 0;
	}
}


int CMibModule::ConnectAndCompile(char *chaineConnexion)
{
	AFX_MANAGE_STATE (AfxGetAppModuleState());

	try
	{
		int ret = -1;
		InitErrMess();

		if (!Bdd.Open(chaineConnexion))
		{
			CString strMess;
			strMess.Format (IDS_MDB0001);
			m_ErrMessages.AddTail(strMess);
			//AfxMessageBox(IDS_MDB0001);
			return ret;
		}

		ret = Compile ();

		if (Bdd.IsOpen())
			Bdd.Close();

		return ret;
	}
	catch(...)
	{
		if (Bdd.IsOpen())
			Bdd.Close();

		return -1;
	}
}


//	Initialise la compilation du module (ouverture fichiers, init. variables).
//  Recherche le module dans le fichier désigné, et si trouvé, lance la compilation.
//	Affiche les résultats de la compilation.
//  Termine en fermant les fichiers.
//	Retour	0 : OK, -1 : Err. mineure(s), -2 : Err. majeure(s)
//
//	JPB	Jan 2004
//
int CMibModule::Compile ()
{
	CString Root, s;	// banal
	CMibObj * pObj;		// banal

	if (! m_SNMPName.IsEmpty())		// Ce n'est pas la première compilation de ce module
	{
		if (Modules.Lookup (m_SNMPName, (CObject*&) pObj) > 0)	// Il figure déjà dans la listes des appelants !
		{
			s.Format (IDS_MESS0290, m_SNMPName);	//"Boucle détectée avec le module %s"
			if (! bCompileAll)
				//AfxMessageBox (s);
				m_ErrMessages.AddTail(s);

			return -2;
		}

		else
			Modules.SetAt (m_SNMPName, NULL);
	}

	// Ouverture des fichiers

	Root = m_Path.SpanExcluding (".");
	m_FileErr = Root + ".err";
	m_FileLog = Root + ".log";

	fInput = fopen (m_Path, "rb");
	if (fInput == NULL)
	{
		CString strMess;
		strMess.Format (IDS_MESS0291, m_Path);	//"Fichier %s inexistant"
		if (! bCompileAll)
			//AfxMessageBox (strMess);
			m_ErrMessages.AddTail(strMess);

//		AfxSetResourceHandle(hInstOld);	
		return -1;
	}
/*
	fErr = fopen (m_FileErr, "wb");
	if (fErr == NULL)
	{
		s.Format (IDS_MESS0292, m_FileErr);	//"Ne peut créer le fichier %s"
		if (! bCompileAll)
			//AfxMessageBox (s);
			m_ErrMessages.AddTail(s);

		fclose (fInput);
		return -1;
	}
	
	fLog = fopen (m_FileLog, "wb");
	if (fLog == NULL)
	{
		s.Format (IDS_MESS0292, m_FileLog);	//"Ne peut créer le fichier %s"
		if (! bCompileAll)
			//AfxMessageBox (s);
			m_ErrMessages.AddTail(s);

		fclose (fInput);
		fclose (fErr);
		return -1;
	}
*/
	// Initialisation des variables de compilation

	m_Ligne.Empty();
	m_LigneLong	= 0;
	m_LigneNum	= 0;
	m_MotRendu.Empty();
	m_Pos		= 0;
	m_SMI		= 0;

	m_NbObj		= 0;
	m_NbObjSupp	= 0;
	m_NbErr		= 0;
	m_NbWarn	= 0;
	m_Version.Empty();

	POSITION Pos = m_Objs.GetStartPosition ();
	while (Pos != NULL)
	{
		pObj = NULL;
		m_Objs.GetNextAssoc (Pos, s, (CObject *&) pObj);
		if (pObj != NULL)
		{
			delete pObj;
			m_NbObjSupp++;
		}
	}
	m_Objs.RemoveAll ();

/*
	Pos = m_ObjsEnum.GetStartPosition ();
	while (Pos != NULL)
	{
		pObj = NULL;
		m_ObjsEnum.GetNextAssoc (Pos, s, (CObject *&) pObj);
		if (pObj != NULL)
		{
			delete pObj;
		}
	}
*/
	m_ObjsEnum.RemoveAll ();

	// Analyse du fichier de MIB, pour rechercher le module demandé et lancement de
	// sa compilation, s'il est trouvé.

	int ret = 0;
	if (mibFile ())			
	{
		s.Format (IDS_MESS0293,m_NbErr, m_NbWarn);	//"Résultats de la compilation : %d erreurs, %d avertissements\r\nConsultez les fichiers %s et %s"
		if (! bCompileAll)
			//AfxMessageBox (s);
			m_ErrMessages.AddTail(s);

		if (! m_NbErr)
			ret = mibStocke ();	// Stockage des résultats en BDD
		else
		{
			ExternError();
			ret = -1;
		}
	}

	else
	{
		s.Format (IDS_MESS0294,m_SNMPName, m_Path, m_SNMPName);	//"Le module %s n'est pas trouvé dans le fichier %s OU\r\n erreur générale rencontrée dans le module %s"
		if (! bCompileAll)
			//AfxMessageBox (s);
			m_ErrMessages.AddTail(s);

		fclose (fInput);
		//fclose (fErr);
		//fclose (fLog);

		return -2;
	}

	// Fin de l'opération : fermeture des fichiers.

	fclose (fInput);
	//fclose (fErr);
	//fclose (fLog);

	return ret;
}		// Compile


// Lecture d'une ligne de texte. Une ligne doit se terminer par \n ou par EOF
// Elimine les commentaires en fin de ligne
//
// JPB Dec 2003
//
CString CMibModule::ReadLine ()
{
	char	CarLu;		// Caractère lu
	CString	LineLue;	// Ligne lue
	int		Idx;		// Banal
	int		LineLong;	// Longueur de la ligne

	LineLue.Empty();

	while (true)
	{
		if (fread (&CarLu, 1, 1, fInput) <= 0)
			break;

		LineLue += CarLu;

		if (CarLu == '\n')
			break;
	}

	LineLong = LineLue.GetLength();

	LineLue = LineLue.SpanExcluding ("\r\n");
	if ((Idx = LineLue.Find ("--")) >= 0)
		LineLue = LineLue.Left (Idx);

	if (LineLong > 0)
		LineLue += "\n";	// LineLue vide veut dire fin du traitement

	return LineLue;
}		// ReadLine


// Lecture d'un mot "valide". Un mot se termine par un caractère de CarSep ou par EOL
// Un mot "valide" est un mot qui ne contient pas de caractères de CarSep
// Si le "mot" s'étend sur plusieurs lignes, il faut appeler plusieurs fois ReadWord
// Les caractères de séparation ou les blancs en tête sont supprimés, sauf ceux "attendus".
// Si un séparateur "attendu" est en tête, on s'arrête sur lui.
// En sortie, Pos pointe sur le 1° caractère suivant le mot, ou sur le 1° caractère "attendu" rencontré
// Le résultat correspond au mot trouvé ou au séparateur attendu, selon le cas.
//
// JPB Dec 2003
//
CString CMibModule::ReadWord
(
	CString CarSep,		// Ensemble des caractères séparateurs
	CString	SepAtt		// Séparateur particulier attendu. Si on le trouve en début de mot,
						// on sort en se positionnant sur lui
)
{
	int		Idx;		// Banal
	CString	Str;		// Sous-chaîne de recherche
	CString	s;			// banal
	int		i;			// banal

	if (! m_MotRendu.IsEmpty())
	{
		s = m_MotRendu;
		m_MotRendu.Empty();
		return s;
	}

	Str = m_Ligne.Right (m_LigneLong - m_Pos);

	Idx = Str.FindOneOf (CarSep);

	if (Idx == 0)		// On démarre par un (ou plusieurs) caractère(s) séparateur(s)
	{
		s = Str.SpanIncluding (CarSep);			// On rejette les blancs de tête

		if (SepAtt.IsEmpty())
			i = -1;
		else
			i = s.FindOneOf (SepAtt);

		if (i >= 0 && i < s.GetLength())		// Séparateur attendu trouvé en début de mot
		{
			m_Pos += i;
			return m_Ligne [m_Pos];
		}

		m_Pos += s.GetLength();
		Str = m_Ligne.Right (m_LigneLong - m_Pos);
	}

	s = Str.SpanExcluding (CarSep);
	m_Pos += s.GetLength();

	if (! s.GetLength())
	{
		m_LigneNum++;
		m_Pos	= 0;
		m_Ligne = ReadLine();
		if (m_Ligne.IsEmpty())
			return "";

		m_LigneLong = m_Ligne.GetLength();
		m_Ligne = m_Ligne.Left (m_LigneLong -1);	// Suppression du \n final
		m_LigneLong--;

		s = ReadWord (CarSep, SepAtt);
	}

	return s;
}		// ReadWord


//	Traitement des erreurs de compilation
//
// JPB Dec 2003
//
void CMibModule::Erreur 
(
	int		NumErr,		// Numéro d'erreur
	bool	bErr,		// true = Erreur, false = Warning
	CString Comment		// Commentaire libre
)
{
	/*
	if (bErr)
		fprintf (fErr, GetStrItem(IDS_MDC0261), 
				 NumErr, m_LigneNum, m_Pos, Comment); //"Erreur n° %d Ligne %d Position %d -- %s \r\n"
	else
		fprintf (fErr, GetStrItem(IDS_MDC0262), 
				 NumErr, m_LigneNum, m_Pos, Comment); //"Avertissement n° %d Ligne %d Position %d -- %s \r\n"

	fprintf (fErr, "%s \r\n\r\n", m_Ligne);

	if (bErr)
		m_NbErr++;
	else
		m_NbWarn++;
		*/

	CString strErr;
	if (bErr)
		strErr.Format (GetStrItem(IDS_MDC0261), 
						NumErr, m_LigneNum, m_Pos, Comment); //"Erreur n° %d Ligne %d Position %d -- %s \r\n"
	else
		strErr.Format (GetStrItem(IDS_MDC0262), 
						NumErr, m_LigneNum, m_Pos, Comment); //"Avertissement n° %d Ligne %d Position %d -- %s \r\n"

	m_strErrComp += strErr;
	strErr.Format ("%s \r\n\r\n", m_Ligne);
	m_strErrComp += strErr;

	if (bErr)
		m_NbErr++;
	else
		m_NbWarn++;

}		// Erreur


//	Traitement externe d'un échec de compilation
//
// JPB Fev. 2004
//
void CMibModule::ExternError()
{
	CMibObj * pObj;		// Pointeur sur un objet lu en CMap
	CString	s;			// banal

	Erreur (134, true);

	// Vidage de la table MIBOBJ
	POSITION Pos = m_Objs.GetStartPosition ();
	while (Pos != NULL)
	{
		pObj = NULL;
		m_Objs.GetNextAssoc (Pos, s, (CObject *&) pObj);
		if (pObj != NULL)
		{
			delete pObj;
			m_NbObjSupp++;
		}
	}

	m_Objs.RemoveAll();

/*
	Pos = m_ObjsEnum.GetStartPosition ();
	while (Pos != NULL)
	{
		pObj = NULL;
		m_ObjsEnum.GetNextAssoc (Pos, s, (CObject *&) pObj);
		if (pObj != NULL)
		{
			delete pObj;
		}
	}
*/
	m_ObjsEnum.RemoveAll();

	m_CompilDate.Empty();

	// Suppression des anciens objets MIBOBJ
	mibStocke();

	if (! bCompileAll)
	{
		//AfxMessageBox (IDS_MESS0295);	//"Pb. lors de la compilation d'un module. Compilation abandonnée"
		CString strMess;
		strMess.Format (IDS_MESS0295);
		m_ErrMessages.AddTail(strMess);
	}
}		// ExternError


// Lit en BDD la valeur MIBOBJ_VISIBLE pour tous les objets existants déjà pour ce module.
// Met à jour en conséquence la CMap m_Objs pour les objets encore présents
// (ainsi, en cas de recompilation ou maj de la MIB, les choix précédents de l'opérateur 
//	sont conservés).
// Note : pour les objets nouveaux, la valeur par défaut est "Visible".
//
// Supprime de la BDD tous les anciens objets de ce module.
// Stocke en BDD les résultats de la compilation :
//	  Dans la table MIB_MODULE : **_NAME, **_DATE, **_SMI, **_COMPILDATE
//	  Dans la table MIB_OBJ : tous les objets découverts au cours de la compil.
//	  Met à jour les variables du module et l'écran affiché.
//
// JPB Jan 2004
//
// XL 23/04/09 : renvoie 0 si pas erreur, -2 dans le cas contraire
int CMibModule::mibStocke ()
{
	CString s;			// banal
	CMibObj * pObj;		// Pointeur sur un objet lu en CMap

	CString	ObjNom;		// Joli nom de l'objet
	CString	ObjName;	// Nom de l'objet lu en BDD
	CString	ObjType;	// Type de cet objet
	CString	FatherName;	// Nom de son père
	int		ObjVis;		// Objet visible (1) ou non (0)
	CString	Comment;	// Commentaire sur l'objet
	CString	Key;		// Clé de recherche en CMap
	CString strMess;

	// Lit en BDD la valeur MIBOBJ_VISIBLE pour tous les objets existants déjà pour ce module
	// et maj de m_Objs en conséquence

//	BeginWaitCursor();

	CCursor CObj (&Bdd, "select #129S#MIBOBJ_NOM, #129S#MIBOBJ_NAME, #11S#MIBOBJ_TYPE, \
							#i#MIBOBJ_VISIBLE, #129S#MIBOBJ_FATHERNAME, #81S#MIBOBJ_COMMENT  \
							from  MIBOBJ \
							where MIBMODULE_NAME = #129S#:name",
							&ObjNom, &ObjName, &ObjType, &ObjVis, &FatherName, &Comment, &m_SNMPName);
	CObj.Exec();

	while (CObj.Fetch() == OK)
	{
		if (m_Objs.Lookup (ObjName, (CObject*&) pObj) > 0)
		{
			if (ObjType != pObj->m_Type)
				continue;
			if (ObjType == "VT" && FatherName != pObj->m_TableName)
				continue;

			pObj->m_Visible = (ObjVis == 1 ? true : false);
			pObj->m_Name	= ObjNom;
			pObj->m_Comment	= Comment;
		}
	}

	// Supprime de la BDD tous les anciens objets de ce module.

	CCursor CDel1 (&Bdd, "delete MIBENUM where MIBOBJ_ID in \
							  (select MIBOBJ_ID from MIBOBJ \
									where MIBMODULE_NAME = #129S#:name)",
							&m_SNMPName);
	if (CDel1.Exec() != OK)
	{
		if (! bCompileAll)
		{
			//AfxMessageBox (IDS_MESS0296);	//"Erreur de stockage en BDD. Compilation abandonnée"
			strMess.Format (IDS_MESS0296);
			m_ErrMessages.AddTail(strMess);
		}
//		EndWaitCursor();
		return -2;
	}

	CCursor CDel  (&Bdd, "delete MIBOBJ where MIBMODULE_NAME = #129S#:name",
							&m_SNMPName);

	if (CDel.Exec() != OK)
	{
		if (! bCompileAll)
		{
			//AfxMessageBox (IDS_MESS0296);	//"Erreur de stockage en BDD. Compilation abandonnée"
			strMess.Format (IDS_MESS0296);
			m_ErrMessages.AddTail(strMess);
		}
//		EndWaitCursor();
		return -2;
	}
	
	// Stocke en BDD les résultats de la compilation

	if (! m_NbErr)
	{
		CCursor CDte (&Bdd, " select #41S#to_char (sysdate, 'DD/MM/YYYY HH24:MI:SS') from dual", 
							&m_CompilDate);
		CDte.Exec();
		CDte.Fetch();
	}

	// Table MIBMODULE
	CCursor CUp1 (&Bdd, "update MIBMODULE set	\
							MIBMODULE_NAME = #129S#:Name, \
							MIBMODULE_DATE = #41S#:SDate, \
							MIBMODULE_SMI  = #i#:SMI,	 \
							MIBMODULE_COMPILDATE = #41S#:CDate \
								where MIBMODULE_NOM = #129S#:MName",
							&m_SNMPName, &m_Date, &m_SMI, &m_CompilDate, &m_Name);
	if (CUp1.Exec() != OK)
	{
		if (! bCompileAll)
		{
			//AfxMessageBox (IDS_MESS0296);	//"Erreur de stockage en BDD. Compilation abandonnée"
			strMess.Format (IDS_MESS0296);
			m_ErrMessages.AddTail(strMess);
		}
//		EndWaitCursor();
		return -2;
	}

	// Table MIBOBJ
	POSITION Pos = m_Objs.GetStartPosition ();
	while (Pos != NULL)
	{
		pObj = NULL;
		m_Objs.GetNextAssoc (Pos, s, (CObject *&) pObj);
		if (pObj != NULL)
		{
			pObj->m_Info		= pObj->m_Info.Left (2000);			// Taille du Varchar2
			pObj->m_Reference	= pObj->m_Reference.Left (2000);	// Taille du Varchar2
			pObj->m_DisplayHint = pObj->m_DisplayHint.Left (2000);	// Taille du Varchar2
			if (pObj->m_Visible)
				ObjVis = 1;
			else
				ObjVis = 0;

			if (Debug1)
			{
				CString strLog;
				strLog.Format("%s\t%s (Table %s)\t%s  (Ln : %d) (Type %s -- %s) Acces %s Status %s DefVal %s \
								\r\nIndex : %s  -- Augments : %s\
								\r\nInfo : %s\r\n\r\n",
								pObj->m_Type, pObj->m_Name, pObj->m_TableName, pObj->m_OID, pObj->m_LineNbr,
								pObj->m_TypeSNMP, pObj->m_Constraint, pObj->m_Access, 
								pObj->m_Status, pObj->m_DefVal,
								pObj->m_Index, pObj->m_Augments, pObj->m_Info);
				m_strLogComp += strLog;

/*
				fprintf (fLog, "%s\t%s (Table %s)\t%s  (Ln : %d) (Type %s -- %s) Acces %s Status %s DefVal %s \
								\r\nIndex : %s  -- Augments : %s\
								\r\nInfo : %s\r\n\r\n",
								pObj->m_Type, pObj->m_Name, pObj->m_TableName, pObj->m_OID, pObj->m_LineNbr,
								pObj->m_TypeSNMP, pObj->m_Constraint, pObj->m_Access, 
								pObj->m_Status, pObj->m_DefVal,
								pObj->m_Index, pObj->m_Augments, pObj->m_Info);
*/
			}
			// JL 30/01/2006
			// Maj pour obtenir m_Enterprise à partir de m_OID.

			if(pObj->m_OID.GetLength() > 13 && _T(pObj->m_OID).Left(13) == ".1.3.6.1.4.1.")
			{
				pObj->m_Enterprise = _T(pObj->m_OID).Mid(13);
				pObj->m_Enterprise = _T(pObj->m_Enterprise).Mid(0,_T(pObj->m_Enterprise).Find('.'));	
			}
			// Fin de Maj JL

			CCursor CUp2 (&Bdd, "insert into MIBOBJ \
									(MIBOBJ_ID, MIBOBJ_CLASSID, MIBOBJ_NOM, MIBOBJ_NAME, MIBOBJ_COMMENT, \
									 MIBMODULE_ID, MIBMODULE_NAME, \
									 MIBOBJ_TYPE, MIBOBJ_LINENBR, MIBOBJ_VISIBLE,		  \
									 MIBOBJ_FATHERNAME, MIBOBJ_OID, MIBOBJ_IANA, MIBOBJ_TRAPNBR, \
									 MIBOBJ_TYPESNMP, MIBOBJ_CONSTRAINT, MIBOBJ_UNIT,	  \
									 MIBOBJ_ACCESS, MIBOBJ_STATUS, MIBOBJ_DEFVAL, MIBOBJ_INDEX,	 \
									 MIBOBJ_AUGMENTS, MIBOBJ_INFO, MIBOBJ_REF, MIBOBJ_HINTS)	 \
									 values			\
									 (SEQ_MIBOBJ.NEXTVAL, #i#:ClassId, #129S#:Name, #129S#:SName, #81S#:Commentaire, \
									  #l#:MId, #129S#:MName,	\
									  #11S#:SType, #i#:Nbr, #i#:Visible,	\
									  #129S#:FName, #257S#:Oid, #129S#:Iana, #i#:Trap,			\
									  #41S#:TypeSNMP, #257S#:SConstraint, #41S#:SUnit,		\
									  #41S#:Acces, #41S#:Status, #257S#:DefVal, #257S#:SIndex,\
									  #257S#:Augments, #2001S#:Info, #2001S#:Ref, #2001S#:Hints)",
								&CMIBOBJ_ID, &pObj->m_Name, &pObj->m_SNMPName, &pObj->m_Comment,
								&m_BddId, &m_SNMPName,
								&pObj->m_Type, &pObj->m_LineNbr, &ObjVis,
								&pObj->m_TableName, &pObj->m_OID, &pObj->m_Enterprise, &pObj->m_TrapNbr,
								&pObj->m_TypeSNMP, &pObj->m_Constraint, &pObj->m_Unit,
								&pObj->m_Access, &pObj->m_Status, &pObj->m_DefVal, &pObj->m_Index,
								&pObj->m_Augments, &pObj->m_Info, &pObj->m_Reference, &pObj->m_DisplayHint);

			if (CUp2.Exec() != OK)
			{
				if (! bCompileAll)
				{
					//AfxMessageBox (IDS_MESS0296);	//"Erreur de stockage en BDD. Compilation abandonnée"
					strMess.Format(IDS_MESS0296);
					m_ErrMessages.AddTail(strMess);
				}
//				EndWaitCursor();
				return -2;
			}

			// Stockage des énumérés éventuels
			// Table MIBENUM

			for (int iEnum=0; iEnum < pObj->m_NbEnum; iEnum++)
			{
				CCursor CUp3 (&Bdd, "insert into MIBENUM \
										(MIBENUM_ID, MIBENUM_NAME, MIBENUM_CODE, MIBENUM_TYPE,  \
										 MIBOBJ_ID, MIBOBJ_NAME) \
										 values \
										 (SEQ_MIBENUM.NEXTVAL, #129S#:Name, #l#:Code, #11S#:Type, \
										  SEQ_MIBOBJ.CURRVAL, #129S#:ObjName)",
									 &pObj->m_NameEn [iEnum], &pObj->m_CodeEn [iEnum], &pObj->m_TypeEnum,
									 &pObj->m_Name);

				if (CUp3.Exec() != OK)
				{
					if (! bCompileAll)
					{
						//AfxMessageBox (IDS_MESS0296);	//"Erreur de stockage en BDD. Compilation abandonnée"
						strMess.Format(IDS_MESS0296);
						m_ErrMessages.AddTail(strMess);
					}
//					EndWaitCursor();
					return -2;
				}
			}

			delete pObj;
			m_NbObjSupp++;
		}
	}

	m_Objs.RemoveAll();

/*
	Pos = m_ObjsEnum.GetStartPosition ();
	while (Pos != NULL)
	{
		pObj = NULL;
		m_ObjsEnum.GetNextAssoc (Pos, s, (CObject *&) pObj);
		if (pObj != NULL)
		{
			delete pObj;
		}
	}
*/
	m_ObjsEnum.RemoveAll();

	Bdd.Commit();

	return 0;
//	EndWaitCursor();
}		// mibStocke


// Analyse du fichier de MIB, pour rechercher le module demandé.
// Retourne true si c'est le cas, false sinon.
// Si le module est trouvé, on lance sa compilation.
// A la première compilation (m_SNMPName null), le "joli nom" doit correspondre au nom du 
// module, OU il ne doit y avoir qu'un seul module dans le fichier. Dans ce cas, c'est ce
// module qui est compilé (s'il y a plusieurs modules, le module compilé est le dernier
// trouvé).
//
// <mibFile> = <mibModule>...
// <mibModule> = 
// ucName "DEFINITIONS" "::=" "BEGIN"
// ......
// "END"
//
//	Retourne false si le module n'est pas trouvé dans le fichier
//
// JPB Dec 2003
//
bool CMibModule::mibFile()
{
	CString s;				// banal
	CString ModuleName;		// Nom du module analysé
	CString	Name;			// Nom du module attendu
	CString	Mot [DEEPMAX];	// Mot en cours d'analyse
	CString	CarSep;			// Séparateurs

	CarSep		= " \t\r\n";		// Espace, Tab, CR, LF

	if (m_SNMPName.IsEmpty())		// 1° compilation
		Name = m_Name;
	else							// Compilations suivantes
		Name = m_SNMPName;

//	BeginWaitCursor();
	while (true)
	{	
		ModuleName	= ReadWord (CarSep, "");
		if (ModuleName.IsEmpty())
		{
//			EndWaitCursor();
			return false;
		}

		Mot [0]		= ReadWord (CarSep, "");
		Mot [0].MakeUpper();
		Mot [1]		= ReadWord (CarSep, "");
		Mot [2]		= ReadWord (CarSep, "");
		Mot [2].MakeUpper();

		if (Mot [0] == "DEFINITIONS" && Mot [1] == "::=" && Mot [2] == "BEGIN")
		{
			if (ModuleName == Name)
			{
				if (! mibCompile())		// Compilation du module
				{
//					EndWaitCursor();
					return true;
				}

				m_SNMPName = ModuleName;
				if (Debug1)
				{
					CString strLog;
					strLog.Format ("MibModule %s Date %s SMI %d\r\n", m_SNMPName, m_Date, m_SMI);
					m_strLogComp += strLog;
					/*
					fprintf (fLog, "MibModule %s Date %s SMI %d\r\n", m_SNMPName, m_Date, m_SMI);
					*/
				}

				Modules.SetAt (m_SNMPName, NULL);

//				EndWaitCursor();
				return true;
			}
		}

		else					// Ce n'est pas le module attendu
		{
			while (true)		// Recherche du module suivant
			{	
				Mot [0]	= ReadWord (CarSep, "");
				if (Mot [0].IsEmpty())
				{
//					EndWaitCursor();
					return false;
				}

				Mot [0].MakeUpper();

				if (Mot [0] == "END")
					break;
			}
		}	// fin du cas "module != attendu"
	}		// fin de la boucle sur les modules

//	EndWaitCursor();
}		// mibFile


//	Compilation du module MIB trouvé.
//	Retourne true si 0 err. de compil, false sinon.
//
//  Pour chacune des fonctions appelée par la compilation, on rappelle en commentaire
//  la syntaxe des MIBs définies dans les SMI versions 1 et 2 (si rien n'est indiqué, 
//	cela signifie que la syntaxe est commune aux deux versions).
//	Cette syntaxe est décrite dans le livre "Understanding SNMP MIBs" de
//	David PERKINS et Evan Mc GINNIS - Prentice Hall 1997
//
//	Les erreurs de compilation trouvées sont décrites dans "ErreursMib.txt".
//
// <mibModule> = 
// ucName "DEFINITIONS" "::=" "BEGIN"	// La compilation démarre après le "BEGIN"
// ["IMPORTS" <importsFrom>... ";"]
// <moduleIdentityDefinition>			// Only for V2
// <definitions>
// "END"
//
// JPB Dec 2003
//
bool	CMibModule::mibCompile ()
{
	CString		Mot [DEEPMAX];	// Mot en cours d'analyse
	CString		OldMot;			// OldMot correspond au mot lu, avant qu'il soit forcé en majuscules
	CString		CarSep;			// Séparateur de mots

	CarSep		= " \t\r\n";	// Espace, Tab, CR, LF

	Mot [0]		= ReadWord (CarSep, "");
	OldMot		= Mot [0];
	Mot [0].MakeUpper();

	if (Mot [0] == "IMPORTS")
	{
		if (! importedItems ())
			return false;
	}

	else
		m_MotRendu = OldMot;

	if (! definitions ())
		Erreur (107, true);

	Mot [0]		= ReadWord (CarSep, "");
	OldMot		= Mot [0];
	Mot [0].MakeUpper();

	if (Mot [0] != "END")
		Erreur (129, true);

	if (m_NbErr)
		return false;
	else
		return true;
}		// mibCompile


//
//	Retourne un string pouvant s'étendre sur plusieurs lignes, éventuellement.
//	Un string est contenu entre deux "
//
// JPB Dec 2003
//
CString CMibModule::chrStr()
{
	CString	CarSep2 = "\"";	// Car. séparateur de mots en mode "Texte" : "
	CString	Result;			// Chaîne à retourner

	CString	Mot [DEEPMAX];	// Mot en cours d'analyse
	CString	CarSep;			// Séparateur de mots
	int		LineNum;		// Numéro de ligne, pour réintroduire les sauts de ligne

	CarSep		= " \t\"\r\n";		// Espace, Tab, ", RC, LF

	Mot [0] = ReadWord (CarSep, "\""); // Up to "

	if (Mot [0] == "\"")
		m_Pos++;			// sauter le "
	
	else
	{
		Erreur (104, true);		// Il y des mots non vides avant le "
		return "";
	}

	Result.Empty();
	LineNum = m_LigneNum;

	while (true)
	{
		Mot [0] = ReadWord (CarSep, "\"\r\n");
		if (Mot [0] == "\"")
		{
			m_Pos++;		// sauter le "
			break;
		}

		if (LineNum != m_LigneNum)
		{
			LineNum = m_LigneNum;
			Result += "\r\n";
		}

		Result = Result + " " + Mot [0];
	}

	return Result;
}		// chrStr


//
//	Retourne un OID absolu
//	<oidValue> =
//		  "{" <wellKnownName> <oidCompVal>... "}"
//		| "{" <oidCompVal> <oidCompVal>... "}"
//		| "{" <oidValRef>  <oidCompVal>... "}"
//		| <oidValRef>
//	<wellKnownName> = "ccitt" | "iso" | "joint-iso-ccitt"		(0, 1, 2)
//	<oidValRef>		= [ucName "."]lcName
//	<oidCompVal>	= number  | lcName "(" number ")"			(number : entier >= 0)
//
//	Les constructions { enterprises ***} permettent d'identifier le n° IANA de l'entreprise
//
// JPB Dec 2003
//
CString CMibModule::oidValue()
{
	CString	Result;			// OID à retourner

	CString	Mot [DEEPMAX];	// Mot en cours d'analyse
	CString	CarSep;			// Séparateur de mots
	CString	ucName, lcName;	// Noms commençant par une majuscule ou une minuscule
	CMibObj	 *  pObjFather;	// Pointeur sur le père
	CString	Label;			// Etiquette
	CMibObj  *  pObj;		// Pointeur sur l'objet
	CString  Str;			// Banal

	CarSep		= " \t\r\n.()";		// Espace, Tab, CR, LF, ., (, )

	Mot [0] = ReadWord (CarSep + "{", "{"); 
	Result.Empty();

	if (Mot [0] == "{")
	{
		m_Pos++;		// sauter {

		Mot [0] = ReadWord (CarSep + "}", "()");
		if (Mot [0] == "ccitt")
			Result = "0";
		else if (Mot [0] == "iso")
			Result = "1";
		else if (Mot [0] == "joint-iso-ccitt")
			Result = "2";
		else if (Mot [0] == "enterprises")	// Ajouté à la syntaxe de la norme, pour trouver
											// le n° IANA.
			Result = ".1.3.6.1.4.1";
		else if (Mot [0][0] >= '0' && Mot [0][0] <= '9')
			Result = Mot [0];
		else if (Mot [0][0] >= 'A' && Mot [0][0] <= 'Z' && Mot [0].Find ('.') >=0)
		{
			ucName = Mot [0];				// Dans ucName, le nom du module
			lcName = ReadWord (CarSep, "");	// Dans lcName, le nom de la variable

			if (m_Objs.Lookup (lcName, (CObject*&) pObjFather) > 0)
				Result = pObjFather->m_OID;
			else
				Erreur (105, true, lcName);
		}
		else if (Mot [0][0] >= 'A' && Mot [0][0] <= 'Z' && Mot [0].Find ('.') < 0)
				// Ce cas est interdit par la norme. Malheureusement, on le trouve dans des MIBs !!
		{
			if (m_Objs.Lookup (Mot [0], (CObject*&) pObjFather) > 0)
				Result = pObjFather->m_OID;
			else
				Erreur (105, true, lcName);
		}
		else if (Mot [0][0] >= 'a' && Mot [0][0] <= 'z')
		{
			if (m_Objs.Lookup (Mot [0], (CObject*&) pObjFather) > 0)
				Result = pObjFather->m_OID;
			else if (m_ObjsEnum.Lookup (Mot [0], Str) > 0)
				Result.Format ("%s", Str);
			else
				Erreur (105, true, Mot [0]);
		}

		Label.Empty();
		while (true)
		{
			Mot [1] = ReadWord (CarSep + "}", "()}");

			if (Mot [1] == "(")
			{
				m_Pos++;	// sauter (
				Mot [1] = ReadWord (CarSep, ")");
				Result = Result + "." + Mot [1];
				ReadWord (CarSep, ")");
				m_Pos++;	// sauter )

				if (! Label.IsEmpty())
				{
					pObj	= new CMibObj;
					m_NbObj++;
					pObj->m_Name	 = Label;
					pObj->m_SNMPName = Label;
					pObj->m_LineNbr	 = m_LigneNum;
					pObj->m_Type	 = "ID";
					pObj->m_OID		 = Result;

					m_Objs.SetAt (pObj->m_Name, pObj);
					if (Debug2)
					{
						CString strLog;
						strLog.Format (IDS_MDC0263, pObj->m_Name);
						m_strLogComp += strLog;
						/*
						fprintf (fLog, GetStrItem(IDS_MDC0263), pObj->m_Name); //"Objet créé %s\r\n"
						*/
					}

					Label.Empty();
				}
			}

			else if (Mot [1] == "}")
			{
				m_Pos++;	// sauter }
				break;
			}

			else if (Mot [1][0] >= '0' && Mot [1][0] <= '9')
				Result = Result + "." + Mot [1];

			else if (Mot [1][0] >= 'a' && Mot [1][0] <= 'z')	// Définition d'une étiquette
				Label  = Mot [1];
		}
	}

	else	// oidValRef
	{
		char c = Mot [0][0];

		if (c >= 'A' && c <= 'Z')			// Dans ucName, le nom du module
		{
			ucName = Mot [0];
			lcName = ReadWord (CarSep, "");	// Dans lcName, le nom de la variable
		}
		else
		{
			ucName.Empty();
			lcName = Mot [0];
		}

		if (m_Objs.Lookup (lcName, (CObject*&) pObjFather) > 0)
			Result = pObjFather->m_OID;
		else
			Erreur (105, true, lcName);
	}

	if (!Result.IsEmpty() && Result [0] != '.')
		Result = "." + Result;

	return Result;
}		// oidValue


//   Lit l'identificateur d'un module importé
//	<importedItems> = <importsFrom>... ";"
//  <importsFrom>	= <importsName> ["," <importsName>]... "FROM" <moduleIdentifier>
//	<importsName>	= lcName | ucName | <snmpConstructOrTypeName>
//	<moduleIdentifier> = ucName [<oidValue>]
//
// JPB Dec 2003
//
CString CMibModule::moduleIdentifier()
{
	CString	Mot [DEEPMAX];		// Mot en cours d'analyse
	CString Result;				// résultat à sortir
	CString	CarSep;				// Séparateur de mots

	CarSep		= " \t\r\n";	// Espace, Tab, CR, LF

	Mot [0]	= ReadWord (CarSep + ",;{", ";{");
	Result	= Mot [0];

	Mot [0]	= ReadWord (CarSep + ",;{", ";{");
	m_MotRendu = Mot [0];

	if (Mot [0] == "{")
		oidValue();

	return Result;
}		// moduleIdentifier


//
//   Lit les IMPORTS
//	<importedItems> = <importsFrom>... ";"
//  <importsFrom>	= <importsName> ["," <importsName>]... "FROM" <moduleIdentifier>
//	<importsName>	= lcName | ucName | <snmpConstructOrTypeName>
//	<moduleIdentifier> = ucName [<oidValue>]
//
//  <snmpConstructOrTypeName> : nom d'un type SNMP ou d'une construction définie dans un 
//	module MIB
//
//  Si la construction ucName <oidValue> apparait, l'OID n'est pas pris en compte dans cette
//  implémentation du compilateur.
//  On n'accepte ici comme oidValue que des constructions { .. }. En effet, l'utilisation
//	d'un oidValRef peut être confondu avec le importsName suivant (ambigüité du langage).
//	Cette construction plante le compilateur, qui ne sait pas interpréter de telles MIBs.
//
// JPB Dec 2003
//
bool CMibModule::importedItems()
{
	CString	Mot [DEEPMAX];		// Mot en cours d'analyse
	CString MotMaj;				// Mot en majuscules
	CString	s;					// banal
	int  Id;					// Id de l'objet importé ou du module correspondant

	CString	Items [MAX_IMPORTS];// Stockage temporaire du nom des items, en attendant de
								// connaître le nom du moduleIdentifier
	int		iItem;				// Index de l'item importé
	CString moduleIdent;		// Nom du module importé
	CMibObj * pObj;				// Pointe sur l'objet importé

	CString	CompilDate;			// Date de la dernière compilation
	CTime	DCompil;			// Idem, en CTime
	int	day, month, year, hour, minut, sec;

	CString	CarSep;				// Séparateur de mots
	CarSep		= " \t\r\n";	// Espace, Tab, CR, LF
	CString strMess;

	iItem = 0;
	while (true)
	{
		Mot [0]	= ReadWord (CarSep + ",", ",");
		MotMaj	= Mot [0];
		MotMaj.MakeUpper();

		if (Mot [0] == ",")
			m_Pos++;		// sauter ,

		else if (MotMaj == "FROM")	// On connait le module, on va pouvoir importer les objets
		{
			moduleIdent = moduleIdentifier();

			CCursor CMod (&Bdd, "select #l#MIBMODULE_ID, #41S#MIBMODULE_COMPILDATE \
										from MIBMODULE \
										where MIBMODULE_NAME = #129S#:ObjName or \
											  MIBMODULE_NOM  = #129S#:ObjNom",
									&Id, &CompilDate, &moduleIdent, &moduleIdent);
			if (CMod.Exec() != OK)
			{
				if (! bCompileAll)
				{
					//AfxMessageBox (IDS_MESS0297);	//"Erreur de lecture en BDD. Compilation abandonnée"
					strMess.Format (IDS_MESS0297);
					m_ErrMessages.AddTail(strMess);
				}
				return false;
			}

			if (CMod.Fetch() == OK)
			{
				sscanf (CompilDate, "%2d/%2d/%4d %2d:%2d:%2d", 
								&day, &month, &year, &hour, &minut, &sec);
				if (CompilDate.IsEmpty())
				{
					day		= 1;
					month	= 1;
					year	= 1988;
					hour	= 0;
					minut	= 0;
					sec		= 0;
				}

				CTime DCompil (year, month, day, hour, minut, sec);
				
				if (DCompil < DOper - CTimeSpan (0, 1, 0, 0) || CompilDate.IsEmpty())	
				// Date de compil. plus vieille que la date actuelle - 1 heure : on recompile.
				{
					CMibModule * pModule = new CMibModule;
					pModule->m_BddId = Id;
					pModule->Load();

					int Res = pModule->Compile();

					if (Res == 0)
					{
						CCursor CMod1 (&Bdd, "select #l#MIBMODULE_ID, #41S#MIBMODULE_COMPILDATE \
												from MIBMODULE \
												where MIBMODULE_NAME = #129S#:ObjName",
													&Id, &CompilDate, &moduleIdent);
													// Id et CompilDate ont changé
						CMod1.Exec();
						CMod1.Fetch();
					}

					else if (Res == -1)
					{
						Erreur (133, false, moduleIdent);
						iItem = 0;		// On abandonne cet import
								// On n'abandonne pas la compilation toutefois, car il arrive
								// que des imports soient indiqués bien qu'aucun objet ne
								// les utilise.
					}

					else if (Res == -2)
					{
						Erreur (134, true, moduleIdent);
						return false;
								// On abandonne la compilation.
					}
				}
			}

			else
			{
				Erreur (101, false, moduleIdent);
				iItem = 0;		// On abandonne cet import
								// On n'abandonne pas la compilation toutefois, car il arrive
								// que des imports soient indiqués bien qu'aucun objet ne
								// les utilise.
			}

			for (int i=0; i < iItem; i++)
			{
				CCursor CObj (&Bdd, "select #l#MIBOBJ_ID from MIBOBJ	\
										where MIBOBJ_NAME = #129S#:ObjName and \
											  MIBMODULE_NAME = #129S#:ModName",
									&Id, &Items [i], &moduleIdent);
				if (CObj.Exec() != OK)
				{
					if (! bCompileAll)
					{
						//AfxMessageBox (IDS_MESS0297);	//"Erreur de lecture en BDD. Compilation abandonnée"
						strMess.Format(IDS_MESS0297);
						m_ErrMessages.AddTail(strMess);
					}
					return false;
				}

				if (CObj.Fetch() == OK)
				{
					pObj	= new CMibObj;
					pObj->m_BddId = Id;		// Id de l'objet en BDD

					if (! pObj->Load())
					{
						if (! bCompileAll)
						{
							//AfxMessageBox
							//(IDS_MESS0297);	//"Erreur de lecture en BDD. Compilation abandonnée"
							strMess.Format (IDS_MESS0297);
							m_ErrMessages.AddTail(strMess);
						}
						return false;
					}

					pObj->m_LineNbr	  = m_LigneNum;	// N° de ligne dans le fichier final,
													// pas dans celui importé.

					m_Objs.SetAt (pObj->m_Name, pObj);
					if (Debug2)
					{
						CString strLog;
						strLog.Format(IDS_MDC0263, pObj->m_Name); //"Objet créé %s\r\n"
						m_strLogComp += strLog;
						/*
						fprintf (fLog, GetStrItem(IDS_MDC0263), pObj->m_Name); //"Objet créé %s\r\n"
						*/
					}
					m_NbObj++;
				}

				else
					Erreur (130, false, Items [i]);
			}	// Fin de la boucle sur les items importés dans ce module

			Mot [0]	= ReadWord (CarSep + ",;", ",;");

			if (Mot [0] == ";")
			{
				m_Pos++;		// sauter ;
				return true;	// on a fini
			}

			else if (Mot [0] == ",")
				m_Pos++;		// sauter ,
			
			else
			{
				m_MotRendu = Mot [0];
				iItem = 0;		// On repart sur un nouveau module
			}
		}		// Fin du cas FROM

		else if (Mot [0] == "Counter" || Mot [0] == "Counter32" || Mot [0] == "Counter64" ||
				 Mot [0] == "Gauge"   || Mot [0] == "Gauge32"   || Mot [0] == "Integer32" ||
				 Mot [0] == "IpAddress" || Mot [0] == "NetworkAddress" ||
				 Mot [0] == "Opaque"  || Mot [0] == "TimeTicks" || Mot [0] == "Unsigned32"||	
				 Mot [0] == "INTEGER" || Mot [0] == "BITS"		||
				 Mot [0] == "TEXTUAL-CONVENTION" || Mot [0] == "OBJECT-TYPE" || 
				 Mot [0] == "TRAP-TYPE" || Mot [0] == "SEQUENCE"|| Mot [0] == "MODULE-IDENTITY" ||
				 Mot [0] == "OBJECT-IDENTITY" || Mot [0] == "NOTIFICATION-TYPE"|| Mot [0] == "OBJECT-GROUP" ||
				 Mot [0] == "NOTIFICATION-GROUP" || Mot [0] == "MODULE-COMPLIANCE"|| Mot [0] == "AGENT-CAPABILITIES")
			continue;	// Instruction vide : on ne redéfinit pas ici les mots de la syntaxe de base

		else if (Mot [0] == "OCTET")
		{
			Mot [1]	= ReadWord (CarSep + ",", ",");
			
			if (Mot [1] == "STRING")
				continue;	// Instruction vide : on ne redéfinit pas ici les mots de la syntaxe de base

			else
			{
				m_MotRendu = Mot [1];
				Items [iItem++] = Mot [0];

				if (iItem >= MAX_IMPORTS)
				{
					Erreur (131, true);
					return false;
				}
			}
		}		// Fin du cas OCTET

		else
		{
			Items [iItem++] = Mot [0];

			if (iItem >= MAX_IMPORTS)
			{
				Erreur (131, true);
				return false;
			}
		}		// Fin du else
	}			// Fin du while TRUE
}		// importedItems


// Boucle générale. Lit et dispatche les définitions d'objets
// Retourne false en cas d'erreur irrécupérable détectée.
//
//	lcName "MODULE-IDENTITY" etc..
//	lcName "OBJECT" "IDENTIFIER"	"::=" <oidValue>
//  lcName "::=" <oidValue>							-- rencontré fréquemment, bien que non normalisé
//	lcName "OBJECT-IDENTITY" etc..
//	lcName "OBJECT-TYPE" etc..
//	lcName "TRAP-TYPE" etc..
//	lcName "NOTIFICATION-TYPE" etc..
//	lcName "OBJECT-GROUP" etc..
//	lcName "NOTIFICATION-GROUP" etc..
//	lcName "MODULE-COMPLIANCE" etc..
//	lcName "AGENT-CAPABILITIES" etc..
//	ucName "::=" <simpleOrEnum> ou <simpleOrEnumOrBit>
//	ucName "::=" "TEXTUAL-CONVENTION" etc..
//	ucName "::=" "SEQUENCE" etc..
//
// JPB Dec 2003
//
bool CMibModule::definitions ()
{
	CMibObj	 *  pObj;		// Pointeur sur l'objet analysé
	CString	CarSep;			// Séparateur de mots
	CarSep	= " \t\r\n";	// Espace, Tab, CR, LF
	bool	Ok;				// Résultat

	CString	objName;		// Nom de l'identifieur
	CString	objType;		// Type de l'objet identifié
	CString s;				// banal
	int		minMaj;			// 1 minuscule, 2 majuscule, 0 autre

	while (true)
	{
		Ok = true;
		minMaj = 0;

		objName = ReadWord (CarSep, "");
		if (objName == "END")
		{
			m_MotRendu = "END";
			return true;
		}

		if (objName.IsEmpty())
			return false;

		if (objName == "SMI")		// Définition de macro dans le compilateur Smic. Ignoré.
		{
			while (true)
			{
				objName = ReadWord ("\r\n", "\r\n");

				if (objName == "\r" || objName == "\n")
					m_Pos++;
				else
					break;
			}

			continue;
		}

		s = objName;
		if (s [0] >= 'a' && s [0] <= 'z')	// 1° lettre en minuscule
			minMaj = 1;
		if (s [0] >= 'A' && s [0] <= 'Z')	// 1° lettre en majuscule
		{
			s.MakeReverse();
			if (s.Find ("yrtnE") == 0)	// se termine par "Entry"
				objName.SetAt (0, objName [0] - 'A' + 'a');	// Transforme la 1° lettre en minuscule
			minMaj = 2;
		}

		objType = ReadWord (CarSep, "");

		if (m_Objs.Lookup (objName, (CObject*&) pObj) <= 0)
		{
			m_pObj	= new CMibObj;
			m_NbObj++;
			m_pObj->m_Name	  = objName;
			m_pObj->m_SNMPName= objName;
			m_pObj->m_LineNbr = m_LigneNum;

			m_Objs.SetAt (m_pObj->m_Name, m_pObj);
			if (Debug2)
			{
				CString strLog;
				strLog.Format(IDS_MDC0263, m_pObj->m_Name); //"Objet créé %s\r\n"
				m_strLogComp += strLog;
				/*
				fprintf (fLog, GetStrItem(IDS_MDC0263), m_pObj->m_Name); //"Objet créé %s\r\n"
				*/
			}
		}

		else if (pObj->m_Type == "VT" || pObj->m_Type == "Entry")
		{
			m_pObj = pObj;
			m_pObj->m_LineNbr = m_LigneNum;
		}

		else
			Erreur (109, false, objName);

		if (objType == "MODULE-IDENTITY")
			Ok = moduleIdentity();

		else if (objType == "OBJECT")
			Ok = objectIdentifier();

		else if (objType == "OBJECT-IDENTITY")
			Ok = objectIdentity();

		else if (objType == "OBJECT-TYPE")
		{
			CString	s;	// banal
			s = objName.Right (5);

			if (s == "Table")
				Ok = objectTypeTable();
			else if (s == "Entry")
				Ok = objectTypeEntry();
			else
				Ok = objectType();
		}

		else if (objType == "TRAP-TYPE")
			Ok = trapType();

		else if (objType == "NOTIFICATION-TYPE")
			Ok = notificationType();

		else if (objType == "OBJECT-GROUP")
			Ok = objectGroup();

		else if (objType == "NOTIFICATION-GROUP")
			Ok = notificationGroup();

		else if (objType == "MODULE-COMPLIANCE")
			Ok = moduleCompliance();

		else if (objType == "AGENT-CAPABILITIES")
			Ok = agentCapabilities();

		else if (objType == "::=" && minMaj == 1)
		{
			m_pObj->m_OID = oidValue();
			Ok = true;
		}

		else if (objType == "::=" && minMaj != 1)
			Ok = QuatrePoints();

		else
			Erreur (103, true, objType);

		objName.Empty();
		objType.Empty();

		if (! Ok)
			return false;
	}	// fin de la boucle ss fin
}		// definitions


// Lit les MODULE_IDENTITY. Renseigne m_Date.
//
//	<moduleIdentity> =							V2 only
//		lcName "MODULE-IDENTITY"
//			"LAST-UPDATED"	<UTCTime>
//			"ORGANIZATION"	chrStr
//			"CONTACT-INFO"	chrStr
//			"DESCRIPTION"	chrStr
//			[<revItem>]...	"::=" <oidValue>
//	<revItem> =
//		"REVISION"		<UTCTime>
//		"DESCRIPTION"	chrStr
//
// JPB Dec 2003
//
bool CMibModule::moduleIdentity()
{
	CString	Mot [DEEPMAX];		// Mot en cours d'analyse
	CString		CarSep;			// Séparateur de mots

	ASSERT (m_pObj != NULL);
	m_pObj->m_Type = "MI";

	if (m_SMI == 1)
		Erreur (110, false);
	m_SMI	= 2;				// Only in V2
	CarSep		= " \t\r\n";	// Espace, Tab, CR, LF

	Mot [0]	= ReadWord (CarSep, "");
	Mot [0].MakeUpper();
	if (Mot [0] == "LAST-UPDATED")
		m_Date = chrStr();
	else
	{
		Erreur (102, true, "LAST-UPDATED");
		return false;
	}

	Mot [0]	= ReadWord (CarSep, "");
	Mot [0].MakeUpper();
	if (Mot [0] == "ORGANIZATION")
		chrStr();
	else
	{
		Erreur (102, true, "ORGANIZATION");
		return false;
	}

	Mot [0]	= ReadWord (CarSep, "");
	Mot [0].MakeUpper();
	if (Mot [0] == "CONTACT-INFO")
		chrStr();
	else
	{
		Erreur (102, true, "CONTACT-INFO");
		return false;
	}

	Mot [0]	= ReadWord (CarSep, "");
	Mot [0].MakeUpper();
	if (Mot [0] == "DESCRIPTION")
		chrStr();
	else
	{
		Erreur (102, true, "DESCRIPTION");
		return false;
	}

	while (true)
	{
		Mot [0]	= ReadWord (CarSep + "{", "{");
		if (Mot [0] == "::=")
		{
			m_pObj->m_OID = oidValue();
			return true;
		}

		Mot [0].MakeUpper();
		if (Mot [0] == "REVISION")
			m_Date = chrStr();
		else
		{
			Erreur (102, true, "REVISION");
			return false;
		}

		Mot [0]	= ReadWord (CarSep, "");
		Mot [0].MakeUpper();
		if (Mot [0] == "DESCRIPTION")
			chrStr();
		else
		{
			Erreur (102, true, "DESCRIPTION");
			return false;
		}
	}	// boucle <revItem>...

	return true;
}		// moduleIdentity


//
//	lcName "OBJECT" "IDENTIFIER" "::=" <oidValue>
//
// JPB Dec 2003
//
bool CMibModule::objectIdentifier ()
{
	CString	Mot [DEEPMAX];		// Mot en cours d'analyse
	CString	CarSep;				// Séparateur de mots
	CarSep		= " \t\r\n";	// Espace, Tab, CR, LF

	ASSERT (m_pObj != NULL);
	m_pObj->m_Type = "ID";

	Mot [0] = ReadWord (CarSep, "");
	Mot [0].MakeUpper();

	if (Mot [0] != "IDENTIFIER")
	{
		Erreur (106, true, Mot [0]);
		return false;
	}

	if (m_pObj->m_SNMPName [0] < 'a' || m_pObj->m_SNMPName [0] > 'z')
		Erreur (132, false, m_pObj->m_SNMPName);

	Mot [0] = ReadWord (CarSep + "{", "{");
	if (Mot [0] != "::=")
	{
		Erreur (106, true, Mot [0]);
		return false;
	}

	m_pObj->m_OID = oidValue();

	return true;
}		// objectIdentifier


//
//	<objectIdentity> =							V2 only
//		lcName "OBJECT-IDENTITY"
//			"STATUS"		<statusV2>
//			"DESCRIPTION"	chrStr
//			["REFERENCE" chrStr]	"::=" <oidValue>
//
// JPB Dec 2003
//
bool CMibModule::objectIdentity ()
{
	CString	Mot [DEEPMAX];	// Mot en cours d'analyse
	CString	CarSep;				// Séparateur de mots
	CarSep		= " \t\r\n";	// Espace, Tab, CR, LF

	ASSERT (m_pObj != NULL);
	m_pObj->m_Type = "ID";

	if (m_SMI == 1)
		Erreur (110, false);
	m_SMI	= 2;				// Only in V2

	Mot [0] = ReadWord (CarSep, "");
	Mot [0].MakeUpper();

	if (Mot [0] == "STATUS")
		m_pObj->m_Status = ReadWord (CarSep, "");
	else
	{
		Erreur (108, true, Mot [0]);
		return false;
	}

	Mot [0] = ReadWord (CarSep, "");
	Mot [0].MakeUpper();

	if (Mot [0] == "DESCRIPTION")
		m_pObj->m_Info = chrStr();
	else
	{
		Erreur (108, true, Mot [0]);
		return false;
	}

	Mot [0] = ReadWord (CarSep + "{", "{");
	Mot [0].MakeUpper();

	if (Mot [0] == "REFERENCE")
	{
		m_pObj->m_Reference = chrStr();

		Mot [0] = ReadWord (CarSep + "{", "{");
		Mot [0].MakeUpper();
	}

	if (Mot [0] == "::=")
		m_pObj->m_OID = oidValue();

	else
	{
		Erreur (108, true, Mot [0]);
		return false;
	}

	return true;
}		// objectIdentity


//
//	Pour les TABLES		(xxxTable)
//	<objectType> =
//		lcName "OBJECT-TYPE"
//			"SYNTAX"	"SEQUENCE" "OF"	<SequenceIdentifier>
//			"ACCESS"	"not-accessible"  ou "MAX-ACCESS" "not-accessible"
//			"STATUS"		<statusV1/V2>
//			["DESCRIPTION"	chrStr]		  obligatoire en V2
//			["REFERENCE" chrStr]	"::=" <oidValue>
//
// JPB Dec 2003
//
bool CMibModule::objectTypeTable ()
{
	CString	Mot [DEEPMAX];		// Mot en cours d'analyse
	CString	CarSep;				// Séparateur de mots
	CarSep		= " \t\r\n";	// Espace, Tab, CR, LF
	CString	seqIdent;			// SequenceIdentifier
	CMibObj * pObj;				// Objet banal

	ASSERT (m_pObj != NULL);

	m_pObj->m_TableName = m_pObj->m_Name;
	m_pObj->m_Type = "TAB";

	Mot [0] = ReadWord (CarSep, "");
	Mot [0].MakeUpper();
	Mot [1] = ReadWord (CarSep, "");
	Mot [1].MakeUpper();
	Mot [2] = ReadWord (CarSep, "");
	Mot [2].MakeUpper();

	if (Mot [0] == "SYNTAX" && Mot [1] == "SEQUENCE" && Mot [2] == "OF")
	{
		seqIdent = ReadWord (CarSep, "");		// SequenceIdentifier

		char c = seqIdent [0];
		if (c >= 'A' && c <= 'Z')
		{
			c = c + 'a' - 'A';	// transforme la 1° lettre en minuscule
			seqIdent.SetAt (0, c);
		}

		if (m_Objs.Lookup (seqIdent, (CObject*&) pObj) <= 0)
		{
			pObj	= new CMibObj;
			m_NbObj++;
			pObj->m_Name	  = seqIdent;
			pObj->m_SNMPName  = seqIdent;
			pObj->m_LineNbr	  = m_LigneNum;
			pObj->m_TableName = m_pObj->m_TableName;
			pObj->m_Type	  = "Entry";

			m_Objs.SetAt (pObj->m_Name, pObj);
			if (Debug2)
			{
				CString strLog;
				strLog.Format(IDS_MDC0263, pObj->m_Name); //"Objet créé %s\r\n"
				m_strLogComp += strLog;
				/*
				fprintf (fLog, GetStrItem(IDS_MDC0263), pObj->m_Name); //"Objet créé %s\r\n"
				*/
			}
		}
	}

//	else if (Mot [0] == "SYNTAX" && Mot [1] == "OPAQUE")
//		m_MotRendu = Mot [2];

	else
	{
		Erreur (135, true, Mot [0] + " / " + Mot [1] + " / " + Mot [2]);
		return false;
	}
	
	Mot [0] = ReadWord (CarSep, "");
	Mot [0].MakeUpper();

	if (Mot [0] == "ACCESS")
	{
		if (m_SMI == 2)
			Erreur (110, false);
		m_SMI	= 1;				// Only in V1
		m_pObj->m_Access = ReadWord (CarSep, "");		// not-accessible
	}

	else if (Mot [0] == "MAX-ACCESS")
	{
		if (m_SMI == 1)
			Erreur (110, false);
		m_SMI	= 2;				// Only in V2
		m_pObj->m_Access = ReadWord (CarSep, "");		// not-accessible
	}

	else
	{
		Erreur (135, true, Mot [0]);
		return false;
	}
	
	Mot [0] = ReadWord (CarSep, "");
	Mot [0].MakeUpper();

	if (Mot [0] == "STATUS")
		m_pObj->m_Status = ReadWord (CarSep, "");		// statusV1/V2
	else
	{
		Erreur (112, true, Mot [0]);
		return false;
	}

	Mot [0] = ReadWord (CarSep + "{", "{");
	Mot [0].MakeUpper();

	if (Mot [0] == "DESCRIPTION")
	{
		m_pObj->m_Info = chrStr();

		Mot [0] = ReadWord (CarSep + "{", "{");
		Mot [0].MakeUpper();
	}

	if (Mot [0] == "REFERENCE")
	{
		m_pObj->m_Reference = chrStr();

		Mot [0] = ReadWord (CarSep + "{", "{");
		Mot [0].MakeUpper();
	}

	if (Mot [0] == "::=")
		m_pObj->m_OID = oidValue();

	else
	{
		Erreur (112, true, Mot [0]);
		return false;
	}

	return true;
}		// objectTypeTable


//
//	Pour les RANGEES	(xxxEntry)
//	<objectType> =
//		lcName "OBJECT-TYPE"
//			"SYNTAX"	<SequenceIdentifier>
//			"ACCESS"	"not-accessible"  ou "MAX-ACCESS" "not-accessible"
//			"STATUS"		<statusV1/V2>
//			["DESCRIPTION"	chrStr]		  obligatoire en V2
//			["REFERENCE" chrStr]
//			"INDEX" "{" <indexItemV1> ["," <indexItemV1>]... "}"  ou <indexOrAugments> en V2
//		"::=" "{" <tableIdentifier> "1" "}"
//
// JPB Dec 2003
//
bool CMibModule::objectTypeEntry ()
{
	CString	Mot [DEEPMAX];		// Mot en cours d'analyse
	CString	CarSep;				// Séparateur de mots
	CarSep		= " \t\r\n";	// Espace, Tab, CR, LF
	CString	s;					// banal
	int		l;					// banal
	CMibObj * pObjTable;		// pointe sur la table
	CMibObj * pObj;				// pointe sur l'objet "Entry"

	ASSERT (m_pObj != NULL);

	s.Empty();
	if (m_Objs.Lookup (m_pObj->m_Name, (CObject*&) pObj) > 0)	// Objet déjà créé
		s = pObj->m_TableName;

	if (s.IsEmpty())
	{
		s = m_pObj->m_Name;
		l = s.GetLength();
		s = s.Left (l - 5);
		s += "Table";
	}

	m_pObj->m_TableName = s;
	m_pObj->m_Type = "Entry";

	Mot [0] = ReadWord (CarSep, "");
	Mot [0].MakeUpper();

	if (Mot [0] == "SYNTAX")
		ReadWord (CarSep, "");		// SequenceIdentifier
	else
	{
		Erreur (112, true, Mot [0]);
		return false;
	}
	
	Mot [0] = ReadWord (CarSep, "");
	Mot [0].MakeUpper();

	if (Mot [0] == "ACCESS")
	{
		if (m_SMI == 2)
			Erreur (110, false);
		m_SMI	= 1;				// Only in V1
		m_pObj->m_Access = ReadWord (CarSep, "");		// not-accessible
	}

	else if (Mot [0] == "MAX-ACCESS")
	{
		if (m_SMI == 1)
			Erreur (110, false);
		m_SMI	= 2;				// Only in V2
		m_pObj->m_Access = ReadWord (CarSep, "");		// not-accessible
	}

	else
	{
		Erreur (112, true, Mot [0]);
		return false;
	}
	
	Mot [0] = ReadWord (CarSep, "");
	Mot [0].MakeUpper();

	if (Mot [0] == "STATUS")
		m_pObj->m_Status = ReadWord (CarSep, "");		// statusV1/V2
	else
	{
		Erreur (112, true, Mot [0]);
		return false;
	}

	Mot [0] = ReadWord (CarSep, "");
	Mot [0].MakeUpper();

	if (Mot [0] == "DESCRIPTION")
	{
		m_pObj->m_Info = chrStr();

		Mot [0] = ReadWord (CarSep, "");
		Mot [0].MakeUpper();
	}

	if (Mot [0] == "REFERENCE")
	{
		m_pObj->m_Reference = chrStr();

		Mot [0] = ReadWord (CarSep, "");
		Mot [0].MakeUpper();
	}

	if (Mot [0] == "INDEX")
	{
		m_pObj->m_Index = indexValue();

		Mot [0] = ReadWord (CarSep + "{", "{");
		m_pObj->m_OID	= oidValue();
	}

	else if (Mot [0] == "AUGMENTS")
	{
		m_pObj->m_Augments = indexValue();

		Mot [0] = ReadWord (CarSep + "{", "{");
		m_pObj->m_OID	= oidValue();
	}

	else
	{
		Erreur (112, true, Mot [0]);
		return false;
	}

	// On initialise les variables "Index" et "Augments" de la table

	if (m_Objs.Lookup (m_pObj->m_TableName, (CObject*&) pObjTable) > 0)
	{
		pObjTable->m_Index	  = m_pObj->m_Index;
		pObjTable->m_Augments = m_pObj->m_Augments;
	}

	return true;
}		// objectTypeEntry


//
//	"INDEX" "{" <indexItemV1> ["," <indexItemV1>]... "}"  ou <indexOrAugments> en V2
//	<indexItemV1> = [ucName"."]lcName | autres valeurs valides mais généralement non supportées
//	<indexOrAugments> = 
//		"INDEX" "{" <indexItemV2> ["," <indexItemV2>]... "}" |
//		"AUGMENTS" "{" <baseRow> "}"
//	<indexItemV2> = ["IMPLIED"][ucName"."]lcName
//	<baseRow>	  = [ucName"."]lcName
//
// JPB Dec 2003
//
CString CMibModule::indexValue ()
{
	CString	Mot [DEEPMAX];		// Mot en cours d'analyse
	CString	s;					// banal
	CString	CarSep;				// Séparateur de mots
	CString	Result;				// Résultat à sortir

	CarSep = " \t\r\n";

	Mot [0]	= ReadWord (CarSep + "{", "{");
	if (Mot [0] != "{")
		return "";

	m_Pos++;		// sauter {

	Result.Empty();
	while (true)
	{
		Mot [0]	= ReadWord ("}, \t", "},");
		if (Mot [0] == "}")
		{
			m_Pos++;		// sauter }
			break;
		}

		else if (Mot [0] == ",")
		{
			m_Pos++;		// sauter ,
			Result += ", ";
		}

		else
			Result += Mot [0];
	}

	return Result;
}		// indexValue


//
//	Pour les VARIABLES SIMPLES ("Scalaires") ou DE TABLE ("Colonnes")
//	<objectType> =
//		lcName "OBJECT-TYPE"
//			"SYNTAX"	<simpleOrEnum>	  ou <simpleOrEnumOrBit> en V2
//			["UNITS" chrStr]	en V2 seulement
//			"ACCESS"	<accessV1>  ou "MAX-ACCESS" <accessV2>
//			"STATUS"		<statusV1/V2>
//			["DESCRIPTION"	chrStr]		  obligatoire en V2
//			["REFERENCE"	chrStr]	
//			["DEFVAL" "{" <defvalV1/V2> "}"]
//			"::=" <oidValue>
//
// JPB Dec 2003
//
bool CMibModule::objectType ()
{
	CString	Mot [DEEPMAX];		// Mot en cours d'analyse
	CString	OldMot;				// Mot, avant transformation en majuscules
	CMibObj * pObj;				// Banal
	CString	CarSep;				// Séparateur de mots
	CarSep		= " \t\r\n";	// Espace, Tab, CR, LF

	ASSERT (m_pObj != NULL);

	if (m_pObj->m_Type.IsEmpty())
		m_pObj->m_Type = "VS";	// VT : variable de table, VS, variable simple

	if (m_pObj->m_Type == "VT")	// Recherche de la table
	{
		if (m_Objs.Lookup (m_pObj->m_TableName, (CObject*&) pObj) <= 0)
		{
			CString s;
			TCHAR   c;

			s = m_pObj->m_SeqName;
			c = s [0];
			if (c >= 'A' && c <= 'Z')
			{
				c = c + 'a' - 'A';	// transforme la 1° lettre en minuscule
				s.SetAt (0, c);
			}

			if (m_Objs.Lookup (s, (CObject*&) pObj)	 &&
				! pObj->m_TableName.IsEmpty())
				m_pObj->m_TableName = pObj->m_TableName;
		}
	}

	Mot [0] = ReadWord (CarSep, "");
	Mot [0].MakeUpper();

	if (Mot [0] == "SYNTAX")
	{
		Mot [0] = ReadWord (CarSep + "({", "");
		simpleOrEnumOrBit (Mot [0]);
	}

	else
	{
		Erreur (112, true, Mot [0]);
		return false;
	}
	
	Mot [0] = ReadWord (CarSep, "");
	Mot [0].MakeUpper();

	if (Mot [0] == "UNITS")
	{
		if (m_SMI == 1)
			Erreur (110, false);
		m_SMI	= 2;				// Only in V2

		m_pObj->m_Unit  = chrStr();

		Mot [0] = ReadWord (CarSep, "");
		Mot [0].MakeUpper();
	}

	if (Mot [0] == "ACCESS")
	{
		if (m_SMI == 2)
			Erreur (110, false);
		m_SMI	= 1;				// Only in V1

		m_pObj->m_Access = ReadWord (CarSep, "");
	}

	else if (Mot [0] == "MAX-ACCESS")
	{
		if (m_SMI == 1)
			Erreur (110, false);
		m_SMI	= 2;				// Only in V2

		m_pObj->m_Access = ReadWord (CarSep, "");
	}

	else
	{
		Erreur (112, true, Mot [0]);
		return false;
	}

	Mot [0] = ReadWord (CarSep, "");
	Mot [0].MakeUpper();

	if (Mot [0] == "STATUS")
		m_pObj->m_Status = ReadWord (CarSep, "");

	else
	{
		Erreur (112, true, Mot [0]);
		return false;
	}

	Mot [0] = ReadWord (CarSep + "{", "{");
	Mot [0].MakeUpper();

	if (Mot [0] == "DESCRIPTION")
	{
		m_pObj->m_Info = chrStr();

		Mot [0] = ReadWord (CarSep + "{", "{");
		Mot [0].MakeUpper();
	}			// Description

	if (Mot [0] == "REFERENCE")
	{
		m_pObj->m_Reference = chrStr();

		Mot [0] = ReadWord (CarSep + "{", "{");
		Mot [0].MakeUpper();
	}			// Référence

	if (Mot [0] == "DEFVAL")
	{
		m_pObj->m_DefVal = defVal();

		Mot [0] = ReadWord (CarSep + "{", "{");
		Mot [0].MakeUpper();
	}			// DefVal

	if (Mot [0] == "::=")
		m_pObj->m_OID = oidValue();

	else
	{
		Erreur (112, true, Mot [0]);
		return false;
	}

	return true;
}		// objectType


//
// JPB Dec 2003
//
bool CMibModule::QuatrePoints ()
{
	CString	Mot [DEEPMAX];		// Mot en cours d'analyse
	CString	CarSep;				// Séparateur de mots
	CString	OldMot;				// Mot, avant passage en majuscules
	bool	Ok;					// Résultat

	CarSep	= " \t\r\n";		// Espace, Tab, CR, LF

	Mot [0]	= ReadWord (CarSep + "{", "");
	OldMot	= Mot [0];
	Mot [0].MakeUpper();

	if (Mot [0] == "TEXTUAL-CONVENTION")
		Ok = textualConvention();

	else if (Mot [0] == "SEQUENCE")
		Ok = sequence();

	else
	{
		ASSERT (m_pObj != NULL);
		m_pObj->m_Type = "TC";	// Textual Convention (ie. définition d'un type)

		Ok = simpleOrEnumOrBit (OldMot);
	}

	return Ok;
}		// QuatrePoints


//
//	<SEQdefinition> =
//		ucName "::=" "SEQUENCE" "{" <seqMember> ["," <seqMember>]... "}"
//	<seqMember>   = lcName <seqDataType>
//	<seqDataType> = <synType> | <tcType> | <seqEnum> | <seqBits>
//
// JPB Dec 2003
//
bool CMibModule::sequence ()
{
	CMibObj	 *  pObj;			// Pointeur sur l'objet analysé
	CString	minName;			// Nom de la séquence, avec la 1° lettre en minuscule
	CMibObj	 *  pMinObj;		// Pointeur sur l'objet renommé
	CString	Mot [DEEPMAX];		// Mot en cours d'analyse
	CString	CarSep;				// Séparateur de mots
	CarSep		= " \t\r\n";	// Espace, Tab, CR, LF
	CString	TableName;			// Nom de la table
	CString	s, t;				// banal
	int		l;					// banal
	TCHAR	c;					// banal

	ASSERT (m_pObj != NULL);	// Pointe sur l'objet "**Entry"

	minName = m_pObj->m_Name;
	c = minName [0];
	if (c >= 'A' && c <= 'Z')
	{
		c = c + 'a' - 'A';	// transforme la 1° lettre en minuscule
		minName.SetAt (0, c);
	}

	t.Empty();
	if (m_Objs.Lookup (minName, (CObject*&) pMinObj))
		if (! pMinObj->m_TableName.IsEmpty())
			t = pMinObj->m_TableName;

	m_pObj->m_Type = "Entry";

	Mot [0] = ReadWord (CarSep + "{", "{");
	if (Mot [0] == "{")
		m_Pos++;		// sauter {
	else
	{
		Erreur (119, true, Mot [0]);
		return false;
	}

	if (! m_pObj->m_TableName.IsEmpty())
		s = m_pObj->m_TableName;
	else if (! t.IsEmpty())
		s = t;
	else
	{
		s = m_pObj->m_Name;
		l = s.GetLength();
		s = s.Left (l - 5);
		s += "Table";
		c = s [0];

		if (c >= 'A' && c <= 'Z')
		{
			c = c + 'a' - 'A';	// transforme la 1° lettre en minuscule
			s.SetAt (0, c);
		}
	}

	TableName = s;

	while (true)
	{
		Mot [0] = ReadWord (CarSep + ",}", ",}");
		if (Mot [0] == ",")
		{
			m_Pos++;	// sauter ,
			continue;
		}

		else if (Mot [0] == "}")
		{
			m_Pos++;	// sauter }
			break;
		}

		if (m_Objs.Lookup (Mot [0], (CObject*&) pObj) <= 0)
		{
			pObj	= new CMibObj;
			m_NbObj++;
			pObj->m_Name	  = Mot [0];
			pObj->m_SNMPName  = Mot [0];
			pObj->m_LineNbr	  = m_LigneNum;
			pObj->m_TableName = TableName;
			pObj->m_SeqName	  = m_pObj->m_SNMPName;
			pObj->m_Type	  = "VT";

			m_Objs.SetAt (pObj->m_Name, pObj);
			if (Debug2)
			{
				CString strLog;
				strLog.Format(IDS_MDC0263, pObj->m_Name); //"Objet créé %s\r\n"
				m_strLogComp += strLog;
				/*
				fprintf (fLog, GetStrItem(IDS_MDC0263), pObj->m_Name); //"Objet créé %s\r\n"
				*/
			}
		}

		else
			Erreur (120, true, Mot [0]);

		s = ReadWord (CarSep + "(,}", "(,}");	// sauter <seqDataType>
		s.MakeUpper();
		if (s == "OBJECT")
			ReadWord (CarSep + ",}", ",}");	// IDENTIFIER

		if (s == "OCTET")
			ReadWord (CarSep + ",}", ",}");	// STRING

		if (s == "INTEGER")
		{
			Mot [1] = ReadWord (CarSep + "(,}", "(,}");
			if (Mot [1] == "(")				// Cas INTEGER ( ...). Ce cas n'est pas NORMAL !!
											// Mais on le traite quand même (pour AHEAD !!)
			{
				m_Pos++;	// sauter (
				rangeSpec();
			}

			else
				m_MotRendu = Mot [1];
		}
	}		// fin boucle sur les seqMembers

	return true;
}		// sequence


//
//	<defValV1/V2> = chrStr | binStr | hexStr | number | "-"number | [ucName "."]lcName |
//					<oidValue>							(V1 only) ou
//					"{" [lcName ["," lcName]...] "}"	(V2 only)
//
// JPB Dec 2003
//
CString CMibModule::defVal ()
{
	CString	Mot [DEEPMAX];		// Mot en cours d'analyse
	CString	OldMot;				// Mot, avant transformation en majuscules
	CString Result;				// Résultat attendu
	CString	CarSep;				// Séparateur de mots

	CarSep		= " \t\r\n";	// Espace, Tab, CR, LF
	Result.Empty();

	Mot [0] = ReadWord (CarSep + "-'{\"", "-'{\"");

	if (Mot [0] == "\"")
		Result = chrStr ();

	else if (Mot [0] == "'")
	{
		int	Nb;
		CarSep += ",()";

		m_Pos++;	// sauter '
		Mot [2] = ReadWord (CarSep + "'", "'");
		Mot [3] = ReadWord (CarSep + "'", "'");
		m_Pos++;	// sauter '

		Mot [4] = ReadWord (CarSep, ")");
		Mot [4].MakeUpper();
		if (Mot [4] == "B")
			Nb = ::btoi (Mot [2]);
		else if (Mot [4] == "H")
			Nb = ::xtoi (Mot [2]);
		else
		{
			Erreur (122, true);
			return "";
		}

		if (Nb < 0)
		{
			Erreur (124, true, Mot [2]);
			return "";
		}

		Result.Format ("%d", Nb);
	}

	else if (Mot [0][0] >= '0' && Mot [0][0] <= '9')
		Result = Mot [0];

	else if (Mot [0] == "-")
	{
		m_Pos++;		// sauter -
		Mot [0] = ReadWord (CarSep, "");
		Result  = "-" + Mot [0];
	}

	else if (Mot [0][0] >= 'A' && Mot [0][0] <= 'Z')
		Result = Mot [0];

	else if (Mot [0][0] >= 'a' && Mot [0][0] <= 'z')
		Result = Mot [0];

	else if (Mot [0] == "{")
	{
		if (m_SMI == 1)
			Result = oidValue();

		else if (m_SMI == 2)
		{
			m_Pos++;		// sauter {

			Result.Empty();
			while (true)
			{
				Mot [0]	= ReadWord ("}, \t", "},");
				if (Mot [0] == "}")
				{
					m_Pos++;		// sauter }
					break;
				}

				else if (Mot [0] == ",")
				{
					m_Pos++;		// sauter ,
					Result += ", ";
				}

				else
					Result += Mot [0];
			}

			if (Mot [0] != "}")
			{
				Erreur (122, true, Mot [0]);
				return "";
			}
		}

		else
		{
			Erreur (123, true);
			return "";
		}
	}

	else
	{
		Erreur (122, true, Mot [0]);
		return "";
	}

	return Result;
}		// defVal


//
//	<simpleEnumOrBit> =
//		<simpleSyntax> |
//		"INTEGER" "{" <enumItem> ["," <enumItem>]... "}" |       limitée à MAX_ENUM
//		"BITS"	  "{" <bitItem>  ["," <bitItem>]... "}"				"			"
//	<simpleSyntax> = <synType> | <tcType>
//	synType : type de la syntaxe de base, avec restriction possible
//	tcType	: convention textuelle, avec restriction possible
//	enumItem: valeur étiquetée
//	bitItem	: bit étiqueté
//
//  synType	: INTEGER, Integer32, INTEGER {  }, Unsigned32, Gauge, Gauge32, Counter, Counter32,
//			  Counter64, TimeTicks, OCTET STRING, OBJECT IDENTIFIER, IpAddress, NetworkAddress,
//			  Opaque, BITS {  }.
//
//	- S'il y a une restriction derrière un tcType, cette restriction figurera dans m_Constraint
//	- S'il n'y a pas de restriction derrière un tcType, et que le tcType est restreint,
//	cette restriction figurera dans m_Constraint
//	- S'il n'y a pas de restriction derrière un tcType, et que le tcType n'est pas restreint,
//	m_Constraint sera vide.
//
//
// JPB Dec 2003
//
// JPB : modif le 10/10/05
//	Accepte "Integer32"  "{" <enumItem> ["," <enumItem>]... "}" |       limitée à MAX_ENUM
//			"Unsigned32" "{" <enumItem> ["," <enumItem>]... "}" |       limitée à MAX_ENUM
//

bool CMibModule::simpleOrEnumOrBit 
(
	CString	 OldMot			// Mot lu 
)
{
	CString	Mot [DEEPMAX];	// Mot en cours d'analyse
	CString	CarSep;			// Séparateur de mots
	CMibObj	* pObj;			// Un objet recherché
	int	iEnum;				// Index d'énumération

	CarSep		= " \t\r\n,()";		// Espace, Tab, CR, LF, (,)

	Mot [0] = OldMot;

	if (Mot [0] == "INTEGER" || Mot [0] == "BITS" || 
		Mot [0] == "Integer32" || Mot [0] == "Unsigned32")
	{
		m_pObj->m_TypeEnum	= "VAL";
		m_pObj->m_TypeSNMP	= Mot [0];

		Mot [0] = ReadWord (CarSep + "{(", "{("); 
		if (Mot [0] == "{")
		{
			m_Pos++;	// sauter {
			iEnum = 0;

			while (true)
			{
				Mot [1] = ReadWord (CarSep + "}", "()}");

				if ((Mot [1][0] >= 'a' && Mot [1][0] <= 'z') ||
					(Mot [1][0] >= 'A' && Mot [1][0] <= 'Z') ||
					(Mot [1][0] >= '0' && Mot [1][0] <= '9'))
					m_pObj->m_NameEn [iEnum] = Mot [1].Left (LONG_ENUM);

				else if (Mot [1] == "(")
				{
					m_Pos++;	// sauter (
					Mot [1] = ReadWord (CarSep + "-'", "-')");

					if (Mot [1] == "-")
					{
						m_Pos++;	// sauter -
						Mot [2] = ReadWord (CarSep, ")");
						m_pObj->m_CodeEn [iEnum] = - atol (Mot [2]);				
					}

					else if (Mot [1] == "'")
					{
						CString s;

						m_Pos++;	// sauter '
						Mot [2] = ReadWord (CarSep + "'", "'");
						Mot [3] = ReadWord (CarSep + "'", "'");
						m_Pos++;	// sauter '

						Mot [4] = ReadWord (CarSep, ")");
						Mot [4].MakeUpper();
						if (Mot [4] == "B")
							m_pObj->m_CodeEn [iEnum] = ::btoi (Mot [2]);
						else if (Mot [4] == "H")
							m_pObj->m_CodeEn [iEnum] = ::xtoi (Mot [2]);
						else
						{
							Erreur (116, true);
							return false;
						}

						if (m_pObj->m_CodeEn [iEnum] < 0)
							Erreur (117, false, Mot [2]);
					}

					else
						m_pObj->m_CodeEn [iEnum] = atol (Mot [1]);				

					// m_pObj->m_iEnum = iEnum;	
					CString Str;
					Str.Format ("%ld", m_pObj->m_CodeEn [iEnum]);
					m_ObjsEnum.SetAt (m_pObj->m_NameEn [iEnum], Str);

					ReadWord (CarSep, ")");
					m_Pos++;	// sauter )

					iEnum++;
					if (iEnum >= MAX_ENUM)
					{
						Erreur (115, true);
						return false;
					}
					else
						m_pObj->m_NbEnum = iEnum;
				}

				else if (Mot [1] == "}")
				{
					m_Pos++;	// sauter }
					break;
				}
			}	// fin du while true
		}		// fin du if {

		else if (Mot [0] == "(")	// Cas INTEGER ( ...) 
		{
			m_Pos++;	// sauter (

			if (! rangeSpec())
				return false;
		}

		else if (Mot [0] == "Integer32" || Mot [0] == "Unsigned32")		
		{
			m_pObj->m_TypeSNMP	= Mot [0];
		
			Mot [1] = ReadWord (CarSep, "(");
			if (Mot [1] == "(")
			{
				m_Pos++;	// sauter (
				if (! rangeSpec())
					return false;
			}

			else
				m_MotRendu = Mot [1];
		}

		else
		{
			m_pObj->m_TypeSNMP	= "INTEGER";
			m_MotRendu = Mot [0];
		}
	}			// fin du cas INTEGER ou BITS

	else if (Mot [0] == "Counter" || Mot [0] == "Counter32" || Mot [0] == "Counter64" ||
			 Mot [0] == "Gauge"   || Mot [0] == "Gauge32"   || 
			 Mot [0] == "IpAddress" || Mot [0] == "NetworkAddress" ||
			 Mot [0] == "Opaque"  || Mot [0] == "TimeTicks")		
									// Syntaxe de base (synType)
	{
		m_pObj->m_TypeSNMP	= Mot [0];
		
		Mot [1] = ReadWord (CarSep, "(");
		if (Mot [1] == "(")
		{
			m_Pos++;	// sauter (
			if (! rangeSpec())
				return false;
		}

		else
			m_MotRendu = Mot [1];
	}

	else if (Mot [0] == "OCTET")	// Syntaxe de base : OCTET STRING (synType)
	{
		Mot [1] = ReadWord (CarSep, "");
		if (Mot [1] != "STRING")
		{
			Erreur (114, true, Mot [1]);
			return false;
		}

		m_pObj->m_TypeSNMP	= "OCTET STRING";

		Mot [1] = ReadWord (CarSep, "(");
		if (Mot [1] == "(")
		{
			m_Pos++;		// sauter (
			ReadWord (CarSep, "");	// "SIZE"
			ReadWord (CarSep, "(");
			m_Pos++;		// sauter (

			if (! rangeSpec())
				return false;

			Mot [1] = ReadWord (CarSep, ")");
			if (Mot [1] == ")")
			{
				m_Pos++;	// sauter )
				m_pObj->m_Constraint = "SIZE (" + m_pObj->m_Constraint + ")";
			}
			else
			{
				Erreur (116, true);
				return false;
			}
		}

		else
			m_MotRendu = Mot [1];
	}

	else if (Mot [0] == "OBJECT")	// Syntaxe de base : OBJECT IDENTIFIER (synType)
	{
		Mot [1] = ReadWord (CarSep, "");
		if (Mot [1] != "IDENTIFIER")
		{
			Erreur (114, true, Mot [1]);
			return false;
		}

		m_pObj->m_TypeSNMP	= "OBJECT IDENTIFIER";
	}

	else							// tcType
	{
		if (m_Objs.Lookup (Mot [0], (CObject*&) pObj) > 0)
		{
			m_pObj->m_TypeSNMP   = pObj->m_TypeSNMP;	// Recopie du type de base
			m_pObj->m_NbEnum     = pObj->m_NbEnum;		// Recopie des énumérés
			m_pObj->m_TypeEnum	 = pObj->m_TypeEnum;

			for (int i=0; i < pObj->m_NbEnum; i++)
			{
				m_pObj->m_CodeEn [i] = pObj->m_CodeEn [i];
				m_pObj->m_NameEn [i] = pObj->m_NameEn [i];
			}

			Mot [1] = ReadWord (CarSep, "(");
			if (Mot [1] == "(")		// Restriction derrière le tcType
			{
				m_Pos++;	// sauter (
				Mot [1] = ReadWord (CarSep, "");	// "SIZE" éventuellement

				if (Mot [1] == "SIZE")
				{
					ReadWord (CarSep, "(");
					m_Pos++;		// sauter (

					if (! rangeSpec())
						return false;

					Mot [1] = ReadWord (CarSep, ")");
					if (Mot [1] == ")")
					{
						m_Pos++;	// sauter )
						m_pObj->m_Constraint = "SIZE (" + m_pObj->m_Constraint + ")";
					}
				
					else
					{
						Erreur (116, true);
						return false;
					}
				}	// tcType de type OCTET STRING

				else
				{
					m_MotRendu = Mot [1];
					if (! rangeSpec())
						return false;
				}	// tcType de type numérique
			}		// restriction derrière le tcType

			else					// Pas de restriction derrière le tcType,
									// on prend celle du tcType lui-même
			{
				m_MotRendu = Mot [1];
				m_pObj->m_Constraint = pObj->m_Constraint;
			}
		}

		else
		{
			Erreur (113, true, Mot [0]);
			return false;
		}
	}

	return true;
}		// simpleOrEnumOrBit


//
//	<TCTdefinition> =		 V2 only
//		ucName "::=" "TEXTUAL-CONVENTION"
//			["DISPLAY-HINT" chrStr]
//			 "STATUS"	<statusV2>
//		 	 "DESCRIPTION"	chrStr
//			["REFERENCE"	chrStr]
//			 "SYNTAX"	<simpleOrEnumOrBit>
//	<statusV2> = "mandatory" | "deprecated" | "obsolete"
//
// JPB Dec 2003
//
bool CMibModule::textualConvention ()
{
	CString	Mot [DEEPMAX];	// Mot en cours d'analyse
	CString	CarSep;				// Séparateur de mots
	CarSep		= " \t\r\n";	// Espace, Tab, CR, LF

	ASSERT (m_pObj != NULL);
	if (m_SMI == 1)
		Erreur (110, false);
	m_SMI	= 2;				// Only in V2

	m_pObj->m_Type = "TC";	// Textual Convention (ie. définition d'un type)

	Mot [0] = ReadWord (CarSep, "");
	Mot [0].MakeUpper();

	if (Mot [0] == "DISPLAY-HINT")
	{
		m_pObj->m_DisplayHint = chrStr();

		Mot [0] = ReadWord (CarSep, "");
		Mot [0].MakeUpper();
	}

	if (Mot [0] == "STATUS")
		m_pObj->m_Status = ReadWord (CarSep, "");

	else
	{
		Erreur (108, true, Mot [0]);
		return false;
	}

	Mot [0] = ReadWord (CarSep, "");
	Mot [0].MakeUpper();

	if (Mot [0] == "DESCRIPTION")
		m_pObj->m_Info = chrStr();
	else
	{
		Erreur (108, true, Mot [0]);
		return false;
	}

	Mot [0] = ReadWord (CarSep, "");
	Mot [0].MakeUpper();

	if (Mot [0] == "REFERENCE")
	{
		m_pObj->m_Reference = chrStr();

		Mot [0] = ReadWord (CarSep, "");
		Mot [0].MakeUpper();
	}

	if (Mot [0] == "SYNTAX")
	{
		Mot [0] = ReadWord (CarSep + "({", "");
		simpleOrEnumOrBit (Mot [0]);
	}

	else
	{
		Erreur (108, true, Mot [0]);
		return false;
	}

	return true;
}		// textualConvention


//
//	<rangeSpec> = "("<rangeItem> ["|"<rangeItem>]... ")"
//	<rangeItem> = "-"number | <intVal> | "-"number ".." "-"number |
//				  "-"number ".." <intVal> | <intVal> ".." <intVal>
//	<intVal>	= number | binStr | hexStr
//	number	: un entier >= 0	(en base 10)
//  binStr	: '00100'b ou '00100'B	 (entre les ', le nombre en base 2)
//  hexStr	: '32AE0'h ou '32AE0'H	 (entre les ', le nombre en base 16)
//
//	Ces spécifications ne sont pas implantées. On retourne seulement le champ entre ().
//
// JPB Dec 2003
//
bool CMibModule::rangeSpec ()
{
	CString	Mot [DEEPMAX];	// Mot en cours d'analyse
	CString	CarSep;			// Séparateur de mots

	Mot [0] = ReadWord (")", "");
	Mot [0].TrimLeft();
	Mot [0].TrimRight();

	m_pObj->m_Constraint = Mot [0];

	Mot [0] = ReadWord  (")", ")");		// ReadWord1
	if (Mot [0] == ")")
	{
		m_Pos++;	// sauter )
		return true;
	}
	
	else
	{
		Erreur (118, true, Mot [0]);
		return false;
	}
}		// rangeSpec


//
//	<TTdefinition> =					V1 only
//		lcName	"TRAP-TYPE"
//				"ENTERPRISE" [ucName "."]lcName
//				["VARIABLES" "{" <varItem> ["," <varItem>]... "}"]
//				["DESCRIPTION"  chrStr]
//				["REFERENCE"	chrStr]	"::=" number
//	<varItem> = [ucName "."]lcName
//
// JPB Dec 2003
//
bool CMibModule::trapType ()
{
	CMibObj	 *  pObj;			// Pointeur sur un objet
	CString	Mot [DEEPMAX];		// Mot en cours d'analyse
	CString	OldMot;				// Mot, avant transformation en majuscules
	CString	CarSep;				// Séparateur de mots
	CString	s;					// Banal
	CarSep		= " \t\r\n";	// Espace, Tab, CR, LF

	ASSERT (m_pObj != NULL);
	m_pObj->m_Type  = "TRAP";

	if (m_SMI == 2)
		Erreur (110, false);
	m_SMI	= 1;				// Only in V1

	Mot [0] = ReadWord (CarSep, "");
	Mot [0].MakeUpper();

	if (Mot [0] == "ENTERPRISE")
	{
		Mot [1] = ReadWord (CarSep, "");
		if (m_Objs.Lookup (Mot [1], (CObject*&) pObj) > 0)
		{
			s = pObj->m_OID;
			s = s.Right (s.GetLength() - 13);
			m_pObj->m_Enterprise = s;
		}
	}

	else
	{
		Erreur (125, true, Mot [1]);
		return false;
	}

	Mot [0] = ReadWord (CarSep, "");
	Mot [0].MakeUpper();

	if (Mot [0] == "VARIABLES")
	{
		int iVar;	// index liste des variables

		m_pObj->m_TypeEnum = "VTRAP";

		Mot [0] = ReadWord (CarSep + "{", "{");
		if (Mot [0] != "{")
		{
			Erreur (126, true, Mot [0]);
			return false;
		}
		
		m_Pos++;			// sauter {
		iVar = 0;

		while (true)
		{
			Mot [0] = ReadWord (CarSep + ",}", ",}");
			if (Mot [0] == ",")
				m_Pos++;	// sauter ,

			else if (Mot [0] == "}")
			{
				m_Pos++;	// sauter }
				m_pObj->m_NbEnum = iVar;
				break;
			}

			else if ((Mot [0][0] >= 'A' && Mot [0][0] <= 'Z') ||
					 (Mot [0][0] >= 'a' && Mot [0][0] <= 'z'))
			{
				m_pObj->m_CodeEn [iVar]	  = iVar;
				m_pObj->m_NameEn [iVar++] = Mot [0].Left (LONG_ENUM);

				if (iVar >= MAX_ENUM)
				{
					Erreur (128, true);
					return false;
				}
			}

			else
			{
				Erreur (126, true, Mot [0]);
				return false;
			}
		}	// fin du while true

		Mot [0] = ReadWord (CarSep, "");
		Mot [0].MakeUpper();
	}		// fin du cas VARIABLES

	if (Mot [0] == "DESCRIPTION")
	{
		m_pObj->m_Info = chrStr();

		Mot [0] = ReadWord (CarSep, "");
		Mot [0].MakeUpper();
	}

	if (Mot [0] == "REFERENCE")
	{
		m_pObj->m_Reference = chrStr();

		Mot [0] = ReadWord (CarSep, "");
		Mot [0].MakeUpper();
	}

	if (Mot [0] == "::=")
		m_pObj->m_TrapNbr = atoi (ReadWord (CarSep, ""));

	else
	{
		Erreur (126, true, Mot [0]);
		return false;
	}

	if (m_pObj->m_TrapNbr < 0)
		m_pObj->m_TrapNbr = 0;

	return true;
}		// trapType


//
//	<NTdefinition> =					V2 only
//		lcName	"NOTIFICATION-TYPE"
//				["OBJECTS" "{" <varItem> ["," <varItem>]... "}"]
//				 "STATUS"	<statusV2>
//				 "DESCRIPTION"  chrStr
//				["REFERENCE"	chrStr]	"::=" <oidValue>
//	<varItem> = [ucName "."]lcName
//
// JPB Dec 2003
//
bool CMibModule::notificationType ()
{
	CString	Mot [DEEPMAX];		// Mot en cours d'analyse
	CString	OldMot;				// Mot, avant transformation en majuscules
	CString	CarSep;				// Séparateur de mots
	CString	s;					// Banal
	CarSep		= " \t\r\n";	// Espace, Tab, CR, LF

	ASSERT (m_pObj != NULL);
	m_pObj->m_Type  = "TRAP2";

	if (m_SMI == 1)
		Erreur (110, false);
	m_SMI	= 2;				// Only in V2

	Mot [0] = ReadWord (CarSep, "");
	OldMot  = Mot [0];
	Mot [0].MakeUpper();

	if (Mot [0] == "OBJECTS")
	{
		int iVar;	// index liste des variables

		m_pObj->m_TypeEnum = "VTRAP";

		Mot [0] = ReadWord (CarSep + "{", "{");
		if (Mot [0] != "{")
		{
			Erreur (126, true, Mot [0]);
			return false;
		}
		
		m_Pos++;			// sauter {
		iVar = 0;

		while (true)
		{
			Mot [0] = ReadWord (CarSep + ",}", ",}");
			if (Mot [0] == ",")
				m_Pos++;	// sauter ,

			else if (Mot [0] == "}")
			{
				m_Pos++;	// sauter }
				m_pObj->m_NbEnum = iVar;
				break;
			}

			else if ((Mot [0][0] >= 'A' && Mot [0][0] <= 'Z') ||
					 (Mot [0][0] >= 'a' && Mot [0][0] <= 'z'))
			{
				m_pObj->m_CodeEn [iVar]	  = iVar;
				m_pObj->m_NameEn [iVar++] = Mot [0].Left (LONG_ENUM);

				if (iVar >= MAX_ENUM)
				{
					Erreur (128, true);
					return false;
				}
			}

			else
			{
				Erreur (126, true, Mot [0]);
				return false;
			}
		}	// fin du while true

		Mot [0] = ReadWord (CarSep, "");
		Mot [0].MakeUpper();
	}				// OBJECTS

	if (Mot [0] == "STATUS")
		m_pObj->m_Status = ReadWord (CarSep, "");
	else
	{
		Erreur (126, true, Mot [0]);
		return false;
	}

	Mot [0] = ReadWord (CarSep, "");
	Mot [0].MakeUpper();

	if (Mot [0] == "DESCRIPTION")
		m_pObj->m_Info = chrStr();
	else
	{
		Erreur (126, true, Mot [0]);
		return false;
	}

	Mot [0] = ReadWord (CarSep + "{", "{");
	Mot [0].MakeUpper();

	if (Mot [0] == "REFERENCE")
	{
		m_pObj->m_Reference = chrStr();

		Mot [0] = ReadWord (CarSep + "{", "{");
		Mot [0].MakeUpper();
	}

	if (Mot [0] == "::=")
	{
		m_pObj->m_OID = oidValue();

		// Le n° de trap est la valeur suivant le dernier point
		s = m_pObj->m_OID;
		s.MakeReverse();
		s = s.SpanExcluding (".");
		s.MakeReverse();
		m_pObj->m_TrapNbr = atoi (s);

		if (m_pObj->m_TrapNbr < 0)
			m_pObj->m_TrapNbr = 0;

		// Le n° IANA suit .1.3.6.1.4.1.
		s = m_pObj->m_OID;
		s = s.Right (s.GetLength() - 13);
		m_pObj->m_Enterprise = s;
	}

	else
	{
		Erreur (126, true, Mot [0]);
		return false;
	}

	return true;
}		// notificationType


//
//	<OGdefinition> =					V2 only
//		lcName	"OBJECT-GROUP"
//				 "OBJECTS" "{" <ogObject> ["," <ogObject>]... "}"
//				 "STATUS"	<statusV2>
//				 "DESCRIPTION"  chrStr
//				["REFERENCE"	chrStr]	"::=" <oidValue>
//	<ogObject> = lcName
//
// JPB Dec 2003
//
bool CMibModule::objectGroup ()
{
	CString	Mot [DEEPMAX];		// Mot en cours d'analyse
	CString	OldMot;				// Mot, avant transformation en majuscules
	CString	CarSep;				// Séparateur de mots
	CarSep		= " \t\r\n";	// Espace, Tab, CR, LF

	ASSERT (m_pObj != NULL);
	m_pObj->m_Type  = "OG";

	if (m_SMI == 1)
		Erreur (110, false);
	m_SMI	= 2;				// Only in V2

	Mot [0] = ReadWord (CarSep, "");
	OldMot  = Mot [0];
	Mot [0].MakeUpper();

	if (Mot [0] == "OBJECTS")
	{
		int iVar;	// index liste des variables

		m_pObj->m_TypeEnum = "VOBJ";

		Mot [0] = ReadWord (CarSep + "{", "{");
		if (Mot [0] != "{")
		{
			Erreur (127, true, Mot [0]);
			return false;
		}
		
		m_Pos++;			// sauter {
		iVar = 0;

		while (true)
		{
			Mot [0] = ReadWord (CarSep + ",}", ",}");
			if (Mot [0] == ",")
				m_Pos++;	// sauter ,

			else if (Mot [0] == "}")
			{
				m_Pos++;	// sauter }
				break;
			}

			else if ((Mot [0][0] >= 'A' && Mot [0][0] <= 'Z') ||
					 (Mot [0][0] >= 'a' && Mot [0][0] <= 'z'))
			{
				m_pObj->m_CodeEn [iVar]	  = iVar;
				m_pObj->m_NameEn [iVar++] = Mot [0].Left (LONG_ENUM);

  				if (iVar >= MAX_ENUM)
				{
					Erreur (128, true);
					return false;
				}
			}

			else
			{
				Erreur (127, true, Mot [0]);
				return false;
			}
		}	// fin du while true
	}				// OBJECTS

	else
	{
		Erreur (127, true, Mot [0]);
		return false;
	}

	Mot [0] = ReadWord (CarSep, "");
	Mot [0].MakeUpper();

	if (Mot [0] == "STATUS")
		m_pObj->m_Status = ReadWord (CarSep, "");
	else
	{
		Erreur (127, true, Mot [0]);
		return false;
	}

	Mot [0] = ReadWord (CarSep, "");
	Mot [0].MakeUpper();

	if (Mot [0] == "DESCRIPTION")
		m_pObj->m_Info = chrStr();
	else
	{
		Erreur (127, true, Mot [0]);
		return false;
	}

	Mot [0] = ReadWord (CarSep + "{", "{");
	Mot [0].MakeUpper();

	if (Mot [0] == "REFERENCE")
	{
		m_pObj->m_Reference = chrStr();

		Mot [0] = ReadWord (CarSep + "{", "{");
		Mot [0].MakeUpper();
	}

	if (Mot [0] == "::=")
		m_pObj->m_OID = oidValue();
	else
	{
		Erreur (127, true, Mot [0]);
		return false;
	}

	return true;
}		// objectGroup


//
//	<NGdefinition> =					V2 only
//		lcName	"NOTIFICATION-GROUP"
//				 "NOTIFICATIONS" "{" <ogObject> ["," <ogObject>]... "}"
//				 "STATUS"	<statusV2>
//				 "DESCRIPTION"  chrStr
//				["REFERENCE"	chrStr]	"::=" <oidValue>
//	<ogObject> = lcName
//
// JPB Dec 2003
//
bool CMibModule::notificationGroup ()
{
	CString	Mot [DEEPMAX];		// Mot en cours d'analyse
	CString	OldMot;				// Mot, avant transformation en majuscules
	CString	CarSep;				// Séparateur de mots
	CarSep		= " \t\r\n";	// Espace, Tab, CR, LF

	ASSERT (m_pObj != NULL);
	m_pObj->m_Type  = "NG";

	if (m_SMI == 1)
		Erreur (110, false);
	m_SMI	= 2;				// Only in V2

	Mot [0] = ReadWord (CarSep, "");
	OldMot  = Mot [0];
	Mot [0].MakeUpper();

	if (Mot [0] == "NOTIFICATIONS")
	{
		int iVar;	// index liste des variables

		m_pObj->m_TypeEnum = "VOBJ";

		Mot [0] = ReadWord (CarSep + "{", "{");
		if (Mot [0] != "{")
		{
			Erreur (127, true, Mot [0]);
			return false;
		}
		
		m_Pos++;			// sauter {
		iVar = 0;

		while (true)
		{
			Mot [0] = ReadWord (CarSep + ",}", ",}");
			if (Mot [0] == ",")
				m_Pos++;	// sauter ,

			else if (Mot [0] == "}")
			{
				m_Pos++;	// sauter }
				break;
			}

			else if ((Mot [0][0] >= 'A' && Mot [0][0] <= 'Z') ||
					 (Mot [0][0] >= 'a' && Mot [0][0] <= 'z'))
			{
				m_pObj->m_CodeEn [iVar]   = iVar;
				m_pObj->m_NameEn [iVar++] = Mot [0].Left (LONG_ENUM);

				if (iVar >= MAX_ENUM)
				{
					Erreur (128, true);
					return false;
				}
			}

			else
			{
				Erreur (127, true, Mot [0]);
				return false;
			}
		}	// fin du while true
	}				// OBJECTS

	else
	{
		Erreur (127, true, Mot [0]);
		return false;
	}

	Mot [0] = ReadWord (CarSep, "");
	Mot [0].MakeUpper();

	if (Mot [0] == "STATUS")
		m_pObj->m_Status = ReadWord (CarSep, "");
	else
	{
		Erreur (127, true, Mot [0]);
		return false;
	}

	Mot [0] = ReadWord (CarSep, "");
	Mot [0].MakeUpper();

	if (Mot [0] == "DESCRIPTION")
		m_pObj->m_Info = chrStr();
	else
	{
		Erreur (127, true, Mot [0]);
		return false;
	}

	Mot [0] = ReadWord (CarSep + "{", "{");
	Mot [0].MakeUpper();

	if (Mot [0] == "REFERENCE")
	{
		m_pObj->m_Reference = chrStr();

		Mot [0] = ReadWord (CarSep + "{", "{");
		Mot [0].MakeUpper();
	}

	if (Mot [0] == "::=")
		m_pObj->m_OID = oidValue();
	else
	{
		Erreur (127, true, Mot [0]);
		return false;
	}

	return true;
}		// notificationGroup


//
//	<MCdefinition> =					V2 only
//		lcName	"MODULE-COMPLIANCE"
//				 "STATUS"	<statusV2>
//				 "DESCRIPTION"  chrStr
//				["REFERENCE"	chrStr]	
//				[<mcModule>]...  "::=" <oidValue>
//	<mcModule> = not implemented here
//
// JPB Dec 2003
//
bool CMibModule::moduleCompliance ()
{
	CString	Mot [DEEPMAX];		// Mot en cours d'analyse
	CString	OldMot;				// Mot, avant transformation en majuscules
	CString	CarSep;				// Séparateur de mots
	CarSep		= " \t\r\n";	// Espace, Tab, CR, LF

	ASSERT (m_pObj != NULL);
	m_pObj->m_Type  = "MC";

	if (m_SMI == 1)
		Erreur (110, false);
	m_SMI	= 2;				// Only in V2

	Mot [0] = ReadWord (CarSep, "");
	Mot [0].MakeUpper();

	if (Mot [0] == "STATUS")
		m_pObj->m_Status = ReadWord (CarSep, "");
	else
	{
		Erreur (127, true, Mot [0]);
		return false;
	}

	Mot [0] = ReadWord (CarSep, "");
	Mot [0].MakeUpper();

	if (Mot [0] == "DESCRIPTION")
		m_pObj->m_Info = chrStr();
	else
	{
		Erreur (127, true, Mot [0]);
		return false;
	}

	Mot [0] = ReadWord (CarSep, "");
	OldMot  = Mot [0];
	Mot [0].MakeUpper();

	if (Mot [0] == "REFERENCE")
		m_pObj->m_Reference = chrStr();

	else
		m_MotRendu = OldMot;

	while (true)						// on élimine mcModule
	{
		Mot [0] = ReadWord (CarSep + "{}\",", "{}\",");
		if (Mot [0] == "{" || Mot [0] == "}" || Mot [0] == "\"" || Mot [0] == ",")
			m_Pos++;	// Sauter  le caractère

		if (Mot [0] == "::=")
			break;
	}

	m_pObj->m_OID = oidValue();

	return true;
}		// moduleCompliance


//
//	<ACdefinition> =					V2 only
//		lcName	"AGENT-CAPABILITIES"
//				 "PRODUCT-RELEASE" chrStr		
//				 "STATUS"	<statusV2>
//				 "DESCRIPTION"  chrStr
//				["REFERENCE"	chrStr]	
//				[<acModule>]...  "::=" <oidValue>
//	<acModule> = not implemented here
//
// JPB Dec 2003
//
bool CMibModule::agentCapabilities ()
{
	CString	Mot [DEEPMAX];		// Mot en cours d'analyse
	CString	OldMot;				// Mot, avant transformation en majuscules
	CString	CarSep;				// Séparateur de mots
	CarSep		= " \t\r\n";	// Espace, Tab, CR, LF

	ASSERT (m_pObj != NULL);
	m_pObj->m_Type  = "AC";

	if (m_SMI == 1)
		Erreur (110, false);
	m_SMI	= 2;				// Only in V2

	Mot [0] = ReadWord (CarSep, "");
	Mot [0].MakeUpper();

	if (Mot [0] == "PRODUCT-RELEASE")
		chrStr();
	else
	{
		Erreur (127, true, Mot [0]);
		return false;
	}

	Mot [0] = ReadWord (CarSep, "");
	Mot [0].MakeUpper();

	if (Mot [0] == "STATUS")
		m_pObj->m_Status = ReadWord (CarSep, "");
	else
	{
		Erreur (127, true, Mot [0]);
		return false;
	}

	Mot [0] = ReadWord (CarSep, "");
	Mot [0].MakeUpper();

	if (Mot [0] == "DESCRIPTION")
		m_pObj->m_Info = chrStr();
	else
	{
		Erreur (127, true, Mot [0]);
		return false;
	}

	Mot [0] = ReadWord (CarSep, "");
	OldMot  = Mot [0];
	Mot [0].MakeUpper();

	if (Mot [0] == "REFERENCE")
		m_pObj->m_Reference = chrStr();
	else
		m_MotRendu = OldMot;

	while (true)						// on élimine mcModule
	{
		Mot [0] = ReadWord (CarSep + "{}\",", "{}\",");

		if (Mot [0] == "{" || Mot [0] == "}" || Mot [0] == "\"" || Mot [0] == ",")
			m_Pos++;	// Sauter  le caractère

		if (Mot [0] == "::=")
			break;
	}

	m_pObj->m_OID = oidValue();

	return true;
}		// agentCapabilities



/////////////////////////////////////////////////////////////////////////////
// CMibObj 
//
/////////////////////////////////////////////////////////////////////////////

IMPLEMENT_DYNCREATE (CMibObj, CItem);

///////////////////////////////////////////////////////////////////////////////
//@mfunc Echange des données entre boîte de dialogue et variables membres
//		 pour une consultation



//////////////////////////////////////////////////////////////////////////////
//
//		Méthodes générales
//
// JPB Jan 2004
//

CMibObj::CMibObj()
{
	//{{AFX_DATA_INIT(CMibObj)
	m_Comment = _T("");
	m_Name = _T("");
	m_Visible = FALSE;
	//}}AFX_DATA_INIT

	m_Access.Empty();
	m_Augments.Empty();
	m_Constraint.Empty();
	m_DefVal.Empty();
	m_DisplayHint.Empty();
	m_Enterprise.Empty();
	m_Index.Empty();
	m_Info.Empty();
	m_LineNbr	= 0;
	m_NbEnum	= 0;
	m_iEnum		= 0;
	m_OID.Empty();
	m_Reference.Empty();
	m_SeqName.Empty();
	m_SNMPName.Empty();
	m_Status.Empty();
	m_TableName.Empty();
	m_TrapNbr	= 0;
	m_Type.Empty();
	m_TypeEnum.Empty();
	m_TypeSNMP.Empty();
	m_Unit.Empty();

	for (int i=0; i<MAX_ENUM; i++)
	{
		m_CodeEn [i] = 0;
		m_NameEn [i].Empty();
	}
}


/////////////////////////////////////////////////////////////////////////////
// CMibObj message handlers

///////////////////////////////////////////////////////////////////////////////
//@mfunc Recherche en BDD des données d'un objet de la MIB 
//
//@rdesc Un pointeur sur le curseur Select. Le curseur étant créé sur le tas,
// Il est de la responsabilité de l'appelant de libérer la mémoire correspondante
// après usage
//
CCursor * CMibObj::SelectOrder ()
{
	CString SelectOrder;    // Ordre SELECT

	SelectOrder = "select #129S#MIBOBJ_NOM, #129S#MIBOBJ_NAME, #11S#MIBOBJ_TYPE, \
						  #i#MIBOBJ_LINENBR, #i#MIBOBJ_VISIBLE, #129S#MIBOBJ_FATHERNAME, \
						  #257S#MIBOBJ_OID, #129S#MIBOBJ_IANA, #i#MIBOBJ_TRAPNBR, \
						  #41S#MIBOBJ_TYPESNMP, #257S#MIBOBJ_CONSTRAINT, #21S#MIBOBJ_UNIT, \
						  #21S#MIBOBJ_ACCESS, #21S#MIBOBJ_STATUS, #257S#MIBOBJ_DEFVAL, \
						  #257S#MIBOBJ_INDEX, #257S#MIBOBJ_AUGMENTS, #2001S#MIBOBJ_INFO, \
						  #2001S#MIBOBJ_REF, #2001S#MIBOBJ_HINTS, #81S#MIBOBJ_COMMENT \
					from MIBOBJ where MIBOBJ_ID = #L#:m_BddId";

	if (m_State == Modification || m_State == Copie)
		SelectOrder += " FOR UPDATE OF mibobj_nom NOWAIT";

	return (new CCursor (&Bdd, SelectOrder, &m_Name, &m_SNMPName, &m_Type,
						 &m_LineNbr, &m_Visible, &m_TableName,
						 &m_OID, &m_Enterprise, &m_TrapNbr,
						 &m_TypeSNMP, &m_Constraint, &m_Unit,
						 &m_Access, &m_Status, &m_DefVal,
						 &m_Index, &m_Augments, &m_Info,
						 &m_Reference, &m_DisplayHint, &m_Comment,
						 &m_BddId));
}			// SelectOrder


///////////////////////////////////////////////////////////////////////////////
//@mfunc Ordre de création des données en BDD pour un module MIB
//		 Voir la fonction Store locale
/*
//
CCursor * CMibObj::CreateOrder ()
{
	return (new CCursor (&Bdd,
						 "insert into MIBOBJ  \
								 (MIBOBJ_ID,  \
								  MIBOBJ_NOM, \
								  MIBOBJ_NAME,\
								  MIBOBJ_COMMENT, \
								  MIBOBJ_VISIBLE  \
								  )\
								  VALUES (SEQ_MIBOBJ.NEXTVAL, \
								  #129S#:m_Name,	\
								  #129S#:m_SNMPName,\
								  #81S#:m_Comment,	\
								  #i#:m_Visible)",
						 &m_Name, &m_SNMPName, &m_Comment, &m_Visible)); 
}			// CreateOrder
*/


///////////////////////////////////////////////////////////////////////////////
//@mfunc Ordre de mise à jour des données en BDD, voir la fonction Store locale.
//
CCursor * CMibObj::UpdateOrder ()
{
	return (new CCursor (&Bdd,
						 "update MIBOBJ \
							set MIBOBJ_NOM		= #129S#:m_Name,	\
								MIBOBJ_NAME		= #129S#:m_SNMPName,\
								MIBOBJ_COMMENT	= #81S#:m_Comment,	\
								MIBOBJ_VISIBLE	= #i#:m_Visible		\
							where MIBOBJ_ID		= #L#:m_BddId",
						 &m_Name, &m_SNMPName, &m_Comment, &m_Visible, &m_BddId));
}			// UpdateOrder



///////////////////////////////////////////////////////////////////////////////
//@mfunc Chargement d'un objet MIB à partir de la Bdd
//
//@rdesc Retourne une des valeurs suivantes :
//	@flag	true  | si succès
//	@flag	false | sinon
//
bool CMibObj::Load ()
{
	int		iEnum;		// index de table
	long	CodeEn;		// Code de l'objet énuméré
	CString	NameEn;		// Nom de l'objet énuméré

	if (! CItem::Load ())		// Chargement de la table MIBOBJ
		return false;

	CCursor CEn (&Bdd, "select #129S#MIBENUM_NAME, #l#MIBENUM_CODE, #11S#MIBENUM_TYPE \
							from MIBENUM where MIBOBJ_ID = #L#:m_BddId",
							&NameEn, &CodeEn, &m_TypeEnum, &m_BddId);

	if (CEn.Exec() != OK)
		return false;

	iEnum = 0;
	while (CEn.Fetch() == OK)
	{
		m_CodeEn [iEnum] = CodeEn;
		m_NameEn [iEnum] = NameEn;
		iEnum++;
	}

	m_NbEnum = iEnum;

	return true;
}		// Load


//@mfunc Renvoie les contraintes concernant l'objet c'est à dire
//la longueur, la valeur min et la valeur max.
//@rdesc Retourne l'une des valeurs suivantes :
//@flag		true	| si succès
//@flag		false	| si une erreur de syntaxe est détectée
//
bool CMibObj::GetConstraints 
(
 long *plMin,		//@parm Valeur min.
 long *plMax,		//@parm Valeur max.
 int *pnLength		//@parm Taille
)
{
	*plMin = LONG_MAX;
	*plMax = LONG_MIN;

	// Si le mot SIZE existe, il n'y a qu'une information de longueur dans la contrainte
	int nPos1, nPos2;
	if (m_Constraint.Find ("SIZE") >= 0)
	{
		nPos1 = m_Constraint.Find ("(");
		nPos2 = m_Constraint.Find (")");

		if (nPos1 < 0 || nPos2 < 0)
			return false;

		GetMinMax (m_Constraint.Mid (nPos1 + 1, nPos2 - nPos1 - 1), plMin, plMax);
		*pnLength = *plMax;
		*plMin = *plMax = 0;
	}
	else
	{
		GetMinMax (m_Constraint, plMin, plMax);
		*pnLength = GetLength (*plMin, *plMax);
	}

	return true;
}


//@mfunc Détermine les valeurs min et max dans une contrainte
void CMibObj::GetMinMax 
(
 CString strConstraint,		//@parm la contrainte ou une partie de celle-ci, la partie
							//provenant du contenu de la contrainte SIZE
 long *plMin,				//@parm la valeur min. à renseigner
 long *plMax				//@parm la valeur max. à renseigner
)
{
	int nPos1 = 0;
	int nPos2;				// Position d'un séparateur de groupe |
	long lMin2, lMax2;
	CString strGroupe;		// Un groupe de valeurs

	while (1)
	{
		nPos2 = strConstraint.Find ("|");
		if (nPos2 >= 0)
		{
			strGroupe = strConstraint.Mid (nPos1, nPos2);
			GetMinMaxOneGroupe (strGroupe, &lMin2, &lMax2);
			*plMin = (lMin2 < *plMin) ? lMin2 : *plMin;
			*plMax = (lMax2 > *plMax) ? lMax2 : *plMax;
			strConstraint = strConstraint.Mid (nPos2 + 1);
		}
		else
		{
			GetMinMaxOneGroupe (strConstraint, &lMin2, &lMax2);
			*plMin = (lMin2 < *plMin) ? lMin2 : *plMin;
			*plMax = (lMax2 > *plMax) ? lMax2 : *plMax;
			break;
		}
	}
}


//@mfunc Détermine les valeurs min et max dans un groupe
//de la forme n..m ou n .. m
void CMibObj::GetMinMaxOneGroupe
(
 CString strGroupe,			//@parm Groupe à examiner
 long *plMin,				//@parm la valeur min. à renseigner
 long *plMax				//@parm la valeur max. à renseigner
)
{
	int nPos1;
	CString strMin, strMax;
	nPos1 = strGroupe.Find ("..");
	if (nPos1 >= 1)
	{
		strMin = strGroupe.Left (nPos1);
		strMin.TrimLeft();
		strMin.TrimRight();
		*plMin = atol (strMin.GetBuffer(0));
		strMax = strGroupe.Mid (nPos1 + 2);
		strMax.TrimLeft();
		strMax.TrimRight();
		*plMax = atol(strMax.GetBuffer(0));
	}
	else
	{
		strGroupe.TrimLeft();
		strGroupe.TrimRight();
		*plMin = *plMax = atol (strGroupe.GetBuffer(0));
	}
}


//@mfunc Renvoie la longueur du nombre en fonction
//du type de l'objet, de son min et de son max
//Renvoie -1 si le type de l'objet n'est pas reconnu
int CMibObj::GetLength (long lMin, long lMax)
{
	CString str;
	int nLen = -1;

	if (m_TypeSNMP == "BITS" || m_TypeSNMP == "OCTET STRING" || m_TypeSNMP == "Opaque")
	{
		str.Format ("%ld" , max (lMin, lMax));
		nLen = str.GetLength();
	}

	else if (m_TypeSNMP == "Counter" || m_TypeSNMP == "Counter32" || 
			 m_TypeSNMP == "Gauge" || m_TypeSNMP == "Gauge32" ||
			 m_TypeSNMP == "TimeTicks" || m_TypeSNMP == "Unsigned32")
		nLen = 10;

	else if (m_TypeSNMP == "Counter64")
		nLen = 20;

	else if (m_TypeSNMP == "INTEGER" || m_TypeSNMP == "Integer32")
		nLen = 11;

	else if (m_TypeSNMP == "IpAddress" || m_TypeSNMP == "NetworkAddress")
		nLen = 15;

	else if (m_TypeSNMP == "OBJECT IDENTIFIER")
		nLen = 255;

	return nLen;
}


//@mfunc Renvoie le code correspondant au nom d'un énuméré
//
//X.L. Création le 06/02/06
bool CMibObj::GetCodeEnumFromName (CString strName, long *pCode)
{
	for (int i = 0; i < m_NbEnum; i++)
	{
		if (m_NameEn [i] == strName)
		{
			*pCode = m_CodeEn [i];
			return true;
		}
	}
	return false;
}



//@cmember Retourne l'énuméré d'un certain index
//
//X.L. Création le 07/02/06
//
bool CMibObj::GetEnum (int nIndex, long *plCode, CString *pstrName)
{
	if (nIndex >= m_NbEnum)
		return false;
	else
	{
		*plCode = m_CodeEn [nIndex];
		*pstrName = m_NameEn [nIndex];
	}
	return true;
}
