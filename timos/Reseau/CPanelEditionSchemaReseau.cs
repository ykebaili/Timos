using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.IO;
using System.Windows.Forms;
using sc2i.win32.common;
using sc2i.drawing;
using sc2i.data;
using timos.data;
using sc2i.win32.navigation;
using sc2i.win32.data.navigation;
using sc2i.common;
using timos.data.symbole.dynamique;
using sc2i.process;
using System.Collections;

namespace timos.Reseau
{
    public partial class CPanelEditionSchemaReseau : CPanelEditionObjetGraphique
    {

        //Pendant la création d'un nouveau lien, stock les points intermédiaires du lien
        private List<Point> m_listePointsNouveauLien = new List<Point>();
        

        private CLienReseau m_lienReseauEdite;

        private C2iLienDeSchemaReseau m_ligneEditee;

        private int m_nIndexSelectedPoint = -1;

        private C2iObjetDeSchema m_objetDebutLien;
        private IEtapeLienReseau[] m_etapesDebutLienReseau = null;
        private IElementALiensReseau m_elementDebutLien = null;

        private CEditeurSchemaReseau m_editeur;

        private CSchemaReseau m_schemaReseau;

        private CParametreRepresentationSchema m_parametreDynamique = null;


        private EModeEditeurSchema m_modeEnCours = EModeEditeurSchema.Selection;


        public CLienReseau LienReseauEdite
        {
            get
            {
                return m_lienReseauEdite;
            }

            set
            {
                m_lienReseauEdite = value;
            }
        }

        /// ////////////////////////////////////////////////////////////////
        protected override CContextDessinObjetGraphique GetContexteDessin(Graphics g, Rectangle clipZone)
        {
            CContextDessinObjetGraphique ctx =  base.GetContexteDessin(g, clipZone);
            if ( m_parametreDynamique != null )
                m_parametreDynamique.AttacheToContexte ( ctx );
            return ctx;
        }

        /// ////////////////////////////////////////////////////////////////
        public CParametreRepresentationSchema ParametreDynamique
        {
            get
            {
                return m_parametreDynamique;
            }
            set
            {
                m_parametreDynamique = value;
            }
        }
        
        /// ////////////////////////////////////////////////////////////////
 

        public EModeEditeurSchema ModeEdition
        {
            get
            {
                return m_modeEnCours;
            }
            set
            {

                if (value == EModeEditeurSchema.Selection)
                {
                    ModeSouris = EModeSouris.Selection;
                    SelectionVisible = true;
                    if (m_ligneEditee != null)
                    {
                        m_ligneEditee.SetModeSelection(true);
                        m_ligneEditee = null;
                        Refresh();
                    }
                }
                else if ( value == EModeEditeurSchema.Zoom )
                {
                    ModeSouris = EModeSouris.Zoom;
                    SelectionVisible = true;
                    if ( m_ligneEditee != null )
                    {
                        m_ligneEditee.SetModeSelection(true);
                        m_ligneEditee = null;
                    }
                }
            /*    else if (value == EModeEditeurSchema.Etiquette)
                {
                    AjouterEtiquette();
                    m_modeEnCours = EModeEditeurSchema.Selection;

                }*/
                else
                {
                    SelectionVisible = false;
                    ModeSouris = EModeSouris.Custom;
                }
                m_modeEnCours = value;

                LoadCurseurAdapté();

                if (OnChangeModeEdition != null)
                    OnChangeModeEdition(this, null);
            }
        }

        public event EventHandler OnChangeModeEdition;



        //-----------------------------------------------
        public CPanelEditionSchemaReseau()
        {
            InitializeComponent();
          
        }

        //-----------------------------------------------
        public C2iSchemaReseau SchemaReseau
        {
            get
            {
                return ObjetEdite as C2iSchemaReseau;
            }
            set
            {
                ObjetEdite = value;
            }
        }

        public CEditeurSchemaReseau Editeur
        {
            get
            {
                return m_editeur;
            }
            set
            {
                m_editeur = value;
            }
        }


        public CSchemaReseau ObjetSchemaReseau
        {
            get
            {
                return m_schemaReseau;
            }
            set
            {
                m_schemaReseau = value;
            }
        }


       
        protected override void AfficherMenuAdditonnel(ContextMenuStrip menu)
        {

            if (m_mnu_itm_properties == null)
            {
                m_mnu_itm_properties = new System.Windows.Forms.ToolStripMenuItem();
                menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { m_mnu_itm_properties });
                m_mnu_itm_properties.Name = "m_mnu_itm_properties";
                m_mnu_itm_properties.Size = new System.Drawing.Size(194, 22);
                m_mnu_itm_properties.Text = I.T("Properties|1234");
                m_mnu_itm_properties.Click += new System.EventHandler(this.m_mnu_itm_properties_Click);
            }
            if ( m_mnu_itm_Cablage == null )
            {
                m_mnu_itm_Cablage = new System.Windows.Forms.ToolStripMenuItem(I.T("Edit wiring|20132"));
                m_mnu_itm_Cablage.Click += new EventHandler(menuCablage_Click);
                menu.Items.Add(m_mnu_itm_Cablage);
            }
            if ( Selection.Count == 1 )
            {
                m_mnu_itm_properties.Visible = false;
                C2iObjetDeSchema objet = Selection[0] as C2iObjetDeSchema;
                if ( objet != null && objet.ElementDeSchema != null && objet.ElementDeSchema.ElementAssocie is CSite )
                    m_mnu_itm_Cablage.Visible = true;
                else
                    m_mnu_itm_Cablage.Visible = false;
            }
            else
            {
                m_mnu_itm_Cablage.Visible = false;
                m_mnu_itm_properties.Visible = false;
            }

            if (m_mnu_itm_edit_points == null)
            {
                m_mnu_itm_edit_points = new System.Windows.Forms.ToolStripMenuItem();
                menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { m_mnu_itm_edit_points });

                m_mnu_itm_edit_points.Name = "m_mnu_itm_edit_points";
                m_mnu_itm_edit_points.Size = new System.Drawing.Size(194, 22);
                m_mnu_itm_edit_points.Text = I.T("Edit points|30387");
                m_mnu_itm_edit_points.Click += new System.EventHandler(this.m_mnu_itm_edit_points_Click);

            }

            if (m_mnu_itm_action == null)
            {
                m_mnu_itm_action = new System.Windows.Forms.ToolStripMenuItem();
                m_mnu_itm_edit_points = new System.Windows.Forms.ToolStripMenuItem();
                menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { m_mnu_itm_action });

                m_mnu_itm_action.Name = "m_mnu_itm_action";
                m_mnu_itm_action.Size = new System.Drawing.Size(194, 22);
                m_mnu_itm_action.Text = I.T("Action|50000");
            }

            if (Selection.Count == 1)
            {
                FillMenuAction();
            }
            else
            {
                m_mnu_itm_action.Visible = false;
            }

            bool bPropertiesVisible = MNU_PropertiesShow();
            bool bLinkVisible = MNU_LinkShow();
          //  bool bSchemaVisible = MNU_SchemaShow();
          //  bool bCloseSchemaVisible = MNU_CloseSchemaShow();
            bool bEditPointsVisible = MNU_EditPointsShow();
            m_mnu_itm_properties.Visible = bPropertiesVisible;
            // m_mnu_itm_schema.Visible = bSchemaVisible;
           // m_mnu_itm_close_schema.Visible = bCloseSchemaVisible;
            m_mnu_itm_edit_points.Visible = bEditPointsVisible;

        }

        private class CMenuItemDeclencheur : ToolStripMenuItem
		{
			public readonly IDeclencheurActionManuelle Declencheur;
			public CMenuItemDeclencheur ( IDeclencheurActionManuelle declencheur )
			{
				Declencheur = declencheur;
				Text = declencheur.Libelle;
			}
		}

        private void FillMenuAction()
        {
            m_mnu_itm_action.Visible = false;
            foreach (ToolStripMenuItem item in new ArrayList(m_mnu_itm_action.DropDownItems))
            {
                m_mnu_itm_action.DropDownItems.Remove(item);
                item.Dispose();
            }

            if (Selection.Count == 1)
            {
                C2iObjetDeSchema obj = Selection[0] as C2iObjetDeSchema;
                if (obj != null)
                {
                    if (obj.ElementDeSchema != null)
                    {
                        IDeclencheurAction[] declencheurs = CRecuperateurDeclencheursActions.GetActionsManuelles(obj.ElementDeSchema, true);
                        if (declencheurs.Length > 0)
                        {
                            foreach (IDeclencheurAction declencheur in declencheurs)
                            {
                                IDeclencheurActionManuelle declManuelle = declencheur as IDeclencheurActionManuelle;
                                if ( declManuelle != null &&declManuelle.DeclencherSurContexteClient)
                                {
                                    string strMenu = "";
                                    if (declencheur is IDeclencheurActionManuelle)
                                        strMenu = ((IDeclencheurActionManuelle)declencheur).MenuManuel;
                                    string[] strMenus = strMenu.Split('/');
                                    ToolStripItemCollection listeSousMenus = m_mnu_itm_action.DropDownItems;
                                    if (strMenus.Length > 0)
                                    {
                                        foreach (string strSousMenu in strMenus)
                                        {
                                            if (strSousMenu.Trim().Length > 0)
                                            {
                                                ToolStripMenuItem sousMenu = null;
                                                foreach (ToolStripMenuItem item in listeSousMenus)
                                                    if (item.Text == strSousMenu)
                                                    {
                                                        sousMenu = item;
                                                        break;
                                                    }
                                                if (sousMenu == null)
                                                {
                                                    sousMenu = new ToolStripMenuItem(strSousMenu);
                                                    listeSousMenus.Add(sousMenu);
                                                }
                                                listeSousMenus = sousMenu.DropDownItems;
                                            }
                                        }
                                    }
                                    CMenuItemDeclencheur itemAction = new CMenuItemDeclencheur(declManuelle);
                                    itemAction.Click += new EventHandler(MenuDeclencheurClick);
                                    listeSousMenus.Add(itemAction);
                                    m_mnu_itm_action.Visible = true;
                                }
                            }
                            
                        }
                        
                    }
                }
            }
        }

        //-------------------------------------------------------------------------
        private void MenuDeclencheurClick(object sender, EventArgs e)
        {
            if (sender is CMenuItemDeclencheur && Selection.Count == 1)
            {
                C2iObjetDeSchema obj = Selection[0] as C2iObjetDeSchema;
                if (obj.ElementDeSchema != null)
                {
                    IDeclencheurActionManuelle declencheur = ((CMenuItemDeclencheur)sender).Declencheur;
                    CInfoDeclencheurProcess infoDeclencheur = new CInfoDeclencheurProcess(TypeEvenement.Manuel);
                    CResultAErreur result = declencheur.EnregistreDeclenchementEvenementSurClient ( 
                        obj.ElementDeSchema,
                        infoDeclencheur,
                        null );
                    if (!result)
                    {
                        CFormAlerte.Afficher(result.Erreur);
                    }
                    Refresh();
                }
            }
        }
			

        void menuCablage_Click(object sender, EventArgs e)
        {
            if (Selection.Count != 1 || m_schemaReseau == null)
                return;
            C2iObjetDeSchema objet = Selection[0] as C2iObjetDeSchema;
            if (objet == null || objet.ElementDeSchema == null || !(objet.ElementDeSchema.ElementAssocie is CSite))
                return;
            CSite site = objet.ElementDeSchema.ElementAssocie as CSite;
            //Trouve le schema fils correspondant au site
            CSchemaReseau schemaCablage = null;
            foreach (CSchemaReseau schema in m_schemaReseau.SchemaFils)
            {
                if (site.Equals(schema.SiteApparenance))
                {
                    schemaCablage = schema;
                    break;
                }
            }
            if (schemaCablage == null)
            {
                schemaCablage = new CSchemaReseau(m_schemaReseau.ContexteDonnee);
                schemaCablage.CreateNew();
                //schemaCablage.SchemaParent = null;//Car pb sur création de contexte d'édition sur un fils composition
                schemaCablage.SchemaParent = m_schemaReseau; //Test Youcef 04/03/2010
                schemaCablage.SiteApparenance = site;
                schemaCablage.Libelle = I.T("Wiring of @1 in @2|20133", m_schemaReseau.Libelle, site.Libelle);
            }
            
            CFormEditionSchemaReseau frm = new CFormEditionSchemaReseau(schemaCablage);
            CFormNavigateurPopup.Show(frm, FormWindowState.Maximized);
            if (schemaCablage.IsValide() && schemaCablage.SchemaParent == null)
                schemaCablage.SchemaParent = m_schemaReseau;
            Refresh();
        }

        private bool MNU_LinkShow()
        {
            if((ModeEdition == EModeEditeurSchema.Selection) && (Selection.Count ==1))          {
               
               C2iObjetDeSchema objet = (C2iObjetDeSchema)Selection[0];
               if (objet != null)
               {
                   CElementDeSchemaReseau element = objet.ElementDeSchema;
                   if (element != null)
                   {
                       if (element.ElementAssocie != null)
                       {
                          if((typeof(IElementDeSchemaReseau).IsAssignableFrom(element.ElementAssocie.GetType()))&&(element.ElementAssocie.GetType()!=typeof(CLienReseau)))    
                              return true;
                       }

                  }
             }

          }

          return false;
         }


     /*  private bool MNU_SchemaShow()
        {
            if ((ModeEdition == EModeEditeurSchema.Selection) && (Selection.Count == 1))
            {

                C2iObjetDeSchema objet = (C2iObjetDeSchema)Selection[0];
                if (objet != null)
                {
                    if(typeof(C2iLienDeSchemaReseau).IsAssignableFrom(objet.GetType()))
                    {
                        C2iLienDeSchemaReseau lienDeSchema = (C2iLienDeSchemaReseau)objet;
                       if(!lienDeSchema.SchemaOuvert)
                       {
                        
                         CElementDeSchemaReseau element = objet.ElementDeSchema;
                        if (element != null)
                       {
                          if (element.ElementAssocie != null)
                          {
                              if ((element.ElementAssocie.GetType() == typeof(CLienReseau)))
                               {
                                  CLienReseau lienReseau = (CLienReseau)element.ElementAssocie;
                                  if(lienReseau.SchemaReseau !=null)
                                   {
                                     return true;                             
                                   }
                               }
                          }        
                        }
                      }
                    }
                }

            }

                   return false;
        }
        */


        private bool MNU_EditPointsShow()
        {
            if ((ModeEdition == EModeEditeurSchema.Selection) && (Selection.Count == 1))
            {

                C2iObjetDeSchema objet = (C2iObjetDeSchema)Selection[0];
                if (objet != null)
                {
                    if (typeof(C2iLienDeSchemaReseau).IsAssignableFrom(objet.GetType()))
                    {
                        
                           return true;
                               
                    }
                }

            }

            return false;
        }


    /*    private bool MNU_CloseSchemaShow()
        {
             if ((ModeEdition == EModeEditeurSchema.Selection) && (Selection.Count == 1))
            {

                C2iObjetDeSchema objet = (C2iObjetDeSchema)Selection[0];
                if (objet != null)
                {
                    if(typeof(C2iLienDeSchemaReseau).IsAssignableFrom(objet.GetType()))
                    {
                        C2iLienDeSchemaReseau lienDeSchema = (C2iLienDeSchemaReseau)objet;
                       if(lienDeSchema.SchemaOuvert)
                       {
                           return true;
                       } 
                    }
                }
             }
            return false;
        }*/

      
        protected override void LoadCurseurAdapté()
        {
            
           
            switch (ModeEdition)
            {

                
                case EModeEditeurSchema.Selection:
                case EModeEditeurSchema.Zoom :
                        base.LoadCurseurAdapté();
                        return;

               
                case EModeEditeurSchema.EditionLigne:
                 {
                        if ((ModifierKeys & Keys.Shift) == Keys.Shift)
                        {
                            
                            Cursor = C2iCursorLoader.LoadCursor(GetType(), "editLineDelPoint", Properties.Resources.editLineDelPoint);

                        }
                        else if ((ModifierKeys & Keys.Control) == Keys.Control)
                        {
                            
                            Cursor = C2iCursorLoader.LoadCursor(GetType(), "editLineAddPoint", Properties.Resources.editLineAddPoint);

                        }
                        else
                        {
                            Point pt = GetLogicalPointFromDisplay(PointToClient(Cursor.Position));
                            if ( m_ligneEditee != null && m_ligneEditee.IsCloseToPoint ( pt ) )
                                Cursor = C2iCursorLoader.LoadCursor(GetType(), "editLineMovePoint", Properties.Resources.editLineMovePoint);
                            else
                                Cursor = C2iCursorLoader.LoadCursor(GetType(), "editLine", Properties.Resources.editLine);

                        }


                        break;
                    }
                case EModeEditeurSchema.EditionModificationPoint:
                    {

                        Cursor = C2iCursorLoader.LoadCursor(GetType(), "editLineMovePoint", Properties.Resources.editLineMovePoint);
                         break;

                    }

                case EModeEditeurSchema.Lien1:
                    {
                      
                        Cursor = C2iCursorLoader.LoadCursor(GetType(), "curLien1", Properties.Resources.curLien1);
                        break;
                    }


                case EModeEditeurSchema.Lien2:
                {
                   if ((ModifierKeys & Keys.Control) == Keys.Control)
                       Cursor = C2iCursorLoader.LoadCursor(GetType(), "editLineAddPoint", Properties.Resources.editLineAddPoint);
                    else
                       Cursor = C2iCursorLoader.LoadCursor(GetType(), "curLien2", Properties.Resources.curLien2);
                   break;
                }

                case EModeEditeurSchema.AjoutSchema:
                {

                    Cursor = C2iCursorLoader.LoadCursor(GetType(), "curSchema", Properties.Resources.curSchema);
                    break;
                }

            }
        }
        

        private bool MNU_PropertiesShow()
        {
            if (Selection.Count == 1)
                return true;
            else
                return false;
        }

        private void m_mnu_itm_properties_Click(object sender, EventArgs e)
        {
            MNU_Properties();
        }

        private void MNU_Properties()
        {
          AfficherProprietes();

        }


        



    /*    private void m_mnu_itm_close_schema_Click(Object sender, EventArgs e)
        {
            MNU_CloseSchema();
        }


        private void m_mnu_itm_schema_Click(object sender, EventArgs e)
        {
            MNU_Schema();
        }*/

        private void m_mnu_itm_edit_points_Click(object sender, EventArgs e)
        {
            MNU_EditPoints();
        }

        private void MNU_EditPoints()
        {
            if (Selection.Count == 1)
            {
                C2iLienDeSchemaReseau lien = Selection[0] as C2iLienDeSchemaReseau;
                if (lien != null)
                    EditeLine(lien);
            }
        }

        public void EditeLine(C2iLienDeSchemaReseau lien)
        {
            Selection.Clear();
            Selection.Add(lien);
            ModeEdition = EModeEditeurSchema.EditionLigne;
            m_ligneEditee = lien;
            m_ligneEditee.SetModeSelection(false);
            Refresh();
        }



     /*   private void MNU_Schema()
        {

            C2iLienDeSchemaReseau lienSchema = (C2iLienDeSchemaReseau)Selection[0];

            
            CLienReseau lienReseau = (CLienReseau)lienSchema.ElementDeSchema.ElementAssocie;

            if (lienReseau.SchemaReseau != null)
            {
                lienSchema.ForeColor = Color.Green;
                CSchemaReseau schemaLien = lienReseau.SchemaReseau;
                foreach (CElementDeSchemaReseau element in schemaLien.ElementsDeSchema)
                {
                    if (element.LienReseau != null)
                    {
                        C2iLienDeSchemaReseau lienAffiche = (C2iLienDeSchemaReseau)element.ObjetDeSchema;

                        ObjetEdite.AddChild(lienAffiche);
                        lienAffiche.Parent = ObjetEdite;



                    }
                }


            }
            lienSchema.SchemaOuvert = true;

        }*/


      /*  private void MNU_CloseSchema()
        {
              C2iLienDeSchemaReseau lienSchema = (C2iLienDeSchemaReseau)Selection[0];

            
            CLienReseau lienReseau = (CLienReseau)lienSchema.ElementDeSchema.ElementAssocie;

            if (lienReseau.SchemaReseau != null)
            {
                lienSchema.ForeColor = Color.Green;
                CSchemaReseau schemaLien = lienReseau.SchemaReseau;
                foreach (CElementDeSchemaReseau element in schemaLien.ElementsDeSchema)
                {
                    foreach (C2iObjetDeSchema objetGraphique in ObjetEdite.Childs)
                    {
                        if (objetGraphique.ElementDeSchema == element)
                            ObjetEdite.RemoveChild(objetGraphique);

                    }
                    
                }
            }
            lienSchema.SchemaOuvert = false;
        }*/

        private void AfficherProprietes()
        {
            C2iObjetDeSchema objet = (C2iObjetDeSchema)Selection[0];
            if (objet != null)
            {
                CElementDeSchemaReseau element = objet.ElementDeSchema;
                if (element != null)
                {
                    if (element.ElementAssocie != null)
                    {
                        CObjetDonneeAIdNumeriqueAuto objetAEditer = (CObjetDonneeAIdNumeriqueAuto)element.ElementAssocie;
                        CReferenceTypeForm reference = CFormFinder.GetRefFormToEdit(objetAEditer.GetType());
                        if (reference != null)
                        {
                            CFormEditionStandard frm = reference.GetForm(objetAEditer) as CFormEditionStandard;
                            if (frm != null)
                            {
                                if (LockEdition)
                                    CTimosApp.Navigateur.AffichePage(frm);
                                else
                                {

                                    CFormNavigateurPopup.Show(frm);
                                    Refresh();
                                }
                            }
                        }
                    }
                }
            }
        }



        private CFiltreData GetFiltreTypeliens(Type typeElt1, Type typeElt2)
        {
            CFiltreData filtre = new CFiltreData(CTypeLienReseau.c_champTypeElement1 + "=@1 " + " AND " + CTypeLienReseau.c_champTypeElement2 + "=@2", typeElt1.ToString(),typeElt2.ToString());
            CListeObjetsDonnees liste = new CListeObjetsDonnees(ObjetSchemaReseau.ContexteDonnee, typeof(CTypeLienReseau), filtre);
            if (liste.Count == 0)
                return null;
            string strIds = "";
            if(m_lienReseauEdite !=null)
            {


                if (m_lienReseauEdite.TypeLienReseau != null)
                {

                    foreach (CTypeLienReseauSupport typeLien in m_lienReseauEdite.TypeLienReseau.TypesPouvantSupporterCeType)
                    {
                        strIds += (typeLien.TypeSupportant.Id + ",");
                    }


                    if (strIds != "")
                    {

                        strIds = strIds.Substring(0, strIds.Length - 1);
                        string strFiltre = CTypeLienReseau.c_champId + " IN (" + strIds + ")";
                        CFiltreData filtreType = CFiltreData.GetAndFiltre(filtre,
                        new CFiltreData(strFiltre));

                        return filtreType;
                    }
                    else
                        return null;
                }

               
           
                
       
            }

            return filtre;
           

           
        }
            
        private void CPanelEditionSchemaReseau_DoubleClick(object sender, EventArgs e)
        {
            if (Selection.Count == 1)
            {
                AfficherProprietes();
            } 
        }

 
            
        public override void  OnMouseUpNonStandard(object sender, MouseEventArgs e)
        {

            Point ptSouris = GetLogicalPointFromDisplay(new Point(e.X, e.Y));

            if (ModeEdition == EModeEditeurSchema.EditionModificationPoint && m_ligneEditee != null && m_nIndexSelectedPoint >= 0)
            {

                if ((ModifierKeys & Keys.Shift) == Keys.Shift)
                    ptSouris = new Point(GetThePlusProche(ptSouris.X, EDimentionDessin.X),
                        GetThePlusProche(ptSouris.Y, EDimentionDessin.Y));
                m_ligneEditee.ReplacePoint(m_nIndexSelectedPoint, ptSouris);


                Refresh();
                ModeEdition = EModeEditeurSchema.EditionLigne;

            }
            else if (ModeEdition == EModeEditeurSchema.EditionLigne && m_ligneEditee != null)
            {
                if (e.Button == MouseButtons.Right)
                {

                    ModeEdition = EModeEditeurSchema.Selection;

                    if (m_ligneEditee != null)
                    {
                        m_ligneEditee.SetModeSelection(true);
                        m_ligneEditee = null;
                    }
                    Refresh();

                }


                else
                {

                    m_ligneEditee.SetModeSelection(false);
                    Point pt = ptSouris;

                    if ((ModifierKeys & Keys.Control) == Keys.Control)
                    {
                        Point? prevPointOnLine;
                        if ((prevPointOnLine = m_ligneEditee.PointOnlineBeforePoint(pt)) != null)
                        {
                            m_ligneEditee.InsertAfterPoint((Point)prevPointOnLine, pt);
                            Refresh();
                        }


                    }
                    else
                    {

                        m_nIndexSelectedPoint = m_ligneEditee.GetIndexPointProche(ptSouris);

                        if (((ModifierKeys & Keys.Shift) == Keys.Shift) && (m_nIndexSelectedPoint >= 0))
                        {
                            if (m_ligneEditee.RemovePoint(m_nIndexSelectedPoint))
                            {
                                m_nIndexSelectedPoint = -1;
                                Refresh();
                            }
                            else
                                MessageBox.Show(I.T("Impossible to remove the point|30033"));
                        }

                    }
                }
            }
        }

            

    
     
     
        public override void  OnMouseDownNonStandard(object sender, MouseEventArgs e)
        {
            Point ptSouris = GetLogicalPointFromDisplay(new Point(e.X, e.Y));

            this.Capture = true;

            

            if (this.ObjetEdite != null)
            {
                if (ModeEdition == EModeEditeurSchema.EditionLigne)
                {
                  
               
                   if (m_ligneEditee != null && (ModifierKeys & Keys.Shift) != Keys.Shift)
                   {
                        ptSouris = m_ligneEditee.Parent.GlobalToClient(ptSouris);

                        if ((m_nIndexSelectedPoint = m_ligneEditee.GetIndexPointProche(ptSouris)) >= 0)
                            ModeEdition = EModeEditeurSchema.EditionModificationPoint;

                    }
                 
               }
               else if ((ModeEdition == EModeEditeurSchema.Lien1) && (SchemaReseau != null))
               {
                   m_listePointsNouveauLien.Clear();
                   I2iObjetGraphique objetASelectionner = SchemaReseau.SelectionnerElementDuDessus(ptSouris);
                   C2iObjetDeSchema objetDebutLien = objetASelectionner as C2iObjetDeSchema;
                   if (objetDebutLien != null)
                   {
                       if (objetDebutLien.ElementDeSchema != null)
                       {
                           if (objetDebutLien.ElementDeSchema.ElementAssocie != null)
                           {
                               m_etapesDebutLienReseau = null;
                               m_elementDebutLien = CFormSelectExtremiteDeElementDeSchema.SelectExtremite(objetDebutLien.ElementDeSchema.ElementAssocie, ref m_etapesDebutLienReseau);
                               if ( m_elementDebutLien != null )
                               {
                                   m_listePointsNouveauLien.Add(ptSouris);
                                   m_objetDebutLien = objetDebutLien;
                                   ModeEdition = EModeEditeurSchema.Lien2;
                                   Refresh();
                               }
                           }
                       }

                   }

               }
                else if((ModeEdition == EModeEditeurSchema.AjoutSchema) && (SchemaReseau !=null))
                {

                    if (ObjetSchemaReseau != null)
                    {
                        CSchemaReseau schemaFils = new CSchemaReseau(ObjetSchemaReseau.ContexteDonnee);
                        schemaFils.CreateNew();
                        schemaFils.SchemaParent = ObjetSchemaReseau;
                        schemaFils.SiteApparenance = ObjetSchemaReseau.SiteApparenance;
                        CFormEditionSchemaReseau frm = new CFormEditionSchemaReseau(schemaFils);
                        
                        CFormNavigateurPopup.Show(frm, FormWindowState.Normal);
                        if (schemaFils.IsValide())
                        {

                            CElementDeSchemaReseau element = new CElementDeSchemaReseau(ObjetSchemaReseau.ContexteDonnee);
                            element.CreateNewInCurrentContexte();
                            element.SchemaReseau = ObjetSchemaReseau;
                            element.X = ptSouris.X;
                            element.Y = ptSouris.Y;
                            element.ElementAssocie = schemaFils;
                            C2iObjetDeSchema schemaGraphique = element.ObjetDeSchema;
                            SchemaReseau.AddChild(schemaGraphique);
                            schemaGraphique.Parent = SchemaReseau;
                          /*  Editeur.ObjetDeSchema.AddChild(schemaGraphique);
                            schemaGraphique.Parent = Editeur.ObjetDeSchema;*/

                            Refresh();
                        }
                        else
                        {

                            schemaFils.Delete(true);
                        }

                    }
                    ModeEdition=EModeEditeurSchema.Selection;
                }

               else if ((ModeEdition == EModeEditeurSchema.Lien2) && (SchemaReseau != null))
               {
                   //création d'un lien entre deux éléments du schéma
                   if (m_objetDebutLien != null)
                   {
                       if (m_objetDebutLien.ElementDeSchema != null)
                       {
                           if ((ModifierKeys & Keys.Control) == Keys.Control)//Création d'un point intermédiaire
                           {
                               m_listePointsNouveauLien.Add(ptSouris);
                               Graphics g = CreateGraphics();
                               PrepareGraphicPourDessiner(g);
                               g.DrawLines(Pens.Black, m_listePointsNouveauLien.ToArray());
                               g.Dispose();
                           }
                           else
                           {
                               I2iObjetGraphique objetASelectionner = SchemaReseau.SelectionnerElementDuDessus(ptSouris);
                               C2iObjetDeSchema objetFinLien = objetASelectionner as C2iObjetDeSchema;

                               if (objetFinLien != null)
                               {
                                   if (objetFinLien.ElementDeSchema != null)
                                   {
                                       IEtapeLienReseau[] etapesFin = null;
                                       IElementALiensReseau elementFinLien = CFormSelectExtremiteDeElementDeSchema.SelectExtremite(objetFinLien.ElementDeSchema.ElementAssocie, ref etapesFin);
                                       if ( elementFinLien != null )
                                       {
                                           bool bCreation = false;
                         
                                           

                                           CLienReseau lienAAjouter = CFormSelectionNouveauLien.SelectExistant(
                                               m_elementDebutLien,
                                               elementFinLien, 
                                               m_etapesDebutLienReseau, 
                                               etapesFin, 
                                               LienReseauEdite, 
                                               ref bCreation);



                                           if(!bCreation)
                                           {
                                               if (lienAAjouter != null)
                                               {
                                                   if (m_schemaReseau.LienReseau != null)
                                                   {
                                                       if(!m_schemaReseau.LienReseau.PeutEtreSupporte(lienAAjouter))
                                                       {
                                                           CFormAlerte.Afficher(I.T("Impossible to add a link because it is alerady supported by the current link|30385"),EFormAlerteType.Erreur);
                                                           ModeEdition = EModeEditeurSchema.Selection;
                                                           return;
                                                       }

                                                   }      
                                                   CElementDeSchemaReseau elementDeSchema = new CElementDeSchemaReseau(ObjetSchemaReseau.ContexteDonnee);
                                                   elementDeSchema.CreateNewInCurrentContexte();
                                                   elementDeSchema.ElementAssocie = lienAAjouter;
                                                   elementDeSchema.SchemaReseau = m_schemaReseau;

                                                   C2iObjetDeSchema lienGraphique = elementDeSchema.ObjetDeSchema;
                                                   //Editeur.ObjetDeSchema.AddChild(lienGraphique);
                                                   SchemaReseau.AddChild(lienGraphique);
                                                   C2iLienDeSchemaReseau lienQuiEnEstUn = lienGraphique as C2iLienDeSchemaReseau;
                                                   lienGraphique.Parent = SchemaReseau;
                                                   //lienGraphique.Parent = Editeur.ObjetDeSchema;
                                                   if (lienQuiEnEstUn != null)
                                                   {
                                                       m_listePointsNouveauLien.Add(ptSouris);
                                                       lienQuiEnEstUn.Points = m_listePointsNouveauLien.ToArray();
                                                   }
                                                   m_listePointsNouveauLien.Clear();
                                                   lienGraphique.Parent.FrontToBack(lienGraphique);
                                                   Refresh();


                                               }


                                           }
                                           else
                                           {
                                              
                                               CLienReseau lienReseau = new CLienReseau(ObjetSchemaReseau.ContexteDonnee);
                                               lienReseau.CreateNew();
                                               lienReseau.Element1 = m_elementDebutLien;
                                               lienReseau.Element2 = elementFinLien;
                                               
                                               CFiltreData filtreLien = GetFiltreTypeliens(m_elementDebutLien.GetType(),
                                                    elementFinLien.GetType());
                                               if (filtreLien == null)
                                               {
                                                   CFormAlerte.Afficher(I.T("Cannot add a link. There is no possible link types|30383"), EFormAlerteType.Erreur);
                                               }
                                               else
                                               {
                                                   CListeObjetsDonnees liste_type = new CListeObjetsDonnees(lienReseau.ContexteDonnee, typeof(CTypeLienReseau));
                                                   liste_type.Filtre = filtreLien;



                                                   lienReseau.TypeLienReseau = (CTypeLienReseau)liste_type[0];



                                                   CFormEditionLienReseau frm = new CFormEditionLienReseau(lienReseau, m_lienReseauEdite);
                                                  // frm.SetFiltreTypeLien(filtreLien);
                                                   frm.LockComboElements();

                                                   if (frm != null)
                                                   {

                                                       CFormNavigateurPopup.Show(frm, FormWindowState.Normal);
                                                       if (lienReseau.IsValide())
                                                       {

                                                           CElementDeSchemaReseau element = new CElementDeSchemaReseau(ObjetSchemaReseau.ContexteDonnee);
                                                           element.CreateNewInCurrentContexte();
                                                           element.SchemaReseau = ObjetSchemaReseau;
                                                           element.ElementAssocie = lienReseau;
                                                           //Crée les etapes
                                                           if (m_etapesDebutLienReseau != null)
                                                           {
                                                               CCheminLienReseau lastEtape = null;
                                                               foreach (IEtapeLienReseau etape in m_etapesDebutLienReseau)
                                                               {
                                                                   CCheminLienReseau chemin = new CCheminLienReseau(lienReseau.ContexteDonnee);
                                                                   chemin.CreateNewInCurrentContexte();
                                                                   chemin.ElementDeSchemaConcerne = element;
                                                                   chemin.NumeroExtremiteConcernee = (int)EExtremiteLienReseau.Un;
                                                                   chemin.Etape = etape;
                                                                   chemin.CheminParent = lastEtape;
                                                                   lastEtape = chemin;
                                                               }
                                                           }
                                                           if (etapesFin != null)
                                                           {
                                                               CCheminLienReseau lastEtape = null;
                                                               foreach (IEtapeLienReseau etape in etapesFin)
                                                               {
                                                                   CCheminLienReseau chemin = new CCheminLienReseau(lienReseau.ContexteDonnee);
                                                                   chemin.CreateNewInCurrentContexte();
                                                                   chemin.ElementDeSchemaConcerne = element;
                                                                   chemin.NumeroExtremiteConcernee = (int)EExtremiteLienReseau.Deux;
                                                                   chemin.Etape = etape;
                                                                   chemin.CheminParent = lastEtape;
                                                                   lastEtape = chemin;
                                                               }
                                                           }
                                                           C2iObjetDeSchema lienGraphique = element.ObjetDeSchema;
                                                           SchemaReseau.AddChild(lienGraphique);
                                                           //Editeur.ObjetDeSchema.AddChild(lienGraphique);
                                                           C2iLienDeSchemaReseau lienQuiEnEstUn = lienGraphique as C2iLienDeSchemaReseau;
                                                           lienGraphique.Parent = SchemaReseau;
                                                          // lienGraphique.Parent = Editeur.ObjetDeSchema;
                                                           if (lienQuiEnEstUn != null)
                                                           {
                                                               m_listePointsNouveauLien.Add(ptSouris);
                                                               lienQuiEnEstUn.Points = m_listePointsNouveauLien.ToArray();
                                                           }
                                                           m_listePointsNouveauLien.Clear();
                                                           // SchemaReseau.AddChild(lienGraphique);

                                                           lienGraphique.Parent.BringToFront(lienGraphique);
                                                           Refresh();
                                                       }
                                                       else
                                                       {

                                                           //Pas de test d'erreur, logiquement, si le nouveau lien
                                                           //n'est pas valide, il est déjà supprimé
                                                           lienReseau.Delete(true);
                                                       }
                                                   }
                                               } 
                                           }

                                       }
                                   }
                               }
                               ModeEdition = EModeEditeurSchema.Selection;
                               Refresh();
                           }
                       }

                       
                   }
               }
                
            }


          
        }






        public CFiltreData GetFiltreListeLiens(IElementALiensReseau element1, IElementALiensReseau element2)
        {

            string strIds1 = "";
            string strIds2 = "";
            CFiltreData filtre;


            foreach (CLienReseau lien in element1.Liens)
            {
                if (lien.Element1.Id == element1.Id)
                    strIds1 += lien.Id.ToString() + ",";

            }

            foreach (CLienReseau lien in element2.Liens)
            {

                if (lien.Element2.Id == element2.Id)
                    strIds2 += lien.Id.ToString() + ",";

            }

            if ((strIds1 != "") && (strIds2 != ""))
            {

                strIds1 = strIds1.Substring(0, strIds1.Length - 1);
                strIds2 = strIds2.Substring(0, strIds2.Length - 1);
                filtre = new CFiltreData(CLienReseau.c_champId + " IN (" + strIds1 + ")");
                filtre = CFiltreData.GetAndFiltre(filtre, new CFiltreData(CLienReseau.c_champId + " IN (" + strIds2 + ")"));

                return filtre;

            }
            else
                return null;





        }
       

        private void CPanelEditionSchemaReseau_MouseMove(object sender, MouseEventArgs e)
        {
           
            if (ModeSouris != EModeSouris.Custom)
                return;
            LoadCurseurAdapté();
            Point mousePoint = GetLogicalPointFromDisplay(new Point(e.X, e.Y));


            if (this.ObjetEdite != null)
            {
                if (ModeEdition == EModeEditeurSchema.EditionModificationPoint && m_ligneEditee != null && m_nIndexSelectedPoint >= 0)
                {
                    mousePoint = m_ligneEditee.Parent.GlobalToClient(mousePoint);
                    if ( (ModifierKeys & Keys.Shift) == Keys.Shift )
                        mousePoint = new Point ( GetThePlusProche ( mousePoint.X, EDimentionDessin.X ),
                            GetThePlusProche ( mousePoint.Y, EDimentionDessin.Y ));
                    m_ligneEditee.ReplacePoint(m_nIndexSelectedPoint, mousePoint);
                    Refresh();

                }
            }
        }

        private void CPanelEditionSchemaReseau_SelectionChanged(object sender, EventArgs e)
        {
            if (m_editeur != null)
            {
                if (Selection.Count == 1)
                {
                    if (Selection[0].GetType() == typeof(C2iLienDeSchemaReseau))
                    {
                        Editeur.BoutonEditionLigneVisible(true);
                        return;
                    }
                }
                Editeur.BoutonEditionLigneVisible(false);
            }
        }

        private void CPanelEditionSchemaReseau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                if (ModeEdition != EModeEditeurSchema.Selection)
                {
                    ModeEdition = EModeEditeurSchema.Selection;
                    if (m_ligneEditee != null)
                    {
                        m_ligneEditee.SetModeSelection(true);
                        m_ligneEditee = null;

                    }

                }
            }
        }

        public override void MyDrawElementsSupplementaires(Graphics gPretPourDessinElementsLogiques)
        {
            base.MyDrawElementsSupplementaires(gPretPourDessinElementsLogiques);
            if (m_listePointsNouveauLien != null && m_listePointsNouveauLien.Count > 1 && ModeEdition == EModeEditeurSchema.Lien2)
            {
                gPretPourDessinElementsLogiques.DrawLines(Pens.Black, m_listePointsNouveauLien.ToArray());
            }
        }

        private void CPanelEditionSchemaReseau_AfterRemoveObjetGraphique(object sender, EventArgs e)
        {
          
        }

        private bool CPanelEditionSchemaReseau_BeforeDeleteElement()
        {
            return default(bool);
        }

        private bool CPanelEditionSchemaReseau_BeforeDeleteElement(List<I2iObjetGraphique> objs)
        {
            foreach (I2iObjetGraphique objet in objs)
            {
                C2iObjetDeSchema onjDeSchema = objet as C2iObjetDeSchema;
                if (onjDeSchema != null && onjDeSchema.ElementDeSchema != null && onjDeSchema.ElementDeSchema.IsCableALinterieur)
                {
                    CFormAlerte.Afficher(I.T("Cannot delete this element, delete wiring first|20136"));
                    return false;
                }
                C2iLienDeSchemaReseau lien = objet as C2iLienDeSchemaReseau;
                if (lien != null)
                {
                    if (lien.ElementDeSchema != null)
                    {
                        CLienReseau lienReseau = lien.ElementDeSchema.LienReseau;
                        CResultAErreur result = CResultAErreur.True;
                        if (lienReseau != null)
                        {
                            if (lienReseau.IsNew())
                            {
                                result = lienReseau.Delete(true);
                                if (!result)
                                {
                                    CFormAlerte.Afficher(result.Erreur);
                                    return false;
                                }
                            }
                            else if (CFormAlerte.Afficher(I.T("Do you want to remove definitely the link '@1' from the database ?|30397", lienReseau.Libelle), EFormAlerteType.Question) == DialogResult.Yes)
                            {
                                result = lienReseau.Delete(true);
                                if (!result)
                                {
                                    CFormAlerte.Afficher(result.Erreur);
                                    return false;
                                }                                
                            }
                        }
                    }
                }



            }


            return true;
        }

        protected override List<CDonneeDragDropObjetGraphique> GetDragDropData(IDataObject data)
        {
            List<CDonneeDragDropObjetGraphique> retour = base.GetDragDropData(data);
            if ( retour != null )
                return retour;
            CReferenceObjetDonnee reference = data.GetData(typeof(CReferenceObjetDonnee)) as CReferenceObjetDonnee;
            if (reference != null)
            {
                if (typeof(IElementDeSchemaReseau).IsAssignableFrom(reference.TypeObjet))
                {
                    C2iObjetDeSchemaTemporairePourDragDropSansElementDeSchema objet = new C2iObjetDeSchemaTemporairePourDragDropSansElementDeSchema();
                    objet.InitFrom(reference);

                    CDonneeDragDropObjetGraphique donnee = new CDonneeDragDropObjetGraphique(OrigineDragDropId+"TMP", objet);
                    retour = new List<CDonneeDragDropObjetGraphique>();
                    retour.Add(donnee);
                    return retour;
                }
            }
            return null;
        }


        public void AjouterEtiquette()
        {

            if (Selection.Count != 1)
            {
                ModeEdition = EModeEditeurSchema.Selection;
                return;
            }

            C2iObjetDeSchema objetDeSchema = Selection[0] as C2iObjetDeSchema;
            if (objetDeSchema != null)
            {
                if (typeof(C2iEtiquetteSchema).IsAssignableFrom(objetDeSchema.GetType()))
                {
                   ModeEdition = EModeEditeurSchema.Selection;
                    return;
                }

                if (objetDeSchema.ElementDeSchema != null)
                {
                    if (objetDeSchema.ElementDeSchema.ElementAssocie != null)
                    {

                        Type typeObjetAssocie = objetDeSchema.ElementDeSchema.ElementAssocie.GetType();
                        CModeleEtiquetteSchema modele = CFormSelectionModeleEtiquette.SelectModele(typeObjetAssocie);
                        if (modele != null)
                        {
                            
                            C2iEtiquetteSchema etiquette = new C2iEtiquetteSchema();
                           
                            CElementDeSchemaReseau element = new CElementDeSchemaReseau(ObjetSchemaReseau.ContexteDonnee);
                            element.CreateNewInCurrentContexte();
                            element.SchemaReseau = ObjetSchemaReseau;
                            etiquette.ElementDeSchema = element;
                            SchemaReseau.AddChild(etiquette);
                            etiquette.Parent = SchemaReseau;
                            //Editeur.ObjetDeSchema.AddChild(etiquette);
                            //etiquette.Parent = Editeur.ObjetDeSchema;
                            etiquette.IdObjetAssocie = objetDeSchema.IdObjetDeSchema;
                            etiquette.Formula=modele.Formule;
                            etiquette.Size = new Size(64, 32);
                            etiquette.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                            etiquette.TextColor = Color.Black;
                            int posX = (objetDeSchema.Position.X + objetDeSchema.Size.Width / 2) - etiquette.Size.Width/2;
                            int posY = (objetDeSchema.Position.Y + objetDeSchema.Size.Height / 2) - etiquette.Size.Height/2;
                            //element.Height = etiquette.Size.Height;
                            //element.Width = etiquette.Size.Width;
                            
                            etiquette.Position = new Point(posX, posY);
                          

                            Selection.Clear();

                            Selection.Add(etiquette);

                        }


                    }

                }


              //  ModeEdition = EModeEditeurSchema.Selection;
            }


        }

        private bool CPanelEditionSchemaReseau_AfterAddElements(List<I2iObjetGraphique> objs)
        {
            foreach (C2iObjetDeSchema objet in objs)
            {
                if (objet.ElementDeSchema == null && objet is IDonneeDessinElementDeSchemaReseau)
                {
                    Rectangle rct = new Rectangle(objet.Position, objet.Size);
                    CElementDeSchemaReseau elt = new CElementDeSchemaReseau(ObjetSchemaReseau.ContexteDonnee);
                    elt.CreateNewInCurrentContexte();
                    elt.SchemaReseau = ObjetSchemaReseau;
                    objet.ElementDeSchema = elt;
                    elt.DonneeDessin = objet as IDonneeDessinElementDeSchemaReseau;
                    objet.Position = rct.Location;
                    objet.Size = rct.Size;
                }
            }
            Focus();
            return true;

        }


        public override void  CompleteDragDropData(DataObject datas, I2iObjetGraphique[] objetsMisDansLeDragDropData)
        {
            List<CReferenceObjetDonnee> lstRefs = new List<CReferenceObjetDonnee>();
            foreach (I2iObjetGraphique obj in objetsMisDansLeDragDropData)
            {
                C2iObjetDeSchema objDeSchema = obj as C2iObjetDeSchema;
                if (objDeSchema.ElementDeSchema != null && objDeSchema.ElementDeSchema.ElementAssocie is CObjetDonnee)
                {
                    lstRefs.Add(new CReferenceObjetDonnee((CObjetDonnee)objDeSchema.ElementDeSchema.ElementAssocie));
                }
            }
            if (lstRefs.Count > 0)
            {
                datas.SetData(typeof(List<CReferenceObjetDonnee>), lstRefs);
                datas.SetData(typeof(CReferenceObjetDonnee), lstRefs[0]);
            }
        }
         
       


     
       
    }



    public enum ECurseurEnCours
    {
        CursSelect,
        CursEdit,
        CursAdd,
        CursSuppr,
        CursMove,
        Curslien2,
        CursEtiquette

    }

    public enum EModeEditeurSchema
    {
        Selection,
        Zoom,
        Lien1,
        Lien2,
        EditionLigne,
        EditionModificationPoint,
        AjoutSchema,
        Etiquette
        
        
        
    }
}

       