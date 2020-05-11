using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using sc2i.common;
using System.IO;
using System.Collections;
using System.Drawing;


namespace HelpExtender
{
	public class CMenuItem : I2iSerializable
	{
		public CMenuItem( CMenuItem menuParent)
		{
			Initialiser();
			m_menuParent = menuParent;
		}
		public CMenuItem(CMenuItem menuParent, string nom)
		{
			Initialiser();
			m_menuParent = menuParent;
			m_strID = Guid.NewGuid().ToString();
			m_strNom = nom;
		}

		private string m_strID;
		private string m_strDescrip;
		private string m_strNom;
		private string m_strHelpId;
		private CMenuItem m_menuParent;
		private CHelpData m_help;

		//Liste des menus fils, triée par position
		private List<CMenuItem> m_listeMenusItems = new List<CMenuItem>();
		//-----------------------------------
		public string ID
		{
			get
			{
				return m_strID;
			}
		}

		//-----------------------------------
		public string Description
		{
			get
			{
				return m_strDescrip;
			}
			set
			{
				m_strDescrip = value;
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
		public CMenuItem MenuParent
		{
			get
			{
				return m_menuParent;
			}
			set
			{
				m_menuParent = value;
			}
		}

		//-----------------------------------
		public CHelpData Help
		{
			get
			{
				if (m_help == null && m_strHelpId != "")
				{
					m_help = CHelpData.GetHelp(m_strID);
					if (m_help == null)
						m_strHelpId = "";
				}
				return m_help;
			}
			set
			{
				m_help = value;
				if (value != null)
					m_strHelpId = m_help.HelpKey;
				else
					m_strHelpId = "";
			}
		}

		private void Initialiser()
		{
			m_strNom = "";
			m_strDescrip = "";
			m_strID = "";
			m_strHelpId = "";
			m_help = null;
			m_menuParent = null;
		}

		private int GetNumVersion()
		{
			return 0;
		}

		public CResultAErreur Serialize(C2iSerializer serializer)
		{
			int nVersion = GetNumVersion();
			CResultAErreur result = serializer.TraiteVersion(ref nVersion);
			if (!result)
				return result;
			serializer.TraiteString(ref m_strID);
			serializer.TraiteString(ref m_strNom);
			serializer.TraiteString(ref m_strDescrip);
			serializer.TraiteString(ref m_strHelpId);
			ArrayList lst = new ArrayList ( m_listeMenusItems );
			result = serializer.TraiteArrayListOf2iSerializable ( lst, this );
			if ( !result )
				return result;
			if ( serializer.Mode == ModeSerialisation.Lecture )
			{
				m_listeMenusItems.Clear();
				foreach (CMenuItem item in lst)
					m_listeMenusItems.Add(item);
			}
			return result;
		}

		//-----------------------------------------
		public void AddItem(CMenuItem item)
		{
			m_listeMenusItems.Add(item);
		}

		//-----------------------------------------
		public void RemoveItem(CMenuItem item)
		{
			m_listeMenusItems.Remove(item);
		}

		//-----------------------------------------
		public CMenuItem[] Items
		{
			get
			{
				return m_listeMenusItems.ToArray();
			}
		}

		/// <summary>
		/// Retourne vrai si l'item a pu être monté
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public bool MonterFils(CMenuItem item)
		{
			int nIndex = m_listeMenusItems.IndexOf(item);
			if (nIndex >= 1)
			{
				m_listeMenusItems.Remove(item);
				m_listeMenusItems.Insert ( nIndex - 1, item );
				return true;
			}
			return false;
		}


		/// <summary>
		/// Retourne faux si l'item a pu être descendu
		/// </summary>
		/// <param name="item"></param>
		public bool DescendreFils(CMenuItem item)
		{
			int nIndex = m_listeMenusItems.IndexOf ( item );
			if ( nIndex >= 0 && nIndex < m_listeMenusItems.Count -1 )
			{
				m_listeMenusItems.Remove(item);
				m_listeMenusItems.Insert(nIndex + 1, item);
				return true;
			}
			return false;
		}
	}
}
