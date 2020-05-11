using System;
using System.Collections.Generic;
using System.Text;
using sc2i.drawing;
using sc2i.common;
using sc2i.data;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace timos.data
{
    [Serializable]
    public class C2iObjetDeSchema : C2iObjetGraphique, IDisposable
    {
        [NonSerialized]
        private CElementDeSchemaReseau m_elementDeSchema = null;
        private Image m_imageCache = null;

        private IDonneeDessinElementDeSchemaReseau m_donneeDessin = null;


        private bool m_bNoDelete = false;
        //---------------------------------------------------
        public  C2iObjetDeSchema( )
            : base()
        {
        }

        public void Dispose()
        {
            if (m_imageCache != null)
                m_imageCache.Dispose();
            m_imageCache = null;
        }

        //---------------------------------------------------
        public void ClearDrawingCache()
        {
            if (m_imageCache != null)
                m_imageCache.Dispose();
            m_imageCache = null;
            foreach (I2iObjetGraphique objet in Childs)
            {
                C2iObjetDeSchema o = objet as C2iObjetDeSchema;
                if (o != null)
                    o.ClearDrawingCache();
            }
        }

        //---------------------------------------------------
        [System.ComponentModel.Browsable(false)]
        public virtual int IdObjetDeSchema
        {
            get
            {
                return DonneeDessin.IdObjetDeSchema;
            }
            set
            {
                DonneeDessin.IdObjetDeSchema = value;
            }
        }

        public bool CollectChildsAlarms
        {
            get
            {
                CDonneeDessinElementDeSchemaReseau donneeDessin = DonneeDessin as CDonneeDessinElementDeSchemaReseau;
                if (donneeDessin != null)
                    return donneeDessin.CollectChildsAlarms;
                return false;
            }
            set
            {
                CDonneeDessinElementDeSchemaReseau donneeDessin = DonneeDessin as CDonneeDessinElementDeSchemaReseau;
                if (donneeDessin != null)
                    donneeDessin.CollectChildsAlarms = value;
            }
        }


        //---------------------------------------------------
        public override bool AcceptChilds
        {
            get
            {
                return false;
            }
        }

        //---------------------------------------------------
        /// <summary>
        /// Recherche l'objet représentant un objet spécifique dans le schéma
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public C2iObjetDeSchema FindChildRepresentant(IElementDeSchemaReseau element)
        {
            if (element == null)
                return null;
            foreach (C2iObjetDeSchema objet in Childs)
            {
                if (objet.ElementDeSchema != null && objet.ElementDeSchema.IsValide() && element.Equals(objet.ElementDeSchema.ElementAssocie))
                    return objet;
            }
            //Si pas trouvé dans les fils, cherche dans les fils des fils
            foreach (C2iObjetDeSchema objet in Childs)
            {
                C2iObjetDeSchema objetDansFils = objet.FindChildRepresentant(element);
                if (objetDansFils != null)
                    return objetDansFils;
            }
            return null;
        }


        
        //---------------------------------------------------
        [System.ComponentModel.Browsable(false)]
        public CElementDeSchemaReseau ElementDeSchema
        {
            get
            {
                return m_elementDeSchema;
            }
            set
            {
                m_elementDeSchema = value;
                if (value != null)
                {
                    Position = new Point(value.X, value.Y);
                    Size = new Size(value.Width, value.Height);
                }
            }
        }

        [System.ComponentModel.Browsable(false)]
        public override bool NoDelete
        {
            get
            {
                return m_bNoDelete; 
            }

       }

        public void SetNoDelete(bool bNoDelete)
        {

            m_bNoDelete = bNoDelete;
        }

        
        //---------------------------------------------------
        public override bool AddChild(I2iObjetGraphique child)
        {
            return false;
        }

        //---------------------------------------------------
        public override void BringToFront(I2iObjetGraphique child)
        {
        }

        //---------------------------------------------------
        public override I2iObjetGraphique[] Childs
        {
            get
            {
                return new I2iObjetGraphique[0];
            }
        }

        //---------------------------------------------------
        public override bool ContainsChild(I2iObjetGraphique child)
        {
            return false;
        }

        //---------------------------------------------------
        public override void FrontToBack(I2iObjetGraphique child)
        {
            
        }

        //---------------------------------------------------
        protected override void MyDraw(CContextDessinObjetGraphique ctx)
        {
            if (ElementDeSchema != null && ElementDeSchema.IsValide())
            {
                C2iSymbole symbole = ElementDeSchema.SymboleADessiner;
                if (symbole != null)
                {
                    if (m_imageCache != null)
                    {
                        if (m_imageCache.Size == Size)
                        {
                            ctx.Graphic.DrawImageUnscaled(m_imageCache, new Point(Position.X, Position.Y));
                            return;
                        }

                    }
                    if (m_imageCache != null)
                        m_imageCache.Dispose();
                    m_imageCache = new Bitmap(Size.Width, Size.Height);
                    
                    Graphics g = Graphics.FromImage(m_imageCache);
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                    //Ajuste la matrice pour que le symbole prenne toute la place
                    //dans le rectangle
                    float fEchelleX = (float)ClientSize.Width / (float)symbole.Size.Width;
                    float fEchelleY = (float)ClientSize.Height / (float)symbole.Size.Height;
                    g.InterpolationMode = InterpolationMode.HighQualityBilinear;
                    g.ScaleTransform(fEchelleX, fEchelleY);
                    Graphics oldG = ctx.Graphic;
                    bool bOldLimit = ctx.WorkWithLimits;
                    ctx.WorkWithLimits = false;
                    ctx.Graphic = g;
                    symbole.Draw(ctx);
                    g.ResetTransform();
                    if (ElementDeSchema.IsCableALinterieur)
                    {
                        Icon icon = (System.Drawing.Icon)Resource.ResourceManager.GetObject("Connection");
                        ctx.Graphic.DrawIcon(icon, new Rectangle(ClientSize.Width - icon.Width,
                            ClientSize.Height - icon.Height, icon.Width, icon.Height));
                    }
                    g.Dispose();
                    ctx.Graphic = oldG;
                    ctx.WorkWithLimits = bOldLimit;
                    ctx.Graphic.DrawImage(m_imageCache, PositionAbsolue.X, PositionAbsolue.Y, ClientSize.Width, ClientSize.Height);


                    /*
                    //Ajuste la matrice pour que le symbole prenne toute la place
                    //dans le rectangle
                    Matrix oldMat = ctx.Graphic.Transform;
                    float fEchelleX = (float)ClientSize.Width / (float)symbole.Size.Width;
                    float fEchelleY = (float)ClientSize.Height / (float)symbole.Size.Height;
                    ctx.Graphic.InterpolationMode = InterpolationMode.HighQualityBilinear;
                    ctx.Graphic.TranslateTransform(Position.X, Position.Y);
                    ctx.Graphic.ScaleTransform(fEchelleX, fEchelleY);
                    
                    symbole.Draw(ctx);
                    ctx.Graphic.Transform = oldMat;

                    if ( ElementDeSchema.IsCableALinterieur )
                    {
                        Icon icon = (System.Drawing.Icon)Resource.ResourceManager.GetObject("Connection");
                        ctx.Graphic.DrawIconUnstretched ( icon, new Rectangle ( Position.X+ClientSize.Width - icon.Width,
                            Position.Y+ClientSize.Height -icon.Height, icon.Width, icon.Height ));
                    }*/
                }
            }
        }
        //----------------------------------------------------
        public CResultAErreur DeleteObjetLie(bool bDansContexteCourant)
        {
            CResultAErreur result= CResultAErreur.True;
            if (ElementDeSchema != null && ElementDeSchema.IsValide())
            {
                result = ElementDeSchema.Delete(bDansContexteCourant);
                return result;
            }
            else
                return CResultAErreur.False;
        }
 


        //---------------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //---------------------------------------------------
        protected override sc2i.common.CResultAErreur MySerialize(sc2i.common.C2iSerializer serializer)
        {

            int nVersion = this.GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion ( ref nVersion );
            if ( !result )
                return result;
            return result;
        }

        //---------------------------------------------------
        public override void RemoveChild(I2iObjetGraphique child)
        {
        }

        //---------------------------------------------------
        public override Point Position
        {
            get
            {
                return base.Position;
            }
            set
            {
                base.Position = value;
                if (ElementDeSchema != null)
                {
                    ElementDeSchema.X = value.X;
                    ElementDeSchema.Y = value.Y;
                }
            }
        }

        public override Size Size
        {
            get
            {
                return base.Size;
            }
            set
            {
                base.Size = value;
                if (ElementDeSchema != null)
                {
                    ElementDeSchema.Width = value.Width;
                    ElementDeSchema.Height = value.Height;
                    
                }
            }
        }

        //---------------------------------------------------
        /// <summary>
        /// Alloue l'objet CDonneeDessin adapté à ce contrôle
        /// </summary>
        /// <returns></returns>
        protected virtual IDonneeDessinElementDeSchemaReseau AlloueDonneeDessin()
        {
            return new CDonneeDessinElementDeSchemaReseau(-1);
        }

        //---------------------------------------------------
        [System.ComponentModel.Browsable(false)]
        public IDonneeDessinElementDeSchemaReseau DonneeDessin
        {
            get
            {
                if (m_donneeDessin == null)
                    m_donneeDessin = AlloueDonneeDessin();
                return m_donneeDessin;
            }
            set
            {
                if (value != null)
                {
                    //Si les données n'ont pas d'id d'objet, conserver l'ancien id
                    if (m_donneeDessin != null && m_donneeDessin.IdObjetDeSchema >= 0 &&
                        value.IdObjetDeSchema < 0)
                        value.IdObjetDeSchema = m_donneeDessin.IdObjetDeSchema;
                    m_donneeDessin = value;
                }
            }

           
        }

        /// ////////////////////////////////////////////////////////
        public static Image GetImage(Type tp)
        {
            try
            {
                //Nom d'image : le nom du type suivi de gif
                string[] strNoms = tp.ToString().Split('.');
                string strNomImage = strNoms[strNoms.Length - 1];


                Image img = (System.Drawing.Image)Resource.ResourceManager.GetObject(strNomImage);
                return img;
            }
            catch { }
            return null;
        }

        /// ////////////////////////////////////////////////////////
        public virtual Point GetCenterPoint()
        {
            Point pt = new Point(PositionAbsolue.X + Size.Width / 2,
                PositionAbsolue.Y + Size.Height / 2);
            return pt;
        }

        /// ////////////////////////////////////////////////////////
        ///Retourne le schéma auquel appartient cet élément
        public virtual CSchemaReseau SchemaContenant
        {
            get
            {
                if ( Parent is C2iObjetDeSchema )
                    return ((C2iObjetDeSchema)Parent).SchemaContenant;
                if ( ElementDeSchema != null )
                    return ElementDeSchema.SchemaReseau;
                return null;
            }
        }

        /// ////////////////////////////////////////////////////////
        public override I2iObjetGraphique GetCloneAMettreDansParent(I2iObjetGraphique parent, Dictionary<Type, object> dicObjetsPourCloner)
        {
            C2iObjetDeSchema objet = (C2iObjetDeSchema)base.GetCloneAMettreDansParent(parent, dicObjetsPourCloner);
            C2iObjetDeSchema parentAsC2iObjet = parent as C2iObjetDeSchema;
            if (ElementDeSchema != null && parentAsC2iObjet != null && parentAsC2iObjet.SchemaContenant != null)
            {
                CElementDeSchemaReseau newElement = new CElementDeSchemaReseau(parentAsC2iObjet.SchemaContenant.ContexteDonnee);
                newElement.CreateNewInCurrentContexte();
                newElement.ElementAssocie = ElementDeSchema.ElementAssocie;
                newElement.SchemaReseau = parentAsC2iObjet.SchemaContenant;
                newElement.Width = Size.Width;
                newElement.Height = Size.Height;
                objet.ElementDeSchema = newElement;
            }
            return objet;
        }

        /// ////////////////////////////////////////////////////////
        public override void CancelClone()
        {
            if (ElementDeSchema != null && ElementDeSchema.IsNew())
            {
                ElementDeSchema.CancelCreate();
                ElementDeSchema = null;
            }
        }

        


    }
}
