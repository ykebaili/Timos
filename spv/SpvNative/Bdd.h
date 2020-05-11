//@doc Base de donn�es
//
// Project  : SPV
//
// Auteur	: X. Leconte
// Date		: 04/05/98 -- Cr�ation
// 30/06/00 : JP Borg	:	Ajout de CBddException
// Release	: 1.0
//
//@module Bdd | 
// Ce module permet la connexion � la Base de Donn�es Oracle
// gr�ce � l'objet <c CBdd>.

#if !defined(AFX_BDD_H__747F2F61_DFF5_11D1_BCD0_0080C8521D73__INCLUDED_)
#define AFX_BDD_H__747F2F61_DFF5_11D1_BCD0_0080C8521D73__INCLUDED_

#if _MSC_VER >= 1000
#pragma once
#endif // _MSC_VER >= 1000

// include demand�s par l'OCI ORACLE
extern "C" {
#include	<ocidfn.h>
#include	<ociapr.h>
}


#include <afx.h>


// D�finitions en rapport avec l'OCI ORACLE
#define	HDA_SIZE			512		// Taille par d�faut de la hda de l'OCI
#define ORAMESS_SIZE		512		// Taille max. d'un message ORACLE
#define PARSE_NO_DEFER		  0		// parsing ordre SQL non diff�r�
#define PARSE_DEFER			  1		// parsing ordre SQL diff�r�
#define VERSION_7			  2		// SQL suivant ORACLE V7
#define MAX_SQL_IDENT		 31		// nombre max. de car. pour un identifiant SQL
#define VARCHAR2_TYPE		  1		// indique � ORACLE une variable du type VARCHAR2
#define STRING_TYPE			  5		// indique � ORACLE une variable du type null terminated string
#define SIGNINT_TYPE		  3		// indique � ORACLE une variable du type int sign�

const	unsigned int ARRAY_SIZE = 20;	// Taille par d�faut des tableaux pour select en bdd


///////////////////////////////////////////////////////////////////////////////
// @class Cette classe d�finit les exceptions cons�cutives � un
// probl�me li� � la BDD.

class CBddException 
{
public:
	CBddException (CString& ErrMess)
		: m_ErrMess(ErrMess) {};
	
	CString m_ErrMess;
};


// Base de donn�es Oracle atteinte par l'interface OCI
//@class Base de donn�es <c CBdd>
//@base public | CObject
class CBdd 
{

//@access Variables membres publiques
public:
	//@cmember Structure de communication avec la BDD
	Lda_Def lda;
	//@cmember Autre structure de communication avec la BDD
	ub1 hda [HDA_SIZE];

	//@cmember Fetch en cours : ne pas arr�ter la BDD (JPB 21/02/05)
	bool m_bFetch;

	//@cmember Identificateur de la session que l'on vient 
	// d'ouvrir. C'est le resultat de la requ�te SQL :
	// select userenv('sessionid') from dual. m_SessionId
	// est positionn� dans <mf CBdd::Open>.
	long m_SessionId;

//@access Variables membres priv�es
private:
	//@cmember Indicateur de connexion �tablie
	bool	bConnecte;
	//@cmember Cha�ne de connexion
	CString	m_Connexion;
	//@cmember Index du dernier SavePoint pos�
	unsigned long m_SavePointIdx;
	//@cmember Taille par d�faut des tableaux de recherche en bdd
	unsigned int  m_ArraySize;

public:
//@access Construction, destruction
	//@cmember Construction d'un <c CBdd>
	CBdd();
	//@cmember Destruction d'un <c CBdd>
	virtual ~CBdd();

	friend class CCursor;

//@access Fonctions membres publiques
	//@cmember Commit des op�rations faites en Bdd
	bool Commit();
	//@cmember Rollback des op�rations faites en Bdd
	bool RollBack ();
	//@cmember Pose un SavePoint
	bool PutSavePt ();
	//@cmember D�cr�mente l'index des savepoints
	void DecSavePt ();
	//@cmember RollBack jusqu'au dernier SavePoint pos�
	bool RollBackToLastSavePt ();
	//@cmember Pose un SavePoint dont le nom est pass� en argument
	bool PutSavePt (CString PointName);
	//@cmember RollBack jusqu'au SavePoint dont le nom est pass� en argument
	bool RollBackToLastSavePt (CString PointName);
	//@cmember Indique si erreur en LDA
	bool IsErreurBdd();
	//@cmember Etablissement de la connexion
	bool Open (CString Connect, unsigned int ArraySize = 0);
	//@cmember Indique si la connexion BDD est �tablie
	bool IsOpen ();
	//@cmember Fermeture de la connexion
	bool Close ();
	//@cmember Affiche l'erreur Oracle suite � une commande BDD
	// Celle-ci se trouve soit dans lda soit dans cda
	// on passe ce qui convient � la fonction
	void AffErreur (Cda_Def *Cda);
	//@cmember Retourne la valeur de la taille par d�faut des tableaux de recherche en bdd
	UINT GetArraySize () {return m_ArraySize;};
	//@cmember Retourne l'intitul� de l'erreur courante
	CString CBdd::GetOraMess ();
	//@cmember Retourne la cha�ne de connexion base de donn�es.
	CString GetConnexion () {return m_Connexion;};

	//@cmember Donne la valeur courante de la s�quence associ�e � une table
	bool CurValSeq (char* lpszSeqName, long &lCurId);
	//@cmember Donne la prochaine valeur de la s�quence associ�e � une table
	bool NextValSeq (char* lpszSeqName, long &lCurId);
};


#endif // !defined(AFX_BDD_H__747F2F61_DFF5_11D1_BCD0_0080C8521D73__INCLUDED_)
