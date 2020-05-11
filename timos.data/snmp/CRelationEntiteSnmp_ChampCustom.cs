using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;
using futurocom.snmp;
using System.Net;

namespace timos.data.snmp
{
	/// <summary>
    /// Relation entre une <see cref="CEntiteSnmp">Entité SNMP</see> et un 
    /// <see cref="sc2i.data.dynamic.CChampCustom">Champ personnalisé</see>.
	/// </summary>
    [DynamicClass("Snmp entity / Custom field")]
	[ObjetServeurURI("CRelationEntiteSnmp_ChampCustomServeur")]
	[Table(CRelationEntiteSnmp_ChampCustom.c_nomTable, CRelationEntiteSnmp_ChampCustom.c_champId,true)]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModuleSNMP)]
	public class CRelationEntiteSnmp_ChampCustom : CRelationElementAChamp_ChampCustom,
        IElementADonneePourMediationSNMP
	{
		public const string c_nomTable = "SNMPETT_CUSTOM_FIELD";
		public const string c_champId = "SNMPETT_CUSTFLD_ID";
        public const string c_champDateDonneeSnmp = "SNMPETT_DATE_SNMP";
        public const string c_champLastFromSnmp = "SNMPETT_LAST_SNMP_VALUE";
        public const string c_champLastFromSnmpType = "SNMPETT_LAST_SNMP_TYPE";

        private const string c_champValeurSnmpLueEnDirect = "SNMP_ETT_DIRECT_SNMP_VALUE";

		//-------------------------------------------------------------------
#if PDA
		public CRelationEntiteSnmp_ChampCustom()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationEntiteSnmp_ChampCustom(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationEntiteSnmp_ChampCustom(System.Data.DataRow row)
			:base(row)
		{
		}

		//-------------------------------------------------------------------
		public override Type GetTypeElementAChamps()
		{
			return typeof(CEntiteSnmp);
		}

		//-------------------------------------------------------------------
		public override string GetNomTable()
		{
			return c_nomTable;
		}
		//-------------------------------------------------------------------
		public override string GetChampId()
		{
			return c_champId;
		}

		
		//-------------------------------------------------------------------
        /// <summary>
        /// Entité SNMP, objet de la relation
        /// </summary>
		[Relation(
			CEntiteSnmp.c_nomTable,
            CEntiteSnmp.c_champId,
            CEntiteSnmp.c_champId, 
			true, 
			true, 
			true)]
		[DynamicField("Snmp entity")]
		public override IElementAChamps ElementAChamps
		{
			get
			{
				return (IElementAChamps)GetParent(CEntiteSnmp.c_champId, typeof(CEntiteSnmp));
			}
			set
			{
				SetParent(CEntiteSnmp.c_champId, (CEntiteSnmp)value);
			}
		}

		//-------------------------------------------------------------------
        /// <summary>
        /// Date de dernière mise à jour automatique<br/>
        /// à partir de l'interrogation SNMP
        /// </summary>
        [TableFieldProperty(c_champDateDonneeSnmp, true, IsInDb = false)]
        [DynamicField("Snmp sync last date")]
        public CDateTimeEx DateSynchroSnmp
        {
            get
            {
                if (Row[c_champDateDonneeSnmp] == DBNull.Value)
                    return null;
                else
                    return (CDateTimeEx)Row[c_champDateDonneeSnmp];
            }
            set
            {
                object val = DBNull.Value;
                if (value != null)
                    val = value;
                CContexteDonnee.ChangeRowSansDetectionModification ( Row.Row, c_champDateDonneeSnmp, val );
            }
        }

        //-------------------------------------------------------------------
        /// <summary>
        /// Permet de stocker la valeur lue dans SNMP, sans modification de la DataRow
        /// non stocké en base
        /// </summary>
        [TableFieldProperty(c_champLastFromSnmp, 1024, IsInDb=false)]
        public string LastSnmpValueString
        {
            get
            {
                return (string)Row[c_champLastFromSnmp];
            }
            set
            {
                CContexteDonnee.ChangeRowSansDetectionModification(Row.Row, c_champLastFromSnmp, value);
            }
        }

        
		//-----------------------------------------------------------
        /// <summary>
        /// Permet de stocker le type lu dans SNMP, sans modification de la DataRow
        /// Non stocké en base
        /// </summary>
		[TableFieldProperty ( c_champLastFromSnmpType, 255, IsInDb = false)]
		public string LastFromSnmpTypeString
		{
			get
			{
				return Row[c_champLastFromSnmpType] as string;
			}
			set
			{
                CContexteDonnee.ChangeRowSansDetectionModification(Row.Row, c_champLastFromSnmpType, value);
			}
		}

        //-----------------------------------------------------------
        public Type LastFromSnmpType
        {
            get{
                return CActivatorSurChaine.GetType(LastFromSnmpTypeString);
            }
            set{
                LastFromSnmpTypeString = value.ToString();
            }
        }


        //-----------------------------------------------------------
        /// <summary>
        /// Dernière valeur lue par interrogation SNMP
        /// </summary>
        [DynamicField("Last Snmp readed value")]
        public object LastSnmpValue
        {
            get
            {
                Type tp = LastFromSnmpType;
                if (tp == typeof(DBNull))
                    return null;
                if (tp != null)
                    return CUtilTexte.FromUniversalString(LastSnmpValueString, tp);
                return "";
            }
            set
            {
                if (value == null)
                {
                    LastFromSnmpType = typeof(DBNull);
                    LastSnmpValueString = "";
                }
                else
                {
                    LastFromSnmpType = value.GetType();
                    LastSnmpValueString = CUtilTexte.ToUniversalString(value);
                    DateSynchroSnmp = DateTime.Now;
                }
            }
        }

        //-----------------------------------------------------------
        public CResultAErreur UpdateSnmpValue()
        {
            CResultAErreur result = CResultAErreur.True;
            CEntiteSnmp entite = ElementAChamps as CEntiteSnmp;
            if (entite != null)
                return entite.ReadChampSnmp(ChampCustom.Id);
            return result;
        }

        //-----------------------------------------------------------
        public CResultAErreur WriteSnmpValue()
        {
            CResultAErreur result = CResultAErreur.True;
            CEntiteSnmp entite = ElementAChamps as CEntiteSnmp;
            if (entite != null)
                return entite.SendToSnmp(false, ChampCustom.Id);
            return result;
        }



        #region IElementADonneePourMediationSNMP Membres

        public int[] IdsProxysConcernesParDonneesMediation
        {
            get
            {
                CEntiteSnmp entite = ElementAChamps as CEntiteSnmp;
                if (entite != null)
                    return entite.IdsProxysConcernesParDonneesMediation;
                return new int[0];
            }
        }

        public int[] IdsProxysConcernesParConfigurationProxy
        {
            get
            {
                CEntiteSnmp entite = ElementAChamps as CEntiteSnmp;
                if (entite != null)
                    return entite.IdsProxysConcernesParConfigurationProxy;
                return new int[0];
            }
        }

        #endregion
    }
}
