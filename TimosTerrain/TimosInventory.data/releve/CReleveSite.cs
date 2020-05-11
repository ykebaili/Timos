using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common.memorydb;
using System.Data;
using sc2i.common;

namespace TimosInventory.data.releve
{
    [MemoryTable(c_nomTable, c_champId)]
    public class CReleveSite : CEntiteReleve
    {
        public const string c_nomTable = "SITE_SURVEY";

        public const string c_champId = "SS_ID";
        public const string c_champDate = "SS_DATE";

        //-------------------------------------------------------
        public CReleveSite(CMemoryDb db)
            : base(db)
        {
        }

        //-------------------------------------------------------
        public CReleveSite(CReleveDb db)
            : this((CMemoryDb)db)
        {
        }

        //-------------------------------------------------------
        public CReleveSite(DataRow row)
            : base(row)
        {
        }

        //-------------------------------------------------------
        [MemoryField(c_champDate)]
        public DateTime DateReleve
        {
            get{
                return Row.Get<DateTime>(c_champDate);
            }
            set{
                Row[c_champDate] = value;
            }
        }

        //-------------------------------------------------------
        [MemoryField(CSite.c_champId)]
        public string IdSite
        {
            get
            {
                return Row.Get<string>(CSite.c_champId);
            }
            set
            {
                Row[CSite.c_champId] = value;
            }
        }

        //-------------------------------------------------------
        public CSite Site
        {
            get
            {
                return GetEntiteTimos<CSite>(IdSite);
            }
            set 
            {
                if (value != null)
                    IdSite = value.Id;
                else
                    IdSite = null;
            }
        }

        //-------------------------------------------------------
        [MemoryChild()]
        public CListeEntitesDeMemoryDb<CReleveEquipement> RelevesEquipement
        {
            get
            {
                return GetFils<CReleveEquipement>();
            }
        }

        //-------------------------------------------------------
        public override void MyInitValeursParDefaut()
        {
            DateReleve = DateTime.Now;
        }

        //-------------------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //-------------------------------------------------------
        protected override sc2i.common.CResultAErreur MySerialize(sc2i.common.C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if ( !result) 
                return result;
            result = SerializeChamps(serializer, CSite.c_champId, c_champDate);
            /*if (result)
                result = SerializeChilds<CReleveEquipement>(serializer);*/
            return result;
        }

        //-------------------------------------------------------
        public static CReleveSite GetNewReleve ( CReleveDb db, CSite site )
        {
            CReleveSite releve = new CReleveSite (db);
            releve.CreateNew();
            releve.DateReleve = DateTime.Now;
            releve.Site = site;
            releve.InitEquipementsReleves();
            return releve;
        }

        //-------------------------------------------------------
        public void InitEquipementsReleves (  )
        {
            //Prépare les équipements
            CListeEntitesDeMemoryDb<CEquipement> lstEqpts = Site.Equipements;
            lstEqpts.Filtre = new CFiltreMemoryDb ( CEquipement.c_champIdEquipementContenant+" is null");
            lstEqpts.Sort = CEquipement.c_champCoordonnee;
            foreach ( CEquipement eqpt in lstEqpts )
            {
                CReleveEquipement relEqpt = new CReleveEquipement(Database as CReleveDb);
                relEqpt.CreateNew();
                relEqpt.ReleveSite = this;
                relEqpt.FillFromEquipement ( eqpt, null );
            }
        }

        //-------------------------------------------------------
        public void ClearRelevesEquipements()
        {
            CListeEntitesDeMemoryDb<CReleveEquipement> lst = RelevesEquipement;
            lst.Filtre = new CFiltreMemoryDb(CReleveEquipement.c_champIdContenant + " is null");
            foreach (CReleveEquipement releve in lst.ToArray())
            {
                releve.Delete();
            }
        }
                

        
            

    }
}
