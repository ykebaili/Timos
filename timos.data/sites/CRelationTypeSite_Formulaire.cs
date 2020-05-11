using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;

namespace timos.data
{
    /// <summary>
    /// Relation entre un <see cref="CTypeSite">Type de Site</see> et un
    /// <see cref="sc2i.data.dynamic.CChampCustom">Formulaire personnalisé</see>.
    /// </summary>
    [DynamicClass("Site type / Custom form")]
	[ObjetServeurURI("CRelationTypeSite_FormulaireServeur")]
	[Table(CRelationTypeSite_Formulaire.c_nomTable, CRelationTypeSite_Formulaire.c_champId,true)]
	[FullTableSync]
    [Unique(false,
        "Another association already exist for the relation Site Type/Custom Form|148",
        CTypeSite.c_champId,
        CFormulaire.c_champId)]
    public class CRelationTypeSite_Formulaire : CRelationDefinisseurChamp_Formulaire
	{
		public const string c_nomTable = "SITE_TYPE_FORM";
		public const string c_champId = "SITE_TYPE_FORM_ID";
		
        
		//-------------------------------------------------------------------
		public CRelationTypeSite_Formulaire(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationTypeSite_Formulaire(System.Data.DataRow row)
			:base(row)
		{
		}

		//-------------------------------------------------------------------
        /// <summary>
        /// <see cref="CTypeSite">Type de site</see> objet de la relation
        /// </summary>
		[Relation(
            CTypeSite.c_nomTable,
            CTypeSite.c_champId,
            CTypeSite.c_champId,
            true,
            true,
            true)]
        [DynamicField("Site type")]
		public override IDefinisseurChampCustom Definisseur
		{
			get
			{
                return (IDefinisseurChampCustom)GetParent(CTypeSite.c_champId, typeof(CTypeSite));
			}
			set
			{
                SetParent(CTypeSite.c_champId, (CTypeSite)value);
			}
		}
	}
}
