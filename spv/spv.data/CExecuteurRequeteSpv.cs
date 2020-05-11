using System;
using System.Collections.Generic;
using System.Text;
using sc2i.common;
using sc2i.multitiers.client;

namespace spv.data
{
    public static class CExecuteurRequeteSpv
    {
        public static CResultAErreur ExecuteScalar(int nIdSession, string strStatement)
        {
            IExecuteurRequeteServeurSpv executeur = C2iFactory.GetNewObjetForSession("CExecuteurRequeteServeurSpv", typeof(IExecuteurRequeteServeurSpv), nIdSession) as IExecuteurRequeteServeurSpv;
            return executeur.ExecuteScalar(strStatement);
        }
    }

    public interface IExecuteurRequeteServeurSpv
    {
        CResultAErreur ExecuteScalar(string strStatement);
    }
}
