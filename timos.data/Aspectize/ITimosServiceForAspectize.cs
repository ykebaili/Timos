using sc2i.common;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timos.data.Aspectize
{
    public interface ITimosServiceForAspectize
    {
        /// <summary>
        /// Retour : le Data du Result contient un dictionnaire de propriétés à passer à Aspectize
        /// </summary>
        /// <param name="strLogin"></param>
        /// <param name="strPassword"></param>
        /// <returns></returns>
        CResultAErreur OpenSession(string strLogin, string strPassword);
        CResultAErreur GetSession(int nIdSession);
        void CloseSession(int nIdSession);
        CResultAErreur GetTodosForUser(int nIdSession, string keyUtilisateur);
        CResultAErreur GetTodoDetails(int nIdSession, int nIdTodo);
        CResultAErreur SaveTodo(int nIdSession, DataSet ds, int nIdTodo, string elementType, int elementId);
        CResultAErreur EndTodo(int nIdSession, int nIdTodo);
        CResultAErreur AddFile(int nIdSession, string strNomfichier, byte[] octets);
        CResultAErreur SaveDocument(int nIdSession, DataSet ds, int nIdDocument, int nIdCategorie);

    }
}
