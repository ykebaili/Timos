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
	/// Cette entité permet l'envoi de messages SMS à partir d'un mobile connecté à un port série<br/>
    /// du serveur TIMOS.
	/// </summary>
	[DynamicClass("Sms message")]
	[ObjetServeurURI("CMessageSMSServeur")]
	[Table(CMessageSMS.c_nomTable, CMessageSMS.c_champId,true)]
	[RelationToPostit]
	public class CMessageSMS : CObjetDonneeAIdNumeriqueAuto
	{
		#region Déclaration des constantes
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
        /// Chaîne de caractères donnant la liste des numéros de mobile des destinataires.
        /// Chaque numéro est séparé du précédent par le caractère ";"
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
        /// Date de création du message
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
        /// Date d'expédition du message
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
        /// Utilisateur ayant envoyé le message
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
        /// Nombre de tentatives d'expédition ayant eu lieu
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
        /// Prochaine date d'expédition
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
        /// Libellé de la dernière erreur correspondant
        /// au dernier échec d'expédition
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
