using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using sc2i.common.memorydb;
using System.Runtime.Serialization;

namespace futurocom.supervision
{
    public interface ITraiteurAlarmeFromMediation
    {
        CResultAErreurType<CMappageIdsAlarmes> Traite(CMemoryDb dbContenantLesAlarmesATraiter);



        void UpdateAgentIpFromMediation(string strAgentId, string strNewIp, bool bUpdateTimosDb);
    }

    /// <summary>
    /// Permet d'indiquer qu'une alarme a changé d'ID lors de son traitement par
    /// le serveur TIMOS
    /// </summary>
    [Serializable]
    public class CMappageIdsAlarmes : Dictionary<string, string>
    {
        private Dictionary<string, string> m_dicMappage = new Dictionary<string, string>();

        public CMappageIdsAlarmes()
            : base()
        {
        }

        public CMappageIdsAlarmes(SerializationInfo info, StreamingContext ctx)
            : base(info, ctx)
        {
        }
    }
}
