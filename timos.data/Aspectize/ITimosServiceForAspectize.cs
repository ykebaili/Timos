using sc2i.common;
using System;
using System.Collections.Generic;
using System.Data;
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
        void CloseSession(int nIdSession);
        CResultAErreur GetTodosForUser(int nIdSession, string keyUtilisateur);
        CResultAErreur GetTodoDetails(int nIdSession, int nIdTodo);
        CResultAErreur SaveTodo(int nIdSession, DataSet ds);


    }
}
