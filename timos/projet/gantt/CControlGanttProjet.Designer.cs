namespace timos.projet.gantt
{
    partial class CControlGanttProjet
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CControlGanttProjet));
            timos.data.projet.gantt.CParametresAffichageGantt cParametresAffichageGantt1 = new timos.data.projet.gantt.CParametresAffichageGantt();
            timos.data.projet.gantt.CParametreDessinLigneGantt cParametreDessinLigneGantt1 = new timos.data.projet.gantt.CParametreDessinLigneGantt();
            timos.data.projet.gantt.CParametreDessinLigneGantt.CParametreDessinBarreGantt cParametreDessinBarreGantt1 = new timos.data.projet.gantt.CParametreDessinLigneGantt.CParametreDessinBarreGantt();
            timos.data.projet.gantt.CParametreDessinLigneGantt.CParametreDessinGantt cParametreDessinGantt1 = new timos.data.projet.gantt.CParametreDessinLigneGantt.CParametreDessinGantt();
            timos.data.projet.gantt.icones.CParametreIconeGanttWarning cParametreIconeGanttWarning1 = new timos.data.projet.gantt.icones.CParametreIconeGanttWarning();
            timos.data.projet.gantt.icones.CParametreIconeGanttRetard cParametreIconeGanttRetard1 = new timos.data.projet.gantt.icones.CParametreIconeGanttRetard();
            timos.data.projet.gantt.icones.CParametreIconeGanttTermine cParametreIconeGanttTermine1 = new timos.data.projet.gantt.icones.CParametreIconeGanttTermine();
            timos.data.projet.gantt.CParametreDessinLigneGantt.CParametreDessinGantt cParametreDessinGantt2 = new timos.data.projet.gantt.CParametreDessinLigneGantt.CParametreDessinGantt();
            timos.data.projet.gantt.icones.CParametreIconeGanttAuto cParametreIconeGanttAuto1 = new timos.data.projet.gantt.icones.CParametreIconeGanttAuto();
            this.m_menuArbreGantt = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_menuArbreGanttAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.m_extModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_cmbDisplayMode = new sc2i.win32.data.CComboBoxListeObjetsDonnees();
            this.label1 = new System.Windows.Forms.Label();
            this.m_imageFiltre = new System.Windows.Forms.PictureBox();
            this.m_menuFiltres = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_iconeHasFilter = new System.Windows.Forms.PictureBox();
            this.m_gantt = new timos.win32.gantt.CGanttDiagram();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.m_composantSauvegardePreferences = new timos.projet.gantt.CComposantSauvegardePreferencesGanttRegistre();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menuArbreGantt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageFiltre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_iconeHasFilter)).BeginInit();
            this.SuspendLayout();
            // 
            // m_menuArbreGantt
            // 
            this.m_menuArbreGantt.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_menuArbreGanttAdd});
            this.m_extModeEdition.SetModeEdition(this.m_menuArbreGantt, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_menuArbreGantt.Name = "m_menuArbreGantt";
            this.m_menuArbreGantt.Size = new System.Drawing.Size(121, 26);
            // 
            // m_menuArbreGanttAdd
            // 
            this.m_menuArbreGanttAdd.Name = "m_menuArbreGanttAdd";
            this.m_menuArbreGanttAdd.Size = new System.Drawing.Size(120, 22);
            this.m_menuArbreGanttAdd.Text = "Add|22";
            this.m_menuArbreGanttAdd.Click += new System.EventHandler(this.m_menuArbreGanttAdd_Click);
            // 
            // m_cmbDisplayMode
            // 
            this.m_cmbDisplayMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbDisplayMode.ElementSelectionne = null;
            this.m_cmbDisplayMode.FormattingEnabled = true;
            this.m_cmbDisplayMode.IsLink = false;
            this.m_cmbDisplayMode.ListDonnees = null;
            this.m_cmbDisplayMode.Location = new System.Drawing.Point(3, 16);
            this.m_cmbDisplayMode.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_cmbDisplayMode, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_cmbDisplayMode.Name = "m_cmbDisplayMode";
            this.m_cmbDisplayMode.NullAutorise = true;
            this.m_cmbDisplayMode.ProprieteAffichee = null;
            this.m_cmbDisplayMode.ProprieteParentListeObjets = null;
            this.m_cmbDisplayMode.SelectionneurParent = null;
            this.m_cmbDisplayMode.Size = new System.Drawing.Size(190, 21);
            this.m_cmbDisplayMode.TabIndex = 2;
            this.m_cmbDisplayMode.TextNull = "(empty)";
            this.m_cmbDisplayMode.Tri = true;
            this.m_cmbDisplayMode.SelectionChangeCommitted += new System.EventHandler(this.m_cmbDisplayMode_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.m_extModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Display mode|20169";
            // 
            // m_imageFiltre
            // 
            this.m_imageFiltre.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_imageFiltre.Image = ((System.Drawing.Image)(resources.GetObject("m_imageFiltre.Image")));
            this.m_imageFiltre.Location = new System.Drawing.Point(159, 0);
            this.m_extModeEdition.SetModeEdition(this.m_imageFiltre, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_imageFiltre.Name = "m_imageFiltre";
            this.m_imageFiltre.Size = new System.Drawing.Size(16, 17);
            this.m_imageFiltre.TabIndex = 9;
            this.m_imageFiltre.TabStop = false;
            this.m_imageFiltre.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_imageFiltre_MouseUp);
            // 
            // m_menuFiltres
            // 
            this.m_extModeEdition.SetModeEdition(this.m_menuFiltres, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_menuFiltres.Name = "m_menuFiltres";
            this.m_menuFiltres.Size = new System.Drawing.Size(61, 4);
            this.m_menuFiltres.Opening += new System.ComponentModel.CancelEventHandler(this.m_menuFiltres_Opening);
            // 
            // m_iconeHasFilter
            // 
            this.m_iconeHasFilter.Image = global::timos.Properties.Resources.ok;
            this.m_iconeHasFilter.Location = new System.Drawing.Point(176, 0);
            this.m_extModeEdition.SetModeEdition(this.m_iconeHasFilter, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_iconeHasFilter.Name = "m_iconeHasFilter";
            this.m_iconeHasFilter.Size = new System.Drawing.Size(24, 17);
            this.m_iconeHasFilter.TabIndex = 10;
            this.m_iconeHasFilter.TabStop = false;
            this.m_iconeHasFilter.Visible = false;
            // 
            // m_gantt
            // 
            this.m_gantt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_gantt.Location = new System.Drawing.Point(0, 0);
            this.m_gantt.LockEdition = true;
            this.m_extModeEdition.SetModeEdition(this.m_gantt, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_gantt.Name = "m_gantt";
            cParametresAffichageGantt1.CellWidth = 40;
            cParametresAffichageGantt1.DateDebut = new System.DateTime(2010, 2, 16, 16, 0, 0, 0);
            cParametresAffichageGantt1.LineHeight = 20;
            cParametresAffichageGantt1.PrecisionUnit = 1;
            cParametresAffichageGantt1.Unit = timos.data.projet.gantt.EGanttTimeUnit.Hour;
            this.m_gantt.Parametre = cParametresAffichageGantt1;
            cParametreDessinLigneGantt1.FormuleDateDebut = null;
            cParametreDessinLigneGantt1.FormuleDateFin = null;
            cParametreDessinLigneGantt1.HauteurLigne = 22;
            cParametreDessinBarreGantt1.FormuleCouleurFond1 = ((sc2i.expression.C2iExpression)(resources.GetObject("cParametreDessinBarreGantt1.FormuleCouleurFond1")));
            cParametreDessinBarreGantt1.FormuleCouleurFond2 = ((sc2i.expression.C2iExpression)(resources.GetObject("cParametreDessinBarreGantt1.FormuleCouleurFond2")));
            cParametreDessinBarreGantt1.FormuleCouleurProgress = ((sc2i.expression.C2iExpression)(resources.GetObject("cParametreDessinBarreGantt1.FormuleCouleurProgress")));
            cParametreDessinBarreGantt1.FormuleCouleurTexte = ((sc2i.expression.C2iExpression)(resources.GetObject("cParametreDessinBarreGantt1.FormuleCouleurTexte")));
            cParametreDessinBarreGantt1.FormuleTexte = ((sc2i.expression.C2iExpression)(resources.GetObject("cParametreDessinBarreGantt1.FormuleTexte")));
            cParametreDessinBarreGantt1.ParametresIcones = new timos.data.projet.gantt.IParametreIconeGantt[0];
            cParametreDessinLigneGantt1.ParametreBarre = cParametreDessinBarreGantt1;
            cParametreDessinGantt1.FormuleCouleurTexte = null;
            cParametreDessinGantt1.FormuleTexte = null;
            cParametreIconeGanttWarning1.Tooltip = ((sc2i.expression.C2iExpression)(resources.GetObject("cParametreIconeGanttWarning1.Tooltip")));
            cParametreIconeGanttRetard1.Tooltip = ((sc2i.expression.C2iExpression)(resources.GetObject("cParametreIconeGanttRetard1.Tooltip")));
            cParametreIconeGanttTermine1.Tooltip = ((sc2i.expression.C2iExpression)(resources.GetObject("cParametreIconeGanttTermine1.Tooltip")));
            cParametreDessinGantt1.ParametresIcones = new timos.data.projet.gantt.IParametreIconeGantt[] {
        ((timos.data.projet.gantt.IParametreIconeGantt)(cParametreIconeGanttWarning1)),
        ((timos.data.projet.gantt.IParametreIconeGantt)(cParametreIconeGanttRetard1)),
        ((timos.data.projet.gantt.IParametreIconeGantt)(cParametreIconeGanttTermine1))};
            cParametreDessinLigneGantt1.ParametreZoneDroite = cParametreDessinGantt1;
            cParametreDessinGantt2.FormuleCouleurTexte = null;
            cParametreDessinGantt2.FormuleTexte = ((sc2i.expression.C2iExpression)(resources.GetObject("cParametreDessinGantt2.FormuleTexte")));
            cParametreIconeGanttAuto1.Tooltip = ((sc2i.expression.C2iExpression)(resources.GetObject("cParametreIconeGanttAuto1.Tooltip")));
            cParametreDessinGantt2.ParametresIcones = new timos.data.projet.gantt.IParametreIconeGantt[] {
        ((timos.data.projet.gantt.IParametreIconeGantt)(cParametreIconeGanttAuto1))};
            cParametreDessinLigneGantt1.ParametreZoneGauche = cParametreDessinGantt2;
            this.m_gantt.ParametreDessinLigne = cParametreDessinLigneGantt1;
            this.m_gantt.SelectedElement = null;
            this.m_gantt.Size = new System.Drawing.Size(581, 270);
            this.m_gantt.TabIndex = 1;
            this.m_gantt.Load += new System.EventHandler(this.m_gantt_Load);
            this.m_gantt.GanttContextMenuOpenning += new timos.win32.gantt.GanttElementEventHandler(this.m_gantt_GanttContextMenuOpenning);
            this.m_gantt.ElementGanttArbreMouseDown += new timos.win32.gantt.GanttElementEventHandler(this.m_gantt_ElementGanttArbreMouseDown);
            this.m_gantt.OnMoveElementDeGantt += new timos.win32.gantt.OnMoveGanttElement(this.m_gantt_OnMoveElementDeGantt);
            this.m_gantt.ElementGanttArbreDoubleClick += new timos.win32.gantt.GanttElementEventHandler(this.m_gantt_ElementGanttArbreDoubleClick);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(32, 19);
            // 
            // m_composantSauvegardePreferences
            // 
            this.m_composantSauvegardePreferences.ControlGantt = null;
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(32, 19);
            this.toolStripMenuItem2.Text = "toolStripMenuItem2";
            // 
            // CControlGanttProjet
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.m_iconeHasFilter);
            this.Controls.Add(this.m_imageFiltre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_cmbDisplayMode);
            this.Controls.Add(this.m_gantt);
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControlGanttProjet";
            this.Size = new System.Drawing.Size(581, 270);
            this.m_menuArbreGantt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_imageFiltre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_iconeHasFilter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip m_menuArbreGantt;
        private System.Windows.Forms.ToolStripMenuItem m_menuArbreGanttAdd;
        private timos.win32.gantt.CGanttDiagram m_gantt;
        private sc2i.win32.common.CExtModeEdition m_extModeEdition;
        private sc2i.win32.data.CComboBoxListeObjetsDonnees m_cmbDisplayMode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox m_imageFiltre;
        private System.Windows.Forms.ContextMenuStrip m_menuFiltres;
        private CComposantSauvegardePreferencesGanttRegistre m_composantSauvegardePreferences;
        private System.Windows.Forms.PictureBox m_iconeHasFilter;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
    }
}
