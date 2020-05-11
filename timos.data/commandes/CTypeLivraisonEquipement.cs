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
using tiag.client;
using sc2i.doccode;

using timos.data.tiag;

namespace timos.data.commandes
{

    /// <summary>
    /// Type de livraison équipement. 
    /// Définit le comportement pour les <see cref="CLivraisonEquipement">livraisons équipement</see> de ce type.
    /// </summary>
    [DynamicClass("Delivery type")]
    [Table(CTypeLivraisonEquipement.c_nomTable, CTypeLivraisonEquipement.c_champId, true)]
    [ObjetServeurURI("CTypeLivraisonEquipementServeur")]
	[TiagClass(CTypeLivraisonEquipement.c_nomTiag, "Id", true)]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_Stock_ID)]
    public class CTypeLivraisonEquipement : CObjetDonneeAIdNumeriqueAuto,
                            IDefinisseurChampCustomRelationObjetDonnee,
							IElementAInterfaceTiag
    {
		public const string c_nomTiag = "Delivery_type";

        public const string c_nomTable = "DELIVERY_TYPE";
		public const string c_champId = "DELIVTYPE_ID";

		public const string c_champLibelle = "DELIVTYPE_LABEL";
		public const string c_champCommentaire = "ORDERTYPE_COMMENTS";


		/// /////////////////////////////////////////////
		public CTypeLivraisonEquipement( CContexteDonnee contexte)
			:base(contexte)
		{
		}

		/// /////////////////////////////////////////////
		public CTypeLivraisonEquipement(DataRow row)
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
        // Decription du Type de Site
		public override string DescriptionElement
		{
			get { return I.T( "Delivrery Type: @1|20119", Libelle); }
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

		 /////////////////////////////////////////////
        /// <summary>
		/// Libellé pour ce Type de Livraison Equipement. 
        /// Ce champ texte de 255 caractères maximum est obligatoire et unique.
        /// </summary>
        [TableFieldProperty(c_champLibelle, 255)]
        [DynamicField("Label")]
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

        // /////////////////////////////////////////////
        /// <summary>
        /// Le champ Commentaire est un texte libre de description du Type de Livraison Equipement. 
        /// 1024 caractères maximum. Ce champ n'est pas olbigatoire.
        /// </summary>
        [TableFieldProperty(c_champCommentaire, 1024)]
        [DynamicField("Comment")]
        [TiagField("Comment")]
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


		
		#region IDefinisseurChampCustomRelationObjetDonnee Membres

		[RelationFille(typeof(CRelationTypeLivraisonEquipement_ChampCustom), "Definisseur")]
        public CListeObjetsDonnees RelationsChampsCustomListe
        {
            get { return GetDependancesListe(CRelationTypeLivraisonEquipement_ChampCustom.c_nomTable, c_champId); }
        }

        [RelationFille(typeof(CRelationTypeLivraisonEquipement_Formulaire), "Definisseur")]
        public CListeObjetsDonnees RelationsFormulairesListe
        {
            get { return GetDependancesListe(CRelationTypeLivraisonEquipement_Formulaire.c_nomTable, c_champId); }
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
                return CRoleChampCustom.GetRole(CLivraisonEquipement.c_roleChampCustom);
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

     }
}
