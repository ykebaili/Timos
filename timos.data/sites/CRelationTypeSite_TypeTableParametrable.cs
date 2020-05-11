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
	/// Relation entre un <see cref="CTypeSite">Type Site</see> et un 
	/// <see cref="CTypeTableParametrable">Type de Table Parametrable</see>.
	/// </summary>
    [DynamicClass("Site type / Custom table type")]
	[Table(CRelationTypeSite_TypeTableParametrable.c_nomTable, CRelationTypeSite_TypeTableParametrable.c_champId, true)]
	[FullTableSync]
	[ObjetServeurURI("CRelationTypeSite_TypeTableParametrableServeur")]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_TablesParam_ID)]
    public class CRelationTypeSite_TypeTableParametrable : CObjetDonneeAIdNumeriqueAuto
	{

		public const string c_nomTable = "SITETYPE_TCUSTOMTABLE";
		public const string c_champId = "SITT_TCTBL_ID";

		//////////////////////////////////////////////////////////////////////////
		public CRelationTypeSite_TypeTableParametrable(CContexteDonnee contexte)
			: base(contexte)
		{
		}

		//////////////////////////////////////////////////////////////////////////
		public CRelationTypeSite_TypeTableParametrable(DataRow row)
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
				return I.T( "Relation between @1 Site Type and @2 Custom Table Type|441", TypeSite.Libelle, TypeTableParametrable.Libelle);
			}
		}

		//////////////////////////////////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
		}

		//---------------------------------------------------------------------------
        /// <summary>
        /// <see cref="CTypeSite">Type de site</see> objet de la relation
        /// </summary>
		[RelationAttribute(
		   CTypeSite.c_nomTable,
		   CTypeSite.c_champId,
		   CTypeSite.c_champId,
			true,
			true,
			false)]
		[DynamicField("Site Type")]
		public CTypeSite TypeSite
		{
			get
			{
				return (CTypeSite)GetParent(CTypeSite.c_champId, typeof(CTypeSite));
			}
			set
			{
				SetParent(CTypeSite.c_champId, value);
			}
		}

		//-----------------------------------------------------------
        /// <summary>
        /// <see cref="CTypeTableParametrable">Table paramétrable</see>, objet de la relation
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
