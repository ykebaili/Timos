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
	public class CWndTypeIntervention_SousIntervention : 
        C2iWndLabelBase
        //IObjetGraphiqueASuppressionSurveillee
	{
        //private CTypeIntervention_SousIntervention m_sousIntervention = null;

		//-------------------------------------------------
		public CWndTypeIntervention_SousIntervention()
			:base()
		{
			Init();
		}

        ////-------------------------------------------------
        //public CWndTypeIntervention_SousIntervention(CTypeIntervention_SousIntervention sousIntervention)
        //{
        //    m_sousIntervention = sousIntervention;
        //    Position = new Point(sousIntervention.X, sousIntervention.Y);
        //    Size = new Size(sousIntervention.Width, sousIntervention.Height);
        //    Init();
        //    Text = m_sousIntervention.TypeSousIntervention.Libelle;
        //    TextAlign = ContentAlignment.MiddleCenter;
        //}

		//-------------------------------------------------
        //public CTypeIntervention_SousIntervention TypeIntervention_SousIntervention
        //{
        //    get
        //    {
        //        return m_sousIntervention;
        //    }
        //    set
        //    {
        //        m_sousIntervention = value;
        //    }
        //}

        ////-------------------------------------------------
        private void Init()
        {
        //    this.BorderStyle = LabelBorderStyle.Plein;
        //    BackColor = Color.White;
        //    ForeColor = Color.Black;
        //    Font = new Font("Arial", 8);
        }

        ////-------------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        ////-------------------------------------------------
        protected override CResultAErreur  MySerialize(C2iSerializer serializer)
        {
        //    int nVersion = GetNumVersion();
            //CResultAErreur result = serializer.TraiteVersion(ref nVersion);
        //    if (result)
        //        result = base.MySerialize(serializer);
        //    if (!result)
        //        return result;

        //    //Implémenter ici le code de sérialisation spécifique
           // return result;
            return CResultAErreur.True;
        }

        ////-------------------------------------------------
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
            base.MyDraw(ctx);
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
                //TypeIntervention_SousIntervention.X = value.X;
                //TypeIntervention_SousIntervention.Y = value.Y;
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
                //TypeIntervention_SousIntervention.Width = value.Width;
                //TypeIntervention_SousIntervention.Height = value.Height;
            }
        }

        /// ////////////////////////////////////////////////////////
        public CResultAErreur OnDelete()
        {
            //return m_sousIntervention.Delete();
            return CResultAErreur.True;
        }

        /// ////////////////////////////////////////////////////////
        public bool IsValide()
        {
            //return m_sousIntervention != null && m_sousIntervention.IsValide();
            return true;
        }
	}
}
