using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.data;
using sc2i.common;
using System.Data;
using System.Net;
using timos.data;
using sc2i.data.dynamic;

namespace CamusatQowisioClientPlugin
{
    [DynamicClass("CamusatQowisioData")]
    [Table(CCamusatQowisioData.c_nomTable, CCamusatQowisioData.c_champId, false)]
    [ObjetServeurURI("CCamusatQowisioDataServeur")]
    [AutoExec("Autoexec")]
    [NoRelationTypeId]
    public class CCamusatQowisioData : CObjetDonneeAIdNumeriqueAuto, IObjetSansVersion
    {
        public const string c_nomTable = "CAQWFU_DATA";
        public const string c_champId = "CAQWFUDATA_ID";

        #region Id des entités Timos liées au paramétrage Camusat
        public const int c_nIdChampTimosQowisioId = 1;
        public const int c_nIdSiteQowisionAwaitingElements = 2;
        public const int c_nIdTypeSiteTelecom = 3;
        public const int c_nIdTypeSitePickup = 1;
        public const int c_nIdTypeEquipementQowisioBoxVehicule = 1;
        public const int c_nIdTypeEquipementQowisioVirtualSite = 4;
        public const int c_nIdTypeEquipementQowisioFuelProbe = 2;
        // Champs custom sur equipement logique / Physique
        public const int c_nIdChampTimosFuelProbeAssociatedTank = 8;
        public const int c_nIdChampTimosFuelTankShape = 3;
        public const int c_nIdChampTimosFuelTankDimensions = 4;
        public const int c_nIdChampTimosFuelTankCapacity = 5;
        public const int c_nIdChampTimosFuelProbeType = 6;
        #endregion

        #region Noms des champs de la table
        // Qw = Quowisio
        // Fu = Futurocom
        // InFP = Internal Fuel Probe
        // ExFP = External Fuel Probe
        // Tank = Relation vers un Equipement physique Timos
        // Site = Relation vers un Site timos
        // Pickup = Relation vers un Site Timos

        // Boitier Qowisio
        public const string c_champQwHost_Id = "QWDATA_HOSTID";
        public const string c_champFuPickup_Id = "FUDATA_PICKUPID";
        public const string c_champFuSite_Id = "FUDATA_SITEID";
        public const string c_champQwDateTime = "QWDATA_DATETIME";
        public const string c_champQwLatitude = "QWDATA_LATITUDE";
        public const string c_champQwLongitude = "QWDATA_LONGITUDE";
        public const string c_champQwStatut = "QWDATA_PICKUP_STATE";
        // Sonde externe
        public const string c_champQwExFP_Id = "QWDATA_EXFPID";
        public const string c_champFuExTank_Id = "FUDATA_EXTANKID";
        public const string c_champQwExTank_Vol = "QWDATA_EXTANKVOL";
        public const string c_champQwExTank_Temp = "QWDATA_EXTANKTEMP";
        public const string c_champQwExTank_Flow = "QWDATA_EXTANKFLOW";
        // Sonde interne 1
        public const string c_champQwInFP1_Id = "QWDATA_INFP1ID";
        public const string c_champFuTank1_Id = "FUDATA_TANK1ID";
        public const string c_champQwTank1_Vol = "QWDATA_TANK1VOL";
        public const string c_champQwTank1_Temp = "QWDATA_TANK1TEMP";
        public const string c_champQwTank1_Flow = "QWDATA_TANK1FLOW";
        // Sonde interne 2
        public const string c_champQwInFP2_Id = "QWDATA_INFP2ID";
        public const string c_champFuTank2_Id = "FUDATA_TANK2ID";
        public const string c_champQwTank2_Vol = "QWDATA_TANK2VOL";
        public const string c_champQwTank2_Temp = "QWDATA_TANK2TEMP";
        public const string c_champQwTank2_Flow = "QWDATA_TANK2FLOW";
        // Sonde interne 3
        public const string c_champQwInFP3_Id = "QWDATA_INFP3ID";
        public const string c_champFuTank3_Id = "FUDATA_TANK3ID";
        public const string c_champQwTank3_Vol = "QWDATA_TANK3VOL";
        public const string c_champQwTank3_Temp = "QWDATA_TANK3TEMP";
        public const string c_champQwTank3_Flow = "QWDATA_TANK3FLOW";
        // Sonde interne 4
        public const string c_champQwInFP4_Id = "QWDATA_INFP4ID";
        public const string c_champFuTank4_Id = "FUDATA_TANK4ID";
        public const string c_champQwTank4_Vol = "QWDATA_TANK4VOL";
        public const string c_champQwTank4_Temp = "QWDATA_TANK4TEMP";
        public const string c_champQwTank4_Flow = "QWDATA_TANK4FLOW";
        #endregion

        #region Dictionnaires de cache
        private static Dictionary<int, KeyValuePair<string, Type>> s_dicMappageColonneCsv_ChampData =
            new Dictionary<int, KeyValuePair<string, Type>>();
        private static Dictionary<string, int> s_dicCacheHostId_SiteId = new Dictionary<string, int>();
        private static Dictionary<string, int> s_dicCacheFuelProbeId_EquipementId = new Dictionary<string, int>();
        private static Dictionary<int, int> s_dicCacheSiteId_TypeSiteId = new Dictionary<int, int>();
        #endregion

        public CCamusatQowisioData(CContexteDonnee context)
            : base(context)
        {
        }

        public CCamusatQowisioData(DataRow row)
            : base(row)
        {
        }

        public override string DescriptionElement
        {
            get { return "Qowisio Data from Host " + HostId ; }
        }

        public override string[] GetChampsTriParDefaut()
        {
            return new string[] { c_champId };
        }

        protected override void MyInitValeurDefaut()
        {
        }

        public static void Autoexec()
        {
            // Mappage des colonnes CSV avec les champs de la table de données
            s_dicMappageColonneCsv_ChampData.Clear();

            // Host
            s_dicMappageColonneCsv_ChampData.Add(0, new KeyValuePair<string, Type>(c_champQwHost_Id, typeof(string)));
            s_dicMappageColonneCsv_ChampData.Add(1, new KeyValuePair<string, Type>(c_champQwDateTime, typeof(DateTime)));
            s_dicMappageColonneCsv_ChampData.Add(2, new KeyValuePair<string, Type>(c_champQwLatitude, typeof(double)));
            s_dicMappageColonneCsv_ChampData.Add(3, new KeyValuePair<string, Type>(c_champQwLongitude, typeof(double)));
            // Internal Fuel probe 1
            s_dicMappageColonneCsv_ChampData.Add(4, new KeyValuePair<string, Type>(c_champQwInFP1_Id, typeof(string)));
            s_dicMappageColonneCsv_ChampData.Add(5, new KeyValuePair<string, Type>(c_champQwTank1_Vol, typeof(double)));
            s_dicMappageColonneCsv_ChampData.Add(6, new KeyValuePair<string, Type>(c_champQwTank1_Temp, typeof(double)));
            s_dicMappageColonneCsv_ChampData.Add(7, new KeyValuePair<string, Type>(c_champQwTank1_Flow, typeof(double)));
            // Internal Fuel probe 2
            s_dicMappageColonneCsv_ChampData.Add(8, new KeyValuePair<string, Type>(c_champQwInFP2_Id, typeof(string)));
            s_dicMappageColonneCsv_ChampData.Add(9, new KeyValuePair<string, Type>(c_champQwTank2_Vol, typeof(double)));
            s_dicMappageColonneCsv_ChampData.Add(10, new KeyValuePair<string, Type>(c_champQwTank2_Temp, typeof(double)));
            s_dicMappageColonneCsv_ChampData.Add(11, new KeyValuePair<string, Type>(c_champQwTank2_Flow, typeof(double)));
            // Internal Fuel probe 3
            s_dicMappageColonneCsv_ChampData.Add(12, new KeyValuePair<string, Type>(c_champQwInFP3_Id, typeof(string)));
            s_dicMappageColonneCsv_ChampData.Add(13, new KeyValuePair<string, Type>(c_champQwTank3_Vol, typeof(double)));
            s_dicMappageColonneCsv_ChampData.Add(14, new KeyValuePair<string, Type>(c_champQwTank3_Temp, typeof(double)));
            s_dicMappageColonneCsv_ChampData.Add(15, new KeyValuePair<string, Type>(c_champQwTank3_Flow, typeof(double)));
            // Internal Fuel probe 4
            s_dicMappageColonneCsv_ChampData.Add(16, new KeyValuePair<string, Type>(c_champQwInFP4_Id, typeof(string)));
            s_dicMappageColonneCsv_ChampData.Add(17, new KeyValuePair<string, Type>(c_champQwTank4_Vol, typeof(double)));
            s_dicMappageColonneCsv_ChampData.Add(18, new KeyValuePair<string, Type>(c_champQwTank4_Temp, typeof(double)));
            s_dicMappageColonneCsv_ChampData.Add(19, new KeyValuePair<string, Type>(c_champQwTank4_Flow, typeof(double)));
            // External Fuel probe
            s_dicMappageColonneCsv_ChampData.Add(20, new KeyValuePair<string, Type>(c_champQwExFP_Id, typeof(string)));
            s_dicMappageColonneCsv_ChampData.Add(21, new KeyValuePair<string, Type>(c_champQwExTank_Vol, typeof(double)));
            s_dicMappageColonneCsv_ChampData.Add(22, new KeyValuePair<string, Type>(c_champQwExTank_Temp, typeof(double)));
            s_dicMappageColonneCsv_ChampData.Add(23, new KeyValuePair<string, Type>(c_champQwExTank_Flow, typeof(double)));
            s_dicMappageColonneCsv_ChampData.Add(24, new KeyValuePair<string, Type>(c_champQwStatut, typeof(int)));
        }

        //-----------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        [TableFieldProperty(c_champQwHost_Id, 128)]
        [DynamicField("Host Id")]
        [IndexField]
        public string HostId
        {
            get
            {
                return (string)Row[c_champQwHost_Id];
            }
            set
            {
                Row[c_champQwHost_Id] = value;
            }
        }



        //----------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        [TableFieldProperty(c_champFuPickup_Id, NullAutorise = true)]
        [DynamicField("Pickup Id")]
        [IndexField]
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

        /// <summary>
        /// Returns the Pickup (Timos Site)
        /// </summary>
        [DynamicField("Pichup")]
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

        //------------------------------------------------------------------------------
        /// <summary>
        /// Returns Timos Site Id
        /// </summary>
        [TableFieldProperty(c_champFuSite_Id, NullAutorise = true)]
        [DynamicField("Site Id")]
        [IndexField]
        public int? SiteId
        {
            get
            {
                return (int?)Row[c_champFuSite_Id, true];
            }
            set
            {
                Row[c_champFuSite_Id, true] = value;
            }
        }

        /// <summary>
        /// Returns Timos Site
        /// </summary>
        [DynamicField("Site")]
        public CSite Site
        {

            get
            {
                int? nId = SiteId;
                if (nId != null)
                {
                    CSite site = new CSite(ContexteDonnee);
                    if (site.ReadIfExists(nId.Value))
                        return site;
                }
                return null;
            }
            set
            {
                if (value != null)
                    SiteId = value.Id;
                else
                    SiteId = null;
            }
        }


        //-----------------------------------------------------------
        /// <summary>
        /// Qowisio data date
        /// </summary>
        [TableFieldProperty(c_champQwDateTime)]
        [DynamicField("Data Date")]
        [IndexField]
        public DateTime DataDate
        {
            get
            {
                return (DateTime)Row[c_champQwDateTime];
            }
            set
            {
                Row[c_champQwDateTime] = value;
            }
        }

        //---------------------------------------------------------------------------------
        /// <summary>
        /// Host Latitude
        /// </summary>
        [TableFieldProperty(c_champQwLatitude)]
        [DynamicField("Host Latitude")]
        public double Latitude
        {
            get
            {
                return (double)Row[c_champQwLatitude];
            }
            set
            {
                Row[c_champQwLatitude] = value;
            }
        }

        //----------------------------------------------------------------------------------
        /// <summary>
        /// Host Latitude
        /// </summary>
        [TableFieldProperty(c_champQwLongitude)]
        [DynamicField("Host Longitude")]
        public double Longitude
        {
            get
            {
                return (double)Row[c_champQwLongitude];
            }
            set
            {
                Row[c_champQwLongitude] = value;
            }
        }

        //----------------------------------------------------------------------------------
        /// <summary>
        /// Vehicule state code
        /// </summary>
        /// <remarks>
        /// 0 = Stopped<BR>
        /// 1 = Travelling
        /// </remarks>
        [TableFieldProperty(c_champQwStatut, NullAutorise = true)]
        [DynamicField("Pickup state code")]
        public int? CodeStatusVehicule
        {
            get
            {
                return Row.Get<int?>(c_champQwStatut);
            }
            set
            {
                Row[c_champQwStatut, true] = value;
            }
        }

        //----------------------------------------------------------------------------------
        /// <summary>
        /// Vehicule state
        /// </summary>
        [DynamicField("Pickup state")]
        public CStatutVehicule StatusVehicule
        {
            get
            {
                if (CodeStatusVehicule != null)
                    return new CStatutVehicule((EStatutVehicule)CodeStatusVehicule.Value);
                return null;
            }
            set
            {
                if (value == null)
                    CodeStatusVehicule = null;
                else
                    CodeStatusVehicule = value.CodeInt;
            }
        }


        #region Data from External Fuel Prob
        //---------------------------------------------------------------------------------
		/// <summary>
		/// Qowisio external Fuel Probe Id
		/// </summary>
		[TableFieldProperty ( c_champQwExFP_Id, 128 )]
		[DynamicField("External Fuel Probe Id")]
		public string ExternalFuelProbeId
		{
			get
			{
				return (string)Row[c_champQwExFP_Id];
			}
			set
			{
				Row[c_champQwExFP_Id] = value;
			}
		}

        //--------------------------------------------------------------------------------
        /// <summary>
        /// Timos external Tank Id
        /// </summary>
        [TableFieldProperty(c_champFuExTank_Id, NullAutorise = true)]
        [DynamicField("External Tank Id")]
        public int? ExternalTankId
        {
            get
            {
                return (int?)Row[c_champFuExTank_Id, true];
            }
            set
            {
                Row[c_champFuExTank_Id, true] = value;
            }
        }

        /// <summary>
        /// Timos Physical Equipment external Tank
        /// </summary>
        [DynamicField("External Tank")]
        public CEquipement ExternalTank
        {
            get
            {
                int? nId = ExternalTankId;
                if (nId != null)
                {
                    CEquipement externalTank = new CEquipement(ContexteDonnee);
                    if (externalTank.ReadIfExists(nId))
                        return externalTank;
                }
                return null;
            }
            set
            {
                if (value != null)
                    ExternalTankId = value.Id;
                else
                    ExternalTankId = null;
            }
        }



        //-----------------------------------------------------------
        /// <summary>
        /// Qowision external tank volume
        /// </summary>
        [TableFieldProperty(c_champQwExTank_Vol)]
        [DynamicField("External Tank Volume")]
        public double ExternalTankVolume
        {
            get
            {
                return (double)Row[c_champQwExTank_Vol];
            }
            set
            {
                Row[c_champQwExTank_Vol] = value;
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// Qowision external tank temperature
        /// </summary>
        [TableFieldProperty(c_champQwExTank_Temp)]
        [DynamicField("External Tank Temperature")]
        public double ExternalTankTemperature
        {
            get
            {
                return (double)Row[c_champQwExTank_Temp];
            }
            set
            {
                Row[c_champQwExTank_Temp] = value;
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// Qowision external tank flow
        /// </summary>
        [TableFieldProperty(c_champQwExTank_Flow)]
        [DynamicField("External Tank Flow")]
        public double ExternalTankFlow
        {
            get
            {
                return (double)Row[c_champQwExTank_Flow];
            }
            set
            {
                Row[c_champQwExTank_Flow] = value;
            }
        }

        #endregion

        #region Data from Internal Fuel Prob 1
        //---------------------------------------------------------------------------------
        /// <summary>
        /// Qowisio internal Fuel Probe 1 Id
        /// </summary>
        [TableFieldProperty(c_champQwInFP1_Id, 128)]
        [DynamicField("Internal Fuel Probe1 Id")]
        public string InternalFuelProbe1Id
        {
            get
            {
                return (string)Row[c_champQwInFP1_Id];
            }
            set
            {
                Row[c_champQwInFP1_Id] = value;
            }
        }

        //--------------------------------------------------------------------------------
        /// <summary>
        /// Timos internal Tank 1 Id
        /// </summary>
        [TableFieldProperty(c_champFuTank1_Id, NullAutorise = true)]
        [DynamicField("Tank1 Id")]
        public int? Tank1Id
        {
            get
            {
                return (int?)Row[c_champFuTank1_Id, true];
            }
            set
            {
                Row[c_champFuTank1_Id, true] = value;
            }
        }

        /// <summary>
        /// Timos Physical Equipment internal Tank 1
        /// </summary>
        [DynamicField("Tank 1")]
        public CEquipement Tank1
        {
            get
            {
                int? nId = Tank1Id;
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
                    Tank1Id = value.Id;
                else
                    Tank1Id = null;
            }
        }



        //-----------------------------------------------------------
        /// <summary>
        /// Qowision internal tank 1 volume
        /// </summary>
        [TableFieldProperty(c_champQwTank1_Vol)]
        [DynamicField("Tank 1 Volume")]
        public double Tank1Volume
        {
            get
            {
                return (double)Row[c_champQwTank1_Vol];
            }
            set
            {
                Row[c_champQwTank1_Vol] = value;
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// Qowision internal tank 1 temperature
        /// </summary>
        [TableFieldProperty(c_champQwTank1_Temp)]
        [DynamicField("Tank 1 Temperature")]
        public double Tank1Temperature
        {
            get
            {
                return (double)Row[c_champQwTank1_Temp];
            }
            set
            {
                Row[c_champQwTank1_Temp] = value;
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// Qowision internal tank 1 flow
        /// </summary>
        [TableFieldProperty(c_champQwTank1_Flow)]
        [DynamicField("Tank 1 Flow")]
        public double Tank1Flow
        {
            get
            {
                return (double)Row[c_champQwTank1_Flow];
            }
            set
            {
                Row[c_champQwTank1_Flow] = value;
            }
        }

        #endregion

        #region Data from Internal Fuel Prob 2
        //---------------------------------------------------------------------------------
        /// <summary>
        /// Qowisio internal Fuel Probe 2 Id
        /// </summary>
        [TableFieldProperty(c_champQwInFP2_Id, 128)]
        [DynamicField("Internal Fuel Probe2 Id")]
        public string InternalFuelProbe2Id
        {
            get
            {
                return (string)Row[c_champQwInFP2_Id];
            }
            set
            {
                Row[c_champQwInFP2_Id] = value;
            }
        }

        //--------------------------------------------------------------------------------
        /// <summary>
        /// Timos internal Tank 2 Id
        /// </summary>
        [TableFieldProperty(c_champFuTank2_Id, NullAutorise = true)]
        [DynamicField("Tank2 Id")]
        public int? Tank2Id
        {
            get
            {
                return (int?)Row[c_champFuTank2_Id, true];
            }
            set
            {
                Row[c_champFuTank2_Id, true] = value;
            }
        }

        /// <summary>
        /// Timos Physical Equipment internal Tank 2
        /// </summary>
        [DynamicField("Tank 2")]
        public CEquipement Tank2
        {
            get
            {
                int? nId = Tank2Id;
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
                    Tank2Id = value.Id;
                else
                    Tank2Id = null;
            }
        }



        //-----------------------------------------------------------
        /// <summary>
        /// Qowision internal tank 2 volume
        /// </summary>
        [TableFieldProperty(c_champQwTank2_Vol)]
        [DynamicField("Tank 2 Volume")]
        public double Tank2Volume
        {
            get
            {
                return (double)Row[c_champQwTank2_Vol];
            }
            set
            {
                Row[c_champQwTank2_Vol] = value;
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// Qowision internal tank 2 temperature
        /// </summary>
        [TableFieldProperty(c_champQwTank2_Temp)]
        [DynamicField("Tank 2 Temperature")]
        public double Tank2Temperature
        {
            get
            {
                return (double)Row[c_champQwTank2_Temp];
            }
            set
            {
                Row[c_champQwTank2_Temp] = value;
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// Qowision internal tank 2 flow
        /// </summary>
        [TableFieldProperty(c_champQwTank2_Flow)]
        [DynamicField("Tank 2 Flow")]
        public double Tank2Flow
        {
            get
            {
                return (double)Row[c_champQwTank2_Flow];
            }
            set
            {
                Row[c_champQwTank2_Flow] = value;
            }
        }

        #endregion

        #region Data from Internal Fuel Prob 3
        //---------------------------------------------------------------------------------
        /// <summary>
        /// Qowisio internal Fuel Probe 3 Id
        /// </summary>
        [TableFieldProperty(c_champQwInFP3_Id, 128)]
        [DynamicField("Internal Fuel Probe3 Id")]
        public string InternalFuelProbe3Id
        {
            get
            {
                return (string)Row[c_champQwInFP3_Id];
            }
            set
            {
                Row[c_champQwInFP3_Id] = value;
            }
        }

        //--------------------------------------------------------------------------------
        /// <summary>
        /// Timos internal Tank 3 Id
        /// </summary>
        [TableFieldProperty(c_champFuTank3_Id, NullAutorise = true)]
        [DynamicField("Tank3 Id")]
        public int? Tank3Id
        {
            get
            {
                return (int?)Row[c_champFuTank3_Id, true];
            }
            set
            {
                Row[c_champFuTank3_Id, true] = value;
            }
        }

        /// <summary>
        /// Timos Physical Equipment internal Tank 3
        /// </summary>
        [DynamicField("Tank 3")]
        public CEquipement Tank3
        {
            get
            {
                int? nId = Tank3Id;
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
                    Tank3Id = value.Id;
                else
                    Tank3Id = null;
            }
        }



        //-----------------------------------------------------------
        /// <summary>
        /// Qowision internal tank 3 volume
        /// </summary>
        [TableFieldProperty(c_champQwTank3_Vol)]
        [DynamicField("Tank 3 Volume")]
        public double Tank3Volume
        {
            get
            {
                return (double)Row[c_champQwTank3_Vol];
            }
            set
            {
                Row[c_champQwTank3_Vol] = value;
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// Qowision internal tank 3 temperature
        /// </summary>
        [TableFieldProperty(c_champQwTank3_Temp)]
        [DynamicField("Tank 3 Temperature")]
        public double Tank3Temperature
        {
            get
            {
                return (double)Row[c_champQwTank3_Temp];
            }
            set
            {
                Row[c_champQwTank3_Temp] = value;
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// Qowision internal tank 3 flow
        /// </summary>
        [TableFieldProperty(c_champQwTank3_Flow)]
        [DynamicField("Tank 3 Flow")]
        public double Tank3Flow
        {
            get
            {
                return (double)Row[c_champQwTank3_Flow];
            }
            set
            {
                Row[c_champQwTank3_Flow] = value;
            }
        }

        #endregion

        #region Data from Internal Fuel Prob 4
        //---------------------------------------------------------------------------------
        /// <summary>
        /// Qowisio internal Fuel Probe 4 Id
        /// </summary>
        [TableFieldProperty(c_champQwInFP4_Id, 128)]
        [DynamicField("Internal Fuel Probe4 Id")]
        public string InternalFuelProbe4Id
        {
            get
            {
                return (string)Row[c_champQwInFP4_Id];
            }
            set
            {
                Row[c_champQwInFP4_Id] = value;
            }
        }

        //--------------------------------------------------------------------------------
        /// <summary>
        /// Timos internal Tank 4 Id
        /// </summary>
        [TableFieldProperty(c_champFuTank4_Id, NullAutorise = true)]
        [DynamicField("Tank4 Id")]
        public int? Tank4Id
        {
            get
            {
                return (int?)Row[c_champFuTank4_Id, true];
            }
            set
            {
                Row[c_champFuTank4_Id, true] = value;
            }
        }

        /// <summary>
        /// Timos Physical Equipment internal Tank 4
        /// </summary>
        [DynamicField("Tank 4")]
        public CEquipement Tank4
        {
            get
            {
                int? nId = Tank4Id;
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
                    Tank4Id = value.Id;
                else
                    Tank4Id = null;
            }
        }



        //-----------------------------------------------------------
        /// <summary>
        /// Qowision internal tank 4 volume
        /// </summary>
        [TableFieldProperty(c_champQwTank4_Vol)]
        [DynamicField("Tank 4 Volume")]
        public double Tank4Volume
        {
            get
            {
                return (double)Row[c_champQwTank4_Vol];
            }
            set
            {
                Row[c_champQwTank4_Vol] = value;
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// Qowision internal tank 4 temperature
        /// </summary>
        [TableFieldProperty(c_champQwTank4_Temp)]
        [DynamicField("Tank 4 Temperature")]
        public double Tank4Temperature
        {
            get
            {
                return (double)Row[c_champQwTank4_Temp];
            }
            set
            {
                Row[c_champQwTank4_Temp] = value;
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// Qowision internal tank 4 flow
        /// </summary>
        [TableFieldProperty(c_champQwTank4_Flow)]
        [DynamicField("Tank 4 Flow")]
        public double Tank4Flow
        {
            get
            {
                return (double)Row[c_champQwTank4_Flow];
            }
            set
            {
                Row[c_champQwTank4_Flow] = value;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------
        public static void ClearAllCacheDatas()
        {
            lock (typeof(CLockerCacheDatasQowisio))
            {
                s_dicCacheHostId_SiteId.Clear();
                s_dicCacheFuelProbeId_EquipementId.Clear();
                s_dicCacheSiteId_TypeSiteId.Clear();
            }
        }

        //------------------------------------------------------------------------------------
        public CResultAErreur TraiteDataRowFromCsv(string strCsvDataRow)
        {
            CResultAErreur result = CResultAErreur.True;

            // Traite la data row de données CSV
            string[] listeDatas = strCsvDataRow.Split(';');

            string strHostId = listeDatas[0];
            if (strHostId == "")
            {
                string strErreur = "No host Id for CSV data row : " + strCsvDataRow;
                C2iEventLog.WriteErreur(strErreur);
                result.EmpileErreur(strErreur);
                return result;
            }
            HostId = strHostId;

            try{
                DateTime dt = ParseDateFromString(listeDatas[1]);
                if ( dt != null )
                {
                    //Vérifie l'existence de cet élément
                    CListeObjetDonneeGenerique<CCamusatQowisioData> lstToCount = new CListeObjetDonneeGenerique<CCamusatQowisioData>(ContexteDonnee);
                    lstToCount.Filtre = new CFiltreData ( 
                        c_champQwHost_Id+"=@1 and "+
                        c_champQwDateTime+"=@2",
                        strHostId,
                        dt);
                    if ( lstToCount.Count > 0 )
                    {
                        if ( IsNew() )
                            CancelCreate();
                        PointeSurLigne ( lstToCount[0].Id );
                    }
                }
            }
            catch ( Exception e )
            {
            }


            int? nIdSite = TrouveAssociationIdHost_IdSite(strHostId, ContexteDonnee);
            if (nIdSite == null)
            {
                string strErreur = "Error in TraiteDataRowFromCsv: No associatied Site found for Host Id : " + strHostId;
                C2iEventLog.WriteErreur(strErreur);
                result.EmpileErreur(strErreur);
                return result;
            }

            int nIdTypSite = -1;
            lock (typeof(CLockerCacheDatasQowisio))
            {
                if (!s_dicCacheSiteId_TypeSiteId.TryGetValue(nIdSite.Value, out nIdTypSite))
                {
                    CSite site = new CSite(ContexteDonnee);
                    if (site.ReadIfExists(nIdSite))
                    {
                        nIdTypSite = site.TypeSite.Id;
                        s_dicCacheSiteId_TypeSiteId[nIdSite.Value] = nIdTypSite;
                    }
                }
            }
            if (nIdTypSite == c_nIdTypeSiteTelecom)
                SiteId = nIdSite;
            else if (nIdTypSite == c_nIdTypeSitePickup)
                PickupId = nIdSite;
            else
            {
                string strErreur = "Error in Site Type for site Id = " + nIdSite.Value;
                C2iEventLog.WriteErreur(strErreur);
                result.EmpileErreur(strErreur);
                return result;
            }

            int nNbColonnes = listeDatas.Length;
            for (int i = 1; i < nNbColonnes; i++)
            {
                string strDataSource = listeDatas[i];

                KeyValuePair<string, Type> defChampData;
                if (s_dicMappageColonneCsv_ChampData.TryGetValue(i, out defChampData))
                {
                    string strNomChamp = defChampData.Key;
                    Type typeDonnee = defChampData.Value;

                    if (typeDonnee == typeof(DateTime))
                    {
                        try
                        {
                            DateTime date = ParseDateFromString(strDataSource);
                            Row[strNomChamp] = date;
                            continue;
                        }
                        catch { }
                    }
                    if (typeDonnee == typeof(int?))
                    {
                        if (strDataSource.Trim() == "")
                            Row[strNomChamp] = DBNull.Value;
                        else
                        {
                            try
                            {
                                int nVal = Int32.Parse(strDataSource);
                                Row[strNomChamp] = nVal;
                            }
                            catch
                            {
                                Row[strNomChamp] = DBNull.Value;
                            }
                        }
                    }

                    if (typeDonnee == typeof(double))
                    {
                        try
                        {
                            double valeur = CUtilDouble.DoubleFromString(strDataSource);
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

            result += TraiteAssociationsFuelProbeTank();

            return result;
        }

        public static int? TrouveAssociationIdHost_IdSite(string strHostId, CContexteDonnee contexte)
        {
            int nIdSite = -1;
            if (strHostId != "")
            {
                lock (typeof(CLockerCacheDatasQowisio))
                {
                    if (s_dicCacheHostId_SiteId.TryGetValue(strHostId, out nIdSite))
                    {
                        return nIdSite;
                    }
                    else
                    {
                        CResultAErreur result = GetEquipementLogiqueFromQowisioId(strHostId, contexte);
                        if (!result)
                            return null;
                        CEquipementLogique qowisioBox = result.Data as CEquipementLogique;
                        if (qowisioBox != null)
                        {
                            // Recherche le Pickup correspondant
                            CSite site = qowisioBox.Site;
                            if (site != null && site.Id != c_nIdSiteQowisionAwaitingElements)
                            {
                                nIdSite = site.Id;
                                s_dicCacheHostId_SiteId[strHostId] = nIdSite;
                                return nIdSite;
                            }
                        }
                    }
                }
            }

            return null;
        }

        //----------------------------------------------------------------------------------------
        private CResultAErreur TraiteAssociationsFuelProbeTank()
        {
            CResultAErreur result = CResultAErreur.True;

            try
            {
                ExternalTankId = TrouveAssociationIdFuelProbe_IdEquipement(ExternalFuelProbeId, ContexteDonnee);
                Tank1Id = TrouveAssociationIdFuelProbe_IdEquipement(InternalFuelProbe1Id, ContexteDonnee);
                Tank2Id = TrouveAssociationIdFuelProbe_IdEquipement(InternalFuelProbe2Id, ContexteDonnee);
                Tank3Id = TrouveAssociationIdFuelProbe_IdEquipement(InternalFuelProbe3Id, ContexteDonnee);
                Tank4Id = TrouveAssociationIdFuelProbe_IdEquipement(InternalFuelProbe4Id, ContexteDonnee);
            }
            catch (Exception ex)
            {
                result.EmpileErreur(ex.Message);
            }

            return result;

        }

        //-----------------------------------------------------------------------------------------
        public static int? TrouveAssociationIdFuelProbe_IdEquipement(string strIdFuelProbe, CContexteDonnee contexte)
        {
            int nIdEquipementPhysique = -1;
            if (strIdFuelProbe != "")
            {
                lock (typeof(CLockerCacheDatasQowisio))
                {
                    if (s_dicCacheFuelProbeId_EquipementId.TryGetValue(strIdFuelProbe, out nIdEquipementPhysique))
                    {
                        return nIdEquipementPhysique;
                    }
                    else
                    {
                        CResultAErreur result = GetEquipementLogiqueFromQowisioId(strIdFuelProbe, contexte);
                        if (result)
                        {
                            CEquipementLogique logicalFuelProbe = result.Data as CEquipementLogique;
                            if (logicalFuelProbe != null)
                            {
                                CEquipement tank = logicalFuelProbe.GetValeurChamp(c_nIdChampTimosFuelProbeAssociatedTank) as CEquipement;
                                if (tank != null)
                                {
                                    nIdEquipementPhysique = tank.Id;
                                    s_dicCacheFuelProbeId_EquipementId[strIdFuelProbe] = nIdEquipementPhysique;
                                    return nIdEquipementPhysique;
                                }
                            }
                        }
                    }
                }
            }
            return null;
        }

        //-----------------------------------------------------------------------------------------
        public static DateTime ParseDateFromString(string strDate)
        {
            try
            {
                int nAnnee = Int32.Parse(strDate.Substring(0, 4));
                int nMois = Int32.Parse(strDate.Substring(4, 2));
                int nJour = Int32.Parse(strDate.Substring(6, 2));
                int nHeure = Int32.Parse(strDate.Substring(8, 2));
                int nMinute = Int32.Parse(strDate.Substring(10, 2));
                int nSeconde = Int32.Parse(strDate.Substring(12, 2));

                DateTime date = new DateTime(nAnnee, nMois, nJour, nHeure, nMinute, nSeconde, DateTimeKind.Utc);
                return date;
            }
            catch (Exception e)
            {
                C2iEventLog.WriteErreur("Error in ParseDateFromString : " + e.Message);
            }
            
            return DateTime.MinValue;
        }

        //-----------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strQowisioId"></param>
        /// <param name="contexte"></param>
        /// <returns></returns>
        public static CResultAErreur GetEquipementLogiqueFromQowisioId(string strQowisioId, CContexteDonnee contexte)
        {
            CResultAErreur result = CResultAErreur.True;

            CFiltreData filtre = new CFiltreDataAvance(
                CEquipementLogique.c_nomTable,
                CRelationEquipementLogique_ChampCustom.c_nomTable + "." +
                CChampCustom.c_nomTable + "." + CChampCustom.c_champId + " = @1 AND " +
                CRelationEquipementLogique_ChampCustom.c_nomTable + "." +
                CRelationEquipementLogique_ChampCustom.c_champValeurString + " = @2",
                c_nIdChampTimosQowisioId,
                strQowisioId);

            try
            {
                CEquipementLogique equipementLogiqueQowisio = new CEquipementLogique(contexte);
                if (equipementLogiqueQowisio.ReadIfExists(filtre))
                {
                    result.Data = equipementLogiqueQowisio;
                    return result;
                }
            }
            catch (Exception e)
            {
                C2iEventLog.WriteErreur("Error in GetEquipementLogiqueFromQowisioId : " + e.Message);
                result.EmpileErreur(e.Message);
                return result;
            }

            return result;
        }


        [DynamicMethod("Returns tank volume (-1 if no data)", "Tank id")]
        public double GetTankVolume(int nIdTank)
        {
            if (nIdTank == Tank1Id)
                return Tank1Volume;
            if (nIdTank == Tank2Id)
                return Tank2Volume;
            if (nIdTank == Tank3Id)
                return Tank3Volume;
            if (nIdTank == Tank4Id)
                return Tank4Volume;
            if (nIdTank == ExternalTankId)
                return ExternalTankVolume;
            return -1;
        }

        [DynamicMethod("Returns tank temperature (-1 if no data)", "Tank id")]
        public double GetTankTemperature(int nIdTank)
        {
            if (nIdTank == Tank1Id)
                return Tank1Temperature;
            if (nIdTank == Tank2Id)
                return Tank2Temperature;
            if (nIdTank == Tank3Id)
                return Tank3Temperature;
            if (nIdTank == Tank4Id)
                return Tank4Temperature;
            if (nIdTank == ExternalTankId)
                return ExternalTankTemperature;
            return -1;
        }

        [DynamicMethod("Returns tank flow (-1 if no data)", "Tank id")]
        public double GetTankFlow(int nIdTank)
        {
            if (nIdTank == Tank1Id)
                return Tank1Flow;
            if (nIdTank == Tank2Id)
                return Tank2Flow;
            if (nIdTank == Tank3Id)
                return Tank3Flow;
            if (nIdTank == Tank4Id)
                return Tank4Flow;
            if (nIdTank == ExternalTankId)
                return ExternalTankFlow;
            return -1;
        }

        public static CResultAErreurType<CCamusatQowisioData> StaticTraiteDataRowFromCsv(CContexteDonnee contexte, string strCsvRow)
        {
            CResultAErreurType<CCamusatQowisioData> result = new CResultAErreurType<CCamusatQowisioData>();
            result.Result = true;
            CCamusatQowisioData newData = new CCamusatQowisioData(contexte);

            newData.CreateNewInCurrentContexte();
            CResultAErreur resTmp = CResultAErreur.True;
            resTmp = newData.TraiteDataRowFromCsv(strCsvRow);
            if (!resTmp && newData.IsNew())
                newData.CancelCreate();

            if (!resTmp)
                result.Erreur = resTmp.Erreur;
            else
                result.DataType = newData;
            return result;
        }
    }

    public class CLockerCacheDatasQowisio
    {

    }


}
