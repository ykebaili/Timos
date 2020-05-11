using System;
using System.Collections;
using System.Data;
using System.Drawing;

using sc2i.data;
using sc2i.common;
using sc2i.multitiers.client;
using sc2i.data.dynamic;
using sc2i.process;
using sc2i.expression;

using timos.data;

namespace sc2i.workflow
{

    /// <summary>
    /// Représente une relation entre un <see cref="CTypeTableauPlanning">Type de Tableau de Planning</see> et une <see cref="CHoraireJournalier_Tranche">Tranche Horaire</see>
    /// </summary>
    [DynamicClass("Schedule Table / Schedule Part")]
    [Table(CTypeTableauPlanning_TrancheHoraire.c_nomTable, CTypeTableauPlanning_TrancheHoraire.c_champId, true)]
    [FullTableSync]
    [ObjetServeurURI("CTypeTableauPlanning_TrancheHoraireServeur")]
    //[Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_TypeTableauPlanning_ID)]
    public class CTypeTableauPlanning_TrancheHoraire : CObjetDonneeAIdNumeriqueAuto,
                                IObjetALectureTableComplete
    {
        public const string c_nomTable = "PLANTABTP_TSLOT";
        public const string c_champId = "PLTABTPTS_ID";
        public const string c_champLibelle = "PLTABTPTS_LABEL";
        public const string c_champFormule = "PLTABTPTS_DB_FORMULA";
        public const string c_champCacheFormule = "PLTABTPTS_CACH_FORMULA";
        public const string c_champCouleur = "PLTABTPTS_COLOR";


		public const string c_nomVariablePourEvaluation = "Date value";

        /// /////////////////////////////////////////////
        public CTypeTableauPlanning_TrancheHoraire(CContexteDonnee contexte)
            : base(contexte)
        {
        }

        /// /////////////////////////////////////////////
        public CTypeTableauPlanning_TrancheHoraire(DataRow row)
            : base(row)
        {
        }

        /// /////////////////////////////////////////////
        public override string DescriptionElement
        {
            get
            {
                return I.T( "|");
            }
        }

        /// /////////////////////////////////////////////
        protected override void MyInitValeurDefaut()
        {
            Couleur = Color.White.ToArgb();
        }

        /// /////////////////////////////////////////////
        public override string[] GetChampsTriParDefaut()
        {
            return new string[] { c_champId };
        }


        
		//-----------------------------------------------------------
		/// <summary>
		/// Libellé de la relation
		/// </summary>
		[TableFieldProperty ( c_champLibelle, 128 )]
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
        /// Type de tableau de planning, objet de la relation
        /// </summary>
        [Relation(
            CTypeTableauPlanning.c_nomTable,
            CTypeTableauPlanning.c_champId,
            CTypeTableauPlanning.c_champId,
            true,
            true,
            true)]
        [DynamicField("Schedule Table")]
        public CTypeTableauPlanning TypeTableauPlanning
        {
            get
            {
                return (CTypeTableauPlanning)GetParent(CTypeTableauPlanning.c_champId, typeof(CTypeTableauPlanning));
            }
            set
            {
                SetParent(CTypeTableauPlanning.c_champId, value);
            }
        }



        //-------------------------------------------------------------------
        /// <summary>
        /// Tranche horaire, objet de la relation
        /// </summary>
        [Relation(
            CHoraireJournalier_Tranche.c_nomTable,
            CHoraireJournalier_Tranche.c_champId,
            CHoraireJournalier_Tranche.c_champId,
            true,
            false,
            true)]
        [DynamicField("Time Slot")]
        public CHoraireJournalier_Tranche TrancheHoraire
        {
            get
            {
                return (CHoraireJournalier_Tranche)GetParent(CHoraireJournalier_Tranche.c_champId, typeof(CHoraireJournalier_Tranche));
            }
            set
            {
                SetParent(CHoraireJournalier_Tranche.c_champId, value);
            }
        }


        /////////////////////////////////////////////////////
        /// <summary>
        /// Formule conditionnelle sous forme de chaine stockée dans le BDD
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
        /// <summary>
        /// Formule conditionnelle non stockée dans le BDD
        /// </summary>
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

		public static CElementAVariablesDynamiques ElementPourEvaluerLaFormuleConditionnelle
		{
			get
			{
				CElementAVariablesDynamiques elt = new CElementAVariablesDynamiques();

				CVariableDynamiqueStatique variable = new CVariableDynamiqueStatique(elt);
				variable.Nom = c_nomVariablePourEvaluation;
				variable.SetTypeDonnee ( new CTypeResultatExpression(typeof(DateTime), false) );

				elt.AddVariable(variable);
				return elt;
			}
		}

        //----------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool EvaluerFormuleConditionnelle( DateTime dt)
        {
			CElementAVariablesDynamiques elt = ElementPourEvaluerLaFormuleConditionnelle;
			
			elt.SetValeurChamp((IVariableDynamique)elt.ListeVariables[0], dt);
			CContexteEvaluationExpression contexte = new CContexteEvaluationExpression(elt);
            C2iExpression formule = this.FormuleConditionnelle;
            if (formule != null)
            {
                CResultAErreur result = formule.Eval(contexte);
                if (result)
                {
                    if (result.Data is bool && (bool)result.Data ||
                         result.Data is int && (int)result.Data != 0)
                        return true;
                }
            }
            return false;
        }

        //-----------------------------------------------------------
        /// <summary>
        /// Code couleur correspondant à la tranche horaire dans le tableau
        /// </summary>
        [TableFieldProperty(c_champCouleur)]
        [DynamicField("Color")]
        public int Couleur
        {
            get
            {
                return (int)Row[c_champCouleur];
            }
            set
            {
                Row[c_champCouleur] = value;
            }
        }

    }
}
