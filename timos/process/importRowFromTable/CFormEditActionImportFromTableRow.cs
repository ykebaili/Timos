using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

using sc2i.expression;
using sc2i.process;
using sc2i.common;
using sc2i.data.dynamic;
using timos.data;
using sc2i.data;
using System.Collections.Generic;
using sc2i.win32.common;
using timos.process.importRowFromTable;

namespace sc2i.win32.process
{
    [AutoExec("Autoexec")]
    public class CFormEditActionImportFromTableRow : sc2i.win32.process.CFormEditObjetDeProcess
    {
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private Label label2;
        private System.ComponentModel.IContainer components = null;
        private Label label3;
        private CheckBox m_chkIgnorerLignesVides;
        private Panel m_panelMappage;
        private Label label4;
        private sc2i.win32.data.CComboBoxListeObjetsDonnees m_cmbTypeTable;
        private Panel panel3;
        private Label label5;
        private Label label7;
        private Label label6;
        private sc2i.win32.expression.CTextBoxZoomFormule m_txtFormuleTarget;
        private sc2i.win32.expression.CTextBoxZoomFormule m_txtFormuleRow;

        public CFormEditActionImportFromTableRow()
        {
            // Cet appel est requis par le Concepteur Windows Form.
            InitializeComponent();

            // TODO : ajoutez les initialisations après l'appel à InitializeComponent
        }

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

        public static void Autoexec()
        {
            CEditeurActionsEtLiens.RegisterEditeur(typeof(CActionImportFromTableRow), typeof(CFormEditActionImportFromTableRow));
        }


        public CActionImportFromTableRow ActionImportFromTableRow
        {
            get
            {
                return (CActionImportFromTableRow)ObjetEdite;
            }
        }

        #region Code généré par le concepteur
        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_panelMappage = new System.Windows.Forms.Panel();
            this.m_chkIgnorerLignesVides = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_cmbTypeTable = new sc2i.win32.data.CComboBoxListeObjetsDonnees();
            this.label4 = new System.Windows.Forms.Label();
            this.m_txtFormuleTarget = new sc2i.win32.expression.CTextBoxZoomFormule();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txtFormuleRow = new sc2i.win32.expression.CTextBoxZoomFormule();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_panelMappage);
            this.panel2.Controls.Add(this.m_chkIgnorerLignesVides);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.m_cmbTypeTable);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.m_txtFormuleTarget);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.m_txtFormuleRow);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(626, 447);
            this.panel2.TabIndex = 2;
            // 
            // m_panelMappage
            // 
            this.m_panelMappage.AutoScroll = true;
            this.m_panelMappage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelMappage.Location = new System.Drawing.Point(0, 213);
            this.m_panelMappage.Name = "m_panelMappage";
            this.m_panelMappage.Size = new System.Drawing.Size(626, 217);
            this.m_panelMappage.TabIndex = 8;
            // 
            // m_chkIgnorerLignesVides
            // 
            this.m_chkIgnorerLignesVides.AutoSize = true;
            this.m_chkIgnorerLignesVides.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_chkIgnorerLignesVides.Location = new System.Drawing.Point(0, 430);
            this.m_chkIgnorerLignesVides.Name = "m_chkIgnorerLignesVides";
            this.m_chkIgnorerLignesVides.Size = new System.Drawing.Size(626, 17);
            this.m_chkIgnorerLignesVides.TabIndex = 7;
            this.m_chkIgnorerLignesVides.Text = "Ignore empty values|20817";
            this.m_chkIgnorerLignesVides.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 193);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(626, 20);
            this.panel3.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(130, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(326, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "Import into|20821";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Dock = System.Windows.Forms.DockStyle.Right;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(456, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(170, 20);
            this.label7.TabIndex = 2;
            this.label7.Text = "Condition|20822";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Column|20820";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(626, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Columns mapping|20816";
            // 
            // m_cmbTypeTable
            // 
            this.m_cmbTypeTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_cmbTypeTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbTypeTable.ElementSelectionne = null;
            this.m_cmbTypeTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmbTypeTable.FormattingEnabled = true;
            this.m_cmbTypeTable.IsLink = false;
            this.m_cmbTypeTable.ListDonnees = null;
            this.m_cmbTypeTable.Location = new System.Drawing.Point(0, 157);
            this.m_cmbTypeTable.LockEdition = false;
            this.m_cmbTypeTable.Name = "m_cmbTypeTable";
            this.m_cmbTypeTable.NullAutorise = false;
            this.m_cmbTypeTable.ProprieteAffichee = null;
            this.m_cmbTypeTable.ProprieteParentListeObjets = null;
            this.m_cmbTypeTable.SelectionneurParent = null;
            this.m_cmbTypeTable.Size = new System.Drawing.Size(626, 21);
            this.m_cmbTypeTable.TabIndex = 9;
            this.m_cmbTypeTable.TextNull = "(empty)";
            this.m_cmbTypeTable.Tri = true;
            this.m_cmbTypeTable.SelectionChangeCommitted += new System.EventHandler(this.m_cmbTypeTable_SelectionChangeCommitted);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(626, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Table type|20818";
            // 
            // m_txtFormuleTarget
            // 
            this.m_txtFormuleTarget.AllowGraphic = true;
            this.m_txtFormuleTarget.AllowNullFormula = false;
            this.m_txtFormuleTarget.AllowSaisieTexte = true;
            this.m_txtFormuleTarget.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_txtFormuleTarget.Formule = null;
            this.m_txtFormuleTarget.Location = new System.Drawing.Point(0, 86);
            this.m_txtFormuleTarget.LockEdition = false;
            this.m_txtFormuleTarget.LockZoneTexte = false;
            this.m_txtFormuleTarget.Name = "m_txtFormuleTarget";
            this.m_txtFormuleTarget.Size = new System.Drawing.Size(626, 56);
            this.m_txtFormuleTarget.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(626, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Target|20815";
            // 
            // m_txtFormuleRow
            // 
            this.m_txtFormuleRow.AllowGraphic = true;
            this.m_txtFormuleRow.AllowNullFormula = false;
            this.m_txtFormuleRow.AllowSaisieTexte = true;
            this.m_txtFormuleRow.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_txtFormuleRow.Formule = null;
            this.m_txtFormuleRow.Location = new System.Drawing.Point(0, 15);
            this.m_txtFormuleRow.LockEdition = false;
            this.m_txtFormuleRow.LockZoneTexte = false;
            this.m_txtFormuleRow.Name = "m_txtFormuleRow";
            this.m_txtFormuleRow.Size = new System.Drawing.Size(626, 56);
            this.m_txtFormuleRow.TabIndex = 13;
            this.m_txtFormuleRow.Leave += new System.EventHandler(this.m_txtFormuleRow_Leave);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(626, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Row to import|20814";
            // 
            // CFormEditActionImportFromTableRow
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(626, 495);
            this.Controls.Add(this.panel2);
            this.Name = "CFormEditActionImportFromTableRow";
            this.Text = "Import table row|20813";
            this.Load += new System.EventHandler(this.CFormEditActionImportFromTableRow_Load);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion



        /// //////////////////////////////////////////
        protected override sc2i.common.CResultAErreur MAJ_Champs()
		{
			CResultAErreur result = base.MAJ_Champs();

            C2iExpression formule = m_txtFormuleRow.Formule;
            if (!m_txtFormuleRow.ResultAnalyse)
            {
                result.EmpileErreur(m_txtFormuleRow.ResultAnalyse.Erreur);
                return result;
            }
            ActionImportFromTableRow.FormuleRow = formule;

            formule = m_txtFormuleTarget.Formule;
            if (!m_txtFormuleTarget.ResultAnalyse)
            {
                result.EmpileErreur(m_txtFormuleTarget.ResultAnalyse.Erreur);
                return result;
            }
            ActionImportFromTableRow.FormuleElementCible = formule;

            CTypeTableParametrable typeTable = m_cmbTypeTable.ElementSelectionne as CTypeTableParametrable;
            if ( typeTable == null )
            {
                result.EmpileErreur(I.T("Select a table type|20823"));
                return result;
            }
            ActionImportFromTableRow.IdTypeTable = typeTable.Id;

            ActionImportFromTableRow.IgnorerValeursVide = m_chkIgnorerLignesVides.Checked;

            List<CActionImportFromTableRow.CMappageColonne> lstMappages = new List<CActionImportFromTableRow.CMappageColonne>();
            foreach ( CControleEditeMappageImportTableRow ctrl in m_panelMappage.Controls )
            {
                result = ctrl.MajChamps();
                if ( !result )
                    return result;
                lstMappages.Add ( ctrl.Mappage );
            }
            ActionImportFromTableRow.Mappages = lstMappages.ToArray();
			return result;
		}

        /// //////////////////////////////////////////
        private void InitPanelMappages()
        {
            C2iExpression formuleCible = m_txtFormuleTarget.Formule;
            CTypeTableParametrable typeTable = m_cmbTypeTable.ElementSelectionne as CTypeTableParametrable;
            Dictionary<int, CActionImportFromTableRow.CMappageColonne> dicMappages = new Dictionary<int, CActionImportFromTableRow.CMappageColonne>();
            foreach (CActionImportFromTableRow.CMappageColonne map in ActionImportFromTableRow.Mappages)
                dicMappages[map.IdColonne] = map;
            List<CActionImportFromTableRow.CMappageColonne> lstOld = new List<CActionImportFromTableRow.CMappageColonne>();
            foreach (CControleEditeMappageImportTableRow ctrl in m_panelMappage.Controls)
            {
                if (ctrl.MajChamps())
                    dicMappages[ctrl.Mappage.IdColonne] = ctrl.Mappage;
            }
            m_panelMappage.SuspendDrawing();
            m_panelMappage.ClearAndDisposeControls();
            if (formuleCible != null && typeTable != null)
            {
                Type tpElements = formuleCible.TypeDonnee.TypeDotNetNatif;
                List<CActionImportFromTableRow.CMappageColonne> lst = new List<CActionImportFromTableRow.CMappageColonne>();
                foreach (CColonneTableParametrable col in typeTable.Colonnes)
                {
                    CActionImportFromTableRow.CMappageColonne map = null;
                    if (!dicMappages.TryGetValue(col.Id, out map))
                    {
                        map = new CActionImportFromTableRow.CMappageColonne();
                        map.IdColonne = col.Id;
                    }
                    CControleEditeMappageImportTableRow controle = new CControleEditeMappageImportTableRow();
                    controle.Init(ActionImportFromTableRow.Process, tpElements, map);
                    m_panelMappage.Controls.Add(controle);
                    controle.Dock = DockStyle.Top;
                    controle.BringToFront();
                }
            }
            m_panelMappage.ResumeDrawing();

        }


        /// //////////////////////////////////////////
        protected override void InitChamps()
        {
            base.InitChamps();

            m_txtFormuleRow.Init(ActionImportFromTableRow.Process, typeof(CProcess));
            m_txtFormuleRow.Formule = ActionImportFromTableRow.FormuleRow;
            m_txtFormuleTarget.Init(ActionImportFromTableRow.Process, typeof(CProcess));
            m_txtFormuleTarget.Formule = ActionImportFromTableRow.FormuleElementCible;
            m_cmbTypeTable.Init(typeof(CTypeTableParametrable), "Libelle", false);
            CTypeTableParametrable typeTable = new CTypeTableParametrable(CContexteDonneeSysteme.GetInstance());
            if (typeTable.ReadIfExists(ActionImportFromTableRow.IdTypeTable))
                m_cmbTypeTable.ElementSelectionne = typeTable;
            InitPanelMappages();
        }



        private void CFormEditActionImportFromTableRow_Load(object sender, EventArgs e)
        {
            // Traduit le formulaire
            sc2i.win32.common.CWin32Traducteur.Translate(this);

        }

        private void m_cmbTypeTable_SelectionChangeCommitted(object sender, EventArgs e)
        {
            InitPanelMappages();
        }

        private void m_txtFormuleRow_Leave(object sender, EventArgs e)
        {
            InitPanelMappages();
        }










    }
}

