using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace timos
{
	public interface IControlVivant 
	{
		Control Controle { get;}
		bool MustBeRedraw { get; set;}
		Bitmap ScreenShot { get;}
		bool Initialiser(object valeur);
		object Valeur { get; set;}
	}




	
}
