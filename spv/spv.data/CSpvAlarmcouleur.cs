using System;
using System.Data;
using sc2i.data;
using sc2i.common;
using System.Drawing;
using System.Collections.Generic;


namespace spv.data
{
	[Table(CSpvAlarmcouleur.c_nomTable,CSpvAlarmcouleur.c_nomTableInDb,new string[]{ CSpvAlarmcouleur.c_champALARMCOUL_ID})]
	[ObjetServeurURI("CSpvAlarmcouleurServeur")]
	[DynamicClass("Alarm color")]
	public class	CSpvAlarmcouleur : CObjetDonneeAIdNumeriqueAuto, IObjetSansVersion
	{
		public const string c_nomTable = "SPV_ALARMCOUL";
		public const string c_nomTableInDb = "ALARMCOUL";
		public const string c_champALARMCOUL_ID ="ALARMCOUL_ID";
		public const string c_champALARMCOUL_CLASSID ="ALARMCOUL_CLASSID";
	//	public const string c_champALARMCOUL_NOM ="ALARMCOUL_NOM";
	//	public const string c_champALARMCOUL_ABREV ="ALARMCOUL_ABREV";
	//	public const string c_champALARMCOUL_COULEUR ="ALARMCOUL_COULEUR";
        public const string c_champALARMCOUL_GRAVITE = "ALARMCOUL_GRAVITE";
        public const string c_champALARMCOUL_COULEUR_NET = "ALARMCOUL_COULEUR_NET";
        
        const int c_classID = 2037;
		
		///////////////////////////////////////////////////////////////
		public CSpvAlarmcouleur( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public CSpvAlarmcouleur( DataRow row )
			:base(row)
		{
		}
		
		///////////////////////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
			//TODO : Insérer ici le code d'initalisation
            Row[c_champALARMCOUL_CLASSID] = c_classID;
		}
		
		///////////////////////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[] {c_champALARMCOUL_ID};
		}
		
		///////////////////////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
                return I.T("Alarm color|30009 @1", Id.ToString());
			}
		}
		
				
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champALARMCOUL_CLASSID)]
		[DynamicField("Class ID")]
		public System.Int32 ClassId
		{
			get
			{
                return (System.Int32)Row[c_champALARMCOUL_CLASSID];
			}
			
		}
	
		///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champALARMCOUL_COULEUR_NET)]
        [DynamicField("Color ARGB")]
		public System.Int32 CouleurARGB
		{
			get
			{
                return (System.Int32)Row[c_champALARMCOUL_COULEUR_NET];
			}
			set
			{
                Row[c_champALARMCOUL_COULEUR_NET, true] = value;
			}
		}

        public Color Couleur
        {
            get
            {
                return Color.FromArgb(CouleurARGB);
            }
            set
            {                
                CouleurARGB = value.ToArgb();
            }
        }

        ///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champALARMCOUL_GRAVITE)]
        [DynamicField("Color type code")]
        [IndexField]
        public System.Int32 CodeCouleur
        {
            get
            {
                return (System.Int32)Row[c_champALARMCOUL_GRAVITE];
            }

        }

        [DynamicField("Color type")]
        public CCouleurAlarme TypeCouleur
        {
            get
            {
                if (Enum.IsDefined(typeof(ECouleurAlarme), CodeCouleur))
                {
                    try
                    {
                        return new CCouleurAlarme((ECouleurAlarme)CodeCouleur);
                    }
                    catch
                    {
                    }
                }
                return null;
            }
            set
            {
                if (value != null)
                    Row[c_champALARMCOUL_GRAVITE] = value.CodeInt;
            }
        }

        public static Color GetColor(ECouleurAlarme couleur, CContexteDonnee ctx)
        {
            CSpvAlarmcouleur alarmCouleur = new CSpvAlarmcouleur(ctx);
            CFiltreData filtre = new CFiltreData(c_champALARMCOUL_GRAVITE + " = @1", (int)couleur);
            if (alarmCouleur.ReadIfExists(filtre))
                return alarmCouleur.Couleur;
            else
            {
                return DefaultColor(couleur);
            }
        }

        public static Color DefaultColor(ECouleurAlarme gravite)
        {
            switch (gravite)
            {
                case ECouleurAlarme.NoAlarm:
                    return Color.Green;
                case ECouleurAlarme.MaskBrig:
                    return Color.LightBlue;
                case ECouleurAlarme.MaskAdmin:
                    return Color.Blue;
                case ECouleurAlarme.Warning:
                    return Color.Salmon;
                case ECouleurAlarme.Undetermined:
                    return Color.Violet;
                case ECouleurAlarme.Minor:
                    return Color.Yellow;
                case ECouleurAlarme.Major:
                    return Color.Orange;
                case ECouleurAlarme.Critical:
                    return Color.Red;
                case ECouleurAlarme.NoAlarmAcces :
                    return Color.LightGray;
                case ECouleurAlarme.MinorOrMajorButOk :
                    return Color.Salmon;
                case ECouleurAlarme.NOk :
                    return Color.Red;
                default:
                    return Color.White;
                
            }
        }

        public static Image[] GetImageListSeverity(Size sz, CContexteDonnee ctx)
        {
            List<Image> lstImages = new List<Image>();
            List<IEnumALibelle> lstGrave = new List<IEnumALibelle>(CUtilSurEnum.GetEnumsALibelle(typeof(CCouleurAlarme)));
            foreach(CCouleurAlarme couleur in lstGrave)
            {
                Image bmp = new Bitmap(sz.Width, sz.Height);
                Graphics g = Graphics.FromImage(bmp);
                Brush br = new SolidBrush ( GetColor (couleur.Code, ctx ) );
                Rectangle rct = new Rectangle ( 0, 0, sz.Width, sz.Height );
                g.FillRectangle ( br, rct );
                br.Dispose();
                g.DrawRectangle ( Pens.Black, rct );
                lstImages.Add ( bmp );
            }
            return lstImages.ToArray();
        }        
	}
}
