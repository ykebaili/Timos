using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using timos.data;
using sc2i.win32.common;
using sc2i.drawing;
using System.Drawing.Drawing2D;
using sc2i.win32.data.navigation;
using sc2i.win32.navigation;
using sc2i.data;
using sc2i.common;
using sc2i.win32.data;
using timos.data.supervision.vueanimee;
using futurocom.supervision;
using timos.data.supervision;
using sc2i.common.memorydb;
using timos.data.snmp;
using System.Threading;
using sc2i.data.dynamic;

namespace timos.supervision.vueanimee
{
    /// <summary>
    /// Permet de superviser un schéma réseau
    /// </summary>
    public partial class CControlSchemaSupervise : UserControl
    {
        private CFormNavigateur m_navigateur = null;
        private CSchemaReseau m_schemaReseau = null;
        private C2iSchemaReseau m_dessinDeSchema = null;
        private Bitmap m_bitmapDessin = null;

        private const int c_nProgressHeight = 15;

        private bool m_bModeChargement = true;

        private CBasePourVueAnimee m_baseVue = null;

        private C2iObjetDeSchema m_objetDeSchemaSelectionne = null;

        //Liste des schémas de réseau ouverts
        Stack<CSchemaReseau> m_stackCheminsReseau = new Stack<CSchemaReseau>();

        private double m_fEchelle = 1;

        private bool m_bHasSnmpEntities = false;

        private DateTime? m_lastSnmpUpdate = null;

        //--------------------------------------------------------------------
        public CControlSchemaSupervise()
        {
            InitializeComponent();
            this.SetStyle(
           ControlStyles.UserPaint |
           ControlStyles.AllPaintingInWmPaint |
           ControlStyles.DoubleBuffer, true);
            m_progress.SetInfo(I.T("Updating SNMP data|20477"));

        }

        //--------------------------------------------------------------------
        private int m_nNbElementsToLoad = 0;
        private int m_nNbElementsLoaded = 0;
        public void Init(CSchemaReseau schemaReseau, CBasePourVueAnimee basePourVue, CFormNavigateur navigateur)
        {
            m_baseVue = basePourVue;
            m_baseVue.RefreshVueSupervision = new RefreshVueSupervisionDelegate(RefreshVueSupervision);
            m_baseVue.AfterLoadElement = new CBasePourVueAnimee.AfterLoadElementDelegate ( AfterLoadElement );
            m_navigateur = navigateur;
            m_schemaReseau = schemaReseau;
            m_nNbElementsToLoad = m_schemaReseau.ElementsDeSchema.Count;
            m_stackCheminsReseau.Clear();
            m_stackCheminsReseau.Push ( m_schemaReseau );
            if ( schemaReseau == null )
            {
                m_dessinDeSchema = null;
                return;
            }
            UpdateTraitementSNMP();

            m_dessinDeSchema = schemaReseau.GetSchema(false);
            RedrawSchema();
            SnmpUpdate();
            
        }

        private void UpdateTraitementSNMP()
        {
            UpdateDateSNMP();
            CSchemaReseau schema = m_stackCheminsReseau.Peek();
            foreach (CElementDeSchemaReseau elt in schema.ElementsDeSchema)
            {
                if (elt.ElementAssocie is CEntiteSnmp)
                {
                    m_bHasSnmpEntities = true;
                    break;
                }
            }
            m_timerSnmp.Interval = schema.DelaiUpdateSnmpSecondes * 1000;
        }


        //--------------------------------------------------------------------
        private void UpdateDateSNMP()
        {
            DateTime ? dtOld = null;
            CSchemaReseau schema = m_stackCheminsReseau.Peek();
            CListeCouplesEntiteChamp couples = schema.GetListeValeursSnmpAffichees();
            foreach ( CCoupleEntiteSnmp_Champ couple in couples )
            {
                CRelationEntiteSnmp_ChampCustom rel = CUtilElementAChamps.GetRelationToChamp( couple.Entite, couple.ChampCustom.Id ) as CRelationEntiteSnmp_ChampCustom;
                if ( rel != null && rel.DateSynchroSnmp != null)
                {
                    if ( dtOld == null || rel.DateSynchroSnmp.DateTimeValue < dtOld.Value )
                        dtOld = rel.DateSynchroSnmp.DateTimeValue;
                }
            }
            m_bHasSnmpEntities = couples.Count > 0;
            m_panelSNMP.Visible = m_bHasSnmpEntities;
            m_lastSnmpUpdate = dtOld;
            UpdateLabelSnmpUpdate();
        }

        //--------------------------------------------------------------------
        private void UpdateLabelSnmpUpdate()
        {
            m_lblLastSNMPUpdate.Text = I.T("Last snmp update : @1|20478",
                m_lastSnmpUpdate == null ? "-" : m_lastSnmpUpdate.Value.ToString("G"));
        }

        //--------------------------------------------------------------------
        public int NiveauMasquageMaxAffiche
        {
            get
            {
                return m_baseVue.NiveauMasquageMaxAffiche;
            }
            set
            {
                m_baseVue.NiveauMasquageMaxAffiche = value;
                RedrawSchema();
            }
        }

        //--------------------------------------------------------------------
        public void AfterLoadElement(int nIdElement)
        {
            if (m_schemaReseau != null)
            {
                CListeObjetsDonnees lst = m_schemaReseau.ElementsDeSchema;
                lst.Filtre = new CFiltreData(CElementDeSchemaReseau.c_champId + "=@1", nIdElement);
                if (nIdElement != null)
                {
                    m_nNbElementsLoaded++;
                    UpdateProgress();
                }
            }
        }

        //--------------------------------------------------------------------
        public void UpdateProgress()
        {
            if ( m_nNbElementsToLoad != 0 )
            {
            double fPas = (double)ClientSize.Width / (double)m_nNbElementsToLoad;
            Invalidate(new Rectangle((int)fPas*(m_nNbElementsLoaded-1), 0, (int)fPas, c_nProgressHeight), true);
            }
        }

        //--------------------------------------------------------------------
        private void RefreshVueSupervision(List<int> lstIdElements)
        {
            if (lstIdElements == null)
                Invalidate(null, true);
            else
            {
                if (m_stackCheminsReseau.Peek() != null)
                {
                    CSchemaReseau schema = m_stackCheminsReseau.Peek();
                    CListeObjetsDonnees lstElements = schema.ElementsDeSchema;
                    foreach (int nId in lstIdElements)
                    {
                        lstElements.Filtre =new CFiltreData(CElementDeSchemaReseau.c_champId + "=@1", nId);
                        lstElements.InterditLectureInDB = true;
                        if (lstElements.Count != 0)
                        {
                            CElementDeSchemaReseau elt = lstElements[0] as CElementDeSchemaReseau;
                            if (elt != null)
                            {
                                Rectangle rct = new Rectangle(
                                    GetScreenPoint(new Point ( elt.X-15, elt.Y-15), true),
                                    GetScreenSize(new Size ( elt.Width+30, elt.Height+30) ) );
                                Invalidate(rct, true);
                            }
                        }
                    }
                }
            }
        }

        //--------------------------------------------------------------------
        public void SetChargementTermine()
        {
            m_bModeChargement = false;
            Refresh();
        }

        //--------------------------------------------------------------------
        public void RedrawSchema()
        {
            if ( m_dessinDeSchema != null )
                m_dessinDeSchema.ClearDrawingCache();
            Size sz = GetLogicalSize(ClientSize);


            AutoScrollMinSize = new Size(m_dessinDeSchema.Size.Width - sz.Width,
                m_dessinDeSchema.Size.Height - sz.Height);
            Invalidate ( null , true);
            /*
            if (m_dessinDeSchema == null)
                return;
            if (m_bitmapDessin != null)
                m_bitmapDessin.Dispose();
            m_bitmapDessin = null;
            
            Refresh();*/
        }

        //--------------------------------------------------------------------
        private void SetSelection ( C2iObjetDeSchema objet )
        {
            if ( m_objetDeSchemaSelectionne == objet )
                return;
            if ( m_objetDeSchemaSelectionne != null && !(m_objetDeSchemaSelectionne is C2iSchemaReseau))
                Invalidate ( new Rectangle ( GetScreenPoint ( m_objetDeSchemaSelectionne.PositionAbsolue, true),
                    GetScreenSize ( m_objetDeSchemaSelectionne.Size ) ), true );
            //Graphics g = CreateGraphics();
            //HideSelection(g);
            m_objetDeSchemaSelectionne = objet;
            if ( m_objetDeSchemaSelectionne != null && !(m_objetDeSchemaSelectionne is C2iSchemaReseau))
                Invalidate(new Rectangle(GetScreenPoint(m_objetDeSchemaSelectionne.PositionAbsolue,true),
                        GetScreenSize(m_objetDeSchemaSelectionne.Size)), true);
            //Refresh();
            //DrawSelection(g);
            //g.Dispose();

        }

        //--------------------------------------------------------------------
        private void HideSelection(Graphics g)
        {
            return;
        }

        //--------------------------------------------------------------------
        private void DrawSelection(Graphics g)
        {
            if (m_objetDeSchemaSelectionne == null || (m_objetDeSchemaSelectionne is C2iSchemaReseau))
                return;
            C2iLienDeSchemaReseau dessinLien = m_objetDeSchemaSelectionne as C2iLienDeSchemaReseau;
            if ( dessinLien != null )
            {
                DrawSelectionLien (  g, dessinLien );
                return;
            }
            Rectangle rct = m_objetDeSchemaSelectionne.RectangleAbsolu;
            rct = new Rectangle(
                GetScreenPoint(rct.Location, false),
                GetScreenSize(rct.Size));
            Pen pen = new Pen(Color.Black, 2);
            pen.DashStyle = DashStyle.Dot;
            g.DrawRectangle(pen, rct);
            pen.Dispose();
        }

        //--------------------------------------------------------------------
        private void DrawSelectionLien(Graphics g, C2iLienDeSchemaReseau dessinLien)
        {
            int fDist = 3;
            Pen pen = new Pen(Color.Black, 1);
            pen.DashStyle = DashStyle.Dot;
            
            for ( int nCote = -1; nCote <= 1; nCote+=2 )
            {
                for ( int nPoint = 0; nPoint < dessinLien.Points.Length-1; nPoint++ )
                {
                    Point pt1 = dessinLien.Points[nPoint];
                    Point pt2 = dessinLien.Points[nPoint+1];
                if (pt1.Y == pt2.Y)
                {
                    pt1.Offset(00, (int)(fDist*nCote));
                    pt2.Offset ( 0, (int)(fDist*nCote ));
                }
                else
                {
                    double fPente = -((pt1.X - pt2.X) / (pt1.Y - pt2.Y));
                    double fX = fDist / (Math.Sqrt(1 + fPente * fPente))*nCote;
                    double fY = fPente * fX;
                    pt1.Offset ( (int)fX, (int)fY);
                    pt2.Offset ( (int)fX, (int)fY );
                }
                    g.DrawLine ( pen, pt1, pt2 );

                }
            }
            pen.Dispose();
        }

        //--------------------------------------------------------------------
        public Point GetScreenPoint(Point ptLogique, bool bWithScrollBars)
        {
            double fX = (double)ptLogique.X / m_fEchelle;
            double fY = (double)ptLogique.Y / m_fEchelle;
            if ( bWithScrollBars )
            {
                fX -= HorizontalScroll.Value;
                fY -= VerticalScroll.Value;
            }
            return new Point((int)fX, (int)fY);
        }

        //--------------------------------------------------------------------
        public Size GetScreenSize(Size sizeLogique)
        {
            return new Size(
                (int)((double)sizeLogique.Width / m_fEchelle),
                (int)((double)sizeLogique.Height / m_fEchelle));
        }

        //--------------------------------------------------------------------
        public Point GetLogicalPoint(Point ptScreen)
        {
            double fX = ptScreen.X;
            double fY = ptScreen.Y;
           /*fX += HorizontalScroll.Value;
            fY += VerticalScroll.Value*/;
            fX = (double)fX * m_fEchelle;
            fY = (double)fY * m_fEchelle;
            return new Point((int)fX, (int)fY);
        }

        //--------------------------------------------------------------------
        public Size GetLogicalSize(Size sizeScreen)
        {
            return new Size(
                (int)((double)sizeScreen.Width * m_fEchelle),
                (int)((double)sizeScreen.Height * m_fEchelle));
        }

        //--------------------------------------------------------------------
        /// <summary>
        /// Applique les matrices de transformation sur le graphic pour dessiner des points logiques
        /// </summary>
        /// <param name="g"></param>
        protected void PrepareGraphicPourDessiner(Graphics g)
        {
            g.ResetTransform();
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;
            //g.TranslateTransform(AutoScrollPosition.X, AutoScrollPosition.Y);
            g.ScaleTransform((float)m_fEchelle, (float)m_fEchelle);
        }

        //--------------------------------------------------------------------
        private Bitmap m_imageCache = null;//Utilisée pour dessiner l'élément quand
        //Disable
        private void m_panelDessin_Paint(object sender, PaintEventArgs e)
        {
            if (DesignMode)
                return;
            Bitmap bmp = m_imageCache;
            Graphics g = e.Graphics;
            if (bmp == null || !m_bModeChargement || bmp.Size != ClientSize)
            {
                List<Rectangle> lstInvalide = new List<Rectangle>();
                lstInvalide.Add(e.ClipRectangle);
                bmp = new Bitmap(ClientSize.Width, ClientRectangle.Height);
                Graphics gBmp = Graphics.FromImage(bmp);
                gBmp.TranslateTransform(-AutoScrollPosition.X, -AutoScrollPosition.Y);
                PrepareGraphicPourDessiner(gBmp);
                CContextDessinObjetGraphique ctx = new CContextDessinObjetGraphique(gBmp, lstInvalide);
                ctx.WorkWithLimits = true;
                ctx.FonctionDessinSupplementaireApresObjet = new DessinSupplementaireDelegate(m_baseVue.DoDessinSupplementaireAfter);
                ctx.FonctionDessinSupplementaireAvantObjet = new DessinSupplementaireDelegate(m_baseVue.DoDessinSupplementaireBefore);
                m_dessinDeSchema.Draw(ctx);
                if (m_bModeChargement)
                    m_imageCache = bmp;
                gBmp.Dispose();
            }
            g.DrawImageUnscaled(bmp, AutoScrollPosition.X, AutoScrollPosition.Y);
            if (!m_bModeChargement)
            {
                bmp.Dispose();
                m_imageCache = null;
            }
            if ( m_bModeChargement && m_nNbElementsToLoad != 0)
            {
                LinearGradientBrush br = new LinearGradientBrush ( new Point ( 0, 0), new Point ( ClientSize.Width, c_nProgressHeight ),
                    Color.DarkGreen, Color.LightGreen);
                double fX = ((double)ClientSize.Width / (double)m_nNbElementsToLoad)*m_nNbElementsLoaded;
                g.FillRectangle ( br, new Rectangle( (int)0, 0, (int)fX, c_nProgressHeight));
                System.Threading.Thread.Sleep(10);
                br.Dispose();
            }
                

            /*if (m_bitmapDessin != null)
            {
                Rectangle rctClient = ClientRectangle;
                rctClient.Offset(AutoScrollPosition.X, AutoScrollPosition.Y);
                e.Graphics.DrawImage(m_bitmapDessin, rctClient.Left, rctClient.Top);
            }*/
            DrawSelection(e.Graphics);
        }

        //--------------------------------------------------------------------
        private List<C2iObjetDeSchema> GetObjetsFromPoint(Point ptScreen)
        {
            Point ptLogique = GetLogicalPoint(new Point(ptScreen.X, ptScreen.Y));
            List<C2iObjetDeSchema> lst = new List<C2iObjetDeSchema>();
            if (m_dessinDeSchema != null)
            {
                List<I2iObjetGraphique> lstTmp = m_dessinDeSchema.SelectionnerElements ( ptLogique );
                if ( lstTmp != null )
                    foreach ( I2iObjetGraphique obj in lstTmp )
                    {
                        if ( obj is C2iObjetDeSchema )
                            lst.Add ( (C2iObjetDeSchema)obj);
                    }
            }
            return lst;
        }

        //--------------------------------------------------------------------
        void CControlSchemaSupervise_EnabledChanged(object sender, System.EventArgs e)
        {
        }

        //-----------------------------
        public void Home()
        {
            if (m_stackCheminsReseau.Count == 1)
                return;
            while (m_stackCheminsReseau.Count > 1)
                m_stackCheminsReseau.Pop();
            CSchemaReseau schema = m_stackCheminsReseau.Peek();
            m_dessinDeSchema = schema.GetSchema(false);
            SetSelection(null);
            RedrawSchema();
            UpdateTraitementSNMP();
            SnmpUpdate();
        }

        //-----------------------------
        public bool DrillDown ( IElementDeSchemaReseau eltDeSchema )
        {
            CSchemaReseau schema = eltDeSchema as CSchemaReseau;
            if ( schema == null )
            {
                CLienReseau lien = eltDeSchema as CLienReseau;
                if ( lien != null )
                    schema = lien.SchemaReseau;
            }
            if (schema == null)
            {
                CSite site = eltDeSchema as CSite;
                if (site != null)
                {
                    //S'il y a un cablage, affiche le cablage
                    foreach (CSchemaReseau sousSchema in SchemaAffiche.SchemaFils)
                    {
                        if (site.Equals(sousSchema.SiteApparenance))
                        {
                            schema = sousSchema;
                            break;
                        }
                    }
                }
            }
                    
            if ( schema != null )
            {
                m_stackCheminsReseau.Push ( schema );
                m_dessinDeSchema = schema.GetSchema(false);
                SetSelection(null);
                RedrawSchema();
                UpdateTraitementSNMP();
                if (OnChangeSchemaAffiche != null)
                    OnChangeSchemaAffiche(this, new EventArgs());
                SnmpUpdate();
                return true;
            }
            return false;
        }

        //-----------------------------
        public bool DrillUp()
        {
            if ( m_stackCheminsReseau.Count > 1 )
            {
                m_stackCheminsReseau.Pop();
                CSchemaReseau schema = m_stackCheminsReseau.Peek();
                m_dessinDeSchema = schema.GetSchema(false);
                SetSelection(null);
                RedrawSchema();
                UpdateTraitementSNMP();
                if (OnChangeSchemaAffiche != null)
                    OnChangeSchemaAffiche(this, new EventArgs());
                SnmpUpdate();
                
                return true;
            }
            return false;
        }

        //-----------------------------
        private void m_panelDessin_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            List<C2iObjetDeSchema> lst = GetObjetsFromPoint(new Point(e.X, e.Y));
            if (lst.Count > 0)
            {
                foreach (C2iObjetDeSchema objetDeSchema in lst)
                {
                    CElementDeSchemaReseau elementDeSchema = objetDeSchema.ElementDeSchema;
                    if (elementDeSchema != null)
                    {
                        IElementDeSchemaReseau elt = elementDeSchema.ElementAssocie;
                        if (DrillDown(elt))
                            return;
                    }
                }
            }
        }

        //-----------------------------
        public CSchemaReseau SchemaAffiche
        {
            get
            {
                if (m_stackCheminsReseau.Count > 0)
                    return m_stackCheminsReseau.Peek();
                return null;
            }
        }

        private class CMenuItemAvecAlarme : ToolStripMenuItem
        {
            private CLocalAlarme m_infoAlarme;

            public CMenuItemAvecAlarme ( CLocalAlarme infoAlarme )
            {
                Text = infoAlarme.Libelle;//17082011 +" / " + infoAlarme.ElementGereType + "-" + infoAlarme.ElementGereName;
                CLocalSeveriteAlarme sev = infoAlarme.TypeAlarme.Severite;
                BackColor = sev != null ? sev.Couleur : Color.White;
               m_infoAlarme = infoAlarme;
            }
            public CLocalAlarme Alarme
            {
                get{
                    return m_infoAlarme;
                }
            }

        }


        //-----------------------------
        public event EventHandler OnChangeSchemaAffiche;

        private class CSorterAlarmes : IComparer<CLocalAlarme>
        {
        
                public int  Compare(CLocalAlarme x, CLocalAlarme y)
                {
                    if (x.TypeAlarme.Severite.Priorite.Equals(y.TypeAlarme.Severite.Priorite))
                        return x.Libelle.CompareTo(y.Libelle);
                    return x.TypeAlarme.Severite.Priorite.CompareTo(y.TypeAlarme.Severite.Priorite);
                }

        }

        private void m_menuRightClick_Opening(object sender, CancelEventArgs e)
        {
            m_menuAlarmes.Visible = false;
            m_menuShowDiagram.Visible = false;
            m_menuShowProperties.Visible = false;
            if (m_objetDeSchemaSelectionne != null)
            {
                CElementDeSchemaReseau eltDeSchema = m_objetDeSchemaSelectionne.ElementDeSchema;
                if (eltDeSchema != null)
                {
                    IElementDeSchemaReseau elt = eltDeSchema.ElementAssocie;
                    if (elt != null)
                    {
                        m_menuShowProperties.Visible = true;
                    }
                    m_menuAlarmes.DropDownItems.Clear();
                    if (elt is CSchemaReseau || elt is CLienReseau)
                        m_menuShowDiagram.Visible = true;
                    List<CLocalAlarme> lstAlarmes = m_baseVue.GetAlarmesPourElement(eltDeSchema);
                    if (lstAlarmes.Count == 0)
                        m_menuAlarmes.Visible = false;
                    else
                    {
                        lstAlarmes.Sort(new CSorterAlarmes());
                        foreach (CLocalAlarme alarme in lstAlarmes)
                        {
                            CMenuItemAvecAlarme menu = new CMenuItemAvecAlarme(alarme);
                            menu.Click += new EventHandler(menu_Click);
                            m_menuAlarmes.DropDownItems.Add(menu);
                        }
                        m_menuAlarmes.Visible = true;
                    }
                }
                
            }
        }

        private void  menu_Click(object sender, EventArgs e)
        {
            CMenuItemAvecAlarme menu = sender as CMenuItemAvecAlarme;
            if ( menu != null && m_navigateur != null )
            {
                CAlarme alarme = new CAlarme(m_baseVue.ContexteDonnee);
                if (alarme.ReadIfExists(new CFiltreData(CAlarme.c_champAlarmId + "=@1", menu.Alarme.Id)))
                {
                    m_navigateur.AffichePage(new CFormEditionAlarme(alarme));
                }
            }
        }
        
        void m_menuShowDiagram_Click(object sender, EventArgs e)
        {
            if (m_objetDeSchemaSelectionne == null)
                return;
            CElementDeSchemaReseau eltDeSchema = m_objetDeSchemaSelectionne.ElementDeSchema;
            if (eltDeSchema != null)
                if (eltDeSchema.ElementAssocie != null)
                    DrillDown(eltDeSchema.ElementAssocie);
        }


        private void m_menuShowProperties_Click(object sender, EventArgs e)
        {
            if (m_objetDeSchemaSelectionne == null)
                return;
            CElementDeSchemaReseau eltDeSchema = m_objetDeSchemaSelectionne.ElementDeSchema;
            if (eltDeSchema != null)
            {
                if (eltDeSchema.ElementAssocie != null)
                {
                    CReferenceTypeForm refTypeForm = CFormFinder.GetRefFormToEdit(eltDeSchema.ElementAssocie.GetType());
                    if (refTypeForm != null)
                    {
                        IFormNavigable form = refTypeForm.GetForm(eltDeSchema.ElementAssocie as CObjetDonneeAIdNumeriqueAuto) as IFormNavigable;
                        if (form != null && m_navigateur != null)
                            m_navigateur.AffichePage(form);
                    }
                }
            }
        }

        //--------------------------------------------------------------------
        private void m_panelDessin_MouseUp(object sender, MouseEventArgs e)
        {
            List<C2iObjetDeSchema> lst = GetObjetsFromPoint(new Point(e.X, e.Y));
            if (lst.Count > 0)
            {
                C2iObjetDeSchema obj = lst[0];
                SetSelection(obj);
            }
            if (m_objetDeSchemaSelectionne != null && (e.Button & MouseButtons.Right)==e.Button)
                m_menuRightClick.Show(this, new Point(e.X, e.Y));
        }

        //--------------------------------------------------------------------
        public void SnmpUpdate()
        {
            if (!m_bIsSnmpUpdating && m_bHasSnmpEntities )
            {
                m_progress.Visible = true;
                CBackgroundWorkerAvecProgress wk = new CBackgroundWorkerAvecProgress(m_progress);
                wk.DoWork += new DoWorkEventHandler(SnmpUpdateThread);
                wk.RunWorkerCompleted += new RunWorkerCompletedEventHandler(wk_RunWorkerCompleted);
                wk.RunWorkerAsync();
            }
        }

        void wk_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            m_lastSnmpUpdate = DateTime.Now;
            UpdateLabelSnmpUpdate();
            RedrawSchema();
        }

        //--------------------------------------------------------------------
        private bool m_bIsSnmpUpdating = false;
        private void SnmpUpdateThread(object sender, DoWorkEventArgs args)
        {
            if (m_bIsSnmpUpdating)
                return;
            IIndicateurProgression indicateur = sender as IIndicateurProgression;
            m_bIsSnmpUpdating = true;
            try
            {
                if (indicateur != null)
                {
                    indicateur.SetBornesSegment(0, 100);
                    indicateur.SetValue(0);
                    indicateur.Masquer(false);
                }
                CSchemaReseau schema = m_stackCheminsReseau.Peek();
                CListeCouplesEntiteChamp liste = schema.GetListeValeursSnmpAffichees();
                liste.UpdateValeurs(schema.ContexteDonnee, indicateur);
                if (indicateur != null)
                    indicateur.Masquer(true);
                
            }
            catch { }
            finally
            {
                m_bIsSnmpUpdating = false;
            }
        }


        //--------------------------------------------------------------------
        private void m_timerSnmp_Tick(object sender, EventArgs e)
        {
            SnmpUpdate();
        }



    }
}
