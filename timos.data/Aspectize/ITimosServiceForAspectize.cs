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

        CResultAErreur GetTodosForUser(int nIdSessin, string keyUtilisateur);

        CResultAErreur SaveToDo(int nIdSession, DataSet ds);


    }
}
