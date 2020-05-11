using System;
using System.Reflection;

using sc2i.data;

namespace sc2i.workflow
{
	/// <summary>
	/// Tout �l�ment ayant des relations fille avec des tranches horaires
	/// </summary>
	/// <remarks>
	/// 
	/// </remarks>
	public interface IElementATrancheHoraire: IObjetDonnee
	{
        // Relation fille vers les Tranches Horaires (CHoraireJournalier_Tranche)
        CListeObjetsDonnees TranchesHorairesListe { get;}
        
		// Relation parente vers le Type d'occupation Horaire (CTypeOccupationHoraire)
        CTypeOccupationHoraire TypeOccupationHoraire { get;set;}
		
		// Retourne l'�l�ment � tranche qui est appliqu� � celui-ci (celui qui poss�de r�ellement les tranches horaires)
		IElementATrancheHoraire ElementATrancheHoraireApplique { get;}

    }
}
