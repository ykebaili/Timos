using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;


namespace HelpExtender
{
	public class WebViewerEx : WebBrowser
	{

		#region :: Propriétés ::
		private bool _liensVersHelpActifs;
		#endregion

		#region Interop-Defines
		[ StructLayout( LayoutKind.Sequential )]
		private struct CHARFORMAT2_STRUCT
		{
			public UInt32	cbSize; 
			public UInt32   dwMask; 
			public UInt32   dwEffects; 
			public Int32    yHeight; 
			public Int32    yOffset; 
			public Int32	crTextColor; 
			public byte     bCharSet; 
			public byte     bPitchAndFamily; 
			[MarshalAs(UnmanagedType.ByValArray, SizeConst=32)]
			public char[]   szFaceName; 
			public UInt16	wWeight;
			public UInt16	sSpacing;
			public int		crBackColor; // Color.ToArgb() -> int
			public int		lcid;
			public int		dwReserved;
			public Int16	sStyle;
			public Int16	wKerning;
			public byte		bUnderlineType;
			public byte		bAnimation;
			public byte		bRevAuthor;
			public byte		bReserved1;
		}

		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

		private const int WM_USER			 = 0x0400;
		private const int EM_GETCHARFORMAT	 = WM_USER+58;
		private const int EM_SETCHARFORMAT	 = WM_USER+68;

		private const int SCF_SELECTION	= 0x0001;
		private const int SCF_WORD		= 0x0002;
		private const int SCF_ALL		= 0x0004;

		#region CHARFORMAT2 Flags
		private const UInt32 CFE_BOLD		= 0x0001;
		private const UInt32 CFE_ITALIC		= 0x0002;
		private const UInt32 CFE_UNDERLINE	= 0x0004;
		private const UInt32 CFE_STRIKEOUT	= 0x0008;
		private const UInt32 CFE_PROTECTED	= 0x0010;
		private const UInt32 CFE_LINK		= 0x0020;
		private const UInt32 CFE_AUTOCOLOR	= 0x40000000;
		private const UInt32 CFE_SUBSCRIPT	= 0x00010000;		/* Superscript and subscript are */
		private const UInt32 CFE_SUPERSCRIPT= 0x00020000;		/*  mutually exclusive			 */

		private const int CFM_SMALLCAPS		= 0x0040;			/* (*)	*/
		private const int CFM_ALLCAPS		= 0x0080;			/* Displayed by 3.0	*/
		private const int CFM_HIDDEN		= 0x0100;			/* Hidden by 3.0 */
		private const int CFM_OUTLINE		= 0x0200;			/* (*)	*/
		private const int CFM_SHADOW		= 0x0400;			/* (*)	*/
		private const int CFM_EMBOSS		= 0x0800;			/* (*)	*/
		private const int CFM_IMPRINT		= 0x1000;			/* (*)	*/
		private const int CFM_DISABLED		= 0x2000;
		private const int CFM_REVISED		= 0x4000;

		private const int CFM_BACKCOLOR		= 0x04000000;
		private const int CFM_LCID			= 0x02000000;
		private const int CFM_UNDERLINETYPE	= 0x00800000;		/* Many displayed by 3.0 */
		private const int CFM_WEIGHT		= 0x00400000;
		private const int CFM_SPACING		= 0x00200000;		/* Displayed by 3.0	*/
		private const int CFM_KERNING		= 0x00100000;		/* (*)	*/
		private const int CFM_STYLE			= 0x00080000;		/* (*)	*/
		private const int CFM_ANIMATION		= 0x00040000;		/* (*)	*/
		private const int CFM_REVAUTHOR		= 0x00008000;


		private const UInt32 CFM_BOLD		= 0x00000001;
		private const UInt32 CFM_ITALIC		= 0x00000002;
		private const UInt32 CFM_UNDERLINE	= 0x00000004;
		private const UInt32 CFM_STRIKEOUT	= 0x00000008;
		private const UInt32 CFM_PROTECTED	= 0x00000010;
		private const UInt32 CFM_LINK		= 0x00000020;
		private const UInt32 CFM_SIZE		= 0x80000000;
		private const UInt32 CFM_COLOR		= 0x40000000;
		private const UInt32 CFM_FACE		= 0x20000000;
		private const UInt32 CFM_OFFSET		= 0x10000000;
		private const UInt32 CFM_CHARSET	= 0x08000000;
		private const UInt32 CFM_SUBSCRIPT	= CFE_SUBSCRIPT | CFE_SUPERSCRIPT;
		private const UInt32 CFM_SUPERSCRIPT= CFM_SUBSCRIPT;

		private const byte CFU_UNDERLINENONE		= 0x00000000;
		private const byte CFU_UNDERLINE			= 0x00000001;
		private const byte CFU_UNDERLINEWORD		= 0x00000002; /* (*) displayed as ordinary underline	*/
		private const byte CFU_UNDERLINEDOUBLE		= 0x00000003; /* (*) displayed as ordinary underline	*/
		private const byte CFU_UNDERLINEDOTTED		= 0x00000004;
		private const byte CFU_UNDERLINEDASH		= 0x00000005;
		private const byte CFU_UNDERLINEDASHDOT		= 0x00000006;
		private const byte CFU_UNDERLINEDASHDOTDOT	= 0x00000007;
		private const byte CFU_UNDERLINEWAVE		= 0x00000008;
		private const byte CFU_UNDERLINETHICK		= 0x00000009;
		private const byte CFU_UNDERLINEHAIRLINE	= 0x0000000A; /* (*) displayed as ordinary underline	*/

		#endregion

		#endregion

		#region ++ Constructeurs ++
		public WebViewerEx()
		{
			_liensVersHelpActifs = true;
			_navigationEnCour = false;
			Navigating += new WebBrowserNavigatingEventHandler(Navigation);
			Navigated += new WebBrowserNavigatedEventHandler(WebViewerEx_Navigated);

		}
		#endregion

		#region ~~ Méthodes ~~
		public void Precedant()
		{
			GoBack();
		}
		public void Suivant()
		{
			GoForward();
		}
		/// <summary>
		/// Set the current selection's link style
		/// </summary>
		/// <param name="link">true: set link style, false: clear link style</param>
		public void SetSelectionLink(bool link)
		{
			SetSelectionStyle(CFM_LINK, link ? CFE_LINK : 0);
		}
		/// <summary>
		/// Get the link style for the current selection
		/// </summary>
		/// <returns>0: link style not set, 1: link style set, -1: mixed</returns>
		public int GetSelectionLink()
		{
			return GetSelectionStyle(CFM_LINK, CFE_LINK);
		}
		private void SetSelectionStyle(UInt32 mask, UInt32 effect)
		{
			CHARFORMAT2_STRUCT cf = new CHARFORMAT2_STRUCT();
			cf.cbSize = (UInt32)Marshal.SizeOf(cf);
			cf.dwMask = mask;
			cf.dwEffects = effect;

			IntPtr wpar = new IntPtr(SCF_SELECTION);
			IntPtr lpar = Marshal.AllocCoTaskMem(Marshal.SizeOf(cf));
			Marshal.StructureToPtr(cf, lpar, false);

			IntPtr res = SendMessage(Handle, EM_SETCHARFORMAT, wpar, lpar);

			Marshal.FreeCoTaskMem(lpar);
		}
		private int GetSelectionStyle(UInt32 mask, UInt32 effect)
		{
			CHARFORMAT2_STRUCT cf = new CHARFORMAT2_STRUCT();
			cf.cbSize = (UInt32)Marshal.SizeOf(cf);
			cf.szFaceName = new char[32];

			IntPtr wpar = new IntPtr(SCF_SELECTION);
			IntPtr lpar = Marshal.AllocCoTaskMem(Marshal.SizeOf(cf));
			Marshal.StructureToPtr(cf, lpar, false);

			IntPtr res = SendMessage(Handle, EM_GETCHARFORMAT, wpar, lpar);

			cf = (CHARFORMAT2_STRUCT)Marshal.PtrToStructure(lpar, typeof(CHARFORMAT2_STRUCT));

			int state;
			// dwMask holds the information which properties are consistent throughout the selection:
			if ((cf.dwMask & mask) == mask)
			{
				if ((cf.dwEffects & effect) == effect)
					state = 1;
				else
					state = 0;
			}
			else
			{
				state = -1;
			}

			Marshal.FreeCoTaskMem(lpar);
			return state;
		}
		#endregion

		#region >> Assesseurs <<
		public bool LiensVersHelpActifs
		{
			get
			{
				return _liensVersHelpActifs;
			}
			set
			{
				_liensVersHelpActifs = value;
			}
		}
		#endregion

		#region ** Evenements **
		public event EvenementNavigationVersAide ClickLienVersAide;

		public bool _navigationEnCour;
		void Navigation(object sender, WebBrowserNavigatingEventArgs e)
		{
			if (_navigationEnCour)
				e.Cancel = true;
			else
			{
				string strURL = e.Url.ToString();
				if (strURL.Length > 6 && strURL.Substring(0, 6).ToUpper() == "HLP://")
				{
					string strKey = strURL.Substring(6);
					if (strKey[strKey.Length - 1] == '/')
						strKey = strKey.Substring(0, strKey.Length - 1);
					CHelpData hlp = CHelpData.SourceAide.GetHelp(strKey);
					if (hlp != null)
					{
						_navigationEnCour = true;
						if (ClickLienVersAide != null)
							ClickLienVersAide(sender, new ArgumentsEvenementNavigationVersAide(hlp));
						if (_liensVersHelpActifs)
							DocumentText = hlp.FullTexteHtml;
						_navigationEnCour = false;
						e.Cancel = true;
					}
				}
			}
		}

		#endregion

		private void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// WebViewerEx
			// 
			this.ResumeLayout(false);

		}

		//-----------------------------------------
		private void WebViewerEx_Navigated(object sender, WebBrowserNavigatedEventArgs e)
		{
			HtmlDocument document = Document;
			HtmlElementCollection images = document.Images;
			foreach (HtmlElement image in images)
			{
				string strImage = image.GetAttribute("src");
				if (strImage.Length > 6 && strImage.Substring(0, 6).ToUpper() == "RES://")
				{
					string strRessource = strImage.Substring(6);
					if (strRessource.Length > 0 && strRessource[strRessource.Length - 1] == '/')
						strRessource = strRessource.Substring(0, strRessource.Length - 1);
					CRessourceFichier ressource = CHelpData.SourceAide.GetRessourceFichier(strRessource);
					if (ressource != null)
					{
						image.SetAttribute("src", ressource.NomFichierLocal);
					}
				}
			}
		}

	}

	public delegate void EvenementNavigationVersAide(object sender, ArgumentsEvenementNavigationVersAide e);

	#region Classe arguments de l'evenement Navigation Vers Aide
	[ComVisible(true)]
	public sealed class ArgumentsEvenementNavigationVersAide : EventArgs
	{
		#region :: Propriétés ::
		private CHelpData _hlp;
		#endregion

		#region ++ Constructeurs ++
		public ArgumentsEvenementNavigationVersAide(CHelpData hlp)
		{
			_hlp = hlp;
		}
		#endregion
		#region >> Assesseurs <<
		public CHelpData Help
		{
			get
			{
				return _hlp;
			}
		}
		#endregion
	}
	#endregion
}
