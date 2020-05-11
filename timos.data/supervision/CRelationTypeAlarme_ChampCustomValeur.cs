using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;


namespace timos.data.supervision
{
    /// <summary>
    /// Relation entre une <see cref="CTypeAlarme">Alarme</see> et un 
    /// <see cref="sc2i.data.dynamic.CChampCustom">Champ personnalisé</see>.
    /// </summary>
    [DynamicClass("Alarm type / Custom field value")]
	[ObjetServeurURI("CRelationTypeAlarme_ChampCustomValeurServeur")]
	[Table(CRelationTypeAlarme_ChampCustomValeur.c_nomTable, CRelationTypeAlarme_ChampCustomValeur.c_champId,true)]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModuleSupervision)]
	public class CRelationTypeAlarme_ChampCustomValeur : CRelationElementAChamp_ChampCustom,
        IObjetSansVersion
	{
		public const string c_nomTable = "ALARMTP_CUSTOM_FIELD_VAL";
		public const string c_champId = "ALARMTPVAL_CUSTFLD_ID";

		//-------------------------------------------------------------------
#if PDA
		public CRelationTypeAlarme_ChampCustomValeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationTypeAlarme_ChampCustomValeur(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
        public CRelationTypeAlarme_ChampCustomValeur(System.Data.DataRow row)
			:base(row)
		{
		}

		//-------------------------------------------------------------------
		public override Type GetTypeElementAChamps()
		{
			return typeof(CTypeAlarme);
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
			CTypeAlarme.c_nomTable,
            CTypeAlarme.c_champId,
            CTypeAlarme.c_champId, 
			true, 
			true, 
			true)]
		[DynamicField("Alarm type")]
		public override IElementAChamps ElementAChamps
		{
			get
			{
				return (IElementAChamps)GetParent(CTypeAlarme.c_champId, typeof(CTypeAlarme));
			}
			set
			{
				SetParent(CTypeAlarme.c_champId, (CTypeAlarme)value);
			}
		}

		//-------------------------------------------------------------------
	}
}
