using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using System.IO;
using spv.data.ConsultationAlarmes;
using System.Collections.Generic;
using sc2i.expression;
using sc2i.documents;

namespace spv.data
{
	/// <summary>
	/// PAramétrage de la vue des alarmes en cours
	/// </summary>
    [DynamicClass("Current alarm E-mail  setting")]
    [Table(CParamlArmEC_EMail.c_nomTable,
      CParamlArmEC_EMail.c_nomTableInDb,
       CParamlArmEC_EMail.c_champId, 
        true)]
	[FullTableSync]
    [ObjetServeurURI("CParamlArmEC_EMailServeur")]
	public class CParamlArmEC_EMail : CObjetDonneeAIdNumeriqueAuto,
        IObjetALectureTableComplete, IObjetSansVersion
	{
		public const string c_nomTable = "SPV_PARAMALRMEC_EMAIL";
        public const string c_nomTableInDb = "PARAMALRMEC_EMAIL";
        public const string c_champId = "PARAMALRMEC_EMAIL_ID";
        public const string c_champParamAlarmECId = "PARAM_ALRMEC_ID";
        public const string c_champEMail = "PARAM_ALRMEC_EMAIL";

		/// /////////////////////////////////////////////
		public CParamlArmEC_EMail( CContexteDonnee contexte)
			:base(contexte)
		{
		}
		
	/// /////////////////////////////////////////////
        public CParamlArmEC_EMail(DataRow row)
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
                return I.T("Current alarms consultation @1 mailing list|60013", ConsultationAlarmesEnCours.Libelle);
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
            
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
            return new string[] { c_champParamAlarmECId };
		}

        ///////////////////////////////////////////////////////////////
        //relation vers parent
        ///////////////////////////////////////////////////////////////
        [Relation(CConsultationAlarmesEnCoursInDb.c_nomTable, new string[] { CConsultationAlarmesEnCoursInDb.c_champId }, new string[] { CParamlArmEC_EMail.c_champParamAlarmECId }, false, true)]
        [DynamicField("ConsultationAlarmesEnCours")]
        public CConsultationAlarmesEnCoursInDb ConsultationAlarmesEnCours
        {
            get
            {
                return (CConsultationAlarmesEnCoursInDb)GetParent(new string[] { c_champParamAlarmECId }, typeof(CConsultationAlarmesEnCoursInDb));
            }
            set
            {
                SetParent(new string[] { c_champParamAlarmECId }, value);
            }
        }
		
        [TableFieldProperty(c_champEMail, 100)]
        [DynamicField("E-mail address")]
        public string Email
        {
            get
            {
                return (string)Row[c_champEMail];
            }
            set
            {
                Row[c_champEMail] = value;
            }
        }
	}
}
