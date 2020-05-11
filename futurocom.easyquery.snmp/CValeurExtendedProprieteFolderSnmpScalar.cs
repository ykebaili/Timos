using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using sc2i.common;
using futurocom.easyquery;

namespace futurocom.easyquery.snmp
{
    [AutoExec("Autoexec")]
    public class CValeurExtendedProprieteFolderSnmpScalar : IValeurExtendedProperiteFolder
    {
        public const string  c_strImageScalar = "SNMP_SCALAR";
        private string m_strOID = "";

        //------------------------------------------------
        public CValeurExtendedProprieteFolderSnmpScalar(string strOID)
        {
            m_strOID = strOID;
        }

        //------------------------------------------------
        public static void Autoexec()
        {
            CEasyQuerySource.RegisterImageForFolder(c_strImageScalar, Resource1.number16);
        }


        //------------------------------------------------
        public string GetValue(CEasyQuerySource source)
        {
            CSnmpTableFiller filler = source.GetTableFiller(typeof(CSnmpTableFiller)) as CSnmpTableFiller;
            string strRetour = null;
            if (filler != null)
            {
                object val = filler.GetValue(m_strOID);
                if (val != null)
                    strRetour = val.ToString();
            }
            return strRetour;
        }
    }
}
