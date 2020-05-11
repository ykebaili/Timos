using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.win32.common;
using sc2i.formulaire.win32;
using sc2i.formulaire.win32.controles2iWnd;
using sc2i.win32.data.dynamic.controlesFor2iWnd;
using timos.data;
using sc2i.formulaire;
using System.Windows.Forms;
using sc2i.expression;
using sc2i.common;
using sc2i.data.dynamic;
using System.Drawing;
using timos.data.C2iWndComposants;
using timos.data.snmp;
using sc2i.formulaire.win32.datagrid;
using sc2i.common.Restrictions;
using futurocom.snmp.polling;
using sc2i.common.DonneeCumulee;

namespace timos.WndControles
{
	[AutoExec("Autoexec")]
    public class CWndForWndChampSnmp : CControlWndFor2iWnd, IControleWndFor2iWnd, IControlIncluableDansDataGrid
	{
		private C2iPanel m_panel = new C2iPanel();
        CCreateur2iFormulaireV2 m_createur = null;

        private 

		CWndFor2iWndVariable m_wndChamp = null;

        Control m_controleSnmp = null;

        PictureBox m_imageTools = null;
        PictureBox m_imageWarning = null;

        ContextMenuStrip m_menuSnmp = null;
        ToolStripMenuItem m_menuEcrireSnmp = null;
        ToolStripMenuItem m_menuOID = null;
        ToolStripMenuItem m_menuAddToPolled = null;

		//---------------------------------------------------------------
		public static void Autoexec()
		{
			CCreateur2iFormulaireV2.RegisterEditeur(typeof(C2iWndChampSnmp), typeof(CWndForWndChampSnmp));
		}

		//---------------------------------------------------------------
        protected override void MyCreateControle(
            CCreateur2iFormulaireV2 createur,
            C2iWnd wnd,
            Control parent,
            IFournisseurProprietesDynamiques fournisseurProprietes)
        {
            m_createur = createur;

            if (WndSnmp == null)
                return;

            CCreateur2iFormulaireV2.AffecteProprietesCommunes(WndSnmp, m_panel);
            parent.Controls.Add(m_panel);
            m_wndChamp = createur.CreateControle(WndSnmp.FieldZone, m_panel, fournisseurProprietes) as CWndFor2iWndVariable;
            m_wndChamp.OnValueChanged += new EventHandler(OnChampValueChanged);
            CChampCustom champCustom = null;
            if (WndSnmp.FieldZone.ChampCustom != null)
                champCustom = WndSnmp.FieldZone.ChampCustom;
            if (champCustom != null)
            {
                switch (champCustom.TypeDonneeChamp.TypeDonnee)
                {
                    case TypeDonnee.tBool:
                        m_controleSnmp = new CheckBox();
                        m_controleSnmp.Enabled = false;
                        break;
                    case TypeDonnee.tDate:
                    case TypeDonnee.tDouble:
                    case TypeDonnee.tEntier:
                    case TypeDonnee.tString:
                        m_controleSnmp = new C2iTextBox();
                        if (WndSnmp.FieldZone.MultiLine)
                            ((C2iTextBox)m_controleSnmp).Multiline = true;
                        ((C2iTextBox)m_controleSnmp).LockEdition = true;
                        ((C2iTextBox)m_controleSnmp).OnChangeLockEdition += new EventHandler(CWndForWndChampSnmp_OnChangeLockEdition);
                        break;
                    default:
                        break;
                }
                if (m_controleSnmp != null)
                {
                    m_panel.Controls.Add(m_controleSnmp);
                    m_controleSnmp.Location = WndSnmp.SnmpZone.Position;
                    m_controleSnmp.Size = WndSnmp.SnmpZone.Size;
                    m_controleSnmp.BackColor = WndSnmp.SnmpZone.BackColor;
                    m_controleSnmp.ForeColor = WndSnmp.SnmpZone.ForeColor;
                    switch (WndSnmp.SnmpZone.DockStyle)
                    {
                        case sc2i.formulaire.EDockStyle.Bottom:
                            m_controleSnmp.Dock = DockStyle.Bottom;
                            break;
                        case sc2i.formulaire.EDockStyle.Fill:
                            m_controleSnmp.Dock = DockStyle.Fill;
                            break;
                        case sc2i.formulaire.EDockStyle.Left:
                            m_controleSnmp.Dock = DockStyle.Left;
                            break;
                        case sc2i.formulaire.EDockStyle.None:
                            m_controleSnmp.Dock = DockStyle.None;
                            break;
                        case sc2i.formulaire.EDockStyle.Right:
                            m_controleSnmp.Dock = DockStyle.Right;
                            break;
                        case sc2i.formulaire.EDockStyle.Top:
                            m_controleSnmp.Dock = DockStyle.Top;
                            break;
                        default:
                            break;
                    }
                }
            }
            m_imageWarning = new PictureBox();
            m_panel.Controls.Add(m_imageWarning);
            if (m_controleSnmp != null)
            {
                m_imageWarning.Location = new Point(m_controleSnmp.Location.X + m_controleSnmp.Size.Width - 16,
                    m_controleSnmp.Location.Y);
            }
            if ( m_controleSnmp != null )
                m_imageWarning.Size = new Size(16, m_controleSnmp.Height);
            m_imageWarning.BackColor = wnd.BackColor;
            m_imageWarning.SizeMode = PictureBoxSizeMode.CenterImage;
            m_imageWarning.Image = Properties.Resources.alerte;
            m_imageWarning.BringToFront();
            m_imageWarning.Visible = false;

            m_imageTools = new PictureBox();
            m_panel.Controls.Add(m_imageTools);
            m_imageTools.Dock = DockStyle.Right;
            m_imageTools.BackColor = wnd.BackColor;
            if (m_controleSnmp != null)
                m_imageTools.Size = new Size(16, m_controleSnmp.Height);
            m_imageTools.SendToBack();
            m_imageTools.SizeMode = PictureBoxSizeMode.CenterImage;
            m_imageTools.Image = Properties.Resources.tools;
            m_imageTools.Click += new EventHandler(m_imageTools_Click);
            m_imageTools.Cursor = Cursors.Hand;


            if (WndSnmp.IsHorizontal)
            {
                if (m_wndChamp != null && m_wndChamp.Control != null)
                {
                    m_wndChamp.Control.Dock = DockStyle.Fill;
                    m_wndChamp.Control.BringToFront();
                }
                if (m_controleSnmp != null)
                {
                    m_controleSnmp.Dock = DockStyle.Right;
                    if (parent is sc2i.formulaire.win32.datagrid.CControlEncapsuleWndControl)
                        m_controleSnmp.Width = parent.Width / 2;
                }
                m_imageWarning.Dock = DockStyle.Right;
                m_imageTools.Dock = DockStyle.Right;
                m_imageWarning.SendToBack();
                m_imageTools.SendToBack();
            }
            else
            {
                if (m_wndChamp != null && m_wndChamp.Control != null)
                {
                    m_wndChamp.Control.Dock = DockStyle.Fill;
                    m_wndChamp.Control.BringToFront();
                }
                if (m_controleSnmp != null)
                    m_controleSnmp.Dock = DockStyle.Bottom;
                m_imageWarning.Dock = DockStyle.Right;
                m_imageTools.Dock = DockStyle.Right;
                m_imageWarning.SendToBack();
                m_imageTools.SendToBack();
            }
            parent.SizeChanged += new EventHandler(parent_SizeChanged);

        }

        void parent_SizeChanged(object sender, EventArgs e)
        {
            Control ctrl= sender as Control;
            if ( ctrl != null && m_controleSnmp != null && ctrl is sc2i.formulaire.win32.datagrid.CControlEncapsuleWndControl)
                m_controleSnmp.Width = Math.Max(10, (ctrl.Width-m_imageTools.Width - m_imageWarning.Width)/2);
        }

        //---------------------------------------------------
        public void OnChampValueChanged(object sender, EventArgs args)
        {
            if (m_view != null)
                m_view.NotifyCurrentCellDirty(true);
        }

        //---------------------------------------------------
        public override bool LockEdition
        {
            get
            {
                return base.LockEdition;
            }
            set
            {
                base.LockEdition = value;
                m_imageTools.Enabled = true;
            }
        }


        //---------------------------------------------------
        void m_imageTools_Click(object sender, EventArgs e)
        {
            AssureMenuSnmp();
            CEntiteSnmp entiteSnmp = EditedElement as CEntiteSnmp;
            bool bWriteAutorise = entiteSnmp != null && entiteSnmp.TypeEntiteSnmp != null && !entiteSnmp.TypeEntiteSnmp.ReadOnly;
            m_menuEcrireSnmp.Visible = bWriteAutorise;
            if (m_menuAddToPolled != null && entiteSnmp != null &&
                entiteSnmp.AgentSnmp.ParametresPolling.Count() > 0)
                m_menuAddToPolled.Visible = !LockEdition;
            else
                m_menuAddToPolled.Visible = false;
            if (m_menuOID != null)
            {
                try
                {
                    string strOID = entiteSnmp.GetFieldOID(WndSnmp.FieldZone.ChampCustom.Id);
                    if (strOID != null)
                    {
                        m_menuOID.Text = I.T("OID @1 (Click to copy)|20857",strOID);
                        m_menuOID.Tag = strOID;
                        m_menuOID.Visible = true;
                    }
                    else
                        m_menuOID.Visible = false;
                }
                catch
                {
                    m_menuOID.Visible = false;
                }
            }
            m_menuSnmp.Show(Cursor.Position);
        }

        //---------------------------------------------
        private void AssureMenuSnmp()
        {
            if (m_menuAddToPolled != null && m_menuAddToPolled.DropDownItems.Count == 0)
                m_menuAddToPolled.DropDownItems.Add("DUMMY");
            if (m_menuSnmp != null)
                return;
            m_menuSnmp = new ContextMenuStrip();

            ToolStripMenuItem item = new ToolStripMenuItem(I.T("Read snmp value|20316"));
            item.Click += new EventHandler(ReadSnmpValue);
            m_menuSnmp.Items.Add(item);

            m_menuEcrireSnmp = new ToolStripMenuItem(I.T("Write snmp value|20352"));
            m_menuEcrireSnmp.Click += new EventHandler(WriteValue);
            m_menuSnmp.Items.Add(m_menuEcrireSnmp);

            item = new ToolStripMenuItem(I.T("Read this entity from SNMP|20318"));
            item.Click += new EventHandler(ReadSnmpEntity);
            m_menuSnmp.Items.Add(item);

            item = new ToolStripMenuItem(I.T("Read all agent from SNMP|20319"));
            item.Click += new EventHandler(ReadSnmpAgent);
            m_menuSnmp.Items.Add(item);

            CEntiteSnmp ett = EditedElement as CEntiteSnmp;
            if ( ett != null && ett.AgentSnmp != null )
            {
                m_menuAddToPolled = new ToolStripMenuItem(I.T("Add to polled data|20856"));
                m_menuAddToPolled.DropDownOpening += new EventHandler(m_menuAddToPolled_DropDownOpening);
                m_menuSnmp.Items.Add ( m_menuAddToPolled );

                m_menuAddToPolled.DropDownItems.Add("DUMMY");
            }

            m_menuOID = new ToolStripMenuItem("");
            m_menuSnmp.Items.Add(m_menuOID);
            m_menuOID.Click += new EventHandler(m_menuOID_Click);
        }

        //-----------------------------------------------
        void m_menuOID_Click(object sender, EventArgs e)
        {
            ToolStripItem item = sender as ToolStripItem;
            string strOID = item != null?item.Tag as string:null;
            if (strOID != null)
                Clipboard.SetText(strOID);
        }

        //-----------------------------------------------
        void m_menuAddToPolled_DropDownOpening(object sender, EventArgs e)
        {
            m_menuAddToPolled.DropDownItems.Clear();
            CEntiteSnmp ett = EditedElement as CEntiteSnmp;
            if (ett != null)
            {
                foreach (CSnmpPollingSetup p in ett.AgentSnmp.ParametresPolling)
                {
                    ToolStripMenuItem itemPollSetup = new ToolStripMenuItem(p.Libelle);
                    m_menuAddToPolled.DropDownItems.Add(itemPollSetup);
                    itemPollSetup.Tag = p;
                    itemPollSetup.DropDownItems.Add("DUMMY");
                    itemPollSetup.DropDownOpening += new EventHandler(itemPollSetup_DropDownOpening);
                }
            }
        }

        //-----------------------------------------------
        private class CAddToPollData
        {
            public readonly CChampDonneeCumulee Champ;
            public readonly CSnmpPollingSetup PollSetup;

            public CAddToPollData(CSnmpPollingSetup pollSetup, CChampDonneeCumulee champ)
            {
                PollSetup = pollSetup;
                Champ = champ;
            }
        }

        //-----------------------------------------------
        void itemPollSetup_DropDownOpening(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if ( item != null )
                item.DropDownItems.Clear();
            CSnmpPollingSetup setup = item != null ? item.Tag as CSnmpPollingSetup : null;
            CEntiteSnmp ett = EditedElement as CEntiteSnmp;
            if (setup != null && ett != null)
            {
                CTypeDonneeCumulee tp = new CTypeDonneeCumulee(ett.ContexteDonnee);
                if (tp.ReadIfExists(setup.IdTypeDonneeCumulee))
                {
                    foreach (CChampDonneeCumulee champ in tp.GetChampsRenseignes())
                    {
                        string strNomChamp = tp.GetNomChamp(champ);
                        if (strNomChamp != null && strNomChamp.Length > 0)
                        {
                            ToolStripMenuItem itemAddToPolledField = new ToolStripMenuItem(strNomChamp);
                            itemAddToPolledField.Tag = new CAddToPollData(setup, champ);
                            itemAddToPolledField.Click += new EventHandler(itemAddToPolledField_Click);
                            item.DropDownItems.Add(itemAddToPolledField);
                        }
                    }
                }
            }
        }

        //-----------------------------------------------
        void itemAddToPolledField_Click(object sender, EventArgs e)
        {
            CEntiteSnmp ett = EditedElement as CEntiteSnmp;
            if (ett != null)
            {
            }
        }

       

        //-----------------------------------------------
        void WriteValue(object sender, EventArgs e)
        {
            CEntiteSnmp entiteSnmp = EditedElement as CEntiteSnmp;
            if (entiteSnmp != null)
            {
                CResultAErreur result = MajChamps(true);
                if (!result)
                {
                    CFormAlerte.Afficher(result.Erreur);
                    return;
                }
                CRelationEntiteSnmp_ChampCustom rel = CUtilElementAChamps.GetRelationToChamp(entiteSnmp, ((CChampCustom)WndSnmp.FieldZone.Variable).Id) as CRelationEntiteSnmp_ChampCustom;
                if (rel != null)
                {
                    result = rel.WriteSnmpValue();
                    if (!result)
                    {
                        CFormAlerte.Afficher(result.Erreur);
                    }
                    else
                    {
                        ReadSnmpValue(this, null);
                        MyUpdateValeursCalculees();
                    }
                }
            }
        }

        void ReadSnmpAgent(object sender, EventArgs e)
        {
            CEntiteSnmp entite = EditedElement as CEntiteSnmp;
            if (entite != null && entite.AgentSnmp != null)
            {
                CResultAErreur result = CResultAErreur.True;
                using (CWaitCursor waiter = new CWaitCursor())
                {
                    result = entite.AgentSnmp.LireValeursSnmp();
                    //Trouve le parent 
                    IRuntimeFor2iWnd parent = this;
                    while (parent.WndContainer is IRuntimeFor2iWnd)
                    {
                        parent = parent.WndContainer as IRuntimeFor2iWnd;
                    }
                    parent.UpdateValeursCalculees();
                }
                if (!result)
                    CFormAlerte.Afficher(result.Erreur);
            }
        }

        void ReadSnmpEntity(object sender, EventArgs e)
        {
            CEntiteSnmp entite = EditedElement as CEntiteSnmp;
            if (entite != null )
            {
                
                CResultAErreur result =  CResultAErreur.True;
                using (CWaitCursor waiter = new CWaitCursor())
                {
                    result = entite.LireValeursSnmp();
                    //Trouve le parent 
                    IRuntimeFor2iWnd parent = this;
                    while (parent.WndContainer is IRuntimeFor2iWnd)
                    {
                        parent = parent.WndContainer as IRuntimeFor2iWnd;
                    }
                    parent.UpdateValeursCalculees();
                }
                if (!result)
                    CFormAlerte.Afficher(result.Erreur);
            }
        }

        //---------------------------------------------
        void ReadSnmpValue(object sender, EventArgs e)
        {
            CEntiteSnmp entiteSnmp = EditedElement as CEntiteSnmp;
            if (entiteSnmp != null)
            {
                CRelationEntiteSnmp_ChampCustom rel = CUtilElementAChamps.GetRelationToChamp(entiteSnmp, ((CChampCustom)WndSnmp.FieldZone.Variable).Id) as CRelationEntiteSnmp_ChampCustom;
                if (rel != null)
                {
                    CResultAErreur result = rel.UpdateSnmpValue();
                    if (!result)
                    {
                        CFormAlerte.Afficher(result.Erreur);
                    }
                    else
                        MyUpdateValeursCalculees();
                }
            }
                
        }


        private bool m_bIsInLockEditionChanged = false;
        void CWndForWndChampSnmp_OnChangeLockEdition(object sender, EventArgs e)
        {
            if (m_bIsInLockEditionChanged)
                return;
            m_bIsInLockEditionChanged = true;
            if (sender is IControlALockEdition)
                ((IControlALockEdition)sender).LockEdition = true;
            m_bIsInLockEditionChanged = false;
        }

		//-------------------------------------
		private C2iWndChampSnmp WndSnmp
		{
			get
			{
				return WndAssociee as C2iWndChampSnmp;
			}
		}

		//---------------------------------------------------------------
		public override Control Control
		{
			get
			{
				return m_panel;
			}
		}

		//---------------------------------------------------------------
		protected override void OnChangeElementEdite(object elementEdite)
		{
			if ( m_wndChamp!= null )
				m_wndChamp.SetElementEdite ( elementEdite );
			UpdateValeursCalculees();
		}


		//---------------------------------------------------------------
		protected override CResultAErreur MyMajChamps(bool bAvecVerificationDeDonnees )
		{
			CResultAErreur result = CResultAErreur.True;
			if ( m_wndChamp != null )
				result = m_wndChamp.MajChamps ( true );
			return result;
		}

		//-------------------------------------
		protected override void  MyUpdateValeursCalculees()
		{
			if ( m_controleSnmp ==null)
				return;
			CEntiteSnmp entiteSnmp = EditedElement as CEntiteSnmp;
			if ( entiteSnmp == null )
				return;

            CRelationEntiteSnmp_ChampCustom rel = CUtilElementAChamps.GetRelationToChamp(entiteSnmp, ((CChampCustom)WndSnmp.FieldZone.Variable).Id) as CRelationEntiteSnmp_ChampCustom;
            if (m_createur != null && m_controleSnmp != null)
                m_createur.SetTooltip(m_controleSnmp, "");
            if (rel == null)
            {
                m_controleSnmp.Visible = false;
                m_imageWarning.Visible = false;
                
            }
            else
            {
                CDateTimeEx dt = rel.DateSynchroSnmp;
                if (dt != null)
                {
                    if (m_createur != null && m_controleSnmp != null)
                        m_createur.SetTooltip ( m_controleSnmp, I.T("Last updated : @1 @2|20317",
                            dt.DateTimeValue.ToShortDateString() ,
                            dt.DateTimeValue.ToLongTimeString()));
                }
                m_controleSnmp.Visible = true;
                object val = rel.LastSnmpValue;
                if (val == null)
                    m_controleSnmp.Text = "";
                else
                {
                    if (WndSnmp.ChampCustom.IsChoixParmis())
                        m_controleSnmp.Text = WndSnmp.ChampCustom.DisplayFromValue(val);
                    else if (m_controleSnmp is CheckBox)
                        ((CheckBox)m_controleSnmp).Checked = (val is bool) ? (bool)val : false;
                    else
                        m_controleSnmp.Text = val.ToString();
                }
                string strVal1 = m_wndChamp.Value != null ? m_wndChamp.Value.ToString() : "";
                string strVal2 = val != null ? val.ToString() : "";

                if (strVal1 != strVal2 && rel.DateSynchroSnmp != null)
                {
                    m_imageWarning.Visible = true;
                    m_controleSnmp.Width = m_wndChamp.Control.Width - 16;
                }
                else
                {
                    m_imageWarning.Visible = false;
                    m_controleSnmp.Width = m_wndChamp.Control.Width;
                }
            }
            
            
		}



		//---------------------------------------------
        protected override void MyAppliqueRestriction(
            CRestrictionUtilisateurSurType restrictionSurObjetEdite,
            CListeRestrictionsUtilisateurSurType restrictions,
            IGestionnaireReadOnlySysteme gestionnaireReadOnly)
		{
			if ( m_wndChamp != null )
				m_wndChamp.AppliqueRestriction(restrictionSurObjetEdite,
                    restrictions,
                    gestionnaireReadOnly);
		}



        #region IControlIncluableDansDataGrid Membres
        private DataGridView m_view = null;
        public DataGridView DataGrid
        {
            get
            {
                return m_view;
            }
            set
            {
                m_view = value;
            }
        }


        public void SelectAll()
        {
            if (m_wndChamp != null)
                m_wndChamp.SelectAll();
        }

        public bool WantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)
        {
            if (m_wndChamp != null)
                return m_wndChamp.WantsInputKey(keyData, dataGridViewWantsInputKey);
            return !dataGridViewWantsInputKey;
        }

        #endregion
    }
}
