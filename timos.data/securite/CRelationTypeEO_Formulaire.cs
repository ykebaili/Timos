using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;

namespace timos.securite
{
	/// <summary>
    /// Relation entre un <see cref="CTypeEntiteOrganisationnelle">Type d'entité organisationnelle</see> et un
    /// <see cref="sc2i.data.dynamic.CFormulaire">Formulaire personnalisé</see>.
	/// </summary>
    [DynamicClass("Organisational entity type / Custom form")]
	[ObjetServeurURI("CRelationTypeEO_FormulaireServeur")]
	[Table(CRelationTypeEO_Formulaire.c_nomTable, CRelationTypeEO_Formulaire.c_champId,true)]
	[FullTableSync]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_TypeEO_ID)]
    public class CRelationTypeEO_Formulaire : CRelationDefinisseurChamp_Formulaire
	{
		#region Déclaration des constantes
		public const string c_nomTable = "OE_TYPE_FORM";
		public const string c_champId = "OETYP_FORM_ID";
		#endregion
		//-------------------------------------------------------------------
#if PDA
		public CRelationTypeEO_Formulaire()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationTypeEO_Formulaire(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationTypeEO_Formulaire(System.Data.DataRow row)
			:base(row)
		{
		}
		//-------------------------------------------------------------------
        /// <summary>
        /// Type d'entité organisationnelle, objet de la relation
        /// </summary>
		[Relation(
            CTypeEntiteOrganisationnelle.c_nomTable,
		   CTypeEntiteOrganisationnelle.c_champId,
		   CTypeEntiteOrganisationnelle.c_champId,
            true,
            true,
            true)]
        [DynamicField("Entity type")]
		public override IDefinisseurChampCustom Definisseur
		{
			get
			{
                return (IDefinisseurChampCustom)GetParent(CTypeEntiteOrganisationnelle.c_champId, typeof(CTypeEntiteOrganisationnelle));
			}
			set
			{
                SetParent(CTypeEntiteOrganisationnelle.c_champId, (CTypeEntiteOrganisationnelle)value);
			}
		}
	}
}
