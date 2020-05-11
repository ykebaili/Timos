using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using sc2i.data;
using sc2i.common;
using timos.data;
using sc2i.expression;

namespace spv.data
{
	[Table(CSpvEquip.c_nomTable,CSpvEquip.c_nomTableInDb,new string[]{ CSpvEquip.c_champEQUIP_ID}, ModifiedByTrigger=true)]
	[ObjetServeurURI("CSpvEquipServeur")]
	[DynamicClass("Spv Equipment")]
    [AutoExec("CompleteProprietesEquipement")]
    [RechercheRapide(CSpvEquip.c_champSITE_EQUIP_COMMENT)]
    public class CSpvEquip : CMappableAvecTimos<CEquipementLogique, CSpvEquip>, 
        IObjetSansVersion, 
        ISpvObjetAvecAccesAlarmeCable,
        IElementACoeffOperationnel
	{
        public enum EModeEtiquetage
        {
            ParReference = 0,
            // ParPostionGeo = 1, dans SMT, traité comme un commentaire
            ParCommentaire = 2,
            ParAddrIP = 3
        }

		public const string c_nomTable = "SPV_EQUIP";
		public const string c_nomTableInDb = "EQUIP";
		public const string c_champEQUIP_ID ="EQUIP_ID";
		public const string c_champTYPEQ_ID ="TYPEQ_ID";
		public const string c_champTYPEQ_NOM ="TYPEQ_NOM";
		public const string c_champSITE_ID ="SITE_ID";
		public const string c_champEQUIP_REF ="EQUIP_REF";
		public const string c_champEQUIP_CLASSID ="EQUIP_CLASSID";
		public const string c_champEQUIP_SOFT ="EQUIP_SOFT";
		public const string c_champEQUIP_CARACT ="EQUIP_CARACT";
		public const string c_champEQUIP_COMMUT ="EQUIP_COMMUT";
		public const string c_champBAIE_EQUIP_CARTE ="BAIE_EQUIP_CARTE";
		public const string c_champSITE_EQUIP_COMMENT ="SITE_EQUIP_COMMENT";
		public const string c_champEQUIP_UNICITE ="EQUIP_UNICITE";
		public const string c_champEQUIP_MASQUE ="EQUIP_MASQUE";
		public const string c_champEQUIP_ADDRIP ="EQUIP_ADDRIP";
		public const string c_champEQUIP_BINDINGID ="EQUIP_BINDINGID";
		public const string c_champTYPEQINC_ID ="TYPEQINC_ID";
		public const string c_champEQUIP_INDEXSNMP ="EQUIP_INDEXSNMP";
		public const string c_champTYPEQ_BINDINGID ="TYPEQ_BINDINGID";
		public const string c_champEQUIP_CMNTE ="EQUIP_CMNTE";
		public const string c_champEQUIP_TOSURV ="EQUIP_TOSURV";
		public const string c_champEQUIP_TOREDECOUV ="EQUIP_TOREDECOUV";
		public const string c_champEQUIP_VIRTUEL ="EQUIP_VIRTUEL";
		public const string c_champEQUIP_NBPORTS ="EQUIP_NBPORTS";
		public const string c_champEQUIP_NBPORTSOCC ="EQUIP_NBPORTSOCC";
		public const string c_champEQUIP_NBPORTSRESER ="EQUIP_NBPORTSRESER";
		public const string c_champEQUIP_EMNAME ="EQUIP_EMNAME";
		public const string c_champEQUIP_REACHABLE ="EQUIP_REACHABLE";
		public const string c_champEQUIP_UNICITE_REF ="EQUIP_UNICITE_REF";
		public const string c_champEQUIP_UNICITE_COMMENT ="EQUIP_UNICITE_COMMENT";
		public const string c_champEQUIP_UNICITE_SNMP ="EQUIP_UNICITE_SNMP";
		public const string c_champEQUIP_FLAG_NOM_REF ="EQUIP_FLAG_NOM_REF";
		public const string c_champEQUIP_FLAG_NOM_POS ="EQUIP_FLAG_NOM_POS";
		public const string c_champEQUIP_FLAG_NOM_COM ="EQUIP_FLAG_NOM_COM";
		public const string c_champEQUIP_FLAG_NOM_ADR ="EQUIP_FLAG_NOM_ADR";
		public const string c_champEQUIP_FLAG_UNI_REF ="EQUIP_FLAG_UNI_REF";
		public const string c_champEQUIP_FLAG_UNI_POS ="EQUIP_FLAG_UNI_POS";
		public const string c_champEQUIP_FLAG_UNI_COM ="EQUIP_FLAG_UNI_COM";
		public const string c_champEQUIP_FLAG_UNI_ADR ="EQUIP_FLAG_UNI_ADR";
		public const string c_champEQUIP_ETIQ_VUE ="EQUIP_ETIQ_VUE";
        public const string c_champEQUIP_FREQE = "EQUIP_FREQE";
        public const string c_champSmtEquipementLogique_Id = "SMTEQUIPEMENT_ID";
        public const int c_classID = 1018;		// Equipement

		public const int c_nMinSnmpIndexMediation = 1;
		public const int c_nMaxSnmpIndexMediation = 20;
        public const int c_NbPortsParCarteGTR = 48;
		
		///////////////////////////////////////////////////////////////
		public CSpvEquip( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public CSpvEquip( DataRow row )
			:base(row)
		{
		}

        //////////////////////////////////////////////////////////////
        public static void CompleteProprietesEquipement()
        {
            CMappableAvecTimos<CEquipementLogique, CSpvEquip>.CompleteProprietesObjetTimos("Supervision data");
        }
		
		///////////////////////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
			//TODO : Insérer ici le code d'initalisation
            Row[c_champEQUIP_CLASSID] = c_classID;
            ChoixEtiquette = (Int32?) EModeEtiquetage.ParCommentaire;
            NommageParReference = false;
            NommageParGeographie = false;
            NommageParCommentaire = true;
            NommageParAdresseIP = false;
            FlagUniciteReference = false;
            FlagUniciteGeographie = false;
            FlagUniciteCommentaire = true;
            FlagUniciteAdresseIP = false;
		}
		
		///////////////////////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[] {c_champEQUIP_ID};
		}
		
		///////////////////////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
                return I.T("Equipment @1|30016", CommentairePourSituer);
			}
		}
		

		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTYPEQ_NOM,40)]
		[DynamicField("Equipement type label")]
		public System.String LibelleTypeEquipement
		{
			get
			{
				return (System.String)Row[c_champTYPEQ_NOM];
			}
			set
			{
				Row[c_champTYPEQ_NOM,true]=value;
			}
		}
		


		///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champEQUIP_REF, 40, NullAutorise = true)]
		[DynamicField("Reference")]
		public System.String Reference
		{
			get
			{
				if (Row[c_champEQUIP_REF] == DBNull.Value)
					return null;
				return (System.String)Row[c_champEQUIP_REF];
			}
			set
			{
				Row[c_champEQUIP_REF,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champEQUIP_CLASSID)]
		[DynamicField("Class ID")]
        public System.Int32 ClassId
		{
			get
			{
				return (System.Int32)Row[c_champEQUIP_CLASSID];
			}
		}
		
		
		///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champEQUIP_CARACT, 40, NullAutorise = true)]
		[DynamicField("Equipement type SNMP reference")]
		public System.String ReferenceSnmpTypeEquipement
		{
			get
			{
                if (Row[c_champEQUIP_CARACT] == DBNull.Value)
                    return null;
				return (System.String)Row[c_champEQUIP_CARACT];
			}
			set
			{
				Row[c_champEQUIP_CARACT,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champEQUIP_COMMUT)]
		[DynamicField("Switch position")]
		public System.Int32 PositionCommutateur
		{
			get
			{
				return (System.Int32)Row[c_champEQUIP_COMMUT];
			}
			set
			{
				Row[c_champEQUIP_COMMUT,true]=value;
			}
		}
		
        /*
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champBAIE_EQUIP_NICHE,5)]
		[DynamicField("BAIE_EQUIP_NICHE")]
		public System.String BAIE_EQUIP_NICHE
		{
			get
			{
				if (Row[c_champBAIE_EQUIP_NICHE] == DBNull.Value)
					return null;
				return (System.String)Row[c_champBAIE_EQUIP_NICHE];
			}
			set
			{
				Row[c_champBAIE_EQUIP_NICHE,true]=value;
			}
		}*/
		
        /*
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champBAIE_EQUIP_EMPL,5)]
		[DynamicField("BAIE_EQUIP_EMPL")]
		public System.String BAIE_EQUIP_EMPL
		{
			get
			{
				if (Row[c_champBAIE_EQUIP_EMPL] == DBNull.Value)
					return null;
				return (System.String)Row[c_champBAIE_EQUIP_EMPL];
			}
			set
			{
				Row[c_champBAIE_EQUIP_EMPL,true]=value;
			}
		}*/
		

		///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champBAIE_EQUIP_CARTE, 5, NullAutorise = true)]
		[DynamicField("Slot number")]
		public System.String NumeroCarte
		{
			get
			{
				if (Row[c_champBAIE_EQUIP_CARTE] == DBNull.Value)
					return null;
				return (System.String)Row[c_champBAIE_EQUIP_CARTE];
			}
			set
			{
				Row[c_champBAIE_EQUIP_CARTE,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champSITE_EQUIP_COMMENT, 80, NullAutorise = true)]
		[DynamicField("Label")]
		public System.String CommentairePourSituer
		{
			get
			{
				if (Row[c_champSITE_EQUIP_COMMENT] == DBNull.Value)
					return null;
				return (System.String)Row[c_champSITE_EQUIP_COMMENT];
			}
			set
			{
				Row[c_champSITE_EQUIP_COMMENT,true]=value;
			}
		}
		
		
		///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champEQUIP_MASQUE, NullAutorise = true)]
		[DynamicField("Mask all alarms flag")]
		public System.Int32? MasqueAlarmes
		{
			get
			{
				if (Row[c_champEQUIP_MASQUE] == DBNull.Value)
					return null;
				return (System.Int32?)Row[c_champEQUIP_MASQUE];
			}
			set
			{
				Row[c_champEQUIP_MASQUE,true]=value;
			}
		}
		
		
		///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champEQUIP_ADDRIP, 16, NullAutorise = true)]
		[DynamicField("IP Address")]
        public System.String AdresseIP
		{
			get
			{
				if (Row[c_champEQUIP_ADDRIP] == DBNull.Value)
					return null;
				return (System.String)Row[c_champEQUIP_ADDRIP];
			}
			set
			{
				Row[c_champEQUIP_ADDRIP,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
     /*   [TableFieldProperty(c_champEQUIP_BINDINGID, NullAutorise = true)]
		[DynamicField("Container equipment ID")]
		public System.Int32? IDEquipementEnglobant
		{
			get
			{
				if (Row[c_champEQUIP_BINDINGID] == DBNull.Value)
					return null;
				return (System.Int32?)Row[c_champEQUIP_BINDINGID];
			}
			set
			{
				Row[c_champEQUIP_BINDINGID,true]=value;
			}
		}
		*/
		
		///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champEQUIP_INDEXSNMP, 256, NullAutorise = true)]
		[DynamicField("Snmp index")]
        public System.String IndexSnmp
		{
			get
			{
				if (Row[c_champEQUIP_INDEXSNMP] == DBNull.Value)
					return null;
				return (System.String)Row[c_champEQUIP_INDEXSNMP];
			}
			set
			{
				Row[c_champEQUIP_INDEXSNMP,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
    /*    [TableFieldProperty(c_champTYPEQ_BINDINGID, NullAutorise = true)]
		[DynamicField("Container equipement type")]
		public System.Int32? IDTypeEquipementEnglobant
		{
			get
			{
				if (Row[c_champTYPEQ_BINDINGID] == DBNull.Value)
					return null;
				return (System.Int32?)Row[c_champTYPEQ_BINDINGID];
			}
			set
			{
				Row[c_champTYPEQ_BINDINGID,true]=value;
			}
		}
		*/
		
		///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champEQUIP_CMNTE, 80, NullAutorise = true)]
		[DynamicField("Snmp community")]
        public System.String CommunauteSnmp
		{
			get
			{
				if (Row[c_champEQUIP_CMNTE] == DBNull.Value)
					return null;
				return (System.String)Row[c_champEQUIP_CMNTE];
			}
			set
			{
				Row[c_champEQUIP_CMNTE,true]=value;
			}
		}
		
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champEQUIP_TOSURV)]
		[DynamicField("To supervise flag")]
        public bool ASuperviser
		{
			get
			{
                if (Row[c_champEQUIP_TOSURV] == DBNull.Value)
                    return false;
				return (bool)Row[c_champEQUIP_TOSURV];
			}
			set
			{
				Row[c_champEQUIP_TOSURV,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champEQUIP_TOREDECOUV)]
		[DynamicField("To discover periodically flag")]
        public bool ARedecouvrirPeriodiquement
		{
			get
			{
                if (Row[c_champEQUIP_TOREDECOUV] == DBNull.Value)
                    return false;
				return (bool)Row[c_champEQUIP_TOREDECOUV];
			}
			set
			{
				Row[c_champEQUIP_TOREDECOUV,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champEQUIP_VIRTUEL)]
		[DynamicField("Virtual equipement flag")]
		public System.Boolean EquipementVirtuel
		{
			get
			{
                if (Row[c_champEQUIP_VIRTUEL] == DBNull.Value)
                    return false;
				return (System.Boolean)Row[c_champEQUIP_VIRTUEL];
			}
			set
			{
				Row[c_champEQUIP_VIRTUEL,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champEQUIP_NBPORTS)]
		[DynamicField("Port number")]
		public System.Int32 NombreDePorts
		{
			get
			{
				return (System.Int32)Row[c_champEQUIP_NBPORTS];
			}
			set
			{
				Row[c_champEQUIP_NBPORTS,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champEQUIP_NBPORTSOCC)]
		[DynamicField("Busy port number")]
		public System.Int32 NombreDePortsOccupes
		{
			get
			{
				return (System.Int32)Row[c_champEQUIP_NBPORTSOCC];
			}
			set
			{
				Row[c_champEQUIP_NBPORTSOCC,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champEQUIP_NBPORTSRESER)]
		[DynamicField("Reserved port number")]
		public System.Int32 NombreDePortsReserves
		{
			get
			{
				return (System.Int32)Row[c_champEQUIP_NBPORTSRESER];
			}
			set
			{
				Row[c_champEQUIP_NBPORTSRESER,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champEQUIP_EMNAME, 40, NullAutorise = true)]
		[DynamicField("Mediation equipment")]
		public System.String EquipementDeMediation
		{
			get
			{
				if (Row[c_champEQUIP_EMNAME] == DBNull.Value)
					return null;
				return (System.String)Row[c_champEQUIP_EMNAME];
			}
			set
			{
				Row[c_champEQUIP_EMNAME,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champEQUIP_REACHABLE, NullAutorise = true)]
		[DynamicField("Reachable flag")]
		public System.Boolean? EquipementJoignable
		{
			get
			{
				if (Row[c_champEQUIP_REACHABLE] == DBNull.Value)
					return false;
				return (System.Boolean?)Row[c_champEQUIP_REACHABLE];
			}
			set
			{
				Row[c_champEQUIP_REACHABLE,true]=value;
			}
		}

        ///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champEQUIP_UNICITE, 100, NullAutorise = true)]
        [DynamicField("Geographical unique designation")]
        public System.String UniciteGeographie
        {
            get
            {
                if (Row[c_champEQUIP_UNICITE] == DBNull.Value)
                    return null;
                return (System.String)Row[c_champEQUIP_UNICITE];
            }
            set
            {
                Row[c_champEQUIP_UNICITE, true] = value;
            }
        }

		///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champEQUIP_UNICITE_REF, 100, NullAutorise = true)]
		[DynamicField("Reference unique designation")]
		public System.String UniciteReference
		{
			get
			{
				if (Row[c_champEQUIP_UNICITE_REF] == DBNull.Value)
					return null;
				return (System.String)Row[c_champEQUIP_UNICITE_REF];
			}
			set
			{
				Row[c_champEQUIP_UNICITE_REF,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champEQUIP_UNICITE_COMMENT, 100, NullAutorise = true)]
		[DynamicField("Commentary unique designation")]
		public System.String UniciteCommentaire
		{
			get
			{
				if (Row[c_champEQUIP_UNICITE_COMMENT] == DBNull.Value)
					return null;
				return (System.String)Row[c_champEQUIP_UNICITE_COMMENT];
			}
			set
			{
				Row[c_champEQUIP_UNICITE_COMMENT,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champEQUIP_UNICITE_SNMP, 100, NullAutorise = true)]
		[DynamicField("SNMP unique designation")]
		public System.String UniciteAdresseIP
		{
			get
			{
				if (Row[c_champEQUIP_UNICITE_SNMP] == DBNull.Value)
					return null;
				return (System.String)Row[c_champEQUIP_UNICITE_SNMP];
			}
			set
			{
				Row[c_champEQUIP_UNICITE_SNMP,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champEQUIP_FLAG_NOM_REF, NullAutorise = true)]
		[DynamicField("Identified by reference flag")]
		public System.Boolean? NommageParReference
		{
			get
			{
				if (Row[c_champEQUIP_FLAG_NOM_REF] == DBNull.Value)
					return null;
                return (System.Boolean?)Row[c_champEQUIP_FLAG_NOM_REF];
			}
			set
			{
				Row[c_champEQUIP_FLAG_NOM_REF,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champEQUIP_FLAG_NOM_POS, NullAutorise = true)]
		[DynamicField("Identified by geography flag")]
        public System.Boolean? NommageParGeographie
		{
			get
			{
				if (Row[c_champEQUIP_FLAG_NOM_POS] == DBNull.Value)
					return null;
                return (System.Boolean?)Row[c_champEQUIP_FLAG_NOM_POS];
			}
			set
			{
				Row[c_champEQUIP_FLAG_NOM_POS,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champEQUIP_FLAG_NOM_COM, NullAutorise = true)]
		[DynamicField("Identified by comment flag")]
        public System.Boolean? NommageParCommentaire
		{
			get
			{
				if (Row[c_champEQUIP_FLAG_NOM_COM] == DBNull.Value)
					return null;
                return (System.Boolean?)Row[c_champEQUIP_FLAG_NOM_COM];
			}
			set
			{
				Row[c_champEQUIP_FLAG_NOM_COM,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champEQUIP_FLAG_NOM_ADR, NullAutorise = true)]
		[DynamicField("Identified by IP address flag")]
        public System.Boolean? NommageParAdresseIP
		{
			get
			{
				if (Row[c_champEQUIP_FLAG_NOM_ADR] == DBNull.Value)
					return null;
                return (System.Boolean?)Row[c_champEQUIP_FLAG_NOM_ADR];
			}
			set
			{
				Row[c_champEQUIP_FLAG_NOM_ADR,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champEQUIP_FLAG_UNI_REF, NullAutorise = true)]
		[DynamicField("Unicity by reference flag")]
        public System.Boolean? FlagUniciteReference
		{
			get
			{
				if (Row[c_champEQUIP_FLAG_UNI_REF] == DBNull.Value)
					return null;
                return (System.Boolean?)Row[c_champEQUIP_FLAG_UNI_REF];
			}
			set
			{
				Row[c_champEQUIP_FLAG_UNI_REF,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champEQUIP_FLAG_UNI_POS, NullAutorise = true)]
		[DynamicField("Unicity by geography flag")]
        public System.Boolean? FlagUniciteGeographie
		{
			get
			{
				if (Row[c_champEQUIP_FLAG_UNI_POS] == DBNull.Value)
					return null;
                return (System.Boolean?)Row[c_champEQUIP_FLAG_UNI_POS];
			}
			set
			{
				Row[c_champEQUIP_FLAG_UNI_POS,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champEQUIP_FLAG_UNI_COM, NullAutorise = true)]
		[DynamicField("Unicity by comment flag")]
        public System.Boolean? FlagUniciteCommentaire
		{
			get
			{
				if (Row[c_champEQUIP_FLAG_UNI_COM] == DBNull.Value)
					return null;
                return (System.Boolean?)Row[c_champEQUIP_FLAG_UNI_COM];
			}
			set
			{
				Row[c_champEQUIP_FLAG_UNI_COM,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champEQUIP_FLAG_UNI_ADR, NullAutorise = true)]
		[DynamicField("Unicity by IP address flag")]
        public System.Boolean? FlagUniciteAdresseIP
		{
			get
			{
				if (Row[c_champEQUIP_FLAG_UNI_ADR] == DBNull.Value)
					return null;
                return (System.Boolean?)Row[c_champEQUIP_FLAG_UNI_ADR];
			}
			set
			{
				Row[c_champEQUIP_FLAG_UNI_ADR,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champEQUIP_ETIQ_VUE, NullAutorise = true)]
		[DynamicField("Label choice")]
		public System.Int32? ChoixEtiquette
		{
			get
			{
				if (Row[c_champEQUIP_ETIQ_VUE] == DBNull.Value)
					return null;
				return (System.Int32?)Row[c_champEQUIP_ETIQ_VUE];
			}
			set
			{
				Row[c_champEQUIP_ETIQ_VUE,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champEQUIP_FREQE, NullAutorise = true)]
		[DynamicField("Frequent alarm parameter")]
		public System.Int32? ParametreAlarmeFrequente
		{
			get
			{
                if (Row[c_champEQUIP_FREQE] == DBNull.Value)
                    return null;
				return (System.Int32?)Row[c_champEQUIP_FREQE];
			}
			set
			{
				Row[c_champEQUIP_FREQE,true]=value;
			}
		}


        /// <summary>
        /// Lorsque l'équipement est une Interface de Surveillance,
        /// renvoie le numéro de cette IS ou :
        ///     -1 quand il ne s'agit pas d'une carte GTR
        ///     -2 lorque le nom de l'équipement n'a pas le format IS xx/GTR yy
        /// </summary>
        /// <returns></returns>
        public int GetNumeroIS()
        {
            if (this.TypeEquipement.Libelle != CSpvTypeq.c_CARTE_GTR)
                return -1;

            string strNom = CommentairePourSituer;
            Regex pattern = new Regex("^(IS )( |[0-9])[0-9]/GTR ( |[0-9])[0-9]");
            if (!pattern.IsMatch(CommentairePourSituer))
                return -2;
            return Convert.ToInt32(CommentairePourSituer.Substring(3, 2));
        }


        /// <summary>
        /// Lorsque l'équipement est une Interface de Surveillance,
        /// renvoie le numéro de carte GTR ou :
        ///     -1 quand il ne s'agit pas d'une carte GTR
        ///     -2 lorque le nom de l'équipement n'a pas le format IS xx/GTR yy
        /// </summary>
        /// <returns></returns>
        public int GetNumeroCarteGTR()
        {
            if (this.TypeEquipement.Libelle != CSpvTypeq.c_CARTE_GTR)
                return -1;

            string strNom = CommentairePourSituer;
            Regex pattern = new Regex("^(IS )( |[0-9])[0-9]/GTR ( |[0-9])[0-9]");
            if (!pattern.IsMatch(CommentairePourSituer))
                return -2;
            return Convert.ToInt32(CommentairePourSituer.Substring(10, 2));
        }

		
		///////////////////////////////////////////////////////////////
		[Relation(CSpvTypeqinc.c_nomTable,new string[]{CSpvTypeqinc.c_champTYPEQINC_ID}, new string[]{CSpvEquip.c_champTYPEQINC_ID},false,false)]
		[DynamicField("Snmp family")]
		public CSpvTypeqinc SpvTypeqinc
		{
			get
			{
				return (CSpvTypeqinc) GetParent(new string[]{c_champTYPEQINC_ID},typeof(CSpvTypeqinc));
			}
			set
			{
				SetParent(new string[]{c_champTYPEQINC_ID}, value);
			}
		}
		
		///////////////////////////////////////////////////////////////
		[Relation(CSpvTypeq.c_nomTable,new string[]{CSpvTypeq.c_champTYPEQ_ID}, new string[]{CSpvEquip.c_champTYPEQ_BINDINGID},false,false)]
		[DynamicField("Container equipment type")]
		public CSpvTypeq TypeEquipementEnglobant
		{
			get
			{
				return (CSpvTypeq) GetParent(new string[]{c_champTYPEQ_BINDINGID},typeof(CSpvTypeq));
			}
			set
			{
				SetParent(new string[]{c_champTYPEQ_BINDINGID}, value);
			}
		}
		
		
		
		///////////////////////////////////////////////////////////////
		[Relation(CSpvTypeq.c_nomTable,new string[]{CSpvTypeq.c_champTYPEQ_ID}, new string[]{CSpvEquip.c_champTYPEQ_ID},true,true)]
		[DynamicField("Equipment type")]//COMMENT : renommer, pour être plus clair
		public CSpvTypeq TypeEquipement
		{
			get
			{
				return (CSpvTypeq) GetParent(new string[]{c_champTYPEQ_ID},typeof(CSpvTypeq));
			}
			set
			{
				SetParent(new string[]{c_champTYPEQ_ID}, value);
			}
		}
		
		///////////////////////////////////////////////////////////////
		[Relation(CSpvSite.c_nomTable,new string[]{CSpvSite.c_champSITE_ID}, new string[]{CSpvEquip.c_champSITE_ID},false,false)]
		[DynamicField("Site")]
		public CSpvSite SpvSite
		{
			get
			{
				return (CSpvSite) GetParent(new string[]{c_champSITE_ID},typeof(CSpvSite));
			}
			set
			{
				SetParent(new string[]{c_champSITE_ID}, value);
			}
		}
		
		
		///////////////////////////////////////////////////////////////
		[Relation(CSpvEquip.c_nomTable,new string[]{CSpvEquip.c_champEQUIP_ID}, new string[]{CSpvEquip.c_champEQUIP_BINDINGID},false,false)]
		[DynamicField("Container equipement")]
		public CSpvEquip EquipementEnglobant
		{
			get
			{
				return (CSpvEquip) GetParent(new string[]{c_champEQUIP_BINDINGID},typeof(CSpvEquip));
			}
			set
			{
				SetParent(new string[]{c_champEQUIP_BINDINGID}, value);
			}
		}
		
		
		///////////////////////////////////////////////////////////////
		//[RelationFille(typeof(CSpvEquip),"SpvEquip2")]
        [RelationFille(typeof(CSpvEquip), "EquipementEnglobant")]
		[DynamicChilds("Included equipments", typeof(CSpvEquip))]
		public CListeObjetsDonnees EquipementsInclus
		{
			get
			{
				return GetDependancesListe(CSpvEquip.c_nomTable,c_champEQUIP_BINDINGID);
			}
		}
		
		///////////////////////////////////////////////////////////////
        /*
		[RelationFille(typeof(CSpvCablequ_Equip),"SpvEquip")]
        [DynamicChilds("Wirings", typeof(CSpvCablequ_Equip))]
		public CListeObjetsDonnees CablagesEquipement
		{
			get
			{
				return GetDependancesListe(CSpvCablequ_Equip.c_nomTable,c_champEQUIP_ID);
			}
		}*/
		
		
		///////////////////////////////////////////////////////////////
		[RelationFille(typeof(CSpvAccesAlarme),"SpvEquip")]
        [DynamicChilds("Alarm ports", typeof(CSpvAccesAlarme))]
		public CListeObjetsDonnees AccesAlarme
		{
			get
			{
				return GetDependancesListe(CSpvAccesAlarme.c_nomTable,c_champEQUIP_ID);
			}
		}

        public CSpvAccesAlarme GetAccesAlarme (string accesNom)
        {
            CListeObjetsDonnees lst = AccesAlarme;
            lst.Filtre = new CFiltreData(CSpvAcces.c_champACCES_NOM + "=@1",
                accesNom);
            if (lst.Count > 0)
                return lst[0] as CSpvAccesAlarme;
            return null;
        }

        /*
        ///////////////////////////////////////////////////////////////
        /// <summary>
        /// Retourne l'accès de transmission grâce à son nom
        /// </summary>
        /// <param name="accesNom"></param>
        /// <returns></returns>
        public CSpvAccesTrans GetAccesTrans(string accesNom)
        {
            CListeObjetsDonnees lst = AccesTransmission;
            lst.Filtre = new CFiltreData(CSpvAcces.c_champACCES_NOM + "=@1",
                accesNom);
            if (lst.Count > 0)
                return lst[0] as CSpvAccesTrans;
            return null;
        }*/
        
        public CListeObjetsDonnees AccesAlarmeBoucle
        {
            get
            {
                CListeObjetsDonnees liste = new CListeObjetsDonnees(ContexteDonnee, typeof(CSpvAccesAlarme));
                liste.Filtre = new CFiltreData(CSpvAccesAlarme.c_champEQUIP_ID + "=@1 AND " + 
                                               CSpvAccesAlarme.c_champACCES_CATEGORIE + "=@2", this.Id, (int) ECategorieAccesAlarme.SortieBoucle);
                return liste;
            }
        }

        public CListeObjetsDonnees AccesAlarmeBoucleNonCable
        {
            get
            {
                CListeObjetsDonnees liste = new CListeObjetsDonnees(ContexteDonnee, typeof(CSpvAccesAlarme));
                liste.Filtre = new CFiltreData(CSpvAccesAlarme.c_champEQUIP_ID + "=@1 AND " +
                                               CSpvAccesAlarme.c_champACCES_CATEGORIE + "=@2 AND " +
                                               CSpvAccesAlarme.c_champACCES_ETAT + " IN (" + CSpvAccesAlarme.c_accesNonCable + ")", this.Id,
                                               (int) ECategorieAccesAlarme.SortieBoucle);
                return liste;
            }
        }
        /*
        ///////////////////////////////////////////////////////////////
        [RelationFille(typeof(CSpvAccesTrans), "SpvEquip")]
        [DynamicChilds("Transmission ports", typeof(CSpvAccesTrans))]
        public CListeObjetsDonnees AccesTransmission
        {
            get
            {
                return GetDependancesListe(CSpvAccesTrans.c_nomTable, c_champEQUIP_ID);
            }
        }*/
		
				
		///////////////////////////////////////////////////////////////
        [RelationFille(typeof(CSpvEquip_Msk), "EquipementMasquant")]
        [DynamicChilds("Mask these equipments", typeof(CSpvEquip_Msk))]
		public CListeObjetsDonnees EquipementsMasques
		{
			get
			{
				return GetDependancesListe(CSpvEquip_Msk.c_nomTable,CSpvEquip_Msk.c_champEQUIP_MASQUANT_ID);
			}
		}

		
		///////////////////////////////////////////////////////////////
        [RelationFille(typeof(CSpvEquip_Msk), "EquipementMasque")]
        [DynamicChilds("Masked by these equipments", typeof(CSpvEquip_Msk))]
		public CListeObjetsDonnees EquipementsMasquant
		{
			get
			{
                return GetDependancesListe(CSpvEquip_Msk.c_nomTable, CSpvEquip_Msk.c_champEQUIP_MASQUE_ID);
			}
		}
		
		
        ///////////////////////////////////////////////////////////////
        [RelationFille(typeof(CSpvEquip_Rep), "SpvEquip")]
        [DynamicChilds("Operational state", typeof(CSpvEquip_Rep))]
        public CListeObjetsDonnees SpvEquip_Rep
        {
            get
            {
                return GetDependancesListe(CSpvEquip_Rep.c_nomTable, c_champEQUIP_ID);
            }
        }

        ///////////////////////////////////////////////////////////////
        [Relation(
            CEquipementLogique.c_nomTable,
            CEquipementLogique.c_champId,
            CSpvEquip.c_champSmtEquipementLogique_Id,
            true,
            true,
            false)]
        [DynamicField("Corresponding SMT logical equipment")]
        public override CEquipementLogique ObjetTimosAssocie
        {
            get
            {
                return ObjetTimosAssocieProtected;
            }
            set
            {
                ObjetTimosAssocieProtected = value;
            }
        }

        public static object GetSpvEquipFromEquipement(object objet)
        {
            CEquipementLogique equipement = objet as CEquipementLogique;
            if (equipement != null)
            {
                CSpvEquip spvEquip = new CSpvEquip(equipement.ContexteDonnee);
                if (spvEquip.ReadIfExists(new CFiltreData(CSpvEquip.c_champSmtEquipementLogique_Id + "=@1", equipement.Id)))
                    return spvEquip;
            }
            return null;
        }

        public static CResultAErreur SetSpvEquipFromEquipement(object objet, object valeur)
        {
            CSpvEquip spvEquip = valeur as CSpvEquip;
            CEquipementLogique equipement = objet as CEquipementLogique;
            if (spvEquip != null && equipement != null)
                spvEquip.ObjetTimosAssocie = equipement;
            return CResultAErreur.True;
        }

        public static CSpvEquip GetSpvEquipFromEquipementAvecCreation(CEquipementLogique equipement)
        {
            CSpvEquip spvEquip = GetSpvEquipFromEquipement(equipement) as CSpvEquip;
            if (spvEquip == null)
            {
                spvEquip = new CSpvEquip(equipement.ContexteDonnee);
                spvEquip.CreateNewInCurrentContexte();
                spvEquip.ObjetTimosAssocie = equipement;
                spvEquip.CopyFromObjetTimos(equipement);
            }
            return spvEquip;
        }


        /// <summary>
        /// Effectue la mise à jour des colonnes SPV à partir des colonnes SMT
        /// </summary>
        /// <param name="equipement"></param>
        public override void CopyFromObjetTimos(CEquipementLogique equipement)
        {
            CommentairePourSituer = equipement.Libelle;

            TypeEquipement = CSpvTypeq.GetSpvTypeqFromTypeEquipementAvecCreation(equipement.TypeEquipement);
            LibelleTypeEquipement = TypeEquipement.Libelle;

			if (equipement.Site != null)
				SpvSite = CSpvSite.GetObjetSpvFromObjetTimosAvecCreation(equipement.Site);

            if (equipement.EquipementLogiqueContenant != null)
                EquipementEnglobant = CSpvEquip.GetSpvEquipFromEquipementAvecCreation(equipement.EquipementLogiqueContenant);
            else
                EquipementEnglobant = null;
        }


        /// <summary>
        /// Renvoie ce qui doit identifier l'équipement dans les traps
        /// </summary>
        /// <returns>l'identifiant</returns>
        public string GetEquipEtiquette ()
        {
            string strEtiq = "";

            switch ((EModeEtiquetage) ChoixEtiquette)
            {
                case EModeEtiquetage.ParReference:
                    strEtiq = Reference;
                    break;

                case EModeEtiquetage.ParCommentaire:
                    strEtiq = CommentairePourSituer;
                    break;

                case EModeEtiquetage.ParAddrIP:
                    strEtiq = AdresseIP;
                    break;
            }
            return strEtiq;
        }

       
        /// <summary>
        /// Création de l'enregistrement EQUIP_OPER à la création de l'équipement
        /// </summary>
        public void CreEquipOper (int equipId)
        {
            if (this.Row.RowState != DataRowState.Added)    // pas en création, on ne fait rien
                return;

            CSpvEquip_Rep spvEquipRep = new CSpvEquip_Rep(this.ContexteDonnee);
			spvEquipRep.CreateNewInCurrentContexte(new object[] { equipId });

            spvEquipRep.SpvEquip = this;
			spvEquipRep.PositionCommutateur = this.PositionCommutateur;
            //spvEquipRep.Id = -3;
        }


        /// <summary>
        /// Génération des accès alarme de l'équipement à la création de celui-ci.
        /// Ceci se fait par rapport aux types d'accès existant sur le type d'équipement
        /// </summary>
        private void GenereTousAccesAlarmeFromTypeq ()
        {
            if (this.Row.RowState != DataRowState.Added)    // pas en création donc on ne fait rien
                return;

            CSpvTypeq spvTypeq = this.TypeEquipement;
            CSpvAccesAlarme spvAccesAlarm;
            CListeObjetsDonnees listeTypeAccesAlarmes = spvTypeq.TypesAccesAlarme;
            if (listeTypeAccesAlarmes != null)
            {
                foreach (CSpvTypeAccesAlarme spvTypeAccesAlarme in spvTypeq.TypesAccesAlarme)
                {
                    spvAccesAlarm = new CSpvAccesAlarme(this.ContexteDonnee);
                    spvAccesAlarm.SpvEquip = this;
                    spvAccesAlarm.InitFromTypeAccesAlarme(spvTypeAccesAlarme);
                    spvAccesAlarm.CreateNewInCurrentContexte();
                }
            }
        }

        /*
        /// <summary>
        /// Génération des accès transmisson de l'équipement à la création de celui-ci.
        /// Ceci se fait par rapport aux types d'accès existant sur le type d'équipement
        /// </summary>
        private void GenereTousAccesTransFromTypeq ()
        {
            if (this.Row.RowState != DataRowState.Added)    // pas en création donc on ne fait rien
                return;

            CSpvTypeq spvTypeq = this.TypeEquipement;
            CSpvAccesTrans accesTrans = null;
            CListeObjetsDonnees listeTypesAccesTrans = spvTypeq.TypesAccesTrans;
            if (listeTypesAccesTrans != null)
            {
                foreach (CSpvTypeAccesTrans spvTypeAccesTrans in listeTypesAccesTrans)
                {
                    accesTrans = GetAccesTrans(spvTypeAccesTrans.NomAcces);
                    if (accesTrans == null)
                    {
                        accesTrans = new CSpvAccesTrans(this.ContexteDonnee);
                        accesTrans.CreateNewInCurrentContexte();
                    }
                    accesTrans.InitFromTypeAccesTrans(spvTypeAccesTrans);
                    accesTrans.SpvEquip = this;
                    //accesTrans.Row[CSpvAccesTrans.c_champACCES_UNICITE] = "";
                }
            }

        }*/


        /// <summary>
        /// Traitements métier à la création ou à la modification de l'équipement
        /// </summary>
        public void TraitementMetier(DataRowState rowState)
        {
            if (rowState != DataRowState.Added && rowState != DataRowState.Modified)
                return;

			LibelleTypeEquipement = TypeEquipement.Libelle;			

			CalculeUnicite();


            if (rowState == DataRowState.Added)
            {
                CreEquipOper(Id);

				if (TypeEquipement.Libelle == CSpvTypeq.c_SATURNE_IS)
					CreMessAlrm();
                else if (TypeEquipement.Id == CSpvTypeq.c_TypeEquipMediationId)
                    TraitementCreationMediation();

                GenereTousAccesAlarmeFromTypeq();
                //GenereTousAccesTransFromTypeq();
            }
            else if (rowState == DataRowState.Modified)
            {
                if (Row[CSpvEquip.c_champEQUIP_FREQE] != Row[CSpvEquip.c_champEQUIP_FREQE, DataRowVersion.Original])
                    CreMessAlrm();
                
                if (Row[CSpvEquip.c_champEQUIP_ADDRIP] != Row[CSpvEquip.c_champEQUIP_ADDRIP, DataRowVersion.Original] ||
                    Row[CSpvEquip.c_champEQUIP_INDEXSNMP] != Row[CSpvEquip.c_champEQUIP_INDEXSNMP, DataRowVersion.Original] ||
                    Row[CSpvEquip.c_champSITE_EQUIP_COMMENT] != Row[CSpvEquip.c_champSITE_EQUIP_COMMENT, DataRowVersion.Original] ||
                    Row[CSpvEquip.c_champEQUIP_COMMUT] != Row[CSpvEquip.c_champEQUIP_COMMUT, DataRowVersion.Original])
                {
                    MajFils();
                    foreach (CSpvAccesAlarme spvAccesAlarme in this.AccesAlarme)
                        foreach (CSpvLienAccesAlarme spvLienAlarme in spvAccesAlarme.Acces_AccescsOne)
                            spvLienAlarme.MajIpFromEquip(this);
                }
 
            }
        }


		private void CreMessAlrm()
		{
			CSpvMessalrm messAlrm = new CSpvMessalrm(ContexteDonnee);
			messAlrm.CreateNewInCurrentContexte();
			messAlrm.MessageCreationPourSaturneIS(CommentairePourSituer, ParametreAlarmeFrequente);
		}


        public bool GetNomsPourTestEM(string strEquipNom, ref string strEM, ref string strService)
        {
            int nPos = strEquipNom.IndexOf('/');
            if (nPos < 0)
                return false;
            strEM = strEquipNom.Substring(0, nPos);
            strService = strEquipNom.Substring(nPos + 1);
            return true;
        }


		public void TraitementCreationMediation()
		{
			CSpvLienAccesAlarme spvLienAccesAlarme = new CSpvLienAccesAlarme(ContexteDonnee);
			spvLienAccesAlarme.CreateNewInCurrentContexte();

			spvLienAccesAlarme.AccesAlarmeOne = spvLienAccesAlarme.SpvAccesAlarmeSysteme0();
			spvLienAccesAlarme.AccesAlarmeTwo = spvLienAccesAlarme.SpvAccesAlarmeSysteme0();
			spvLienAccesAlarme.BindingClassId = CSpvLienAccesAlarme.c_BindingClassId;
			spvLienAccesAlarme.EquipCommutateur = false;
			spvLienAccesAlarme.SpvAlarmgeree = spvLienAccesAlarme.SpvAlarmGereeSysteme1();
			spvLienAccesAlarme.CodeGravite = (int) EGraviteAlarmeAvecMasquage.Critical;
			spvLienAccesAlarme.Masking_Type = EMaskType.Demasque;
            spvLienAccesAlarme.SpvEquip = this;

            //Création de l'enregistrement dans TESTEM
            string strEM = "";
            string strService = "";
            if (! GetNomsPourTestEM (this.CommentairePourSituer, ref strEM, ref strService))
                throw new Exception(I.T("For equipment type EQUIP MEDIATION, equipement label should be like 'mediation_name/service_name'|50016"));
            
            CSpvTestem spvTestem = new CSpvTestem(ContexteDonnee);
            spvTestem.CreateNewInCurrentContexte(new object[] { this.IndexSnmp, strEM });
            spvTestem.NomService = strService;
            spvTestem.DateRafraichissement = System.DateTime.Today;
            spvTestem.NomEquipementMediation = strEM;
		}

        public void SuppressionTestEM(string strSiteEquipComment, string strEquipIndex)
        {
            CSpvTestem testEM = new CSpvTestem (ContexteDonnee);
            string strEM = "";
            string strService = "";
            if (GetNomsPourTestEM (strSiteEquipComment, ref strEM, ref strService))
            {
                if (testEM.ReadIfExists(
                            new CFiltreData(CSpvTestem.c_champTESTEM_ID + "=@1 and " +
                                            CSpvTestem.c_champTESTEM_NOM + "=@2",
                                            strEquipIndex, strService)))
                {
                    testEM.Delete();
                }
            }
        }


        // Mise à jour des équipements fils lorsque adresse IP, médiation, communauté sont modifiés
        private void MajFils()
        {
            //throw new Exception("The method or operation is not implemented.");
            string strAdresseIPOrg, strCommunauteOrg, strMediation;
            strAdresseIPOrg = (Row[c_champEQUIP_ADDRIP, DataRowVersion.Original] == DBNull.Value) ? "" :
                                (string)Row[c_champEQUIP_ADDRIP, DataRowVersion.Original];
            strCommunauteOrg = (Row[c_champEQUIP_CMNTE, DataRowVersion.Original] == DBNull.Value) ? "" :
                                (string)Row[c_champEQUIP_CMNTE, DataRowVersion.Original];
            strMediation = (Row[c_champEQUIP_EMNAME, DataRowVersion.Original] == DBNull.Value) ? "" :
                                (string)Row[c_champEQUIP_EMNAME, DataRowVersion.Original];

            if (AdresseIP != strAdresseIPOrg || CommunauteSnmp != strCommunauteOrg ||
                EquipementDeMediation != strMediation)
            {
                CListeObjetsDonnees liste = new CListeObjetsDonnees(ContexteDonnee, typeof(CSpvEquip));
                liste.Filtre = new CFiltreData(c_champEQUIP_BINDINGID + "=@1", Id);
                if (liste.Count > 0)
                {
                    foreach (CSpvEquip spvEquip in liste)
                    {
                        spvEquip.AdresseIP = AdresseIP;
                        spvEquip.CommunauteSnmp = CommunauteSnmp;
                        spvEquip.EquipementDeMediation = EquipementDeMediation;
                        spvEquip.MajFils();
                    }
                }
            }
        }


		public void CalculeUnicite()
		{
			string strTemp;

			// Unicité sur le commentaire
			if (ClassId == c_classID && FlagUniciteCommentaire == true)
			{
				strTemp = TypeEquipement.Id.ToString() + "/"
						+ SpvSite.Id.ToString() + "/"
						+ ((EquipementEnglobant != null) ? EquipementEnglobant.Id.ToString() : "0")
						+ "/"
						+ ((SpvTypeqinc != null) ? SpvTypeqinc.Id.ToString() : "0") + "/"
						+ CommentairePourSituer + "/"
						+ IndexSnmp + "/"
						+ NumeroCarte;

                if (strTemp.Length > 100)
                    UniciteCommentaire = strTemp.Substring(0, 100);
                else
                    UniciteCommentaire = strTemp;
			}

			// Cas des IS SATURNE
			if (ClassId == c_classID && 
				(TypeEquipement.Libelle == CSpvTypeq.c_SATURNE_IS || TypeEquipement.Id == 1 ||
				 TypeEquipement.Id == 2))
				UniciteCommentaire = CommentairePourSituer.TrimEnd(null);

			// Unicité sur la référence
			if (ClassId == c_classID && FlagUniciteReference == true)
				UniciteReference = Reference;

			// Unicité sur l'adresse IP
			if (ClassId == c_classID && FlagUniciteAdresseIP == true)
			{
				strTemp = AdresseIP + "/"
						+ ((SpvTypeqinc != null) ? SpvTypeqinc.Id.ToString() : "0") + "/"
						+ IndexSnmp;

                if (strTemp.Length > 100)
                    UniciteAdresseIP = strTemp.Substring(0, 100);
                else
                    UniciteAdresseIP = strTemp;

			}
		}


        /// <summary>
        /// Indique si l'équipement SPV est modifié.
        /// Nécessaire lorsque la modification porte uniquement
        /// sur la partie SPV
        /// </summary>
        /// <param name="equipementId">ID de l'équipement SMT</param>
        /// <returns></returns>
        public static bool IsModified(Int32 equipementId, CContexteDonnee ctx)
        {
            DataTable dt = ctx.Tables[CSpvEquip.c_nomTable];

            /*
            CEquipementLogique eqpt = new CEquipementLogique(ctx);
            
			if (eqpt.ReadIfExists(equipementId, false))
			{
				return (eqpt.Row.RowState == DataRowState.Modified );
            }*/

            CSpvEquip spvEquip = new CSpvEquip(ctx);
            CFiltreData filtre = new CFiltreData (c_champSmtEquipementLogique_Id + "=@1", equipementId);
            if (spvEquip.ReadIfExists (filtre, false))
                return (spvEquip.Row.RowState == DataRowState.Modified);

            return false;
        }

        ///////////////////////////////////////////////////////////////
        [RelationFille(typeof(CSpvLienAccesAlarme), "SpvEquip")]
        [DynamicChilds("Alarm wiring", typeof(CSpvLienAccesAlarme))]
        public CListeObjetsDonnees AlarmesCables
        {
            get
            {
                return GetDependancesListe(CSpvLienAccesAlarme.c_nomTable, c_champEQUIP_ID);
            }
        }


        public CListeObjetsDonnees AlarmesCablesBoucles
        {
            get
            {
                string clauseWhere = "AccesAlarmeOne." + CSpvAccesAlarme.c_champEQUIP_ID + "=@1 AND " +
                                     "AccesAlarmeOne." + CSpvAccesAlarme.c_champACCES_CATEGORIE + "=@2";
                CFiltreDataAvance filtre = new CFiltreDataAvance(CSpvLienAccesAlarme.c_nomTable, clauseWhere,
                                                                 this.Id,
                                                                 (int)ECategorieAccesAlarme.SortieBoucle);
                CListeObjetsDonnees liste = new CListeObjetsDonnees(ContexteDonnee, typeof(CSpvLienAccesAlarme), filtre);
                int nb = liste.Count;
                return liste;
            }
        }


        public CListeObjetsDonnees AlarmesCablesBouclesAndTrap
        {
            get
            {
                string clauseWhere = "AccesAlarmeOne." + CSpvAccesAlarme.c_champEQUIP_ID + "=@1 AND (" +
                                     "AccesAlarmeOne." + CSpvAccesAlarme.c_champACCES_CATEGORIE + "=@2 OR " +
                                     "AccesAlarmeOne." + CSpvAccesAlarme.c_champACCES_CATEGORIE + "=@3)";
                CFiltreDataAvance filtre = new CFiltreDataAvance(CSpvLienAccesAlarme.c_nomTable, clauseWhere, 
                                                                 this.Id, 
                                                                 (int) ECategorieAccesAlarme.TrapSnmp,
                                                                 (int) ECategorieAccesAlarme.SortieBoucle);
                CListeObjetsDonnees liste = new CListeObjetsDonnees(ContexteDonnee, typeof(CSpvLienAccesAlarme), filtre);
                int nb = liste.Count;
                return liste; 
            }
        }

        ///////////////////////////////////////////////////////////////
        public CSpvSite[] SitesPouvantContenirLeCollecteur
        {
            get
            {
                if (SpvSite != null)
                    return new CSpvSite[] { SpvSite };
                return new CSpvSite[0];
            }
        }

        public override string GetChampIdObjetTimos()
        {
            return c_champSmtEquipementLogique_Id;
        }

        public string GetName()
        {
            
            return this.CommentairePourSituer;//tmp
        }

        public string GetTypeName()
        {
            return TypeEquipement.Libelle;
        }

        
        public CListeObjetsDonnees PrestationsConcernees
        {
            get
            {
                CListeObjetsDonnees liste = new CListeObjetsDonnees(ContexteDonnee, typeof(CSpvSchemaReseau));
                /*
                string clauseWhere = CSpvService_DependanceCablage.c_nomTable + "." +
                    CSpvCablequ.c_nomTable + "." +
                    CSpvCablequ_Equip.c_nomTable + "." +
                    CSpvCablequ_Equip.c_champEQUIP_ID + "=@1";

                liste.Filtre = new CFiltreDataAvance(CSpvSchemaReseau.c_nomTable, clauseWhere, Id);
                */
                return liste;
            }
        }

        public double CoefficientOperationnel
        {
            get
            {
                CSpvEquip_Rep equipRep = new CSpvEquip_Rep(ContexteDonnee);
                if (equipRep.ReadIfExists(Id))
                    return equipRep.CoefficientOperationnel;
                return 1.0;
            }
        }

    }
}
