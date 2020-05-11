using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common.memorydb;
using System.Data;
using sc2i.expression;
using sc2i.common;

namespace futurocom.supervision
{

    [MemoryTable(CLocalRelationTypeAlarmeChampAlarme.c_nomTable, CLocalRelationTypeAlarmeChampAlarme.c_champId)]
    public class CLocalRelationTypeAlarmeChampAlarme : CEntiteDeMemoryDb
    {
        public const string c_nomTable = "ALARM_TYPE_FIELD";
        public const string c_champId = "ALRMTPFLD_ID";
        public const string c_champIsKey = "ALRMFLD_IS_KEY";

        //-------------------------------------------------
        public CLocalRelationTypeAlarmeChampAlarme(CMemoryDb db )
            :base ( db )
        {
        }

        //-------------------------------------------------
        public CLocalRelationTypeAlarmeChampAlarme(DataRow row)
            : base(row)
        {
        }

        //-------------------------------------------------
        public override void MyInitValeursParDefaut()
        {
            IsKey = false;
        }

        
        //-------------------------------------------------
        [MemoryField(c_champIsKey)]
        public bool IsKey
        {
            get
            {
                return Row.Get<bool>(c_champIsKey);
            }
            set
            {
                Row[c_champIsKey] = value;
            }
        }

        //-------------------------------------------------
        [MemoryParent(true)]
        public CLocalTypeAlarme TypeAlarme
        {
            get
            {
                return GetParent<CLocalTypeAlarme>();
            }
            set
            {
                SetParent<CLocalTypeAlarme>(value);
            }
        }

        //-------------------------------------------------
        [MemoryParent(true)]
        public CLocalChampTypeAlarme Champ
        {
            get
            {
                return GetParent<CLocalChampTypeAlarme>();
            }
            set
            {
                SetParent<CLocalChampTypeAlarme>(value);
            }
        }

        //-------------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //-------------------------------------------------
        protected override CResultAErreur MySerialize(sc2i.common.C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            if ( result )
                result = SerializeChamps(serializer, 
                    c_champIsKey);
            if (result)
                result = SerializeParent<CLocalTypeAlarme>(serializer);
            if (result)
                result = SerializeParent<CLocalChampTypeAlarme>(serializer);
            return result;
        }

        
    }
}
