using System;
using System.Collections.Generic;
using System.Linq;
using sc2i.common;

namespace futurocom.snmp.Mib
{
    /// <summary>
    /// Definition class.
    /// </summary>
    internal class Definition : IDefinition
    {
        private uint[] _id;
        protected string _name;
        private string _module;
        private string _parent;
        private uint _value;
        private IDictionary<uint, IDefinition> _children = new Dictionary<uint, IDefinition>();
        private Definition _parentNode;
        private string _typeString;
        private string _description;
        
        internal Definition()
        {
        }
        
        internal Definition(uint[] id, string name, string parent, string module, string typeString)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id");
            }

            _id = id;
            _name = name;
            _parent = parent;
            _module = module;
            _value = id[id.Length - 1];
            _typeString = typeString;
        }
        
        /// <summary>
        /// Creates a <see cref="Definition"/> instance.
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="entity"></param>
        internal Definition(IEntity entity, Definition parent)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            if (parent == null)
            {
                throw new ArgumentNullException("parent");
            }

            _parentNode = parent;
            uint[] id = string.IsNullOrEmpty(parent.Name) ?
                null : parent._id; // null for root node    (use _id rather than GetNumericalForm to avoid the Clone)
            _id = ObjectIdentifier.AppendTo(id, entity.Value);
            _parent = parent.Name;
            _name = entity.Name;
            _module = entity.ModuleName;
            _value = entity.Value;
            _description = entity.Description;
            _parentNode.Append(this);
            Type = DetermineType(entity.GetType().ToString(), _name, _parentNode);

        }

        internal void DetermineType(IDefinition parent)
        {
            Type = DetermineType(_typeString, _name, parent);
        }
        
        private static DefinitionType DetermineType(string type, string name, IDefinition parent)
        {
            if (type == typeof(OidValueAssignment).ToString()) 
            {
                return DefinitionType.OidValueAssignment;
            }

            if (type == typeof(NotificationType).ToString())
            {
                return DefinitionType.Notification;
            }

            if (type == typeof(ModuleIdentity).ToString())
            {
                return DefinitionType.OidValueAssignment;
            }

            if (type == typeof(TrapType).ToString())
            {
                return DefinitionType.Trap;
            }

            if (type != typeof(ObjectType).ToString())
            {
                return DefinitionType.Unknown;
            }

            if (name.EndsWith("Table", StringComparison.Ordinal))
            {
                return DefinitionType.Table;
            }

            if (name.EndsWith("Entry", StringComparison.Ordinal)) 
            {
                return DefinitionType.Entry;
            }

            return parent.Type == DefinitionType.Entry ? DefinitionType.Column : DefinitionType.Scalar;
        }
        
        /// <summary>
        /// Value.
        /// </summary>
        public uint Value
        {
            get { return _value; }
        }
        
        public string Parent
        {
            get { return _parent; }
            set { }
        }
        
        public IDefinition ParentDefinition
        {
            get
            {
                return _parentNode;
            }

            set
            {
                _parentNode = (Definition)value;
                if (_parentNode != null)
                {
                    _parentNode.Append(this);
                }
            }
        }

        /// <summary>
        /// Children definitions.
        /// </summary>
        public IEnumerable<IDefinition> Children
        {
            get { return _children.Values; }
        }

        public DefinitionType Type { get; private set; }

        internal static Definition RootDefinition
        {
            get { return new Definition(); }
        }
        
        /// <summary>
        /// Returns the textual form.
        /// </summary>
        internal string TextualForm
        {
            get { return _module + "::" + _name; }
        }

        /// <summary>
        /// Indexer.
        /// </summary>
        public IDefinition GetChildAt(uint index)
        {
            // Since this method is very often used (when parsing OID, and so when displaying a MIB tree),
            // we avoid to call d.GetNumericalForm (which clones the uint[] of the OID) but cast 'd' as a Definition
            // and then call directly it _id field (without modifying it of course).
            // Assume all IDefinition are Definition
            return (from Definition d in _children.Values let id = d._id where id[id.Length - 1] == index select d).FirstOrDefault();
        }

        /// <summary>
        /// Module name.
        /// </summary>
        public string ModuleName
        {
            get { return _module; }
        }
        
        /// <summary>
        /// Name.
        /// </summary>
        public string Name
        {
            get { return _name; }
        }
        
        /// <summary>
        /// Gets the numerical form.
        /// </summary>
        /// <returns></returns>
        public uint[] GetNumericalForm()
        {
            return (uint[])_id.Clone();
        }
        
        /// <summary>
        /// Add an <see cref="IEntity"/> node.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public Definition Add(IEntity node)
        {
            // * algorithm 1: recursive
            if (_name == node.Parent)
            {
                /*if (node is TrapType)
                {
                    Definition defParent = _children.Values.FirstOrDefault(n => n.Value == 0) as Definition;
                    if (defParent == null)
                    {
                        OidValueAssignment nodeParent = new OidValueAssignment(_module, I.T("V1 Traps|2010"), _name, 0);
                        defParent = new Definition(nodeParent, this);
                    }
                    return new Definition(node, defParent);
                }
                else*/
                    return new Definition(node, this);
            }

            return (from Definition d in _children.Values select d.Add(node)).FirstOrDefault(result => result != null);

            // */

            /* algorithm 2: put parent locating task outside. slower, so dropped.
            if (_name != node.Parent)
            {
                throw new ArgumentException("this node is not child of mine", "node");
            }
            return new Definition(node, this);
            // */
        }
        
        /// <summary>
        /// Adds a <see cref="Definition"/> child to this <see cref="Definition"/>.
        /// </summary>
        /// <param name="def"></param>
        private void Append(IDefinition def)
        {
            if (!_children.ContainsKey(def.Value))
            {
                _children.Add(def.Value, def);
            }
        }
        
        internal static uint[] GetParent(IDefinition definition)    // Assume all IDefinition are Definition
        {
            uint[] self = ((Definition)definition)._id;        // use _id rather than GetNumericalForm to avoid the Clone.
            uint[] result = new uint[self.Length - 1];
            Array.Copy(self, result, self.Length - 1);            
            return result;
        }
        
        public string Description
        {
            get { return _description; }
        }

        public virtual IEntity Entity 
        {
            get
            {
                if (_parentNode != null)
                    return _parentNode.GetEntity(this);
                return null;
            }

        }

        //--------------------------------------------
        protected virtual IEntity GetEntity(IDefinition definition)
        {
            if (_parentNode != null)
                return _parentNode.GetEntity(definition);
            return null;
        }


        //--------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //--------------------------------------------
        public CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;

            long nLong = 0;

            int nNb = _id == null?0:_id.Length;
            serializer.TraiteInt(ref nNb);
            switch (serializer.Mode)
            {
                case ModeSerialisation.Ecriture:
                    if (_id != null)
                    {
                        foreach (uint nVal in _id)
                        {
                            nLong = (long)nVal;
                            serializer.TraiteLong(ref nLong);
                        }
                    }
                    break;
                case ModeSerialisation.Lecture:
                    _id = new uint[nNb];
                    for (int i = 0; i < nNb; i++)
                    {
                        serializer.TraiteLong(ref nLong);
                        _id[nNb] = (uint)nLong;
                    }
                    break;
            }
            serializer.TraiteString(ref _name);
            serializer.TraiteString(ref _module);
            serializer.TraiteString(ref _parent);

            nLong = (long)_value;
            serializer.TraiteLong(ref nLong);
            _value = (uint)nLong;

            int nCount = _children == null?0:_children.Count;
            serializer.TraiteInt(ref nCount);
            switch (serializer.Mode)
            {
                case ModeSerialisation.Ecriture:
                    foreach (KeyValuePair<uint, IDefinition> kv in _children)
                    {
                        nLong = (long)kv.Key;
                        IDefinition def = kv.Value;
                        serializer.TraiteLong(ref nLong);
                        result = serializer.TraiteObject<IDefinition>(ref def);
                    }
                    break;
                case ModeSerialisation.Lecture:
                    _children.Clear();
                    for (int n = 0; n < nCount; n++)
                    {
                        serializer.TraiteLong(ref nLong);
                        IDefinition def = null;
                        result = serializer.TraiteObject<IDefinition>(ref def);
                        if (!result)
                            return result;
                        def.ParentDefinition = this;
                        _children[(uint)nLong] = def;
                    }
                    break;
            }
            serializer.TraiteString(ref _typeString);
            serializer.TraiteString(ref _description);
            return result;
        }

        //------------------------------------
        public virtual IObjectTree Tree
        {
            get
            {
                if (ParentDefinition != null)
                    return ParentDefinition.Tree;
                return null;
            }
        }





    }

    //---------------------------------------------
    //Definition root dans un arbre
    internal class RootDefinition : Definition
    {
        IObjectTree m_arbre = null;

        internal RootDefinition(IObjectTree arbre)
        {
            m_arbre = arbre;
        }

        internal RootDefinition(
            IObjectTree arbre,
            uint[] id,
            string name,
            string parent,
            string module,
            string typeString)
            : base(id, name, parent, module, typeString)
        {
            m_arbre = arbre;
        }


        protected override IEntity GetEntity(IDefinition definition)
        {
            if ( definition == null || m_arbre == null )
                return null;

            IModule module = m_arbre.GetModule(definition.ModuleName);
            if (module != null)
                return module.Entities.FirstOrDefault(e => e.Name == definition.Name);
            return null;
        }

        //---------------------------------------------------
        public override IObjectTree Tree
        {
            get
            {
                return m_arbre;
            }
        }

        
    }


    //---------------------------------------------
    //Definition root dans un mibmodule
    internal class CMibModuleRootDefinition : RootDefinition
    {
        private const string c_strName = "?";
        IModule m_module = null;


        internal CMibModuleRootDefinition(IObjectTree arbre, IModule module)
            :base ( arbre, new uint[]{0}, c_strName, "", module.Name, "")
        {
            m_module = module;
            CreateChildrens();
        }



        private void CreateChildrens()
        {
            HashSet<string> seen = new HashSet<string>();
            foreach (IEntity entity in m_module.Entities)
            {
                if ( !seen.Contains ( entity.Parent ))
                    entity.Parent = c_strName;
                Add(entity);
                seen.Add(entity.Name);

            }
        }

        
    }


}
