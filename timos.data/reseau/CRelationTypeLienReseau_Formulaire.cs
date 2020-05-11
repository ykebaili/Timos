using System;
using System.Collections.Generic;
using System.Text;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;



namespace timos.data
{

    /// <summary>
    /// Relation entre un <see cref="CTypeLienReseau">Type de lien réseau</see> et un 
    /// <see cref="sc2i.data.dynamic.CFormulaire">Formulaire personnalisé</see>.
    /// </summary>
    [DynamicClass("Network link type/ Custom form")]
    [ObjetServeurURI("CRelationTypeLienReseau_FormulaireServeur")]
    [Table(CRelationTypeLienReseau_Formulaire.c_nomTable, CRelationTypeLienReseau_Formulaire.c_champId, true)]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_Liaisons_ID)]
    [FullTableSync]
    [Unique(false,
        "Another association already exist for the relation Network link Type/Custom Form",
        CTypeLienReseau.c_champId,
        CFormulaire.c_champId)]
    public class CRelationTypeLienReseau_Formulaire : CRelationDefinisseurChamp_Formulaire
    {
        public const string c_nomTable = "NETWORK_LINK_TYPE_FORM";
		public const string c_champId = "NETWORKLINK_TYPE_FORM_ID";
		
        
		//-------------------------------------------------------------------
		public CRelationTypeLienReseau_Formulaire(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationTypeLienReseau_Formulaire(System.Data.DataRow row)
			:base(row)
		{
		}

		//-------------------------------------------------------------------
        /// <summary>
        /// <see cref="CTypeLienReseau">Type de lien réseau</see> concerné par la relation
        /// </summary>
		[Relation(
            CTypeLienReseau.c_nomTable,
            CTypeLienReseau.c_champId,
            CTypeLienReseau.c_champId,
            true,
            true,
            true)]
        [DynamicField("Network link type")]
		public override IDefinisseurChampCustom Definisseur
		{
			get
			{
                return (IDefinisseurChampCustom)GetParent(CTypeLienReseau.c_champId, typeof(CTypeLienReseau));
			}
			set
			{
                SetParent(CTypeLienReseau.c_champId, (CTypeLienReseau)value);
			}
		}
	}
}
