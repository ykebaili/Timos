using timos.data.projet.gantt;
namespace timos.win32.gantt
{
    partial class CGanttDiagram
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
            timos.data.projet.gantt.CParametresAffichageGantt cParametresAffichageGantt7 = new timos.data.projet.gantt.CParametresAffichageGantt();
            timos.data.projet.gantt.CParametreDessinLigneGantt cParametreDessinLigneGantt4 = new timos.data.projet.gantt.CParametreDessinLigneGantt();
            timos.data.projet.gantt.CParametreDessinLigneGantt.CParametreDessinBarreGantt cParametreDessinBarreGantt4 = new timos.data.projet.gantt.CParametreDessinLigneGantt.CParametreDessinBarreGantt();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CGanttDiagram));
            timos.data.projet.gantt.CParametreDessinLigneGantt.CParametreDessinGantt cParametreDessinGantt7 = new timos.data.projet.gantt.CParametreDessinLigneGantt.CParametreDessinGantt();
            timos.data.projet.gantt.icones.CParametreIconeGanttWarning cParametreIconeGanttWarning4 = new timos.data.projet.gantt.icones.CParametreIconeGanttWarning();
            timos.data.projet.gantt.icones.CParametreIconeGanttRetard cParametreIconeGanttRetard4 = new timos.data.projet.gantt.icones.CParametreIconeGanttRetard();
            timos.data.projet.gantt.icones.CParametreIconeGanttTermine cParametreIconeGanttTermine4 = new timos.data.projet.gantt.icones.CParametreIconeGanttTermine();
            timos.data.projet.gantt.CParametreDessinLigneGantt.CParametreDessinGantt cParametreDessinGantt8 = new timos.data.projet.gantt.CParametreDessinLigneGantt.CParametreDessinGantt();
            timos.data.projet.gantt.icones.CParametreIconeGanttAuto cParametreIconeGanttAuto4 = new timos.data.projet.gantt.icones.CParametreIconeGanttAuto();
            timos.data.projet.gantt.CParametresAffichageGantt cParametresAffichageGantt8 = new timos.data.projet.gantt.CParametresAffichageGantt();
            this.m_panelGauche = new System.Windows.Forms.Panel();
            this.m_arbre = new timos.win32.gantt.CGanttTree();
            this.m_panelBas = new System.Windows.Forms.Panel();
            this.m_panelMargeHG = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.m_panelTimeEtBarres = new System.Windows.Forms.Panel();
            this.m_panelInfoScroll = new System.Windows.Forms.Panel();
            this.m_lblDateScroll = new System.Windows.Forms.Label();
            this.m_zoneBarres = new timos.win32.gantt.CGanttBar();
            this.m_zoneTemps = new timos.win32.gantt.CTimeBar();
            this.m_scrollDate = new System.Windows.Forms.HScrollBar();
            this.m_timerHideInfoScroll = new System.Windows.Forms.Timer(this.components);
            this.m_extModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_panelGauche.SuspendLayout();
            this.m_panelTimeEtBarres.SuspendLayout();
            this.m_panelInfoScroll.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelGauche
            // 
            this.m_panelGauche.Controls.Add(this.m_arbre);
            this.m_panelGauche.Controls.Add(this.m_panelBas);
            this.m_panelGauche.Controls.Add(this.m_panelMargeHG);
            this.m_panelGauche.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_panelGauche.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_panelGauche, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelGauche.Name = "m_panelGauche";
            this.m_panelGauche.Size = new System.Drawing.Size(250, 300);
            this.m_panelGauche.TabIndex = 3;
            // 
            // m_arbre
            // 
            this.m_arbre.AllowDrop = true;
            this.m_arbre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_arbre.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.m_arbre.HideSelection = false;
            this.m_arbre.ItemHeight = 22;
            this.m_arbre.Location = new System.Drawing.Point(0, 39);
            this.m_arbre.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_arbre, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_arbre.Name = "m_arbre";
            this.m_arbre.SelectedBackColor = System.Drawing.Color.LightBlue;
            this.m_arbre.SelectedElement = null;
            this.m_arbre.SelectedForeColor = System.Drawing.Color.Black;
            this.m_arbre.Size = new System.Drawing.Size(250, 245);
            this.m_arbre.TabIndex = 2;
            this.m_arbre.OnChangePosition += new System.EventHandler(this.m_arbre_OnChangePosition);
            this.m_arbre.SelectionChanged += new System.EventHandler(this.m_arbre_SelectionChanged);
            this.m_arbre.ElementGanttMouseDown += new timos.win32.gantt.GanttElementEventHandler(this.m_arbre_ElementGanttMouseDown);
            this.m_arbre.ElementGanttDoubleClick += new timos.win32.gantt.GanttElementEventHandler(this.m_arbre_ElementGanttDoubleClick);
            // 
            // m_panelBas
            // 
            this.m_panelBas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_panelBas.Location = new System.Drawing.Point(0, 284);
            this.m_extModeEdition.SetModeEdition(this.m_panelBas, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelBas.Name = "m_panelBas";
            this.m_panelBas.Size = new System.Drawing.Size(250, 16);
            this.m_panelBas.TabIndex = 3;
            // 
            // m_panelMargeHG
            // 
            this.m_panelMargeHG.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelMargeHG.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_panelMargeHG, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelMargeHG.Name = "m_panelMargeHG";
            this.m_panelMargeHG.Size = new System.Drawing.Size(250, 39);
            this.m_panelMargeHG.TabIndex = 3;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(250, 0);
            this.m_extModeEdition.SetModeEdition(this.splitter1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 300);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // m_panelTimeEtBarres
            // 
            this.m_panelTimeEtBarres.Controls.Add(this.m_panelInfoScroll);
            this.m_panelTimeEtBarres.Controls.Add(this.m_zoneBarres);
            this.m_panelTimeEtBarres.Controls.Add(this.m_zoneTemps);
            this.m_panelTimeEtBarres.Controls.Add(this.m_scrollDate);
            this.m_panelTimeEtBarres.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelTimeEtBarres.Location = new System.Drawing.Point(253, 0);
            this.m_extModeEdition.SetModeEdition(this.m_panelTimeEtBarres, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelTimeEtBarres.Name = "m_panelTimeEtBarres";
            this.m_panelTimeEtBarres.Size = new System.Drawing.Size(394, 300);
            this.m_panelTimeEtBarres.TabIndex = 5;
            // 
            // m_panelInfoScroll
            // 
            this.m_panelInfoScroll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_panelInfoScroll.BackColor = System.Drawing.Color.Black;
            this.m_panelInfoScroll.Controls.Add(this.m_lblDateScroll);
            this.m_panelInfoScroll.Location = new System.Drawing.Point(3, 268);
            this.m_extModeEdition.SetModeEdition(this.m_panelInfoScroll, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelInfoScroll.Name = "m_panelInfoScroll";
            this.m_panelInfoScroll.Size = new System.Drawing.Size(141, 16);
            this.m_panelInfoScroll.TabIndex = 5;
            this.m_panelInfoScroll.Visible = false;
            // 
            // m_lblDateScroll
            // 
            this.m_lblDateScroll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.m_lblDateScroll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lblDateScroll.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_lblDateScroll, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblDateScroll.Name = "m_lblDateScroll";
            this.m_lblDateScroll.Size = new System.Drawing.Size(140, 15);
            this.m_lblDateScroll.TabIndex = 3;
            this.m_lblDateScroll.Text = "label1";
            this.m_lblDateScroll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_zoneBarres
            // 
            this.m_zoneBarres.BackColor = System.Drawing.Color.White;
            this.m_zoneBarres.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_zoneBarres.Location = new System.Drawing.Point(0, 41);
            this.m_zoneBarres.LockEdition = true;
            this.m_extModeEdition.SetModeEdition(this.m_zoneBarres, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_zoneBarres.MovingBar = null;
            this.m_zoneBarres.Name = "m_zoneBarres";
            cParametresAffichageGantt7.CellWidth = 40;
            cParametresAffichageGantt7.DateDebut = new System.DateTime(2010, 1, 28, 17, 0, 0, 0);
            cParametresAffichageGantt7.LineHeight = 20;
            cParametresAffichageGantt7.PrecisionUnit = 1;
            cParametresAffichageGantt7.Unit = timos.data.projet.gantt.EGanttTimeUnit.Hour;
            this.m_zoneBarres.ParametreAffichage = cParametresAffichageGantt7;
            cParametreDessinLigneGantt4.FormuleDateDebut = null;
            cParametreDessinLigneGantt4.FormuleDateFin = null;
            cParametreDessinLigneGantt4.HauteurLigne = 22;
            cParametreDessinBarreGantt4.FormuleCouleurFond1 = ((sc2i.expression.C2iExpression)(resources.GetObject("cParametreDessinBarreGantt4.FormuleCouleurFond1")));
            cParametreDessinBarreGantt4.FormuleCouleurFond2 = ((sc2i.expression.C2iExpression)(resources.GetObject("cParametreDessinBarreGantt4.FormuleCouleurFond2")));
            cParametreDessinBarreGantt4.FormuleCouleurProgress = ((sc2i.expression.C2iExpression)(resources.GetObject("cParametreDessinBarreGantt4.FormuleCouleurProgress")));
            cParametreDessinBarreGantt4.FormuleCouleurTerminee = null;
            cParametreDessinBarreGantt4.FormuleCouleurTexte = ((sc2i.expression.C2iExpression)(resources.GetObject("cParametreDessinBarreGantt4.FormuleCouleurTexte")));
            cParametreDessinBarreGantt4.FormuleTexte = ((sc2i.expression.C2iExpression)(resources.GetObject("cParametreDessinBarreGantt4.FormuleTexte")));
            cParametreDessinBarreGantt4.ParametresIcones = new timos.data.projet.gantt.IParametreIconeGantt[0];
            cParametreDessinLigneGantt4.ParametreBarre = cParametreDessinBarreGantt4;
            cParametreDessinGantt7.FormuleCouleurTexte = null;
            cParametreDessinGantt7.FormuleTexte = null;
            cParametreIconeGanttWarning4.Tooltip = ((sc2i.expression.C2iExpression)(resources.GetObject("cParametreIconeGanttWarning4.Tooltip")));
            cParametreIconeGanttRetard4.Tooltip = ((sc2i.expression.C2iExpression)(resources.GetObject("cParametreIconeGanttRetard4.Tooltip")));
            cParametreIconeGanttTermine4.Tooltip = ((sc2i.expression.C2iExpression)(resources.GetObject("cParametreIconeGanttTermine4.Tooltip")));
            cParametreDessinGantt7.ParametresIcones = new timos.data.projet.gantt.IParametreIconeGantt[] {
        ((timos.data.projet.gantt.IParametreIconeGantt)(cParametreIconeGanttWarning4)),
        ((timos.data.projet.gantt.IParametreIconeGantt)(cParametreIconeGanttRetard4)),
        ((timos.data.projet.gantt.IParametreIconeGantt)(cParametreIconeGanttTermine4))};
            cParametreDessinLigneGantt4.ParametreZoneDroite = cParametreDessinGantt7;
            cParametreDessinGantt8.FormuleCouleurTexte = null;
            cParametreDessinGantt8.FormuleTexte = ((sc2i.expression.C2iExpression)(resources.GetObject("cParametreDessinGantt8.FormuleTexte")));
            cParametreIconeGanttAuto4.Tooltip = ((sc2i.expression.C2iExpression)(resources.GetObject("cParametreIconeGanttAuto4.Tooltip")));
            cParametreDessinGantt8.ParametresIcones = new timos.data.projet.gantt.IParametreIconeGantt[] {
        ((timos.data.projet.gantt.IParametreIconeGantt)(cParametreIconeGanttAuto4))};
            cParametreDessinLigneGantt4.ParametreZoneGauche = cParametreDessinGantt8;
            this.m_zoneBarres.ParametreDessinLigne = cParametreDessinLigneGantt4;
            this.m_zoneBarres.SelectedBackColor = System.Drawing.Color.LightBlue;
            this.m_zoneBarres.SelectedElement = null;
            this.m_zoneBarres.Size = new System.Drawing.Size(394, 243);
            this.m_zoneBarres.TabIndex = 1;
            this.m_zoneBarres.BarContextMenuOpenning += new timos.win32.gantt.GanttElementEventHandler(this.m_zoneBarres_BarContextMenuOpenning);
            this.m_zoneBarres.SelectionChanged += new System.EventHandler(this.m_zoneBarres_SelectionChanged);
            this.m_zoneBarres.OnMoveElementDeGantt += new timos.win32.gantt.OnMoveGanttElement(this.m_zoneBarres_OnMoveElementDeGantt);
            // 
            // m_zoneTemps
            // 
            this.m_zoneTemps.BackColor = System.Drawing.Color.White;
            this.m_zoneTemps.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_zoneTemps.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_zoneTemps, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_zoneTemps.Name = "m_zoneTemps";
            cParametresAffichageGantt8.CellWidth = 40;
            cParametresAffichageGantt8.DateDebut = new System.DateTime(2010, 1, 28, 17, 0, 0, 0);
            cParametresAffichageGantt8.LineHeight = 20;
            cParametresAffichageGantt8.PrecisionUnit = 1;
            cParametresAffichageGantt8.Unit = timos.data.projet.gantt.EGanttTimeUnit.Hour;
            this.m_zoneTemps.ParametreAffichage = cParametresAffichageGantt8;
            this.m_zoneTemps.Size = new System.Drawing.Size(394, 41);
            this.m_zoneTemps.TabIndex = 0;
            this.m_zoneTemps.OnApplyAsDefaultScale += new timos.win32.gantt.CTimeBar.ApplyAsDefaultScaleEventHandler(this.m_zoneTemps_OnApplyAsDefaultScale);
            // 
            // m_scrollDate
            // 
            this.m_scrollDate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_scrollDate.Location = new System.Drawing.Point(0, 284);
            this.m_scrollDate.Maximum = 365;
            this.m_extModeEdition.SetModeEdition(this.m_scrollDate, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_scrollDate.Name = "m_scrollDate";
            this.m_scrollDate.Size = new System.Drawing.Size(394, 16);
            this.m_scrollDate.TabIndex = 2;
            this.m_scrollDate.Scroll += new System.Windows.Forms.ScrollEventHandler(this.m_scrollDate_Scroll);
            this.m_scrollDate.ValueChanged += new System.EventHandler(this.m_scrollDate_ValueChanged);
            this.m_scrollDate.Resize += new System.EventHandler(this.m_scrollDate_Resize);
            // 
            // m_timerHideInfoScroll
            // 
            this.m_timerHideInfoScroll.Interval = 500;
            this.m_timerHideInfoScroll.Tick += new System.EventHandler(this.m_timerHideInfoScroll_Tick);
            // 
            // CGanttDiagram
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.m_panelTimeEtBarres);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.m_panelGauche);
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CGanttDiagram";
            this.Size = new System.Drawing.Size(647, 300);
            this.m_panelGauche.ResumeLayout(false);
            this.m_panelTimeEtBarres.ResumeLayout(false);
            this.m_panelInfoScroll.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CTimeBar m_zoneTemps;
        private CGanttBar m_zoneBarres;
        private System.Windows.Forms.Panel m_panelGauche;
        private System.Windows.Forms.Panel m_panelMargeHG;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel m_panelTimeEtBarres;
        private System.Windows.Forms.Panel m_panelBas;
        private System.Windows.Forms.HScrollBar m_scrollDate;
        private System.Windows.Forms.Panel m_panelInfoScroll;
        private System.Windows.Forms.Label m_lblDateScroll;
        private System.Windows.Forms.Timer m_timerHideInfoScroll;
        private sc2i.win32.common.CExtModeEdition m_extModeEdition;
        private CGanttTree m_arbre;
    }
}
