using System;
using System.Collections;
using System.Data;
using System.Linq;
using sc2i.data;
using sc2i.common;
using sc2i.multitiers.client;
using sc2i.common.sig;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using sc2i.drawing;


namespace futurocom.sig.cartography
{
	/// <summary>
	/// Permet de définir la civilité d'un acteur (ex: Monsieur, Madame, société...)
	/// </summary>
    /// <remarks>
    /// Le terme acteur est pris au sens large; ce peut être une personne physique ou morale
    /// </remarks>
    [DynamicClass("GPS Map")]
	[Table(CGPSCarte.c_nomTable, CGPSCarte.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CGPSCarteServeur")]
	public class CGPSCarte : CObjetDonneeAIdNumeriqueAuto
	{
		public const string c_nomTable = "GPS_MAP";
		public const string c_champId = "GPS_MAP_ID";
		public const string c_champLibelle = "GPS_MAP_LABEL";

        public const string c_champBitmap = "GPS_MAP_IMAGE";

		/// /////////////////////////////////////////////
		public CGPSCarte( CContexteDonnee contexte)
			:base(contexte)
		{
		}
		
	/// /////////////////////////////////////////////
		public CGPSCarte(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T("GPS Map @1|20026",Libelle);
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



        //--------------------------------------------------------------------
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

        //--------------------------------------------------------------------
        /// <summary>
        /// Liste des lignes de la carte
        /// </summary>
        [RelationFille(typeof(CGPSLine),"Carte")]
        [DynamicChilds("Lines", typeof(CGPSLine))]
        public CListeObjetsDonnees Lignes
        {
            get
            {
                return GetDependancesListe(CGPSLine.c_nomTable, c_champId);
            }
        }

        //--------------------------------------------------------------------
        /// <summary>
        /// Liste des points de la carte
        /// </summary>
        [RelationFille(typeof(CGPSPoint), "Carte")]
        [DynamicChilds("Points", typeof(CGPSPoint))]
        public CListeObjetsDonnees Points
        {
            get
            {
                return GetDependancesListe(CGPSPoint.c_nomTable, c_champId);
            }
        }

        //--------------------------------------------------------------------
        public IEnumerable<IElementDeGPSCarte> ElementsDeCarte
        {
            get
            {
                List<IElementDeGPSCarte> lst = new List<IElementDeGPSCarte>();
                lst.AddRange(Points.OfType<IElementDeGPSCarte>());
                lst.AddRange(Lignes.OfType<IElementDeGPSCarte>());
                return lst.AsReadOnly();
            }
        }

        //--------------------------------------------------------------------
        public IEnumerable<CMapLayer> GenereItems(CMapDatabase database)
        {
            List<CMapLayer> lstLayers = new List<CMapLayer>();
            CMapLayer layer = database.GetLayer(IdUniversel, true);
            layer.ClearItems();
            lstLayers.Add(layer);
            foreach ( IElementDeGPSCarte element in ElementsDeCarte )
            {
                element.CreateMapItems(layer);
            }

            return lstLayers;

        }

        /// /////////////////////////////////////////////////////////
        [TableFieldProperty(c_champBitmap, NullAutorise = true)]
        public CDonneeBinaireInRow DataImage
        {
            get
            {
                if (Row[c_champBitmap] == DBNull.Value)
                {
                    CDonneeBinaireInRow donnee = new CDonneeBinaireInRow(ContexteDonnee.IdSession, Row, c_champBitmap);
                    CContexteDonnee.ChangeRowSansDetectionModification(Row, c_champBitmap, donnee);
                }
                object obj = Row[c_champBitmap];
                return ((CDonneeBinaireInRow)obj).GetSafeForRow(Row.Row);
            }
            set
            {
                Row[c_champBitmap] = value;
            }
        }

        /// /////////////////////////////////////////////////////////
        [BlobDecoder]
        public Bitmap ImageCarte
        {
            get
            {
                CDonneeBinaireInRow data = DataImage;
                if (data != null && data.Donnees != null)
                {
                    using (Stream stream = new MemoryStream(data.Donnees))
                    {
                        try
                        {
                            Bitmap image = (Bitmap)Bitmap.FromStream(stream);
                            return image;
                        }
                        catch
                        {
                        }
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
                    using (MemoryStream stream = new MemoryStream())
                    {
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

        /// <summary>
        /// Retourne l'image sous la forme d'un tableau d'octets
        /// </summary>
        /// <returns>Tableau d'octets de l'image</returns>
        [DynamicMethod("Returns image bytes")]
        public byte[] GetImageBytes()
        {
            return GetImageBytesResized(0, 0);
        }

        /// <summary>
        /// Retourne l'image sous la forme d'un tableau d'octets, en retouchant au<br/>
        /// préalable sa taille, en fonction des dimensions maximales passées en paramètres.
        /// </summary>
        /// <param name="nMaxWidth">Largeur maximale</param>
        /// <param name="nMaxHeight">Hauteur maximale</param>
        /// <returns>Tableau d'octets de l'image</returns>
        [DynamicMethod("Returns image bytes", "Max width", "Max height")]
        public byte[] GetImageBytesResized(int nMaxWidth, int nMaxHeight)
        {
            byte[] btResult = null;
            Image img = null;            
            try
            {
                img = ImageCarte;
                if (img != null)
                {
                    if (nMaxWidth > 0 && nMaxHeight > 0 && (img.Width > nMaxWidth || img.Height > nMaxHeight))
                    {
                        Size sz = CUtilImage.GetSizeAvecRatio(img, new Size(nMaxWidth, nMaxHeight));
                        Image img2 = CUtilImage.CreateImageImageResizeAvecRatio(img, sz, Color.White);
                        img.Dispose();
                        img = img2;
                    }
                    MemoryStream stream = new MemoryStream();
                    img.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    btResult = stream.GetBuffer();
                    stream.Close();
                    stream.Dispose();
                    img.Dispose();
                }
            }
            catch
            {

            }
            finally
            {
                if ( img != null )
                    img.Dispose();
            }
        
            return btResult;
        }

	}
}
