using System;
using System.Collections.Generic;
using System.Text;

using sc2i.data.dynamic;
using sc2i.common;
using tiag.client;
using sc2i.data;

namespace timos.data.tiag
{
	class CChampTiagForCustomEntite : IChampTiag
	{
		private string m_strNomTiag;
		private int m_nIdChampCustom = -1;
		private Type m_type;

		public CChampTiagForCustomEntite(CChampCustom champ)
		{
			m_nIdChampCustom = champ.Id;
			m_strNomTiag = champ.Nom+"_Id";
			m_type = typeof(int);
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
			if (objet != null && objet is IObjetDonneeAChamps)
			{
				CObjetDonneeAIdNumerique retour = (CObjetDonneeAIdNumerique)CUtilElementAChamps.GetValeurChamp((IObjetDonneeAChamps)objet, m_nIdChampCustom);
				if (retour == null)
					return DBNull.Value;
				return retour.Id;
			}
			return null;
		}

		//---------------------------------------------------------------------
		public void SetValeur(object objet, object valeur)
		{
			if (objet != null && objet is IObjetDonneeAChamps)
			{
				if ( valeur is int )
				{
					if ( (int)valeur >= 0 )
					{
						CContexteDonnee contexte = ((IObjetDonneeAChamps)objet).ContexteDonnee;
						CChampCustom champ = new CChampCustom (contexte);
						if ( champ.ReadIfExists ( IdChampCustom ) )
						{
							CObjetDonneeAIdNumerique objetDonne = (CObjetDonneeAIdNumerique)Activator.CreateInstance ( champ.TypeObjetDonnee, new object[]{contexte} );
							if ( objetDonne.ReadIfExists ( (int)valeur ) )
								CUtilElementAChamps.SetValeurChamp((IObjetDonneeAChamps)objet, m_nIdChampCustom, objetDonne);
							else
								throw new Exception(I.T("Object @1 @2 doesn't exist|515",
									DynamicClassAttribute.GetNomConvivial (champ.TypeObjetDonnee),
									valeur.ToString() ));
						}
					}
				}
				else
				{
					CUtilElementAChamps.SetValeurChamp ((IObjetDonneeAChamps)objet, m_nIdChampCustom, null );
				}
			}

		}

		//---------------------------------------------------------------------
		public Type Type
		{
			get { return m_type; }
		}

	}
}
