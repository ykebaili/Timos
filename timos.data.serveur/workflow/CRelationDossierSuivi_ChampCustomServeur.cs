using System;

using sc2i.common;
using sc2i.data;
using sc2i.data.serveur;
using sc2i.data.dynamic;
using sc2i.data.dynamic.loader;

namespace sc2i.workflow.serveur
{
	/// <summary>
	/// Description résumée de Class1.
	/// </summary>
	public class CRelationDossierSuivi_ChampCustomServeur : CRelationElementAChamp_ChampCustomServeur
	{
		/// //////////////////////////////////////////////////
#if PDA
		public CRelationDossierSuivi_ChampCustomServeur()
			:base ()
		{
			
		}
#endif
		/// //////////////////////////////////////////////////
		public CRelationDossierSuivi_ChampCustomServeur( int nIdSession )
			:base ( nIdSession )
		{
			
		}

		//////////////////////////////////////////////////////////////////////
		public override string GetNomTable()
		{
			return CRelationDossierSuivi_ChampCustom.c_nomTable;
		}

		//////////////////////////////////////////////////////////////////////
		public override Type GetTypeObjets()
		{
			return typeof(CRelationDossierSuivi_ChampCustom);
		}

	}
}
