namespace timos.tables
{
	partial class CTextBoxZoomable
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
            this.m_textBox = new System.Windows.Forms.TextBox();
            this.m_btnZoom = new System.Windows.Forms.PictureBox();
            this.m_cadreHaut = new System.Windows.Forms.Panel();
            this.m_cadreBas = new System.Windows.Forms.Panel();
            this.m_cadreGauche = new System.Windows.Forms.Panel();
            this.m_cadreDroite = new System.Windows.Forms.Panel();
            this.m_margeHaute = new System.Windows.Forms.Panel();
            this.m_margeBasse = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnZoom)).BeginInit();
            this.SuspendLayout();
            // 
            // m_textBox
            // 
            this.m_textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_textBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_textBox.Location = new System.Drawing.Point(1, 2);
            this.m_textBox.Name = "m_textBox";
            this.m_textBox.Size = new System.Drawing.Size(138, 19);
            this.m_textBox.TabIndex = 0;
            this.m_textBox.TextChanged += new System.EventHandler(this.m_textBox_TextChanged);
            this.m_textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_textBox_KeyDown);
            // 
            // m_btnZoom
            // 
            this.m_btnZoom.BackColor = System.Drawing.Color.White;
            this.m_btnZoom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnZoom.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_btnZoom.Location = new System.Drawing.Point(139, 1);
            this.m_btnZoom.Name = "m_btnZoom";
            this.m_btnZoom.Size = new System.Drawing.Size(10, 69);
            this.m_btnZoom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_btnZoom.TabIndex = 1;
            this.m_btnZoom.TabStop = false;
            this.m_btnZoom.Click += new System.EventHandler(this.m_btnZoom_Click);
            this.m_btnZoom.Paint += new System.Windows.Forms.PaintEventHandler(this.m_btnZoom_Paint);
            // 
            // m_cadreHaut
            // 
            this.m_cadreHaut.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.m_cadreHaut.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_cadreHaut.Location = new System.Drawing.Point(0, 0);
            this.m_cadreHaut.Name = "m_cadreHaut";
            this.m_cadreHaut.Size = new System.Drawing.Size(150, 1);
            this.m_cadreHaut.TabIndex = 2;
            // 
            // m_cadreBas
            // 
            this.m_cadreBas.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.m_cadreBas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_cadreBas.Location = new System.Drawing.Point(0, 70);
            this.m_cadreBas.Name = "m_cadreBas";
            this.m_cadreBas.Size = new System.Drawing.Size(150, 1);
            this.m_cadreBas.TabIndex = 3;
            // 
            // m_cadreGauche
            // 
            this.m_cadreGauche.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.m_cadreGauche.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_cadreGauche.Location = new System.Drawing.Point(0, 1);
            this.m_cadreGauche.Name = "m_cadreGauche";
            this.m_cadreGauche.Size = new System.Drawing.Size(1, 69);
            this.m_cadreGauche.TabIndex = 4;
            // 
            // m_cadreDroite
            // 
            this.m_cadreDroite.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.m_cadreDroite.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_cadreDroite.Location = new System.Drawing.Point(149, 1);
            this.m_cadreDroite.Name = "m_cadreDroite";
            this.m_cadreDroite.Size = new System.Drawing.Size(1, 69);
            this.m_cadreDroite.TabIndex = 5;
            // 
            // m_margeHaute
            // 
            this.m_margeHaute.BackColor = System.Drawing.Color.White;
            this.m_margeHaute.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_margeHaute.Location = new System.Drawing.Point(1, 1);
            this.m_margeHaute.Name = "m_margeHaute";
            this.m_margeHaute.Size = new System.Drawing.Size(138, 1);
            this.m_margeHaute.TabIndex = 6;
            // 
            // m_margeBasse
            // 
            this.m_margeBasse.BackColor = System.Drawing.Color.White;
            this.m_margeBasse.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_margeBasse.Location = new System.Drawing.Point(1, 66);
            this.m_margeBasse.Name = "m_margeBasse";
            this.m_margeBasse.Size = new System.Drawing.Size(138, 4);
            this.m_margeBasse.TabIndex = 7;
            // 
            // CTextBoxZoomable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.m_textBox);
            this.Controls.Add(this.m_margeHaute);
            this.Controls.Add(this.m_margeBasse);
            this.Controls.Add(this.m_cadreGauche);
            this.Controls.Add(this.m_btnZoom);
            this.Controls.Add(this.m_cadreDroite);
            this.Controls.Add(this.m_cadreHaut);
            this.Controls.Add(this.m_cadreBas);
            this.Name = "CTextBoxZoomable";
            this.Size = new System.Drawing.Size(150, 71);
            this.FontChanged += new System.EventHandler(this.CTextBoxZoomable2_FontChanged);
            this.SizeChanged += new System.EventHandler(this.CTextBoxZoomable2_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnZoom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox m_textBox;
		private System.Windows.Forms.PictureBox m_btnZoom;
		private System.Windows.Forms.Panel m_cadreHaut;
		private System.Windows.Forms.Panel m_cadreBas;
		private System.Windows.Forms.Panel m_cadreGauche;
		private System.Windows.Forms.Panel m_cadreDroite;
		private System.Windows.Forms.Panel m_margeHaute;
		private System.Windows.Forms.Panel m_margeBasse;
	}
}
