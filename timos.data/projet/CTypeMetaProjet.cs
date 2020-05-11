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
using timos.data;
using timos.data.projet.gantt;

namespace timos.data.projet
{
    /// <summary>
    /// Définit le type des <see cref="CCMetaProjet">meta-projets</see>.
    /// Le Type de meta-projet permet de donner un certain nombre d'attributs au meta-projet, notamment les Fiches (ou formulaires personnalisés) 
    /// à afficher sur la page d'édition du meta-projet. 
    /// </summary>
    [DynamicClass("Meta project type")]
    [Table(CTypeMetaProjet.c_nomTable, CTypeMetaProjet.c_champId, true)]
    [ObjetServeurURI("CTypeMetaProjetServeur")]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IngeProjet_ID)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_TypeProjet_ID)]
    public class CTypeMetaProjet : CObjetDonneeAIdNumeriqueAuto,
                                    IObjetALectureTableComplete,
                                    IDefinisseurChampCustomRelationObjetDonnee,
                                    IElementAEO
    {


        public const string c_nomTable = "META_PROJECT_TYPE";
        public const string c_champId = "MTPRJTP_ID";
        public const string c_champLibelle = "MTPRJTP_LABEL";
        public const string c_champDefaultTimeUnit = "MTPRJTP_DEFAULT_UNIT";
        public const string c_champDefaultTimePrecision = "MTPRJTP_DEFAULT_PRECISION";


		/// /////////////////////////////////////////////
		public CTypeMetaProjet( CContexteDonnee contexte)
			:base(contexte)
		{
        }

		/// /////////////////////////////////////////////
        public CTypeMetaProjet(DataRow row)
			:base(row)
		{
        }

        /// <summary>
        /// Description
        /// </summary>
        public override string DescriptionElement
        {
            get
            {
                return I.T("Meta-project type @1 |20136",Libelle);
            }
        }

        /// /////////////////////////////////////////////
        public override string[] GetChampsTriParDefaut()
        {
            return new string[] { c_champLibelle };
        }

        /// /////////////////////////////////////////////
        protected override void MyInitValeurDefaut()
        {
            DefaultTimeUnit = EGanttTimeUnit.Semaine;
        }

        /// /////////////////////////////////////////////
        [TableFieldProperty(c_champDefaultTimeUnit)]
        [DynamicField("Default time unit")]
        public int DefaultTimeUnitInt
        {
            get
            {
                return (int)Row[c_champDefaultTimeUnit];
            }
            set
            {
                Row[c_champDefaultTimeUnit] = value;
            }
        }

        /// /////////////////////////////////////////////
        public EGanttTimeUnit DefaultTimeUnit
        {
            get
            {
                try
                {
                    return (EGanttTimeUnit)DefaultTimeUnitInt;
                }
                catch
                {
                    return EGanttTimeUnit.Semaine;
                }
            }
            set
            {
                DefaultTimeUnitInt = (int)value;
            }
        }

        /// /////////////////////////////////////////////
        [TableFieldProperty(c_champDefaultTimePrecision)]
        [DynamicField("Default time precision")]
        public int DefaultTimePrecision
        {
            get
            {
                return (int)Row[c_champDefaultTimePrecision];
            }
            set
            {
                Row[c_champDefaultTimePrecision] = value;
            }
        }


        ////////////////////////////////////////////////
        /// <summary>
        /// Le nom du Type de Ressource (champ texte de 255 caractère au maximum).
        /// </summary>
        [TableFieldProperty(c_champLibelle, 255)]
        [DynamicField("Label")]
        [RechercheRapide]
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


        //---------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        [RelationFille(typeof(CMetaProjet), "TypeMetaProjet")]
        [DynamicChilds("Meta projects", typeof(CMetaProjet))]
        public CListeObjetsDonnees MetaProjets
        {
            get
            {
                return GetDependancesListe(CMetaProjet.c_nomTable, c_champId);
            }
        }

        #region IDefinisseurChampCustomRelationObjetDonnee Membres

        /// <summary>
        /// Définit la liste des relation avec les champs custom
        /// </summary>
        [RelationFille(typeof(CRelationTypeMetaProjet_ChampCustom), "Definisseur")]
        public CListeObjetsDonnees RelationsChampsCustomListe
        {
            get 
            {
                return GetDependancesListe(CRelationTypeMetaProjet_ChampCustom.c_nomTable, c_champId);
            }
        }

        /// <summary>
        /// Définit la liste des relation avec les formulaire custom
        /// </summary>
        [RelationFille(typeof(CRelationTypeMetaProjet_Formulaire), "Definisseur")]
        public CListeObjetsDonnees RelationsFormulairesListe
        {
            get
            {
                return GetDependancesListe(CRelationTypeMetaProjet_Formulaire.c_nomTable, c_champId);
            }
        }

        

        #endregion

        #region IDefinisseurChampCustom Membres

        /// /////////////////////////////////////////////
        public IRelationDefinisseurChamp_ChampCustom[] RelationsChampsCustomDefinis
        {
            get{
                return (IRelationDefinisseurChamp_ChampCustom[])RelationsChampsCustomListe.ToArray(typeof(IRelationDefinisseurChamp_ChampCustom));
            }
        }

        /// /////////////////////////////////////////////
        public IRelationDefinisseurChamp_Formulaire[] RelationsFormulaires
        {
            get
            {
                return (IRelationDefinisseurChamp_Formulaire[])RelationsFormulairesListe.ToArray(typeof(IRelationDefinisseurChamp_Formulaire));
            }
        }

        /// /////////////////////////////////////////////
        public CRoleChampCustom RoleChampCustomDesElementsAChamp
        {
            get
            {
                return CRoleChampCustom.GetRole(CMetaProjet.c_roleChampCustom);
            }
        }

        /// /////////////////////////////////////////////
        public CChampCustom[] TousLesChampsAssocies
        {
            get
            {
                Hashtable tableChamps = new Hashtable();
                FillHashtableChamps(tableChamps);
                CChampCustom[] liste = new CChampCustom[tableChamps.Count];
                int nChamp = 0;
                foreach (CChampCustom champ in tableChamps.Values)
                    liste[nChamp++] = champ;
                return liste;
            }
        }

        //-------------------------------------------------------------------
        /// <summary>
        /// Remplit une hashtable IdChamp->Champ
        /// avec tous les champs liés.(hiérarchique)
        /// </summary>
        /// <param name="tableChamps">HAshtable à remplir</param>
        private void FillHashtableChamps(Hashtable tableChamps)
        {
            foreach (IRelationDefinisseurChamp_ChampCustom relation in RelationsChampsCustomDefinis)
                tableChamps[relation.ChampCustom.Id] = relation.ChampCustom;
            foreach (IRelationDefinisseurChamp_Formulaire relation in RelationsFormulaires)
            {
                foreach (CRelationFormulaireChampCustom relFor in relation.Formulaire.RelationsChamps)
                    tableChamps[relFor.Champ.Id] = relFor.Champ;
            }
        }

        #endregion

        #region IElementAEO Membres

        //----------------------------------------------------------------------------------
        /// <summary>
        /// Codes complets (Full_system_code) de toutes les <see cref="CEntiteOrganisationnelle">entités organisationnelles</see> auxquelles est affecté le type de ressource<br/>
        /// <br/>
        /// <br/>
        /// Ces codes sont présentés sous la forme d'une chaîne de caractères<br/>
        /// Chaque code est encadré par deux caractères ~ (exemple : ~01051B~0201~061A0304~)
        /// </summary>
        [TableFieldProperty(CUtilElementAEO.c_champEO, 500)]
        [DynamicField("Organisational entities codes")]
        public string CodesEntitesOrganisationnelles
        {
            get
            {
                return (string)Row[CUtilElementAEO.c_champEO];
            }
            set
            {
                Row[CUtilElementAEO.c_champEO] = value;
            }
        }

        //-----------------------------------------------------------------------------------
        public IElementAEO[] DonnateursEO
        {
            get
            {
                return new IElementAEO[0] {  };
            }
        }

        public IElementAEO[] HeritiersEO
        {
            get
            {
                return (IElementAEO[])GetDependancesListe(CMetaProjet.c_nomTable, c_champId).ToArray(typeof(IElementAEO));
            }
        }

		//-----------------------------------------------------------------
		public CListeObjetsDonnees EntiteOrganisationnellesDirectementLiees
		{
			get
			{
				return CRelationElement_EO.GetEntitesOrganisationnellesDirectementLiees(this);
			}
		}

        //-----------------------------------------------------------------
        /// <summary>
        /// Attribue une nouvelle entité organisationnelle à l'élément
        /// </summary>
        /// <param name="nIdEO">Id de l'entité organisationnelle</param>
        /// <returns>retourne le <see cref="CResultAErreur">résultat</see></returns>
        [DynamicMethod(
            "Asigne a new Organisationnal Entity to the Element",
            "The Organisationnal Entity Identifier")]
        public CResultAErreur AjouterEO(int nIdEO)
        {
            return CUtilElementAEO.AjouterEO(this, nIdEO);
        }

        //-----------------------------------------------------------------
        /// <summary>
        /// Ote de l'élément une entité organisationnelle
        /// </summary>
        /// <param name="nIdEO">Id de l'entité à enlever</param>
        /// <returns>retourne le <see cref="CResultAErreur">résultat</see></returns>
        [DynamicMethod(
            "Remove an Organisationnal Entity from the Element",
            "The Organisationnal Entity Identifier")]
        public CResultAErreur SupprimerEO(int nIdEO)
        {
            return CUtilElementAEO.SupprimerEO(this, nIdEO);
        }

        //----------------------------------------------------------------
        /// <summary>
        /// Positionne toutes les entités organisationnelles de l'élément
        /// </summary>
        /// <param name="nIdsOE">Tableau d'Id des entités organisationnelles à associer</param>
        /// <returns>retourne le <see cref="CResultAErreur">résultat</see></returns>
        [DynamicMethod(
            "Set all Organizational Entities to the Element",
            "An array of Organizational Entity IDs")]
        public CResultAErreur SetAllOrganizationalEntities(int[] nIdsOE)
        {
            return CUtilElementAEO.SetAllOrganizationalEntities(this, nIdsOE);
        }

        #endregion

        #region IObjetARestrictionSurEntite Membres

        public void CompleteRestriction(CRestrictionUtilisateurSurType restriction)
        {
            CUtilElementAEO.CompleteRestriction(this, restriction);
        }

        #endregion
    }
}
