using System;
using System.Data;
using sc2i.data;
using sc2i.common;
using spv.data.ConsultationAlarmes;

namespace spv.data
{
	[Table(CSpvMessalrm.c_nomTable,CSpvMessalrm.c_nomTableInDb,new string[]{ CSpvMessalrm.c_champMESSALRM_ID})]
	[ObjetServeurURI("CSpvMessalrmServeur")]
	[DynamicClass("Spv Alarm Message")]
	public class	CSpvMessalrm : CObjetDonneeAIdNumeriqueAuto, IObjetSansVersion
	{
		public const string c_nomTable = "SPV_MESSALRM";
		public const string c_nomTableInDb = "MESSALRM";
		public const string c_champMESSALRM_ID ="MESSALRM_ID";
		public const string c_champMESSALRM_MESS ="MESSALRM_MESS";
		public const string c_champMESSALRM_SENT ="MESSALRM_SENT";
		public const string c_champMESSALRM_NATURE ="MESSALRM_NATURE";

		// Cette chaîne de caractère présente dans le message est
		// à remplacer par l'ID du message dans l'objet serveur
		// juste avant l'enregistrement
		public const string c_CompleterMessId = "MessIdARemplacer";
        public const int c_nIdObjetInconnu = 999;

        private const string m_separator = "#";
		
		///////////////////////////////////////////////////////////////
		public CSpvMessalrm( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public CSpvMessalrm( DataRow row )
			:base(row)
		{
		}
		
		///////////////////////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
			Nature = 0;
			Sent = false;
		}
		
		///////////////////////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[] {c_champMESSALRM_ID};
		}
		
		///////////////////////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
                return I.T("Alarm message @1|30031", Id.ToString());
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champMESSALRM_MESS,1800)]
		[DynamicField("Message")]
        public System.String MessalrmMessage
		{
			get
			{
				return (System.String)Row[c_champMESSALRM_MESS];
			}
			set
			{
				Row[c_champMESSALRM_MESS,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champMESSALRM_SENT)]
		[DynamicField("Sent")]
        public System.Boolean Sent
		{
			get
			{
				if (Row[c_champMESSALRM_SENT] == DBNull.Value)
					return false;
                return (System.Boolean)Row[c_champMESSALRM_SENT];
			}
			set
			{
				Row[c_champMESSALRM_SENT,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champMESSALRM_NATURE)]
		[DynamicField("Nature")]
        public System.Int32? Nature
		{
			get
			{
				if (Row[c_champMESSALRM_NATURE] == DBNull.Value)
					return null;
				return (System.Int32?)Row[c_champMESSALRM_NATURE];
			}
			set
			{
				Row[c_champMESSALRM_NATURE,true]=value;
			}
		}


		///////////////////////////////////////////////////////////////
		public void MessageCreationPourSaturneIS
		(
			string strCommentairePourSituerEquipement,
			Int32? nEquipFreqE
		)
		{
                        MessalrmMessage = "6#"		// Code du message
										+ "8#"		// Nb. de #
										+ "0#"		// Alarm_Id
										+ CSpvMessalrm.c_CompleterMessId
										+ "#"
    									+ "0#"		// Alarmgeree_Id
    									+ "0#"		// BindingId
   										+ "0#"		// BindingTyp
										+ "D"
										+ (strCommentairePourSituerEquipement.Length>3?strCommentairePourSituerEquipement.Substring(0,3):strCommentairePourSituerEquipement)
										+ "/"
										+ ((nEquipFreqE == null) ? "" : nEquipFreqE.ToString())
										+ "/#";
			// c_CompleterMessId est remplacé dans le BeforeSave de la classe serveur
		}

        public void MessageModifTempoPourSaturneIS
        (
            string strCommentairePourSituerEquipement,
            string strNomAcces
        )
        {
            string strPremierBit = "", strDernierBit = "";  // Vestiges des alarmes SEM

            MessalrmMessage = "6#"			// Code du message
				            + "8#"          // Nb. de #
				            + "0#"          // Alarm_Id
    				        + CSpvMessalrm.c_CompleterMessId
				            + "#"
	    			        + "0#"          // Alarmgeree_Id
			    	        + "0#"          // BindingId
   				            + "0#"          // BindingTyp
				            + "4"
                            + strCommentairePourSituerEquipement + "/"
					        + strNomAcces + "/" 
					        + strPremierBit + "/"
					        + strDernierBit
                            + "#";
            // c_CompleterMessId est remplacé dans le BeforeSave de la classe serveur
        }


        public void MessageModifTempoPourSaturneIS
        (
            int nAlarmGereeId
        )
        {
            string strPremierBit = "", strDernierBit = "";  // Vestiges des alarmes SEM

            MessalrmMessage = "6#"			// Code du message
                            + "8#"          // Nb. de #
                            + "0#"          // Alarm_Id
                            + CSpvMessalrm.c_CompleterMessId
                            + "#"
                            + "0#"          // Alarmgeree_Id
                            + "0#"          // BindingId
                            + "0#"          // BindingTyp
                            + "9G"
                            + nAlarmGereeId.ToString() + "/#";

            // c_CompleterMessId est remplacé dans le BeforeSave de la classe serveur
        }


        public void MessageAcquittementGlobalListeAlarme
        (
            int nListeAlarmeId
        )
        {
            MessalrmMessage =
                string.Format("5#7#0#{0}#0#{1}#0#", CSpvMessalrm.c_CompleterMessId, nListeAlarmeId);

            // c_CompleterMessId est remplacé dans le BeforeSave de la classe serveur
        }

        public void MessageAcquittementAlarmeIndividuelle(int nIdEvtAlarme)
        {
            MessalrmMessage =
                string.Format("5#7#{0}#{1}#0#0#0#", nIdEvtAlarme, CSpvMessalrm.c_CompleterMessId);
            Nature = 0;
            Sent = false;
        }



        public void MessageMasquageAlarme
            (string AlarmCl, int AlarmNumObj, string AlarmNumal, int AlarmGrave,
             int SiteId, int EquipId, int LiaiId, string TsPrOper
            )
        {
            int nIdObjet;
            ETypeObjetEnAlarme typeObjet;
            if (SiteId > 0)
            {
                nIdObjet = SiteId;
                typeObjet = ETypeObjetEnAlarme.Site;
            }
            else if (EquipId > 0)
            {
                nIdObjet = EquipId;
                typeObjet = ETypeObjetEnAlarme.Equipement;
            }
            else if (LiaiId > 0)
            {
                nIdObjet = LiaiId;
                typeObjet = ETypeObjetEnAlarme.Liaison;
            }
            else
            {
                typeObjet = ETypeObjetEnAlarme.Inconnu;
                nIdObjet = c_nIdObjetInconnu;
            }

            MessalrmMessage = string.Format(
                "7#18#0#{0}#0#{1}#{2}#0# #{3}#{4}#0# #{5}# #0#{6}#{7}#",
                CSpvMessalrm.c_CompleterMessId, nIdObjet, typeObjet, AlarmCl,
                AlarmNumObj, AlarmGrave, AlarmNumal, TsPrOper);
        }



        ///////////////////////////////////////////////////////////////       
        public CEvenementAlarm GetNewEvenementAlarm()
        {
            /*
            CEvenementAlarm eventAl = new CEvenementAlarm(MessalrmMessage, m_separator);
            return eventAl;           
            */
            CMessageAlarmeNotification messageAlarmeNotification
                = new CMessageAlarmeNotification(MessalrmMessage);

            if (messageAlarmeNotification.MessagePourEm)
                return null;

            switch (messageAlarmeNotification.CodeMessage)
            {
                case ECategorieMessageAlarme.AlarmStartStop:
                    return new CEvenementAlarmStartStop(messageAlarmeNotification);
                case ECategorieMessageAlarme.AcquittementListeAlarme:
                    return new CEvenementAlarmAcknowledge(messageAlarmeNotification);
                case ECategorieMessageAlarme.AlarmMasqueeParUneAutre:
                    return new CEvenementAlarmMasqueeParUneAutre(messageAlarmeNotification); ;
                case ECategorieMessageAlarme.MasquageAccesAlarme:
                    return new CEvenementAlarmMask(messageAlarmeNotification);
                default:
                    return null;
            }
            
        }

        /*public CEvenementAlarmStop GetNewEvenementAlarmStop()
        {
            CEvenementAlarm eventAl = new CEvenementAlarm(MessalrmMessage, m_separator);
            return eventAl.GetEventAlarmStop(); 
        }

        public CEvenementAlarmMask GetNewEvenementAlarmMask()
        {
            CEvenementAlarm eventAl = new CEvenementAlarm(MessalrmMessage, m_separator);
            return eventAl.GetEventAlarmMask(); 
        }

        public CEvenementAlarmAcknowledge GetNewEvenementAlarmAcknowledge()
        {
            CEvenementAlarm eventAl = new CEvenementAlarm(MessalrmMessage, m_separator);
            return eventAl.GetEventAlarmAcknowledge(); 
        }*/
        
	}
}
