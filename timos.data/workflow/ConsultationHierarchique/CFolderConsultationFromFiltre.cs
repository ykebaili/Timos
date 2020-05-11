using System;
using System.Collections.Generic;
using System.Text;
using sc2i.data.dynamic;
using sc2i.expression;
using sc2i.common;
using sc2i.data;

namespace timos.data.workflow.ConsultationHierarchique
{
	[Serializable]
	public class CFolderConsultationFromFiltre : CFolderConsultationHierarchique
	{
		private CFiltreDynamique m_filtreDynamique = null;

        private const string c_strNomVariableFiltre = "Parent folder";

		public CFolderConsultationFromFiltre(CFolderConsultationHierarchique folderParent)
			: base(folderParent)
		{
		}

		public override Type TypeElements
		{
			get
			{
				return FiltreDynamique.TypeElements;
			}
		}

		private CVariableDynamique AssureVariableParent()
		{
			if (m_filtreDynamique == null)
				return null;
			foreach (CVariableDynamique variable in m_filtreDynamique.ListeVariables)
			{
				if (variable.Nom == c_strNomVariableFiltre && variable is CVariableDynamiqueSysteme)
				{
					if (FolderParent == null || FolderParent.TypeElements == null )
					{
						m_filtreDynamique.RemoveVariable(variable);
						return null;
					}
					else
					{
                        CVariableDynamiqueSystemeInstance varSys = variable as CVariableDynamiqueSystemeInstance;
                        varSys.SetInstance(FolderParent);
						return variable;
					}
					
				}
			}

			//La variable n'existe pas
			if (FolderParent != null && FolderParent.TypeElements != null)
			{
                CVariableDynamiqueSystemeInstance variable = new CVariableDynamiqueSystemeInstance();
                variable.SetInstance(FolderParent);
				variable.Nom = c_strNomVariableFiltre;
				m_filtreDynamique.AddVariable(variable);
				return variable;
			}
			return null;
		}

		//--------------------------------------------------
		public CFiltreDynamique FiltreDynamique
		{
			get
			{
				if (m_filtreDynamique == null)
				{
					m_filtreDynamique = new CFiltreDynamique();
				}
				/*if (FolderParent != null && FolderParent.TypeElements != null)
					m_filtreDynamique.TypeElements = FolderParent.TypeElements;*/
				AssureVariableParent();
				return m_filtreDynamique;
			}
			set
			{
				m_filtreDynamique = value;
			}
		}

		//-------------------------------------------
		private int GetNumVersion()
		{
			return 0;
		}

		//-------------------------------------------
		public override sc2i.common.CResultAErreur Serialize(sc2i.common.C2iSerializer serializer)
		{
			int nVersion = GetNumVersion();
			CResultAErreur result = serializer.TraiteVersion(ref nVersion);
			if (!result)
				return result;
			result = base.Serialize(serializer);
			if ( !result )
				return result;
			result = serializer.TraiteObject<CFiltreDynamique>(ref m_filtreDynamique);
			return result;
		}

		//-------------------------------------------
		public override object[] GetObjets(CNodeConsultationHierarchique nodeParent, CContexteDonnee contexte)
		{
			try
			{
				if (m_filtreDynamique == null || m_filtreDynamique.TypeElements == null)
					return new object[0];
				CVariableDynamique variable = AssureVariableParent();
				if (variable != null)
					m_filtreDynamique.SetValeurChamp(variable, nodeParent);
				CResultAErreur result = m_filtreDynamique.GetFiltreData();
				if (!result)
					return new object[0];
				CListeObjetsDonnees lst = new CListeObjetsDonnees(contexte, m_filtreDynamique.TypeElements);
				lst.Filtre = (CFiltreData)result.Data;
				return (object[])lst.ToArray(typeof(object));
			}
			catch 
			{
			}
			return new object[0];
		}

        public override string FolderTypeName
        {
            get { return I.T("Filter|20058"); }
        }

		
	}
}
