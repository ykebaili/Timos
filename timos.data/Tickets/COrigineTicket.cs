using System;
using System.Collections;
using System.Data;
using System.Collections.Generic;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using sc2i.data.dynamic;
using sc2i.process;
using tiag.client;

namespace timos.data
{
    /// <summary>
    /// Détermine l'origine possible d'un <see cref="CTicket">Ticket</see>.<br/>
    /// A une origine, il est possible d'associer un formulaire personnalisé,<br/>
    /// afin d'en enrichir la saisie au niveau du ticket.<br/>
    /// </summary>
    [DynamicClass("Ticket origin")]
    [Table(COrigineTicket.c_nomTable, COrigineTicket.c_champId, true)]
    [FullTableSync]
    [ObjetServeurURI("COrigineTicketServeur")]
    [Unique(false, "This Origin Label is already used|232", COrigineTicket.c_champLibelle)]
    [sc2i.doccode.DocRefMenusOrMenuItems(CDocLabels.c_iTicket)]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersCorrectives_ID)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_ParamTickets_ID)]
    [TiagClass(COrigineTicket.c_nomTiag, "Id", true)]
    public class COrigineTicket : CObjetDonneeAIdNumeriqueAuto,	IDefinisseurChampCustom
    {
        public const string c_nomTiag = "Ticket Orign";
        public const string c_nomTable = "TICKET_ORIGIN";

		public const string c_champId = "TKT_ORIGIN_ID";
		public const string c_champLibelle = "TKT_ORIGIN_LABEL";

        /// /////////////////////////////////////////////
        public COrigineTicket(CContexteDonnee contexte)
            : base(contexte)
        {
        }

        /// /////////////////////////////////////////////
        public COrigineTicket(DataRow row)
            : base(row)
        {
        }

        /// /////////////////////////////////////////////
        public override string DescriptionElement
        {
            get
            {
                return I.T( "Ticket Origin @1|231",Libelle);
            }
        }

        /// /////////////////////////////////////////////
        protected override void MyInitValeurDefaut()
        {
        }

        /// /////////////////////////////////////////////
        public override string[] GetChampsTriParDefaut()
        {
            return new string[] { c_champLibelle };
        }



        //---------------------------------------------------
        /// <summary>
        /// Libellé de l'origine
        /// </summary>
        [TableFieldProperty(c_champLibelle, 100)]
        [DynamicField("Label")]
        [DescriptionField]
        [TiagField("Label")]
        public string Libelle
        {
            get
            {
                return (string)Row[c_champLibelle];
            }
            set
            {
                Row[c_champLibelle] = value;
            }
        }

		/// /////////////////////////////////////////////
		
		//-------------------------------------------------------------------
		/// <summary>
		/// Formulaire personnalisé associé à l'origine
		/// </summary>
		[Relation(
			CFormulaire.c_nomTable,
			CFormulaire.c_champId,
			CFormulaire.c_champId,
			false,
			false,
			false)]
		[DynamicField("Form")]
		public CFormulaire Formulaire
		{
			get
			{
				return (CFormulaire)GetParent(CFormulaire.c_champId, typeof(CFormulaire));
			}
			set
			{
				SetParent(CFormulaire.c_champId, value);
			}
		}

        


		#region IDefinisseurChampCustom Membres


		public IRelationDefinisseurChamp_ChampCustom[] RelationsChampsCustomDefinis
		{
			get { return new IRelationDefinisseurChamp_ChampCustom[0]; }
		}

		public IRelationDefinisseurChamp_Formulaire[] RelationsFormulaires
		{
			get 
			{
				if (Formulaire != null)
				{
					CRelationDefinisseurChamp_FormulaireStatic rel = new CRelationDefinisseurChamp_FormulaireStatic(this, Formulaire);
					return new IRelationDefinisseurChamp_Formulaire[] { rel };
				}
				return new IRelationDefinisseurChamp_Formulaire[0];
			}
		}

        public CRoleChampCustom RoleChampCustomDesElementsAChamp
		{
			get { return CRoleChampCustom.GetRole(CTicket.c_roleChampCustom); }
		}

		public CChampCustom[] TousLesChampsAssocies
		{
			get
			{
				List<CChampCustom> lst = new List<CChampCustom>();
				if (Formulaire != null)
					foreach (CRelationFormulaireChampCustom rel in Formulaire.RelationsChamps)
						lst.Add(rel.Champ);
				return lst.ToArray();
			}
		}

		#endregion
	}
}
