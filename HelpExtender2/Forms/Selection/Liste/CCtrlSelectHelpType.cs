using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace HelpExtender
{
	public partial class CCtrlSelectHelpType : UserControl
	{
		#region ++ Constructeurs ++
		public CCtrlSelectHelpType()
		{
			InitializeComponent();
		}
		#endregion

		#region :: Propri�t�s ::
		
		#endregion

		#region >> Assesseurs <<
		public Type TypeSelectionne
		{
			get
			{
				return null;
			}
		}
		public CHelpData HelpSelectionne
		{
			get
			{
				return null;
			}
		}
		#endregion

		#region ~~ M�thodes ~~
		public void Initialiser()
		{

		}
		#endregion
	}
}
