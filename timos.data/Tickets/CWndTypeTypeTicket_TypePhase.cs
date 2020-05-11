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
	public class CWndTypeTypeTicket_TypePhase : 
		C2iWndLabelBase,
		IObjetGraphiqueASuppressionSurveillee
	{
		private CTypeTicket_TypePhase m_relTypePhase = null;

		//-------------------------------------------------
		public CWndTypeTypeTicket_TypePhase()
			:base()
		{
			Init();
		}

		//-------------------------------------------------
		public CWndTypeTypeTicket_TypePhase(CTypeTicket_TypePhase relTypePhase)
		{
			m_relTypePhase = relTypePhase;
			Position = new Point(relTypePhase.X, relTypePhase.Y);
			Size = new Size(relTypePhase.Width, relTypePhase.Height);
			Init();
			Text = m_relTypePhase.TypePhase.Libelle;
			TextAlign = ContentAlignment.MiddleCenter;
		}

		//-------------------------------------------------
		public CTypeTicket_TypePhase TypeTicket_TypePhase
		{
			get
			{
				return m_relTypePhase;
			}
			set
			{
				m_relTypePhase = value;
			}
		}

		//-------------------------------------------------
		private void Init()
		{
			this.BorderStyle = LabelBorderStyle.Plein;
			BackColor = Color.White;
			ForeColor = Color.Black;
			Font = new Font("Arial", 8);
		}

		//-------------------------------------------------
		private int GetNumVersion()
		{
			return 0;
		}

		//-------------------------------------------------
		protected override CResultAErreur  MySerialize(C2iSerializer serializer)
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
			lst.Add ( new Point ( Position.X+Size.Width, Position.Y + Size.Height ));
			lst.Add ( new Point (Position.X, Position.Y + Size.Height ) );
			return lst.ToArray();
		}

		//-------------------------------------------------
		protected override void  MyDraw(CContextDessinObjetGraphique ctx)
		{
			base.MyDraw(ctx);
			Graphics g = ctx.Graphic;
			if (!TypeTicket_TypePhase.IsValide())
				return;
			if (TypeTicket_TypePhase.IsPointEntree)
			{
				Rectangle rect = new Rectangle(Position.X, Position.Y, 10, 10);
				g.FillEllipse(Brushes.Green, rect);
			}
            if(TypeTicket_TypePhase.IsPointSortie)
            {
                Rectangle rect = new Rectangle(Position.X + 10, Position.Y, 10, 10);
                g.FillEllipse(Brushes.Red, rect);
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
				m_relTypePhase.X = value.X;
				m_relTypePhase.Y = value.Y;
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
				m_relTypePhase.Width = value.Width;
				m_relTypePhase.Height = value.Height;
			}
		}

		/// ////////////////////////////////////////////////////////
		public CResultAErreur OnDelete()
		{
			return m_relTypePhase.Delete();
		}

		/// ////////////////////////////////////////////////////////
		public bool IsValide()
		{
			return m_relTypePhase != null && m_relTypePhase.IsValide();
		}
	}
}
