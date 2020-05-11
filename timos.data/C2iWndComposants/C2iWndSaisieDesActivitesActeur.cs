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
using timos.acteurs;
using System.ComponentModel;

namespace timos.data.C2iWndComposants
{
	[WndName("Member Activity")]
	[Serializable]
	public class C2iWndSaisieDesActivitesActeur : C2iWndComposantFenetre
	{
		private bool m_bPanelEnteteVisible = true;
        private C2iExpression m_expressionElement = null;
        private C2iExpression m_expDateInitialeDebutSaisie;
        private C2iExpression m_expDateInitialeFinSaisie;

        public const string c_strIdEvenementChangeDates = "CHANGE_DATES";

        public C2iWndSaisieDesActivitesActeur()
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
                if (typeof(CActeur).Equals(tp))                    
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
        public C2iExpression InitialStartDate
        {
            get
            {
                return m_expDateInitialeDebutSaisie;
            }
            set
            {
                m_expDateInitialeDebutSaisie = value;
            }
        }

        //------------------------------------------------------------------------------
        [TypeConverter(typeof(CExpressionOptionsConverter))]
        [System.ComponentModel.Editor(typeof(CProprieteExpressionEditor), typeof(UITypeEditor))]
        public C2iExpression InitialEndDate
        {
            get
            {
                return m_expDateInitialeFinSaisie;
            }
            set
            {
                m_expDateInitialeFinSaisie = value;
            }
        }

		//-------------------------------------------------------------------------
		private int GetNumVersion()
		{
            //return 0;
			return 1; // Ajout dates de début et fin de saisie
		}

		//---------------------------------------------------------------------------
		protected override CResultAErreur  MySerialize(C2iSerializer serializer)
		{
			int nVersion = GetNumVersion();
			CResultAErreur result = serializer.TraiteVersion(ref nVersion);
			if (!result)
				return result;

            serializer.TraiteBool(ref m_bPanelEnteteVisible);

            result = serializer.TraiteObject<C2iExpression>(ref m_expressionElement);
            if (!result)
                return result;

            if (nVersion >= 1)
            {
                result = serializer.TraiteObject<C2iExpression>(ref m_expDateInitialeDebutSaisie);
                if (!result)
                    return result;
                result = serializer.TraiteObject<C2iExpression>(ref m_expDateInitialeFinSaisie);
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
            if (m_bPanelEnteteVisible)
                g.DrawImage(global::timos.data.Resource.Fond_saisie_des_activites_acteur_v1, rect);
            else
                g.DrawImage(global::timos.data.Resource.Fond_saisie_des_activites_acteur_v2, rect);
            
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

        public override CDefinitionProprieteDynamique[] GetProprietesInstance()
        {
            List<CDefinitionProprieteDynamique> lst = new List<CDefinitionProprieteDynamique>(base.GetProprietesInstance());
            lst.Add(new CDefinitionProprieteDynamiqueDeportee(
                "StartDate",
                "DateDebut",
                new CTypeResultatExpression(typeof(DateTime), false),
                false,
                true,
                ""));

            lst.Add(new CDefinitionProprieteDynamiqueDeportee(
                "EndDate",
                "DateFin",
                new CTypeResultatExpression(typeof(DateTime), false),
                false,
                true,
                ""));

            lst.Add(new CDefinitionMethodeDynamique(
                "Init", "Init",
                new CTypeResultatExpression(typeof(void), false),
                false,
                I.T("Initialisation du control"),
                new string[] { I.T("1"), I.T("2"), I.T("3") }));

            return lst.ToArray();
        }


        public override CDescriptionEvenementParFormule[] GetDescriptionsEvenements()
        {
            List<CDescriptionEvenementParFormule> lst = new List<CDescriptionEvenementParFormule>(base.GetDescriptionsEvenements());
            lst.Add(new CDescriptionEvenementParFormule(
                c_strIdEvenementChangeDates,
                "OnChangeDates",
                I.T("Occurs when dates are modified|10007")));

            return lst.ToArray();
        }

	}
}
