using System;
using System.Collections;
using System.Collections.Generic;
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
using sc2i.expression;

namespace timos.data
{
    /// <summary>
    /// Le résumé de l'activité d'un acteur représente le cumul des activités d'une journée
    /// </summary>
	[DynamicClass("Member Activity summary")]
	[Table(CActiviteActeurResume.c_nomTable, CActiviteActeurResume.c_champId, true)]
	[ObjetServeurURI("CActiviteActeurResumeServeur")]
	[AutoExec("Autoexec")]
    [sc2i.doccode.DocRefMenusOrMenuItems(CDocLabels.c_iIntervention)]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_SuiviActivite_ID)]
    public class CActiviteActeurResume : CObjetDonneeAIdNumeriqueAuto,  
							       IObjetDonneeAChamps,
									IDefinisseurChampCustom
	{

		public const string c_roleChampCustom = "MEMBER_ACTV_SUMRY";

        public const string c_nomTable = "MEMBER_ACTIVITY_SUMMARY";
        public const string c_champId = "MBRACTSUM_ID";
        
        public const string c_champDate = "MBMACTSUM_DATE";
		public const string c_champDuree = "MBMACTSUM_DURATION";
        public const string c_champReadOnly = "MBMACTSUM_READONLY";

		/// /////////////////////////////////////////////
		public CActiviteActeurResume(CContexteDonnee contexte)
			: base(contexte)
		{
		}

		/// /////////////////////////////////////////////
		public CActiviteActeurResume(DataRow row)
			: base(row)
		{
		}

		//-------------------------------------------------------------------
		public static void Autoexec()
		{
			CRoleChampCustom.RegisterRole(c_roleChampCustom, "Member Activity summary", typeof(CActiviteActeurResume), typeof(CActiviteActeurResume));
		}

		/// /////////////////////////////////////////////
		// Propriété de la classe 
		public override string DescriptionElement
		{
			get
			{
				return I.T("Member activity summary|20000");
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
            Date = DateTime.Today;
			Duree = 0;
            ReadOnly = false;
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[] { c_champDate };
		}



        //-----------------------------------------------------------
        /// <summary>
        /// Date du résumé d'Activité
        /// </summary>
        [TableFieldProperty(c_champDate)]
        [DynamicField("Date")]
        public DateTime Date
        {
            get
            {
                return (DateTime)Row[c_champDate];
            }
            set
            {
                Row[c_champDate] = value.Date;
            }
        }



		//-------------------------------------------------------------------
		/// <summary>
		/// Durée d'activité globale pour cette journée
		/// </summary>
		[TableFieldProperty ( c_champDuree )]
		[DynamicField("Duration")]
		public double Duree
		{
			get
			{
				return (double)Row[c_champDuree];
			}
			set
			{
				Row[c_champDuree] = value;
			}
		}



        //-------------------------------------------------------------------
        /// <summary>
        /// L'Acteur concerné par le résumé d'Activité. Champ obligatoire
        /// </summary>
        [Relation(
            CActeur.c_nomTable,
            CActeur.c_champId,
            CActeur.c_champId,
            true,
            false,
            false)]
        [DynamicField("Member")]
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




		#region IObjetDonneeAChamps Membres

		//----------------------------------------------------
		public CRelationElementAChamp_ChampCustom GetNewRelationToChamp()
		{
			return new CRelationActiviteActeurResume_ChampCustomValeur(ContexteDonnee);
		}

		//----------------------------------------------------
		public string GetNomTableRelationToChamps()
		{
			return CRelationActiviteActeurResume_ChampCustomValeur.c_nomTable;
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
				return new IDefinisseurChampCustom[] { this };
			}
		}

		//----------------------------------------------------------------------------
		public CChampCustom[] GetChampsHorsFormulaire()
		{
			return new CChampCustom[0];
		}

		//---------------------------------------------------------------------------
		public CFormulaire[] GetFormulaires()
		{
			CListeObjetsDonnees listeFormulaires = new CListeObjetsDonnees(ContexteDonnee, typeof(CFormulaire));
            listeFormulaires.Filtre = CFormulaire.GetFiltreFormulairesForRole(c_roleChampCustom);
                /*new CFiltreData(
				CFormulaire.c_champCodeRole + "=@1",
				c_roleChampCustom);*/
			return (CFormulaire[])listeFormulaires.ToArray(typeof(CFormulaire));
		}

		//----------------------------------------------------------------------------
        /// <summary>
        /// Donne la liste des relations du résumé d'activité d'acteur avec les valeurs de champs personnalisés
        /// </summary>
        [RelationFille(typeof(CRelationActiviteActeurResume_ChampCustomValeur), "ElementAChamps")]
        [DynamicChilds("Custom fields relations", typeof(CRelationActiviteActeurResume_ChampCustomValeur))]
        public CListeObjetsDonnees RelationsChampsCustom
		{
			get
			{
				return GetDependancesListe(CRelationActiviteActeurResume_ChampCustomValeur.c_nomTable, c_champId);
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



		#region IDefinisseurChampCustom Membres


		public IRelationDefinisseurChamp_ChampCustom[] RelationsChampsCustomDefinis
		{
			get { return new IRelationDefinisseurChamp_ChampCustom[0]; }
		}

		public class CRelationActiviteActeurResume_Formulaire : IRelationDefinisseurChamp_Formulaire
		{
			private IDefinisseurChampCustom m_definisseur = null;
			private CFormulaire m_formulaire = null;

			public CRelationActiviteActeurResume_Formulaire ( CActiviteActeurResume resume, CFormulaire formulaire )
			{
				m_definisseur = resume;
				m_formulaire = formulaire;
			}

			public IDefinisseurChampCustom Definisseur
			{
				get
				{
					return m_definisseur;
				}
				set
				{
					m_definisseur = value;
				}
			}

			public CFormulaire Formulaire
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

			#endregion
		}

		public IRelationDefinisseurChamp_Formulaire[] RelationsFormulaires
		{
			get { 
				ArrayList lst = new ArrayList();
				foreach ( CFormulaire formulaire in GetFormulaires())
					lst.Add ( new CRelationActiviteActeurResume_Formulaire ( this, formulaire ) );
				return ( IRelationDefinisseurChamp_Formulaire[] ) lst.ToArray ( typeof(IRelationDefinisseurChamp_Formulaire));
			}
		}

        public CRoleChampCustom RoleChampCustomDesElementsAChamp
		{
			get { return CRoleChampCustom.GetRole ( c_roleChampCustom) ;}
		}

        public CRoleChampCustom RoleChampCustomAssocie
        {
            get { return CRoleChampCustom.GetRole(c_roleChampCustom); }
        }

		public CChampCustom[] TousLesChampsAssocies
		{
			get
			{ 
				List<CChampCustom> lst = new List<CChampCustom>();
                foreach ( CFormulaire formulaire in GetFormulaires() )
                    foreach (CRelationFormulaireChampCustom rel in formulaire.RelationsChamps)
                        lst.Add(rel.Champ);
                return lst.ToArray();
			}
		}


        /// <summary>
        /// Donne la liste des activités concernées par ce résumé
        /// </summary>
		[RelationFille ( typeof(CActiviteActeur), "ResumeActivite")]
		[DynamicChilds("Activities", typeof(CActiviteActeur))]
		public CListeObjetsDonnees Activites
		{
			get
			{
				return GetDependancesListe(CActiviteActeur.c_nomTable, c_champId);
			}
		}


		/// <summary>
		/// Recalcule le cumul de l'activité
		/// </summary>
		[DynamicMethod("Recalc member activity for that summary") ]
		public void Recalc()
		{
			Duree = 0;
			foreach (CActiviteActeur activite in Activites)
			{
				if ( activite.Row.RowState != DataRowState.Deleted &&  activite.Duree != null )
					Duree += (double)activite.Duree;
			}
		}


        //-----------------------------------------------------------
        /// <summary>
        /// Indicateur d'accès en lecture seule
        /// </summary>
        [TableFieldProperty(c_champReadOnly)]
        [DynamicField("Read Only")]
        public bool ReadOnly
        {
            get
            {
                return (bool)Row[c_champReadOnly];
            }
            set
            {
                Row[c_champReadOnly] = value;
            }
        }


	}
}
