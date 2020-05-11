using System;
using System.Data;
using sc2i.data;
using sc2i.common;
using System.Collections.Generic;

namespace spv.data
{
    /// <summary>
    /// Lien entre deux accès alarme
    /// </summary>
    [Table(CSpvLienAccesAlarme.c_nomTable, CSpvLienAccesAlarme.c_nomTableInDb, new string[] { CSpvLienAccesAlarme.c_champACCES_ACCESC_ID }, ModifiedByTrigger = true)]
    [ObjetServeurURI("CSpvLienAccesAlarmeServeur")]
	[DynamicClass("Alarm access link")]
	public class CSpvLienAccesAlarme : CObjetDonneeAIdNumeriqueAuto, IObjetSansVersion
	{
        public const string c_nomTable = "SPV_ALARM_ACCES_LINK";
		public const string c_nomTableInDb = "ACCES_ACCESC";
		public const string c_champACCES_ACCESC_ID ="ACCES_ACCESC_ID";
		public const string c_champACCES1_ID ="ACCES1_ID";
		public const string c_champACCES2_ID ="ACCES2_ID";
		public const string c_champACCES_BINDINGID ="ACCES_BINDINGID";
		public const string c_champACCES_BINDINGCLASSID ="ACCES_BINDINGCLASSID";
        public const string c_champCOMMUT = "COMMUT";                   //Redondance, à supprimer plus tard
		public const string c_champACCES_ACCESC_NEQUIP ="ACCES_ACCESC_NEQUIP";
		public const string c_champACCES_ACCESC_PREBIT ="ACCES_ACCESC_PREBIT";
		public const string c_champACCES_ACCESC_DERBIT ="ACCES_ACCESC_DERBIT";
		public const string c_champALARMGEREE_ID ="ALARMGEREE_ID";
		public const string c_champALARMGEREE_GRAVE ="ALARMGEREE_GRAVE";
		public const string c_champALARMGEREE_MIN ="ALARMGEREE_MIN";
		public const string c_champALARMGEREE_SON ="ALARMGEREE_SON";
		public const string c_champALARMGEREE_ACQ ="ALARMGEREE_ACQ";
		public const string c_champMSKBRI_MIN ="MSKBRI_MIN";
		public const string c_champMSKBRI_MAX ="MSKBRI_MAX";
		public const string c_champMSKADM_MIN ="MSKADM_MIN";
		public const string c_champMSKADM_MAX ="MSKADM_MAX";
        public const string c_champEQUIP_TRAPNOM = "EQUIP_TRAPNOM";     //Redondance, à supprimer plus tard
        public const string c_champEQUIP_ADDRIP = "EQUIP_ADDRIP";       //Redondance, à supprimer plus tard
		public const string c_champSCRIPT_ID ="SCRIPT_ID";
        public const string c_champEQUIP_INDEXSNMP = "EQUIP_INDEXSNMP";//Redondance, à supprimer plus tard
		public const string c_champMSKADM_HOW ="MSKADM_HOW";
		public const string c_champALARMGEREE_TOSURV ="ALARMGEREE_TOSURV";
		public const string c_champALARMGEREE_FREQN ="ALARMGEREE_FREQN";
		public const string c_champALARMGEREE_FREQD ="ALARMGEREE_FREQD";
		public const string c_champALARMGEREE_TOAFF ="ALARMGEREE_TOAFF";
		public const string c_champALARMGEREE_SEUILB ="ALARMGEREE_SEUILB";
		public const string c_champALARMGEREE_SEUILH ="ALARMGEREE_SEUILH";
        public const string c_champSITE_ID = "SITE_ID"; //Attention! Erreur dans la documentation de SPV! Ce champ n'est pas obsolete!
        public const string c_champEQUIP_ID = "EQUIP_ID";//Attention! Erreur dans la documentation de SPV! Ce champ n'est pas obsolete!
        public const string c_champLIAI_ID = "LIAI_ID";//Attention! Erreur dans la documentation de SPV! Ce champ n'est pas obsolete!
        public const string c_champTYPEQ_ID = "TYPEQ_ID";//Attention! Erreur dans la documentation de SPV! Ce champ n'est pas obsolete!

        public const int c_BindingClassId = 8;

        
		///////////////////////////////////////////////////////////////
		public CSpvLienAccesAlarme( CContexteDonnee ctx )
			:base(ctx)
		{            
		}

        
        ///////////////////////////////////////////////////////////////
        public void InitFromAccesAndAlarmeGeree (CSpvAccesAlarme accesAlarme, CSpvAlarmGeree spvAlarmeGeree)
        {
            //BindingId = accesAlarme.SpvEquip.Id;
            this.BindingId = -3;
            this.AccesAlarmeOne = accesAlarme;
            this.AccesAlarmeTwo = SpvAccesAlarmeSysteme0();
            this.BindingClassId = c_BindingClassId;
            this.SpvAlarmgeree = spvAlarmeGeree;
            this.CodeGravite = spvAlarmeGeree.CodeAlarmgereeGravite;
            this.DureeMin = spvAlarmeGeree.DureeMin;
            this.Surveiller = spvAlarmeGeree.AlarmgereeSurveiller;
            this.SeuilBas = spvAlarmeGeree.SeuilBas;
            this.SeuilHaut = spvAlarmeGeree.SeuilHaut;

            if (accesAlarme.SpvEquip != null)   // Accès d'équipempent
            {
                //EquipTrapNom = FormatEquipTrapNom(accesAlarme.SpvEquip.CommentairePourSituer);
                EquipTrapNom = accesAlarme.SpvEquip.CommentairePourSituer;
                EquipAddrIP = accesAlarme.SpvEquip.AdresseIP;
                EquipSNMPIndex = accesAlarme.SpvEquip.IndexSnmp;

                this.SpvTypeq = accesAlarme.SpvEquip.TypeEquipement;
                this.SpvEquip = accesAlarme.SpvEquip;
            }

            this.Afficher = spvAlarmeGeree.AlarmgereeAfficher;
            this.Acquitter = spvAlarmeGeree.Alarmgeree_Acquitter;
            this.SonActive = spvAlarmeGeree.AlarmgereeSon;
        }


        public void MajFromAlarmeGeree(CSpvAlarmGeree spvAlarmeGeree)
        {
            this.DureeMin = spvAlarmeGeree.DureeMin;
            this.Afficher = spvAlarmeGeree.AlarmgereeAfficher;
            this.Acquitter = spvAlarmeGeree.Alarmgeree_Acquitter;
            this.SonActive = spvAlarmeGeree.AlarmgereeSon;
            this.Surveiller = spvAlarmeGeree.AlarmgereeSurveiller;
            this.CodeGravite = spvAlarmeGeree.CodeAlarmgereeGravite;
            this.SeuilBas = spvAlarmeGeree.SeuilBas;
            this.SeuilHaut = spvAlarmeGeree.SeuilHaut;

        }

        public void MajFrequenceFromAlarmeGeree(CSpvAlarmGeree spvAlarmGeree)
        {
            this.FreqNb = spvAlarmGeree.AlarmgereeFreqNb;
            this.FreqPeriod = spvAlarmGeree.AlarmgereeFreqPeriod;
        }

        public void MajIpFromEquip(CSpvEquip spvEquip)
        {
            this.EquipAddrIP = spvEquip.AdresseIP;
            this.EquipSNMPIndex = spvEquip.IndexSnmp;

            this.EquipTrapNom = FormatEquipTrapNom (spvEquip.CommentairePourSituer);
            this.EquipCommutateur = (spvEquip.PositionCommutateur > 0 ? true : false);
        }

        // Formatage pour GLOBECAST. Il faudra faire autrement
        // ceci est spécifique à certains équipements.
        // Inhibé pour l'instant
        private string FormatEquipTrapNom (string commentairePourSituer)
        {
            int nIndex;
            if ((nIndex = commentairePourSituer.IndexOf(':')) >= 0)
                return commentairePourSituer.Substring (0, nIndex);
            else
                return commentairePourSituer;
        }
		
		///////////////////////////////////////////////////////////////
		public CSpvLienAccesAlarme( DataRow row )
			:base(row)
		{
		}
		
		///////////////////////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
            Row[c_champMSKADM_HOW] = EMaskType.Demasque;
            Row[c_champCOMMUT] = false;
            Row[c_champACCES_BINDINGCLASSID] = c_BindingClassId;
            Row[c_champACCES_BINDINGID] = 0;
            Acquitter = false;
            SonActive = false;
            Surveiller = true;
            Afficher = true;
            FreqNb = 0;
            FreqPeriod = 1;
            MaskBriMin = 0;
            MaskBriMax = 0;
            MaskAdminMin = 0;
            MaskAdminMax = 0;
		}
		
		///////////////////////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[] {c_champACCES_ACCESC_ID};
		}
		
		///////////////////////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
                return I.T("Alarm access link @1|30029", Id.ToString());
			}
		}
		
				
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champACCES_BINDINGID, NullAutorise = true)]
		[DynamicField("Binding Id")]
		public System.Int32? BindingId
		{
			get
			{
				if (Row[c_champACCES_BINDINGID] == DBNull.Value)
					return null;
                return (System.Int32?)Row[c_champACCES_BINDINGID];
			}
			set
			{
				Row[c_champACCES_BINDINGID,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
        // Pour un câblage d'alarme, pas de NULL autorisé
        [TableFieldProperty(c_champACCES_BINDINGCLASSID, NullAutorise = false)]
		[DynamicField("Binding ClassId")]
		public System.Int32? BindingClassId
		{
			get
			{
                return (System.Int32?)Row[c_champACCES_BINDINGCLASSID];
			}
			set
			{
				Row[c_champACCES_BINDINGCLASSID,true]=value;
			}
		}
		
				
				
		///////////////////////////////////////////////////////////////
        //Redondance, à supprimer plus tard. N'est pas vraiment une redondance
        //indique s'il s'agit d'un commutateur à partir du moment où la position
        //du commutateur est diférente de la position repos.
        //utilisé dans correl_alarm, tib_alarm, ReinitVideo, VerifAlarmEnCours
        //mis à jour par tu_equip
        [TableFieldProperty(c_champCOMMUT)]
		[DynamicField("Switch")]
		public System.Boolean EquipCommutateur
		{
			get
			{
				if (Row[c_champCOMMUT] == DBNull.Value)
					return false;
                return (System.Boolean)Row[c_champCOMMUT];
			}
            set
            {
                Row[c_champCOMMUT, true] = value;
            }
		}
		
		///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champACCES_ACCESC_NEQUIP, NullAutorise = true)]
		[DynamicField("Equipment rate")]
		public System.Int32? Equipment_Rate
		{
			get
			{
				if (Row[c_champACCES_ACCESC_NEQUIP] == DBNull.Value)
					return null;
                return (System.Int32?)Row[c_champACCES_ACCESC_NEQUIP];
			}
			set
			{
				Row[c_champACCES_ACCESC_NEQUIP,true]=value;
			}
		}
		
		
									
		///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champALARMGEREE_GRAVE, NullAutorise = true)]
        [DynamicField("Alarm access severity code")]
        public int? CodeGravite
        {
            get
            {
                if (Row[c_champALARMGEREE_GRAVE] == DBNull.Value)
                    return null;
                return (int?)Row[c_champALARMGEREE_GRAVE];
            }
            set
            {
                Row[c_champALARMGEREE_GRAVE, true] = value;
            }
        }

        ///////////////////////////////////////////////////////////////
        [DynamicField("Alarm access severity")]
        public CGraviteAlarmeAvecMasquage Gravite
        {
            get
            {
                if (CodeGravite == null)
                    return null;

                if (Enum.IsDefined(typeof(EGraviteAlarmeAvecMasquage), CodeGravite))
                {
                    try
                    {
                        return new CGraviteAlarmeAvecMasquage((EGraviteAlarmeAvecMasquage)CodeGravite);
                    }
                    catch
                    {
                    }
                }
                return null;
            }
            set
            {
                CodeGravite = (int?)value.Code;
            }
        }
		
		
		///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champALARMGEREE_MIN, NullAutorise = true)]
        [DynamicField("Confirmation length")]
        public System.Int32? DureeMin
		{
			get
			{
				if (Row[c_champALARMGEREE_MIN] == DBNull.Value)
					return null;
                return (System.Int32?)Row[c_champALARMGEREE_MIN];
			}
			set
			{
				Row[c_champALARMGEREE_MIN,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champALARMGEREE_SON, NullAutorise = true)]
        [DynamicField("Sound activated")]
        public System.Boolean? SonActive
		{
			get
			{
				if (Row[c_champALARMGEREE_SON] == DBNull.Value)
					return false;
                return (System.Boolean?)Row[c_champALARMGEREE_SON];
			}
			set
			{
				Row[c_champALARMGEREE_SON,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champALARMGEREE_ACQ, NullAutorise = true)]
        [DynamicField("Acknowledge Alarm")]
        public System.Boolean? Acquitter
		{
			get
			{
				if (Row[c_champALARMGEREE_ACQ] == DBNull.Value)
					return false;
                return (System.Boolean?)Row[c_champALARMGEREE_ACQ];
			}
			set
			{
				Row[c_champALARMGEREE_ACQ,true]=value;
			}
		}

        ////////////////////////////////////////////////////////////////////////
        [DynamicField("Operating agent masking begining date")]
        public System.DateTime? MaskBriDateMin
        {
            get
            {
                CDivers div = new CDivers();
                return div.FromSecToDate((double?)MaskBriMin);
            }
            set
            {
                CDivers div = new CDivers();
                MaskBriMin = (System.Int32?)div.FromDateToSec(value);
            }
        }
		
		///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champMSKBRI_MIN, NullAutorise = true)]
        [DynamicField("Operating agent masking start (sec.)")]
        public System.Int32? MaskBriMin
		{
            get
            {
                CSpvAcces_Accesc2 acc2 = GetAcces_Accesc2();
                if (acc2 != null)
                    return acc2.MaskBriMin;
                else
                {
                    if (Row[c_champMSKBRI_MIN] == DBNull.Value)
                        return null;
                    else
                        return (System.Int32?)Row[c_champMSKBRI_MIN];
                }

            }
            set
            {
                Row[c_champMSKBRI_MIN, true] = value;
                GetAcces_Accesc2AvecCreation().MaskBriMin = value;
            }
		}

        ////////////////////////////////////////////////////////////////////////
        [DynamicField("Operating agent masking ending date")]
        public System.DateTime? MaskBriDateMax
        {
            get
            {
                CDivers div = new CDivers();
                return div.FromSecToDate((double?)MaskBriMax);
            }
            set
            {
                CDivers div = new CDivers();
                MaskBriMax = (System.Int32?)div.FromDateToSec(value);
            }
        }

        		
		///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champMSKBRI_MAX, NullAutorise = true)]
        [DynamicField("Operating agent masking end (sec.)")]
        public System.Int32? MaskBriMax
		{
			get
			{
                CSpvAcces_Accesc2 acc2 = GetAcces_Accesc2();
                if (acc2 != null)
                    return acc2.MaskBriMax;
                else
                {
                    if (Row[c_champMSKBRI_MAX] == DBNull.Value)
					    return null;
                    else
				        return (System.Int32?)Row[c_champMSKBRI_MAX];
                }
                
			}
			set
			{
                Row[c_champMSKBRI_MAX, true] = value;
                GetAcces_Accesc2AvecCreation().MaskBriMax = value;
			}
		}

        [DynamicField("Operating agent mask")]
        public Boolean MaskBri
        {
            get
			{
                return (MaskBriMin > 0);
			}			
        }

        public string MaskBriDateMaxString
        {
            get
            {
                if (MaskBriDateMax == null)
                    return "";
                else
                    return ((DateTime)MaskBriDateMax).ToString("G");
            }
        }

        public string MaskBriDateMinString
        {
            get
            {
                if (MaskBriDateMin == null)
                    return "";
                else
                    return ((DateTime)MaskBriDateMin).ToString("G");
            }
        }
		
		///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champMSKADM_MIN, NullAutorise = true)]
        [DynamicField("Administrator masking start (sec.)")]
        public System.Int32? MaskAdminMin
		{
			get
			{
                CSpvAcces_Accesc2 acc2 = GetAcces_Accesc2();
                if (acc2 != null)
                    return acc2.MaskAdminMin;
                else
                {
                    if (Row[c_champMSKADM_MIN] == DBNull.Value)
					    return null;
                    else
				        return (System.Int32?)Row[c_champMSKADM_MIN];
                }
                
			}
			set
			{
                Row[c_champMSKADM_MIN, true] = value;
                GetAcces_Accesc2AvecCreation().MaskAdminMin = value;
			}            
		}

        ////////////////////////////////////////////////////////////////////////
        [DynamicField("Administrator masking ending date")]
        public System.DateTime? MaskAdminDateMax
        {
            get
            {
                CDivers div = new CDivers();
                return div.FromSecToDate((double?)MaskAdminMax);
            }
            set
            {
                CDivers div = new CDivers();
                MaskAdminMax = (System.Int32?)div.FromDateToSec(value);
            }
        }

        public string MaskAdminDateMaxString
        {
            get
            {
                if (MaskAdminDateMax == null)
                    return "";
                else
                    return ((DateTime)MaskAdminDateMax).ToString("G");
            }
        }

        public string MaskAdminDateMinString
        {
            get
            {
                if (MaskAdminDateMin == null)
                    return "";
                else
                    return ((DateTime)MaskAdminDateMin).ToString("G");
            }
        }
		
		
		///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champMSKADM_MAX, NullAutorise = true)]
        [DynamicField("Administrator masking end (sec.)")]
        public System.Int32? MaskAdminMax
		{
			get
			{
                CSpvAcces_Accesc2 acc2 = GetAcces_Accesc2();
                if (acc2 != null)
                    return acc2.MaskAdminMax;
                else
                {
                    if (Row[c_champMSKADM_MAX] == DBNull.Value)
					    return null;
                    else
				        return (System.Int32?)Row[c_champMSKADM_MAX];
                }
                
			}
			set
			{
                Row[c_champMSKADM_MAX, true] = value;
                GetAcces_Accesc2AvecCreation().MaskAdminMax = value;
			}            
		}

        ////////////////////////////////////////////////////////////////////////
        [DynamicField("Administrator masking begining date")]
        public System.DateTime? MaskAdminDateMin
        {
            get
            {
                CDivers div = new CDivers();
                return div.FromSecToDate((double?)MaskAdminMin);
            }
            set
            {
                CDivers div = new CDivers();
                MaskAdminMin = (System.Int32?)div.FromDateToSec(value);
            }
        }

        [DynamicField("Administrator mask")]
        public Boolean MaskAdmin
        {
            get
			{
                return (MaskAdminMin > 0);
			}	
        }

        public void Demasque(bool bAdmin)
        {
            if (bAdmin)
            {
                MaskAdminMin = 0;
                MaskAdminMax = 0;                
            }
            else
            {
                MaskBriMin = 0;
                MaskBriMax = 0;              
            }
        }
        //Redondance, à supprimer plus tard
        //créée par la procédure stockée GenAccesAccesc()
        //mis à jour par tu_equip (plus depuis le 11/08/09)	
        ///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champEQUIP_TRAPNOM, 128, NullAutorise = true)]
		[DynamicField("Trap name")]
		public System.String EquipTrapNom
		{
			get
			{
				if (Row[c_champEQUIP_TRAPNOM] == DBNull.Value)
					return null;
				return (System.String)Row[c_champEQUIP_TRAPNOM];
			}
            set
            {
                Row[c_champEQUIP_TRAPNOM, true] = value;
            }
		}

        //Redondance, à supprimer plus tard
        //utilisé dans SvcPol et SpvTrap
		///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champEQUIP_ADDRIP, 16, NullAutorise = true)]
		[DynamicField("Equipment IP address ")]
        public System.String EquipAddrIP
		{
			get
			{
				if (Row[c_champEQUIP_ADDRIP] == DBNull.Value)
					return null;
				return (System.String)Row[c_champEQUIP_ADDRIP];
			}
            set
            {
                Row[c_champEQUIP_ADDRIP, true] = value;
            }
		}

        //Redondance, à supprimer plus tard
	    ///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champEQUIP_INDEXSNMP, 256, NullAutorise = true)]
		[DynamicField("Equipment SNMP index")]
		public System.String EquipSNMPIndex
		{
			get
			{
				if (Row[c_champEQUIP_INDEXSNMP] == DBNull.Value)
					return null;
				return (System.String)Row[c_champEQUIP_INDEXSNMP];
			}
            set
            {
                Row[c_champEQUIP_INDEXSNMP, true] = value;
            }
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champMSKADM_HOW)]
		[DynamicField("Masking type")]
        public EMaskType Masking_Type
		{
			get
			{
                CSpvAcces_Accesc2 acc2 = GetAcces_Accesc2();
                if (acc2 != null)
                    return acc2.Masking_Type;
                else
                    return (EMaskType)Row[c_champMSKADM_HOW];
			}
			set
			{
                Row[c_champMSKADM_HOW, true] = (EMaskType)value;
                GetAcces_Accesc2AvecCreation().Masking_Type = (EMaskType)value;
			}
		}

        [DynamicField("Masking Trigger")]
        public System.Int32? Masking_Trigger
        {
            get
            {
                CSpvAcces_Accesc2 acc2 = GetAcces_Accesc2();
                if (acc2 != null)
                    return acc2.Trigger;
                else
                    return null;
            }
            set
            {
                GetAcces_Accesc2AvecCreation().Trigger = value;
            }
        }

        
        ///////////////////////////////////////////////////////////////////////////       
        [DynamicField("Masking Comment")]
        public System.String Masking_Comment
        {
            get
            {
                CSpvAcces_Accesc2 acc2 = GetAcces_Accesc2();
                if (acc2 != null)
                    return acc2.Comment;
                else
                    return null;
            }
            set
            {
                GetAcces_Accesc2AvecCreation().Comment = value;
            }
        }
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champALARMGEREE_TOSURV)]
        [DynamicField("Monitor alarm access")]
        public Boolean Surveiller
		{
			get
			{
                return (Boolean)Row[c_champALARMGEREE_TOSURV];
			}
			set
			{
				Row[c_champALARMGEREE_TOSURV,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champALARMGEREE_FREQN, NullAutorise = true)]
        [DynamicField("Frequent alarm number")]
        public System.Int32? FreqNb
		{
			get
			{
				if (Row[c_champALARMGEREE_FREQN] == DBNull.Value)
					return null;
                return (System.Int32?)Row[c_champALARMGEREE_FREQN];
			}
			set
			{
				Row[c_champALARMGEREE_FREQN,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champALARMGEREE_FREQD, NullAutorise = true)]
        [DynamicField("Frequent alarm period")]
        public System.Int32? FreqPeriod
		{
			get
			{
				if (Row[c_champALARMGEREE_FREQD] == DBNull.Value)
					return null;
                return (System.Int32?)Row[c_champALARMGEREE_FREQD];
			}
			set
			{
				Row[c_champALARMGEREE_FREQD,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champALARMGEREE_TOAFF)]
        [DynamicField("Display alarm")]
        public Boolean Afficher
		{
			get
			{
				return (Boolean)Row[c_champALARMGEREE_TOAFF];
			}
			set
			{
				Row[c_champALARMGEREE_TOAFF,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champALARMGEREE_SEUILB, NullAutorise = true)]
        [DynamicField("Threshold bottom level")]
        public System.Int32? SeuilBas
		{
			get
			{
				if (Row[c_champALARMGEREE_SEUILB] == DBNull.Value)
					return null;
                return (System.Int32?)Row[c_champALARMGEREE_SEUILB];
			}
			set
			{
				Row[c_champALARMGEREE_SEUILB,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champALARMGEREE_SEUILH, NullAutorise = true)]
        [DynamicField("Threshold high level")]
        public System.Int32? SeuilHaut
		{
			get
			{
				if (Row[c_champALARMGEREE_SEUILH] == DBNull.Value)
					return null;
                return (System.Int32?)Row[c_champALARMGEREE_SEUILH];
			}
			set
			{
				Row[c_champALARMGEREE_SEUILH,true]=value;
			}
		}


        ///////////////////////////////////////////////////////////////
        public bool AccesCable()
        {
            return (AccesAlarmeOne.Id > 0 && AccesAlarmeTwo.Id > 0);
        }

        ///////////////////////////////////////////////////////////////
        [Relation(CSpvAccesAlarme.c_nomTable, new string[] { CSpvAccesAlarme.c_champACCES_ID }, new string[] { CSpvLienAccesAlarme.c_champACCES1_ID }, true, true)]
        [DynamicField("First Alarm Access")]
        public CSpvAccesAlarme AccesAlarmeOne
        {
            get
            {
                return (CSpvAccesAlarme)GetParent(new string[] { c_champACCES1_ID }, typeof(CSpvAccesAlarme));
            }
            set
            {
                SetParent(new string[] { c_champACCES1_ID }, value);
            }
        }

        ///////////////////////////////////////////////////////////////
        [Relation(CSpvAccesAlarme.c_nomTable, new string[] { CSpvAccesAlarme.c_champACCES_ID }, new string[] { CSpvLienAccesAlarme.c_champACCES2_ID }, false, false)]
        [DynamicField("Second Alarm Access")]
        public CSpvAccesAlarme AccesAlarmeTwo
        {
            get
            {
                return (CSpvAccesAlarme)GetParent(new string[] { c_champACCES2_ID }, typeof(CSpvAccesAlarme));
            }
            set
            {
                SetParent(new string[] { c_champACCES2_ID }, value);
            }
        }

        public CSpvAccesAlarme SpvAccesAlarmeSysteme0()
        {
            CListeObjetsDonnees  liste = new CListeObjetsDonnees(ContexteDonnee, typeof (CSpvAccesAlarme));
            liste.Filtre = new CFiltreData (CSpvAccesAlarme.c_champACCES_ID + "=@1", 0);
            if (liste.Count != 1)
            {
                Exception e = new Exception("Alarm access not found|50001");
                throw e;
            }
            return (CSpvAccesAlarme) liste[0];
        }


		public CSpvAlarmGeree SpvAlarmGereeSysteme1()
		{
			CListeObjetsDonnees liste = new CListeObjetsDonnees(ContexteDonnee, typeof(CSpvAlarmGeree));
			liste.Filtre = new CFiltreData(CSpvAlarmGeree.c_champALARMGEREE_ID + "=@1", 1);
			if (liste.Count != 1)
			{
				Exception e = new Exception("System alarm access type extension not found|50013");
				throw e;
			}
			return (CSpvAlarmGeree)liste[0];
		}

              		
		
          ///////////////////////////////////////////////////////////////
        [Relation(CSpvAlarmGeree.c_nomTable, new string[] { CSpvAlarmGeree.c_champALARMGEREE_ID }, new string[] { CSpvLienAccesAlarme.c_champALARMGEREE_ID }, false, true)]

        [DynamicField("Managed alarm")]
        public CSpvAlarmGeree SpvAlarmgeree
        {
            get
            {
                return (CSpvAlarmGeree)GetParent(new string[] { c_champALARMGEREE_ID }, typeof(CSpvAlarmGeree));
            }
            set
            {
                SetParent(new string[] { c_champALARMGEREE_ID }, value);
            }
        }

        ///////////////////////////////////////////////////////////////
   /*     [Relation(CSpvScript.c_nomTable, new string[] { CSpvScript.c_champSCRIPT_ID }, new string[] { CSpvLienAccesAlarmes.c_champSCRIPT_ID }, false, false)]
        [DynamicField("Script")]
        public CSpvScript SpvScript
        {
            get
            {
                return (CSpvScript)GetParent(new string[] { c_champSCRIPT_ID }, typeof(CSpvScript));
            }
            set
            {
                SetParent(new string[] { c_champSCRIPT_ID }, value);
            }
        }*/

        ///////////////////////////////////////////////////////////////
        [Relation(CSpvSite.c_nomTable, new string[] { CSpvSite.c_champSITE_ID }, new string[] { CSpvLienAccesAlarme.c_champSITE_ID }, false, true)]
        [DynamicField("Spv Site")]
        public CSpvSite SpvSite
        {
            get
            {
                return (CSpvSite)GetParent(new string[] { c_champSITE_ID }, typeof(CSpvSite));
            }
            set
            {
                SetParent(new string[] { c_champSITE_ID }, value);
            }
        }

        [Relation(CSpvEquip.c_nomTable, new string[] { CSpvEquip.c_champEQUIP_ID }, new string[] { CSpvLienAccesAlarme.c_champEQUIP_ID }, false, true)]
        [DynamicField("Spv Equipment")]
        public CSpvEquip SpvEquip
        {
            get
            {
                return (CSpvEquip)GetParent(new string[] { c_champEQUIP_ID }, typeof(CSpvEquip));
            }
            set
            {
                SetParent(new string[] { c_champEQUIP_ID }, value);
            }
        }

        [Relation(CSpvLiai.c_nomTable, new string[] { CSpvLiai.c_champLIAI_ID }, new string[] { CSpvLienAccesAlarme.c_champLIAI_ID }, false, true)]
        [DynamicField("Spv Link")]
        public CSpvLiai SpvLiai
        {
            get
            {
                return (CSpvLiai)GetParent(new string[] { c_champLIAI_ID }, typeof(CSpvLiai));
            }
            set
            {
                SetParent(new string[] { c_champLIAI_ID }, value);
            }
        }

 
        [Relation(CSpvTypeq.c_nomTable, new string[] { CSpvTypeq.c_champTYPEQ_ID }, new string[] { CSpvLienAccesAlarme.c_champTYPEQ_ID }, false, true)]
        [DynamicField("Spv Equipment type")]
        public CSpvTypeq SpvTypeq
        {
            get
            {
                return (CSpvTypeq)GetParent(new string[] { c_champTYPEQ_ID }, typeof(CSpvTypeq));
            }
            set
            {
                SetParent(new string[] { c_champTYPEQ_ID }, value);
            }
        }

        ///////////////////////////////////////////////////////////////
        [RelationFille(typeof(CSpvAcces_Accesc2), "Acces_Accesc")]
        [DynamicChilds("Masking informations", typeof(CSpvAcces_Accesc2))]
        public CListeObjetsDonnees Acces_Accesc2
        {
            get
            {
                return GetDependancesListe(CSpvAcces_Accesc2.c_nomTable, CSpvAcces_Accesc2.c_champACCES_ACCESC2_ID);
            }
        }

        ///////////////////////////////////////////////////////////////
        [RelationFille(typeof(CSpvLienAccesAlarme_Rep), "LienAccesAlarmes")]
        [DynamicChilds("Operational state",typeof(CSpvLienAccesAlarme_Rep))]
        public CListeObjetsDonnees Acces_Accesc_Rep
        {
            get
            {
                return GetDependancesListe(CSpvLienAccesAlarme_Rep.c_nomTable, CSpvLienAccesAlarme_Rep.c_champACCES_ACCESC_ID);
            }
        }

        public ISpvObjetAvecAccesAlarmeCable BindingObject
        {
            get
            {
                /*
                if (m_BindingObject == null && AccesAlarmeOne != null)
                {                   
                    if (AccesAlarmeOne.SpvSite != null)
                        m_BindingObject = AccesAlarmeOne.SpvSite;
                    else if (AccesAlarmeOne.SpvEquip != null)
                        m_BindingObject = AccesAlarmeOne.SpvEquip;
                    else if (AccesAlarmeOne.SpvLiai != null)
                        m_BindingObject = AccesAlarmeOne.SpvLiai;
                }
                return m_BindingObject;*/

                if (SpvSite != null)
                    return SpvSite;
                if (SpvEquip != null)
                    return SpvEquip;
                if (SpvLiai != null)
                    return SpvLiai;
                return null;
                
            }
        }

        public string BindingObjectName
        {
            get
            {
                if (BindingObject != null)
                    return BindingObject.GetName();

                return "";
            }
        }

        public string BindingObjectTypeName
        {
            get
            {
                if (BindingObject != null)
                    return BindingObject.GetTypeName();

                return "";
            }
        }

        public CListeObjetsDonnees PrestationsConcernees
        {
            get
            {
                if (BindingObject != null)
                    return BindingObject.PrestationsConcernees;
                else
                    return null;
            }
        }
        /*
        public string NomsPrestationsConcernees
        {
            get
            {
                string names="";
                char[] trim = new char[2];
                trim[0]=(';');
                trim[1] = (' ');
                foreach (CSpvService prog in PrestationsConcernees)
                {
                    names += prog.Nom;
                    names += "; ";
                }
               
                return names.TrimEnd(trim);                
            }
        }*/


        protected override CResultAErreur MyCanDelete()
        {
            return CResultAErreur.True;
        }

        public string BindingObjectSiteName
        {
            get
            {
                if (BindingObject != null)
                {
                    CSpvSite[] sites = BindingObject.SitesPouvantContenirLeCollecteur;
                    if (sites.Length > 0)
                        return sites[0].SiteNom;
                }
                return "";
            }
        }

        public CSpvAcces_Accesc2 GetAcces_Accesc2()
        {
            CSpvAcces_Accesc2 acces_accesc2 = new CSpvAcces_Accesc2(ContexteDonnee);
            if (acces_accesc2.ReadIfExists(new CFiltreData(
                CSpvAcces_Accesc2.c_champACCES_ACCESC2_ID + "=" + Id)))
                return acces_accesc2;
            else
                return null;
        }
 
        public CSpvAcces_Accesc2 GetAcces_Accesc2AvecCreation()
        {
            CSpvAcces_Accesc2 acces_accesc2 = new CSpvAcces_Accesc2(ContexteDonnee);
            if (!acces_accesc2.ReadIfExists(new CFiltreData( 
                CSpvAcces_Accesc2.c_champACCES_ACCESC2_ID + "=" + Id)))
            {
                acces_accesc2.CreateNewInCurrentContexte();
                FillAcces_Accesc2(acces_accesc2);
            }

            return acces_accesc2;
        }

        void FillAcces_Accesc2(CSpvAcces_Accesc2 acces_accesc2)
        {
            acces_accesc2.Acces_Accesc = this;
            if (Row[c_champMSKADM_MIN] != DBNull.Value)
                acces_accesc2.MaskAdminMin = (System.Int32?)Row[c_champMSKADM_MIN];
            
            if (Row[c_champMSKADM_MAX] != DBNull.Value)
                acces_accesc2.MaskAdminMax = (System.Int32?)Row[c_champMSKADM_MAX];

            if (Row[c_champMSKBRI_MIN] != DBNull.Value)
                acces_accesc2.MaskBriMin = (System.Int32?)Row[c_champMSKBRI_MIN];
            
            if (Row[c_champMSKBRI_MAX] != DBNull.Value)
                acces_accesc2.MaskBriMax = (System.Int32?)Row[c_champMSKBRI_MAX];            
                       
        }

        public CResultAErreur MaskAdministrateur(DateTime? dateFrom, DateTime? dateTo, string stComment)
        {
            BeginEdit();

            MaskAdminDateMin = dateFrom;
            MaskAdminDateMax = dateTo;
            Masking_Comment = stComment;

            return CommitEdit();
        }

        public CResultAErreur MaskBrigadier(DateTime? dateFrom, DateTime? dateTo, string stComment)
        {
            BeginEdit();

            MaskBriDateMin = dateFrom;
            MaskBriDateMax = dateTo;
            Masking_Comment = stComment;

            return CommitEdit();
        }

        public CResultAErreur DemasquageAutomatic(bool bAdmin)
        {
            BeginEdit();
            Demasque(bAdmin);
            return CommitEdit();
        }

        public CResultAErreur ProvoquerAlarme()
        {
            CResultAErreur result = CResultAErreur.True;

            if (this.AccesAlarmeOne == this.SpvAccesAlarmeSysteme0())
                result.EmpileErreur(I.T("Impossible to start an alarm for this acces|50018"));

            if (result)
            {
                CSpvEvenementReseau evenementReseau = new CSpvEvenementReseau(this.ContexteDonnee);
                evenementReseau.CreateNew();
                evenementReseau.CodeAlarmGrave = (int)this.CodeGravite;
                evenementReseau.AlarmDateText = CDivers.GetSysdateNotNull().ToString(CSpvEvenementReseau.c_formatDate);
                evenementReseau.AlarmCategory = CSpvEvenementReseau.c_strClasseTRAPS;
                evenementReseau.AlarmNumObj = CSpvEvenementReseau.c_TrapSimuMonteeAlarme;
                evenementReseau.AlarmComment = CSpvEvenementReseau.c_IANA_Futurocom.ToString();
                evenementReseau.AlarmNumAl = "192.168.0.1"; // Adresse IP bidon
                evenementReseau.SpvAlarmgeree = this.SpvAlarmgeree;

                string alarmInfo;
                string strNumal;
                
                switch (this.AccesAlarmeOne.CodeCategorieAcces)
                {
                    case (int)ECategorieAccesAlarme.SortieBoucle:
                        if (this.AccesAlarmeTwo.SpvEquip.TypeEquipement.Libelle == CSpvTypeq.c_CARTE_GTR)
                        {
                            int numIS = this.AccesAlarmeTwo.SpvEquip.GetNumeroIS();
                            int numCarte = this.AccesAlarmeTwo.SpvEquip.GetNumeroCarteGTR();
                            int numAcces = Convert.ToInt32(this.AccesAlarmeTwo.NomAcces);
                            int NumAccesAbsolu = (numCarte - 1) * CSpvEquip.c_NbPortsParCarteGTR + numAcces;
                            alarmInfo = string.Format("{0} = {1};{0} = {2}; {0} = {3}; {0} = {4}; {0} = {5}; {0} = {6}; {0} =",
                                ".1.3.6", this.CodeGravite, CSpvEvenementReseau.c_strClasseIS,
                                CSpvEvenementReseau.c_DefaultTexte, numIS, NumAccesAbsolu, 0);
                            evenementReseau.AlarmInfo = alarmInfo;
                        }
                        else // Equipement de collecte de la catégorie IP2
                        {
                            int numobj = 0;
                            string strComment = "";
                            strNumal = this.AccesAlarmeTwo.SpvEquip.AdresseIP;
                            if (strNumal == null || strNumal == "") // Cas équipements avec adresse IP non renseignée
                                strNumal = this.AccesAlarmeTwo.SpvEquip.Id.ToString();
                            alarmInfo = string.Format("{7};{0} = {1};{0} = {2}; {0} = {3}; {0} = {4}; {0} = {5}; {0} = {6}; {0} = {7};{0} = DIG{8}_ON",
                                ".1.3.6", this.CodeGravite, CSpvEvenementReseau.c_strClasseIP2,
                                CSpvEvenementReseau.c_DefaultTexte, numobj,
                                strNumal, strComment,
                                this.AccesAlarmeTwo.SpvEquip.Id,
                                this.AccesAlarmeTwo.NomAcces);
                            evenementReseau.AlarmInfo = alarmInfo;
                        }
                        break;
                    
                    case (int)ECategorieAccesAlarme.TrapSnmp:
                        System.Int32? nTrapGenerique = this.AccesAlarmeOne.TrapGenerique;
                        System.Int32? nTrapSpecifique = this.AccesAlarmeOne.TrapSpecifique;
                        string strClasse = CSpvEvenementReseau.c_strClasseTRAPS;
                        int nTrap = (int)nTrapSpecifique;

                        if (nTrapGenerique != null && nTrapGenerique < CSpvAccesAlarme.c_TrapGeneriqueMax)
                        {
                            strClasse = CSpvEvenementReseau.c_strClasseTRAPG;
                            nTrap = (int)nTrapGenerique;
                        }
                        strNumal = this.AccesAlarmeOne.SpvEquip.AdresseIP;
                        if (strNumal == null || strNumal == "") // Cas équipements commutateur E10B
                            strNumal = this.AccesAlarmeOne.SpvEquip.Id.ToString();

                        alarmInfo = string.Format("{0} = {1};{0} = {2}; {0} = {3}; {0} = {4}; {0} = {5}; {0} = {6}; {0} = {7};",
                                ".1.3.6", this.CodeGravite, strClasse,
                                CSpvEvenementReseau.c_DefaultTexte, nTrap, 
                                strNumal,
                                this.AccesAlarmeOne.TrapIANA, this.AccesAlarmeOne.SpvEquip.Id);
                        evenementReseau.AlarmInfo = alarmInfo;    
                        break;
                    default:
                        result.EmpileErreur(I.T("Impossible to start an alarm for this acces type|50017"));
                        break;
                }
                if (result)
                    result = evenementReseau.CommitEdit();
            }

            return result;
        }

        public static CListeObjetsDonnees ListeLienAccesMasqueBriq(CContexteDonnee ctx)
        {
            CListeObjetsDonnees lstAccesAccesC = new CListeObjetsDonnees(ctx, typeof(CSpvLienAccesAlarme));

            CDivers div = new CDivers();

            //int nowSec = (int)div.FromDateToSec(DateTime.Now);
            int nowSec = (int)div.FromDateToSec(CDivers.GetSysdateNotNull());

           string clauseWhere = CSpvLienAccesAlarme.c_champMSKBRI_MIN + "<= " + nowSec.ToString() + " and " +
                                CSpvLienAccesAlarme.c_champMSKBRI_MAX + ">= " + nowSec.ToString();
           
            lstAccesAccesC.Filtre = new CFiltreData(clauseWhere);

            return lstAccesAccesC;
        }

        public static CListeObjetsDonnees ListeLienAccesMasqueAdmin(CContexteDonnee ctx)
        {
            CListeObjetsDonnees lstAccesAccesC = new CListeObjetsDonnees(ctx, typeof(CSpvLienAccesAlarme));

            CDivers div = new CDivers();

            //int nowSec = (int)div.FromDateToSec(DateTime.Now);
            int nowSec = (int)div.FromDateToSec(CDivers.GetSysdateNotNull());

            string clauseWhere = CSpvLienAccesAlarme.c_champMSKADM_MIN + "<= " + nowSec.ToString() + " and " +
                                CSpvLienAccesAlarme.c_champMSKADM_MAX + ">= " + nowSec.ToString() + " and " +
                                CSpvLienAccesAlarme.c_champMSKADM_HOW + "<>" + ((int)EMaskType.ALaCreation).ToString();

            lstAccesAccesC.Filtre = new CFiltreData(clauseWhere);

            return lstAccesAccesC;
        }

        public static CListeObjetsDonnees ListeLienAccesMasqueACreation(CContexteDonnee ctx)
        {
            CListeObjetsDonnees lstAccesAccesC = new CListeObjetsDonnees(ctx, typeof(CSpvLienAccesAlarme));

            CDivers div = new CDivers();

            //int nowSec = (int)div.FromDateToSec(DateTime.Now);
            int nowSec = (int)div.FromDateToSec(CDivers.GetSysdateNotNull());

            string clauseWhere = CSpvLienAccesAlarme.c_champMSKADM_MIN + "<= " + nowSec.ToString() + " and " +
                                CSpvLienAccesAlarme.c_champMSKADM_MAX + ">= " + nowSec.ToString() + " and " +
                                CSpvLienAccesAlarme.c_champMSKADM_HOW + "=" + ((int)EMaskType.ALaCreation).ToString();

            lstAccesAccesC.Filtre = new CFiltreData(clauseWhere);

            return lstAccesAccesC;
        }
	}
}
