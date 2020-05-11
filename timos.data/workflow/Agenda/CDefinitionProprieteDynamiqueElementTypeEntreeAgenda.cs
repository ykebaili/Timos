using System;

using sc2i.expression;

namespace sc2i.workflow
{
	/// <summary>
	/// Definition correspondant au lien entre une entr�e d'agenda et un de ses �l�ments li�s
	/// Nom convivial = libell� du lien type entree->element
	/// propri�t� = Id du lien
	/// 
	/// </summary>
	public class CDefinitionProprieteDynamiqueElementTypeEntreeAgenda : CDefinitionProprieteDynamique
	{
		/// ////////////////////////////////////////////
		/// <param name="relation"></param>
		public CDefinitionProprieteDynamiqueElementTypeEntreeAgenda	(
			CRelationTypeEntreeAgenda_TypeElementAAgenda relation
			)
			:base (
			relation.Libelle,
			relation.Id.ToString(),
			new CTypeResultatExpression( relation.TypeElements, false),
			true,
			false)
		{
		}

		/// ////////////////////////////////////////////
		public CRelationTypeEntreeAgenda_TypeElementAAgenda GetRelationTypeElement ( CTypeEntreeAgenda typeEntree )
		{
			int nId = Int32.Parse(NomPropriete);

			foreach ( CRelationTypeEntreeAgenda_TypeElementAAgenda rel in typeEntree.RelationsTypeElementsAAgenda )
			{
				if ( rel.Id == nId )
					return rel;
				if ( rel.Libelle.ToUpper() == Nom.ToUpper() )
					return rel;
			}
			return null;
		}
	}
}
