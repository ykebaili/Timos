using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using sc2i.data.dynamic;

using Lys.Licence;
using Lys.Applications.Timos.Smt;

using timos.securite;
using tiag.client;
using timos.data.equipement;

namespace timos.data
{
	/// <summary>
	/// Definit le type de <see cref="CStock">Stocks</see>
	/// </summary>
    [sc2i.doccode.DocRefMenusOrMenuItems(CDocLabels.c_iStock)]
    [DynamicClass("Stock type")]
	[Table(CTypeStock.c_nomTable, CTypeStock.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CTypeStockServeur")]
	[TiagClass(CTypeStock.c_nomTiag, "Id", true)]
    //[AModulesApp(CConfigModulesTimos.c_appModule_Stock_ID)]
    [AutoExec("Autoexec")]
    public class CTypeStock :
        CElementAChamp,
		IObjetALectureTableComplete,
		IElementAInterfaceTiag,
        IDefinisseurChampCustomRelationObjetDonnee
        
	{
		public const string c_nomTiag = "Stock type";
		public const string c_nomTable = "STOCK_TYPE";
		
		public const string c_champId = "STKTYP_ID";
		public const string c_champLibelle = "STKTYP_LABEL";

        public const string c_roleChampCustom = "STOCK_TYPE";


		/// /////////////////////////////////////////////
		public CTypeStock( CContexteDonnee contexte)
			:base(contexte)
		{
		}

		/// /////////////////////////////////////////////
		public CTypeStock(DataRow row )
			:base(row)
		{
		}

        //-------------------------------------------------------------------
        public static void Autoexec()
        {
            CRoleChampCustom.RegisterRole(c_roleChampCustom, "Stock type", typeof(CTypeStock), typeof(CDefinisseurChampsPourTypeSansDefinisseur));
        }

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T("Stock type|106")+" "+Libelle;
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champLibelle};
		}

		public object[] TiagKeys
		{
			get { return new object[] { Id }; }
		}

		public string TiagType
		{
			get { return c_nomTiag; }
		}

		//-----------------------------------------------------
        /// <summary>
        /// Libellé du type de stock
        /// </summary>
		[TableFieldProperty(c_champLibelle, 255)]
		[DynamicField("Label")]
		[TiagField("Label")]
        [DescriptionField]
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
        /// Liste des relations entre le type de stock et les types d'équipements
        /// </summary>
        [RelationFille(typeof(CRelationTypeEquipement_TypeStock), "TypeStock")]
        [DynamicChilds("Equipment types relations", typeof(CRelationTypeEquipement_TypeStock))]
        public CListeObjetsDonnees RelationsTypesEquipements
        {
            get
            {
                return GetDependancesListe(CRelationTypeEquipement_TypeStock.c_nomTable, c_champId);
            }
        }

        //-------------------------------------------------------------------------------
        /// <summary>
        /// Retourne la relation entre le stock et un type d'équipement précis
        /// </summary>
        /// <param name="equipement">Le type d'équipement</param>
        /// <returns>La relation</returns>
        [DynamicMethod("Retourne l'objet Relation Type_Equipement/Type_Stock d'un type d'équipement", "Le Type d'Equipement concerné")]
        public CRelationTypeEquipement_TypeStock GetRelationTypeEquipemetStock(CTypeEquipement typeEqpt)
        {
            if (typeEqpt == null)
                return null;

            CRelationTypeEquipement_TypeStock rel = new CRelationTypeEquipement_TypeStock(this.ContexteDonnee);
            if (rel.ReadIfExists(
                    new CFiltreData(
                        CTypeStock.c_champId + " = @1 and " + CTypeEquipement.c_champId + " = @2 ",
                        this.Id,
                        typeEqpt.Id)))
            {
                return rel;
            }
            else
            {
                rel.CreateNewInCurrentContexte();
                rel.TypeStock = this;
                rel.TypeEquipement = typeEqpt;

                return rel;
            }
        }


        #region IDefinisseurChampCustomRelationObjetDonnee Membres

        [RelationFille(typeof(CRelationTypeStock_ChampCustom), "Definisseur")]
        public CListeObjetsDonnees RelationsChampsCustomListe
        {
            get { return GetDependancesListe(CRelationTypeStock_ChampCustom.c_nomTable, c_champId); }
        }

        [RelationFille(typeof(CRelationTypeStock_Formulaire), "Definisseur")]
        public CListeObjetsDonnees RelationsFormulairesListe
        {
            get { return GetDependancesListe(CRelationTypeStock_Formulaire.c_nomTable, c_champId); }
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
                return CRoleChampCustom.GetRole(CStock.c_roleChampCustom);
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

        public override IDefinisseurChampCustom[] DefinisseursDeChamps
        {
            get
            {
                return new IDefinisseurChampCustom[]{
                    new CDefinisseurChampsPourTypeSansDefinisseur(
                        ContexteDonnee, 
                        CRoleChampCustom.GetRole(CTypeStock.c_roleChampCustom) )};
            }
        }

        public override CRelationElementAChamp_ChampCustom GetNewRelationToChamp()
        {
            return new CRelationTypeStock_ChampCustomValeur(ContexteDonnee);
        }

        [RelationFille(typeof(CRelationTypeStock_ChampCustomValeur), "ElementAChamps")]
        public override CListeObjetsDonnees RelationsChampsCustom
        {
            get
            {
                return GetDependancesListe(CRelationTypeStock_ChampCustomValeur.c_nomTable, c_champId);
            }
        }

        public override CRoleChampCustom RoleChampCustomAssocie
        {
            get
            {
                return CRoleChampCustom.GetRole(CTypeStock.c_roleChampCustom);
            }
        }
		
    
    }
}
