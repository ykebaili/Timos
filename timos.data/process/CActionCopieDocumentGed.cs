using System;
using System.Drawing;
using System.IO;
using System.Collections;

using sc2i.data;
using sc2i.process;
using sc2i.common;
using sc2i.expression;
using sc2i.data.dynamic;
using sc2i.formulaire;


using sc2i.workflow;
using sc2i.documents;
using sc2i.multitiers.client;
using System.Net;
using System.Text;

namespace timos.process
{
	/// <summary>
	/// Permet de stocker un document de GED dans le système de fichiers
	/// </summary>
	[AutoExec("Autoexec")]
	public class CActionCopieDocumentGed : CActionLienSortantSimple
	{
        public static string c_idServiceClientSetFichier = "CLIENT_SET_FILE";

        [Serializable]
        public class CParametreCopierLocalDansGed
        {
            public readonly string NomFichier = "";
            public readonly int IdDocumentGed = -1;
            public CParametreCopierLocalDansGed(
                int nIdDocument,
                string strNomFichier)
            {
                IdDocumentGed = nIdDocument;
                NomFichier = strNomFichier;
            }
        }

		private C2iExpression m_formuleDocument = null;
		private C2iExpression m_formuleNomFichier = null;

        private C2iExpression m_formuleUser = null;
        private C2iExpression m_formulePassword = null;
		
		//Formule indiquant le nom de fichier renommé si le fichier demandé existe déjà
		private C2iExpression m_formuleNomRenommage = null;
		
		//Si vrai, la copie est réalisée à partir du poste client
		private bool m_bCopieSurPosteClient = false;

		/// /////////////////////////////////////////
		public CActionCopieDocumentGed( CProcess process )
			:base(process)
		{
			Libelle = I.T("Copy a document|361");
		}

		/// /////////////////////////////////////////////////////////
		public static void Autoexec()
		{
			CGestionnaireActionsDisponibles.RegisterTypeAction(
				I.T("Copy a document|361"),
				I.T("Copy a document on file system|362"),
				typeof(CActionCopieDocumentGed),
				CGestionnaireActionsDisponibles.c_categorieInterface );
		}

		/// /////////////////////////////////////////
		public override void AddIdVariablesNecessairesInHashtable(Hashtable table)
		{
			AddIdVariablesExpressionToHashtable ( FormuleDocument, table );
			AddIdVariablesExpressionToHashtable ( FormuleNomFichier, table );
            AddIdVariablesExpressionToHashtable(m_formuleUser, table);
            AddIdVariablesExpressionToHashtable(m_formulePassword, table);
		}

		/// /////////////////////////////////////////////////////////
		public override bool PeutEtreExecuteSurLePosteClient
		{
			get { return false; }
		}

		

		/// /////////////////////////////////////////
		private int GetNumVersion()
		{
			//return 0;
            return 1;//Ajout de user et password pour FTP

		}


		/// ////////////////////////////////////////////////////////
		protected override CResultAErreur MySerialize ( C2iSerializer serializer )
		{
			int nVersion = GetNumVersion();
			CResultAErreur result = serializer.TraiteVersion ( ref nVersion );
			if ( result )
				result = base.MySerialize(serializer);
			if ( !result )
				return result;

			serializer.TraiteBool ( ref m_bCopieSurPosteClient );

			I2iSerializable objet = (I2iSerializable)FormuleDocument;
			result = serializer.TraiteObject ( ref objet );
			if ( !result )
				return result;
			FormuleDocument = (C2iExpression)objet;

			objet = (I2iSerializable)FormuleNomFichier;
			result = serializer.TraiteObject ( ref objet );
			if ( !result)
				return result;
			FormuleNomFichier = (C2iExpression)objet;

			objet = (I2iSerializable)FormuleNomFichierRenommage;
			result = serializer.TraiteObject ( ref objet );
			if ( !result)
				return result;
			FormuleNomFichierRenommage = (C2iExpression)objet;

            if ( nVersion >= 1 )
            {
                result = serializer.TraiteObject<C2iExpression>(ref m_formuleUser);
                if (result)
                    result = serializer.TraiteObject<C2iExpression>(ref m_formulePassword);
                if (!result)
                    return result;
            }

			return result;
		}

		/// ////////////////////////////////////////////////////////
		public C2iExpression FormuleDocument
		{
			get
			{
				return m_formuleDocument;
			}
			set
			{
				m_formuleDocument = value;
			}
		}

		/// ////////////////////////////////////////////////////////
		public C2iExpression FormuleNomFichier
		{
			get
			{
				return m_formuleNomFichier;
			}
			set
			{
				m_formuleNomFichier = value;
			}
		}

		/// ////////////////////////////////////////////////////////
		public C2iExpression FormuleNomFichierRenommage
		{
			get
			{
				return m_formuleNomRenommage;
			}
			set
			{
				m_formuleNomRenommage = value;
			}
		}

        /// ////////////////////////////////////////////////////////
        public C2iExpression FormuleUser
        {
            get
            {
                return m_formuleUser;
            }
            set { m_formuleUser = value; }
        }

        /// ////////////////////////////////////////////////////////
        public C2iExpression FormulePassword
        {
            get
            {
                return m_formulePassword;
            }
            set { m_formulePassword = value; }
        }

		/// ////////////////////////////////////////////////////////
		public bool CopierDepuisLePosteClient
		{
			get
			{
				return m_bCopieSurPosteClient;
			}
			set
			{
				m_bCopieSurPosteClient = value;
			}
		}
		

		/// ////////////////////////////////////////////////////////
		public override CResultAErreur VerifieDonnees()
		{
			CResultAErreur result = base.VerifieDonnees();

			if ( FormuleDocument == null )
				result.EmpileErreur(I.T("Incorrect document formula|363"));
			else
			{
				if ( !FormuleDocument.TypeDonnee.Equals ( new CTypeResultatExpression(typeof(CDocumentGED),false ) ) )
					result.EmpileErreur(I.T("The document formula must return an EDM document|364"));
			}
			if ( FormuleNomFichier == null || !FormuleNomFichier.TypeDonnee.Equals(new CTypeResultatExpression(typeof(string), false) ))
				result.EmpileErreur(I.T("Incorrect file name formula|365"));

			if(  FormuleNomFichierRenommage != null 
					&& !FormuleNomFichierRenommage.TypeDonnee.Equals ( new CTypeResultatExpression(typeof ( string ), false ) ) )
				result.EmpileErreur ( "Incorrest renaming formula|366");

			
			return result;
		}


		/// ////////////////////////////////////////////////////////
		protected override CResultAErreur MyExecute(CContexteExecutionAction contexte)
		{
			CResultAErreur result = CResultAErreur.True;

			CContexteEvaluationExpression contexteEval = new CContexteEvaluationExpression (Process);
			if ( FormuleDocument == null )
			{
				result.EmpileErreur(I.T( "Incorrect document formula|363"));
				return result;
			}
			result = FormuleDocument.Eval ( contexteEval );
			if ( !result )
			{
				result.EmpileErreur(I.T("Error during Document evaluation|367"));
				return result;
			}
			if ( !(result.Data is CDocumentGED) )
			{
				result.EmpileErreur(I.T( "The document formula must return an EDM document|364"));
				return result;
			}
			CDocumentGED document = (CDocumentGED)result.Data;

			if ( FormuleNomFichier == null )
			{
				result.EmpileErreur(I.T( "Incorrect file name formula|365"));
				return result;
			}
			result = FormuleNomFichier.Eval ( contexteEval );
			if ( !result )
			{
				result.EmpileErreur(I.T("Error during the destination file name of document evaluation|368"));
				return result;
			}
			if ( !(result.Data is string ) )
			{
				result.EmpileErreur(I.T("File name formula doesn't return a file name string|369"));
				return result;
			}

			string strNomFichier = result.Data.ToString();

            if ( strNomFichier.ToUpper().StartsWith("FTP://"))
            {
                string strUser = "";
                string strPassword = "";
                if ( FormuleUser != null)
                    result = FormuleUser.Eval(contexteEval);
                if ( !result )
                {
                    result.EmpileErreur(I.T("Error in User formula|20250"));
                    return result;
                }
                else
                    strUser = result.Data != null?result.Data.ToString():"";
                if ( FormulePassword != null )
                    result = FormulePassword.Eval(contexteEval);
                if ( !result )
                {
                    result.EmpileErreur(I.T("Error in password formula|20250"));
                    return result;
                }
                else
                    strPassword = result.Data != null?result.Data.ToString():"";
                return CopyToFtp(contexte.IdSession, document, strNomFichier, strUser, strPassword);
            }
            else if (CopierDepuisLePosteClient)
            {
                CSessionClient sessionClient = CSessionClient.GetSessionForIdSession(contexte.IdSession);
                if (sessionClient != null)
                {
                    //TESTDBKEYOK
                    if (sessionClient.GetInfoUtilisateur().KeyUtilisateur == contexte.Branche.KeyUtilisateur)
                    {
                        using (C2iSponsor sponsor = new C2iSponsor())
                        {
                            CServiceSurClient service = sessionClient.GetServiceSurClient(c_idServiceClientSetFichier);
                            if (service != null)
                            {
                                sponsor.Register(service);
                                CParametreCopierLocalDansGed parametre = new CParametreCopierLocalDansGed(
                                    document.Id,
                                    strNomFichier);
                                result = service.RunService(parametre);
                                return result;
                            }
                        }
                    }
                }
            }

			if ( File.Exists ( strNomFichier ) )
			{
				#region renommage du fichier existant
				if ( FormuleNomFichierRenommage != null )
				{
					result = FormuleNomFichierRenommage.Eval ( contexteEval );
					if ( !result )
					{
						result.EmpileErreur(I.T("Error in the renaming file name|370"));
						return result;
					}
					if ( !(result.Data is string ) )
					{
						result.EmpileErreur(I.T("The renaming formula doesn't return text|371"));
						return result;
					}
					int nIndex = 0;
					string strRename = result.Data.ToString();
					string strExt = "";
					nIndex = strNomFichier.LastIndexOf('.');
					string strNom = strRename;
					if ( nIndex >= 0 )
					{
						strNom = strRename.Substring(0, nIndex );
						strExt = strRename.Substring ( nIndex );
						strRename = strNom;
					}
					nIndex = 0;
					while ( File.Exists ( strNom+strExt ) )
					{
						nIndex++;
						strNom = strRename+"_"+nIndex;
					}
					try
					{
						if ( strExt != "" )
							strNom = strNom+strExt;
						File.Copy ( strNomFichier, strNom, true );
					}
					catch (Exception e )
					{
						result.EmpileErreur( new CErreurException ( e ) );
						result.EmpileErreur(I.T("New name : '@1'|372",strNom));
						result.EmpileErreur(I.T("Error during file renaming|373"));
						
						return result;
					}
				}
				#endregion
			}
			try
			{
				using ( CProxyGED proxy = new CProxyGED ( contexte.IdSession, document.ReferenceDoc ) )
				{
					result = proxy.CopieFichierEnLocal();
					if ( !result )
						return result;
					//Si le fichier existe, il est renommé
					File.Copy ( proxy.NomFichierLocal, strNomFichier, true );
				}
			}
			catch ( Exception e )
			{
				result.EmpileErreur ( new CErreurException ( e ) );
				return result;
			}
			

			return result;
		}


        private bool FtpFileExists ( 
            int nIdSession,
            string strNomFichierDest,
            string strUser,
            string strPassword )
        {
            bool bResult = false;
            try
            {
                FtpWebRequest req = (FtpWebRequest)WebRequest.Create(strNomFichierDest);
                req.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                if (strUser.Length > 0 || strPassword.Length > 0)
                    req.Credentials = new NetworkCredential(strUser, strPassword);
                FtpWebResponse response = (FtpWebResponse)req.GetResponse();
                Stream respStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(respStream);
                String strRes = reader.ReadToEnd();
                bResult = strRes.Trim().Length != 0;
            }
            catch
            {
            }
            return false;
        }

        private CResultAErreur CopyToFtp ( 
            int nIdSession,
            CDocumentGED document,
            string strNomFichierDest,
            string strUser,
            string strPassword )
        {
            CResultAErreur result = CResultAErreur.True;
            if ( !strNomFichierDest.ToUpper().StartsWith("FTP://"))
            {
                result.EmpileErreur(I.T("Bad file name '@1' for ftp transfert|20252", strNomFichierDest));
                return result;
            }
            try
            {
                using (CProxyGED proxy = new CProxyGED(nIdSession, document.ReferenceDoc))
                {
                    result = proxy.CopieFichierEnLocal();
                    if (!result)
                        return result;

                    FtpWebRequest req = (FtpWebRequest)WebRequest.Create(strNomFichierDest);
                    req.Method = WebRequestMethods.Ftp.UploadFile;
                    if (strUser.Length > 0 || strPassword.Length > 0)
                        req.Credentials = new NetworkCredential(strUser, strPassword);
                    FileStream reader = new FileStream(proxy.NomFichierLocal, FileMode.Open, FileAccess.Read);
                    byte[] buff = new byte[1024];
                    Stream requestStream = req.GetRequestStream();
                    int nSize = 0;
                    int nSizeTotal = 0;
                    while ((nSize = reader.Read(buff, 0, 1024)) > 0)
                    {
                        nSizeTotal += nSizeTotal;
                        requestStream.Write(buff, 0, nSize);
                    }
                    req.ContentLength = nSizeTotal;
                    requestStream.Close();
                    reader.Close();
                    FtpWebResponse reponse = (FtpWebResponse)req.GetResponse();
                    reponse.Close();

                }
            }
            catch (Exception e)
            {
                result.EmpileErreur(new CErreurException(e));
            }
            return result;
        }
	}
}
