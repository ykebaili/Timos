using System.Drawing;
using System.Collections.Generic;
using sc2i.drawing;
using sc2i.data;

namespace timos.data
{
	public static class CUtilProjet
	{
		public static void DrawIcones(Graphics g, IWndElementDeProjetPlanifiable ele)
		{
			if (ele == null || ele.ElementDuProjet == null)
				return;

			#region Anomalies
			CProjet prj = null;
			if (ele.ElementDuProjet.Projet != null)
				prj = ele.ElementDuProjet.Projet;
			else if (ele.ElementDuProjet is CProjet)
				prj = (CProjet)ele.ElementDuProjet;
			else
				return;

			if (prj.AfficherIcoAno)
			{
				Bitmap bmp = Resource.ok;

				CListeObjetsDonnees anomalies = ele.ElementDuProjet.AnomaliesConcernant;
				bool bBoucle = false;
				foreach (CAnomalieProjet ano in anomalies)
				{
					if (!ano.Ignorer)
					{
						bmp = Resource.anomalienonbloquante;
						if (ano.TypeAnomalie == ETypeAnomalieProjet.Boucle)
							bBoucle = true;
					}
				}

				//Dessin ico anomalie
				Rectangle rectPos = new Rectangle(ele.Position.X + 1, ele.Position.Y + 1, bmp.Size.Width, bmp.Size.Height);
				g.DrawImageUnscaled(bmp, rectPos);

				//Bordure ico anomalie
				Rectangle rect = new Rectangle(ele.Position.X, ele.Position.Y, bmp.Size.Width + 2, bmp.Size.Height + 2);
				Pen pen = new Pen(Color.Black);
				g.DrawRectangle(pen, rect);

				//Anomalie boucle > on met en gras la bordure
				if (bBoucle)
				{
					pen.Color = Color.Red;
					Rectangle rectBoucle = new Rectangle(ele.Position.X,ele.Position.Y, ele.Size.Width - 2,ele.Size.Height - 2);
					rectBoucle.Width = 2;
					g.DrawRectangle(pen, rectBoucle);
				}
				pen.Dispose();
			}
			#endregion

			#region Etat
			if (prj.AfficherIcoEtat)
			{
				Bitmap bmp = CEtatPlanification.GetBitmapEtat(ele.ElementDuProjet.EtatPlanification);

				//Dessin ico etat
				if (bmp != null)
				{
					//Redimentionner image :
					Bitmap bmpEtat = new Bitmap(bmp, new Size(16, 16));
					Rectangle rectPos = new Rectangle(ele.Position.X + (ele.RectangleAbsolu.Width - bmpEtat.Size.Width - 1),
														ele.Position.Y + 1, bmpEtat.Size.Width, bmpEtat.Size.Height);
					g.DrawImageUnscaled(bmpEtat, rectPos);

					//Bordure
					Pen pen = new Pen(Color.Black);

					Rectangle rect = new Rectangle(ele.Position.X + (ele.RectangleAbsolu.Width - bmpEtat.Size.Width) - 2,
											ele.Position.Y, bmpEtat.Size.Width + 2, bmpEtat.Size.Height + 2);
					g.DrawRectangle(pen, rect);
					pen.Dispose();
				}
			}
			#endregion
		}

		public static string GetChampIDElement(IWndElementDeProjetPlanifiable ele)
		{
			if(ele != null && ele.ElementDuProjet != null)
				return GetChampIDElement(ele.ElementDuProjet.TypeElementDeProjet.Code);
			return "";
		}
		public static string GetChampIDElement(I2iObjetGraphique objGraphique)
		{
			ETypeElementDeProjet? typeEle = GetTypeElement(objGraphique);
			if(typeEle.HasValue)
				return GetChampIDElement(typeEle.Value);
			return "";
		}
		public static string GetChampIDElement(ETypeElementDeProjet typeEle)
		{
			switch (typeEle)
			{
				case ETypeElementDeProjet.Intervention:
					return CIntervention.c_champId;
				case ETypeElementDeProjet.Lien:
					return CLienDeProjet.c_champId;
				case ETypeElementDeProjet.Projet:
					return CProjet.c_champId;
				default:
					break;
			}
			return "";
		}

		public static ETypeElementDeProjet? GetTypeElement(I2iObjetGraphique objGraphique)
		{
			if (objGraphique is CWndIntervention)
				return ETypeElementDeProjet.Intervention;
			else if (objGraphique is CWndProjetBrique)
				return ETypeElementDeProjet.Projet;
			else if (objGraphique is CWndLienDeProjet)
				return ETypeElementDeProjet.Lien;
			else
				return null; ;

		}
		public static IElementDeProjet GetIElementDeProjet(I2iObjetGraphique objGraphique)
		{
			if (objGraphique is CWndIntervention)
				return ((CWndIntervention)objGraphique).Intervention;
			else if (objGraphique is CWndProjetBrique)
				return ((CWndProjetBrique)objGraphique).Projet;
			else if (objGraphique is CWndLienDeProjet)
				return ((CWndLienDeProjet)objGraphique).LienDeProjet;
			else
				return null; ;
		}
	}
}
