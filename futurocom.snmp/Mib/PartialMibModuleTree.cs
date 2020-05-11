using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;

namespace futurocom.snmp.Mib
{
    public class PartialMibModuleTree : IObjectTree
    {
        private IModule m_module = null;
        private IDefinition m_root = null;
        private Dictionary<string, IDefinition> m_dicDefinitions = new Dictionary<string,IDefinition>();

        //--------------------------------------------------------
        public PartialMibModuleTree ( IModule module )
        {
            m_module = module;
            m_root = new CMibModuleRootDefinition(this, module);
            FillDicDefinitions ( m_root );
        }

        //--------------------------------------------------------
        private void FillDicDefinitions( IDefinition def)
        {
            if ( def.Name != null )
                m_dicDefinitions[def.Name] = def;
            foreach ( IDefinition child in def.Children )
                FillDicDefinitions ( child );
        }

        //--------------------------------------------------------
        public IDefinition Root
        {
            get { return m_root; }
        }

        //--------------------------------------------------------
        public IEnumerable<TrapType> Traps
        {
            get
            {
                return new List<TrapType>();
            }
        }

        //--------------------------------------------------------
        public ICollection<string> LoadedModules
        {
            get 
            { 
                List<string> lst = new List<string>();
                if ( m_module != null )
                    lst.Add ( m_module.Name );
                return lst.AsReadOnly();
            }
        }

        //--------------------------------------------------------
        public ICollection<string> PendingModules
        {
            get { return new List<string>(); }
        }

        //--------------------------------------------------------
        public IModule GetModule(string strModuleName)
        {
            if ( m_module != null && m_module.Name == strModuleName )
                return m_module;
            return null;
        }

        //--------------------------------------------------------
        public IDefinition Find(string moduleName, string name)
        {
            IDefinition retour = null;
            m_dicDefinitions.TryGetValue ( name, out retour );
            return retour;
        }

        //--------------------------------------------------------
        public IDefinition Find(string name)
        {
            return Find ( null, name );
        }

        //--------------------------------------------------------
        public IDefinition Find(IList<uint> oid)
        {
            return null;
        }

        public IDefinition FindKnownParent(IList<uint> numerical)
        {
            return null;
        }

        public void Remove(string moduleName)
        {
        }

        public void Import(IEnumerable<IModule> modules)
        {
        }

        public void Refresh()
        {
        }

        public SearchResult Search(uint[] id)
        {
            return new SearchResult(null);
        }

        public object Decode(Variable variable)
        {
            return null;
        }

        public void ResolveTableColumnsNames(System.Data.DataTable table)
        {
        }


        public sc2i.common.CResultAErreur Serialize(sc2i.common.C2iSerializer serializer)
        {
            CResultAErreur result = CResultAErreur.True;
            result.EmpileErreur("Partial mib module tree serialization is not implemented");
            return result;
        }
    }
}
