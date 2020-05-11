using System;
using System.Drawing;
using System.IO;
using System.Drawing.Design;

using sc2i.expression;
using sc2i.common;
using sc2i.drawing;
using sc2i.formulaire;
using System.Drawing.Imaging;

namespace timos.data
{

    [WndName("Metafile")]
    [Serializable]
    [VisibleInInterfaceAttribute]
    public class C2iSymboleEMF : C2iSymbole
    {

        [System.Runtime.InteropServices.DllImport("gdi32")]

        public static extern int GetEnhMetaFileBits(int hemf, int cbBuffer, byte[] lpbBuffer); 

        private Metafile m_metafileDefault = null;



		/// ///////////////////////
		public C2iSymboleEMF()
		{
            Size = new Size(50, 50);
		}

		

		/// ///////////////////////
		public Metafile ImageFile
		{
			get
			{
				return m_metafileDefault;
			}
			set
			{
				if ( value == null )
					m_metafileDefault = null;
				else
				{
					if ( m_metafileDefault != null )
						m_metafileDefault.Dispose();
                    m_metafileDefault = (Metafile)value.Clone();
				}
			}
		}

		/// ///////////////////////
		public Metafile GetImage(CContexteEvaluationExpression contexte)
		{
			Metafile imgToCopy = null;
		
			if (imgToCopy == null)
				imgToCopy = ImageFile;
			if (imgToCopy != null)
			{
				return (Metafile)imgToCopy.Clone();
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
			base.MyDraw ( ctx );
		}

		/// ///////////////////////
		public override void DrawInterieur ( CContextDessinObjetGraphique ctx )
		{
			Graphics g = ctx.Graphic;
			Size sz = ClientSize;
			Rectangle rect = new Rectangle ( 0, 0, (int)sz.Width, (int)sz.Height);
			if ( m_metafileDefault != null )
			{
				int nWidth = m_metafileDefault.Width;
				int nHeight = m_metafileDefault.Height;
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
				g.DrawImage ( m_metafileDefault, destRect);
			}
		}


        public override void HorizontalFlip()
        {
            m_metafileDefault.RotateFlip(RotateFlipType.RotateNoneFlipX);
        }

        public override void VerticalFlip()
        {
            m_metafileDefault.RotateFlip(RotateFlipType.RotateNoneFlipY);
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

			bool bHasImage = m_metafileDefault != null;
			serializer.TraiteBool(ref bHasImage);
			if (bHasImage)
			{
				switch (serializer.Mode)
				{
					case ModeSerialisation.Lecture:
						Byte[] bt = null;
						serializer.TraiteByteArray(ref bt);
                        if (m_metafileDefault != null)
                            m_metafileDefault.Dispose();
                        m_metafileDefault = null;
						MemoryStream stream = new MemoryStream(bt);
						try
						{

							Metafile meta = (Metafile)Metafile.FromStream(stream);
							m_metafileDefault = meta;
						}
						catch
						{
							m_metafileDefault = null;
						}
						stream.Close();
						break;

					case ModeSerialisation.Ecriture:
						try
						{
                            int nHandle = m_metafileDefault.GetHenhmetafile().ToInt32();
                            int nBufSize = GetEnhMetaFileBits ( nHandle, 0, null );
                            byte[] buffer = new byte[nBufSize];
                            if (GetEnhMetaFileBits(nHandle, nBufSize, buffer) > 0)
                                serializer.TraiteByteArray(ref buffer);
                            else
                            {
                                buffer = new byte[0];
                                serializer.TraiteByteArray(ref buffer);
                            }
						}
						catch (Exception e)
						{
							string strVal = e.ToString();
						}
						break;

				}
			}
		
			return result;
		}

		
	}
}

    

