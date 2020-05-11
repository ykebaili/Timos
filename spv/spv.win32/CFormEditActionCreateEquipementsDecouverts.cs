using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using sc2i.expression;
using sc2i.process;
using sc2i.common;
using sc2i.data;
using spv.data;
using sc2i.win32.process;
using timos.data;
using sc2i.win32.data;

namespace spv.win32
{
	[AutoExec("Autoexec")]
	public class CFormEditActionCreateEquipementsDecouverts : CFormEditObjetDeProcess
	{
		#region Code généré par le concepteur
		//private sc2i.win32.common.CEffetFonduPourForm m_effetFondu;
		private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private Label label2;
        private sc2i.win32.data.dynamic.CComboBoxArbreObjetDonneesHierarchique m_cmbSelectFamille;
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}


		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_cmbSelectFamille = new sc2i.win32.data.dynamic.CComboBoxArbreObjetDonneesHierarchique();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.m_cmbSelectFamille);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(536, 57);
            this.panel2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Equipment family";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(124, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(400, 27);
            this.label2.TabIndex = 3;
            this.label2.Text = "All discovered equipments types will be inserted in selected family|20023";
            // 
            // m_cmbSelectFamille
            // 
            this.m_cmbSelectFamille.BackColor = System.Drawing.Color.White;
            this.m_cmbSelectFamille.ElementSelectionne = null;
            this.m_cmbSelectFamille.Location = new System.Drawing.Point(127, 4);
            this.m_cmbSelectFamille.LockEdition = false;
            this.m_cmbSelectFamille.Name = "m_cmbSelectFamille";
            this.m_cmbSelectFamille.NullAutorise = false;
            this.m_cmbSelectFamille.Size = new System.Drawing.Size(380, 21);
            this.m_cmbSelectFamille.TabIndex = 4;
            this.m_cmbSelectFamille.TextNull = "None";
            // 
            // CFormEditActionCreateEquipementsDecouverts
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(536, 107);
            this.Controls.Add(this.panel2);
            this.Name = "CFormEditActionCreateEquipementsDecouverts";
            this.Text = "Transfer discovered equipments|20022";
            this.Load += new System.EventHandler(this.CFormEditActionCreateEquipementsDecouverts_Load);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		public CFormEditActionCreateEquipementsDecouverts()
		{
			InitializeComponent();
		}

		public static void Autoexec()
		{
            CEditeurActionsEtLiens.RegisterEditeur(typeof(CActionCreateEquipementsDecouverts), typeof(CFormEditActionCreateEquipementsDecouverts));
		}


        public CActionCreateEquipementsDecouverts ActionDecouverte
		{
			get
			{
				return (CActionCreateEquipementsDecouverts)ObjetEdite;
			}
		}

		

	

		/// //////////////////////////////////////////
		protected override sc2i.common.CResultAErreur MAJ_Champs()
		{
			CResultAErreur result = base.MAJ_Champs();
            CFamilleEquipement famille = m_cmbSelectFamille.ElementSelectionne as CFamilleEquipement;
            if (famille == null)
                ActionDecouverte.IdFamilleEquipement = -1;
            else
                ActionDecouverte.IdFamilleEquipement = famille.Id;
			return result;
		}

		
		/// //////////////////////////////////////////
		protected override void InitChamps()
		{
			base.InitChamps ();
            m_cmbSelectFamille.Init(typeof(CFamilleEquipement), "FamillesFilles",
                CFamilleEquipement.c_champIdParent, "Libelle", null, null);
            CFamilleEquipement famille = new CFamilleEquipement(CSc2iWin32DataClient.ContexteCourant);
            if (famille.ReadIfExists(ActionDecouverte.IdFamilleEquipement))
                m_cmbSelectFamille.ElementSelectionne =famille;
			
		}

		
        private void CFormEditActionCreateEquipementsDecouverts_Load(object sender, EventArgs e)
        {
            // Traduit le formulaire
            sc2i.win32.common.CWin32Traducteur.Translate(this);

        }

		




	}
}

