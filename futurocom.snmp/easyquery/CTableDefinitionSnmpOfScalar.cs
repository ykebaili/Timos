using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using futurocom.easyquery;
using sc2i.common;
using futurocom.easyquery.snmp;
using System.Data;

namespace futurocom.snmp.easyquery
{
    //Contient les valeurs scalaires d'un folder
    [Serializable]
    public class CTableDefinitionSnmpOfScalar : CTableDefinitionBase
    {
        private uint[] m_nOidRacine;
        private string m_strName;
        private bool m_bRemplissageOptimise = true;

        //-----------------------------------
        public CTableDefinitionSnmpOfScalar()
            :base()
        {
        }

        //-----------------------------------
        public CTableDefinitionSnmpOfScalar(CEasyQuerySource laBase)
            : base(laBase)
        {
        }

        //-----------------------------------
        public override string TableName
        {
            get
            {
                return m_strName;
            }
            set
            {
                m_strName = value;
            }
        }

        //-----------------------------------
        public bool RemplissageOptimise
        {
            get
            {
                return m_bRemplissageOptimise;
            }
            set
            {
                m_bRemplissageOptimise = value;
            }
        }

        //-----------------------------------
        public uint[] OIDRacine
        {
            get
            {
                return m_nOidRacine;
            }
            set
            {
                m_nOidRacine = value;
            }
        }

        //-----------------------------------
        public string OIDString
        {
            get
            {
                try
                {
                    return ObjectIdentifier.Convert(OIDRacine);
                }
                catch
                {
                    return "";
                }
            }
            set
            {
                try
                {
                    OIDRacine = ObjectIdentifier.Convert(value);
                }
                catch { }
            }

        }

        //-----------------------------------
        public override string Id
        {
            get { return OIDString; }
        }

        //-----------------------------------
        private int GetNumVersion()
        {
            return 1;
            //1 : ajout de remplissage optimisé
        }

        //-----------------------------------
        public override CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (result)
                result = base.Serialize(serializer);
            if (!result)
                return result;
            string strOID = serializer.Mode == ModeSerialisation.Ecriture ? OIDString : "";
            serializer.TraiteString(ref strOID);
            OIDString = strOID;
            serializer.TraiteString(ref m_strName);
            if (nVersion >= 1)
                serializer.TraiteBool(ref m_bRemplissageOptimise);
            else
                m_bRemplissageOptimise = true;

            return result;
        }

        //-----------------------------------
        public override CResultAErreur GetDatas(CEasyQuerySource source, params string[] strIdsColonnesSources)
        {
            CResultAErreur result = CResultAErreur.True;
            List<string> strCols = new List<string>();
            foreach (IColumnDefinition col in Columns)
            {
                CColumnDefinitionSNMP colSnmp = col as CColumnDefinitionSNMP;
                if (colSnmp != null)
                {
                    if (strIdsColonnesSources.Contains(colSnmp.Id))
                        strCols.Add(colSnmp.OIDString);
                }
            }
            DataTable table = source.GetTable(this, strCols.ToArray());
            result.Data = table;
            return result;
        }
   }
}
