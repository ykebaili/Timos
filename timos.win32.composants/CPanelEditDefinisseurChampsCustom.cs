using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using sc2i.common;
using sc2i.data;
using sc2i.data.dynamic;
using sc2i.win32.common;
using sc2i.win32.data.navigation;

namespace timos.win32.composants
{
	/// <summary>
	/// Description résumée de CPanelEditDefinisseurChampsCustom.
	/// </summary>
	public class CPanelEditDefinisseurChampsCustom : System.Windows.Forms.UserControl, IControlALockEdition
	{

		//objet pour lequel on est en train d'éditer l'ordre
		private CObjetDonnee m_lastObjetEditionOrdre = null;

        private bool m_bAvecAffectationDirecteDesChamps = false;

		private IDefinisseurChampCustomRelationObjetDonnee m_definisseur = null;
		private Type m_typeFormGererChamps = null;
		private Type m_typeFormGererFormulaires = null;
		private bool m_bIsLock = false;
		private System.Windows.Forms.LinkLabel m_lnkFormulaire;
		private sc2i.win32.data.navigation.CPanelListeRelationSelection m_panelListeFormulaires;
		private System.Windows.Forms.LinkLabel m_lnkNewChampCustom;
		private sc2i.win32.data.navigation.CPanelListeRelationSelection m_panelListeChampsCustom;
		private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn1;
		private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn2;
		private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn3;
		private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn4;
		private System.Windows.Forms.Label label1;
		private sc2i.win32.common.C2iNumericUpDown m_numUpDownOrdre;
        private SplitContainer m_splitContainer;
        private Panel m_panelConteneurGererChamps;
        private Panel m_panelConteneurGererFormulaires;
		/// <summary> 
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CPanelEditDefinisseurChampsCustom()
		{
			// Cet appel est requis par le Concepteur de formulaires Windows.Forms.
			InitializeComponent();

			// TODO : ajoutez les initialisations après l'appel à InitForm

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

        //----------------------------------------------
        public bool AvecAffectationDirecteDeChamps
        {
            set
            {
                m_bAvecAffectationDirecteDesChamps = value;
            }
            get
            {
                return m_bAvecAffectationDirecteDesChamps;
            }

        }


		

		#region Component Designer generated code
		/// <summary> 
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.m_lnkFormulaire = new System.Windows.Forms.LinkLabel();
            this.m_panelListeFormulaires = new sc2i.win32.data.navigation.CPanelListeRelationSelection();
            this.listViewAutoFilledColumn4 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.listViewAutoFilledColumn2 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_lnkNewChampCustom = new System.Windows.Forms.LinkLabel();
            this.m_panelListeChampsCustom = new sc2i.win32.data.navigation.CPanelListeRelationSelection();
            this.listViewAutoFilledColumn3 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.listViewAutoFilledColumn1 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.m_numUpDownOrdre = new sc2i.win32.common.C2iNumericUpDown();
            this.m_splitContainer = new System.Windows.Forms.SplitContainer();
            this.m_panelConteneurGererFormulaires = new System.Windows.Forms.Panel();
            this.m_panelConteneurGererChamps = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.m_numUpDownOrdre)).BeginInit();
            this.m_splitContainer.Panel1.SuspendLayout();
            this.m_splitContainer.Panel2.SuspendLayout();
            this.m_splitContainer.SuspendLayout();
            this.m_panelConteneurGererFormulaires.SuspendLayout();
            this.m_panelConteneurGererChamps.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_lnkFormulaire
            // 
            this.m_lnkFormulaire.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lnkFormulaire.AutoSize = true;
            this.m_lnkFormulaire.Location = new System.Drawing.Point(181, 11);
            this.m_lnkFormulaire.Name = "m_lnkFormulaire";
            this.m_lnkFormulaire.Size = new System.Drawing.Size(126, 13);
            this.m_lnkFormulaire.TabIndex = 7;
            this.m_lnkFormulaire.TabStop = true;
            this.m_lnkFormulaire.Text = "Form management|30104";
            this.m_lnkFormulaire.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkFormulaire_LinkClicked);
            // 
            // m_panelListeFormulaires
            // 
            this.m_panelListeFormulaires.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelListeFormulaires.Columns.AddRange(new sc2i.win32.common.ListViewAutoFilledColumn[] {
            this.listViewAutoFilledColumn4});
            this.m_panelListeFormulaires.EnableCustomisation = true;
            this.m_panelListeFormulaires.ExclusionParException = false;
            this.m_panelListeFormulaires.Location = new System.Drawing.Point(17, 27);
            this.m_panelListeFormulaires.LockEdition = true;
            this.m_panelListeFormulaires.Name = "m_panelListeFormulaires";
            this.m_panelListeFormulaires.Size = new System.Drawing.Size(299, 232);
            this.m_panelListeFormulaires.TabIndex = 6;
            // 
            // listViewAutoFilledColumn4
            // 
            this.listViewAutoFilledColumn4.Field = "Libelle";
            this.listViewAutoFilledColumn4.PrecisionWidth = 0;
            this.listViewAutoFilledColumn4.ProportionnalSize = false;
            this.listViewAutoFilledColumn4.Text = "Label|50";
            this.listViewAutoFilledColumn4.Visible = true;
            this.listViewAutoFilledColumn4.Width = 120;
            // 
            // listViewAutoFilledColumn2
            // 
            this.listViewAutoFilledColumn2.Field = "Libelle";
            this.listViewAutoFilledColumn2.PrecisionWidth = 0;
            this.listViewAutoFilledColumn2.ProportionnalSize = false;
            this.listViewAutoFilledColumn2.Text = "Label|50";
            this.listViewAutoFilledColumn2.Visible = true;
            this.listViewAutoFilledColumn2.Width = 177;
            // 
            // m_lnkNewChampCustom
            // 
            this.m_lnkNewChampCustom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lnkNewChampCustom.AutoSize = true;
            this.m_lnkNewChampCustom.Location = new System.Drawing.Point(176, 11);
            this.m_lnkNewChampCustom.Name = "m_lnkNewChampCustom";
            this.m_lnkNewChampCustom.Size = new System.Drawing.Size(125, 13);
            this.m_lnkNewChampCustom.TabIndex = 4;
            this.m_lnkNewChampCustom.TabStop = true;
            this.m_lnkNewChampCustom.Text = "Field management|30105";
            this.m_lnkNewChampCustom.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkNewChampCustom_LinkClicked);
            // 
            // m_panelListeChampsCustom
            // 
            this.m_panelListeChampsCustom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelListeChampsCustom.Columns.AddRange(new sc2i.win32.common.ListViewAutoFilledColumn[] {
            this.listViewAutoFilledColumn3});
            this.m_panelListeChampsCustom.EnableCustomisation = true;
            this.m_panelListeChampsCustom.ExclusionParException = false;
            this.m_panelListeChampsCustom.Location = new System.Drawing.Point(17, 27);
            this.m_panelListeChampsCustom.LockEdition = true;
            this.m_panelListeChampsCustom.Name = "m_panelListeChampsCustom";
            this.m_panelListeChampsCustom.Size = new System.Drawing.Size(295, 196);
            this.m_panelListeChampsCustom.TabIndex = 5;
            this.m_panelListeChampsCustom.OnValideRelation += new sc2i.win32.data.navigation.AssocieDataEventHandler(this.m_panelListeChampsCustom_OnValideRelation);
            this.m_panelListeChampsCustom.OnSelectionChanged += new sc2i.win32.data.navigation.ObjetSelecionneeChangedEventHandler(this.m_panelListeChampsCustom_OnSelectionChanged);
            this.m_panelListeChampsCustom.OnAssocieData += new sc2i.win32.data.navigation.AssocieDataEventHandler(this.m_panelListeChampsCustom_OnAssocieData);
            // 
            // listViewAutoFilledColumn3
            // 
            this.listViewAutoFilledColumn3.Field = "Nom";
            this.listViewAutoFilledColumn3.PrecisionWidth = 0;
            this.listViewAutoFilledColumn3.ProportionnalSize = false;
            this.listViewAutoFilledColumn3.Text = "Name|64";
            this.listViewAutoFilledColumn3.Visible = true;
            this.listViewAutoFilledColumn3.Width = 200;
            // 
            // listViewAutoFilledColumn1
            // 
            this.listViewAutoFilledColumn1.Field = "Nom";
            this.listViewAutoFilledColumn1.PrecisionWidth = 0;
            this.listViewAutoFilledColumn1.ProportionnalSize = false;
            this.listViewAutoFilledColumn1.Text = "Nom";
            this.listViewAutoFilledColumn1.Visible = true;
            this.listViewAutoFilledColumn1.Width = 225;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Location = new System.Drawing.Point(26, 226);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Order|30106";
            // 
            // m_numUpDownOrdre
            // 
            this.m_numUpDownOrdre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_numUpDownOrdre.DoubleValue = 0;
            this.m_numUpDownOrdre.IntValue = 0;
            this.m_numUpDownOrdre.Location = new System.Drawing.Point(96, 224);
            this.m_numUpDownOrdre.LockEdition = false;
            this.m_numUpDownOrdre.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.m_numUpDownOrdre.Name = "m_numUpDownOrdre";
            this.m_numUpDownOrdre.Size = new System.Drawing.Size(82, 20);
            this.m_numUpDownOrdre.TabIndex = 9;
            this.m_numUpDownOrdre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_numUpDownOrdre.ThousandsSeparator = true;
            this.m_numUpDownOrdre.ValueChanged += new System.EventHandler(this.c2iNumericUpDown1_ValueChanged);
            // 
            // m_splitContainer
            // 
            this.m_splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_splitContainer.Location = new System.Drawing.Point(0, 3);
            this.m_splitContainer.Name = "m_splitContainer";
            // 
            // m_splitContainer.Panel1
            // 
            this.m_splitContainer.Panel1.Controls.Add(this.m_panelConteneurGererFormulaires);
            // 
            // m_splitContainer.Panel2
            // 
            this.m_splitContainer.Panel2.Controls.Add(this.m_panelConteneurGererChamps);
            this.m_splitContainer.Size = new System.Drawing.Size(663, 262);
            this.m_splitContainer.SplitterDistance = 332;
            this.m_splitContainer.TabIndex = 10;
            // 
            // m_panelConteneurGererFormulaires
            // 
            this.m_panelConteneurGererFormulaires.Controls.Add(this.m_panelListeFormulaires);
            this.m_panelConteneurGererFormulaires.Controls.Add(this.m_lnkFormulaire);
            this.m_panelConteneurGererFormulaires.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelConteneurGererFormulaires.Location = new System.Drawing.Point(0, 0);
            this.m_panelConteneurGererFormulaires.Name = "m_panelConteneurGererFormulaires";
            this.m_panelConteneurGererFormulaires.Size = new System.Drawing.Size(332, 262);
            this.m_panelConteneurGererFormulaires.TabIndex = 10;
            // 
            // m_panelConteneurGererChamps
            // 
            this.m_panelConteneurGererChamps.Controls.Add(this.m_lnkNewChampCustom);
            this.m_panelConteneurGererChamps.Controls.Add(this.m_numUpDownOrdre);
            this.m_panelConteneurGererChamps.Controls.Add(this.label1);
            this.m_panelConteneurGererChamps.Controls.Add(this.m_panelListeChampsCustom);
            this.m_panelConteneurGererChamps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelConteneurGererChamps.Location = new System.Drawing.Point(0, 0);
            this.m_panelConteneurGererChamps.Name = "m_panelConteneurGererChamps";
            this.m_panelConteneurGererChamps.Size = new System.Drawing.Size(327, 262);
            this.m_panelConteneurGererChamps.TabIndex = 10;
            // 
            // CPanelEditDefinisseurChampsCustom
            // 
            this.Controls.Add(this.m_splitContainer);
            this.Name = "CPanelEditDefinisseurChampsCustom";
            this.Size = new System.Drawing.Size(666, 268);
            this.Load += new System.EventHandler(this.CPanelEditDefinisseurChampsCustom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_numUpDownOrdre)).EndInit();
            this.m_splitContainer.Panel1.ResumeLayout(false);
            this.m_splitContainer.Panel2.ResumeLayout(false);
            this.m_splitContainer.ResumeLayout(false);
            this.m_panelConteneurGererFormulaires.ResumeLayout(false);
            this.m_panelConteneurGererFormulaires.PerformLayout();
            this.m_panelConteneurGererChamps.ResumeLayout(false);
            this.m_panelConteneurGererChamps.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		/// ////////////////////////////////////////////////////////////////////////
		public void InitPanel 
			( 
			IDefinisseurChampCustomRelationObjetDonnee definisseur,
			Type typeFormGererChamps,
			Type typeFormGererFormulaires
			)
		{
			m_definisseur = definisseur;
			m_typeFormGererChamps = typeFormGererChamps;
			m_typeFormGererFormulaires = typeFormGererFormulaires;

            if (m_bAvecAffectationDirecteDesChamps)
            {
                CListeObjetsDonnees listeChamps = new CListeObjetsDonnees(definisseur.ContexteDonnee, typeof(CChampCustom));
                listeChamps.Filtre = CChampCustom.GetFiltreChampsForRole(definisseur.RoleChampCustomDesElementsAChamp.CodeRole);

                m_panelListeChampsCustom.Init(
                    listeChamps,
                    m_definisseur.RelationsChampsCustomListe,
                    (CObjetDonneeAIdNumeriqueAuto)definisseur,
                    "Definisseur",
                    "ChampCustom"
                    );
            }

			CListeObjetsDonnees listeFormulaires = new CListeObjetsDonnees(definisseur.ContexteDonnee, typeof(CFormulaire));
            listeFormulaires.Filtre = CFormulaire.GetFiltreFormulairesForRole(definisseur.RoleChampCustomDesElementsAChamp.CodeRole);
            //listeFormulaires.Filtre = new CFiltreData(CFormulaire.c_champCodeRole + "=@1", definisseur.RoleChampCustomDesElementsAChamp.CodeRole);
			m_panelListeFormulaires.Init(
				listeFormulaires,
				m_definisseur.RelationsFormulairesListe,
				(IObjetAContexteDonnee)definisseur,
				"Definisseur",
				"Formulaire"
				);

			m_panelListeChampsCustom.RemplirGrille();
			m_panelListeFormulaires.RemplirGrille();

            if ( !m_bAvecAffectationDirecteDesChamps )
                m_panelConteneurGererChamps.Visible = false;
		}

		/// ////////////////////////////////////////////////////////////////////////
		public CResultAErreur MAJ_Champs()
		{
			m_panelListeChampsCustom.ApplyModifs();
			m_panelListeFormulaires.ApplyModifs();
			return CResultAErreur.True;
		}

		/// ////////////////////////////////////////////////////////////////////////
		private string CodeRole
		{
			get
			{
				if ( m_definisseur != null )
                    return m_definisseur.RoleChampCustomDesElementsAChamp.CodeRole;
				return "";
			}
		}

		/// ////////////////////////////////////////////////////////////////////////
		private void m_lnkNewChampCustom_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			CFormNavigateurPopupListe.Show((CFormListeStandard)Activator.CreateInstance(m_typeFormGererChamps, new object[]{CodeRole}));
			InitPanel ( m_definisseur, m_typeFormGererChamps, m_typeFormGererFormulaires );
		}

		private void m_lnkFormulaire_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			CFormNavigateurPopupListe.Show((CFormListeStandard)Activator.CreateInstance(m_typeFormGererFormulaires,new object[]{CodeRole}) );
			InitPanel ( m_definisseur, m_typeFormGererChamps, m_typeFormGererFormulaires );
		}

		private void c2iNumericUpDown1_ValueChanged(object sender, System.EventArgs e)
		{
		
		}

		private void CPanelEditDefinisseurChampsCustom_Load(object sender, System.EventArgs e)
		{
		
		}

		/// ////////////////////////////////////////////////////////////////////////
		private void m_panelListeChampsCustom_OnAssocieData(sc2i.data.CObjetDonnee objet, sc2i.data.CObjetDonnee relation, ref object dataAAssocier)
		{
			if ( relation == null )
				dataAAssocier = 0;
			else
				dataAAssocier = ((IRelationDefinisseurChamp_ChampCustom)relation).Ordre;
		}

		/// ////////////////////////////////////////////////////////////////////////
		private void m_panelListeChampsCustom_OnSelectionChanged(sc2i.data.CObjetDonnee objet, object dataAssocie)
		{
			if ( m_lastObjetEditionOrdre != null )
				m_panelListeChampsCustom.SetDataAssocie ( m_lastObjetEditionOrdre, (int)m_numUpDownOrdre.IntValue );
			m_lastObjetEditionOrdre = objet;
			object data = m_panelListeChampsCustom.GetDataAssocie ( objet );
			if ( data is int )
				m_numUpDownOrdre.IntValue = (int)data;
			else
				m_numUpDownOrdre.IntValue = 0;
		}

		private void m_panelListeChampsCustom_OnValideRelation(sc2i.data.CObjetDonnee objet, sc2i.data.CObjetDonnee relation, ref object dataAssocie)
		{
			if ( (relation  is IRelationDefinisseurChamp_ChampCustom) && dataAssocie is int )
			{
				((IRelationDefinisseurChamp_ChampCustom)relation).Ordre = (int)dataAssocie;
			}
		}

		/// ////////////////////////////////////////////////////////////////////////
		public event EventHandler OnChangeLockEdition; 
		public bool LockEdition
		{
			get
			{
				return m_bIsLock;
			}
			set
			{
				m_bIsLock = value;
				m_panelListeChampsCustom.LockEdition = m_bIsLock;
				m_panelListeFormulaires.LockEdition = m_bIsLock;
				m_numUpDownOrdre.LockEdition = m_bIsLock;

				if ( OnChangeLockEdition != null )
					OnChangeLockEdition(this, new EventArgs());
			}
        }
	}

   
}
