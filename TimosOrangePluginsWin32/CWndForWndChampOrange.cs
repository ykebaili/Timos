using System;
using System.Collections.Generic;
using System.Text;
using sc2i.win32.common;
using sc2i.formulaire.win32;
using sc2i.formulaire.win32.controles2iWnd;
using sc2i.win32.data.dynamic.controlesFor2iWnd;
using TimosOrangePlugins;
using timos.data;
using sc2i.formulaire;
using System.Windows.Forms;
using sc2i.expression;
using sc2i.common;
using sc2i.data.dynamic;
using System.Drawing;
using sc2i.common.Restrictions;

namespace TimosOrangePluginsWin32
{
	[AutoExec("Autoexec")]
	public class CWndForWndChampOrange : CControlWndFor2iWnd, IControleWndFor2iWnd
	{
		private C2iPanel m_panel = new C2iPanel();
		private const int c_nIdChampeltAChampOrange = 397;
		private const int c_nIdChampEquipementOrange = 408;

		CWndFor2iLabel m_wndForLabel = null;
		CWndFor2iWndVariable m_wndChamp = null;

        Control m_controleOrange = null;
		//CWndFor2iLabel m_wndValeurOrange = null;

        PictureBox m_imageWarning = null;

		//---------------------------------------------------------------
		public static void Autoexec()
		{
			CCreateur2iFormulaireV2.RegisterEditeur(typeof(C2iWndChampOrange), typeof(CWndForWndChampOrange));
		}

		//---------------------------------------------------------------
        protected override void MyCreateControle(
            CCreateur2iFormulaireV2 createur,
            C2iWnd wnd,
            Control parent,
            IFournisseurProprietesDynamiques fournisseurProprietes)
        {

            if (WndOrange == null)
                return;

            CCreateur2iFormulaireV2.AffecteProprietesCommunes(WndOrange, m_panel);
            parent.Controls.Add(m_panel);
            m_wndForLabel = createur.CreateControle(WndOrange.LabelZone, m_panel, fournisseurProprietes) as CWndFor2iLabel;
            m_wndChamp = createur.CreateControle(WndOrange.FieldZone, m_panel, fournisseurProprietes) as CWndFor2iWndVariable;
            CChampCustom champCustom = null;
            if (WndOrange.FieldZone.ChampCustom != null)
                champCustom = WndOrange.FieldZone.ChampCustom;
            //m_wndValeurOrange = createur.CreateControle(WndOrange.OrangeZone, m_panel, fournisseurProprietes) as CWndFor2iLabel;
            if (champCustom != null)
            {
                switch (champCustom.TypeDonneeChamp.TypeDonnee)
                {
                    case TypeDonnee.tBool:
                        m_controleOrange = new CheckBox();
                        m_controleOrange.Enabled = false;
                        break;
                    case TypeDonnee.tDate:
                    case TypeDonnee.tDouble:
                    case TypeDonnee.tEntier:
                    case TypeDonnee.tString:
                        m_controleOrange = new C2iTextBox();
                        if (WndOrange.FieldZone.MultiLine)
                            ((C2iTextBox)m_controleOrange).Multiline = true;
                        ((C2iTextBox)m_controleOrange).LockEdition = true;
                        ((C2iTextBox)m_controleOrange).OnChangeLockEdition += new EventHandler(CWndForWndChampOrange_OnChangeLockEdition);
                        break;
                    default:
                        break;
                }
                if (m_controleOrange != null)
                {
                    m_panel.Controls.Add(m_controleOrange);
                    m_controleOrange.Location = WndOrange.OrangeZone.Position;
                    m_controleOrange.Size = WndOrange.OrangeZone.Size;
                    m_controleOrange.BackColor = WndOrange.OrangeZone.BackColor;
                    m_controleOrange.ForeColor = WndOrange.OrangeZone.ForeColor;
                    switch (WndOrange.OrangeZone.DockStyle)
                    {
                        case sc2i.formulaire.EDockStyle.Bottom:
                            m_controleOrange.Dock = DockStyle.Bottom;
                            break;
                        case sc2i.formulaire.EDockStyle.Fill:
                            m_controleOrange.Dock = DockStyle.Fill;
                            break;
                        case sc2i.formulaire.EDockStyle.Left:
                            m_controleOrange.Dock = DockStyle.Left;
                            break;
                        case sc2i.formulaire.EDockStyle.None:
                            m_controleOrange.Dock = DockStyle.None;
                            break;
                        case sc2i.formulaire.EDockStyle.Right:
                            m_controleOrange.Dock = DockStyle.Right;
                            break;
                        case sc2i.formulaire.EDockStyle.Top:
                            m_controleOrange.Dock = DockStyle.Top;
                            break;
                        default:
                            break;
                    }
                }
            }
            m_imageWarning = new PictureBox();
            m_panel.Controls.Add(m_imageWarning);
            if (m_controleOrange != null)
            {
                m_imageWarning.Location = new Point(m_controleOrange.Location.X + m_controleOrange.Size.Width - 16,
                    m_controleOrange.Location.Y );
            }
            m_imageWarning.Size = new Size(16, m_controleOrange.Height);
            m_imageWarning.BackColor = m_controleOrange.BackColor;
            m_imageWarning.SizeMode = PictureBoxSizeMode.CenterImage;
            m_imageWarning.Image = Properties.Resources.Warning;
            m_imageWarning.BringToFront();
            m_imageWarning.Visible = false;

            
        }

        private bool m_bIsInLockEditionChanged = false;
        void CWndForWndChampOrange_OnChangeLockEdition(object sender, EventArgs e)
        {
            if (m_bIsInLockEditionChanged)
                return;
            m_bIsInLockEditionChanged = true;
            if (sender is IControlALockEdition)
                ((IControlALockEdition)sender).LockEdition = true;
            m_bIsInLockEditionChanged = false;
        }

		//-------------------------------------
		private C2iWndChampOrange WndOrange
		{
			get
			{
				return WndAssociee as C2iWndChampOrange;
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
			if ( m_controleOrange ==null)
				return;
			IElementAChamps eltAChampTibco = EditedElement as IElementAChamps;
			if ( eltAChampTibco == null )
				return;
			IElementAChamps eltAChampOrange = null;
			int nIdChamp = c_nIdChampeltAChampOrange;
			if (eltAChampTibco is CEquipementLogique)
				nIdChamp = c_nIdChampEquipementOrange;

			eltAChampOrange = eltAChampTibco.GetValeurChamp(nIdChamp) as IElementAChamps;
            if (eltAChampOrange == null)
            {
                m_controleOrange.Visible = false;
                m_imageWarning.Visible = false;
            }
            else
            {
                m_controleOrange.Visible = true;
                object val = eltAChampOrange.GetValeurChamp(WndOrange.ChampCustom.Id);
                if (val == null)
                    m_controleOrange.Text = "";
                else
                {
                    if (WndOrange.ChampCustom.IsChoixParmis())
                        m_controleOrange.Text = WndOrange.ChampCustom.DisplayFromValue(val);
                    else if (m_controleOrange is CheckBox)
                        ((CheckBox)m_controleOrange).Checked = (val is bool) ? (bool)val : false;
                    else
                        m_controleOrange.Text = val.ToString();
                }
                string strVal1 = m_wndChamp.Value != null ? m_wndChamp.Value.ToString() : "";
                string strVal2 = val != null ? val.ToString() : "";

                if (strVal1 != strVal2)
                {
                    m_imageWarning.Visible = true;
                    m_controleOrange.Width = m_wndChamp.Control.Width - 16;
                }
                else
                {
                    m_imageWarning.Visible = false;
                    m_controleOrange.Width = m_wndChamp.Control.Width;
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


	}
}
