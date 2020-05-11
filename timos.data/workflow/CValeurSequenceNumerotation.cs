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
    /// Valeur d'une <see cref="CSequenceNumerotation">séquence de numérotation</see>
	/// </summary>
    [DynamicClass("Numeration sequence value")]
	[Table(CValeurSequenceNumerotation.c_nomTable, CValeurSequenceNumerotation.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CValeurSequenceNumerotationServeur")]
    [Unique(true, "Value already exists", CSequenceNumerotation.c_champId, CValeurSequenceNumerotation.c_champCle)]
	public class CValeurSequenceNumerotation : CObjetDonneeAIdNumeriqueAuto,
		IObjetALectureTableComplete
	{
		public const string c_nomTable = "NUM_SEQUENCE_VALUE";
		public const string c_champId = "NSV_ID";
		public const string c_champCle = "NSV_KEY";
        public const string c_champLast = "NSV_LAST";
        
		/// /////////////////////////////////////////////
		public CValeurSequenceNumerotation( CContexteDonnee contexte)
			:base(contexte)
		{
		}
		
	/// /////////////////////////////////////////////
		public CValeurSequenceNumerotation(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T("Numerotation sequence value|20129");
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

        /// /////////////////////////////////////////////
		/// <summary>
		/// Clé associée à la valeur; pour qu'elle soit non vide,
        /// il faut que la formule de clé définie dans la séquence
        /// de numérotation soit renseignée
		/// </summary>
		[TableFieldProperty(c_champCle, 1024)]
		[DynamicField("Key")]
        [IndexField]
		public string Cle
		{
			get
			{
				return (string)Row[c_champCle];
			}
			set
			{
                Row[c_champCle] = value;
			}
		}

        /// /////////////////////////////////////////////
        //-----------------------------------------------------------
        /// <summary>
        /// Dernière valeur
        /// </summary>
        [TableFieldProperty(c_champLast)]
        [DynamicField("Last value")]
        public int DerniereValeur
        {
            get
            {
                return (int)Row[c_champLast];
            }
            set
            {
                Row[c_champLast] = value;
            }
        }

        //-------------------------------------------------------------------
        /// <summary>
        /// Séquence de numérotation correspondante
        /// </summary>
        [Relation(
            CSequenceNumerotation.c_nomTable,
            CSequenceNumerotation.c_champId,
            CSequenceNumerotation.c_champId,
            true,
            true,
            true)]
        [DynamicField("Sequence type")]
        public CSequenceNumerotation SequenceNumerotation
        {
            get
            {
                return (CSequenceNumerotation)GetParent(CSequenceNumerotation.c_champId, typeof(CSequenceNumerotation));
            }
            set
            {
                SetParent(CSequenceNumerotation.c_champId, value);
            }
        }

        protected override string ProtectedGetMessageAccesConccurentiel()
        {
            return I.T("Fail to obtain a new value '@1'. Please try to validate again|20132",
                SequenceNumerotation.Libelle);
        }

	



        
	}
}
