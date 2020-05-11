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

    [MemoryTable(CLocalChampTypeAlarme.c_nomTable, CLocalChampTypeAlarme.c_champId)]
    public class CLocalChampTypeAlarme : CEntiteDeMemoryDb
    {
        public const string c_nomTable = "ALARM_FIELD";
        public const string c_champNom = "ALRMFLD_NAME";
        public const string c_champId = "ALRMFLD_ID";
        public const string c_champType = "ALRMFLD_TYPE";

        //-------------------------------------------------
        public CLocalChampTypeAlarme(CMemoryDb db )
            :base ( db )
        {
        }

        //-------------------------------------------------
        public CLocalChampTypeAlarme(DataRow row)
            : base(row)
        {
        }

        //-------------------------------------------------
        public override void MyInitValeursParDefaut()
        {
        }

        //-------------------------------------------------
        [MemoryField(c_champNom)]
        public string NomChamp
        {
            get
            {
                return Row.Get<string>(c_champNom);
            }
            set
            {
                Row[c_champNom] = value;
            }
        }

        //-------------------------------------------------
        [MemoryField(c_champType)]
        public ETypeChampBasique TypeDonnee
        {
            get
            {
                return Row.Get<ETypeChampBasique>(c_champType);
            }
            set
            {
                Row[c_champType] = value;
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
                    c_champNom,
                    c_champType);
            return result;
        }

        
    }
}
