using System;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using sc2i.data.dynamic;
using sc2i.data.dynamic.loader;
using timos.acteurs;

namespace timos.acteurs.serveur
{
	/// <summary>
	/// Description résumée de CRelationGroupeActeur_ChampCustomServeur.
	/// </summary>
	public class CRelationGroupeActeur_ChampCustomServeur : CRelationDefinisseurChamp_ChampCustomServeur
	{
		//-------------------------------------------------------------------
#if PDA
		public CRelationGroupeActeur_ChampCustomServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationGroupeActeur_ChampCustomServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CRelationGroupeActeur_ChampCustom.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override Type GetTypeObjets()
		{
			return typeof(CRelationGroupeActeur_ChampCustom);
		}
		//-------------------------------------------------------------------
	}
}
