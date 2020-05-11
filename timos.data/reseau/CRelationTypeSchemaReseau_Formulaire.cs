using System;
using System.Collections.Generic;
using System.Text;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;



namespace timos.data
{

    /// <summary>
    /// Relation entre un <see cref="CTypeSchemaReseau">Type de schéma réseau</see> et un 
    /// <see cref="sc2i.data.dynamic.CFormulaire">Formulaire personnalisé</see>.
    /// </summary>
    [DynamicClass("Network diagram type / Custom form")]
    [ObjetServeurURI("CRelationTypeSchemaReseau_FormulaireServeur")]
    [Table(CRelationTypeSchemaReseau_Formulaire.c_nomTable, CRelationTypeSchemaReseau_Formulaire.c_champId, true)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_Liaisons_ID)]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_Liaisons_ID)]
    [FullTableSync]
    [Unique(false,
        "Another association already exist for the relation Network link Type/Custom Form",
        CTypeSchemaReseau.c_champId,
        CFormulaire.c_champId)]
    public class CRelationTypeSchemaReseau_Formulaire : CRelationDefinisseurChamp_Formulaire
    {
        public const string c_nomTable = "NETWORK_DIAG_TYPE_FORM";
        public const string c_champId = "NETWORKDIAG_TYPE_FORM_ID";


        //-------------------------------------------------------------------
        public CRelationTypeSchemaReseau_Formulaire(CContexteDonnee ctx)
            : base(ctx)
        {
        }
        //-------------------------------------------------------------------
        public CRelationTypeSchemaReseau_Formulaire(System.Data.DataRow row)
            : base(row)
        {
        }

        //-------------------------------------------------------------------
        /// <summary>
        /// <see cref="CTypeSchemaReseau">Type de schéma réseau</see> objet de la relation
        /// </summary>
        [Relation(
            CTypeSchemaReseau.c_nomTable,
            CTypeSchemaReseau.c_champId,
            CTypeSchemaReseau.c_champId,
            true,
            true,
            true)]
        [DynamicField("Network diagram type")]
        public override IDefinisseurChampCustom Definisseur
        {
            get
            {
                return (IDefinisseurChampCustom)GetParent(CTypeSchemaReseau.c_champId, typeof(CTypeSchemaReseau));
            }
            set
            {
                SetParent(CTypeSchemaReseau.c_champId, (CTypeSchemaReseau)value);
            }
        }
    }
}
