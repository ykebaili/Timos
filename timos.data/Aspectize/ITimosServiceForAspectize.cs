﻿using sc2i.common;
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
        CResultAErreur SaveCaracteristique(int nIdSession, DataSet dataSet, int nIdCarac, string strTypeElement, int nIdTodo);
        CResultAErreur DeleteCaracteristique(int nIdSession, int nIdCarac, string strTypeElement);
        CResultAErreur EndTodo(int nIdSession, int nIdTodo);
        CResultAErreur AddFile(int nIdSession, string strNomfichier, byte[] octets);
        CResultAErreur DeleteFile(int nIdSession, string strKeyFile);
        CResultAErreur DownloadFile(int nIdSession, string strKeyFile);
        CResultAErreur SaveDocument(int nIdSession, DataSet ds, int nIdDocument, int nIdCategorie);
        CResultAErreur GetActionsForUser(int nIdSession, string keyUtilisateur);
        CResultAErreur ExecuteAction(int nIdSession, DataSet ds, int nIdAction, string strTypeCible, int nIdElementCible);
        CResultAErreur GetExportsForUser(int nIdSession, string keyUtilisateur);
        CResultAErreur GetDataSetExport(int nIdSession, string keyExport);
    }
}
