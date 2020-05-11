using System;
using System.Collections;
using System.Text;
using System.Data;
using System.Drawing;
using System.IO;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using sc2i.data.dynamic;

using timos.securite;
using timos.data.tiag;
using tiag.client;
using sc2i.expression;

namespace timos.data
{
    /// <summary>
	/// Le Type de Contrainte fournit des caractéristiques et des options aux <see cref="CContrainte">Contraintes</see> de ce type.<br/> 
    /// Les Types de Contraintes sont des entités hiérarchiques. Un Type de Contraintes peut avoir plusieurs Types fils.
    /// Le type de contrainte détermine les types de ressources qui peuvent lever les contraintes de ce type,<br/>
    /// ainsi que les formulaires qui doivent être présentés aux utilisateurs.
    /// </summary>
    [sc2i.doccode.DocRefMenusOrMenuItems(CDocLabels.c_iContrainte)]
    [DynamicClass("Constraint type")]
    [Table(CTypeContrainte.c_nomTable, CTypeContrainte.c_champId, true)]
    [ObjetServeurURI("CTypeContrainteServeur")]
    [TiagClass(CTypeContrainte.c_nomTiag, "Id", true)]
    [TiagUniqueAttribute(CTypeContrainte.c_champLibelle + "=@1", "Libelle")]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_TypeContrainte_ID)]
    [AutoExec("Autoexec")]
    public class CTypeContrainte : CObjetHierarchique,
                                   IObjetDonneeAChamps,
                                   IObjetALectureTableComplete,
                                   IDefinisseurChampCustomRelationObjetDonnee,
                                   IElementAInterfaceTiag
    {

        public const string c_nomTiag = "Constraint Type";
        public const string c_nomTable =        "CONSTRAINT_TYPE";
        public const string c_champId =         "CONSTRAINT_TYPE_ID";

        public const string c_champLibelle =    "CONSTP_LABEL";
        public const string c_champOptionTousLesAttributs = "CONSTP_ALL_ATTRIBUTES_OPT";
        public const string c_champOptionChoixAttributListe = "CONSTP_ATT_LIST_OPT";
        public const string c_champOptionChoixAttributLibre = "CONSTP_FREE_ATT_OPT";
        public const string c_champOptionAuMoinsUnAttributListe = "CONSTP_1LEAST_ATT_OPT";
        public const string c_champOptionAuPlusUnAttributListe = "CONSTP_1MORE_ATT_OPT";
		public const string c_champOptionToutesRessourcesDeTypeLevant = "CONSTP_ALL_RESOURCES";

        public const string c_champCodeSystemePartiel = "CONSTP_PARTIAL_SYS_CODE";
        public const string c_champCodeSystemeComplet = "CONSTP_FULL_SYS_CODE";
        public const string c_champNiveau = "CONSTP_LEVEL";
        public const string c_champIdParent = "CONSTP_PARENT_ID";
		public const string c_champImage = "CONSTP_IMAGE";
		public const string c_champIsInCheckList = "CONSTP_IN_CHECKLIST";
		public const string c_champIsContrainteNecessaireActeur = "CONSTTP_MEMBER_NEEDED";

        public const string c_roleChampCustom = "CONSTRAINT_TYPE";

		/// /////////////////////////////////////////////
		public CTypeContrainte( CContexteDonnee contexte)
			:base(contexte)
		{
        }

		/// /////////////////////////////////////////////
        public CTypeContrainte(DataRow row)
			:base(row)
		{
        }

        //-------------------------------------------------------------------
        public static void Autoexec()
        {
            CRoleChampCustom.RegisterRole(c_roleChampCustom, "Constraint type", typeof(CTypeContrainte), typeof(CDefinisseurChampsPourTypeSansDefinisseur));
        }

        /// <summary>
        /// Description
        /// </summary>
        public override string DescriptionElement
        {
            get
            {
                return I.T( "Constraint type @1 |568",Libelle);
            }
        }

        public override string[] GetChampsTriParDefaut()
        {
            return new string[] { c_champLibelle };
        }

        protected override void MyInitValeurDefaut()
        {
            base.MyInitValeurDefaut();
			OptionToutesRessourcesDeTypeLevant = false;

        }


        #region IMPLEMENTE OBJET HIERARCHIQUE
        //------------------------------------------ IMPLEMENTE OBJET HIERARCHIQUE ---------------------------------------
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
        /// Indique le code système du type de contrainte (unique dans son parent).<br/>
        /// Ce code est exprimé sur deux caractères alphanumériques.
        /// </summary>
        [TableFieldProperty(c_champCodeSystemePartiel, 2)]
        [DynamicField("Partiel system code")]
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
        /// Code système complet du type de contrainte. Ce code système est<br/>
        /// constitué du code système complet du type de contrainte parente<br/>
        /// concaténé avec le code système propre du type de contrainte.<br/>
        /// Exemple : TPC_GRDPARENTE -> TPC_PARENTE -> TPC_FILLE<br/>
        /// si le code de TPC_GRDPARENTE est 01, le code de TPC_PARENTE est 03 et<br/>
        /// et le code propre de TPC_FILLE est 08, le code système complet<br/>
        /// de TPC_FILLE est 010308.
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
        /// Niveau du type de contrainte dans la hiérarchie des types (nombre de parents).<br/>
        /// Exemple : TPC_GRDPARENTE -> TPC_PARENTE -> TPC_FILLE<br/>
        /// TPC_GRDPARENTE a pour niveau 0, TPC_PARENTE a pour niveau 1<br/>
        /// (1 parent en remontant la hiérarchie), TPC_FILLE a pour niveau 2<br/>
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

        /// /////////////////////////////////////////////
        /// <summary>
        /// Donne ou définit le nom du Type de Contrainte<br/>
        /// (champ texte de 255 caractrères maximum).
        /// </summary>
        [TableFieldProperty(c_champLibelle, 255)]
        [DynamicField("Label")]
        [RechercheRapide]
        [TiagField("Label")]
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



        //-------------------------------------------------------------------
        public void TiagSetParentConstraintTypeKeys(object[] lstCles)
        {
            CTypeContrainte typeParent = new CTypeContrainte(ContexteDonnee);
            if (typeParent.ReadIfExists(lstCles))
                TypeContrainteParent = typeParent;
        }

        //---------------------------------------------------------------------------
        /// <summary>
        /// Donne ou définit le Type de Contrainte parent dans la hiérarchie
        /// </summary>
        [Relation(
            c_nomTable,
            c_champId,
            c_champIdParent,
            false,
            false)]
        [DynamicField("Parent constraint type")]
        [TiagRelation(typeof(CTypeContrainte), "TiagSetParentConstraintTypeKeys")]
        public CTypeContrainte TypeContrainteParent
        {
            get
            {
                return (CTypeContrainte)ObjetParent;
            }
            set
            {
                ObjetParent = value;
            }
        }

        //--------------------------------------------------------------------------------
        /// <summary>
        /// Retourne la liste des Types de Contrainte fils dans la hiérarchie<br/>
        /// (ceux d'ordre immédiatement inférieur)
        /// </summary>
        [RelationFille(typeof(CTypeContrainte), "TypeContrainteParent")]
        [DynamicChilds("Child constraint types", typeof(CTypeContrainte))]
        public CListeObjetsDonnees TypesContraintesFils
        {
            get
            {
                return ObjetsFils;
            }
        }

        //--------------------------------------------------------------------------------
        /// <summary>
        /// Renvoie la liste des relations avec des Types de Ressources.<br/>
        /// Ce sont les Types de Ressources qui peuvent lever explicitement Le Type de Contrainte
        /// </summary>
        [RelationFille(typeof(CRelationTypeContrainte_TypeRessource), "TypeContrainte")]
        [DynamicChilds("Resource types relations", typeof(CRelationTypeContrainte_TypeRessource))]
        public CListeObjetsDonnees RelationsTypesRessourcesListe
        {
            get
            {
                return GetDependancesListe(CRelationTypeContrainte_TypeRessource.c_nomTable, c_champId);
            }
        }

        //--------------------------------------------------------------------------------
        /// <summary>
        /// Renvoie le tableau de toutes les relations avec les types de Ressources<br/> 
        /// héritées de tous les Types Parents du Type de Contrainte.
        /// </summary>
        [DynamicMethod("Return an array of all Resources Types that raises this Type of Constraint, including inhérited Resources Types from Parents Constraints Types")]
        public CTypeRessource[] GetTousLesTypesRessources()
        {
            ArrayList liste = new ArrayList();

            // Ajoute ces propres relations à la liste
            foreach (CRelationTypeContrainte_TypeRessource rel in this.RelationsTypesRessourcesListe)
            {
                liste.Add(rel.TypeRessource);
            }
            // Vérifie les relations de son parent et les ajoute à la liste
            if (this.TypeContrainteParent != null)
            {
                liste.AddRange(this.TypeContrainteParent.GetTousLesTypesRessources());
            }


            return (CTypeRessource[])liste.ToArray(typeof(CTypeRessource));

        }
        

        //------------------------------------------------------------------------------------
        /// <summary>
        /// Retourne la liste des Attributs possibles pour les Contraintes de ce Type
        /// </summary>
        [RelationFille(typeof(CAttributTypeContrainte), "TypeContrainte")]
        [DynamicChilds("Constraint Type Attributes", typeof(CAttributTypeContrainte))]
        public CListeObjetsDonnees AttributsTypeContrainte
        {
            get
            {
                return GetDependancesListe(CAttributTypeContrainte.c_nomTable, c_champId); 
            }
        }
        //------------------------------------------------------------------------------------
        /// <summary>
        /// Fonction récursive:
        /// Renvoie la liste de tous las attribuits possibles de la hiérarchie
        /// Ajoute les attributs de ces parents à ces propres Attributs.
        /// </summary>
        /// <returns>Tableau de CAttributTypeContrainte</returns>
        public CAttributTypeContrainte[] GetTousLesAttributsTypeContrainte()
        {
            ArrayList liste = new ArrayList();

            // Ajoute ces propres attributs à la liste
            foreach (CAttributTypeContrainte att in this.AttributsTypeContrainte)
            {
                liste.Add(att);
            }
            // Vérifie les attributs de son parent et les ajoute à la liste
            if (this.TypeContrainteParent != null)
            {
                liste.AddRange(this.TypeContrainteParent.GetTousLesAttributsTypeContrainte());
            }


            return (CAttributTypeContrainte[])liste.ToArray(typeof(CAttributTypeContrainte));

        }

        //-----------------------------------------------------------
        /// <summary>
        /// Option booléenne qui indique si une Ressource devra posséder tous les attributs (option à VRAI) de la contrainte,<br/>
        /// ou seulement un seul (option à FAUX) pour pouvoir lever les Contraintes de ce Type.
        /// </summary>
        [TableFieldProperty(c_champOptionTousLesAttributs)]
        [DynamicField("Option : all attributes")]
        [TiagField("All attributes option")]
        public bool OptionTousAttributsRessourceLevant
        {
            get
            {
                return (bool)Row[c_champOptionTousLesAttributs];
            }
            set
            {
                Row[c_champOptionTousLesAttributs] = value;
            }
        }


        //-----------------------------------------------------------
        /// <summary>
        /// Option booléenne qui indique si les Contraintes de ce Type<br/>
        /// peuvent avoir des attributs choisis dans la liste.
        /// </summary>
        [TableFieldProperty(c_champOptionChoixAttributListe)]
        [DynamicField("Option : select attributes in list")]
        [TiagField("Select attributes from list")]
        public bool OptionChoixAttributDansListe
        {
            get
            {
                return (bool)Row[c_champOptionChoixAttributListe];
            }
            set
            {
                Row[c_champOptionChoixAttributListe] = value;
            }
        }


        
        //-----------------------------------------------------------
        /// <summary>
        /// Option booléenn qui indique si les Contraintes de ce Type<br/>
        /// doivent avoir au moins un Attribut de la liste.
        /// </summary>
        [TableFieldProperty(c_champOptionAuMoinsUnAttributListe)]
        [DynamicField("Option : At least one attribute")]
        [TiagField("At least one Attribute")]
        public bool OptionAuMoinsUnAttributListe
        {
            get
            {
                return (bool)Row[c_champOptionAuMoinsUnAttributListe];
            }
            set
            {
                Row[c_champOptionAuMoinsUnAttributListe] = value;
            }
        }


        //-----------------------------------------------------------
        /// <summary>
        /// Option booléenne qui indique si les Contraintes de ce Type<br/>
        /// doivent avoir au plus un Attribut de la liste
        /// </summary>
        [TableFieldProperty(c_champOptionAuPlusUnAttributListe)]
        [DynamicField("Option : at more one attribute")]
        [TiagField("At more one Attribute")]
        public bool OptionAuPlusUnAttributListe
        {
            get
            {
                return (bool)Row[c_champOptionAuPlusUnAttributListe];
            }
            set
            {
                Row[c_champOptionAuPlusUnAttributListe] = value;
            }
        }



		//-----------------------------------------------------------
		/// <summary>
		/// Option booléenne qui indique que si la Contrainte de ce Type n'a pas d'Attributs,<br/>
        /// alors toutes les Ressources du bon Type lèvent la Contrainte
		/// </summary>
		[TableFieldProperty(c_champOptionToutesRessourcesDeTypeLevant)]
		[DynamicField("All resources")]
        [TiagField("All Resources")]
		public bool OptionToutesRessourcesDeTypeLevant
		{
			get
			{
				return (bool)Row[c_champOptionToutesRessourcesDeTypeLevant];
			}
			set
			{
				Row[c_champOptionToutesRessourcesDeTypeLevant] = value;
			}
		}



        //-----------------------------------------------------------
        /// <summary>
        /// Option booléenne qui indique si les Contraintes de ce Type peuvent avoir des Attributs libres.
        /// </summary>
        [TableFieldProperty(c_champOptionChoixAttributLibre)]
        [DynamicField("Option : Free attribute selection")]
        [TiagField("Free Attributes selection")]
        public bool OptionChoixAttributLibre
        {
            get
            {
                return (bool)Row[c_champOptionChoixAttributLibre];
            }
            set
            {
                Row[c_champOptionChoixAttributLibre] = value;
            }
        }

		/// /////////////////////////////////////////////////////////
		[TableFieldProperty(c_champImage, NullAutorise = true)]
		public CDonneeBinaireInRow DataImage
		{
			get
			{
				if (Row[c_champImage] == DBNull.Value)
				{
					CDonneeBinaireInRow donnee = new CDonneeBinaireInRow(ContexteDonnee.IdSession, Row, c_champImage);
					CContexteDonnee.ChangeRowSansDetectionModification(Row, c_champImage, donnee);
				}
				object obj = Row[c_champImage];
				return ((CDonneeBinaireInRow)obj).GetSafeForRow ( Row.Row );
			}
			set
			{
				Row[c_champImage] = value;
			}
		}

		/// <summary>
		/// Option booléenne qui indique que les Contraintes de ce types n'apparaissent que dans les<br/>
		/// checklist sur les Interventions et n'ont pas besoin d'être lévées par des Ressources
		/// </summary>
		[TableFieldProperty ( CTypeContrainte.c_champIsInCheckList )]
		[DynamicField("On check list")]
        [TiagField("On check list")]
		public bool IsInCheckList
		{
			get
			{
				return (bool)Row[c_champIsInCheckList];
			}
			set
			{
				Row[c_champIsInCheckList] = value;
			}
		}

		

		//-----------------------------------------------------------
		/// <summary>
		/// Option booléenne qui indique si les acteurs doivent lever la Contrainte de ce type<br/>
        /// pour pouvoir intervenir.
		/// </summary>
		[TableFieldProperty ( c_champIsContrainteNecessaireActeur)]
		[DynamicField("Is needed for Members")]
        [TiagField("Is needed for Members")]
		public bool IsContrainteNecessaireActeur
		{
			get
			{
				return (bool)Row[c_champIsContrainteNecessaireActeur];
			}
			set
			{
				Row[c_champIsContrainteNecessaireActeur] = value;
			}
		}


		/// /////////////////////////////////////////////////////////
        [BlobDecoder]
        public Bitmap ImagePropre
		{
			get
			{
				CDonneeBinaireInRow data = DataImage;
				if (data != null && data.Donnees != null)
				{
					Stream stream = new MemoryStream(data.Donnees);
					try
					{
						Bitmap image = (Bitmap)Bitmap.FromStream(stream);
						return image;
					}
					catch
					{
					}
				}
				return null;
			}
			set
			{
				if (value == null)
				{
					CDonneeBinaireInRow data = DataImage;
					data.Donnees = null;
					DataImage = data;
				}
				else
				{
					MemoryStream stream = new MemoryStream();
					try
					{
						value.Save(stream, System.Drawing.Imaging.ImageFormat.Gif);
						CDonneeBinaireInRow data = DataImage;
						data.Donnees = stream.GetBuffer();
						DataImage = data;
					}
					catch
					{
						CDonneeBinaireInRow data = DataImage;
						data.Donnees = null;
						DataImage = data;
					}
				}
			}
		}

		/// /////////////////////////////////////////////////////////
		public Image ImageApplique
		{
			get
			{
				Image img = ImagePropre;
				if (img == null && TypeContrainteParent != null)
					return TypeContrainteParent.ImageApplique;
				return img;					
			}
		}


        #region IDefinisseurChampCustomRelationObjetDonnee Membres

        /// <summary>
        /// Définit la liste des relation avec les formulaire custom
        /// </summary>
        [RelationFille(typeof(CRelationTypeContrainte_ChampCustom), "Definisseur")]
        public CListeObjetsDonnees RelationsChampsCustomListe
        {
            get 
            {
                return GetDependancesListe(CRelationTypeContrainte_ChampCustom.c_nomTable, c_champId);
            }
        }

        /// <summary>
        /// Définit la liste des relation avec les formulaire custom
        /// </summary>
        [RelationFille(typeof(CRelationTypeContrainte_Formulaire), "Definisseur")]
        public CListeObjetsDonnees RelationsFormulairesListe
        {
            get
            {
                return GetDependancesListe(CRelationTypeContrainte_Formulaire.c_nomTable, c_champId);
            }
        }

        #endregion


        #region IDefinisseurChampCustom Membres

        /// /////////////////////////////////////////////
        public IRelationDefinisseurChamp_ChampCustom[] RelationsChampsCustomDefinis
        {
            get
            {
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
                return CRoleChampCustom.GetRole(CContrainte.c_roleChampCustom);
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

        #region IElementAInterfaceTiag Membres

        public object[] TiagKeys
        {
            get { return new object[] { Id }; }
        }

        public string TiagType
        {
            get { return c_nomTiag; }
        }

        #endregion

        public IDefinisseurChampCustom[] DefinisseursDeChamps
        {
            get
            {
                return new IDefinisseurChampCustom[]{
                    new CDefinisseurChampsPourTypeSansDefinisseur(
                        ContexteDonnee, 
                        CRoleChampCustom.GetRole(CTypeContrainte.c_roleChampCustom) )};
            }
        }

        public CRelationElementAChamp_ChampCustom GetNewRelationToChamp()
        {
            return new CRelationTypeContrainte_ChampCustomValeur(ContexteDonnee);
        }

        [RelationFille(typeof(CRelationTypeContrainte_ChampCustomValeur), "ElementAChamps")]
        public CListeObjetsDonnees RelationsChampsCustom
        {
            get
            {
                return GetDependancesListe(CRelationTypeContrainte_ChampCustomValeur.c_nomTable, c_champId);
            }
        }

        public CRoleChampCustom RoleChampCustomAssocie
        {
            get
            {
                return CRoleChampCustom.GetRole(CTypeContrainte.c_roleChampCustom);
            }
        }
                
        public string GetNomTableRelationToChamps()
        {
            return CRelationTypeContrainte_ChampCustomValeur.c_nomTable;
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
