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
		TypeAcces,				// Type d'acc�s (sortie alarme...)
		DebitLiaison,			// D�bit de liaison
		CentreDirecteur,		// Centres directeurs pour les liaisons
		ParamProg,				// Param�tres pour un programme
		DefaultPointForSiteExt,	// POINT par d�faut pour les extr�mit�s de site
		TypeAlim,				// Type d'alimentation pour les types d'�quipements
		Systeme,			// Options de l'application
		SignalTypeForRegl,		// Type de signal pour les r�glettes de r�partiteur
		CriTop1 = 11,			// Crit�res de type 1 pour les topologies
		CriTop2,				// Crit�res de type 2 pour les topologies
		CriTop3,				// Crit�res de type 3 pour les topologies
		CriTop4,				// Crit�res de type 4 pour les topologies
		CriTop5,				// Crit�res de type 5 pour les topologies

		// Attention, les crit�res CriTop ci-dessus doivent �tre cons�cutifs et dans
		// cet ordre.
		// Attention, pour des param�tres futurs, laisser de
		// la place apr�s les crit�res de topologie afin qu'on puisse
		// en rajouter � la suite.

        AlarmColor = 17,
	    ParamNbFixe = 18,		// Nb. crypt� de licences fixes
		ParamNbFlot = 19,		// Nb. crypt� de licences flottantes

		ParamSite = 20,			// Param�tres pour un site (Cegetel POP, remnet, etc.)
		ParamRole = 21,			// Groupes auxquels un r�le peut appartenir

		ParamSite2 = 23,		// Param�tres 2 pour un site (TDF Sites physiques, points de service, etc.)
		CriFamille = 24,		// Crit�res pour les familles
		CriFabric  = 25,		// Crit�res pour les fabricants
		CriClient  = 26,		// Crit�res pour les clients
		CriOpe	   = 27,		// Crit�res pour les op�rateurs satellite
		CriProg	   = 28			// Crit�res pour les programmes        
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
