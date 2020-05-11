using System;
using System.Collections.Generic;
using System.Text;

using sc2i.common;
using sc2i.formulaire;
using sc2i.data.dynamic;
using System.Drawing;
using System.Drawing.Design;
using timos.data;
using sc2i.expression;
using System.ComponentModel;

namespace timos.data.C2iWndComposants
{
	[WndName("Operations report")]
	[Serializable]
	public class C2iWndSaisieOperations : C2iWndComposantFenetre
	{
		private bool m_bPanelEnteteVisible = false;
        private C2iExpression m_expressionElement = null;

		public C2iWndSaisieOperations()
			: base()
		{

            Size = new Size(200, 100);
		}

		//-----------------------------------
		private void RecalcLayout()
		{

	
		}

		//-----------------------------------
		public override bool CanBeUseOnType(Type tp)
		{
            if (tp != null)
            {
                if (typeof(CFractionIntervention).Equals(tp) ||
                    typeof(CPhaseTicket).Equals(tp))
                    return true;
            }
			return false;
		}

		//-----------------------------------
		public override System.Drawing.Size Size
		{
			get
			{
				return base.Size;
			}
			set
			{
				base.Size = value;
				RecalcLayout();
			}
		}

		//-----------------------------------
		public bool HeaderPanelVisible
		{
			get
			{
				return m_bPanelEnteteVisible;
			}
			set
			{
				m_bPanelEnteteVisible = value;
			}
		}

        //------------------------------------------------------------------------------
        [TypeConverter(typeof(CExpressionOptionsConverter))]
        [System.ComponentModel.Editor(typeof(CProprieteExpressionEditor), typeof(UITypeEditor))]
        public C2iExpression FormuleElement
        {
            get
            {
                return m_expressionElement;
            }
            set
            {
                m_expressionElement = value;
            }
        }


		//-------------------------------------------------------------------------
		private int GetNumVersion()
		{
			return 1;
		}

		//---------------------------------------------------------------------------
		protected override CResultAErreur  MySerialize(C2iSerializer serializer)
		{
			int nVersion = GetNumVersion();
			CResultAErreur result = serializer.TraiteVersion(ref nVersion);
			if (!result)
				return result;

            serializer.TraiteBool(ref m_bPanelEnteteVisible);

            if (nVersion >= 1)
            {
                result = serializer.TraiteObject<C2iExpression>(ref m_expressionElement);
                if (!result)
                    return result;
            }
			return result;
		}

		//-----------------------------------
		public override bool AcceptChilds
		{
			get
			{
				return false;
			}
		}

		//-----------------------------------
		protected override void MyDraw(sc2i.drawing.CContextDessinObjetGraphique ctx)
		{
			Graphics g = ctx.Graphic;
			Brush b = new SolidBrush(BackColor);
			Rectangle rect = new Rectangle(Position, Size);
            if (HeaderPanelVisible)
                g.DrawImage(global::timos.data.Resource.fond_saisie_operations_v1, rect);
            else
                g.DrawImage(global::timos.data.Resource.fond_saisie_operations_V2, rect);
			
			b.Dispose();

			base.MyDraw(ctx);
		}

		//-----------------------------------
		public override void DrawInterieur(sc2i.drawing.CContextDessinObjetGraphique ctx)
		{

		}


		//-----------------------------------
		public override void OnDesignSelect(
			Type typeEdite,
			object objetEdite,
			sc2i.expression.IFournisseurProprietesDynamiques fournisseurProprietes)
		{
			base.OnDesignSelect(typeEdite, objetEdite, fournisseurProprietes);
			

		}


	}
}
