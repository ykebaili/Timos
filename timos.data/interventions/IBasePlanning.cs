using System;
using System.Collections.Generic;
using System.Text;

using timos.acteurs;
using sc2i.data;

namespace timos.data
{
	public interface IBasePlanning
	{
		IEnumerable<IElementAIntervention> ElementsAIntervention{ get;}
        void AddElementAIntervention(IElementAIntervention elt);
        void RemoveElementAIntervention(IElementAIntervention elt);
        void ClearElementsAIntervention();
		List<ITranchePlanning> GetTranchesForElementsAInterventionBetween(DateTime dateDebut, DateTime dateFin);
		
		IEnumerable<IRessourceEntreePlanning> Ressources { get;}
        void AddRessource(IRessourceEntreePlanning ressource);
        void RemoveRessource(IRessourceEntreePlanning ressource);
        void ClearRessources();
		List<ITranchePlanning> GetOccupationsForRessourcesBetween( DateTime dateDebut, DateTime dateFin);

        CContexteDonnee ContexteDonnee { get; }

	}
}
