using System;
using System.Data;


using sc2i.common;

using sc2i.workflow;
using tiag.client;
using sc2i.data;

namespace timos.data
{
	/// <summary>
	/// Relation entre un <see cref="CTypeEquipement">Type d'Equipement</see> et un 
	/// <see cref="CDonneesActeurConstructeur">Constructeur</see>.
	/// </summary>
    [DynamicClass("Equipment Type / Manufacturer")]
    [Table(CRelationTypeEquipement_Constructeurs.c_nomTable, CRelationTypeEquipement_Constructeurs.c_champId, true)]
	[FullTableSync]
	[ObjetServeurURI("CRelationTypeEquipement_ConstructeursServeur")]
	[TiagClass ( CRelationTypeEquipement_Constructeurs.c_nomTiag,"Id", true )]
    //[RechercheRapide("TypeEquipement.Mnemonique")]
    //[RechercheRapide("TypeEquipement.Code")]
    //[RechercheRapide("TypeEquipement.Libelle")]
	public class CRelationTypeEquipement_Constructeurs : CObjetDonneeAIdNumeriqueAuto,
								IElementAInterfaceTiag
	{
		public const string c_nomTiag = "Equipment type/Manufacturer";

		public const string c_nomTable = "EQUIPMENT_TYPE_MANUF";

		public const string c_champId = "EQTTP_MAN_ID";
		public const string c_champReference = "EQTTP_MAN_REF";

		//////////////////////////////////////////////////////////////////////////
		public CRelationTypeEquipement_Constructeurs( CContexteDonnee contexte)
			:base(contexte)
		{
		}

		//////////////////////////////////////////////////////////////////////////
		public CRelationTypeEquipement_Constructeurs(DataRow row )
			:base(row)
		{
		}

		//////////////////////////////////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[] {c_champId};
		}

		//////////////////////////////////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				string strRetour = I.T( "Manufacturer|205") + " " + Constructeur != null ? Constructeur.Acteur.Nom : "";
                strRetour += " : " + Reference;
                return strRetour;
			}
		}

		//////////////////////////////////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
		}

		//-------------------------------------------------------------------
		/// <summary>
		/// Utilisé par TIAG pour affecter le type de site par ses clés
		/// </summary>
		/// <param name="lstCles"></param>
		public void TiagSetEquipmentTypeKeys(object[] lstCles)
		{
			CTypeEquipement typeEquipement = new CTypeEquipement(ContexteDonnee);
			if (typeEquipement.ReadIfExists(lstCles))
				TypeEquipement = typeEquipement;
		}
		
		//---------------------------------------------------------------------------
        /// <summary>
        /// Type de l'équipement concerné par la relation
        /// </summary>
		[RelationAttribute(
			CTypeEquipement.c_nomTable, 
			CTypeEquipement.c_champId,
		    CTypeEquipement.c_champId,
			true,
			true,
			false)]
		[DynamicField("Equipment type")]
		[TiagRelation(typeof(CTypeEquipement), "TiagSetEquipmentTypeKeys")]
		public CTypeEquipement TypeEquipement
		{
			get
			{
				return (CTypeEquipement)GetParent(CTypeEquipement.c_champId, typeof(CTypeEquipement));
			}
			set
			{
				SetParent(CTypeEquipement.c_champId, value);
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
		/// <summary>
		/// Utilisé par TIAG pour affecter le type de site par ses clés
		/// </summary>
		/// <param name="lstCles"></param>
		public void TiagSetManufacturerKeys(object[] lstCles)
		{
			CDonneesActeurConstructeur constructeur = new CDonneesActeurConstructeur(ContexteDonnee);
			if (constructeur.ReadIfExists(lstCles))
				Constructeur = constructeur;
		}

		//-----------------------------------------------------------
        /// <summary>
        /// Constructeur concerné par la relation
        /// </summary>
		[RelationAttribute(
			CDonneesActeurConstructeur.c_nomTable,
		   CDonneesActeurConstructeur.c_champId,
		   CDonneesActeurConstructeur.c_champId, 
			true, 
			false)]
		[DynamicField("Manufacturer")]
		[TiagRelation(typeof(CDonneesActeurConstructeur), "TiagSetManufacturerKeys")]
		public CDonneesActeurConstructeur Constructeur
		{
			get
			{
				return (CDonneesActeurConstructeur)GetParent(CDonneesActeurConstructeur.c_champId, typeof(CDonneesActeurConstructeur));
			}
			set
			{
				SetParent(CDonneesActeurConstructeur.c_champId, value);
			}
		}

		//////////////////////////////////////////////////////////////////////////
		/// <summary>
		/// Référence de l'équipement chez le fournisseur
		/// </summary>
		[TableFieldProperty ( CRelationTypeEquipement_Constructeurs.c_champReference, 128)]
		[DynamicField("Reference")]
		[TiagField("Reference")]
        [RechercheRapide]
		public string Reference
		{
			get
			{
				return (string)Row[c_champReference];
			}
			set
			{
				Row[c_champReference] = value;
			}
		}

        // Retourne le nom du constructeur suivi de sa référence
        [DescriptionField]
        public string ReferenceComplete
        {
            get
            {
                return Constructeur.Acteur.Libelle + ": " + Reference;
            }
        }
	}
}
