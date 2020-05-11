using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

using sc2i.data;
using sc2i.common;
using sc2i.drawing;

namespace timos.data
{
	/// <summary>
	/// </summary>
	public class CWndProjetDetail : C2iObjetGraphique
	{
		private CProjet m_prj = null;
		private List<I2iObjetGraphique> m_listeChilds = new List<I2iObjetGraphique>();

		//--------------------------------------------
		public CWndProjetDetail(CProjet projet)
			: base()
		{
			m_prj = projet;
			Position = new Point(0, 0);
			Size = new Size(1000, 1000);
			m_bMiniature = false;	

		}


		private bool m_bMiniature = false;
		public Image Miniature
		{
			get
			{
				m_bMiniature = true;
				Image img = new Bitmap(Size.Width,Size.Height);
				img = RegarderMiniature(img);
				img = SupprimerCouleur(img);
				Graphics g = Graphics.FromImage(img);
				MyDraw(new CContextDessinObjetGraphique(g));
				m_bMiniature = false;
				return img;
			}
		}
		private Image RegarderMiniature(Image img)
		{
			return img;
		}
		private Image SupprimerCouleur(Image img)
		{
			return img;
			//ColorMatrix cm = new ColorMatrix(new float[][]{
			//    new float[]{0.5f,0.5f,0.5f,0,0},
			//    new float[]{0.5f,0.5f,0.5f,0,0},
			//    new float[]{0.5f,0.5f,0.5f,0,0},
			//    new float[]{0,0,0,1,0,0},
			//    new float[]{0,0,0,0,1,0},
			//    new float[]{0,0,0,0,0,1}});
			//ImageAttributes ia = new ImageAttributes();
			//ia.SetColorMatrix(cm);
			//Graphics g = Graphics.FromImage(img);
			//g.DrawImage(img, new Rectangle(), 0, 0, img.Size.Width, img.Size.Height, GraphicsUnit.Pixel, ia);
			//return img;

		}

		public override bool IsLock
		{
			get
			{
				return true;
			}
			set
			{
			}
		}
		
		//--------------------------------------------
		public CProjet Projet
		{
			get
			{
				return m_prj;
			}
			set
			{
				m_prj = value;
			}
		}


		//--------------------------------------------
		public override bool AcceptChilds
		{
			get
			{
				return true;
			}
		}

		//--------------------------------------------------
		private int GetNumVersion()
		{
			return 0;
		}

		//--------------------------------------------------
		protected override sc2i.common.CResultAErreur MySerialize(sc2i.common.C2iSerializer serializer)
		{
			int nVersion = GetNumVersion();
			CResultAErreur result = serializer.TraiteVersion(ref nVersion);
			if (!result)
				return result;

			return result;
		}

		//--------------------------------------------------
		public static CWndProjetDetail GetNewWnd(CProjet projet)
		{
			CWndProjetDetail wnd = new CWndProjetDetail( projet );


			Dictionary<CProjet, CWndProjetBrique> tableProjets = new Dictionary<CProjet, CWndProjetBrique>();
			CListeObjetsDonnees prjs = projet.ProjetsFils;
			foreach(CProjet p in prjs)
			{
				CWndProjetBrique wndPrj = new CWndProjetBrique(p);
				tableProjets.Add(p,wndPrj);
				wnd.AddChild(wndPrj);
			}
			
			Dictionary<CIntervention, CWndIntervention> tableInters = new Dictionary<CIntervention, CWndIntervention>();
			CListeObjetsDonnees inters = projet.Interventions;
			foreach (CIntervention i in inters)
			{
				CWndIntervention wndInter = new CWndIntervention(i);
				tableInters.Add(i,wndInter);
				wnd.AddChild(wndInter);
			}

			CListeObjetsDonnees liens = projet.LiensDuProjet;
			foreach(CLienDeProjet l in liens)
			{
				CWndLienDeProjet wndLien = new CWndLienDeProjet(l);
				if (l.ElementA is CIntervention)
				{
					//SC 20/05/08 : si l'inter n'existe pas, on ne crée pas le wndLien
					if (tableInters.ContainsKey((CIntervention)l.ElementA))
						wndLien.ElementDepart = tableInters[(CIntervention)l.ElementA];
					else
						continue;
				}
				else if (l.ElementA is CProjet)
				{
					//SC 20/05/08 : si le projet n'existe pas, on ne crée pas le wndLien
					if (tableProjets.ContainsKey((CProjet)l.ElementA))
						wndLien.ElementDepart = tableProjets[(CProjet)l.ElementA];
					else
						continue;
				}
				else
					continue;
				if (l.ElementB is CIntervention)
				{
					//SC 20/05/08 : si l'inter n'existe pas, on ne crée pas le wndLien
					if (tableInters.ContainsKey((CIntervention)l.ElementB))
						wndLien.ElementArrivee = tableInters[(CIntervention)l.ElementB];
					else
						continue;
				}
				else if (l.ElementB is CProjet)
				{
					//SC 20/05/08 : si le projet n'existe pas, on ne crée pas le wndLien
					if (tableProjets.ContainsKey((CProjet)l.ElementB))
						wndLien.ElementArrivee = tableProjets[(CProjet)l.ElementB];
					else
						continue;
				}
				else
					continue;

				wnd.AddChild(wndLien);
			}

			return wnd;
		}

		//-------------------------------------------------------
		public ETypeElementDeProjet? GetTypeObjetFilsFromPoint(System.Drawing.Point ptSouris)
		{
			I2iObjetGraphique o = GetObjetFilsFromPoint(ptSouris);

			if (o == null)
				return null;
			else if(o is CWndIntervention)
				return ETypeElementDeProjet.Intervention;
			else if(o is CWndLienDeProjet)
				return ETypeElementDeProjet.Lien;
			else if(o is CWndProjetBrique)
				return ETypeElementDeProjet.Projet;
			return null;


		}
		public I2iObjetGraphique GetObjetFilsFromPoint(System.Drawing.Point ptSouris)
		{
			foreach (I2iObjetGraphique wnd in Childs)
			{
				if ((wnd is CWndProjetBrique ||
					wnd is CWndLienDeProjet ||
					wnd is CWndIntervention) &&
					wnd.IsPointIn(ptSouris))
					return wnd;
			}
			return null;
		}

		//-------------------------------------------------------
		public override I2iObjetGraphique[] Childs
		{
			get 
			{
				return m_listeChilds.ToArray();
			}
		}

		//-------------------------------------------------------
		public override bool AddChild(I2iObjetGraphique child)
		{
			child.Parent = this;
			m_listeChilds.Add(child);
			return true;
		}

		//-------------------------------------------------------
		public override bool ContainsChild(I2iObjetGraphique child)
		{
			return m_listeChilds.Contains(child);
			
		}
		public void RemoveChildOnlyInGraphic(I2iObjetGraphique child)
		{
			m_listeChilds.Remove(child);
		}
		//-------------------------------------------------------
		public override void RemoveChild(I2iObjetGraphique child)
		{

			CResultAErreur result = CResultAErreur.True;
			if (child is IObjetGraphiqueASuppressionSurveillee)
				result = ((IObjetGraphiqueASuppressionSurveillee)child).OnDelete();
			if ( result )
				m_listeChilds.Remove(child);
			
		}

		public override void BringToFront(I2iObjetGraphique child)
		{
			if (!ContainsChild(child))
				return;
			m_listeChilds.Remove(child);
			m_listeChilds.Add(child);
		}

		public override void FrontToBack(I2iObjetGraphique child)
		{
			if (!ContainsChild(child))
				return;
			m_listeChilds.Remove(child);
			m_listeChilds.Insert(0, child);
		}
		//-------------------------------------------------------
		protected override void MyDraw(CContextDessinObjetGraphique ctx)
		{
			if (!m_prj.IsValide())
				return;

			Graphics g = ctx.Graphic;
			foreach (I2iObjetGraphique objet in m_listeChilds)
			{
				if (objet is CWndProjetBrique && m_prj.AfficherMiniature && !m_bMiniature)
				{
					CWndProjetBrique prj = (CWndProjetBrique)objet;
					g.DrawImageUnscaled(prj.Miniature,new Rectangle(prj.Position.X,prj.Position.Y, prj.Projet.DesignerProjetWidth,prj.Projet.DesignerProjetHeight));
					Rectangle rect = new Rectangle(prj.Position.X, prj.Position.Y,  prj.Projet.DesignerProjetWidth,prj.Projet.DesignerProjetHeight);
					Pen pen = new Pen(Color.Black);
					g.DrawRectangle(pen, rect);
					pen.Dispose();
				}
				else
					objet.Draw(ctx);
			}
		}

		//-------------------------------------------------------
		public void NettoieObjetsInvalides()
		{
			foreach (I2iObjetGraphique objet in Childs)
				if (objet is IObjetGraphiqueASuppressionSurveillee)
					if (!((IObjetGraphiqueASuppressionSurveillee)objet).IsValide())
						RemoveChild(objet);		
		}


		

	}

}
