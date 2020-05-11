using System;
using System.Collections;
using System.IO;

using sc2i.common;
using sc2i.data;
using sc2i.data.dynamic;
using tiag.client;


namespace timos.data
{
	/// <summary>
	/// La famille d'un <see cref="CTypeEquipementLogique" equipement logique</see> correspond à une
	/// nature.<br/>
	/// La famille est obligatoire lors de la création d'un type d'équipement logique.
	/// </summary>
	[DynamicClass("Logical equipment family")]
	[ObjetServeurURI("CFamilleEquipementLogiqueServeur")]
	[Table(CFamilleEquipementLogique.c_nomTable, CFamilleEquipementLogique.c_champId,true)]
	[FullTableSync]
	[TiagClass(CFamilleEquipementLogique.c_nomTiag, "Id", true)]
	public class CFamilleEquipementLogique : CObjetHierarchique, 
		IObjetALectureTableComplete,
		IDefinisseurChampCustomRelationObjetDonnee,
		IElementAInterfaceTiag

	{

		#region Déclaration des constantes
		public const string c_nomTiag = "Logical equipment family";


		public const string c_nomTable = "EQUIPMENT_FUNC_FAMILY";
		public const string c_champId = "EQTFNCFAM_ID";
		public const string c_champLibelle = "EQTFNCFAM_LIBELLE";
		public const string c_champCodePartiel = "EQTFNCFAM_PARTIAL_SYSCODE";
		public const string c_champCodeComplet = "EQTFNCFAM_FULL_SYSCODE";
		public const string c_champNiveau = "EQTFNCFAM_LEVEL";
		public const string c_champIdParent = "FAMEQTFNCFAM_PARENT_ID";


		#endregion
		//-------------------------------------------------------------------
		public CFamilleEquipementLogique( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CFamilleEquipementLogique( System.Data.DataRow row )
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
				return I.T("Logical Equipment Family @1|20019",Libelle);
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
		/// Système Code partiel de la famille ( code dans sa famille principale )
		/// </summary>
		[
		TableFieldProperty(c_champCodePartiel, 2),
		DynamicField("Partial system code")
		]
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
		/// Système : Code complet de la famille, incluant les codes
		/// des familles de niveau supérieur
		/// </summary>
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
		/// Niveau de la famille. La famille 'root' est au niveau 0.
		/// </summary>
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
			CFamilleEquipementLogique famille = new CFamilleEquipementLogique(ContexteDonnee);
			if (famille.ReadIfExists(lstCles))
				FamilleParente = famille;
		}

		//-------------------------------------------------------------------
		/// <summary>
		/// Famille partente
		/// </summary>
		[Relation ( CFamilleEquipementLogique.c_nomTable, 
			 CFamilleEquipementLogique.c_champId,
			 c_champIdParent,
			 false,
			 false,
			 false)]
		[DynamicField("Parent family")]
		[TiagRelation(typeof(CFamilleEquipementLogique), "TiagSetParentFamilyKeys")]
		public  CFamilleEquipementLogique FamilleParente
		{
			get
			{
				return (CFamilleEquipementLogique)ObjetParent;
			}
			set
			{
                if (value != null)
                    ObjetParent = value;
			}
		}

		//-------------------------------------------------------------------
		/// <summary>
		/// Retourne les familles filles
		/// </summary>
		[RelationFille(typeof(CFamilleEquipementLogique), "FamilleParente")]
		[DynamicChilds("Child families", typeof(CFamilleEquipementLogique))]
		public CListeObjetsDonnees FamillesFilles
		{
			get
			{
				return ObjetsFils;
			}
		}


        //-----------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        [RelationFille(typeof(CTypeEquipementLogique), "Famille")]
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
		[RelationFille ( typeof ( CRelationFamillEquipementLogique_ChampCustom ), "Definisseur" )]
		public CListeObjetsDonnees RelationsChampsCustomListe
		{
			get
			{
				return GetDependancesListe(CRelationFamillEquipementLogique_ChampCustom.c_nomTable, c_champId);
			}
		}

		//-------------------------------------------------------------------
		[RelationFille(typeof(CRelationFamilleEquipementLogique_Formulaire), "Definisseur")]
		public CListeObjetsDonnees RelationsFormulairesListe
		{
			get
			{
				return GetDependancesListe(CRelationFamilleEquipementLogique_Formulaire.c_nomTable, c_champId);
			}
		}


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
		public CRoleChampCustom RoleChampCustomAssocie
		{
			get
			{
				return CRoleChampCustom.GetRole(CTypeEquipementLogique.c_roleChampCustom);
			}
		}

		//-------------------------------------------------------------------
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
		/// avec tous les champs liés.(hiérarchique
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
			if ( FamilleParente != null )
				FamilleParente.FillHashtableChamps(tableChamps);
		}
		#endregion
	}
}
