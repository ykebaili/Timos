using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;


namespace timos.data
{
	/// <summary>
	/// Relation entre une <see cref="CActiviteActeur">Activite d'Acteur</see> et une
	/// <see cref="CChampCustomValeur">Valeur de Champ personnalisé</see>
	/// </summary>
    [DynamicClass("Member activity / Custom field value")]
	[ObjetServeurURI("CRelationActiviteActeur_ChampCustomValeurServeur")]
	[Table(CRelationActiviteActeur_ChampCustomValeur.c_nomTable, CRelationActiviteActeur_ChampCustomValeur.c_champId,true)]
	[FullTableSync]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_SuiviActivite_ID)]
    public class CRelationActiviteActeur_ChampCustomValeur : CRelationElementAChamp_ChampCustom
	{
		public const string c_nomTable = "MEMBACT_CUSTOM_FIELD";
		public const string c_champId = "MBMACTFLD_CUST_ID";

		//-------------------------------------------------------------------
#if PDA
		public CRelationActiviteActeur_ChampCustomValeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationActiviteActeur_ChampCustomValeur(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationActiviteActeur_ChampCustomValeur(System.Data.DataRow row)
			:base(row)
		{
		}

		//-------------------------------------------------------------------
		public override Type GetTypeElementAChamps()
		{
			return typeof(CActiviteActeur);
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
        /// Activité d'acteur, objet de la relation
        /// </summary>
		[Relation(
			CActiviteActeur.c_nomTable,
            CActiviteActeur.c_champId,
            CActiviteActeur.c_champId, 
			true, 
			true, 
			true)]
		[DynamicField("Member activity")]
		public override IElementAChamps ElementAChamps
		{
			get
			{
				return (IElementAChamps)GetParent(CActiviteActeur.c_champId, typeof(CActiviteActeur));
			}
			set
			{
				SetParent(CActiviteActeur.c_champId, (CActiviteActeur)value);
			}
		}

		//-------------------------------------------------------------------
	}
}
