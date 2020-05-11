// Item.cpp : implementation file
//

#include "stdafx.h"
#include "Item.h"


// CItem

CItem::CItem()
{
}

CItem::~CItem()
{
}


//@cmember Met � jour les donn�es membres du CItem.
void CItem::SetInfo (long BddId, char *lpszName, long ClassId)
{
	m_ClassId = ClassId;
	m_Name    = lpszName;
	m_BddId   = BddId;
}


///////////////////////////////////////////////////////////////////////////////
//@mfunc Chargement des donn�es membres de l'item � partir de la base 
// de donn�es. Par d�faut cette m�thode exploite la fonction 
// <mf CItem::SelectOrder>
//
// @rdesc R�sultat du chargement
//		@flag true  | Si le chargement s'est bien op�r�
//		@flag false | Si le chargement n'a pu �tre ex�cut�
bool CItem::Load ()
{
	bool bResult = false;


	CCursor	*pCursor = SelectOrder ();
	
	if (pCursor == NULL)
	{
		AfxMessageBox (IDS_MESS0015, MB_ICONSTOP | MB_OK);
		return false;
	}

	CString Message;
	Message.Format (IDS_MESS0014, m_Name);
	pCursor->CatchOraMess (ORA00054, &Message);

	pCursor->Exec ();

	switch (pCursor->Fetch ())
	{
		case OK :
			bResult = true;
			if (m_State == Creation || m_State == Copie || m_State == Generation)
				InitCopy ();
			break;

		case EOF : 
			Message.Format (IDS_MESS0021, m_Name);
			AfxMessageBox (Message, MB_ICONSTOP | MB_OK);
			break;
		
		default :
			break;
	}


	delete pCursor;
	return bResult;
}			// Load

// Chargement � partir de la BDD
/*
bool CItem::Load(void)
{
	return false;
}*/
