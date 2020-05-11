using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

using sc2i.drawing;
using sc2i.common;
using sc2i.formulaire;

namespace timos.data
{

	public class CWndLienDeProjet : 
		C2iObjetGraphiqueSansChilds,
		IObjetGraphiqueASuppressionSurveillee
	{
		private IWndElementDeProjetPlanifiable m_wndEleDepart = null;
		private IWndElementDeProjetPlanifiable m_wndEleArrivee = null;
		private CLienDeProjet m_lien = null;

		//Point de départ et d'arrivée, sans tenir compte
		//du décallage de la flèche sur le début ou la fin
		private Point m_lastPointDepart = new Point(0, 0), 
			m_lastPointArrivee = new Point(10, 10);
		private bool m_bPositionInvalide = true;

		/// //////////////////////////////////////////////////////////////
		public CWndLienDeProjet()
		{
		}
		public CWndLienDeProjet(CLienDeProjet lien)
		{
			m_lien = lien;
		}


		public override bool IsLock
		{
			get
			{
				return true;
			}
			set
			{
				base.IsLock = value;
			}
		}
		/// //////////////////////////////////////////////////////////////
		public CLienDeProjet LienDeProjet
		{
			get
			{
				return m_lien;
			}
			set
			{
				m_lien = value;
			}
		}

		//// //////////////////////////////////////////////////////////////
		public virtual string Libelle
		{
			get
			{
				return I.T("Simple link|451");
			}
		}

		/// //////////////////////////////////////////////////////////////
		private Rectangle m_lastRectangleDepart = new Rectangle(0, 0, 0, 0);
		private Rectangle m_lastRectangleArrivee = new Rectangle(0, 0, 0, 0);
		private void AssurePositionOk()
		{
			if (!m_bPositionInvalide)//Vérifie que le départ et l'arrivé n'ont pas bougé
			{
				if (ElementDepart != null && ElementDepart.RectangleAbsolu != m_lastRectangleDepart ||
					 ElementArrivee!= null && ElementArrivee.RectangleAbsolu != m_lastRectangleArrivee)
				{
					m_bPositionInvalide = true;
				}
			}
			if (m_bPositionInvalide)
			{
				Point pt1;
				IWndElementDeProjetPlanifiable eleDepart = ElementDepart;
				if (eleDepart == null)
					pt1 = m_lastPointDepart;
				else
				{
					pt1 = GetCentreRect(eleDepart.RectangleAbsolu);
				}

				Point pt2;
				IWndElementDeProjetPlanifiable eleArrivee = ElementArrivee;
				if (eleArrivee == null)
					pt2 = m_lastPointArrivee;
				else
				{
					pt2 = GetCentreRect(eleArrivee.RectangleAbsolu);
				}

				if (eleDepart != null)
				{
					if (!new CSegmentDroite(pt1, pt2).GetIntersectionPoint(eleDepart.GetPolygoneDessin(), ref pt1))
					{
						//Ca ne se peut pas !!!
						pt1 = GetCentreRect(eleDepart.RectangleAbsolu);
					}
				}
				if (eleArrivee != null)
				{
					if (!new CSegmentDroite(pt1, pt2).GetIntersectionPoint(eleArrivee.GetPolygoneDessin(), ref pt2))
						//Ca ne se peut pas
						pt2 = GetCentreRect(eleArrivee.RectangleAbsolu);
				}
				m_lastPointDepart = pt1;
				m_lastPointArrivee = pt2;
				m_bPositionInvalide = false;
			}
		}

		/// //////////////////////////////////////////////////////////////
		public override Point Position
		{
			get
			{
				AssurePositionOk();
				return new Point(
					Math.Min(m_lastPointArrivee.X, m_lastPointDepart.X),
					Math.Min(m_lastPointDepart.Y, m_lastPointArrivee.Y));
			}
			set
			{
			}
		}

		/// //////////////////////////////////////////////////////////////
		public override Size Size
		{
			get
			{
				AssurePositionOk();
				return new Size(
					Math.Abs(m_lastPointArrivee.X - m_lastPointDepart.X),
					Math.Abs(m_lastPointArrivee.Y - m_lastPointDepart.Y));
			}
			set
			{
			}
		}

		/// ///////////////////////////////////////////////
		public override bool IsPointIn(Point pt)
		{
			AssurePositionOk();
			//Calcule la distance entre la droite et le point
			CSegmentDroite segment = new CSegmentDroite(m_lastPointArrivee, m_lastPointDepart);
			double fA = 0, fB = 0, fC = 0;
			segment.GetEquationDroite(ref fA, ref fB, ref fC);
			double fSqrt = Math.Sqrt(fA * fA + fB * fB);
			if (fSqrt == 0)
				return false;
			double fDistance = (fA * (double)pt.X + fB * (double)pt.Y + fC) / fSqrt;
			if (fDistance < 16)
			{
				//Vérifie que le point est environ sur le segment
				if (pt.X >= Math.Min(m_lastPointArrivee.X , m_lastPointDepart.X) &&
					pt.X <= Math.Max(m_lastPointArrivee.X, m_lastPointDepart.X) &&
					pt.Y >= Math.Min(m_lastPointArrivee.Y, m_lastPointDepart.Y) &&
					pt.Y <= Math.Max(m_lastPointArrivee.Y, m_lastPointDepart.Y))
					return true;
			}
			return false;
		}

		/// //////////////////////////////////////////////////////////////
		public IWndElementDeProjetPlanifiable ElementDepart
		{
			get
			{
				return m_wndEleDepart;
			}
			set
			{
				m_wndEleDepart = value;
			}
		}

		/// //////////////////////////////////////////////////////////////
		public IWndElementDeProjetPlanifiable ElementArrivee
		{
			get
			{
				return m_wndEleArrivee;
			}
			set
			{
				m_wndEleArrivee = value;
			}
		}

		/// //////////////////////////////////////////////////////////////
		private Point GetCentreRect(Rectangle rect)
		{
			return new Point((rect.Left + rect.Right) / 2, (rect.Top + rect.Bottom) / 2);
		}

		/// //////////////////////////////////////////////////////////////
		public virtual Pen GetNewPenCouleurCadre()
		{
			if(m_lien.Projet == null || !m_lien.Projet.AfficherIcoAno || m_lien.AnomaliesConcernant.CountNoLoad == 0)
				return new Pen(Color.Black);

			return new Pen(Color.OrangeRed,2);
		}

		/// //////////////////////////////////////////////////////////////
		protected override void MyDraw(CContextDessinObjetGraphique ctx)
		{
			Graphics g = ctx.Graphic;
			if (!m_lien.IsValide())
				return;
			AssurePositionOk();
			Point pt1 = m_lastPointDepart;
			Point pt2 = m_lastPointArrivee;

			

			Pen pen = GetNewPenCouleurCadre();
			g.DrawLine(pen, pt1, pt2);

			try
			{
				switch (m_lien.TypeRelation.Code)
				{
					case ETypeLienDeProjet.DemarrentEnMemeTemps:
						//Creation de 2 rond d'attache
						break;
					case ETypeLienDeProjet.ElementADemarreQuandElementBTermine:
						double fDim2 = 12;
						double fCosa2 = (double)Math.Abs(pt2.X - pt1.X) / (double)(Math.Sqrt((pt2.X - pt1.X) * (pt2.X - pt1.X) + (pt2.Y - pt1.Y) * (pt2.Y - pt1.Y)));
						double fSina2 = (double)Math.Abs(pt2.Y - pt1.Y) / (double)(Math.Sqrt((pt2.X - pt1.X) * (pt2.X - pt1.X) + (pt2.Y - pt1.Y) * (pt2.Y - pt1.Y)));
						Point m2 = new Point(0, 0);
						Point[] p2 = new Point[2];
						p2[0] = new Point(0, 0);
						p2[1] = new Point(0, 0);

						if (pt1.X > pt2.X)
						{
							m2.X = (int)(pt2.X + (long)(fDim2 * Math.Sqrt(3) * fCosa2 / 2.0));
							p2[0].X = (int)(m2.X + (long)(fDim2 * fSina2 / 2.0));
							p2[1].X = (int)(m2.X - (long)(fDim2 * fSina2 / 2.0));
						}
						else
						{
							m2.X = (int)(pt2.X - (long)(fDim2 * Math.Sqrt(3) * fCosa2 / 2.0));
							p2[0].X = (int)(m2.X - (long)(fDim2 * fSina2 / 2.0));
							p2[1].X = (int)(m2.X + (long)(fDim2 * fSina2 / 2.0));
						}
						if (pt1.Y > pt2.Y)
						{
							m2.Y = (int)(pt2.Y + (long)(fDim2 * Math.Sqrt(3) * fSina2 / 2.0));
							p2[0].Y = (int)(m2.Y - (long)(fDim2 * fCosa2 / 2.0));
							p2[1].Y = (int)(m2.Y + (long)(fDim2 * fCosa2 / 2.0));
						}
						else
						{
							m2.Y = (int)(pt2.Y - (long)(fDim2 * Math.Sqrt(3) * fSina2 / 2.0));
							p2[0].Y = (int)(m2.Y + (long)(fDim2 * fCosa2 / 2.0));
							p2[1].Y = (int)(m2.Y - (long)(fDim2 * fCosa2 / 2.0));
						}
						g.DrawLine(pen, pt1.X, pt1.Y, p2[0].X, p2[0].Y);
						g.DrawLine(pen, pt1.X, pt1.Y, p2[1].X, p2[1].Y);
						break;
					case ETypeLienDeProjet.ElementBDemarreQuandElementATermine:
						double fDim = 12;
						double fCosa = (double)Math.Abs(pt1.X - pt2.X) / (double)(Math.Sqrt((pt1.X - pt2.X) * (pt1.X - pt2.X) + (pt1.Y - pt2.Y) * (pt1.Y - pt2.Y)));
						double fSina = (double)Math.Abs(pt1.Y - pt2.Y) / (double)(Math.Sqrt((pt1.X - pt2.X) * (pt1.X - pt2.X) + (pt1.Y - pt2.Y) * (pt1.Y - pt2.Y)));
						Point m = new Point(0, 0);
						Point[] p = new Point[2];
						p[0] = new Point(0, 0);
						p[1] = new Point(0, 0);

						if (pt1.X > pt2.X)
						{
							m.X = (int)(pt2.X + (long)(fDim * Math.Sqrt(3) * fCosa / 2.0));
							p[0].X = (int)(m.X + (long)(fDim * fSina / 2.0));
							p[1].X = (int)(m.X - (long)(fDim * fSina / 2.0));
						}
						else
						{
							m.X = (int)(pt2.X - (long)(fDim * Math.Sqrt(3) * fCosa / 2.0));
							p[0].X = (int)(m.X - (long)(fDim * fSina / 2.0));
							p[1].X = (int)(m.X + (long)(fDim * fSina / 2.0));
						}
						if (pt1.Y > pt2.Y)
						{
							m.Y = (int)(pt2.Y + (long)(fDim * Math.Sqrt(3) * fSina / 2.0));
							p[0].Y = (int)(m.Y - (long)(fDim * fCosa / 2.0));
							p[1].Y = (int)(m.Y + (long)(fDim * fCosa / 2.0));
						}
						else
						{
							m.Y = (int)(pt2.Y - (long)(fDim * Math.Sqrt(3) * fSina / 2.0));
							p[0].Y = (int)(m.Y + (long)(fDim * fCosa / 2.0));
							p[1].Y = (int)(m.Y - (long)(fDim * fCosa / 2.0));
						}
						g.DrawLine(pen, pt2.X, pt2.Y, p[0].X, p[0].Y);
						g.DrawLine(pen, pt2.X, pt2.Y, p[1].X, p[1].Y);
						break;
					default:
						break;
				}
				
			}
			catch
			{
			}
			pen.Dispose();
		}

		/// //////////////////////////////////////////////////////////////
		private int GetNumVersion()
		{
			return 0;
		}

		/// //////////////////////////////////////////////////////////////
		protected override sc2i.common.CResultAErreur MySerialize(sc2i.common.C2iSerializer serializer)
		{
			int nVersion = GetNumVersion();
			CResultAErreur result = serializer.TraiteVersion(ref nVersion);
			if (!result)
				return result;
			int nX, nY;

			nX = m_lastPointArrivee.X;
			nY = m_lastPointArrivee.Y;
			serializer.TraiteInt(ref nX);
			serializer.TraiteInt(ref nY);
			m_lastPointArrivee.X = nX;
			m_lastPointArrivee.Y = nY;

			nX = m_lastPointDepart.X;
			nY = m_lastPointDepart.Y;
			serializer.TraiteInt(ref nX);
			serializer.TraiteInt(ref nY);
			m_lastPointDepart.X = nX;
			m_lastPointDepart.Y = nY;

			return result;
		}

		/// ////////////////////////////////////////////////////////
		public virtual CResultAErreur VerifieDonnees()
		{
			return CResultAErreur.True;
		}


		/// ////////////////////////////////////////////////////////
		public CResultAErreur OnDelete()
		{
			if (m_lien.IsValide())
				return m_lien.Delete();
			else
				return CResultAErreur.True;
		}

		/// ////////////////////////////////////////////////////////
		public bool IsValide()
		{
			return m_lien != null && m_lien.IsValide();
		}
	}
}
