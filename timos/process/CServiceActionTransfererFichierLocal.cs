using System;
using System.Windows.Forms;
using System.Diagnostics;

using sc2i.common;
using sc2i.multitiers.client;
using sc2i.process;
using sc2i.expression;
using sc2i.win32.common;
using System.IO;
using sc2i.documents;
using System.Net;


namespace timos.process
{
	/// <summary>
	/// Description résumée de CServiceActionTransfererFichierLocal.
	/// </summary>
	[AutoExec("Autoexec")]
	public class CServiceActionTransfererFichierLocal : CServiceSurClient, IDisposable
	{
        private Stream m_streamFichier = null;
        private CFichierLocalTemporaire m_fichierTemporaireFromFTP = null;

        /// ///////////////////////////////////////////
        public void Dispose()
        {
            MyDispose();
        }

        private void MyDispose()
        {
            if ( m_streamFichier != null )
            {
                m_streamFichier.Close();
                m_streamFichier.Dispose();
                m_streamFichier = null;
            }
            if (m_fichierTemporaireFromFTP != null)
            {
                m_fichierTemporaireFromFTP.Dispose();
                m_fichierTemporaireFromFTP = null;
            }

        }
		/// ///////////////////////////////////////////
		public override string IdService
		{
			get
			{
                return CActionCopierLocalDansGed.c_idServiceClientGetFichier;
			}
		}

		public static void Autoexec()
		{
			CSessionClient.RegisterServiceSurClient ( new CServiceActionTransfererFichierLocal() );
		}

		/// ///////////////////////////////////////////
		public override sc2i.common.CResultAErreur RunService(object parametre)
		{
            MyDispose();
			CResultAErreur result = CResultAErreur.True;
            CActionCopierLocalDansGed.CParametresCopierLocalDansGed paramCopie = parametre as CActionCopierLocalDansGed.CParametresCopierLocalDansGed;
			if ( paramCopie == null )
            {
                result.EmpileErreur(I.T("Bad parameter value for service GetLocalFile|20121"));
                return result;
            }
            if (paramCopie.NomFichierLocal.ToUpper().StartsWith("FTP://"))
            {
                //Si FTP récupère le fichier FTP et l'envoie dans un fichier local temporaire
                result = GetFileFromFtp(paramCopie);
                if ( !result )
                    return result;
                paramCopie.NomFichierLocal = m_fichierTemporaireFromFTP.NomFichier;
            }

            string strNomFichier = paramCopie.NomFichierLocal;
            if ( !File.Exists ( strNomFichier ) )
            {
                result.EmpileErreur(I.T("File @1 doesn't exists|20122", strNomFichier));
                return result;
            }
            m_streamFichier = new FileStream(strNomFichier,FileMode.Open, FileAccess.Read);
            CSourceDocumentStream source = new CSourceDocumentStream (  
                m_streamFichier, Path.GetExtension ( strNomFichier ) );
            result.Data = source;
            return result;
		}

        private CResultAErreur GetFileFromFtp(CActionCopierLocalDansGed.CParametresCopierLocalDansGed parametre)
        {
            CResultAErreur result = CResultAErreur.True;
            string strExt = "dat";
            int nPosPoint = parametre.NomFichierLocal.LastIndexOf(".");
            if (nPosPoint >= 0)
                strExt = parametre.NomFichierLocal.Substring(nPosPoint+1);
            m_fichierTemporaireFromFTP = new CFichierLocalTemporaire(strExt);
            m_fichierTemporaireFromFTP.CreateNewFichier();

            using (FileStream streamDest = new FileStream(
                m_fichierTemporaireFromFTP.NomFichier,
                FileMode.CreateNew,
                FileAccess.Write))
            {
                try
                {
                    FtpWebRequest req = (FtpWebRequest)WebRequest.Create(parametre.NomFichierLocal);
                    req.Method = WebRequestMethods.Ftp.DownloadFile;
                    req.Credentials = new NetworkCredential(parametre.User, parametre.Password);

                    FtpWebResponse response = (FtpWebResponse)req.GetResponse();
                    Stream respStream = response.GetResponseStream();
                    byte[] buffer = new byte[256];
                    int nNbLus = 0;
                    while ((nNbLus = respStream.Read(buffer, 0, 256)) != 0)
                        streamDest.Write(buffer, 0, nNbLus);
                    respStream.Close();
                    respStream.Dispose();
                    response.Close();
                    response.Dispose();
                }
                catch (Exception e)
                {
                    result.EmpileErreur(new CErreurException(e));
                }
                streamDest.Close();

            }
            return result;
        }

		

	}
}
