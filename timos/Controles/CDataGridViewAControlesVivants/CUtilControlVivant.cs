using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace timos
{
	public static class CUtilControlVivant 
	{
		public static Bitmap GetScreenShot(IControlVivant control)
		{

			Bitmap img = new Bitmap(control.Controle.Width, control.Controle.Height);
			Rectangle rect = new Rectangle(new Point(0, 0), control.Controle.Size);
			control.Controle.DrawToBitmap(img, rect);
			return img;
		}
	}




	
}
