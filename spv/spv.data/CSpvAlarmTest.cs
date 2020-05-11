using System;
using System.Data;
using sc2i.data;
using sc2i.common;

namespace spv.data
{
    [Table(CSpvAlarmTest.c_nomTable, CSpvAlarmTest.c_nomTableInDb, new string[] { CSpvAlarmTest.c_champALARM_ID })]
    [ObjetServeurURI("CSpvAlarmTestServeur")]
    [DynamicClass("Test alarm")]
    public class CSpvAlarmTest : CObjetDonneeAIdNumeriqueAuto, IObjetSansVersion
    {
        public const string c_nomTable = "SPV_ALARM_TEST";
        public const string c_nomTableInDb = "ALARM";
        public const string c_champALARM_ID = "ALARM_ID";
        public const string c_champALARMGEREE_ID = "ALARMGEREE_ID";
        public const string c_champALARM_TYPE = "ALARM_TYPE";
        public const string c_champSITE_ID = "SITE_ID";
        public const string c_champEQUIP_ID = "EQUIP_ID";
        public const string c_champLIAI_ID = "LIAI_ID";
        public const string c_champALARM_NOM = "ALARM_NOM";
        public const string c_champALARM_IDDEB = "ALARM_IDDEB";
        public const string c_champALARM_NUM = "ALARM_NUM";
        public const string c_champALARM_CL = "ALARM_CL";
        public const string c_champALARM_NUMOBJ = "ALARM_NUMOBJ";
        public const string c_champALARM_NUMAL = "ALARM_NUMAL";
        public const string c_champALARM_DATE = "ALARM_DATE";
        public const string c_champALARM_SEC = "ALARM_SEC";
        public const string c_champALARM_GRAVE = "ALARM_GRAVE";
        public const string c_champALARM_LOCAL = "ALARM_LOCAL";
        public const string c_champALARM_NSEUIL = "ALARM_NSEUIL";
        public const string c_champALARM_VSEUIL = "ALARM_VSEUIL";
        public const string c_champALARM_COMMUT = "ALARM_COMMUT";
        public const string c_champALARM_TEXTE = "ALARM_TEXTE";
        public const string c_champALARM_INFO = "ALARM_INFO";
        public const string c_champALARM_COMMENT = "ALARM_COMMENT";
        public const string c_champCABLAGEP_ID = "CABLAGEP_ID";
        public const string c_champALARM_IANA = "ALARM_IANA";
        public const string c_champALARM_AQUITTEE = "ALARM_AQUITTEE";
        public const string c_champALARM_ACQUITWHO = "ALARM_ACQUITWHO";
        public const string c_champALARM_ACQUITWHEN = "ALARM_ACQUITWHEN";
        public const string c_champALARM_TYPMAJ = "ALARM_TYPMAJ";
        public const string c_champALARM_DEB_SEC = "ALARM_DEB_SEC";
        public const string c_champALARM_NBRSEQ = "ALARM_NBRSEQ";

        public static int m_nGraviteeAlarmFini = 0;

        ///////////////////////////////////////////////////////////////
        public CSpvAlarmTest(CContexteDonnee ctx)
            : base(ctx)
        {
        }

        ///////////////////////////////////////////////////////////////
        public CSpvAlarmTest(DataRow row)
            : base(row)
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
            return new string[] { c_champALARM_ID };
        }

        ///////////////////////////////////////////////////////////////
        public override string DescriptionElement
        {
            get
            {
                return ("Test alarm ");
            }
        }


        ///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champALARMGEREE_ID)]
        [DynamicField("Alarmgeree Id")]
        public System.Int32? AlarmgereeId
        {
            get
            {
                if (Row[c_champALARMGEREE_ID] == DBNull.Value)
                    return null;
                return (System.Int32?)Row[c_champALARMGEREE_ID];
            }

            set
            {
                Row[c_champALARMGEREE_ID, true] = value;
            }
           
        }



        ///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champALARM_NUM)]
        [DynamicField("Alarm_Num")]
        public System.Int32? AlarmNum
        {
            get
            {
                if (Row[c_champALARM_NUM] == DBNull.Value)
                    return null;
                return (System.Int32?)Row[c_champALARM_NUM];
            }

            set
            {
                Row[c_champALARM_NUM, true] = value;
            }

        }

        ///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champALARM_TYPE)]
        [DynamicField("Event type code")]
        public System.Int32? CodeAlarmEvent
        {
            get
            {
                if (Row[c_champALARM_TYPE] == DBNull.Value)
                    return null;
                return (System.Int32?)Row[c_champALARM_TYPE];
            }

            set
            {
                Row[c_champALARM_TYPE, true] = value;
            }
        }

        ///////////////////////////////////////////////////////////////
        [DynamicField("Event type")]
        public CAlarmEvent AlarmEvent
        {
            get
            {
                if (CodeAlarmEvent == null)
                    return null;

                if (Enum.IsDefined(typeof(EAlarmEvent), CodeAlarmEvent))
                {
                    try
                    {
                        return new CAlarmEvent((EAlarmEvent)CodeAlarmEvent);
                    }
                    catch
                    {
                    }
                }
                return null;
            }

            set
            {
                CodeAlarmEvent = (int)value.Code;
            }


        }

        ///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champSITE_ID)]
        [DynamicField("Site Id")]
        public System.Int32? SiteId
        {
            get
            {
                if (Row[c_champSITE_ID] == DBNull.Value)
                    return null;
                return (System.Int32?)Row[c_champSITE_ID];
            }

            set
            {
                Row[c_champSITE_ID, true] = value;
            }
        }

        ///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champEQUIP_ID)]
        [DynamicField("Equip Id")]
        public System.Int32? EquipId
        {
            get
            {
                if (Row[c_champEQUIP_ID] == DBNull.Value)
                    return null;
                return (System.Int32?)Row[c_champEQUIP_ID];
            }
            set
            {
                Row[c_champEQUIP_ID, true] = value;
            }
        }


        ///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champLIAI_ID)]
        [DynamicField("Liai Id")]
        public System.Int32? LiaiId
        {
            get
            {
                if (Row[c_champLIAI_ID] == DBNull.Value)
                    return null;
                return (System.Int32?)Row[c_champLIAI_ID];
            }

            set
            {
                Row[c_champLIAI_ID, true] = value;
            }
        }


        ///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champALARM_NOM, 40)]
        [DynamicField("Alarm Name")]
        public System.String Name
        {
            get
            {
                if (Row[c_champALARM_NOM] == DBNull.Value)
                    return null;
                return (System.String)Row[c_champALARM_NOM];
            }
            set
            {
                Row[c_champALARM_NOM, true] = value;
            }
        }

        ///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champALARM_IDDEB)]
        [DynamicField("Start alarm Id")]
        public System.Int32? StartAlarmId
        {
            get
            {
                if (Row[c_champALARM_IDDEB] == DBNull.Value)
                    return null;
                return (System.Int32?)Row[c_champALARM_IDDEB];
            }

            set
            {
                Row[c_champALARM_IDDEB, true] = value;
            }
        }

        ///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champALARM_CL, 11)]
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
        [TableFieldProperty(c_champALARM_NUMAL, 40)]
        [DynamicField("Alarm detail")]
        public System.String AlarmNumAl
        {
            get
            {
                return (System.String)Row[c_champALARM_NUMAL];
            }

            set
            {
                Row[c_champALARM_NUMAL, true] = value;
            }
        }

        ///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champALARM_DATE, 20)]
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
        /*	[TableFieldProperty(c_champALARM_SEC)]
            [DynamicField("Alarme date in seconds")]
            public System.Int32 AlarmDateSec
            {
                get
                {
                    return (System.Int32)Row[c_champALARM_SEC];
                }			
            }*/

        ///////////////////////////////////////////////////////////////
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

            set
            {
                CodeAlarmGrave = (int)value.Code;
            }
        }


        ///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champALARM_LOCAL, NullAutorise = true)]
        [DynamicField("Local Alarm")]
        public System.Boolean? AlarmLocal
        {
            get
            {
                if (Row[c_champALARM_LOCAL] == DBNull.Value)
                    return null;
                return (System.Boolean?)Row[c_champALARM_LOCAL];
            }

            set
            {
                Row[c_champALARM_LOCAL, true] = value;
            }


        }

        ///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champALARM_NSEUIL, 40)]
        [DynamicField("Threshold Name")]
        public System.String AlarmSeuilNom
        {
            get
            {
                if (Row[c_champALARM_NSEUIL] == DBNull.Value)
                    return null;
                return (System.String)Row[c_champALARM_NSEUIL];
            }

            set
            {
                Row[c_champALARM_NSEUIL, true] = value;
            }

        }

        ///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champALARM_VSEUIL)]
        [DynamicField("Threshold value")]
        public System.Int32? AlarmSeuilValeur
        {
            get
            {
                if (Row[c_champALARM_VSEUIL] == DBNull.Value)
                    return null;
                return (System.Int32?)Row[c_champALARM_VSEUIL];
            }

            set
            {
                Row[c_champALARM_VSEUIL, true] = value;
            }
        }

        ///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champALARM_COMMUT)]
        [DynamicField("Switch")]
        public System.Boolean AlarmCommut
        {
            get
            {
                return (System.Boolean)Row[c_champALARM_COMMUT];
                
            }

            set
            {
                Row[c_champALARM_COMMUT, true] = value;
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

            set
            {
                Row[c_champALARM_TEXTE, true] = value;
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

            set
            {
                CodeAlarmNature = (int)value.Code;
            }
        }

        ///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champALARM_INFO, 1024)]
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
                Row[c_champALARM_INFO, true] = value;
            }
        }


        ///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champALARM_COMMENT, 256)]
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
        [TableFieldProperty(c_champCABLAGEP_ID)]
        [DynamicField("Acces wiring Id")]
        public System.Int32? AccesAccescId
        {
            get
            {
                if (Row[c_champCABLAGEP_ID] == DBNull.Value)
                    return null;
                return (System.Int32?)Row[c_champCABLAGEP_ID];
            }

            set
            {
                Row[c_champCABLAGEP_ID, true] = value;
            }

        }

        ///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champALARM_IANA)]
        [DynamicField("IANA")]
        public System.Int32? AlarmIANA
        {
            get
            {
                if (Row[c_champALARM_IANA] == DBNull.Value)
                    return null;
                return (System.Int32?)Row[c_champALARM_IANA];
            }

            set
            {
                Row[c_champALARM_IANA, true] = value;
            }
        }

        ///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champALARM_AQUITTEE, NullAutorise = true)]
        [DynamicField("Alarm acknowledgement")]
        public System.Boolean? AlarmAquittee
        {
            get
            {
                if (Row[c_champALARM_AQUITTEE] == DBNull.Value)
                    return null;
                return (System.Boolean?)Row[c_champALARM_AQUITTEE];
            }
            set
            {
                Row[c_champALARM_AQUITTEE] = value;
            }

        }

        ///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champALARM_ACQUITWHO, 40)]
        [DynamicField("Acknowledged by")]
        public System.String AcquitteePar
        {
            get
            {
                if (Row[c_champALARM_ACQUITWHO] == DBNull.Value)
                    return null;
                return (System.String)Row[c_champALARM_ACQUITWHO];
            }
            set
            {
                Row[c_champALARM_ACQUITWHO] = value;
            }
        }

        ///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champALARM_ACQUITWHEN, 20)]
        public System.String AcquittementDateString
        {
            get
            {
                if (Row[c_champALARM_ACQUITWHEN] == DBNull.Value)
                    return null;
                return (System.String)Row[c_champALARM_ACQUITWHEN];
            }
            set
            {
                Row[c_champALARM_ACQUITWHEN] = value;
            }
        }

        ///////////////////////////////////////////////////////////////
        [DynamicField("Acknowledgement date")]
        public System.DateTime? AcquittementDate
        {
            get
            {
                if (AcquittementDateString == null)
                    return null;
                else
                {
                    DateTime date = new DateTime();
                    date = DateTime.Parse(AcquittementDateString);
                    return date;
                }
            }
            set
            {
                if (value == null)
                    AcquittementDateString = "";
                else
                {
                    DateTime date = (DateTime)value;
                    AcquittementDateString = "'" + date.ToString() + "'";// string.Format("{0}/{1}/{2} {3}:{4}:{5}", date.Day, date.Month, date.Year,
                    //    date.Hour, date.Minute, date.Second);                    
                }
            }
        }

        ///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champALARM_TYPMAJ, 1)]
        [DynamicField("Updating type")]
        public System.String AlarmTypMAJ
        {
            get
            {
                if (Row[c_champALARM_TYPMAJ] == DBNull.Value)
                    return null;
                return (System.String)Row[c_champALARM_TYPMAJ];
            }
            set
            {
                Row[c_champALARM_TYPMAJ, true] = value;
            }
        }

        ///////////////////////////////////////////////////////////////
        /*	[TableFieldProperty(c_champALARM_DEB_SEC)]
            [DynamicField("Starting alarm date")]
            public DateTime? AlarmDebSec
            {
                get
                {
                    if (Row[c_champALARM_DEB_SEC] == DBNull.Value)
                        return null;
                    else
                    {
                        CDivers div = new CDivers();
                        return div.FromSecToDate((System.Double?)Row[c_champALARM_DEB_SEC]);
                    }     
                }
			
            }*/

        [TableFieldProperty(c_champALARM_DEB_SEC)]
        public System.Int32? AlarmDebSec
        {
            get
            {
                if (Row[c_champALARM_DEB_SEC] == DBNull.Value)
                    return null;
                else
                    return (System.Int32?)Row[c_champALARM_DEB_SEC];
            }

            set
            {
                Row[c_champALARM_DEB_SEC, true] = value;
            }
        }


        [DynamicField("Starting alarm date")]
        public DateTime? AlarmDebutDate
        {
            get
            {
                if (AlarmDebSec == null)
                    return null;
                else
                {
                    CDivers div = new CDivers();
                    return div.FromSecToDate((System.Double?)AlarmDebSec);
                }
            }
        }

        ///////////////////////////////////////////////////////////////
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

        [DynamicField("SpvSite")]
        public CSpvSite SpvSite
        {
            get
            {
                if (SiteId != null)
                {
                    CSpvSite site = new CSpvSite(ContexteDonnee);
                    if (site.ReadIfExists((int)SiteId))
                        return site;
                }
                return null;
            }
        }

        [DynamicField("SpvEquip")]
        public CSpvEquip SpvEquip
        {
            get
            {
                if (EquipId != null)
                {
                    CSpvEquip equip = new CSpvEquip(ContexteDonnee);
                    if (equip.ReadIfExists((int)EquipId))
                        return equip;
                }
                return null;
            }
        }

        [DynamicField("SpvLiai")]
        public CSpvLiai SpvLiai
        {
            get
            {
                if (LiaiId != null)
                {
                    CSpvLiai liai = new CSpvLiai(ContexteDonnee);
                    if (liai.ReadIfExists((int)LiaiId))
                        return liai;
                }
                return null;
            }
        }

        [DynamicField("SpvAlarmgeree")]
        public CSpvAlarmGeree SpvAlarmgeree
        {
            get
            {
                if (AlarmgereeId != null)
                {
                    CSpvAlarmGeree alarmgeree = new CSpvAlarmGeree(ContexteDonnee);
                    if (alarmgeree.ReadIfExists((int)AlarmgereeId))
                        return alarmgeree;
                }
                return null;
            }
        }

        private CSpvEvenementReseauEtatServices SpvAlarm2
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
                if (SpvAlarm2 == null)
                    return null;
                else
                    return SpvAlarm2.TsProgsOper;
            }
        }

        private CSpvEvenementReseauConcernes SpvAlarm3
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
                if (SpvAlarm3 == null)
                    return null;
                else
                    return SpvAlarm3.ClientsConcernes;
            }
        }

        [DynamicField("Concerned programs")]
        public System.Int32[] ProgrammesConcernes
        {
            get
            {
                if (SpvAlarm3 == null)
                    return null;
                else
                    return SpvAlarm3.ServicesConcernes;
            }
        }

        [DynamicField("Program's operating state")]
        public double[] ProgsOper
        {
            get
            {
                if (SpvAlarm3 == null)
                    return null;
                else
                    return SpvAlarm3.EtatOperationnelServices;
            }
        }

        [DynamicField("Managed object name")]
        public System.String ElementGereNom
        {
            get
            {
                if (SpvAlarm3 == null)
                    return null;
                else
                    return SpvAlarm3.ElementGereNom;
            }
        }

        [DynamicField("Site name")]
        public System.String SiteNom
        {
            get
            {
                if (SpvAlarm3 == null)
                    return null;
                else
                    return SpvAlarm3.ElementGereNomSite;
            }
        }

        [DynamicField("Managed object type name")]
        public System.String ElementGereeNomType
        {
            get
            {
                if (SpvAlarm3 == null)
                    return null;
                else
                    return SpvAlarm3.ElementGereNomType;
            }
        }

        /*
        [DynamicField("Alarm custom data")]
        public System.String AlarmGereeFiche
        {
            get
            {
                if (SpvAlarm3 == null)
                    return null;
                else
                    return SpvAlarm3.AlarmGereeFiche;
            }
        }

        [DynamicField("Managed object custom data")]
        public System.String ElementGereeFiche
        {
            get
            {
                if (SpvAlarm3 == null)
                    return null;
                else
                    return SpvAlarm3.ElementGereeFiche;
            }
        }*/

        public CSpvLienAccesAlarme SpvAccesAccesc
        {
            get
            {
                CSpvLienAccesAlarme accesAccesc = new CSpvLienAccesAlarme(ContexteDonnee);
                if (AccesAccescId > 0 && accesAccesc.ReadIfExists((int)AccesAccescId))
                    return accesAccesc;

                return null;
            }
        }

        public string GetBindingVarInfo()
        {
            if (AlarmCategory.ToUpper().Contains("TRAP"))
            {
                string stSQL;
                stSQL = string.Format("select BindingVarInfo('{0}', {1}, {2}, {3}) from dual",
                    AlarmInfo, (int)EquipId, (int)AlarmIANA, AlarmNumObj);

                CResultAErreur result = CExecuteurRequeteSpv.ExecuteScalar(0, stSQL);
                return result.Data.ToString();
            }

            return "";
        }
        /*
        ///////////////////////////////////////////////////////////////
        //relation vers parent
        [Relation(CSpvEvenementReseau.c_nomTable, new string[] { CSpvEvenementReseau.c_champALARM_IDDEB }, new string[] { CSpvEvenementReseau.c_champALARM_ID }, false, false)]
        [DynamicField("Alarm Start")]
        public CSpvEvenementReseau AlarmStart
        {
            get
            {
                return (CSpvEvenementReseau)GetParent(new string[] { c_champALARM_IDDEB }, typeof(CSpvEvenementReseau));
            }
            set
            {
                SetParent(new string[] { c_champALARM_IDDEB }, value);
            }
        }

        //relation vers enfants
        [RelationFille(typeof(CSpvEvenementReseau), "EvenementDebut")]
        [DynamicChilds("Alarm End", typeof(CSpvEvenementReseau))]
        public CListeObjetsDonnees AlarmEnd
        {
            get
            {
                return GetDependancesListe(CSpvEvenementReseau.c_nomTable, CSpvEvenementReseau.c_champALARM_IDDEB);
            }
        }*/

        //relation vers enfants
        [RelationFille(typeof(CSpvLienAccesAlarme_Rep), "EvenementReseau")]
        [DynamicChilds("Acces_Accesc_Rep", typeof(CSpvLienAccesAlarme_Rep))]
        public CListeObjetsDonnees Acces_Accesc_Rep
        {
            get
            {
                return GetDependancesListe(CSpvLienAccesAlarme_Rep.c_nomTable, CSpvLienAccesAlarme_Rep.c_champALARM_ID);
            }
        }

        public CSpvLienAccesAlarme_Rep GetFirstAccesAccescRep()
        {
            return (CSpvLienAccesAlarme_Rep)Acces_Accesc_Rep[0];
        }

        //relation vers enfants
        /*
        [RelationFille(typeof(CSpvAlarmeDonneeCorrelation), "MaskedAlarm")]
        public CListeObjetsDonnees Alarm_Alarmc
        {
            get
            {
                return GetDependancesListe(CSpvAlarmeDonneeCorrelation.c_nomTable, CSpvAlarmeDonneeCorrelation.c_champALARM_ID);
            }
        }*/

    }
}
