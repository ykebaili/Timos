using System;

using sc2i.data;

namespace sc2i.workflow
{
	/// <summary>
	/// Paramétrage d'un élément qui peut avoir des liens sur d'autres objets
	/// </summary>
	public interface ITypeElementALien : IObjetDonneeAIdNumeriqueAuto
	{
		CListeObjetsDonnees TypesRelationsToElement {get;}
	}

	/// <summary>
	/// Paramétrage d'un lien entre un type d'élément à lien et un type d'élément
	/// </summary>
	public interface IRelationTypeElementALien_TypeElement : IObjetDonneeAIdNumeriqueAuto
	{
		ITypeElementALien TypeElementALien{get;set;}
		bool Multiple{get;set;}
		bool SuppressionAutomatique{get;set;}
		Type TypeElements{get;set;}
		string TypeElementsConvivial{get;}
		string Code{get;set;}
		string Libelle{get;set;}
		CFiltreData FiltreDataAssocie{get;}

		IRelationElementALien_Element GetNewRelation ( IElementALien elementALien, CObjetDonneeAIdNumerique elementLie );
	}

	/// <summary>
	/// Element ayant des liens vers d'autres éléments
	/// </summary>
	public interface IElementALien : IObjetDonneeAIdNumeriqueAuto
	{
		ITypeElementALien TypeElementALien {get;set;}
		CListeObjetsDonnees RelationsElements{get;}
		bool AddElementLie ( CObjetDonneeAIdNumerique element, string strCode );
		bool AddElementLieSurType ( CObjetDonneeAIdNumerique element, IRelationTypeElementALien_TypeElement relationType);
		CObjetDonneeAIdNumerique GetElementLie ( string strCode );
		CObjetDonneeAIdNumerique[] GetElementsLies ( string strCode );
		bool DelieElement ( CObjetDonneeAIdNumerique element, string strCode );
		bool DelieElementSurType ( CObjetDonneeAIdNumerique element, IRelationTypeElementALien_TypeElement relationType );

	}

	/// <summary>
	/// Relation entre un élément à lien et un élément
	/// </summary>
	public interface IRelationElementALien_Element : IObjetDonneeAIdNumeriqueAuto
	{
		CObjetDonneeAIdNumerique ElementLie{get;set;}
		IRelationTypeElementALien_TypeElement RelationType{get;set;}
	}
}
