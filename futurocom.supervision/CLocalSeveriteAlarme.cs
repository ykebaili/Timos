using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using sc2i.common;
using sc2i.common.memorydb;
using System.Drawing;


namespace futurocom.supervision
{

    public static class CConvertisseurSeveriteAlarmeToHs
    {
        public const int c_nSeuilHS = 50;

        public static bool IsPrioriteSeveriteHS(int nPriorite)
        {
            return nPriorite >= c_nSeuilHS;
        }
    }

    [MemoryTable(CLocalSeveriteAlarme.c_nomTable, CLocalSeveriteAlarme.c_champId)]
    public class CLocalSeveriteAlarme : CEntiteDeMemoryDb
    {
        public const string c_nomTable = "ALARM_SEVERITY";
        public const string c_champId = "ALRMSEVERITY_ID";
        public const string c_champLibelle = "ALRMSEVERITY_LABEL";
        public const string c_champCode = "ALRMSEVERITY_CODE";
        public const string c_champPriorite = "ALRMSEVERITY_PRIO";
        public const string c_champCodeCouleur = "ALRMSEVERITY_COLCODE";


        public CLocalSeveriteAlarme(CMemoryDb db)
            : base(db)
        {
        }

        public CLocalSeveriteAlarme(DataRow row)
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

        //-----------------------------------------------------------
        public bool IsHS
        {
            get
            {
                return CConvertisseurSeveriteAlarmeToHs.IsPrioriteSeveriteHS(Priorite);
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// Code du Type d'Occupation Horaire
        /// </summary>
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

        //-----------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        [MemoryField(c_champPriorite)]
        [DynamicField("Priority")]
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
        [MemoryField(c_champCodeCouleur)]
        [DynamicField("Color Code")]
        public int CouleurInt
        {
            get
            {
                return Row.Get<int>(c_champCodeCouleur);
            }
            set
            {
                Row[c_champCodeCouleur] = value;
            }
        }

        //----------------------------------------------------------------------
        [DynamicField("Color")]
        public Color Couleur
        {
            get
            {
                return Color.FromArgb(CouleurInt);
            }
            set
            {
                CouleurInt = value.ToArgb();
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
                c_champPriorite,
                c_champCodeCouleur);

            return result;
        }
        
    }
}
