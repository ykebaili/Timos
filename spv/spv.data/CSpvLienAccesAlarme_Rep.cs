using System;
using System.Data;
using sc2i.data;
using sc2i.common;

// Objet de redondance qui ne sert qu'aux traitements PL/SQL d'alarmes.
namespace spv.data
{
	[Table(CSpvLienAccesAlarme_Rep.c_nomTable,
        CSpvLienAccesAlarme_Rep.c_nomTableInDb,
        new string[]{ CSpvLienAccesAlarme_Rep.c_champACCES_ACCESC_ID},
        ModifiedByTrigger=true)]
    [ObjetServeurURI("CSpvLienAccesAlarme_RepServeur")]
	[DynamicClass("Alarm link dynamic info")]
    public class CSpvLienAccesAlarme_Rep : CObjetDonneeAIdNumerique, IObjetSansVersion
	{
		public const string c_nomTable = "SPV_ACCES_ACCESC_REP";
		public const string c_nomTableInDb = "ACCES_ACCESC_REP";
		public const string c_champACCES_ACCESC_ID ="ACCES_ACCESC_ID";
		public const string c_champALARM_CL ="ALARM_CL";
		public const string c_champALARM_NUMOBJ ="ALARM_NUMOBJ";
		public const string c_champALARM_NUMAL ="ALARM_NUMAL";
		public const string c_champALARM_ID ="ALARM_ID";
        public const string c_champALARMEDONNEE_ID = "ALARMDATA_ID";
		public const string c_champSITE_ID ="SITE_ID";
		public const string c_champEQUIP_ID ="EQUIP_ID";
		public const string c_champLIAI_ID ="LIAI_ID";
		public const string c_champALARM_SEC ="ALARM_SEC";
		public const string c_champALARMGEREE_GRAVE ="ALARMGEREE_GRAVE";
		
		///////////////////////////////////////////////////////////////
		public CSpvLienAccesAlarme_Rep( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public CSpvLienAccesAlarme_Rep( DataRow row )
			:base(row)
		{
		}
		
		///////////////////////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
			//TODO : Insérer ici le code d'initalisation
		}
		
		///////////////////////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[] {c_champACCES_ACCESC_ID};
		}
		
		///////////////////////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T("Alarm link dynamic info @1|30053",Id.ToString());
			}
		}
		
		// Ce champ est géré par les alarmes exclusivement
        // il n'a donc pas à être renseigné ici, d'autre part le fait
        // de remplir par espace lorsque le champ est null pose problème
        // vis à vis de la contrainte check sur cette colonne
        /*
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champALARM_CL,5)]
		[DynamicField("Alarm category")]
        public System.String AlarmCategory
		{
			get
			{
				if (Row[c_champALARM_CL] == DBNull.Value)
					return null;
				return (System.String)Row[c_champALARM_CL];
			}
			set
			{
				Row[c_champALARM_CL,true]=value;
			}
		}*/
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champALARM_NUMOBJ)]
        [DynamicField("Alarm object detail")]
        public System.Double? AlarmNumObj
		{
			get
			{
				if (Row[c_champALARM_NUMOBJ] == DBNull.Value)
					return null;
				return (System.Double?)Row[c_champALARM_NUMOBJ];
			}
			set
			{
				Row[c_champALARM_NUMOBJ,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champALARM_NUMAL,40)]
        [DynamicField("Alarm detail")]
        public System.String AlarmNumAl
		{
			get
			{
				if (Row[c_champALARM_NUMAL] == DBNull.Value)
					return null;
				return (System.String)Row[c_champALARM_NUMAL];
			}
			set
			{
				Row[c_champALARM_NUMAL,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
        /// <summary>
        /// ID de l'événement début d'alarme dans la table ALARM si celle-ci est en cours, null sinon
        /// </summary>
		[TableFieldProperty(c_champALARM_ID)]
		[DynamicField("ALARM_ID")]
		public System.Double? ALARM_ID
		{
			get
			{
				if (Row[c_champALARM_ID] == DBNull.Value)
					return null;
				return (System.Double?)Row[c_champALARM_ID];
			}
			set
			{
				Row[c_champALARM_ID,true]=value;
			}
		}

        ///////////////////////////////////////////////////////////////
        /// <summary>
        /// ID de l'alarme dans la table ALARMDATA si celle-ci est en cours, null sinon
        /// </summary>
        [TableFieldProperty(c_champALARMEDONNEE_ID)]
        [DynamicField("ALARMDATA_ID")]
        public System.Double? ALARMDATA_ID
        {
            get
            {
                if (Row[c_champALARMEDONNEE_ID] == DBNull.Value)
                    return null;
                return (System.Double?)Row[c_champALARMEDONNEE_ID];
            }
            set
            {
                Row[c_champALARMEDONNEE_ID, true] = value;
            }
        }
		

		///////////////////////////////////////////////////////////////
        /// <summary>
        /// ID du site si c'est une alarme de site qui est en cours, null sinon
        /// </summary>
		[TableFieldProperty(c_champSITE_ID)]
		[DynamicField("SITE_ID")]
		public System.Double? SITE_ID
		{
			get
			{
				if (Row[c_champSITE_ID] == DBNull.Value)
					return null;
				return (System.Double?)Row[c_champSITE_ID];
			}
			set
			{
				Row[c_champSITE_ID,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
        /// <summary>
        /// ID de l'équipement si c'est une alarme d'équipement qui est en cours, null sinon
        /// </summary>
		[TableFieldProperty(c_champEQUIP_ID)]
		[DynamicField("EQUIP_ID")]
		public System.Double? EQUIP_ID
		{
			get
			{
				if (Row[c_champEQUIP_ID] == DBNull.Value)
					return null;
				return (System.Double?)Row[c_champEQUIP_ID];
			}
			set
			{
				Row[c_champEQUIP_ID,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
        /// <summary>
        /// ID de la liaison si c'est une alarme de liaison qui est en cours, null sinon
        /// </summary>
		[TableFieldProperty(c_champLIAI_ID)]
		[DynamicField("LIAI_ID")]
		public System.Double? LIAI_ID
		{
			get
			{
				if (Row[c_champLIAI_ID] == DBNull.Value)
					return null;
				return (System.Double?)Row[c_champLIAI_ID];
			}
			set
			{
				Row[c_champLIAI_ID,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
        /// <summary>
        /// Date de début de l'alarme (en nombre de secondes depuis le 01/01/1998) si celle
        /// est en cours, null sinon
        /// </summary>
		[TableFieldProperty(c_champALARM_SEC)]
		[DynamicField("Alarm date (sec.)")]
		public System.Double? DateAlarmeEnSecondes
		{
			get
			{
				if (Row[c_champALARM_SEC] == DBNull.Value)
					return null;
				return (System.Double?)Row[c_champALARM_SEC];
			}
			set
			{
				Row[c_champALARM_SEC,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
        /// <summary>
        /// Code de gravité de l'alarme gérée correspondante
        /// </summary>
		[TableFieldProperty(c_champALARMGEREE_GRAVE)]
		[DynamicField("Alarm Severity code")]
        public System.Int32? CodeAlarmGrave
		{
			get
			{
				if (Row[c_champALARMGEREE_GRAVE] == DBNull.Value)
					return null;
				return (System.Int32?)Row[c_champALARMGEREE_GRAVE];
			}
			set
			{
				Row[c_champALARMGEREE_GRAVE,true]=value;
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


        //relation vers parent
        [Relation(CSpvEvenementReseau.c_nomTable, new string[] { CSpvEvenementReseau.c_champALARM_ID }, new string[] { CSpvLienAccesAlarme_Rep.c_champALARM_ID }, false, false)]
        [DynamicField("Alarm event")]
        public CSpvEvenementReseau EvenementReseau
        {
            get
            {
                return (CSpvEvenementReseau)GetParent(new string[] { c_champALARM_ID }, typeof(CSpvEvenementReseau));
            }
            set
            {
                SetParent(new string[] { c_champALARM_ID }, value);
            }
        }

        //relation vers parent
        [Relation(CSpvAlarmeDonnee.c_nomTable, new string[] { CSpvAlarmeDonnee.c_champALARMEDONNEE_ID }, new string[] { CSpvLienAccesAlarme_Rep.c_champALARMEDONNEE_ID }, false, false)]
        [DynamicField("Alarm data")]
        public CSpvAlarmeDonnee AlarmeDonnee
        {
            get
            {
                return (CSpvAlarmeDonnee)GetParent(new string[] { c_champALARMEDONNEE_ID }, typeof(CSpvAlarmeDonnee));
            }
            set
            {
                SetParent(new string[] { c_champALARMEDONNEE_ID }, value);
            }
        }

        //relation vers parent
        [Relation(CSpvLienAccesAlarme.c_nomTable, new string[] { CSpvLienAccesAlarme.c_champACCES_ACCESC_ID }, new string[] { CSpvLienAccesAlarme_Rep.c_champACCES_ACCESC_ID }, false, true)]
        [DynamicField("LienAccesAlarmes")]
        public CSpvLienAccesAlarme LienAccesAlarmes
        {
            get
            {
                return (CSpvLienAccesAlarme)GetParent(new string[] { c_champACCES_ACCESC_ID }, typeof(CSpvLienAccesAlarme));
            }
            set
            {
                SetParent(new string[] { c_champACCES_ACCESC_ID }, value);
            }
        }
	}
}
