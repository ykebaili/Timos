using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common.memorydb;
using sc2i.common;
using futurocom.snmp.entitesnmp;
using sc2i.expression;
using sc2i.common.DonneeCumulee;
using System.Data;

namespace futurocom.snmp.polling
{
    [MemoryTable(CSnmpPollingSetup.c_nomTable, CSnmpPollingSetup.c_champId)]
    public class CSnmpPollingSetup : CEntiteDeMemoryDbAIdAuto
    {
        public const string c_nomTable = "POLLING_SETUP";
        public const string c_champId = "POLSET_ID";
        public const string c_champLabel = "POLSET_LABEL";

        public const string c_champIdTypeDonneeCumulee = "CUMDATTYP_ID";
        public const string c_champFrequenceMinutes = "POLSET_FREQ_MINUTES";
        public const string c_champParametresRemplisssage = "POLSET_FIELDS_SETTINGS";

        //---------------------------------------
        public CSnmpPollingSetup(CMemoryDb db)
            : base(db)
        {
        }

        //---------------------------------------
        public CSnmpPollingSetup(DataRow row)
            : base(row)
        {
        }

        //---------------------------------------
        public override void MyInitValeursParDefaut()
        {
            Libelle = "";
            IdTypeDonneeCumulee = -1;
            FrequenceMinutes = 240;
        }

        //---------------------------------------
        [MemoryField(c_champLabel)]
        [DynamicField("Label")]
        public string Libelle
        {
            get
            {
                return Row.Get<string>(c_champLabel);
            }
            set
            {
                Row[c_champLabel] = value;
            }
        }

        //---------------------------------------
        [MemoryField(c_champIdTypeDonneeCumulee)]
        [DynamicField("Cumulated data type id")]
        public int IdTypeDonneeCumulee
        {
            get
            {
                return Row.Get<int>(c_champIdTypeDonneeCumulee);
            }
            set
            {
                Row[c_champIdTypeDonneeCumulee] = value;
            }
        }

        //---------------------------------------
        [MemoryField(c_champFrequenceMinutes)]
        [DynamicField("Frequency in minutes")]
        public double FrequenceMinutes
        {
            get
            {
                return Row.Get<double>(c_champFrequenceMinutes);
            }
            set
            {
                Row[c_champFrequenceMinutes] = value;
            }
        }

        //---------------------------------------
        [MemoryParent(true)]
        [DynamicField("Snmp agent")]
        public CAgentSnmpPourSupervision Agent
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

        //---------------------------------------
        [DynamicMethod(
            "Add a filling parameter",
            "Field type (0=key, 1=decimal value, 2=Date value, 3=String value",
            "Field number",
            "Formula (use Compile fonction)")]
        public void AddFillingField(int nCodeTypeChamp, int nNumChamp, C2iExpression formule)
        {
            try
            {
                ETypeChampDonneeCumulee eType = (ETypeChampDonneeCumulee)nCodeTypeChamp;
                CChampDonneeCumulee champ = new CChampDonneeCumulee();
                champ.TypeChamp = eType;
                champ.NumeroChamp = nNumChamp;
                CListeParametresFillChampDonneeCumulee lst = new CListeParametresFillChampDonneeCumulee();
                lst.AddRange(ParametresFillChamps);
                bool bDone = false;
                foreach (CParametreFillChampDonneeCumulee p in lst)
                {
                    if (p.Champ.Equals(champ))
                    {
                        p.FormuleSource = formule;
                        bDone = true;
                        break;
                    }
                }
                if (!bDone)
                {
                    CParametreFillChampDonneeCumulee parametre = new CParametreFillChampDonneeCumulee();
                    parametre.Champ = champ;
                    parametre.FormuleSource = formule;
                    lst.Add(parametre);
                }
                ParametresFillChamps = lst;
            }
            catch { }
        }

        //---------------------------------------
        [MemoryField(c_champParametresRemplisssage)]
        public CListeParametresFillChampDonneeCumulee ParametresFillChamps
        {
            get
            {
                CListeParametresFillChampDonneeCumulee p = Row.Get<CListeParametresFillChampDonneeCumulee>(c_champParametresRemplisssage);
                if (p == null)
                    return new CListeParametresFillChampDonneeCumulee(); ;
                return p;
            }
            set
            {
                CListeParametresFillChampDonneeCumulee lst = new CListeParametresFillChampDonneeCumulee();
                if (value != null)
                {
                    lst.AddRange(value);
                }
                Row[c_champParametresRemplisssage] = lst;
            }
        }

        //---------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //---------------------------------------
        protected override CResultAErreur MySerialize(sc2i.common.C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            result = SerializeChamps(serializer, c_champLabel, c_champIdTypeDonneeCumulee, c_champFrequenceMinutes, c_champParametresRemplisssage);
            if (result)
                result = SerializeParent<CAgentSnmpPourSupervision>(serializer);
            return result;
        }


        //---------------------------------------
        internal CDonneeCumuleeTransportable GetDonneeTransportable()
        {
            CDonneeCumuleeTransportable donnee = new CDonneeCumuleeTransportable();
            donnee.IdTypeDonneeCumulee = IdTypeDonneeCumulee;
            CContexteEvaluationExpression ctx = new CContexteEvaluationExpression(Agent);
            foreach (CParametreFillChampDonneeCumulee p in ParametresFillChamps)
            {
                if (p.FormuleSource != null)
                {
                    CResultAErreur result = p.FormuleSource.Eval(ctx);
                    if (!result && p.Champ.TypeChamp == ETypeChampDonneeCumulee.Cle)
                        return null;//on ne peut pas prendre une donnée dans laquelle il manque une clé
                    if (result)
                    {
                        switch (p.Champ.TypeChamp)
                        {
                            case ETypeChampDonneeCumulee.Cle:
                                if (result.Data != null)
                                    donnee.SetValeurCle(p.Champ.NumeroChamp, result.Data.ToString());
                                break;
                            case ETypeChampDonneeCumulee.Texte :
                                if (result.Data != null)
                                    donnee.SetValeurString(p.Champ.NumeroChamp, result.Data.ToString());
                                break;
                            case ETypeChampDonneeCumulee.Date:
                                if (result.Data != null)
                                {
                                    DateTime? dt = null;
                                    if (result.Data is DateTime)
                                        dt = (DateTime)result.Data;
                                    else
                                    {
                                        try
                                        {
                                            dt = Convert.ToDateTime(result.Data);
                                        }
                                        catch { }
                                    }
                                    if (dt != null)
                                        donnee.SetValeurDate(p.Champ.NumeroChamp, dt.Value);
                                }
                                break;
                            case ETypeChampDonneeCumulee.Decimal:
                                if (result.Data != null)
                                {
                                    double? fVal = null;
                                    if (result.Data is Double)
                                        fVal = (Double)result.Data;
                                    else if (result.Data is int)
                                        fVal = (double)result.Data;
                                    else
                                    {
                                        try
                                        {
                                            fVal = Convert.ToDouble(result.Data);
                                        }
                                        catch { }
                                    }
                                    if (fVal != null)
                                        donnee.SetValeurDouble(p.Champ.NumeroChamp, fVal.Value);
                                }
                                break;
                        }
                    }
                }
            }
            return donnee;
        }
    }
}
