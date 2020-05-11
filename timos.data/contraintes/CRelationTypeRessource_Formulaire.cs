using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;

namespace timos.data
{
	/// <summary>
	/// Relation entre un <see cref="CTypeRessource">Type de Ressource</see> et
	/// un <see cref="sc2i.data.dynamic.CFormulaire">Formulaire personnalisé</see>.
	/// </summary>
    [DynamicClass("Resource type / Custom form")]
	[ObjetServeurURI("CRelationTypeRessource_FormulaireServeur")]
    [Table(CRelationTypeRessource_Formulaire.c_nomTable, CRelationTypeRessource_Formulaire.c_champId, true)]
	[FullTableSync]
    [Unique(false,
        "Another association already exist for the relation Resource Type/Custom Form|146",
        CTypeRessource.c_champId,
        CFormulaire.c_champId)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_TypeRessource_ID)]
    public class CRelationTypeRessource_Formulaire : CRelationDefinisseurChamp_Formulaire
	{
		public const string c_nomTable = "RESOURCE_TYPE_FORM";
        public const string c_champId = "RESOURCE_TYPE_FORM_ID";


		//-------------------------------------------------------------------
		public CRelationTypeRessource_Formulaire(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
        public CRelationTypeRessource_Formulaire(System.Data.DataRow row)
			:base(row)
		{
		}

		//-------------------------------------------------------------------
        /// <summary>
        /// Type de ressource, objet de la relation
        /// </summary>
		[Relation(
            CTypeRessource.c_nomTable,
            CTypeRessource.c_champId,
            CTypeRessource.c_champId,
            true,
            true,
            true)]
        [DynamicField("Resource type")]
		public override IDefinisseurChampCustom Definisseur
		{
			get
			{
                return (IDefinisseurChampCustom)GetParent(CTypeRessource.c_champId, typeof(CTypeRessource));
			}
			set
			{
                SetParent(CTypeRessource.c_champId, (CTypeRessource)value);
			}
		}
	}
}
