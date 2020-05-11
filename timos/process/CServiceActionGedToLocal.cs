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
using sc2i.data;


namespace timos.process
{
	/// <summary>
	/// Description résumée de CServiceActionGedToLocal.
	/// </summary>
	[AutoExec("Autoexec")]
	public class CServiceActionGedToLocal : CServiceSurClient
	{
		/// ///////////////////////////////////////////
		public override string IdService
		{
			get
			{
                return CActionCopieDocumentGed.c_idServiceClientSetFichier;
			}
		}

		public static void Autoexec()
		{
			CSessionClient.RegisterServiceSurClient ( new CServiceActionGedToLocal() );
		}

		/// ///////////////////////////////////////////
		public override sc2i.common.CResultAErreur RunService(object parametre)
		{
			CResultAErreur result = CResultAErreur.True;
            CActionCopieDocumentGed.CParametreCopierLocalDansGed parametreCopie = parametre as CActionCopieDocumentGed.CParametreCopierLocalDansGed;
			if ( parametreCopie == null )
            {
                result.EmpileErreur(I.T("Bad parameter value for service SetLocalFile|20125"));
                return result;
            }
            using (CContexteDonnee contexte = new CContexteDonnee(CTimosApp.SessionClient.IdSession, true, false))
            {
                CDocumentGED document = new CDocumentGED(contexte);
                if (!document.ReadIfExists(parametreCopie.IdDocumentGed))
                {
                    result.EmpileErreur(I.T("Document @1 doesn't exists|20126"));
                    return result;
                }
                try
                {
                    using (CProxyGED proxy = new CProxyGED(CTimosApp.SessionClient.IdSession, document.ReferenceDoc))
                    {
                        result = proxy.CopieFichierEnLocal();
                        if (!result)
                            return result;
                        File.Copy(proxy.NomFichierLocal, parametreCopie.NomFichier, true);
                    }
                }
                catch (Exception e)
                {
                    result.EmpileErreur(new CErreurException(e));
                }
            }
            return result;
		}

	}
}
