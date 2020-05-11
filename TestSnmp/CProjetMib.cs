using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using futurocom.snmp.Mib;
using futurocom.snmp;

namespace TestSnmp
{
    public class CProjetMib : I2iSerializable
    {
        private List<string> m_listeFichiers = new List<string>();
        private SimpleObjectRegistry m_registry = null;

        private static CProjetMib m_defaultInstance = null;

        private CProjetMib()
        {
        }

        private int GetNumVersion()
        {
            return 0;
        }

        public void AddString(string strFichier)
        {
            if (!m_listeFichiers.Contains(strFichier))
            {
                m_listeFichiers.Add(strFichier);
                ReloadMibs();
            }
        }

        public static CProjetMib Instance
        {
            get
            {
                if (m_defaultInstance == null)
                    m_defaultInstance = new CProjetMib();
                return m_defaultInstance;
            }
            set
            {
                m_defaultInstance = value;
            }
        }



        public CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            int nCount = m_listeFichiers.Count;
            serializer.TraiteInt(ref nCount);
            switch (serializer.Mode)
            {
                case ModeSerialisation.Ecriture:
                    foreach (string strFichier in m_listeFichiers)
                    {
                        string strStmp = strFichier;
                        serializer.TraiteString(ref strStmp);
                    }
                    break;
                    break;
                case ModeSerialisation.Lecture:
                    m_listeFichiers = new List<string>();
                    for (int n = 0; n < nCount; n++)
                    {
                        string strTmp = "";
                        serializer.TraiteString(ref strTmp);
                        m_listeFichiers.Add(strTmp);
                    }
                    break;
            }
            return result;
        }

        //-------------------------------
        public void ReloadMibs()
        {
            m_registry = null;
        }

        //-------------------------------
        public ObjectRegistryBase Mib
        {
            get
            {
                if (m_registry == null)
                {
                    m_registry = new SimpleObjectRegistry();
                    m_registry.CompileFiles(m_listeFichiers);
                }
                return m_registry;
            }
        }

        //-------------------------------
        public string[] LoadedModules
        {
            get{
                List<string> strModules = new List<string>();
                ObjectRegistryBase mib = Mib;
                if ( mib != null )
                {
                    foreach ( string strModule in mib.Tree.LoadedModules )
                        strModules.Add ( strModule );
                    foreach (string strModule in mib.Tree.PendingModules)
                        strModules.Add ("["+strModule+"]" );
                }
                return strModules.ToArray();
            }
        }

        //-------------------------------
        public string[] MissingModules
        {
            get
            {
                HashSet<string> loader = new HashSet<string>(LoadedModules);
                HashSet<string> missing = new HashSet<string>();
                ObjectRegistryBase mib = Mib;
                if (mib != null)
                {
                    foreach (string strModule in mib.Tree.PendingModules)
                    {
                        IModule module = mib.Tree.GetModule(strModule);
                        if (module != null)
                        {
                            foreach (string strDep in module.Dependents)
                            {
                                if (!loader.Contains(strDep))
                                    missing.Add(strDep);
                            }
                        }
                    }
                }
                return missing.ToArray();
            }
        }

        //-------------------------------
        public static CResultAErreur Load(string strFichier)
        {
            CProjetMib projet = new CProjetMib();
            CResultAErreur result = CSerializerObjetInFile.ReadFromFile(projet, "MIBPRJ", strFichier);
            if (result)
                m_defaultInstance = projet;
            return result;
        }

        //-------------------------------
        public static CResultAErreur Save(string strFichier)
        {
            return CSerializerObjetInFile.SaveToFile(Instance, "MIBPRJ", strFichier);
        }
    }
}
