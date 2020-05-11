namespace timos.win32.composants.RichEdit
{
	partial class CPanelRichEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CPanelRichEditor));
            this.m_toolbar = new System.Windows.Forms.ToolStrip();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbrFont = new System.Windows.Forms.ToolStripButton();
            this.tspColor = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tbrLeft = new System.Windows.Forms.ToolStripButton();
            this.tbrCenter = new System.Windows.Forms.ToolStripButton();
            this.tbrRight = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tbrBold = new System.Windows.Forms.ToolStripButton();
            this.tbrItalic = new System.Windows.Forms.ToolStripButton();
            this.tbrUnderline = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tbrFind = new System.Windows.Forms.ToolStripButton();
            this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.EditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.FindToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FindAndReplaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.SelectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.CopyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.InsertImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SelectFontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.FontColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.BoldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ItalicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UnderlineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NormalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.PageColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ParagraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.IndentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuIndent0 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuIndent5 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuIndent10 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuIndent15 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuIndent20 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAlign = new System.Windows.Forms.ToolStripMenuItem();
            this.LeftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CenterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BulletsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddBulletsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveBulletsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_txtBox = new System.Windows.Forms.RichTextBox();
            this.m_panelFormule = new sc2i.win32.common.C2iPanel(this.components);
            this.m_lnkInsererFormule = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.m_wndFormule = new sc2i.win32.expression.CTextBoxZoomFormule();
            this.m_fontDialog = new System.Windows.Forms.FontDialog();
            this.m_colorDialog = new System.Windows.Forms.ColorDialog();
            this.m_toolbar.SuspendLayout();
            this.MenuStrip1.SuspendLayout();
            this.m_panelFormule.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_toolbar
            // 
            this.m_toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripSeparator1,
            this.tbrFont,
            this.tspColor,
            this.ToolStripSeparator4,
            this.tbrLeft,
            this.tbrCenter,
            this.tbrRight,
            this.ToolStripSeparator2,
            this.tbrBold,
            this.tbrItalic,
            this.tbrUnderline,
            this.ToolStripSeparator3,
            this.tbrFind});
            this.m_toolbar.Location = new System.Drawing.Point(0, 24);
            this.m_toolbar.Name = "m_toolbar";
            this.m_toolbar.Size = new System.Drawing.Size(669, 25);
            this.m_toolbar.TabIndex = 2;
            this.m_toolbar.Text = "ToolStrip1";
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tbrFont
            // 
            this.tbrFont.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbrFont.Image = ((System.Drawing.Image)(resources.GetObject("tbrFont.Image")));
            this.tbrFont.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbrFont.Name = "tbrFont";
            this.tbrFont.Size = new System.Drawing.Size(23, 22);
            this.tbrFont.Text = "Font|30038";
            this.tbrFont.Click += new System.EventHandler(this.tbrFont_Click);
            // 
            // tspColor
            // 
            this.tspColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tspColor.Image = ((System.Drawing.Image)(resources.GetObject("tspColor.Image")));
            this.tspColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspColor.Name = "tspColor";
            this.tspColor.Size = new System.Drawing.Size(23, 22);
            this.tspColor.Text = "toolStripButton1";
            this.tspColor.Click += new System.EventHandler(this.tspColor_Click);
            // 
            // ToolStripSeparator4
            // 
            this.ToolStripSeparator4.Name = "ToolStripSeparator4";
            this.ToolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tbrLeft
            // 
            this.tbrLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbrLeft.Image = ((System.Drawing.Image)(resources.GetObject("tbrLeft.Image")));
            this.tbrLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbrLeft.Name = "tbrLeft";
            this.tbrLeft.Size = new System.Drawing.Size(23, 22);
            this.tbrLeft.Text = "Left|30039";
            this.tbrLeft.Click += new System.EventHandler(this.tbrLeft_Click);
            // 
            // tbrCenter
            // 
            this.tbrCenter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbrCenter.Image = ((System.Drawing.Image)(resources.GetObject("tbrCenter.Image")));
            this.tbrCenter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbrCenter.Name = "tbrCenter";
            this.tbrCenter.Size = new System.Drawing.Size(23, 22);
            this.tbrCenter.Text = "Center|30040";
            this.tbrCenter.Click += new System.EventHandler(this.tbrCenter_Click);
            // 
            // tbrRight
            // 
            this.tbrRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbrRight.Image = ((System.Drawing.Image)(resources.GetObject("tbrRight.Image")));
            this.tbrRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbrRight.Name = "tbrRight";
            this.tbrRight.Size = new System.Drawing.Size(23, 22);
            this.tbrRight.Text = "Right|30041";
            this.tbrRight.Click += new System.EventHandler(this.tbrRight_Click);
            // 
            // ToolStripSeparator2
            // 
            this.ToolStripSeparator2.Name = "ToolStripSeparator2";
            this.ToolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tbrBold
            // 
            this.tbrBold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbrBold.Image = ((System.Drawing.Image)(resources.GetObject("tbrBold.Image")));
            this.tbrBold.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbrBold.Name = "tbrBold";
            this.tbrBold.Size = new System.Drawing.Size(23, 22);
            this.tbrBold.Text = "Bold|30042";
            this.tbrBold.Click += new System.EventHandler(this.tbrBold_Click);
            // 
            // tbrItalic
            // 
            this.tbrItalic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbrItalic.Image = ((System.Drawing.Image)(resources.GetObject("tbrItalic.Image")));
            this.tbrItalic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbrItalic.Name = "tbrItalic";
            this.tbrItalic.Size = new System.Drawing.Size(23, 22);
            this.tbrItalic.Text = "Italic|30043";
            this.tbrItalic.Click += new System.EventHandler(this.tbrItalic_Click);
            // 
            // tbrUnderline
            // 
            this.tbrUnderline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbrUnderline.Image = ((System.Drawing.Image)(resources.GetObject("tbrUnderline.Image")));
            this.tbrUnderline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbrUnderline.Name = "tbrUnderline";
            this.tbrUnderline.Size = new System.Drawing.Size(23, 22);
            this.tbrUnderline.Text = "Underline|30044";
            this.tbrUnderline.Click += new System.EventHandler(this.tbrUnderline_Click);
            // 
            // ToolStripSeparator3
            // 
            this.ToolStripSeparator3.Name = "ToolStripSeparator3";
            this.ToolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tbrFind
            // 
            this.tbrFind.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbrFind.Image = ((System.Drawing.Image)(resources.GetObject("tbrFind.Image")));
            this.tbrFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbrFind.Name = "tbrFind";
            this.tbrFind.Size = new System.Drawing.Size(23, 22);
            this.tbrFind.Text = "Find|30048";
            // 
            // MenuStrip1
            // 
            this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditToolStripMenuItem,
            this.FontToolStripMenuItem,
            this.ParagraphToolStripMenuItem,
            this.BulletsToolStripMenuItem});
            this.MenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip1.Name = "MenuStrip1";
            this.MenuStrip1.Size = new System.Drawing.Size(669, 24);
            this.MenuStrip1.TabIndex = 3;
            this.MenuStrip1.Text = "MenuStrip1";
            // 
            // EditToolStripMenuItem
            // 
            this.EditToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuUndo,
            this.mnuRedo,
            this.ToolStripSeparator6,
            this.FindToolStripMenuItem,
            this.FindAndReplaceToolStripMenuItem,
            this.ToolStripMenuItem4,
            this.SelectAllToolStripMenuItem,
            this.ToolStripMenuItem5,
            this.CopyToolStripMenuItem,
            this.CutToolStripMenuItem,
            this.PasteToolStripMenuItem,
            this.ToolStripMenuItem8,
            this.InsertImageToolStripMenuItem});
            this.EditToolStripMenuItem.Name = "EditToolStripMenuItem";
            this.EditToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.EditToolStripMenuItem.Text = "&Edit|30045";
            // 
            // mnuUndo
            // 
            this.mnuUndo.Name = "mnuUndo";
            this.mnuUndo.Size = new System.Drawing.Size(179, 22);
            this.mnuUndo.Text = "&Undo|30047";
            this.mnuUndo.Click += new System.EventHandler(this.mnuUndo_Click);
            // 
            // mnuRedo
            // 
            this.mnuRedo.Name = "mnuRedo";
            this.mnuRedo.Size = new System.Drawing.Size(179, 22);
            this.mnuRedo.Text = "&Redo|30046";
            this.mnuRedo.Click += new System.EventHandler(this.mnuRedo_Click);
            // 
            // ToolStripSeparator6
            // 
            this.ToolStripSeparator6.Name = "ToolStripSeparator6";
            this.ToolStripSeparator6.Size = new System.Drawing.Size(176, 6);
            // 
            // FindToolStripMenuItem
            // 
            this.FindToolStripMenuItem.Name = "FindToolStripMenuItem";
            this.FindToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.FindToolStripMenuItem.Text = "Fi&nd...|30048";
            // 
            // FindAndReplaceToolStripMenuItem
            // 
            this.FindAndReplaceToolStripMenuItem.Name = "FindAndReplaceToolStripMenuItem";
            this.FindAndReplaceToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.FindAndReplaceToolStripMenuItem.Text = "Find and &Replace...|30049";
            // 
            // ToolStripMenuItem4
            // 
            this.ToolStripMenuItem4.Name = "ToolStripMenuItem4";
            this.ToolStripMenuItem4.Size = new System.Drawing.Size(176, 6);
            // 
            // SelectAllToolStripMenuItem
            // 
            this.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem";
            this.SelectAllToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.SelectAllToolStripMenuItem.Text = "Select &All|30050";
            this.SelectAllToolStripMenuItem.Click += new System.EventHandler(this.SelectAllToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem5
            // 
            this.ToolStripMenuItem5.Name = "ToolStripMenuItem5";
            this.ToolStripMenuItem5.Size = new System.Drawing.Size(176, 6);
            // 
            // CopyToolStripMenuItem
            // 
            this.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem";
            this.CopyToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.CopyToolStripMenuItem.Text = "&Copy|30051";
            this.CopyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItem_Click);
            // 
            // CutToolStripMenuItem
            // 
            this.CutToolStripMenuItem.Name = "CutToolStripMenuItem";
            this.CutToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.CutToolStripMenuItem.Text = "C&ut|30052";
            this.CutToolStripMenuItem.Click += new System.EventHandler(this.CutToolStripMenuItem_Click);
            // 
            // PasteToolStripMenuItem
            // 
            this.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem";
            this.PasteToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.PasteToolStripMenuItem.Text = "Pas&te|30053";
            this.PasteToolStripMenuItem.Click += new System.EventHandler(this.PasteToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem8
            // 
            this.ToolStripMenuItem8.Name = "ToolStripMenuItem8";
            this.ToolStripMenuItem8.Size = new System.Drawing.Size(176, 6);
            // 
            // InsertImageToolStripMenuItem
            // 
            this.InsertImageToolStripMenuItem.Name = "InsertImageToolStripMenuItem";
            this.InsertImageToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.InsertImageToolStripMenuItem.Text = "Insert Image...|30054";
            // 
            // FontToolStripMenuItem
            // 
            this.FontToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SelectFontToolStripMenuItem,
            this.ToolStripMenuItem6,
            this.FontColorToolStripMenuItem,
            this.ToolStripSeparator5,
            this.BoldToolStripMenuItem,
            this.ItalicToolStripMenuItem,
            this.UnderlineToolStripMenuItem,
            this.NormalToolStripMenuItem,
            this.ToolStripMenuItem7,
            this.PageColorToolStripMenuItem});
            this.FontToolStripMenuItem.Name = "FontToolStripMenuItem";
            this.FontToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.FontToolStripMenuItem.Text = "F&ont|30055";
            // 
            // SelectFontToolStripMenuItem
            // 
            this.SelectFontToolStripMenuItem.Name = "SelectFontToolStripMenuItem";
            this.SelectFontToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.SelectFontToolStripMenuItem.Text = "Se&lect Font...|30056";
            this.SelectFontToolStripMenuItem.Click += new System.EventHandler(this.SelectFontToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem6
            // 
            this.ToolStripMenuItem6.Name = "ToolStripMenuItem6";
            this.ToolStripMenuItem6.Size = new System.Drawing.Size(148, 6);
            // 
            // FontColorToolStripMenuItem
            // 
            this.FontColorToolStripMenuItem.Name = "FontColorToolStripMenuItem";
            this.FontColorToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.FontColorToolStripMenuItem.Text = "Font &Color...|30057";
            this.FontColorToolStripMenuItem.Click += new System.EventHandler(this.FontColorToolStripMenuItem_Click);
            // 
            // ToolStripSeparator5
            // 
            this.ToolStripSeparator5.Name = "ToolStripSeparator5";
            this.ToolStripSeparator5.Size = new System.Drawing.Size(148, 6);
            // 
            // BoldToolStripMenuItem
            // 
            this.BoldToolStripMenuItem.Name = "BoldToolStripMenuItem";
            this.BoldToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.BoldToolStripMenuItem.Text = "&Bold|30058";
            this.BoldToolStripMenuItem.Click += new System.EventHandler(this.BoldToolStripMenuItem_Click);
            // 
            // ItalicToolStripMenuItem
            // 
            this.ItalicToolStripMenuItem.Name = "ItalicToolStripMenuItem";
            this.ItalicToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.ItalicToolStripMenuItem.Text = "&Italic|30059";
            this.ItalicToolStripMenuItem.Click += new System.EventHandler(this.ItalicToolStripMenuItem_Click);
            // 
            // UnderlineToolStripMenuItem
            // 
            this.UnderlineToolStripMenuItem.Name = "UnderlineToolStripMenuItem";
            this.UnderlineToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.UnderlineToolStripMenuItem.Text = "&Underline|30060";
            this.UnderlineToolStripMenuItem.Click += new System.EventHandler(this.UnderlineToolStripMenuItem_Click);
            // 
            // NormalToolStripMenuItem
            // 
            this.NormalToolStripMenuItem.Name = "NormalToolStripMenuItem";
            this.NormalToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.NormalToolStripMenuItem.Text = "&Normal|30061";
            this.NormalToolStripMenuItem.Click += new System.EventHandler(this.NormalToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem7
            // 
            this.ToolStripMenuItem7.Name = "ToolStripMenuItem7";
            this.ToolStripMenuItem7.Size = new System.Drawing.Size(148, 6);
            // 
            // PageColorToolStripMenuItem
            // 
            this.PageColorToolStripMenuItem.Name = "PageColorToolStripMenuItem";
            this.PageColorToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.PageColorToolStripMenuItem.Text = "&Page Color...|30062";
            this.PageColorToolStripMenuItem.Click += new System.EventHandler(this.PageColorToolStripMenuItem_Click);
            // 
            // ParagraphToolStripMenuItem
            // 
            this.ParagraphToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.IndentToolStripMenuItem,
            this.mnuAlign});
            this.ParagraphToolStripMenuItem.Name = "ParagraphToolStripMenuItem";
            this.ParagraphToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.ParagraphToolStripMenuItem.Text = "P&aragraph|30063";
            // 
            // IndentToolStripMenuItem
            // 
            this.IndentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuIndent0,
            this.mnuIndent5,
            this.mnuIndent10,
            this.mnuIndent15,
            this.mnuIndent20});
            this.IndentToolStripMenuItem.Name = "IndentToolStripMenuItem";
            this.IndentToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.IndentToolStripMenuItem.Text = "&Indent|30064";
            // 
            // mnuIndent0
            // 
            this.mnuIndent0.Name = "mnuIndent0";
            this.mnuIndent0.Size = new System.Drawing.Size(115, 22);
            this.mnuIndent0.Text = "None|30065";
            this.mnuIndent0.Click += new System.EventHandler(this.mnuIndent0_Click);
            // 
            // mnuIndent5
            // 
            this.mnuIndent5.Name = "mnuIndent5";
            this.mnuIndent5.Size = new System.Drawing.Size(115, 22);
            this.mnuIndent5.Text = "5 pts|30066";
            this.mnuIndent5.Click += new System.EventHandler(this.mnuIndent5_Click);
            // 
            // mnuIndent10
            // 
            this.mnuIndent10.Name = "mnuIndent10";
            this.mnuIndent10.Size = new System.Drawing.Size(115, 22);
            this.mnuIndent10.Text = "10 pts|30067";
            this.mnuIndent10.Click += new System.EventHandler(this.mnuIndent10_Click);
            // 
            // mnuIndent15
            // 
            this.mnuIndent15.Name = "mnuIndent15";
            this.mnuIndent15.Size = new System.Drawing.Size(115, 22);
            this.mnuIndent15.Text = "15 pts|30068";
            this.mnuIndent15.Click += new System.EventHandler(this.mnuIndent15_Click);
            // 
            // mnuIndent20
            // 
            this.mnuIndent20.Name = "mnuIndent20";
            this.mnuIndent20.Size = new System.Drawing.Size(115, 22);
            this.mnuIndent20.Text = "20 pts|30069";
            this.mnuIndent20.Click += new System.EventHandler(this.mnuIndent20_Click);
            // 
            // mnuAlign
            // 
            this.mnuAlign.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LeftToolStripMenuItem,
            this.CenterToolStripMenuItem,
            this.RightToolStripMenuItem});
            this.mnuAlign.Name = "mnuAlign";
            this.mnuAlign.Size = new System.Drawing.Size(117, 22);
            this.mnuAlign.Text = "&Align|30070";
            // 
            // LeftToolStripMenuItem
            // 
            this.LeftToolStripMenuItem.Name = "LeftToolStripMenuItem";
            this.LeftToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.LeftToolStripMenuItem.Text = "Left|30071";
            // 
            // CenterToolStripMenuItem
            // 
            this.CenterToolStripMenuItem.Name = "CenterToolStripMenuItem";
            this.CenterToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.CenterToolStripMenuItem.Text = "Center|30072";
            this.CenterToolStripMenuItem.Click += new System.EventHandler(this.CenterToolStripMenuItem_Click_1);
            // 
            // RightToolStripMenuItem
            // 
            this.RightToolStripMenuItem.Name = "RightToolStripMenuItem";
            this.RightToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.RightToolStripMenuItem.Text = "Right|30073";
            this.RightToolStripMenuItem.Click += new System.EventHandler(this.RightToolStripMenuItem_Click_1);
            // 
            // BulletsToolStripMenuItem
            // 
            this.BulletsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddBulletsToolStripMenuItem,
            this.RemoveBulletsToolStripMenuItem});
            this.BulletsToolStripMenuItem.Name = "BulletsToolStripMenuItem";
            this.BulletsToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.BulletsToolStripMenuItem.Text = "&Bullets|30074";
            // 
            // AddBulletsToolStripMenuItem
            // 
            this.AddBulletsToolStripMenuItem.Name = "AddBulletsToolStripMenuItem";
            this.AddBulletsToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.AddBulletsToolStripMenuItem.Text = "A&dd Bullets|30075";
            this.AddBulletsToolStripMenuItem.Click += new System.EventHandler(this.AddBulletsToolStripMenuItem_Click);
            // 
            // RemoveBulletsToolStripMenuItem
            // 
            this.RemoveBulletsToolStripMenuItem.Name = "RemoveBulletsToolStripMenuItem";
            this.RemoveBulletsToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.RemoveBulletsToolStripMenuItem.Text = "&Remove Bullets|30076";
            this.RemoveBulletsToolStripMenuItem.Click += new System.EventHandler(this.RemoveBulletsToolStripMenuItem_Click);
            // 
            // m_txtBox
            // 
            this.m_txtBox.AutoWordSelection = true;
            this.m_txtBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtBox.Location = new System.Drawing.Point(0, 74);
            this.m_txtBox.Name = "m_txtBox";
            this.m_txtBox.Size = new System.Drawing.Size(669, 161);
            this.m_txtBox.TabIndex = 4;
            this.m_txtBox.Text = "";
            // 
            // m_panelFormule
            // 
            this.m_panelFormule.Controls.Add(this.m_lnkInsererFormule);
            this.m_panelFormule.Controls.Add(this.label1);
            this.m_panelFormule.Controls.Add(this.m_wndFormule);
            this.m_panelFormule.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelFormule.Location = new System.Drawing.Point(0, 49);
            this.m_panelFormule.LockEdition = false;
            this.m_panelFormule.Name = "m_panelFormule";
            this.m_panelFormule.Size = new System.Drawing.Size(669, 25);
            this.m_panelFormule.TabIndex = 5;
            // 
            // m_lnkInsererFormule
            // 
            this.m_lnkInsererFormule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lnkInsererFormule.AutoSize = true;
            this.m_lnkInsererFormule.Location = new System.Drawing.Point(596, 5);
            this.m_lnkInsererFormule.Name = "m_lnkInsererFormule";
            this.m_lnkInsererFormule.Size = new System.Drawing.Size(65, 13);
            this.m_lnkInsererFormule.TabIndex = 2;
            this.m_lnkInsererFormule.TabStop = true;
            this.m_lnkInsererFormule.Text = "Insert|30032";
            this.m_lnkInsererFormule.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkInsererFormule_LinkClicked);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Formula|30033";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_wndFormule
            // 
            this.m_wndFormule.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_wndFormule.Formule = null;
            this.m_wndFormule.Location = new System.Drawing.Point(90, 0);
            this.m_wndFormule.LockEdition = false;
            this.m_wndFormule.LockZoneTexte = false;
            this.m_wndFormule.Name = "m_wndFormule";
            this.m_wndFormule.Size = new System.Drawing.Size(484, 23);
            this.m_wndFormule.TabIndex = 0;
            // 
            // CPanelRichEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.m_txtBox);
            this.Controls.Add(this.m_panelFormule);
            this.Controls.Add(this.m_toolbar);
            this.Controls.Add(this.MenuStrip1);
            this.Name = "CPanelRichEditor";
            this.Size = new System.Drawing.Size(669, 235);
            this.m_toolbar.ResumeLayout(false);
            this.m_toolbar.PerformLayout();
            this.MenuStrip1.ResumeLayout(false);
            this.MenuStrip1.PerformLayout();
            this.m_panelFormule.ResumeLayout(false);
            this.m_panelFormule.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.ToolStrip m_toolbar;
		internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
		internal System.Windows.Forms.ToolStripButton tbrFont;
		private System.Windows.Forms.ToolStripButton tspColor;
		internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator4;
		internal System.Windows.Forms.ToolStripButton tbrLeft;
		internal System.Windows.Forms.ToolStripButton tbrCenter;
		internal System.Windows.Forms.ToolStripButton tbrRight;
		internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator2;
		internal System.Windows.Forms.ToolStripButton tbrBold;
		internal System.Windows.Forms.ToolStripButton tbrItalic;
		internal System.Windows.Forms.ToolStripButton tbrUnderline;
		internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator3;
		internal System.Windows.Forms.ToolStripButton tbrFind;
		internal System.Windows.Forms.MenuStrip MenuStrip1;
		internal System.Windows.Forms.ToolStripMenuItem EditToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem mnuUndo;
		internal System.Windows.Forms.ToolStripMenuItem mnuRedo;
		internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator6;
		internal System.Windows.Forms.ToolStripMenuItem FindToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem FindAndReplaceToolStripMenuItem;
		internal System.Windows.Forms.ToolStripSeparator ToolStripMenuItem4;
		internal System.Windows.Forms.ToolStripMenuItem SelectAllToolStripMenuItem;
		internal System.Windows.Forms.ToolStripSeparator ToolStripMenuItem5;
		internal System.Windows.Forms.ToolStripMenuItem CopyToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem CutToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem PasteToolStripMenuItem;
		internal System.Windows.Forms.ToolStripSeparator ToolStripMenuItem8;
		internal System.Windows.Forms.ToolStripMenuItem InsertImageToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem FontToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem SelectFontToolStripMenuItem;
		internal System.Windows.Forms.ToolStripSeparator ToolStripMenuItem6;
		internal System.Windows.Forms.ToolStripMenuItem FontColorToolStripMenuItem;
		internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator5;
		internal System.Windows.Forms.ToolStripMenuItem BoldToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem ItalicToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem UnderlineToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem NormalToolStripMenuItem;
		internal System.Windows.Forms.ToolStripSeparator ToolStripMenuItem7;
		internal System.Windows.Forms.ToolStripMenuItem PageColorToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem ParagraphToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem IndentToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem mnuIndent0;
		internal System.Windows.Forms.ToolStripMenuItem mnuIndent5;
		internal System.Windows.Forms.ToolStripMenuItem mnuIndent10;
		internal System.Windows.Forms.ToolStripMenuItem mnuIndent15;
		internal System.Windows.Forms.ToolStripMenuItem mnuIndent20;
		internal System.Windows.Forms.ToolStripMenuItem mnuAlign;
		internal System.Windows.Forms.ToolStripMenuItem LeftToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem CenterToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem RightToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem BulletsToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem AddBulletsToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem RemoveBulletsToolStripMenuItem;
		private System.Windows.Forms.RichTextBox m_txtBox;
		private sc2i.win32.common.C2iPanel m_panelFormule;
		private System.Windows.Forms.Label label1;
		private sc2i.win32.expression.CTextBoxZoomFormule m_wndFormule;
		private System.Windows.Forms.LinkLabel m_lnkInsererFormule;
		internal System.Windows.Forms.FontDialog m_fontDialog;
		internal System.Windows.Forms.ColorDialog m_colorDialog;
	}
}
