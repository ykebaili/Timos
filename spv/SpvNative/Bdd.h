//@doc Base de données
//
// Project  : SPV
//
// Auteur	: X. Leconte
// Date		: 04/05/98 -- Création
// 30/06/00 : JP Borg	:	Ajout de CBddException
// Release	: 1.0
//
//@module Bdd | 
// Ce module permet la connexion à la Base de Données Oracle
// grâce à l'objet <c CBdd>.

#if !defined(AFX_BDD_H__747F2F61_DFF5_11D1_BCD0_0080C8521D73__INCLUDED_)
#define AFX_BDD_H__747F2F61_DFF5_11D1_BCD0_0080C8521D73__INCLUDED_

#if _MSC_VER >= 1000
#pragma once
#endif // _MSC_VER >= 1000

// include demandés par l'OCI ORACLE
extern "C" {
#include	<ocidfn.h>
#include	<ociapr.h>
}


#include <afx.h>


// Définitions en rapport avec l'OCI ORACLE
#define	HDA_SIZE			512		// Taille par défaut de la hda de l'OCI
#define ORAMESS_SIZE		512		// Taille max. d'un message ORACLE
#define PARSE_NO_DEFER		  0		// parsing ordre SQL non différé
#define PARSE_DEFER			  1		// parsing ordre SQL différé
#define VERSION_7			  2		// SQL suivant ORACLE V7
#define MAX_SQL_IDENT		 31		// nombre max. de car. pour un identifiant SQL
#define VARCHAR2_TYPE		  1		// indique à ORACLE une variable du type VARCHAR2
#define STRING_TYPE			  5		// indique à ORACLE une variable du type null terminated string
#define SIGNINT_TYPE		  3		// indique à ORACLE une variable du type int signé

const	unsigned int ARRAY_SIZE = 20;	// Taille par défaut des tableaux pour select en bdd


///////////////////////////////////////////////////////////////////////////////
// @class Cette classe définit les exceptions consécutives à un
// problème lié à la BDD.

class CBddException 
{
public:
	CBddException (CString& ErrMess)
		: m_ErrMess(ErrMess) {};
	
	CString m_ErrMess;
};


// Base de données Oracle atteinte par l'interface OCI
//@class Base de données <c CBdd>
//@base public | CObject
class CBdd 
{

//@access Variables membres publiques
public:
	//@cmember Structure de communication avec la BDD
	Lda_Def lda;
	//@cmember Autre structure de communication avec la BDD
	ub1 hda [HDA_SIZE];

	//@cmember Fetch en cours : ne pas arrêter la BDD (JPB 21/02/05)
	bool m_bFetch;

	//@cmember Identificateur de la session que l'on vient 
	// d'ouvrir. C'est le resultat de la requête SQL :
	// select userenv('sessionid') from dual. m_SessionId
	// est positionné dans <mf CBdd::Open>.
	long m_SessionId;

//@access Variables membres privées
private:
	//@cmember Indicateur de connexion établie
	bool	bConnecte;
	//@cmember Chaîne de connexion
	CString	m_Connexion;
	//@cmember Index du dernier SavePoint posé
	unsigned long m_SavePointIdx;
	//@cmember Taille par défaut des tableaux de recherche en bdd
	unsigned int  m_ArraySize;

public:
//@access Construction, destruction
	//@cmember Construction d'un <c CBdd>
	CBdd();
	//@cmember Destruction d'un <c CBdd>
	virtual ~CBdd();

	friend class CCursor;

//@access Fonctions membres publiques
	//@cmember Commit des opérations faites en Bdd
	bool Commit();
	//@cmember Rollback des opérations faites en Bdd
	bool RollBack ();
	//@cmember Pose un SavePoint
	bool PutSavePt ();
	//@cmember Décrémente l'index des savepoints
	void DecSavePt ();
	//@cmember RollBack jusqu'au dernier SavePoint posé
	bool RollBackToLastSavePt ();
	//@cmember Pose un SavePoint dont le nom est passé en argument
	bool PutSavePt (CString PointName);
	//@cmember RollBack jusqu'au SavePoint dont le nom est passé en argument
	bool RollBackToLastSavePt (CString PointName);
	//@cmember Indique si erreur en LDA
	bool IsErreurBdd();
	//@cmember Etablissement de la connexion
	bool Open (CString Connect, unsigned int ArraySize = 0);
	//@cmember Indique si la connexion BDD est établie
	bool IsOpen ();
	//@cmember Fermeture de la connexion
	bool Close ();
	//@cmember Affiche l'erreur Oracle suite à une commande BDD
	// Celle-ci se trouve soit dans lda soit dans cda
	// on passe ce qui convient à la fonction
	void AffErreur (Cda_Def *Cda);
	//@cmember Retourne la valeur de la taille par défaut des tableaux de recherche en bdd
	UINT GetArraySize () {return m_ArraySize;};
	//@cmember Retourne l'intitulé de l'erreur courante
	CString CBdd::GetOraMess ();
	//@cmember Retourne la chaîne de connexion base de données.
	CString GetConnexion () {return m_Connexion;};

	//@cmember Donne la valeur courante de la séquence associée à une table
	bool CurValSeq (char* lpszSeqName, long &lCurId);
	//@cmember Donne la prochaine valeur de la séquence associée à une table
	bool NextValSeq (char* lpszSeqName, long &lCurId);
};


#endif // !defined(AFX_BDD_H__747F2F61_DFF5_11D1_BCD0_0080C8521D73__INCLUDED_)
