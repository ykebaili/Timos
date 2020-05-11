using System;
using sc2i.data;

namespace sc2i.data
{
	//#######################################################################

	public interface IRelationGroupe : IObjetDonneeAIdNumeriqueAuto
	{
		CGroupeStructurant Groupe {get;set;}
		CObjetDeGroupe ObjetDeGroupe {get;set;}
	}

	//#######################################################################

	public interface IRelationGroupeGroupeNecessaire : IObjetDonneeAIdNumeriqueAuto, IObjetALectureTableComplete
	{
		CGroupeStructurant GroupeNecessitant {get; set;}
		CGroupeStructurant GroupeNecessaire {get; set;}
	}

	//#######################################################################	

	public interface IRelationGroupeStructurantGroupeParent : IObjetDonneeAIdNumeriqueAuto, IObjetDonneeAutoReference, IObjetALectureTableComplete
	{
		CGroupeStructurant GroupeContenant {get; set;}
		CGroupeStructurant GroupeContenu {get; set;}
		IRelationGroupeStructurantGroupeParent RelationSourceFille {get; set;}
		IRelationGroupeStructurantGroupeParent RelationSourceParent {get; set;}
		bool IsRelationDirecte();
	}

	//#######################################################################
}
