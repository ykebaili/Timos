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
	/// Permet de définir d'un point GPS
	/// </summary>
    [DynamicClass("GPS point type")]
	[Table(CGPSTypePoint.c_nomTable, CGPSTypePoint.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CGPSTypePointServeur")]
	public class CGPSTypePoint : CObjetDonneeAIdNumeriqueAuto
	{
		public const string c_nomTable = "GPS_POINT_TYPE";
		public const string c_champId = "GPSPTTP_ID";
        public const string c_champLibelle = "GPSPTTP_LABEL";
        public const string c_champMarkerType = "GPSPTTP_MARKER_TYPE";
        public const string c_champImage = "GPSPTTP_IMAGE";
        

		/// /////////////////////////////////////////////
		public CGPSTypePoint( CContexteDonnee contexte)
			:base(contexte)
		{
		}
		
	/// /////////////////////////////////////////////
		public CGPSTypePoint(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T("GPS point type @1|20035",Libelle);
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
            MarkerType = EMapMarkerType.blue;
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
        /// Type de marqueur
        /// </summary>
        /// <remarks>
        /// Les valeurs possibles sont : 
        /// none = 0
        /// arrow = 1
        /// blue = 2
        /// blue_small = 3
        /// blue_dot = 4
        /// blue_pushpin = 5
        /// brown_small = 6
        /// gray_small = 7
        /// green = 8
        /// green_small = 9
        /// green_dot = 10
        /// green_pushpin = 11
        /// green_big_go = 12
        /// yellow = 13
        /// yellow_small = 14
        /// yellow_dot = 15
        /// yellow_big_pause = 16
        /// yellow_pushpin = 17
        /// lightblue = 18
        /// lightblue_dot = 19
        /// lightblue_pushpin = 20
        /// orange = 21
        /// orange_small = 22
        /// orange_dot = 23
        /// pink = 24
        /// pink_dot = 25
        /// pink_pushpin = 26
        /// purple = 27
        /// purple_small = 28
        /// purple_dot = 29
        /// purple_pushpin = 30
        /// red = 31
        /// red_small = 32
        /// red_dot = 33
        /// red_pushpin = 34
        /// red_big_stop = 35
        /// black_small = 36
        /// white_small = 37
        /// </remarks>
        [TableFieldProperty(c_champMarkerType)]
        [DynamicField("Marker type")]
        public int MarkerTypeInt
        {
            get
            {
                return (int)Row[c_champMarkerType];
            }
            set
            {
                Row[c_champMarkerType] = value;
            }
        }

        /// /////////////////////////////////////////////
        public EMapMarkerType MarkerType
        {
            get
            {
                return (EMapMarkerType)MarkerTypeInt;
            }
            set
            {
                MarkerTypeInt = (int)value;
            }
        }

        /// /////////////////////////////////////////////////////////
        [TableFieldProperty(c_champImage, NullAutorise = true)]
        public CDonneeBinaireInRow DataImage
        {
            get
            {
                if (Row[c_champImage] == DBNull.Value)
                {
                    CDonneeBinaireInRow donnee = new CDonneeBinaireInRow(ContexteDonnee.IdSession, Row, c_champImage);
                    CContexteDonnee.ChangeRowSansDetectionModification(Row, c_champImage, donnee);
                }
                object obj = Row[c_champImage];
                return ((CDonneeBinaireInRow)obj).GetSafeForRow(Row.Row);
            }
            set
            {
                Row[c_champImage] = value;
            }
        }

        /// /////////////////////////////////////////////////////////
        [BlobDecoder]
        public Bitmap Image
        {
            get
            {
                CDonneeBinaireInRow data = DataImage;
                if (data != null && data.Donnees != null)
                {
                    Stream stream = new MemoryStream(data.Donnees);
                    try
                    {
                        Bitmap image = (Bitmap)Bitmap.FromStream(stream);
                        return image;
                    }
                    catch
                    {
                    }
                }
                return null;
            }
            set
            {
                if (value == null)
                {
                    CDonneeBinaireInRow data = DataImage;
                    data.Donnees = null;
                    DataImage = data;
                }
                else
                {
                    MemoryStream stream = new MemoryStream();
                    try
                    {
                        value.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                        CDonneeBinaireInRow data = DataImage;
                        data.Donnees = stream.GetBuffer();
                        DataImage = data;
                    }
                    catch
                    {
                        CDonneeBinaireInRow data = DataImage;
                        data.Donnees = null;
                        DataImage = data;
                    }
                }
            }
        }
    

        
    }
}
