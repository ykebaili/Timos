using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;


namespace timos.data
{
	/// <summary>
	/// Relation entre une <see cref="CActiviteActeurResume">Résumé d'Activite d'Acteur</see> et une
	/// <see cref="CChampCustomValeur">Valeur de Champ Custom</see>
	/// </summary>
    [DynamicClass("Member activity summary / Custom field value")]
	[ObjetServeurURI("CRelationActiviteActeurResume_ChampCustomValeurServeur")]
	[Table(CRelationActiviteActeurResume_ChampCustomValeur.c_nomTable, CRelationActiviteActeurResume_ChampCustomValeur.c_champId,true)]
	[FullTableSync]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_SuiviActivite_ID)]
    public class CRelationActiviteActeurResume_ChampCustomValeur : CRelationElementAChamp_ChampCustom
	{
		public const string c_nomTable = "MEMBACTSUM_CUSTOM_FIELD";
		public const string c_champId = "MBMACTFLDSUM_CUST_ID";

		//-------------------------------------------------------------------
#if PDA
		public CRelationActiviteActeurResume_ChampCustomValeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationActiviteActeurResume_ChampCustomValeur(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationActiviteActeurResume_ChampCustomValeur(System.Data.DataRow row)
			:base(row)
		{
		}

		//-------------------------------------------------------------------
		public override Type GetTypeElementAChamps()
		{
			return typeof(CActiviteActeurResume);
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
        /// Résumé d'activité d'acteur, objet de la relation
        /// </summary>
		[Relation(
			CActiviteActeurResume.c_nomTable,
            CActiviteActeurResume.c_champId,
            CActiviteActeurResume.c_champId, 
			true, 
			true, 
			true)]
		[DynamicField("Member activity summary")]
		public override IElementAChamps ElementAChamps
		{
			get
			{
				return (IElementAChamps)GetParent(CActiviteActeurResume.c_champId, typeof(CActiviteActeurResume));
			}
			set
			{
				SetParent(CActiviteActeurResume.c_champId, (CActiviteActeurResume)value);
			}
		}

		//-------------------------------------------------------------------
	}
}
