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


namespace timos.data
{
	/// <summary>
	/// Le rôle de cette entité est de donner une propriété "Constructeur" aux <see cref="CTypeEquipement">Types d'Equipements</see>. 
    /// Le Constructeur est modélisé par un Acteur dans TIMOS. On retrouve donc sur le Constructeur toutes les propriétés liées à l'<see cref="CActeur">Acteur</see>
    /// </summary>
    [sc2i.doccode.DocRefMenusOrMenuItems(CDocLabels.c_iEquipement)]
    [DynamicClass("Manufacturer")]
	[AutoExec("RegisterRole")]
	[ObjetServeurURI("CDonneesActeurConstructeurServeur")]
	[FullTableSync]
	[Table(CDonneesActeurConstructeur.c_nomTable, CDonneesActeurConstructeur.c_champId,true)]
	[RechercheRapide("Acteur.Nom")]
	[TiagClass(CDonneesActeurConstructeur.c_nomTiag, "Id", true)]
	public class CDonneesActeurConstructeur : CDonneesActeur,
								IElementAInterfaceTiag	
		
	{
		public const string c_nomTiag = "Manufacturer";
		public const string c_codeRole = "MANUFACTURER";

		public const string c_nomTable = "MANUFACTURER";
		public const string c_champId = "MAN_ID";


		//-------------------------------------------------------------------
		public CDonneesActeurConstructeur( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CDonneesActeurConstructeur( System.Data.DataRow row )
			:base(row)
		{
		}
		//-------------------------------------------------------------------
		public static void RegisterRole()
		{
			CRoleActeur.RegisterRole(c_codeRole, I.T("Manufacturer|205"), typeof(CDonneesActeurConstructeur));
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
				return I.T( "Manufacturer @1|260", Acteur.IdentiteComplete);
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

	}
}
