using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using sc2i.common;
using sc2i.multitiers.client;


namespace sc2i.workflow
{
    [Serializable]
    public class CMessageSMSPourEnvoi
    {
        private string[] m_strNumerosDestinataires = new string[0];
        private string m_strMessage = "";

        public CMessageSMSPourEnvoi(string[] strNumerosDestinataires,
            string strMessage)
        {
            m_strNumerosDestinataires = strNumerosDestinataires;
            m_strMessage = strMessage;
        }

        public string[] NumerosDestinataires
        {
            get
            {
                return m_strNumerosDestinataires;
            }
            set
            {
                m_strNumerosDestinataires = value;
            }
        }

        public string Message
        {
            get
            {
                return m_strMessage;
            }
            set
            {
                m_strMessage = value;
            }
        }

        //---------------------------------------------------------------
        public static string CutTo160 ( string strChaine )
        {
            if ( strChaine.Length < 160 )
                return strChaine;
            string strRetour = strChaine.Substring(0, 160);
            
            for ( int nPos = strRetour.Length-1; nPos >120 ; nPos-- )
            {
                if ( " .,;?".IndexOf ( strRetour[nPos] ) >= 0 || strRetour[nPos] < 26 )
                    return strRetour.Substring(0, nPos+1);
            }
            return strRetour;            
        }

        //---------------------------------------------------------------
        public static string GSMChar(string strMessage)
        {
            string strFinale = strMessage.Normalize(NormalizationForm.FormD);
            // ` is not a conversion, just a untranslatable letter
            string strGSMTable = "";
            strGSMTable += "@£$¥èéùìòÇ`Øø`Åå";
            strGSMTable += "Δ_ΦΓΛΩΠΨΣΘΞ`ÆæßÉ";
            strGSMTable += " !\"#¤%&'()*=,-./";
            strGSMTable += "0123456789:;<=>?";
            strGSMTable += "¡ABCDEFGHIJKLMNO";
            strGSMTable += "PQRSTUVWXYZÄÖÑÜ`";
            strGSMTable += "¿abcdefghijklmno";
            strGSMTable += "pqrstuvwxyzäöñüà";

            string strExtendedTable = "";
            strExtendedTable += "````````````````";
            strExtendedTable += "````^```````````";
            strExtendedTable += "````````{}`````\\";
            strExtendedTable += "````````````[~]`";
            strExtendedTable += "|```````````````";
            strExtendedTable += "````````````````";
            strExtendedTable += "`````€``````````";
            strExtendedTable += "````````````````";

            string strGSMOutput = "";

            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < strFinale.Length; i++)
            {
                Char c = strFinale[i];
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    stringBuilder.Append(c);
            }
            strFinale = stringBuilder.ToString();
            stringBuilder = new StringBuilder();
            foreach (char cPlainText in strFinale.ToCharArray())
            {
                int intGSMTable = strGSMTable.IndexOf(cPlainText);
                if (intGSMTable != -1)
                {
                    stringBuilder.Append(cPlainText);
                    strGSMOutput += intGSMTable.ToString("X2");
                    continue;
                }
                int intExtendedTable = strExtendedTable.IndexOf(cPlainText);
                if (intExtendedTable != -1)
                {
                    strGSMOutput += (27).ToString("X2");
                    strGSMOutput += intExtendedTable.ToString("X2");
                }
            }
            return stringBuilder.ToString().Replace('\"','\'');
        }

        //---------------------------------------------------------------
        public string[] GetSMSStrings()
        {
            //Convertit le texte du message en enlevant les accents
            //et tout ce qui n'est pas compatible avec un message SMS.
            string strFinale = GSMChar(Message).Trim();
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < strFinale.Length; i++)
            {
                Char c = strFinale[i];
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    stringBuilder.Append(c);
            }
            strFinale = stringBuilder.ToString();

            strFinale.Trim();
            if (strFinale.Length == 0)
                return new string[0];
            List<string> lst = new List<string>();
            while (strFinale.Length > 0)
            {
                if (strFinale.Length > 160)
                {
                    string strTrunq = CutTo160(strFinale);
                    strFinale = strFinale.Substring(strTrunq.Length);
                    lst.Add(strTrunq);
                }
                else
                {
                    lst.Add(strFinale);
                    strFinale = "";
                }
            }
            return lst.ToArray();
        }

        //---------------------------------------------------------------
        public CResultAErreur Send(int nIdSession)
        {
            ISMSSender sender = (ISMSSender)C2iFactory.GetNewObjetForSession("CSMSSender", typeof(ISMSSender), nIdSession);
            return sender.SendMessage(this);
        }


      

    }
}
