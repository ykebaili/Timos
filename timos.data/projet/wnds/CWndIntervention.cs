using System;
using System.Collections.Generic;
using System.Text;


using System.Drawing;
using sc2i.drawing;
using sc2i.common;
using sc2i.formulaire;

namespace timos.data
{
	/// <summary>
	/// Représente graphiquement une Intervention
	/// </summary>
	public class CWndIntervention :
		C2iWndLabelBase,
		IWndElementDeProjetPlanifiable,
		IObjetGraphiqueASuppressionSurveillee
	{
		private CIntervention m_intervention = null;

		//-------------------------------------------------
		public CWndIntervention()
			:base()
		{
			Init();
		}

		//-------------------------------------------------
		public CWndIntervention(CIntervention intevention)
		{
			m_intervention = intevention;
			Init();
		}
		//-------------------------------------------------
		private void Init()
		{
			Position = new Point(m_intervention.DesignerProjetX, m_intervention.DesignerProjetY);
			
			if (m_intervention.DesignerProjetWidth == 0)
				m_intervention.DesignerProjetWidth = 100;
			if (m_intervention.DesignerProjetHeight == 0)
				m_intervention.DesignerProjetHeight = 50;

			Size = new Size(m_intervention.DesignerProjetWidth, m_intervention.DesignerProjetHeight);
			Text = m_intervention.Libelle;
			TextAlign = ContentAlignment.MiddleCenter;
			BorderStyle = LabelBorderStyle.Plein;
			BackColor = Color.AliceBlue;
			ForeColor = Color.Black;
			Font = new Font("Arial", 8);
		}
		//-------------------------------------------------
		public CIntervention Intervention
		{
			get
			{
				return m_intervention;
			}
			set
			{
				m_intervention = value;
			}
		}
		public IElementDeProjetPlanifiable ElementDuProjet
		{
			get
			{
				return m_intervention;
			}
			set
			{
				m_intervention = (CIntervention)value;
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
			if (!m_intervention.IsValide())
				return;
			Text = m_intervention.Libelle;

			base.MyDraw(ctx);

			CUtilProjet.DrawIcones(ctx.Graphic, this);
			
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
				m_intervention.DesignerProjetX = value.X;
				m_intervention.DesignerProjetY = value.Y;
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
				m_intervention.DesignerProjetWidth = value.Width;
				m_intervention.DesignerProjetHeight = value.Height;
			}
		}

		/// ////////////////////////////////////////////////////////
		public CResultAErreur OnDelete()
		{
			if (m_intervention.IsValide() && !m_bDetacher)
				return m_intervention.Delete();
			else
				return CResultAErreur.True;
		}

		/// ////////////////////////////////////////////////////////
		public bool IsValide()
		{
			return m_intervention != null && m_intervention.IsValide();
		}
	}

}
