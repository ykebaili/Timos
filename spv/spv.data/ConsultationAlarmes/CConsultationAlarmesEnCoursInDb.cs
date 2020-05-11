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
    [DynamicClass("Current alarm connsultation setting")]
	[Table(CConsultationAlarmesEnCoursInDb.c_nomTable,
       CConsultationAlarmesEnCoursInDb.c_nomTableInDb,
        CConsultationAlarmesEnCoursInDb.c_champId, 
        true)]
	[FullTableSync]
    [ObjetServeurURI("CConsultationAlarmesEnCoursInDbServeur")]
	public class CConsultationAlarmesEnCoursInDb : CObjetDonneeAIdNumeriqueAuto,
		IObjetALectureTableComplete
	{
		public const string c_nomTable = "SPV_PARAM_ALRM_EC";
        public const string c_nomTableInDb = "PARAM_ALRMEC";
        public const string c_champId = "PARAM_ALRMEC_ID";
        public const string c_champLibelle = "PARAM_ALRMEC_NOM";
        public const string c_champSoundFile = "PARAM_SOUND_FILE";
        public const string c_champDocGed = "EDMDOC_ID";
        public const string c_champActiverEMail = "ACTIVER_EMAIL";


        public const string c_champDataParametre = "PARAM_ALRMEC_PARAM";

		/// /////////////////////////////////////////////
		public CConsultationAlarmesEnCoursInDb( CContexteDonnee contexte)
			:base(contexte)
		{
		}
		
	/// /////////////////////////////////////////////
		public CConsultationAlarmesEnCoursInDb(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
                return I.T("Current alarms consultation @1|60012", Libelle);
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
            ActiverEMail = false;
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champLibelle};
		}
        		

		/// <summary>
		/// Le libellé du paramètre
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


        [TableFieldProperty(c_champSoundFile, 255, NullAutorise = true)]
        [DynamicField("Sound File")]
        public string SoundFile
        {
            get
            {
                return (string)Row[c_champSoundFile];
            }
            set
            {
                Row[c_champSoundFile] = value;
            }
        }

        ///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champDocGed, NullAutorise = true)]
        [DynamicField("Electronic document ID")]
        public System.Int32 EDMDOC_ID
        {
            get
            {
                return (System.Int32)Row[c_champDocGed];
            }
            set
            {
                Row[c_champDocGed, true] = value;
            }
        }

        //-------------------------------------------------------------------
        [Relation(CDocumentGED.c_nomTable, CDocumentGED.c_champId, CDocumentGED.c_champId, false, true, IsInDb=false)]
        [
        DynamicField("Sound document file")
        ]
        [NonCloneable]
        public CDocumentGED DocumentGEDSoundFile
        {
            get
            {
                return (CDocumentGED)GetParent(CDocumentGED.c_champId, typeof(CDocumentGED));
            }
            set
            {
                if (value != null)
                    value.IsFichierSysteme = true;
                SetParent(CDocumentGED.c_champId, value);
            }
        }

        /// /////////////////////////////////////////////////////////
        [TableFieldProperty(c_champDataParametre, NullAutorise = true)]
        public CDonneeBinaireInRow DonneesSchema
        {
            get
            {
                if (Row[c_champDataParametre] == DBNull.Value)
                {
                    CDonneeBinaireInRow donnee = new CDonneeBinaireInRow(ContexteDonnee.IdSession, Row, c_champDataParametre);
                    CContexteDonnee.ChangeRowSansDetectionModification(Row, c_champDataParametre, donnee);
                }
                object obj = Row[c_champDataParametre];
                return ((CDonneeBinaireInRow)obj).GetSafeForRow(Row.Row);
            }
            set
            {
                Row[c_champDataParametre] = value;
            }
        }

        /// /////////////////////////////////////////////////////////////
        /// <summary>
        /// Le schéma de réseau
        /// </summary>
        public CConsultationAlarmesEnCours Parametres
        {
            get
            {
                CConsultationAlarmesEnCours parametre = null;
                if (DonneesSchema.Donnees != null)
                {
                    MemoryStream stream = new MemoryStream(DonneesSchema.Donnees);
                    BinaryReader reader = new BinaryReader(stream);
                    CSerializerReadBinaire serializer = new CSerializerReadBinaire(reader);
                    CResultAErreur result = serializer.TraiteObject<CConsultationAlarmesEnCours>(ref parametre);
                    if (!result)
                    {
                        parametre = null;
                    }
                }
                if (parametre == null)
                    parametre = new CConsultationAlarmesEnCours();

                return parametre;
            }
            set
            {
                if (value == null)
                {
                    CDonneeBinaireInRow data = DonneesSchema;
                    data.Donnees = null;
                    DonneesSchema = data;
                }
                else
                {
                    MemoryStream stream = new MemoryStream();
                    BinaryWriter writer = new BinaryWriter(stream);
                    CSerializerSaveBinaire serializer = new CSerializerSaveBinaire(writer);
                    CResultAErreur result = serializer.TraiteObject<CConsultationAlarmesEnCours>(ref value);
                    if (result)
                    {
                        CDonneeBinaireInRow data = DonneesSchema;
                        data.Donnees = stream.GetBuffer();
                        DonneesSchema = data;
                    }
                }
            }
        }//Parametres  

        ///////////////////////////////////////////////////////////////
        [RelationFille(typeof(CParamlArmEC_EMail), "ConsultationAlarmesEnCours")]
        [DynamicChilds("Emails", typeof(CParamlArmEC_EMail))]
        public CListeObjetsDonnees Emails
        {
            get
            {
                return GetDependancesListe(CParamlArmEC_EMail.c_nomTable, CParamlArmEC_EMail.c_champParamAlarmECId);
            }
        }
        
        [TableFieldProperty(c_champActiverEMail)]
        [DynamicField("Activate Mailing List")]
        public bool ActiverEMail
        {
            get
            {
                return (bool)Row[c_champActiverEMail];
            }
            set
            {
                Row[c_champActiverEMail] = value;
            }
        }

	}
}
