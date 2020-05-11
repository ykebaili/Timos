using System;

using sc2i.common;
using sc2i.data;
using sc2i.data.serveur;
using sc2i.data.dynamic;

namespace sc2i.workflow.serveur
{
	/// <summary>
	/// Description résumée de Class1.
	/// </summary>
	public class CRelationTypeEntreeAgenda_TypeElementAAgendaServeur : CObjetServeurAvecBlob
	{
		/// //////////////////////////////////////////////////
#if PDA
		public CRelationTypeEntreeAgenda_TypeElementAAgendaServeur()
			:base ()
		{
			
		}
#endif
		/// //////////////////////////////////////////////////
		public CRelationTypeEntreeAgenda_TypeElementAAgendaServeur( int nIdSession )
			:base ( nIdSession )
		{
			
		}

		//////////////////////////////////////////////////////////////////////
		public override string GetNomTable()
		{
			return CRelationTypeEntreeAgenda_TypeElementAAgenda.c_nomTable;
		}

		//////////////////////////////////////////////////////////////////////
		public override Type GetTypeObjets()
		{
			return typeof(CRelationTypeEntreeAgenda_TypeElementAAgenda);
		}

		//////////////////////////////////////////////////////////////////////
		public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{	
				CRelationTypeEntreeAgenda_TypeElementAAgenda relation = (CRelationTypeEntreeAgenda_TypeElementAAgenda)objet;
				if ( relation.Libelle == "" )
				{
					result.EmpileErreur(I.T("The label cannot be empty|327"));
				}
				CFiltreData filtre = new CFiltreData (
					CRelationTypeEntreeAgenda_TypeElementAAgenda.c_champLibelle+"=@1 and "+
					CRelationTypeEntreeAgenda_TypeElementAAgenda.c_champId+"<>@2 and "+
					CTypeEntreeAgenda.c_champId+"=@3",
					relation.Libelle,
					relation.Id,
					relation.TypeEntree.Id);
				if ( CountRecords(CRelationTypeEntreeAgenda_TypeElementAAgenda.c_nomTable,
					filtre) > 0 )
				{
					result.EmpileErreur(I.T("The label '@1' already exists|326",relation.Libelle));
				}

				
				return result;
			}
			catch ( Exception e )
			{
				result.EmpileErreur(new CErreurException(e));
			}
			return result;
				
		}


	}
}
