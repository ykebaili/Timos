using futurocom.snmp.entitesnmp;
using sc2i.common;
using sc2i.expression;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace futurocom.snmp.polling
{
    [Serializable]
    [AutoExec("Autoexec")]
    public class CDefinitionProprieteDynamiqueOID : CDefinitionProprieteDynamique
    {
        private const string c_strCleType = "OID";

        //----------------------------------------------------
        public CDefinitionProprieteDynamiqueOID()
            : base()
        {
        }

        //----------------------------------------------------
        public CDefinitionProprieteDynamiqueOID(
            string strOID)
            : base(
                strOID.Replace(".", "_"),
            strOID.Replace(".","_"),
            new CTypeResultatExpression(typeof(object), false),
            false,
            false)
        {
        }

        //--------------------------------------------------------------------------------------------
        public static void Autoexec()
        {
            CInterpreteurProprieteDynamique.RegisterTypeDefinition(c_strCleType, typeof(CInterpreteurProprieteDynamiqueOID));
        }

        //-----------------------------------------------
        public override string CleType
        {
            get { return c_strCleType; }
        }

        /// ////////////////////////////////////////
        private int GetNumVersion()
        {
            return 0;
        }

        /// ////////////////////////////////////////
        public override CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            result = base.Serialize(serializer);
            if (!result)
                return result;
            return result;
        }
    }

    public class CInterpreteurProprieteDynamiqueOID : IInterpreteurProprieteDynamique
    {
        //------------------------------------------------------------
        public bool ShouldIgnoreForSetValue(string strPropriete)
        {
            return false;
        }

        //------------------------------------------------------------
        public IOptimiseurGetValueDynamic GetOptimiseur(Type tp, string strPropriete)
        {
            return null;
        }

        //------------------------------------------------------------
        public CResultAErreur GetValue(object objet, string strPropriete)
        {
            CResultAErreur result = CResultAErreur.True;
            CAgentSnmpPourSupervision agent = objet as CAgentSnmpPourSupervision;
            if (agent == null)
                return result;
            string strOID = strPropriete.Replace("_",".");
            if (agent.HasCacheOID)
                result.Data = agent.GetValeurSNMPEnCache(strOID);
            else
                result.Data = agent.ReadSnmpString(strOID);
            if (result.Data != null && result.Data is ISnmpData)
                result.Data = ((ISnmpData)result.Data).ConvertToTypeDotNet();
            return result;
        }

        //------------------------------------------------------------
        public CResultAErreur SetValue(object objet, string strPropriete, object valeur)
        {
            CResultAErreur result = CResultAErreur.True;
            result.EmpileErreur(I.T("OID fields can not be set|20011"));
            return result;
        }
    }
}
