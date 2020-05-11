using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Reflection;

using System.Windows.Forms;
using System.Drawing;
using sc2i.workflow;

namespace timos.win32.composants
{
	[ProvideProperty("RichToolTipGetAtMethod", typeof(Control))]
	[ProvideProperty("RichToolTipMethodProvider", typeof(Control))]
	public partial class ModeleTexteToolTip : Component, IExtenderProvider
	{
		private Dictionary<Control, string> m_tableControleToMethod = new Dictionary<Control, string>();
		private Dictionary<Control, Control> m_tableControleToMethodProvider = new Dictionary<Control, Control>();
		
		private string m_strContexte;

		private bool m_bEnabled = true;
		
		public ModeleTexteToolTip()
		{
			InitializeComponent();
		}

		public ModeleTexteToolTip(IContainer container)
		{
			container.Add(this);

			InitializeComponent();
		}

		//-------------------------------------------------------------------------
		public string TooltipContext
		{
			get
			{
				return m_strContexte;
			}
			set
			{
				m_strContexte = value;
			}
		}

		//-------------------------------------------------------------------------
		public virtual void SetRichToolTipGetAtMethod(object extendee, string strValue)
		{
			if ( extendee is Control )
			{
				m_tableControleToMethod[(Control)extendee] = strValue;
				if ( !DesignMode && strValue.Trim() != "" )
				{
					((Control)extendee).MouseLeave += new EventHandler(ModeleTexteToolTip_MouseLeave);
					((Control)extendee).MouseMove += new MouseEventHandler(ModeleTexteToolTip_MouseMove);
					((Control)extendee).MouseDown += new MouseEventHandler(ModeleTexteToolTip_MouseDown);
					((Control)extendee).MouseUp += new MouseEventHandler(ModeleTexteToolTip_MouseUp);
				}
			}
		}

		

		//-------------------------------------------------------------------------
		public virtual string GetRichToolTipGetAtMethod(object extendee)
		{
			if (extendee is Control && m_tableControleToMethod.ContainsKey((Control)extendee))
				return m_tableControleToMethod[(Control)extendee];
			return "";
		}

		//-------------------------------------------------------------------------
		public virtual void SetRichToolTipMethodProvider(object extendee, Control ctrl)
		{
			if ( extendee is Control )
			{
				m_tableControleToMethodProvider[(Control)extendee] = ctrl;
			}
		}

		//-------------------------------------------------------------------------
		public virtual Control GetRichToolTipMethodProvider(object extendee)
		{
			if (extendee is Control && m_tableControleToMethodProvider.ContainsKey((Control)extendee))
				return m_tableControleToMethodProvider[(Control)extendee];
			return null;
		}

		//-------------------------------------------------------------------------
		void ModeleTexteToolTip_MouseUp(object sender, MouseEventArgs e)
		{
			m_timer.Enabled = false;
			m_bAfficheSansDelai = false;
			HideToolTip();
		}

		void ModeleTexteToolTip_MouseDown(object sender, MouseEventArgs e)
		{
			m_timer.Enabled = false;
			m_bAfficheSansDelai = false;
			HideToolTip();
		}
		
	
		//-------------------------------------------------------------------------
		public bool CanExtend ( object extendee )
		{
			if ( extendee is Control )
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		//-----------------------------------------------------------------
		private object m_lastObjetPopup = null;
		private Point m_lastPoint = new Point(0, 0);
		private Control m_lastControlMouseMove = null;
		private Control m_providerMethodPourControleEnCours = null;
		private MethodInfo m_methodeGetAt = null;
		private bool m_bAfficheSansDelai = false;
		private DateTime m_lastDatePopup = DateTime.Now;
		void ModeleTexteToolTip_MouseMove(object sender, MouseEventArgs e)
		{
			if (!m_bEnabled)
				return;
			if (sender == m_lastControlMouseMove &&
				e.X == m_lastPoint.X && e.Y == m_lastPoint.Y)
				return;
			TimeSpan sp = DateTime.Now - m_lastDatePopup;
			if (sp.TotalSeconds > 2)
				m_bAfficheSansDelai = false;
			m_lastPoint = new Point(e.X, e.Y);
			m_timer.Enabled = false;
			if (sender is Control && e.Button == MouseButtons.None)
			{
				if (!m_bAfficheSansDelai)
				{
					HideToolTip();
					m_timer.Enabled = true;
					return;
				}
				if (sender != m_lastControlMouseMove)
				{
					m_lastControlMouseMove = (Control)sender;
					m_providerMethodPourControleEnCours = m_lastControlMouseMove;
					if (m_tableControleToMethodProvider.ContainsKey(m_lastControlMouseMove))
						m_providerMethodPourControleEnCours = m_tableControleToMethodProvider[m_lastControlMouseMove];
					m_methodeGetAt = m_providerMethodPourControleEnCours.GetType().GetMethod(
						m_tableControleToMethod[m_lastControlMouseMove],
						new Type[] { typeof(Point) });
				}
				try
				{
					Point pt = new Point(e.X, e.Y);
					object obj = m_methodeGetAt.Invoke(m_providerMethodPourControleEnCours, new object[] { pt });
					if (obj == null)
					{
						HideToolTip();
					}
					else
					{
						if (obj is IObjetAToolTipModeleSpecial)
							obj = ((IObjetAToolTipModeleSpecial)obj).ObjetPourToolTip;
						m_lastDatePopup = DateTime.Now;
						if (!obj.Equals(m_lastObjetPopup))
						{
							ShowToolTip(obj);
						}
					}
				}
				catch
				{
					HideToolTip();
				}
			}
		}

		//-----------------------------------------------------------------
		void ModeleTexteToolTip_MouseLeave(object sender, EventArgs e)
		{
			HideToolTip();
			m_bAfficheSansDelai = false;
		}

		//-----------------------------------------------------------------
		private void m_timer_Tick(object sender, EventArgs e)
		{
			m_timer.Enabled = false;
			m_bAfficheSansDelai = true;
			m_lastPoint.Offset(1, 0);
			m_lastDatePopup = DateTime.Now;
			ModeleTexteToolTip_MouseMove ( m_lastControlMouseMove, new MouseEventArgs ( MouseButtons.None, 0, m_lastPoint.X-1, m_lastPoint.Y, 0 ));
		}

		//-----------------------------------------------------------------
		public void ShowToolTip(object objet)
		{
			if (objet == null)
				return;
			m_lastObjetPopup = objet;
			CModeleTexte modele = CTimosAppRegistre.GetModeleTexteForType(m_strContexte, objet.GetType());
			if (modele != null)
			{
				if (m_lastControlMouseMove != null)
				{
					Point pt = m_lastControlMouseMove.PointToScreen(m_lastPoint);
					pt.Offset(16, 16);
					CRichTextViewerPopup.Popup( pt, modele, objet);
				}
			}

		}

		//-----------------------------------------------------------------
		public void HideToolTip()
		{
			CRichTextViewerPopup.HideTooltip();
            m_bAfficheSansDelai = false;
			m_lastObjetPopup = null;
		}

		//-----------------------------------------------------------------
		public bool Enable
		{
			get
			{
				return m_bEnabled;
			}
			set
			{
				m_bEnabled = value;
				if (!value) 
					HideToolTip();
			}
		}

	}

	

}

