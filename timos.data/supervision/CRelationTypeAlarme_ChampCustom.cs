using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;

namespace timos.data.supervision
{
    /// <summary>
    /// Relation entre une <see cref="CTypeAlarme">Type d'Alarme</see> et un 
    /// <see cref="sc2i.data.dynamic.CChampCustom">Champ personnalisé</see>.
    /// </summary>
    [DynamicClass("Alarm type / Custom field")]
	[ObjetServeurURI("CRelationTypeAlarme_ChampCustomServeur")]
	[Table(CRelationTypeAlarme_ChampCustom.c_nomTable, CRelationTypeAlarme_ChampCustom.c_champId, true)]
    [Unique(false,
        "Another association already exist for the relation Site Type/Custom Field|147",
        CTypeAlarme.c_champId,
        CChampCustom.c_champId)]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModuleSupervision)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_ParametrageSupervision_ID)]
    public class CRelationTypeAlarme_ChampCustom : CRelationDefinisseurChamp_ChampCustom
	{
		public const string c_nomTable = "ALARM_TYPE_CUSTOM_FIELD";
		public const string c_champId = "ARLMTP_CUSTFLD_ID";
        public const string c_champIsCle = "ARLMTP_CUSTFLD_KEY";

		//-------------------------------------------------------------------
#if PDA
		public CRelationTypeEO_ChampCustom()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationTypeAlarme_ChampCustom(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationTypeAlarme_ChampCustom(System.Data.DataRow row)
			:base(row)
		{
		}

        //-------------------------------------------------------------------
		[Relation(
            CTypeAlarme.c_nomTable,
            CTypeAlarme.c_champId,
            CTypeAlarme.c_champId,
            true, 
            true, 
            true)]
		public override IDefinisseurChampCustom Definisseur
		{
			get
			{
                return (IDefinisseurChampCustom)GetParent(CTypeAlarme.c_champId, typeof(CTypeAlarme));
			}
			set
			{
                SetParent(CTypeAlarme.c_champId, (CTypeAlarme)value);
			}
		}


        //-------------------------------------------------------------------
        /// <summary>
        /// Indicateur comme quoi le champ participe à la clé de l'alarme
        /// </summary>
        [TableFieldProperty(c_champIsCle)]
        [DynamicField("Is key")]
        public bool IsKey
        {
            get
            {
                return (bool)Row[c_champIsCle];
            }
            set
            {
                Row[c_champIsCle] = value;
            }
        }
	}
}
