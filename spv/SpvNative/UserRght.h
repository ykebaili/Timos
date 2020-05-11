//@doc UserRght
//
// Project  : SPV
//
// Authors	: T. Aim�
// Date		: 23/9/98 -- Cr�ation
// Release	: 1.0
//
//@module UserRght |
// Ce Module d�finit l'objet charg� de la gestion des droits de l'utilisateur
//@xref <c CUserRight>
///////////////////////////////////////////////////////////////////////////////

#ifndef USERRGHT_H
#define USERRGHT_H

///////////////////////////////////////////////////////////////////////////////
//

const int PRI_EMPTY  = -1;
const int PRI_HERITE = 127;

const int PRI_USER   = 0;
const int PRI_ROLE   = 1;
const int PRI_PERIF  = 2;
const int PRI_CONFIG = 3;	// Droit d'acc�s � la branche configuration
const int PRI_SCRIPT = 5;
const int PRI_ALARM	 = 6;
const int PRI_MCAB   = 7;
const int PRI_MODEL  = 8;
const int PRI_CAUSAL = 9;
const int PRI_SITE   = 12;
const int PRI_SALLE  = 13;
const int PRI_EQUIP  = 16;
const int PRI_PROG   = 19;
const int PRI_CLIENT = 22;
const int PRI_CONTAC = 23;
const int PRI_SUPERV = 26;
const int PRI_CONSAL = 27;
const int PRI_ACQAL  = 28;
const int PRI_ARCH	 = 29;	// Archivage des propri�t�s
const int PRI_MSKADM = 30;
const int PRI_PARAM	 = 31;	// Param�tres de l'appli. (couleur alarmes etc..)
const int PRI_JCXION = 32;  // Journal de connexion
const int PRI_CONSNOPRO = 33;  // Consultation non propri�taire
const int PRI_TOPO	 = 34;  // privil�ge Topologie
const int PRI_PROGHOR = 35;		// Plages horaires.

const int CONSULT = 1;
const int UPDATE  = 2;

const int UNKNOWN		= -1;
const int INTERN		= 0;	// Son propre site (avant, valait 1)
const int DOMAINE		= 1;
const int EXTERN		= 2;	// Tous les sites (avant valait 0)

const int PINTERN		= 1;
const int PDOMAIN		= 2;
const int PEXTERN		= 4;

const int LOC_HERITE	= 127;	// H�rite les droits du p�re (avant, valait 2)

const int MAX_PRIV		= 128;	// nb. max. de privil�ges dans un r�le (actuellt. 44)
const int MAX_DOMAIN	= 128;	// nb. max. de domaines possibles


///////////////////////////////////////////////////////////////////////////////
// @class Cette classe d�termine les droits de l'utilisateur en modification et
// consultation sur les objets de l'application.
// Elle se base sur les privil�ges de l'utilisateur.
// Les privil�ges sont d�compos�s par cat�gories. Chaque cat�gorie
// �tant elle-m�me d�compos�e en 2 actions, avec trois localisations
// possibles (objets de son site, les objets d'un domaine, tous les objets).

// Voici pour chaque cat�gorie la constante l'adressant :<nl>
//   Op�rateur...................-> PRI_USER <nl>
//   R�le........................-> PRI_ROLE <nl>
//   P�riph�rique................-> PRI_PERIF <nl>
//	 C�blage inter �quipements...-> PRI_MCAB <nl>
//   Autre mod�le et type........-> PRI_MODEL <nl>
//   Cause possible d'alarme.....-> PRI_CAUSAL <nl>
//   Site, liaison inter-sites...-> PRI_SITE <nl>
//   Salle, baie, r�partiteur....-> PRI_SALLE <nl>
//   Equipement..................-> PRI_EQUIP <nl>
//   Programme...................-> PRI_PROG <nl>
//   Client......................-> PRI_CLIENT <nl>
//   Contact.....................-> PRI_CONTAC <nl>
//   Supervision.................-> PRI_SUPERV <nl>
//   Consultation d'alarmes......-> PRI_CONSAL <nl>
//   Acquitement d'alarmes.......-> PRI_ACQAL <nl>
//   Masquage Administrateur.....-> PRI_MSKADM <nl>
//   Param�tres de l'application.-> PRI_PARAM <nl>
//   Script......................-> PRI_SCRIPT <nl>
//	 Alarme g�r�e................-> PRI_ALARM <nl>
//  <nl><nl>
// Les actions possibles sont : UPDATE ou CONSULT <nl>
// <nl>
// Les port�es possibles sont : INTERN, DOMAINE ou EXTERN 

class CItem;		// Pour GetFor
class CUserRight
{
public :
//@access Constructeurs, destructeur
	
	//@cmember Construction d'un <c CUserRight>
	CUserRight ();

	//@cmember Destruction d'un <c CUserRight>
	virtual ~CUserRight (){};

public:
//@access Acc�s donn�es membres
	
	//@cmember Mise � jour des privil�ges de l'utilisateur.
	void SetUserRight (const unsigned char Privileges [], bool Maximize = false);

	//@cmember Retourne vrai ou faux suivant que l'utilisateur dispose
	// du droit sp�cifi� en argument.
	bool GetFor (int BaseIdx, int ActIdx, int LocIdx, 
				 long BddId = 0, int ClassId = 0, CItem * pFatherItem = NULL);

public:
	// Ensemble d'octets d�finissant les privil�ges
	unsigned char m_Privileges [MAX_PRIV +2];
};


//@globalv Identifiant du site de l'op�rateur.
extern long	LocalSiteId;


#endif // USERRGHT_H