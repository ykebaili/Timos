using System;
using System.Drawing;


namespace sc2i.workflow
{
	/// <summary>
	/// Définit les couleurs d'affichage des entrées d'agenda
	/// </summary>
	public class CCouleursForEntreeAgenda
	{
		public static Color c_couleurTextStd = Color.Black;
		public static Color c_couleurFondStd = Color.White;

		public static Color c_couleurFondAnnulee = Color.LightGray;
		public static Color c_couleurTextAnnulee = Color.Black;
		
		public static Color c_couleurTextTermine = Color.Black;
		public static Color c_couleurFondTermine = Color.LightGreen;

		public static Color c_couleurTextEnRetard = Color.Black;
		public static Color c_couleurFondEnRetard = Color.LightPink;

		public static Color c_couleurTextEnCours = Color.Black;
		public static Color c_couleurFondEnCours = Color.LightBlue;
		
		public CCouleursForEntreeAgenda()
		{
		}

		public static void GetCouleursFor ( IEntreeAgenda entree, ref Color couleurFond, ref Color couleurText )
		{
			couleurFond = c_couleurFondStd;
			couleurText = c_couleurTextStd;
			switch ( entree.Etat.Etat )
			{
				case EtatEntreeAgenda.AFaire :
					if ( entree.DateFin < DateTime.Now )
					{
						couleurFond = c_couleurFondEnRetard ;
						couleurText = c_couleurTextEnRetard ;
					}
					break;
				case EtatEntreeAgenda.Annulee :
					couleurFond = c_couleurFondAnnulee ;
					couleurText = c_couleurTextAnnulee ;
					break;
				case EtatEntreeAgenda.Terminee :
					couleurFond = c_couleurFondTermine ;
					couleurText = c_couleurTextTermine ;
					break;
				case EtatEntreeAgenda.EnCours :
					couleurFond = c_couleurFondEnCours ;
					couleurText = c_couleurTextEnCours ;
					break;
			}
		}
	}

}
