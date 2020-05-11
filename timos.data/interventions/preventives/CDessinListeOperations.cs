using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Text;


using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using sc2i.data.dynamic;

namespace timos.data.preventives
{	

	public class CDessinListeOperations : IElementADessiner
	{
		public CDessinListeOperations(
			CDessinTrancheSite dessinTrancheSite,
			CContrat_ListeOperations contratLstOp,
			CInterventionPourEditeurPreventive intervention)
		{
			m_dessinTrancheSite = dessinTrancheSite;
			m_contratLstOperation = contratLstOp;
			m_intervention = intervention;
		}


		public DateTime DateDebut
		{
			get
			{
				return Intervention.DateDebut;
			}
		}
		public DateTime DateFin
		{
			get
			{
				return Intervention.DateFin;
			}
		}

		private CDessinTrancheSite m_dessinTrancheSite;
		public CDessinTrancheSite DessinTrancheSite
		{
			get
			{
				return m_dessinTrancheSite;
			}
		}

		//METIER
		private CContrat_ListeOperations m_contratLstOperation;
		public CContrat_ListeOperations ContratListeOperation
		{
			get
			{
				return m_contratLstOperation;
			}
		}
		private CInterventionPourEditeurPreventive m_intervention;
		public CInterventionPourEditeurPreventive Intervention
		{
			get
			{
				return m_intervention;
			}
		}


		public Color Couleur
		{
			get
			{
				return Color.FromArgb(ContratListeOperation.Couleur);
			}
		}

		//DESSIN - Dessine le rectangle correspondant à la liste d'opération
		private Image m_cacheDessin;
		public Image CacheDessin
		{
			get
			{
				return m_cacheDessin;
			}
		}

		private Rectangle m_rect;
		public Rectangle RectangleInter
		{
			get
			{
				return m_rect;
			}
		}

		public void Refresh()
		{
			m_cacheDessin = null;
		}

		//private bool m_bSurvole = false;
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

				//Hauteur et largeur du rectangle de l'inter
				int nLargeur = (int)(((DateFin.Ticks - DateDebut.Ticks) * rcImage.Width) / (DessinTrancheSite.DateFin.Ticks - DessinTrancheSite.DateDebut.Ticks));
				int nHauteur = rcImage.Height;

				//Position du rectangle de l'inter sur X
				double fEch = ((double)DessinTrancheSite.DateFin.Ticks - (double)DessinTrancheSite.DateDebut.Ticks) / rcImage.Width;
				int nPosX =  (int)((((double)DateDebut.Ticks - (double)DessinTrancheSite.DateDebut.Ticks)) / fEch);

				Rectangle rectInter = new Rectangle(nPosX, 2, nLargeur, nHauteur-4);

				CDessinEditeurPreventive dessinEditeur = DessinTrancheSite.DessinSite.DessinEditeur;
				bool bSurvole = dessinEditeur.InterSurvolee == Intervention;
				bool bSelected = dessinEditeur.IntersSelectionnees.Contains(Intervention);
				int nLargeurCadre = dessinEditeur.IntersSelectionnees.Contains(Intervention)? 2 : 1;
				Color c = dessinEditeur.InterSurvolee == Intervention && dessinEditeur.MettreEnEvidanceLelementSurvole ? Color.Red : Couleur;
				if (dessinEditeur.IntersSelectionnees.Contains(Intervention))
					c = Color.FromArgb(125, c);
				SolidBrush brush = new SolidBrush(c);
				gTmp.FillRectangle(brush, rectInter);
				Rectangle rectBordure = new Rectangle(rectInter.X, rectInter.Y, rectInter.Width, rectInter.Height);
				CDessinEditeurPreventive.DessinerLigne(ECoteRectangle.Haut, System.Drawing.Drawing2D.DashStyle.Solid, Color.Black, nLargeurCadre, rectBordure, gTmp);
				CDessinEditeurPreventive.DessinerLigne(ECoteRectangle.Bas, System.Drawing.Drawing2D.DashStyle.Solid, Color.Black, nLargeurCadre, rectBordure, gTmp);
				if(DateDebut >= DessinTrancheSite.DateDebut)
					CDessinEditeurPreventive.DessinerLigne(ECoteRectangle.Gauche, System.Drawing.Drawing2D.DashStyle.Solid, Color.Black, nLargeurCadre, rectBordure, gTmp);
				if(DateFin <= DessinTrancheSite.DateFin)
					CDessinEditeurPreventive.DessinerLigne(ECoteRectangle.Droite, System.Drawing.Drawing2D.DashStyle.Solid, Color.Black, nLargeurCadre, rectBordure, gTmp);

				//TITRE LISTE OP A REDEFINIR
				//SizeF sz = gTmp.MeasureString(Intervention.Label, Police);
				//if (sz.Width <= nLargeur && sz.Height <= nHauteur)
				//{
				//    Brush br = new SolidBrush(CouleurTexte);


				//    float nPosXLabel = (rectInter.Width / 2) - (sz.Width / 2);
				//    float nPosYLabel = (rectInter.Height / 2) - (sz.Height / 2);

				//    gTmp.DrawString(Intervention.Label, Police, br, nPosXLabel,nPosYLabel);
				//    br.Dispose();
				//}

				int nPosY = rect.Location.Y;
				
				g.DrawImageUnscaled(img, new Point(0,nPosY));
				m_cacheDessin = img;
				m_rect = new Rectangle(nPosX + rcImage.Left, nPosY, nLargeur, nHauteur);

				brush.Dispose();
			}
		}

		private Color m_couleurText = Color.Black;
		public Color CouleurTexte
		{
			get
			{
				return m_couleurText;
			}
			set
			{
				m_couleurText = value;
			}
		}
		private ContentAlignment m_alignement = ContentAlignment.MiddleCenter;
		public ContentAlignment AlignementTexte
		{
			get
			{
				return m_alignement;
			}
			set
			{
				m_alignement = value;
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
	}


}
