﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;

namespace futurocom.snmp.Mib
{
    class Counter64Type : ITypeAssignment
    {
        private string _module;
        private string _name;

        public Counter64Type()
        {
        }

        public SnmpType SnmpType
        {
            get
            {
                return SnmpType.Counter64 ;
            }
        }

        public Counter64Type(string module, string name, Lexer lexer)
        {
            _module = module;
            _name = name;
        }

        public Counter64Type(string module, string name, IEnumerator<Symbol> enumerator)
        {
            _module = module;
            _name = name;
        }

        public string Name
        {
            get { return _name; }
        }

        //---------------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //---------------------------------------------------
        public CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            serializer.TraiteString(ref _module);
            serializer.TraiteString(ref _name);
            return result;
        }
    }
}
