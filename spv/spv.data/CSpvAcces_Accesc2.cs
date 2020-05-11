using System;
using System.Data;
using sc2i.data;
using sc2i.common;

namespace spv.data
{
    //Cette table contient les champs MSKBRI_MIN et MSKBRI_MAX ainsi que MSKADM_MIN et MAX
    //On utilise une table différente de ACCES_ACCESC et BITMESS pour éviter les problèmes de table en mutation.
    //Redondance, à supprimer plus tard
    //Le TRIGGER tub_acces_accesc2 maj ACCES_ACCESC.

	[Table(CSpvAcces_Accesc2.c_nomTable,CSpvAcces_Accesc2.c_nomTableInDb,new string[]{ CSpvAcces_Accesc2.c_champACCES_ACCESC2_AUTO_ID}, ModifiedByTrigger = true)]
	[ObjetServeurURI("CSpvAcces_Accesc2Serveur")]
	[DynamicClass("Spv alarm access wiring masking information")]
    public class CSpvAcces_Accesc2 : CObjetDonneeAIdNumeriqueAuto, IObjetSansVersion
	{
		public const string c_nomTable = "SPV_ACCES_ACCESC2";
		public const string c_nomTableInDb = "ACCES_ACCESC2";
        public const string c_champACCES_ACCESC2_AUTO_ID = "ACCES_ACCESC2_AUTO_ID";
		public const string c_champACCES_ACCESC2_ID ="ACCES_ACCESC2_ID";
		public const string c_champMSKBRI_MIN ="MSKBRI_MIN";
		public const string c_champMSKBRI_MAX ="MSKBRI_MAX";
		public const string c_champBRI_MASQUE ="BRI_MASQUE";
		public const string c_champMSKADM_MIN ="MSKADM_MIN";
		public const string c_champMSKADM_MAX ="MSKADM_MAX";
		public const string c_champADM_MASQUE ="ADM_MASQUE";
		public const string c_champTRIG ="TRIG";
		public const string c_champMSK_COMMENT ="MSK_COMMENT";
		public const string c_champMSKADM_HOW ="MSKADM_HOW";
		
		///////////////////////////////////////////////////////////////
		public CSpvAcces_Accesc2( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public CSpvAcces_Accesc2( DataRow row )
			:base(row)
		{
		}
		
		///////////////////////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
            Trigger = 0;
            Masking_Type = EMaskType.Demasque;
            Row[c_champADM_MASQUE] = false;
            Row[c_champBRI_MASQUE] = false;
 		}
		
		///////////////////////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
            return new string[] { c_champACCES_ACCESC2_AUTO_ID };
		}
		
		///////////////////////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
                return I.T("Alarm access wiring masking ainformation @1|30005", Id.ToString());
			}
		}

				
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champMSKBRI_MIN)]
   //     [DynamicField("Operating agent masking start (sec.)")]
        public System.Int32? MaskBriMin
		{
			get
			{
				if (Row[c_champMSKBRI_MIN] == DBNull.Value)
					return null;
                return (System.Int32?)Row[c_champMSKBRI_MIN];
			}
			set
			{
				Row[c_champMSKBRI_MIN,true]=value;
                SetMaskBri();
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
            
        }
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champMSKBRI_MAX)]
    //    [DynamicField("Operating agent masking end (sec.)")]
        public System.Int32? MaskBriMax
		{
			get
			{
				if (Row[c_champMSKBRI_MAX] == DBNull.Value)
					return null;
				return (System.Int32?)Row[c_champMSKBRI_MAX];
			}
			set
			{
				Row[c_champMSKBRI_MAX,true]=value;
                SetMaskBri();
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
            
        }

        private void SetMaskBri()
        {
            DateTime now = CDivers.GetSysdateNotNull();// DateTime.Now;
            if (now >= MaskBriDateMin && now < MaskBriDateMax)
                MaskBriEnCours = true;
            else
                MaskBriEnCours = false;
        }

		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champBRI_MASQUE)]
        [DynamicField("Operating agent mask")]
        public Boolean MaskBriEnCours
		{
			get
			{
				return (Boolean)Row[c_champBRI_MASQUE];
			}
            set
            {
                Row[c_champBRI_MASQUE, true] = value;
            }
		}
               	
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champMSKADM_MIN)]
    //    [DynamicField("Administrator masking start")]
        public System.Int32? MaskAdminMin
		{
			get
			{
				if (Row[c_champMSKADM_MIN] == DBNull.Value)
					return null;
				return (System.Int32?)Row[c_champMSKADM_MIN];
			}
			set
			{
				Row[c_champMSKADM_MIN,true]=value;
                SetMaskAdmin();
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
            
        }
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champMSKADM_MAX)]
   //     [DynamicField("Administrator masking end")]
        public System.Int32? MaskAdminMax
		{
			get
			{
				if (Row[c_champMSKADM_MAX] == DBNull.Value)
					return null;
				return (System.Int32?)Row[c_champMSKADM_MAX];
			}
			set
			{
				Row[c_champMSKADM_MAX,true]=value;
                SetMaskAdmin();
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
            
        }

        private void SetMaskAdmin()
        {
            DateTime now = CDivers.GetSysdateNotNull();//DateTime.Now;
            if (now >= MaskAdminDateMin && now < MaskAdminDateMax)
                MaskAdminEnCours = true;
            else
                MaskAdminEnCours = false;
        }
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champADM_MASQUE)]
        [DynamicField("Administrator mask")]
        public Boolean MaskAdminEnCours
		{
			get
			{
				return (Boolean)Row[c_champADM_MASQUE];
            }
            set
            {
                Row[c_champADM_MASQUE, true] = value;
            }
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTRIG)]
		[DynamicField("Trigger")]
		public System.Int32? Trigger
		{
			get
			{
				if (Row[c_champTRIG] == DBNull.Value)
					return null;
                return (System.Int32?)Row[c_champTRIG];
			}
			set
			{
				Row[c_champTRIG,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champMSK_COMMENT,256)]
		[DynamicField("Comment")]
        public System.String Comment
		{
			get
			{
				if (Row[c_champMSK_COMMENT] == DBNull.Value)
					return null;
				return (System.String)Row[c_champMSK_COMMENT];
			}
			set
			{
				Row[c_champMSK_COMMENT,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champMSKADM_HOW)]
        [DynamicField("Masking type")]
        public EMaskType Masking_Type
		{
			get
			{
                return (EMaskType)Row[c_champMSKADM_HOW];
			}
			set
			{
                Row[c_champMSKADM_HOW, true] = (EMaskType)value;
			}
		}

        [Relation(CSpvLienAccesAlarme.c_nomTable, new string[] { CSpvLienAccesAlarme.c_champACCES_ACCESC_ID }, new string[] { CSpvAcces_Accesc2.c_champACCES_ACCESC2_ID }, false, true)]
        [DynamicField("Alarm access wiring")]
        public CSpvLienAccesAlarme Acces_Accesc
        {
            get
            {
                return (CSpvLienAccesAlarme)GetParent(new string[] { c_champACCES_ACCESC2_ID }, typeof(CSpvLienAccesAlarme));
            }
            set
            {
                SetParent(new string[] { c_champACCES_ACCESC2_ID }, value);
            }
        }
	}
}
