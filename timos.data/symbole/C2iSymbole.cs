using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using sc2i.common;
using sc2i.drawing;
using sc2i.formulaire;
using sc2i.expression;
using System.Resources;


namespace timos.data
{
    public enum EDockStyle
    {
        None = 0,
        Top,
        Bottom,
        Left,
        Right,
        Fill
    }

    /// <summary>
    /// Pour voir la classe dans la liste des symboles disponibles
    /// </summary>
    public class VisibleInInterfaceAttribute : Attribute
    {
    }


    [Serializable]
    public class C2iSymbole : C2iObjetGraphique
    {
        public const string c_idFichier = "2I_SYMBOL";
        private IElementASymbolePourDessin m_elementASymbole = null;

        private bool m_bCouleurFondAutomatique = false;
        private Color m_backColor = Color.White;
        private Color m_foreColor = Color.Black;
        private ArrayList m_listeFils = new ArrayList();

        private bool m_bVisible = true;
        

        private int m_nTabOrder = 0;
        private bool m_bAnchorLeft = false;
        private bool m_bAnchorRight = false;
        private bool m_bAnchorTop = false;
        private bool m_bAnchorBottom = false;

        ////Si true, L'élément à symbole ne peut plus être modifié
        private bool m_bLockElementASymbole = false;

       
        public override event EventHandlerChild ChildAdded;
        public override event EventHandlerChild ChildRemoved;

        public EDockStyle m_dockStyle = EDockStyle.None;

        private bool m_bIsDocking = false;

        private Type m_targetType = null;


        private string m_strName = "";

        public C2iSymbole()
            :base()
        {
            Size = new Size(300, 300);
            BackColor = Color.Transparent;
        }

        public string Name
        {
			get
			{
				return m_strName;
			}
			set
			{
				m_strName = value;
			}
		}


       public Type TargetType
       {
           get
           {
               return m_targetType;
           }
           set
           {
               m_targetType = value;
           }
       }


        //Si true, l'élément à symbole ne peut plus être modifié
        [System.ComponentModel.Browsable(false)]
        public bool LockElementASymbole
        {
            get
            {
                return m_bLockElementASymbole;
            }
            set
            {
                m_bLockElementASymbole = value;
            }
        }

        /// ///////////////////////////////////////////////
        public int X
        {
            get
            {
                return Position.X;
            }
            set
            {
                Position = new Point (value, Y);
            }
        }

        /// ///////////////////////////////////////////////
        public int Y
        {
            get
            {
                return Position.Y;
            }
            set
            {
                Position = new Point ( X, value);
            }
        }

        /// ///////////////////////////////////////////////
        public int Width
        {
            get
            {
                return Size.Width;
            }
            set
            {
                Size = new Size ( value, Height );
            }
        }

        /// ///////////////////////////////////////////////
        public int Height
        {
            get
            {
                return Size.Height;
            }
            set
            {
                Size = new Size(Width, value);
            }
        }

        /// ///////////////////////////////////////////////
        public int Transparency
        {
            get
            {
                return (int)Math.Round(100-BackColor.A/2.55,0);
            }
            set
            {
                BackColor = Color.FromArgb((int)((100-value) * 2.55), BackColor.R, BackColor.G, BackColor.B);
            }
        }
      


        /// ///////////////////////////////////////////////
        public virtual bool CouleurFondAutomatique
        {
            get
            {
                return m_bCouleurFondAutomatique;
            }
            set
            {
                m_bCouleurFondAutomatique = value;
            }
        }

        /// ///////////////////////////////////////////////
        public bool Visible
        {
            get
            {
                return m_bVisible;
            }
            set
            {
                m_bVisible = value;
            }
        }

        /// ///////////////////////////////////////////////
        public virtual IElementASymbolePourDessin ElementASymbole
        {
            get
            {
                return m_elementASymbole;
            }
            set
            {
                if (!LockElementASymbole )
                {
                    m_elementASymbole = value;
                    foreach (C2iSymbole symbole in Childs)
                        symbole.ElementASymbole = value;
                }
            }
        }

        /// ///////////////////////////////////////////////
        public int TabOrder
        {
            get
            {
                return m_nTabOrder;
            }
            set
            {
                m_nTabOrder = value;
            }
        }

        

        /// ///////////////////////////////////////////////
        public Color BackColor
        {
            get
            {
                return m_backColor;
            }
            set
            {
                //Propage la couleur de fond à ses fils
                foreach (C2iSymbole fils in m_listeFils)
                    if (fils.BackColor == m_backColor)
                        fils.BackColor = value;
                m_backColor = value;
                if (Parent != null)
                {
                    if (((C2iSymbole)Parent).BackColor == BackColor)
                        CouleurFondAutomatique = true;
                    else
                        CouleurFondAutomatique = false;
                }
            }
        }

        /// ///////////////////////////////////////////////
        public Color ForeColor
        {
            get
            {
                return m_foreColor;
            }
            set
            {
                m_foreColor = value;
            }
        }

        protected bool IsDocking
        {
            get
            {
                return m_bIsDocking;
            }
        }

        /// ///////////////////////////////////////////////
        [System.ComponentModel.Browsable(false)]
        public bool AnchorLeft
        {
            get
            {
                return m_bAnchorLeft;
            }
            set
            {
                m_bAnchorLeft = value;
            }
        }

        /// ///////////////////////////////////////////////
        [System.ComponentModel.Browsable(false)]
        public bool AnchorRight
        {
            get
            {
                return m_bAnchorRight;
            }
            set
            {
                m_bAnchorRight = value;
            }
        }

        /// ///////////////////////////////////////////////
        [System.ComponentModel.Browsable(false)]
        public bool AnchorTop
        {
            get
            {
                return m_bAnchorTop;
            }
            set
            {
                m_bAnchorTop = value;
            }
        }

        /// ///////////////////////////////////////////////
        [System.ComponentModel.Browsable(false)]
        public bool AnchorBottom
        {
            get
            {
                return m_bAnchorBottom;
            }
            set
            {
                m_bAnchorBottom = value;
            }
        }


        /// ///////////////////////////////////////////////
        public EDockStyle DockStyle
        {
            get
            {
                return m_dockStyle;
            }
            set
            {
                EDockStyle oldValue = m_dockStyle;
                m_dockStyle = value;
                if (value != oldValue)
                {
                    if (Parent != null && Parent is C2iSymbole)
                        ((C2iSymbole)Parent).DockChilds();
                }
            }
        }


        /// //////////////////////////////////
        /// <summary>
        /// Dessin de tout le controle et de ses fils
        /// </summary>
        /// <param name="contexte"></param>
        public override void Draw(CContextDessinObjetGraphique ctx)
        {
            if (!m_bVisible)
                return;
            MyDraw(ctx);
            Graphics g = ctx.Graphic;
            Matrix oldMat = g.Transform;
            Matrix matrice = (Matrix)oldMat.Clone();
            Point pt = ClientToGlobal(new Point(0, 0));
            if (Parent != null)
                pt = Parent.GlobalToClient(pt);
            //pt = ClientToGlobal ( pt );
            matrice.Translate(pt.X, pt.Y);
            g.Transform = matrice;
            Region oldClip = g.Clip;
            g.Clip = new Region(new Rectangle(0, 0, ClientSize.Width + 1, ClientSize.Height + 1));
            DrawInterieur(ctx);
            foreach (C2iSymbole fils in Childs)
                fils.Draw(ctx);
            g.Clip = oldClip;
            g.Transform = oldMat;
        }


        public override bool IsPointIn(Point pt)
        {
         
            
            if(typeof(C2iSymboleSelectionMultiple).IsAssignableFrom(this.Parent.GetType()))
                return false;
            else
                return base.IsPointIn(pt);
        }



        public override I2iObjetGraphique[] Childs
        {

            get
            {
                return (I2iObjetGraphique[])m_listeFils.ToArray(typeof(I2iObjetGraphique));
            }
        }

        public override bool AddChild(I2iObjetGraphique child)
        {
            m_listeFils.Add(child);
			if (child is C2iSymbole && ((C2iSymbole)child).CouleurFondAutomatique)
			{
				C2iSymbole wndChild = (C2iSymbole)child;
				wndChild.BackColor = BackColor;
				wndChild.ForeColor = ForeColor;
			}
			if (ChildAdded != null)
				ChildAdded(child);
			DockChilds();
			return true;
        }

        public override bool ContainsChild(I2iObjetGraphique child)
		{
			return m_listeFils.Contains(child);
		}


	
		public override void RemoveChild(I2iObjetGraphique child)
		{
			m_listeFils.Remove(child);
			if (ChildRemoved != null)
				ChildRemoved(child);
			DockChilds();
		}

        /// //////////////////////////////////////////////
        public override Size Size
        {
            get
            {
                return base.Size;
            }
            set
            {
                Size oldValue = Size;
                base.Size = value;
                if (value != oldValue)
                    DockChilds();
                if (!IsDocking && Parent is C2iSymbole)
                    ((C2iSymbole)Parent).DockChilds();
            }
        }

        /// //////////////////////////////////////////////
        public override Point Position
        {
            get
            {
                return base.Position;
            }
            set
            {
                base.Position = value;
                if (!IsDocking && Parent is C2iSymbole && DockStyle != EDockStyle.None)
                    ((C2iSymbole)Parent).DockChilds();

            }
        }

        public override void BringToFront(I2iObjetGraphique child) 
        {
            if (!ContainsChild(child))
                return;
            m_listeFils.Remove(child);
            m_listeFils.Add(child);
            DockChilds();

        }

        public override void FrontToBack(I2iObjetGraphique child)
        {
            if (!ContainsChild(child))
                return;
            m_listeFils.Remove(child);
            m_listeFils.Insert(0, child);
            DockChilds();
        }

        public virtual void DockChilds()
        {
            Rectangle rc = ClientRect;
            foreach (C2iSymbole wnd in Childs)
            {
                if (rc.Height > 2 && rc.Width > 2)
                {
                    wnd.m_bIsDocking = true;
                    switch (wnd.DockStyle)
                    {
                        case EDockStyle.Top:
                            wnd.Size = new Size(rc.Width, wnd.Size.Height);
                            wnd.Position = rc.Location;
                            rc.Offset(0, wnd.Size.Height);
                            rc.Height -= wnd.Size.Height;
                            break;
                        case EDockStyle.Bottom:
                            wnd.Size = new Size(rc.Width, wnd.Size.Height);
                            wnd.Position = new Point(rc.Location.X, rc.Bottom - wnd.Size.Height);
                            rc.Height -= wnd.Size.Height;
                            break;
                        case EDockStyle.Left:
                            wnd.Size = new Size(wnd.Size.Width, rc.Height);
                            wnd.Position = rc.Location;
                            rc.Offset(wnd.Size.Width, 0);
                            rc.Width -= wnd.Size.Width;
                            break;
                        case EDockStyle.Right:
                            wnd.Size = new Size(wnd.Size.Width, rc.Height);
                            wnd.Position = new Point(rc.Right - wnd.Size.Width, rc.Top);
                            rc.Width -= wnd.Size.Width;
                            break;
                        case EDockStyle.Fill:
                            wnd.Size = rc.Size;
                            wnd.Position = rc.Location;
                            break;
                    }
                    wnd.m_bIsDocking = false;
                }
            }
        }


        [System.ComponentModel.Browsable(false)]
        public virtual bool Lock
        {
            get
            {
                return IsLock;
            }
            set
            {
                IsLock = value;
                foreach (C2iSymbole symb in Childs)
                {
                    symb.Lock=value;
                }
            }
        }





        public virtual void SetTargetType(Type tp)
        {
            m_targetType = tp;
            // propage le type sur tous les fils
            foreach (C2iSymbole symb in Childs)
            {
                symb.SetTargetType(tp);
            }
        }

        public virtual Type GetTargetType()
        {
            return m_targetType;
        }




        public virtual void HorizontalFlip()
        {
            int newX;
            int nMilieu = Size.Width / 2;
            for (int i = 0; i < Childs.Length; i++)
            {
                C2iSymbole fils = (C2iSymbole)Childs[i];

                if (fils.Position.X < nMilieu)
                    newX = fils.Position.X + 2 * (nMilieu - fils.Position.X) - fils.Size.Width;

                else
                    newX = fils.Position.X - 2 * (fils.Position.X - nMilieu) - fils.Size.Width;
                fils.Position = new Point(newX, fils.Position.Y);
                fils.HorizontalFlip();
            }
        }

        public virtual void VerticalFlip()
        {
            int newY;
            int nMilieu = Size.Height / 2;
            for (int i = 0; i < Childs.Length; i++)
            {

                C2iSymbole fils = (C2iSymbole)Childs[i];

                if (fils.Position.Y < nMilieu)
                    newY = fils.Position.Y + 2 * (nMilieu - fils.Position.Y) - fils.Size.Height;

                else
                    newY = fils.Position.Y - 2 * (fils.Position.Y - nMilieu) - fils.Size.Height;
                fils.Position = new Point(fils.Position.X, newY);
                fils.VerticalFlip();
            }
        }


        /// //////////////////////////////////////////////
        private int GetNumVersion()
        {
            return 4;
            //Ajout de LockElementASymbole
            //4 : ajout de m_bVisible
         
        }
   
        public override CResultAErreur Serialize(C2iSerializer serializer)
        {
           
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
         
            result = base.Serialize(serializer);
            
            if (!result)
                return result;
            
                 result = serializer.TraiteArrayListOf2iSerializable(m_listeFils);
            if (!result)
                return result;
            foreach (C2iSymbole  wnd in m_listeFils)
                wnd.Parent = this;

            serializer.TraiteString(ref m_strName);

                serializer.TraiteBool(ref m_bAnchorBottom);
                serializer.TraiteBool(ref m_bAnchorLeft);
                serializer.TraiteBool(ref m_bAnchorRight);
                serializer.TraiteBool(ref m_bAnchorTop);

                int nTmp = (int)DockStyle;
                serializer.TraiteInt(ref nTmp);
                DockStyle = (EDockStyle)nTmp;
                DockChilds();


                nTmp = m_backColor.ToArgb();
                serializer.TraiteInt(ref nTmp);
                m_backColor = Color.FromArgb(nTmp);

                nTmp = m_foreColor.ToArgb();
                serializer.TraiteInt(ref nTmp);
                m_foreColor = Color.FromArgb(nTmp);


                if (nVersion >= 1)
                    serializer.TraiteInt(ref m_nTabOrder);
                if (nVersion >= 2)
                    serializer.TraiteBool(ref m_bCouleurFondAutomatique);


                if (nVersion >= 2)
                {
                    bool bHasType = m_targetType != null;
                    serializer.TraiteBool(ref bHasType);
                    if (bHasType)
                        serializer.TraiteType(ref m_targetType);
                }
                else
                    m_targetType = null;

                if (nVersion >= 3)
                    serializer.TraiteBool(ref m_bLockElementASymbole);

                if (nVersion >= 4)
                    serializer.TraiteBool(ref m_bVisible);


                return CResultAErreur.True;
        }

        public IEnumerable<string> GetNameAndChildsNames()
        {
            List<string> lstNames = new List<string>();
            GetNameAndChildsNames ( lstNames );
            return lstNames;
        }

        protected void GetNameAndChildsNames(List<string> lstNames)
        {
            if (m_strName != "")
                lstNames.Add(m_strName);
            foreach (C2iSymbole symbole in Childs)
            {
                symbole.GetNameAndChildsNames(lstNames);
            }
        }


        public C2iSymbole GetChildFromName(string strName)
        {
            if (strName.ToUpper() == m_strName.ToUpper())
                return this;
            foreach (C2iSymbole child in Childs)
            {
                C2iSymbole retour = child.GetChildFromName(strName);
                if (retour != null)
                    return retour;
            }
            return null;
        }


        protected override CResultAErreur MySerialize(C2iSerializer serializer)
        {
            return CResultAErreur.True;
        }

        protected override void MyDraw(CContextDessinObjetGraphique ctx)
        {
           /*if (BackColor != Color.Transparent)
            {
                Brush br = new SolidBrush(BackColor);
                ctx.Graphic.FillRectangle(br, new Rectangle(Position.X, Position.Y, Size.Width, Size.Height));
                br.Dispose();
            }*/
        }

        public virtual void DrawInterieur(CContextDessinObjetGraphique ctx)
        {
        }



        public  void OnDesignSelect(
            Type typeEdite,
            IFournisseurProprietesDynamiques fournisseurProprietes)
        {
            CProprieteExpressionEditor.ObjetPourSousProprietes = new CObjetPourSousProprietes(typeEdite);
            CProprieteExpressionEditor.FournisseurProprietes = fournisseurProprietes;
        }

        public C2iSymbole GetCloneSymbole()
        {
            return CCloner2iSerializable.Clone(this) as C2iSymbole;
        }

        /// ////////////////////////////////////////////////////////
		public static Image GetImage(Type tp)
		{
			try
			{
				//Nom d'image : le nom du type suivi de gif
				string[] strNoms = tp.ToString().Split('.');
                string strNomImage = strNoms[strNoms.Length - 1] ;


                Image img = (System.Drawing.Image)Resource.ResourceManager.GetObject(strNomImage); 
				return img;
			}
			catch { }
			return null;
		}

        /// ////////////////////////////////////////////////////////
        public IEnumerable<CDefinitionProprieteDynamique> GetChampsUtilises()
        {
            HashSet<CDefinitionProprieteDynamique> defs = new HashSet<CDefinitionProprieteDynamique>();
            FillListeProprietesUtilisees(defs);
            return defs.ToArray();
        }

        /// ////////////////////////////////////////////////////////
        protected virtual void FillListeProprietesUtilisees(HashSet<CDefinitionProprieteDynamique> defs)
        {
            foreach (I2iObjetGraphique objet in Childs)
            {
                C2iSymbole symboleFils = objet as C2iSymbole;
                if (symboleFils != null)
                    symboleFils.FillListeProprietesUtilisees(defs);
            }
        }


                
    }
}
