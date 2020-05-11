using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace timos.win32.composants
{
	public static class SFormPopup
	{
		
		/// <summary>
		/// Retourne le point où il faut afficher le formulaire pour qu'il rentre dans l'écran
		/// </summary>
		/// <param name="ptDemande"></param>
		/// <param name="form"></param>
		/// <returns></returns>
		public static Point GetPointForFormPopup(Point ptDemande, Form form)
		{
			Screen sc = Screen.FromPoint(ptDemande);
			if (sc != null)
			{
				if (ptDemande.X + form.Width > sc.WorkingArea.Width)
					ptDemande.X = sc.WorkingArea.Width - form.Width;
				if (ptDemande.Y + form.Height > sc.WorkingArea.Height)
					ptDemande.Y = sc.WorkingArea.Height - form.Height;
			}
			return ptDemande;

		}
	}
}
