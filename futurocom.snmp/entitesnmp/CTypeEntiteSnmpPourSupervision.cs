using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using System.Drawing;
using futurocom.easyquery;
using futurocom.easyquery.snmp;
using sc2i.expression;
using sc2i.common.memorydb;
using System.Data;

namespace futurocom.snmp.entitesnmp
{
    
    [MemoryTable(CTypeEntiteSnmpPourSupervision.c_nomTable, CTypeEntiteSnmpPourSupervision.c_champId)]
    public class CTypeEntiteSnmpPourSupervision : CEntiteDeMemoryDb
    {
        public const string c_nomTable = "SNMP_ENTITY_TYPE";
        public const string c_champId = "SNMETTTP_ID";
        public const string c_champLibelle = "SNMETTTP_LABEL";
        public const string c_champIndex = "SNMETTTP_INDEX";
        public const string c_champIdParent = "SNMETTTP_PARENT_ID";
        public const string c_champIdObjetDeQuerySource = "SNMETTTP_SOURCE_ID";
        public const string c_champFormuleLibelle = "SNMETTTP_LABEL_FORMULA";
        public const string c_champFormuleIndex = "SNMETTTP_INDEX_FORMULA";
        public const string c_champListeChamps = "SNMETTTP_FIELDS";

        //----------------------------------------------
        public CTypeEntiteSnmpPourSupervision(CMemoryDb db)
            : base(db)
        {
        }

        //----------------------------------------------
        public CTypeEntiteSnmpPourSupervision(DataRow row)
            : base(row)
        {
        }

        //----------------------------------------------
        public override void MyInitValeursParDefaut()
        {
            Index = 0;
            Libelle = "";
        }

        //----------------------------------------------
        [MemoryParent(true)]
        public CTypeAgentPourSupervision TypeAgent
        {
            get
            {
                return GetParent<CTypeAgentPourSupervision>();
            }
            set
            {
                SetParent<CTypeAgentPourSupervision>(value);
                foreach (CTypeEntiteSnmpPourSupervision typeFils in TypesFils)
                    typeFils.TypeAgent = value;
            }
        }

        //----------------------------------------------
        [MemoryParent(c_champIdParent, true)]
        public CTypeEntiteSnmpPourSupervision TypeParent
        {
            get
            {
                return GetParent<CTypeEntiteSnmpPourSupervision>(c_champIdParent);
            }
            set
            {
                SetParent<CTypeEntiteSnmpPourSupervision>(value, c_champIdParent);
            }
        }

        //----------------------------------------------
        [MemoryChild]
        public CListeEntitesDeMemoryDb<CTypeEntiteSnmpPourSupervision> TypesFils
        {
            get
            {
                return GetFils<CTypeEntiteSnmpPourSupervision>(c_champIdParent);
            }
        }

        

        //------------------------------------------
        [MemoryField(c_champLibelle)]
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

        //------------------------------------------
        [MemoryField(c_champIdObjetDeQuerySource)]
        public string IdObjetDeQuerySource
        {
            get
            {
                return Row.Get<string>(c_champIdObjetDeQuerySource);
            }
            set
            {
                Row[c_champIdObjetDeQuerySource] = value;
            }
        }

        //------------------------------------------
        [MemoryField(c_champFormuleLibelle)]
        public C2iExpression FormuleLibelle
        {
            get
            {
                return Row.Get<C2iExpression>(c_champFormuleLibelle);
            }
            set
            {
                Row[c_champFormuleLibelle] = value;
            }
        }

        //------------------------------------------
        [MemoryField(c_champIndex)]
        public int Index
        {
            get
            {
                return Row.Get<int>(c_champIndex);
            }
            set
            {
                Row[c_champIndex] = value;
            }
        }

        //------------------------------------------
        [MemoryField(c_champListeChamps)]
        public IEnumerable<IChampEntiteSNMP> Champs
        {
            get
            {
                IEnumerable<IChampEntiteSNMP> lstChamps = Row.Get<IEnumerable<IChampEntiteSNMP>>(c_champListeChamps);
                if (lstChamps == null)
                {
                    lstChamps = new List<IChampEntiteSNMP>();
                    Row[c_champListeChamps] = lstChamps;
                }
                return lstChamps;
            }
        }

        //------------------------------------------
        private List<IChampEntiteSNMP> ChampsListe
        {
            get
            {
                return (List<IChampEntiteSNMP>)Champs;
            }
        }

        //------------------------------------------
        public bool AddChamp(IChampEntiteSNMP champ)
        {

            if (Champs.FirstOrDefault(c => c.NomChamp.ToUpper() == champ.NomChamp.ToUpper()) == null)
            {
                ChampsListe.Add(champ);
                return true;
            }
            return false;
        }

        //------------------------------------------
        public void RemoveChamp(IChampEntiteSNMP champ)
        {
            ChampsListe.Remove(champ);
        }

        //------------------------------------------
        [MemoryField(c_champFormuleIndex)]
        public C2iExpression FormuleIndexParDefaut
        {
            get
            {
                return Row.Get<C2iExpression>(c_champFormuleIndex);
            }
            set
            {
                Row[c_champFormuleIndex] = value;
            }
        }

        


        //------------------------------------------
        public CODEQBase GetObjetDeQuery(CTypeAgentPourSupervision typeAgent)
        {
            if (IdObjetDeQuerySource != null)
            {
                CEasyQuery query = typeAgent.Queries.FirstOrDefault(q => q.GetObjet(IdObjetDeQuerySource) != null);
                if (query != null)
                    return query.Childs.FirstOrDefault(c => c is CODEQBase && ((CODEQBase)c).Id == IdObjetDeQuerySource) as CODEQBase;
            }
            return null;
        }

        //------------------------------------------
        public void FillFromTable(CODEQBase objetDeRequete)
        {
            CEasyQuery query = objetDeRequete.Query;
            if (query == null)
                return;
            IdObjetDeQuerySource = objetDeRequete.Id;
            HashSet<string> champsASupprimer = new HashSet<string>();
            foreach (IChampEntiteSNMP champ in Champs.ToArray())
            {
                if (champ is CChampEntiteSnmpStandard)
                    champsASupprimer.Add(champ.Id);
            }
            foreach (IColumnDeEasyQuery col in objetDeRequete.Columns)
            {
                CChampEntiteFromQuery champ = Champs.FirstOrDefault(c =>
                    c is CChampEntiteFromQuery && ((CChampEntiteFromQuery)c).ColonneSource.Id == col.Id) as CChampEntiteFromQuery;
                if (champ == null)
                {
                    champ = new CChampEntiteFromQuery();
                    ChampsListe.Add(champ);
                }
                champ.InitFromColonneSource(col, objetDeRequete);
            }
        }

        //------------------------------------------
        public CEntiteSnmpPourSupervision GetEntiteDeTest()
        {
            CEntiteSnmpPourSupervision entite = new CEntiteSnmpPourSupervision(new CMemoryDb());
            entite.CreateNew();
            entite.TypeEntite = this;
            return entite;
        }

        //------------------------------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //------------------------------------------------------------------
        protected override CResultAErreur MySerialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            result = SerializeChamps(serializer,
                c_champLibelle,
                c_champIndex,
                c_champIdObjetDeQuerySource,
                c_champFormuleLibelle,
                c_champFormuleIndex,
                c_champListeChamps);
            if (result)
                result = SerializeParent<CTypeAgentPourSupervision>(serializer);
            if (result)
                result = SerializeParent<CTypeEntiteSnmpPourSupervision>(serializer, c_champIdParent);
            if (result)
                result = SerializeChilds<CTypeEntiteSnmpPourSupervision>(serializer, c_champIdParent);
            return result;

        }




        
    }
}
