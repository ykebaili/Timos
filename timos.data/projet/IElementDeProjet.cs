using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

using sc2i.data;
using sc2i.common;
using sc2i.process;
using sc2i.multitiers.client;
using sc2i.data.dynamic;
using sc2i.common.planification;

using timos.securite;
using timos.acteurs;


namespace timos.data
{
    /// <summary>
    /// Tout élément qui peut avoir des anomalies au niveau de la gestion de projet
    /// </summary>
	public interface IElementAAnomalieProjet : IObjetDonneeAIdNumerique
	{
        CListeObjetsDonnees AnomaliesConcernant { get; }
	}


	public interface IElementDeProjetPlanifiable : IElementAAnomalieProjet
	{
        string Libelle { get; set; }
		CListeObjetsDonnees LiensDeProjetAttaches { get; }
        DateTime DateDebutGantt { get; set; }
        DateTime DateFinGantt { get; set; }
        bool DatesAuto { get; }
		CEtatPlanification EtatPlanification { get;}
        CProjet Projet { get; set; }

        //Effectue un déplacement en respectant le gantt
        void Move(
            TimeSpan sp, 
            TimeSpan ? duree,
            EModeDeplacementProjet mode,
            bool bForceForThisElement);


        void FillDicSuccesseurs(HashSet<IElementDeProjetPlanifiable> dic);
        void FillDicPredecesseurs(HashSet<IElementDeProjetPlanifiable> dic);
	}
}
