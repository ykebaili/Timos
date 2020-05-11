using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using System.Drawing;
using System.Drawing.Imaging;

namespace timos.data.projet.besoin
{
    public enum ETypeDonneeBesoin
    {
        QuantiteCU = 0,
        TypeEquipement = 1,
       // Pourcentage = 2,
        BesoinParent = 3,
        TypeConsommable=4,
        Temps=5,
        Operation=6,
        Projet = 7

    }

    //--------------------------------------------------------
    public class CTypeDonneeBesoin : CEnumALibelle<ETypeDonneeBesoin>
    {
        private static Dictionary<ETypeDonneeBesoin, Image> m_dicImages = new Dictionary<ETypeDonneeBesoin, Image>();

        //--------------------------------------------------------
        public CTypeDonneeBesoin(ETypeDonneeBesoin type)
            : base(type)
        {
        }

        //--------------------------------------------------------
        [DynamicField("Label")]
        public override string Libelle
        {
            get
            {
                switch (Code)
                {
                    case ETypeDonneeBesoin.QuantiteCU:
                        return I.T("Quantity/Cost|20162");
                    case ETypeDonneeBesoin.TypeEquipement:
                        return I.T("Equipment|20163");
                    /*case ETypeDonneeBesoin.Pourcentage:
                        return I.T("Percentage|20161");*/
                    case ETypeDonneeBesoin.BesoinParent :
                        return I.T("Parent cost|20162");
                    case ETypeDonneeBesoin.TypeConsommable :
                        return I.T("Consumable|20175");
                    case ETypeDonneeBesoin.Temps :
                        return I.T("Time|20176");
                    case ETypeDonneeBesoin.Operation :
                        return I.T("Operation|20181");
                    case ETypeDonneeBesoin.Projet :
                        return I.T("Project|20191");
                }
                return "?";
            }
        }

        //--------------------------------------------------------
        private static Image GetImageComplement(ETypeDonneeBesoin type)
        {
            switch (type)
            {
                case ETypeDonneeBesoin.QuantiteCU:
                    return Resource.donneeBesoinQuantite;
                    break;
                case ETypeDonneeBesoin.TypeEquipement:
                    return DynamicClassAttribute.GetImage(typeof(CEquipement));
                    break;
                /*case ETypeDonneeBesoin.Pourcentage:
                    return Resource.donneeBesoinPourcentage;
                    break;*/
                case ETypeDonneeBesoin.BesoinParent:
                    return Resource.donneeBesoinParent;
                    break;
                case ETypeDonneeBesoin.TypeConsommable:
                    return DynamicClassAttribute.GetImage(typeof(timos.data.equipement.consommables.CTypeConsommable));
                    break;
                case ETypeDonneeBesoin.Temps:
                    return Resource.donneeBesoinTemps;
                    break;
                case ETypeDonneeBesoin.Operation :
                    return DynamicClassAttribute.GetImage(typeof(COperation));
                    break;
                case ETypeDonneeBesoin.Projet :
                    return DynamicClassAttribute.GetImage(typeof(CProjet));
                default:
                    break;
            }
            return null;
        }

        //--------------------------------------------------------
        public static Image GetImage(ETypeDonneeBesoin type)
        {
            Image img = null;
            if (m_dicImages.TryGetValue(type, out img))
                return img;
            Image imgBesoin = DynamicClassAttribute.GetImage(typeof(CBesoin));

            Image complement = GetImageComplement(type);
            if (complement == null)
            {
                m_dicImages[type] = imgBesoin;
                return imgBesoin;
            }

            img = new Bitmap(imgBesoin.Width, imgBesoin.Height);
            Graphics g = Graphics.FromImage(img);


            //Dessin l'image besoin en fond transparent
            ColorMatrix cm = new ColorMatrix();
            cm.Matrix33 = 0.25f;
            ImageAttributes ia = new ImageAttributes();
            ia.SetColorMatrix(cm);
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.DrawImage(imgBesoin, new Rectangle(0, 0, imgBesoin.Width, imgBesoin.Height), 0, 0, imgBesoin.Width, imgBesoin.Height,
                GraphicsUnit.Pixel, ia);
            ia.Dispose();

            Size szComp = new Size((int)(imgBesoin.Width * 0.7), (int)(imgBesoin.Height * 0.7));
            Point pt = new Point(imgBesoin.Width - szComp.Width, imgBesoin.Height-szComp.Height);
            g.DrawImage ( complement, new Rectangle(pt, szComp), new Rectangle (0,0, complement.Width,complement.Height),GraphicsUnit.Pixel);
            m_dicImages[type]=img;
            g.Dispose();
            return img;
        }
    }
}
