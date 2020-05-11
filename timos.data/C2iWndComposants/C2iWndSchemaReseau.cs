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
	[WndName("Network diagram")]
	[Serializable]
	public class C2iWndSchemaReseau : C2iWndComposantFenetre
	{
        private C2iExpression m_expressionElement = null;
        private C2iExpression m_expressionVueSchemaDynamique = null;
        

		public C2iWndSchemaReseau()
			: base()
		{
            Size = new Size(400, 300);
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


        //------------------------------------------------------------------------------
        [TypeConverter(typeof(CExpressionOptionsConverter))]
        [System.ComponentModel.Editor(typeof(CProprieteExpressionEditor), typeof(UITypeEditor))]
        public C2iExpression ElementFormula
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

        //------------------------------------------------------------------------------
        [TypeConverter(typeof(CExpressionOptionsConverter))]
        [System.ComponentModel.Editor(typeof(CProprieteExpressionEditor), typeof(UITypeEditor))]
        public C2iExpression DynamicNetworkViewFormula
        {
            get
            {
                return m_expressionVueSchemaDynamique;
            }
            set
            {
                m_expressionVueSchemaDynamique = value;
            }
        }


		//-------------------------------------------------------------------------
		private int GetNumVersion()
		{
			return 0;
		}

		//---------------------------------------------------------------------------
		protected override CResultAErreur  MySerialize(C2iSerializer serializer)
		{
			int nVersion = GetNumVersion();
			CResultAErreur result = serializer.TraiteVersion(ref nVersion);
			if (!result)
				return result;

            result = serializer.TraiteObject<C2iExpression>(ref m_expressionElement);
            if (!result)
                return result;

            result = serializer.TraiteObject<C2iExpression>(ref m_expressionVueSchemaDynamique);
            if (!result)
                return result;


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
            
            g.DrawImage(global::timos.data.Resource.WAN_diagram_web_2, rect);
			
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
