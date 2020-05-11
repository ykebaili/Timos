using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using sc2i.data.dynamic;

namespace timos.data.preventives
{
	//Cette classe dessine les cellules definissant les tranches
    public class CDessinTranche : IElementADessiner
	{
		public CDessinTranche(
			CDessinEditeurPreventive dessinEditeur,
			CTranche tranche,
			EPositionDessinTranche position)
		{
			m_dessinEditeur = dessinEditeur;
			m_position = position;
			m_tranche = tranche;
		}


		

		private CDessinEditeurPreventive m_dessinEditeur;
		public CDessinEditeurPreventive DessinEditeur
		{
			get
			{
				return m_dessinEditeur;
			}
		}

		private EPositionDessinTranche m_position;
		public EPositionDessinTranche PositionTranche
		{
			get
			{
				return m_position;
			}
			set
			{
				m_position = value;
			}
		}

		//Correspond aux cellules
		public List<CDessinTrancheSite> DessinsTrancheSite
		{
			get
			{
				List<CDessinTrancheSite> cellules = new List<CDessinTrancheSite>();
				foreach (CDessinSite ligne in DessinEditeur.DessinsSites)
				{
					foreach(CDessinTrancheSite cel in ligne.DessinsCellules)
						if(cel.DessinTranche == this)
						{
							cellules.Add(cel);
							break;

						}
				}
				return cellules;
			}
		}
		public CDessinTrancheSite this[int indexCelluleBaseZero]
		{
			get
			{
				return DessinsTrancheSite[indexCelluleBaseZero];
			}
		}


		private EFormatDate FormatDate
		{
			get
			{
				return DessinEditeur.FormatDate;
			}
		}

		private CTranche m_tranche;
		public CTranche Tranche
		{
			get
			{
				return m_tranche;
			}
		}
		public DateTime DateFin
		{
			get
			{
				return m_tranche.DateFin;
			}
			set
			{
				m_tranche.DateFin = value;
			}
		}
		public DateTime DateDebut
		{
			get
			{
				return m_tranche.DateDebut;
			}
			set
			{
				m_tranche.DateDebut = value;
			}
		}

		//Dessine l'entête de la colonne
		private Image m_cacheDessin;
		public Image CacheDessin
		{
			get
			{
				return m_cacheDessin;
			}
		}

		private Font m_police;
		public Font Police
		{
			get
			{
				if (m_police == null)
					m_police = new Font(new FontFamily(GenericFontFamilies.SansSerif), 10);
				return m_police;
			}
			set
			{
				m_police = value;
			}
		}

		public void Refresh()
		{
			m_cacheDessin = null;
		}
		public void Draw(Graphics g, Rectangle rect)
		{
			//Cache valide
			if (m_cacheDessin != null && rect.Size == CacheDessin.Size)
				g.DrawImageUnscaled(m_cacheDessin, rect.Location);
			else
			{
				Rectangle rcImage = rect;
				rcImage.Offset(new Point(-rcImage.Left, -rcImage.Top));

				Image img = new Bitmap(rect.Size.Width, rect.Size.Height);
				Graphics gTmp = Graphics.FromImage(img);

				SolidBrush brush = new SolidBrush(Color.Beige);
				gTmp.FillRectangle(brush, rcImage);
				//Calendar calendrier = CultureInfo.InvariantCulture.Calendar;
				int nWeekD = CUtilDate.GetWeekNum(DateDebut);
				//int nWeekD = calendrier.GetWeekOfYear(DateDebut, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
				string strWeekD = nWeekD.ToString();
				if (nWeekD < 10)
					strWeekD = "0" + strWeekD;
				string strMoisD = DateDebut.Month.ToString();
				if (DateDebut.Month < 10)
					strMoisD = "0" + strMoisD;
				string strJourD = DateDebut.Day.ToString();
				if (DateDebut.Day < 10)
					strJourD = "0" + strJourD;
				string strAnneeD = DateDebut.Year.ToString();

				int nWeekF = CUtilDate.GetWeekNum(DateFin);
				//int nWeekF = calendrier.GetWeekOfYear(DateFin, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
				string strWeekF = nWeekF.ToString();
				if (nWeekF < 10)
					strWeekF = "0" + strWeekF;
				string strMoisF = DateFin.Month.ToString();
				if (DateFin.Month < 10)
					strMoisF = "0" + strMoisF;
				string strJourF = DateFin.Day.ToString();
				if (DateFin.Day < 10)
					strJourF = "0" + strJourF;
				string strAnneeF = DateFin.Year.ToString();

				//string strWeekF2 = calendrier.GetWeekOfYear(DateFin, CalendarWeekRule.FirstDay, DayOfWeek.Monday).ToString();

				string strDateD = "";
				string strDateF = "";

				switch (FormatDate)
				{
					default:
					case EFormatDate.JourMoisAnnee:
						strDateD = strJourD + "/" + strMoisD + "/" + strAnneeD;
						strDateF = strJourF + "/" + strMoisF + "/" + strAnneeF;
						break;

					case EFormatDate.JourMois:
						strDateD = strJourD + "/" + strMoisD;
						strDateF = strJourF + "/" + strMoisF;
						break;

					case EFormatDate.MoisAnnee:
						strDateD = strMoisD + "/" + strAnneeD;
						strDateF = strMoisF + "/" + strAnneeF;
						break;

					case EFormatDate.Jour:
						strDateD = strJourD;
						strDateF = strJourF;
						break;

					case EFormatDate.Mois:
						strDateD = strMoisD;
						strDateF = strMoisF;
						break;

					case EFormatDate.Annee:
						strDateD = strAnneeD;
						strDateF = strAnneeF;
						break;
					case EFormatDate.Semaine:
						strDateD = strWeekD;
						strDateF = strWeekF;
						break;
				}


				SizeF sDateD = gTmp.MeasureString(strDateD, Police);
				SizeF sDateF = gTmp.MeasureString(strDateF, Police);

				int nHDateD = 0;
				int nYCadreDateD = 0;
				int nWDateD = 0;
				int nXCadreDateD = 0;
				Rectangle rDateD = new Rectangle();

				int nHDateF = 0;
				int nYCadreDateF = 0;
				int nWDateF = 0;
				int nXCadreDateF = 0;
				Rectangle rDateF = new Rectangle();

				Pen crayonRouge = new Pen(Brushes.Red);
				Brush brushBlack = new SolidBrush(Color.Black);
				Brush brushPaleGoldenrod = new SolidBrush(Color.PaleGoldenrod);
				switch (PositionTranche)
				{
					case EPositionDessinTranche.Fin:
						CDessinEditeurPreventive.DessinerLigne(ECoteRectangle.Droite, System.Drawing.Drawing2D.DashStyle.Dash, Color.Black, 1, rcImage, gTmp);
						Image imgEtqFin = new Bitmap(((int)sDateF.Width + 5), ((int)sDateF.Height + 5));
						Graphics gEtqFin = Graphics.FromImage(imgEtqFin);
						rDateF = new Rectangle(0, 0, (int)sDateF.Width + 4, (int)sDateF.Height + 4);
						gEtqFin.FillRectangle(brushPaleGoldenrod, rDateF);
						gEtqFin.DrawRectangle(crayonRouge, rDateF);
						gEtqFin.DrawString(strDateF, Police, brushBlack, 2, 2);
						imgEtqFin.RotateFlip(RotateFlipType.Rotate270FlipNone);
						gTmp.DrawImageUnscaled(imgEtqFin, new Point(rcImage.Width - 1 - imgEtqFin.Width, (rcImage.Height / 2) - imgEtqFin.Height / 2));
						if (PositionTranche != EPositionDessinTranche.Unique)
							goto case EPositionDessinTranche.Intermediaire;
						else
						{
							CDessinEditeurPreventive.DessinerLigne(ECoteRectangle.Gauche, System.Drawing.Drawing2D.DashStyle.Dash, Color.Black, 1, rcImage, gTmp);
							break;
						}

					case EPositionDessinTranche.Debut:
						Image imgEtqDebut = new Bitmap(((int)sDateD.Width + 5), ((int)sDateD.Height + 5));
						Graphics gEtqDebut = Graphics.FromImage(imgEtqDebut);
						rDateD = new Rectangle(0,0, (int)sDateD.Width + 4, (int)sDateD.Height + 4);
						gEtqDebut.FillRectangle(brushPaleGoldenrod, rDateD);
						gEtqDebut.DrawRectangle(crayonRouge, rDateD);
						gEtqDebut.DrawString(strDateD, Police, brushBlack, 2, 2);
						imgEtqDebut.RotateFlip(RotateFlipType.Rotate270FlipNone);
						gTmp.DrawImageUnscaled(imgEtqDebut, new Point(1, (rcImage.Height / 2) - imgEtqDebut.Height / 2));

						if(PositionTranche != EPositionDessinTranche.Unique)
							goto case EPositionDessinTranche.Intermediaire;
						else
							goto case EPositionDessinTranche.Fin;

					case EPositionDessinTranche.Intermediaire:

						CDessinEditeurPreventive.DessinerLigne(ECoteRectangle.Gauche, System.Drawing.Drawing2D.DashStyle.Dash, Color.Black, 1, rcImage, gTmp);

						#region LABEL DROIT
						if (PositionTranche != EPositionDessinTranche.Fin)
						{
							nHDateF = (int)sDateF.Height;
							nYCadreDateF = ((rcImage.Height / 2) - (nHDateF / 2) - 2);

							nWDateF = (int)sDateF.Width;
							nXCadreDateF = (rcImage.Width - (nWDateF / 2) - 2);
							if (nWDateF % 2 != 0)
								nXCadreDateF--;

							rDateF = new Rectangle(nXCadreDateF, nYCadreDateF, ((int)sDateF.Width + 4), ((int)sDateF.Height + 4));
							gTmp.FillRectangle(brushPaleGoldenrod, rDateF);
							gTmp.DrawRectangle(crayonRouge, rDateF);
							int posXFont = nXCadreDateF + 3;
							int posYFont = nYCadreDateF + 2;
							if (FormatDate == EFormatDate.JourMoisAnnee
								|| FormatDate == EFormatDate.Mois)
							{
								posXFont += 2;
							}
							gTmp.DrawString(strDateF, Police, brushBlack, posXFont, posYFont);
						}
						#endregion

						#region LABEL GAUCHE
						if (PositionTranche != EPositionDessinTranche.Debut)
						{
							nHDateD = (int)sDateD.Height;
							nYCadreDateD = ((rcImage.Height / 2) - (nHDateD / 2) - 2);
							nWDateD = (int)sDateD.Width;
							nXCadreDateD = (-(nWDateD / 2) - 2);
							if (nWDateD % 2 != 0)
								nXCadreDateD++;

							int posYFont = nYCadreDateD + 2;
							int posXFont = nXCadreDateD + 3;
							if(FormatDate == EFormatDate.Semaine)
								posXFont--;
							rDateD = new Rectangle(nXCadreDateD, nYCadreDateD, (int)sDateD.Width + 4, (int)sDateD.Height + 4);
							gTmp.FillRectangle(brushPaleGoldenrod, rDateD);
							gTmp.DrawRectangle(crayonRouge, rDateD);
							gTmp.DrawString(strDateD, Police, brushBlack, posXFont, posYFont);
						}

						#endregion

						break;
					case EPositionDessinTranche.Unique:
						goto case EPositionDessinTranche.Debut;
					default:
						break;
				}

				CDessinEditeurPreventive.DessinerLigne(ECoteRectangle.Bas, System.Drawing.Drawing2D.DashStyle.Solid, Color.Black, 1, rcImage, gTmp);

				//Sauvegarde du cache
				g.DrawImageUnscaled(img, rect.Location);
				m_cacheDessin = img;

				brush.Dispose();
				crayonRouge.Dispose();
				brushBlack.Dispose();
				brushPaleGoldenrod.Dispose();

			}
		}
    }

	//La position de DessinTranche permet de savoir comment dessiner la cellule
	public enum EPositionDessinTranche
	{
		Debut,
		Fin,
		Intermediaire,
		Unique
	}
}
