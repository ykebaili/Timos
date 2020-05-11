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
using sc2i.expression;

namespace timos.data
{
    /// <summary>
    /// Le Type de Ressource fournit des caractéristiques et des options aux <see cref="CRessourceMaterielle">Ressources</see>. 
    /// Les Types de Ressources sont des entités hiérarchiques. Un Type de Ressources peut avoir plusieurs Types fils.<br/>
    /// Les types de ressources sont associés aux types de contrainte et indiquent pour un type de contrainte donné<br/>
    /// quels sont les types de ressources capables de lever le type de contrainte.
    /// </summary>
    [sc2i.doccode.DocRefMenusOrMenuItems(CDocLabels.c_iContrainte)]
    [DynamicClass("Resource type")]
    [Table(CTypeRessource.c_nomTable, CTypeRessource.c_champId, true)]
    [ObjetServeurURI("CTypeRessourceServeur")]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_TypeRessource_ID)]
    [AutoExec("Autoexec")]
    public class CTypeRessource : CObjetHierarchique,
                                  IObjetDonneeAChamps,
                                  IObjetALectureTableComplete,
                                  IDefinisseurChampCustomRelationObjetDonnee,
                                  IElementAEO
    {


        public const string c_nomTable = "RESOURCE_TYPE";
        public const string c_champId = "RESOURCE_TYPE_ID";

        public const string c_champLibelle = "RESOURCE_TYPE_LABEL";
        public const string c_champCommentaire = "RES_TYPE_COMMENTS";
        public const string c_champOptionDeplacable = "RESTYPE_MOVEABLE_OPTION";
        public const string c_champEmplacementSitePossible = "RESTP_POSS_SITE_PLACE";
        public const string c_champEmplacementActeurPossible = "RESTP_POSS_MEMBER_PLACE";
        public const string c_champOptionAfficherAgenda = "RESTP_DISP_AGENDA_OPTION";

        public const string c_champCodeSystemePartiel = "RESTP_PATIAL_SYS_CODE";
        public const string c_champCodeSystemeComplet = "RESTP_FULL_SYS_CODE";
        public const string c_champNiveau = "RESTP_LEVEL";
        public const string c_champIdParent = "RESTP_PARENT_ID";

        public const string c_roleChampCustom = "RESOURCE_TYPE";

		/// /////////////////////////////////////////////
		public CTypeRessource( CContexteDonnee contexte)
			:base(contexte)
		{
        }

		/// /////////////////////////////////////////////
        public CTypeRessource(DataRow row)
			:base(row)
		{
        }

        //-------------------------------------------------------------------
        public static void Autoexec()
        {
            CRoleChampCustom.RegisterRole(c_roleChampCustom, "Resource type", typeof(CTypeRessource), typeof(CDefinisseurChampsPourTypeSansDefinisseur));
        }

        /// <summary>
        /// Description
        /// </summary>
        public override string DescriptionElement
        {
            get
            {
                return I.T("Resource type @1 |250",Libelle);
            }
        }

        public override string[] GetChampsTriParDefaut()
        {
            return new string[] { c_champLibelle };
        }

        protected override void MyInitValeurDefaut()
        {
            base.MyInitValeurDefaut();
            OptionDeplacable = true;
            EmplacementActeurPossible = true;
            EmplacementSitePossible = true;
            OptionAfficherAgenda = true;
        }


        ////////////////////////////////////////////////
        /// <summary>
        /// Le nom du Type de Ressource (champ texte de 255 caractère au maximum).
        /// </summary>
        [TableFieldProperty(c_champLibelle, 255)]
        [DynamicField("Label")]
        [RechercheRapide]
        public override string Libelle
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

        ////////////////////////////////////////////////
        /// <summary>
        /// Champ commentaire de 1024 caractères au maximum.
        /// </summary>
        [TableFieldProperty(c_champCommentaire, 1024)]
        [DynamicField("Comment")]
        public string Commentaire
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


        //----------------------------------------------------
        /// <summary>
        /// Le Type de Ressource parent dans la hiérarchie
        /// </summary>
        [Relation(
            c_nomTable,
            c_champId,
            c_champIdParent,
            false,
            false)]
        [DynamicField("Parent resource type")]
        public CTypeRessource TypeRessourceParent
        {
            get
            {
                return (CTypeRessource)ObjetParent;
            }
            set
            {
                ObjetParent = value;
            }
        }

        //----------------------------------------------------
        /// <summary>
        /// Retourne la liste des Types de Ressources fils dans la hiérarchie
        /// </summary>
        [RelationFille(typeof(CTypeRessource), "TypeRessourceParent")]
        [DynamicChilds("Child Resource types", typeof(CTypeRessource))]
        public CListeObjetsDonnees TypesRessourcesFils
        {
            get
            {
                return ObjetsFils;
            }
        }

        //-------------------------------------------------------------------------
        /// <summary>
        /// Renvoie la liste des relations avec les Types de Contraintes.<br/>
        /// Ce sont les Types de Contraintes que ce Type de Ressource peut lever.
        /// </summary>
        [RelationFille(typeof(CRelationTypeContrainte_TypeRessource), "TypeRessource")]
        [DynamicChilds("Constraint types relations", typeof(CRelationTypeContrainte_TypeRessource))]
        public CListeObjetsDonnees RelationsTypesContraintesListe
        {
            get
            {
                return GetDependancesListe(CRelationTypeContrainte_TypeRessource.c_nomTable, c_champId);
            }
        }


        public CTypeContrainte[] GetTousLesTypesContraintes()
        {
            ArrayList liste = new ArrayList();
            // Ajoute ces propres types de Contraintes
            foreach (CRelationTypeContrainte_TypeRessource rel in this.RelationsTypesContraintesListe)
            {
                liste.Add(rel.TypeContrainte);
            }
            // Ajoute les Types de Contraintes de son Parent
            if (this.TypeRessourceParent != null)
            {
                liste.AddRange( this.TypeRessourceParent.GetTousLesTypesContraintes());
            }

            return (CTypeContrainte[])liste.ToArray(typeof(CTypeContrainte));
        }


        //------------------------------------------------------------------------
        /// <summary>
        /// Option booléenne qui définit le caractère déplaçable des Ressources de ce Type.<br/>
        /// Si FAUX, une ressource de ce type restera toujours à l'emplacement où elle a été créée<br/>
        /// (donc sur le site ou l'acteur)
        /// </summary>
        [TableFieldProperty(c_champOptionDeplacable)]
        [DynamicField("Option : Moveable")]
        public bool OptionDeplacable
        {
            get
            {
                return (bool)Row[c_champOptionDeplacable];
            }
            set
            {
                Row[c_champOptionDeplacable] = value;
            }
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// Option booléenne qui indique si Les Ressources de ce Type peuvent être exploitées sur un Site
        /// </summary>
        [TableFieldProperty(c_champEmplacementSitePossible)]
        [DynamicField("Can be place on site")]
        public bool EmplacementSitePossible
        {
            get
            {
                return (bool)Row[c_champEmplacementSitePossible];
            }
            set
            {
                Row[c_champEmplacementSitePossible] = value;
            }
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// Option booléenne qui indique si Les Ressources de ce Type peuvent être exploitées sur un Acteur
        /// </summary>
        [TableFieldProperty(c_champEmplacementActeurPossible)]
        [DynamicField("Can be placed at member")]
        public bool EmplacementActeurPossible
        {
            get
            {
                return (bool)Row[c_champEmplacementActeurPossible];
            }
            set
            {
                Row[c_champEmplacementActeurPossible] = value;
            }
        }


        //-----------------------------------------------------------------------------
        /// <summary>
        /// Option booléenne qui indique si les Ressources de ce Type seront gérées par un Agenda.<br/> 
        /// Le cas échéant, un Agenda sera affiché sur la fenêtre d'édition de la Ressource.<br/>
        /// Permet de planifier les ressources de ce type dans le module de planification<br/>
        /// des interventions.
        /// </summary>
        [TableFieldProperty(c_champOptionAfficherAgenda)]
        [DynamicField("Display diary")]
        public bool OptionAfficherAgenda
        {
            get
            {
                return (bool)Row[c_champOptionAfficherAgenda];
            }
            set
            {
                Row[c_champOptionAfficherAgenda] = value;
            }
        }


        #region IDefinisseurChampCustomRelationObjetDonnee Membres

        /// <summary>
        /// Définit la liste des relation avec les champs custom
        /// </summary>
        [RelationFille(typeof(CRelationTypeRessource_ChampCustom), "Definisseur")]
        public CListeObjetsDonnees RelationsChampsCustomListe
        {
            get 
            {
                return GetDependancesListe(CRelationTypeRessource_ChampCustom.c_nomTable, c_champId);
            }
        }

        /// <summary>
        /// Définit la liste des relation avec les formulaire custom
        /// </summary>
        [RelationFille(typeof(CRelationTypeRessource_Formulaire), "Definisseur")]
        public CListeObjetsDonnees RelationsFormulairesListe
        {
            get
            {
                return GetDependancesListe(CRelationTypeRessource_Formulaire.c_nomTable, c_champId);
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
                return CRoleChampCustom.GetRole(CRessourceMaterielle.c_roleChampCustom);
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
                
        #region CObjetHierarchique Membres

        public override int NbCarsParNiveau
        {
            get { return 2; }
        }

        public override string ChampCodeSystemePartiel
        {
            get { return c_champCodeSystemePartiel; }
        }

        public override string ChampCodeSystemeComplet
        {
            get { return c_champCodeSystemeComplet; }
        }

        public override string ChampNiveau
        {
            get { return c_champNiveau; }
        }

        public override string ChampLibelle
        {
            get { return c_champLibelle; }
        }

        public override string ChampIdParent
        {
            get { return c_champIdParent; }
        }


        //----------------------------------------------------
        /// <summary>
        /// Code système propre au type de ressource.<br/>
        /// Ce code est exprimé sur 2 caractères alphanumériques
        /// </summary>
        [TableFieldProperty(c_champCodeSystemePartiel, 2)]
        [DynamicField("Partial system code")]
        public override string CodeSystemePartiel
        {
            get
            {
                string strVal = "";
                if (Row[c_champCodeSystemePartiel] != DBNull.Value)
                    strVal = (string)Row[c_champCodeSystemePartiel];
                strVal = strVal.Trim().PadLeft(2, '0');
                return (string)Row[c_champCodeSystemePartiel];
            }
        }

        //----------------------------------------------------
        /// <summary>
        /// Code système complet du type de ressource. Ce code système est<br/>
        /// constitué du code système complet du type de ressource parente<br/>
        /// concaténé avec le code système propre du type de ressource.<br/>
        /// Exemple : TPR_GRDPARENTE -> TPR_PARENTE -> TPR_FILLE<br/>
        /// si le code de TPR_GRDPARENTE est 01, le code de TPR_PARENTE est 03 et<br/>
        /// et le code propre de TPR_FILLE est 08, le code système complet<br/>
        /// de TPR_FILLE est 010308.
        /// </summary>
        [TableFieldProperty(c_champCodeSystemeComplet, 400)]
        [DynamicField("Full system code")]
        public override string CodeSystemeComplet
        {
            get
            {
                return (string)Row[c_champCodeSystemeComplet];
            }
        }

        //----------------------------------------------------
        /// <summary>
        /// Niveau du type de ressource dans la hiérarchie des types (nombre de parents).<br/>
        /// Exemple : TPR_GRDPARENTE -> TPR_PARENTE -> TPR_FILLE<br/>
        /// TPR_GRDPARENTE a pour niveau 0, TPR_PARENTE a pour niveau 1<br/>
        /// (1 parent en remontant la hiérarchie), TPR_FILLE a pour niveau 2<br/>
        /// (2 parents en remontant la hiérarchie)
        /// </summary>
        [TableFieldProperty(c_champNiveau)]
        [DynamicField("Level")]
        public override int Niveau
        {
            get
            {
                return (int)Row[c_champNiveau];
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
                return new IElementAEO[] { TypeRessourceParent };
            }
        }

        public IElementAEO[] HeritiersEO
        {
            get
            {
                return (IElementAEO[])GetDependancesListe(CRessourceMaterielle.c_nomTable, c_champId).ToArray(typeof(IElementAEO));
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
            "Asigne a new Organizational Entity to the Element",
            "The Organizational Entity Identifier")]
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
            "Remove an Organizational Entity from the Element",
            "The Organizational Entity Identifier")]
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

        public IDefinisseurChampCustom[] DefinisseursDeChamps
        {
            get
            {
                return new IDefinisseurChampCustom[]{
                    new CDefinisseurChampsPourTypeSansDefinisseur(
                        ContexteDonnee, 
                        CRoleChampCustom.GetRole(CTypeRessource.c_roleChampCustom) )};
            }
        }

        public CRelationElementAChamp_ChampCustom GetNewRelationToChamp()
        {
            return new CRelationTypeRessource_ChampCustomValeur(ContexteDonnee);
        }

        [RelationFille(typeof(CRelationTypeRessource_ChampCustomValeur), "ElementAChamps")]
        public CListeObjetsDonnees RelationsChampsCustom
        {
            get
            {
                return GetDependancesListe(CRelationTypeRessource_ChampCustomValeur.c_nomTable, c_champId);
            }
        }

        public CRoleChampCustom RoleChampCustomAssocie
        {
            get
            {
                return CRoleChampCustom.GetRole(CTypeRessource.c_roleChampCustom);
            }
        }

        public string GetNomTableRelationToChamps()
        {
            return CRelationTypeRessource_ChampCustomValeur.c_nomTable;
        }

        public CListeObjetsDonnees GetRelationsToChamps(int nIdChamp)
        {
            CListeObjetsDonnees liste = RelationsChampsCustom;
            liste.InterditLectureInDB = true;
            liste.Filtre = new CFiltreData(CChampCustom.c_champId + " = @1", nIdChamp);
            return liste;
        }

        public CChampCustom[] GetChampsHorsFormulaire()
        {
            return new CChampCustom[0];
        }

        public CFormulaire[] GetFormulaires()
        {
            return CUtilElementAChamps.GetFormulaires(this);
        }

        //-------------------------------------------------------------------
        public virtual object GetValeurChamp(IVariableDynamique champ)
        {
            return GetValeurChamp(champ.IdVariable);
        }

        //-------------------------------------------------------------------
        public virtual object GetValeurChamp(string strIdChamp)
        {
            return CUtilElementAChamps.GetValeurChamp(this, strIdChamp);
        }

        //-------------------------------------------------------------------
        public virtual object GetValeurChamp(int idChamp)
        {
            return GetValeurChamp(idChamp, DataRowVersion.Default);
        }

        //-------------------------------------------------------------------
        public virtual object GetValeurChamp(int idChamp, DataRowVersion version)
        {
            return CUtilElementAChamps.GetValeurChamp(this, idChamp, version);
        }

        //-------------------------------------------------------------------
        public virtual CResultAErreur SetValeurChamp(IVariableDynamique champ, object valeur)
        {
            return SetValeurChamp(champ.IdVariable, valeur);
        }

        //-------------------------------------------------------------------
        public virtual CResultAErreur SetValeurChamp(string strIdChamp, object valeur)
        {
            return CUtilElementAChamps.SetValeurChamp(this, strIdChamp, valeur);
        }

        //-------------------------------------------------------------------
        public CResultAErreur SetValeurChamp(int idChamp, object valeur)
        {
            return CUtilElementAChamps.SetValeurChamp(this, idChamp, valeur);
        }
    }
}
