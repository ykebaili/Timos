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
    [MemoryTable(CLocalParametrageFiltrageAlarmes.c_nomTable, CLocalParametrageFiltrageAlarmes.c_champId)]
    public class CLocalParametrageFiltrageAlarmes : CEntiteDeMemoryDb, IParametrageFiltrageAlarmes
    {
        public const string c_nomTable = "ALARM_FILTER";
        public const string c_champId = "ALRMFILTER_ID";
        public const string c_champLibelle = "ALRMFILTER_LABEL";
        public const string c_champParametre = "ALRMFILTER_SETTING";
        public const string c_champIsActif = "ALRMFILTER_ENABLED";
        public const string c_champIgnorerEnBase = "ALRMFILTER_IGNORE_DB";
        public const string c_champDateDebutValidite = "ALRMFILTER_STARTDATE";
        public const string c_champDateFinValidite = "ALRMFILTER_ENDDATE";
        

        public CLocalParametrageFiltrageAlarmes(CMemoryDb db)
            : base(db)
        {
        }

        public CLocalParametrageFiltrageAlarmes(DataRow row)
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
        /// <summary>
        /// 
        /// </summary>
        [MemoryField(c_champIsActif)]
        [DynamicField("Enabled")]
        public bool Enabled
        {
            get
            {
                return Row.Get<bool>(c_champIsActif);
            }
            set
            {
                Row[c_champIsActif] = value;
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        [MemoryField(c_champDateDebutValidite)]
        [DynamicField("Validity Start Date")]
        public DateTime DateDebutValidite
        {
            get
            {
                return Row.Get<DateTime>(c_champDateDebutValidite);
            }
            set
            {
                Row[c_champDateDebutValidite] = value;
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        [MemoryField(c_champDateFinValidite)]
        [DynamicField("Validity End Date")]
        public DateTime DateFinValidite
        {
            get
            {
                return Row.Get<DateTime>(c_champDateFinValidite);
            }
            set
            {
                Row[c_champDateFinValidite] = value;
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        [MemoryField(c_champIgnorerEnBase)]
        [DynamicField("Ignore In Database")]
        public bool IgnorerEnBase
        {
            get
            {
                return Row.Get<bool>(c_champIgnorerEnBase);
            }
            set
            {
                Row[c_champIgnorerEnBase] = value;
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        [MemoryField(c_champParametre)]
        [DynamicField("Filter Setting")]
        public CParametreFiltrageAlarmes Parametre
        {
            get
            {
                return Row.Get<CParametreFiltrageAlarmes>(c_champParametre);
            }
            set
            {
                Row[c_champParametre] = value;
            }
        }

        //---------------------------------------------------------------
        [MemoryParent(false)]
        [DynamicField("Masking Category")]
        public CLocalCategorieMasquageAlarme CategorieMasquage
        {
            get
            {
                return GetParent<CLocalCategorieMasquageAlarme>();
            }
            set
            {
                SetParent<CLocalCategorieMasquageAlarme>(value);
            }
        }

        //---------------------------------------------------------------
        public int Priorite
        {
            get
            {
                CLocalCategorieMasquageAlarme cat = CategorieMasquage;
                if (cat != null)
                {
                    try
                    {
                        return Int32.Parse(cat.Id);
                    }
                    catch { }
                }
                return 0;
            }
        }



        //--------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //------------------------------------------------------------------------
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
                c_champParametre,
                c_champIsActif,
                c_champIgnorerEnBase,
                c_champDateDebutValidite,
                c_champDateFinValidite);

            if (result)
                result = SerializeParent<CLocalCategorieMasquageAlarme>(serializer);

            return result;
        }

        //------------------------------------------------------------------------
        public bool ShouldMask(IAlarme alarme, DateTime date)
        {
            if (date >= DateDebutValidite && date <= DateFinValidite &&
                Enabled)
            {
                return Parametre.ShouldMask(alarme, date);
            }
            return false;
        }
        
    }
}
