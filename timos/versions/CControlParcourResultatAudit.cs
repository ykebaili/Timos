using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using sc2i.data;

using timos.data.version;

namespace timos.version
{
	public partial class CControlParcourResultatAudit : UserControl
	{
		public CControlParcourResultatAudit()
		{
			InitializeComponent();
		}


		private CAuditVersion m_audit;
		public void Init(CAuditVersion audit)
		{
			m_txtSelectVersionCible.FonctionTextNull = CFormEditionAuditVersion.GetTextNullVersionBase;
			m_txtSelectVersionSource.FonctionTextNull = CFormEditionAuditVersion.GetTextNullVersionBase;

			m_audit = audit;
			ActualiserAffichage();
		}
		private bool AuditEffectue
		{
			get
			{
				return m_audit.DateRealisationAudit.HasValue;
			}
			set
			{
				m_sc1.Enabled = value;
				m_txtSelectVersionCible.Enabled = value;
				m_txtSelectVersionSource.Enabled = value;
			}
		}
		private bool m_bInitialise = false;
		public void ActualiserAffichage()
		{
			m_bInitialise = false;
			m_lstTypes.Items.Clear();
			m_lstEntities.Items.Clear();
			m_bRecalcIDs = true;
			AuditEffectue = m_audit.DateRealisationAudit.HasValue;
			if (!AuditEffectue)
				return;
			InitialiserVersions();
			InitTypes();
			m_bInitialise = true;
		}

		#region IDs Versions
		private int? IdVersionCibleSelectionnee
		{
			get
			{
				if (m_audit.IsArchive)
					return m_audit.IdVersionCible;
				if (VersionCibleSelectionnee != null)
					return VersionCibleSelectionnee.Id;
				return null;
			}
		}
		private CVersionDonnees VersionCibleSelectionnee
		{
			get
			{
				try
				{
					return (CVersionDonnees)m_txtSelectVersionCible.ElementSelectionne;
				}
				catch
				{
					return null;
				}
			}
			set
			{
				m_txtSelectVersionCible.ElementSelectionne = value;
			}
		}
		private int? IdVersionSourceSelectionnee
		{
			get
			{
				if (m_audit.IsArchive)
					return m_audit.IdVersionSource;
				if (VersionSourceSelectionnee != null)
					return VersionSourceSelectionnee.Id;
				return null;
			}
		}
		private CVersionDonnees VersionSourceSelectionnee
		{
			get
			{
				try
				{
					return (CVersionDonnees)m_txtSelectVersionSource.ElementSelectionne;
				}
				catch
				{
					return null;
				}
			}
			set
			{
				m_txtSelectVersionSource.ElementSelectionne = value;
			}
		}
		private bool m_bRecalcIDs = false;
		private List<string> m_idsVersions;
		private List<string> IdsVersions
		{
			get
			{
				return m_idsVersions;
			}
			set
			{
				m_bRecalcIDs = true;
			}
		}
		private List<string> m_idsVersionsSources;
		private List<string> IdsVersionsSources
		{
			get
			{
				if (m_bRecalcIDs)
					RecalcIdsVersions();
				return m_idsVersionsSources;
			}
		}
		private List<string> IdsVersionsSourcesPossibles
		{
			get
			{
				List<string> ids = new List<string>();

				if (VersionCibleSelectionnee != null)
				{

					CVersionDonnees v = VersionCibleSelectionnee.VersionParente;
					while (v != m_audit.VersionSource)
						ids.Add(v.Id.ToString());

					if (m_audit.VersionSource != null)
						ids.Add(m_audit.VersionSource.Id.ToString());
				}
				return ids;
			}
		}
		private List<string> m_idsVersionsCibles;
		private List<string> IdsVersionsCibles
		{
			get
			{
				if (m_bRecalcIDs)
					RecalcIdsVersions();
				return m_idsVersionsCibles;
			}
		}
		private void RecalcIdsVersions()
		{
			CVersionDonnees v = m_audit.VersionCible;
			m_idsVersions = new List<string>();
			while (v != null)
			{
				m_idsVersions.Add(v.Id.ToString());
				v = v.VersionParente;
			}
			if (m_idsVersions.Count < 1)
			{
				//ERR
			}

			m_idsVersionsCibles = new List<string>(m_idsVersions);
			if(m_idsVersions.Count > 1)
				m_idsVersionsCibles.RemoveAt(m_idsVersionsCibles.Count - 1);

			m_idsVersionsSources = new List<string>(m_idsVersions);
			m_idsVersionsSources.RemoveAt(0);
			m_bRecalcIDs = false;
		}
		private void InitialiserVersions()
		{
			return;
			/*m_txtSelectVersionCible.Init(typeof(CVersionDonnees), "Libelle",
				new CFiltreData(CVersionDonnees.c_champId + " in(" + string.Join(",", IdsVersionsCibles.ToArray()) + ")"));
			VersionCibleSelectionnee = m_audit.VersionCible;

			m_txtSelectVersionSource.Init(typeof(CVersionDonnees), "Libelle",
				new CFiltreData(CVersionDonnees.c_champId + " in(" + string.Join(",", IdsVersionsSources.ToArray()) + ")"));
			VersionSourceSelectionnee = m_audit.VersionSource;

			m_txtSelectVersionCible.Enabled = !m_audit.AuditDetaille;
			m_txtSelectVersionSource.Enabled = !m_audit.AuditDetaille;*/
		}
		#endregion

		//CHANGEMENT SUR VERSION
		private void m_txtSelectVersionSource_ElementSelectionneChanged(object sender, EventArgs e)
		{
			if (!m_bInitialise)
				return;

		}
		private void m_txtSelectVersionCible_ElementSelectionneChanged(object sender, EventArgs e)
		{
			if (!m_bInitialise)
				return;
			CVersionDonnees vSourceSelec = VersionSourceSelectionnee;
			if (IdsVersionsSourcesPossibles.Count > 0)
			{
				m_txtSelectVersionSource.InitAvecFiltreDeBase<CVersionDonnees>(
                    "Libelle",
					new CFiltreData(CVersionDonnees.c_champId + " in(" + string.Join(",", IdsVersionsSourcesPossibles.ToArray()) + ")"),
                    true);
			}
			else
			{
				m_txtSelectVersionSource.InitAvecFiltreDeBase<CVersionDonnees>(
                    "Libelle",
					new CFiltreDataImpossible(), 
                    true);
			}
			VersionSourceSelectionnee = vSourceSelec;

		}


		private Dictionary<string, string> m_mappTypes = new Dictionary<string, string>();
		private List<string> m_lstTypesSelec = new List<string>();
		private void CalcTypesPossibles()
		{
			m_mappTypes = new Dictionary<string, string>();
			foreach (CAuditVersionParametrageTypeEntite paramType in m_audit.TypeAudit.ParametrageObject.TypesParametres)
				m_mappTypes.Add(paramType.NomTypeConvivial, paramType.TypeEntite.ToString());

			m_oldIDTypeAudit = m_audit.TypeAudit.Id;
		}
		private int? m_oldIDTypeAudit;
		private void InitTypes()
		{
			m_lstTypes.Items.Clear();
			m_lstEntities.Items.Clear();
			m_ctrlOperations.Init(null);

			if(m_oldIDTypeAudit == null || m_oldIDTypeAudit.Value != m_audit.TypeAudit.Id)
				CalcTypesPossibles();
			foreach(string strType in m_mappTypes.Keys)
			{
				ListViewItem itm = new ListViewItem(strType);
				itm.Tag = m_mappTypes[strType];
				m_lstTypes.Items.Add(itm);
				itm.Checked = m_lstTypesSelec.Contains(strType);
			}
		}
		private void m_lstTypes_ItemChecked(object sender, ItemCheckedEventArgs e)
		{
			if (!m_bInitialise)
				return;
			string strTypeConcerne = (string)e.Item.Tag;
			if (e.Item.Checked)
			{
				if (!m_lstTypesSelec.Contains(strTypeConcerne))
					m_lstTypesSelec.Add(strTypeConcerne);
			}
			else
				m_lstTypesSelec.Remove(strTypeConcerne);

			InitEntities();
		}

		private void InitEntities()
		{
			m_lstEntities.Items.Clear();
			m_ctrlOperations.Init(null);
			List<string> lstTypes = new List<string>();
			foreach (string strType in m_lstTypesSelec)
				lstTypes.Add(strType);
			if (lstTypes.Count == 0)
				return;
			//lstTypes.Count > 1
			List<CAuditVersionObjet> entites = m_audit.GetEntities(IdVersionSourceSelectionnee, IdVersionCibleSelectionnee, lstTypes);
			foreach (CAuditVersionObjet entite in entites)
			{
				ListViewItem itm = new ListViewItem(entite.Description);
				itm.SubItems.Add(entite.TypeElementConvivial);
				itm.Tag = entite;
				m_lstEntities.Items.Add(itm);
			}
		}
		private void m_lstEntities_SelectedIndexChanged(object sender, EventArgs e)
		{
			InitOperations();
		}

		private CAuditVersionObjet CAVOSelectionne
		{
			get
			{
				if (m_lstEntities.SelectedItems.Count == 1)
					return (CAuditVersionObjet)m_lstEntities.SelectedItems[0].Tag;
				return null;
			}
		}
		private void InitOperations()
		{
			//m_lstOperations.Items.Clear();
			m_ctrlOperations.Init(CAVOSelectionne);

			//if (CAVOSelectionne != null)
			//{
			//    //CListeObjetsDonnees cavoos = CAVOSelectionne.Datas;
			//    //foreach (CAuditVersionObjetOperation cavoo in cavoos)
			//    //{
			//    //    ListViewItem itm = new ListViewItem(cavoo.TypeOperation.Libelle);
			//    //    itm.SubItems.Add(cavoo.NomChamp);
			//    //    itm.SubItems.Add(cavoo.ValChampSourceString);
			//    //    itm.SubItems.Add(cavoo.ValChampCibleString);
			//    //    m_lstOperations.Items.Add(itm);
			//    //}
			//}
		}

		

	



	}
}
