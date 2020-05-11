using System;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using sc2i.data.dynamic;
using timos.securite;
using sc2i.data.dynamic.loader;

namespace timos.data.serveur
{
	/// <summary>
	/// Description résumée de CRelationSite_ChampCustomServeur.
	/// </summary>
	public class CRelationProjet_ChampCustomServeur : CRelationElementAChamp_ChampCustomServeur
	{
		//-------------------------------------------------------------------
#if PDA
		public CRelationEO_ChampCustomServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationProjet_ChampCustomServeur(int nIdSession)
			:base(nIdSession)
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CRelationProjet_ChampCustom.c_nomTable;
		}
		
		//-------------------------------------------------------------------
		public override Type GetTypeObjets()
		{
			return typeof(CRelationProjet_ChampCustom);
		}
		//-------------------------------------------------------------------
	}
}
