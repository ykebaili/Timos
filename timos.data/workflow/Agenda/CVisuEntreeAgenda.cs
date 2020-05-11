using System;

using sc2i.data;

namespace sc2i.workflow
{
	/// <summary>
	/// Description résumée de CVisuEntreeAgenda.
	/// </summary>
	public class CVisuEntreeAgenda
	{
		private CObjetDonneeAIdNumerique m_objetLie;
		private IEntreeAgenda m_entree;
		private IRoleSurEntreeAgenda m_role;
		private DateTime m_dateDebut, m_dateFin;
		
		////////////////////////////////////////////////////////////////////////// 
		public CVisuEntreeAgenda( CRelationEntreeAgenda_ElementAAgenda relation )
		{
			m_entree = relation.EntreeAgenda;
			m_role  = relation.RelationTypeEntree_TypeElement.Role;
			m_objetLie = relation.ElementLie;
			m_dateDebut = m_entree.DateDebut;
			m_dateFin = m_entree.DateFin;
		}

		////////////////////////////////////////////////////////////////////////// 
		public CVisuEntreeAgenda( IEntreeAgenda entree, IRoleSurEntreeAgenda role, CObjetDonneeAIdNumerique elementLie, DateTime dateDebut, DateTime dateFin )
		{
			m_entree = entree;
			m_role  = role;
			m_objetLie = elementLie;
			m_dateDebut = dateDebut;
			m_dateFin = dateFin;
		}

		//////////////////////////////////////////////////////////////////////////
		public CVisuEntreeAgenda ( CRelationEntreeAgenda_ElementAAgenda relation, DateTime dtDebut,
			DateTime dtfin )
		{
			m_entree = (CEntreeAgenda)relation.EntreeAgenda;
			m_role  = relation.RelationTypeEntree_TypeElement.Role;
			m_objetLie = relation.ElementLie;
			m_dateDebut = dtDebut;
			m_dateFin = dtfin;
		}

		//////////////////////////////////////////////////////////////////////////
		public IEntreeAgenda Entree
		{
			get
			{
				return m_entree;
			}
		}

		//////////////////////////////////////////////////////////////////////////
		public IRoleSurEntreeAgenda Role
		{
			get
			{
				return m_role;
			}
		}

		//////////////////////////////////////////////////////////////////////////
		public CObjetDonneeAIdNumerique ElementLie
		{
			get
			{
				return m_objetLie;
			}
		}

		//////////////////////////////////////////////////////////////////////////
		public DateTime DateDebut
		{
			get
			{
				return m_dateDebut;
			}
		}

		//////////////////////////////////////////////////////////////////////////
		public DateTime DateFin
		{
			get
			{
				return m_dateFin;
			}
		}
	}
}
