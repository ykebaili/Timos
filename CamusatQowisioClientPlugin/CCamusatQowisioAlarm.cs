using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.data;
using System.Data;
using sc2i.common;
using timos.data;

namespace CamusatQowisioClientPlugin
{
    [DynamicClass("CamusatQowisioAlarm")]
    [Table(CCamusatQowisioAlarm.c_nomTable, CCamusatQowisioAlarm.c_champId, false)]
    [ObjetServeurURI("CCamusatQowisioAlarmServeur")]
    [AutoExec("Autoexec")]
    public class CCamusatQowisioAlarm : CObjetDonneeAIdNumeriqueAuto, IObjetSansVersion
    {
        public const string c_nomTable = "CAQWFU_ALARM";
        public const string c_champId = "CAQWFUALARM_ID";

        #region champs de la table alarms
        public const string c_champAlarmId = "QWALRM_ALARMID";
        public const string c_champHostId = "QWALRM_HOSTID";
        public const string c_champFuPickup_Id = "FUALRM_PICKUPID";
        public const string c_champFuelProbId = "QWALRM_FUELPROBEID";
        public const string c_champFuTank_Id = "FUALRM_TANKID";
        public const string c_champCriticity = "QWALRM_CRITICITY";
        public const string c_champAlarmType = "QWALRM_TYPE";
        public const string c_champDate = "QWALRM_DATE";
        public const string c_champMessage = "QWALRM_MESSAGE";
        public const string c_champVolume = "QWALRM_VOLUME";
        public const string c_champTemperature = "QWALRM_TEMPERATURE";
        #endregion

        #region Dictionnaires de cache
        private static Dictionary<int, KeyValuePair<string, Type>> s_dicMappageColonneCsv_ChampAlarme =
            new Dictionary<int, KeyValuePair<string, Type>>();
        private static Dictionary<string, int> s_dicCacheHostId_SiteId = new Dictionary<string, int>();
        private static Dictionary<string, int> s_dicCacheFuelProbeId_EquipementId = new Dictionary<string, int>();
        #endregion


        public CCamusatQowisioAlarm(CContexteDonnee ctx)
            : base(ctx)
        {

        }

        public CCamusatQowisioAlarm(DataRow row)
            : base(row)
        {

        }

        public override string DescriptionElement
        {
            get
            {
                return "Qowisio Alarm Id : " + AlarmId;
            }
        }

        public override string[] GetChampsTriParDefaut()
        {
            return new string[] { };
        }

        protected override void MyInitValeurDefaut()
        {

        }


        public static void Autoexec()
        {
            // Mappage des colonnes CSV avec les champs de la table des Alarmes
            s_dicMappageColonneCsv_ChampAlarme.Clear();

            s_dicMappageColonneCsv_ChampAlarme.Add(0, new KeyValuePair<string, Type>(c_champAlarmId, typeof(string)));
            s_dicMappageColonneCsv_ChampAlarme.Add(1, new KeyValuePair<string, Type>(c_champHostId, typeof(string)));
            s_dicMappageColonneCsv_ChampAlarme.Add(2, new KeyValuePair<string, Type>(c_champFuelProbId, typeof(string)));
            s_dicMappageColonneCsv_ChampAlarme.Add(3, new KeyValuePair<string, Type>(c_champCriticity, typeof(int)));
            s_dicMappageColonneCsv_ChampAlarme.Add(4, new KeyValuePair<string, Type>(c_champAlarmType, typeof(int)));
            s_dicMappageColonneCsv_ChampAlarme.Add(5, new KeyValuePair<string, Type>(c_champDate, typeof(DateTime)));
            s_dicMappageColonneCsv_ChampAlarme.Add(6, new KeyValuePair<string, Type>(c_champMessage, typeof(string)));
            s_dicMappageColonneCsv_ChampAlarme.Add(7, new KeyValuePair<string, Type>(c_champVolume, typeof(double)));
            s_dicMappageColonneCsv_ChampAlarme.Add(8, new KeyValuePair<string, Type>(c_champTemperature, typeof(double)));
        }


        //-----------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        [TableFieldProperty(c_champAlarmId, 128)]
        [DynamicField("Alarm Id")]
        public string AlarmId
        {
            get
            {
                return (string)Row[c_champAlarmId];
            }
            set
            {
                Row[c_champAlarmId] = value;
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        [TableFieldProperty(c_champHostId, 128)]
        [DynamicField("Host Id")]
        public string HostId
        {
            get
            {
                return (string)Row[c_champHostId];
            }
            set
            {
                Row[c_champHostId] = value;
            }
        }

        //----------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        [TableFieldProperty(c_champFuPickup_Id, NullAutorise = true)]
        [DynamicField("Pickup Id")]
        public int? PickupId
        {
            get
            {
                return (int?)Row[c_champFuPickup_Id, true];
            }
            set
            {
                Row[c_champFuPickup_Id, true] = value;
            }
        }

        //----------------------------------------------------------------------------------
        /// <summary>
        /// Site Pickup Timos associé au Host Id
        /// </summary>
        [DynamicField("Pickup")]
        public CSite Pickup
        {
            get
            {
                int? nId = PickupId;
                if (nId != null)
                {
                    CSite pickupSite = new CSite(ContexteDonnee);
                    if (pickupSite.ReadIfExists(nId.Value))
                        return pickupSite;
                }
                return null;
            }
            set
            {
                if (value != null)
                    PickupId = value.Id;
                else
                    PickupId = null;
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        [TableFieldProperty(c_champFuelProbId, 128)]
        [DynamicField("Fuel Probe Id")]
        public string FuelProbId
        {
            get
            {
                return (string)Row[c_champFuelProbId];
            }
            set
            {
                Row[c_champFuelProbId] = value;
            }
        }

        [TableFieldProperty(c_champFuTank_Id, NullAutorise = true)]
        [DynamicField("Tank Id")]
        public int? TankId
        {
            get
            {
                return (int?)Row[c_champFuTank_Id, true];
            }
            set
            {
                Row[c_champFuTank_Id, true] = value;
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// Equipement physique Timos Tank associé
        /// </summary>
        [DynamicField("Tank")]
        public CEquipement Tank
        {
            get
            {
                int? nId = TankId;
                if (nId != null)
                {
                    CEquipement tank = new CEquipement(ContexteDonnee);
                    if (tank.ReadIfExists(nId))
                        return tank;
                }
                return null;
            }
            set
            {
                if (value != null)
                    TankId = value.Id;
                else
                    TankId = null;
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        [TableFieldProperty(c_champCriticity)]
        [DynamicField("Criticity")]
        public int Criticity
        {
            get
            {
                return (int)Row[c_champCriticity];
            }
            set
            {
                Row[c_champCriticity] = value;
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        [TableFieldProperty(c_champAlarmType)]
        [DynamicField("Alarm Type code")]
        public int AlarmTypeCode
        {
            get
            {
                return (int)Row[c_champAlarmType];
            }
            set
            {
                Row[c_champAlarmType] = value;
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// Indique le type d'alarme
        /// </summary>
        [DynamicField("Alarm type")]
        public CTypeAlarmeQowisio TypeAlarme
        {
            get
            {
                try
                {
                    ETypeAlarmeQowisio t = (ETypeAlarmeQowisio)AlarmTypeCode;
                    return new CTypeAlarmeQowisio(t);
                }
                catch { }
                return null;
            }
            set
            {
                if (value != null)
                {
                    AlarmTypeCode = value.CodeInt;
                }
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        [TableFieldProperty(c_champDate)]
        [DynamicField("Alarm Date")]
        public DateTime AlarmDate
        {
            get
            {
                return (DateTime)Row[c_champDate];
            }
            set
            {
                Row[c_champDate] = value;
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        [TableFieldProperty(c_champMessage, 200)]
        [DynamicField("Message")]
        public string Message
        {
            get
            {
                return (string)Row[c_champMessage];
            }
            set
            {
                Row[c_champMessage] = value;
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        [TableFieldProperty(c_champVolume)]
        [DynamicField("Volume")]
        public double Volume
        {
            get
            {
                return (double)Row[c_champVolume];
            }
            set
            {
                Row[c_champVolume] = value;
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        [TableFieldProperty(c_champTemperature)]
        [DynamicField("Temperature")]
        public double Temperature
        {
            get
            {
                return (double)Row[c_champTemperature];
            }
            set
            {
                Row[c_champTemperature] = value;
            }
        }


        //----------------------------------------------------------------------------------
        public CResultAErreur TraiteAlarmRowFromCsv(string strAlarmCsv)
        {
            CResultAErreur result = CResultAErreur.True;

            string[] listeDatas = strAlarmCsv.Split(';');

            string strAlarmId = listeDatas[0];
            if (strAlarmId == string.Empty)
            {
                result.EmpileErreur("No Alarm Id for CSV row : " + strAlarmCsv);
                return result;
            }
            AlarmId = strAlarmId;
            string strHostId = listeDatas[1];
            if (strHostId != "")
            {
                HostId = strHostId;
                // Recherche le Site associé au Host Id, si on ne trouve pas c'est pas grave on garde quand même l'alarme
                int? nIdSite = CCamusatQowisioData.TrouveAssociationIdHost_IdSite(strHostId, ContexteDonnee);
                PickupId = nIdSite;
            }

            int nNbColonnes = listeDatas.Length;
            for (int i = 2; i < nNbColonnes; i++)
            {
                string strDataSource = listeDatas[i];

                KeyValuePair<string, Type> defChampAlarm;
                if (s_dicMappageColonneCsv_ChampAlarme.TryGetValue(i, out defChampAlarm))
                {
                    string strNomChamp = defChampAlarm.Key;
                    Type typeDonnee = defChampAlarm.Value;

                    if (typeDonnee == typeof(DateTime))
                    {
                        try
                        {
                            DateTime date = CCamusatQowisioData.ParseDateFromString(strDataSource);
                            Row[strNomChamp] = date;
                        }
                        catch { }
                    }
                    if (typeDonnee == typeof(int))
                    {
                        try
                        {
                            int valeur = Int32.Parse(strDataSource);
                            Row[strNomChamp] = valeur;
                            continue;
                        }
                        catch { }
                    }
                    if (typeDonnee == typeof(double))
                    {
                        try
                        {
                            double valeur = Convert.ToDouble(strDataSource.Replace('.', ','));
                            Row[strNomChamp] = valeur;
                            continue;
                        }
                        catch { }
                    }
                    if (typeDonnee == typeof(string))
                    {
                        Row[strNomChamp] = strDataSource;
                        continue;
                    }
                }
                else
                {
                    return result;
                }
            }

            try
            {
                TankId = CCamusatQowisioData.TrouveAssociationIdFuelProbe_IdEquipement(FuelProbId, ContexteDonnee);
            }
            catch (Exception e)
            {
                result.EmpileErreur(e.Message);
            }

            return result;
        }
    }
}
