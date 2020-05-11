using System;
using System.Text;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

using sc2i.data;
using sc2i.data.dynamic;
using sc2i.common;
using sc2i.workflow;
using sc2i.process;
using sc2i.custom;
using sc2i.documents;
using sc2i.data.serveur;

using timos.securite;
using timos.data;
using timos.acteurs;


namespace timos.serveur
{

	public class CLogsMAJStructureBase
	{
		private DateTime m_heureLancementMAJ;
		private List<CRapportOperationMAJ> m_lstRapports;

		public CLogsMAJStructureBase()
		{
			m_heureLancementMAJ = DateTime.Now;
			m_lstRapports = new List<CRapportOperationMAJ>();

		}
	}

	public class CRapportOperationMAJ
	{
		

	}


}
