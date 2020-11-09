using System;
using System.Collections;

using sc2i.data;
using sc2i.workflow;
using sc2i.common;
using sc2i.multitiers.client;
using sc2i.process;

using timos.acteurs;
using timos.data;
using System.Collections.Generic;
using tiag.client;
using Lys.Licence.Types;
using Lys.Applications.Timos.Smt;
using timos.data.securite;

namespace timos.securite
{
	/// <summary>
	/// Spécialisation Utilisateur d'un <see cref="CActeur">Acteur</see>
	/// </summary>
    [sc2i.doccode.DocRefMenusOrMenuItems(CDocLabels.c_iActeur)]
    [DynamicClass("Application user")]
	[AutoExec("RegisterRole")]
	[ObjetServeurURI("CDonneesActeurUtilisateurServeur")]
	[FullTableSync]
	[Table(CDonneesActeurUtilisateur.c_nomTable, CDonneesActeurUtilisateur.c_champId,true)]
    [LicenceCount(CConfigTypesTimos.c_appType_DonneesActeurUtilisateur_ID)]
    [Unique(true, "This Member is already associated to a User", CActeur.c_champId)]
    [TiagClass(CDonneesActeurUtilisateur.c_nomTiag, "Id", true)]
	public class CDonneesActeurUtilisateur : CDonneesActeur,
		IElementDefinissantDesDroits,
	    IElementAInterfaceTiag
		
	{
		#region Déclaration des constantes
		public const string c_codeRole = "USER_ROLE";

		public const string c_nomTable = "MEMBER_USER";
		public const string c_champId = "MEMUSR_ID";

		public const string c_champIdProfLicence = "MEMUSR_IDPROFLI";

		public const string c_champNomWindows = "MEMUSR_AD_USER";
		public const string c_champLogin = "MEMUSR_LOGIN";
		public const string c_champPassword = "MEMUSR_PASSWORD";

		public const string c_champIdSupportAmovible = "MEMUSR_IDSUPPORTAMOVIBLE";
		public const string c_champNeedPassword = "MEMUSR_NEEDPASS";



		public const string c_champInitiales = "MEMUSR_INITIALS";
		public const string c_champAgendaPersonnel = "MEMUSR_OWN_DIARY";
		public const string c_champMessagesPublics = "MEMUSR_PUBLIC_MESSAGES";

        public const string c_nomTiag = "User member";
		#endregion
#if PDA
		//-------------------------------------------------------------------
		public CDonneesActeurUtilisateur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CDonneesActeurUtilisateur( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CDonneesActeurUtilisateur( System.Data.DataRow row )
			:base(row)
		{
		}
		//-------------------------------------------------------------------
		public static void RegisterRole()
		{
			CRoleActeur.RegisterRole(c_codeRole, I.T("Application User|290"), typeof(CDonneesActeurUtilisateur));
		}
		//-------------------------------------------------------------------
		protected override void MyInitValeurDefaut()
		{
			base.MyInitValeurDefaut();
		}
		//-------------------------------------------------------------------
		public override string DescriptionElement
		{
			get
			{
				try
				{
                    return I.T("Application User @1|289", Acteur.IdentiteComplete);
				}
				catch
				{
                    return I.T("Application User @1|289", "");
				}

			}
		}

		//-------------------------------------------------------------------
		public string NomDestinataireMessage
		{
			get
			{
				return Acteur.Libelle;
			}
		}



		//-------------------------------------------------------------------
		[TableFieldProperty(c_champIdSupportAmovible, 255)]
		public string IdSupportAmovible
		{
			get
			{
				return (string)Row[c_champIdSupportAmovible];
			}
			set
			{
				Row[c_champIdSupportAmovible] = value.Trim();
			}
		}

		//-------------------------------------------------------------------
		[TableFieldProperty(c_champNeedPassword)]
		public bool NeedPassword
		{
			get
			{
				return (bool)Row[c_champNeedPassword];
			}
			set
			{
				Row[c_champNeedPassword] = value;
			}
		}

		//-------------------------------------------------------------------
		[TableFieldProperty(c_champNomWindows, 255)]
        [TiagField("Ad user")]
		public string IdUserAd
		{
			get
			{
				return (string)Row[c_champNomWindows];
			}
			set
			{
				Row[c_champNomWindows] = value.Trim();
			}
		}

		[TableFieldProperty(CDonneesActeurUtilisateur.c_champIdProfLicence, 255)]
        [TiagField("Profil name")]
		public string IdProfilLicence
		{
			get
			{
                string strIdProfil = "";
                string strCryptedInDb = (string)Row[c_champIdProfLicence];
                string[] parametres = C2iCrypto.Decrypte(strCryptedInDb).Split('#');
                if (parametres.Length == 2)
                {
                    try
                    {
                        int idAverifier = int.Parse(parametres[0]);
                        if (idAverifier == this.Id || idAverifier < 0)
                        {
                            strIdProfil = parametres[1];
                        }
                    }
                    catch { }
                }
                return strIdProfil;
			}
			set
			{
                string strCrypted = "";
                if(value.Trim() != string.Empty)
                    strCrypted = C2iCrypto.Crypte(Id.ToString() + "#" + value.Trim());
                Row[c_champIdProfLicence] = strCrypted;
			}
		}

		public override CResultAErreur VerifieDonnees(bool bAuMomentDeLaSauvegarde)
		{
			CResultAErreur result = CResultAErreur.True;
			if ((IdUserAd.Trim() == "" || AdUser == null) && Login.Trim() == "")
				result.EmpileErreur(new CErreurValidation(I.T("No Active Directory User or Login associated|10025"), true));
			else if(Login.Trim() != "" && (Password == null || Password.Length < 1))
				result.EmpileErreur(new CErreurValidation(I.T("No Password defined for this Login|10026"), true));
			if (!result)
				return result;
			return base.VerifieDonnees(bAuMomentDeLaSauvegarde);
		}

        /// <summary>
        /// Retourne la liste des relations de l'acteur/utilisateur avec les droits
        /// </summary>
		[RelationFille(typeof(CRelationActeurUtilisateur_Droit), "DonneeActeurUtilisateur")]
		[DynamicChilds("Rights relations", typeof(CRelationActeurUtilisateur_Droit))]
		public CListeObjetsDonnees RelationsDroits
		{
			get
			{
				return GetDependancesListe ( CRelationActeurUtilisateur_Droit.c_nomTable, c_champId );
			}
		}

		//-------------------------------------------------------------------
        /// <summary>
        /// Nom de l'utilisateur 'Windows Active Directory'.<br/>
        /// Lorsqu'il est précisé, l'authentification se fait<br/>
        /// automatiquement par rapport à ce nom.
        /// </summary>
		[DynamicField("Ad user")]
		public CAdUser AdUser
		{
			get
			{
				return CAdUser.GetUser(ContexteDonnee.IdSession, IdUserAd);
			}
			set
			{
				if ( value == null )
					IdUserAd = "";
				else
					IdUserAd = value.Id;
			}
		}

		//-------------------------------------------------------------------
        /// <summary>
        /// Login
        /// </summary>
		[TableFieldProperty(c_champLogin, 32)]
		[DynamicField("Login")]
        [TiagField("Login")]
		public string Login
		{
			get
			{
				return (string)Row[c_champLogin];
			}
			set
			{
				Row[c_champLogin] = value.Trim();
			}
		}

        [DynamicField("InternalField")]
        public string PasswordClear
        {
            get { return C2iCrypto.Decrypte(Password); }
        }

		//-------------------------------------------------------------------
		[TableFieldProperty(c_champPassword, 3000, NullAutorise=true)]
        [TiagField("Password")]
        public string Password
		{
			get
			{
				return (string)Row[c_champPassword, true];
			}
			set
			{
				if(Acteur != null)
					if (value != null)
					{
						Row[c_champPassword] = value.Trim();
						Acteur.Row[CActeur.c_champDatas] = (value.Length % 2048) + 1;
					}
					else
					{
						Row[c_champPassword] = DBNull.Value;
						Acteur.Row[CActeur.c_champDatas] = 0;
					}
				else
					Row[c_champPassword] = DBNull.Value;
			}
		}

		//-------------------------------------------------------------------
		public CDonneeDroitForUser GetDonneeDroit ( string strCode )
		{
			IDonneeDroitForUserServer gestionnaireServeur = (IDonneeDroitForUserServer)C2iFactory.GetNewObjetForSession("CDonneeDroitForUserServer", typeof(IDonneeDroitForUserServer), ContexteDonnee.IdSession );
			if ( gestionnaireServeur != null )
				return gestionnaireServeur.GetDonneeDroit ( Id, strCode );
			return null;
		}

		//-------------------------------------------------------------------
		public CListeRestrictionsUtilisateurSurType GetRestrictions( int? nIdVersion )
		{
			//Récupère les profils a restriction globales
			CListeObjetsDonnees listeProfils = RelationsProfils;
			
			bool bIsAdmin = false;
			CListeRestrictionsUtilisateurSurType listeRestrictions = new CListeRestrictionsUtilisateurSurType(bIsAdmin);
			foreach (CRelationUtilisateur_Profil rel in listeProfils)
			{
				listeRestrictions = CListeRestrictionsUtilisateurSurType.Combine(listeRestrictions, rel.Profil.GetRestrictionsGlobales(nIdVersion));
			}

			return listeRestrictions;
		}
		public CRestrictionUtilisateurSurType GetRestrictionsSurType ( Type tp, int? nIdVersion )
		{
			return GetRestrictions(nIdVersion).GetRestriction ( tp );
		}

		//-------------------------------------------------------------------
		public CRelationElement_Droit GetNewObjetRelationDroit()
		{
			return new CRelationActeurUtilisateur_Droit ( ContexteDonnee );
		}


		//-------------------------------------------------------------------
		public static CDonneesActeurUtilisateur GetUserForSession ( int nIdSession, CContexteDonnee contexte )
		{
			try
			{
				CSessionClient session = CSessionClient.GetSessionForIdSession ( nIdSession );
				if ( session == null )
					return null;
				//TESTDBKEYOK
                CDbKey keyUtilisateur =  session.GetInfoUtilisateur().KeyUtilisateur;
				CDonneesActeurUtilisateur user = new CDonneesActeurUtilisateur(contexte);
				if ( !user.ReadIfExists ( keyUtilisateur ) )
					return null;
				return user;
			}
			catch 
			{
			}
			return null;
		}



		//---------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
		[DynamicField("PDA Key")]
		public int ClePDA
		{
			get
			{
				return Id << 1;
			}
		}

		
		/// //////////////////////////////////////////
		/// <summary>
		/// Initiales de l'utilisateur ( utile dans l'agenda )
		/// </summary>
		[TableFieldProperty(c_champInitiales, 6 )]
		[DynamicField("Initials")]
        [TiagField("Initials")]
		public string Initiales
		{
			get
			{
				string strVal = (string)Row[c_champInitiales];
				if ( strVal.Trim() == "" )
					strVal = CUtilTexte.GetInitiales ( Acteur.Nom, true );
				return strVal;
			}
			set
			{
				Row[c_champInitiales] = value;
			}
		}

		/// //////////////////////////////////////////
		/// <summary>
		/// Indique que l'utilisateur a un agenda personnel (qui peut être geré par un
		/// autre utilisateur
		/// </summary>
		[TableFieldProperty(c_champAgendaPersonnel)]
		[DynamicField("Personnal diary")]
        [TiagField("Personnal diary")]
		public bool AgendaPersonnel
		{
			get
			{
				return (bool)Row[c_champAgendaPersonnel];
			}
			set
			{
				Row[c_champAgendaPersonnel] = value;
			}
		}

		/// <summary>
		/// Retourne la liste des relations avec les profils
		/// </summary>
		[RelationFille ( typeof (CRelationUtilisateur_Profil), "Utilisateur" )]
		[DynamicChilds("Profiles relations", typeof(CRelationUtilisateur_Profil))]
		public CListeObjetsDonnees RelationsProfils
		{
			get
			{
				return GetDependancesListe(CRelationUtilisateur_Profil.c_nomTable, c_champId);
			}
		}


		//----------------------------------------------------------
        /// <summary>
        /// Permet de savoir si l'utilisateur correspond au profil<br/>
        /// passé en paramètre
        /// </summary>
        /// <param name="profil">Le profil testé</param>
        /// <returns>TRUE si oui, FALSE sinon</returns>
		[DynamicMethod("Returns true if user is in specified profile", "Profile to test")]
		public bool IsInProfil(CProfilUtilisateur profil)
		{
			if (profil == null)
				return false;
			foreach (CRelationUtilisateur_Profil rel in RelationsProfils)
			{
				if (rel.Profil != null && rel.Profil.Id == profil.Id)
					return true;
				if (rel.Profil_Inclusion != null && rel.Profil_Inclusion.ProfilFils != null &&
					rel.Profil_Inclusion.ProfilFils.Id == profil.Id)
					return true;
			}
			return false;
		}


        /// <summary>
        /// Identité de l'acteur (concaténation du prénom et du nom)
        /// </summary>
		[DynamicField("Member identity")]
		[DescriptionField]
		public string NomActeur
		{
			get
			{
				try
				{
					return Acteur.IdentiteComplete;
				}
				catch
				{
					return DescriptionElement;
				}
			}
		}

		public CResultAErreur VerifiePassword(string strPassword)
		{
			CResultAErreur result = CResultAErreur.True;

			string strCrypte = C2iCrypto.Crypte(strPassword.Trim());
			if (strCrypte != Password || (((strCrypte.Length % 2048) + 1) != Acteur.Datas))
				result.EmpileErreur(I.T("Invalid password !|30030"));

			return result;
		}

		public CResultAErreur ChangePassword(string strOldPassword, string strNewPassword)
		{
			CResultAErreur result = CResultAErreur.True;

			if (CUtilUtilisateur.UtilisateurConnecteIsUserManager(ContexteDonnee))
			{
				Password = C2iCrypto.Crypte(strNewPassword.Trim());
			}
			else
			{
				if (CUtilUtilisateur.UtilisateurActuel(ContexteDonnee).Id == Acteur.Id)
				{
					if (VerifiePassword(strOldPassword))
					{
						Password = C2iCrypto.Crypte(strNewPassword.Trim());
					}
					else
					{
						result.EmpileErreur(I.T("Invalid old password, only the administrator or the holder of the old password is authorized to modify it|30029"));
					}
				}
				else
					result.EmpileErreur(I.T("Only the user or an administrator is entitled to modify the password|30028"));
			}

			return result;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Retourne la liste des types pour lesquels il y a une restriction suivant les
		/// objets
		/// </summary>
		/// <returns></returns>
		public List<Type> GetTypesARestrictionsSurObjets(int? nIdVersion)
		{
			Dictionary<Type, bool> dicTypesARestrictionsSurObjets = new Dictionary<Type,bool>();
			foreach (CRelationUtilisateur_Profil relProfil in RelationsProfils)
			{
				relProfil.AddTypesARestrictionsSurObjets(dicTypesARestrictionsSurObjets, nIdVersion);
			}
            foreach (Type tp in CContexteDonnee.GetAllTypes())
            {
                if (typeof(IElementARestrictionsSpecifiques).IsAssignableFrom(tp))
                    dicTypesARestrictionsSurObjets[tp] = true;
            }
			List<Type> lst = new List<Type>(dicTypesARestrictionsSurObjets.Keys);
			return lst;
		}

        //-------------------------------------------------------------------

        #region IElementAInterfaceTiag Membres

        public object[] TiagKeys
        {
            get { return new object[] { Id }; }
        }

        public string TiagType
        {
            get { return c_nomTiag; }
        }

        #endregion
	}

	public static class CUtilUtilisateur
	{
		public static bool UtilisateurConnecteIsAdministrateur(CContexteDonnee ctx)
		{
			IDonneeDroitUtilisateur data = null;
			CSessionClient session = CSessionClient.GetSessionForIdSession(ctx.IdSession);
			if (session != null)
			{
				IInfoUtilisateur infoUser = session.GetInfoUtilisateur();
				if(infoUser != null)
					data = infoUser.GetDonneeDroit(CDroitDeBaseSC2I.c_droitAdministration);
			} 
			return data != null;
		}

        public static bool UtilisateurConnecteIsUserManager(CContexteDonnee ctx)
        {
            IDonneeDroitUtilisateur data = null;
            CSessionClient session = CSessionClient.GetSessionForIdSession(ctx.IdSession);
            if (session != null)
            {
                IInfoUtilisateur infoUser = session.GetInfoUtilisateur();
                if (infoUser != null)
                    data = infoUser.GetDonneeDroit(CDroitDeBase.c_droitBaseGestionUtilisateurs);
            }
            return data != null;
        }

		public static CActeur UtilisateurActuel(CContexteDonnee ctx)
		{
			CSessionClient session = CSessionClient.GetSessionForIdSession(ctx.IdSession);
			if (session != null)
			{
				IInfoUtilisateur infoUser = session.GetInfoUtilisateur();
				if(infoUser != null)
				{
					CDonneesActeurUtilisateur data = new CDonneesActeurUtilisateur(ctx);
                    //TESTDBKEYOK
					if (data.ReadIfExists(infoUser.KeyUtilisateur))
					{

						return data.Acteur;
					}
				}
			}
			return null;
		}

        

		

	}

    [AutoExec("Autoexec")]
    public class CFournisseurInformationsUtilisateurTimos : IFournisseurInformationsUtilisateur
    {
        //------------------------------------------------------------
        public static void Autoexec()
        {
            CUtilInfosUtilisateur.SetFournisseurInfosUtilisateur(new CFournisseurInformationsUtilisateurTimos());
        }

        //------------------------------------------------------------
        public int GetIdUtilisateurFromKey(CDbKey key)
        {
            CDonneesActeurUtilisateur user = new CDonneesActeurUtilisateur(CContexteDonneeSysteme.GetInstance());
            if (user.ReadIfExists(key))
                return user.Id;
            return -1;
        }

        //------------------------------------------------------------
        public CDbKey GetKeyUtilisateurFromId(int nId)
        {
            CDonneesActeurUtilisateur user = new CDonneesActeurUtilisateur(CContexteDonneeSysteme.GetInstance());
            if (user.ReadIfExists(nId))
                return user.DbKey;
            return null;
        }
    }

	#region MethodeProcessGetUtilisateur
	/// <summary>
	/// Ajoute à l'élément process, la méthode permettant de retourner
	/// l'utilisateur du process
	/// </summary>
	[AutoExec("Autoexec")]
	public class CMethodeProcessGetUtilisateur : CMethodeSupplementaire
	{
		/// <summary>
		/// ///////////////////////////////////////////
		/// </summary>
		private CMethodeProcessGetUtilisateur (  )
			:base ( typeof(CProcess) )
		{
		}

		/// ///////////////////////////////////////////
		public static void Autoexec()
		{
			CGestionnaireMethodesSupplementaires.RegisterMethode ( new CMethodeProcessGetUtilisateur() );
		}

		/// ///////////////////////////////////////////
		public override string Description
		{
			get
			{
				return I.T("Return User Entity associated to the action|291");
			}
		}

		/// ///////////////////////////////////////////
		public override CInfoParametreMethodeDynamique[] InfosParametres
		{
			get
			{
				return new CInfoParametreMethodeDynamique[0];
			}
		}

		/// ///////////////////////////////////////////
		public override string Name
		{
			get
			{
				return "GetUtilisateur";
			}
		}

		/// ///////////////////////////////////////////
		public override Type ReturnType
		{
			get
			{
				return typeof(CDonneesActeurUtilisateur);
			}
		}

		/// ///////////////////////////////////////////
		public override bool ReturnArrayOfReturnType
		{
			get
			{
				return false;
			}
		}


		/// ///////////////////////////////////////////
		public override object Invoke(object objetAppelle, params object[] parametres)
		{
			if ( !(objetAppelle is CProcess ) )
				return null;
			CProcess process = (CProcess)objetAppelle;
			if ( process.ContexteExecution != null )
			{
                //TESTDBKEYOK
				CDbKey keyUtilisateur = process.ContexteExecution.Branche.KeyUtilisateur;
				CDonneesActeurUtilisateur user = new CDonneesActeurUtilisateur ( process.ContexteExecution.ContexteDonnee );
                if (user.ReadIfExists(keyUtilisateur))
					return user;
			}
			return null;
		}

	
		
	}
	#endregion
}
