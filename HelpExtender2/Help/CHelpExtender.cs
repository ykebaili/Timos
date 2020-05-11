using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;

namespace HelpExtender
{
	public partial class CHelpExtender
	{
		#region :: Propriétés ::
		
		private static int m_nHookHandle = 0;
		//Indique si l'utilisateur est autorisé à passer en mode édition
		private static bool m_bAutoriseModeEdition = false;
		//Indique si on est en mode édition
		private static bool m_bModeEdition;
		private static HookProc m_hookProc = new HookProc(OnHook); 
		private static int m_nIdProcess = -1;

		public delegate int HookProc(int code, int wparam, int lparam);
		#endregion

		#region API Windows
		[DllImport("user32.dll")]
		public static extern int SetWindowsHookEx(int hookType,
												   HookProc callback,
												   int instance,
												   int threadID);
		[DllImport("user32.dll")]
		public static extern int CallNextHookEx(int hookHandle, int code,
												int wparam, int lparam);
		[DllImport("user32.dll")]
		public static extern bool UnhookWindowsHookEx(int hookHandle);
		[DllImport("user32.dll")]
		public static extern int GetKeyState(int vKey);

		[DllImport("user32.dll")]
		static extern IntPtr GetForegroundWindow();
		#endregion

		public const int WH_KEYBOARD = 2;

		//-----------------------------------------
		public static bool ModeEdition
		{
			get
			{
				return m_bModeEdition;
			}
			set
			{
				m_bModeEdition = value;

			}
		}

		//-------------------------------------------
		public static bool AutoriseModeEdition
		{
			get
			{
				return m_bAutoriseModeEdition;
			}
			set
			{
				m_bAutoriseModeEdition = value;
			}
		}

		//-----------------------------------------
		public static void Init(bool modeEdition)
		{
			m_bAutoriseModeEdition = modeEdition;
			m_nIdProcess = Process.GetCurrentProcess().Id;
			m_nHookHandle = SetWindowsHookEx(WH_KEYBOARD, m_hookProc, 0,
				AppDomain.GetCurrentThreadId() );
										  //Thread.CurrentThread.ManagedThreadId);
		}

		

		//-----------------------------------------
		private void Release()
		{
			if (m_nHookHandle != 0)
				UnhookWindowsHookEx(m_nHookHandle);
			m_nHookHandle = 0;
		}

		//-----------------------------------------
		private static Control FindFocused(Control ctrl)
		{
			if (ctrl is Form && ((Form)ctrl).IsMdiContainer)
			{
				Form frmMdi = ((Form)ctrl).ActiveMdiChild;
				if (frmMdi != null)
					ctrl = frmMdi;
			}
			foreach (Control ctrlFils in ctrl.Controls)
			{
				Control set = FindFocused(ctrlFils);
				if (set != ctrlFils)
					return set;
				if (ctrlFils.Focused)
					return ctrlFils;
			}
			return ctrl;
		}

		//-----------------------------------------
		private static Control m_lastControl;
		public static Control GetLastActiveControl()
		{
			return m_lastControl;
		}


		#region HOOK
		//-----------------------------------------
		private static int m_nNbFormvisible = 0;
		private static int OnHook(int nCode, int wParam, int lParam)
		{
			try
			{
				if (nCode == 0)
				{
					if (wParam == (int)Keys.F1)
					{
						if (lParam < 0)
						{
							Process process = Process.GetProcessById(m_nIdProcess);
							Control ctrl = null;
							if (process != null)
								ctrl = System.Windows.Forms.Form.ActiveForm;
							if (ctrl != null)
							{
								m_lastControl = ctrl;
								ctrl = FindFocused(ctrl);
								m_nNbFormvisible++;
								try
								{
									if (m_nNbFormvisible == 1)
									{
										Control pere = ctrl;
										while (pere != null)
										{
											//if (pere.GetType() == typeof(MdiClient))
											//    pere = null;
											//else
											//{
												CHelpData.FenetreActive = pere;

												pere = pere.Parent;
											//}
										}

										CHelpData help = CHelpData.GetHelp(ctrl, "");
										CFormAide.ShowHelp(help,ctrl);
										
									}
								}
								catch
								{
									//MessageBox.Show(e.Message);
								}
								finally
								{
									m_nNbFormvisible--;
								}
							}
						}
					}
				}
			}
			catch
			{
			}
			return 0;
		}
		#endregion

		#region Clignotement Control
		#region :: Propriétés ::
		private static int m_nIncrement;
		private static int m_nValeurVert;
		private static Color m_lastBackColor;
		private static Control m_lastControleClignote;
		private static System.Windows.Forms.Timer m_timer;
		#endregion
		#region ~~ Méthodes ~~
		public static void InitialiserTimer()
		{
			if (!m_bModeEdition)
				return;
			m_nIncrement = 10;
			m_timer = new System.Windows.Forms.Timer();
			m_timer.Interval = 50;
			m_timer.Tick += new EventHandler(m_timer_Tick);
		}

		public static void FaireClignoterControl(CHelpData.CtrlPartiel ctrl)
		{
			Control c = CHelpData.GetControl(ctrl);
			if (c != null)
				FaireClignoterControl(c);
		}
		public static void FaireClignoterControl(Control ctrl)
		{
			if(m_timer == null)
				InitialiserTimer();

			ArreterClignotementControl();
			m_lastBackColor = ctrl.BackColor;
			m_lastControleClignote = ctrl;
			m_nValeurVert = ctrl.BackColor.G;
			if ( m_timer != null )
				m_timer.Start();
		}
		public static void RepriseClignementControle()
		{
			if (m_timer != null)
				m_timer.Start();
		}
		public static void ArreterClignotementControl()
		{
			if (m_timer != null)
			{
				try
				{
					m_timer.Stop();

					if (m_lastControleClignote != null)
						m_lastControleClignote.BackColor = m_lastBackColor;
				}
				catch
				{ }
			}
		}
		#endregion
		#region ** Evenements **
		static void m_timer_Tick(object sender, EventArgs e)
		{
			try
			{
				if (m_lastControleClignote != null)
				{
					m_nValeurVert += m_nIncrement;
					if (m_nValeurVert < 0)
					{
						m_nValeurVert = 0;
						m_nIncrement = 10;
					}
					if (m_nValeurVert > 255)
					{
						m_nValeurVert = 255;
						m_nIncrement = -10;
					}
					Color c = Color.FromArgb(m_lastBackColor.R, m_nValeurVert, m_lastBackColor.B);
					m_lastControleClignote.BackColor = c;
				}
			}
			catch
			{
			}
		}
		#endregion
		#endregion


	}
}


