using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.server;

namespace timos.serveur
{

    [Serializable]
    public class CSMSSenderParametres : IInitialisableFromRegistre
    {
        public bool LoopOnRecipients { get; set; }
        public string PortName{get;set;}
        public int BaudRate{get;set;}
        public Parity Parity{get;set;}
        public byte DataBits{get;set;}
        public StopBits StopBits{get;set;}
        public Handshake Handshake{get;set;}
        public bool DtrEnable{get;set;}
        public bool RtsEnable{get;set;}
        public string NewLine{get;set;}
        public int WriteTimeout { get; set; }

        public int WaitBeforeRead{get;set;}
        public bool Debug{get;set;}
        public string SmsServiceNumber{get;set;}
        public int TimeOut{get;set;}

        public CSMSSenderParametres()
        {
            BaudRate = 9600;
            Parity = Parity.None;
            DataBits = 8;
            StopBits = StopBits.One;
            Handshake = Handshake;
            DtrEnable = true;
            RtsEnable = true;
            NewLine = System.Environment.NewLine;
            WriteTimeout = 3000;

            WaitBeforeRead = 300;
            Debug = false;
            SmsServiceNumber = "";
            TimeOut = 3000;
            LoopOnRecipients = true;
        }

    }

    [AutoExec("Autoexec")]
    public class CSMSSender : C2iObjetServeur, ISMSSender
    {
        private static CSMSSenderParametres m_parametre = new CSMSSenderParametres();

        public static void Autoexec()
        {
            CTimosServeurRegistre.ReadObjetFromRegistre ( "sms", m_parametre );
        }

        public CSMSSender(int nIdSession)
            : base(nIdSession)
        {
        }


        public CSMSSender()
        {
        }

        public CResultAErreur SendMessage
            (
            CMessageSMSPourEnvoi message 
            )
        {
            CResultAErreur result = CResultAErreur.True;
            string[] strMessages = message.GetSMSStrings();
            if (strMessages.Length == 0)
                return result;
            SerialPort port = new SerialPort();
            port.PortName = m_parametre.PortName;
            port.BaudRate = m_parametre.BaudRate;
            port.Parity = m_parametre.Parity;
            port.DataBits = m_parametre.DataBits;
            port.StopBits = m_parametre.StopBits;
            port.Handshake = m_parametre.Handshake;
            port.DtrEnable = m_parametre.DtrEnable;
            port.RtsEnable = m_parametre.RtsEnable;
            port.NewLine = m_parametre.NewLine;
            port.WriteTimeout = m_parametre.WriteTimeout;

            try
            {
                port.Open();
            }

            catch (Exception e)
            {
                result.EmpileErreur(new CErreurException(e));
                return result;
            }
            try
            {
                //Vide le buffer
                string[] strLines = ReadLines(port, m_parametre.TimeOut);
                if (m_parametre.Debug)
                {
                    Console.WriteLine("Init-------");
                    foreach (string strLine in strLines)
                        Console.Write(strLine);
                }
                for (int n = 0; n < 10; n++)
                    port.WriteLine("\u001A");

                if (m_parametre.Debug)
                    Console.Write("Ecrit ATZ0...");
                port.WriteLine("ATZ0");
                if (m_parametre.Debug)
                    Console.WriteLine("OK");

                //Pas d'écho
                strLines = WriteAndReadReponse(port, "ATE1", m_parametre.TimeOut);
                if (GetErrorLine(strLines) != null)
                {
                    result.EmpileErreur(GetErrorLine(strLines));
                    return result;
                }

                //Format SMS texte
                strLines = WriteAndReadReponse(port, "AT+CMGF=1", m_parametre.TimeOut);
                if (GetErrorLine(strLines) != null)
                {
                    result.EmpileErreur(GetErrorLine(strLines));
                    return result;
                }

                //NUMERO du centre d'appel
                strLines = WriteAndReadReponse(port, "AT+CSCA=\"" + m_parametre.SmsServiceNumber + "\"", m_parametre.TimeOut);
                if (GetErrorLine(strLines) != null)
                {
                    result.EmpileErreur(GetErrorLine(strLines));
                    return result;
                }

                foreach (string strMessage in strMessages)
                {
                    List<string> lstDestinataires = new List<string>();
                    if (m_parametre.LoopOnRecipients)
                    {
                        foreach (string strDestinataire in message.NumerosDestinataires)
                        {
                            if (strDestinataire.Trim().Length > 0)
                                lstDestinataires.Add(strDestinataire);
                        }
                    }
                    else
                    {
                        StringBuilder bl = new StringBuilder();
                        foreach (string strDestinataire in message.NumerosDestinataires)
                        {
                            if (strDestinataire.Trim().Length > 0)
                            {
                                bl.Append(strDestinataire);
                                bl.Append(';');
                            }
                        }
                        if (bl.Length > 0)
                        {
                            bl.Remove(bl.Length - 1, 1);
                            lstDestinataires.Add(bl.ToString());
                        }
                    }
                    foreach (string strDestinataire in lstDestinataires)
                    {
                        if (strDestinataire.Trim() != "")
                        {
                            port.WriteLine("AT+CMGS=\"" + strDestinataire + "\"");
                            System.Threading.Thread.Sleep(m_parametre.WaitBeforeRead);
                            //Attend le prompt
                            string strPrompt = ReadLineIfExists(port, 500);
                            DateTime dtWaitPrompt = DateTime.Now;
                            while ((strPrompt == null || !strPrompt.Contains("CMGS")) && 
                                ((TimeSpan)(DateTime.Now-dtWaitPrompt)).TotalMilliseconds < m_parametre.TimeOut*3)
                            {
                                strPrompt = ReadLineIfExists(port, 500);
                                System.Threading.Thread.Sleep(500);
                            }
                            if (strPrompt == null || !strPrompt.Contains("CMGS"))
                            {
                                port.WriteLine("\u001A");
                                result.EmpileErreur("Wait prompt timeout");
                                return result;
                            }
                            strLines = strMessage.Split('\r');
                            for (int nLigne = 0; nLigne < strLines.Length; nLigne++)
                            {
                                port.Write(strLines[nLigne]);
                                if (nLigne < strLines.Length - 1)
                                    port.Write(System.Environment.NewLine);
                                System.Threading.Thread.Sleep(m_parametre.WaitBeforeRead);
                            }

                            port.WriteLine("\u001A");
                            System.Threading.Thread.Sleep(m_parametre.WaitBeforeRead);
                            if (m_parametre.Debug)
                            {
                                Console.WriteLine("APRES AT CMGS-------");
                            }
                            strLines = ReadLines(port, 10000);
                            if (GetErrorLine(strLines) != null)
                            {
                                result.EmpileErreur(GetErrorLine(strLines));
                                return result;
                            }
                            if (m_parametre.Debug)
                            {
                                foreach (string strLine in strLines)
                                    Console.Write(strLine);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                result.EmpileErreur(new CErreurException(e));
            }
            finally
            {
                port.Close();
                port.Dispose();
            }
            return result;
        }

        private string GetErrorLine(string[] strLignes)
        {
            foreach (string strLigne in strLignes)
            {
                if (strLigne.ToUpper().Contains("ERROR"))
                    return strLigne;
            }
            return null;
        }

        private string[] WriteAndReadReponse(SerialPort port, string strMessage, int nMaxDelai)
        {
            port.WriteLine(strMessage);
            System.Threading.Thread.Sleep(m_parametre.WaitBeforeRead);
            string[] strLines = ReadLines(port, nMaxDelai);
            if (m_parametre.Debug)
            {
                Console.WriteLine("-------->" + strMessage);
                foreach (string strLigne in strLines)
                    Console.WriteLine(strLigne);
            }
            return strLines;
        }

        public string[] ReadLines(SerialPort port, int nMaxDelai)
        {
            List<string> lst = new List<string>();
            string strRet = ReadLine(port, nMaxDelai);
            lst.Add(strRet);
            while ((strRet = ReadLineIfExists(port, nMaxDelai)) != null)
                lst.Add(strRet);
            return lst.ToArray();
        }

        public string ReadLineIfExists(SerialPort port, int nMaxDelai)
        {
            if (port.BytesToRead != 0)
                return ReadLine(port, nMaxDelai);
            return null;
        }

        private string ReadLine ( SerialPort port, int nMaxDelai )
        {
            ReadPortDelegate del = new ReadPortDelegate(ReadPortAsync);
            IAsyncResult res = del.BeginInvoke ( port, nMaxDelai, null, null);
            while  (!res.IsCompleted)
            {
                System.Threading.Thread.Sleep(100);
            }
            return del.EndInvoke(res);
        }

        void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            
        }

        private delegate string ReadPortDelegate ( SerialPort port, int nMaxDelai );

        private string ReadPortAsync(SerialPort port, int nMaxDelai)
        {
            DateTime dt = DateTime.Now;
            string strRetour = "";
            while (((TimeSpan)(DateTime.Now - dt)).TotalMilliseconds < nMaxDelai && (strRetour.Length < port.NewLine.Length ||
                strRetour.Substring(strRetour.Length - port.NewLine.Length, port.NewLine.Length) != port.NewLine))
            {
                if (port.BytesToRead != 0)
                {
                    strRetour += (char)port.ReadChar();
                    dt = DateTime.Now;
                }
                else
                    System.Threading.Thread.Sleep(10);
            }

            return strRetour;
        }
    }
}
