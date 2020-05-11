using System;
using System.Collections;
using System.Data;
using System.Collections.Generic;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;

namespace timos.data
{
	/// <summary>
	/// Relation entre un <see cref="CEquipement">Equipement</see> et une 
	/// <see cref="CTableParametrable">Table Paramétrable</see>.
	/// </summary>
    [DynamicClass("Equipment / Custom table")]
	[Table(CRelationEquipement_TableParametrable.c_nomTable, CRelationEquipement_TableParametrable.c_champId, true)]
	[FullTableSync]
	[ObjetServeurURI("CRelationEquipement_TableParametrableServeur")]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_TablesParam_ID)]
    public class CRelationEquipement_TableParametrable : CObjetDonneeAIdNumeriqueAuto
	{

		public const string c_nomTable = "EQUIPMENT_CUSTOMTABLE";
		public const string c_champId = "EQTTB_CTBL_ID";

		//////////////////////////////////////////////////////////////////////////
		public CRelationEquipement_TableParametrable(CContexteDonnee contexte)
			: base(contexte)
		{
		}

		//////////////////////////////////////////////////////////////////////////
		public CRelationEquipement_TableParametrable(DataRow row)
			: base(row)
		{
		}

		//////////////////////////////////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[] { c_champId };
		}

		//////////////////////////////////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T( "Relation between the @1 Equipement and the @2 Custom Table|439", Equipement.Libelle, TableParametrable.Libelle);
			}
		}

		//////////////////////////////////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
		}

		//---------------------------------------------------------------------------
        /// <summary>
        /// Equipement concerné par la relation
        /// </summary>
		[RelationAttribute(
			CEquipement.c_nomTable,
			CEquipement.c_champId,
			CEquipement.c_champId,
			true,
			true,
			false)]
		[DynamicField("Equipment")]
		public CEquipement Equipement
		{
			get
			{
				return (CEquipement)GetParent(CEquipement.c_champId, typeof(CEquipement));
			}
			set
			{
				SetParent(CEquipement.c_champId, value);
			}
		}

		//-------------------------------------------------------------------
        /// <summary>
        /// Table paramétrable concernée par la relation
        /// </summary>
		[RelationAttribute(
		   CTableParametrable.c_nomTable,
		  CTableParametrable.c_champId,
		  CTableParametrable.c_champId,
			true,
			false)]
		[DynamicField("Custom Table")]
		public CTableParametrable TableParametrable
		{
			get
			{
				return (CTableParametrable)GetParent(CTableParametrable.c_champId, typeof(CTableParametrable));
			}
			set
			{
				SetParent(CTableParametrable.c_champId, value);
			}
		}

	}
}
