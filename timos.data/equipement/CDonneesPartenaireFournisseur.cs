using System;
using System.Data;
using System.Collections;

using sc2i.data;
using sc2i.workflow;
using sc2i.common;
using sc2i.multitiers.client;
using sc2i.process;
using sc2i.data.dynamic;
using timos.acteurs;
using timos.data;
using tiag.client;
using timos.data.commandes;





namespace timos.data
{
	/// <summary>
    /// Le rôle de cette entité est de donner une propriété "Fournisseur" aux <see cref="CTypeEquipement">Types d'Equipements</see>. 
    /// Le Fournisseur est modélisé par un Acteur dans TIMOS. On retrouve donc sur le Fournisseur toutes les propriétés liées à l'<see cref="CActeur">Acteur</see>
    /// </summary>
    [sc2i.doccode.DocRefMenusOrMenuItems(CDocLabels.c_iEquipement)]
    [DynamicClass("Supplier")]
	[AutoExec("RegisterRole")]
	[ObjetServeurURI("CDonneesActeurFournisseurServeur")]
	[FullTableSync]
	[Table(CDonneesActeurFournisseur.c_nomTable, CDonneesActeurFournisseur.c_champId,true)]
	[RechercheRapide("Acteur.Nom")]
	[TiagClass(CDonneesActeurFournisseur.c_nomTiag, "Id", true)]
	public class CDonneesActeurFournisseur : CDonneesActeur,
								IElementAInterfaceTiag	
		
	{
		#region Déclaration des constantes
		public const string c_nomTiag = "Suppliers";
		public const string c_codeRole = "SUPPLIER";

		public const string c_nomTable = "SUPPLIER";
		public const string c_champId = "SUP_ID";

		#endregion

		//-------------------------------------------------------------------
		public CDonneesActeurFournisseur( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CDonneesActeurFournisseur( System.Data.DataRow row )
			:base(row)
		{
		}
		//-------------------------------------------------------------------
		public static void RegisterRole()
		{
			CRoleActeur.RegisterRole(c_codeRole, I.T("Supplier|104"), typeof(CDonneesActeurFournisseur));
		}
		//-------------------------------------------------------------------
		protected override void MyInitValeurDefaut()
		{
			base.MyInitValeurDefaut();
		}
		//-------------------------------------------------------------------
		public override string DescriptionElement
		{
			get
			{
				return I.T("The Supplier @1|261", Acteur.IdentiteComplete);
			}
		}

        [DescriptionField]
        public string Identite
        {
            get
            {
                if (Acteur != null)
                    return Acteur.IdentiteComplete;
                return "";
            }
        }

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


        //---------------------------------------------
        /// <summary>
        /// Liste des <see cref="CCommande">Commandes</see> passées à ce fournisseur
        /// </summary>
        [RelationFille(typeof(CCommande), "Fournisseur")]
        [DynamicChilds("Orders", typeof(CCommande))]
        public CListeObjetsDonnees Commandes
        {
            get
            {
                return GetDependancesListe(CCommande.c_nomTable, c_champId);
            }
        }

	}
}
