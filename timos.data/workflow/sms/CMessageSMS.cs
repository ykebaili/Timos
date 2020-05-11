using System;
using System.Collections;

using sc2i.data;
using sc2i.common;
using timos.acteurs;
using sc2i.multitiers.client;
using timos.securite;

namespace sc2i.workflow
{
	/// <summary>
	/// Cette entit� permet l'envoi de messages SMS � partir d'un mobile connect� � un port s�rie<br/>
    /// du serveur TIMOS.
	/// </summary>
	[DynamicClass("Sms message")]
	[ObjetServeurURI("CMessageSMSServeur")]
	[Table(CMessageSMS.c_nomTable, CMessageSMS.c_champId,true)]
	[RelationToPostit]
	public class CMessageSMS : CObjetDonneeAIdNumeriqueAuto
	{
		#region D�claration des constantes
		public const string c_nomTable = "SMS";
		public const string c_champId = "SMS_ID";
		public const string c_champTexte = "SMS_TEXT";
        public const string c_champDestinataires = "SMS_DEST";
		public const string c_champDateCreation = "SMS_END_DATE";
        public const string c_champNextSendDate = "SMS_NEXT_SEND";
        public const string c_champNbEssais = "SMS_TRY_NUMBER";
        public const string c_champDateEnvoi = "SMS_SEND_DATE";
        public const string c_champLastErreur = "SMS_LAST_ERROR";

		#endregion
		//-------------------------------------------------------------------
		public CMessageSMS( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CMessageSMS( System.Data.DataRow row )
			:base(row)
		{
		}
		//-------------------------------------------------------------------
		protected override void MyInitValeurDefaut()
		{
            DateCreation = DateTime.Now;
            NextSendDate = DateTime.Now;
			try
			{
				CSessionClient session = CSessionClient.GetSessionForIdSession ( ContexteDonnee.IdSession );
				if ( session != null )
				{
                    //TESTDBKEYOK
					CDbKey keyUser = session.GetInfoUtilisateur().KeyUtilisateur;
					CDonneesActeurUtilisateur user = new CDonneesActeurUtilisateur ( ContexteDonnee );
					if ( user.ReadIfExists ( keyUser ) )
						Auteur = user;
				}
			}
			catch
			{}
            NbEssais = 0;
		}
		//-------------------------------------------------------------------
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champDateCreation};
		}
		//-------------------------------------------------------------------
		public override string DescriptionElement
		{
			get
			{
				return I.T("SMS message @1|20106",Texte.ToString());
			}
		}
		
		
		//-------------------------------------------------------------------
        /// <summary>
        /// Texte du message SMS
        /// </summary>
		[
		TableFieldProperty(c_champTexte, 960),
		DynamicField("Text")
		]
		public string Texte
		{
			get
			{
				return (string)Row[c_champTexte];
			}
			set
			{
				Row[c_champTexte] = value;
			}
		}


        //-----------------------------------------------------------
        /// <summary>
        /// Cha�ne de caract�res donnant la liste des num�ros de mobile des destinataires.
        /// Chaque num�ro est s�par� du pr�c�dent par le caract�re ";"
        /// </summary>
        [TableFieldProperty(c_champDestinataires,1000)]
        [DynamicField("Destination number")]
        public string DestinatairesString
        {
            get
            {
                return (string)Row[c_champDestinataires];
            }
            set
            {
                Row[c_champDestinataires] = value;
            }
        }

        //-----------------------------------------------------------
        public string[] Destinataires
        {
            get
            {
                return DestinatairesString.Split(';');
            }
        }

        //-----------------------------------------------------------
        public void AddDestinataire(string strDest)
        {
            DestinatairesString += ";" + strDest;
        }


		//-------------------------------------------------------------------
        /// <summary>
        /// Date de cr�ation du message
        /// </summary>
		[TableFieldProperty(c_champDateCreation)]
		[DynamicField("Creation date")]
		public DateTime DateCreation
		{
			get
			{
				return ( DateTime )Row[c_champDateCreation];
			}
			set
			{
                Row[c_champDateCreation] = value;
			}
		}

        //-------------------------------------------------------------------
        /// <summary>
        /// Date d'exp�dition du message
        /// </summary>
        [TableFieldProperty(c_champDateEnvoi, NullAutorise = true)]
        [DynamicField("Sent date")]
        public DateTime? DateEnvoi
        {
            get
            {
                return (DateTime?)Row[c_champDateEnvoi, true];
            }
            set
            {
                Row[c_champDateEnvoi, true] = value;
            }
        }

		

		//-------------------------------------------------------------------
        /// <summary>
        /// Utilisateur ayant envoy� le message
        /// </summary>
		[Relation(CDonneesActeurUtilisateur.c_nomTable,
			 CDonneesActeurUtilisateur.c_champId,
			 CDonneesActeurUtilisateur.c_champId,
			 true,
			 false,
			 true)]
		[DynamicField("Author")]
		public CDonneesActeurUtilisateur Auteur
		{
			get
			{
				return (CDonneesActeurUtilisateur)GetParent ( CDonneesActeurUtilisateur.c_champId, typeof(CDonneesActeurUtilisateur) );
			}
			set
			{
				SetParent ( CDonneesActeurUtilisateur.c_champId, value );
                
			}
		}


        //-----------------------------------------------------------
        /// <summary>
        /// Nombre de tentatives d'exp�dition ayant eu lieu
        /// </summary>
        [TableFieldProperty(c_champNbEssais)]
        [DynamicField("try number")]
        public int NbEssais
        {
            get
            {
                return (int)Row[c_champNbEssais];
            }
            set
            {
                Row[c_champNbEssais] = value;
            }
        }


        //-----------------------------------------------------------
        /// <summary>
        /// Prochaine date d'exp�dition
        /// </summary>
        [TableFieldProperty(c_champNextSendDate)]
        [DynamicField("Next send date")]
        public DateTime NextSendDate
        {
            get
            {
                return (DateTime)Row[c_champNextSendDate];
            }
            set
            {
                Row[c_champNextSendDate] = value;
            }
        }


        //-----------------------------------------------------------
        /// <summary>
        /// Libell� de la derni�re erreur correspondant
        /// au dernier �chec d'exp�dition
        /// </summary>
        [TableFieldProperty(c_champLastErreur, 1024)]
        [DynamicField("Last error")]
        public string LastErreur
        {
            get
            {
                return (string)Row[c_champLastErreur];
            }
            set
            {
                Row[c_champLastErreur] = value;
            }
        }
	}
}
