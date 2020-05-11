using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Drawing;

using sc2i.common;
using sc2i.formulaire;
using sc2i.drawing;



namespace timos.data
{
	/// <summary>
	/// Dessine les sous tâches d'une Intervention
	/// </summary>
	public class CWndProjetBrique : 
		C2iWndLabelBase,
		IWndElementDeProjetPlanifiable,
		IObjetGraphiqueASuppressionSurveillee
	{
		private bool m_bMiniature = false;
		private CProjet m_projet = null;

		private List<C2iObjetGraphique> m_listeChilds = new List<C2iObjetGraphique>();

				//-------------------------------------------------
		public CWndProjetBrique()
			:base()
		{
			Init();
		}

		//--------------------------------------------
		public CWndProjetBrique(CProjet projet)
		{
			m_projet = projet;
			Init();
			
		}
		public Image Miniature
		{
			get
			{
				m_bMiniature = true;
				Image img = CWndProjetDetail.GetNewWnd(m_projet).Miniature;
				Bitmap bmp = new Bitmap(img, m_projet.DesignerProjetWidth, m_projet.DesignerProjetHeight);
				return bmp;

			}
		}
		//-------------------------------------------------
		private void Init()
		{
			if (m_projet.DesignerProjetWidth == 0)
				m_projet.DesignerProjetWidth = 100;
			if (m_projet.DesignerProjetHeight == 0)
				m_projet.DesignerProjetHeight = 50;


			Position = new Point(m_projet.DesignerProjetX, m_projet.DesignerProjetY);
			Size = new Size(m_projet.DesignerProjetWidth, m_projet.DesignerProjetHeight);

			BorderStyle = LabelBorderStyle.Plein;
			BackColor = Color.Orange;
			ForeColor = Color.Black;
			
			Font = new Font("Arial", 8);
			Text = m_projet.Libelle;
			TextAlign = ContentAlignment.MiddleCenter;
		}

		private bool m_bDetacher = false;
		public bool Detacher
		{
			get
			{
				return m_bDetacher;
			}
			set
			{
				m_bDetacher = value;
			}
		}
		public CProjet Projet
		{
			get
			{
				return m_projet;
			}
			set
			{
				m_projet = value;
			}
		}
		public bool AfficherIcoEtat
		{
			get
			{
				return m_projet.AfficherIcoEtat;
			}
			set
			{
				m_projet.AfficherIcoEtat = value;
			}
		}
		public bool AfficherIcoAno
		{
			get
			{
				return m_projet.AfficherIcoAno;
			}
			set
			{
				m_projet.AfficherIcoAno = value;
			}
		}
		public IElementDeProjetPlanifiable ElementDuProjet
		{
			get
			{
				return m_projet;
			}
			set
			{
				m_projet = (CProjet)value;
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
		//-------------------------------------------------
		protected override CResultAErreur MySerialize(C2iSerializer serializer)
		{
			int nVersion = GetNumVersion();
			CResultAErreur result = serializer.TraiteVersion(ref nVersion);
			if (result)
				result = base.MySerialize(serializer);
			if (!result)
				return result;

			//Implémenter ici le code de sérialisation spécifique
			return result;
		}

		//-------------------------------------------------
		public Point[] GetPolygoneDessin()
		{
			List<Point> lst = new List<Point>();
			lst.Add(new Point(Position.X, Position.Y));
			lst.Add(new Point(Position.X + Size.Width, Position.Y));
			lst.Add(new Point(Position.X + Size.Width, Position.Y + Size.Height));
			lst.Add(new Point(Position.X, Position.Y + Size.Height));
			return lst.ToArray();
		}

		//-------------------------------------------------
		protected override void MyDraw(CContextDessinObjetGraphique ctx)
		{
			Graphics g = ctx.Graphic;
			if (!m_projet.IsValide())
				return;
			Text = m_projet.Libelle;

			if (m_bMiniature)
				g.DrawImage(new CWndProjetDetail(m_projet).Miniature, Position);
			else
				base.MyDraw(ctx);

			m_bMiniature = false;


			CUtilProjet.DrawIcones(g, this);
		}

		//-------------------------------------------------
		public override Point Position
		{
			get
			{
				return base.Position;
			}
			set
			{
				base.Position = value;
				m_projet.DesignerProjetX = value.X;
				m_projet.DesignerProjetY = value.Y;
			}
		}

		//-------------------------------------------------
		public override Size Size
		{
			get
			{
				return base.Size;
			}
			set
			{
				base.Size = value;
				m_projet.DesignerProjetWidth = value.Width;
				m_projet.DesignerProjetHeight = value.Height;
			}
		}

		/// ////////////////////////////////////////////////////////
		public CResultAErreur OnDelete()
		{
			if(m_projet.IsValide() && !m_bDetacher)
				return m_projet.Delete();
			else
				return CResultAErreur.True;
		}

		/// ////////////////////////////////////////////////////////
		public bool IsValide()
		{
			return m_projet != null && m_projet.IsValide();
		}
	}

}
