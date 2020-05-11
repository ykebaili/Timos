namespace futurocom.win32.snmp
{
    partial class CPanelDetailObjectType
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
            this.m_exStyle = new sc2i.win32.common.CExtStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.c2iTextBox1 = new sc2i.win32.common.C2iTextBox();
            this.m_lblOID = new sc2i.win32.common.C2iTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.c2iTextBox3 = new sc2i.win32.common.C2iTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.m_lblDescription = new sc2i.win32.common.C2iTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.m_txtAccess = new sc2i.win32.common.C2iTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.c2iTextBox2 = new sc2i.win32.common.C2iTextBox();
            this.c2iTextBox4 = new sc2i.win32.common.C2iTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.c2iTextBox5 = new sc2i.win32.common.C2iTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.c2iTextBox6 = new sc2i.win32.common.C2iTextBox();
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_pageDetail = new Crownwood.Magic.Controls.TabPage();
            this.m_pageDescriptio = new Crownwood.Magic.Controls.TabPage();
            this.m_pageIndices = new Crownwood.Magic.Controls.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.c2iTextBox7 = new sc2i.win32.common.C2iTextBox();
            this.m_wndListeIndices = new System.Windows.Forms.ListBox();
            this.m_pageTable = new Crownwood.Magic.Controls.TabPage();
            this.m_lblForFontColumnName = new System.Windows.Forms.LinkLabel();
            this.m_wndListeColonnes = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.m_panelTop = new System.Windows.Forms.Panel();
            this.m_exLinkField = new sc2i.win32.common.CExtLinkField();
            this.label12 = new System.Windows.Forms.Label();
            this.m_lblDataType = new sc2i.win32.common.C2iTextBox();
            this.m_tabControl.SuspendLayout();
            this.m_pageDetail.SuspendLayout();
            this.m_pageDescriptio.SuspendLayout();
            this.m_pageIndices.SuspendLayout();
            this.m_pageTable.SuspendLayout();
            this.m_panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.m_exLinkField.SetLinkField(this.label1, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.label1, false);
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 17);
            this.m_exStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name|20000";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c2iTextBox1
            // 
            this.c2iTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.c2iTextBox1.EmptyText = "";
            this.m_exLinkField.SetLinkField(this.c2iTextBox1, "Name");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.c2iTextBox1, true);
            this.c2iTextBox1.Location = new System.Drawing.Point(109, 1);
            this.c2iTextBox1.LockEdition = true;
            this.c2iTextBox1.Name = "c2iTextBox1";
            this.c2iTextBox1.Size = new System.Drawing.Size(288, 20);
            this.m_exStyle.SetStyleBackColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBox1.TabIndex = 1;
            this.c2iTextBox1.Text = "[Name]";
            // 
            // m_lblOID
            // 
            this.m_lblOID.EmptyText = "";
            this.m_exLinkField.SetLinkField(this.m_lblOID, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_lblOID, false);
            this.m_lblOID.Location = new System.Drawing.Point(113, 33);
            this.m_lblOID.LockEdition = true;
            this.m_lblOID.Name = "m_lblOID";
            this.m_lblOID.Size = new System.Drawing.Size(271, 21);
            this.m_exStyle.SetStyleBackColor(this.m_lblOID, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_lblOID, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblOID.TabIndex = 3;
            // 
            // label2
            // 
            this.m_exLinkField.SetLinkField(this.label2, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.label2, false);
            this.label2.Location = new System.Drawing.Point(7, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 17);
            this.m_exStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 2;
            this.label2.Text = "OID|20001";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c2iTextBox3
            // 
            this.c2iTextBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.c2iTextBox3.EmptyText = "";
            this.m_exLinkField.SetLinkField(this.c2iTextBox3, "ModuleName");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.c2iTextBox3, true);
            this.c2iTextBox3.Location = new System.Drawing.Point(113, 6);
            this.c2iTextBox3.LockEdition = true;
            this.c2iTextBox3.Name = "c2iTextBox3";
            this.c2iTextBox3.Size = new System.Drawing.Size(502, 21);
            this.m_exStyle.SetStyleBackColor(this.c2iTextBox3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.c2iTextBox3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBox3.TabIndex = 5;
            this.c2iTextBox3.Text = "[ModuleName]";
            // 
            // label3
            // 
            this.m_exLinkField.SetLinkField(this.label3, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.label3, false);
            this.label3.Location = new System.Drawing.Point(7, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 17);
            this.m_exStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 4;
            this.label3.Text = "Module|20002";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.m_exLinkField.SetLinkField(this.label4, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.label4, false);
            this.label4.Location = new System.Drawing.Point(7, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 17);
            this.m_exStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 6;
            this.label4.Text = "Description|20003";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lblDescription
            // 
            this.m_lblDescription.AcceptsReturn = true;
            this.m_lblDescription.AcceptsTab = true;
            this.m_lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblDescription.EmptyText = "";
            this.m_exLinkField.SetLinkField(this.m_lblDescription, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_lblDescription, false);
            this.m_lblDescription.Location = new System.Drawing.Point(113, 58);
            this.m_lblDescription.LockEdition = true;
            this.m_lblDescription.Multiline = true;
            this.m_lblDescription.Name = "m_lblDescription";
            this.m_lblDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.m_lblDescription.Size = new System.Drawing.Size(502, 328);
            this.m_exStyle.SetStyleBackColor(this.m_lblDescription, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_lblDescription, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblDescription.TabIndex = 7;
            this.m_lblDescription.Text = "[Description]";
            // 
            // label5
            // 
            this.m_exLinkField.SetLinkField(this.label5, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.label5, false);
            this.label5.Location = new System.Drawing.Point(3, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 17);
            this.m_exStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 8;
            this.label5.Text = "Access|20004";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtAccess
            // 
            this.m_txtAccess.EmptyText = "";
            this.m_exLinkField.SetLinkField(this.m_txtAccess, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_txtAccess, false);
            this.m_txtAccess.Location = new System.Drawing.Point(109, 4);
            this.m_txtAccess.LockEdition = true;
            this.m_txtAccess.Name = "m_txtAccess";
            this.m_txtAccess.Size = new System.Drawing.Size(197, 21);
            this.m_exStyle.SetStyleBackColor(this.m_txtAccess, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_txtAccess, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtAccess.TabIndex = 9;
            // 
            // label6
            // 
            this.m_exLinkField.SetLinkField(this.label6, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.label6, false);
            this.label6.Location = new System.Drawing.Point(3, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 17);
            this.m_exStyle.SetStyleBackColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label6.TabIndex = 10;
            this.label6.Text = "Syntax|20010";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.m_exLinkField.SetLinkField(this.label7, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.label7, false);
            this.label7.Location = new System.Drawing.Point(3, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 17);
            this.m_exStyle.SetStyleBackColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label7.TabIndex = 13;
            this.label7.Text = "Units|20011";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c2iTextBox2
            // 
            this.c2iTextBox2.EmptyText = "";
            this.m_exLinkField.SetLinkField(this.c2iTextBox2, "Units");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.c2iTextBox2, true);
            this.c2iTextBox2.Location = new System.Drawing.Point(109, 85);
            this.c2iTextBox2.LockEdition = true;
            this.c2iTextBox2.Name = "c2iTextBox2";
            this.c2iTextBox2.Size = new System.Drawing.Size(197, 21);
            this.m_exStyle.SetStyleBackColor(this.c2iTextBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.c2iTextBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBox2.TabIndex = 12;
            this.c2iTextBox2.Text = "[Units]";
            // 
            // c2iTextBox4
            // 
            this.c2iTextBox4.EmptyText = "";
            this.m_exLinkField.SetLinkField(this.c2iTextBox4, "Syntax.Name");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.c2iTextBox4, true);
            this.c2iTextBox4.Location = new System.Drawing.Point(109, 58);
            this.c2iTextBox4.LockEdition = true;
            this.c2iTextBox4.Name = "c2iTextBox4";
            this.c2iTextBox4.Size = new System.Drawing.Size(197, 21);
            this.m_exStyle.SetStyleBackColor(this.c2iTextBox4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.c2iTextBox4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBox4.TabIndex = 14;
            this.c2iTextBox4.Text = "[Syntax.Name]";
            // 
            // label8
            // 
            this.m_exLinkField.SetLinkField(this.label8, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.label8, false);
            this.label8.Location = new System.Drawing.Point(3, 112);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 17);
            this.m_exStyle.SetStyleBackColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label8.TabIndex = 16;
            this.label8.Text = "Default|20012";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c2iTextBox5
            // 
            this.c2iTextBox5.EmptyText = "";
            this.m_exLinkField.SetLinkField(this.c2iTextBox5, "DefaultValue.Text");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.c2iTextBox5, true);
            this.c2iTextBox5.Location = new System.Drawing.Point(109, 111);
            this.c2iTextBox5.LockEdition = true;
            this.c2iTextBox5.Name = "c2iTextBox5";
            this.c2iTextBox5.Size = new System.Drawing.Size(197, 21);
            this.m_exStyle.SetStyleBackColor(this.c2iTextBox5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.c2iTextBox5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBox5.TabIndex = 15;
            this.c2iTextBox5.Text = "[DefaultValue.Text]";
            // 
            // label9
            // 
            this.m_exLinkField.SetLinkField(this.label9, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.label9, false);
            this.label9.Location = new System.Drawing.Point(3, 138);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 17);
            this.m_exStyle.SetStyleBackColor(this.label9, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.label9, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label9.TabIndex = 18;
            this.label9.Text = "Reference|20013";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c2iTextBox6
            // 
            this.c2iTextBox6.EmptyText = "";
            this.m_exLinkField.SetLinkField(this.c2iTextBox6, "Reference");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.c2iTextBox6, true);
            this.c2iTextBox6.Location = new System.Drawing.Point(109, 137);
            this.c2iTextBox6.LockEdition = true;
            this.c2iTextBox6.Name = "c2iTextBox6";
            this.c2iTextBox6.Size = new System.Drawing.Size(197, 21);
            this.m_exStyle.SetStyleBackColor(this.c2iTextBox6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.c2iTextBox6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBox6.TabIndex = 17;
            this.c2iTextBox6.Text = "[Reference]";
            // 
            // m_tabControl
            // 
            this.m_tabControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_tabControl.BoldSelectedPage = true;
            this.m_tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_tabControl.ForeColor = System.Drawing.Color.Black;
            this.m_tabControl.IDEPixelArea = false;
            this.m_exLinkField.SetLinkField(this.m_tabControl, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_tabControl, false);
            this.m_tabControl.Location = new System.Drawing.Point(0, 23);
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = false;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 1;
            this.m_tabControl.SelectedTab = this.m_pageDetail;
            this.m_tabControl.Size = new System.Drawing.Size(629, 416);
            this.m_exStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_exStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabControl.TabIndex = 19;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_pageDescriptio,
            this.m_pageDetail,
            this.m_pageIndices,
            this.m_pageTable});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            // 
            // m_pageDetail
            // 
            this.m_pageDetail.Controls.Add(this.label12);
            this.m_pageDetail.Controls.Add(this.m_lblDataType);
            this.m_pageDetail.Controls.Add(this.label5);
            this.m_pageDetail.Controls.Add(this.m_txtAccess);
            this.m_pageDetail.Controls.Add(this.label9);
            this.m_pageDetail.Controls.Add(this.label6);
            this.m_pageDetail.Controls.Add(this.c2iTextBox6);
            this.m_pageDetail.Controls.Add(this.c2iTextBox2);
            this.m_pageDetail.Controls.Add(this.label8);
            this.m_pageDetail.Controls.Add(this.label7);
            this.m_pageDetail.Controls.Add(this.c2iTextBox5);
            this.m_pageDetail.Controls.Add(this.c2iTextBox4);
            this.m_exLinkField.SetLinkField(this.m_pageDetail, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_pageDetail, false);
            this.m_pageDetail.Location = new System.Drawing.Point(0, 25);
            this.m_pageDetail.Name = "m_pageDetail";
            this.m_pageDetail.Size = new System.Drawing.Size(629, 391);
            this.m_exStyle.SetStyleBackColor(this.m_pageDetail, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_pageDetail, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageDetail.TabIndex = 11;
            this.m_pageDetail.Title = "Detail|20014";
            // 
            // m_pageDescriptio
            // 
            this.m_pageDescriptio.Controls.Add(this.label3);
            this.m_pageDescriptio.Controls.Add(this.c2iTextBox3);
            this.m_pageDescriptio.Controls.Add(this.label2);
            this.m_pageDescriptio.Controls.Add(this.m_lblOID);
            this.m_pageDescriptio.Controls.Add(this.label4);
            this.m_pageDescriptio.Controls.Add(this.m_lblDescription);
            this.m_exLinkField.SetLinkField(this.m_pageDescriptio, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_pageDescriptio, false);
            this.m_pageDescriptio.Location = new System.Drawing.Point(0, 25);
            this.m_pageDescriptio.Name = "m_pageDescriptio";
            this.m_pageDescriptio.Selected = false;
            this.m_pageDescriptio.Size = new System.Drawing.Size(629, 391);
            this.m_exStyle.SetStyleBackColor(this.m_pageDescriptio, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_pageDescriptio, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageDescriptio.TabIndex = 10;
            this.m_pageDescriptio.Title = "Description|20003";
            // 
            // m_pageIndices
            // 
            this.m_pageIndices.Controls.Add(this.label11);
            this.m_pageIndices.Controls.Add(this.label10);
            this.m_pageIndices.Controls.Add(this.c2iTextBox7);
            this.m_pageIndices.Controls.Add(this.m_wndListeIndices);
            this.m_exLinkField.SetLinkField(this.m_pageIndices, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_pageIndices, false);
            this.m_pageIndices.Location = new System.Drawing.Point(0, 25);
            this.m_pageIndices.Name = "m_pageIndices";
            this.m_pageIndices.Selected = false;
            this.m_pageIndices.Size = new System.Drawing.Size(629, 391);
            this.m_exStyle.SetStyleBackColor(this.m_pageIndices, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_pageIndices, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageIndices.TabIndex = 12;
            this.m_pageIndices.Title = "Indexs|20015";
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_exLinkField.SetLinkField(this.label11, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.label11, false);
            this.label11.Location = new System.Drawing.Point(3, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(261, 17);
            this.m_exStyle.SetStyleBackColor(this.label11, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.label11, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label11.TabIndex = 12;
            this.label11.Text = "Indexs|20015";
            this.label11.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label10
            // 
            this.m_exLinkField.SetLinkField(this.label10, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.label10, false);
            this.label10.Location = new System.Drawing.Point(3, 3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 17);
            this.m_exStyle.SetStyleBackColor(this.label10, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.label10, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label10.TabIndex = 10;
            this.label10.Text = "Augment|20016";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c2iTextBox7
            // 
            this.c2iTextBox7.EmptyText = "";
            this.m_exLinkField.SetLinkField(this.c2iTextBox7, "Augment");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.c2iTextBox7, true);
            this.c2iTextBox7.Location = new System.Drawing.Point(109, 3);
            this.c2iTextBox7.LockEdition = true;
            this.c2iTextBox7.Name = "c2iTextBox7";
            this.c2iTextBox7.Size = new System.Drawing.Size(155, 21);
            this.m_exStyle.SetStyleBackColor(this.c2iTextBox7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.c2iTextBox7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBox7.TabIndex = 11;
            this.c2iTextBox7.Text = "[Augment]";
            // 
            // m_wndListeIndices
            // 
            this.m_wndListeIndices.FormattingEnabled = true;
            this.m_exLinkField.SetLinkField(this.m_wndListeIndices, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_wndListeIndices, false);
            this.m_wndListeIndices.Location = new System.Drawing.Point(4, 43);
            this.m_wndListeIndices.Name = "m_wndListeIndices";
            this.m_wndListeIndices.Size = new System.Drawing.Size(260, 329);
            this.m_exStyle.SetStyleBackColor(this.m_wndListeIndices, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_wndListeIndices, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeIndices.TabIndex = 0;
            // 
            // m_pageTable
            // 
            this.m_pageTable.Controls.Add(this.m_lblForFontColumnName);
            this.m_pageTable.Controls.Add(this.m_wndListeColonnes);
            this.m_exLinkField.SetLinkField(this.m_pageTable, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_pageTable, false);
            this.m_pageTable.Location = new System.Drawing.Point(0, 25);
            this.m_pageTable.Name = "m_pageTable";
            this.m_pageTable.Selected = false;
            this.m_pageTable.Size = new System.Drawing.Size(629, 391);
            this.m_exStyle.SetStyleBackColor(this.m_pageTable, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_pageTable, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageTable.TabIndex = 13;
            this.m_pageTable.Title = "Table|20028";
            // 
            // m_lblForFontColumnName
            // 
            this.m_lblForFontColumnName.AutoSize = true;
            this.m_lblForFontColumnName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_exLinkField.SetLinkField(this.m_lblForFontColumnName, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_lblForFontColumnName, false);
            this.m_lblForFontColumnName.Location = new System.Drawing.Point(262, 149);
            this.m_lblForFontColumnName.Name = "m_lblForFontColumnName";
            this.m_lblForFontColumnName.Size = new System.Drawing.Size(111, 13);
            this.m_exStyle.SetStyleBackColor(this.m_lblForFontColumnName, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_lblForFontColumnName, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblForFontColumnName.TabIndex = 1;
            this.m_lblForFontColumnName.TabStop = true;
            this.m_lblForFontColumnName.Text = "Font pour columName";
            this.m_lblForFontColumnName.Visible = false;
            // 
            // m_wndListeColonnes
            // 
            this.m_wndListeColonnes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.m_wndListeColonnes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_wndListeColonnes.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_wndListeColonnes.FullRowSelect = true;
            this.m_wndListeColonnes.GridLines = true;
            this.m_wndListeColonnes.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.m_exLinkField.SetLinkField(this.m_wndListeColonnes, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_wndListeColonnes, false);
            this.m_wndListeColonnes.Location = new System.Drawing.Point(0, 0);
            this.m_wndListeColonnes.Name = "m_wndListeColonnes";
            this.m_wndListeColonnes.ShowItemToolTips = true;
            this.m_wndListeColonnes.Size = new System.Drawing.Size(629, 391);
            this.m_exStyle.SetStyleBackColor(this.m_wndListeColonnes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_wndListeColonnes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeColonnes.TabIndex = 0;
            this.m_wndListeColonnes.UseCompatibleStateImageBehavior = false;
            this.m_wndListeColonnes.View = System.Windows.Forms.View.Details;
            this.m_wndListeColonnes.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m_wndListeColonnes_MouseDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Column name|20029";
            this.columnHeader1.Width = 166;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Column type|20031";
            this.columnHeader2.Width = 108;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Description|20003";
            this.columnHeader3.Width = 255;
            // 
            // m_panelTop
            // 
            this.m_panelTop.Controls.Add(this.label1);
            this.m_panelTop.Controls.Add(this.c2iTextBox1);
            this.m_panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_exLinkField.SetLinkField(this.m_panelTop, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_panelTop, false);
            this.m_panelTop.Location = new System.Drawing.Point(0, 0);
            this.m_panelTop.Name = "m_panelTop";
            this.m_panelTop.Size = new System.Drawing.Size(629, 23);
            this.m_exStyle.SetStyleBackColor(this.m_panelTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_panelTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelTop.TabIndex = 20;
            // 
            // m_exLinkField
            // 
            this.m_exLinkField.SourceTypeString = "";
            // 
            // label12
            // 
            this.m_exLinkField.SetLinkField(this.label12, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.label12, false);
            this.label12.Location = new System.Drawing.Point(3, 31);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 17);
            this.m_exStyle.SetStyleBackColor(this.label12, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.label12, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label12.TabIndex = 19;
            this.label12.Text = "Data type|20119";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lblDataType
            // 
            this.m_lblDataType.EmptyText = "";
            this.m_exLinkField.SetLinkField(this.m_lblDataType, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_lblDataType, false);
            this.m_lblDataType.Location = new System.Drawing.Point(109, 31);
            this.m_lblDataType.LockEdition = true;
            this.m_lblDataType.Name = "m_lblDataType";
            this.m_lblDataType.Size = new System.Drawing.Size(197, 21);
            this.m_exStyle.SetStyleBackColor(this.m_lblDataType, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_lblDataType, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblDataType.TabIndex = 20;
            // 
            // CPanelDetailObjectType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.m_tabControl);
            this.Controls.Add(this.m_panelTop);
            this.ForeColor = System.Drawing.Color.Black;
            this.m_exLinkField.SetLinkField(this, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this, false);
            this.Name = "CPanelDetailObjectType";
            this.Size = new System.Drawing.Size(629, 439);
            this.m_exStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_exStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.Load += new System.EventHandler(this.CPanelDetailScalar_Load);
            this.m_tabControl.ResumeLayout(false);
            this.m_tabControl.PerformLayout();
            this.m_pageDetail.ResumeLayout(false);
            this.m_pageDetail.PerformLayout();
            this.m_pageDescriptio.ResumeLayout(false);
            this.m_pageDescriptio.PerformLayout();
            this.m_pageIndices.ResumeLayout(false);
            this.m_pageIndices.PerformLayout();
            this.m_pageTable.ResumeLayout(false);
            this.m_pageTable.PerformLayout();
            this.m_panelTop.ResumeLayout(false);
            this.m_panelTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private sc2i.win32.common.CExtStyle m_exStyle;
        private System.Windows.Forms.Label label1;
        private sc2i.win32.common.CExtLinkField m_exLinkField;
        private sc2i.win32.common.C2iTextBox c2iTextBox1;
        private sc2i.win32.common.C2iTextBox m_lblOID;
        private System.Windows.Forms.Label label2;
        private sc2i.win32.common.C2iTextBox c2iTextBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private sc2i.win32.common.C2iTextBox m_lblDescription;
        private System.Windows.Forms.Label label5;
        private sc2i.win32.common.C2iTextBox m_txtAccess;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private sc2i.win32.common.C2iTextBox c2iTextBox2;
        private sc2i.win32.common.C2iTextBox c2iTextBox4;
        private System.Windows.Forms.Label label8;
        private sc2i.win32.common.C2iTextBox c2iTextBox5;
        private System.Windows.Forms.Label label9;
        private sc2i.win32.common.C2iTextBox c2iTextBox6;
        private sc2i.win32.common.C2iTabControl m_tabControl;
        private Crownwood.Magic.Controls.TabPage m_pageDescriptio;
        private Crownwood.Magic.Controls.TabPage m_pageDetail;
        private Crownwood.Magic.Controls.TabPage m_pageIndices;
        private System.Windows.Forms.Panel m_panelTop;
        private System.Windows.Forms.ListBox m_wndListeIndices;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private sc2i.win32.common.C2iTextBox c2iTextBox7;
        private Crownwood.Magic.Controls.TabPage m_pageTable;
        private System.Windows.Forms.ListView m_wndListeColonnes;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.LinkLabel m_lblForFontColumnName;
        private System.Windows.Forms.Label label12;
        private sc2i.win32.common.C2iTextBox m_lblDataType;
    }
}
