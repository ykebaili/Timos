using System;
using System.Collections.Generic;
using System.Text;

namespace timos.win32.composants
{
	/// <summary>
	/// Impl�ment� par les objets qui n'affichent pas des bulles
	/// sur eux m�me, mais sur un �l�ment particulier d'eux m�me
	/// </summary>
	public interface IObjetAToolTipModeleSpecial
	{
		object ObjetPourToolTip { get;}
	}
}
