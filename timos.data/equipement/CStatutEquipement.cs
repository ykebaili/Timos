using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using tiag.client;

namespace timos.data
{
	/// <summary>
	/// Le statut d'un <see cref="CEquipement">équipement</see> renseigne sur 
	/// son etat actuel.<br/>
	/// Vous êtes entièrement libre de créer vos propres statuts pour pouvoir 
	/// gérer vos équipements selon votre activité et les etats possibles que vous 
	/// souhaitez renseigner dans votre gestion.
	/// </summary>
    [sc2i.doccode.DocRefMenusOrMenuItems(CDocLabels.c_iEquipement)]
    [DynamicClass("Equipment status")]
	[Table(CStatutEquipement.c_nomTable, CStatutEquipement.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CStatutEquipementServeur")]
	[TiagClass(CStatutEquipement.c_nomTiag, "Id", true)]
	public class CStatutEquipement : CObjetDonneeAIdNumeriqueAuto, IObjetALectureTableComplete,
								IElementAInterfaceTiag
	{
		public const string c_nomTiag = "Equipment status";
		public const string c_nomTable = "EQUIPMENT_STATUTE";
		
		public const string c_champId = "EQTSTA_ID";
		public const string c_champLibelle = "EQTSTA_LABEL";
		public const string c_champStatutDeBase = "EQTSTA_BASE_STATUTE";
		public const string c_champCode = "EQTSTA_CODE";

#if PDA
		//-------------------------------------------------------------------
		public CStatutEquipement()
			:base()
		{
		}
#endif
		/// /////////////////////////////////////////////
		public CStatutEquipement( CContexteDonnee contexte)
			:base(contexte)
		{
		}

		/// /////////////////////////////////////////////
		public CStatutEquipement(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T( "Equipment status @1|111", Libelle);
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

		  /////////////////////////////////////////////
		/// <summary>
		/// Libellé du Statut<br/>
		/// (obligatoire)
		/// </summary>
		[TableFieldProperty(c_champLibelle, 30)]
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

		////////////////////////////////////////////////
		/// <summary>
		/// code du statut
		/// </summary>
		[TableFieldProperty ( CStatutEquipement.c_champCode, 64)]
		[DynamicField("Code")]
		[TiagField("Code")]
		public string Code
		{
			get
			{
				return ( string )Row[c_champCode];
			}
			set
			{
				Row[c_champCode] = value;
			}
		}

		////////////////////////////////////////////////
		/// <summary>
		/// Statut de base sur lequel s'appuie ce statut
		/// </summary>
		[TableFieldProperty ( CStatutEquipement.c_champStatutDeBase )]
		[DynamicField("Base status code")]
		[TiagField("Base status code")]
		public int StatutBaseInt
		{
			get
			{
				return (int)Row[c_champStatutDeBase];
			}
			set
			{
				Row[c_champStatutDeBase] = value;
			}
		}

		////////////////////////////////////////////////
		/// <summary>
		/// Code du statut de base sur lequel s'appuie ce statut
		/// </summary>
		[DynamicField("Base status")]
		public CStatutBaseEquipement StatutDeBase
		{
			get
			{
				return new CStatutBaseEquipement((StatutBaseEquipement)StatutBaseInt);
			}
			set
			{
				if (value != null)
					StatutBaseInt = value.CodeInt;
			}
		}
	}
}
