using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using sc2i.common;
using sc2i.data.dynamic;
using sc2i.process;
using sc2i.expression;
using timos.process;

namespace sc2i.win32.process
{
	[AutoExec("Autoexec")]
	public class CFormEditActionCreerEntreeAgenda : sc2i.win32.process.CFormEditActionFonction
	{
		private sc2i.win32.common.C2iTabControl c2iTabControl1;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre1;
		private timos.CPanelParametrageAgenda m_panelAgenda;
		private System.ComponentModel.IContainer components = null;

		public CFormEditActionCreerEntreeAgenda()
		{
			// Cet appel est requis par le Concepteur Windows Form.
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
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		public static void Autoexec()
		{
			CEditeurActionsEtLiens.RegisterEditeur ( typeof(CActionCreerEntreeAgenda), typeof(CFormEditActionCreerEntreeAgenda));
		}

		#region Code généré par le concepteur
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.c2iTabControl1 = new sc2i.win32.common.C2iTabControl(this.components);
            this.c2iPanelOmbre1 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_panelAgenda = new timos.CPanelParametrageAgenda();
            this.c2iPanelOmbre1.SuspendLayout();
            this.SuspendLayout();
            // 
            // c2iTabControl1
            // 
            this.c2iTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.c2iTabControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(184)))));
            this.c2iTabControl1.BoldSelectedPage = true;
            this.c2iTabControl1.ControlBottomOffset = 16;
            this.c2iTabControl1.ControlRightOffset = 16;
            this.c2iTabControl1.IDEPixelArea = false;
            this.c2iTabControl1.Location = new System.Drawing.Point(0, 32);
            this.c2iTabControl1.Name = "c2iTabControl1";
            this.c2iTabControl1.Ombre = true;
            this.c2iTabControl1.PositionTop = true;
            this.c2iTabControl1.Size = new System.Drawing.Size(712, 328);
            this.c2iTabControl1.TabIndex = 2;
            // 
            // c2iPanelOmbre1
            // 
            this.c2iPanelOmbre1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.c2iPanelOmbre1.Controls.Add(this.m_panelAgenda);
            this.c2iPanelOmbre1.Location = new System.Drawing.Point(0, 32);
            this.c2iPanelOmbre1.LockEdition = false;
            this.c2iPanelOmbre1.Name = "c2iPanelOmbre1";
            this.c2iPanelOmbre1.Size = new System.Drawing.Size(744, 343);
            this.c2iPanelOmbre1.TabIndex = 4003;
            // 
            // m_panelAgenda
            // 
            this.m_panelAgenda.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelAgenda.BackColor = System.Drawing.SystemColors.Control;
            this.m_panelAgenda.Location = new System.Drawing.Point(0, 0);
            this.m_panelAgenda.LockEdition = false;
            this.m_panelAgenda.Name = "m_panelAgenda";
            this.m_panelAgenda.Size = new System.Drawing.Size(728, 327);
            this.m_panelAgenda.TabIndex = 3;
            // 
            // CFormEditActionCreerEntreeAgenda
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(744, 421);
            this.Controls.Add(this.c2iPanelOmbre1);
            this.Name = "CFormEditActionCreerEntreeAgenda";
            this.Text = "Create diary entry|1022";
            this.Controls.SetChildIndex(this.c2iPanelOmbre1, 0);
            this.c2iPanelOmbre1.ResumeLayout(false);
            this.c2iPanelOmbre1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		/// ////////////////////////////////////////////////////
		private CActionCreerEntreeAgenda ActionCreeAgenda
		{
			get
			{
				return (CActionCreerEntreeAgenda)ObjetEdite;
			}
		}

		/// ////////////////////////////////////////////////////
		protected override void InitChamps()
		{
			base.InitChamps ();
			m_panelAgenda.InitChamps ( ActionCreeAgenda.Parametre, typeof(CProcess), ActionCreeAgenda.Process );
		}

		/// ////////////////////////////////////////////////////
		protected override CResultAErreur MAJ_Champs()
		{
			CResultAErreur result = m_panelAgenda.MAJChamps();
			if ( !result )
				return result;
			ActionCreeAgenda.Parametre = m_panelAgenda.Parametre;
			result = base.MAJ_Champs();
			return result;
		}




	}
}

