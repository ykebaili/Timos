using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using System.Drawing;
using sc2i.drawing;
using System.ComponentModel;
using sc2i.expression;
using System.Collections;
using System.Reflection;

namespace timos.data.composantphysique
{
    public enum E3DDockStyle
    {
        None = 0,
        Left,
        Right,
        Bottom,
        Top,
        Front,
        Back,
        Fill
    }

    public enum E3DRotation
    {
        Rotate0 = 0,
        Rotate90 = 90,
        Rotate180 = 180,
        Rotate270 = 270
    }

    [Serializable]
    public abstract class C2iComposant3D : I2iSerializable
    {
        public static string c_idFichier = "3DCOMPONOENT";

        public static C3DSize[] m_NormalesFace = new C3DSize[]{
            new C3DSize(0, 0,1),
            new C3DSize(-1,0,0),
            new C3DSize(0,1,0),
            new C3DSize(0,0,-1),
            new C3DSize(1,0,0),
            new C3DSize(0,-1,0)};

        private C3DPoint m_position = new C3DPoint(0, 0, 0);
        private C3DSize m_size = new C3DSize(50000, 50000, 50000);

        private CEmplacementDansParent m_emplacementDansParent = null;

        private Color m_backColor = Color.White;
        private Color m_foreColor = Color.Black;

        private List<C2iComposant3D> m_listeFils = new List<C2iComposant3D>();

        private E3DRotation m_rotationY = E3DRotation.Rotate0;
        private E3DRotation m_rotationX = E3DRotation.Rotate0;
        private E3DRotation m_rotationZ = E3DRotation.Rotate0;

        private bool m_bLockChilds = false;

        private bool m_bSelectAtRunTime = true;
        private bool m_bAcceptChildAtRunTime = true;



        private string m_strName = "";

        private C2iComposant3D m_parent = null;

        private bool m_bIsModeRuntime = false;

        /// <summary>
        /// Formules dynamiques
        /// </summary>
        private Dictionary<string, C2iExpression> m_dicFormulesParPropriete = new Dictionary<string, C2iExpression>();

        //------------------------------------
        public C2iComposant3D()
        {
        }

        //--------------------------------------
        public C2iComposant3D Parent
        {
            get
            {
                return m_parent;
            }
            set
            {
                if (value != m_parent)
                {
                    if ( m_parent != null )
                        m_parent.RemoveFils(value);
                    if ( value != null )
                        value.AddFils(this);
                }
            }   
        }

        ///--------------------------------------
        public E3DRotation YRotation
        {
            get
            {
                return m_rotationY;
            }
            set
            {
                m_rotationY = value;
            }
        }
        
        //--------------------------------------
        public E3DRotation XRotation
        {
            get
            {
                return m_rotationX;
            }
            set
            {
                m_rotationX = value;
            }
        }

        //--------------------------------------
        public E3DRotation ZRotation
        {
            get
            {
                return m_rotationZ;
            }
            set
            {
                m_rotationZ = value;
            }
        }

        //--------------------------------------
        public bool LockChilds
        {
            get
            {
                return m_bLockChilds;
            }
            set
            {
                m_bLockChilds = value;
            }
        }

        //--------------------------------------
        [Category("Runtime")]
        public bool CanSelectAtRuntime
        {
            get
            {
                return m_bSelectAtRunTime;
            }
            set
            {
                m_bSelectAtRunTime = value;
            }
        }

        //--------------------------------------
        [Category("Runtime")]
        public bool AcceptChildsAtRuntime
        {
            get
            {
                return m_bAcceptChildAtRunTime;
            }
            set
            {
                m_bAcceptChildAtRunTime = value;
            }
        }

        //-----------------------------------------------------
        /// <summary>
        /// Indique si on travaille en mode runtime
        /// </summary>
        [Browsable(false)]
        public bool IsModeRuntime
        {
            get
            {
                return m_bIsModeRuntime;
            }

            set
            {
                m_bIsModeRuntime = value;
                foreach (C2iComposant3D fils in Childs)
                    fils.IsModeRuntime = value;
            }
        }

        //--------------------------------------
        public virtual bool AcceptChilds
        {
            get
            {
                return false;
            }
        }

        //--------------------------------------
        public bool AddFils(C2iComposant3D fils)
        {
            if (fils == this)
                return false;
            fils.m_parent = this;
            if (fils.LocationInParent != null)
                fils.LocationInParent.ComposantAssocie = fils;
            if (!m_listeFils.Contains(fils))
            {
                m_listeFils.Add(fils);
                CEmplacementDansParent newPlace = GetNewEmplacementForChild(fils);
                newPlace.ComposantAssocie = fils;
                if (fils.LocationInParent == null || fils.LocationInParent.GetType() != newPlace.GetType())
                    fils.LocationInParent = newPlace;
                RepositionneChilds();
                return true;
            }
            
            return false;
        }

        //--------------------------------------
        public IEnumerable<C2iComposant3D> AllChilds()
        {
            List<C2iComposant3D> lst = new List<C2iComposant3D>();
            GetChildsInList ( lst );
            return lst.AsReadOnly();
        }

        //--------------------------------------
        public void BringToFront ( C2iComposant3D composant )
        {
            if ( m_listeFils.Contains ( composant ))
            {
                m_listeFils.Remove ( composant );
                AddFils ( composant );
            }
        }

        //--------------------------------------
        public void FrontToBack(C2iComposant3D composant)
        {
            if (m_listeFils.Contains(composant))
            {
                m_listeFils.Remove(composant);
                m_listeFils.Insert(0, composant);
                RepositionneChilds();
            }
        }

            

        //--------------------------------------
        protected void GetChildsInList ( List<C2iComposant3D> lst )
        {
            foreach (C2iComposant3D fils in Childs)
            {
                lst.Add(fils);
                fils.GetChildsInList(lst);
            }
        }

             

        //--------------------------------------
        public void RemoveFils(C2iComposant3D fils)
        {
            if (m_listeFils.Contains(fils))
            {
                m_listeFils.Remove(fils);
                fils.m_parent = null;
            }
        }

        //--------------------------------------
        public IEnumerable<C2iComposant3D> Childs
        {
            get
            {
                return m_listeFils.AsReadOnly();
            }
        }

        //--------------------------------------
        public virtual C3DPoint Position
        {
            get
            {
                return m_position;
            }
            set
            {
                m_position = value;
                if (Parent != null)
                    Parent.RepositionneChilds();
            }
        }

        //--------------------------------------
        protected int GetCentMmFromMm(double fVal)
        {
            return (int)(fVal * 100.0);
        }

        //--------------------------------------
        protected double GetMmFromCentMm(int nVal)
        {
            return ((double)nVal) / 100.0;
        }
        //--------------------------------------
        [Category("Position")]
        public double Xmm
        {
            get
            {
                return GetMmFromCentMm(Position.X);
            }
            set
            {
                Position = new C3DPoint(GetCentMmFromMm(value), Position.Y, Position.Z);
            }
        }

        //--------------------------------------
        [Category("Position")]
        public double Ymm
        {
            get
            {
                return GetMmFromCentMm(Position.Y);
            }
            set
            {
                Position = new C3DPoint(Position.X, GetCentMmFromMm(value), Position.Z);
            }
        }

        //--------------------------------------
        [Category("Position")]
        public double Zmm
        {
            get
            {
                return GetMmFromCentMm(Position.Z);
            }
            set
            {
                Position = new C3DPoint(Position.X, Position.Y, GetCentMmFromMm(value));
            }
        }

        //--------------------------------------
        [Category("Position")]
        [CanBeDynamic]
        public double Widthmm
        {
            get
            {
                return GetMmFromCentMm(Size.With);
            }
            set
            {
                Size = new C3DSize(GetCentMmFromMm(value), Size.Height, Size.Depth);
            }
        }

        //--------------------------------------
        [Category("Position")]
        [CanBeDynamic]
        public double Heightmm
        {
            get
            {
                return GetMmFromCentMm(Size.Height);
            }
            set
            {
                Size = new C3DSize(Size.With, GetCentMmFromMm(value), Size.Depth);
            }
        }

        //--------------------------------------
        [Category("Position")]
        [CanBeDynamic]
        public double Depthmm
        {
            get
            {
                return GetMmFromCentMm(Size.Depth);
            }
            set
            {
                Size = new C3DSize(Size.With, Size.Height, GetCentMmFromMm(value));
            }
        }

        //--------------------------------------
        public virtual C3DPoint PositionAbsolue
        {
            get
            {
                if ( Parent != null )
                    return Parent.ClientToGlobal ( Position );
                return Position;
            }
        }

        //--------------------------------------
        public virtual C3DSize SizeAbsolue
        {
            get
            {
                CTransformation3D t = CTransformation3D.Identity;
                PushTransformationChildToGlobal(t);
                return t.Transforme(Size);
                /*
                if (Parent != null)
                    return Parent.ClientToGlobal(Size);
                return Size;*/
            }
            set
            {
                CTransformation3D t = CTransformation3D.Identity;
                PushTransformationGlobalToChild(t);
                Size = t.Transforme(value);
                
            }
        }

        //--------------------------------------
        public virtual C3DPoint OrigineCliente
        {
            get
            {
                return new C3DPoint ( 0, 0, 0);
            }
        }

        //--------------------------------------
        public C3DPoint ClientToGlobal ( C3DPoint pt )
        {
            CTransformation3D t = CTransformation3D.Identity;
            PushTransformationChildToGlobal(t);
            return t.Transforme(pt);
        }/*
            C3DPoint newPt = pt;
            newPt.Offset(OrigineCliente.X, OrigineCliente.Y, OrigineCliente.Z);
            newPt.Offset(Position.X, Position.Y, Position.Z);
            if (Parent != null)
                return Parent.ClientToGlobal(newPt);
            else
                return newPt;
        }*/

        //--------------------------------------
        public C3DPoint GlobalToClient(C3DPoint pt)
        {
            CTransformation3D t = CTransformation3D.Identity;
            PushTransformationGlobalToChild(t);
            return t.Transforme(pt);
        }

        //--------------------------------------
        public C3DSize ClientToGlobal(C3DSize size)
        {
            CTransformation3D t = CTransformation3D.Identity;
            PushTransformationChildToGlobal(t);
            return t.Transforme(size);
        }

        //--------------------------------------
        public C3DSize GlobalToClient(C3DSize size)
        {
            CTransformation3D t = CTransformation3D.Identity;
            PushTransformationGlobalToChild(t);
            return t.Transforme(size);
        }
    

        //--------------------------------------
        public virtual C3DSize Size
        {
            get
            {
                return m_size;
            }
            set
            {
                m_size = value;
                RepositionneChilds();
                if (Parent != null)
                    Parent.RepositionneChilds();
            }
        }

        //--------------------------------------
        private bool m_bIsRepositionning = false;
        public void RepositionneChilds()
        {
            if (m_bIsRepositionning)
                return;
            m_bIsRepositionning = true;
            try
            {
                MyRepositionneChilds();
            }
            catch
            {
            }
            m_bIsRepositionning = false;
        }

        //--------------------------------------
        protected virtual void MyRepositionneChilds()
        {
        }

        //--------------------------------------
        public virtual C3DSize ClientSize
        {
            get
            {
                return m_size;
            }
        }

        //--------------------------------------
        public virtual C3DPoint Offset
        {
            get
            {
                return new C3DPoint ( 0, 0, 0 );
            }
        }

        //--------------------------------------
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
       

        

        //--------------------------------------
        [CanBeDynamic]
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

        //--------------------------------------
        [CanBeDynamic]
        public Color BackColor
        {
            get
            {
                return m_backColor;
            }
            set
            {
                m_backColor = Color.FromArgb(
                    (int)((100.0 - (double)Transparency) * 2.55),
                    value);
            }
        }

        

        //--------------------------------------
        public int Transparency
        {
            get
            {
                return (int)((255.0 - (double)BackColor.A) / 2.55);
            }
            set
            {
                Color c = m_backColor;
                int nTrans = (int)((100.0 - (double)value) * 2.55);
                if ( nTrans > 253 )
                    nTrans = 255;
                if ( nTrans < 2 )
                    nTrans = 0;
                m_backColor = Color.FromArgb(nTrans, 
                    m_backColor );
            }
        }

        //--------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //--------------------------------------
        public virtual CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;

            result = serializer.TraiteObject<C3DPoint>(ref m_position);
            if (result)
                result = serializer.TraiteObject<C3DSize>(ref m_size);
            if (!result)
                return result;

            serializer.TraiteString(ref m_strName);

            result = serializer.TraiteObject<CEmplacementDansParent>(ref m_emplacementDansParent, new object[]{this});

            int nTmp = BackColor.ToArgb();
            serializer.TraiteInt(ref nTmp);
            m_backColor = Color.FromArgb(nTmp);

            nTmp = ForeColor.ToArgb();
            serializer.TraiteInt(ref nTmp);
            ForeColor = Color.FromArgb(nTmp);

            nTmp = (int)m_rotationX;
            serializer.TraiteInt(ref nTmp);
            m_rotationX = (E3DRotation)nTmp;

            nTmp = (int)m_rotationY;
            serializer.TraiteInt(ref nTmp);
            m_rotationY = (E3DRotation)nTmp;

            nTmp = (int)m_rotationZ;
            serializer.TraiteInt(ref nTmp);
            m_rotationZ = (E3DRotation)nTmp;

            serializer.TraiteBool(ref m_bLockChilds);

            result = serializer.TraiteListe<C2iComposant3D>(m_listeFils);
            if (!result)
                return result;
            if (serializer.Mode == ModeSerialisation.Lecture)
                foreach (C2iComposant3D fils in m_listeFils)
                    fils.Parent = this;

            //Nettoie les formules à null;
            foreach (KeyValuePair<string, C2iExpression> kv in new ArrayList(m_dicFormulesParPropriete))
            {
                if (kv.Value == null)
                    m_dicFormulesParPropriete.Remove(kv.Key);
            }
            int nNbFormules = m_dicFormulesParPropriete.Count;
            serializer.TraiteInt(ref nNbFormules);
            switch (serializer.Mode)
            {
                case ModeSerialisation.Ecriture:
                    foreach (KeyValuePair<string, C2iExpression> kv in m_dicFormulesParPropriete)
                    {
                        string strVal = kv.Key;
                        C2iExpression formule = kv.Value;
                        serializer.TraiteString(ref strVal);
                        result = serializer.TraiteObject<C2iExpression>(ref formule);
                        if (!result)
                            return result;
                    }
                    break;
                case ModeSerialisation.Lecture:
                    m_dicFormulesParPropriete.Clear();
                    for (int nFormule = 0; nFormule < nNbFormules; nFormule++)
                    {
                        string strProp = "";
                        C2iExpression formule = null;
                        serializer.TraiteString(ref strProp);
                        result = serializer.TraiteObject<C2iExpression>(ref formule);
                        if (!result)
                            return result;
                        m_dicFormulesParPropriete[strProp] = formule;
                    }
                    break;
            }

            serializer.TraiteBool(ref m_bAcceptChildAtRunTime);
            serializer.TraiteBool(ref m_bSelectAtRunTime);

            return result;
        }

        

        //-----------------------------------------------------
        public virtual I2iObjetGraphique Get2D(EFaceVueDynamique face)
        {
            return new C2i3DEn2D(this, face);
        }

        //-----------------------------------------------------
        public virtual IEnumerable<I3DPrimitive> Get3DPrimitives()
        {
            List<I3DPrimitive> lst = new List<I3DPrimitive>();
            AddPrimitivesToListe ( lst );
            return lst.AsReadOnly();
        }

        //-----------------------------------------------------
        protected virtual void AddPrimitivesToListe(List<I3DPrimitive> lst)
        {
            foreach (C2iComposant3D composant in Childs)
            {
                composant.AddPrimitivesToListe(lst);
            }
        }

        //-----------------------------------------------------
        public abstract void Draw2D(
            CContextDessinObjetGraphique contexte, 
            EFaceVueDynamique faceVisible,
            Size sizeReference);

        //-----------------------------------------------------
        public int GetPointForSort2D(EFaceVueDynamique face)
        {
            switch (face)
            {
                case EFaceVueDynamique.Front:
                    return PositionAbsolue.Z + Size.Depth;
                case EFaceVueDynamique.Left:
                    return -PositionAbsolue.X;
                case EFaceVueDynamique.Top:
                    return PositionAbsolue.Y + Size.Height;

                case EFaceVueDynamique.Rear:
                    return PositionAbsolue.Z;
                case EFaceVueDynamique.Right:
                    return Position.X + Size.With;
                case EFaceVueDynamique.Bottom:
                    return PositionAbsolue.Y;
            }
            return PositionAbsolue.Z;
        }
        
        
        //-----------------------------------------------------
        public virtual IEnumerable<C2iComposant3D> SortChildsFor2D(EFaceVueDynamique face)
        {
            List<C2iComposant3D> lstFils = new List<C2iComposant3D>(m_listeFils);
            lstFils.Sort(delegate(C2iComposant3D a, C2iComposant3D b) { return a.GetPointForSort2D(face).CompareTo(b.GetPointForSort2D(face)); });
            return lstFils.AsReadOnly();
        }

        //-----------------------------------------------------
        public virtual CEmplacementDansParent GetNewEmplacementForChild( C2iComposant3D composantFils)
        {
            return null;
        }

        //-----------------------------------------------------
        public EFaceVueDynamique ConvertFaceToLocal ( EFaceVueDynamique face )
        {
            C3DSize vecteur = m_NormalesFace[(int)face];
            CTransformation3D t = CTransformation3D.Identity;
            PushTransformationGlobalToChild ( t );
            vecteur = t.Transforme ( vecteur );
            foreach ( EFaceVueDynamique faceTest in Enum.GetValues ( typeof(EFaceVueDynamique) ) )
            {
                if ( m_NormalesFace[(int)faceTest].Equals(vecteur) )
                    return faceTest;
            }
            return face;
        }

        //-----------------------------------------------------
        public EFaceVueDynamique ConvertFaceToGlobal(EFaceVueDynamique face)
        {
            C3DSize vecteur = m_NormalesFace[(int)face];
            CTransformation3D t = CTransformation3D.Identity;
            PushTransformationChildToGlobal(t);
            vecteur = t.Transforme(vecteur);
            foreach (EFaceVueDynamique faceTest in Enum.GetValues(typeof(EFaceVueDynamique)))
            {
                if (m_NormalesFace[(int)faceTest].Equals(vecteur))
                    return faceTest;
            }
            return face;
        }

        //-----------------------------------------------------
        public virtual CEmplacementDansParent LocationInParent
        {
            get
            {
                return m_emplacementDansParent;
            }
            set
            {
                m_emplacementDansParent = value;
            }
        }

        //-----------------------------------------------------
        public void PushTransformationChildToGlobal( CTransformation3D t)
        {
            if ( Parent != null )
                Parent.PushTransformationChildToGlobal(t);
            t.PushTranslation(Position.X, Position.Y, Position.Z);
            t.PushTranslation(Offset.X, Offset.Y, Offset.Z);
            t.PushRotation((int)m_rotationX, 0, 0);
            t.PushRotation(0, (int)m_rotationY, 0);
            t.PushRotation(0, 0, (int)m_rotationZ);
        }

        //-----------------------------------------------------
        public void PushTransformationGlobalToChild(CTransformation3D t)
        {
            t.PushRotation(0, 0, -(int)m_rotationZ);
            t.PushRotation(0, -(int)m_rotationY, 0);
            t.PushRotation(-(int)m_rotationX, 0, 0);
            t.PushTranslation(-Offset.X, -Offset.Y, -Offset.Z);
            t.PushTranslation(-Position.X, -Position.Y, -Position.Z);
            if (Parent != null)
                Parent.PushTransformationGlobalToChild(t);
        }

        //---------------------------------------
        public void SetFormule(string strPropriete, C2iExpression formule)
        {
            m_dicFormulesParPropriete[strPropriete] = formule;
        }

        //---------------------------------------
        public C2iExpression GetFormule(string strPropriete)
        {
            C2iExpression formule = null;
            m_dicFormulesParPropriete.TryGetValue(strPropriete, out formule);
            return formule;
        }

        //---------------------------------------
        public void SetElementToEvalFormules(object element)
        {
            if (m_dicFormulesParPropriete.Count > 0)
            {
                CContexteEvaluationExpression ctx = new CContexteEvaluationExpression(element);
                foreach (KeyValuePair<string, C2iExpression> propFormule in m_dicFormulesParPropriete)
                {
                    string strProp = propFormule.Key;
                    C2iExpression exp = propFormule.Value;
                    CResultAErreur result = exp.Eval(ctx);
                    if (result)
                    {
                        try
                        {
                            PropertyInfo info = GetType().GetProperty(strProp);
                            if (info != null && info.GetSetMethod() != null)
                                info.GetSetMethod().Invoke(this, new object[] { result.Data });
                        }
                        catch
                        {
                        }
                    }
                }
            }
            foreach (C2iComposant3D composant in Childs)
                composant.SetElementToEvalFormules(element);
        }

        //---------------------------------------
        public virtual bool PlaceFilsACoordonnées(IObjetACoordonnees fils)
        {
            IObjetAFilsACoordonnees parent = fils.ConteneurFilsACoordonnees;
            if (parent == null)
                return false;
            CParametrageSystemeCoordonnees paramCoord = parent.ParametrageCoordonneesApplique;
            if (paramCoord == null)
                return false;
            CNiveauCoordonnee[] niveaux = paramCoord.DecodeCoordonnee(fils.Coordonnee);
            return PlaceFilsACoordonnées(fils, niveaux);
        }

        //---------------------------------------
        private bool PlaceFilsACoordonnées ( IObjetACoordonnees fils, CNiveauCoordonnee[] niveaux )
        {
            if (niveaux == null || niveaux.Length == 0)
                return false;
            C2iComposant3D composant = fils.GetComposantPhysique();
            if (composant == null)
                return false;
            IEnumerable<IComposantPourObjetACoordonnées> lstPossibles = GetTousLesFilsPourElementsACoordonnées(niveaux[0].Prefixe);
            if (lstPossibles.Count() > 0)
            {
                IComposantPourObjetACoordonnées composantParent = lstPossibles.ElementAt(0);
                if (niveaux.Length == 1)
                    return composantParent.AddFilsWithIndex(composant, niveaux[0].Index);
                else
                {
                    List<CNiveauCoordonnee> lst = new List<CNiveauCoordonnee>(niveaux);
                    lst.RemoveAt(0);
                    return composant.PlaceFilsACoordonnées(fils, lst.ToArray());
                }
            }
            return false;   
        }

        //---------------------------------------
        protected IEnumerable<IComposantPourObjetACoordonnées> GetTousLesFilsPourElementsACoordonnées( string strPrefixe)
        {
            List<IComposantPourObjetACoordonnées> lst = new List<IComposantPourObjetACoordonnées>();
            FillListeFilsPourElementsACoordonnées(lst, strPrefixe);
            return lst.AsReadOnly();
        }

        //---------------------------------------
        protected void FillListeFilsPourElementsACoordonnées(List<IComposantPourObjetACoordonnées> lst, string strPrefixe)
        {
            foreach (C2iComposant3D fils in Childs)
            {
                IComposantPourObjetACoordonnées cp = fils as IComposantPourObjetACoordonnées;
                if (cp != null && (cp.PrefixesCoordonneeAssocies.Count() == 0 || cp.PrefixesCoordonneeAssocies.Contains ( strPrefixe )))
                    lst.Add(cp);
                fils.FillListeFilsPourElementsACoordonnées(lst, strPrefixe);
            }
        }
    }
}
