using System;
using System.Collections.Generic;
using System.Text;
using sc2i.common;

namespace timos.data.workflow.ConsultationHierarchique
{
	[Serializable]
	public class CFolderConsultationFolder : CFolderConsultationHierarchique
	{
		public CFolderConsultationFolder(CFolderConsultationHierarchique folderParent)
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
			return result;
		}

		public override object[] GetObjets(CNodeConsultationHierarchique nodeParent, sc2i.data.CContexteDonnee contexteDonnee)
		{
            if ( nodeParent != null )
                return new object[] { nodeParent.ObjetLie };
            return new object[] { null };

		}

		public override Type TypeElements
		{
			get
			{
				if (FolderParent != null)
					return FolderParent.TypeElements;
				return null;
			}
		}

        public override string GetLibelleNode(object source)
        {
            return Libelle;
        }

        

        public override string FolderTypeName
        {
            get { return I.T("Free folder|20057"); }
        }
	}
}
