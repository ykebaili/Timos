using System;
using System.Collections;
using System.Data;
using System.Linq;
using sc2i.data;
using sc2i.common;
using sc2i.multitiers.client;
using System.IO;
using sc2i.common.sig;
using System.Collections.Generic;
using System.Drawing;


namespace futurocom.sig.cartography
{
	/// <summary>
	/// Permet de définir le type d'une ligne GPS
	/// </summary>
    /// <remarks>
    /// Le terme acteur est pris au sens large; ce peut être une personne physique ou morale
    /// </remarks>
    [DynamicClass("GPS line type")]
	[Table(CGPSTypeLigne.c_nomTable, CGPSTypeLigne.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CGPSTypeLigneServeur")]
	public class CGPSTypeLigne : CObjetDonneeAIdNumeriqueAuto
	{
		public const string c_nomTable = "GPS_LINE_TYPE";
		public const string c_champId = "GPSLNTP_ID";
        public const string c_champLibelle = "GPSLNTP_LABEL";
        public const string c_champDefaultColor = "GPSLNTP_COLOR";
        public const string c_champDefaultWidth = "GPSLNTP_WIDTH";
        

		/// /////////////////////////////////////////////
		public CGPSTypeLigne( CContexteDonnee contexte)
			:base(contexte)
		{
		}
		
	/// /////////////////////////////////////////////
		public CGPSTypeLigne(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T("GPS line type @1|20029",Libelle);
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
            DefaultWidth = 1;
            DefaultColor = Color.Black;
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champLibelle};
		}



        /// /////////////////////////////////////////////
		/// <summary>
		/// Le libellé du type de ligne
		/// </summary>
		[TableFieldProperty(c_champLibelle, 256)]
		[DynamicField("Label")]
		public string Libelle
		{
			get
			{
				return (string)Row[c_champLibelle];
			}
			set
			{
				Row[c_champLibelle] = value;
			}
		}

        /// /////////////////////////////////////////////
        /// <summary>
        /// Couleur par defaut (nombre entier)
        /// </summary>
        [TableFieldProperty(c_champDefaultColor)]
        [DynamicField("Color int")]
        public int DefaultColorInt
        {
            get
            {
                return (int)Row[c_champDefaultColor];
            }
            set
            {
                Row[c_champDefaultColor] = value;
            }
        }

        /// /////////////////////////////////////////////
        ///<summary>
        ///Couleur par défault (objet couleur)
        ///</summary>
        [DynamicField("Color")]
        public Color DefaultColor
        {
            get
            {
                try
                {
                    return Color.FromArgb(DefaultColorInt);
                }
                catch{}
                return Color.Black;
            }
            set{
                DefaultColorInt = value.ToArgb();
            }
        }

        /// /////////////////////////////////////////////
        /// <summary>
        /// Largeur par défaut des lignes
        /// </summary>
        [TableFieldProperty(c_champDefaultWidth)]
        [DynamicField("Default width")]
        public int DefaultWidth
        {
            get
            {
                return (int)Row[c_champDefaultWidth];
            }
            set
            {
                Row[c_champDefaultWidth] = value;
            }
        }
    

        
    }
}
