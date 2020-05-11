using System;
using System.Drawing;

using sc2i.common;
using sc2i.drawing;

namespace timos.data
{
	/// <summary>
	/// Description résumée de CLienAction.
	/// </summary>
	public class CWndLienTypeIntervention_SousIntervention :
		C2iObjetGraphiqueSansChilds,
		IObjetGraphiqueASuppressionSurveillee
	{
		private CWndTypeIntervention_SousIntervention m_wndInterventionDepart = null;
		private CWndTypeIntervention_SousIntervention m_wndInterventionArrivee = null;
        //private CLienTypeIntervention m_lien = null;

		//Point de départ et d'arrivée, sans tenir compte
		//du décallage de la flèche sur le début ou la fin
		private Point m_lastPointDepart = new Point(0, 0), 
				m_lastPointArrivee = new Point(10, 10);

		//Indique que m_lastPointDepart et m_lastPointArrivee ne sont pas corrects
		private bool m_bPositionInvalide = true;

		private const int c_nLargeurDebutFin = 16;
		private const int c_nHauteurDebutFin = 10;

		/// //////////////////////////////////////////////////////////////
		public CWndLienTypeIntervention_SousIntervention()
		{
		}

		//// //////////////////////////////////////////////////////////////
		public virtual string Libelle
		{
			get
			{
				return I.T( "Simple Link|243");
			}
		}

		/// //////////////////////////////////////////////////////////////
		private Rectangle m_lastRectangleDepart = new Rectangle(0, 0, 0, 0);
		private Rectangle m_lastRectangleArrivee = new Rectangle(0, 0, 0, 0);
		private void AssurePositionOk()
		{
			if (!m_bPositionInvalide)//Vérifie que le départ et l'arrivé n'ont pas bougé
			{
				if (InterventionDepart != null && InterventionDepart.RectangleAbsolu != m_lastRectangleDepart ||
					 InterventionArrivee != null && InterventionArrivee.RectangleAbsolu != m_lastRectangleArrivee)
				{
					m_bPositionInvalide = true;
				}
			}
			if (m_bPositionInvalide)
			{
				Point pt1;
				CWndTypeIntervention_SousIntervention tacheDepart = InterventionDepart;
				if (tacheDepart == null)
					pt1 = m_lastPointDepart;
				else
				{
					pt1 = GetCentreRect(tacheDepart.RectangleAbsolu);
				}

				Point pt2;
				CWndTypeIntervention_SousIntervention tacheArrivee = InterventionArrivee;
				if (tacheArrivee == null)
					pt2 = m_lastPointArrivee;
				else
				{
					pt2 = GetCentreRect(tacheArrivee.RectangleAbsolu);
				}

				if (tacheDepart != null)
				{
					if (!new CSegmentDroite(pt1, pt2).GetIntersectionPoint(tacheDepart.GetPolygoneDessin(), ref pt1))
					{
						//Ca ne se peut pas !!!
						pt1 = GetCentreRect(tacheDepart.RectangleAbsolu);
					}
				}
				if (tacheArrivee != null)
				{
					if (!new CSegmentDroite(pt1, pt2).GetIntersectionPoint(tacheArrivee.GetPolygoneDessin(), ref pt2))
						//Ca ne se peut pas
						pt2 = GetCentreRect(tacheArrivee.RectangleAbsolu);
				}
				m_lastPointArrivee = pt2;
				m_lastPointDepart = pt1;
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
					Math.Min(m_lastPointArrivee.X-c_nLargeurDebutFin/2, m_lastPointDepart.X-c_nLargeurDebutFin/2),
					Math.Min(m_lastPointDepart.Y-c_nHauteurDebutFin/2, m_lastPointArrivee.Y-c_nHauteurDebutFin/2));
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
					Math.Abs(m_lastPointArrivee.X - m_lastPointDepart.X+c_nLargeurDebutFin),
					Math.Abs(m_lastPointArrivee.Y - m_lastPointDepart.Y+c_nHauteurDebutFin));
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
				if (pt.X >= Math.Min(m_lastPointArrivee.X - c_nLargeurDebutFin, m_lastPointDepart.X - c_nLargeurDebutFin) &&
					pt.X <= Math.Max(m_lastPointArrivee.X+c_nLargeurDebutFin, m_lastPointDepart.X+c_nLargeurDebutFin) &&
					pt.Y >= Math.Min(m_lastPointArrivee.Y-c_nHauteurDebutFin, m_lastPointDepart.Y-c_nHauteurDebutFin) &&
					pt.Y <= Math.Max(m_lastPointArrivee.Y+c_nHauteurDebutFin, m_lastPointDepart.Y+c_nHauteurDebutFin))
					return true;
			}
			return false;
		}


		/// //////////////////////////////////////////////////////////////
		public CWndTypeIntervention_SousIntervention InterventionDepart
		{
			get
			{
				return m_wndInterventionDepart;
			}
			set
			{
				m_wndInterventionDepart = value;
				m_bPositionInvalide = true;
			}
		}

		/// //////////////////////////////////////////////////////////////
		public CWndTypeIntervention_SousIntervention InterventionArrivee
		{
			get
			{
				return m_wndInterventionArrivee;
			}
			set
			{
				m_wndInterventionArrivee = value;
				m_bPositionInvalide = true;
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
			return new Pen(Color.Black);
		}

		/// //////////////////////////////////////////////////////////////
		protected override void MyDraw(CContextDessinObjetGraphique ctx)
		{
			Graphics g = ctx.Graphic;
			AssurePositionOk();
			
			Point pt1 = m_lastPointDepart;
			Point pt2 = m_lastPointArrivee;

			Pen pen = GetNewPenCouleurCadre();

			Rectangle rectDepart = new Rectangle(pt1.X - c_nLargeurDebutFin/2, pt1.Y - c_nHauteurDebutFin/2, c_nLargeurDebutFin/2, c_nHauteurDebutFin);
			Brush brTmp = new SolidBrush(Color.Green);
			g.FillRectangle(brTmp, rectDepart);
			brTmp.Dispose();
			g.DrawRectangle(pen, rectDepart);

			rectDepart = new Rectangle(pt1.X, pt1.Y - c_nHauteurDebutFin / 2, c_nLargeurDebutFin / 2, c_nHauteurDebutFin);
			brTmp = new SolidBrush(Color.Red);
			g.FillRectangle(brTmp, rectDepart);
			brTmp.Dispose();
			g.DrawRectangle(pen, rectDepart);

			Rectangle rectFin = new Rectangle(pt2.X - c_nLargeurDebutFin/2, pt2.Y - c_nHauteurDebutFin / 2, c_nLargeurDebutFin, c_nHauteurDebutFin);
			brTmp = new SolidBrush(Color.Green);
			g.FillRectangle(brTmp, rectFin);
			brTmp.Dispose();
			g.DrawRectangle(pen, rectFin);

			rectFin = new Rectangle(pt2.X, pt2.Y - c_nHauteurDebutFin/2, c_nLargeurDebutFin/2, c_nHauteurDebutFin);
			brTmp = new SolidBrush(Color.Red);
			g.FillRectangle(brTmp, rectFin);
			brTmp.Dispose();
			g.DrawRectangle(pen, rectFin);


            //if (Lien.ReferenceDateIntervention1 == CLienTypeIntervention.EnumDateReference.DateDebut)
            //    pt1.X -= c_nLargeurDebutFin/4;
            //else
            //    pt1.X += c_nLargeurDebutFin/4;

            //if (Lien.ReferenceDateIntervention2 == CLienTypeIntervention.EnumDateReference.DateDebut)
            //    pt2.X -= c_nLargeurDebutFin / 4;
            //else
            //    pt2.X += c_nLargeurDebutFin / 4;

			
			g.DrawLine(pen, pt1.X, pt1.Y, pt2.X, pt2.Y);
			pen.Dispose();

			try
			{
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
				pen = GetNewPenCouleurCadre();
				g.DrawLine(pen, pt2.X, pt2.Y, p[0].X, p[0].Y);
				g.DrawLine(pen, pt2.X, pt2.Y, p[1].X, p[1].Y);
				pen.Dispose();

                //if (m_lien.RetardIntervention2SurIntervention1 != 0)
                //{
                //    //Cherche le centre
                //    Point ptCentre = new Point(pt1.X + (pt2.X - pt1.X)/2 + c_nLargeurDebutFin/2, pt1.Y + (pt2.Y - pt1.Y)/2);
                //    Font ft = new Font("Arial", 8);
                //    string strText = (m_lien.RetardIntervention2SurIntervention1 > 0 ? "+" : "") + m_lien.RetardIntervention2SurIntervention1.ToString()+"h";
                //    g.DrawString(strText, ft, Brushes.Black, ptCentre);
                //    ft.Dispose();
                //}
			}
			catch
			{
			}
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
			//return m_lien.Delete();

            return CResultAErreur.True;
		}

		/// ////////////////////////////////////////////////////////
		public bool IsValide()
		{
			//return m_lien != null && m_lien.IsValide();

            return CResultAErreur.True;
        }
	}
}
