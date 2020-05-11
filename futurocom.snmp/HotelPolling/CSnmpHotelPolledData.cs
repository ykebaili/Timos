using data.hotel.client;
using futurocom.snmp.entitesnmp;
using futurocom.snmp.polling;
using sc2i.common;
using sc2i.expression;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace futurocom.snmp.HotelPolling
{
    [Serializable]
    public class CSnmpHotelPolledData : I2iSerializable
    {
        private C2iExpression m_formulePolling = null;
        private string m_strEntityId = "";
        private string m_strHotelTable = "";
        private string m_strHotelField = "";

        //------------------------------------------------------------
        public CSnmpHotelPolledData()
        {

        }

        //------------------------------------------------------------
        public CSnmpHotelPolledData(
            C2iExpression formulePolling,
            string strEntityId,
            string strHotelTable,
            string strHotelField)
        {
            m_formulePolling = formulePolling;
            m_strEntityId = strEntityId;
            m_strHotelTable = strHotelField;
            m_strHotelField = strHotelField;
        }

        //------------------------------------------------------------
        public C2iExpression Formule
        {
            get
            {
                return m_formulePolling;
            }
            set
            {
                m_formulePolling = value;
            }
        }

        //------------------------------------------------------------
        public string EntityId
        {
            get
            {
                return m_strEntityId;
            }
            set
            {
                m_strEntityId = value;
            }
        }

        //------------------------------------------------------------
        public string HotelTable
        {
            get
            {
                return m_strHotelTable;
            }
            set
            {
                m_strHotelTable = value;
            }
        }

        //------------------------------------------------------------
        public string HotelField
        {
            get
            {
                return m_strHotelField;
            }
            set
            {
                m_strHotelField = value;
            }
        }

        //------------------------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //------------------------------------------------------------
        public CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            result = serializer.TraiteObject<C2iExpression>(ref m_formulePolling);
            if (!result)
                return result;
            serializer.TraiteString(ref m_strEntityId);
            serializer.TraiteString(ref m_strHotelTable);
            serializer.TraiteString(ref m_strHotelField);
            return result;
        }

        //----------------------------------------------------------------------
        internal CResultAErreur DoPoll(
            CDataHotelClient client, 
            CAgentSnmpPourSupervision agent)
        {
            CResultAErreur result = CResultAErreur.True;
            if (m_formulePolling != null)
            {
                try
                {
                    CContexteEvaluationExpression ctx = new CContexteEvaluationExpression(agent);
                    result = m_formulePolling.Eval(ctx);
                    if (!result || result.Data == null)
                    {
                        result.EmpileErreur("Error while polling " + HotelTable + "." + HotelField);
                        return result;
                    }
                    double? fVal = result.Data as double?;
                    if (fVal == null)
                    {
                        fVal = result.Data as Int32?;
                        if (fVal == null)
                        {
                            fVal = Convert.ToDouble(result.Data);
                        }
                    }
                    if (fVal != null)
                    {
                        client.GetRoomServer().SendData(
                            HotelTable,
                            HotelField,
                            EntityId,
                            DateTime.Now,
                            fVal.Value);
                    }
                }
                catch (Exception e)
                {
                    result.EmpileErreur(new CErreurException(e));
                    result.EmpileErreur("Error while polling " + HotelTable + "." + HotelField);
                    return result;
                }
            }
            return result;
        }

        //----------------------------------------------------------------------
        internal void ExtractOids(HashSet<string> strOids)
        {
            if ( Formule != null )
            {
                ArrayList lstChamps =  Formule.ExtractExpressionsType(typeof(C2iExpressionChamp));
                foreach ( C2iExpressionChamp champ in lstChamps )
                {
                    CDefinitionProprieteDynamiqueOID defOID = champ.DefinitionPropriete as CDefinitionProprieteDynamiqueOID;
                    if ( defOID != null )
                    {
                        strOids.Add(defOID.NomProprieteSansCleTypeChamp.Replace("_", "."));
                    }
                }
                
            }
        }
    }

    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    [Serializable]
    public class CListeSnmpHotelPolledData : List<CSnmpHotelPolledData>, I2iSerializable
    {

        //----------------------------------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }


        //----------------------------------------------------------------------
        public CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteListe<CSnmpHotelPolledData>(this);
            return result;
        }
    }
}
