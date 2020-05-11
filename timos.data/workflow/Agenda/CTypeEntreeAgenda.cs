using System;
using System.Data;
using System.Collections;

using sc2i.common;
using sc2i.data;
using sc2i.data.dynamic;
using sc2i.formulaire;
using sc2i.expression;
using sc2i.process;

namespace sc2i.workflow
{
	/// <summary>
    /// Type d'<see cref="CEntreeAgenda">entrée d'agenda</see>.<br/>
    /// Définit le comportement des entrées d'agenda de ce type.
	/// </summary>


    [sc2i.doccode.DocRefMenusOrMenuItems(timos.data.CDocLabels.c_iPlanif)]
    [Table(CTypeEntreeAgenda.c_nomTable, CTypeEntreeAgenda.c_champId, true)]
	[FullTableSync]
	[DynamicClass("Diary entry type")]
	[ObjetServeurURI("CTypeEntreeAgendaServeur")]
    //[Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_TypeEntreeAgenda_ID)]
    public class CTypeEntreeAgenda : CObjetDonneeAIdNumeriqueAuto, 
		IDefinisseurChampCustomRelationObjetDonnee, 
		IDefinisseurEvenements, IObjetALectureTableComplete,
		ITypeElementALien
	{
		public const string c_nomTable = "DIARY_ENTRY_TYPE";
		public const string c_champId = "DRYENTY_ID";
		public const string c_champLibelle = "DRYENTY_LABEL";
		public const string c_champDescription = "DRYENTY_DESCRIPTION";
		public const string c_champEtatAuto = "DRYENTY_AUTO_STATE";
		public const string c_champDroitLimites = "DRYENTY_LIMIT_RIGHTS";
        public const string c_champIsTache = "DRYENTY_TASK";
		
#if PDA
		public CTypeEntreeAgenda()
			:base ()
		{
		}
#endif
		/// <summary>
		/// //////////////////////////////////////////////
		/// </summary>
		/// <param name="ctx"></param>
		public CTypeEntreeAgenda( CContexteDonnee ctx )
			:base (ctx)
		{
		}

		/// //////////////////////////////////////////////
		public CTypeEntreeAgenda ( DataRow row )
			:base(row)
		{
		}

		/// //////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T("Diary Entry Type @1|344",Libelle);
			}
		}

		/// //////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champLibelle};
		}

		/// //////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
		}

		//---------------------------------------------
        /// <summary>
        /// Donne ou définit le libellé du type d'entrée d'agenda
        /// </summary>
		[TableFieldProperty(c_champLibelle, 128)]
		[DynamicField("Label")]
		public string Libelle
		{
			get
			{
				return (string)Row[c_champLibelle];
			}
			set
			{
				Row[c_champLibelle] = value;
			}
		}

		//---------------------------------------------------
        /// <summary>
        /// Donne ou définit la description du type d'entrée d'agenda
        /// </summary>
		[TableFieldProperty(c_champDescription, 1024)]
		[DynamicField("Description")]
		public string Description
		{
			get
			{
				return (string)Row[c_champDescription];
			}
			set
			{
				Row[c_champDescription] = value;
			}
		}

		/// //////////////////////////////////////////////
		/// <summary>
		/// Si VRAI, indique que les entrées d'agenda de ce type changent automatiquement d'état à leur création :
        /// <ul>
		/// <LI>"L'état passe à "En cours" lorsque la date de début de l'élément est dépassée.</LI>
		/// <LI>"L'état passe à "Terminé" lorsque la date de fin de l'élément est dépassée.</LI>
        /// </ul>
        /// </summary>
		[TableFieldProperty(c_champEtatAuto)]
		[DynamicField("Automatic state")]
		public bool EtatAuto
		{
			get
			{
				return ( bool )Row[c_champEtatAuto];
			}
			set
			{
				Row[c_champEtatAuto] = value;
			}
		}

		/// //////////////////////////////////////////////
		/// <summary>
		/// Si VRAI, indique que seuls les acteurs liés à l'entrée d'agenda sur un 
		/// rôle autorisant la modification peuvent modifier cette entrée d'agenda.
		/// </summary>
		[TableFieldProperty(c_champDroitLimites)]
		[DynamicField("Limited rights")]
		public bool DroitsLimites
		{
			get
			{
				return (bool)Row[c_champDroitLimites];
			}
			set
			{
				Row[c_champDroitLimites] = value;
			}
		}


		//-------------------------------------------------
        /// <summary>
        /// Retourne la liste des relations du type d'entrée d'agenda<br/>
        /// avec les champs personnalisés
        /// </summary>
		[RelationFille(typeof(CRelationTypeEntreeAgenda_ChampCustom), "Definisseur")]
		[DynamicChilds("Custom fields relations", typeof(CRelationTypeEntreeAgenda_ChampCustom))]
		public CListeObjetsDonnees RelationsChampsCustomListe
		{
			get
			{
				return GetDependancesListe ( CRelationTypeEntreeAgenda_ChampCustom.c_nomTable, c_champId );
			}
		}
		
		/// //////////////////////////////////////////////
		public IRelationDefinisseurChamp_ChampCustom[] RelationsChampsCustomDefinis
		{
			get
			{
				return (IRelationDefinisseurChamp_ChampCustom[])RelationsChampsCustomListe.ToArray(typeof(IRelationDefinisseurChamp_ChampCustom));
			}
		}

		//-------------------------------------------------------------------
        /// <summary>
        /// Retourne la liste des relations du type d'entrée d'agenda<br/>
        /// avec des formulaires personnalisés
        /// </summary>
		[RelationFille(typeof(CRelationTypeEntreeAgenda_Formulaire), "Definisseur")]
		[DynamicChilds("Forms relations", typeof(CRelationTypeEntreeAgenda_Formulaire))]
		public CListeObjetsDonnees RelationsFormulairesListe
		{
			get
			{
				return  GetDependancesListe(CRelationTypeEntreeAgenda_Formulaire.c_nomTable, CTypeEntreeAgenda.c_champId);
			}
		}
		//-------------------------------------------------------------------
		public IRelationDefinisseurChamp_Formulaire[] RelationsFormulaires
		{
			get
			{
				return  (IRelationDefinisseurChamp_Formulaire[])RelationsFormulairesListe.ToArray(typeof(IRelationDefinisseurChamp_Formulaire));
			}
		}

		/// //////////////////////////////////////////////
		public CChampCustom[] TousLesChampsAssocies
		{
			get
			{
				return CRecuperateurTousChampsAssociesADefinisseur.GetTousLesChampsAssociesA( this );
			}
		}

		//-------------------------------------------------------------
        /// <summary>
        /// Retourne la liste des relations du type d'entrée d'agenda<br/>
        /// avec des types d'éléments à agenda (exemple, avec des acteurs)
        /// </summary>
		[RelationFille(typeof(CRelationTypeEntreeAgenda_TypeElementAAgenda), "TypeEntree")]
		[DynamicChilds("Element type relations", typeof(CRelationTypeEntreeAgenda_TypeElementAAgenda))]
		public CListeObjetsDonnees RelationsTypeElementsAAgenda
		{
			get
			{
				return GetDependancesListe(CRelationTypeEntreeAgenda_TypeElementAAgenda.c_nomTable, CTypeEntreeAgenda.c_champId);
			}
		}

		/// //////////////////////////////////////////////
		public CListeObjetsDonnees TypesRelationsToElement
		{
			get
			{
				return RelationsTypeElementsAAgenda;
			}
		}

		/// //////////////////////////////////////////////
		public CListeObjetsDonnees Evenements
		{
			get
			{
				return CUtilDefinisseurEvenement.GetEvenementsFor ( this );
			}
		}

		/// //////////////////////////////////////////////
		public Type[] TypesCibleEvenement
		{
			get
			{
				return new Type[]{typeof(CEntreeAgenda)};
			}
		}

		//-------------------------------------------------------------------
		public CComportementGenerique[] ComportementsInduits
		{
			get
			{
				return CUtilDefinisseurEvenement.GetComportementsInduits ( this );
			}
		}

		//-------------------------------------------------------------------
        public CRoleChampCustom RoleChampCustomDesElementsAChamp
		{
			get
			{
				return CRoleChampCustom.GetRole(CEntreeAgenda.c_roleChampCustom);
			}
		}

        //-------------------------------------------------------------------
        /// <summary>
        /// Indique que les entrées de ce type sont des tâches
        /// (donc avec état d'avancement, prédecesseurs, et sous tâches)
        /// </summary>
        [TableFieldProperty(CTypeEntreeAgenda.c_champIsTache)]
        [DynamicField("Is task")]
        public bool IsTache
        {
            get
            {
                return (bool)Row[c_champIsTache];
            }
            set
            {
                Row[c_champIsTache] = value;
            }
        }

		/// <summary>
		/// Remplit les zones de base liées à ce type pour une entrée de Agenda
		/// </summary>
		/// <param name="entree"></param>
		/// <param name="element"></param>
		/// <returns></returns>
		public CResultAErreur InitEntreeManuelleFor ( CEntreeAgenda entree, CObjetDonneeAIdNumerique element )
		{
			CResultAErreur result = CResultAErreur.True;
			if ( entree == null )
			{
				result.EmpileErreur(I.T("Fill an empty Diary Entry is impossible|345"));
				return result;
			}
			if ( element == null )
			{
				result.EmpileErreur(I.T("Entry creation on null element is impossible|346"));
				return result;
			}
			entree.TypeEntree = this;
			foreach ( CRelationTypeEntreeAgenda_TypeElementAAgenda relation in RelationsTypeElementsAAgenda )
			{
				if ( relation.TypeElements == element.GetType() && relation.LienMaitre )
				{
					CRelationEntreeAgenda_ElementAAgenda newRel = new CRelationEntreeAgenda_ElementAAgenda(entree.ContexteDonnee);
					newRel.CreateNewInCurrentContexte();
					newRel.RelationTypeEntree_TypeElement = relation;
					newRel.ElementLie = element;
					newRel.EntreeAgenda = entree;
					return result;
				}
			}
			result.EmpileErreur(I.T("No relation on @1 type exists for Diary Entry Type @2|347",element.GetType() + Libelle));
			return result;
		}
	}
}
