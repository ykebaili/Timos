using System;
using System.Collections;
using System.Data;
using System.Drawing;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using tiag.client;

namespace sc2i.workflow
{
	/// <summary>
	/// Le type d'occupation horaire permet de cr�er des cat�gories d'occupation.<br/>
    /// Exemples : 'Heures ouvrables', 'Heures non ouvrables', 'repos', etc.<br/>
	/// Chaque type d'occupation horaire dispose d'un ordre de priorit� qui permettra 
	/// d'�tablir des classements sur les activit�s.<br/>
	/// </summary>
    [sc2i.doccode.DocRefMenusOrMenuItems(timos.data.CDocLabels.c_iPlanif)]
    [DynamicClass("Diary occupation type")]
	[Table(CTypeOccupationHoraire.c_nomTable, CTypeOccupationHoraire.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CTypeOccupationHoraireServeur")]
    [Unique(true, "This Label already exist|50", CTypeOccupationHoraire.c_champLibelle)]
    //[Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_TypeOccupation_ID)]
    [TiagClass(CTypeOccupationHoraire.c_nomTiag, "Id", true)]
    public class CTypeOccupationHoraire : CObjetDonneeAIdNumeriqueAuto, IObjetALectureTableComplete
	{
        public const string c_nomTable = "DIARY_OCCUPATION_TYPE";
        public const string c_nomTiag = "Diary Occupation Type";
		
		public const string c_champId = "DRYOCCTY_ID";
		public const string c_champLibelle = "DRYOCCTY_LABEL";
        public const string c_champCode = "DRYOCCTY_CODE";
        public const string c_champCouleur = "DRYOCCTY_COLOR";
        public const string c_champEstDisponible = "DRYOCCTY_IS_AVAILABLE";

		public const string c_champSurOperation = "DRYOCCTY_ON_OP";
		public const string c_champSurCalendrier = "DRYOCCTY_ON_CALEND";
		public const string c_champIsTempDeTravail = "DRYOCCTY_WORK_TIME";

		public const string c_champPriorite = "DRYOCCTY_PRIORITY";

		


		/// /////////////////////////////////////////////
		public CTypeOccupationHoraire( CContexteDonnee contexte)
			:base(contexte)
		{
		}
		
	/// /////////////////////////////////////////////
		public CTypeOccupationHoraire(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T( "Diary occupation type @1|348", Libelle);
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
            // Par d�faut "blanc"
            // A = 255, R = 0, G = 0, B = 0
            Couleur = Color.White.ToArgb();
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champLibelle};
		}

		/// <summary>
		/// La valeur de la priorit� d�finit le classement d'un type d'occupation
		/// horaire en fonction des autres.<br/>
		/// 0 correspond � la priorit� la plus faible, tandis que 2147483647 est la plus
		/// haute valeur de priorit� possible.<br/><br/>
		/// <remarks>
		/// Il vous est recommand� d'utiliser des param�trages sur au moins 3 chiffres
		/// pour vous �viter d'avoir � repasser dans tout vos types d'occupation horaire
		/// lorsqu'un nouveau type d'occupation, de priorit� interm�diaire, devient n�cessaire.
		/// </remarks>
		/// </summary>
		[TableFieldProperty(c_champPriorite)]
		[DynamicField("Priority")]
        [TiagField("Priority")]
		public int Priorite
		{
			get
			{
				return (int)Row[c_champPriorite];
			}
			set
			{
				Row[c_champPriorite] = value;
			}
		}
        
		

		/// <summary>
		/// Libell� du type d'occupation<br/>
		/// (obligatoire)
		/// </summary>
		[TableFieldProperty(c_champLibelle, 128)]
		[DynamicField("Label")]
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


		//-----------------------------------------------------------
		/// <summary>
		/// Si VRAI, cette valeur indique que le temps de ce type d'occupation
		/// est consid�r� comme du temps de travail.<BR>
		/// </BR>
		/// Les journ�es li�es � ce type d'occupation peuvent donc �tre comptabilis�es
		/// comme temps de travail de la personne associ�e au calendrier.
		/// </summary>
		[TableFieldProperty(c_champIsTempDeTravail)]
		[DynamicField("Work time")]
        [TiagField("Work time")]
		public bool TempsDeTravail
		{
			get
			{
				return (bool)Row[c_champIsTempDeTravail];
			}
			set
			{
				Row[c_champIsTempDeTravail] = value;
			}
		}




		/// <summary>
		/// Donne ou d�finit si ce type d'occupation est utilisable dans les calendriers
        /// (TRUE si utilisable, FALSE dans le cas contraire) 
		/// </summary>
		[TableFieldProperty(c_champSurCalendrier)]
		[DynamicField("On calendar")]
        [TiagField("On calendar")]
		public bool SurCalendrier
		{
			get
			{
				return (bool)Row[c_champSurCalendrier];
			}
			set
			{
				Row[c_champSurCalendrier] = value;
			}
		}


		/// <summary>
		/// Donne ou d�finit si ce type d'occupation est utilisable pour les operations
        /// (TRUE si utilisable, FALSE dans le cas contraire)
		/// </summary>
		[TableFieldProperty(c_champSurOperation)]
		[DynamicField("On operation")]
        [TiagField("On operation")]
		public bool SurOperation
		{
			get
			{
				return (bool)Row[c_champSurOperation];
			}
			set
			{
				Row[c_champSurOperation] = value;
			}
		}



        //-----------------------------------------------------------
        /// <summary>
        /// Donne ou d�finit le Code du Type d'Occupation Horaire
        /// </summary>
        [TableFieldProperty(c_champCode, 256)]
        [DynamicField("Code")]
        [TiagField("Code")]
        public string Code
        {
            get
            {
                return (string)Row[c_champCode];
            }
            set
            {
                Row[c_champCode] = value;
            }
        }


        //-----------------------------------------------------------
        /// <summary>
        /// Donne ou d�finit le Code couleur correspondant au type d'occupation.
        /// Ce code couleur est exploit�, par exemple dans les calendriers.
        /// </summary>
        [TableFieldProperty(c_champCouleur)]
        [DynamicField("Color")]
        [TiagField("Color")]
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

        //-----------------------------------------------------------
        /// <summary>
        /// Donne ou d�finit la disponibilit� d'un acteur pour ce type d'occupation.
        /// (TRUE si disponible, FALSE dans le cas contraire).
        /// Par exemple, pour un type d'occupation 'Heures ouvrables', un acteur
        /// est consid�r� comme disponible, dans le sens o� il peut travailler,
        /// contrairement � un type d'occupation 'Repos'.
        /// </summary>
        [TableFieldProperty(c_champEstDisponible)]
        [DynamicField("Is Available")]
        [TiagField("Is Available")]
        public bool EstDisponible
        {
            get
            {
                return (bool)Row[c_champEstDisponible];
            }
            set
            {
                Row[c_champEstDisponible] = value;
            }
        }


	}

	/// <summary>
	/// Tri des types d'occupation du plus prioritaire au moins prioritaire
	/// </summary>
	public class CTypeOccupationHoraire_PrioriteComparer : System.Collections.Generic.IComparer<CTypeOccupationHoraire>
	{
		public int Compare(CTypeOccupationHoraire x, CTypeOccupationHoraire y)
		{
            // Si le type d'occupation est null la priorit� est la plus basse = 0
            int nxPriorite = x != null ? x.Priorite : 0;
            int nyPriorite = y != null ? y.Priorite : 0;

			if (nxPriorite == nyPriorite)
				return 0;
			else if (nxPriorite > nyPriorite)
				return 1;
			else
				return -1;
		}
	}

}
