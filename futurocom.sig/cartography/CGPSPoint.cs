using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.multitiers.client;
using sc2i.common.sig;
using System.Collections.Generic;


namespace futurocom.sig.cartography
{
	/// <summary>
	/// Permet de définir la civilité d'un acteur (ex: Monsieur, Madame, société...)
	/// </summary>
    /// <remarks>
    /// Le terme acteur est pris au sens large; ce peut être une personne physique ou morale
    /// </remarks>
    [DynamicClass("GPS Point")]
	[Table(CGPSPoint.c_nomTable, CGPSPoint.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CGPSPointServeur")]
    public class CGPSPoint : CObjetDonneeAIdNumeriqueAuto, IElementDeGPSCarte
	{
		public const string c_nomTable = "GPS_POINT";
		public const string c_champId = "GPS_POINT_ID";
		public const string c_champLibelle = "GPS_POINT_LABEL";
        public const string c_champLongitude = "GPS_LONGITUDE";
        public const string c_champLatitude = "GPS_LATITUDE";
        public const string c_champMarkerType = "GPS_MARKER_TYPE";
        public const string c_champPermanentTooltip = "GPS_TOOTIP_ALWAYS";

		/// /////////////////////////////////////////////
		public CGPSPoint( CContexteDonnee contexte)
			:base(contexte)
		{
		}
		
	/// /////////////////////////////////////////////
		public CGPSPoint(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T("GPS point @1|20028",Libelle);
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
            MarkerType = EMapMarkerType.blue_small;
            PermanentToolTip = false;
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champLibelle};
		}


		

		/// <summary>
		/// Le libellé de la carte
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

        //------------------------------------------
        [TableFieldProperty(c_champLongitude)]
        [DynamicField("Longitude")]
        public double Longitude
        {
            get
            {
                return (double)Row[c_champLongitude];
            }
            set
            {
                Row[c_champLongitude] = value;
            }
        }

        //------------------------------------------
        [TableFieldProperty(c_champLatitude)]
        [DynamicField("Latitude")]
        public double Latitude
        {
            get
            {
                return (double)Row[c_champLatitude];
            }
            set
            {
                Row[c_champLatitude] = value;
            }
        }

        //------------------------------------------
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

        //------------------------------------------
        public EMapMarkerType MarkerType
        {
            get
            {
                try
                {
                    EMapMarkerType type = (EMapMarkerType)MarkerTypeInt;
                    return type;
                }
                catch
                {
                    return EMapMarkerType.blue_small;
                }
            }
            set
            {
                MarkerTypeInt = (int)value;
            }
        }

        //------------------------------------------
        [TableFieldProperty(c_champPermanentTooltip)]
        [DynamicField("Permanent tooltip")]
        public bool PermanentToolTip
        {
            get
            {
                return (bool)Row[c_champPermanentTooltip];
            }
            set
            {
                Row[c_champPermanentTooltip] = value;
            }
        }


        //------------------------------------------

        [Relation (
            CGPSCarte.c_nomTable,
            CGPSCarte.c_champId,
            CGPSCarte.c_champId,
            true,
            true
            )]
        [DynamicField("GPS Map")]
        public CGPSCarte Carte
        {
            get
            {
                return GetParent(CGPSCarte.c_champId, typeof(CGPSCarte)) as CGPSCarte;
            }
            set
            {
                SetParent(CGPSCarte.c_champId, value);
            }
        }


        //---------------------------------------------------------------------------
        public IEnumerable<IMapItem> CreateMapItems(CMapLayer layer)
        {
            CMapItemPoint point = null;
            if ( MarkerType == EMapMarkerType.none )
            {
                if ( TypePoint != null && TypePoint.Image != null )
                {
                    layer.Database.AddImage(TypePoint.IdUniversel, TypePoint.Image);
                    point = new CMapItemImage ( layer, Latitude, Longitude, TypePoint.IdUniversel);
                }
            }
            if (point == null)
            {
                EMapMarkerType type = MarkerType == EMapMarkerType.none ? EMapMarkerType.blue_dot : MarkerType;
                point = new CMapItemSimple(layer, Latitude, Longitude, type);
            }
            point.ToolTip = Libelle;
            point.PermanentToolTip = PermanentToolTip;
            point.Tag = this;
            return new IMapItem[] { point };
        }
        
        //---------------------------------------------------------------------------
        public IEnumerable<IMapItem> FindMapItems(CMapDatabase database)
        {
            CMapItemPoint mapItem = database.FindItemFromTag(this) as CMapItemPoint;
            if (mapItem != null)
                return new IMapItem[] { mapItem };
            return new IMapItem[0];
        }

        //---------------------------------------------------------------------------
        public IEnumerable<IMapItem> UpdateMapItems(CMapDatabase database, List<IMapItem> itemsToDelete)
        {
            CMapItemPoint mapItem = database.FindItemFromTag(this) as CMapItemPoint;
            if( mapItem != null )
            {
                CMapLayer layer = mapItem.Layer;
                //Vérifie le type du mapItem
                if (TypePoint != null && TypePoint.Image != null)
                {
                    if ( !(mapItem is CMapItemImage ) )
                    {
                        itemsToDelete.Add(mapItem);
                        mapItem.Layer.RemoveItem(mapItem);
                        layer.Database.AddImage(TypePoint.IdUniversel, TypePoint.Image);
                        mapItem = new CMapItemImage(layer, Latitude, Longitude, TypePoint.IdUniversel);
                    }
                    ((CMapItemImage)mapItem).ImageId = TypePoint.IdUniversel;
                }
                else
                {
                    if ( !(mapItem is CMapItemSimple) )
                    {
                        itemsToDelete.Add(mapItem);
                        mapItem.Layer.RemoveItem(mapItem);
                        mapItem = new CMapItemSimple(layer, Latitude, Longitude, MarkerType);
                    }
                    ((CMapItemSimple)mapItem).SimpleMarkerType = MarkerType == EMapMarkerType.none?EMapMarkerType.blue_dot:MarkerType;
                }

                mapItem.Tag = this;
                mapItem.Latitude = Latitude;
                mapItem.Longitude = Longitude;
                mapItem.ToolTip = Libelle;
                mapItem.PermanentToolTip = PermanentToolTip;
                return new IMapItem[] { mapItem };
            }
            return new IMapItem[0];
        }

        //---------------------------------------------------------------------------
        /// <summary>
        /// Le type du point
        /// </summary>
        [Relation(
            CGPSTypePoint.c_nomTable,
            CGPSTypePoint.c_champId,
            CGPSTypePoint.c_champId,
            false,
            false)]
        [DynamicField("Point type")]
        public CGPSTypePoint TypePoint
        {
            get
            {
                return (CGPSTypePoint)GetParent(CGPSTypePoint.c_champId, typeof(CGPSTypePoint));
            }
            set
            {
                SetParent(CGPSTypePoint.c_champId, value);
                if (value != null)
                    MarkerType = value.MarkerType;
            }
        }

        //---------------------------------------------------------------------------
        public void DeleteThisMapItem()
        {
            Delete(true);
        }


        //---------------------------------------------------------------------------
        public IEnumerable<CMoveablePoint> GetMoveablePoints(CMapDatabase database)
        {
            return new CMoveablePoint[]{ new CMoveablePointForGPSPoint(database, this)};
        }

       
    }
}
