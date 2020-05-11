using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using sc2i.data.dynamic;

namespace timos.data.preventives
{
	//Cette classe dessine la cellule en Ligne 0 Colonne 0
    public class CDessinAngle : IElementADessiner
	{
		public CDessinAngle(CDessinEditeurPreventive dessinEditeur)
		{
			m_dessinEditeur = dessinEditeur;
		}

		private CDessinEditeurPreventive m_dessinEditeur;
		public CDessinEditeurPreventive DessinEditeur
		{
			get
			{
				return m_dessinEditeur;
			}
		}

		private Image m_cacheDessin;
		public Image CacheDessin
		{
			get
			{
				return m_cacheDessin;
			}
		}
		public void Refresh()
		{
			m_cacheDessin = null;
		}
		public void Draw(Graphics g, Rectangle rect)
		{
			
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
				CDessinEditeurPreventive.DessinerLigne(ECoteRectangle.Bas, System.Drawing.Drawing2D.DashStyle.Solid, Color.Black, 1, rcImage, gTmp);
				g.DrawImageUnscaled(img, rect.Location);
				m_cacheDessin = img;

				brush.Dispose();
			}
		}
    }
}
