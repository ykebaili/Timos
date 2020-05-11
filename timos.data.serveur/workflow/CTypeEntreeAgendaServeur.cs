using System;

using sc2i.common;
using sc2i.data;
using sc2i.data.serveur;
using sc2i.data.dynamic;

namespace sc2i.workflow.serveur
{
	/// <summary>
	/// Description rÃ©sumÃ©e de Class1.
	/// </summary>
	public class CTypeEntreeAgendaServeur : CObjetServeur
	{
		/// //////////////////////////////////////////////////
#if PDA
		public CTypeEntreeAgendaServeur()
			:base ( )
		{
			
		}
#endif
		/// //////////////////////////////////////////////////
		public CTypeEntreeAgendaServeur( int nIdSession )
			:base ( nIdSession )
		{
			
		}

		//////////////////////////////////////////////////////////////////////
		public override string GetNomTable()
		{
			return CTypeEntreeAgenda.c_nomTable;
		}

		//////////////////////////////////////////////////////////////////////
		public override Type GetTypeObjets()
		{
			return typeof(CTypeEntreeAgenda);
		}

		//////////////////////////////////////////////////////////////////////
		public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{	
				CTypeEntreeAgenda typeEntree = (CTypeEntreeAgenda)objet;
				if ( typeEntree.Libelle == "" )
				{
					result.EmpileErreur(I.T("Diary entry type label should not be empty|347"));
				}
				if (!CObjetDonneeAIdNumerique.IsUnique(typeEntree, CTypeEntreeAgenda.c_champLibelle, typeEntree.Libelle))
				{
					result.EmpileErreur(I.T("Another type of diary entry already has this label|249"));
				}

				
				return result;
			}
			catch ( Exception e )
			{
				result.EmpileErreur(new CErreurException(e));
				result.EmpileErreur(I.T("Diary entry type data error|348"));
			}
			return result;
				
		}


	}
}
