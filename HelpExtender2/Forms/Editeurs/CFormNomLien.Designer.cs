namespace HelpExtender
{
	partial class CFormNomLien
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

		#region Code généré par le Concepteur Windows Form

		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.btn_ok = new System.Windows.Forms.Button();
            this.tbn_prop = new System.Windows.Forms.RadioButton();
            this.rbt_perso = new System.Windows.Forms.RadioButton();
            this.txt_nom = new System.Windows.Forms.TextBox();
            this.cmb_prop = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(127, 92);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 0;
            this.btn_ok.Text = "Ok|10";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // tbn_prop
            // 
            this.tbn_prop.AutoSize = true;
            this.tbn_prop.Checked = true;
            this.tbn_prop.Location = new System.Drawing.Point(12, 12);
            this.tbn_prop.Name = "tbn_prop";
            this.tbn_prop.Size = new System.Drawing.Size(137, 17);
            this.tbn_prop.TabIndex = 1;
            this.tbn_prop.TabStop = true;
            this.tbn_prop.Text = "Predefined name|30031";
            this.tbn_prop.UseVisualStyleBackColor = true;
            this.tbn_prop.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // rbt_perso
            // 
            this.rbt_perso.AutoSize = true;
            this.rbt_perso.Location = new System.Drawing.Point(12, 35);
            this.rbt_perso.Name = "rbt_perso";
            this.rbt_perso.Size = new System.Drawing.Size(121, 17);
            this.rbt_perso.TabIndex = 2;
            this.rbt_perso.Text = "Custom name|30032";
            this.rbt_perso.UseVisualStyleBackColor = true;
            this.rbt_perso.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // txt_nom
            // 
            this.txt_nom.Location = new System.Drawing.Point(12, 66);
            this.txt_nom.Name = "txt_nom";
            this.txt_nom.Size = new System.Drawing.Size(307, 20);
            this.txt_nom.TabIndex = 3;
            this.txt_nom.TextChanged += new System.EventHandler(this.txt_nom_TextChanged);
            // 
            // cmb_prop
            // 
            this.cmb_prop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_prop.FormattingEnabled = true;
            this.cmb_prop.Location = new System.Drawing.Point(142, 11);
            this.cmb_prop.Name = "cmb_prop";
            this.cmb_prop.Size = new System.Drawing.Size(177, 21);
            this.cmb_prop.TabIndex = 4;
            this.cmb_prop.SelectedIndexChanged += new System.EventHandler(this.cmb_prop_SelectedIndexChanged);
            // 
            // CFormNomLien
            // 
            this.AcceptButton = this.btn_ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(331, 127);
            this.ControlBox = false;
            this.Controls.Add(this.cmb_prop);
            this.Controls.Add(this.txt_nom);
            this.Controls.Add(this.rbt_perso);
            this.Controls.Add(this.tbn_prop);
            this.Controls.Add(this.btn_ok);
            this.Name = "CFormNomLien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enter the link name... |30033";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btn_ok;
		private System.Windows.Forms.RadioButton tbn_prop;
		private System.Windows.Forms.RadioButton rbt_perso;
		private System.Windows.Forms.TextBox txt_nom;
		private System.Windows.Forms.ComboBox cmb_prop;
	}
}