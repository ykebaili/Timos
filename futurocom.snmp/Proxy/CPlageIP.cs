using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Globalization;
using sc2i.common;

namespace futurocom.snmp.Proxy
{
    [Serializable]
    public class CPlageIP : I2iSerializable
    {
        private string m_strModeleIP;
        private int m_nMask = 0;

        public CPlageIP()
        {
        }

        public CPlageIP(IPAddress modeleIP, int nMask)
        {
            m_strModeleIP = modeleIP.ToString();
            m_nMask = nMask;
        }

        public CPlageIP(string strModeleIP, int nMask)
        {
            m_strModeleIP = strModeleIP;
            m_nMask = nMask;
        }


        //-------------------------------------------------------------------------
        public IPAddress ModeleIP
        {
            get
            {
                return new IP(m_strModeleIP).ToIPAddress();
            }
        }

        //-------------------------------------------------------------------------
        public string ModeleIpString
        {
            get
            {
                return m_strModeleIP;
            }
            set
            {
                m_strModeleIP = value;
            }
        }

        //-------------------------------------------------------------------------
        public int Mask
        {
            get
            {
                return m_nMask;
            }
            set
            {
                m_nMask = value;
            }
        }

        //-------------------------------------------------------------------------
        private IPAddress MaskIp(IPAddress ip)
        {
            try
            {
                byte[] tabOctetsAMasquer = ip.GetAddressBytes();
                byte[] tabOctetsMask = MaskComplet.GetAddressBytes();

                byte res = (byte)(tabOctetsAMasquer[0] & tabOctetsMask[0]);

                // Masquage de l'IP à analyser
                return new IPAddress(new byte[]{
                    (byte) (tabOctetsAMasquer[0] & tabOctetsMask[0]),
                    (byte) (tabOctetsAMasquer[1] & tabOctetsMask[1]),
                    (byte) (tabOctetsAMasquer[2] & tabOctetsMask[2]),
                    (byte) (tabOctetsAMasquer[3] & tabOctetsMask[3])
                });
            }
            catch { }

            return ip;
        }

        //-------------------------------------------------------------------------
        public bool Match(string strMonIp)
        {
            IPAddress ip = new IP(strMonIp).ToIPAddress();
            return Match(ip);
        }

        //-------------------------------------------------------------------------
        public bool Match(IPAddress ipAAnalyser)
        {
            try
            {
                ipAAnalyser = MaskIp(ipAAnalyser);
                if (ipAAnalyser.Equals(MaskIp(ModeleIP)))
                    return true;
            }
            catch { }

            return false;
        }

        //-------------------------------------------------------------------------
        public IPAddress MaskComplet
        {
            get
            {
                IPAddress IpMask = new IPAddress(new byte[] { 255, 255, 255, 255 });

                try
                {
                    StringBuilder sb = new StringBuilder(32, 32);
                    sb.Append('1', 32 - m_nMask);
                    sb.Append('0', m_nMask);
                    string strMask = sb.ToString();

                    byte octet4 = Convert.ToByte(strMask.Substring(0, 8), 2);
                    byte octet3 = Convert.ToByte(strMask.Substring(8, 8), 2);
                    byte octet2 = Convert.ToByte(strMask.Substring(16, 8), 2);
                    byte octet1 = Convert.ToByte(strMask.Substring(24, 8), 2);

                    IpMask = new IPAddress(new byte[] { octet4, octet3, octet2, octet1 });
                }
                catch { }

                return IpMask;
            }
        }

        #region Serialization
        //-------------------------------------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //-------------------------------------------------------------------------
        public CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;

            serializer.TraiteString(ref m_strModeleIP);
            serializer.TraiteInt(ref m_nMask);

            return result;

        }
        #endregion

        //-------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            CPlageIP plage = obj as CPlageIP;
            if (plage != null && plage.m_strModeleIP == this.m_strModeleIP && plage.m_nMask == this.m_nMask)
                return true;

            return false;
        }

        //-------------------------------------------------------------------------
        public override int GetHashCode()
        {
            string strHCode = m_strModeleIP + "_" + m_nMask.ToString();
            return strHCode.GetHashCode();
        }

    }
}
