using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;


namespace timos.data.supervision
{
    /// <summary>
    /// Relation entre une <see cref="CAlarme">Alarme</see> et un 
    /// <see cref="sc2i.data.dynamic.CChampCustom">Champ personnalisé</see>.
    /// </summary>
    [DynamicClass("Alarm / Custom field")]
	[ObjetServeurURI("CRelationAlarme_ChampCustomServeur")]
	[Table(CRelationAlarme_ChampCustom.c_nomTable, CRelationAlarme_ChampCustom.c_champId,true)]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModuleSupervision)]
	public class CRelationAlarme_ChampCustom : CRelationElementAChamp_ChampCustom,
        IObjetSansVersion
	{
		public const string c_nomTable = "ALARM_CUSTOM_FIELD";
		public const string c_champId = "ALARM_CUSTFLD_ID";

		//-------------------------------------------------------------------
#if PDA
		public CRelationAlarme_ChampCustom()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationAlarme_ChampCustom(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationAlarme_ChampCustom(System.Data.DataRow row)
			:base(row)
		{
		}

		//-------------------------------------------------------------------
		public override Type GetTypeElementAChamps()
		{
			return typeof(CAlarme);
		}

		//-------------------------------------------------------------------
		public override string GetNomTable()
		{
			return c_nomTable;
		}
		//-------------------------------------------------------------------
		public override string GetChampId()
		{
			return c_champId;
		}

		
		//-------------------------------------------------------------------
        /// <summary>
        /// Alarme, objet de la relation
        /// </summary>
		[Relation(
			CAlarme.c_nomTable,
            CAlarme.c_champId,
            CAlarme.c_champId, 
			true, 
			true, 
			true)]
		[DynamicField("Alarm")]
		public override IElementAChamps ElementAChamps
		{
			get
			{
				return (IElementAChamps)GetParent(CAlarme.c_champId, typeof(CAlarme));
			}
			set
			{
				SetParent(CAlarme.c_champId, (CAlarme)value);
			}
		}

		//-------------------------------------------------------------------
	}
}
