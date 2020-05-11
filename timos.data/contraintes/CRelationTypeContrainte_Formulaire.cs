using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;

namespace timos.data
{
	/// <summary>
	/// Relation entre un <see cref="CTypeContrainte">Type de Contrainte</see> et un
    /// <see cref="sc2i.data.dynamic.CFormulaire">Formulaire personnalisé</see>.
	/// </summary>
    [DynamicClass("Constraint type / Custom form")]
	[ObjetServeurURI("CRelationTypeContrainte_FormulaireServeur")]
    [Table(CRelationTypeContrainte_Formulaire.c_nomTable, CRelationTypeContrainte_Formulaire.c_champId, true)]
	[FullTableSync]
    [Unique(false,
        "Another association already exist for the relation Constraint Type/Custom Form|144",
        CTypeContrainte.c_champId,
        CFormulaire.c_champId)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_TypeContrainte_ID)]
    public class CRelationTypeContrainte_Formulaire : CRelationDefinisseurChamp_Formulaire
	{
		public const string c_nomTable = "CONST_TYPE_FORM";
        public const string c_champId = "CONST_TYPE_FORM_ID";

		//-------------------------------------------------------------------
		public CRelationTypeContrainte_Formulaire(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
        public CRelationTypeContrainte_Formulaire(System.Data.DataRow row)
			:base(row)
		{
		}

		//-------------------------------------------------------------------
		/// <summary>
		/// Relation avec le Definisseur du Champ Custom<br/>
		/// (obligatoire)
		/// </summary>
		[Relation(
            CTypeContrainte.c_nomTable,
            CTypeContrainte.c_champId,
            CTypeContrainte.c_champId,
            true,
            true,
            true)]
        [DynamicField("Constraint type")]
		public override IDefinisseurChampCustom Definisseur
		{
			get
			{
                return (IDefinisseurChampCustom)GetParent(CTypeContrainte.c_champId, typeof(CTypeContrainte));
			}
			set
			{
                SetParent(CTypeContrainte.c_champId, (CTypeContrainte)value);
			}
		}
	}
}
