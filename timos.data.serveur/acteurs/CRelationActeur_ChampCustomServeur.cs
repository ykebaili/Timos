using System;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using sc2i.data.dynamic;
using timos.acteurs;
using sc2i.data.dynamic.loader;

namespace timos.acteurs.serveur
{
	/// <summary>
	/// Description résumée de CRelationActeur_ChampCustomServeur.
	/// </summary>
	public class CRelationActeur_ChampCustomServeur : CRelationElementAChamp_ChampCustomServeur
	{
		//-------------------------------------------------------------------
#if PDA
		public CRelationActeur_ChampCustomServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationActeur_ChampCustomServeur( int nIdSession )
			:base(nIdSession)
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CRelationActeur_ChampCustom.c_nomTable;
		}
		
		//-------------------------------------------------------------------
		public override Type GetTypeObjets()
		{
			return typeof(CRelationActeur_ChampCustom);
		}
		//-------------------------------------------------------------------
	}
}
