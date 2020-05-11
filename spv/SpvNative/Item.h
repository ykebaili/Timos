#pragma once

// CItem command target

#include "Cursor.h"

class AFX_EXT_CLASS CItem : public CObject
{
public:
	CItem();
	virtual ~CItem();

	//@cmember Met � jour les donn�es membres du CItem.
	virtual void SetInfo (long BddId, char *lpszName, long ClassId);

	//@cmember Charge � partir de la base de donn�es les donn�es
	// membres de l'item.
	virtual bool Load ();

		//@cmember Cr�e le curseur permettant de charger les donn�es de l'item.
	// Par d�faut retourne NULL. Il faudra surcharger pour les descendants. 
	virtual CCursor* SelectOrder () 
		{return NULL;};

		//@cmember Cr�e le curseur permettant de cr�er l'item en bdd.
	// Par d�faut retourne NULL. Il faudra surcharger pour les descendants. 
	virtual CCursor* CreateOrder () 
		{return NULL;};

	//@cmember Cr�e le curseur permettant de modifier l'item en bdd.
	// Par d�faut retourne NULL. Il faudra surcharger pour les descendants. 	
	virtual CCursor* UpdateOrder () 
		{return NULL;};

	//@cmember Cr�e le curseur permettant de supprimer l'item en bdd.
	// Par d�faut retourne NULL. Il faudra �ventuellement le
	// surcharger pour les descendants, qui ne pourrait utiliser
	// l'odre de suppression par d�faut. 	
	virtual CCursor* EraseOrder () 
		{return NULL;};

	//@cmember Cette m�thode est appel�e juste avant de lancer  
	// <mf CDialog::DoModal> de la feuille de propri�t�s, lors de la cr�ation
	// de l'item.
	virtual void InitCreate (long BddId, long ClassId){};

		//@cmember Cette m�thode est appel�e juste avant la copie de l'item.
	virtual void InitCopy () 
		{m_BddId = 0;};

		//@cmember Copie les �l�ments autres que ceux de la saisie
	// Cette copie s'effectue APRES l'affichage de l'�cran de propri�t�s
	virtual bool CopySuite (long lBddIdOrg, long lBddIdCop) {return true;};


public:
	//@cmember,menum Etats d'un <c CItem>
	enum State
	{
		Modification,	//@@emem L'item est en train d'�tre modifi�
		Creation,		//@@emem L'item est en train d'�tre cr��
		CreModSansMaj,	//@@emem L'item est en saisie, mais le dialog 
						//ne mettra pas � jour la Bdd
		Generation,		//@@emem L'item g�n�re un item d'un autre type
		Visualisation,	//@@emem L'item est en train d'�tre visualis�
		Standby,		//@@emem Etat de l'item par defaut 
		Copie			//@@emem L'item est en train d'�tre copi�
	};

	//@cmember Pointeur sur la session dans laquelle les 
	// �changes avec la base se d�rouleront
	CBdd* m_pBdd;

	//@cmember Id de la classe � laquelle l'item appartient.
	int		 m_ClassId;

	//@cmember Nom en clair de l'item
	CString	m_Name;

	//@cmember Identifiant en Bdd
	long	m_BddId;

	//@cmember Etat de l'item
	State   m_State;
};


