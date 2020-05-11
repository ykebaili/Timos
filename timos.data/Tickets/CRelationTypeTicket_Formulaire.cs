using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;

namespace timos.data
{
    /// <summary>
    /// Relation entre un <see cref="CTypeTicket">Type de Ticket</see> et un 
    /// <see cref="sc2i.data.dynamic.CFormulaire">Formulaire personnalisé</see>
    /// </summary>
    [DynamicClass("Ticket type / Custom form")]
	[ObjetServeurURI("CRelationTypeTicket_FormulaireServeur")]
	[Table(CRelationTypeTicket_Formulaire.c_nomTable, CRelationTypeTicket_Formulaire.c_champId,true)]
	[FullTableSync]
    [Unique(false,
        "Another association already exist for the relation Ticket Type/Custom Form|226",
        CTypeTicket.c_champId,
        CFormulaire.c_champId)]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersCorrectives_ID)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_ParamTickets_ID)]
    public class CRelationTypeTicket_Formulaire : CRelationDefinisseurChamp_Formulaire
	{
		public const string c_nomTable = "TICKET_TYPE_FORM";
		public const string c_champId = "TKTTP_FORM_ID";
		
        
		//-------------------------------------------------------------------
		public CRelationTypeTicket_Formulaire(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationTypeTicket_Formulaire(System.Data.DataRow row)
			:base(row)
		{
		}

		//-------------------------------------------------------------------
        /// <summary>
        /// Type de ticket objet de la relation
        /// </summary>
		[Relation(
            CTypeTicket.c_nomTable,
            CTypeTicket.c_champId,
            CTypeTicket.c_champId,
            true,
            true,
            true)]
        [DynamicField("Ticket type")]
		public override IDefinisseurChampCustom Definisseur
		{
			get
			{
                return (IDefinisseurChampCustom)GetParent(CTypeTicket.c_champId, typeof(CTypeTicket));
			}
			set
			{
                SetParent(CTypeTicket.c_champId, (CTypeTicket)value);
			}
		}
	}
}
