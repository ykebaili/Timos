using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.expression;
using sc2i.common;
using System.Data;
using futurocom.easyquery;
using sc2i.common.memorydb;
using futurocom.supervision;

namespace futurocom.snmp.entitesnmp
{
    [MemoryTable(CEntiteSnmpPourSupervision.c_nomTable, CEntiteSnmpPourSupervision.c_champId)]
    public class CEntiteSnmpPourSupervision : CEntiteDeMemoryDbAIdAuto,
                                            IElementAVariableInstance,
                                            IEntiteDeclencheuseAlarme
    {
        public const string c_nomTable = "SNMP_ENTITY";
        public const string c_champId = "SNMPET_ID";
        public const string c_champIndex = "SNMPET_INDEX";
        public const string c_champLibelle = "SNMPET_LIBELLE";
        public const string c_champDicValeurs = "SNMPET_VALUES";
        public const string c_champIdSite = "SNMPET_SITE_ID";
        public const string c_champIdEquipement = "SNMPET_LOGEQPT_ID";
        public const string c_champIdLien = "SNMPET_LINK_ID";

        //-------------------------------------
        public CEntiteSnmpPourSupervision(CMemoryDb db)
            :base(db)
        {
        
        }

        //-------------------------------------
        public CEntiteSnmpPourSupervision(DataRow row)
            : base(row)
        {
        }

        //-------------------------------------
        public override void MyInitValeursParDefaut()
        {
            Index = "";
            Libelle = "";
        }

        //-------------------------------------
        [MemoryField(c_champLibelle)]
        [DynamicField("Calculated Label")]
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

        //-------------------------------------
        [MemoryParent(true)]
        public CAgentSnmpPourSupervision AgentSnmp
        {
            get
            {
                return GetParent<CAgentSnmpPourSupervision>();
            }
            set
            {
                SetParent<CAgentSnmpPourSupervision>(value);
            }
        }

        //-------------------------------------
        public void UpdateIndexEtLibelle()
        {
            if (TypeEntite != null )
            {
                CContexteEvaluationExpression ctx = new CContexteEvaluationExpression(this);
                if (TypeEntite.FormuleLibelle != null)
                {
                    CResultAErreur result = TypeEntite.FormuleLibelle.Eval(ctx);
                    if (result && result.Data != null)
                        Libelle = result.Data.ToString();
                }
                if (TypeEntite.FormuleIndexParDefaut != null)
                {
                    CResultAErreur result = TypeEntite.FormuleIndexParDefaut.Eval(ctx);
                    if (result && result.Data != null)
                        Index = result.Data.ToString();
                }
            }
        }
        
        //-------------------------------------
        [MemoryField(c_champIndex)]
        [DynamicField("Calculated Index")]
        public string Index
        {
            get
            {
                return Row.Get<string>(c_champIndex);
            }
            set
            {
                Row[c_champIndex] = value;
            }
        }

        //---------------------------------------------
        [MemoryField(c_champIdSite)]
        [DynamicField("Site Id")]
        public CDbKey IdSiteAssocie
        {
            get
            {
                return Row.Get<CDbKey>(c_champIdSite);
            }
            set
            {
                Row[c_champIdSite] = value;
            }
        }

        //---------------------------------------------
        [MemoryField(c_champIdEquipement)]
        [DynamicField("Logical Equipment Id")]
        public CDbKey IdEquipementLogiqueAssocie
        {
            get
            {
                return Row.Get<CDbKey>(c_champIdEquipement);
            }
            set
            {
                Row[c_champIdEquipement] = value;
            }
        }

        //---------------------------------------------
        [MemoryField(c_champIdLien)]
        [DynamicField("Link Id")]
        public CDbKey IdLienReseauAssocie
        {
            get
            {
                return Row.Get<CDbKey>(c_champIdLien);
            }
            set
            {
                Row[c_champIdLien] = value;
            }
        }

        //---------------------------------------------
        public CDbKey IdEntiteSnmpAssociee
        {
            get
            {
                try
                {
                    CDbKey nVal = CDbKey.CreateFromStringValue(Id);
                    return nVal;
                }
                catch { }
                return null;
            }

        }

        //-------------------------------------
        [MemoryField(c_champDicValeurs)]
        public Dictionary<string, CValeurTypeChampBasique> DicValeursChamps
        {
            get
            {
                Dictionary<string, CValeurTypeChampBasique> dic = Row.Get<Dictionary<string, CValeurTypeChampBasique>>(c_champDicValeurs);
                if (dic == null)
                {
                    dic = new Dictionary<string, CValeurTypeChampBasique>();
                    Row[c_champDicValeurs] = dic;
                }
                return dic;
            }
        }
        

        //-------------------------------------
        [DynamicField("Entity type")]
        [MemoryParent(false)]
        public CTypeEntiteSnmpPourSupervision TypeEntite
        {
            get
            {
                return GetParent<CTypeEntiteSnmpPourSupervision>();
            }
            set
            {
                SetParent<CTypeEntiteSnmpPourSupervision>(value);
            }
        }


        //-------------------------------------
        public CDefinitionProprieteDynamique[] GetProprietesInstance()
        {
            List<CDefinitionProprieteDynamique> lstDefs = new List<CDefinitionProprieteDynamique>();
            if (TypeEntite != null)
            {
                foreach (IChampEntiteSNMP champ in TypeEntite.Champs)
                {
                    lstDefs.Add(new CDefinitionProprieteDynamiqueChampEntiteSnmp(champ));
                }
            }
            return lstDefs.ToArray();
        }

        //-------------------------------------
        public void SetValeurChamp(string strIdChamp, object valeur)
        {
            DicValeursChamps[strIdChamp] = new CValeurTypeChampBasique(valeur);
        }

        //--------------------------------------
        public object GetValeurChamp(string strIdChamp)
        {
            CValeurTypeChampBasique valeur = null;
            DicValeursChamps.TryGetValue(strIdChamp, out valeur);
            if (valeur != null)
                return valeur.Value;
            return null ;
        }


        

        //-----------------------------------------------------
        internal void FillFromSource(DataRow row)
        {
            if (TypeEntite != null)
            {
                Dictionary<string, DataColumn> dicIdToCol = new Dictionary<string, DataColumn>();
                Dictionary<string, DataColumn> dicNomToCol = new Dictionary<string, DataColumn>();
                foreach (DataColumn col in row.Table.Columns)
                {
                    dicNomToCol[col.ColumnName] = col;
                    string strId = col.ExtendedProperties[CODEQBase.c_extPropColonneId] as string;
                    if (strId != null)
                        dicIdToCol[strId] = col;
                }


                foreach (IChampEntiteSNMP champ in TypeEntite.Champs)
                {
                    CChampEntiteFromQuery cfq = champ as CChampEntiteFromQuery;
                    DataColumn col = null;
                    if (cfq != null)
                    {
                        dicIdToCol.TryGetValue(cfq.Id, out col);
                        if (col == null)
                            dicNomToCol.TryGetValue(cfq.NomChamp, out col);
                        if (col != null)
                            SetValeurChamp(cfq.Id, row[col] == DBNull.Value ? null : row[col]);
                    }
                }
            }
        }

        //-------------------------------------
        [DynamicMethod("Returns the requiered field value","Field ID (Custom field ID)")]
        public object GetFieldValue(int nCustomFieldId)
        {
            return GetValeurChamp(nCustomFieldId.ToString());
        }



        //-------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //-------------------------------------
        protected override CResultAErreur MySerialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;

            result = SerializeChamps(serializer,
                c_champLibelle,
                c_champIndex,
                c_champIdSite,
                c_champIdEquipement,
                c_champIdLien,
                c_champDicValeurs);

            if (result)
                result = SerializeParent<CAgentSnmpPourSupervision>(serializer);
            if (result)
                result = SerializeParent<CTypeEntiteSnmpPourSupervision>(serializer);
            return result;
        }


       
    }
}
