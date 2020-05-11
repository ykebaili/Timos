using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using spv.data.SNMP;
using sc2i.common;
using sc2i.multitiers.server;
using Org.Snmp.Snmp_pp;

namespace spv.data.serveur.SNMP
{
    public class CRequeteSNMPServeur : C2iObjetServeur, IRequeteSNMPServeur
    {
        public CRequeteSNMPServeur(int nIdSession)
            : base(nIdSession)
        {
        }

        public CResultAErreur GetValue(CRequeteSnmpOID requeteOID)
        {
            CResultAErreur result = CResultAErreur.True;
            
            string[] args = new string[7];
            args[0] = "get";
            args[1] = requeteOID.IpAgent;
            string strOID = requeteOID.OID;
            //Si l'OID commence par un ., supprime le .
            if (strOID.Length > 0 && strOID[0] == '.')
                strOID = strOID.Substring(1);
            args[2] = "-o" + strOID;
            args[3] = "-Dl0"; //don't make debug
            args[4] = "-c" + requeteOID.Community; //community read
            args[5] = "-t" + requeteOID.TimeOut;
            args[6] = "-r" + requeteOID.NbRetry;

            try
            {
                Hashtable htResult = new Hashtable();
                htResult = Manager.makeOrder(args);
                //Hashtable htResult = Manager.makeOrder(args);
                htResult.Add("value", (string)((Hashtable)htResult[1])["value"]);
                htResult.Add("type", (string)((Hashtable)htResult[1])["type"]);
                result.Data = (string)(htResult["value"]);
            }
            catch (Exception e)
            {
                result.EmpileErreur(new CErreurException(e));
            }
            return result;
        }

        //Renvoie un CVariableSNMPResultat
        public CResultAErreur GetNextValue(CRequeteSnmpOID requeteOID)
        {
            CResultAErreur result = CResultAErreur.True;

            string[] args = new string[7];
            args[0] = "getnext";
            args[1] = requeteOID.IpAgent;
            string strOID = requeteOID.OID;
            //Si l'OID commence par un ., supprime le .
            if (strOID.Length > 0 && strOID[0] == '.')
                strOID = strOID.Substring(1);
            args[2] = "-o" + strOID;
            args[3] = "-Dl0"; //don't make debug
            args[4] = "-c" + requeteOID.Community; //community read
            args[5] = "-t" + requeteOID.TimeOut;
            args[6] = "-r" + requeteOID.NbRetry;

            try
            {
                Hashtable htResult = new Hashtable();
                htResult = Manager.makeOrder(args);

                result.Data = new CVariableSNMPResultat((string)((Hashtable)htResult[1])["value"],
                                                        (string)((Hashtable)htResult[1])["oid"]); ;
            }
            catch (Exception e)
            {
                result.EmpileErreur(new CErreurException(e));
            }
            return result;
        }


        // Pour pouvoir enchaîner les getnext sans avoir à réinitialiser
        private CResultAErreur GetNextInTable(CRequeteSnmpOID requeteOID, string strOID)
        {
            CResultAErreur result = CResultAErreur.True;

            string[] args = new string[7];
            args[0] = "getnext";
            args[1] = requeteOID.IpAgent;
            args[2] = "-o" + strOID;
            args[3] = "-Dl0"; //don't make debug
            args[4] = "-c" + requeteOID.Community; //community read
            args[5] = "-t" + requeteOID.TimeOut;
            args[6] = "-r" + requeteOID.NbRetry;

            try
            {
                Hashtable htResult = new Hashtable();
                htResult = Manager.makeOrder(args);

                result.Data = new CVariableSNMPResultat((string)((Hashtable)htResult[1])["value"],
                                                        (string)((Hashtable)htResult[1])["oid"]); ;
            }
            catch (Exception e)
            {
                result.EmpileErreur(new CErreurException(e));
            }
            return result;
        }


        //Acquisition d'une table complète pour une variable donnée
        //L'OID de départ ne doit pas contenir d'index, il doit
        //contenir l'OID pur de la variable de table
        public CResultAErreur GetTable(CRequeteSnmpOID requeteOID)
        {
            CResultAErreur resultat = CResultAErreur.True;
            CResultAErreur result;

            List<CVariableSNMPResultat> listeResultat = new List<CVariableSNMPResultat>();

            CRequeteSnmpOID reqOID = requeteOID;
            string strOID = requeteOID.OID;
            //Si l'OID commence par un ., supprime le .
            if (strOID.Length > 0 && strOID[0] == '.')
                strOID = strOID.Substring(1);

            string strRootOID = strOID;
            int nLen = strRootOID.Length;

            do
            {
                result = GetNextInTable(requeteOID, strOID);
                
                if (result)
                {
                    CVariableSNMPResultat varResult = (CVariableSNMPResultat)result.Data;
                    strOID = varResult.Oid;
                    if (strOID.Substring(0, nLen) != strRootOID) // on est sorti de la table
                        break;
                    else
                    {
                        listeResultat.Add(varResult);
                        varResult.Index = strOID.Substring(nLen);
                    }
                }
            }
            while (result);

            if (result)
            {
                resultat.Data = listeResultat;
                return resultat;
            }

            return result;
        }


        public CResultAErreur SetValue(CRequeteSnmpOID requeteOID, object valeur)
        {
            CResultAErreur result = CResultAErreur.True;

            string[] args = new string[9];
            args[0] = "set";
            args[1] = requeteOID.IpAgent;
            string strOID = requeteOID.OID;
            //Si l'OID commence par un ., supprime le .
            if (strOID.Length > 0 && strOID[0] == '.')
                strOID = strOID.Substring(1);
            args[2] = "-o" + strOID;
            args[3] = "-Dl0"; //don't make debug
            args[4] = "-C" + requeteOID.Community; //community read
            args[5] = "-t" + requeteOID.TimeOut;
            args[6] = "-r" + requeteOID.NbRetry;
            args[7] = "-T" + ConvertTypeMibObjToTypeLibrairie(requeteOID.Type);
            args[8] = "-V" + Convert.ToString(valeur);

            try
            {
                Hashtable htResult = new Hashtable();
                htResult = Manager.makeOrder(args);
            }
            catch (Exception e)
            {
                result.EmpileErreur(new CErreurException(e));
            }
            return result;
        }


        private string ConvertTypeMibObjToTypeLibrairie(string strSpvType)
        {
            string strType;

            if (strSpvType == CSpvMibobj.OctetString)
                strType = "OctetString";
            else if (strSpvType == CSpvMibobj.INTEGER)
                strType = CSpvMibobj.INTEGER;
            else if (strSpvType == CSpvMibobj.Integer32)
                strType = CSpvMibobj.Integer32;
            else if (strSpvType == CSpvMibobj.Unsigned)
                strType = CSpvMibobj.Unsigned;
            else if (strSpvType == CSpvMibobj.Unsigned32)
                strType = CSpvMibobj.Unsigned32;
            else if (strSpvType == CSpvMibobj.Counter)
                strType = CSpvMibobj.Counter;
            else if (strSpvType == CSpvMibobj.Counter32)
                strType = CSpvMibobj.Counter32;
            else if (strSpvType == CSpvMibobj.Counter64)
                strType = CSpvMibobj.Counter64;
            else if (strSpvType == CSpvMibobj.TimeTicks)
                strType = CSpvMibobj.TimeTicks;
            else if (strSpvType == CSpvMibobj.Gauge)
                strType = CSpvMibobj.Gauge;
            else if (strSpvType == CSpvMibobj.Gauge32)
                strType = CSpvMibobj.Gauge32;
            else if (strSpvType == CSpvMibobj.IpAddress)
                strType = CSpvMibobj.IpAddress;
            else if (strSpvType == CSpvMibobj.BITS)
                strType = CSpvMibobj.BITS;
            else if (strSpvType == CSpvMibobj.Opaque)
                strType = CSpvMibobj.Opaque;
            else if (strSpvType == CSpvMibobj.ObjectIdentifier)
                strType = "oid";
            else
                strType = "OctetString";

            return strType;
        }
    }
}
