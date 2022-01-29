using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using sc2i.data.dynamic;
using sc2i.process;
using sc2i.expression;

namespace timos.data
{
	/// <summary>
	/// Definit un lien entre deux <see cref="CTypePhase">Types de Phases de Ticket</see>. <br/>
    /// Ces liens sont créés lors de l'élaboration d'un Processus de résolution sur le <see cref="cTypeTicket">Type de ticket</see>.<br/>
    /// Dans ce processus de résolution, un tel lien exprime la possibilité de passer d'un type de phase à un autre type de phase.<br/>
    /// 
	/// </summary>
	[DynamicClass("Ticket Phase Type link")]
	[Table(CLienTypePhase.c_nomTable, CLienTypePhase.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CLienTypePhaseServeur")]
    [sc2i.doccode.DocRefMenusOrMenuItems(CDocLabels.c_iTicket)]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersCorrectives_ID)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_ParamTickets_ID)]
    public class CLienTypePhase : CObjetDonneeAIdNumeriqueAuto, IObjetSansVersion
                                
	{
		public const string c_nomTable = "PHASE_TYPE_LINK";
        public const string c_champId = "PHASETYPLNK_ID";
		public const string c_champIdTypePhaseFrom = "PHASETYPLNK_FROM";
		public const string c_champIdTypePhaseTo = "PHASETYPLNK_TO";

        public const string c_champFormule = "PHASETYPLNK_DB_FORMULA";
        public const string c_champCacheFormule = "PHASETYPLNK_CACH_FORMULA";

        
        /// /////////////////////////////////////////////
		public CLienTypePhase( CContexteDonnee contexte)
			:base(contexte)
		{
		}
		
	    /// /////////////////////////////////////////////
		public CLienTypePhase(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
                string strRet = I.T("Link from phase type  |30069");
                if(FromTypePhase != null  && FromTypePhase.TypePhase != null) 
                    strRet += FromTypePhase.TypePhase.Libelle;
                strRet += I.T("to the phase type |30070");
                if (ToTypePhase != null && ToTypePhase.TypePhase != null)
                    strRet += ToTypePhase.TypePhase.Libelle;

                return strRet;
            }
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
            return new string[] { c_champId };
		}


        //-------------------------------------------------------------------
        /// <summary>
        /// Type de Phase source du lien
        /// </summary>
        [Relation(
            CTypeTicket_TypePhase.c_nomTable,
            CTypeTicket_TypePhase.c_champId,
            CLienTypePhase.c_champIdTypePhaseFrom,
            true,
            true,
            false)]
        [DynamicField("From Type Phase")]
        public CTypeTicket_TypePhase FromTypePhase
        {
            get
            {
                return (CTypeTicket_TypePhase)GetParent(CLienTypePhase.c_champIdTypePhaseFrom, typeof(CTypeTicket_TypePhase));
            }
            set
            {
                SetParent(CLienTypePhase.c_champIdTypePhaseFrom, value);
            }
        }



        //-------------------------------------------------------------------
        /// <summary>
        /// Type de Phase destination du lien
        /// </summary>
        [Relation(
            CTypeTicket_TypePhase.c_nomTable,
            CTypeTicket_TypePhase.c_champId,
            CLienTypePhase.c_champIdTypePhaseTo,
            true,
            true,
            false)]
        [DynamicField("To Type Phase")]
        public CTypeTicket_TypePhase ToTypePhase
        {
            get
            {
                return (CTypeTicket_TypePhase)GetParent(CLienTypePhase.c_champIdTypePhaseTo, typeof(CTypeTicket_TypePhase));
            }
            set
            {
                SetParent(CLienTypePhase.c_champIdTypePhaseTo, value);
            }
        }

		/////////////////////////////////////////////////////
        /// <summary>
        /// Formule conditionnelle pour passer d'une phase à une autre<br/>
        /// L'évaluation de cette formule doit retourner VRAI pour pouvoir passer à la phase suivante
        /// </summary>
		[TableFieldProperty(c_champFormule, 2000)]
		public string FormuleConditionnelleString
		{
			get
			{
				return (string)Row[c_champFormule];
			}
			set
			{
				Row[c_champFormule] = value;
			}
		}

		//-------------------------------------------------------------------
		[TableFieldProperty(c_champCacheFormule, IsInDb = false)]
		public C2iExpression FormuleConditionnelle
		{
			get
			{
				if (Row[c_champCacheFormule] == DBNull.Value)
				{
					C2iExpression expression = C2iExpression.FromPseudoCode(FormuleConditionnelleString);
					if (expression == null)
						expression = new C2iExpressionVrai();
					CContexteDonnee.ChangeRowSansDetectionModification(Row.Row, c_champCacheFormule, expression);
				}
				return (C2iExpression)Row[c_champCacheFormule];
			}
			set
			{
				if (value == null)
					FormuleConditionnelleString = "";
				else
					FormuleConditionnelleString = C2iExpression.GetPseudoCode(value);
				CContexteDonnee.ChangeRowSansDetectionModification(Row.Row, c_champCacheFormule, DBNull.Value);
			}
		}
	

 
    }
}
