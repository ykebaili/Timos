using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using System.Drawing;
using sc2i.expression;
using sc2i.common.sig;
using System.IO;

namespace futurocom.sig
{
    public class CMapItemDessin : I2iSerializable, IDisposable
    {
        //Generateur d'items correspondant
        private CMapPointGenerator m_mapItemGenerator = null;

        //Index (ordre de test de la formule de condition dans L'item generator)
        private int m_nIndex = 0;

        private C2iExpression m_formuleToolTip = null;
        private C2iExpression m_formuleCondition = null;

        private bool m_bPermanentToolTip = false;
        
        private EMapMarkerType m_markerType = EMapMarkerType.green;
        private Bitmap m_image = null;

        //Non serialisé, utilisé à l'execution pour s'assurer de n'avoir 
        //qu'une instance de l'image enregistrée dans la Database
        private string m_strImageId = "";

        //-----------------------------------------------
        public CMapItemDessin()
        {
            m_strImageId = Guid.NewGuid().ToString();
        }

        //-----------------------------------------------
        public CMapItemDessin(CMapPointGenerator itemGenerator)
            :this()
        {
            m_mapItemGenerator = itemGenerator;
        }


        //-----------------------------------------------
        public void Dispose()
        {
            if (m_image != null)
                m_image.Dispose();
            m_image = null;
        }

        //-----------------------------------------------
        public CMapPointGenerator ItemGenerator
        {
            get
            {
                return m_mapItemGenerator;
            }
            set
            {
                m_mapItemGenerator = value;
            }
        }

        //-----------------------------------------------
        public int Index
        {
            get
            {
                return m_nIndex;
            }
            set
            {
                m_nIndex = value;
            }
        }

        //-----------------------------------------------
        public C2iExpression FormuleCondition
        {
            get
            {
                return m_formuleCondition;
            }
            set
            {
                m_formuleCondition = value;
            }
        }

        //-----------------------------------------------
        public bool PermanentToolTip
        {
            get
            {
                return m_bPermanentToolTip;
            }
            set
            {
                m_bPermanentToolTip = value;
            }
        }

        //-----------------------------------------------
        public C2iExpression FormuleToolTip
        {
            get
            {
                return m_formuleToolTip;
            }
            set
            {
                m_formuleToolTip = value;
            }
        }

        //-----------------------------------------------
        public Type TypeElementsDessines
        {
            get
            {
                if (m_mapItemGenerator != null)
                    return m_mapItemGenerator.TypeElementsDessines;
                return null;
            }
        }


        //-----------------------------------------------
        public EMapMarkerType MarkerType
        {
            get
            {
                return m_markerType;
            }
            set
            {
                m_markerType = value;
            }
        }

        //-----------------------------------------------
        public Bitmap Image
        {
            get
            {
                return m_image;
            }
            set
            {
                if (m_image != null)
                    m_image.Dispose();
                if (value == null)
                    m_image = null;
                else
                {
                    m_image = new Bitmap(value);
                }
            }
        }

        //-----------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //-----------------------------------------------
        public CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            serializer.TraiteInt(ref m_nIndex);

            int nTmp = (int)m_markerType;
            serializer.TraiteInt(ref nTmp);
            m_markerType = (EMapMarkerType)nTmp;

            result = serializer.TraiteObject<C2iExpression>(ref m_formuleCondition);
            if (result)
                result = serializer.TraiteObject<C2iExpression>(ref m_formuleToolTip);
            if (!result)
                return result;

            serializer.TraiteBool(ref m_bPermanentToolTip);

            bool bHasImage = m_image != null;
            serializer.TraiteBool(ref bHasImage);
            if (bHasImage)
            {
                switch (serializer.Mode)
                {
                    case ModeSerialisation.Lecture:
                        Byte[] bt = null;
                        serializer.TraiteByteArray(ref bt);
                        if (m_image != null)
                            m_image.Dispose();
                        m_image = null;
                        MemoryStream stream = new MemoryStream(bt);
                        try
                        {
                            Bitmap bmp = (Bitmap)Bitmap.FromStream(stream);
                            m_image = bmp;
                        }
                        catch
                        {
                            m_image = null;
                        }
                        stream.Close();
                        break;

                    case ModeSerialisation.Ecriture:
                        MemoryStream streamSave = new MemoryStream();
                        try
                        {
                            Bitmap copie = new Bitmap(m_image);
                            copie.Save(streamSave, System.Drawing.Imaging.ImageFormat.Png);
                            copie.Dispose();
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


        //---------------------------------------------------------------------------
        public bool GenereItem(
            object obj, 
            double fLat, 
            double fLong, CMapLayer layer)
        {
            CResultAErreur result = CResultAErreur.True;
            CContexteEvaluationExpression ctx = new CContexteEvaluationExpression(this.m_mapItemGenerator);
            if (FormuleCondition != null && !(FormuleCondition is C2iExpressionVrai))
            {
                result = FormuleCondition.Eval(ctx);
                if (!result || result.Data == null)
                    return false;
                bool? bResult = CUtilBool.BoolFromString(result.Data.ToString());
                if (bResult == null || !bResult.Value)
                    return false;
            }
            string strLibelle = "";
            if (FormuleToolTip != null)
            {
                result = FormuleToolTip.Eval(ctx);
                if (result && result.Data != null)
                {
                    strLibelle = result.Data.ToString();
                }
            }
            IMapItem item = null;
            if (MarkerType != EMapMarkerType.none)
            {
                item = new CMapItemSimple(layer, fLat, fLong, MarkerType);
            }
            else if (Image != null)
            {
                if (layer.Database.GetImage(m_strImageId) == null)
                    layer.Database.AddImage(m_strImageId, Image);
                item = new CMapItemImage(layer, fLat, fLong, m_strImageId);
            }
            else
            {
                item = new CMapItemSimple(layer, fLat, fLong, EMapMarkerType.green);
            }
            item.Tag = obj;
            item.ToolTip = strLibelle;
            item.PermanentToolTip = PermanentToolTip;

            if ( ItemGenerator.ActionSurClick != null )
                item.MouseClicked += new MapItemClickEventHandler(OnMouseClick);

            return true;
        }

        public void OnMouseClick(IMapItem item)
        {
            if (ItemGenerator != null && item != null)
                ItemGenerator.OnMapItemClick(item);
        }
    }
}
