using System;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using sc2i.data.dynamic;
using sc2i.data.dynamic.loader;
using timos.acteurs;
using timos.data.equipement.consommables;

namespace timos.data
{
	/// <summary>
	/// Description résumée de CRelationTypeConsommable_ChampCustomServeur.
	/// </summary>
	public class CRelationTypeConsommable_ChampCustomServeur : CRelationDefinisseurChamp_ChampCustomServeur
	{
		//-------------------------------------------------------------------
#if PDA
		public CRelationTypeConsommable_ChampCustomServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationTypeConsommable_ChampCustomServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CRelationTypeConsommable_ChampCustom.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override Type GetTypeObjets()
		{
			return typeof(CRelationTypeConsommable_ChampCustom);
		}
		//-------------------------------------------------------------------
	}
}
