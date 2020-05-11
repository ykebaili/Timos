using System;
using System.Data;
using System.Collections;

using sc2i.data;
using sc2i.workflow;
using sc2i.common;
using sc2i.multitiers.client;
using sc2i.process;

using timos.acteurs;
using timos.data;
using tiag.client;


namespace timos.data
{
	/// <summary>
	/// Le rôle Client d'un <see cref="CActeur">Acteur</see>. La notion de Client est utilisée lors de la création d'un <see cref="CTicket">Ticket d'Intervention</see> 
    /// Le Ticket doit obligatoirement être lié à un Client.
	/// </summary>
    [sc2i.doccode.DocRefMenusOrMenuItems(CDocLabels.c_iActeur)]
    [DynamicClass("Customer")]
	[AutoExec("RegisterRole")]
	[ObjetServeurURI("CDonneesActeurClientServeur")]
	[FullTableSync]
	[Table(CDonneesActeurClient.c_nomTable, CDonneesActeurClient.c_champId,true)]
	[TiagClass(CDonneesActeurClient.c_nomTiag, "Id", true)]
	public class CDonneesActeurClient : CDonneesActeur,
								IElementAInterfaceTiag
	{
		#region Déclaration des constantes
		public const string c_nomTiag = "Customers";
		public const string c_codeRole = "CUSTOMER_ROLE";

		public const string c_nomTable = "CUSTOMER";
		public const string c_champId = "CUSTOMER_ID";

		#endregion

		//-------------------------------------------------------------------
		public CDonneesActeurClient( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CDonneesActeurClient( System.Data.DataRow row )
			:base(row)
		{
		}
		//-------------------------------------------------------------------
		public static void RegisterRole()
		{
			CRoleActeur.RegisterRole(c_codeRole, "Client", typeof(CDonneesActeurClient));
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
                return I.T("Customer : @1|281", Acteur.IdentiteComplete);
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

        [DescriptionField]
        public string Identite
        {
            get
            {
                if(Acteur != null)
                    return Acteur.IdentiteComplete;
                return "";
            }
        }
        
        //---------------------------------------------------------------------
        /// <summary>
        /// La liste des Tickets créés pour ce Client
        /// </summary>
        [RelationFille(typeof(CTicket), "Client")]
        [DynamicChilds("Tickets", typeof(CTicket))]
        public CListeObjetsDonnees Tickets
        {
            get
            {
                return GetDependancesListe(CTicket.c_nomTable, c_champId);
            }
        }



		//---------------------------------------------------------------------
		/// <summary>
		/// La liste des Contrats créés pour ce Client
		/// </summary>
		[RelationFille(typeof(CContrat), "Client")]
		[DynamicChilds("Contracts", typeof(CContrat))]
		public CListeObjetsDonnees Contrats
		{
			get
			{
				return GetDependancesListe(CContrat.c_nomTable, c_champId);
			}
		}
	}
}
