using System;
using System.Collections;
using System.IO;

using sc2i.common;
using sc2i.data;
using sc2i.data.dynamic;
using tiag.client;
using timos.data.equipement.consommables;
using timos.data.equipement;


namespace timos.data
{
	/// <summary>
	/// La famille d'un <see cref="CTypeEquipement">type d'équipement</see> est un objet
    /// de classement hiérarchique de ces types.
	/// </summary>
    /// <remarks>
    /// Une famille a zéro ou un parent.
    /// La famille est obligatoire lors de la création d'un type d'équipement.<br/>
    /// Un type d'équipement est attaché à une famille et à une seule<br/>
    /// un <see cref="CEquipement">équipement</see> est atttaché à une famille par l'intermédiaire de son type.
    /// </remarks>
    [sc2i.doccode.DocRefMenusOrMenuItems(CDocLabels.c_iEquipement)]
    [DynamicClass("Equipment family")]
	[ObjetServeurURI("CFamilleEquipementServeur")]
	[Table(CFamilleEquipement.c_nomTable, CFamilleEquipement.c_champId,true)]
	[FullTableSync]
	[TiagClass(CFamilleEquipement.c_nomTiag, "Id", true)]
	public class CFamilleEquipement : CObjetHierarchique, 
		IObjetALectureTableComplete,
		IElementAInterfaceTiag

	{

		#region Déclaration des constantes
		public const string c_nomTiag = "Equipment family";


		public const string c_nomTable = "EQUIPMENT_FAMILY";
		public const string c_champId = "EQTFAM_ID";
		public const string c_champLibelle = "EQTFAM_LIBELLE";
		public const string c_champCodePartiel = "EQTFAM_PARTIAL_SYSCODE";
		public const string c_champCodeComplet = "EQTFAM_FULL_SYSCODE";
		public const string c_champNiveau = "EQTFAM_LEVEL";
		public const string c_champIdParent = "FAMEQTFAM_PARENT_ID";

        public const string c_champNoEquipment = "FAMEQT_NOEQPT";
        public const string c_champNoConsommable = "FAMEQT_NOCUNS";


		#endregion
		//-------------------------------------------------------------------
		public CFamilleEquipement( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CFamilleEquipement( System.Data.DataRow row )
			:base(row)
		{
		}

		
	
		//-------------------------------------------------------------------
		protected override void MyInitValeurDefaut()
		{
			base.MyInitValeurDefaut();

		}

		//-------------------------------------------------------------------
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champNiveau,c_champLibelle};
		}

		//-------------------------------------------------------------------
		public override string DescriptionElement
		{
			get
			{
				return I.T("Equipment Family @1|263",Libelle);
			}
		}

		public object[] TiagKeys
		{
			get { return new object[] { Id }; }
		}

		public string TiagType
		{
			get { return c_nomTiag; }
		}

		//-------------------------------------------------------------------
		public override int NbCarsParNiveau
		{
			get
			{
				return 2;
			}
		}

		//-------------------------------------------------------------------
		public override string ChampLibelle
		{
			get
			{
				return c_champLibelle;
			}
		}

		//-------------------------------------------------------------------
		public override string ChampCodeSystemePartiel
		{
			get
			{
				return c_champCodePartiel;
			}
		}

		//-------------------------------------------------------------------
		public override string ChampCodeSystemeComplet
		{
			get
			{
				return c_champCodeComplet;
			}
		}

		//-------------------------------------------------------------------
		public override string ChampNiveau
		{
			get
			{
				return c_champNiveau;
			}
		}

		//-------------------------------------------------------------------
		public override string ChampIdParent
		{
			get
			{
				return c_champIdParent;
			}
		}

		//-------------------------------------------------------------------
		/// <summary>
		/// Code système partiel de la famille ( code dans sa famille parente )
		/// </summary>
        /// <remarks>Le code système d'une famille est exprimé sur deux caractères</remarks>
		[TableFieldProperty(c_champCodePartiel, 2)]
		[DynamicField("Partial system code")]
		[TiagField("Partial system code")]
		public override string CodeSystemePartiel
		{
			get
			{
				string strVal = "";
				if ( Row[c_champCodePartiel] != DBNull.Value )
				  strVal = (string)Row[c_champCodePartiel];
				strVal = strVal.Trim().PadLeft(2,'0');
				return (string)Row[c_champCodePartiel];
			}
		}

        
        //-------------------------------------------------------------------
        /// <summary>
        /// Si vrai, indique que les types de consommables ne peuvent pas
        /// être affectés à cette famille
        /// </summary>
        [TableFieldProperty(c_champNoConsommable)]
        [DynamicField("No Consumable type")]
        [TiagField("No Consumable type")]
        public bool PasDeConsommable
        {
            get
            {
                return (bool)Row[c_champNoConsommable];
            }
            set
            {
                Row[c_champNoConsommable] = value;
            }
        }

        //-------------------------------------------------------------------
        /// <summary>
        /// Si vrai, indique que les types d'équipements ne peuvent pas
        /// être affectés à cette famille
        /// </summary>
        [TableFieldProperty(c_champNoEquipment)]
        [DynamicField("No Equipment type")]
        [TiagField("No Equipment type")]
        public bool PasDEquipement
        {
            get
            {
                return (bool)Row[c_champNoEquipment];
            }
            set
            {
                Row[c_champNoEquipment] = value;
            }
        }

		//-------------------------------------------------------------------
		/// <summary>
		/// Libellé de la famille
		/// </summary>
		[TableFieldProperty(c_champLibelle, 255)]
		[DynamicField("Label")]
		[TiagField("Label")]
        [DescriptionField]
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
		/// <summary>
		/// Code système complet de la famille, incluant les codes
		/// des familles de niveau supérieur
		/// </summary>
        /// <remarks>
        /// Le code système complet est un moyen pratique pour des objets hiérarchiques,
        /// de retrouver tous les enfants d'un objet parent, quelque soit leur niveau
        /// dans la hiérarchie :
        /// Supposons qu'un parent racine ait pour code système complet 02, un fils 020A,
        /// un arrière petit fils 020A05, en filtrant les objets dont le code système complet
        /// commence par 02, il est possible de retrouver le parent et tous ses enfants.
        /// </remarks>
		[TableFieldProperty(c_champCodeComplet, 64)]
		[DynamicField("Full system code")]
		[TiagField("Full system code")]
		public override string CodeSystemeComplet
		{
			get
			{
				return (string)Row[c_champCodeComplet];
			}
		}

		//-------------------------------------------------------------------
		/// <summary>
		/// Niveau de la famille dans la hiérarchie. La famille 'racine' est au niveau 0.
		/// </summary>
        /// <remarks>On peut dire également que le niveau donne le nombre de parents</remarks>
		[TableFieldProperty(c_champNiveau)]
		[DynamicField("Level")]
		[TiagField("Level")]
		public override int Niveau
		{
			get
			{
				return (int)Row[c_champNiveau];
			}
		}

		//-------------------------------------------------------------------
		public void TiagSetParentFamilyKeys(object[] lstCles)
		{
			CFamilleEquipement famille = new CFamilleEquipement(ContexteDonnee);
			if (famille.ReadIfExists(lstCles))
				FamilleParente = famille;
		}

		//-------------------------------------------------------------------
		/// <summary>
		/// Famille parente d'ordre immédiatement supérieur
		/// </summary>
		[Relation ( CFamilleEquipement.c_nomTable, 
			 CFamilleEquipement.c_champId,
			 c_champIdParent,
			 false,
			 false,
			 false)]
		[DynamicField("Parent family")]
		[TiagRelation(typeof(CFamilleEquipement), "TiagSetParentFamilyKeys")]
		public  CFamilleEquipement FamilleParente
		{
			get
			{
				return (CFamilleEquipement)ObjetParent;
			}
			set
			{
                if (value != null)
                    ObjetParent = value;
			}
		}

		//-------------------------------------------------------------------
		/// <summary>
		/// Liste des familles filles d'ordre immédiatement inférieur
		/// </summary>
		[RelationFille(typeof(CFamilleEquipement), "FamilleParente")]
		[DynamicChilds("Child families", typeof(CFamilleEquipement))]
		public CListeObjetsDonnees FamillesFilles
		{
			get
			{
				return ObjetsFils;
			}
		}


        //-----------------------------------------------------------------------
        /// <summary>
        /// Liste des <see cref="CTypeEquipement">types d'équipements</see> adirectement rattachés à cette famille
        /// </summary>
        [RelationFille(typeof(CTypeEquipement), "Famille")]
        [DynamicChilds("Equipments Types", typeof(CTypeEquipement))]
        public CListeObjetsDonnees TypesEquipements
        {
            get
            {
                return GetDependancesListe(CTypeEquipement.c_nomTable, c_champId);
            }
        }

		#region IDefinisseurChampCustom Membres

		//-------------------------------------------------------------------
		[RelationFille ( typeof ( CRelationFamilleEquipement_ChampCustom ), "Definisseur" )]
		public CListeObjetsDonnees RelationsChampsCustomListe
		{
			get
			{
				return GetDependancesListe(CRelationFamilleEquipement_ChampCustom.c_nomTable, c_champId);
			}
		}

		//-------------------------------------------------------------------
		[RelationFille(typeof(CRelationFamilleEquipement_Formulaire), "Definisseur")]
		public CListeObjetsDonnees RelationsFormulairesListe
		{
			get
			{
				return GetDependancesListe(CRelationFamilleEquipement_Formulaire.c_nomTable, c_champId);
			}
		}

        /*
		//-------------------------------------------------------------------
		public IRelationDefinisseurChamp_ChampCustom[] RelationsChampsCustomDefinis
		{
			get
			{
				return (IRelationDefinisseurChamp_ChampCustom[])RelationsChampsCustomListe.ToArray(typeof(IRelationDefinisseurChamp_ChampCustom));
			}
		}

		//-------------------------------------------------------------------
		public IRelationDefinisseurChamp_Formulaire[] RelationsFormulaires
		{
			get 
			{
				return (IRelationDefinisseurChamp_Formulaire[])RelationsFormulairesListe.ToArray(typeof(IRelationDefinisseurChamp_Formulaire));
			}
		}

		//-------------------------------------------------------------------
        public CRoleChampCustom RoleChampCustomDesElementsAChamp
		{
			get
			{
				return CRoleChampCustom.GetRole(CTypeEquipement.c_roleChampCustom);
			}
		}*/

        //-------------------------------------------------------------------
        public IDefinisseurChampCustomRelationObjetDonnee GetDefinisseurPourTypeEquipement()
        {
            return new CDefinisseurChampsFamilleEquipement(this, CTypeEquipement.c_roleChampCustom);
        }

        //-------------------------------------------------------------------
        public IDefinisseurChampCustomRelationObjetDonnee GetDefinisseurPourTypeConsommable()
        {
            return new CDefinisseurChampsFamilleEquipement(this, CTypeConsommable.c_roleChampCustom);
        }
       
		//-------------------------------------------------------------------
        public CChampCustom[] GetTousLesChampsAssocies(string strCodeRole)
        {
            Hashtable tableChamps = new Hashtable();
            FillHashtableChamps(tableChamps, strCodeRole);
            CChampCustom[] liste = new CChampCustom[tableChamps.Count];
            int nChamp = 0;
            foreach (CChampCustom champ in tableChamps.Values)
                liste[nChamp++] = champ;
            return liste;
        }
        //-------------------------------------------------------------------
        /// <summary>
        /// Remplit une hashtable IdChamp->Champ
        /// avec tous les champs liés.(hiérarchique
        /// </summary>
        /// <param name="tableChamps">HAshtable à remplir</param>
        private void FillHashtableChamps(Hashtable tableChamps, string strCodeRole)
        {
            foreach (IRelationDefinisseurChamp_ChampCustom relation in RelationsChampsCustomListe)
            {
                if (relation.ChampCustom.CodeRole == strCodeRole)
                    tableChamps[relation.ChampCustom.Id] = relation.ChampCustom;
            }
            foreach (IRelationDefinisseurChamp_Formulaire relation in RelationsFormulairesListe)
            {
                if (relation.Formulaire.CodeRole == strCodeRole)
                {
                    foreach (CRelationFormulaireChampCustom relFor in relation.Formulaire.RelationsChamps)
                        tableChamps[relFor.Champ.Id] = relFor.Champ;
                }
            }
            if (FamilleParente != null)
                FamilleParente.FillHashtableChamps(tableChamps, strCodeRole);
        }
	
		#endregion

        //-------------------------------------------------------------------
        public static CListeObjetsDonnees GetFamillesPourEquipements(CContexteDonnee contexte)
        {
            CListeObjetsDonnees lst = new CListeObjetsDonnees(
                contexte,
                typeof(CFamilleEquipement),
                new CFiltreData(CFamilleEquipement.c_champNoEquipment + "=@1",
                false));
            return lst;
        }

        //-------------------------------------------------------------------
        public static CListeObjetsDonnees GetFamillesPourConsommables(CContexteDonnee contexte)
        {
            CListeObjetsDonnees lst = new CListeObjetsDonnees(
                contexte,
                typeof(CFamilleEquipement),
                new CFiltreData(CFamilleEquipement.c_champNoConsommable + "=@1",
                false));
            return lst;
        }
	}
}
