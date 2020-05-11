using System;
using System.Collections;

using sc2i.common;
using sc2i.expression;
using sc2i.data.dynamic;
using sc2i.data;


namespace sc2i.workflow
{
	/// <summary>
	/// Contient des éléments qui permettent de parametrer une entrée d'agenda
	/// </summary>
	[Serializable]
	public class CParametreEntreeAgenda : I2iSerializable
	{
		private CTypeEntreeAgenda m_typeEntree = null;

		private C2iExpression m_formuleCle = null;
		private C2iExpression m_formuleDateDebut = null;
		private C2iExpression m_formuleDateFin = null;
		private C2iExpression m_formuleLibelle = null;
		private C2iExpression m_formuleCommentaires = null;
		private int m_nMinutesRappel = -1;
		private bool m_bSansHoraires = false;
		private CEtatEntreeAgenda m_etatInitial = new CEtatEntreeAgenda ( EtatEntreeAgenda.AFaire );
		private bool m_bEtatAuto = false;

		private ArrayList m_listeParametresRelationsTypesElements = new ArrayList();
		private ArrayList m_listeParametresRelationsChamps = new ArrayList();

		/// ////////////////////////////////////////
		public CParametreEntreeAgenda( )
		{
		}


		/// ////////////////////////////////////////
		public CTypeEntreeAgenda TypeEntree
		{
			get
			{
				return m_typeEntree;
			}
			set
			{
				m_typeEntree = value;
			}
		}

		/// ////////////////////////////////////////
		public C2iExpression FormuleCle
		{
			get
			{
				return m_formuleCle;
			}
			set
			{
				m_formuleCle = value;
			}
		}

		/// ////////////////////////////////////////
		public C2iExpression FormuleDateDebut
		{
			get
			{
				return m_formuleDateDebut;
			}
			set
			{
				m_formuleDateDebut = value;
			}
		}

		/// ////////////////////////////////////////
		public C2iExpression FormuleDateFin
		{
			get
			{
				return m_formuleDateFin;
			}
			set
			{
				m_formuleDateFin = value;
			}
		}

		/// ////////////////////////////////////////
		public C2iExpression FormuleLibelle
		{
			get
			{
				return m_formuleLibelle;
			}
			set
			{
				m_formuleLibelle = value;
			}
		}

		
		/// ////////////////////////////////////////
		public C2iExpression FormuleCommentaires
		{
			get
			{
				return m_formuleCommentaires;
			}
			set
			{
				m_formuleCommentaires = value;
			}
		}


		/// ////////////////////////////////////////
		public bool SansHoraire
		{
			get
			{
				return m_bSansHoraires;
			}
			set
			{
				m_bSansHoraires = value;
			}
		}

		/// ////////////////////////////////////////
		public int MinutesRappel
		{
			get
			{
				return m_nMinutesRappel;
			}
			set
			{
				m_nMinutesRappel = value;
			}
		}

		/// ////////////////////////////////////////
		public bool EtatAutomatique
		{
			get
			{
				return m_bEtatAuto;
			}
			set
			{
				m_bEtatAuto = value;
			}
		}

		/// ////////////////////////////////////////
		public CEtatEntreeAgenda EtatInitial
		{
			get
			{
				return m_etatInitial;
			}
			set
			{
				m_etatInitial = value;
			}
		}

		/// ////////////////////////////////////////
		public void NettoieFormulesLienEtChamps()
		{
			if ( TypeEntree != null )
			{
				Hashtable tableRelations = new Hashtable();
				foreach ( CRelationTypeEntreeAgenda_TypeElementAAgenda relation in TypeEntree.RelationsTypeElementsAAgenda )
					tableRelations[relation.Id] = true;

				foreach ( CParametreRelationEntreeAgenda_TypeElement parametre in (IEnumerable)m_listeParametresRelationsTypesElements.Clone() )
				{
					if ( parametre.Relation == null ||
						tableRelations[parametre.Relation.Id] == null ||
						parametre.FormuleLien == null )
						m_listeParametresRelationsTypesElements.Remove ( parametre );
				}

				Hashtable tableChamps = new Hashtable();
				foreach ( CChampCustom champ in TypeEntree.TousLesChampsAssocies )
					tableChamps[champ.Id] = true;
				
				foreach (CParametreRelationEntreeAgenda_ChampCustom parametre in (IEnumerable)m_listeParametresRelationsChamps.Clone() )
				{
					if ( parametre.FormuleValeur == null ||
						tableChamps[parametre.IdChamp] ==  null )
						m_listeParametresRelationsChamps.Remove ( parametre );
				}
			}
		}

		/// ////////////////////////////////////////
		public void SetFormuleForRelationTypeElement ( CRelationTypeEntreeAgenda_TypeElementAAgenda rel, C2iExpression formule )
		{
			foreach ( CParametreRelationEntreeAgenda_TypeElement relEx in m_listeParametresRelationsTypesElements )
				if ( relEx.Relation.Id == rel.Id )
				{
					if ( formule == null )
					{
						m_listeParametresRelationsChamps.Remove ( relEx );
						return;
					}
					relEx.FormuleLien = formule;
					return;
				}
			if ( formule == null )
				return;
			CParametreRelationEntreeAgenda_TypeElement parametre = new CParametreRelationEntreeAgenda_TypeElement ( this );
			parametre.Relation = rel;
			parametre.FormuleLien = formule;
			m_listeParametresRelationsTypesElements.Add ( parametre );
		}

		/// ////////////////////////////////////////
		public C2iExpression GetFormuleForRelationTypeElement ( CRelationTypeEntreeAgenda_TypeElementAAgenda relation )
		{
			foreach ( CParametreRelationEntreeAgenda_TypeElement relEx in m_listeParametresRelationsTypesElements )
				if ( relEx != null && relEx.Relation != null && relEx.Relation.Id == relation.Id )
					return relEx.FormuleLien;
			return null;
		}

		/// ////////////////////////////////////////
		public CParametreRelationEntreeAgenda_ChampCustom[] ParametresChamps
		{
			get
			{
				return (CParametreRelationEntreeAgenda_ChampCustom[])m_listeParametresRelationsChamps.ToArray(typeof(CParametreRelationEntreeAgenda_ChampCustom));
			}
		}

		/// ////////////////////////////////////////
		public CParametreRelationEntreeAgenda_TypeElement[] ParametresTypesElements
		{
			get
			{
				return (CParametreRelationEntreeAgenda_TypeElement[])m_listeParametresRelationsTypesElements.ToArray(typeof(CParametreRelationEntreeAgenda_TypeElement));
			}
		}

		/// ////////////////////////////////////////
		public void SetFormuleForRelationChamp ( int nIdChamp, C2iExpression formule )
		{
			foreach ( CParametreRelationEntreeAgenda_ChampCustom relEx in m_listeParametresRelationsChamps )
			{
				if ( relEx.IdChamp == nIdChamp )
				{
					if ( formule == null )
					{
						m_listeParametresRelationsChamps.Remove ( relEx );
						return;
					}
					relEx.FormuleValeur = formule;
					return;
				}
			}
			if ( formule == null )
				return;
			CParametreRelationEntreeAgenda_ChampCustom parametre = new CParametreRelationEntreeAgenda_ChampCustom ( this );
			parametre.IdChamp = nIdChamp;
			parametre.FormuleValeur = formule;
			m_listeParametresRelationsChamps.Add ( parametre );
		}

		/// ////////////////////////////////////////
		public C2iExpression GetFormuleForRelationChamp ( int nIdChamp )
		{
			foreach ( CParametreRelationEntreeAgenda_ChampCustom relEx in m_listeParametresRelationsChamps )
				if ( relEx != null && relEx.IdChamp == nIdChamp )
					return relEx.FormuleValeur;
			return null;
		}

		#region Membres de I2iSerializable
		private int GetNumVersion()
		{
			return 4;
			//3 : Ajout de la formule de clé
			//4 : Ajout des minutes de rappel
		}
		
		public CResultAErreur Serialize(C2iSerializer serializer)
		{
			int nVersion = GetNumVersion();
			CResultAErreur result = serializer.TraiteVersion ( ref nVersion );
			if ( !result )
				return result;
			NettoieFormulesLienEtChamps();
			int nIdTypeEntree = -1;
			if ( TypeEntree != null )
				nIdTypeEntree = TypeEntree.Id;
			serializer.TraiteInt ( ref nIdTypeEntree );
			if ( serializer.Mode == ModeSerialisation.Lecture )
			{
				if ( nIdTypeEntree != -1 )
				{
					CTypeEntreeAgenda typeEntree = new CTypeEntreeAgenda ( (CContexteDonnee)serializer.GetObjetAttache ( typeof(CContexteDonnee)));
					if ( typeEntree.ReadIfExists ( nIdTypeEntree ) )
						m_typeEntree = typeEntree;
				}
			}
			if ( TypeEntree == null )
			{
				result.EmpileErreur(I.T("The entry type is incorrect|30081"));
				return result;
			}

			I2iSerializable objet = m_formuleCommentaires;
			result = serializer.TraiteObject ( ref objet );
			if ( !result )
				return result;
			m_formuleCommentaires = (C2iExpression)objet;

			objet = m_formuleDateDebut;
			result = serializer.TraiteObject ( ref objet );
			if ( !result )
				return result;
			m_formuleDateDebut = (C2iExpression)objet;

			objet = m_formuleDateFin;
			result = serializer.TraiteObject ( ref objet );
			if ( !result )
				return result;
			m_formuleDateFin = (C2iExpression)objet;

			objet = m_formuleLibelle;
			result = serializer.TraiteObject ( ref objet );
			if ( !result )
				return result;
			m_formuleLibelle = (C2iExpression)objet;

			serializer.TraiteBool ( ref m_bSansHoraires );
			serializer.TraiteBool ( ref m_bEtatAuto );

			int nEtat = m_etatInitial.EtatInt;
			serializer.TraiteInt ( ref nEtat );
			m_etatInitial = new CEtatEntreeAgenda ( (EtatEntreeAgenda)nEtat );

			serializer.AttacheObjet ( typeof(CParametreEntreeAgenda), this );

			result = serializer.TraiteArrayListOf2iSerializable ( m_listeParametresRelationsChamps );
			if ( !result )
				return result;
			result = serializer.TraiteArrayListOf2iSerializable ( m_listeParametresRelationsTypesElements );
			if ( !result )
				return result;
			foreach ( CParametreRelationEntreeAgenda_TypeElement parametre in m_listeParametresRelationsTypesElements.ToArray() )
				if ( parametre.Relation == null )
					m_listeParametresRelationsChamps.Remove ( parametre );


			serializer.DetacheObjet ( typeof(CParametreEntreeAgenda), this );

			//Supprime les relations à type éléments invalides
			foreach ( CParametreRelationEntreeAgenda_TypeElement rel in (IEnumerable)m_listeParametresRelationsChamps.Clone())
				if ( rel.Relation == null )
					m_listeParametresRelationsChamps.Remove ( rel );


			if ( nVersion == 1 )
			{
				//Ancienne référence de la date
				objet = null;
				result = serializer.TraiteObject ( ref objet );
				string strDummy = "";
				serializer.TraiteString ( ref strDummy );
			}

			if ( nVersion >= 3 )
			{
				objet = (I2iSerializable)m_formuleCle;
				result = serializer.TraiteObject ( ref objet );
				if ( !result )
					return result;
				m_formuleCle = (C2iExpression)objet;
			}
			if ( nVersion >= 4 )
			{
				serializer.TraiteInt ( ref m_nMinutesRappel );
			}
			return result;
		}

		#endregion

		/// ////////////////////////////////////////
		/// <summary>
		/// Vérifie que tous les paramètres sont corrects
		/// </summary>
		/// <returns></returns>
		public CResultAErreur VerifieDonnees()
		{
			CResultAErreur result = CResultAErreur.True;
			if ( TypeEntree == null )
			{
				result.EmpileErreur(I.T("The Diary Entry Type of parameter is not defined|315"));
			}
			if ( m_formuleLibelle == null )
				result.EmpileErreur(I.T("Label formula not defined|316"));
			
			if ( m_formuleDateDebut == null )
				result.EmpileErreur(I.T("Start Date formula not defined|317"));
			else 
				if ( m_formuleDateDebut.TypeDonnee.TypeDotNetNatif != typeof(DateTime) )
					result.EmpileErreur(I.T("Start Date formula must return a date type|318"));
			
			if ( m_formuleDateFin == null )
				result.EmpileErreur ( I.T("End Date formula not defined|319"));
			else 
				if ( m_formuleDateDebut.TypeDonnee.TypeDotNetNatif != typeof(DateTime) )
				result.EmpileErreur(I.T("End Date formula must return a date type|320"));

			if  (!result )
				return result;
			//Vérifie les liens
			foreach ( CRelationTypeEntreeAgenda_TypeElementAAgenda relationElement in TypeEntree.RelationsTypeElementsAAgenda )
			{
				C2iExpression formule = GetFormuleForRelationTypeElement ( relationElement );
				if ( formule != null && 
					!relationElement.TypeElements.IsAssignableFrom(formule.TypeDonnee.TypeDotNetNatif) )
					result.EmpileErreur(I.T("@1 formula must return @2 type|321",relationElement.Libelle,relationElement.TypeElementsConvivial));
			}
			return result;
		}

		/// <summary>
		/// Crée une nouvelle entrée d'agenda en utilisant le contexte d'évaluation pour
		/// évaluer les expression.
		/// LE data du result contient le CEntreeAgenda créé.
		/// </summary>
		/// <param name="contexteDonnee"></param>
		/// <param name="contexteEval"></param>
		/// <returns></returns>
		public CResultAErreur CreateEntree ( CContexteDonnee contexteDonnee, CContexteEvaluationExpression contexteEval )
		{
			CResultAErreur result = CResultAErreur.True;
			string strCle = "";
			if ( FormuleCle != null )
			{
				result = FormuleCle.Eval ( contexteEval );
				if ( !result )
				{
					result.EmpileErreur(I.T("Error during the calculation of Diary Entry Key|322"));
					return result;
				}
				if ( result.Data != null )
					strCle = result.Data.ToString();
			}
			CEntreeAgenda entree = new CEntreeAgenda ( contexteDonnee );
			if ( strCle != "" )
			{
				if (!entree.ReadIfExists(new CFiltreData(CEntreeAgenda.c_champCle + "=@1",
					strCle)))
				{
					entree.CreateNewInCurrentContexte();
				}
			}
			entree.TypeEntree = TypeEntree;
			entree.Cle = strCle;
			entree.Etat = EtatInitial;
			entree.EtatAuto = EtatAutomatique;
			entree.SansHoraire = SansHoraire;

			if ( FormuleLibelle != null )
			{
				result = FormuleLibelle.Eval ( contexteEval );
				if ( !result )
				{
					result.EmpileErreur(I.T("Error in label formula|323"));
					return result;
				}
				entree.Libelle = result.Data.ToString();
			}

			if ( FormuleDateDebut != null )
			{
				result = FormuleDateDebut.Eval ( contexteEval );
				if ( !result || !(result.Data is DateTime))
				{
					result.EmpileErreur(I.T("Error in Start Date formula|324"));
					return result;
				}
				entree.DateDebut = (DateTime)result.Data;
			}
			else
			{
				result.EmpileErreur(I.T("Incorrect Start Date Formula|325"));
				return result;
			}

			if ( FormuleDateFin != null )
			{
				result = FormuleDateFin.Eval ( contexteEval );
				if ( !result || !(result.Data is DateTime))
				{
					result.EmpileErreur(I.T("Error in End Date Formula|326"));
					return result;
				}
				entree.DateFin = (DateTime)result.Data;
			}
			else
			{
				result.EmpileErreur(I.T("Incorrect End Date Formula|327"));
				return result;
			}

			if ( FormuleCommentaires != null )
			{
				result = FormuleCommentaires.Eval ( contexteEval );
				if ( result )
					entree.Commentaires = result.Data.ToString();
			}

			//Valeurs des champs
			foreach ( CParametreRelationEntreeAgenda_ChampCustom parametreChamp in ParametresChamps )
			{
				if ( parametreChamp.FormuleValeur != null )
				{
					result = parametreChamp.FormuleValeur.Eval ( contexteEval );
					if ( !result )
					{
						result.EmpileErreur(I.T("Error in the field @1 formula|328",parametreChamp.IdChamp.ToString()));
						return result;
					}
					entree.SetValeurChamp ( parametreChamp.IdChamp, result.Data );
				}
			}

			//Valeurs des liens
			foreach ( CParametreRelationEntreeAgenda_TypeElement paramLien in ParametresTypesElements )
			{
				if ( paramLien.FormuleLien != null && paramLien.Relation != null)
				{
					result = paramLien.FormuleLien.Eval ( contexteEval );
					if (  !result )
					{
						result.EmpileErreur(I.T( "Error in the link @1 formula|329", paramLien.Relation.Libelle));
						return result;
					}
					if ( result.Data != null )
						entree.SetElementsLies(
							new CObjetDonneeAIdNumerique[] { (CObjetDonneeAIdNumerique)result.Data }, paramLien.Relation);
					
				}
			}
			entree.MinutesRappel = m_nMinutesRappel;
			result.Data = entree;
			return result;
		}


	}

	[Serializable]
	public class CParametreRelationEntreeAgenda_TypeElement : I2iSerializable
	{
		private CParametreEntreeAgenda m_parametre = null;

		private CRelationTypeEntreeAgenda_TypeElementAAgenda m_relation = null;
		private C2iExpression m_formuleLien = null;

		/// /////////////////////////////////////////////////
		public CParametreRelationEntreeAgenda_TypeElement ( )
		{
		}

		
		public CParametreRelationEntreeAgenda_TypeElement ( CParametreEntreeAgenda parametre )
		{
			m_parametre = parametre;
		}

		/// <summary>
		/// ParamètreEntreeAgenda auquel appartient le paramètre
		/// </summary>
		public CParametreEntreeAgenda Parametre
		{
			get
			{
				return m_parametre;
			}
		}

		/// <summary>
		/// Relation éditée
		/// </summary>
		public CRelationTypeEntreeAgenda_TypeElementAAgenda Relation
		{
			get
			{
				return m_relation;
			}
			set
			{
				m_relation = value;
			}
		}

		/// <summary>
		/// Expression définissant la valeur du lien
		/// </summary>
		public C2iExpression FormuleLien
		{
			get
			{
				return m_formuleLien;
			}
			set
			{
				m_formuleLien = value;
			}
		}


		#region Membres de I2iSerializable

		private int GetNumVersion()
		{
			return 0;
		}

		public CResultAErreur Serialize(C2iSerializer serializer)
		{
			int nVersion = GetNumVersion();
			CResultAErreur result = serializer.TraiteVersion ( ref nVersion );
			if ( !result )
				return result;

			m_parametre = (CParametreEntreeAgenda)serializer.GetObjetAttache ( typeof(CParametreEntreeAgenda));
			
			int nIdRelation = -1;
			if ( m_relation != null )
				nIdRelation = m_relation.Id;
			serializer.TraiteInt ( ref nIdRelation );
			if ( serializer.Mode == ModeSerialisation.Lecture )
			{
				CRelationTypeEntreeAgenda_TypeElementAAgenda relation = new CRelationTypeEntreeAgenda_TypeElementAAgenda ( (CContexteDonnee)serializer.GetObjetAttache ( typeof(CContexteDonnee)) );
				if ( relation.ReadIfExists ( nIdRelation ))
					m_relation = relation;
				else
					relation = null;//Si la relation n'existe plus, elle sera supprimée du paramètre
			}

			I2iSerializable objet = m_formuleLien;
			result = serializer.TraiteObject ( ref objet );
			m_formuleLien = (C2iExpression)objet;

			return result;
		}

		#endregion
	}

	[Serializable]
	public class CParametreRelationEntreeAgenda_ChampCustom : I2iSerializable
	{
		private CParametreEntreeAgenda m_parametre = null;
		private int m_nIdChamp = -1;
		private C2iExpression m_formuleValeur = null;

		/// <summary>
		/// //////////////////////////////////////
		/// </summary>
		public CParametreRelationEntreeAgenda_ChampCustom ( )
		{
		}

		/// //////////////////////////////////////
		public CParametreRelationEntreeAgenda_ChampCustom ( CParametreEntreeAgenda parametre )
		{
			m_parametre = parametre;
		}

		/// //////////////////////////////////////
		public CParametreEntreeAgenda Parametre
		{
			get
			{
				return m_parametre;
			}
		}

		/// //////////////////////////////////////
		public int IdChamp
		{
			get
			{
				return m_nIdChamp;
			}
			set
			{
				m_nIdChamp = value;
			}
		}

		/// //////////////////////////////////////
		public C2iExpression FormuleValeur
		{
			get
			{
				return m_formuleValeur;
			}
			set
			{
				m_formuleValeur = value;
			}
		}
		

		#region Membres de I2iSerializable
		
		/// //////////////////////////////////////
		private int GetNumVersion()
		{
			return 0;
		}

		/// //////////////////////////////////////
		public CResultAErreur Serialize(C2iSerializer serializer)
		{
			int nVersion = GetNumVersion();
			CResultAErreur result = serializer.TraiteVersion ( ref nVersion );
			if ( !result )
				return result;

			m_parametre = (CParametreEntreeAgenda)serializer.GetObjetAttache ( typeof(CParametreEntreeAgenda));
			
			serializer.TraiteInt ( ref m_nIdChamp );

			I2iSerializable objet = m_formuleValeur;
			result = serializer.TraiteObject ( ref objet );
			m_formuleValeur = (C2iExpression)objet;
			return result;
		}

		#endregion

	}
}
