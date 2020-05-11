using System;
using System.Collections;
using System.Data;
using System.Collections.Generic;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using timos.acteurs;
using sc2i.expression;
using sc2i.data.dynamic;

namespace timos.data
{
	/// <summary>
    /// Exprime une relation entre un <see cref="CTypeTicket">Type de Ticket</see> et un <see cref="CTypePhase">Type de Phase</see> de Ticket.
	/// </summary>
	[DynamicClass("Ticket type / Phase type")]
	[Table(CTypeTicket_TypePhase.c_nomTable, CTypeTicket_TypePhase.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CTypeTicket_TypePhaseServeur")]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersCorrectives_ID)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_ParamTickets_ID)]
    public class CTypeTicket_TypePhase : CObjetDonneeAIdNumeriqueAuto,
                                      IObjetALectureTableComplete
	{
		public const string c_nomTable = "TICKETTYPE_PHASETYPE";
        public const string c_champId = "TKTTP_PHATP_ID";

	

		//Designer
		public const string c_champIsPointEntree = "TKTTP_PHATP_IN_POINT";
		public const string c_champIsPointSortie = "TKTTP_PHATP_OUT_POINT";


		public const string c_champX = "TKTTP_PHATP_X";
		public const string c_champY = "TKTTP_PHATP_Y";
		public const string c_champWidth = "TKTTP_PHATP_WIDTH";
		public const string c_champHeight = "TKTTP_PHATP_HEIGHT";

		/// /////////////////////////////////////////////
		public CTypeTicket_TypePhase( CContexteDonnee contexte)
			:base(contexte)
		{
		}
		
	    /// /////////////////////////////////////////////
		public CTypeTicket_TypePhase(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				if(TypePhase != null && TypeTicket != null)
					return I.T("Relation @1 Phase Type / @2 Ticket Type: @1|452",TypePhase.Libelle,TypeTicket.Libelle);
				else
					return I.T( "Relation Phase Type / Ticket Type: @1|453");

			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
			X = 0;
			Y = 0;
			Width = 100;
			Height = 33;
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champId};
		}


		

        //-------------------------------------------------------------------
        /// <summary>
        /// Le Type de ticket objet de la relation
        /// </summary>
        [Relation(
            CTypeTicket.c_nomTable,
            CTypeTicket.c_champId,
            CTypeTicket.c_champId,
            true,
            true,
            false)]
        [DynamicField("Ticket type")]
        public CTypeTicket TypeTicket
        {
            get
            {
                return (CTypeTicket)GetParent(CTypeTicket.c_champId, typeof(CTypeTicket));
            }
            set
            {
                SetParent(CTypeTicket.c_champId, value);
            }
        }

		//-----------------------------------------------------------
		/// <summary>
		/// Indique si le type de phase est un point d'entrée, dans l'arbre des enchaînements<br/>
        /// des types de phase
		/// </summary>
		[TableFieldProperty(c_champIsPointEntree)]
		[DynamicField("Is entry point")]
		public bool IsPointEntree
		{
			get
			{
				return (bool)Row[c_champIsPointEntree];
			}
			set
			{
				Row[c_champIsPointEntree] = value;
			}
		}

        //-----------------------------------------------------------
        /// <summary>
        /// Indique si le type de phase est un point de sortie, dans l'arbre des enchaînements<br/>
        /// des types de phase
        /// </summary>
        [TableFieldProperty(c_champIsPointSortie)]
        [DynamicField("Is out point")]
        public bool IsPointSortie
        {
            get
            {
                return (bool)Row[c_champIsPointSortie];
            }
            set
            {
                Row[c_champIsPointSortie] = value;
            }
        }

        //-------------------------------------------------------------------
        /// <summary>
        /// Le Type de phase objet de la relation
        /// </summary>
        [Relation(
            CTypePhase.c_nomTable,
            CTypePhase.c_champId,
            CTypePhase.c_champId,
            true,
            false,
            false)]
        [DynamicField("Phase type")]
        public CTypePhase TypePhase
        {
            get
            {
                return (CTypePhase)GetParent(CTypePhase.c_champId, typeof(CTypePhase));
            }
            set
            {
                SetParent(CTypePhase.c_champId, value);
            }
        }

		//-----------------------------------------------------------
		/// <summary>
		/// Position en X du type de phase, dans le graphique décrivant les enchaînements des types de phases
		/// </summary>
		[TableFieldProperty(c_champX)]
		[DynamicField("X")]
		public int X
		{
			get
			{
				return (int)Row[c_champX];
			}
			set
			{
				Row[c_champX] = value;
			}
		}

		//-----------------------------------------------------------
		/// <summary>
        /// /// Position en Y du type de phase, dans le graphique décrivant les enchaînements des types de phases
		/// </summary>
		[TableFieldProperty(c_champY)]
		[DynamicField("Y")]
		public int Y
		{
			get
			{
				return (int)Row[c_champY];
			}
			set
			{
				Row[c_champY] = value;
			}
		}


		//-----------------------------------------------------------
		/// <summary>
		/// Largeur du cadre englobant du type de phase, dans le graphique décrivant les enchaînements
		/// </summary>
		[TableFieldProperty(c_champWidth)]
		[DynamicField("Width")]
		public int Width
		{
			get
			{
				return (int)Row[c_champWidth];
			}
			set
			{
				Row[c_champWidth] = value;
			}
		}


		//-----------------------------------------------------------
		/// <summary>
        /// Haiteur du cadre englobant du type de phase, dans le graphique décrivant les enchaînements
		/// </summary>
		[TableFieldProperty(c_champHeight)]
		[DynamicField("Height")]
		public int Height
		{
			get
			{
				return (int)Row[c_champHeight];
			}
			set
			{
				Row[c_champHeight] = value;
			}
		}






		//-------------------------------------------------------------------
		/// <summary>
		/// Retourne la liste des liens pointant vers les relations suivantes
		/// </summary>
		[RelationFille(typeof(CLienTypePhase), "FromTypePhase")]
		[DynamicChilds("Next phase type relations", typeof(CLienTypePhase))]
		public CListeObjetsDonnees RelationsTypesPhasesSuivantes
		{
			get
			{
				return GetDependancesListe(CLienTypePhase.c_nomTable, CLienTypePhase.c_champIdTypePhaseFrom);
			}
		}

		//-------------------------------------------------------------------
		/// <summary>
		/// Retourne la liste des liens pointant vers les relations précédentes
		/// </summary>
		[RelationFille(typeof(CLienTypePhase), "ToTypePhase")]
		[DynamicChilds("Previous phase type relations", typeof(CLienTypePhase))]
		public CListeObjetsDonnees RelationsTypesPhasesPrecedentes
		{
			get
			{
				return GetDependancesListe(CLienTypePhase.c_nomTable, CLienTypePhase.c_champIdTypePhaseTo);
			}
		}

		//----------------------------------------------------------------------
		public CTypePhase[] GetTypesPhasesSuivantesPossibles(CPhaseTicket phase)
		{
			List<CTypePhase> liste = new List<CTypePhase>();
			CContexteEvaluationExpression contexte = new CContexteEvaluationExpression(phase);
			foreach (CLienTypePhase liens in RelationsTypesPhasesSuivantes)
			{
				C2iExpression formule = liens.FormuleConditionnelle;
				if (formule != null)
				{
					CResultAErreur result = formule.Eval(contexte);
					if (result)
					{
						if (result.Data is bool && (bool)result.Data ||
							 result.Data is int && (int)result.Data != 0)
							liste.Add(liens.ToTypePhase.TypePhase);
					}
				}
			}
			return liste.ToArray();
		}


	}
}
