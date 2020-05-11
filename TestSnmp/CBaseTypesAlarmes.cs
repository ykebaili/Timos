using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using futurocom.supervision;
using futurocom.snmp.alarme;
using futurocom.snmp.entitesnmp;

namespace TestSnmp
{
    public class CBaseTypesAlarmes : I2iSerializable, IBaseTypesAlarmes
    {
        private static string c_strCleFichier = "BASE_TYPE_ALARMES";
        private List<CTestTypeAlarme> m_listeTypesAlarmes = new List<CTestTypeAlarme>();

        private static CBaseTypesAlarmes m_instance = null;

        private CTypeAgentSnmpLocal m_traps = new CTypeAgentSnmpLocal();

        private CBaseTypesAlarmes()
        {
        }

        public static CBaseTypesAlarmes Instance
        {
            get
            {
                if (m_instance == null)
                    m_instance = new CBaseTypesAlarmes();
                return m_instance;
            }
        }

        private int GetNumVersion()
        {
            return 1;
        }

        private void AddType ( CTestTypeAlarme type )
        {
            if (type == null)
                return;
            m_listeTypesAlarmes.Add ( type );
            foreach ( ITypeAlarme typeChild in type.TypesFils )
                AddType ( typeChild as CTestTypeAlarme );
        }

        public CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            List<CTestTypeAlarme> lst = new List<CTestTypeAlarme>(from tp in m_listeTypesAlarmes where tp.TypeParent == null select tp);
            result = serializer.TraiteListe<CTestTypeAlarme>(lst);
            if (serializer.Mode == ModeSerialisation.Lecture)
            {
                m_listeTypesAlarmes.Clear();
                foreach (ITypeAlarme typeAlarme in lst)
                {
                    AddType(typeAlarme as CTestTypeAlarme);
                }
            }
            if (!result)
                return result;
            if ( nVersion >= 1 )
            {
                result = serializer.TraiteObject<CTypeAgentSnmpLocal>(ref m_traps);
                if ( !result )
                    return result;
            }
            return result;
        }

        //--------------------------------------
        public void AddTypeAlarme(CTestTypeAlarme typeAlarme)
        {
            m_listeTypesAlarmes.Add(typeAlarme);
        }


        //--------------------------------------
        public void RemoveTypeAlarme(CTestTypeAlarme typeAlarme)
        {
            m_listeTypesAlarmes.Remove(typeAlarme);
        }

        //--------------------------------------
        public static CResultAErreur Load(string strFichier)
        {
            CBaseTypesAlarmes baseTemp = new CBaseTypesAlarmes();
            CResultAErreur result = CSerializerObjetInFile.ReadFromFile(baseTemp, c_strCleFichier, strFichier);
            if (result)
            {
                m_instance = baseTemp;
                CCurentBaseTypesAlarmes.SetCurrentBase(m_instance);
            }
            return result;
        }

        //--------------------------------------
        public static CResultAErreur Save(string strFichier)
        {
            CResultAErreur result = CSerializerObjetInFile.SaveToFile(Instance, c_strCleFichier, strFichier);
            return result;
        }


        //--------------------------------------
        public IEnumerable<ITypeAlarme> TypesAlarmes
        {
            get 
            {
                return m_listeTypesAlarmes.ConvertAll(t => (ITypeAlarme)t).AsReadOnly();
            }
        }

        //--------------------------------------
        public CTypeAgentSnmpLocal BaseTraps
        {
            get
            {
                return m_traps;
            }
        }

        //--------------------------------------
        public ITypeAlarme GetTypeAlarme(string strIdTypeAlarme)
        {
            return m_listeTypesAlarmes.FirstOrDefault(ta => ta.Id == strIdTypeAlarme);
        }

    }
}
