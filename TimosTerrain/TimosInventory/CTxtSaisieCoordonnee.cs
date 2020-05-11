using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TimosInventory.data;
using TimosInventory.data.releve;
using System.Drawing;
using sc2i.common;

namespace TimosInventory
{
    public class CTxtSaisieCoordonnee : UserControl
    {
        private ToolTip m_tooltip;
        private System.ComponentModel.IContainer components;
        private ErrorProvider m_error;
        private TextBox m_txtSaisie;
        private Panel panel1;
        private CReleveEquipement m_releveEqpt = null;
        public CTxtSaisieCoordonnee()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.m_tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.m_error = new System.Windows.Forms.ErrorProvider(this.components);
            this.m_txtSaisie = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.m_error)).BeginInit();
            this.SuspendLayout();
            // 
            // m_error
            // 
            this.m_error.ContainerControl = this;
            // 
            // m_txtSaisie
            // 
            this.m_txtSaisie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtSaisie.Location = new System.Drawing.Point(0, 0);
            this.m_txtSaisie.Multiline = true;
            this.m_txtSaisie.Name = "m_txtSaisie";
            this.m_txtSaisie.Size = new System.Drawing.Size(367, 28);
            this.m_txtSaisie.TabIndex = 0;
            this.m_txtSaisie.TextChanged += new System.EventHandler(this.CTxtSaisieCoordonnee_TextChanged);
            this.m_txtSaisie.Leave += new System.EventHandler(this.CTxtSaisieCoordonnee_Leave);
            this.m_txtSaisie.Enter += new System.EventHandler(this.CTxtSaisieCoordonnee_Enter);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(367, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(17, 28);
            this.panel1.TabIndex = 1;
            // 
            // CTxtSaisieCoordonnee
            // 
            this.Controls.Add(this.m_txtSaisie);
            this.Controls.Add(this.panel1);
            this.Name = "CTxtSaisieCoordonnee";
            this.Size = new System.Drawing.Size(384, 28);
            this.TextChanged += new System.EventHandler(this.CTxtSaisieCoordonnee_TextChanged);
            ((System.ComponentModel.ISupportInitialize)(this.m_error)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        //------------------------------------------------
		private void InitToolTip()
		{
			string strAide = "";
            if ( m_releveEqpt != null)
            {
                IObjetAFilsACoordonnees parent = m_releveEqpt.ConteneurFilsACoordonnees;
                if (parent != null && parent.ParametrageCoordonneesApplique != null)
                {
                    CParametrageSystemeCoordonnees parametrage = parent.ParametrageCoordonneesApplique;

                    if (parametrage != null)
                    {
                        strAide = parametrage.SystemeCoordonnees.Libelle;
                        List<CParametrageNiveau> lst = new List<CParametrageNiveau>();
                        foreach (CParametrageNiveau parametrageNiveau in parametrage.RelationParametragesNiveau)
                            lst.Add(parametrageNiveau);
                        lst.Sort(new CParametrageNiveauPositionComparer());
                        foreach (CParametrageNiveau param in lst)
                        {
                            strAide += "\r\n-" + param.Libelle + " (" + param.FormatNumerotation.Libelle + ")";
                        }
                        m_tooltip.SetToolTip(this, strAide);
                        m_tooltip.Show(strAide, this, new Point ( 0, Height), 3000);
                        return;
                    }
                }
            }
            m_tooltip.SetToolTip(this, "");
			
		}

        //----------------------------------------------------------------
        private bool m_bIsInitializing = false;
        public void Init(CReleveEquipement relEqt, bool bEnEdition)
        {
            m_bIsInitializing = true;
            m_releveEqpt = relEqt;
            m_txtSaisie.Text = relEqt.Coordonnee;
            m_bIsInitializing = false;
            
        }

        //----------------------------------------------------------------
        private void CTxtSaisieCoordonnee_Enter(object sender, EventArgs e)
        {
            InitToolTip();
        }

        //----------------------------------------------------------------
        private void CTxtSaisieCoordonnee_Leave(object sender, EventArgs e)
        {
            m_tooltip.Hide(this);
        }

        //----------------------------------------------------------------
        private void CTxtSaisieCoordonnee_TextChanged(object sender, EventArgs e)
        {
            if (m_bIsInitializing)
                return;
            CResultAErreur result = CResultAErreur.True;
            if (m_releveEqpt != null)
            {
                result = m_releveEqpt.VerifieCoordonnee ( m_txtSaisie.Text );
                if (!result)
                {
                    m_error.SetError(m_txtSaisie, result.Erreur.ToString());
                    m_txtSaisie.BackColor = Color.Red;
                }
                else
                {
                    m_error.SetError(m_txtSaisie, "");
                    m_txtSaisie.BackColor = Color.White;
                }
            }
            if (ValueChanged != null)
                ValueChanged(this, null);
            
        }

        //----------------------------------------------------------------
        public event EventHandler ValueChanged;

        //----------------------------------------------------------------
        public CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;
            if (m_releveEqpt != null)
            {
                m_releveEqpt.Coordonnee = m_txtSaisie.Text;
                result = m_releveEqpt.VerifieCoordonnee(m_txtSaisie.Text);
            }
            return result;
                    
        }
        


    }
}
