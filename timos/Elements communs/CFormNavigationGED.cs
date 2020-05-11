using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using sc2i.common;
using sc2i.data;
using sc2i.win32.common;
using sc2i.documents;
using sc2i.win32.navigation;
using sc2i.win32.data.navigation;
using sc2i.win32.data;
using sc2i.formulaire;
using sc2i.data.dynamic;

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;
using timos.Properties;

namespace timos
{
    [DynamicForm("EDM Navigation Form", "GetInfosParametres")]
	public class CFormNavigationGED : CFormMaxiSansMenu, IFormNavigable, IFormDynamiqueAParametres
	{
		private System.ComponentModel.IContainer components = null;

        public const string m_cParametreElementId = "ELEMENT_FOR_GED_ID";
        public const string m_cParametreElementType = "ELEMENT_FOR_GED_TYPE";

        protected CContexteFormNavigable m_contexte;
        private System.Windows.Forms.Panel panel1;

        private IObjetDonneeAIdNumerique m_elementForGED = null;

        private Panel m_panelTitre;
        private LinkLabel m_lnkElement;
        private timos.Elements_communs.CControlGED m_controlGED;
        private Label label1;

		//----------------------------------------------------------------------
		public CFormNavigationGED()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//----------------------------------------------------------------------
        public CFormNavigationGED(IObjetDonneeAIdNumerique objet)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();

			m_elementForGED = objet;

		}


        //----------------------------------------------------------------------
        /// <summary>
        /// Fonction statique nécessaire sur un DynamicForm
        /// </summary>
        /// <returns></returns>
        public static CInfoParametreDynamicForm[] GetInfosParametres()
        {
            return new CInfoParametreDynamicForm[] {
                new CInfoParametreDynamicForm(m_cParametreElementId , typeof(int), "This parameter must return the ID of the Element be displayed"),
                new CInfoParametreDynamicForm(m_cParametreElementType, typeof(string), "This parameter must return the Type (string) of the Element be displayed")};
        }

        //----------------------------------------------------------------------
        public CResultAErreur SetParametres(Dictionary<string, object> dicParametres)
        {
            CResultAErreur result = CResultAErreur.True;

            object obj = null;
            if (dicParametres.TryGetValue(m_cParametreElementId, out obj))
            {
                if (obj is int)
                {
                    int nId = (int)obj;
                    if (dicParametres.TryGetValue(m_cParametreElementType, out obj))
                    {
                        string strType = (string)obj;
                        Type tp = CActivatorSurChaine.GetType(strType);
                        if (tp != null)
                        {
                            m_elementForGED = (CObjetDonneeAIdNumerique)Activator.CreateInstance(
                                tp,
                                new object[] { CSc2iWin32DataClient.ContexteCourant });
                            if (!m_elementForGED.ReadIfExists(nId))
                            {
                                m_elementForGED = null;
                                result.EmpileErreur(I.T("Element for EDM Navigation Form not found|10100"));
                                return result;
                            }
                        }
                    }
                }
            }

            return result;

        }

        //----------------------------------------------------------------------
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
		//----------------------------------------------------------------------
		#region Code généré par le concepteur
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_panelTitre = new System.Windows.Forms.Panel();
            this.m_lnkElement = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.m_controlGED = new timos.Elements_communs.CControlGED();
            this.panel1.SuspendLayout();
            this.m_panelTitre.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_controlGED);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(706, 460);
            this.m_extStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 4045;
            // 
            // m_panelTitre
            // 
            this.m_panelTitre.BackColor = System.Drawing.Color.Navy;
            this.m_panelTitre.Controls.Add(this.m_lnkElement);
            this.m_panelTitre.Controls.Add(this.label1);
            this.m_panelTitre.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelTitre.Location = new System.Drawing.Point(0, 0);
            this.m_panelTitre.Name = "m_panelTitre";
            this.m_panelTitre.Size = new System.Drawing.Size(706, 38);
            this.m_extStyle.SetStyleBackColor(this.m_panelTitre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelTitre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelTitre.TabIndex = 4046;
            // 
            // m_lnkElement
            // 
            this.m_lnkElement.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lnkElement.BackColor = System.Drawing.Color.Navy;
            this.m_lnkElement.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lnkElement.ForeColor = System.Drawing.Color.White;
            this.m_lnkElement.LinkColor = System.Drawing.Color.White;
            this.m_lnkElement.Location = new System.Drawing.Point(74, 0);
            this.m_lnkElement.Name = "m_lnkElement";
            this.m_lnkElement.Size = new System.Drawing.Size(576, 32);
            this.m_extStyle.SetStyleBackColor(this.m_lnkElement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkElement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkElement.TabIndex = 1;
            this.m_lnkElement.TabStop = true;
            this.m_lnkElement.Text = "ELEMENT NAME";
            this.m_lnkElement.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lnkElement.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkElement_LinkClicked);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Navy;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 32);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 0;
            this.label1.Text = "EDM";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_controlGED
            // 
            this.m_controlGED.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_controlGED.Location = new System.Drawing.Point(0, 0);
            this.m_controlGED.LockEdition = true;
            this.m_controlGED.Name = "m_controlGED";
            this.m_controlGED.Size = new System.Drawing.Size(706, 460);
            this.m_extStyle.SetStyleBackColor(this.m_controlGED, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_controlGED, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_controlGED.TabIndex = 0;
            // 
            // CFormNavigationGED
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(706, 498);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.m_panelTitre);
            this.Name = "CFormNavigationGED";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Load += new System.EventHandler(this.CFormVisualisationRapport_Load);
            this.panel1.ResumeLayout(false);
            this.m_panelTitre.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
		//----------------------------------------------------------------------
		#region Membres de IFormNavigable

        public event ContexteFormEventHandler AfterGetContexte;
        public event ContexteFormEventHandler AfterInitFromContexte;

        
		public CContexteFormNavigable GetContexte()
		{
            CContexteFormNavigable contexte = new CContexteFormNavigable(GetType());

            if (m_elementForGED != null)
            {
                contexte["TYPE_OBJET"] = m_elementForGED.GetType();
                contexte["ID_OBJET"] = m_elementForGED.Id;
            }
            if (AfterGetContexte != null)
                AfterGetContexte(this, contexte);

            return contexte;
		}

		public bool QueryClose()
		{
			return true;
		}

		public CResultAErreur InitFromContexte(CContexteFormNavigable contexte)
		{
			CResultAErreur result = CResultAErreur.True;
			m_contexte = contexte;

            if (contexte["TYPE_OBJET"] != null)
            {
                m_elementForGED = (CObjetDonneeAIdNumerique)Activator.CreateInstance(
                    (Type)contexte["TYPE_OBJET"],
                    new object[] { CSc2iWin32DataClient.ContexteCourant });
                if (!m_elementForGED.ReadIfExists((int)contexte["ID_OBJET"]))
                    m_elementForGED = null;
            }
            if (AfterInitFromContexte != null)
                AfterInitFromContexte(this, contexte);

			return result;
		}
        //------------------------------------------------------------------
        public CResultAErreur Actualiser()
        {
            return InitFromContexte(GetContexte());
        }

		#endregion
		//----------------------------------------------------------------------
		private bool m_bRapportLoadInViewer = false;
		//----------------------------------------------------------------------
		private void CFormVisualisationRapport_Load(object sender, System.EventArgs e)
		{
            CTimosApp.Titre = I.T("Documents list|865");
            if (m_elementForGED == null)
                m_lnkElement.Visible = false;
            else
            {
                m_lnkElement.Visible = true;
                m_lnkElement.Text = m_elementForGED.DescriptionElement;
            }

            m_controlGED.Init(m_elementForGED);
		}


        private void m_lnkElement_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (m_elementForGED != null)
            {
                CReferenceTypeForm refTypeForm = CFormFinder.GetRefFormToEdit(m_elementForGED.GetType());
                if (refTypeForm != null)
                {
                    CFormEditionStandard form = refTypeForm.GetForm((CObjetDonneeAIdNumeriqueAuto)m_elementForGED) as CFormEditionStandard;
                    if (form != null)
                        CTimosApp.Navigateur.AffichePage(form);
                }
            }

        }

        public string GetTitle()
        {
            return I.T("Documents list|865");
        }

        public Image GetImage()
        {
            return Resources.documents;
        }


	}
}

