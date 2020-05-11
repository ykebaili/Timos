using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.IO;
using sc2i.common;
using System.Windows.Forms;
using System.Reflection;

namespace HelpExtender
{
	public class CSourceAideFichier : ISourceAide
	{
		#region [[ Constantes ]]

		private const string c_strFichierRefCtrls = "HelpCtrls.crf";
		private const string c_cleFichierRefCtrls = "TIMOS_HELP_CTRLS";

		private const string c_repertoireRessources = "Resources";


        private const string c_cleFichier = "TIMOS_HLP";
		private const string c_strFichiersStyle = "HelpStyles.tib";

		private const string c_strFichiersMenu = "HelpMenu.tib";
        private const string c_cleFichiersMenu = "TIMOS_HELP_MENU";

        public const string c_cleFichiersMenuItem = "TIMOS_HELP_MENU_ITEM";

		private const string c_strFichierIndex = "TimosHelp.ndx";
        private const string c_cleFichierIndex = "TIMOS_HELP_NDX";


		#endregion

		#region :: Propriétés ::
		private CIndexationAide m_index = new CIndexationAide();

		//Clé -> Aide
		private Hashtable m_tableAides = new Hashtable();

		private string m_strRepertoire = "C:\\HELP";

		private string m_strHtmlStyles = "";

		private CMenuItem m_menu = null;



		#endregion

		#region ++ Constructeurs ++
		//---------------------------------------------------
		public CSourceAideFichier(string strRepertoire)
		{
			m_strRepertoire = strRepertoire;

			if (File.Exists(RepertoireDeBase + c_strFichierIndex))
			{
				CSerializerObjetInFile.ReadFromFile(m_index, c_cleFichierIndex, RepertoireDeBase + c_strFichierIndex);
			}
			if (File.Exists(RepertoireDeBase + c_strFichiersMenu))
			{
				//CSerializerObjetInFile.ReadFromFile(m_menu, c_cleFichiersMenu, RepertoireDeBase + c_strFichiersMenu);

			}
		}
		#endregion

		#region ~~ Méthodes ~~

		#region Tests
		//-------------------------------------------
		public bool HasHelp(string strCle)
		{
			string strFichier = RepertoireDeBase + GetFileTitle(strCle);
			return File.Exists(strFichier);
		}
		//-------------------------------------------
		public bool HasHelp(Control ctrl, string strContexte)
		{
			return HasHelp(CHelpData.GetCle(ctrl, strContexte));
		}
		public bool HasHelp(Type tp, string strContexte)
		{
			return HasHelp(CHelpData.GetCle(tp, strContexte));
		}

		#endregion

		#region Chargement Help(s)
		public string GetDirectoryOf(CHelpData hlp)
		{
			string strFichier = GetFileTitle(hlp);
			string strPathDirectory = RepertoireDeBase + strFichier.Substring(0, strFichier.LastIndexOf('.'));
			if (!Directory.Exists(strPathDirectory))
				Directory.CreateDirectory(strPathDirectory);

			return strPathDirectory;
		}


		public CHelpData GetHelp(Type tp, string strContexte)
		{
			CHelpData help = GetHelp(CHelpData.GetCle(tp, strContexte));
			if (help != null)
			{
				help.TypeLie = tp;
				help.Contexte = strContexte;
			}
			return help;
		}
		public CHelpData GetHelp(Control ctrl, string strContexte)
		{
			CHelpData help = GetHelp(CHelpData.GetCle(ctrl, strContexte));
			//if (help != null)
			//{
			//    help.Controle =  ctrl;
			//    help.Contexte = strContexte;
			//}
			return help;
		}
		public CHelpData GetHelp(string strCle, string strContexte)
		{
			CHelpData help = GetHelp(CHelpData.GetCle(strContexte));
			if (help != null)
			{
				help.Contexte = strContexte;
			}
			return help;
		}

		public CHelpData GetHelp(string strCle)
		{
			CResultAErreur result = CResultAErreur.True;
			CHelpData help = null;
			if (m_tableAides.Contains(strCle))
			{

			    return (CHelpData)m_tableAides[strCle];
			}


			string strFile = RepertoireDeBase + GetFileTitle(strCle);
			if (!File.Exists(strFile))
				return null;


			help = new CHelpData();
			help.HelpKey = strCle;
			m_tableAides[strCle] = help;
			result = CSerializerObjetInFile.ReadFromFile(help, c_cleFichier, strFile);
			
			return help;
		}

		public List<CHelpData> GetHelps()
		{
			List<CHelpData> helps = new List<CHelpData>();
			foreach (CIndexAide index in m_index.IndexsAide)
			{
				CHelpData help = GetHelp(index.Cle);
				if (help != null)
				{
					helps.Add(help);
					m_tableAides[index.Cle] = help;
				}
			}
			return helps;
		}

		#endregion

		#region Fichiers
		private string GetFileTitle(int nIndex)
		{
			return "HLP_" + nIndex.ToString() + ".hlpdta";
		}
		private string GetFileTitle(string strCle)
		{
			CIndexAide index = m_index.GetIndex(strCle, true);
			return GetFileTitle(index.Index);
		}
		private string GetFileTitle(CHelpData help)
		{
			return GetFileTitle(help.HelpKey);
		}



		private string GetNomDossier(string pathHelpFile)
		{
			string[] parts = pathHelpFile.Split('\\');
			string nomfichier = parts[parts.Length - 1];

			string retour = "";
			for (int i = 0; i < (parts.Length - 1); i++)
				retour += parts[i] + "\\";

			string[] parts2 = nomfichier.Split('.');
			for (int i = 0; i < (parts2.Length - 1); i++)
				retour += parts2[i] + ".";

			return retour.Substring(0, retour.Length - 1);
		}

		#endregion

		#region Sauvegardes
		//---------------------------------------------------------
		public CResultAErreur SaveMenu()
		{
			string strFichier = RepertoireDeBase + c_strFichiersMenu;
			return CSerializerObjetInFile.SaveToFile(m_menu, c_cleFichiersMenu, strFichier);
		}

		//---------------------------------------------------------
		private void SaveFichierIndex()
		{
			string strFichier = RepertoireDeBase + c_strFichierIndex;

			CSerializerObjetInFile.SaveToFile(m_index, c_cleFichierIndex, strFichier);
		}


		//---------------------------------------------------------
		public CResultAErreur SaveHelp(CHelpData help)
		{
			CResultAErreur result = CResultAErreur.True;
			string strFileTitle = GetFileTitle(help); // >> Créé une instance au niveau de l'index
			if (!help.HasData)
			{
				try
				{
					if (File.Exists(RepertoireDeBase + strFileTitle))
					{
						File.Delete(RepertoireDeBase + strFileTitle);
						m_tableAides.Remove(help.HelpKey);
					}
				}
				catch
				{
				}
				return result;
			}


			//S'assure que le chemin du fichier existe
			string strFichier = RepertoireDeBase + strFileTitle;
			m_tableAides[help.HelpKey] = help;
			SaveFichierIndex();

			return CSerializerObjetInFile.SaveToFile(help, c_cleFichier, strFichier);

		}

		//---------------------------------------------------------
		public CResultAErreur DeleteHelp(CHelpData help)
		{
			CResultAErreur result = CResultAErreur.True;
			Directory.Delete(RepertoireDeBase + GetDirectoryOf(help));
			File.Delete(RepertoireDeBase + GetFileTitle(help));

			m_tableAides.Remove(help.HelpKey);

			return result;

		}
		#endregion

		#endregion

		#region >> Assesseurs <<
		public CMenuItem MenuRoot
		{
			get
			{
				if (m_menu == null)
				{
					m_menu = new CMenuItem(null);
					string strFichierMenu = RepertoireDeBase + c_strFichiersMenu;
					CSerializerObjetInFile.ReadFromFile(m_menu, c_cleFichiersMenu, strFichierMenu);

				}
				return m_menu;
			}
			set
			{
				m_menu = value;
			}
		}

		/// <summary>
		/// Répertoire de base du stockage de l'aide
		/// </summary>
		//-------------------------------------------
		public string RepertoireDeBase
		{
			get
			{
				if (m_strRepertoire[m_strRepertoire.Length - 1] != '\\')
					m_strRepertoire += "\\";
				return m_strRepertoire;
			}
		}

		//-------------------------------------------
		public string HtmlStyles
		{
			get
			{
				if (m_strHtmlStyles.Trim().Length != 0)
					return m_strHtmlStyles;
				if (File.Exists(RepertoireDeBase + c_strFichiersStyle))
				{
					try
					{
						StreamReader reader = new StreamReader(RepertoireDeBase + c_strFichiersStyle);
						string strLigne = reader.ReadLine();
						while (strLigne != null)
						{
							m_strHtmlStyles += strLigne + "\r\n";
							strLigne = reader.ReadLine();
						}
						reader.Close();
					}
					catch
					{
					}
				}
				return m_strHtmlStyles;				
			}
			set
			{
				m_strHtmlStyles = value;
				StreamWriter writer = new StreamWriter(RepertoireDeBase + c_strFichiersStyle );
				string[] strLignes = m_strHtmlStyles.Split('\r');
				for (int i = 0; i < strLignes.Length; i++)
				{
					writer.WriteLine(strLignes[i].Replace("\n",""));
				}
				writer.Close();
			}
		}
		#endregion

		//-------------------------------------------
		private string GetNomFichierRessource(CIndexAide index, bool bCreate)
		{
			if (index == null)
				return "";
			string strRepertoire = c_repertoireRessources;
			string strFichier = index.Cle;
			try
			{
				if ( index.Cle.IndexOf ('/') > 0 )
					//L'index contient un répertoire, création du répertoire
				{
					string[] strParts = index.Cle.Split('/');
					strRepertoire = strParts[0];
					strFichier = strParts[1];
				}
				if (!Directory.Exists(RepertoireDeBase + strRepertoire))
					if ( bCreate )
						Directory.CreateDirectory(RepertoireDeBase + strRepertoire);
				strRepertoire = RepertoireDeBase + strRepertoire + "\\";

			}
			catch
			{
				return "";
			}
			try
			{
				string strTitle = strFichier;
				return strRepertoire + strTitle;
			}
			catch
			{
			}
			return "";
		}

		//-------------------------------------------
		public CResultAErreur ReferenceFichier(string strFichierLocal, CHelpData helpUtilisant)
		{
			CResultAErreur result = CResultAErreur.True;
			CIndexAide index = m_index.CreateIndexForRessource( GetFileTitle ( helpUtilisant )+".RES" );
			string strFichier = GetNomFichierRessource(index, true);
			try
			{
				//Copie du fichier dans les ressource
				if (File.Exists(strFichier))
					File.Delete(strFichier);
				File.Copy(strFichierLocal, strFichier);
				result.Data = new CRessourceFichier(index.Cle, strFichier);
			}
			catch
			{
				result.EmpileErreur(I.T("Error while copying file|30056"));
			}
			return result;
		}

		//-------------------------------------------
		public CRessourceFichier GetRessourceFichier(string strCle)
		{
			CIndexAide index = m_index.GetIndex(strCle, false);
			string strFichier = GetNomFichierRessource(index, false);
			if (File.Exists(strFichier))
			{
				return new CRessourceFichier(strCle, strFichier);
			}
			return null;
		}

		//-------------------------------------------
		public void LibereRessourceFichierLocale(CRessourceFichier ressource)
		{
			//Ne fait rien, car les ressources locales sont les mêmes que les ressource de l'aide !
		}
	}


	
}
