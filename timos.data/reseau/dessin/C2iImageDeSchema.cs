using System;
using System.Drawing;
using System.IO;
using System.Drawing.Design;

using sc2i.expression;
using sc2i.common;
using sc2i.drawing;
using sc2i.formulaire;

namespace timos.data
{

    [WndName("Image")]
    [Serializable]
    [VisibleInInterfaceAttribute]
    public class C2iImageDeSchema : C2iElementDeSchemaStatique
    {


        private Bitmap m_imageDefault = null;


        public C2iImageDeSchema()
            :base()
        {
        }

		/// ///////////////////////
		public C2iImageDeSchema(int nIdContexteDonnee)
            :base ( nIdContexteDonnee )
		{
            Size = new Size(50, 50);
		}

        public override bool ShouldSaveInBlob
        {
            get
            {
                return m_imageDefault != null;
            }
        }

		

		/// ///////////////////////
		public Bitmap ImageFile
		{
			get
			{
				return m_imageDefault;
			}
			set
			{
				if ( value == null )
					m_imageDefault = null;
				else
				{
					if ( m_imageDefault != null )
						m_imageDefault.Dispose();
					m_imageDefault = new Bitmap(value.Width, value.Height);
					Graphics g = Graphics.FromImage(m_imageDefault);
					Brush br = new SolidBrush ( BackColor );
					g.FillRectangle ( br, 0, 0, value.Width, value.Height );
					br.Dispose();
					g.DrawImage ( value, new Rectangle ( 0, 0, value.Width, value.Height ) );
					g.Dispose();
				}
			}
		}

		/// ///////////////////////
		public Image GetImage(CContexteEvaluationExpression contexte)
		{
			Image imgToCopy = null;
		
			if (imgToCopy == null)
				imgToCopy = ImageFile;
			if (imgToCopy != null)
			{
				return (Image)imgToCopy.Clone();
			}
			return null;
		}

	
        	/// ///////////////////////
		protected override void MyDraw( CContextDessinObjetGraphique ctx )
		{
            Graphics g = ctx.Graphic;
			Brush b = new SolidBrush(BackColor);
			Rectangle rect = new Rectangle ( Position , Size );
			g.FillRectangle(b, rect);
			b.Dispose();
            System.Drawing.Drawing2D.Matrix mat = g.Transform;
            g.TranslateTransform(Position.X, Position.Y);
            DrawInterieur(ctx);
            g.Transform = mat;
		}

		/// ///////////////////////
		public void DrawInterieur ( CContextDessinObjetGraphique ctx )
		{
			Graphics g = ctx.Graphic;
			Size sz = ClientSize;
			Rectangle rect = new Rectangle ( 0, 0, (int)sz.Width, (int)sz.Height);
			if ( m_imageDefault != null )
			{
				int nWidth = m_imageDefault.Width;
				int nHeight = m_imageDefault.Height;
				if ( nWidth == 0 || nHeight == 0 )
					return;

				double fRatioImage = (double)nWidth/(double)nHeight;
				double fRatioSize = (double)rect.Width/(double)rect.Height;
				if ( fRatioImage < fRatioSize )
				{
					//Prend toute la hauteur
					nHeight = rect.Height;
					nWidth = (int)(rect.Height * fRatioImage);
				}
				else
				{
					nWidth = rect.Width;
					nHeight = (int)(rect.Width / fRatioImage);
				}
				Rectangle destRect = new Rectangle ( 
					(rect.Width - nWidth)/2,
					(rect.Height-nHeight)/2,
					nWidth,
					nHeight );
                /*Code pour images transparente (pb de mémoire), donc masqué
                 * System.Drawing.Imaging.ImageAttributes attr = new System.Drawing.Imaging.ImageAttributes();
                float[][] mat = new float[][]{
                    new float[]{1,0,0,0,0},
                    new float[]{0,1,0,0,0},
                    new float[]{0,0,1,0,0},
                    new float[]{0,0,0,(float)(BackColor.A/255.0),0},
                    new float[]{0,0,0,0,0}
                };
                try
                {
                    attr.SetColorMatrix ( new System.Drawing.Imaging.ColorMatrix(
                    mat));
                
                    g.DrawImage(m_imageDefault, destRect, 0, 0, m_imageDefault.Width, m_imageDefault.Height, GraphicsUnit.Pixel, attr);
                }
                catch (Exception e)
                {
                }*/
                g.DrawImage(m_imageDefault, destRect);
			}
		}


       

		/// ///////////////////////////////////////
		private int GetNumVersion()
		{
			return 1;
		
		}

		/// ///////////////////////////////////////
		protected override CResultAErreur MySerialize(C2iSerializer serializer)
		{
			int nVersion = GetNumVersion();
			CResultAErreur result = serializer.TraiteVersion(ref nVersion);
			if (!result)
				return result;

			bool bHasImage = m_imageDefault != null;
			serializer.TraiteBool(ref bHasImage);
			if (bHasImage)
			{
				switch (serializer.Mode)
				{
					case ModeSerialisation.Lecture:
						Byte[] bt = null;
						serializer.TraiteByteArray(ref bt);
                        if (m_imageDefault != null)
                            m_imageDefault.Dispose();
                        m_imageDefault = null;
						MemoryStream stream = new MemoryStream(bt);
						try
						{
							Bitmap bmp = (Bitmap)Bitmap.FromStream(stream);
							m_imageDefault = bmp;
						}
						catch
						{
							m_imageDefault = null;
						}
						stream.Close();
						break;

					case ModeSerialisation.Ecriture:
						MemoryStream streamSave = new MemoryStream();
						try
						{
							m_imageDefault.Save(streamSave, System.Drawing.Imaging.ImageFormat.Png);
						}
						catch (Exception e)
						{
							string strVal = e.ToString();
						}
						Byte[] buf = streamSave.GetBuffer();
						serializer.TraiteByteArray(ref buf);
						streamSave.Close();
						break;

				}
			}
		
			return result;
		}

		
	}
}

    

