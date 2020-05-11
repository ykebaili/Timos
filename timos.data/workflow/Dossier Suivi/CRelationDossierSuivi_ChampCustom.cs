using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;

namespace sc2i.workflow
{
	/// <summary>
    /// Relation entre un <see cref="CDossierSuivi">Dossier de suivi</see> et un 
    /// <see cref="sc2i.data.dynamic.CChampCustom">Champ personnalisé</see>.
	/// </summary>
    [DynamicClass("Workbook / Custom field")]
	[ObjetServeurURI("CRelationDossierSuivi_ChampCustomServeur")]
	[Table(CRelationDossierSuivi_ChampCustom.c_nomTable, CRelationDossierSuivi_ChampCustom.c_champId,true)]
	
	public class CRelationDossierSuivi_ChampCustom : CRelationElementAChamp_ChampCustom
	{
		#region Déclaration des constantes
		public const string c_nomTable = "WORKBOOK_CUSTOM_FIELD";
		public const string c_champId = "WKB_CUST_ID";
		#endregion
		//-------------------------------------------------------------------
#if PDA
		public CRelationDossierSuivi_ChampCustom()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationDossierSuivi_ChampCustom(CContexteDonnee ctx)
			:base(ctx)
		{
		}

		//-------------------------------------------------------------------
		public CRelationDossierSuivi_ChampCustom(System.Data.DataRow row)
			:base(row)
		{
		}

		//-------------------------------------------------------------------
		public override Type GetTypeElementAChamps()
		{
			return typeof(CDossierSuivi);
		}

		//-------------------------------------------------------------------
		public override string GetNomTable()
		{
			return c_nomTable;
		}
		//-------------------------------------------------------------------
        /// <summary>
        /// Dossier de suivi, objet de la relation
        /// </summary>
		[Relation(CDossierSuivi.c_nomTable,CDossierSuivi.c_champId,CDossierSuivi.c_champId,true,true)]
		[
		DynamicField("Workbook")
		]
		public override IElementAChamps ElementAChamps
		{
			get
			{
				return (IElementAChamps) GetParent(CDossierSuivi.c_champId, typeof(CDossierSuivi));
			}
			set
			{
				this.SetParent(CDossierSuivi.c_champId, (CDossierSuivi)value);
			}
		}
	}
}
