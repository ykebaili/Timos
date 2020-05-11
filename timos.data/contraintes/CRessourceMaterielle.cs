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

using timos.acteurs;
using timos.securite;
using timos.data.version;
using sc2i.expression;

namespace timos.data
{
    /// <summary>
    /// Les Ressources Materielles sont des moyens utilisés pour lever une ou plusieurs <see cref="CContrainte">Contraintes</see> dans un Processus métier.<br/>
	/// peuvent être localisées dans un des emplacements suivant :<br/>
	/// <list type="bullet">
	///		<item><term><see cref="CSite">Sites</see></term></item>
	///		<item><term><see cref="CActeur">Acteurs</see></term></item>
	/// </list>
    /// </summary>
    [sc2i.doccode.DocRefMenusOrMenuItems(CDocLabels.c_iContrainte)]
    [DynamicClass("Resource")]
    [Table(CRessourceMaterielle.c_nomTable, CRessourceMaterielle.c_champId, true)]
    [ObjetServeurURI("CRessourceServeur")]
    [AutoExec("Autoexec")]
	[Evenement(CRessourceMaterielle.c_evenementAffectation,
		"Assignement to an intervention",
		"Occurs when a resource is asigned to an intervention")]
    public class CRessourceMaterielle : CObjetDonneeAIdNumeriqueAuto,
                              IObjetDonneeAChamps,
                              IObjetDonneeAutoReference,
                              IElementAAgenda,
                              IElementAEO,
							  IRessourceEntreePlanning,
							IElementATypeStructurant<CTypeRessource>
        
    {

		public const string c_evenementAffectation = "ASSIGNEMENT";

        public const string c_nomTable = "MATERIAL_RESOURCE";
        public const string c_champId = "MATMATRES_ID";
        public const string c_champIdParent = "MATRES_PARENT_ID";

        public const string c_champLibelle = "RESOURCE_LABEL";
        public const string c_champSerialNumber = "MATRES_SERIAL_NUMBER";
        public const string c_champInfoEmplacement = "MATRES_PLACE_INFO";
        public const string c_champEtat = "RESOURCE_STATE";

        public const string c_roleChampCustom = "RESOURCE";

        
        /// /////////////////////////////////////////////
        public CRessourceMaterielle(CContexteDonnee contexte)
            : base(contexte)
        {
        }

        /// /////////////////////////////////////////////
        public CRessourceMaterielle(DataRow row)
            : base(row)
        {
        }

        //-------------------------------------------------------------------
        public static void Autoexec()
        {
            CRoleChampCustom.RegisterRole(c_roleChampCustom, "Resource", typeof(CRessourceMaterielle),typeof(CTypeRessource));
        }

        //-------------------------------------------------------------------
        public CRoleChampCustom RoleChampCustomAssocie
        {
            get
            {
                return CRoleChampCustom.GetRole(c_roleChampCustom);
            }
        }


        ////////////////////////////////////////////////
        /// <summary>
        /// Description générale
        /// </summary>
        public override string DescriptionElement
        {
            get
            {
                return I.T("Resource : @1|247", Libelle);
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

         ////////////////////////////////////////////
        /// <summary>
        /// Le libellé de la Ressource. Ce champ est obligatoire
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


         /////////////////////////////////////////////
		/// <summary>
		/// Definit un numéro de série pour la Ressource Matérielle
		/// </summary>
        [TableFieldProperty(c_champSerialNumber, 512)]
        [DynamicField("Serial number")]
        public string SerialNumber
        {
            get
            {
                return (string)Row[c_champSerialNumber];
            }
            set
            {
                Row[c_champSerialNumber] = value;
            }
        }



         /////////////////////////////////////////////
		/// <summary>
		/// Definit l'emplacement de la Ressource
		/// </summary>
        /// <remarks>
        /// L'Emplacement peut être une des entités suivantes:
        /// <list type="bullets">
        /// <item><term><see cref="CSite">Un Site</see></term></item>
        /// <item><term><see cref="CActeur">Un Acteur</see></term></item>
        /// </list>
        /// </remarks>
        [DynamicField("Place")]
        public IPossesseurRessource Emplacement
        {
            get
            {
                IPossesseurRessource emplacement = EmplacementSite;
                if (emplacement == null)
                    emplacement = EmplacementActeur;

                return emplacement;
            }

        }
        //--------------------------------------------------------------------------
        /// <summary>
        /// Definit l'Acteur détenteur de la Ressource.
        /// </summary>
        [Relation(
            CActeur.c_nomTable,
            CActeur.c_champId, 
            CActeur.c_champId,
            false,
            false)]
        [DynamicField("Member place")]
        public CActeur EmplacementActeur
        {
            get
            {
                return (CActeur)GetParent(CActeur.c_champId, typeof(CActeur));
            }
        }

        //-------------------------------------------------------------------------
        /// <summary>
        /// Definit le Site ou se trouve la Ressource.
        /// </summary>
        [Relation(
            CSite.c_nomTable, 
            CSite.c_champId,
            CSite.c_champId,
            false,
            false)]
        [DynamicField("Site place")]
        public CSite EmplacementSite
        {
            get
            {
                return (CSite)GetParent(CSite.c_champId, typeof(CSite));
            }
        }


        //--------------------------------------------------------------------------
        /// <summary>
        /// Définit la Ressource parente détentrice de la Ressource
        /// </summary>
        [Relation(
            c_nomTable,
            c_champId,
            c_champIdParent,
            false,
            false)]
        [DynamicField("Parent resource")]
        public CRessourceMaterielle RessourceParente
        {
            get
            {
                return (CRessourceMaterielle)GetParent(c_champIdParent, typeof(CRessourceMaterielle));
            }
        }

        //--------------------------------------------------------------------------------
        /// <summary>
        /// Définit la Ressource parente initiale de la Ressource
        /// Cette proporiété n'est disponible que sur une nouvelle ressource
        /// </summary>
        public CRessourceMaterielle RessourceParenteInitiale
        {
            set
            {
                if (IsNew())
                {
                    SetParent(c_champIdParent, value);
                    if(value != null)
                        EmplacementInitial = value.Emplacement;
                }
            }
        }


        //----------------------------------------------------------------------------
        /// <summary>
        /// Retouren la liste de toutes les Ressources filles d'un Ressource parente
        /// </summary>
        [RelationFille(typeof(CRessourceMaterielle), "RessourceParente")]
        [DynamicChilds("Child ressources", typeof(CRessourceMaterielle))]
        public CListeObjetsDonnees RessourcesFilles
        {
            get
            {
                return GetDependancesListe(c_nomTable, c_champIdParent);
            }
        }

        /////////////////////////////////////////////
		/// <summary>
		/// Definit un champ d'informations complémentaires sur l'emplacement de la Ressource.
        /// Champs texte de 2048 caractères maximum.
		/// </summary>
        [TableFieldProperty(c_champInfoEmplacement, 2048)]
        [DynamicField("Place info")]
        public string InfoEmplacement
        {
            get
            {
                return (string)Row[c_champInfoEmplacement];
            }
            set
            {
                Row[c_champInfoEmplacement] = value;
            }
        }

        //////////////////////////////////////////////////////
        /// <summary>
        /// Définit l'emplacement initial de la ressource.
        /// Cette proporiété n'est disponible que sur une nouvelle Ressource
        /// </summary>
        public IPossesseurRessource EmplacementInitial
        {
            set
            {
                if (IsNew())//Autorisé uniquement pour un nouvel élément
                {
                    SetEmplacementSansHistorique(value);
                }
            }
        }


        //-------------------------------------------------------------------------------
        /// <summary>
        /// Modifie l'emplacement de la ressource sans créer de mouvement (Sans historique)
        /// </summary>
        /// <param name="emplacement">Nouvel emplacement</param>
        [DynamicMethod("Set Resource place without hystory", "New place")]
        public void SetEmplacementSansHistorique(IPossesseurRessource emplacement)
        {
            if (emplacement is CSite)
            {
                SetParent(CSite.c_champId, (CObjetDonnee)emplacement);
            }
            else
                SetParent(CSite.c_champId, null);
            if (emplacement is CActeur)
                SetParent(CActeur.c_champId, (CObjetDonnee)emplacement);
            else
                SetParent(CActeur.c_champId, null);
        }

        //-------------------------------------------------------------------------------
        /// <summary>
        /// Retourne la liste des mouvements de la ressource (Historique)
        /// </summary>
        [RelationFille(typeof(CMouvementRessource), "RessourceDeplace")]
        [DynamicChilds("Movements", typeof(CMouvementRessource))]
        public CListeObjetsDonnees Mouvements
        {
            get
            {
                return GetDependancesListe(CMouvementRessource.c_nomTable, c_champId);
            }
        }

        //-------------------------------------------------------------------------------
		/// <summary>
		/// Cette méthode permet de déplacer la ressource
		/// </summary>
		/// <param name="strInfoDeplacement">infos déplacement</param>
		/// <param name="emplacementDestination">Emplacement destination</param>
		/// <param name="utilisateur">Utilisateur responsable du mouvement</param>
		/// <param name="dateDeplacement">Date du mouvement</param>
		/// <returns>VRAI si l'opération s'est bien passée</returns>
        [DynamicMethod("Move a resource towards an other place",
            "Movement information",
            "Destination place",
            "User making the movement",
            "Movement date")]
        public CResultAErreur DeplaceRessource(
            string strInfoDeplacement,
            IPossesseurRessource emplacementDestination,
            CDonneesActeurUtilisateur utilisateur,
            DateTime dateDeplacement)
        {
            CResultAErreur result = CResultAErreur.True;
            if (emplacementDestination == null)
            {
                result.EmpileErreur(I.T("Movement must have a destination Place|248"));
            }
            if (utilisateur == null)
            {
                utilisateur = sc2i.workflow.CUtilSession.GetUserForSession(ContexteDonnee);
                if (utilisateur == null)
                    result.EmpileErreur(I.T("No user for movement|249"));
            }
            if (!result)
                return result;

            if (emplacementDestination.Equals(Emplacement))
            {
                return result;
            }
            CRessourceMaterielle ressourceToEdit = this;
            ressourceToEdit.BeginEdit();

            CMouvementRessource mouvement = null;

            if (Emplacement != null)
            {
                mouvement = new CMouvementRessource(ressourceToEdit.ContexteDonnee);
                mouvement.CreateNewInCurrentContexte();
                mouvement.RessourceDeplace = this;
                mouvement.EmplacementOrigine = Emplacement;
                mouvement.Info = strInfoDeplacement;
                mouvement.DateMouvement = dateDeplacement;
                mouvement.Utilisateur = utilisateur;
            }

            ressourceToEdit.SetEmplacementSansHistorique(emplacementDestination);
            // Déplace les ressources filles avec

            if(mouvement != null)
                result = ressourceToEdit.VerifieDonnees(false);
            if (result && mouvement != null)
                result = mouvement.VerifieDonnees(false);
            if (result)
                result = ressourceToEdit.CommitEdit();
            else
                ressourceToEdit.CancelEdit();
            return result;
        }

        //-------------------------------------------------------------------
        /// <summary>
		/// Definit le Type de la Ressource. Ce champ est obligatoire
        /// </summary>
        [Relation(CTypeRessource.c_nomTable, CTypeRessource.c_champId, CTypeRessource.c_champId, true, false)]
        [DynamicField("Resource type")]
        public CTypeRessource TypeRessource
        {
            get
            {
                return (CTypeRessource)GetParent(CTypeRessource.c_champId, typeof(CTypeRessource));
            }
            set
            {
                SetParent(CTypeRessource.c_champId, value);
            }
        }


        /// <summary>
        /// Renvoie la liste des relations avec les Contraintes. Cette liste représente les Containtes que la Ressource peut 
        /// lever explicitement.
        /// </summary>
        [RelationFille(typeof(CRelationContrainte_Ressource), "Ressource")]
        [DynamicChilds("Constraints relations", typeof(CRelationContrainte_Ressource))]
        public CListeObjetsDonnees RelationContrainteListe
        {
            get
            {
                return GetDependancesListe(CRelationContrainte_Ressource.c_nomTable, c_champId);
            }
        }

        //--------------------------------------------------------------------------
		/// <summary>
		/// Liste des Attributs de la Ressource
		/// </summary>
        [RelationFille(typeof(CAttributRessource), "Ressource")]
        [DynamicChilds("Attributes", typeof(CAttributRessource))]
        public CListeObjetsDonnees AttributsListe
        {
            get
            {
                return GetDependancesListe(CAttributRessource.c_nomTable, c_champId);
            }
        }


        //-----------------------------------------------------------------------------
        /// <summary>
        /// Code d'Etat de la ressource : Active, inactive, utilisée
        ///    Active = 0,<br/>
        ///    Inactive = 10,<br/>
        ///    Utilisée = 20<br/>
        /// </summary>
        [TableFieldProperty(c_champEtat)]
        [DynamicField("Resource state code")]
        public int EtatInt
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

        //----------------------------------------------------------------------------
		/// <summary>
		/// L'Etat de la Ressource peut prendre les valeurs suivantes: 
        /// <list type="bullets">
        /// <item>Active: La Ressource est utilisable mais non utilisée</item>
        /// <item>Inactive: La Ressource n'est pas utilisable</item>
        /// <item>Utilisée: La Ressource est utilisable et utilisée</item>
        /// </list>
		/// </summary>
        [DynamicField("Resource state")]
        public CEtatRessource Etat
        {
            get
            {
                return new CEtatRessource((EtatRessource) EtatInt);
            }
            set
            {
                if(value != null)
                    EtatInt = value.CodeInt;
            }
        }
        



        //--------------------------------------- IMPLEMENTATION DES INTERFACES -----------------------------------------

        #region IObjetDonneeAChamps Membres

        public CRelationElementAChamp_ChampCustom GetNewRelationToChamp()
        {
            return new CRelationRessource_ChampCustomValeur(ContexteDonnee);
        }

        public string GetNomTableRelationToChamps()
        {
            return CRelationRessource_ChampCustomValeur.c_nomTable;
        }

        public CListeObjetsDonnees GetRelationsToChamps(int nIdChamp)
        {
            CListeObjetsDonnees liste = RelationsChampsCustom;
            liste.InterditLectureInDB = true;
            liste.Filtre = new CFiltreData(CChampCustom.c_champId + " = @1", nIdChamp);
            return liste;
        }

        #endregion

        #region IElementAChamps Membres

        public IDefinisseurChampCustom[] DefinisseursDeChamps
        {
            get
            {
                return new IDefinisseurChampCustom[] { TypeRessource };
            }
        }

        public CChampCustom[] GetChampsHorsFormulaire()
        {
            if (TypeRessource == null)
                return new CChampCustom[0];

            ArrayList lst = new ArrayList();
            foreach (CRelationTypeRessource_ChampCustom rel in TypeRessource.RelationsChampsCustomDefinis)
                lst.Add(rel.ChampCustom);

            foreach (CRelationTypeRessource_Formulaire rel1 in TypeRessource.RelationsFormulaires)
                foreach (CRelationFormulaireChampCustom rel2 in rel1.Formulaire.RelationsChamps)
                    lst.Remove(rel2.Champ);
          

            return (CChampCustom[])lst.ToArray(typeof(CChampCustom));
        }

        public CFormulaire[] GetFormulaires()
        {
            return CUtilElementAChamps.GetFormulaires(this);

        }

        [RelationFille(typeof(CRelationRessource_ChampCustomValeur), "ElementAChamps")]
        [DynamicChilds("Custom fields relations", typeof(CRelationRessource_ChampCustomValeur))]
        public CListeObjetsDonnees RelationsChampsCustom
        {
            get
            {
                return GetDependancesListe(CRelationRessource_ChampCustomValeur.c_nomTable, c_champId);
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

        #region IElementAAgenda Membres

        public string[] GetProprietesAccessSousElementsAgenda()
        {
            return new string[0];
        }

        #endregion




        #region IObjetDonneeAutoReference Membres

        public string ChampParent
        {
            get 
            {
                return c_champIdParent; 
            }
        }

        public string ProprieteListeFils
        {
            get 
            {
                return "RessourcesFilles";
            }
        }

        #endregion

        #region IElementAEO Membres

        //-------------------------------------------------------------------
        /// <summary>
        /// Codes complets (Full_system_code) de toutes les <see cref="CEntiteOrganisationnelle">entités organisationnelles</see> auxquelles est affectée la ressource<br/>
        /// </summary>
        /// <remarks>
        /// Ces codes sont présentés sous la forme d'une chaîne de caractères<br/>
        /// Chaque code est encadré par deux caractères ~ (exemple : ~01051B~0201~061A0304~)
        /// </remarks>
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
        
        public IElementAEO[] DonnateursEO
        {
            get 
            {
                return new IElementAEO[] {TypeRessource,
                                         (IElementAEO)Emplacement,
                                         RessourceParente };
            }
        }

        public IElementAEO[] HeritiersEO
        {
            get
            {
                ArrayList lst = new ArrayList();
                lst.AddRange(RessourcesFilles);
                return (IElementAEO[])lst.ToArray(typeof(IElementAEO));
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

		public CCalendrier Calendrier
		{
			get { return null; }
		}

        public CTrancheHoraire[] GetHoraires(DateTime dtDebut, DateTime dtfin)
        {
            return new CTrancheHoraire[0];
        }

		//-------------------------------------------------------------------------------
		public bool CanBeUseFor(IProfilElement profil, IEntreePlanning entree)
		{
			CProfilElement[] profils = profil.TousLesProfilsARemplir;
			if (profils.Length == 0)
				return true;
			if (profils[0].TypeElements != typeof(CRessourceMaterielle))
				return false;
			CContrainte contrainte = null;
			if (profil is CContrainte && entree is CIntervention)
			{
				contrainte = (CContrainte)profil;
				profil = ((CIntervention)entree).TypeIntervention.ProfilRessourceDefaut;
			}
				
			CListeObjetsDonnees liste = CProfilElement.GetElementsForSource(profil, (IObjetDonneeAIdNumerique) entree, contrainte, null);
			if (liste != null)
			{
				foreach (CObjetDonneeAIdNumerique objet in liste)
					if (objet.Id == Id)
						return true;
			}
			return false;
		}



		#region IElementATypeStructurant<CTypeRessource> Membres

		public CTypeRessource ElementStructurant
		{
			get { return TypeRessource; }
		}
		public int IdTypeStructurant
		{
			get
			{
				return (int)Row[CTypeRessource.c_champId];
			}
		}
		#endregion
	}
}
