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


namespace futurocom.sig.cartography
{
	/// <summary>
	/// Permet de définir la civilité d'un acteur (ex: Monsieur, Madame, société...)
	/// </summary>
    /// <remarks>
    /// Le terme acteur est pris au sens large; ce peut être une personne physique ou morale
    /// </remarks>
    [DynamicClass("GPS Line")]
	[Table(CGPSLine.c_nomTable, CGPSLine.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CGPSLineServeur")]
	public class CGPSLine : CObjetDonneeAIdNumeriqueAuto, IElementDeGPSCarte
	{
		public const string c_nomTable = "GPS_LINE";
		public const string c_champId = "GPS_LINE_ID";
		public const string c_champLibelle = "GPS_LINE_LABEL";

        public const string c_champDetail = "GPS_LINE_DETAIL";

        public const string c_champCachePoints = "LINE_DETAIL_CACHE";

		/// /////////////////////////////////////////////
		public CGPSLine( CContexteDonnee contexte)
			:base(contexte)
		{
		}
		
	/// /////////////////////////////////////////////
		public CGPSLine(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T("GPS line @1|20027",Libelle);
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champLibelle};
		}



        /// /////////////////////////////////////////////
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

        //-----------------------------------
        [TableFieldProperty(c_champDetail, NullAutorise = true)]
        public CDonneeBinaireInRow DataDetail
        {
            get
            {
                if (Row[c_champDetail] == DBNull.Value)
                {
                    CDonneeBinaireInRow donnee = new CDonneeBinaireInRow(ContexteDonnee.IdSession, Row, c_champDetail);
                    CContexteDonnee.ChangeRowSansDetectionModification(Row, c_champDetail, donnee);
                }
                return ((CDonneeBinaireInRow)Row[c_champDetail]).GetSafeForRow(Row.Row);
            }
            set
            {
                Row[c_champDetail] = value;
            }
        }

        //-----------------------------------
        [BlobDecoder]
        [TableFieldProperty(c_champCachePoints, IsInDb=false, NullAutorise = true)]
        public CGPSLineTrace DetailLigne
        {
            get
            {
                if (Row[c_champCachePoints] != DBNull.Value)
                    return (CGPSLineTrace)Row[c_champCachePoints];
                CGPSLineTrace trace = null;
                CDonneeBinaireInRow data = DataDetail;
                if (data != null && data.Donnees != null)
                {
                    MemoryStream stream = new MemoryStream(data.Donnees);
                        try
                        {
                            BinaryReader reader = new BinaryReader(stream);
                            CSerializerReadBinaire ser = new CSerializerReadBinaire(reader);
                            
                            ser.TraiteObject<CGPSLineTrace>(ref trace);
                            reader.Close();
                            reader.Dispose();
                        }
                        catch { 
                            
                        }
                    
                    stream.Dispose();
                }
                if (trace == null)
                    trace = new CGPSLineTrace();
                CContexteDonnee.ChangeRowSansDetectionModification(Row.Row, c_champCachePoints, trace);
                return trace;
            }
            set
            {
                Row[c_champCachePoints] = DBNull.Value;
                if (value == null)
                {
                    CDonneeBinaireInRow data = DataDetail;
                    data.Donnees = null;
                    DataDetail = data;

                }
                else
                {
                    MemoryStream stream = new MemoryStream();
                    CGPSLineTrace trace = value;
                    BinaryWriter writer = new BinaryWriter(stream);
                    CSerializerSaveBinaire ser = new CSerializerSaveBinaire(writer);
                    ser.TraiteObject<CGPSLineTrace>(ref trace);
                    writer.Close();
                    writer.Dispose();
                    CDonneeBinaireInRow donnee = DataDetail;
                    donnee.Donnees = stream.ToArray();
                    DataDetail = donnee;
                    stream.Dispose();
                }
            }
        }

        public IEnumerable<IMapItem> CreateMapItems(CMapLayer layer)
        {
            List<IMapItem> lstItems = new List<IMapItem>();
            CGPSLineTrace trace = DetailLigne;
            SLatLong lastPoint = trace.PointDepart;
            foreach (CGPSLineSegment segment in trace.Segments)
            {
                CMapItemPath path = new CMapItemPath(layer);
                path.Points = new SLatLong[] { lastPoint, segment.PointDestination };
                path.LineColor = segment.Couleur;
                path.LineWidth = segment.Width;
                path.Tag = segment;
                path.ToolTip = segment.Libelle;
                path.EnableClick = true;
                lstItems.Add(path);
                lastPoint = segment.PointDestination;
            }
            return lstItems.AsReadOnly();
        }

        //---------------------------------------------------------------------------
        public IEnumerable<IMapItem> FindMapItems(CMapDatabase database)
        {
            CGPSLineTrace trace = DetailLigne;
            List<IMapItem> lstPaths = new List<IMapItem>();
            foreach (CGPSLineSegment segment in trace.Segments)
            {
                CMapItemPath path = database.FindItemFromTag(segment) as CMapItemPath;
                if (path != null)
                {
                    lstPaths.Add(path);
                }
            }
            return lstPaths.AsReadOnly();
        }

        //---------------------------------------------------------------------------
        public IEnumerable<IMapItem> UpdateMapItems(CMapDatabase database, List<IMapItem> itemsToDelete)
        {
            CGPSLineTrace trace = DetailLigne;
            SLatLong lastPoint = trace.PointDepart;
            List<IMapItem> lstPaths = new List<IMapItem>();
            foreach (CGPSLineSegment segment in trace.Segments)
            {
                CMapItemPath path = database.FindItemFromTag(segment) as CMapItemPath;
                if (path != null)
                {
                    path.Points = new SLatLong[] { lastPoint, segment.PointDestination };
                    path.LineColor = segment.Couleur;
                    path.LineWidth = segment.Width;
                    path.Tag = segment;
                    path.ToolTip = segment.Libelle;
                    lstPaths.Add(path);
                    lastPoint = segment.PointDestination;
                }
            }
            return lstPaths.AsReadOnly();
        }

        //-----------------------------------------------------------------
        public void DeleteThisMapItem()
        {
            Delete(true);
        }

        //-----------------------------------------------------------------
        public IEnumerable<CMoveablePoint> GetMoveablePoints(CMapDatabase database)
        {
            List<CMoveablePoint> lstPoints = new List<CMoveablePoint>();
            CGPSLineTrace trace = DetailLigne;
            lstPoints.Add(new CMoveablePointForLineStart(database, this));
            foreach (CGPSLineSegment segment in trace.Segments)
            {
                lstPoints.Add(new CMoveablePointForLineSegment(database, this, segment));
            }
            return lstPoints.AsReadOnly();
        }

        /// /////////////////////////////////////////////
        [Relation(
            CGPSTypeLigne.c_nomTable,
            CGPSTypeLigne.c_champId,
            CGPSTypeLigne.c_champId,
            false,
            false)]
        public CGPSTypeLigne TypeLigne
        {
            get
            {
                return (CGPSTypeLigne)GetParent(CGPSTypeLigne.c_champId, typeof(CGPSTypeLigne));
            }
            set
            {
                SetParent(CGPSTypeLigne.c_champId, value);
            }
        }

        /// /////////////////////////////////////////////
        [DynamicField("Start point latitude")]
        public double LatitudeDepart
        {
            get
            {
                return DetailLigne.PointDepart.Latitude;
            }
            set
            {
                DetailLigne.PointDepart = new SLatLong(value, DetailLigne.PointDepart.Longitude);
            }
        }

        /// /////////////////////////////////////////////
        [DynamicField("Start point longitude")]
        public double LongitudeDepart
        {
            get
            {
                return DetailLigne.PointDepart.Longitude;
            }
            set
            {
                DetailLigne.PointDepart = new SLatLong(DetailLigne.PointDepart.Latitude, value);
            }
        }

        /// /////////////////////////////////////////////
        [DynamicField("End point latitude")]
        public double LatitudeFin
        {
            get
            {
                return DetailLigne.PointArrivee.Latitude;
            }
            set
            {

                CGPSLineSegment segment = null;
                if ( DetailLigne.Segments.Count() == 0 )
                { 
                    segment = new CGPSLineSegment(DetailLigne );
                    DetailLigne.AddSegment ( segment );
                }
                segment = DetailLigne.Segments.ElementAt(DetailLigne.Segments.Count() - 1);
                segment.PointDestination = new SLatLong(value, segment.PointDestination.Longitude);

            }
        }

        /// /////////////////////////////////////////////
        [DynamicField("End point longitude")]
        public double LongitudeFin
        {
            get
            {
                return DetailLigne.PointArrivee.Latitude;
            }
            set
            {
                CGPSLineSegment segment = null;
                if (DetailLigne.Segments.Count() == 0)
                {
                    segment = new CGPSLineSegment(DetailLigne);
                    DetailLigne.AddSegment(segment);
                }
                segment = DetailLigne.Segments.ElementAt(DetailLigne.Segments.Count() - 1);
                segment.PointDestination = new SLatLong(segment.PointDestination.Latitude, value);

            }
        }

        /// /////////////////////////////////////////////
        [DynamicMethod("Commit line detail", "Commits all modification in line points")]
        public void CommitLineDetail()
        {
            DetailLigne = DetailLigne;
        }

        

        /// /////////////////////////////////////////////
        [DynamicField("Points")]
        public IEnumerable<CPointGPS> Points
        {
            get
            {
                CGPSLineTrace trace = DetailLigne;
                List<CPointGPS> pts = new List<CPointGPS>();
                pts.Add(new CPointGPS(trace.PointDepart));
                foreach (CGPSLineSegment segment in trace.Segments)
                    pts.Add(new CPointGPS(segment.PointDestination));
                return pts.AsReadOnly();
            }
        }

        /// /////////////////////////////////////////////
        [DynamicField("Segments")]
        public IEnumerable<CGPSLineSegment> Segments
        {
            get
            {
                return DetailLigne.Segments;
            }
        }



        
    }
}
