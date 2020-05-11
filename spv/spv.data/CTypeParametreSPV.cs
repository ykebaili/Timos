using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

using sc2i.data;
using sc2i.common;





namespace spv.data
{

    public enum ETypeSpvParam
    {
        TypeAsservAntenne = 1,	// Type d'asservissement pour les antennes
		ContractantSatellite,	// Contractant pour les satellites
		TypeAcces,				// Type d'accès (sortie alarme...)
		DebitLiaison,			// Débit de liaison
		CentreDirecteur,		// Centres directeurs pour les liaisons
		ParamProg,				// Paramètres pour un programme
		DefaultPointForSiteExt,	// POINT par défaut pour les extrémités de site
		TypeAlim,				// Type d'alimentation pour les types d'équipements
		Systeme,			// Options de l'application
		SignalTypeForRegl,		// Type de signal pour les réglettes de répartiteur
		CriTop1 = 11,			// Critères de type 1 pour les topologies
		CriTop2,				// Critères de type 2 pour les topologies
		CriTop3,				// Critères de type 3 pour les topologies
		CriTop4,				// Critères de type 4 pour les topologies
		CriTop5,				// Critères de type 5 pour les topologies

		// Attention, les critères CriTop ci-dessus doivent être consécutifs et dans
		// cet ordre.
		// Attention, pour des paramètres futurs, laisser de
		// la place après les critères de topologie afin qu'on puisse
		// en rajouter à la suite.

        AlarmColor = 17,
	    ParamNbFixe = 18,		// Nb. crypté de licences fixes
		ParamNbFlot = 19,		// Nb. crypté de licences flottantes

		ParamSite = 20,			// Paramètres pour un site (Cegetel POP, remnet, etc.)
		ParamRole = 21,			// Groupes auxquels un rôle peut appartenir

		ParamSite2 = 23,		// Paramètres 2 pour un site (TDF Sites physiques, points de service, etc.)
		CriFamille = 24,		// Critères pour les familles
		CriFabric  = 25,		// Critères pour les fabricants
		CriClient  = 26,		// Critères pour les clients
		CriOpe	   = 27,		// Critères pour les opérateurs satellite
		CriProg	   = 28			// Critères pour les programmes        
    }


    public  class CTypeParametreSPV : CEnumALibelle<ETypeSpvParam>
    {
        public CTypeParametreSPV(ETypeSpvParam typeParam)
            : base(typeParam)
        {

        }


        public override string Libelle
        {
            get
            { 
            switch (Code)
				{
                case ETypeSpvParam.Systeme :
						return I.T( "System|30000");
					
                 }
                 return "";
            }
        }
    }
}
