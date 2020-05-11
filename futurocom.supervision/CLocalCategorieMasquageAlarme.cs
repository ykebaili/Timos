using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using sc2i.common;
using sc2i.common.memorydb;
using System.Drawing;
using futurocom.supervision.alarmes;


namespace futurocom.supervision
{
    [MemoryTable(CLocalCategorieMasquageAlarme.c_nomTable, CLocalCategorieMasquageAlarme.c_champId)]
    public class CLocalCategorieMasquageAlarme : CEntiteDeMemoryDb
    {
        public const string c_nomTable = "MASKING_CATEGORY";
        public const string c_champId = "MASKCAT_ID";
        public const string c_champLibelle = "MASKCAT_LABEL";
        public const string c_champCode = "MASKCAT_CODE";
        public const string c_champPriorite = "MASKCAT_PRIO";
  

        public CLocalCategorieMasquageAlarme(CMemoryDb db)
            : base(db)
        {
        }

        public CLocalCategorieMasquageAlarme(DataRow row)
            : base(row)
        {
        }

        //-----------------------------------------------------------
        public override void MyInitValeursParDefaut()
        {
            
        }

        //-----------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        [MemoryField(c_champLibelle)]
        [DynamicField("Label")]
        [DescriptionField]
        public string Libelle
        {
            get
            {
                return Row.Get<string>(c_champLibelle);
            }
            set
            {
                Row[c_champLibelle] = value;
            }
        }

        //----------------------------------------------------------------------
        [MemoryField(c_champCode)]
        [DynamicField("Code")]
        public string Code
        {
            get
            {
                return Row.Get<string>(c_champCode);
            }
            set
            {
                Row[c_champCode] = value;
            }
        }

        //----------------------------------------------------------------------
        [MemoryField(c_champPriorite)]
        [DynamicField("Masking Priority")]
        public int Priorite
        {
            get
            {
                return Row.Get<int>(c_champPriorite);
            }
            set
            {
                Row[c_champPriorite] = value;
            }
        }

        //----------------------------------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //----------------------------------------------------------------------
        protected override CResultAErreur MySerialize(C2iSerializer serializer)
        {
            CResultAErreur result = CResultAErreur.True;
            int nVersion = GetNumVersion();
            result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;

            // Sérialise tous les champs
            result = SerializeChamps(serializer,
                c_champLibelle,
                c_champCode,
                c_champPriorite);
                

            return result;
        }
        
    }
}
