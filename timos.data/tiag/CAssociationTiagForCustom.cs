using System;
using System.Collections.Generic;
using System.Text;

using tiag.client;
using sc2i.data.dynamic;
using sc2i.data;
using sc2i.common;

namespace timos.data.tiag
{
	class CAssociationTiagForCustom : IAssociationTiag
	{
		private List<IChampTiag> m_lstChampsFils = new List<IChampTiag>();
		private Type m_typeParent = null;
		private string m_strNom = "";
        private int m_nIdChampCustom = -1;

		public CAssociationTiagForCustom(Type typeParent,
			IChampTiag[] champs,
			string strNom,
			int nIdChampCustom)
		{
			m_typeParent = typeParent;
			m_lstChampsFils = new List<IChampTiag>(champs);
			m_strNom = strNom;
            m_nIdChampCustom = nIdChampCustom;
		}

		//-----------------------------------
		public List<IChampTiag> Champs
		{
			get
			{
				return m_lstChampsFils;
			}
		}

		//-----------------------------------
		public string Nom
		{
			get
			{
				return m_strNom;
			}
			set
			{
				m_strNom = value;
			}
		}

		//-----------------------------------
		public Type TypeParent
		{
			get
			{
				return m_typeParent;
			}
			set
			{
				m_typeParent = value;
			}
		}

		//-----------------------------------
		public int IdChampCustom
		{
			get
			{
                return m_nIdChampCustom;
			}
			set
			{
                m_nIdChampCustom = value;
			}
		}

		//-----------------------------------
		public object GetValeur(object element)
		{
			if (element != null && element is IObjetDonneeAChamps)
                return ((IObjetDonneeAChamps)element).GetValeurChamp(m_nIdChampCustom);
			return null;
		}

		//--------------------------------------------------
		public void SetValeur(object element, object valeur)
		{
			if (element != null && element is IObjetDonneeAChamps)
                ((IObjetDonneeAChamps)element).SetValeurChamp(m_nIdChampCustom, valeur);
		}

		//--------------------------------------------------------------------
		public void SetValeursCles(object element, object[] lstCles)
		{
			if (element == null)
				return;
			if (Champs.Count == 1)
				Champs[0].SetValeur(element, lstCles[0]);
			return;
		}
	}
}
