using System;
using System.Collections;
using System.Data;
using System.Collections.Generic;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using sc2i.data.dynamic;
using sc2i.process;
using sc2i.expression;
using tiag.client;

namespace timos.data
{
	/// <summary>
    /// Le Type de Phase permet de définir, pour les <see cref="CPhaseTicket">phases</see> de ce type :
    /// <ul>
    /// <li>Un formulaire personnalisé</li>
    /// <li>Une liste de <see cref="CTypeOperation">types d'opérations</see></li>
    /// <li>Les <see cref="CTypeIntervention">types d'Interventions</see> possibles</li>
    /// <li>Les <see cref="CActeur">contacts</see> possibles</li>
    /// </ul>
	/// </summary>
	[DynamicClass("Ticket phase type")]
	[Table(CTypePhase.c_nomTable, CTypePhase.c_champId, true)]
	[FullTableSync]
	[ObjetServeurURI("CTypePhaseServeur")]
	[Unique(false, "This Phase Type label is already used", CTypePhase.c_champLibelle)]
    [sc2i.doccode.DocRefMenusOrMenuItems(CDocLabels.c_iTicket)]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersCorrectives_ID)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_ParamTickets_ID)]
    [TiagClass(CTypePhase.c_nomTiag, "Id", true)]
    public class CTypePhase : CObjetDonneeAIdNumeriqueAuto,
		IObjetALectureTableComplete,
		IDefinisseurChampCustom,
		ITypeElementAContacts,
        IDefinisseurEvenements
	{
        public const string c_nomTiag = "Ticket Phase Type";
        public const string c_nomTable = "TICKET_PHASE_TYPE";

		public const string c_champId = "TKTPHTYP_ID";
		public const string c_champLibelle = "TPPHTCKT_LABEL";
		public const string c_champCacheFormule = "PHATYP_HIDDEN_ENDFORMULE";
        public const string c_champFormule = "PHATYP_ENDFORMULE";
        public const string c_champMessageErreurFormule = "PHATYP_MSG_ERR_FORMULE";

		public const string c_champTtesInter = "TKTPHTYP_ALLSINTER";

		/// /////////////////////////////////////////////
		public CTypePhase(CContexteDonnee contexte)
			: base(contexte)
		{
		}

		/// /////////////////////////////////////////////
		public CTypePhase(DataRow row)
			: base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T( "Phase Type for Ticket @1",Libelle);
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[] { c_champLibelle };
		}



		///////////////////////////////////////////////
		/// <summary>
		/// Le libellé du Type de Phase
		/// </summary>
        [TableFieldProperty(c_champLibelle, 100)]
		[DynamicField("Label")]
        [DescriptionField]
        [TiagField("Label")]
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

		/////////////////////////////////////////////////////
        /// <summary>
        /// Si VRAI, Indique que tous les types d'interventions sont possibles sur ce Type de Phase.<br/>
        /// Dans ce cas, il n'est pas nécessaire de préciser une liste de types d'interventions.<br/>
        /// </summary>
		[TableFieldProperty(c_champTtesInter)]
		[DynamicField("All interventions")]
        [TiagField("All interventions")]
		public bool ToutesInterventions
		{
			get
			{
				return (bool)Row[c_champTtesInter];
			}
			set
			{
				Row[c_champTtesInter] = value;
			}
		}


		//-------------------------------------------------------------------
		/// <summary>
		/// Le Formulaire associé au Type de Phase
		/// </summary>
		[Relation(
			CFormulaire.c_nomTable,
			CFormulaire.c_champId,
			CFormulaire.c_champId,
			false,
			false,
			false)]
		[DynamicField("Form")]
		public CFormulaire Formulaire
		{
			get
			{
				return (CFormulaire)GetParent(CFormulaire.c_champId, typeof(CFormulaire));
			}
			set
			{
				SetParent(CFormulaire.c_champId, value);
			}
		}


		//-------------------------------------------------------------------
		/// <summary>
		/// Retourne la liste des relations avec les Types d'Intervention possibles sur ce type de phase
		/// </summary>
		[RelationFille(typeof(CRelationTypePhaseTicket_TypeIntervention), "TypePhase")]
		[DynamicChilds("Intervention types relations", typeof(CRelationTypePhaseTicket_TypeIntervention))]
		public CListeObjetsDonnees RelationTypesIntervention
		{
			get 
            {
                return GetDependancesListe(CRelationTypePhaseTicket_TypeIntervention.c_nomTable, c_champId); 
            }
		}




        //-------------------------------------------------------------------
        /// <summary>
        /// Obtient ou définit le <see cref="CProfilElement">Profil</see> de l'Utilisateur pouvant prendre en charge le Ticket lorsque 
        /// sa Phase en cours est de ce Type de Phase
        /// </summary>
        [Relation(
            CProfilElement.c_nomTable,
            CProfilElement.c_champId,
            CProfilElement.c_champId,
            false,
            false,
            false)]
        [DynamicField("Member in Charge of Ticket Profile")]
        public CProfilElement ProfilResponsableTicket
        {
            get
            {
                return (CProfilElement)GetParent(CProfilElement.c_champId, typeof(CProfilElement));
            }
            set
            {
                SetParent(CProfilElement.c_champId, value);
            }
        }

	
		#region IDefinisseurChampCustom Membres


		public IRelationDefinisseurChamp_ChampCustom[] RelationsChampsCustomDefinis
		{
			get { return new IRelationDefinisseurChamp_ChampCustom[0]; }
		}

		public IRelationDefinisseurChamp_Formulaire[] RelationsFormulaires
		{
			get
			{
				if (Formulaire != null)
				{
					CRelationDefinisseurChamp_FormulaireStatic rel = new CRelationDefinisseurChamp_FormulaireStatic(this, Formulaire);
					return new IRelationDefinisseurChamp_Formulaire[] { rel };
				}
				return new IRelationDefinisseurChamp_Formulaire[0];
			}
		}

        public CRoleChampCustom RoleChampCustomDesElementsAChamp
		{
			get { return CRoleChampCustom.GetRole(CPhaseTicket.c_roleChampCustom); }
		}

		public CChampCustom[] TousLesChampsAssocies
		{
			get
			{
				List<CChampCustom> lst = new List<CChampCustom>();
				if (Formulaire != null)
					foreach (CRelationFormulaireChampCustom rel in Formulaire.RelationsChamps)
						lst.Add(rel.Champ);
				return lst.ToArray();
			}
		}

		#endregion


        //------------------------------------------------------------------------------------
        /// <summary>
        /// Formule à saisir. Cette Formaule sera évaluée et doit retourner VRAI pour pouvoir clore la phase en 
        /// cours et passer à la phase suivante du processus de résolution
        /// </summary>
        [TableFieldProperty(c_champFormule, 2000)]
        public string FormuleConditionSortieString
        {
            get
            {
                return (string)Row[c_champFormule];
            }
            set
            {
                Row[c_champFormule] = value;
            }
        }

        
		//-------------------------------------------------------------------------------------
		/// <summary>
		/// Le message d'erreur qui sera affiché si la Formule de condition de sortie retourne FAUX (pour une phase de ce type).
        /// S'il n'y a pas de message défini, un message d'erreur par défaut sera affiché.
		/// </summary>
		[TableFieldProperty ( c_champMessageErreurFormule, 400 )]
		[DynamicField("Formula error message")]
		public string MessageErreurFormule
		{
			get
			{
				return (string)Row[c_champMessageErreurFormule];
			}
			set
			{
				Row[c_champMessageErreurFormule] = value;
			}
		}

        //------------------------------------------------------------------------
        /// <summary>
        /// Donne ou définit la formule à évaluer comme conditionn de sortie pour une phase de ce type.<br/>
        /// Cette Formaule doit retourner VRAI pour pouvoir clore la phase en cours<br/> 
        /// et passer à la phase suivante du processus de résolution
        /// </summary>
        [TableFieldProperty(c_champCacheFormule, IsInDb = false)]
        [DynamicField("Phase closing condition formula")]
        public C2iExpression FormuleConditionSortie
        {
            get
			{
                if (Row[c_champCacheFormule] == DBNull.Value)
                {
                    C2iExpression expression = C2iExpression.FromPseudoCode(FormuleConditionSortieString);
                    if (expression == null)
                        expression = new C2iExpressionVrai();
                    CContexteDonnee.ChangeRowSansDetectionModification(Row.Row, c_champCacheFormule, expression);
                }
                return (C2iExpression)Row[c_champCacheFormule];
            }
            set
            {
                if (value == null)
                    FormuleConditionSortieString = "";
                else
                    FormuleConditionSortieString = C2iExpression.GetPseudoCode(value);
                CContexteDonnee.ChangeRowSansDetectionModification(Row.Row, c_champCacheFormule, DBNull.Value);
            }
        }

		#region ITypeElementAContacts
		//-------------------------------------------------------------------
		/// <summary>
		/// Profils retournant des Acteurs
		/// </summary>
		[RelationFille(typeof(CActeursSelonProfil), "TypePhase")]
		[DynamicChilds("Members profiles", typeof(CActeursSelonProfil))]
		public List<CActeursSelonProfil> ProfilsContacts
		{
			get
			{
				List<CActeursSelonProfil> lstret = new List<CActeursSelonProfil>();
				CListeObjetsDonnees lst = GetDependancesListe(CActeursSelonProfil.c_nomTable, c_champId);
				foreach (CObjetDonnee obj in lst)
					lstret.Add((CActeursSelonProfil)obj);

				return lstret;
			}
		}

		//--------------------------------------------------
        /// <summary>
        /// Modèle du texte utilisé pour afficher la liste des contacts associés à une phase de ce type
        /// </summary>
		[RelationAttribute(
			CModeleTexte.c_nomTable,
			CModeleTexte.c_champId,
			CModeleTexte.c_champId,
			false,
			false,
			false)]
		[DynamicField("Text model of possible actors")]
		public CModeleTexte ModeleTexteContacts
		{
			get
			{
				return (CModeleTexte)GetParent(CModeleTexte.c_champId, typeof(CModeleTexte));
			}
			set
			{
				SetParent(CModeleTexte.c_champId, value);
			}
		}

        //---------------------------------------------------------------------------------
		public Type TypeDesElementsAContacts
		{
			get
			{
				return typeof(CPhaseTicket);
			}
		}

		#endregion

        #region IDefinisseurEvenements Membres

        //---------------------------------------------------------
        public CComportementGenerique[] ComportementsInduits
        {
            get
            {
                return CUtilDefinisseurEvenement.GetComportementsInduits(this);
            }
        }

        //---------------------------------------------------------
        public CListeObjetsDonnees Evenements
        {
            get
            {
                return CUtilDefinisseurEvenement.GetEvenementsFor(this);
            }
        }

        //---------------------------------------------------------
        public Type[] TypesCibleEvenement
        {
            get
            {
                return new Type[] { typeof(CPhaseTicket) };
            }
        }

        #endregion


        //---------------------------------------------
        /// <summary>
        /// Retourne la liste des relations avec les types d'opérations possibles
        /// </summary>
        [RelationFille(typeof(CTypePhase_TypeOperation), "TypePhase")]
        [DynamicChilds("Operation type relations", typeof(CTypePhase_TypeOperation))]
        public CListeObjetsDonnees RelationsTypesOperations
        {
            get
            {
                return GetDependancesListe(CTypePhase_TypeOperation.c_nomTable, c_champId);
            }
        }
    }
}
