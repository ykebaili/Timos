using System;
using System.Collections.Generic;
using System.Text;

using sc2i.common;
namespace HelpExtender
{
	/// <summary>
	/// Contient l'indexation de toutes les pages d'aide disponibles
	/// C'est un mappage de la clé de chaque page d'aide, vers son index (numéro)
	/// </summary>
	public class CIndexationAide : I2iSerializable
	{
		#region :: Propriétés ::
		private CListeIndex m_listeIndex = new CListeIndex();
		private Dictionary < string, CIndexAide > m_dictionnaireIndex = new Dictionary<string,CIndexAide>();
		private int m_nIndexProchainFichier = 0;

		#endregion

		#region ~~ Méthodes ~~
		//---------------------------------------
		private int GetNumVersion()
		{
			return 0;
		}

		//---------------------------------------
		public CResultAErreur Serialize(C2iSerializer serializer)
		{
			int nVersion = GetNumVersion();
			CResultAErreur result = serializer.TraiteVersion(ref nVersion);
			if (!result)
				return result;

			serializer.TraiteInt(ref m_nIndexProchainFichier);

			result = m_listeIndex.Serialize ( serializer );
			if ( !result )
				return result;

			if ( serializer.Mode == ModeSerialisation.Lecture )
			{
				RecreeDictionnaire();
			}

			return result;
		}

		//---------------------------------------
		private void RecreeDictionnaire()
		{
			m_dictionnaireIndex.Clear();
			foreach ( CIndexAide index in m_listeIndex )
				m_dictionnaireIndex.Add ( index.Cle, index );
		}

		//---------------------------------------
		public CIndexAide GetIndex ( string strCle, bool bCreateSiInexistant )
		{
			if ( m_dictionnaireIndex.ContainsKey ( strCle.ToUpper() ) )
				return m_dictionnaireIndex[strCle.ToUpper()];
			if ( bCreateSiInexistant )
			{
				CIndexAide index = new CIndexAide ( strCle.ToUpper(), m_nIndexProchainFichier++ );
				m_listeIndex.Add ( index );
				m_dictionnaireIndex.Add ( index.Cle, index );
				return index;
			}
			return null;
		}

		//---------------------------------------
		public CIndexAide CreateIndexForRessource( string strPrefixe)
		{
			int nIndex = m_nIndexProchainFichier++;
			CIndexAide index = new CIndexAide(
				(strPrefixe != null && strPrefixe.Length > 0?strPrefixe+"/":"")
				+"RES" + nIndex.ToString(), nIndex);
			m_listeIndex.Add(index);
			m_dictionnaireIndex.Add(index.Cle, index);
			return index;
		}
		#endregion

		#region >> Assesseurs <<
		public CIndexAide[] IndexsAide
		{
			get
			{
				return m_listeIndex.ToArray();
			}
		}
		#endregion
	}

	
}
