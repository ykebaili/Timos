using System;
using System.Collections.Generic;
using System.Text;

using sc2i.data.dynamic;
using tiag.client;

namespace timos.data.tiag
{
	class CChampTiagForCustom : IChampTiag
	{
		private string m_strNomTiag;
		private int m_nIdChampCustom = -1;
		private Type m_type;

		public CChampTiagForCustom(CChampCustom champ)
		{
			m_nIdChampCustom = champ.Id;
			m_strNomTiag = champ.Nom;
			m_type = champ.TypeDonnee.TypeDotNetNatif;
		}

		//---------------------------------------------------------------------
		public int IdChampCustom
		{
			get
			{
				return m_nIdChampCustom;
			}
		}

		//---------------------------------------------------------------------
		public string NomTiag
		{
			get
			{
				return m_strNomTiag;
			}
		}

		//---------------------------------------------------------------------
		public object GetValeur(object objet)
		{
			if ( objet != null && objet is IObjetDonneeAChamps )
				return CUtilElementAChamps.GetValeurChamp((IObjetDonneeAChamps)objet, m_nIdChampCustom);
			return null;
		}

		//---------------------------------------------------------------------
		public void SetValeur(object objet, object valeur)
		{
			if (objet != null && objet is IObjetDonneeAChamps)
				CUtilElementAChamps.SetValeurChamp((IObjetDonneeAChamps)objet, m_nIdChampCustom, valeur);
		}

		//---------------------------------------------------------------------
		public Type Type
		{
			get { return m_type; }
		}

	}
}
