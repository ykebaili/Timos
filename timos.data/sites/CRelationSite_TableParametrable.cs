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
	/// Relation entre un <see cref="CSite">Site</see> et une 
	/// <see cref="CTableParametrable">Table Parametrable</see>.
	/// </summary>
    [DynamicClass("Site / Custom table")]
	[Table(CRelationSite_TableParametrable.c_nomTable, CRelationSite_TableParametrable.c_champId, true)]
	[FullTableSync]
	[ObjetServeurURI("CRelationSite_TableParametrableServeur")]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_TablesParam_ID)]
    public class CRelationSite_TableParametrable : CObjetDonneeAIdNumeriqueAuto
	{

		public const string c_nomTable = "SITE_CUSTOMTABLE";
		public const string c_champId = "SITE_CTBL_ID";

		//////////////////////////////////////////////////////////////////////////
		public CRelationSite_TableParametrable(CContexteDonnee contexte)
			: base(contexte)
		{
		}

		//////////////////////////////////////////////////////////////////////////
		public CRelationSite_TableParametrable(DataRow row)
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
				return I.T( "Relation between the @1 Site and the @2 Custom Table|442", Site.Libelle, TableParametrable.Libelle);
			}
		}

		//////////////////////////////////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
		}

		//---------------------------------------------------------------------------
        /// <summary>
        /// <see cref="CSite">Site</see> objet de la relation
        /// </summary>
		[RelationAttribute(
			CSite.c_nomTable,
			CSite.c_champId,
			CSite.c_champId,
			true,
			true,
			false)]
		[DynamicField("Site")]
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

		//----------------------------------------------------------
        /// <summary>
        /// <see cref="CTableParametrable">Table paramétrable</see> objet de la relation
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
