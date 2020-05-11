using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using System.Drawing;
using sc2i.expression;
using System.IO;

namespace timos.data.projet.gantt.icones
{
    /// <summary>
    /// Indique s'il y a des Customs sur l'élement de gantt
    /// </summary>
    [NomConvivialParametreIconeGantt("Custom Icon", false)]
    public class CParametreIconeGanttCustom : IParametreIconeGantt
    {
        private Image m_image = null;

        //Formules sur IElementDeGantt
        private C2iExpression m_formuleCondition = null;
        private C2iExpression m_formuleTooltip = null;

        //----------------------------------------------------
        public CParametreIconeGanttCustom()
        {
        }

        //----------------------------------------------------
        public Image Image
        {
            get
            {
                return m_image;
            }
            set
            {
                m_image = value;
            }
        }

        //----------------------------------------------------
        public C2iExpression Condition
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

        //----------------------------------------------------
        public C2iExpression Tooltip
        {
            get
            {
                return m_formuleTooltip;
            }
            set
            {
                m_formuleTooltip = value;
            }
        }

        //----------------------------------------------------
        public CIconeGantt GetIcone(IElementDeGantt element)
        {
            if ( m_formuleCondition != null && Image != null  )
            {
                CContexteEvaluationExpression ctx = new CContexteEvaluationExpression ( element );
                CResultAErreur result = m_formuleCondition.Eval ( ctx );
                if ( result )
                {
                    if (result.Data is bool && (bool)result.Data)
                    {
                        string strTooltip = "";
                        if (Tooltip != null)
                        {
                            result = Tooltip.Eval(ctx);
                            if (result)
                                strTooltip = result.Data.ToString();
                        }
                        return new CIconeGantt(Image, strTooltip);
                    }
                }
            }
            return null;
        }
        
        //----------------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //----------------------------------------------------
        public CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion ( ref nVersion );
            if ( !result )
                return result;
            result = serializer.TraiteObject<C2iExpression>(ref m_formuleCondition);
            if(result)
                result = serializer.TraiteObject<C2iExpression>(ref m_formuleTooltip);

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
							m_image.Save(streamSave, System.Drawing.Imaging.ImageFormat.Png);
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
