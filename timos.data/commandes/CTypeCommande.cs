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
    /// Type de commande. D�finit le comportement des <see cref="CCommande">commandes</see> de ce type.
    /// </summary>
    [DynamicClass("Order type")]
    [Table(CTypeCommande.c_nomTable, CTypeCommande.c_champId, true)]
    [ObjetServeurURI("CTypeCommandeServeur")]
	[TiagClass(CTypeCommande.c_nomTiag, "Id", true)]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_Stock_ID)]
    public class CTypeCommande : CObjetDonneeAIdNumeriqueAuto,
                            IDefinisseurChampCustomRelationObjetDonnee,
							IElementAInterfaceTiag
    {
		public const string c_nomTiag = "Order_type";

        public const string c_nomTable = "ORDER_TYPE";
		public const string c_champId = "ORDERTYPE_ID";

		public const string c_champLibelle = "ORDERTYPE_LABEL";
		public const string c_champCommentaire = "ORDERTYPE_COMMENTS";


		/// /////////////////////////////////////////////
		public CTypeCommande( CContexteDonnee contexte)
			:base(contexte)
		{
		}

		/// /////////////////////////////////////////////
		public CTypeCommande(DataRow row)
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
        // Decription du Type de Site
		public override string DescriptionElement
		{
			get { return I.T( "Order Type: @1|20115", Libelle); }
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
		/// Libell� de ce Type de commande. 
        /// Ce champ texte de 255 caract�res maximum est obligatoire et unique.
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
        /// Le champ Commentaire est un texte libre de description du Type de commande. 
        /// 1024 caract�res maximum. Ce champ n'est pas obligatoire.
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

		[RelationFille(typeof(CRelationTypeCommande_ChampCustom), "Definisseur")]
        public CListeObjetsDonnees RelationsChampsCustomListe
        {
            get { return GetDependancesListe(CRelationTypeCommande_ChampCustom.c_nomTable, c_champId); }
        }

        [RelationFille(typeof(CRelationTypeCommande_Formulaire), "Definisseur")]
        public CListeObjetsDonnees RelationsFormulairesListe
        {
            get { return GetDependancesListe(CRelationTypeCommande_Formulaire.c_nomTable, c_champId); }
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
                return CRoleChampCustom.GetRole(CCommande.c_roleChampCustom);
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
        /// avec tous les champs li�s.(hi�rarchique)
        /// </summary>
        /// <param name="tableChamps">HAshtable � remplir</param>
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
