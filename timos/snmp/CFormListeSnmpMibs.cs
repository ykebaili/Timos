using System.Collections;
using System.ComponentModel;
using System.Drawing;

using System.Windows.Forms;
using sc2i.win32.navigation;
using sc2i.data;
using sc2i.win32.data;
using sc2i.common;

using timos.acteurs;
using timos.data.snmp;
using futurocom.snmp;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System;

namespace timos
{
	[sc2i.win32.data.navigation.ObjectListeur(typeof(CSnmpMibModule))]
	public class CFormListeSnmpMibs : CFormListeStandardTimos, IFormNavigable
	{
        private Panel m_panelSpecifiqueMibs;
        private LinkLabel m_lnkImportMibs;
		
		private System.ComponentModel.IContainer components = null;

		public CFormListeSnmpMibs()
			:base(typeof(CSnmpMibModule))
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
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

		#region Designer generated code
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            sc2i.win32.common.GLColumn glColumn3 = new sc2i.win32.common.GLColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormListeSnmpMibs));
            this.m_panelSpecifiqueMibs = new System.Windows.Forms.Panel();
            this.m_lnkImportMibs = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnActions)).BeginInit();
            this.m_panelActions.SuspendLayout();
            this.m_panelLinkList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_imgListe)).BeginInit();
            this.m_panelMilieu.SuspendLayout();
            this.m_panelSpecifiqueMibs.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_lnkListe
            // 
            this.m_extStyle.SetStyleBackColor(this.m_lnkListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkListe.Text = "List";
            // 
            // m_btnActions
            // 
            this.m_extStyle.SetStyleBackColor(this.m_btnActions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnActions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelActions
            // 
            this.m_extStyle.SetStyleBackColor(this.m_panelActions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelActions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_lnkActions
            // 
            this.m_extStyle.SetStyleBackColor(this.m_lnkActions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkActions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkActions.Text = "Actions";
            // 
            // m_panelLinkList
            // 
            this.m_extStyle.SetStyleBackColor(this.m_panelLinkList, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelLinkList, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_imgListe
            // 
            this.m_extStyle.SetStyleBackColor(this.m_imgListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_imgListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelListe
            // 
            glColumn3.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn3.ActiveControlItems")));
            glColumn3.BackColor = System.Drawing.Color.Transparent;
            glColumn3.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn3.ForColor = System.Drawing.Color.Black;
            glColumn3.ImageIndex = -1;
            glColumn3.IsCheckColumn = false;
            glColumn3.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn3.Name = "Name";
            glColumn3.Propriete = "Libelle";
            glColumn3.Text = "Label|50";
            glColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn3.Width = 120;
            this.m_panelListe.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn3});
            this.m_panelListe.Size = new System.Drawing.Size(768, 333);
            this.m_extStyle.SetStyleBackColor(this.m_panelListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelGauche
            // 
            this.m_panelGauche.Size = new System.Drawing.Size(0, 376);
            this.m_extStyle.SetStyleBackColor(this.m_panelGauche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelGauche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelDroit
            // 
            this.m_panelDroit.Location = new System.Drawing.Point(768, 0);
            this.m_panelDroit.Size = new System.Drawing.Size(0, 376);
            this.m_extStyle.SetStyleBackColor(this.m_panelDroit, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelDroit, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelBas
            // 
            this.m_panelBas.Location = new System.Drawing.Point(0, 376);
            this.m_panelBas.Size = new System.Drawing.Size(768, 0);
            this.m_extStyle.SetStyleBackColor(this.m_panelBas, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelBas, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelHaut
            // 
            this.m_panelHaut.Size = new System.Drawing.Size(768, 0);
            this.m_extStyle.SetStyleBackColor(this.m_panelHaut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelHaut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelMilieu
            // 
            this.m_panelMilieu.Controls.Add(this.m_panelSpecifiqueMibs);
            this.m_panelMilieu.Size = new System.Drawing.Size(768, 376);
            this.m_extStyle.SetStyleBackColor(this.m_panelMilieu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelMilieu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelMilieu.Controls.SetChildIndex(this.m_panelSpecifiqueMibs, 0);
            this.m_panelMilieu.Controls.SetChildIndex(this.m_panelListe, 0);
            this.m_panelMilieu.Controls.SetChildIndex(this.m_panelLinkList, 0);
            this.m_panelMilieu.Controls.SetChildIndex(this.m_panelActions, 0);
            // 
            // m_panelSpecifiqueMibs
            // 
            this.m_panelSpecifiqueMibs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(187)))), ((int)(((byte)(255)))));
            this.m_panelSpecifiqueMibs.Controls.Add(this.m_lnkImportMibs);
            this.m_panelSpecifiqueMibs.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_panelSpecifiqueMibs.Location = new System.Drawing.Point(0, 333);
            this.m_panelSpecifiqueMibs.Name = "m_panelSpecifiqueMibs";
            this.m_panelSpecifiqueMibs.Size = new System.Drawing.Size(768, 43);
            this.m_extStyle.SetStyleBackColor(this.m_panelSpecifiqueMibs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelSpecifiqueMibs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelSpecifiqueMibs.TabIndex = 6;
            // 
            // m_lnkImportMibs
            // 
            this.m_lnkImportMibs.AutoSize = true;
            this.m_lnkImportMibs.Location = new System.Drawing.Point(4, 4);
            this.m_lnkImportMibs.Name = "m_lnkImportMibs";
            this.m_lnkImportMibs.Size = new System.Drawing.Size(103, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkImportMibs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkImportMibs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkImportMibs.TabIndex = 0;
            this.m_lnkImportMibs.TabStop = true;
            this.m_lnkImportMibs.Text = "Import mib file|20254";
            this.m_lnkImportMibs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkImportMibs_LinkClicked);
            // 
            // CFormListeSnmpMibs
            // 
            this.ClientSize = new System.Drawing.Size(768, 376);
            this.Name = "CFormListeSnmpMibs";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnActions)).EndInit();
            this.m_panelActions.ResumeLayout(false);
            this.m_panelLinkList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_imgListe)).EndInit();
            this.m_panelMilieu.ResumeLayout(false);
            this.m_panelSpecifiqueMibs.ResumeLayout(false);
            this.m_panelSpecifiqueMibs.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------
		protected override void InitPanel()
		{
			m_panelListe.InitFromListeObjets(
				m_listeObjets,
				typeof(CSnmpMibModule),	
				null, "");

			m_panelListe.RemplirGrille();
		}
		//-------------------------------------------------------------------
        public override string GetTitle()
        {
            return I.T("Mibs list|20250");
		}


        //-------------------------------------------------------------------
        private void m_lnkImportMibs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = I.T("Mib files (*.mib)|*.mib|All files (*.*)|*.*|20255");
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamReader reader = new StreamReader(dlg.FileName, System.Text.Encoding.Default);
                    CResultAErreurType<IList<IModule>> resultModules = CSnmpMibModule.CompileFile(reader);
                    reader.Close();
                    if (resultModules)
                    {
                        using (CContexteDonnee ctx = CSc2iWin32DataClient.ContexteCourant.GetContexteEdition())
                        {
                            CListeObjetDonneeGenerique<CSnmpMibModule> lstModules = new CListeObjetDonneeGenerique<CSnmpMibModule>(ctx);
                            lstModules.AssureLectureFaite();
                            lstModules.InterditLectureInDB = true;
                            foreach (IModule module in resultModules.DataType)
                            {
                                //Cherche le module dans la liste des modules
                                lstModules.Filtre = new CFiltreData(CSnmpMibModule.c_champModuleId + "=@1",
                                    module.Name);
                                if (lstModules.Count == 0)
                                {
                                    CSnmpMibModule mib = new CSnmpMibModule(ctx);
                                    mib.CreateNewInCurrentContexte();
                                    mib.ModuleId = module.Name;
                                    mib.ModuleMib = module;
                                    mib.Libelle = module.Name;
                                }
                            }
                            CResultAErreur result = ctx.CommitEdit();
                            if (!result)
                            {
                                CFormAfficheErreur.Show(result.Erreur);
                            }
                            else
                            {
                                m_panelListe.RemplirGrille();
                            }
                        }
                    }
                    else
                    {
                        CFormAfficheErreur.Show(resultModules.Erreur);
                    }
                }
                catch (Exception ex)
                {
                    CResultAErreur result = CResultAErreur.True;
                    result.EmpileErreur(new CErreurException(ex));
                    CFormAfficheErreur.Show(result.Erreur);
                }
            }
        }
		//-------------------------------------------------------------------
	}
}

