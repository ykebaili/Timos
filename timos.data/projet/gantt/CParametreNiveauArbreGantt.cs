using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using System.Drawing;
using sc2i.drawing;
using System.IO;
using System.Drawing.Imaging;

namespace timos.data.projet.gantt
{
    /// <summary>
    /// Paramétrage d'un niveau de l'arbre Gantt
    /// </summary>
    [Serializable]
    public abstract class CParametreNiveauArbreGantt : I2iSerializable, IDisposable
    {
        private CParametreNiveauArbreGantt m_parametreFils = null;

        private Image m_image = null;


        //------------------------------------------
        public CParametreNiveauArbreGantt()
        {
        }

        //------------------------------------------
        public virtual void Dispose()
        {
            if ( m_image != null )
            {
                m_image.Dispose();
                m_image = null;
            }
        }

        //------------------------------------------
        private int GetNumVersion()
        {
            return 1;
            //1 : ajout de l'image
        }

        //------------------------------------------
        public virtual CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            result = serializer.TraiteObject<CParametreNiveauArbreGantt>(ref m_parametreFils);
            if ( nVersion >= 1 )
            {
                bool bHasImage = m_image != null;
                serializer.TraiteBool(ref bHasImage);
                if (bHasImage)
                {
                    byte[] data = null;
                    MemoryStream stream = null;
                    switch (serializer.Mode)
                    {
                        case ModeSerialisation.Ecriture:
                            stream = new MemoryStream();
                            m_image.Save(stream, ImageFormat.Png);
                            data = stream.ToArray();
                            serializer.TraiteByteArray(ref data);
                            stream.Close();
                            break;
                        case ModeSerialisation.Lecture:
                            serializer.TraiteByteArray(ref data);
                            try
                            {
                                stream = new MemoryStream(data);
                                Image = (Bitmap)Bitmap.FromStream(stream);
                            }
                            catch 
                            {
                            }
                            break;
                    }
                }
            }
            return result;
        }

        //---------------------------------------------------------------
        public Image Image
        {
            get
            {
                if (m_image == null)
                    return null;
                return (Image)m_image.Clone();
            }
            set
            {
                if (m_image != null)
                    m_image.Dispose();
                m_image = null;
                if ( value != null )
                    m_image = CUtilImage.CreateImageImageResizeAvecRatio(value, new Size(16, 16), Color.White);
            }
        }

        //------------------------------------------
        public CParametreNiveauArbreGantt ParametreFils
        {
            get
            {
                return m_parametreFils;
            }
            set
            {
                m_parametreFils = value;
            }
        }

        //------------------------------------------
        public abstract void RangeProjets(IEnumerable<CElementDeGanttProjet> lstEltsProjets, CElementDeGantt elementParent);

    }
}
