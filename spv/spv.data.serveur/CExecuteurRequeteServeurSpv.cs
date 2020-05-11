using System;
using System.Collections.Generic;
using System.Text;
using sc2i.multitiers.server;
using sc2i.common;
using sc2i.data;
using sc2i.data.serveur;

namespace spv.data.serveur
{
    public class CExecuteurRequeteServeurSpv : C2iObjetServeur, IExecuteurRequeteServeurSpv
    {
        public CExecuteurRequeteServeurSpv ( int nIdSession )
            :base ( nIdSession )
        {
        
        }

        public CResultAErreur ExecuteScalar(string strStatement)
        {
            IDatabaseConnexion connexion = CSc2iDataServer.GetInstance().GetDatabaseConnexion(IdSession, typeof(CSpvSiteServeur));
            return connexion.ExecuteScalar(strStatement);
        }


    }
}
