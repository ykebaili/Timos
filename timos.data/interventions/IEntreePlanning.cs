using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

using sc2i.data;
using timos.acteurs;
using sc2i.common;
using sc2i.workflow;

namespace timos.data
{
	/// <summary>
	/// Entrée de planning
	/// </summary>
	public interface IEntreePlanning 
	{
		int Id { get;}
		Color Couleur{get;set;}
		string Libelle{get;set;}

		/// <summary>
		/// Pour une Intervention, retourne l'élément lié à la Intervention
		/// </summary>
		IElementAIntervention ElementLiePrincipal { get;}

		ITranchePlanning[] Tranches{get;set;}

		bool Occupe(IRessourceEntreePlanning ressource);

		//Gestion des ressources
		IRessourceEntreePlanning[] GetRessourcesAssociees(ITypeRelationEntreePlanning_Ressource typeRelation);
		CResultAErreur AssocieRessource(ITypeRelationEntreePlanning_Ressource typeRelation, IRessourceEntreePlanning ressource);
        CResultAErreur DissocieRessource(ITypeRelationEntreePlanning_Ressource typeRelation, IRessourceEntreePlanning ressource);
		ITypeRelationEntreePlanning_Ressource[] GetTypesRelationsAssociees(IRessourceEntreePlanning ressource);

		IRessourceEntreePlanning[] GetRessourcesAffectees(Type typeRessource);

		IRessourceEntreePlanning[] GetRessourcesPossibles(IProfilElement profil, CFiltreData filtreDeBase);

		Type[] GetTypesRessourceAAffecter();
		ITypeRelationEntreePlanning_Ressource[] GetRelationsRessourceAAffecter( Type typeRessource );
		
	}

	//-------------------------------------------------------
	/// <summary>
	/// Lien entre une entrée de planning et une ressource
	/// </summary>
	public interface IEntreePlanning_Ressource
	{
		IEntreePlanning EntreePlanning { get;set;}
		IRessourceEntreePlanning Ressource { get;set;}
	}

	//-------------------------------------------------------
	/// <summary>
	/// Tranche de date d'une entrée de planning 
	/// un entrée de planning peut être divisée en plusieurs tranches
	/// </summary>
	public interface ITranchePlanning : IEntreeAgenda
	{
		/*DateTime DateDebut { get;set;}
		DateTime DateFin { get;set;}*/
		IEntreePlanning EntreePlanning { get;}
	}

	//-------------------------------------------------------
	/// <summary>
	/// Type de relation entre une entrée de planning et une ressource
	/// </summary>
	public interface ITypeRelationEntreePlanning_Ressource : IProfilElement 
	{
		Type GetTypeRessource();
		string Libelle { get;}
		bool IsInCheckListApplique { get;}
        bool AfficherManquantDansPlanning { get; }
	}

	//-------------------------------------------------------
	/// <summary>
	/// Ressource pouvant être affectée à une entrée de planning
	/// </summary>
	public interface IRessourceEntreePlanning : IObjetDonneeAIdNumeriqueAuto
	{
		string Libelle { get;}
		sc2i.workflow.CCalendrier Calendrier { get;}
		bool CanBeUseFor(IProfilElement profil, IEntreePlanning entreePlanning);
        CTrancheHoraire[] GetHoraires(DateTime dtDebut, DateTime dtfin);
	}
}
