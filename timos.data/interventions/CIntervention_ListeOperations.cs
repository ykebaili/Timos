using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using timos.acteurs;

namespace timos.data
{
	/// <summary>
	/// Relation entre une <see cref="CIntervention">Intervention</see> et une 
	/// <see cref="CListeOperations">Liste d'Operations</see>.<br/>
	/// Représente une liste d'Opérations planifiées sur une Intervention
	/// </summary>
	[DynamicClass("Intervention / Operation list")]
	[Table(CIntervention_ListeOperations.c_nomTable, CIntervention_ListeOperations.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CIntervention_ListeOperationsServeur")]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IngeProjet_ID,
        Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersPreventives_ID)]
    public class CIntervention_ListeOperations : CObjetDonneeAIdNumeriqueAuto
	{
		public const string c_nomTable = "INTER_OP_LIST";

        public const string c_champId = "INTER_OPLIST_ID";
        public const string c_champLibelle = "INTER_OPLIST_LABEL";
        public const string c_champBasculeEnOpPrev = "INTER_OPLIST_SWAP_FLAG";


		/// /////////////////////////////////////////////
		public CIntervention_ListeOperations( CContexteDonnee contexte)
			:base(contexte)
		{
		}

		/// /////////////////////////////////////////////
		public CIntervention_ListeOperations(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T( "Operations List for Intervention @1 |422",Intervention.Libelle);
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champId};
		}


        //-----------------------------------------------------------
        /// <summary>
        /// Le Libellé de la relation, car Il est possible d'ajouter plusieurs fois la même liste d'opérations sur une intervention
        /// </summary>
        [TableFieldProperty(c_champLibelle, 128)]
        [DynamicField("Label")]
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



		//-------------------------------------------------------------------
		/// <summary>
		/// Donne ou définit l'Intervention concernée par la relation<br/>
		/// </summary>
		[Relation(
			CIntervention.c_nomTable,
			CIntervention.c_champId,
			CIntervention.c_champId,
			true,
			true,
			true)]
		[DynamicField("Intervention")]
		public CIntervention Intervention
		{
			get
			{
				return (CIntervention)GetParent(CIntervention.c_champId, typeof(CIntervention));
			}
			set
			{
				SetParent(CIntervention.c_champId, value);
			}
		}

		//-------------------------------------------------------------------
		/// <summary>
		/// Donne ou définit la Liste d'Opérations concernée par la relation<br/>
		/// (obligatoire)
		/// </summary>
		[Relation(
			CListeOperations.c_nomTable,
		    CListeOperations.c_champId,
		    CListeOperations.c_champId,
			true,
			false,
			true)]
		[DynamicField("Resource")]
		public CListeOperations ListeOperations
		{
			get
			{
				return (CListeOperations)GetParent(CListeOperations.c_champId, typeof(CListeOperations));
			}
			set
			{
				SetParent(CListeOperations.c_champId, value);
			}
		}

        //-----------------------------------------------------------
        /// <summary>
        /// Donne ou définit que la liste d'opérations, objet de la relation, est planifiée
        /// </summary>
        [TableFieldProperty(c_champBasculeEnOpPrev)]
        [DynamicField("Swaped to Planified Operations")]
        public bool IsBasculeEnOperationsPrev
        {
            get
            {
                return (bool)Row[c_champBasculeEnOpPrev];
            }
            set
            {
                Row[c_champBasculeEnOpPrev] = value;
            }
        }



        //------------------------------------------------------------------------------
        public CResultAErreur BasculerListeEnOperationsPrevisionnelles()
        {
            CResultAErreur result = CResultAErreur.True;

			if (IsBasculeEnOperationsPrev)
			{
				result.EmpileErreur(I.T("This list of operations is already planned|537"));
				return result;
			}
            if (ListeOperations.Operations.Count == 0)
            {
                result.EmpileErreur(I.T( "This list of operations is empty|538"));
                return result;
            }

			foreach (COperation operation in ListeOperations.OperationsParentes.ToArrayList())
            {
                COperation opToAdd = operation;
				result = AjouterOperation(operation, null);
				if (!result)
					break;
            }

            return result;
        }
		private CResultAErreur AjouterOperation(COperation operation, COperation opParente)
		{
			CResultAErreur result = CResultAErreur.True;
			CSite site = (CSite)Intervention.ElementAIntervention;

			if (operation.TypeOperation != null &&
				operation.TypeOperation.IsLieeAEquipement &&
				operation.TypeOperation.GenererUneOpParTypeEquipement)
			{
				CTypeEquipement typeEqpt = operation.TypeEquipement;
				if (typeEqpt != null && site != null)
				{
					CListeObjetsDonnees listeEqpt = site.Equipements;
					listeEqpt.Filtre = new CFiltreData(CTypeEquipement.c_champId + "=@1", typeEqpt.Id);
					if (listeEqpt.Count == 0)
						result.EmpileErreur(I.T("The Site '@1' has no equipment type '@2' specified by Operation '@3'|431", site.Libelle, operation.TypeEquipement.Libelle, operation.TypeOperation.Libelle));
					else
						foreach (CEquipement equip in listeEqpt)
						{
							result = operation.CreerOperationPrevisionnelleSurIntervention(Intervention, equip);
							IsBasculeEnOperationsPrev = true;

							if (result)
								foreach (COperation ssOp in operation.OperationsFilles)
									result = AjouterOperation(ssOp, opParente);
						}
				}
			}
			else
			{
				result = operation.CreerOperationPrevisionnelleSurIntervention(Intervention);
                if (result)
                {
                    COperation op = result.Data as COperation;
                    if (op != null)
                    {
                        op.OperationParente = opParente;
                        foreach (COperation opFille in operation.OperationsFilles)
                        {
                            result = AjouterOperation(opFille, op);
                            if (!result)
                                return result;
                        }
                    }
                }
				IsBasculeEnOperationsPrev = true;
			}
			return result;
		}

	}

}
