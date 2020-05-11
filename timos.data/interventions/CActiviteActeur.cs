using System;
using System.Collections;
using System.Text;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using sc2i.data.dynamic;

using timos.securite;
using timos.acteurs;
using timos.data.version;
using tiag.client;
using sc2i.expression;

namespace timos.data
{
    /// <summary>
    /// Représente une entrée dans le suivi d'activité d'un Acteur.
    /// </summary>
	[DynamicClass("Member Activity")]
	[Table(CActiviteActeur.c_nomTable, CActiviteActeur.c_champId, true)]
	[ObjetServeurURI("CActiviteActeurServeur")]
	[AutoExec("Autoexec")]
    [sc2i.doccode.DocRefMenusOrMenuItems(CDocLabels.c_iIntervention)]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_SuiviActivite_ID)]
    [TiagClass(CActiviteActeur.c_nomTiag, "Id", true)]
    public class CActiviteActeur : CObjetDonneeAIdNumeriqueAuto,  
							       IObjetDonneeAChamps
	{

        public const string c_nomTable = "MEMBER_ACTIVITY";
        public const string c_nomTiag = "Member Activity";

        public const string c_champId = "MBRACT_ID";
        
        public const string c_champDate = "MBMACT_DATE";
        public const string c_champCommentaires = "MBMACT_COMMENT";
        public const string c_champDuree = "MBMACT_DURATION";

        public const string c_roleChampCustom = "MEMBER_ACTIVITY";

		/// /////////////////////////////////////////////
		public CActiviteActeur(CContexteDonnee contexte)
			: base(contexte)
		{
		}

		/// /////////////////////////////////////////////
		public CActiviteActeur(DataRow row)
			: base(row)
		{
		}

		//-------------------------------------------------------------------
		public static void Autoexec()
		{
			CRoleChampCustom.RegisterRole(c_roleChampCustom, "Member Activity", typeof(CActiviteActeur),typeof(CTypeActiviteActeur));
		}

        //-------------------------------------------------------------------
        public CRoleChampCustom RoleChampCustomAssocie
        {
            get { return CRoleChampCustom.GetRole(c_roleChampCustom); }
        }


		/// /////////////////////////////////////////////
		// Propriété de la classe 
		public override string DescriptionElement
		{
			get
			{
				return I.T( I.T("Member Activity|20001"));
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
            Date = DateTime.Today;
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[] { c_champDate };
		}



        //-----------------------------------------------------------
        /// <summary>
        /// Date de l'Activité
        /// </summary>
        [TableFieldProperty(c_champDate)]
        [DynamicField("Date")]
        [TiagField("Date")]
        public DateTime Date
        {
            get
            {
                return (DateTime)Row[c_champDate];
            }
            set
            {
                Row[c_champDate] = value;
            }
        }


		//-----------------------------------------------------------
		/// <summary>
		/// Commentaire lié à l'activité (Texte de 2000 cararctères maximum).
		/// </summary>
		[TableFieldProperty(c_champCommentaires, 2000)]
		[DynamicField("Comment")]
        [TiagField("Comment")]
		public string Commentaires
		{
			get
			{
				return (string)Row[c_champCommentaires];
			}
			set
			{
				Row[c_champCommentaires] = value;
			}
		}


		//-------------------------------------------------------------------
		/// <summary>
		/// Durée de l'Activité au format décimal (exemple pour 1H30min saisir 1,5 en décimal)
		/// </summary>
		[TableFieldProperty ( c_champDuree, NullAutorise = true )]
		[DynamicField("Duration")]
        [TiagField("Duration")]
		public double? Duree
		{
			get
			{
				return (double?)Row[c_champDuree, true];
			}
			set
			{
				Row[c_champDuree, true] = value;
			}
		}


        public void TiagSetTypeActiviteKeys(object[] lstCles)
        {
            CTypeActiviteActeur type = new CTypeActiviteActeur(ContexteDonnee);
            if (type.ReadIfExists(lstCles))
                TypeActiviteActeur = type;
        }
        //-------------------------------------------------------------------
        /// <summary>
        /// Le Type de l'Activite (obligatoire)
        /// </summary>
        [Relation(
            CTypeActiviteActeur.c_nomTable,
            CTypeActiviteActeur.c_champId,
            CTypeActiviteActeur.c_champId,
            true,
            false,
            false)]
        [DynamicField("Member activity type")]
        [TiagRelation(typeof(CTypeActiviteActeur), "TiagSetTypeActiviteKeys")]
        public CTypeActiviteActeur TypeActiviteActeur
        {
            get
            {
                return (CTypeActiviteActeur)GetParent(CTypeActiviteActeur.c_champId, typeof(CTypeActiviteActeur));
            }
            set
            {
                SetParent(CTypeActiviteActeur.c_champId, value);
            }
        }


		//---------------------------------------------------------------------
		/// <summary>
		/// Relations vers les Interventions. La saisie d'un compte rendu d'une Intervention induit la création automatique 
        /// d'un enregistrement d'une Activité d'Acteur dans son suivi d'activté.
		/// </summary>
		[RelationFille(typeof(CIntervention_ActiviteActeur), "ActiviteActeur")]
		[DynamicChilds("Relations interventions", typeof(CIntervention_ActiviteActeur))]
		public CListeObjetsDonnees RelationsInterventions
		{
			get
			{
				return GetDependancesListe(CIntervention_ActiviteActeur.c_nomTable, c_champId);
			}
		}


        public void TiagSetActeurKeys(object[] lstCles)
        {
            CActeur acteur = new CActeur(ContexteDonnee);
            if (acteur.ReadIfExists(lstCles))
                Acteur = acteur;
        }
        //-------------------------------------------------------------------
        /// <summary>
        /// L'Acteur concerné par l'Activité (obligatoire)
        /// </summary>
        [Relation(
            CActeur.c_nomTable,
            CActeur.c_champId,
            CActeur.c_champId,
            true,
            false,
            false)]
        [DynamicField("Member")]
        [TiagRelation(typeof(CActeur), "TiagSetActeurKeys")]
        public CActeur Acteur
        {
            get
            {
                return (CActeur)GetParent(CActeur.c_champId, typeof(CActeur));
            }
            set
            {
                SetParent(CActeur.c_champId, value);
            }
        }


        public void TiagSetSiteKeys(object[] lstCles)
        {
            CSite site = new CSite(ContexteDonnee);
            if (site.ReadIfExists(lstCles))
                Site = site;
        }
        //-------------------------------------------------------------------
        /// <summary>
        /// Le Site concerné par l'Activité (facultatif)
        /// </summary>
        [Relation(
            CSite.c_nomTable,
            CSite.c_champId,
            CSite.c_champId,
            false,
            false,
            false)]
        [DynamicField("Site")]
        [TiagRelation(typeof(CSite), "TiagSetSiteKeys")]
        public CSite Site
        {
            get
            {
                return (CSite)GetParent(CSite.c_champId, typeof(CSite));
            }
            set
            {
                SetParent(CSite.c_champId, value);
            }
        }


        //--------------------------------------------------------------------
        public string Libelle
        {
            get 
            {
                if (TypeActiviteActeur != null)
                    return TypeActiviteActeur.Libelle;
                return ""; 
            }
        }

		//--------------------------------------------------------------------
		//Empèche la suppression si toutes les CIntervention_ActiviteActeurs
		//n'ont pas été supprimées de la base
		protected override CResultAErreur MyCanDelete()
		{
			CResultAErreur result = base.MyCanDelete();
			if (!result)
				return result;
			CListeObjetsDonnees liste = RelationsInterventions;
			foreach ( CIntervention_ActiviteActeur rel in liste )
				if ( rel.Row.Row.RowState != DataRowState.Deleted )
				{
					result.EmpileErreur(I.T("Impossible to remove this activity because interventions are linked to it|30037"));
					return result;
				}
			return result;
		}



		#region IObjetDonneeAChamps Membres

		//----------------------------------------------------
		public CRelationElementAChamp_ChampCustom GetNewRelationToChamp()
		{
			return new CRelationActiviteActeur_ChampCustomValeur(ContexteDonnee);
		}

		//----------------------------------------------------
		public string GetNomTableRelationToChamps()
		{
			return CRelationActiviteActeur_ChampCustomValeur.c_nomTable;
		}

		//----------------------------------------------------
		public CListeObjetsDonnees GetRelationsToChamps(int nIdChamp)
		{
			CListeObjetsDonnees liste = RelationsChampsCustom;
			liste.InterditLectureInDB = true;
			liste.Filtre = new CFiltreData(CChampCustom.c_champId + " = @1", nIdChamp);
			return liste;
		}


		#endregion

		#region IElementAChamps Membres

		//----------------------------------------------------------------------------
		public IDefinisseurChampCustom[] DefinisseursDeChamps
		{
			get
			{
				return new IDefinisseurChampCustom[] { TypeActiviteActeur };
			}
		}

		//----------------------------------------------------------------------------
		public CChampCustom[] GetChampsHorsFormulaire()
		{
            if (TypeActiviteActeur == null)
                return new CChampCustom[0];

            ArrayList lst = new ArrayList();
            foreach (CRelationTypeActiviteActeur_ChampCustom rel in TypeActiviteActeur.RelationsChampsCustomDefinis)
                lst.Add(rel.ChampCustom);

            foreach (CRelationTypeActiviteActeur_Formulaire rel1 in TypeActiviteActeur.RelationsFormulaires)
                foreach (CRelationFormulaireChampCustom rel2 in rel1.Formulaire.RelationsChamps)
                    lst.Remove(rel2.Champ);

            return (CChampCustom[])lst.ToArray(typeof(CChampCustom));
		}

		//---------------------------------------------------------------------------
		public CFormulaire[] GetFormulaires()
		{
            return CUtilElementAChamps.GetFormulaires(this);
		}

		//----------------------------------------------------------------------------
        /// <summary>
        /// Donne la liste des relations entre l'activité et les valeurs de champs personnalisés
        /// </summary>
        [RelationFille(typeof(CRelationActiviteActeur_ChampCustomValeur), "ElementAChamps")]
        [DynamicChilds("Custom fields relations", typeof(CRelationActiviteActeur_ChampCustomValeur))]
        public CListeObjetsDonnees RelationsChampsCustom
		{
			get
			{
				return GetDependancesListe(CRelationActiviteActeur_ChampCustomValeur.c_nomTable, c_champId);
			}
		}

		#endregion

		#region IElementAVariables Membres

        //----------------------------------------------------------------------------
        public object GetValeurChamp(int nIdChamp)
        {
            return CUtilElementAChamps.GetValeurChamp(this, nIdChamp);
        }

        //-----------------------------------------------------------------------------
        public object GetValeurChamp(int nIdChamp, DataRowVersion version)
        {
            return CUtilElementAChamps.GetValeurChamp(this, nIdChamp, version);
        }

        public object GetValeurChamp(string strIdVariable)
        {
            return CUtilElementAChamps.GetValeurChamp(this, strIdVariable);
        }

        //-----------------------------------------------------------------------------
        public object GetValeurChamp(IVariableDynamique variable)
        {
            if (variable == null)
                return null;
            return GetValeurChamp(variable.IdVariable);
        }

        //---------------------------------------------
        public CResultAErreur SetValeurChamp(string strIdVariable, object valeur)
        {
            return CUtilElementAChamps.SetValeurChamp(this, strIdVariable, valeur);
        }

        //---------------------------------------------
        public CResultAErreur SetValeurChamp(IVariableDynamique variable, object valeur)
        {
            if (variable == null)
                return CResultAErreur.True;
            return SetValeurChamp(variable.IdVariable, valeur);
        }

        //-------------------------------------------------------------------
        public CResultAErreur SetValeurChamp(int nIdChamp, object valeur)
        {
            return CUtilElementAChamps.SetValeurChamp(this, nIdChamp, valeur);
        }

		#endregion



		#region IElementATypeStructurant<CTypeActiviteActeur> Membres

		public CTypeActiviteActeur ElementStructurant
		{
			get { return TypeActiviteActeur; }
		}

		#endregion



		//-------------------------------------------------------------------
		/// <summary>
		/// Donne le résumé de l'activité
		/// </summary>
		[Relation(
			CActiviteActeurResume.c_nomTable,
			CActiviteActeurResume.c_champId,
			CActiviteActeurResume.c_champId,
			false,
			true,
			true)]
		[DynamicField("Activity summary")]
		public CActiviteActeurResume ResumeActivite
		{
			get
			{
				return (CActiviteActeurResume)GetParent(CActiviteActeurResume.c_champId, typeof(CActiviteActeurResume));
			}
		}

		/// <summary>
		/// Permet d'associer un résumé à l'activite. Cette fonction
		/// n'est pas faite par ResumeActivite{set} pour qu'elle ne soit pas
		/// publiée dynamiquement. Ca permet de limiter son utilisation au programme.
		/// C'est le traitement avant sauvegarde du cActiviteActeur qui se charge de ce boulot
		/// </summary>
		/// <param name="resume"></param>
		public void SetResumeAssocie(CActiviteActeurResume resume)
		{
			if (resume.Date.Date != Date.Date)
				return;
			SetParent(CActiviteActeurResume.c_champId, resume);
		}

        /// <summary>
        /// Si l'activité est lié à un Résumé s'activités, retourne le flag readOnly du résumé
        /// Sinon l'activité n'est pas en ReadOnly
        /// </summary>
        public bool ReadOnly
        {
            get
            {
                if (ResumeActivite != null)
                    return ResumeActivite.ReadOnly;
                return false;                    
            }
        }

    }
}
