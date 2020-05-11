using System;
using System.Data;
using System.Collections.Generic;

using sc2i.data;
using sc2i.common;
using timos.securite;
using sc2i.workflow;
using timos.acteurs;
using sc2i.multitiers.client;


namespace spv.data
{
    [Table(CSpvEvenementReseau.c_nomTable, CSpvEvenementReseau.c_nomTableInDb, new string[] { CSpvEvenementReseau.c_champALARM_ID }, ModifiedByTrigger = true)]
    [ObjetServeurURI("CSpvEvenementReseauServeur")]
	[DynamicClass("NetworkEvent")]
	public class	CSpvEvenementReseau : CObjetDonneeAIdNumeriqueAuto, IObjetSansVersion
	{
		public const string c_nomTable = "SPV_ALARM";
		public const string c_nomTableInDb = "ALARM";
		public const string c_champALARM_ID ="ALARM_ID";
		public const string c_champALARMGEREE_ID ="ALARMGEREE_ID";
		public const string c_champEQUIP_ID ="EQUIP_ID";
        // ALARM_IDDEB est exploité par PL/SQL.
        // Il est conservé ici pour CSpvAlarmTest
        public const string c_champALARM_IDDEB ="ALARM_IDDEB";
		public const string c_champALARM_NUM ="ALARM_NUM";
		public const string c_champALARM_CL ="ALARM_CL";
		public const string c_champALARM_NUMOBJ ="ALARM_NUMOBJ";
		public const string c_champALARM_NUMAL ="ALARM_NUMAL";
		public const string c_champALARM_DATE ="ALARM_DATE";
		public const string c_champALARM_SEC ="ALARM_SEC";
		public const string c_champALARM_GRAVE ="ALARM_GRAVE";
		public const string c_champALARM_COMMUT ="ALARM_COMMUT";
		public const string c_champALARM_TEXTE ="ALARM_TEXTE";
		public const string c_champALARM_INFO ="ALARM_INFO";
		public const string c_champALARM_COMMENT ="ALARM_COMMENT";
        public const string c_champALARM_HINSERT = "ALARM_HINSERT";
		public const string c_champALARM_TYPMAJ ="ALARM_TYPMAJ";
		public const string c_champALARM_NBRSEQ ="ALARM_NBRSEQ";
        public const string c_champEVENEMENT_TYPE = "EVENEMENT_TYPE";
        public const string c_champALARME_ID = "ALARMDATA_ID";

        public static int m_nGraviteeAlarmFini = 0;
        public const int c_DefaultTexte = 1;
        public const string c_formatDate = "yyyy MM dd HH:mm:ss";

		public const string c_strClasseIS = "IS";
		public const string c_strClasseIS_SERIE = "IS_S";
		public const string c_strClasseTRAPG = "TRAPG";
		public const string c_strClasseTRAPS = "TRAPS";
		public const string c_strClasseSYST = "SYST";
		public const string c_strClasseIP2 = "IP2";
		public const string c_strCLasseGSITE = "GSITE";

        public const int c_TrapSimuMonteeAlarme = 21;
        public const int c_IANA_Futurocom = 9485;
        
		
		///////////////////////////////////////////////////////////////
		public CSpvEvenementReseau( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public CSpvEvenementReseau( DataRow row )
			:base(row)
		{
		}

		
		///////////////////////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
			//TODO : Insérer ici le code d'initalisation
            Row[c_champALARM_TEXTE] = c_DefaultTexte;
            Row[c_champALARM_NBRSEQ] = -1;
		}
		
		///////////////////////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[] {c_champALARM_ID};
		}
		
		///////////////////////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
                return I.T("Network event : @1|50012", AlarmCategory);
                //return I.T("Alarm event : @1|50012", Name);
			}
		}

		
        ///////////////////////////////////////////////////////////////
        /// <summary>
        /// Définit le type d'évenement
        /// </summary>
        [TableFieldProperty(c_champEVENEMENT_TYPE, NullAutorise=false)]
        [DynamicField("Network event type code")]
        public System.Int32 CodeTypeEvenementReseau
        {
            get
            {
                return (System.Int32)Row[c_champEVENEMENT_TYPE];
            }
            set
            {
                Row[c_champEVENEMENT_TYPE] = value;
            }
        }

        ///////////////////////////////////////////////////////////////
        [DynamicField("Network event type")]
        public CTypeEvenementReseau TypeEvenementReseau
        {
            get
            {
                if (Enum.IsDefined(typeof(ETypeEvenementReseau), CodeTypeEvenementReseau))
                {
                    try
                    {
                        return new CTypeEvenementReseau((ETypeEvenementReseau)CodeTypeEvenementReseau);
                    }
                    catch
                    {
                    }
                }
                return null;
            }
            set
            {
                CodeTypeEvenementReseau = value.CodeInt;
            }
        }


		///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champALARM_IDDEB, NullAutorise = true)]
		[DynamicField("Start alarm Id")]
		public System.Int32? StartAlarmId
		{
			get
			{
				if (Row[c_champALARM_IDDEB] == DBNull.Value)
					return null;
                return (System.Int32?)Row[c_champALARM_IDDEB];
			}	
		}
		
				
		///////////////////////////////////////////////////////////////
		/// <summary>
		/// Type de collecte (trap, traps, trapg,...)
		/// </summary>
        [TableFieldProperty(c_champALARM_CL,11)]
		[DynamicField("Alarm category")]
		public System.String AlarmCategory
		{
			get
			{
				return (System.String)Row[c_champALARM_CL];
			}
            set
            {
                Row[c_champALARM_CL, true] = value;
            }
		}


		///////////////////////////////////////////////////////////////
		/// <summary>
		/// Numéro de l'objet de collecte ou du trap
		/// </summary>
        [TableFieldProperty(c_champALARM_NUMOBJ)]
		[DynamicField("Alarm object detail")]
        public System.Int32 AlarmNumObj
		{
			get
			{
                return (System.Int32)Row[c_champALARM_NUMOBJ];
			}
            set
            {
                Row[c_champALARM_NUMOBJ, true] = value;
            }
		}
		
		///////////////////////////////////////////////////////////////
		/// <summary>
		/// Numéro de sortie alarme ou IP
		/// </summary>
        [TableFieldProperty(c_champALARM_NUMAL,40)]
        [DynamicField("Alarm detail")]
        public System.String AlarmNumAl
		{
			get
			{
				return (System.String)Row[c_champALARM_NUMAL];
			}
            set
            {
                Row[c_champALARM_NUMAL] = value;
            }

		}
		

		///////////////////////////////////////////////////////////////
		/// <summary>
		/// Date de l'alarme
		/// </summary>
        [TableFieldProperty(c_champALARM_DATE,20)]
		public string AlarmDateText
		{
			get
			{
                return (System.String)Row[c_champALARM_DATE];
			}
            set
            {
                Row[c_champALARM_DATE, true] = value;
            }
		}


        ///////////////////////////////////////////////////////////////
        [DynamicField("Alarme date")]
        public DateTime AlarmDate
        {
            get
            {
                return DateTime.Parse((System.String)AlarmDateText);
            }
        }


		///////////////////////////////////////////////////////////////
        // Conservée car référencée par SpvQosSvc et EmessEM
		[TableFieldProperty(c_champALARM_SEC)]
        [DynamicField("Alarme date in seconds")]
        public System.Int32 AlarmDateSec
		{
			get
			{
                return (System.Int32)Row[c_champALARM_SEC];
			}			
		}
						
		///////////////////////////////////////////////////////////////
		/// <summary>
		/// code gravité avec masquage
		/// </summary>
        [TableFieldProperty(c_champALARM_GRAVE)]
		[DynamicField("Alarm Severity code")]
		public System.Int32 CodeAlarmGrave
		{
			get
			{
				return (System.Int32)Row[c_champALARM_GRAVE];
			}
            set
            {
                Row[c_champALARM_GRAVE, true] = value;
            }
		}

         ///////////////////////////////////////////////////////////////
        [DynamicField("Alarm severity")]
        public CGraviteAlarmeAvecMasquage AlarmGrave
        {
            get
            {
                if (Enum.IsDefined(typeof(EGraviteAlarmeAvecMasquage), CodeAlarmGrave))
                {
                    try
                    {
                        return new CGraviteAlarmeAvecMasquage((EGraviteAlarmeAvecMasquage)CodeAlarmGrave);
                    }
                    catch
                    {
                    }
                }
                return null;
            }
        }
		
		
		
		///////////////////////////////////////////////////////////////
		/// <summary>
        /// Indique si c'est un commutateur, probablement que ce type d'évenement ne génère pas d'alarme, mais probablement autre chose
		/// </summary>
        [TableFieldProperty(c_champALARM_COMMUT)]
        [DynamicField("Switch")]
		public System.Boolean AlarmCommut
		{
			get
			{
                if (Row[c_champALARM_COMMUT] == DBNull.Value)
                    return false;
                return (System.Boolean)Row[c_champALARM_COMMUT];
			}
		}

        ///////////////////////////////////////////////////////////////
        /// <summary>
        /// Date heure à laquelle l'alarme est mise en base
        /// </summary>
        [TableFieldProperty(c_champALARM_HINSERT, 25, NullAutorise = true)]
        [DynamicField("Insert time")]
        public string HeureInsertion
        {
            get
            {
                if (Row[c_champALARM_HINSERT] == DBNull.Value)
                    return null;
                return (string) Row[c_champALARM_HINSERT];
            }
        }

        
		///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champALARM_TEXTE)]
		[DynamicField("Alarm nature code")]
		public System.Int32 CodeAlarmNature
		{
			get
			{
				return (System.Int32)Row[c_champALARM_TEXTE];
			}			
		}

        
        ///////////////////////////////////////////////////////////////
        [DynamicField("Alarm nature")]
        public CAlarmNature AlarmNature
        {
            get
            {
                if (Enum.IsDefined(typeof(EAlarmNature), CodeAlarmNature))
                {
                    try
                    {
                        return new CAlarmNature((EAlarmNature)CodeAlarmNature);
                    }
                    catch
                    {
                    }
                }
                return null;
            }
        }
		
		///////////////////////////////////////////////////////////////
		/// <summary>
		/// Informations additionnelles
		/// </summary>
        [TableFieldProperty(c_champALARM_INFO,1024)]
		[DynamicField("Alarm Information")]
		public System.String AlarmInfo
		{
			get
			{
				if (Row[c_champALARM_INFO] == DBNull.Value)
					return null;
				return (System.String)Row[c_champALARM_INFO];
			}
            set
            {
                Row[c_champALARM_INFO] = value;
            }
		}
		
		
		///////////////////////////////////////////////////////////////
		/// <summary>
		/// Numéro IANA
		/// </summary>
        [TableFieldProperty(c_champALARM_COMMENT,256, NullAutorise=true)]
		[DynamicField("Comment")]
		public System.String AlarmComment
		{
			get
			{
				if (Row[c_champALARM_COMMENT] == DBNull.Value)
					return null;
				return (System.String)Row[c_champALARM_COMMENT];
			}
            set
            {
                Row[c_champALARM_COMMENT, true] = value;
            }
		}
		
        
		///////////////////////////////////////////////////////////////
		/// <summary>
		/// Type de mise à jour
		/// </summary>
        [TableFieldProperty(c_champALARM_TYPMAJ,1, NullAutorise=true)]
		[DynamicField("Updating type")]
		public System.String AlarmTypMAJ
		{
			get
			{
				if (Row[c_champALARM_TYPMAJ] == DBNull.Value)
					return null;
				return (System.String)Row[c_champALARM_TYPMAJ];
			}			
		}
		
	
		
		///////////////////////////////////////////////////////////////
		/// <summary>
		/// Numéro de séquence du trap (s'il existe, -1 sinon)
		/// </summary>
        [TableFieldProperty(c_champALARM_NBRSEQ)]
		[DynamicField("Sequence number")]
		public System.Int32? SequenceNumber
		{
			get
			{
				if (Row[c_champALARM_NBRSEQ] == DBNull.Value)
					return null;
                return (System.Int32?)Row[c_champALARM_NBRSEQ];
			}
            set
            {
                Row[c_champALARM_NBRSEQ, true] = value;
            }
		}


        /// <summary>
        /// Données de l'alarme
        /// </summary>
        [Relation(
            CSpvAlarmeDonnee.c_nomTable,
            CSpvAlarmeDonnee.c_champALARMEDONNEE_ID,
            CSpvEvenementReseau.c_champALARME_ID,
            false,
            true,
            true)]
        [DynamicField("SpvAlarm")]
        public CSpvAlarmeDonnee SpvAlarme
        {
            get
            {
                return (CSpvAlarmeDonnee)GetParent(c_champALARME_ID, typeof(CSpvAlarmeDonnee));
            }
            set
            {
                SetParent(new string[] { c_champALARME_ID }, value);
            }
        }


        /// <summary>
        /// Equipement en défaut, conservé pour compatibilité de services
        /// </summary>
        [Relation(
            CSpvEquip.c_nomTable,
            CSpvEquip.c_champEQUIP_ID,
            CSpvEvenementReseau.c_champEQUIP_ID,
            false,
            true,
            false)]
        [DynamicField("SpvEquip")]
        public CSpvEquip SpvEquip
        {
            get
            {
                return (CSpvEquip)GetParent(c_champEQUIP_ID, typeof(CSpvEquip));
            }
        }


        /// <summary>
        /// Définition de l'alarme
        /// </summary>
        [Relation ( 
            CSpvAlarmGeree.c_nomTable,
            CSpvAlarmGeree.c_champALARMGEREE_ID,
            CSpvEvenementReseau.c_champALARMGEREE_ID,
            false,
            true,
            false)]

        [DynamicField("SpvAlarmgeree")]
        public CSpvAlarmGeree SpvAlarmgeree
        {
            get
            {
                return (CSpvAlarmGeree)GetParent(c_champALARMGEREE_ID, typeof(CSpvAlarmGeree));
            }
            set
            {
                SetParent(new string[] { c_champALARMGEREE_ID }, value);
            }
        }

        private CSpvEvenementReseauEtatServices evenementReseauEtatsServices
        {
            get
            {
                CSpvEvenementReseauEtatServices alarm2 = new CSpvEvenementReseauEtatServices(ContexteDonnee);
                if (alarm2.ReadIfExists(Id))
                    return alarm2;
               
                return null;
            }
        }


        [DynamicField("All program's operating state")]
        public System.String TsProgsOper
        {
            get
            {
                if (evenementReseauEtatsServices == null)
                    return null;
                else
                    return evenementReseauEtatsServices.TsProgsOper;
            }
        }

        public List<CInfoEtatService> EtatsServices
        {
            get
            {
                if (evenementReseauEtatsServices == null)
                    return null;
                else
                    return evenementReseauEtatsServices.EtatsServices;
            }
        }


        private CSpvEvenementReseauConcernes Concernes
        {
            get
            {
                CSpvEvenementReseauConcernes alarm3 = new CSpvEvenementReseauConcernes(ContexteDonnee);
                if (alarm3.ReadIfExists(Id))
                    return alarm3;

                return null;
            }
        }

        
        [DynamicField("Concerned clients")]
        public System.Int32[] ClientsConcernes
        {
            get
            {
                if (Concernes != null)
                    return Concernes.ClientsConcernes;
                return null;
            }
        }

        [DynamicField("Concerned programs")]
        public System.Int32[] ServicesConcernes
        {
            get
            {
                if (Concernes != null)
                    return Concernes.ServicesConcernes;
                return null;
            }
        }

        [DynamicField("Program's operating state")]
        public double[] ProgsOper
        {
            get
            {
                if (Concernes != null)
                    return Concernes.EtatOperationnelServices;
                return null;
            }
        }

        [DynamicField("Managed object Id")]
        public System.Int32? ElementGereId
        {
            get
            {
                if (Concernes != null)
                    return Concernes.ElementGereId;
                return null;
            }
        }

        [DynamicField("Network element name")]
        public string ElementGereNom
        {
            get
            {
                if (Concernes != null)
                    return Concernes.ElementGereNom;
                return null;
            }
        }

        [DynamicField("Managed object site Id")]
        public System.Int32? ElementGereIdSite
        {
            get
            {
                if (Concernes != null)
                    return Concernes.ElementGereIdSite;
                return null;
            }
        }

        [DynamicField("Managed object site name")]
        public System.String ElementGereNomSite
        {
            get
            {
                if (Concernes != null)
                    return Concernes.ElementGereNomSite;
                return null;
            }
        }

        [DynamicField("Managed object type Id")]
        public System.Int32? ElementGereeIdType
        {
            get
            {
                if (Concernes == null)
                    return null;
                else
                    return Concernes.ElementGereIdType;
            }
        }

        [DynamicField("Network element type name")]
        public string ElementGereNomType
        {
            get
            {
                if (Concernes == null)
                    return null;
                else
                    return Concernes.ElementGereNomType;
            }
        }

       
        public bool VerifieDateTexte()
        {
            if (this.AlarmDateText == "")
                return false;

            try
            {
                DateTime date = DateTime.ParseExact(AlarmDateText, c_formatDate, System.Globalization.CultureInfo.InvariantCulture);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        
        //relation vers enfants
        [RelationFille(typeof(CSpvEvenementReseauEtatServices), "SpvAlarmeEvenement")]
        [DynamicChilds("Operational state services", typeof(CSpvEvenementReseauEtatServices))]
        public CListeObjetsDonnees EtatOperationnelServices
        {
            get
            {
                return GetDependancesListe(CSpvEvenementReseauEtatServices.c_nomTable, CSpvEvenementReseauEtatServices.c_champALARM2_ID);
            }
        }


        [RelationFille(typeof(CSpvEvenementReseauConcernes), "SpvAlarmeEvenement")]
        [DynamicChilds("Concerned network elements", typeof(CSpvEvenementReseauConcernes))]
        public CListeObjetsDonnees ElementsReseauConcernes
        {
            get
            {
                return GetDependancesListe(CSpvEvenementReseauConcernes.c_nomTable, CSpvEvenementReseauConcernes.c_champALARM3_ID);
            }
        }
	}
}
