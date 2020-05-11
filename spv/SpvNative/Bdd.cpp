//@doc Base de données
//
// Project  : SPV
//
// Auteur	: X. Leconte
// Date		: 04/05/98 -- Création
// Release	: 1.0
 

#include "stdafx.h"

#include "Bdd.h"
#include "Cursor.h"
//#include <afxwin.h>

#ifdef _DEBUG
#undef THIS_FILE
static char THIS_FILE[]=__FILE__;
#define new DEBUG_NEW
#endif

#define OCI_VERBOSE

//extern CSpvApp theApp;

///////////////////////////////////////////////////////////////////////////////
//@mfunc Constructeur d'un objet Base de données <c CBdd>
//
// Retour néant
//
// Auteur X.L.
// Date : 04/05/98 -- Création
// Release : 1.0
CBdd::CBdd()
{
	// impératif pour que la connexion ORACLE fonctionne
	// correctement, mettre à 0 la hda.
	memset (hda, 0, sizeof (hda));

	m_bFetch = false;

	m_SavePointIdx = 0;
	bConnecte = FALSE;             // pas de cnx à la base
	opinit (OCI_EV_TSF);           // init. en mode multi-thread
}


///////////////////////////////////////////////////////////////////////////////
//@mfunc Destructeur d'un objet Base de données <c CBdd>
//
// Retour néant
//
// Auteur X.L.
// Date : 04/05/98 -- Création
// Release : 1.0
CBdd::~CBdd()
{
	if (bConnecte)
	{
		// OutputDebugString ("Fermeture BDD dans le destructeur CBdd\n");
		Close();
		if (ologof (&lda))
			AffErreur (NULL);
	}
}


///////////////////////////////////////////////////////////////////////////////
//@mfunc Indique si la connexion à la Bdd est réalisée
//
//@rdesc Retourne les valeurs suivantes :
//	@flag true  | si la connexion est effective
//	@flag flase | si la connexion n'est pas réalisée
//
// Auteur X.L.
// Date : 04/05/98 -- Création
// Release : 1.0
bool CBdd::IsOpen ()
{
	return (bConnecte);
}

///////////////////////////////////////////////////////////////////////////////
//@mfunc Ouvre la connexion avec la Bdd
//
//@rdesc Retourne les valeurs suivantes
//	@flag true  | si l'ouverture est effective
//	@flag false | si un problème a empêché l'ouverture
//
// Auteur X.L.
// Date : 04/05/98 -- Création
// Release : 1.0
bool CBdd::Open
(
	CString Connect,		//@parm String de connexion à la Bdd
	unsigned int ArraySize	//@parm Taille du tableau d'échange pour les 
							// curseurs
)
{
	// Connect: Contient la chaîne de connexion
	// complète de connexion: nom du user, mot de passe,
	// éventuellement nom de la BDD

	// nettoyage de la structure d'échange avec ORACLE et
	// RAZ indicateur
	memset (hda, 0, sizeof (hda));

	bConnecte = FALSE;
	m_Connexion = Connect;

	if (ArraySize > 0)
		m_ArraySize = ArraySize;
	else
		m_ArraySize = ARRAY_SIZE;

	// Tentative de connexion par l'OCI ORACLE
	if (olog (&lda, hda, (text *) (LPCTSTR) Connect, 
		(sword) -1, (text *) 0, (sword) -1, (text*) 0, 
		 (sword) -1, (ub4) OCI_LM_DEF))
		return bConnecte;

	bConnecte = TRUE;

	// Mise à jour de la variable membre m_SessionId
	CCursor GetSessionId (this, 
		"select #l#userenv('sessionid') from dual",	&m_SessionId);

	if (GetSessionId.Exec () != OK || GetSessionId.Fetch () != OK)
		bConnecte = FALSE;	// m_SessionId ne peut être positionné, la connection échoue
	else
		bConnecte = TRUE;
	
	return bConnecte;
}		// Open


///////////////////////////////////////////////////////////////////////////////
//@mfunc Ferme la connexion avec la Bdd
//
//@rdesc Retourne les valeurs suivantes :
//	@flag true  | si la fermeture s'est bien passée
//	@flag flase | si la fermeture a échoué
//
// Auteur X.L.
// Date : 04/05/98 -- Création
// Release : 1.0
bool CBdd::Close ()
{
	bool ret = TRUE;

	if (! bConnecte)
		return (ret);

	while (m_bFetch)	// JPB le 21/02/05 : pour éviter le plantage si arrêt dans la boucle
		Sleep (10);

	if (this -> IsOpen ())
		if (ologof (&lda))
			ret = FALSE;
	memset (hda, 0, sizeof (hda));
	bConnecte = FALSE;
	return (ret);
}


///////////////////////////////////////////////////////////////////////////////
//@mfunc Retourne une chaîne de caractères expliquant l'erreur Oracle
//
// 
CString CBdd::GetOraMess ()
{
	CString OraMess;

	if (oerhms(&lda, lda.rc, 
			(text *) OraMess.GetBufferSetLength (ORAMESS_SIZE),
			(sword) ORAMESS_SIZE))
	{
		OraMess = "\0";
	}

	OraMess.ReleaseBuffer ();

	return OraMess;
}	// GetOraMess


///////////////////////////////////////////////////////////////////////////////
//@mfunc Affiche l'erreur dans la liaison OCI avec la base ORACLE
//
// Retour néant
//
// Auteur X.L.
// Date : 04/05/98 -- Création
// Release : 1.0
//
void CBdd::AffErreur
(
	Cda_Def *Cda	//@parm Structure contenant l'erreur.
)					// si *Cda est NULL ceci signifie que la source de l'erreur 
					// peut être prise dans la lda de la bdd

{
	sword	n;					// nb de caractères du message
	char	msg [ORAMESS_SIZE]; // buffer pour récupérer le message 

	if (Cda == NULL)
		n = oerhms(&lda, lda.rc, (text *) msg, (sword) sizeof (msg));
	else
		n = oerhms(Cda, Cda -> rc, (text *) msg, (sword) sizeof (msg));
	AfxMessageBox (msg, MB_ICONSTOP | MB_OK);
}


///////////////////////////////////////////////////////////////////////////////
//@mfunc Indique si une erreur s'est produite lors de la dernière opération en Bdd
//		 L'erreur en question est relevée dans la LDA non dans un
//		 CDA (structure pour curseur) ouvert éventuellement après la
//		 BDD.
//
//@rdesc Retourne les valeurs suivantes :
//	@flag true  | en cas d'erreur présente
//	@flag false | en cas d'absence d'erreur
//
// Auteur X.L.
// Date : 04/05/98 -- Création
// Release : 1.0
bool CBdd::IsErreurBdd()
{
	if (lda.rc)
		return (TRUE);
	return (FALSE);
}


///////////////////////////////////////////////////////////////////////////////
//@mfunc Commite les opérations réalisées en Bdd
//
//@rdesc Retourne les valeurs suivantes :
//	@flag true  | si le commit s'est bien passé
//	@flag flase | si le commit a échoué
//
// Auteur X.L.
// Date : 04/05/98 -- Création
// Release : 1.0
bool CBdd::Commit()
{
	if (ocom (&lda))
	{
		#ifdef OCI_VERBOSE	
		CString OutputString ;
		OutputString.Format ("OCI : Commit failed on %lu \n", m_SessionId);
		OutputDebugString (OutputString);
		#endif //OCI_VERBOSE

		return (FALSE);
	}

	#ifdef OCI_VERBOSE	
	CString OutputString ;
	OutputString.Format ("OCI : Commit succed on %lu \n", m_SessionId);
	OutputDebugString (OutputString);
	#endif //OCI_VERBOSE

	m_SavePointIdx = 0;
	return (TRUE);
}


///////////////////////////////////////////////////////////////////////////////
//@mfunc Rollback les opérations en Bdd
//
//@rdesc Retourne les valeurs suivantes :
//	@flag true  | si le rollback a réussi
//	@flag false | si le rollback a échoué
//
// Auteur X.L.
// Date : 04/05/98 -- Création
// Release : 1.0
bool CBdd::RollBack()
{
	if (orol (&lda))
	{
		#ifdef OCI_VERBOSE
		CString OutputString ;
		OutputString.Format ("OCI : Rollback failed on %lu \n", m_SessionId);
		OutputDebugString (OutputString);
		#endif //OCI_VERBOSE

		return (FALSE);
	}

	#ifdef OCI_VERBOSE
	CString OutputString ;
	OutputString.Format ("OCI : Rollback succed on %lu \n", m_SessionId);
	OutputDebugString (OutputString);
	#endif //OCI_VERBOSE

	m_SavePointIdx = 0;
	return (TRUE);
}


///////////////////////////////////////////////////////////////////////////////
//@mfunc Pose un SavePoint dans la session ouverte par l'objet Bdd.
// l'identificateur du SavePoint est formé de la chaîne "point" 
// à laquelle est comcaténée l'index du SavePoint <md CBdd::m_SavePtIdx>.
//@rdesc Retourne les valeurs suivantes :
//	@flag true  | si la pose du SavePoint a réussi
//	@flag false | si la pose du SavePoint a échoué
//
// Auteur T.A.
// Date : 29/10/98 -- Création
// Release : 1.0

bool CBdd::PutSavePt ()
{
	m_SavePointIdx++;
		
	CString SQLString;	
	SQLString.Format("SAVEPOINT point%lu", m_SavePointIdx);
	
	CCursor PutSavePoint (this, SQLString);
	
	if (PutSavePoint.Exec())
	{
		#ifdef OCI_VERBOSE
		CString OutputString ;
		OutputString.Format ("OCI : %s succed on %lu \n", SQLString, m_SessionId);
		OutputDebugString (OutputString);
		#endif //OCI_VERBOSE
		return true;
	}
	else
	{
		#ifdef OCI_VERBOSE
		CString OutputString ;
		OutputString.Format ("OCI : %s failed on %lu \n", SQLString, m_SessionId);
		OutputDebugString (OutputString);
		#endif //OCI_VERBOSE

		return false;
	}
}


//@mfunc Décrémente l'index des savepoints
//
// Est exploité dans les mises à jour imbriquées lorsqu'on utilise la fonction
// Store de différents objets successivement et que pour chacun un savepoint
// a été posé. Quand cela se passe mal, il y a appel de RollBackToLastSavePt(),
// quand cela se passe bien il y a DecSavePt ().
//
// X.L. création le 04/06/04
void CBdd::DecSavePt ()
{
	if (m_SavePointIdx > 0)
		m_SavePointIdx--;
}


///////////////////////////////////////////////////////////////////////////////
//@mfunc RollBack jusqu'au dernier SavePoint posé
//@rdesc Retourne les valeurs suivantes :
//	@flag true  | si le rollback a réussi
//	@flag false | si le rollBack a échoué
//
// Auteur T.A.
// Date : 29/10/98 -- Création
// Release : 1.0

bool CBdd::RollBackToLastSavePt ()
{
	if (m_SavePointIdx <= 1)
		return RollBack ();
		
	CString SQLString;
	SQLString.Format("ROLLBACK TO SAVEPOINT point%lu", m_SavePointIdx);

	CCursor RollBack (this, SQLString);
	if (!RollBack.Exec())
	{
		#ifdef OCI_VERBOSE
		CString OutputString ;
		OutputString.Format ("OCI : %s failed on %lu \n", SQLString, m_SessionId);
		OutputDebugString (OutputString);
		#endif //OCI_VERBOSE

		return false;
	}	

	#ifdef OCI_VERBOSE
	CString OutputString ;
	OutputString.Format ("OCI : %s succed on %lu \n", SQLString, m_SessionId);
	OutputDebugString (OutputString);
	#endif //OCI_VERBOSE
	
	m_SavePointIdx--;	
	return true;
}


///////////////////////////////////////////////////////////////////////////////
//@mfunc Pose un SavePoint dans la session ouverte par l'objet Bdd.
// l'identificateur du SavePoint est la chaîne <p PointName>.
//@rdesc Retourne les valeurs suivantes :
//	@flag true  | si la pose du SavePoint a réussi
//	@flag false | si la pose du SavePoint a échoué
//
// Auteur T.A.
// Date : 29/10/98 -- Création
// Release : 1.0

bool CBdd::PutSavePt (CString PointName)
{
	CString SQLString;	
	SQLString.Format("SAVEPOINT %s", PointName);

	CCursor PutSavePoint (this, SQLString);
	
	if (PutSavePoint.Exec())
	{
		#ifdef OCI_VERBOSE
		CString OutputString ;
		OutputString.Format ("OCI : %s succed on %lu \n", SQLString, m_SessionId);
		OutputDebugString (OutputString);
		#endif //OCI_VERBOSE

		return true;
	}
	else
	{
		#ifdef OCI_VERBOSE
		CString OutputString ;
		OutputString.Format ("OCI : %s failed on %lu \n", SQLString, m_SessionId);
		OutputDebugString (OutputString);
		#endif //OCI_VERBOSE

		return false;
	}
}


///////////////////////////////////////////////////////////////////////////////
//@mfunc RollBack jusqu'au SavePoint désigné par la chaîne <p PointName>.
//@rdesc Retourne les valeurs suivantes :
//	@flag true  | si le rollback a réussi
//	@flag false | si le rollBack a échoué
//
// Auteur T.A.
// Date : 29/10/98 -- Création
// Release : 1.0

bool CBdd::RollBackToLastSavePt (CString PointName)
{
	CString SQLString;
	SQLString.Format("ROLLBACK TO SAVEPOINT %s", PointName);

	CCursor RollBack (this, SQLString);

	if (!RollBack.Exec())
	{
		#ifdef OCI_VERBOSE
		CString OutputString ;
		OutputString.Format ("OCI : %s failed on %lu \n", SQLString, m_SessionId);
		OutputDebugString (OutputString);
		#endif //OCI_VERBOSE

		return false;
	}

	#ifdef OCI_VERBOSE
	CString OutputString ;
	OutputString.Format ("OCI : %s succed on %lu \n", SQLString, m_SessionId);
	OutputDebugString (OutputString);
	#endif //OCI_VERBOSE

	return true;
}


//////////////////////////////////////////////////////////////////////
// CurValSeq
//
// Détermine la valeur courante d'une séquence
//
// Retourne true si réussi, false sinon. Met à jour le paramètre lCurId avec
// la valeur renvoyée par la Bdd.
// 
// Auteur : X.L.
// Date : 27/07/98
// Release : 1.0
// 
// Modif. X.L. le 07/07/99 pour travailler sur la session par défaut ou une autre
//
bool CBdd::CurValSeq (char* lpszSeqName, long &lCurId)
{
	bool bRet = false;
	CString SelectOrder;

	SelectOrder = "SELECT #l#seq_";
	SelectOrder += lpszSeqName;
	SelectOrder += ".CURRVAL from dual";
	CCursor CurId (this, SelectOrder, &lCurId);
	if (CurId.Exec ())
		if (CurId.Fetch () == OK)
			bRet = true;

	return (bRet);
}


//////////////////////////////////////////////////////////////////////
// NextValSeq
//
// incrémente une séquence et retourne sa nouvelle valeur
//
// Retourne true si réussi, false sinon. Met à jour le paramètre lCurId avec
// la valeur renvoyée par la Bdd.
// 
// Auteur : A.T.
// Date : 06/11/98
// Release : 1.0
// 
bool CBdd::NextValSeq (char* lpszSeqName, long &lCurId)
{
	bool bRet = false;
	CString SelectOrder;

	SelectOrder = "SELECT #l#seq_";
	SelectOrder += lpszSeqName;
	SelectOrder += ".NEXTVAL from dual";
	CCursor CurId (this, SelectOrder, &lCurId);
	if (CurId.Exec ())
		if (CurId.Fetch () == OK)
			bRet = true;

	return (bRet);
}
