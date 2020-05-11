using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using tiag.client;

namespace timos.data
{
	/// <summary>
    /// Une liste d'Opérations est composée de plusieurs <see cref="CTypeOperation">Types d'Operations</see><br/>
    /// Et représente les opérations planifiées sur une <see cref="CIntervention">Intervention</see><br/>
    /// ou la liste des opérations liées à un <see cref="CContrat">Contrat</see> de maintenance préventive.
	/// </summary>
	[DynamicClass("Operations Liste")]
	[Table(CListeOperations.c_nomTable, CListeOperations.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CListeOperationsServeur")]
    [Unique(false, "This contact label already used", CListeOperations.c_champLibelle)]
    [sc2i.doccode.DocRefMenusOrMenuItems(CDocLabels.c_iTicket)]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IngeProjet_ID,
        Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersPreventives_ID)]
    [TiagClass(CListeOperations.c_nomTiag, "Id", true)]
    public class CListeOperations : CObjetDonneeAIdNumeriqueAuto,
                                    IObjetALectureTableComplete,
                                    IElementAOperationPrevisionnelle
	{
        public const string c_nomTable = "OPERATION_LIST";
        public const string c_nomTiag = "Opertation List";
		
		public const string c_champId = "OP_LIST_ID";
		public const string c_champLibelle = "OP_LIST_LABEL";

		/// /////////////////////////////////////////////
		public CListeOperations( CContexteDonnee contexte)
			:base(contexte)
		{
		}
		
	    /// /////////////////////////////////////////////
		public CListeOperations(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T( "The Operations List @1 |421",Libelle);
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champLibelle};
		}
 
        //----------------------------------------------------------------------
		/// <summary>
		/// Libellé de la Liste d'Opération (30 caractères maximum).
		/// </summary>
		[TableFieldProperty(c_champLibelle, 30)]
		[DynamicField("Label")]
        [RechercheRapide]
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


		//---------------------------------------------------------------------
		/// <summary>
		/// Donne la Liste des types d'Opérations non filles décrivant cette liste
		/// </summary>
		[DynamicChilds("Parents Operations Types Relations", typeof(COperation))]
		public CListeObjetsDonnees OperationsParentes
		{
			get
			{
				CFiltreDataAvance filtre = new CFiltreDataAvance(COperation.c_nomTable, CListeOperations.c_champId + " = @1 AND HasNo(" + COperation.c_champIdOpParente + ")", Id);
				return new CListeObjetsDonnees(ContexteDonnee, typeof(COperation), filtre);
			}
		}


        //---------------------------------------------------------------------
        /// <summary>
        /// Donne la liste des types d'Opérations décrivant cette liste
        /// </summary>
        [RelationFille(typeof(COperation), "ListeOperations")]
        [DynamicChilds("Operations Types Relations", typeof(COperation))]
        public CListeObjetsDonnees Operations
        {
            get
            {
                return GetDependancesListe(COperation.c_nomTable, c_champId);
            }
        }


        #region IElementAOperationPrevisionnelle Membres


        public IFournisseurListeTypeOperation FournisseurListeTypeOperation
        {
            get 
            {
                return CFournisseurListeTousTypesOperations.InstanceUnique;
            }
        }

        #endregion


    }
}
