using System;
using System.Drawing;
using System.Collections;
using System.Drawing.Design;

using sc2i.common;
using sc2i.formulaire;
using System.Collections.Generic;
using timos.data;
using sc2i.expression;
using System.ComponentModel;

namespace sc2i.formulaire
{
    /// <summary>
    /// Description résumée de C2iWndConsultationHierarchique.
    /// </summary>
    [WndName("Object tree")]
    public class C2iWndConsultationHierarchique : C2iWndLabel
    {
        private int m_nIdConsultationHierarchique = -1;
        private C2iExpression m_formuleSource = null;

        public C2iWndConsultationHierarchique()
        {
        }

        /// ///////////////////////////////////////
        public override bool CanBeUseOnType(Type tp)
        {
            return false;
        }

        /// ////////////////////////////////////
        private int GetNumVersion()
        {
            return 0;
        }

        /// ////////////////////////////////////
        protected override CResultAErreur MySerialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (result)
                result = base.MySerialize(serializer);
            if (!result)
                return result;
            serializer.TraiteInt(ref m_nIdConsultationHierarchique);

            result = serializer.TraiteObject<C2iExpression>(ref m_formuleSource);
            if (!result)
                return result;
            

            return result;
        }

        /// ////////////////////////////////////
        public int IdConsultation
        {
            get
            {
                return m_nIdConsultationHierarchique;
            }
            set
            {
                m_nIdConsultationHierarchique = value;
            }
        }


        /// ////////////////////////////////////
        [TypeConverter(typeof(CExpressionOptionsConverter))]
        [System.ComponentModel.Editor(typeof(CProprieteExpressionEditor), typeof(UITypeEditor))]
        public C2iExpression FormuleSource
        {
            get
            {
                return m_formuleSource;
            }
            set
            {
                m_formuleSource = value;
            }
        }


        /////////////////////////////////////////////////////////////////
        public override void OnDesignSelect(
            Type typeEdite,
            object objetEdite,
            sc2i.expression.IFournisseurProprietesDynamiques fournisseurProprietes)
        {
            base.OnDesignSelect(typeEdite, objetEdite, fournisseurProprietes);
        }


        public override CDescriptionEvenementParFormule[] GetDescriptionsEvenements()
        {
            List<CDescriptionEvenementParFormule> lst = new List<CDescriptionEvenementParFormule>();
            lst.AddRange(base.GetDescriptionsEvenements());
            
            return lst.ToArray();
        }


    }

 
}
