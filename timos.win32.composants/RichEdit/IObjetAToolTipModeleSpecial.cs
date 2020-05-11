using System;
using System.Collections.Generic;
using System.Text;

namespace timos.win32.composants
{
	/// <summary>
	/// Implémenté par les objets qui n'affichent pas des bulles
	/// sur eux même, mais sur un élément particulier d'eux même
	/// </summary>
	public interface IObjetAToolTipModeleSpecial
	{
		object ObjetPourToolTip { get;}
	}
}
