using System;
using System.Collections;
using System.Collections.Generic;
using sc2i.common;
using sc2i.expression;



using sc2i.data.dynamic;
using sc2i.multitiers.client;
using sc2i.data;
using sc2i.process;
using sc2i.formulaire;

namespace sc2i.custom
{
	/// <summary>
	/// Description résumée de CActionSur2iLink.
	/// </summary>
	/// ////////////////////////////////////////////////////////////////
	public class CActionSur2iLinkExecuterProcess : CActionSur2iLink
	{
		int m_nIdProcessToExecute = -1;
		int m_nIdEvenementManuelToExecute = -1;
		bool m_bMasquerProgressProcess = false;


        List<CFormuleNommee> m_listeValeursParametres = new List<CFormuleNommee>();

		public CActionSur2iLinkExecuterProcess ()
			:base()
		{
		}

		/// ////////////////////////////////////////////////////////////////
		public override string ToString()
		{
			return I.T("Action|355");
		}

        //-------------------------------------------------------------------
        public override bool AutoriserEnEdition
        {
            get { return false; }
        }

		/// ////////////////////////////////////////////////////////////////
		private int GetNumVersion()
		{
			return 4;
			//2 : Ajout evenement manuel
			//3 : Ajout de MasquerProgressProcess
            //4 : Ajout des valeurs de paramètres
		}

		/// ////////////////////////////////////////////////////////////////
		public override CResultAErreur Serialize(C2iSerializer serializer)
		{
			int nVersion = GetNumVersion();
			CResultAErreur result = serializer.TraiteVersion ( ref nVersion );
			if ( result )
				result = base.Serialize ( serializer );
			if ( !result )
				return result;
			serializer.TraiteInt ( ref m_nIdProcessToExecute );
			if ( nVersion >= 2 )
				serializer.TraiteInt ( ref m_nIdEvenementManuelToExecute );
			if (nVersion >= 3)
				serializer.TraiteBool(ref m_bMasquerProgressProcess);
			else
				m_bMasquerProgressProcess = false;
            if (nVersion >= 4)
                serializer.TraiteListe<CFormuleNommee>(m_listeValeursParametres);
			return result;
		}

        /// ////////////////////////////////////////////////////////////////
        public CFormuleNommee[] FormulesPourParametres
        {
            get
            {
                return m_listeValeursParametres.ToArray();
            }
            set
            {
                m_listeValeursParametres.Clear();
                foreach (CFormuleNommee formule in value)
                {
                    if (formule.Formule != null)
                        m_listeValeursParametres.Add(formule);
                }
            }
        }

		/// ////////////////////////////////////////////////////////////////
		public bool MasquerProgressProcess
		{
			get
			{
				return m_bMasquerProgressProcess;
			}
			set
			{
				m_bMasquerProgressProcess = value;
			}
		}


		/// ////////////////////////////////////////////////////////////////
		public int IdProcessInDb
		{
			get
			{
				return m_nIdProcessToExecute;
			}
			set
			{
				m_nIdProcessToExecute = value;
				if ( value >= 0 )
					m_nIdEvenementManuelToExecute = -1;
			}
		}

		/// ////////////////////////////////////////////////////////////////
		public int IdEvenement
		{
			get
			{
				return m_nIdEvenementManuelToExecute;
			}
			set
			{
				m_nIdEvenementManuelToExecute = value;
				if ( value >= 0 )
					m_nIdProcessToExecute = -1;
			}
		}
	}

	/// ////////////////////////////////////////////////////////////////
	public class CActionSur2iLinkAfficherListe : CActionSur2iLink
	{
		public const string c_champElementSource = "Source element";

		CFiltreDynamique m_filtre = null;

        private int m_nIdFiltreAUtiliser = -1;
		private C2iExpression m_formuleContexte = null;
		private C2iExpression m_formuleTitreForm = null;

        private List<CAffectationsProprietes> m_listeAffectations = new List<CAffectationsProprietes>();
        private CActionSur2iLink m_actionSurDetail = null;

        private bool m_bBoutonSupprimer = true;
        private bool m_bBoutonAjouter = true;
        private bool m_bBoutonDetail = true;

        private List<CFormuleNommee> m_listeOptionsFiltreSélectionné = new List<CFormuleNommee>();
        

		/// ////////////////////////////////////////////////////////////////
		public CActionSur2iLinkAfficherListe()
			:base()
		{}

		/// ////////////////////////////////////////////////////////////////
		public override string ToString()
		{
			return I.T("List|350");
		}

        //-------------------------------------------------------------------
        public override bool AutoriserEnEdition
        {
            get { return false; }
        }

        public bool ShowBoutonDetail
        {
            get
            {
                return m_bBoutonDetail;
            }
            set
            {
                m_bBoutonDetail = value;
            }
        }

        public bool ShowBoutonAjouter
        {
            get
            {
                return m_bBoutonAjouter;
            }
            set
            {
                m_bBoutonAjouter = value;
            }
        }

        public bool ShowBoutonSupprimer
        {
            get
            {
                return m_bBoutonSupprimer;
            }
            set
            {
                m_bBoutonSupprimer = value;
            }
        }

        /// ////////////////////////////////////////////////////////////////
        public int IdFiltreDynamiqueAUtiliser
        {
            get
            {
                return m_nIdFiltreAUtiliser;
            }
            set
            {
                m_nIdFiltreAUtiliser = value;
            }
        }

        /// ////////////////////////////////////////////////////////////////
        public CFormuleNommee[] ValeursVariablesFiltre
        {
            get
            {
                return m_listeOptionsFiltreSélectionné.ToArray();
            }
            set
            {
                if (value != null)
                {
                    m_listeOptionsFiltreSélectionné.Clear();
                    m_listeOptionsFiltreSélectionné.AddRange(value);
                }
            }
        }




		/// ////////////////////////////////////////////////////////////////
		public static IVariableDynamique AssureVariableElementCible ( CFiltreDynamique filtre, CObjetPourSousProprietes objetPourSousProprietes )
		{
            if (objetPourSousProprietes.ElementAVariableInstance as IElementAVariablesDynamiquesAvecContexteDonnee == null)
            {
                foreach (IVariableDynamique variable in filtre.ListeVariables)
                    if (variable.Nom == c_champElementSource)
                        return variable;
                CVariableDynamiqueSysteme newVariable = new CVariableDynamiqueSysteme(filtre);
                newVariable.Nom = c_champElementSource;
                newVariable.SetTypeDonnee(new sc2i.expression.CTypeResultatExpression(objetPourSousProprietes.TypeAnalyse, false));
                filtre.AddVariable(newVariable);
                return newVariable;
            }
            else
            {
                filtre.ElementAVariablesExterne = null;
                while (filtre.ListeVariables.Length > 0)
                    filtre.RemoveVariable(filtre.ListeVariables[0]);
                filtre.ElementAVariablesExterne = objetPourSousProprietes.ElementAVariableInstance as IElementAVariablesDynamiquesAvecContexteDonnee;
                return null;
            }
		}

		/// ////////////////////////////////////////////////////////////////
		public C2iExpression FormuleContexte
		{
			get
			{
				return m_formuleContexte;
			}
			set
			{
				m_formuleContexte = value;
			}
		}

        /// ////////////////////////////////////////////////////////////////
        public CActionSur2iLink ActionSurDetail
        {
            get
            {
                return m_actionSurDetail;
            }
            set
            {
                m_actionSurDetail = value;
            }
        }

		/// ////////////////////////////////////////////////////////////////
		public C2iExpression FormuleTitre
		{
			get
			{
				return m_formuleTitreForm;
			}
			set
			{
				m_formuleTitreForm = value;
			}
		}

		/// ////////////////////////////////////////////////////////////////
		private int GetNumVersion()
		{
			return 6;
			//1 : Ajout de Titre et contexte 
            //2 : ajout des allocations sur création
            //3 : ajout de action sur détail
            //4 : ajout de option pour boutons visilbe
            //5 : ajout de id filtre à utiliser
            //6 : ajout option de filtre à utiliser (valeurs de variables)
		}

		/// ////////////////////////////////////////////////////////////////
		public override CResultAErreur Serialize(C2iSerializer serializer)
		{
			int nVersion = GetNumVersion();
			CResultAErreur result = serializer.TraiteVersion ( ref nVersion );
			if ( result )
				result = base.Serialize ( serializer );
			if ( !result )
				return result;
			if ( nVersion >= 1 )
			{
				string strExp = C2iExpression.GetPseudoCode ( m_formuleContexte );
				serializer.TraiteString ( ref strExp );
				m_formuleContexte = C2iExpression.FromPseudoCode(strExp);
				
				strExp = C2iExpression.GetPseudoCode ( m_formuleTitreForm );
				serializer.TraiteString ( ref strExp );
				m_formuleTitreForm =  C2iExpression.FromPseudoCode ( strExp );
			}
			I2iSerializable objet = m_filtre;
			result = serializer.TraiteObject ( ref objet );
			m_filtre = (CFiltreDynamique)objet;

            if (result && nVersion >= 2)
            {
                result = serializer.TraiteListe<CAffectationsProprietes>(m_listeAffectations);
            }
            if (result && nVersion >= 3)
            {
                result = serializer.TraiteObject<CActionSur2iLink>(ref m_actionSurDetail);
            }
            else
                m_actionSurDetail = null;
            if (nVersion >= 4)
            {
                serializer.TraiteBool(ref m_bBoutonAjouter);
                serializer.TraiteBool(ref m_bBoutonDetail);
                serializer.TraiteBool(ref m_bBoutonSupprimer);
            }
            if (nVersion >= 5)
            {
                serializer.TraiteInt(ref m_nIdFiltreAUtiliser);
            }
            else
                m_nIdFiltreAUtiliser = -1;

            if (nVersion >= 6)
            {
                result = serializer.TraiteListe<CFormuleNommee>(m_listeOptionsFiltreSélectionné);
                if (!result)
                    return result;
            }

			
			return result;
		}

        /// ////////////////////////////////////////////////////////////////
        public IEnumerable<CAffectationsProprietes> Affectations
        {
            get
            {
                return m_listeAffectations.AsReadOnly();
            }
            set
            {
                m_listeAffectations.Clear();
                if (value != null)
                    m_listeAffectations.AddRange(value);
            }
        }

		/// ////////////////////////////////////////////////////////////////
		public CFiltreDynamique Filtre
		{
			get
			{
				return m_filtre;
			}
			set
			{
				m_filtre = value;
			}
		}
	}


    ////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Action qui permet d'afficher un Formulaire standard de l'application
    /// Comme par exemple les menu Patrimoine, Configuration, Maintenance, Visualisation d'un Etat Crystal...
    /// </summary>
	public class CActionSur2iLinkAfficherFormulaire : CActionSur2iLink
	{
		Type m_typeFormulaire = null;
		private string m_strContexteForm = "";
        private Dictionary<string, C2iExpression> m_dicNomParametreExpression = new Dictionary<string, C2iExpression>();
        private int m_nNombreDeParametres = 0;

		
		public CActionSur2iLinkAfficherFormulaire ()
			:base()
		{
		}

		/// ////////////////////////////////////////////////////////////////
		public override string ToString()
		{
			return I.T("Standard form|352");
		}

        //-------------------------------------------------------------------
        public override bool AutoriserEnEdition
        {
            get { return false; }
        }

		//--------------------------------------------------
		public string ContexteForm
		{
			get
			{
				return (this.m_strContexteForm);
			}
			set
			{
				this.m_strContexteForm = value;
			}
		}

        //--------------------------------------------------
        public Dictionary<string, C2iExpression> Parametres
        {
            get
            {
                return m_dicNomParametreExpression;
            }
            set
            {
                m_dicNomParametreExpression = value;
            }
        }



		/// ////////////////////////////////////////////////////////////////
		private int GetNumVersion()
		{
			return 3;
            // 2 : Contexte de Formulaire
            // 3 : Ajout des paramètres du Formulaire standard
		}

		/// ////////////////////////////////////////////////////////////////
		public override CResultAErreur Serialize(C2iSerializer serializer)
		{
			int nVersion = GetNumVersion();
			CResultAErreur result = serializer.TraiteVersion ( ref nVersion );
			if ( result )
				result = base.Serialize ( serializer );
			if ( !result )
				return result;

			bool bHasFormulaire = m_typeFormulaire != null;
			if ( nVersion < 1 )
				bHasFormulaire = true;
			else
				serializer.TraiteBool ( ref bHasFormulaire );
			if ( bHasFormulaire )
				serializer.TraiteType ( ref m_typeFormulaire );
			else
				m_typeFormulaire = null;
			if ( nVersion >= 2 )
				serializer.TraiteString ( ref m_strContexteForm );

            // Traitement des paramètres du Formulaire
            if (nVersion >= 3)
            {      
                // Sérialise le nombre de paramètres
                m_nNombreDeParametres = m_dicNomParametreExpression.Count;
                serializer.TraiteInt(ref m_nNombreDeParametres);

                switch (serializer.Mode)
                {
                    case ModeSerialisation.Ecriture:

                        // Sérialise les Noms et Expressions des paramètres
                        foreach (KeyValuePair<string, C2iExpression> coupleNomExpression in m_dicNomParametreExpression)
                        {
                            // Ecrit le Nom du paramètre
                            string strNom = coupleNomExpression.Key;
                            serializer.TraiteString(ref strNom);
                            // Ecrit la Formule qui renvoie la valeur du paramètre
                            I2iSerializable expression = (I2iSerializable) coupleNomExpression.Value;
                            result = serializer.TraiteObject(ref expression, null);
                            if (!result)
                                return result;
                        }
                        break;
                    case ModeSerialisation.Lecture:
                        // Lit les couples Nom-Expression
                        for (int i = 0; i < m_nNombreDeParametres; i++)
                        {
                            // Lit le nom
                            string strNom = "";
                            serializer.TraiteString(ref strNom);
                            // Lit l'expression (formule)
                            I2iSerializable expression = null;
                            serializer.TraiteObject(ref expression, null);
                            if (!result)
                                return result;
                            m_dicNomParametreExpression[strNom] = (C2iExpression) expression;
                        }
                        break;
                    default:
                        break;
                }
            }

			return result;
		}


        //-------------------------------------------------------------------
        /// <summary>
        /// Evalue l'expression (la formule) de chaque paramètre
        /// </summary>
        /// <param name="element"> L'Element source à partir duquel l'action d'affichage du Formulaire est executée </param>
        /// <returns>Une collection de couples Nom-Valeur</returns>
        public CResultAErreur GetValeursParametres(object objetSource)
        {
            CResultAErreur result = CResultAErreur.True;
            Dictionary<string, object> dicNomParametreValeur = new Dictionary<string, object>();
            // Créé un context d'évaluation des expressions
            CContexteEvaluationExpression contexteEval = new CContexteEvaluationExpression(objetSource);
            string strNom = "";
            C2iExpression expression = null;
            
            foreach (KeyValuePair<string, C2iExpression> coupleNomExpression in m_dicNomParametreExpression)
            {
                strNom = coupleNomExpression.Key;
                expression = coupleNomExpression.Value;
                if (expression != null)
                {
                    result = expression.Eval(contexteEval);
                    if (!result)
                    {
                        result.EmpileErreur(I.T("An error occured during expression evaluation of Parameter: @1|567", strNom));
                        return result;
                    }
                    dicNomParametreValeur.Add(strNom, result.Data);
                }
                else
                {
                    // Si l'expression est nulle, son résultat est considéré comme nul
                    dicNomParametreValeur.Add(strNom, null);
                }
            }
            
            // Si aucune erreru retourne la collection dans le data du result
            if(result)
                result.Data = dicNomParametreValeur;
            return result;

        }

		/// ////////////////////////////////////////////////////////////////
		public Type TypeFormulaire
		{
			get
			{
				return m_typeFormulaire;
			}
			set
			{
				m_typeFormulaire = value;
			}
		}
	}

	/// ////////////////////////////////////////////////////////////////
	public class CActionSur2iLinkAfficheFormulaireCustom : CActionSur2iLink
	{
		int m_nIdFormulaireInDb = -1;

		public CActionSur2iLinkAfficheFormulaireCustom ()
			:base()
		{
		}

		/// ////////////////////////////////////////////////////////////////
		public override string ToString()
		{
			return I.T("Custom form|353");
		}

        //-------------------------------------------------------------------
        public override bool AutoriserEnEdition
        {
            get { return false; }
        }

		/// ////////////////////////////////////////////////////////////////
		private int GetNumVersion()
		{
			return 0;
		}

		/// ////////////////////////////////////////////////////////////////
		public override CResultAErreur Serialize(C2iSerializer serializer)
		{
			int nVersion = GetNumVersion();
			CResultAErreur result = serializer.TraiteVersion ( ref nVersion );
			if ( result )
				result = base.Serialize ( serializer );
			if ( !result )
				return result;
			serializer.TraiteInt ( ref m_nIdFormulaireInDb );
			return result;
		}


		/// ////////////////////////////////////////////////////////////////
		public int IdFormulaireInDb
		{
			get
			{
				return m_nIdFormulaireInDb;
			}
			set
			{
				m_nIdFormulaireInDb = value;
			}
		}
	}

	/// ////////////////////////////////////////////////////////////////
	public class CActionSur2iLinkAfficherEntite : CActionSur2iLink
	{
		public const string c_champElementSource = "Source element";

		private C2iExpression m_formuleElement = null;
		private C2iExpression m_formuleContexte = null;
		private C2iExpression m_formuleTitreForm = null;
        private C2iExpression m_formuleCodeFormulaire = null;

		/// ////////////////////////////////////////////////////////////////
		public CActionSur2iLinkAfficherEntite()
			:base()
		{}

		/// ////////////////////////////////////////////////////////////////
		public override string ToString()
		{
			return I.T("Entity|354");
		}

        //-------------------------------------------------------------------
        public override bool AutoriserEnEdition
        {
            get { return false; }
        }

		/// ////////////////////////////////////////////////////////////////
		public C2iExpression FormuleContexte
		{
			get
			{
				return m_formuleContexte;
			}
			set
			{
				m_formuleContexte = value;
			}
		}

		/// ////////////////////////////////////////////////////////////////
		public C2iExpression FormuleTitre
		{
			get
			{
				return m_formuleTitreForm;
			}
			set
			{
				m_formuleTitreForm = value;
			}
		}

        public C2iExpression FormuleCodeFormulaire
        {
            get { return m_formuleCodeFormulaire; }
            set { m_formuleCodeFormulaire = value; }
        }

		/// ////////////////////////////////////////////////////////////////
		private int GetNumVersion()
		{
			return 3;
            // 2 : ajout du code du formulaire personnalisé
            //3 : passage CodeFormulaire en formule
		}

		/// ////////////////////////////////////////////////////////////////
		public override CResultAErreur Serialize(C2iSerializer serializer)
		{
			int nVersion = GetNumVersion();
			CResultAErreur result = serializer.TraiteVersion ( ref nVersion );
			if ( result )
				result = base.Serialize ( serializer );
			if ( !result )
				return result;
			string strExp = C2iExpression.GetPseudoCode ( m_formuleContexte );
			serializer.TraiteString ( ref strExp );
			m_formuleContexte = C2iExpression.FromPseudoCode(strExp);
			
			strExp = C2iExpression.GetPseudoCode ( m_formuleTitreForm );
			serializer.TraiteString ( ref strExp );
			m_formuleTitreForm =  C2iExpression.FromPseudoCode ( strExp );
			
			strExp = C2iExpression.GetPseudoCode ( m_formuleElement );
			serializer.TraiteString ( ref strExp );
			m_formuleElement = C2iExpression.FromPseudoCode ( strExp );
			
            if(nVersion == 2)
            {
                string strTmp = "";
                serializer.TraiteString(ref strTmp);
                m_formuleCodeFormulaire = new C2iExpressionConstante(strTmp);
            }
            if (nVersion >= 3)
            {
                result = serializer.TraiteObject(ref m_formuleCodeFormulaire);
                if (!result)
                    return result;
            }


			return result;
		}


		/// ////////////////////////////////////////////////////////////////
		public C2iExpression FormuleElement
		{
			get
			{
				return m_formuleElement;
			}
			set
			{
				m_formuleElement = value;
			}
		}
	}


    public class CActionSur2iLinkMenuDeroulant : CActionSur2iLink
    {
        private List<IMenuItem> m_listeMenuItems = new List<IMenuItem>();

        public CActionSur2iLinkMenuDeroulant():
            base()
        { }

        public List<IMenuItem> ListeMenuItems
        {
            get
            {
                m_listeMenuItems.Sort(new CActionMenuItemComparer());
                return m_listeMenuItems;
            }
            set
            {
                m_listeMenuItems = value;
            }
        }

        //-------------------------------------------------------------------
        public override bool AutoriserEnEdition
        {
            get { return true; }
        }


        public override string ToString()
        {
            return I.T("Dropdown Menu Action|10035");
        }
        
        private int GetNumVersion()
        {
            return 0;
        }
        
        public override CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (result)
                result = base.Serialize(serializer);
            if (!result)
                return result;

            result = serializer.TraiteListe<IMenuItem>(m_listeMenuItems);

            return result;
        }



    }

    //////////////////////////////////////////////////////////////////////////////////////
    public class CActionSur2iLinkFormulairePopup : CActionSur2iLink
    {
        private string m_strLibelle = "";
        private C2iWndFenetre m_formulaire = new C2iWndFenetre();
        private C2iExpression m_formuleElementEdite = null;

        public CActionSur2iLinkFormulairePopup() :
            base()
        {
            
        }

        //-------------------------------------------------------------------
        public override bool AutoriserEnEdition
        {
            get { return true; }
        }

        public override string ToString()
        {
            return I.T("Popup Form Action|10036");
        }

        //--------------------------------------------------------------------------
        public string Libelle
        {
            get
            {
                return m_strLibelle;
            }
            set
            {
                m_strLibelle = value;
            }
        }

        //--------------------------------------------------------------------------
        public C2iWndFenetre Formulaire
        {
            get
            {
                return m_formulaire;
            }
            set
            {
                m_formulaire = value;
            }
        }

        //--------------------------------------------------------------------------
        public C2iExpression FormuleElementEdite
        {
            get
            {
                return m_formuleElementEdite;
            }
            set
            {

                m_formuleElementEdite = value;
            }
        }

        //--------------------------------------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //--------------------------------------------------------------------------
        public override CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (result)
                result = base.Serialize(serializer);
            if (!result)
                return result;

            serializer.TraiteString(ref m_strLibelle);
            result = serializer.TraiteObject<C2iExpression>(ref m_formuleElementEdite);
            if(result)
                result = serializer.TraiteObject<C2iWndFenetre>(ref m_formulaire);

            return result;
        }
    }

}
