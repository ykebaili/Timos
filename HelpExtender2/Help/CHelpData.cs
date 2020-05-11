using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using sc2i.common;
using System.IO;
using System.Collections;
using System.Drawing;
using sc2i.win32.common;


namespace HelpExtender
{
	public class CHelpData : I2iSerializable
	{
		#region :[ Propriétés ]:
		private static ISourceAide m_sourceAide = null;
		private static Control m_ctrl = null;

		#endregion
		#region >[ Assesseurs ]<
		public static ISourceAide SourceAide
		{
			get
			{
				return m_sourceAide;
			}
		}
		public static Control FenetreActive
		{
			get
			{
				return m_ctrl;
			}
			set
			{
				//m_sourceAide.Referencement.Referencer(value);
				//m_sourceAide.SaveReferencement();
				m_ctrl = value;
			}
		}
		#endregion
		#region ~[ Méthodes ]~
		//------------------------------------------------------
		private static string GetCleDeControle(Control ctrl)
		{
			string strVal = "";
			if (ctrl is CtrlPartiel)
				strVal += ((CtrlPartiel)ctrl).Type.ToString();
			else
				strVal += ctrl.GetType().ToString();
			strVal += "_" + ctrl.Name;
			return strVal;
		}

		public static string GetCle(Control ctrl, string strContexte)
		{
			string strVal = GetCleDeControle(ctrl);
			ctrl = ctrl.Parent;
			while (ctrl != null)
			{
				strVal = GetCleDeControle(ctrl) + "_" + strVal;
				ctrl = ctrl.Parent;
			}
			strVal += "_" + strContexte;
			string strInterdits = "&é\"'(-è_çà)=/\\?*";
			foreach (char c in strInterdits)
			{
				strVal = strVal.Replace(c, '_');
			}
			return strVal;
		}
		public static string GetCle(Type t, string strContexte)
		{
			string strVal = t.ToString();
			return strVal;
		}
		public static string GetCle(string strContexte)
		{
			return Guid.NewGuid().ToString();
		}


		public static CHelpData GetHelp(Control ctrl, string strContexte)
		{
			if (m_sourceAide == null)
				throw new Exception("Source d'aide non initialisée");
			CHelpData help = m_sourceAide.GetHelp(ctrl, strContexte);
			if (help == null)
				help = new CHelpData(ctrl, strContexte);
			return help;
		}
		public static CHelpData GetHelp(Type type, string strContexte)
		{
			if (m_sourceAide == null)
				throw new Exception("Source d'aide non initialisée");
			CHelpData help = m_sourceAide.GetHelp(type, strContexte);
			if (help == null)
				help = new CHelpData(type, strContexte);
			return help;
		}
		public static CHelpData GetHelp(string strCle, string strContexte)
		{
			if (m_sourceAide == null)
				throw new Exception("Source d'aide non initialisée");
			CHelpData help = m_sourceAide.GetHelp(strCle, strContexte);
			if (help == null)
				help = new CHelpData(strContexte);
			return help;
		}
		public static CHelpData GetHelp(string strCle)
		{
			if (m_sourceAide == null)
				throw new Exception("Source d'aide non initialisée");
			CHelpData help = m_sourceAide.GetHelp(strCle);
			return help;
		}

		public static Control GetControl(CtrlPartiel refctrl)
		{
			if ( refctrl != null )
				return GetControl(refctrl, m_ctrl);
			return null;
		}
		private static Control GetControl(CtrlPartiel refctrl, Control ctrlpere)
		{
			if (ctrlpere == null)
				return null;

			if(IsControl(refctrl, ctrlpere))
				return ctrlpere;

			//Niveau suivant
			foreach(Control c in ctrlpere.Controls)
				if (IsControl(refctrl, c))
					return c;

			//Echec donc sous niveau
			foreach (Control c in ctrlpere.Controls)
				foreach (Control ssctrl in c.Controls)
				{ 
					Control result = GetControl(refctrl, ssctrl);
					if(result != null)
						return result;
				}

			return null;
		}
		public static bool IsControl(CtrlPartiel refctrl, Control ctrl)
		{
			if (refctrl.Name == ctrl.Name && refctrl.Type == ctrl.GetType())
			{
				Control parent = ctrl.Parent;

				//if (parent != null && parent.GetType() == typeof(MdiClient))
				//    parent = null;

				try
				{
					CtrlPartiel parentpartiel = (CtrlPartiel)refctrl.Parent;

					if (parent == null && parentpartiel == null)
						return true;
					else if ((parent != null && parentpartiel != null) && (IsControl(parentpartiel, parent)))
						return true;
					else
						return false;
				}
				catch
				{ 
				}
			}
			return false;
		}


		//------------------------------------------------------
		public static void SetSourceAide(ISourceAide source)
		{
			m_sourceAide = source;
		}


		#endregion

		#region ++ Constructeurs ++
		public CHelpData()
		{
			m_bSauvegarde = false;
		}
		// Document Indépendant
		public CHelpData(string strContexte)
		{
			m_bSauvegarde = false;
			m_typeliaison = ETypeLiaisonAide.Aucune;
			m_strContexte = strContexte;
			HelpKey = GetCle(strContexte);
		}
		// Document lié à un control
		public CHelpData(Control ctrl, string strContexte)
		{
			m_bSauvegarde = false;
			m_typeliaison = ETypeLiaisonAide.Control;

			if(ctrl is CtrlPartiel)
				m_control = new CtrlPartiel(GetControl((CtrlPartiel) ctrl));
			else
				m_control = new CtrlPartiel(ctrl);

			m_strContexte = strContexte;
			HelpKey = GetCle(ctrl, strContexte);
		}
		// Document lié à un Type
		public CHelpData(Type tp, string strContexte)
		{
			m_bSauvegarde = false;
			m_typeliaison = ETypeLiaisonAide.Type;

			m_type = tp;
			m_strContexte = strContexte;
			HelpKey = GetCle(tp, strContexte);
		}
		#endregion
		#region :: Propriétés ::
		private bool m_bSauvegarde;

		private string m_strKey = "";
		private string m_strContexte = "";
		private string m_strTitre = "";
		private string m_strNomCourt = "";

		//Contenu HTML
		private string m_strHTML = "<DIV>&nbsp;</DIV>";
		private ArrayList m_fichiersLiesserial = new ArrayList();
		private List<CHelpData.FichierLie> m_fichiersLies = new List<FichierLie>();
		private List<CHelpData.FichierLie> m_fichiersLiesASupp = new List<FichierLie>();


		//Liaison
		private ETypeLiaisonAide m_typeliaison = ETypeLiaisonAide.Aucune;
		private Type m_type = null;
		private CtrlPartiel m_control = null;
		private ArrayList m_controlserial = new ArrayList();

		//Visualisation
		private EVisualisationAide m_visuAide = EVisualisationAide.Window;
		private Size m_sizePopup = new Size(250, 19);

	
		//References voir Aussi
		private ArrayList m_listeVoirAussiSerial = new ArrayList();
		private List<CHelpData> m_listeVoirAussi = new List<CHelpData>();


		//References pour Groupe
		private ArrayList m_lstCtrlsLiees = new ArrayList();

		//langue
		private ELangueAide m_lng;
		#endregion
		#region >> Assesseurs <<
		public string Designation
		{
			get
			{
				string designation = "";
				switch (m_typeliaison)
				{
					case ETypeLiaisonAide.Control:
						designation = "Aide sur Control : " + m_control.Name + "(" + m_control.GetType().Name + ")";
						break;
					case ETypeLiaisonAide.Type:
						designation = "Aide sur Type : " + m_type.ToString();
						break;
					case ETypeLiaisonAide.Aucune:
					default:
						designation = "Aide générale : " + m_strTitre;
						break;
				}
				return designation;
			}
		}
		public string Titre
		{
			get
			{
				return m_strTitre;
			}
			set
			{
				m_strTitre = value;
			}
		}
		public string NomCourt
		{
			get
			{
				return m_strNomCourt;
			}
			set
			{
				m_strNomCourt = value;
			}
		}
		public string HelpKey
		{
			get
			{
				return m_strKey;
			}
			set
			{
				m_strKey = value;
			}
		}
		public string Contexte
		{
			get
			{
				return m_strContexte;
			}
			set
			{
				m_strContexte = value;
				if (Controle != null)
					HelpKey = GetCle(Controle, m_strContexte);
			}
		}


		public bool DejaEnregistre
		{
			get
			{
				return m_bSauvegarde;
			}

		}

		public ELangueAide Langue
		{
			get
			{
				return m_lng;
			}
			set
			{
				m_lng = value;
			}
		}

		//Contenu,brut, sans styles
		public string TexteHTML
		{
			get
			{
				return m_strHTML;
			}
			set
			{
				m_strHTML = value;
			}
		}

		/// <summary>
		/// Contenu HTML avec styles
		/// </summary>
		public string FullTexteHtml
		{
			get
			{
				string strText = "<HEAD>\r";
				strText += "<Style type=\"text/css\">\r";
				strText += SourceAide.HtmlStyles+"\r";
				strText += "</Style>\r";
				strText += "</HEAD>\r";
				strText += "<BODY>\r";
				strText += TexteHTML + "\r";
				strText += "</BODY>\r";
				return strText;
			}
		}
		//Fichiers
		public List<CHelpData.FichierLie> FichiersLies
		{
			get
			{
				return m_fichiersLies;
			}
			set
			{
				m_fichiersLies = value;
			}
		}
		/*public string CheminDossierRessource
		{
			get
			{
				return CHelpData.SourceAide.GetDirectoryOf(this);
			}
		}*/

		


		public bool HasData
		{
			get
			{
				return m_strHTML != "";
			}
		}

		//------------------------------------------------------
		public EVisualisationAide VisualisationAide
		{
			get
			{
				return m_visuAide;
			}
			set
			{
				m_visuAide = value;
			}
		}
		public Size SizePopup
		{
			get
			{
				return m_sizePopup;
			}
			set
			{
				m_sizePopup = value;
			}
		}


		//------------------------------------------------------
		public CtrlPartiel Controle
		{
			get
			{
				return m_control;
			}
			set
			{
				m_control = value;
				PreparerSerialisationControle();
				if (value != null)
					HelpKey = GetCle(m_control, Contexte);
			}
		}
		public Type TypeLie
		{
			get
			{
				if (m_type != null)
					return m_type;
				else if (TypeLiaison == ETypeLiaisonAide.Control && Controle != null)
					return Controle.Type;
				else
					return null;
			}
			set
			{
				m_type = value;
				if (value != null)
					HelpKey = GetCle(m_type, Contexte);
			}
		}
		public ETypeLiaisonAide TypeLiaison
		{
			get
			{
				return m_typeliaison;
			}
		}

		
		#endregion
		#region ~~ Méthodes ~~
		#region Voir Aussi
		public List<CHelpData> VoirAussiExplicite
		{
			get
			{
				return m_listeVoirAussi;
				
			}
			set
			{
				m_listeVoirAussi = value;
				
			}
		}

		public List<CHelpData> GetTousLesVoirAussi(bool modeCreation)
		{
			List<CHelpData> lst = new List<CHelpData>();

			switch (TypeLiaison)
			{
				case ETypeLiaisonAide.Control: lst.AddRange(GetVoirAussiPourControl(modeCreation)); break;
				case ETypeLiaisonAide.Type: lst.AddRange(GetVoirAussiPourType(modeCreation)); break;
				default:
				case ETypeLiaisonAide.Aucune: lst.AddRange(GetVoirAussiPourAucune(modeCreation)); break;
			}

			lst.AddRange(VoirAussiExplicite);
			return lst;
		}

		public List<CHelpData> GetVoirAussiPourControl(bool modeCreation)
		{
			List<CHelpData> lst = new List<CHelpData>();
			lst.AddRange(GetVoirAussiHeritages(modeCreation));
			lst.AddRange(GetVoirAussiInterfaces(modeCreation));
			lst.AddRange(GetVoirAussiAttributs(modeCreation));

			CHelpData hlptmp = GetVoirAussiType(modeCreation);
			if(hlptmp != null)
				lst.Add(hlptmp);

			lst.AddRange(GetVoirAussiParent(modeCreation));
			lst.AddRange(GetVoirAussiEnfants(modeCreation));
			return lst;
		}
		public List<CHelpData> GetVoirAussiPourType(bool modeCreation)
		{
			List<CHelpData> lst = new List<CHelpData>();
			lst.AddRange(GetVoirAussiHeritages(modeCreation));
			lst.AddRange(GetVoirAussiInterfaces(modeCreation));
			lst.AddRange(GetVoirAussiAttributs(modeCreation));

			return lst;
		}
		public List<CHelpData> GetVoirAussiPourAucune(bool modeCreation)
		{
			List<CHelpData> lst = new List<CHelpData>();
			lst.AddRange(GetVoirAussiLies(modeCreation));

			return lst;
		}

		public List<CHelpData> GetVoirAussiHeritages(bool modeCreation)
		{
			List<CHelpData> lst = new List<CHelpData>();

			Type t = GetTypeSelonLiaison();
			if (t == null)
				return lst;

			Type tparent = t.BaseType;
			while (tparent != null)
			{
				CHelpData hlp = GetVoirAussiType(tparent, modeCreation);
				if (hlp != null)
					lst.Add(hlp);
				tparent = tparent.BaseType;
			}

			return lst;
		}
		public List<CHelpData> GetVoirAussiInterfaces(bool modeCreation)
		{
			List<CHelpData> lst = new List<CHelpData>();

			Type t = GetTypeSelonLiaison();
			if (t == null)
				return lst;
			Type[] interfaces = t.GetInterfaces();
			foreach (Type tInterface in interfaces)
			{
				CHelpData hlp = GetVoirAussiType(tInterface, modeCreation);
				if (hlp != null)
					lst.Add(hlp);
			}

			return lst;
		}
		public List<CHelpData> GetVoirAussiAttributs(bool modeCreation)
		{
			List<CHelpData> lst = new List<CHelpData>();

			Type t = GetTypeSelonLiaison();
			if (t == null)
				return lst;

			object[] atts = t.GetCustomAttributes(false);
			List<Type> tps = new List<Type>();
			foreach (object att in atts)
				tps.Add(att.GetType());

			foreach (Type tatt in tps)
			{
				CHelpData hlp = GetVoirAussiType(tatt, modeCreation);
				if (hlp != null)
					lst.Add(hlp);
			}

			return lst;
		}

		private Type GetTypeSelonLiaison()
		{
			if (TypeLiaison == ETypeLiaisonAide.Type)
				return TypeLie;
			else if (TypeLiaison == ETypeLiaisonAide.Control)
				return Controle.Type;
			else
				return null;
		}
		public CHelpData GetVoirAussiType(bool modeCreation)
		{
			return GetVoirAussiType(TypeLie, modeCreation);
		}
		private CHelpData GetVoirAussiType(Type t, bool modeCreation)
		{
			if (t != null)
			{
				bool exist = CHelpData.SourceAide.HasHelp(t, "");

				if (exist)
					return CHelpData.SourceAide.GetHelp(t, "");
				else if (modeCreation && !exist)
					return new CHelpData(t, "");
			}
			return null;
		}

		public List<CHelpData> GetVoirAussiParent(bool modeCreation)
		{
			List<CHelpData> lst = new List<CHelpData>();
			CtrlPartiel ctrl = Controle;
			if (ctrl == null)
				return lst;
			ctrl = (CtrlPartiel)ctrl.Parent;

			while (ctrl != null)
			{
				bool exist = CHelpData.SourceAide.HasHelp(ctrl, "");

				if (exist)
					lst.Add(CHelpData.SourceAide.GetHelp(ctrl, ""));
				else if (modeCreation && !exist)
					lst.Add(new CHelpData(ctrl, ""));

				ctrl = (CtrlPartiel)ctrl.Parent;
			}

			return lst;
		}
		public List<CHelpData> GetVoirAussiEnfants(bool modeCreation)
		{
			List<CHelpData> lst = new List<CHelpData>();
			return lst;
		}
		public List<CHelpData> GetVoirAussiLies(bool modeCreation)
		{
			List<CHelpData> lst = new List<CHelpData>();
			List<CHelpData> hlps = CHelpData.SourceAide.GetHelps();

			foreach (CHelpData h in hlps)
				foreach (CHelpData h2 in h.VoirAussiExplicite)
					if (h2.Equals(this))
					{
						lst.Add(h);
						break;
					}

			return lst;
		}
		#endregion


		#region Serialisation
		private void PreparerSerialisationControle()
		{
			if (m_control != null)
			{
				List<string> serial = m_control.Serialise;
				m_controlserial = new ArrayList();
				foreach (string str in serial)
					m_controlserial.Add(str);
			}
		}

		#region Fichiers Liés
		private void PreparerSerialisationFichiersLies()
		{
			if (m_fichiersLies != null)
			{
				//Suppression des fichiers
				foreach (FichierLie f in m_fichiersLiesASupp)
					File.Delete(f.FilePath);

				//Serialisation des fichiers finaux
				foreach (FichierLie f in m_fichiersLies)
				{
					m_fichiersLiesserial = new ArrayList();
					m_fichiersLiesserial.Add(f.FilePath + "*" + f.Masquer.ToString());
				}
			}
		}
		private void ReconstruireFichiersLies()
		{
			m_fichiersLies = new List<FichierLie>();
			foreach (string lngFichier in m_fichiersLiesserial)
			{
				string[] strprop = lngFichier.Split('*');
				m_fichiersLies.Add(new FichierLie(strprop[0],bool.Parse(strprop[1])));
			}
		}

		#endregion

		private int GetNumVersion()
		{
			return 1;
		}
		public CResultAErreur Serialize(C2iSerializer serializer)
		{
			int nVersion = GetNumVersion();
			CResultAErreur result = serializer.TraiteVersion(ref nVersion);
			if (nVersion == 0)
			{
				result.EmpileErreur("Version 0 is obsolete");
				return result;
			}

			//Généralités
			serializer.TraiteString(ref m_strHTML);
			serializer.TraiteString(ref m_strTitre);
			serializer.TraiteString(ref m_strNomCourt);
			serializer.TraiteString(ref m_strKey);

			//Control
			I2iSerializable ctrl = (I2iSerializable)m_control;
			serializer.SerializeObjet(ref ctrl);
			m_control = (CtrlPartiel)ctrl;

			//References Help
			m_listeVoirAussiSerial = new ArrayList();
			foreach (CHelpData hlp in m_listeVoirAussi)
				m_listeVoirAussiSerial.Add(hlp.HelpKey);
			IList lst = new ArrayList(m_listeVoirAussiSerial);
			serializer.TraiteListeObjetsSimples(ref lst);
			m_listeVoirAussiSerial = new ArrayList(lst);
			m_listeVoirAussi = new List<CHelpData>();
			for (int i = 0; i < m_listeVoirAussiSerial.Count; i++)
				if (SourceAide.HasHelp((string)m_listeVoirAussiSerial[i]))
					m_listeVoirAussi.Add(GetHelp((string)m_listeVoirAussiSerial[i]));


			//Liaison
			int typeliaison = (int)TypeLiaison;
			serializer.TraiteInt(ref typeliaison);
			m_typeliaison = (ETypeLiaisonAide)typeliaison;

			//Visualisation
			int nType = (int)VisualisationAide;
			serializer.TraiteInt(ref nType);
			VisualisationAide = (EVisualisationAide)(nType);

			//Popup
			int nSX = SizePopup.Width;
			int nSY = SizePopup.Height;
			serializer.TraiteInt(ref nSX);
			serializer.TraiteInt(ref nSY);
			SizePopup = new Size(nSX, nSY);

			//Fichiers Liés
			PreparerSerialisationFichiersLies();
			lst = new ArrayList(m_fichiersLiesserial);
			serializer.TraiteListeObjetsSimples(ref lst);
			m_fichiersLiesserial = new ArrayList(lst);
			ReconstruireFichiersLies();

			//Type lié
			if(m_typeliaison == ETypeLiaisonAide.Type)
				serializer.TraiteType(ref m_type);

			m_bSauvegarde = true;

			return result;
		}
		public CResultAErreur Save()
		{
			if (m_sourceAide == null)
				throw new Exception("Source d'aide non initialisée");
			return m_sourceAide.SaveHelp(this);
		}
		#endregion

		public bool AjouterFichier(FichierLie fichier)
		{
			/*string strPathDirectory = CheminDossierRessource;
			if (!Directory.Exists(strPathDirectory))
				Directory.CreateDirectory(strPathDirectory);

			if (fichier.DirectoryPath != strPathDirectory)
			{
				string strNewPath = strPathDirectory + "\\" + fichier.Nom + '.' + fichier.Extention;
				string strOldPath = fichier.FilePath;
				if (File.Exists(strNewPath))
					if (MessageBox.Show("Attention le fichier '" + fichier.Nom + "' existe déjà voulez vous le remplacer ?", "Alerte sauvegarde", MessageBoxButtons.YesNo) == DialogResult.No)
						return false;

				File.Copy(fichier.FilePath, strNewPath);
				fichier.FilePath = strNewPath;
			}

			m_fichiersLies.Add(fichier);*/
			return true;

		}
		public bool SupprimerFichier(FichierLie fichier)
		{
			if (fichier.TypeDeFichier == TypeFichierLie.Image && TexteHTML.ToLower().Contains("<img src=\"file:///" + fichier.FilePath.Replace('\\', '/').Replace(" ", "%20").ToLower() + "\">"))
				if (CFormAlerte.Afficher("Attention l'image que vous êtes sur le point de supprimer est liée à la documentation: Etes vous sur de vouloir la supprimer ?", EFormAlerteType.Question) == DialogResult.No)
					return false;

			m_fichiersLiesASupp.Add(fichier);
			m_fichiersLies.Remove(fichier);
			return true;
		}
		#endregion

		#region ** Evenements **
		//public event EventHandler ModificationListeFichier;
		//public event EventHandler ModificationListeVoirAussi;
		#endregion

		#region [] Classes d'encodage de Control []
		public class CtrlPartiel : Control, I2iSerializable
		{
			#region .. Enumeration ..
			public enum DirectionSerialisation
			{
				VersParents,
				VersEnfants,
				Origine
			}
			#endregion

			#region [[ Constantes ]]
			public const char separatorprop = '*';
			public const char separatorlevel = '.';

			#endregion

			#region :: Propriétés ::
			private DirectionSerialisation m_direction;
			private string m_strCoor = "";
			private int m_nPos = -1;
			private Type m_type;
			private List<CtrlPartiel> m_fils;
			private ArrayList m_filsserial;
			#endregion

			#region ++ Constructeurs ++
			public CtrlPartiel()
			{
				m_filsserial = new ArrayList();
				m_fils = new List<CtrlPartiel>();
			}
			public CtrlPartiel(Control c)
			{
				Initialiser(c, DirectionSerialisation.Origine);
			}
			public CtrlPartiel(Control c, DirectionSerialisation sens)
			{
				Initialiser(c, sens);
			}
			#endregion

			#region ~~ Méthodes ~~
			private void Initialiser(Control c, DirectionSerialisation sens)
			{
				m_filsserial = new ArrayList();
				m_fils = new List<CtrlPartiel>();

				Name = c.Name;
				m_direction = sens;
				Type t = null;
				if (c is CtrlPartiel)
					t = ((CtrlPartiel)c).Type;
				else
					t = c.GetType();
				m_type = t;

				//Création des enfants
				if (sens == DirectionSerialisation.Origine || sens == DirectionSerialisation.VersEnfants)
				{
					m_fils = new List<CtrlPartiel>();
					foreach (Control cfils in c.Controls)
					{
						//if (cfils.GetType() != typeof(MdiClient))
						//{
						CtrlPartiel f = new CtrlPartiel(cfils, DirectionSerialisation.VersEnfants);
						f.Parent = this;
						m_fils.Add(f);
						//}
					}
				}
				//Création des parents
				if (sens == DirectionSerialisation.Origine || sens == DirectionSerialisation.VersParents)
				{
					if (c.Parent != null)// && c.Parent.GetType() != typeof(MdiClient))
						Parent = new CtrlPartiel(c.Parent, DirectionSerialisation.VersParents);
				}
			}

			private void AjouterLesFils(CtrlPartiel pere, List<CtrlPartiel> enfants)
			{
				for (int i = 0; i < enfants.Count; i++)
				{
					if ((enfants[i].m_strCoor.Length == pere.m_strCoor.Length + 2) &&
						(enfants[i].m_strCoor.Substring(0,pere.m_strCoor.Length) == pere.m_strCoor))
					{
						CtrlPartiel filsdirect = enfants[i];
						AjouterLesFils(filsdirect, enfants);
						filsdirect.Parent = pere;
						pere.m_fils.Add(filsdirect);
					}
				}
			}
			private int GetNumVersion()
			{
				return 1;
			}

		
			private void ReconstruireFils(ArrayList lst)
			{
				m_fils = new List<CtrlPartiel>();
				foreach (CtrlPartiel itm in lst)
				{
					itm.Parent = this;
					m_fils.Add(itm);
				}
			}

			#region I2iSerializable Membres

			public CResultAErreur Serialize(C2iSerializer serializer)
			{
				int nVersion = GetNumVersion();
				CResultAErreur result = serializer.TraiteVersion(ref nVersion);
				if (!result)
					return result;

				string strName = Name;
				serializer.TraiteString(ref strName);
				Name = strName;

				int nSens = (int)m_direction;
				serializer.TraiteInt(ref nSens);
				m_direction = (DirectionSerialisation)nSens;

				serializer.TraiteType(ref m_type);

				//Fils 
				ArrayList lst = new ArrayList(m_fils);
				serializer.TraiteArrayListOf2iSerializable(lst);
				ReconstruireFils(lst);

				//Parent
				if (m_direction != DirectionSerialisation.VersEnfants)
				{
					I2iSerializable father = (I2iSerializable)Parent;
					serializer.SerializeObjet(ref father);
					Parent = (CtrlPartiel)father;
				}



				////Control
				//List<string> lstlignes = Serialise;
				//ArrayList lignes = new ArrayList();
				//foreach (string l in lstlignes)
				//    lignes.Add(l);

				//IList lst = new ArrayList(lignes);
				//serializer.TraiteArrayListOf2iSerializable(ref lst);
				//lignes = new ArrayList(lst);

				return result;

			}

			#endregion
			#endregion

			#region >> Assesseurs <<
			public string Coordonnee
			{
				get
				{
					return m_strCoor;
				}
			}
			public int Position
			{
				get
				{
					return m_nPos;
				}
			}
			public Type Type
			{
				get
				{
					return m_type;
				}
			}
			public List<CtrlPartiel> Fils
			{
				set
				{
					m_fils = value;
				}
				get
				{
					return m_fils;
				}
			}
			/// <summary>
			/// Serialisation du control : position.nom.type.coordonnee
			/// </summary>
			public List<string> Serialise
			{
				get
				{
					List<string> str = new List<string>();
					try
					{
						str.Add(m_nPos.ToString() + separatorprop + Name + separatorprop + m_type.AssemblyQualifiedName + separatorprop + m_strCoor);

						switch (m_direction)
						{
							case DirectionSerialisation.VersParents:
								if (Parent != null)
									str.AddRange(((CtrlPartiel)Parent).Serialise);
								break;
							case DirectionSerialisation.VersEnfants:
								foreach (CtrlPartiel c in m_fils)
									str.AddRange(c.Serialise);
								break;
							case DirectionSerialisation.Origine:
								if (Parent != null)
									str.AddRange(((CtrlPartiel)Parent).Serialise);
								foreach (CtrlPartiel c in m_fils)
									str.AddRange(c.Serialise);
								break;
							default:
								break;
						}
					}
					catch 
					{
					}
					return str;

				}
			}
			#endregion

		
		}
		#region Comparers
		/// <summary>
		/// Tri les contacts Phase du plus petit au plus grand
		/// </summary>
		internal class CtrlPartielPositionComparer : System.Collections.Generic.IComparer<CtrlPartiel>
		{
			#region ~[ Méthodes ]~
			public static void Trier(ref List<CtrlPartiel> lst)
			{
				CtrlPartielPositionComparer comparer = new CtrlPartielPositionComparer();
				lst.Sort(comparer);
			}
			#endregion
			#region ~~ Méthodes ~~
			public int Compare(CtrlPartiel x, CtrlPartiel y)
			{
				if (x.Position < y.Position)
					return -1;
				else if (x.Position == y.Position)
					return 0;
				else
					return 1;
			}
			#endregion
		}
		/// <summary>
		/// Tri les contacts Phase du plus petit au plus grand
		/// </summary>
		internal class CtrlPartielCoorComparer : System.Collections.Generic.IComparer<CtrlPartiel>
		{
			#region ~[ Méthodes ]~
			public static void Trier(ref List<CtrlPartiel> lst)
			{
				CtrlPartielCoorComparer comparer = new CtrlPartielCoorComparer();
				lst.Sort(comparer);
			}
			#endregion
			#region ~~ Méthodes ~~
			public int Compare(CtrlPartiel x, CtrlPartiel y)
			{
				if (x.Coordonnee.Length < y.Coordonnee.Length)
					return -1;
				else if (x.Coordonnee.Length == y.Coordonnee.Length)
				{
					string[] xlvs = x.Coordonnee.Split(CtrlPartiel.separatorlevel);
					string[] ylvs = y.Coordonnee.Split(CtrlPartiel.separatorlevel);
					if(xlvs.Length == 0 || xlvs.Length == 0)
						return 0;
					for (int i = 0; i < xlvs.Length; i++)
					{
						int xpos = int.Parse(xlvs[i]);
						int ypos = int.Parse(ylvs[i]);

						if (xpos < ypos)
							return -1;
						else if (xpos > ypos)
							return 1;
						else
							continue;
					}
					return 0;
				}
				else
					return 1;
			}
			#endregion
		}
		#endregion
		#endregion

		#region [] Classes de fichiers liés []
		public enum TypeFichierLie
		{
			Image,
			NonSupporte,
		}
		public class FichierLie
		{
			#region :: Proprietes ::
			private TypeFichierLie m_type;
			private string m_strPathDirectory;
			private string m_strFilePath;
			private string m_strExt;
			private string m_strNom;
			private bool m_bHide;
			#endregion

			#region ++ Constructeurs ++
			public FichierLie(string filepath)
			{
				Initialiser(filepath, false);
			}
			public FichierLie(string filepath, bool masquer)
			{
				Initialiser(filepath, masquer);
			}
			#endregion

			#region >> Assesseurs <<
			public TypeFichierLie TypeDeFichier
			{
				get
				{
					return m_type;
				}
			}
			public string DirectoryPath
			{
				get
				{
					return m_strPathDirectory;
				}
			}
			public string FilePath
			{
				get
				{
					return m_strFilePath;
				}
				set
				{
					m_strFilePath = value;
					m_strPathDirectory = GetDirectoryPath(m_strFilePath);
					m_strNom = GetNomFichier(m_strFilePath);
					m_strExt = GetExtention(m_strFilePath);
					m_type = GetTypeFichier(m_strExt);
				}
			}
			public bool Masquer
			{
				get
				{
					return m_bHide;
				}
				set
				{
					m_bHide = value;
				}
			}
			public string Extention
			{
				get
				{
					return m_strExt;
				}
			}
			public string Nom
			{
				get
				{
					return m_strNom;
				}
			}
			#endregion

			#region ~~ Méthodes ~~
			private void Initialiser(string filepath, bool masquer)
			{
				m_strFilePath = filepath;
				m_strPathDirectory = GetDirectoryPath(m_strFilePath);
				m_strNom = GetNomFichier(m_strFilePath);
				m_strExt = GetExtention(m_strFilePath);
				m_type = GetTypeFichier(m_strExt);
				m_bHide = masquer;
			}


			private TypeFichierLie GetTypeFichier(string ext)
			{
				if (ext == "bmp" || ext == "jpg" || ext == "png")
					return TypeFichierLie.Image;
				else
					return TypeFichierLie.NonSupporte;
			}
			public string GetExtention(string filepath)
			{
				return filepath.Substring(filepath.LastIndexOf('.') + 1);
			}
			public string GetNomFichier(string filepath)
			{
				int start = filepath.LastIndexOf('\\') + 1;
				int lng = filepath.LastIndexOf('.') - start;
				return filepath.Substring(start,lng);
			}
			public string GetDirectoryPath(string filepath)
			{
				return filepath.Substring(0,filepath.LastIndexOf('\\'));
			}
			#endregion
		}
		#endregion


	}

	#region >< Comparer ><
	/// <summary>
	/// Tri les contacts Phase du plus petit au plus grand
	/// </summary>
	public class CHelpDataNameComparer : System.Collections.Generic.IComparer<CHelpData>
	{
		#region ~[ Méthodes ]~
		public static void Trier(ref List<CHelpData> lst)
		{
			CHelpDataNameComparer comparer = new CHelpDataNameComparer();
			lst.Sort(comparer);
		}
		#endregion
		#region ~~ Méthodes ~~
		public int Compare(CHelpData x, CHelpData y)
		{
			int result = string.Compare(x.Titre, y.Titre, true);
			if(result == 0)
				result = string.Compare(x.NomCourt, y.NomCourt, true);
			return result;
		}
		#endregion
	}
	#endregion
}
