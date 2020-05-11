using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using sc2i.data;
using sc2i.win32.data.navigation;
using sc2i.workflow;
using sc2i.win32.common;
using sc2i.common;


namespace timos.win32.composants
{
	/// <summary>
	/// Description résumée de CPanelSelectLienToElement.
	/// </summary>
	public class CPanelSelectLienToElement : System.Windows.Forms.UserControl, IControlALockEdition
	{
		private IRelationTypeElementALien_TypeElement m_typeRelation = null;
		private IElementALien m_elementALien = null;
		private CListeObjetsDonnees m_listeRelations = null;

		private bool m_bModeEdition = true;

		private System.Windows.Forms.Label m_lblLibelle;
		private System.Windows.Forms.Button m_btnSelect;
		private System.Windows.Forms.ToolTip m_tooltip;
		private System.Windows.Forms.PictureBox m_btnNoSelection;
		private System.Windows.Forms.LinkLabel m_lnkelement;
		private System.ComponentModel.IContainer components;

		public CPanelSelectLienToElement()
		{
			// Cet appel est requis par le Concepteur de formulaires Windows.Forms.
			InitializeComponent();

			// TODO : ajoutez les initialisations après l'appel à InitializeComponent

		}

		/// <summary> 
		/// Nettoyage des ressources utilisées.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Code généré par le Concepteur de composants
		/// <summary> 
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(CPanelSelectLienToElement));
			this.m_lblLibelle = new System.Windows.Forms.Label();
			this.m_lnkelement = new System.Windows.Forms.LinkLabel();
			this.m_btnSelect = new System.Windows.Forms.Button();
			this.m_btnNoSelection = new System.Windows.Forms.PictureBox();
			this.m_tooltip = new System.Windows.Forms.ToolTip(this.components);
			this.SuspendLayout();
			// 
			// m_lblLibelle
			// 
			this.m_lblLibelle.Location = new System.Drawing.Point(0, 4);
			this.m_lblLibelle.Name = "m_lblLibelle";
			this.m_lblLibelle.Size = new System.Drawing.Size(112, 16);
			this.m_lblLibelle.TabIndex = 0;
			this.m_lblLibelle.Text = "label1";
			// 
			// m_lnkelement
			// 
			this.m_lnkelement.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lnkelement.BackColor = System.Drawing.Color.White;
			this.m_lnkelement.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.m_lnkelement.Location = new System.Drawing.Point(112, 4);
			this.m_lnkelement.Name = "m_lnkelement";
			this.m_lnkelement.Size = new System.Drawing.Size(248, 16);
			this.m_lnkelement.TabIndex = 1;
			this.m_lnkelement.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkelement_LinkClicked);
			// 
			// m_btnSelect
			// 
			this.m_btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_btnSelect.Location = new System.Drawing.Point(360, 4);
			this.m_btnSelect.Name = "m_btnSelect";
			this.m_btnSelect.Size = new System.Drawing.Size(16, 16);
			this.m_btnSelect.TabIndex = 2;
			this.m_btnSelect.Text = "...";
            this.m_tooltip.SetToolTip(this.m_btnSelect, I.T("Select the element|30115"));
			this.m_btnSelect.Click += new System.EventHandler(this.m_btnSelect_Click);
			// 
			// m_btnNoSelection
			// 
			this.m_btnNoSelection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_btnNoSelection.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btnNoSelection.Image = ((System.Drawing.Image)(resources.GetObject("m_btnNoSelection.Image")));
			this.m_btnNoSelection.Location = new System.Drawing.Point(376, 4);
			this.m_btnNoSelection.Name = "m_btnNoSelection";
			this.m_btnNoSelection.Size = new System.Drawing.Size(16, 16);
			this.m_btnNoSelection.TabIndex = 3;
			this.m_btnNoSelection.TabStop = false;
            this.m_tooltip.SetToolTip(this.m_btnNoSelection, I.T("Select Nothing|30116"));
			this.m_btnNoSelection.Click += new System.EventHandler(this.m_btnNoSelection_Click);
			// 
			// CPanelSelectLienToElement
			// 
			this.Controls.Add(this.m_btnNoSelection);
			this.Controls.Add(this.m_btnSelect);
			this.Controls.Add(this.m_lnkelement);
			this.Controls.Add(this.m_lblLibelle);
			this.Name = "CPanelSelectLienToElement";
			this.Size = new System.Drawing.Size(392, 24);
			this.Load += new System.EventHandler(this.CPanelSelectLienToElement_Load);
			this.ResumeLayout(false);

		}
		#endregion

		/// ///////////////////////////////////////////////
		private void CPanelSelectLienToElement_Load(object sender, System.EventArgs e)
		{
		
		}

		/// ///////////////////////////////////////////////
		private CListeObjetsDonnees ListeRelations

		{
			get
			{
				if ( m_listeRelations != null )
					return m_listeRelations;
				if(  m_elementALien == null )
					return null;
				CListeObjetsDonnees liste = m_elementALien.RelationsElements;
				liste.Filtre = new CFiltreData ( m_typeRelation.GetChampId()+"=@1",
					m_typeRelation.Id );
				m_listeRelations = liste;
				return m_listeRelations;
			}
		}

		/// ///////////////////////////////////////////////
		public void Init ( IRelationTypeElementALien_TypeElement typeRelation, IElementALien element)
		{
			m_typeRelation = typeRelation;
			m_elementALien = element;
			m_lblLibelle.Text = typeRelation.Libelle;
			RefreshText();
		}

		/// ///////////////////////////////////////////////
		public IRelationTypeElementALien_TypeElement TypeRelation
		{
			get
			{
				return m_typeRelation;
			}
		}

		/// ///////////////////////////////////////////////
		private void m_btnNoSelection_Click(object sender, System.EventArgs e)
		{
			DeleteAll();
		}

		/// ///////////////////////////////////////////////
		private void DeleteAll()
		{
			if ( ListeRelations.Count > 1 )
			{
                if (CFormAlerte.Afficher(I.T("You are about to dissociate @1 elements from this agenda entry. Do you confirm ?|30117", ListeRelations.Count.ToString()),
                    EFormAlerteType.Question) == DialogResult.No)
					return;
			}
			using ( CWaitCursor waiter = new CWaitCursor() )
			{
				ArrayList lst = new ArrayList ( ListeRelations );
				foreach ( IRelationElementALien_Element rel in lst )
					rel.Delete();
			}
			RefreshText();
		}

		/// <summary>
		/// 
		/// </summary>
		public void RefreshText()
		{
			CListeObjetsDonnees listeRel = ListeRelations;
			if ( listeRel.Count == 0 )
                m_lnkelement.Text = I.T("None|30082");
			else if ( listeRel.Count == 1 )
			{
				m_lnkelement.Text = ((IRelationElementALien_Element)listeRel[0]).ElementLie.DescriptionElement;
			}
			else
			{
                m_lnkelement.Text = listeRel.Count + I.T(" selected elements|30118");
			}
		}

		private void m_btnSelect_Click(object sender, System.EventArgs e)
		{
			if ( m_typeRelation.Multiple )
			{
				SelectionMultiples();
				RefreshText();
			}
			else
			{
				Type typeForm = CFormFinder.GetTypeFormToList(m_typeRelation.TypeElements);
				if ( typeForm == null || !typeForm.IsSubclassOf(typeof(CFormListeStandard)))
				{
                    CFormAlerte.Afficher(I.T("The system cannot list elements from type @1|30119", m_typeRelation.TypeElementsConvivial), EFormAlerteType.Exclamation); 
                    return;
				}
				CObjetDonneeAIdNumerique objetSel;
				CFormListeStandard form = (CFormListeStandard)Activator.CreateInstance(typeForm, new object[]{});
				form.FiltreDeBase = m_typeRelation.FiltreDataAssocie;
				objetSel = (CObjetDonneeAIdNumerique)CFormNavigateurPopupListe.SelectObject ( form, null, CFormNavigateurPopupListe.CalculeContexteUtilisation ( this ) );
				if ( objetSel != null )
				{
					if ( ListeRelations.Count > 1 )
						DeleteAll();
					m_elementALien.AddElementLie ( objetSel, m_typeRelation.Code );
					RefreshText();
				}
						
			}
		}

		private void SelectionMultiples()
		{
			CListeObjetsDonnees liste = ListeRelations;
			CObjetDonneeAIdNumerique[]elts = (CObjetDonneeAIdNumerique[])CInterpreteurTextePropriete.CreateListeFrom (
				liste, "ElementLie", typeof(CObjetDonneeAIdNumerique));
			elts = CFormSelectElementsMultiples.GetListeElements ( 
				m_typeRelation.TypeElements,
				m_typeRelation.FiltreDataAssocie,
				elts );
			if ( elts != null )
			{
				using ( CWaitCursor waiter = new CWaitCursor() )
				{
					//Table Entite->Vrai si existe dans les deux liste
					//			->Faux si existe uniquement dans l'ancienne liste (à supprimer)
					//			->Null si existe uniquement dans la nouvelle liste (à créer)
					Hashtable tableExistants = new Hashtable();
					foreach ( IRelationElementALien_Element rel in ListeRelations )
						tableExistants[rel.ElementLie] = false;
					foreach ( CObjetDonneeAIdNumerique objet in elts )
					{
						if ( tableExistants[objet] == null )//création
						{
							m_elementALien.AddElementLieSurType ( objet, m_typeRelation );
						}
						else
							tableExistants[objet] = true;
					}
					//Supprime ceux qui doivent être supprimés
					foreach ( IRelationElementALien_Element rel in ListeRelations.ToArrayList() )
					{
						object val = tableExistants[rel.ElementLie];
						if ( val is bool && ((bool)val)==false )
							rel.Delete();
					}
				}
			}
			RefreshText();
		}

		private void m_lnkelement_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{

			if ( ListeRelations.Count == 0 )
				return;
			CObjetDonneeAIdNumeriqueAuto objet = null;
			if ( ListeRelations.Count > 1 )
			{
				ArrayList lst = new ArrayList();
				foreach ( IRelationElementALien_Element rel in ListeRelations )
				{
					lst.Add ( rel.ElementLie );
				}
				Point pt = m_lnkelement.PointToScreen(new Point(0, m_lnkelement.Height));
                objet = CFormLinksToElements.SelectObjet((CObjetDonneeAIdNumerique[])lst.ToArray(typeof(CObjetDonneeAIdNumerique)),
                    pt) as CObjetDonneeAIdNumeriqueAuto;
			}
			else
				objet = ((IRelationElementALien_Element)ListeRelations[0]).ElementLie as CObjetDonneeAIdNumeriqueAuto;
			if ( objet != null )
			{
                //Type typeForm = CFormFinder.GetTypeFormToEdit(objet.GetType());
                //if ( typeForm == null || !typeForm.IsSubclassOf(typeof(CFormEditionStandard)))
                //{
                //    CFormAlerte.Afficher("Le système ne sait pas afficher les éléments du type "+m_typeRelation.TypeElementsConvivial, EFormAlerteType.Exclamation);
                //    return;
                //}
                //CFormEditionStandard form = (CFormEditionStandard)Activator.CreateInstance(typeForm, new object[]{objet});
                CReferenceTypeForm refTypeForm = CFormFinder.GetRefFormToEdit(objet.GetType());
                if (refTypeForm == null)
                {
                    CFormAlerte.Afficher(I.T("The system cannot display elements from type @1|30120", m_typeRelation.TypeElementsConvivial), EFormAlerteType.Exclamation);
                    return;
                }
                else
                {
                    CFormEditionStandard form = refTypeForm.GetForm(objet) as CFormEditionStandard;
                    if(form != null)
                        CSc2iWin32DataNavigation.Navigateur.AffichePage(form);
                }
			}
		}

		public event EventHandler OnChangeLockEdition;
		public bool LockEdition
		{
			get
			{
				return m_bModeEdition;
			}
			set
			{
				m_bModeEdition = !value;
				m_btnSelect.Visible = m_bModeEdition;
				m_btnNoSelection.Visible = m_bModeEdition;
				m_lnkelement.Enabled = !m_bModeEdition;
				if ( OnChangeLockEdition != null )
					OnChangeLockEdition ( this, new EventArgs() );
			}
		}

		

		
	}
}
