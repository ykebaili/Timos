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
	[Table(CSpvAlarmeDonnee.c_nomTable,CSpvAlarmeDonnee.c_nomTableInDb,new string[]{ CSpvAlarmeDonnee.c_champALARMEDONNEE_ID})]
    [ObjetServeurURI("CSpvAlarmeDonneeServeur")]
	[DynamicClass("AlarmData")]
    [NoTriggerAutoIncrement(CSpvAlarmeDonnee.c_champALARMEDONNEE_ID)]
	public class	CSpvAlarmeDonnee : CObjetDonneeAIdNumeriqueAuto, IObjetSansVersion
	{
		public const string c_nomTable = "SPV_ALARME";
		public const string c_nomTableInDb = "ALARMDATA";
		//public const string c_champALARM_IDDEB ="ALARM_IDDEB";
        //public const string c_champALARM_IDFIN = "ALARM_IDFIN";
        public const string c_champALARMEDONNEE_ID = "ALARMDATA_ID";
		public const string c_champSITE_ID ="SITE_ID";
		public const string c_champEQUIP_ID ="EQUIP_ID";
		public const string c_champLIAI_ID ="LIAI_ID";
        public const string c_champACCES_ACCESC_ID = "ACCES_ACCESC_ID";
        public const string c_champALARMGEREE_ID ="ALARMGEREE_ID";
		public const string c_champALARMGEREE_NOM ="ALARMGEREE_NOM";
        public const string c_champALARMGEREE_GRAVE ="ALARMGEREE_GRAVE";
		public const string c_champALARMGEREE_LOCAL ="ALARMGEREE_LOCAL";
		public const string c_champALARMGEREE_NSEUIL ="ALARMGEREE_NSEUIL";
        public const string c_champALARMGEREE_TYPE = "ALARMGEREE_TYPAL";
		public const string c_champALARMEDONNEE_DATEDEBUT ="ALARMDATA_DATEDEBUT";
        public const string c_champALARMEDONNEE_DATEFIN ="ALARMDATA_DATEFIN";
		public const string c_champALARMEDONNEE_SECDEBUT ="ALARMDATA_SECDEBUT";
        public const string c_champALARMEDONNEE_SECFIN ="ALARMDATA_SECFIN";
		public const string c_champALARMEDONNEE_VSEUIL ="ALARMDATA_VSEUIL";
		public const string c_champALARMEDONNEE_IANA ="ALARMDATA_IANA";
        public const string c_champALARMEDONNEE_ACK = "ALARMDATA_ACK";
        public const string c_champALARMEDONNEE_ACKWHO = "ALARMDATA_ACKWHO";
        public const string c_champALARMEDONNEE_ACKWHEN = "ALARMDATA_ACKWHEN";
        public const string c_champALARMEDONNEE_MASK_OPE = "ALARMDATA_MASK_OPE";
        public const string c_champALARMEDONNEE_MASK_ADM = "ALARMDATA_MASK_ADM";
        public const string c_champALARMEDONNEE_COMMENT = "ALARMDATA_COMMENT";

        public const string c_sequenceAssociee = "SEQ_ALARMDATA";


		///////////////////////////////////////////////////////////////
		public CSpvAlarmeDonnee( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public CSpvAlarmeDonnee( DataRow row )
			:base(row)
		{
		}
		
		///////////////////////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
			//TODO : Insérer ici le code d'initalisation
            Row[c_champALARMEDONNEE_ACK] = false;
            Row[c_champALARMEDONNEE_MASK_OPE] = false;
            Row[c_champALARMEDONNEE_MASK_ADM] = false;
            Row[c_champALARMGEREE_LOCAL] = true;
		}
		
		///////////////////////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
            return new string[] { c_champALARMEDONNEE_ID };
		}
		
		///////////////////////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
                return I.T("Alarm data : @1|50013", NomAlarmeGeree);
			}
		}


        ///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champSITE_ID, NullAutorise=true)]
        [DynamicField("Site Id")]
        public System.Int32? SiteId
        {
            get
            {
                if (Row[c_champSITE_ID] == DBNull.Value)
                    return null;
                return (System.Int32?)Row[c_champSITE_ID];
            }
        }

        ///////////////////////////////////////////////////////////////
        // Pas de relation car des valeurs site_id peuvent exister
        // alors que le site est effacé.
        [DynamicField("Spv Site")]
        public CSpvSite SpvSite
        {
            get
            {
                if (SiteId == null)
                    return null;

                CSpvSite spvSite = new CSpvSite(this.ContexteDonnee);
                if (spvSite.ReadIfExists((Int32)SiteId))
                    return spvSite;

                return null;
            }
        }


        ///////////////////////////////////////////////////////////////
        // Pas de relation car des valeurs equip_id peuvent exister
        // alors que l'équipement est effacé.
        [DynamicField("Logical Equipment")]
        public CSpvEquip SpvEquip
        {
            get
            {
                if (EquipId == null)
                    return null;

                CSpvEquip spvEquip = new CSpvEquip(this.ContexteDonnee);
                if (spvEquip.ReadIfExists((Int32)EquipId))
                    return spvEquip;

                return null;
            }
        }


        ///////////////////////////////////////////////////////////////
        // Pas de relation car des valeurs liai_id peuvent exister
        // alors que la liaison est effacée.
        [DynamicField("Spv Link")]
        public CSpvLiai SpvLiai
        {
            get
            {
                if (LiaiId == null)
                    return null;

                CSpvLiai spvLiai = new CSpvLiai(this.ContexteDonnee);
                if (spvLiai.ReadIfExists((Int32)LiaiId))
                    return spvLiai;

                return null;
            }
        }



        ///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champEQUIP_ID, NullAutorise = true)]
        [DynamicField("Equipment Id")]
        public System.Int32? EquipId
        {
            get
            {
                if (Row[c_champEQUIP_ID] == DBNull.Value)
                    return null;
                return (System.Int32?)Row[c_champEQUIP_ID];
            }
        }

        ///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champLIAI_ID, NullAutorise = true)]
        [DynamicField("Link Id")]
        public System.Int32? LiaiId
        {
            get
            {
                if (Row[c_champLIAI_ID] == DBNull.Value)
                    return null;
                return (System.Int32?)Row[c_champLIAI_ID];
            }
        }

        
		///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champALARMGEREE_NOM, 40, NullAutorise = false)]
		[DynamicField("Alarm Name")]
		public System.String NomAlarmeGeree
		{
			get
			{
				if (Row[c_champALARMGEREE_NOM] == DBNull.Value)
					return null;
				return (System.String)Row[c_champALARMGEREE_NOM];
			}	
		}
		
		
		///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champALARMEDONNEE_DATEDEBUT, NullAutorise = false)]
        [DynamicField("Starting date")]
		public DateTime DateDebut
		{
			get
			{
                return (System.DateTime)Row[c_champALARMEDONNEE_DATEDEBUT];
			}
            set
            {
                Row[c_champALARMEDONNEE_DATEDEBUT, true] = value;
            }
		}

        ///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champALARMEDONNEE_DATEFIN, NullAutorise = true)]
        [DynamicField("Ending date")]
        public DateTime? DateFin
        {
            get
            {
                return (System.DateTime?)Row[c_champALARMEDONNEE_DATEFIN, true];
            }
            set
            {
                Row[c_champALARMEDONNEE_DATEFIN, true] = value;
            }
        }

        [DynamicField("Duration")]
        public TimeSpan? Duree
        {
            get
            {
                if (DateFin != null)
                    return (DateTime)DateFin - DateDebut;
                else
                    return null;
            }
        }


        ///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champALARMGEREE_TYPE, NullAutorise = false)]
        [DynamicField("Event type code")]
        public System.Int32? CodeEvenementX733
        {
            get
            {
                if (Row[c_champALARMGEREE_TYPE] == DBNull.Value)
                    return null;
                return (System.Int32?)Row[c_champALARMGEREE_TYPE];
            }
        }


        ///////////////////////////////////////////////////////////////
        [DynamicField("Event type")]
        public CAlarmEvent EvenementX733
        {
            get
            {
                if (CodeEvenementX733 == null)
                    return null;

                if (Enum.IsDefined(typeof(EAlarmEvent), CodeEvenementX733))
                {
                    try
                    {
                        return new CAlarmEvent((EAlarmEvent)CodeEvenementX733);
                    }
                    catch
                    {
                    }
                }
                return null;
            }
        }
		
		
		///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champALARMGEREE_GRAVE, NullAutorise = false)]
		[DynamicField("Alarm Severity code")]
		public System.Int32 CodeGravite
		{
			get
			{
                return (System.Int32)Row[c_champALARMGEREE_GRAVE];
			}
            set
            {
                Row[c_champALARMGEREE_GRAVE, true] = value;
            }
		}

         ///////////////////////////////////////////////////////////////
        [DynamicField("Alarm severity")]
        public CGraviteAlarme AlarmGrave
        {
            get
            {
                if (Enum.IsDefined(typeof(EGraviteAlarme), CodeGravite))
                {
                    try
                    {
                        return new CGraviteAlarme((EGraviteAlarme)CodeGravite);
                    }
                    catch
                    {
                    }
                }
                return null;
            }
        }
		
		
		///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champALARMGEREE_LOCAL, NullAutorise = false)]
       	[DynamicField("Local Alarm")]
        public System.Boolean AlarmeLocale
		{
			get
			{
                return (System.Boolean)Row[c_champALARMGEREE_LOCAL];
			}
            set
            {
                Row[c_champALARMGEREE_LOCAL, true] = value;
            }
		}
		
		///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champALARMGEREE_NSEUIL, 40, NullAutorise = true)]
        [DynamicField("Threshold Name")]
		public System.String NomSeuilAlarme
		{
			get
			{
                if (Row[c_champALARMGEREE_NSEUIL] == DBNull.Value)
					return null;
                return (System.String)Row[c_champALARMGEREE_NSEUIL];
			}
			
		}
		
		///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champALARMEDONNEE_VSEUIL, NullAutorise = true)]
        [DynamicField("Threshold value")]
        public System.Int32? ValeurSeuilAlarme
		{
			get
			{
                if (Row[c_champALARMEDONNEE_VSEUIL] == DBNull.Value)
					return null;
                return (System.Int32?)Row[c_champALARMEDONNEE_VSEUIL];
			}
		}
		
		
		///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champALARMEDONNEE_COMMENT, 256, NullAutorise = true)]
		[DynamicField("Comment")]
		public System.String Commententaire
		{
			get
			{
				if (Row[c_champALARMEDONNEE_COMMENT] == DBNull.Value)
					return null;
				return (System.String)Row[c_champALARMEDONNEE_COMMENT];
			}
            set
            {
                Row[c_champALARMEDONNEE_COMMENT, true] = value;
            }
		}
		
		
		///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champALARMEDONNEE_IANA, NullAutorise = true)]
		[DynamicField("IANA number")]
		public System.Int32? NumeroIANA
		{
			get
			{
				if (Row[c_champALARMEDONNEE_IANA] == DBNull.Value)
					return null;
                return (System.Int32?)Row[c_champALARMEDONNEE_IANA];
			}
            set
            {
                Row[c_champALARMEDONNEE_IANA, true] = value;
            }
		}

        
		///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champALARMEDONNEE_ACK, NullAutorise = false)]
        [DynamicField("Alarm acknowledgement")]
		public System.Boolean Acquittee
		{
			get
			{
                return (System.Boolean)Row[c_champALARMEDONNEE_ACK];
			}
			set
            {
                Row[c_champALARMEDONNEE_ACK] = value;
            }

		}
		
		///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champALARMEDONNEE_ACKWHO, 40, NullAutorise = true)]
        [DynamicField("Acknowledged by")]
		public System.String AcquitteePar
		{
			get
			{
                if (Row[c_champALARMEDONNEE_ACKWHO] == DBNull.Value)
					return null;
                return (System.String)Row[c_champALARMEDONNEE_ACKWHO];
			}
            set
            {
                Row[c_champALARMEDONNEE_ACKWHO] = value;
            }
		}
		
		///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champALARMEDONNEE_ACKWHEN, NullAutorise = true)]
        [DynamicField("Acknowledged at")]
        public System.DateTime? AcquitteeDate
		{
			get
			{
                if (Row[c_champALARMEDONNEE_ACKWHEN] == DBNull.Value)
					return null;
                return (System.DateTime?)Row[c_champALARMEDONNEE_ACKWHEN];
			}
            set
            {
                Row[c_champALARMEDONNEE_ACKWHEN] = value;
            }
		}

        ///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champALARMEDONNEE_MASK_OPE, NullAutorise = false)]
        [DynamicField("Operator masking")]
        public System.Boolean MasqueeOperateur
        {
            get
            {
                return (System.Boolean)Row[c_champALARMEDONNEE_MASK_OPE];
            }
            set
            {
                Row[c_champALARMEDONNEE_MASK_OPE] = value;
            }

        }

        ///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champALARMEDONNEE_MASK_ADM, NullAutorise = false)]
        [DynamicField("Administrator masking")]
        public System.Boolean MasqueeAdministrateur
        {
            get
            {
                return (System.Boolean)Row[c_champALARMEDONNEE_MASK_ADM];
            }
            set
            {
                Row[c_champALARMEDONNEE_MASK_ADM] = value;
            }

        }

        /*
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
                    AcquittementDateString = date.ToString();                    
                }
            }
        }
		*/



        [TableFieldProperty(c_champALARMEDONNEE_SECDEBUT, NullAutorise = false)]
        public System.Int32 DateDebutEnSecondes
        {
            get
            {
                return (System.Int32)Row[c_champALARMEDONNEE_SECDEBUT];
            }
        }


        [TableFieldProperty(c_champALARMEDONNEE_SECFIN, NullAutorise = true)]
        public System.Int32? DateFinEnSecondes
        {
            get
            {
                if (Row[c_champALARMEDONNEE_SECFIN] == DBNull.Value)
                    return null;
                else
                    return (System.Int32?)Row[c_champALARMEDONNEE_SECFIN];
            }
        }

        /*
        [DynamicField("Starting alarm date")]
        public DateTime? AlarmDebutDate
        {
            get
            {
                if (AlarmDebSec==null)
                    return null;
                else
                {
                    CDivers div = new CDivers();
                    return div.FromSecToDate((System.Double?)AlarmDebSec);
                } 
            }
        }
		*/


        ///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champACCES_ACCESC_ID, NullAutorise = true)]
        [DynamicField("Acces wiring Id")]
        public System.Int32? LienAccesAlarmeId
        {
            get
            {
                if (Row[c_champACCES_ACCESC_ID] == DBNull.Value)
                    return null;
                return (System.Int32?)Row[c_champACCES_ACCESC_ID];
            }

        }


        [DynamicField("All program's operating state")]
        public List<CInfoEtatService> EtatsServices
        {
            get
            {
                return EvenementDebut.EtatsServices;
            }
        }


        [DynamicField("Concerned clients")]
        public System.Int32[] ClientsConcernes
        {
            get
            {
                return EvenementDebut.ClientsConcernes;
            }
        }

        [DynamicField("Concerned programs")]
        public System.Int32[] ServicesConcernes
        {
            get
            {
                return EvenementDebut.ServicesConcernes;
            }
        }

        [DynamicField("Program's operating state")]
        public double[] ProgsOper
        {
            get
            {
                return EvenementDebut.ProgsOper;
            }
        }

        [DynamicField("Managed object site name")]
        public System.String SiteNom
        {
            get
            {
                return EvenementDebut.ElementGereNomSite;
            }
        }

        [DynamicField("Managed object Id")]
        public System.Int32? ElementGereId
        {
            get
            {
                return EvenementDebut.ElementGereId;
            }
        }

        [DynamicField("Network element name")]
        public string ElementGereNom
        {
            get
            {
                return EvenementDebut.ElementGereNom;
            }
        }

        [DynamicField("Managed object site Id")]
        public int? ElementGereIdSite
        {
            get
            {
                return EvenementDebut.ElementGereIdSite;
            }
        }

        [DynamicField("Managed object type Id")]
        public System.Int32? ElementGereIdType
        {
            get
            {
                return EvenementDebut.ElementGereeIdType;
            }
        }

        [DynamicField("Network element type name")]
        public string ElementGereNomType
        {
            get
            {
                return EvenementDebut.ElementGereNomType;
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


        public CSpvLienAccesAlarme SpvLienAccesAlarme
        {
            get
            {
                CSpvLienAccesAlarme lienAccesAlarme = new CSpvLienAccesAlarme(ContexteDonnee);
                if (LienAccesAlarmeId > 0 && lienAccesAlarme.ReadIfExists((int)LienAccesAlarmeId))
                    return lienAccesAlarme;
                
                return null;
            }
        }

        public string GetBindingVarInfo()
        {
            if (EvenementDebut.AlarmCategory.ToUpper().Contains("TRAP"))
            {
                string stSQL;
                stSQL = string.Format("select BindingVarInfo('{0}', {1}, {2}, {3}) from dual",
                    EvenementDebut.AlarmInfo, (int)EquipId, (int)NumeroIANA, EvenementDebut.AlarmNumObj);
                
                CResultAErreur result = CExecuteurRequeteSpv.ExecuteScalar(0, stSQL);
                if (result.Data != null)
                    return result.Data.ToString();
                else
                    return "";
            }

            return "";
        }

        /*
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
        }*/


        //relation vers enfants
        [RelationFille(typeof(CSpvEvenementReseau), "SpvAlarme")]
        [DynamicChilds("Network events", typeof(CSpvEvenementReseau))]
        public CListeObjetsDonnees EvenementsReseau
        {
            get
            {
                return GetDependancesListe(CSpvEvenementReseau.c_nomTable, CSpvEvenementReseau.c_champALARME_ID);
            }
        }

        [DynamicField("Network starting event")]
        public CSpvEvenementReseau EvenementDebut
        {
            get
            {
                foreach (CSpvEvenementReseau evtReseau in EvenementsReseau)
                    if (evtReseau.CodeTypeEvenementReseau == (int)ETypeEvenementReseau.DebutAlarme)
                        return evtReseau;
                return null;
            }
        }


        //relation vers enfants
        [RelationFille(typeof(CSpvAlarmeDonneeCorrelation), "AlarmeMasquee")]
        public CListeObjetsDonnees AlarmeMasquee
        {
            get
            {
                return GetDependancesListe(CSpvAlarmeDonneeCorrelation.c_nomTable, CSpvAlarmeDonneeCorrelation.c_champALARMEDONNEE_ID);
            }
        }


        //relation vers enfants
        [RelationFille(typeof(CSpvAlarmeDonneeCorrelation), "AlarmeMasquante")]
        public CListeObjetsDonnees AlarmeMasquante
        {
            get
            {
                return GetDependancesListe(CSpvAlarmeDonneeCorrelation.c_nomTable, CSpvAlarmeDonneeCorrelation.c_champALARMEDONNEE_BINDINGID);
            }
        }

        //relation vers enfants
        [RelationFille(typeof(CSpvLienAccesAlarme_Rep), "AlarmeDonnee")]
        [DynamicChilds("Alarm data access state", typeof(CSpvLienAccesAlarme_Rep))]
        public CListeObjetsDonnees LienAccesAlarmeRep
        {
            get
            {
                return GetDependancesListe(CSpvLienAccesAlarme_Rep.c_nomTable, CSpvLienAccesAlarme_Rep.c_champALARMEDONNEE_ID);
            }
        }

        public CSpvLienAccesAlarme_Rep GetFirstAccesAccescRep()
        {
            return (CSpvLienAccesAlarme_Rep)LienAccesAlarmeRep[0];
        }



        public CResultAErreur AcquitterNow()
        {
            BeginEdit();
            Acquittee = true;
            AcquitteeDate = CDivers.GetSysdateNotNull();//DateTime.Now;
        
            CSessionClient session = CSessionClient.GetSessionForIdSession(ContexteDonnee.IdSession);
            AcquitteePar = session.GetInfoUtilisateur().NomUtilisateur;
                 
            CSpvMessalrm spvMessalrm = new CSpvMessalrm(ContexteDonnee);
            spvMessalrm.CreateNewInCurrentContexte();
            spvMessalrm.MessageAcquittementAlarmeIndividuelle(this.EvenementDebut.Id);
            return CommitEdit();
        }

        //public static CResultAErreur Retomber(Int32  alarmEventID, CContexteDonnee ctx)
        public static CResultAErreur Retomber(Int32 alarmeID, CContexteDonnee ctx)
        {
            CSpvAlarmeDonnee spvAlarme = new CSpvAlarmeDonnee(ctx);
            if (spvAlarme.ReadIfExists(alarmeID, true))
            {
                CSpvEvenementReseau evtAlarme = new CSpvEvenementReseau(ctx);
                evtAlarme.CreateNew();
                evtAlarme.AlarmComment = "9485";
                //evtAlarme.AlarmIANA = 9485;
                if (spvAlarme.EvenementDebut != null)
                    evtAlarme.AlarmInfo = string.Format(".1.3.6 = {0};", spvAlarme.EvenementDebut.Id);
                evtAlarme.CodeAlarmGrave = (int)EGraviteAlarmeAvecMasquage.Undetermined;
                evtAlarme.AlarmCategory = "TRAPS";
                evtAlarme.AlarmNumObj = 20;
                evtAlarme.SequenceNumber = -1;
                evtAlarme.AlarmDateText = CDivers.GetSysdateNotNull().ToString(CSpvEvenementReseau.c_formatDate);// DateTime.Now.ToString(c_formatDate);
                evtAlarme.SpvAlarmgeree = spvAlarme.EvenementDebut.SpvAlarmgeree;
                evtAlarme.SpvAlarme = spvAlarme;
                evtAlarme.TypeEvenementReseau = new CTypeEvenementReseau(ETypeEvenementReseau.FinAlarme);
                return evtAlarme.CommitEdit();
            }
            else
                throw new Exception(I.T("Alarm not found|50016"));
        }

        public static CListeObjetsDonnees ListCurrentFrequentAlarms(CContexteDonnee ctx)
        {
            CListeObjetsDonnees lstAlarm = new CListeObjetsDonnees(ctx, typeof(CSpvAlarmeDonnee));

            /*SELECT	#l#B.ALARM_ID \
					FROM  ACCES_ACCESC A, ACCES_ACCESC_REP B, ALARM \
					WHERE B.ALARM_ID IS NOT NULL AND  \
						  A.COMMUT = 0 AND \
						  A.ACCES_ACCESC_ID = B.ACCES_ACCESC_ID AND \
						  B.ALARM_ID = ALARM.ALARM_ID AND \
						  ALARM_TEXTE = 2 \
					ORDER BY B.ALARM_SEC*/

            /*
            string clauseWhere = CSpvEvenementReseau.c_champALARM_TEXTE + "=@1 and " +
                "Has (LienAccesAlarmeRep." + CSpvLienAccesAlarme_Rep.c_champACCES_ACCESC_ID + ") and " +
                "LienAccesAlarmeRep.LienAccesAlarmes." + CSpvLienAccesAlarme.c_champCOMMUT + "= 0";*/
            string clauseWhere =
                "EvenementsReseau." + CSpvEvenementReseau.c_champEVENEMENT_TYPE + "=@1 and " +
                "EvenementsReseau." + CSpvEvenementReseau.c_champALARM_TEXTE + "=@2 and " +
                "Has (LienAccesAlarmeRep." + CSpvLienAccesAlarme_Rep.c_champACCES_ACCESC_ID + ") and " +
                "LienAccesAlarmeRep.LienAccesAlarmes." + CSpvLienAccesAlarme.c_champCOMMUT + "=@3";

            lstAlarm.Filtre = new CFiltreDataAvance(CSpvAlarmeDonnee.c_nomTable, clauseWhere,
                                    ETypeEvenementReseau.DebutAlarme,
                                    (int)EAlarmNature.Frequente, EGenreCommutateur.NotCommut);

            return lstAlarm;
        }

	}
}
