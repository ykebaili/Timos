using System;
using System.Collections.Generic;
using System.Text;
using sc2i.common;
using sc2i.expression;
using sc2i.data;
using System.Collections;

namespace timos.data.workflow.ConsultationHierarchique
{
	[Serializable]
	public class CFolderConsultationFromFormula : CFolderConsultationHierarchique
	{
        private C2iExpression m_formuleObjets = null;

		public CFolderConsultationFromFormula(CFolderConsultationHierarchique folderParent)
			: base(folderParent)
		{
		}

		private int GetNumVersion()
		{
			return 0;
		}

		public override sc2i.common.CResultAErreur Serialize(sc2i.common.C2iSerializer serializer)
		{
			int nVersion = GetNumVersion();
			CResultAErreur result = serializer.TraiteVersion(ref nVersion);
			if (!result)
				return result;
			result = base.Serialize(serializer);
			if (!result)
				return result;
            result = serializer.TraiteObject<C2iExpression>(ref m_formuleObjets);
            if (!result)
                return result;
			return result;
		}

        //---------------------------------------------
        public C2iExpression FormuleObjets
        {
            get
            {
                return m_formuleObjets;
            }
            set
            {
                m_formuleObjets = value;
            }
        }

        //---------------------------------------------
		public override object[] GetObjets(CNodeConsultationHierarchique nodeParent, sc2i.data.CContexteDonnee contexteDonnee)
		{
            if (m_formuleObjets == null)
                return new object[0];
            CContexteEvaluationExpression ctx = new CContexteEvaluationExpression(nodeParent);
            CResultAErreur result = m_formuleObjets.Eval(ctx);
            IEnumerable en = result.Data as IEnumerable;
            ArrayList lstObjets = new ArrayList();
            if (en != null)
            {
                foreach ( object obj in en )
                    lstObjets.Add ( obj );
            }
            else if (result.Data != null)
                lstObjets.Add(result.Data);
            return lstObjets.ToArray();
		}

        //---------------------------------------------
        public override Type TypeElements
        {
            get
            {
                if (m_formuleObjets != null)
                {
                    CTypeResultatExpression typeRes = m_formuleObjets.TypeDonnee;
                    return typeRes.TypeDotNetNatif;
                }
                return null;
            }
        }

        

        public override string FolderTypeName
        {
            get { return I.T("Formula|20059"); }
        }
	}
}
