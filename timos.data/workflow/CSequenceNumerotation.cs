using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;

using timos.data;
using sc2i.expression;

namespace sc2i.workflow
{
	/// <summary>
	/// Permet de gérer des séquences de numérotation appliquées<br/>
    /// avec n'importe quel objet TIMOS
	/// </summary>
    [DynamicClass("Numeration sequence")]
	[Table(CSequenceNumerotation.c_nomTable, CSequenceNumerotation.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CSequenceNumerotationServeur")]
	public class CSequenceNumerotation : CObjetDonneeAIdNumeriqueAuto,
		IObjetALectureTableComplete
	{
		public const string c_nomTable = "NUM_SEQUENCE";
		public const string c_champId = "NS_ID";
		public const string c_champLibelle = "NS_LABEL";
        public const string c_champValeurDepart = "NS_START_VALUE";
        public const string c_champTypeSource = "NS_SOURCE_TYPE";
        public const string c_champFormuleCle = "NS_KEY_FORMULA";

        public const string c_champCacheFormuleCle = "NS_KEY_FORMULA_CACHE";

		/// /////////////////////////////////////////////
		public CSequenceNumerotation( CContexteDonnee contexte)
			:base(contexte)
		{
		}
		
	/// /////////////////////////////////////////////
		public CSequenceNumerotation(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T("Numerotation sequence : @1|20128",Libelle);
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

        /// /////////////////////////////////////////////
		/// <summary>
		/// Le libellé de la séquence
		/// </summary>
		[TableFieldProperty(c_champLibelle, 255)]
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

        /// /////////////////////////////////////////////
        //-------------------------------------------------------------------
        /// <summary>
        /// Format de numérotation exploité pour cette séquence
        /// </summary>
        [Relation(
            CFormatNumerotation.c_nomTable,
            CFormatNumerotation.c_champId,
            CFormatNumerotation.c_champId,
            true,
            false,
            false)]
        [DynamicField("Numbering format")]
        public CFormatNumerotation FormatNumerotation
        {
            get
            {
                return (CFormatNumerotation)GetParent(CFormatNumerotation.c_champId, typeof(CFormatNumerotation));
            }
            set
            {
                SetParent(CFormatNumerotation.c_champId, value);
            }
        }

	


        //--------------------------------------------------------
        /// <summary>
        /// Valeur de départ
        /// </summary>
        [TableFieldProperty ( c_champValeurDepart )]
        [DynamicField("Start value")]
        public int ValeurDepart
        {
            get{
                return (int)Row[c_champValeurDepart];
            }
            set{
                Row[c_champValeurDepart] = value;
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// Catégorie d'objet à laquelle s'applique cette séquence
        /// (exemple : timos.data.CSite)
        /// </summary>
        [TableFieldProperty(c_champTypeSource, 512)]
        [DynamicField("Source type string")]
        public string TypeSourceString
        {
            get
            {
                return (string)Row[c_champTypeSource];
            }
            set
            {
                Row[c_champTypeSource] = value;
            }
        }

        //-----------------------------------------------------------
        public Type TypeSource
        {
            get{
                return CActivatorSurChaine.GetType(TypeSourceString);
            }
            set{
                if ( value != null )
                    TypeSourceString = value.ToString();
                else
                    TypeSourceString = "";
            }
        }

        /// /////////////////////////////////////////////
        [TableFieldProperty(c_champFormuleCle, 2000)]
        public string FormuleCleString
        {
            get
            {
                return (string)Row[c_champFormuleCle];
            }
            set
            {
                Row[c_champFormuleCle] = value;
            }
        }

        /// /////////////////////////////////////////////
        [TableFieldProperty(c_champCacheFormuleCle, NullAutorise = true, IsInDb = false)]
        public C2iExpression FormuleCle
        {
            get
            {
                if (Row[c_champCacheFormuleCle] != DBNull.Value)
                    return (C2iExpression)Row[c_champCacheFormuleCle];
                C2iExpression formule = C2iExpression.FromPseudoCode(FormuleCleString);
                if (formule == null)
                    formule = new C2iExpressionConstante("");
                CContexteDonnee.ChangeRowSansDetectionModification(Row.Row, c_champCacheFormuleCle, formule);
                return formule;
            }
            set
            {
                FormuleCleString = C2iExpression.GetPseudoCode(value);
                CContexteDonnee.ChangeRowSansDetectionModification(Row.Row, c_champCacheFormuleCle, DBNull.Value);
            }
        }

        //--------------------------------------------------------------
        /// <summary>
        /// Retourne la prochaine valeur pour l'entité TIMOS passée en paramètre
        /// </summary>
        /// <param name="source">Entité TIMOS</param>
        /// <returns>La valeur calculée</returns>
        [DynamicMethod("Returns and reserves the next value for this sequence","Source")]
        public string GetNextValue(object source)
        {
            C2iExpression formule = FormuleCle;
            string strCle = "";
            if ( formule != null )
            {
                Type typeSource = TypeSource;
                CContexteEvaluationExpression ctx = null;
                if ( typeSource != null )
                {
                    //Vérifie que la source est du bon type
                    if(  source == null || !typeSource.IsAssignableFrom ( source.GetType() ))
                    {
                        throw new Exception(I.T("Source type is invalide for sequence @1 (@2)",
                            Libelle,
                            source == null?"Null":source.GetType().ToString() ));
                    }
                    ctx = new CContexteEvaluationExpression ( source );
                }
                else
                    ctx = new CContexteEvaluationExpression ( null );
                CResultAErreur result = formule.Eval ( ctx );
                if ( !result )
                {
                    throw new Exception(I.T("Error while evaluating key formula for sequence @1|20131",
                        Libelle));
                }
                if ( result.Data != null )
                    strCle = result.Data.ToString();
                else
                    strCle = "";
            }
            //Cherche la dernière valeur pour cette clé
            CValeurSequenceNumerotation valeur = new CValeurSequenceNumerotation(ContexteDonnee);
            if ( !valeur.ReadIfExists ( new CFiltreData(CValeurSequenceNumerotation.c_champCle+"=@1 and "+
                CSequenceNumerotation.c_champId+"=@2",
                strCle,
                Id ) ))
            {
                valeur.CreateNewInCurrentContexte();
                valeur.SequenceNumerotation = this;
                valeur.DerniereValeur = ValeurDepart;
                valeur.Cle = strCle;
            }
            else
                valeur.DerniereValeur ++;
            string strValeur = strCle+FormatNumerotation.GetReference(valeur.DerniereValeur).Data.ToString();
            return strValeur;
        }

        /// <summary>
        /// Retourne la liste des clés instanciées et des valeurs liées
        /// </summary>
        [RelationFille(typeof(CValeurSequenceNumerotation), "SequenceNumerotation")]
        [DynamicChilds("Values", typeof(CValeurSequenceNumerotation))]
        public CListeObjetsDonnees Valeurs
        {
            get
            {
                return GetDependancesListe(CValeurSequenceNumerotation.c_nomTable, c_champId);
            }
        }
	}
}
