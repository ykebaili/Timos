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
	/// Le type d'occupation horaire permet de créer des catégories d'occupation.<br/>
    /// Exemples : 'Heures ouvrables', 'Heures non ouvrables', 'repos', etc.<br/>
	/// Chaque type d'occupation horaire dispose d'un ordre de priorité qui permettra 
	/// d'établir des classements sur les activités.<br/>
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
            // Par défaut "blanc"
            // A = 255, R = 0, G = 0, B = 0
            Couleur = Color.White.ToArgb();
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champLibelle};
		}

		/// <summary>
		/// La valeur de la priorité définit le classement d'un type d'occupation
		/// horaire en fonction des autres.<br/>
		/// 0 correspond à la priorité la plus faible, tandis que 2147483647 est la plus
		/// haute valeur de priorité possible.<br/><br/>
		/// <remarks>
		/// Il vous est recommandé d'utiliser des paramétrages sur au moins 3 chiffres
		/// pour vous éviter d'avoir à repasser dans tout vos types d'occupation horaire
		/// lorsqu'un nouveau type d'occupation, de priorité intermédiaire, devient nécessaire.
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
		/// Libellé du type d'occupation<br/>
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
		/// est considéré comme du temps de travail.<BR>
		/// </BR>
		/// Les journées liées à ce type d'occupation peuvent donc être comptabilisées
		/// comme temps de travail de la personne associée au calendrier.
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
		/// Donne ou définit si ce type d'occupation est utilisable dans les calendriers
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
		/// Donne ou définit si ce type d'occupation est utilisable pour les operations
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
        /// Donne ou définit le Code du Type d'Occupation Horaire
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
        /// Donne ou définit le Code couleur correspondant au type d'occupation.
        /// Ce code couleur est exploité, par exemple dans les calendriers.
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
        /// Donne ou définit la disponibilité d'un acteur pour ce type d'occupation.
        /// (TRUE si disponible, FALSE dans le cas contraire).
        /// Par exemple, pour un type d'occupation 'Heures ouvrables', un acteur
        /// est considéré comme disponible, dans le sens où il peut travailler,
        /// contrairement à un type d'occupation 'Repos'.
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
            // Si le type d'occupation est null la priorité est la plus basse = 0
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
