using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;

namespace timos.data
{
	/// <summary>
	/// Relation entre un <see cref="CTypeActiviteActeur">Type d'Activité d'Acteur</see> et un
	/// <see cref="sc2i.data.dynamic.CChampCustom">Champ personnalisé</see>.
	/// </summary>
    [DynamicClass("Member activity type / Custom field")]
	[ObjetServeurURI("CRelationTypeActiviteActeur_ChampCustomServeur")]
	[Table(CRelationTypeActiviteActeur_ChampCustom.c_nomTable, CRelationTypeActiviteActeur_ChampCustom.c_champId, true)]
	[FullTableSync]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_SuiviActivite_ID)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_TypeActivite_ID)]
    public class CRelationTypeActiviteActeur_ChampCustom : CRelationDefinisseurChamp_ChampCustom
	{
		public const string c_nomTable = "ACTIVMBRTP_CUST_FIELD";
		public const string c_champId = "ACTIVMBRTP_FLD_ID";

		//-------------------------------------------------------------------
#if PDA
		public CRelationTypeEO_ChampCustom()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationTypeActiviteActeur_ChampCustom(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationTypeActiviteActeur_ChampCustom(System.Data.DataRow row)
			:base(row)
		{
		}

        //-------------------------------------------------------------------
        /// <summary>
        /// Type d'activité d'acteur, objet de la relation
        /// </summary>
        [Relation(
            CTypeActiviteActeur.c_nomTable,
            CTypeActiviteActeur.c_champId,
            CTypeActiviteActeur.c_champId, 
            true, 
            false, 
            true)]
        [DynamicField("Member activity type")]
        public override IDefinisseurChampCustom Definisseur
		{
			get
			{
                return (IDefinisseurChampCustom)GetParent(CTypeActiviteActeur.c_champId, typeof(CTypeActiviteActeur));
			}
			set
			{
                SetParent(CTypeActiviteActeur.c_champId, (CTypeActiviteActeur)value);
			}
		}
	}
}
