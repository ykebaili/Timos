using System;
using System.Collections.Generic;
using System.Text;

using sc2i.common;
using sc2i.multitiers.client;

namespace timos.acteurs
{

	[Serializable]
	public class CDonneeNotificationMessageInstantane : IDonneeNotification
	{
		public const string c_droitEnvoiMessageInstantane = "TIMOS_MESSENGER";
		private int m_nIdEnvoyeur;
		private int m_nIdSessionEnvoyeur;

		//null pour tous les utilisateurs
		private CDbKey m_keyUtilisateurDestinataire;
		private string m_strMessage;

		public CDonneeNotificationMessageInstantane(
			int nIdSessionEnvoyeur,
			int nIdEnvoyeur,
			CDbKey keyUtilisateurDestinataire,
			string strMessage)
		{
			m_nIdSessionEnvoyeur = nIdSessionEnvoyeur;
			m_nIdEnvoyeur = nIdEnvoyeur;
            //TESTDBKEYOK
			m_keyUtilisateurDestinataire = keyUtilisateurDestinataire;
			m_strMessage = strMessage;
		}

		
		//------------------------------
		public int IdSessionEnvoyeur
		{
			get
			{
                //TESTDBKEYOK : erreur : renvoyait l'id de l'utilisateur
                return m_nIdSessionEnvoyeur;
			}
			set
			{
                m_nIdSessionEnvoyeur = value;
			}
		}

		//------------------------------
		public int PrioriteNotification
		{
			get { return 0; }
		}

		//------------------------------
		public int IdEnvoyeur
		{
			get
			{
				return m_nIdEnvoyeur;
			}
		}


		//------------------------------
		public CDbKey KeyUtilisateurDestinataire
		{
			get
			{
				return m_keyUtilisateurDestinataire;
			}
		}

		//------------------------------
		public string Message
		{
			get
			{
				return m_strMessage;
			}
		}
	}

	
}
