using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using sc2i.common;
using sc2i.data;
using timos.securite;
using sc2i.win32.common;
using sc2i.data.dynamic;

namespace timos
{
	public partial class CPanelAffectationEO : UserControl, IControlALockEdition
	{
		Hashtable m_tableEOToRelation = new Hashtable();
		private IElementAEO m_elementEdite = null;

		public CPanelAffectationEO()
		{
			InitializeComponent();

			
		}

		//---------------------------------------------------------
		public bool LockEdition
		{
			get
			{
				return !m_gestionnaireModeEdition.ModeEdition;
			}
			set
			{
				bool bChanged = m_gestionnaireModeEdition.ModeEdition == value;
				m_gestionnaireModeEdition.ModeEdition = !value;
				if ( bChanged && OnChangeLockEdition != null )
					OnChangeLockEdition ( this, new EventArgs() );
				if (bChanged)
					Init(m_elementEdite);
			}
		}

		//---------------------------------------------------------
		public event EventHandler OnChangeLockEdition;

		//---------------------------------------------------------
		private bool m_bIsInitialising = false;
		public void Init(IElementAEO element)
		{
			m_arbre.BeginUpdate();
			m_panelChamps.ElementEdite = null;
			m_panelChamps.InitPanel(null, null);
			m_arbre.Nodes.Clear();
			m_elementEdite = element;
			if ( element == null )
				return;
			CListeObjetsDonnees listeRelations = CRelationElement_EO.GetListeRelationsForElement((CObjetDonneeAIdNumerique)element);
			CFiltreData filtre = null;
			if ( !m_gestionnaireModeEdition.ModeEdition )
			{
				
				string strIds = "";
				
				foreach ( CRelationElement_EO rel in  listeRelations )
					strIds += rel.EntiteOrganisationnelle.Id+",";
				if (strIds != "")
				{
					strIds = strIds.Substring(0, strIds.Length - 1);
					filtre = new CFiltreData(CEntiteOrganisationnelle.c_champId + " in (" +
						strIds + ")");
				}
				else
					filtre = new CFiltreDataImpossible();
			}

            // Filtre les Entités qu'on a le droit de voir dans l'interface (gestion des exceptions sur Type d'EO)
            Type tpElement = element.GetType();

            CListeObjetDonneeGenerique<CEntiteOrganisationnelle> lstEO = new CListeObjetDonneeGenerique<CEntiteOrganisationnelle>(element.ContexteDonnee);
            List<string> lstIdsEOsNePasAfficher = new List<string>();
            foreach (CEntiteOrganisationnelle eo in lstEO)
            {
                if (eo.TypeEntite != null && eo.TypeEntite.HasExceptionForType(tpElement))
                {
                    lstIdsEOsNePasAfficher.Add(eo.Id.ToString());
                }
            }
            if (lstIdsEOsNePasAfficher.Count > 0)
            {
                string strIdsEOsNePasAfficher = String.Join(",", lstIdsEOsNePasAfficher.ToArray());
                filtre = CFiltreData.GetAndFiltre
                    (filtre, 
                    new CFiltreData(CEntiteOrganisationnelle.c_champId + " not in (" +
                        strIdsEOsNePasAfficher + ")"));
            }

			m_arbre.Init ( typeof ( CEntiteOrganisationnelle ),
				"EntiteFilles",
				CEntiteOrganisationnelle.c_champIdParent,
				"Libelle",
				filtre,
				null);

			m_bIsInitialising = true;
			m_tableEOToRelation.Clear();
			foreach ( CRelationElement_EO rel in listeRelations )
			{
				m_tableEOToRelation[rel.EntiteOrganisationnelle] = rel;
				m_arbre.SetChecked ( rel.EntiteOrganisationnelle, true );
				TreeNode node = m_arbre.GetNodeFor(rel.EntiteOrganisationnelle);
				while (node != null)
				{
					node = node.Parent;
					if (node != null)
						node.Expand();
				}
				//m_arbre.EnsureVisible ( rel.EntiteOrganisationnelle );
			}
			m_bIsInitialising = false;
			m_arbre.EndUpdate();

			BeginInvoke(new FillHeritageDelegate( FillHeritage));
		}

		//---------------------------------------------------------
		public CResultAErreur MajChamps()
		{
			if (m_panelChamps.ElementEdite != null)
				m_panelChamps.AffecteValeursToElement();
			CResultAErreur result = CResultAErreur.True;
			Hashtable tableRelationsToDelete = new Hashtable();
			Hashtable tableEntiteToRelation = new Hashtable();
			foreach (CRelationElement_EO rel in CRelationElement_EO.GetListeRelationsForElement((CObjetDonneeAIdNumerique)m_elementEdite))
			{
				tableRelationsToDelete[rel.EntiteOrganisationnelle] = true;
				tableEntiteToRelation[rel.EntiteOrganisationnelle] = rel;
			}

			ArrayList lstSelected = new ArrayList();
			foreach (CEntiteOrganisationnelle entite in m_arbre.ElementsSelectionnes)
			{
				bool bShouldAdd = true;
				foreach (CEntiteOrganisationnelle entiteTest in lstSelected.ToArray())
				{
					if (entiteTest.IsChildOf(entite))
						lstSelected.Remove(entiteTest);
					if (entiteTest.IsParentOf(entite))
					{
						bShouldAdd = false;
						break;
					}
				}
				if (bShouldAdd)
				{
					lstSelected.Add(entite);
				}
			}

			foreach (CEntiteOrganisationnelle entite in lstSelected)
			{
				tableRelationsToDelete[entite] = false;
				if (tableEntiteToRelation[entite] == null)
				{
					CRelationElement_EO rel = new CRelationElement_EO(m_elementEdite.ContexteDonnee);
					rel.CreateNewInCurrentContexte();
					rel.EntiteOrganisationnelle = entite;
					rel.ElementLie = (CObjetDonneeAIdNumerique)m_elementEdite;
				}
			}

			foreach (DictionaryEntry entry in tableRelationsToDelete)
			{
				if ((bool)entry.Value)
				{
					CRelationElement_EO rel = (CRelationElement_EO)tableEntiteToRelation[entry.Key];
					result = rel.Delete();
					if (!result)
						return result;
				}
			}
			return result;
		}

		//---------------------------------------------------------
		private void m_arbre_BeforeCheck(object sender, TreeViewCancelEventArgs e)
		{
			if (!m_gestionnaireModeEdition.ModeEdition && !m_bIsInitialising)
				e.Cancel = true;
		}

		//---------------------------------------------------------
		private void ChangeElementAChamps(object element)
		{
			if (m_panelChamps.ElementEdite != null)
				m_panelChamps.AffecteValeursToElement();
			if (element != null)
			{
				IDefinisseurChampCustom[] definisseurs = ((IElementAChamps)element).DefinisseursDeChamps;
				if (definisseurs.Length != 0)
				{
					IDefinisseurChampCustom definisseur = definisseurs[0];
					IRelationDefinisseurChamp_Formulaire[] rels = definisseur.RelationsFormulaires;
					if (rels.Length > 0)
					{
						CFormulaire formulaire = rels[0].Formulaire;
						m_panelChamps.InitPanel(formulaire.Formulaire, element);
						return;
					}
				}
			}
			m_panelChamps.InitPanel(null, null);

		}

		//---------------------------------------------------------
		public event EventHandler OnChangeEOS;
		private void m_arbre_AfterCheck(object sender, TreeViewEventArgs e)
		{
			if (m_bIsInitialising)
				return;
			if (e.Node.Checked)
			{
				CRelationElement_EO relSel = (CRelationElement_EO)m_tableEOToRelation[e.Node.Tag];
				if (relSel == null)
				{
					foreach (CRelationElement_EO rel in CRelationElement_EO.GetListeRelationsForElement((CObjetDonneeAIdNumerique)m_elementEdite))
						if (rel.EntiteOrganisationnelle.Id == ((CObjetDonneeAIdNumerique)m_arbre.GetObjetInNode(e.Node)).Id)
						{
							relSel = rel;
							break;
						}
					if (relSel == null)
					{
						relSel = new CRelationElement_EO(m_elementEdite.ContexteDonnee);
						relSel.CreateNewInCurrentContexte();
						relSel.ElementLie = (CObjetDonneeAIdNumerique)m_elementEdite;
						relSel.EntiteOrganisationnelle = (CEntiteOrganisationnelle)m_arbre.GetObjetInNode(e.Node);
					}
					m_tableEOToRelation[(CEntiteOrganisationnelle)m_arbre.GetObjetInNode(e.Node)] = relSel;
				}
				if (e.Node.IsSelected)
					ChangeElementAChamps(relSel);
			}
			else
				ChangeElementAChamps(null);
			if (OnChangeEOS != null)
				OnChangeEOS(this, new EventArgs());
		}

		//---------------------------------------------------------
		public List<CEntiteOrganisationnelle> GetCheckedEO()
		{
			List<CEntiteOrganisationnelle> lst = new List<CEntiteOrganisationnelle>();
			foreach (CEntiteOrganisationnelle entite in m_arbre.ElementsSelectionnes)
			{
				lst.Add(entite);
			}
			return lst;
		}

		//------------------------------------------------
		private void m_arbre_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (e.Node.Checked)
			{
				CRelationElement_EO rel = (CRelationElement_EO)m_tableEOToRelation[e.Node];
				if (rel == null)
				{
					CEntiteOrganisationnelle eo = (CEntiteOrganisationnelle)m_arbre.GetObjetInNode(e.Node);
					foreach (CRelationElement_EO relTmp in CRelationElement_EO.GetListeRelationsForElement((CObjetDonneeAIdNumerique)m_elementEdite))
						if (relTmp.EntiteOrganisationnelle.Id == eo.Id)
						{
							rel = relTmp;
							break;
						}
				}

				if (rel != null)
				{
					ChangeElementAChamps(rel);
					return;
				}
			}
			ChangeElementAChamps(null);
		}

		//------------------------------------------------
		private void FillDonnateurs ( IElementAEO elt, List<IElementAEO> lstDonnateurs )
		{
			IElementAEO[] donnateurs = elt.DonnateursEO;
			if (donnateurs != null)
			{
				foreach (IElementAEO parent in donnateurs)
				{
					if (parent != null)
					{
						lstDonnateurs.Add(parent);
						FillDonnateurs(parent, lstDonnateurs);
					}
				}
			}
		}

		//------------------------------------------------
		private TreeNode AddNodeEoHerite(CEntiteOrganisationnelle entite, Dictionary<CEntiteOrganisationnelle, TreeNode> tableEOtoNode)
		{
			if (tableEOtoNode.ContainsKey(entite))
				return tableEOtoNode[entite];
			TreeNode nodeParent = null;
			if ( entite.EntiteParente != null )
				nodeParent = AddNodeEoHerite ( entite.EntiteParente, tableEOtoNode );
			TreeNode node = new TreeNode(entite.Libelle);
			if (nodeParent != null)
				nodeParent.Nodes.Add(node);
			else
				m_arbreHeritage.Nodes.Add(node);
			tableEOtoNode[entite] = node;
			return node;
		}

		//------------------------------------------------
		private delegate void FillHeritageDelegate();
		private bool m_bIsInitHeritage = false;
		private void FillHeritage()
		{
            m_arbreHeritage.BeginUpdate();
			m_bIsInitHeritage = true;
			m_arbreHeritage.Nodes.Clear();
			if (m_elementEdite != null)
			{
				List<IElementAEO> lstDonnateurs = new List<IElementAEO>();
				FillDonnateurs(m_elementEdite, lstDonnateurs);

				Dictionary<CEntiteOrganisationnelle, TreeNode> tableEOtoNode = new Dictionary<CEntiteOrganisationnelle, TreeNode>();
				foreach (IElementAEO elt in lstDonnateurs)
				{
					foreach (CEntiteOrganisationnelle entite in elt.EntiteOrganisationnellesDirectementLiees)
					{
						TreeNode node = AddNodeEoHerite(entite, tableEOtoNode);
						node.Checked = true;
					}
				}
			}
			m_bIsInitHeritage = false;
			m_arbreHeritage.EndUpdate();

            m_panelHeritage.Visible = m_arbreHeritage.Nodes.Count != 0;
		}

		private void m_arbreHeritage_BeforeCheck(object sender, TreeViewCancelEventArgs e)
		{
			if (m_bIsInitHeritage)
				return;
			e.Cancel = true;
		}

			


	}
}
