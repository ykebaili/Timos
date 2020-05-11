using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

using System.Windows.Forms;

using timos.data;
using sc2i.data.dynamic;
using sc2i.data;
using sc2i.win32.navigation;
using sc2i.win32.data.navigation;
using sc2i.common;
using sc2i.win32.data;
using sc2i.win32.common;

using sc2i.process;

namespace timos
{
    [sc2i.win32.data.navigation.ObjectEditeur(typeof(CTypeTableParametrable))]
    public class CFormEditionTypeTableParametrable : CFormEditionStdTimos, IFormNavigable
	{
		#region Designer generated code

		private System.Windows.Forms.Label label1;
		private ListViewAutoFilled m_wndListeFormatNumerotation;
		private ListViewAutoFilledColumn listViewAutoFilledColumn4;
		private ListViewAutoFilledColumn listViewAutoFilledColumn1;
		private CControlEditionTypeTableParametrable m_ctrlEditTypeTable;
        private System.ComponentModel.IContainer components = null;



		//-------------------------------------------------------------------------
		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.m_ctrlEditTypeTable = new timos.CControlEditionTypeTableParametrable();
            this.m_wndListeFormatNumerotation = new sc2i.win32.common.ListViewAutoFilled();
            this.listViewAutoFilledColumn1 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.listViewAutoFilledColumn4 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.SuspendLayout();
            // 
            // m_panelMenu
            // 
            this.m_panelMenu.Size = new System.Drawing.Size(747, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label1, "");
            this.label1.Location = new System.Drawing.Point(16, 12);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 4002;
            this.label1.Text  = "Label|50";
            // 
            // m_ctrlEditTypeTable
            // 
            this.m_ctrlEditTypeTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_ctrlEditTypeTable, "");
            this.m_ctrlEditTypeTable.Location = new System.Drawing.Point(0, 56);
            this.m_ctrlEditTypeTable.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_ctrlEditTypeTable, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_ctrlEditTypeTable.Name = "m_ctrlEditTypeTable";
            this.m_ctrlEditTypeTable.Size = new System.Drawing.Size(735, 436);
            this.m_extStyle.SetStyleBackColor(this.m_ctrlEditTypeTable, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_ctrlEditTypeTable, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ctrlEditTypeTable.TabIndex = 3;
            // 
            // m_wndListeFormatNumerotation
            // 
            this.m_wndListeFormatNumerotation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_wndListeFormatNumerotation.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewAutoFilledColumn1,
            this.listViewAutoFilledColumn4});
            this.m_wndListeFormatNumerotation.EnableCustomisation = true;
            this.m_wndListeFormatNumerotation.FullRowSelect = true;
            this.m_wndListeFormatNumerotation.HideSelection = false;
            this.m_extLinkField.SetLinkField(this.m_wndListeFormatNumerotation, "");
            this.m_wndListeFormatNumerotation.Location = new System.Drawing.Point(12, 54);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeFormatNumerotation, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_wndListeFormatNumerotation.MultiSelect = false;
            this.m_wndListeFormatNumerotation.Name = "m_wndListeFormatNumerotation";
            this.m_wndListeFormatNumerotation.Size = new System.Drawing.Size(238, 193);
            this.m_extStyle.SetStyleBackColor(this.m_wndListeFormatNumerotation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeFormatNumerotation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeFormatNumerotation.TabIndex = 4006;
            this.m_wndListeFormatNumerotation.UseCompatibleStateImageBehavior = false;
            this.m_wndListeFormatNumerotation.View = System.Windows.Forms.View.Details;
            // 
            // listViewAutoFilledColumn1
            // 
            this.listViewAutoFilledColumn1.Field = "Libelle";
            this.listViewAutoFilledColumn1.PrecisionWidth = 0;
            this.listViewAutoFilledColumn1.ProportionnalSize = false;
            this.listViewAutoFilledColumn1.Text = "Label|50";
            this.listViewAutoFilledColumn1.Visible = true;
            this.listViewAutoFilledColumn1.Width = 120;
            // 
            // listViewAutoFilledColumn4
            // 
            this.listViewAutoFilledColumn4.Field = "FormatNumerotation.Libelle";
            this.listViewAutoFilledColumn4.PrecisionWidth = 0;
            this.listViewAutoFilledColumn4.ProportionnalSize = false;
            this.listViewAutoFilledColumn4.Text = "Type|54";
            this.listViewAutoFilledColumn4.Visible = true;
            this.listViewAutoFilledColumn4.Width = 110;
            // 
            // CFormEditionTypeTableParametrable
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(747, 504);
            this.Controls.Add(this.m_ctrlEditTypeTable);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CFormEditionTypeTableParametrable";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Controls.SetChildIndex(this.m_ctrlEditTypeTable, 0);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.ResumeLayout(false);

		}
		#endregion

		public CFormEditionTypeTableParametrable()
            : base()
        {
            // Cet appel est requis par le Concepteur Windows Form.
            InitializeComponent();
        }
        //-------------------------------------------------------------------------
        public CFormEditionTypeTableParametrable(CTypeTableParametrable TypeTable)
			: base(TypeTable)
        {
            // Cet appel est requis par le Concepteur Windows Form.
            InitializeComponent();
        }
        //-------------------------------------------------------------------------
		public CFormEditionTypeTableParametrable(CTypeTableParametrable TypeTable, CListeObjetsDonnees liste)
			: base(TypeTable, liste)
        {
            // Cet appel est requis par le Concepteur Windows Form.
            InitializeComponent();
		}

		//-------------------------------------------------------------------------
        private CTypeTableParametrable TypeTableParametrable
        {
            get { return (CTypeTableParametrable)ObjetEdite; }
		}
		//-------------------------------------------------------------------------
        protected override CResultAErreur MyInitChamps()
        {
            CResultAErreur result = base.MyInitChamps();
			AffecterTitre(I.T( "Custom table type @1|1213", TypeTableParametrable.Libelle));

			m_ctrlEditTypeTable.Init(TypeTableParametrable);

            return result;
        }

		//-------------------------------------------------------------------------
		protected override CResultAErreur MAJ_Champs()
		{
			CResultAErreur result = base.MAJ_Champs();

			if (result)
				result = m_ctrlEditTypeTable.MajChamps();
			return result;
		}


	}
}

