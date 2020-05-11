using System;
using System.Data;
using System.Collections.Generic;
using sc2i.data;
using sc2i.common;

namespace timos.data
{
	public enum ETypeAnomaliePlanification
	{
		DateAbsente = 10001,
		DateIncoherante = 10002,
	}

    

	[DynamicClass("Project Anomaly")]
	[ObjetServeurURI("CAnomalieProjetServeur")]
	[Table(CAnomalieProjet.c_nomTable, CAnomalieProjet.c_champId, true)]
	public class CAnomalieProjet : CObjetDonneeAIdNumeriqueAuto, IErreur
	{

		#region Déclaration des constantes
		public const string c_nomTable = "PROJECT_ANOMALY";
		public const string c_champId = "PRJ_ANO_ID";
		public const string c_champMessageErr = "PRJ_ANO_MSG";
		public const string c_champIgnorer = "PRJ_ANO_IGNORE";
		public const string c_champTypeCode = "PRJ_ANO_TYPECODE";

        public const string c_champIdProjetConcerne = "PRJ_ANO_CONCRND_PRJ";

		#endregion

		//-------------------------------------------------------------------
		public CAnomalieProjet(CContexteDonnee ctx)
			: base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CAnomalieProjet(System.Data.DataRow row)
			: base(row)
		{
		}
		

		//-------------------------------------------------------------------
		public override string ToString()
		{
			return Message;
		}

		protected override void MyInitValeurDefaut()
		{

		}
		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get { return I.T("Anomaly @1|273", Message); }
		}


		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[] { c_champMessageErr };
		}
		//-------------------------------------------------------------------
		/// /////////////////////////////////////////////
		[TableFieldProperty(c_champMessageErr, 255)]
		[DynamicField("Error Message")]
		public string Message
		{
			get
			{
				return (string)Row[c_champMessageErr];
			}
			set
			{
				Row[c_champMessageErr] = value;
			}
		}

	

        /// <summary>
        /// Projet auquel appartient l'anomalie
        /// </summary>
		[Relation(CProjet.c_nomTable, CProjet.c_champId, CProjet.c_champId, true, true)]
		[DynamicField("Owner Project")]
		public CProjet Projet
		{
			get
			{
				return (CProjet)GetParent(CProjet.c_champId, typeof(CProjet));
			}
			set
			{
				SetParent(CProjet.c_champId, value);
			}
		}

        /// <summary>
        /// Projet concerné par l'anomalie (sous projet du projet)
        /// </summary>
        [Relation(
            CProjet.c_nomTable,
            CProjet.c_champId,
            CAnomalieProjet.c_champIdProjetConcerne,
            false,
            true)]
        [DynamicField("Concerned project")]
        public CProjet ProjetConcerne
        {
            get
            {
                return (CProjet)GetParent(c_champIdProjetConcerne, typeof(CProjet));
            }
            set
            {
                SetParent(c_champIdProjetConcerne, value);
                if (value != null)
                {
                    InterventionConcernee = null;
                    LienConcerne = null;
                }
            }
        }

        /// <summary>
        /// Intervention concerné par l'anomalie (sous projet du projet)
        /// </summary>
        [Relation ( 
            CIntervention.c_nomTable,
            CIntervention.c_champId,
            CIntervention.c_champId,
            false,
            true )]
        [DynamicField("Concerned intervention")]
        public CIntervention InterventionConcernee
        {
            get{
                return ( CIntervention)GetParent ( CIntervention.c_champId, typeof(CIntervention));
            }
            set{
                SetParent ( CIntervention.c_champId, value );
                if (value != null)
                {
                    ProjetConcerne = null;
                    LienConcerne = null;
                }
            }
        }

        /// <summary>
        /// Lien concerné par l'anomalie
        /// </summary>
        [Relation ( CLienDeProjet.c_nomTable,
            CLienDeProjet.c_champId,
            CLienDeProjet.c_champId,
            false,
            true)]
        [DynamicField("Concerned project link")]
        public CLienDeProjet LienConcerne
        {
            get{
                return (CLienDeProjet)GetParent ( CLienDeProjet.c_champId, typeof(CLienDeProjet));
            }
            set{
                SetParent ( CLienDeProjet.c_champId, value );
                if ( value != null )
                {
                    ProjetConcerne = null;
                    InterventionConcernee = null;
                }
            }
        }

        /// <summary>
        /// Element concerné par l'anomalie
        /// </summary>
        public IElementAAnomalieProjet ElementConcerne
        {
            get
            {
                if (ProjetConcerne != null)
                    return ProjetConcerne;
                if (LienConcerne != null)
                    return LienConcerne;
                if (InterventionConcernee != null)
                    return InterventionConcernee;
                return null;
            }
            set
            {
                CProjet projet = value as CProjet;
                if (projet != null)
                    ProjetConcerne = projet;
                else
                {
                    CIntervention intervention = value as CIntervention;
                    if (intervention != null)
                        InterventionConcernee = intervention;
                    else
                    {
                        CLienDeProjet lien = value as CLienDeProjet;
                        if (lien != null)
                            LienConcerne = lien;
                        else
                        {
                            LienConcerne = null;
                            ProjetConcerne = null;
                            InterventionConcernee = null;
                        }
                    }
                }
            }
        }


		public CTypeAnomalieProjet TypeAnomalie
		{
			get
			{
				return new CTypeAnomalieProjet((ETypeAnomalieProjet)TypeAnomalieCode);
			}
			set
			{
				if (value != null)
					TypeAnomalieCode = value.CodeInt;
			}
		}
		[DynamicField("Anomaly Code")]
		[TableFieldProperty(c_champTypeCode)]
		public int TypeAnomalieCode
		{
			get
			{
				return (int)Row[c_champTypeCode];
			}
			set
			{
				Row[c_champTypeCode] = value;
			}
		}

        public bool IsAvertissement
        {
            get
            {
                return false;
            }
        }

		[TableFieldProperty(c_champIgnorer)]
		[DynamicField("Ignore")]
		public bool Ignorer
		{
			get
			{
				return (bool)Row[c_champIgnorer];
			}
			set
			{
				Row[c_champIgnorer] = value;
			}
		}


        //-----------------------------------------------
		public static CResultAErreur CreerAnomalie(
            CContexteDonnee ctx, 
            CProjet projetParent, 
            ETypeAnomalieProjet type, 
            string message, 
            IElementAAnomalieProjet elementConcerne)
		{
			CAnomalieProjet anomalie = new CAnomalieProjet(ctx);
			anomalie.CreateNewInCurrentContexte();
            anomalie.Projet = projetParent;
            anomalie.TypeAnomalieCode = (int)type;
            anomalie.Message = message;
            anomalie.ElementConcerne = elementConcerne;
			return CResultAErreur.True;
		}

	}
}
