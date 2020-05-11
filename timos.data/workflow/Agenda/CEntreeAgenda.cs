using System;
using System.Collections;
using System.IO;

using sc2i.data;
using sc2i.common;
using sc2i.process;
using sc2i.multitiers.client;

using sc2i.data.dynamic;
using sc2i.common.planification;

using timos.acteurs;
using timos.securite;
using timos.data.version;


namespace sc2i.workflow
{
	/// <summary>
    /// Entrée d'Agenda ( dans un <see cref="CCalendrier">calendrier</see> ).<br/>
	/// Si l'entrée d'agenda est liée à un CProcessEnExecutionInDb,
	/// lors de l'ouverture, si l'état de l'entrée est "à faire", le process sera lancé.
	/// sinon, l'entrée est liée à un CTypeEntreeAgenda qui indique les options possibles
	/// pour l'entrée
	/// </summary>
	/// <remarks>
	/// <P>
	/// Une entrée d'agenda peut être liée à un élément et un champ de date (élément de référence).<BR></BR>
	/// Dans ce cas, lorsque la date de l'élément de référence est modifiée,
	/// la date de l'entrée d'agenda est automatiquement adaptée en fonction de la nouvelle date 
	/// de manière à conserver le même écart entre la date de référence d'origine et la date de l'entrée qu'entre
	/// la nouvelle date de référence et la nouvelle date de l'entrée.
	/// </P>
	/// </remarks>


    [sc2i.doccode.DocRefMenusOrMenuItems(timos.data.CDocLabels.c_iPlanif)]
    [DynamicClass("Diary entry")]
	[ObjetServeurURI("CEntreeAgendaServeur")]
	[Table(CEntreeAgenda.c_nomTable, CEntreeAgenda.c_champId,true)]
	[AutoExec("Autoexec")]
	public class CEntreeAgenda : CElementAChamp, 
		IElementAEvenementsDefinis, 
		IObjetARestrictionSurEntite, 
		IElementALien,
		IEntreeAgenda,
		IElementATypeStructurant<CTypeEntreeAgenda>,
        IObjetDonneeAutoReference
	{
		public const string c_roleChampCustom = "DIARY_ENTRY";

		#region Déclaration des constantes
		public const string c_nomTable = "DIARY_ENTRY";
		public const string c_champId = "DRYENT_ID";
		public const string c_champDateDebut = "DRYENT_START_DATE";
		public const string c_champDateFin = "DRYENT_END_DATE";
		public const string c_champLibelle = "DRYENT_LABEL";
		public const string c_champEtat = "DRYENT_STATE";
		public const string c_champCommentaire = "DRYENT_COMMENT";
		public const string c_champSansHoraire = "DRYENT_WITHOUT_SCHEDULE";
		public const string c_champEtatAutomatique ="DRYENT_AUTO_STATE";
		public const string c_champCle = "DRYENT_KEY";
		public const string c_champEntreePrivee = "DRYENT_PRIVATE";
		public const string c_champLibellePrive = "DRYENT_PRIVATE_LABEL";
		public const string c_champIsCyclique = "DRYENT_IS_CYCLIC";
		public const string c_champDateFinCyclique = "DRYENT__END_CYCLIQUE";
		public const string c_champDataCyclique = "DRYENT__CYCLIQUE";
		public const string c_champMinutesRappel = "DRYENT__DATA_REMIND_MIN";

		public const string c_champIsPriveForUser = "DRYENT_IS_PRIVATE_FOR_USR";

        public const string c_champIdEntreeParente = "DRYENT_PARENT_ID";
        public const string c_champPctAvancement = "DRYENT_PROGRESS_STATE";
        public const string c_champPoidsAvancement = "DRYENT_PROGRES_WGHT";


		#endregion
		//-------------------------------------------------------------------
		public static void Autoexec()
		{
            CRoleChampCustom.RegisterRole(c_roleChampCustom, "Diary entry", typeof(CEntreeAgenda), typeof(CTypeEntreeAgenda));
		}

        //-------------------------------------------------------------------
        public override CRoleChampCustom RoleChampCustomAssocie
        {
            get { return CRoleChampCustom.GetRole(c_roleChampCustom); }
        }

		//-------------------------------------------------------------------
#if PDA
		public CEntreeAgenda()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CEntreeAgenda( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CEntreeAgenda( System.Data.DataRow row )
			:base(row)
		{
		}
		//-------------------------------------------------------------------
		protected override void MyInitValeurDefaut()
		{
			//Arrondi l'heure à 30 minutes
			int nHeure = DateTime.Now.Hour;
			int nMin = DateTime.Now.Minute;
			if ( nMin < 15 )
				nMin = 0;
			else if ( nMin >= 45 )
			{
				nMin = 0;
				nHeure++;
			}
			else
				nMin = 30;
			DateTime dt = new DateTime ( DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
				nHeure, nMin, 0 );
			DateDebut = dt;
			DateFin = dt;
			Etat = new CEtatEntreeAgenda(EtatEntreeAgenda.AFaire);
			EntreePrivee = false;
			LibellePrive = "*******";
		}
		//-------------------------------------------------------------------
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champDateDebut};
		}
		//-------------------------------------------------------------------
		public override string ToString()
		{
			return Libelle;
		}
		//-------------------------------------------------------------------
		public override string DescriptionElement
		{
			get
			{
				return I.T("Diary Entry @1 of @2|307", Libelle, DateDebut.ToShortDateString());
			}
		}
		
		
		//-------------------------------------------------------------------
        /// <summary>
        /// Libellé de l'entrée d'agenda
        /// </summary>
		[
		TableFieldProperty(c_champLibelle, 255),
		DynamicField("Label")
		]
		public string Libelle
		{
			get
			{
				if ( IsPriveeForUser )
					return LibellePrive;
				return (string)Row[c_champLibelle];
			}
			set
			{
				if ( IsPriveeForUser && Row[c_champLibelle] != DBNull.Value)
					return;
				Row[c_champLibelle] = value;
			}
		}

		//-------------------------------------------------------------------
        /// <summary>
        /// Commentaire
        /// </summary>
		[
		TableFieldProperty(c_champCommentaire, 2048),
		DynamicField("Commentaires")
		]
		public string Commentaires
		{
			get
			{
				return (string)Row[c_champCommentaire];
			}
			set
			{
				Row[c_champCommentaire] = value;
			}
		}

		//-------------------------------------------------------------------
		
		/// <summary>
		/// Date à laquelle l'entrée d'agenda doit commencer.<br/>
        /// Lors de la modification de la date de début, la date de fin<br/>
        /// est automatiquement ajustée pour conserver l'écart entre<br/>
        /// les deux dates.
		/// </summary>
		[TableFieldProperty(c_champDateDebut)]
		[DynamicField("Starting date")]
		public DateTime DateDebut
		{
			get
			{
				return (DateTime)Row[c_champDateDebut];
			}
			set
			{
				DateTime valeur = value;
				if ( SansHoraire )
					valeur = new DateTime ( value.Year, value.Month, value.Day, 0, 0, 0 );
				else
					valeur = value;
				/*if ( Row[c_champDateDebut] is DateTime && Row[c_champDateFin] is DateTime )
				{
					TimeSpan sp = valeur-(DateTime)Row[c_champDateDebut];
					DateFin = DateFin.Add ( sp );
				}*/
				Row[c_champDateDebut] = valeur;
			}

		}

		//-------------------------------------------------------------------
		/// <summary>
		/// Si vrai, indique que l'état de l'élément se met à jour automatiquement.
        /// <br/>
        /// <br/>
		/// L'état passe à "En cours" lorsque la date de début de l'élément est dépassée.<br/>
		/// L'état passe à "Terminé" lorsque la date de fin de l'élément est dépassée.<br/>
        /// </summary>
		[TableFieldProperty(c_champEtatAutomatique)]
		[DynamicField("Auto state")]
		public bool EtatAuto
		{
			get
			{
				return (bool)Row[c_champEtatAutomatique];
			}
			set
			{
				Row[c_champEtatAutomatique] = value;
			}
		}

		//-------------------------------------------------------------------
		/// <summary>
		/// Clé permettant aux process de ne pas créer 2 fois la même entrée d'agenda
		/// </summary>
		[TableFieldProperty(c_champCle, 255)]
		[DynamicField("Key")]
		public string Cle
		{
			get
			{
				return (string)Row[c_champCle];
			}
			set
			{
				Row[c_champCle] = value;
			}
		}

		
		

			//-------------------------------------------------------------------
			/// <summary>
			/// Date à laquelle l'entrée d'agenda doit se terminer
			/// </summary>
			[TableFieldProperty(c_champDateFin)]
			[DynamicField("End date")]
			public DateTime DateFin
		{
			get
			{
				return (DateTime)Row[c_champDateFin];
			}
			set
			{
				if ( SansHoraire )
					Row[c_champDateFin] = new DateTime ( value.Year, value.Month, value.Day, 23, 59, 59 );
				else
					Row[c_champDateFin] = value;
			}
		}

		//-------------------------------------------------------------------
		/// <summary>
		/// code de l'état de l'entrée d'agenda :
        /// <ul>
        /// <li>0 : Aucun,</li>
        /// <li>1 : A Faire,</li>
        /// <li>2 : En Cours,</li>
        /// <li>3 : Terminée,</li>
        /// <li>4 : Annulée</li>
        /// </ul>
        /// </summary>
		[TableFieldProperty(c_champEtat)]
		[DynamicField("State code")]
		public int CodeEtatInt 
		{
			get
			{
				return (int)Row[c_champEtat];
			}
			set
			{
				Row[c_champEtat] = value;
			}
		}

		//-------------------------------------------------------------------
		
		/// <summary>
		/// Indique que l'entrée d'agenda est sans horaire<br/>
        /// (heures de début et de fin non définies)
		/// </summary>
		[TableFieldProperty(c_champSansHoraire)]
		[DynamicField("Without schedule")]
		public bool SansHoraire
		{
			get
			{
				return (bool)Row[c_champSansHoraire];
			}
			set
			{
				Row[c_champSansHoraire] = value;
			}
		}

		//-------------------------------------------------------------------
        /// <summary>
        /// Etat de l'entrée d'agenda (cf. 'State code')
        /// </summary>
		[DynamicField("State")]
		public CEtatEntreeAgenda Etat
		{
			get
			{
				if ( EtatAuto )
				{
					if ( DateTime.Now < DateDebut )
						return new CEtatEntreeAgenda(EtatEntreeAgenda.AFaire);
					if ( DateTime.Now > DateDebut && DateTime.Now < DateFin )
						return new CEtatEntreeAgenda(EtatEntreeAgenda.EnCours);
					if ( DateTime.Now > DateFin )
						return new CEtatEntreeAgenda(EtatEntreeAgenda.Terminee);
				}
				return new CEtatEntreeAgenda((EtatEntreeAgenda)CodeEtatInt);
			}
			set
			{
				CodeEtatInt = (int)value.Etat;
			}
		}	

		//-------------------------------------------------------------------
        /// <summary>
        /// Type correspondant de l'entrée d'agenda
        /// </summary>
		[Relation(CTypeEntreeAgenda.c_nomTable, CTypeEntreeAgenda.c_champId, CTypeEntreeAgenda.c_champId, true, false, true)]
		[DynamicField("Entry type")]
		public CTypeEntreeAgenda TypeEntree
		{
			get
			{
				return (CTypeEntreeAgenda)GetParent ( CTypeEntreeAgenda.c_champId, typeof(CTypeEntreeAgenda));
			}
			set
			{
				SetParent ( CTypeEntreeAgenda.c_champId, value );
				if ( IsNew() && value != null)
					EtatAuto = value.EtatAuto;
				if  ( value != null && IsNew() && Row[c_champLibelle] != DBNull.Value && Libelle == "" )
					Libelle = value.Libelle;
			}
		}
		
		//-------------------------------------------------------------------
		public override IDefinisseurChampCustom[] DefinisseursDeChamps
		{
			get
			{
				CListeObjetsDonnees liste = new CListeObjetsDonnees(ContexteDonnee, typeof(CTypeEntreeAgenda));
				liste.Filtre = new CFiltreData(CTypeEntreeAgenda.c_champId+"=@1", TypeEntree.Id);
				liste.InterditLectureInDB = true;//Le type est déjà lu !!!
				return (IDefinisseurChampCustom[])liste.ToArray(typeof(IDefinisseurChampCustom));
			}
		}

		//-------------------------------------------------------------------
		public override CRelationElementAChamp_ChampCustom GetNewRelationToChamp()
		{
			return new CRelationEntreeAgenda_ChampCustom(ContexteDonnee);
		}

		//-------------------------------------------------------------------
        /// <summary>
        /// Retourne la liste des relations entre l'entrée d'agenda et<br/>
        /// les champs personnalisés
        /// </summary>
		[RelationFille(typeof(CRelationEntreeAgenda_ChampCustom), "ElementAChamps")]
		[DynamicChilds("Custom fields relations", typeof(CRelationEntreeAgenda_ChampCustom))]
		public override CListeObjetsDonnees RelationsChampsCustom
		{
			get
			{
				return GetDependancesListe ( CRelationEntreeAgenda_ChampCustom.c_nomTable, GetChampId() );
			}
		}

		//-------------------------------------------------------------------
        /// <summary>
        /// Retourne la liste des relations entre cette entrée d'agenda<br/>
        /// et les éléments à agenda qui lui correspondent
        /// </summary>
		[RelationFille(typeof(CRelationEntreeAgenda_ElementAAgenda), "EntreeAgenda")]
		[DynamicChilds("Elements relations", typeof(CRelationEntreeAgenda_ElementAAgenda))]
		public CListeObjetsDonnees RelationsElementsAgenda
		{
			get
			{
				return GetDependancesListe ( CRelationEntreeAgenda_ElementAAgenda.c_nomTable, GetChampId() );
			}
		}

		//-------------------------------------------------------------------
		/// <summary>
		/// Indique si l'entrée est une entrée privée.
        /// <br/>
        /// <br/>
        /// Une entrée d'agenda privée est visible par tout le monde, mais ne<br/>
        /// peut être consultée que par les acteurs liés à cette entrée et<br/>
        /// leurs collaborateurs d'agenda
		/// </summary>
		[TableFieldProperty(c_champEntreePrivee)]
		[DynamicField("Is private")]
		public bool EntreePrivee
		{
			get
			{
				if ( Row[c_champEntreePrivee] == DBNull.Value )
					return false;
				return (bool)Row[c_champEntreePrivee];
			}
			set
			{
				Row[c_champEntreePrivee] = value;
				Row[c_champIsPriveForUser] = DBNull.Value;

			}
		}

		//-------------------------------------------------------------------
		/// <summary>
		/// Libellé apparaissant lorsqu'une personne non liée à l'entrée d'agenda
		/// consulte cette entrée
		/// </summary>
		[TableFieldProperty(c_champLibellePrive, 64)]
		[DynamicField("Private label")]
		public string LibellePrive
		{
			get
			{
				return ( string )Row[c_champLibellePrive];
			}
			set
			{
				Row[c_champLibellePrive] = value;
			}
		}

		//-------------------------------------------------------------------
        /// <summary>
        /// Process ayant créé l'entrée d'agenda
        /// </summary>
		[Relation(CProcessEnExecutionInDb.c_nomTable,
		CProcessEnExecutionInDb.c_champId,
		CProcessEnExecutionInDb.c_champId,
		false,
		true,
		true)]
		[DynamicField("Opening process")]
		public CProcessEnExecutionInDb ProcessSurOuverture
		{
			get
			{
				return ( CProcessEnExecutionInDb )GetParent ( CProcessEnExecutionInDb.c_champId, typeof(CProcessEnExecutionInDb) );
			}
			set
			{
				SetParent ( CProcessEnExecutionInDb.c_champId, value );
			}
		}

		//-------------------------------------------------------------------
        /// <summary>
        /// Retourne le premier élément correspondant à l'entrée d'agenda,<br/>
        /// à partir du code de lien entre type d'entrée d'agenda et type d'élément, passé en paramètre.
        /// </summary>
        /// <param name="strCode">Code du lien</param>
        /// <returns>L'élément</returns>
		[DynamicMethod("Return an element related to the Diary Entry with Link Code")]
		public CObjetDonneeAIdNumerique GetElementLie ( string strCode )
		{
			strCode = strCode.ToUpper();
			foreach (CRelationEntreeAgenda_ElementAAgenda rel in RelationsElementsAgenda )
				if ( rel.RelationTypeEntree_TypeElement.Code.ToUpper() == strCode )
					return rel.ElementLie;
			return null;
		}
		//-------------------------------------------------------------------
		public CObjetDonneeAIdNumerique[] GetElementsLies(CRelationTypeEntreeAgenda_TypeElementAAgenda relType)
		{
			ArrayList lst = new ArrayList();
			foreach (CRelationEntreeAgenda_ElementAAgenda rel in RelationsElementsAgenda)
				if (rel.RelationTypeEntree_TypeElement.Id == relType.Id)
					lst.Add(rel.ElementLie);
			return (CObjetDonneeAIdNumerique[])lst.ToArray(typeof(CObjetDonneeAIdNumeriqueAuto));
		}

		//-------------------------------------------------------------------
        /// <summary>
        /// Retourne le tableau des éléments correspondant à l'entrée d'agenda,<br/>
        /// à partir du code de lien entre type d'entrée d'agenda et type d'élément, passé en paramètre.
        /// </summary>
        /// <param name="strCode">Code du lien</param>
        /// <returns>Le tableau d'éléments</returns>
		[DynamicMethod("Return elements related to the Diary Entry with Link Code")]
		public CObjetDonneeAIdNumerique[] GetElementsLies ( string strCode )
		{
			ArrayList lst = new ArrayList();
			strCode = strCode.ToUpper();
			foreach (CRelationEntreeAgenda_ElementAAgenda rel in RelationsElementsAgenda )
				if ( rel.RelationTypeEntree_TypeElement.Code.ToUpper() == strCode )
					lst.Add ( rel.ElementLie );
			return (CObjetDonneeAIdNumerique[])lst.ToArray(typeof(CObjetDonneeAIdNumeriqueAuto));
		}

		public void SetElementsLies(IEnumerable elements, CRelationTypeEntreeAgenda_TypeElementAAgenda relType)
		{
			Hashtable tableOk = new Hashtable();
			foreach (CObjetDonneeAIdNumerique objet in elements)
			{
				AddElementLieSurType(objet, relType);
				tableOk[objet.Id] = true;
			}
			foreach (CObjetDonneeAIdNumerique objetLie in GetElementsLies(relType))
				if (!tableOk.Contains(objetLie.Id))
					DelieElementSurType(objetLie, relType);
		}

		//-------------------------------------------------------------------
		/// <summary>
        /// Définit tous les éléments liés par rapport au code du lien<br/>
        /// entre type d'entrée d'agenda et type d'élément passé en paramètre.
        /// <br/>
        /// <br/>
        /// Les nouveaux éléments sont ajoutés, les éléments qui étaient liés<br/>
        /// précédemment et qui ne sont plus dans la liste des éléments sont déliés.
		/// </summary>
		/// <param name="elements">Les éléments</param>
		/// <param name="strCode">Le code du lien</param>
		[DynamicMethod(typeof(bool),"Indicate all elements related to Link type (by its code). The new elements are added, the elements which were bound and aren't in the list are automatically untied",
			 "Elements to link",
			 "Link Type Code")]
		public void SetElementsLies ( IEnumerable elements, string strCode )
		{
			if ( elements == null )
				return ;
			ArrayList lst = new ArrayList();
			CListeObjetsDonnees liste = TypeEntree.RelationsTypeElementsAAgenda;
			liste.Filtre = new CFiltreData ( CRelationTypeEntreeAgenda_TypeElementAAgenda.c_champCode+"=@1",strCode );
			if ( liste.Count == 0 )
				return ;
			CRelationTypeEntreeAgenda_TypeElementAAgenda relType = (CRelationTypeEntreeAgenda_TypeElementAAgenda)liste[0];
			SetElementsLies(elements, relType);
		}
		
		//-------------------------------------------------------------------
		/// <summary>
        /// Ajoute un élément lié à l'entrée d'agenda par rapport au code du lien<br/>
        /// entre type d'entrée d'agenda et type d'élément, passé en paramètre.
        /// <br/>
        /// <br/>
        /// Si le lien est multiple, l'élément est ajouté, sinon, il remplace<br/>
        /// l'élément précédent.
		/// </summary>
		/// <param name="element">L'élément</param>
		/// <param name="strCode">Le code du lien</param>
		/// <returns>VRAI si succès, FALSE si échec</returns>
		[DynamicMethod(typeof(bool),"Links an element to the agenda entry from the type code of the link. If the link is multiple, the élément is added, otherwise it replaces the previous element",
			 "Element to link",
			"Link Type Code")]
		public bool AddElementLie ( CObjetDonneeAIdNumerique element, string strCode )
		{
			if ( element == null )
				return false;
			ArrayList lst = new ArrayList();
			CListeObjetsDonnees liste = TypeEntree.RelationsTypeElementsAAgenda;
			liste.Filtre = new CFiltreData ( CRelationTypeEntreeAgenda_TypeElementAAgenda.c_champCode+"=@1",strCode );
			if ( liste.Count == 0 )
				return false;
			CRelationTypeEntreeAgenda_TypeElementAAgenda relType = (CRelationTypeEntreeAgenda_TypeElementAAgenda)liste[0];
			return AddElementLieSurType ( element, relType );
		}

		public bool AddElementLieSurType ( CObjetDonneeAIdNumerique element, IRelationTypeElementALien_TypeElement relType )
		{
			if ( element == null )
				return false;
			Hashtable tableRelationsExistantes = new Hashtable();
			CRelationEntreeAgenda_ElementAAgenda laRelation = null;
			foreach (CRelationEntreeAgenda_ElementAAgenda rel in RelationsElementsAgenda )
				if ( rel.RelationTypeEntree_TypeElement.Id == relType.Id )
				{
					laRelation = rel;
					tableRelationsExistantes[rel.ElementLie] = rel;
				}

			bool bCreate = false;
			if ( relType.Multiple && element != null)
			{
				if ( tableRelationsExistantes[element] == null )
					bCreate = true;
			}
			else
			{
				if ( tableRelationsExistantes.Count != 0 )
				{
					laRelation.ElementLie = element;
				}
				else
					bCreate = true;
			}
			if ( bCreate )
			{
				CRelationEntreeAgenda_ElementAAgenda rel = new CRelationEntreeAgenda_ElementAAgenda(ContexteDonnee);
				rel.CreateNewInCurrentContexte();
				rel.EntreeAgenda = this;
				rel.ElementLie = element;
				rel.RelationTypeEntree_TypeElement = (CRelationTypeEntreeAgenda_TypeElementAAgenda)relType;
			}
			return true;
		}

		//-------------------------------------------------------------------
		/// <summary>
		/// Annule le lien d'un élément à une entrée d'agenda correspondant<br/>
        /// au code de lien entre type d'entrée d'agenda et type d'élément, passé en paramètre.
		/// </summary>
		/// <param name="element">L'élément</param>
		/// <param name="strCode">Le code de lien</param>
		/// <returns>VRAI si succès, FALSE si échec</returns>
		[DynamicMethod(typeof(bool),"Cancel the bond of one element at the Diary Entry with Link Type Code",
			"Element to link",
			"Link Type Code")]
		public bool DelieElement ( CObjetDonneeAIdNumerique element, string strCode )
		{
			if ( element == null )
				return false;
			foreach ( CRelationEntreeAgenda_ElementAAgenda relation in this.RelationsElementsAgenda )
			{
				if ( relation.ElementLie.Equals ( element ) && relation.RelationTypeEntree_TypeElement.Code == strCode )
				{
					relation.Delete();
					return true;
				}
			}
			return false;
		}

		public bool DelieElementSurType ( CObjetDonneeAIdNumerique element, IRelationTypeElementALien_TypeElement relType )
		{
			if ( element == null )
				return false;
			foreach ( CRelationEntreeAgenda_ElementAAgenda relation in this.RelationsElementsAgenda )
			{
				if ( relation.ElementLie.Equals ( element ) && relation.RelationTypeEntree_TypeElement.Id == relType.Id )
				{
					relation.Delete();
					return true;
				}
			}
			return false;
		}

		//-------------------------------------------------------------------
        /// <summary>
        /// Retourne le premier élément correspondant à l'entrée d'agenda<br/>
        /// correspondant au code de rôle passé en paramètre.
        /// </summary>
        /// <param name="strCodeRole">Code de rôle</param>
        /// <returns>L'élément</returns>
		[DynamicMethod("Return element related to diary entry with Role Code")]
		public CObjetDonneeAIdNumerique GetElementLieRole ( string strCodeRole )
		{
			string strCode = strCodeRole.ToUpper();
			foreach (CRelationEntreeAgenda_ElementAAgenda rel in RelationsElementsAgenda )
			{
				CRoleSurEntreeAgenda role = rel.RelationTypeEntree_TypeElement.Role;
				if ( role != null && role.Code.ToUpper() == strCode )
					return rel.ElementLie;
			}
			return null;
		}

		//-------------------------------------------------------------------
		[TableFieldProperty ( c_champIsPriveForUser, true, IsInDb = false)]
		public bool IsPriveeForUser
		{
			get
			{
				if ( Row[c_champIsPriveForUser] == DBNull.Value )
					CContexteDonnee.ChangeRowSansDetectionModification (Row, c_champIsPriveForUser, CalcIsPriveeForUser ( CUtilSession.GetUserForSession(ContexteDonnee) ) );
				return ( bool )Row[c_champIsPriveForUser];
			}
		}

		//-------------------------------------------------------------------
		private bool CalcIsPriveeForUser ( CDonneesActeurUtilisateur user )
		{
			if ( !EntreePrivee )
				return false;
			string strActeursGeres = user.Acteur.Id.ToString()+",";
			strActeursGeres = strActeursGeres.Substring(0, strActeursGeres.Length-1);
			foreach ( CRelationEntreeAgenda_ElementAAgenda rel in RelationsElementsAgenda )
			{
				CObjetDonneeAIdNumerique eltLie = rel.ElementLie;
				if ( eltLie is CActeur && strActeursGeres.IndexOf(eltLie.Id.ToString())>=0 )
					return false;
			}
			return true;
		}

		//-------------------------------------------------------------------
		/// <summary>
		/// Indique que l'entrée d'agenda est cyclique (se répète dans le temps)
		/// </summary>
		[TableFieldProperty(c_champIsCyclique)]
		[DynamicField("Is cyclic")]
		public bool IsCyclique
		{
			get
			{
				return (bool)Row[c_champIsCyclique];
			}
			set
			{
				Row[c_champIsCyclique] = value;
				if ( value )
				{
					CodeEtatInt = (int)EtatEntreeAgenda.Info;
					EtatAuto = false;
				}
			}
		}

		//-------------------------------------------------------------------
		/// <summary>
		/// Date de fin de l'entrée cyclique
		/// </summary>
		[TableFieldProperty(c_champDateFinCyclique, true)]
		[DynamicField("Cyclic end date")]
		public CDateTimeEx  DateFinCyclique
		{
			get
			{
				if ( Row[c_champDateFinCyclique] == DBNull.Value )
					return null;
				else
					return new CDateTimeEx((DateTime)Row[c_champDateFinCyclique]);
					}
			set
			{
				if ( value == null )
					Row[c_champDateFinCyclique] = DBNull.Value;
				else
					Row[c_champDateFinCyclique] = value.DateTimeValue;
			}
		}

		/// /////////////////////////////////////////////////////////////
		/// <summary>
		/// Indique le nombre de minutes entre le rappel et la date de début<br/>
		/// Si négatif, aucun rappel n'est activé
		/// </summary>
		[TableFieldProperty(c_champMinutesRappel)]
		[DynamicField("Recall minutes")]
		public int MinutesRappel
		{
			get
			{
				return ( int )Row[c_champMinutesRappel];
			}
			set
			{
				Row[c_champMinutesRappel] = value;
			}
		}

		/// /////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champDataCyclique,NullAutorise=true)]
		public CDonneeBinaireInRow DataCyclique
		{
			get
			{
				if ( Row[c_champDataCyclique] == DBNull.Value )
				{
					CDonneeBinaireInRow donnee = new CDonneeBinaireInRow(ContexteDonnee.IdSession ,Row, c_champDataCyclique);
					CContexteDonnee.ChangeRowSansDetectionModification(Row, c_champDataCyclique, donnee);
				}
				return ((CDonneeBinaireInRow)Row[c_champDataCyclique]).GetSafeForRow(Row.Row);
			}
			set
			{
				Row[c_champDataCyclique] = value;
			}
		}

		/// /////////////////////////////////////////////////////////////
        [BlobDecoder]
		public CPlanificationTache PlanificationCyclique
		{
			get
			{
                CPlanificationTache retour = null;
				if ( DataCyclique.Donnees != null )
				{
					MemoryStream stream = new MemoryStream(DataCyclique.Donnees);
					BinaryReader reader = new BinaryReader(stream);
					CSerializerReadBinaire serializer = new CSerializerReadBinaire(reader);
					I2iSerializable objet = null;
					CResultAErreur result = serializer.TraiteObject ( ref objet );
					if ( result )
					{
                        retour = (CPlanificationTache)objet;
					}
                    reader.Close();
                    stream.Close();
				}
				return retour;
			}
			set
			{
				if ( value == null )
				{
					CDonneeBinaireInRow data = DataCyclique;
					data.Donnees = null;
					DataCyclique = data;
				}
				else
				{
					
					MemoryStream stream = new MemoryStream();
					BinaryWriter writer = new BinaryWriter(stream);
					CSerializerSaveBinaire serializer = new CSerializerSaveBinaire(writer);
					I2iSerializable objet = value;
					CResultAErreur result = serializer.TraiteObject ( ref objet );
					if ( result )
					{
						CDonneeBinaireInRow data = DataCyclique;
						data.Donnees = stream.GetBuffer();
						DataCyclique = data;
					}
                    writer.Close();
                    stream.Close();
				}
			}
		}

		//-------------------------------------------------
        /// <summary>
        /// Retourne la liste des entrées de désactivation pour<br/>
        /// cette entrée d'agenda. N'a de sens que pour une entrée<br/>
        /// d'agenda cyclique
        /// </summary>
		[RelationFille(typeof(CDesctivationEntreeAgendaCyclique), "EntreeAgenda")]
		[DynamicChilds("Cyclic inactivation", typeof(CDesctivationEntreeAgendaCyclique))]
		public CListeObjetsDonnees Desactivations
		{
			get
			{
				return GetDependancesListe(CDesctivationEntreeAgendaCyclique.c_nomTable, c_champId);
			}
			set
			{
			}
		}

		/// /////////////////////////////////////////////////////////////
		public CVisuEntreeAgenda[] GetVisusBetween ( CObjetDonneeAIdNumerique elementLie, CRoleSurEntreeAgenda role, DateTime dtDebut, DateTime dtFin, bool bAvecDesactivations )
		{
			ArrayList lst = new ArrayList();
            CPlanificationTache planif = PlanificationCyclique;
			TimeSpan sp = DateFin-DateDebut;
			if ( SansHoraire )
				sp = new TimeSpan ( (int)sp.TotalDays,0,0,0,0 );
			CListeObjetsDonnees liste = Desactivations;
			if(  planif != null )
			{
				DateTime dt = planif.GetNextOccurence ( DateDebut, true );
				DateTime dtLimite = dtFin;
				if ( DateFinCyclique != null && (DateTime)DateFinCyclique < dtFin )
					dtLimite = DateFinCyclique;
				while ( dt < dtLimite )
				{
					if(  bAvecDesactivations )
					liste.Filtre = new CFiltreData ( CDesctivationEntreeAgendaCyclique.c_champDate+">=@1 and "+
						CDesctivationEntreeAgendaCyclique.c_champDate+"<@2",
						dt.Date,
						dt.Date.AddDays(1) );
					if(  dt >= dtDebut && (!bAvecDesactivations || liste.Count == 0) )
						lst.Add ( new CVisuEntreeAgenda ( this, role, elementLie, dt, dt.Add(sp) ) );
					dt = planif.GetNextOccurence ( dt, false );
				}
			}
			return (CVisuEntreeAgenda[])lst.ToArray(typeof(CVisuEntreeAgenda));
		}

		/// /////////////////////////////////////////////////////////////
		public void NettoieDesactivations()
		{
			if ( !IsCyclique )
			{
				//Pas de désactivations
				ArrayList lst = new ArrayList (Desactivations);
				foreach ( CDesctivationEntreeAgendaCyclique desac in lst )
					desac.Delete();
			}
			else
			{
				CPlanificationTache planif = PlanificationCyclique;
				if ( planif == null )
					return;
				CListeObjetsDonnees listeDesac = Desactivations;
				if ( listeDesac.Count == 0 )
					return;
				listeDesac.Tri = CDesctivationEntreeAgendaCyclique.c_champDate+" desc";
				DateTime dtFin = ((CDesctivationEntreeAgendaCyclique)listeDesac[0]).Date.AddDays(1);
				CVisuEntreeAgenda[] visus = GetVisusBetween ( null, null, DateDebut, dtFin, false );
				Hashtable tbl = new Hashtable();
				foreach ( CVisuEntreeAgenda visu in visus )
					tbl[visu.DateDebut.Date] = true;
				ArrayList lst = listeDesac.ToArrayList();
				foreach ( CDesctivationEntreeAgendaCyclique desac in lst )
				{
					if ( tbl[desac.Date.Date] == null )
						desac.Delete();
				}
			}
		}

        //---------------------------------------------------------
        /// <summary>
        /// Indique le pourcentage d'avancement de cette entrée d'agenda
        /// </summary>
        [TableFieldProperty(CEntreeAgenda.c_champPctAvancement)]
        [DynamicField("Progress state")]
        public double PctAvancement
        {
            get
            {
                return (double)Row[c_champPctAvancement];
            }
            set
            {
                Row[c_champPctAvancement] = value;
            }
        }

        //---------------------------------------------------------
        /// <summary>
        /// Indique le poids de l'avancement de cette entrée d'agenda sur
        /// la tâche parente
        /// </summary>
        [TableFieldProperty(CEntreeAgenda.c_champPoidsAvancement)]
        [DynamicField("Progress weight")]
        public double PoidsAvancement
        {
            get
            {
                return (double)Row[c_champPoidsAvancement];
            }
            set
            {
                Row[c_champPoidsAvancement] = value;
            }
        }

        //---------------------------------------------------------
        /// <summary>
        /// Entrée d'agenda parente, lorsqu'elle existe
        /// </summary>
        [Relation(
            CEntreeAgenda.c_nomTable,
            CEntreeAgenda.c_champId,
            CEntreeAgenda.c_champIdEntreeParente,
            false,
            true,
            false)]
        [DynamicField("Parent entry")]
        public CEntreeAgenda EntreeParente
        {
            get
            {
                return GetParent(c_champIdEntreeParente, typeof(CEntreeAgenda)) as CEntreeAgenda;
            }
            set
            {
                SetParent(c_champIdEntreeParente, value);
            }
        }


	
		#region Membres de IElementAEvenementsDefinis

			public IDefinisseurEvenements[] Definisseurs
		{
			get
			{
				return new IDefinisseurEvenements[]{TypeEntree};
			}
		}

		public bool IsDefiniPar(IDefinisseurEvenements definisseur)
		{
			return TypeEntree.Equals ( definisseur );
		}

		#endregion

		#region Membres de IObjetARestrictionSurEntite

		public void CompleteRestriction(CRestrictionUtilisateurSurType restriction)
		{
			CTypeEntreeAgenda typeEntree = TypeEntree;
			if ( typeEntree == null || (!typeEntree.DroitsLimites && !EntreePrivee ))
				return;
			
			//Applique les droits de cet utilisateur
			CDonneesActeurUtilisateur user = CUtilSession.GetUserForSession ( ContexteDonnee );
			if ( user == null || IsPriveeForUser )
			{
				restriction.RestrictionUtilisateur = ERestriction.ReadOnly;
				if ( EntreePrivee )
                    restriction.RestrictionUtilisateur = ERestriction.Hide;
				return;
			}
			else
			{
				if ( !TypeEntree.DroitsLimites )
					return;
				bool bCanModify = false;

				string strActeursGeres = user.Acteur.Id.ToString();

				//Si l'utilisateur correspond à un des liens
				foreach ( CRelationEntreeAgenda_ElementAAgenda rel in RelationsElementsAgenda )
				{
					if ( rel.RelationTypeEntree_TypeElement.DroitModification )
					{
						CObjetDonneeAIdNumerique elementLie = rel.ElementLie;
						if ( elementLie != null )
						{
							//Acteur geré
							if ( elementLie is CActeur && strActeursGeres.IndexOf(elementLie.Id.ToString()) >= 0 )
							{
								bCanModify = true;
								break;
							}

							//Utilisateur
							if ( elementLie is CDonneesActeurUtilisateur && elementLie.Id == user.Id )
							{
								bCanModify = true;
								break;
							}
						}
					}
				}
				if ( !bCanModify )
					restriction.RestrictionUtilisateur= (ERestriction)Math.Max ( (int)restriction.RestrictionGlobale, (int)ERestriction.ReadOnly );
			}
		}

		#endregion

		#region Membres de IElementALien

		public ITypeElementALien TypeElementALien
		{
			get
			{
				return TypeEntree;
			}
			set
			{
				TypeEntree = (CTypeEntreeAgenda)value;
			}
		}

		public CListeObjetsDonnees RelationsElements
		{
			get
			{
				return RelationsElementsAgenda;
			}
		}

		#endregion

		//---------------------------------
		public string IdAppliExterne
		{
			get
			{
				return "";
			}
		}

		//---------------------------------
		public string IdExterne
		{
			get
			{
				return "";
			}
		}


		#region IElementATypeStructurant<CTypeEntreeAgenda> Membres

		public CTypeEntreeAgenda ElementStructurant
		{
			get { return TypeEntree; }
		}

		public int IdTypeStructurant
		{
			get
			{
				return (int)Row[CTypeEntreeAgenda.c_champId];
			}
		}

		#endregion

        #region IObjetDonneeAutoReference Membres

        public string ChampParent
        {
            get { throw new NotImplementedException(); }
        }

        public string ProprieteListeFils
        {
            get { throw new NotImplementedException(); }
        }

        #endregion
    }
}
