using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using log4net;
using System.Data;
using sc2i.common;

namespace futurocom.snmp.Mib
{
    /// <summary>
    /// Object tree class.
    /// </summary>
    internal sealed class ObjectTree : IObjectTree
    {
        private readonly IDictionary<string, MibModule> _loaded = new Dictionary<string, MibModule>();
        private readonly IDictionary<string, MibModule> _pendings = new Dictionary<string, MibModule>();
        private readonly IDictionary<string, Definition> _nameTable;
        private RootDefinition _root;
        private readonly IDictionary<string, ITypeAssignment> _types = new Dictionary<string, ITypeAssignment>();
        private readonly IDictionary<string, TrapType> _traps = new Dictionary<string, TrapType>();
        private static readonly ILog Logger = LogManager.GetLogger("futurocom.snmp.Mib");
        
        /// <summary>
        /// Creates an <see cref="ObjectTree"/> instance.
        /// </summary>
        public ObjectTree()
        {
            _root = new RootDefinition(this);
            Definition ccitt = new Definition(new OidValueAssignment("SNMPV2-SMI", "ccitt", null, 0), _root);
            Definition iso = new Definition(new OidValueAssignment("SNMPV2-SMI", "iso", null, 1), _root);
            Definition jointIsoCcitt = new Definition(new OidValueAssignment("SNMPV2-SMI", "joint-iso-ccitt", null, 2), _root);
            _nameTable = new Dictionary<string, Definition>
                             {
                                 { iso.TextualForm, iso },
                                 { ccitt.TextualForm, ccitt },
                                 { jointIsoCcitt.TextualForm, jointIsoCcitt }
                             };
        }
        
        public ObjectTree(ICollection<ModuleLoader> loaders) : this()
        {
            if (loaders == null)
            {
                throw new ArgumentNullException("loaders");
            }
            
            Logger.InfoFormat(CultureInfo.InvariantCulture, "{0} module files found", loaders.Count);

            List<Definition> defines = new List<Definition>();
            foreach (ModuleLoader loader in loaders)
            {
                Import(loader.Module);
                defines.AddRange(loader.Nodes);
            }
            
            AddNodes(defines);
            Refresh();
        }
        
        public ObjectTree(IEnumerable<string> files) : this(PrepareFiles(files))
        {
        }
        
        private static ICollection<ModuleLoader> PrepareFiles(IEnumerable<string> files)
        {
            if (files == null)
            {
                throw new ArgumentNullException("files");
            }

            IList<ModuleLoader> result = new List<ModuleLoader>();
            foreach (string file in files)
            {
                if (!File.Exists(file))
                {
                    continue;
                }

                string moduleName = Path.GetFileNameWithoutExtension(file);
                using (StreamReader reader = new StreamReader(file))
                {
                    result.Add(new ModuleLoader(reader, moduleName));
                    reader.Close();
                }
            }

            return result;
        }
        
        /// <summary>
        /// Root definition.
        /// </summary>
        public IDefinition Root
        {
            get
            {
                return _root;
            }
        }

        public IDefinition Find(string moduleName, string name)
        {
            string full = moduleName + "::" + name;
            return _nameTable.ContainsKey(full) ? _nameTable[full] : null;
        }

        public IDefinition Find(string name)
        {
            return (from key in _nameTable.Keys
                    where String.CompareOrdinal(key.Split(new[] {"::"}, StringSplitOptions.None)[1], name) == 0
                    select _nameTable[key]).FirstOrDefault();
        }

        public IDefinition FindKnownParent(IList<uint> numerical)
        {
            List<uint> lstOID = new List<uint>(numerical);
            while (lstOID.Count > 0)
            {
                IDefinition def = Find(lstOID);
                if (def != null)
                    return def;
                lstOID.RemoveAt(lstOID.Count - 1);
            }
            return null;
        }


        public IDefinition Find(IList<uint> numerical)
        {
            if (numerical == null)
            {
                throw new ArgumentNullException("numerical");
            }
            
            if (numerical.Count == 0)
            {
                throw new ArgumentException("numerical cannot be empty");
            }
            
            Definition result = _root;
// ReSharper disable LoopCanBePartlyConvertedToQuery
            foreach (uint digit in numerical)
// ReSharper restore LoopCanBePartlyConvertedToQuery
            {
                Definition temp = result.GetChildAt(digit) as Definition;
                if (temp == null)
                {
                    return null;
                }

                result = temp;
            }

            return result;
        }

        public SearchResult Search(uint[] id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id");
            }

            if (id.Length == 0)
            {
                throw new ArgumentException("numerical cannot be empty");
            }

            IDefinition result = _root;
            int end = id.Length;
            for (int i = 0; i < id.Length; i++)
            {
                IDefinition temp = result.GetChildAt(id[i]);
                if (temp == null)
                {
                    end = i;
                    break;
                }

                result = temp;
            }

            List<uint> remaining = new List<uint>();
            for (int j = end; j < id.Length; j++)
            {
                remaining.Add(id[j]);
            }

            return new SearchResult(result, remaining.ToArray());
        }

        private bool CanParse(MibModule module)
        {
            if (!MibModule.AllDependentsAvailable(module, _loaded))
            {
                return false;
            }
            
            bool exists = _loaded.ContainsKey(module.Name); // FIXME: don't parse the same module twice now.
            if (!exists)
            {
                _loaded.Add(module.Name, module);
            }

            return true;
        }

        private void Parse(IModule module)
        {
            Stopwatch watch = new Stopwatch();
            AddTypes(module);
            AddTraps(module);
            AddNodes(module);
            Logger.InfoFormat(CultureInfo.InvariantCulture, "{0}-ms used to assemble {1}", watch.ElapsedMilliseconds, module.Name);
            watch.Stop();
        }

        private void AddTypes(IModule module)
        {
            foreach (KeyValuePair<string, ITypeAssignment> pair in module.Types)
            {
                if (!_types.ContainsKey(pair.Key))
                {
                    _types.Add(pair);
                }
            }
        }

        //---------------------------------------------
        private void AddTraps(IModule module)
        {
            foreach (TrapType trap in module.Traps)
            {
                if (!_traps.ContainsKey(trap.Name))
                    _traps.Add(trap.Name, trap);
            }
        }

        //---------------------------------------------
        public IEnumerable<TrapType> Traps
        {
            get
            {
                return _traps.Values;
            }
        }

        private Definition CreateSelf(IEntity node)
        {
            ObjectType o = node as ObjectType;
            if (o != null)
            {
                TypeAssignment syn = o.Syntax as TypeAssignment;
                if (syn != null && _types.ContainsKey(syn.Value))
                {
                    o.Syntax = _types[syn.Value];
                }
            }
            /* algorithm 2: slower, dropped
            IDefinition parent = Find(node.Parent);
            if (parent == null)
            {
                return null;
            }

            return ((Definition)parent).Add(node);
            // */
            
            // * algorithm 1
            return _root.Add(node);
            
            // */
        }

        private void AddNodes(IModule module)
        {
            List<IEntity> pendingNodes = new List<IEntity>();
            
            // parse all direct nodes.
            foreach (IEntity node in module.Entities)
            {
                if (node.Parent.Contains("."))
                {
                    pendingNodes.Add(node);
                    continue;
                }
                
                Definition result = CreateSelf(node);
                if (result == null)
                {
                    pendingNodes.Add(node);
                    continue;
                }

                AddToTable(result);
            }

            // parse indirect nodes.
            int current = pendingNodes.Count;
            while (current != 0)
            {
                List<IEntity> parsed = new List<IEntity>();
                int previous = current;
                foreach (IEntity node in pendingNodes)
                {
                    if (node.Parent.Contains("."))
                    {
                        if (!FirstNodeExists(node))
                        {
                            // wait till first node available.
                            continue;
                        }

                        // create all place holders.
                        IDefinition unknown = CreateExtraNodes(module.Name, node.Parent);
                        if (unknown != null)
                        {
                            string strOld = node.Parent;
                            node.Parent = unknown.Name;
                            AddToTable(CreateSelf(node));
                            node.Parent = strOld;
                        }

                    }
                    else
                    {
                        Definition result = CreateSelf(node);
                        if (result == null)
                        {
                            // wait for parent
                            continue;
                        }

                        AddToTable(result);
                    }
                    
                    parsed.Add(node);
                }
                
                foreach (IEntity en in parsed)
                {
                    pendingNodes.Remove(en);
                }

                current = pendingNodes.Count;
                if (previous == current)
                {
                    break;
                }
            }
        }

        private bool FirstNodeExists(IEntity node)
        {
            return Find(ExtractName(node.Parent.Split('.')[0])) != null;
        }

        private Definition CreateExtraNodes(string module, string longParent)
        {
            string[] content = longParent.Split('.');
            Definition node = Find(ExtractName(content[0])) as Definition;
            uint[] rootId = node.GetNumericalForm();
            uint[] all = new uint[content.Length + rootId.Length - 1];
            for (int j = rootId.Length - 1; j >= 0; j--)
            {
                all[j] = rootId[j];
            }
            
            // change all to numerical
            for (int i = 1; i < content.Length; i++)
            {
                uint value;
                bool numberFound = UInt32.TryParse(content[i], out value);
                int currentCursor = rootId.Length + i - 1;
                if (numberFound)
                {
                    all[currentCursor] = value;
                    node = Find(ExtractParent(all, currentCursor + 1)) as Definition;
                    if (node != null)
                    {
                        continue;
                    }

                    IDefinition subroot = Find(ExtractParent(all, currentCursor));
                    
                    // if not, create Prefix node.
                    IEntity prefix = new OidValueAssignment(module, subroot.Name + "_" + value.ToString(CultureInfo.InvariantCulture), subroot.Name, value);
                    node = CreateSelf(prefix);
                    AddToTable(node);
                }
                else
                {
                    string self = content[i];
                    string parent = content[i - 1];
                    IEntity extra = new OidValueAssignment(module, ExtractName(self), ExtractName(parent), ExtractValue(self));
                    node = CreateSelf(extra);
                    if (node != null)
                    {
                        AddToTable(node);
                        all[currentCursor] = node.Value;
                    }
                    else
                    {
                        Logger.InfoFormat(CultureInfo.InvariantCulture, "ignored {0} in module {1}", longParent, module);
                    }
                }
            }

            return node;
        }

        private static uint[] ExtractParent(IList<uint> input, int length)
        {
            uint[] result = new uint[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = input[i];
            }
            
            return result;
        }
        
        private void AddToTable(Definition result)
        {
            if (result != null && !_nameTable.ContainsKey(result.TextualForm))
            {
                _nameTable.Add(result.TextualForm, result);
            }
        }

        public void Refresh()
        {
            Logger.Info("loading modules started");
            Stopwatch watch = new Stopwatch();
            watch.Start();
            int current = _pendings.Count;
            while (current != 0)
            {
                int previous = current;
                IList<string> parsed = new List<string>();
                foreach (MibModule pending in
                    from pending in _pendings.Values let succeeded = CanParse(pending) where succeeded select pending)
                {
                    Parse(pending);
                    parsed.Add(pending.Name);
                }

                foreach (string file in parsed)
                {
                    _pendings.Remove(file);
                }

                current = _pendings.Count;
                Logger.InfoFormat(CultureInfo.InvariantCulture, "{0} pending after {1}-ms", current, watch.ElapsedMilliseconds);
                if (current == previous)
                {
                    // cannot parse more
                    break;
                }
            }
            
            watch.Stop();
            
            foreach (string loaded in _loaded.Keys)
            {
                Logger.InfoFormat(CultureInfo.InvariantCulture, "{0} is parsed", loaded);
            }
            
            foreach (MibModule module in _pendings.Values)
            {
                StringBuilder builder = new StringBuilder(module.Name);
                builder.Append(" is pending. Missing dependencies: ");
                foreach (string depend in module.Dependents.Where(depend => !LoadedModules.Contains(depend)))
                {
                    builder.Append(depend).Append(' ');
                }
                
                Logger.Info(builder.ToString());
            }
            
            Logger.Info("loading modules ended");
        }

        public void Import(IEnumerable<IModule> modules)
        {
            if (modules == null)
            {
                throw new ArgumentNullException("modules");
            }
            
            foreach (MibModule module in modules)
            {
                if (LoadedModules.Contains(module.Name) || PendingModules.Contains(module.Name))
                {
                    Logger.InfoFormat(CultureInfo.InvariantCulture, "{0} ignored", module.Name);
                    continue;
                }

                _pendings.Add(module.Name, module);
            }
        }

        private void Import(MibModule module)
        {
            if (module == null)
            {
                throw new ArgumentNullException("module");
            }

            if (LoadedModules.Contains(module.Name) || PendingModules.Contains(module.Name))
            {
                Logger.InfoFormat(CultureInfo.InvariantCulture, "{0} ignored", module.Name);
            }
            else
            {
                _pendings.Add(module.Name, module);
            }
        }

        /// <summary>
        /// Loaded MIB modules.
        /// </summary>
        public ICollection<string> LoadedModules
        {
            get { return _loaded.Keys; }
        }
        
        /// <summary>
        /// Pending MIB modules.
        /// </summary>
        public ICollection<string> PendingModules
        {
            get { return _pendings.Keys; }
        }

        private void AddNodes(IEnumerable<Definition> nodes)
        {
            List<Definition> pendings = new List<Definition>(nodes);
            int current = pendings.Count;
            while (current != 0)
            {
                int previous = current;
                List<Definition> parsed = new List<Definition>();
                foreach (Definition node in pendings)
                {
                    IDefinition parent = Find(Definition.GetParent(node));
                    if (parent == null)
                    {
                        continue;
                    }

                    node.DetermineType(parent);
                    node.ParentDefinition = parent;
                    AddToTable(node);
                    parsed.Add(node);
                }

                foreach (Definition d in parsed)
                {
                    pendings.Remove(d);
                }

                current = pendings.Count;
                if (current == previous)
                {
                    break;
                }
            }
        }
        
        #region IObjectTree Members

        public void Remove(string moduleName)
        {
            if (_loaded.ContainsKey(moduleName))
            {
                _loaded.Remove(moduleName);
            }

            if (_pendings.ContainsKey(moduleName))
            {
                _pendings.Remove(moduleName);
            }

            // TODO: remove all those nodes
        }

        public IModule GetModule ( string strModuleName )
        {
            MibModule module = null;
            if (!_loaded.TryGetValue(strModuleName, out module))
                _pendings.TryGetValue(strModuleName, out module);
            return module;
        }
                    

        #endregion

        /// <summary>
        /// Extracts the name.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        internal static string ExtractName(string input)
        {
            int left = input.IndexOf('(');
            return left == -1 ? input : input.Substring(0, left);
        }

        /// <summary>
        /// Extracts the value.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        internal static uint ExtractValue(string input)
        {
            int left = input.IndexOf('(');
            int right = input.IndexOf(')');
            if (left >= right)
            {
                throw new FormatException("input does not contain a value");
            }

            uint temp;
            if (UInt32.TryParse(input.Substring(left + 1, right - left - 1), out temp))
            {
                return temp;
            }

            throw new FormatException("input does not contain a value");
        }

        /// <summary>
        /// Decodes a variable using the loaded definitions to the best type.
        /// 
        /// Depending on the variable and loaded MIBs can return:
        ///     * Double
        ///     * Int32
        ///     * UInt32
        ///     * UInt64
        /// </summary>
        /// <param name="v">The variable to decode the value of.</param>
        /// <returns>The best result based on the loaded MIBs.</returns>
        public object Decode(Variable v)
        {
            var def = Search(v.Id.ToNumerical()).Definition;
            ObjectType o = def.Entity as ObjectType;

            if (o == null) { return null; }

            TextualConvention tc = o.Syntax as TextualConvention;

            if (tc == null) { return null; }

            return tc.Decode(v);
        }


        //-----------------------------------------------------
        public void ResolveTableColumnsNames(DataTable table)
        {
            foreach (DataColumn col in table.Columns)
            {
                string strNom = col.ColumnName;
                uint[] oid = ObjectIdentifier.Convert(strNom);
                if (oid.Length > 0)
                {
                    SearchResult result = Search(oid);
                    if (result != null && result.Definition != null)
                        col.ColumnName = result.Definition.Name;
                }
            }
        }

        //-----------------------------------------------------
        private int GetNumVersion()
        {
            return 1;
            //V1 : Ajout de _traps;
        }

        //-----------------------------------------------------
        private CResultAErreur TraiteDictionnaryStringToSerializable<T> ( C2iSerializer serializer, IDictionary<string, T> dic )
            where T : I2iSerializable
        {
            CResultAErreur result = CResultAErreur.True;
            int nNb = dic == null?0:dic.Count();
            serializer.TraiteInt ( ref nNb );
            switch ( serializer.Mode )
            {
                case ModeSerialisation.Ecriture :
                    if ( dic != null )
                        foreach ( KeyValuePair<string, T> kv in dic )
                        {
                            string strVal = kv.Key;
                            T val = kv.Value;
                            serializer.TraiteString ( ref strVal );
                            result = serializer.TraiteObject<T>(ref val);
                            if (!result )
                                return result;
                        }   
                    break;
                case ModeSerialisation.Lecture :
                    dic.Clear();
                    for ( int n = 0; n < nNb; n++ )
                    {
                        string strKey = "";
                        T val = default(T);
                        serializer.TraiteString ( ref strKey );
                        result = serializer.TraiteObject<T>(ref val );
                        if ( !result )
                            return result;
                        dic[strKey] = val;
                    }
                    break;
            }
            return result;
        }

        //-----------------------------------------------------
        public CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;

            result = TraiteDictionnaryStringToSerializable<MibModule>(serializer, _loaded);
            if (result)
                result = TraiteDictionnaryStringToSerializable<MibModule>(serializer, _pendings);
            if (result)
                result = TraiteDictionnaryStringToSerializable<Definition>(serializer, _nameTable);
            if (result)
            {
                result = serializer.TraiteObject<RootDefinition>(ref _root, this);
            }
            if (result)
                result = TraiteDictionnaryStringToSerializable<ITypeAssignment>(serializer, _types);
            if (result && nVersion >= 1)
                result = TraiteDictionnaryStringToSerializable<TrapType>(serializer, _traps);

            return result;
        }
            


            

    }
}
