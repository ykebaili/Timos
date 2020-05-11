using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using spv.data.ConsultationAlarmes;
using System.Drawing;
using spv.data;
using sc2i.data;

namespace spv.win32
{
    public partial class CListViewAlarmes : CListeViewOptimiseeParLigne
    {
        
     /*   private static Color[] m_AlarmColors = {Color.Green,Color.Transparent,
                                        Color.Transparent, Color.Cyan,
                                        Color.Blue, Color.Yellow, 
                                        Color.Orange, Color.Red}; */       
        
        public CListViewAlarmes()
            : base()
        {            
            //Assign the ImageList objects to the ListView.
            //this.SmallImageList = CUtilCouleursAlarmes.GetImageListSeverity(Font.Height);            
        }

    /*    public static ImageList GetImageListSeverity(Control listView )
        {
            int rectSizeX = (int)listView.Font.Height;
            int rectSizeY = (int)listView.Font.Height;

            ImageList imageListSmall = new ImageList();

            Graphics g = listView.CreateGraphics();
            Bitmap[] bitmap;
            bitmap = new Bitmap[m_AlarmColors.Length];

           
            for (int i = 0; i < m_AlarmColors.Length; i++)
            {
                bitmap[i] = new Bitmap(rectSizeX, rectSizeY, g);
            }

            for (int z = 0; z < m_AlarmColors.Length; z++)
            {
                for (int i = 1; i < rectSizeY - 1; i++)
                {
                    for (int j = 1; j < rectSizeX - 1; j++)
                    {
                        bitmap[z].SetPixel(i, j, m_AlarmColors[z]);
                    }
                }
                for (int j = 0; j < rectSizeX; j++)
                {
                    bitmap[z].SetPixel(0, j, Color.Black);
                    bitmap[z].SetPixel(rectSizeY - 1, j, Color.Black);
                }
                for (int i = 0; i < rectSizeY ; i++)
                {
                    bitmap[z].SetPixel(i, 0, Color.Black);
                    bitmap[z].SetPixel(i, rectSizeX - 1, Color.Black);
                }
            }

            g.Dispose();
            for (int i = 0; i < m_AlarmColors.Length; i++)
            {
                imageListSmall.Images.Add(bitmap[i]);
            }

            return imageListSmall;
        }*/

        protected override void AfterItemCreation(RetrieveVirtualItemEventArgs e, object obj)
        {
            CInfoAlarmeAffichee info = obj as CInfoAlarmeAffichee;
            
            if(info.WaiteToBeAcknowledged())            
                e.Item.ForeColor = Color.Red;
            else
                e.Item.ForeColor = Color.Black;

            if (info.SeverityCode >= SmallImageList.Images.Count || info.SeverityCode < 0)
                 e.Item.ImageIndex = (int)EGraviteAlarmeAvecMasquage.Undetermined;
            else
                 e.Item.ImageIndex = info.SeverityCode;

        /*    Console.Write("gravite = {0} alarmId = {1}",  info.SeverityCode.ToString(),
                info.IdSpvAlarme.ToString());*/
        }
    }
}
