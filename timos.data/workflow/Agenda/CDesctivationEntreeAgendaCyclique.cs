using System;
using System.Collections;
using System.IO;

using sc2i.data;
using sc2i.common;
using sc2i.process;
using sc2i.multitiers.client;

using sc2i.data.dynamic;
using sc2i.common.planification;


namespace sc2i.workflow
{
	/// <summary>
	/// Entit� de d�sactivation d'une entr�e d'agenda cyclique.<br/>
    /// Cette entit� permet d'indiquer qu'une entr�e cyclique<br/>
    /// est d�sactiv�e � une date donn�e
	/// </summary>
    [sc2i.doccode.DocRefMenusOrMenuItems(timos.data.CDocLabels.c_iPlanif)]
    [DynamicClass("Diary entry desactivation")]
	[ObjetServeurURI("CDesctivationEntreeAgendaCycliqueServeur")]
	[Table(CDesctivationEntreeAgendaCyclique.c_nomTable, CDesctivationEntreeAgendaCyclique.c_champId,true)]
	public class CDesctivationEntreeAgendaCyclique : CObjetDonneeAIdNumeriqueAuto
	{

		#region D�claration des constantes
		public const string c_nomTable = "DIARY_ENT_DESAC_CYCL";
		public const string c_champId = "DEDC_ID";
		public const string c_champDate = "DEDC_DATE";

		#endregion
		//-------------------------------------------------------------------
		public CDesctivationEntreeAgendaCyclique( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CDesctivationEntreeAgendaCyclique( System.Data.DataRow row )
			:base(row)
		{
		}
		//-------------------------------------------------------------------
		protected override void MyInitValeurDefaut()
		{
			Date = DateTime.Now;
		}
		//-------------------------------------------------------------------
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champDate};
		}
		//-------------------------------------------------------------------
		public override string DescriptionElement
		{
			get
			{
				return I.T("Desactivation of Cyclic Diary Entry|304");
			}
		}
		
		
		//-------------------------------------------------------------------
		/// <summary>
		/// Date de d�sactivation
		/// </summary>
		[TableFieldProperty(c_champDate)]
		[DynamicField("Date")]
		[DefaultFormat("d")]
		public DateTime Date
		{
			get
			{
				return (DateTime)Row[c_champDate];
			}
			set
			{
				Row[c_champDate] = value.Date;
			}

		}

		//-------------------------------------------------------------------
		/// <summary>
		/// Entr�e d'agenda d�sactiv�e
		/// </summary>
		[Relation ( CEntreeAgenda.c_nomTable,
			 CEntreeAgenda.c_champId,
			 CEntreeAgenda.c_champId,
			 true,
			 true,
			 true)]
		public CEntreeAgenda EntreeAgenda
		{
			get
			{
				return ( CEntreeAgenda)GetParent(CEntreeAgenda.c_champId, typeof(CEntreeAgenda));
			}
			set
			{
				SetParent ( CEntreeAgenda.c_champId, value );
			}
		}
	}
}
		
