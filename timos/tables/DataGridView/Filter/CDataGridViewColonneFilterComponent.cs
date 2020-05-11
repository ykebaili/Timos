using System;
using System.Data;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using sc2i.data;

namespace timos.tables
{

	[Serializable]
	public abstract class CDataGridViewColonneFilterComponent : ISerializable
	{

		public CDataGridViewColonneFilterComponent(DataGridViewColumn col)
		{
			m_lstFils = new List<CDataGridViewColonneFilterComponent>();
			m_col = col;
		}

		internal List<CDataGridViewColonneFilterComponent> m_lstFils;
		internal DataGridViewColumn m_col;

		public virtual CComposantFiltre GetComposantFiltre()
		{
			CComposantFiltre filtrebase;
			string idOperateur = "";
			switch (FilsOperateur)
			{
				case EOperateurElementAComposantFiltre.Et:
					idOperateur = CComposantFiltreOperateur.c_IdOperateurEt;
					break;
				case EOperateurElementAComposantFiltre.Ou:
					idOperateur = CComposantFiltreOperateur.c_IdOperateurOu;
					break;
				default:
					return null;
			}

			int nbEle = m_lstFils.Count;

			if (nbEle > 1)
			{
				filtrebase = new CComposantFiltreOperateur(idOperateur);
				CComposantFiltreOperateur filtrelast = (CComposantFiltreOperateur)filtrebase;
				for (int i = 0; i < nbEle; i++)
				{
					CDataGridViewColonneFilterComponent fils = m_lstFils[i];
					if (i == m_lstFils.Count - 2)
					{
						filtrelast.Parametres.Add(fils.GetComposantFiltre());
						filtrelast.Parametres.Add(m_lstFils[i + 1].GetComposantFiltre());
						break;
					}
					else
					{
						filtrelast.Parametres.Add(fils.GetComposantFiltre());
						CComposantFiltreOperateur filtresuivant = new CComposantFiltreOperateur(idOperateur);
						filtrelast.Parametres.Add(filtresuivant);
						filtrelast = filtresuivant;
					}
				}
			}
			else if (nbEle == 1)
				filtrebase = m_lstFils[0].GetComposantFiltre();
			else
				return null;

			return filtrebase;
		}

		/// <summary>
		/// Retourne vrai si il y a 
		/// </summary>
		/// <param name="supprimerFilsNonValide"></param>
		/// <returns></returns>
		public virtual bool Valider(bool supprimerFilsNonValide)
		{
			for (int i = m_lstFils.Count; i > 0; i--)
			{
				CDataGridViewColonneFilterComponent fils = m_lstFils[i - 1];
				if (!fils.Valider(false))
					if(!supprimerFilsNonValide)
						return false;
					else
						m_lstFils.Remove(fils);
			}
			if (m_lstFils.Count == 0)
				return false;
			else 
				return true;
		}

		public List<CDataGridViewColonneFilterComponent> Fils
		{
			get
			{
				return m_lstFils;
			}
			set
			{
				m_lstFils = value;
			}
		}
		public DataGridViewColumn ColonneDataGrid
		{
			get
			{
				return m_col;
			}
		}

		public abstract EOperateurElementAComposantFiltre? FilsOperateur { get;}


		#region ISerializable Membres

		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			//if(info != null)
			//    info.AddValue(m_col,true);
		}

		#endregion
	}
}
