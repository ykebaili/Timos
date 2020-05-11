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
	/// Relation entre un <see cref="CTypeEquipement">Type d'Equipement</see> et un 
	/// <see cref="CTypeTableParametrable">Type de Table Paramétrable</see>.
	/// </summary>
    [DynamicClass("Equipment type / Custom table type")]
	[Table(CRelationTypeEquipement_TypeTableParametrable.c_nomTable, CRelationTypeEquipement_TypeTableParametrable.c_champId, true)]
	[FullTableSync]
	[ObjetServeurURI("CRelationTypeEquipement_TypeTableParametrableServeur")]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_TablesParam_ID)]
    public class CRelationTypeEquipement_TypeTableParametrable : CObjetDonneeAIdNumeriqueAuto
	{

		public const string c_nomTable = "EQT_TYPE_TCUSTOMTABLE";
		public const string c_champId = "TEQT_TCTBL_ID";

		//////////////////////////////////////////////////////////////////////////
		public CRelationTypeEquipement_TypeTableParametrable(CContexteDonnee contexte)
			: base(contexte)
		{
		}

		//////////////////////////////////////////////////////////////////////////
		public CRelationTypeEquipement_TypeTableParametrable(DataRow row)
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
				return I.T( "Relation between @1 Equipement Type and @2 Custom Table Type|440",TypeEquipement.Libelle,TypeTableParametrable.Libelle);
			}
		}

		//////////////////////////////////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
		}

		//---------------------------------------------------------------------------
        /// <summary>
        /// Type d'équipement objet de la relation
        /// </summary>
		[RelationAttribute(
		   CTypeEquipement.c_nomTable,
		   CTypeEquipement.c_champId,
		   CTypeEquipement.c_champId,
			true,
			true,
			false)]
		[DynamicField("Equipment Type")]
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

		//----------------------------------------------------------
        /// <summary>
        /// Type de table paramétrable objet de la relation
        /// </summary>
		[RelationAttribute(
		  CTypeTableParametrable.c_nomTable,
		 CTypeTableParametrable.c_champId,
		 CTypeTableParametrable.c_champId,
			true,
			true)]
		[DynamicField("Custom Table Type")]
		public CTypeTableParametrable TypeTableParametrable
		{
			get
			{
				return (CTypeTableParametrable)GetParent(CTypeTableParametrable.c_champId, typeof(CTypeTableParametrable));
			}
			set
			{
				SetParent(CTypeTableParametrable.c_champId, value);
			}
		}

	}
}
