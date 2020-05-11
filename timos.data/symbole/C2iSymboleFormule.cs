using System;
using System.Drawing;
using System.IO;
using System.Drawing.Design;
using System.Drawing.Drawing2D;

using sc2i.common;
using sc2i.drawing;
using sc2i.formulaire;

using sc2i.expression;
using System.Collections;


namespace timos.data
{

    [WndName("Formula")]
    [Serializable]
    [VisibleInInterfaceAttribute]
    public class C2iSymboleFormule : C2iSymboleLabel
    {



        private C2iExpression m_expression;

        private string m_strFormatAffichage = "";

        [System.ComponentModel.Description(@"Format")]
        public string Format
        {
            get
            {
                return m_strFormatAffichage;
            }
            set
            {
                m_strFormatAffichage = value;
            }
        }

       


        [System.ComponentModel.Editor(typeof(CProprieteExpressionEditor), typeof(UITypeEditor))]
        public C2iExpression Formula
        {
            get
            {
                return m_expression;
            }
            set
            {
                m_expression = value;
            }

        }

        //-------------------------------------------------------
        public override IElementASymbolePourDessin ElementASymbole
        {
            get
            {
                return base.ElementASymbole;
            }
            set
            {
                base.ElementASymbole = value;
                if (Formula != null && value != null)
                {
                    CContexteEvaluationExpression ctx = new CContexteEvaluationExpression(ElementASymbole);
                    CResultAErreur result = Formula.Eval(ctx);
                    if (result)
                    {
                        object data = result.Data;
                        Text = data == null ? "" : data.ToString();
                    }
                }
            }
        }

        private int GetNumVersion()
        {
            return 1;
        }

        protected override CResultAErreur MySerialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            if (result)
                result = base.MySerialize(serializer);

            serializer.TraiteString(ref m_strFormatAffichage);

            I2iSerializable objet = m_expression;
            result = serializer.TraiteObject(ref objet);
            if (!result)
                return result;
            m_expression = (C2iExpression)objet;


            return result;
        }

        protected override void FillListeProprietesUtilisees(System.Collections.Generic.HashSet<CDefinitionProprieteDynamique> def)
        {
            base.FillListeProprietesUtilisees(def);
            if (m_expression != null)
            {
                ArrayList lst = m_expression.ExtractExpressionsType(typeof(C2iExpressionChamp));
                foreach (C2iExpressionChamp exp in lst)
                {
                    if (exp.DefinitionPropriete != null)
                        def.Add(exp.DefinitionPropriete);
                }
            }
        }
    }
}
