using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;

namespace sc2i.workflow
{
	/// <summary>
    /// Relation entre un <see cref="CTypeEntreeAgenda">Type d'entrée d'agenda</see> et un 
    /// <see cref="sc2i.data.dynamic.CChampCustom">Champ personnalisé</see>.
	/// </summary>
    [DynamicClass("Diary entry type / Custom field")]
	[ObjetServeurURI("CRelationTypeEntreeAgenda_ChampCustomServeur")]
	[Table(CRelationTypeEntreeAgenda_ChampCustom.c_nomTable, CRelationTypeEntreeAgenda_ChampCustom.c_champId,true)]
	[FullTableSync]
    //[Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_TypeEntreeAgenda_ID)]
    public class CRelationTypeEntreeAgenda_ChampCustom : CRelationDefinisseurChamp_ChampCustom
	{
		#region Déclaration des constantes
		public const string c_nomTable = "DIARY_TYPE_CUSTOM_FIELD";
		public const string c_champId = "DRYTY_CUSTFLD_ID";
		#endregion
		//-------------------------------------------------------------------
#if PDA
		public CRelationTypeEntreeAgenda_ChampCustom()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationTypeEntreeAgenda_ChampCustom(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationTypeEntreeAgenda_ChampCustom(System.Data.DataRow row)
			:base(row)
		{
		}
		//-------------------------------------------------------------------
		[Relation(CTypeEntreeAgenda.c_nomTable,CTypeEntreeAgenda.c_champId,CTypeEntreeAgenda.c_champId,true,true)]
		public override IDefinisseurChampCustom Definisseur
		{
			get
			{
				return (IDefinisseurChampCustom) GetParent(CTypeEntreeAgenda.c_champId, typeof(CTypeEntreeAgenda));
			}
			set
			{
				this.SetParent(CTypeEntreeAgenda.c_champId, (CTypeEntreeAgenda)value);
			}
		}
		//-------------------------------------------------------------------
	}
}
