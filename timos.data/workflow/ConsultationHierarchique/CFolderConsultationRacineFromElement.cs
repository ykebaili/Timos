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
	public class CFolderConsultationRacineFromElement : CFolderConsultationHierarchique
	{
        private Type m_typeElement = null;

        //Lors de l'execution
        private object m_objetRacine = null;

		public CFolderConsultationRacineFromElement()
			: base(null)
		{
		}

        public CFolderConsultationRacineFromElement(CFolderConsultationHierarchique parent)
            : base(null)
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
            serializer.TraiteType(ref m_typeElement);
            return result;
		}

        //---------------------------------------------
        public Type TypeRacine
        {
            get
            {
                return m_typeElement;
            }
            set
            {
                m_typeElement = value;
            }
        }


        //---------------------------------------------
        public void InitConsultation(object objetRacine)
        {
            m_objetRacine = objetRacine; ;
        }


        //---------------------------------------------
        public object ObjetRacine
        {
            get
            {
                return m_objetRacine;
            }
        }
        //---------------------------------------------
		public override object[] GetObjets(CNodeConsultationHierarchique nodeParent, sc2i.data.CContexteDonnee contexteDonnee)
		{
            return new object[] { m_objetRacine };
		}

        //---------------------------------------------
        public override Type TypeElements
        {
            get
            {
                return TypeRacine;
            }
        }

        public override string FolderTypeName
        {
            get { return ""; }
        }
	}
}
