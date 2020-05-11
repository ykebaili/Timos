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
using sc2i.win32.process;
using sc2i.data;
using System.Collections.Generic;

namespace timos.process
{
	[AutoExec("Autoexec")]
	public class CFormEditActionNettoyageRelationsTypeId : sc2i.win32.process.CFormEditObjetDeProcess
	{
		private System.Windows.Forms.Panel panel2;
       private ListView m_wndListeTypes;
        private ColumnHeader columnHeader1;
        private Label label1;
		private System.ComponentModel.IContainer components = null;

		public CFormEditActionNettoyageRelationsTypeId()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();

			// TODO : ajoutez les initialisations après l'appel à InitializeComponent
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

		public static void Autoexec()
		{
			CEditeurActionsEtLiens.RegisterEditeur ( typeof(CActionNettoyageRelationsTypeId), typeof(CFormEditActionNettoyageRelationsTypeId));
		}


		public CActionNettoyageRelationsTypeId ActionNettoyageRelationsTypeId
		{
			get
			{
				return (CActionNettoyageRelationsTypeId)ObjetEdite;
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
            this.m_wndListeTypes = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.m_wndListeTypes);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(0, 8);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(365, 311);
            this.panel2.TabIndex = 2;
            // 
            // m_wndListeTypes
            // 
            this.m_wndListeTypes.CheckBoxes = true;
            this.m_wndListeTypes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.m_wndListeTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_wndListeTypes.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.m_wndListeTypes.Location = new System.Drawing.Point(0, 13);
            this.m_wndListeTypes.Name = "m_wndListeTypes";
            this.m_wndListeTypes.Size = new System.Drawing.Size(365, 298);
            this.m_wndListeTypes.TabIndex = 0;
            this.m_wndListeTypes.UseCompatibleStateImageBehavior = false;
            this.m_wndListeTypes.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 330;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(365, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select types to clean|20769";
            // 
            // CFormEditActionNettoyageRelationsTypeId
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(365, 365);
            this.Controls.Add(this.panel2);
            this.Name = "CFormEditActionNettoyageRelationsTypeId";
            this.Text = "";
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		/// //////////////////////////////////////////
		protected override void InitChamps()
		{
            m_wndListeTypes.BeginUpdate();
            m_wndListeTypes.Items.Clear();
            HashSet<Type> set = new HashSet<Type>();
            foreach ( Type tp in ActionNettoyageRelationsTypeId.TypesANettoyer )
                set.Add ( tp );
            foreach (RelationTypeIdAttribute rel in CContexteDonnee.RelationsTypeIds)
            {
                string strNomTable = rel.TableFille;
                Type tp = CContexteDonnee.GetTypeForTable(strNomTable);
                if (tp != null)
                {
                    ListViewItem item = new ListViewItem(DynamicClassAttribute.GetNomConvivial(tp));
                    item.Tag = tp;
                    item.Checked = set.Contains(tp);
                    m_wndListeTypes.Items.Add(item);
                }
            }
            m_wndListeTypes.EndUpdate();

			base.InitChamps ();
        }
	

		/// //////////////////////////////////////////
		protected override sc2i.common.CResultAErreur MAJ_Champs()
		{
			CResultAErreur result = base.MAJ_Champs();
            List<Type> lst = new List<Type>();
            foreach (ListViewItem item in m_wndListeTypes.CheckedItems)
            {
                Type tp = item.Tag as Type;
                if (tp != null)
                    lst.Add(tp);
            }
            ActionNettoyageRelationsTypeId.TypesANettoyer = lst.ToArray();

			return result;
		}

		

	}
}

