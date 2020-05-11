using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;

using tiag.client;

using timos.data;
using System.Collections.Generic;

namespace timos.data
{
	/// <summary>
    /// D�finit une extr�mit� de liaison sur un <see cref="CSite">site</see>
	/// </summary>
    /// <remarks>
    /// Une liaison de t�l�communication peut s'�tablir soit entre deux <see cref="CSite">sites</see>, soit entre
    /// deux entit�s compl�mentaires aux sites appel�es "extr�mit�".
    /// Une extr�mit� est en r�alit� un sous-ensemble d'un site d�sign� comme point d'acc�s d'une liaison.
    /// </remarks>
    [DynamicClass("Link end")]
	[Table(CExtremiteLienSurSite.c_nomTable, CExtremiteLienSurSite.c_champId, true )]
	[FullTableSync]
    [ObjetServeurURI("CExtremiteLienSurSiteServeur")]
    [TiagClass("Link end","Id", true)]
	public class CExtremiteLienSurSite : CObjetDonneeAIdNumeriqueAuto,IComplementElementALiensReseau
	{
		public const string c_nomTable = "LINK_END";
		public const string c_champId = "LNKEND_ID";
		public const string c_champLibelle = "LNKEND_LABEL";

		/// /////////////////////////////////////////////
		public CExtremiteLienSurSite( CContexteDonnee contexte)
			:base(contexte)
		{
		}
		
	/// /////////////////////////////////////////////
		public CExtremiteLienSurSite(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T("Link end : @1|20033",Libelle);
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


		

		/// <summary>
		/// Le libell� de l'extr�mit�
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

        //-------------------------------------------------------------------
        /// <summary>
        /// Utilis� par TIAG pour affecter le site  par ses cl�s
        /// </summary>
        /// <param name="lstCles"></param>
        public void TiagSetSiteKeys(object[] lstCles)
        {
            CSite site =new CSite ( ContexteDonnee );
            if (site.ReadIfExists(lstCles))
                Site = site;
        }
        //-------------------------------------------------------------------
        /// <summary>
        /// <see cref="CSite">Site</see> auquel l'extr�mit� est attach�e
        /// </summary>
        [Relation(
            CSite.c_nomTable,
            CSite.c_champId,
            CSite.c_champId,
            true,
            true,
            false)]
        [DynamicField("Site")]
        [TiagRelation(typeof(CSite), "TiagSetSiteKeys")]
        public CSite Site
        {
            get
            {
                return (CSite)GetParent(CSite.c_champId, typeof(CSite));
            }
            set
            {
                SetParent(CSite.c_champId, value);
            }
        }


		
		//---------------------------------------------
		/// <summary>
        /// Liste des <see cref="CLienReseau">liens</see> de t�l�communication (liaisons), pour lequels cette extr�mit� est la num�ro 1
		/// </summary>
		[RelationFille ( typeof( CLienReseau ), "ExtremiteSurSite1")]
		[DynamicChilds("Links as element 1",typeof(CLienReseau))]
		public CListeObjetsDonnees LiensCommeExtremite1
		{
			get
			{
				return GetDependancesListe(CLienReseau.c_nomTable, CLienReseau.c_champExtremiteSite1);
			}
		}

		
		//---------------------------------------------
		/// <summary>
        /// Liste des <see cref="CLienReseau">liens</see> de t�l�communication (liaisons), pour lequels cette extr�mit� est la num�ro 2
		/// </summary>
		[RelationFille ( typeof( CLienReseau ), "ExtremiteSurSite2")]
		[DynamicChilds("Links as element 2",typeof(CLienReseau))]
		public CListeObjetsDonnees LiensCommeExtremite2
		{
			get
			{
				return GetDependancesListe(CLienReseau.c_nomTable, CLienReseau.c_champExtremiteSite2);
			}
		}


        #region IComplementElementALiensReseau Membres

        public CLienReseau[] Liens
        {
            get
            {
                List<CLienReseau> liens = new List<CLienReseau>();
                foreach (CLienReseau lien in LiensCommeExtremite1)
                    liens.Add(lien);
                foreach (CLienReseau lien in LiensCommeExtremite2)
                    liens.Add(lien);
                return liens.ToArray();
            }
        }

        #endregion
    }
}
