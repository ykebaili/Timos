#pragma once

// CItem command target

#include "Cursor.h"

class AFX_EXT_CLASS CItem : public CObject
{
public:
	CItem();
	virtual ~CItem();

	//@cmember Met à jour les données membres du CItem.
	virtual void SetInfo (long BddId, char *lpszName, long ClassId);

	//@cmember Charge à partir de la base de données les données
	// membres de l'item.
	virtual bool Load ();

		//@cmember Crée le curseur permettant de charger les données de l'item.
	// Par défaut retourne NULL. Il faudra surcharger pour les descendants. 
	virtual CCursor* SelectOrder () 
		{return NULL;};

		//@cmember Crée le curseur permettant de créer l'item en bdd.
	// Par défaut retourne NULL. Il faudra surcharger pour les descendants. 
	virtual CCursor* CreateOrder () 
		{return NULL;};

	//@cmember Crée le curseur permettant de modifier l'item en bdd.
	// Par défaut retourne NULL. Il faudra surcharger pour les descendants. 	
	virtual CCursor* UpdateOrder () 
		{return NULL;};

	//@cmember Crée le curseur permettant de supprimer l'item en bdd.
	// Par défaut retourne NULL. Il faudra éventuellement le
	// surcharger pour les descendants, qui ne pourrait utiliser
	// l'odre de suppression par défaut. 	
	virtual CCursor* EraseOrder () 
		{return NULL;};

	//@cmember Cette méthode est appelée juste avant de lancer  
	// <mf CDialog::DoModal> de la feuille de propriétés, lors de la création
	// de l'item.
	virtual void InitCreate (long BddId, long ClassId){};

		//@cmember Cette méthode est appelée juste avant la copie de l'item.
	virtual void InitCopy () 
		{m_BddId = 0;};

		//@cmember Copie les éléments autres que ceux de la saisie
	// Cette copie s'effectue APRES l'affichage de l'écran de propriétés
	virtual bool CopySuite (long lBddIdOrg, long lBddIdCop) {return true;};


public:
	//@cmember,menum Etats d'un <c CItem>
	enum State
	{
		Modification,	//@@emem L'item est en train d'être modifié
		Creation,		//@@emem L'item est en train d'être créé
		CreModSansMaj,	//@@emem L'item est en saisie, mais le dialog 
						//ne mettra pas à jour la Bdd
		Generation,		//@@emem L'item génère un item d'un autre type
		Visualisation,	//@@emem L'item est en train d'être visualisé
		Standby,		//@@emem Etat de l'item par defaut 
		Copie			//@@emem L'item est en train d'être copié
	};

	//@cmember Pointeur sur la session dans laquelle les 
	// échanges avec la base se dérouleront
	CBdd* m_pBdd;

	//@cmember Id de la classe à laquelle l'item appartient.
	int		 m_ClassId;

	//@cmember Nom en clair de l'item
	CString	m_Name;

	//@cmember Identifiant en Bdd
	long	m_BddId;

	//@cmember Etat de l'item
	State   m_State;
};


