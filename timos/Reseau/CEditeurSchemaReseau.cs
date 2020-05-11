using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using timos.data.workflow.ConsultationHierarchique;
using sc2i.win32.data;
using timos.data;
using sc2i.data;
using sc2i.win32.common;
using sc2i.common;
using timos.data.reseau.graphe;
using timos.data.reseau.arbre_operationnel;

namespace timos.Reseau
{
    public partial class CEditeurSchemaReseau : UserControl, IControlALockEdition
    {
        private CSchemaReseau m_schemaReseau;
        private C2iObjetDeSchema m_objetDeSchema = null;
        private CLienReseau m_lienEdite = null;
        

        public CEditeurSchemaReseau()
        {
            InitializeComponent();
        }

        public void Init(C2iObjetDeSchema objetEdite, CSchemaReseau schemaReseau)
        {
#if DEBUG
            m_btnGraphe.Visible = true;
#endif
            m_panelSchema.ObjetEdite = objetEdite;
            m_panelSchema.Editeur = this;
            m_panelSchema.NoClipboard = true;
            m_schemaReseau = schemaReseau;
            m_objetDeSchema = objetEdite;
            if (!LockEdition && m_objetDeSchema is C2iSchemaReseau)
            {
                ((C2iSchemaReseau)m_objetDeSchema).ArrangerLiaisons();
                
            }
            
            m_panelSchema.ObjetSchemaReseau = schemaReseau;
            m_panelSchema.ModeEdition = EModeEditeurSchema.Selection;

            if (schemaReseau != null)
            {

                
                m_lienEdite = schemaReseau.LienReseau;
                m_panelSchema.LienReseauEdite = m_lienEdite;

            }
            
            m_panelElements.AddAllLoadedAssemblies();
            if (!LockEdition)
                ReactualiserArbre();
            m_tabDeGauche.Visible = !LockEdition;

            m_cmbVueDynamique.Init(typeof(CParametreVueSchemaDynamique), "Libelle", true);
            
            
        }

       
        public CPanelEditionObjetGraphique Editeur
        {
            get
            {
                return m_panelSchema;

            }
        }
    

        public C2iObjetDeSchema ObjetDeSchema
        {
            get
            {
                 return m_objetDeSchema;
            }
        }

        private void CEditeurSchemaReseau_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;
            ReactualiserArbre();
            
            
        }


        private bool m_bCmbArbreInitialisee = false;
        public void ReactualiserArbre()
        {
            m_bCmbArbreInitialisee = false;
            if (m_schemaReseau == null)
                return;
            Type typeConsulte = null;
            CListeObjetsDonnees lst = new CListeObjetsDonnees ( m_schemaReseau.ContexteDonnee, typeof(CConsultationHierarchique));
            if (m_schemaReseau.SiteApparenance != null)
            {
                lst.Filtre = new CFiltreData(CConsultationHierarchique.c_champTypeSource + "=@1",
                    typeof(CSite).ToString());
                typeConsulte = typeof(CSite);

                

            }
            else
                lst.Filtre = new CFiltreData(CConsultationHierarchique.c_champTypeSource +"=@1", "");
            m_cmbArbreHierarchique.Init(lst, "Libelle", true);
            m_cmbArbreHierarchique.AssureRemplissage();
            int nIdLastConsultationUtilisee = new CTimosAppRegistre().GetLastIdConsultationHierarchiqueInSchema(typeConsulte);
            if (nIdLastConsultationUtilisee >= 0)
            {
                CConsultationHierarchique cslt = new CConsultationHierarchique(CSc2iWin32DataClient.ContexteCourant);
                if (cslt.ReadIfExists(nIdLastConsultationUtilisee))
                    m_cmbArbreHierarchique.ElementSelectionne = cslt;
            }
            if (m_cmbArbreHierarchique.ElementSelectionne == null && m_cmbArbreHierarchique.Items.Count > 0)
                m_cmbArbreHierarchique.SelectedIndex = 0;
            m_bCmbArbreInitialisee = true;
        }


        //---------------------------------------------------------------------
        private void m_cmbArbreHierarchique_SelectedIndexChanged(object sender, EventArgs e)
        {
            CConsultationHierarchique consultation = m_cmbArbreHierarchique.ElementSelectionne as CConsultationHierarchique;
            if (consultation != null)
            {
                CFolderConsultationHierarchique racine = consultation.FolderRacine;
                if (m_schemaReseau.SiteApparenance != null)
                {
                    CFolderConsultationRacineFromElement racineElt = racine as CFolderConsultationRacineFromElement;
                    racineElt.InitConsultation(m_schemaReseau.SiteApparenance);

                    CFolderConsultationFolder folderCablage = new CFolderConsultationFolder(racineElt);
                    folderCablage.Libelle = I.T("Wiring|10055");
                    racineElt.AddFolder(folderCablage);
                    CFolderConsultationCablage cablage = new CFolderConsultationCablage(folderCablage);
                    cablage.SchemaCablage = m_schemaReseau;
                    folderCablage.AddFolder(cablage);
                    
                }
                m_arbreConsultation.InitChamps(racine, CSc2iWin32DataClient.ContexteCourant);
                if (m_bCmbArbreInitialisee)
                {
                    Type typeConsulte = null;
                    if ( m_schemaReseau != null && m_schemaReseau.SiteApparenance != null )
                        typeConsulte = typeof(CSite);
                    new CTimosAppRegistre().SetLastIdConsultationHierarchiqueInSchema ( typeConsulte,  consultation.Id );
                }
            }
        }

        //---------------------------------------------------------------------
        private DragDropEffects m_arbreConsultation_OnDragNode(object sender, CNodeConsultationHierarchique node)
        {
            //if (m_gestionnaireModeEdition.ModeEdition)
            {
                IElementDeSchemaReseau element = node.ObjetLie as IElementDeSchemaReseau;


                
                if (element != null && m_schemaReseau != null)
                {

                    if (m_lienEdite != null)
                    {
                        if (element.GetType() == typeof(CLienReseau))
                        {
                            CLienReseau lien = (CLienReseau)element;

                            if (!m_lienEdite.PeutEtreSupporte(lien))
                            {
                                CFormAlerte.Afficher(I.T("Cannot add the link because it is already supported by the current link|30385"),EFormAlerteType.Erreur);
                                return DragDropEffects.None;

                            }

                            
                            if (!m_lienEdite.TypeSupportantPossible(lien))
                            {
                                CFormAlerte.Afficher(I.T("Cannot add the link because its type is not a possible supporting type for this link type|30400"), EFormAlerteType.Erreur);
                                return DragDropEffects.None;
                            }


                        }
                        



                    }

                    if (element.GetType() == typeof(CSchemaReseau))
                    {

                        //CSchemaReseau schema = (CSchemaReseau)element;

                        //if (schema.SchemaParent != null)
                        //{
                        //    CFormAlerte.Afficher(I.T("Cannot add the diagram beacuse it is included in another diagram|30391"),EFormAlerteType.Erreur);
                        //    return DragDropEffects.None;
                        //}
                    }


                    /*CElementDeSchemaReseau elementDeSchema = new CElementDeSchemaReseau(m_schemaReseau.ContexteDonnee);
                    elementDeSchema.CreateNewInCurrentContexte();
                    elementDeSchema.ElementAssocie = element;
                    elementDeSchema.SchemaReseau = m_schemaReseau;*/

                    C2iObjetDeSchemaTemporairePourDragDropSansElementDeSchema objet = new C2iObjetDeSchemaTemporairePourDragDropSansElementDeSchema();
                    objet.InitFrom(element);

                    CDonneeDragDropObjetGraphique data = new CDonneeDragDropObjetGraphique(m_arbreConsultation.GetType().ToString(), objet);
                    DataObject dataObj = new DataObject();
                    dataObj.SetData(data);
                    dataObj.SetData(typeof(CReferenceObjetDonnee), new CReferenceObjetDonnee((CObjetDonnee)element));
                    DragDropEffects eff = DoDragDrop(dataObj, DragDropEffects.All | DragDropEffects.Link);
                   /* if (eff == DragDropEffects.None)
                        elementDeSchema.CancelCreate();*/
                }
            }
            return DragDropEffects.None;
        }

        #region IControlALockEdition Membres

        public bool LockEdition
        {
            get
            {
                return !m_gestionnaireModeEdition.ModeEdition;
            }
            set
            {
                m_gestionnaireModeEdition.ModeEdition = !value;
                if (OnChangeLockEdition != null)
                    OnChangeLockEdition(this, new EventArgs());
                if (!value && m_objetDeSchema is C2iSchemaReseau)
                {
                    ((C2iSchemaReseau)m_objetDeSchema).ArrangerLiaisons();
                    m_panelSchema.RefreshDelayed();
                }
                m_tabDeGauche.Visible = !LockEdition;
                if (!LockEdition)
                    ReactualiserArbre();
            }
        }


      
       


        public event EventHandler OnChangeLockEdition;

        #endregion

        private void m_btnModeSelection_CheckedChanged(object sender, EventArgs e)
        {
            if (m_btnModeSelection.Checked)
            {
                if (m_panelSchema.ModeEdition != EModeEditeurSchema.Selection)
                {
                    m_panelSchema.ModeEdition = EModeEditeurSchema.Selection;
                    m_panelSchema.Focus();
                    Refresh();
                }
            }
        }

        private void m_btnModeZoom_CheckedChanged(object sender, EventArgs e)
        {
            if (m_btnModeZoom.Checked)
            {
                if (m_panelSchema.ModeEdition != EModeEditeurSchema.Zoom)
                {
                    m_panelSchema.ModeEdition = EModeEditeurSchema.Zoom;
                    m_panelSchema.Focus();
                    Refresh();
                }
            }
        }

       

        private void m_btnModeAjoutLien_CheckedChanged(object sender, EventArgs e)
        {
            
        }
      

        private void m_panelSchema_OnChangeModeEdition(object sender, EventArgs e)
        {
            UpdateBoutonsForModeEdition();
            if (m_panelSchema.ModeEdition == EModeEditeurSchema.Etiquette)
                m_panelSchema.AjouterEtiquette();
        }

        private void UpdateBoutonsForModeEdition()
        {
            switch (m_panelSchema.ModeEdition)
            {
                case EModeEditeurSchema.Selection:
                    if (!m_btnModeSelection.Checked)
                        m_btnModeSelection.Checked = true;
                    break;
                case EModeEditeurSchema.Zoom:
                    if (!m_btnModeZoom.Checked)
                        m_btnModeZoom.Checked = true;
                    break;
                case EModeEditeurSchema.Lien1:
                    if (!m_btnModeAjoutLien.Checked)
                        m_btnModeAjoutLien.Checked = true;
                    break;
                case EModeEditeurSchema.Lien2:
                    if (!m_btnModeAjoutLien.Checked)
                        m_btnModeAjoutLien.Checked = true;
                    break;
                case EModeEditeurSchema.EditionLigne:
                    if ( !m_btnModeEditLine.Checked )
                        m_btnModeEditLine.Checked = true;
                    break;
                case EModeEditeurSchema.EditionModificationPoint:
                    if ( !m_btnModeEditLine.Checked )
                        m_btnModeEditLine.Checked = true;
                    break;
            /*    case EModeEditeurSchema.Etiquette:
                    if (!m_btnEtiquette.Checked )
                        m_btnEtiquette.Checked = true;*/
                   


                default:
                    break;
            }
        }

        private void m_panelSchema_SelectionChanged(object sender, EventArgs e)
        {
            ActualiserPanel();
            m_btnModeEditLine.Enabled = m_panelSchema.Selection.Count == 1 &&
                typeof(C2iLienDeSchemaReseau).IsAssignableFrom(m_panelSchema.Selection[0].GetType());
        }

        private void ActualiserPanel()
        {
            
            if (m_panelSchema.Selection.Count == 0)
            {
                m_propertyGrid.SelectedObject = null;
            }
            else
            {
                if (m_panelSchema.Selection.Count == 1)
                {
                    m_propertyGrid.SelectedObject = m_panelSchema.Selection[0];
                }
                else
                {
                    List<object> objs = new List<object>();
                    foreach (C2iObjetDeSchema elements in m_panelSchema.Selection)
                        objs.Add(elements);
                    m_propertyGrid.SelectedObjects = objs.ToArray();
                }
            }
        }


        public void BoutonEditionLigneVisible(bool bVisible)
        {
            m_btnModeEditLine.Visible = bVisible;
        }

        private void m_btnModeAjoutLien_CheckedChanged_1(object sender, EventArgs e)
        {
            if (m_btnModeAjoutLien.Checked)
            {
                if (m_panelSchema.ModeEdition != EModeEditeurSchema.Lien1 &&
                    m_panelSchema.ModeEdition != EModeEditeurSchema.Lien2)
                {
                    m_panelSchema.ModeEdition = EModeEditeurSchema.Lien1;
                    m_panelSchema.Focus();
                    Refresh();
                }

            }   
        }

        private void m_btnModeAjoutSchema_CheckedChanged(object sender, EventArgs e)
        {
            if(m_btnModeAjoutSchema.Checked)
            {
                if (m_panelSchema.ModeEdition != EModeEditeurSchema.AjoutSchema)
                {
                    m_panelSchema.ModeEdition = EModeEditeurSchema.AjoutSchema;
                    m_panelSchema.Focus();
                    Refresh();
                }
            }



        }

       
        private void m_propertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            m_panelSchema.Refresh();
        }

        private void m_btnEtiquette_CheckedChanged(object sender, EventArgs e)
        {
            if (m_btnEtiquette.Checked)
            {
               /* if (m_panelSchema.ModeEdition != EModeEditeurSchema.Etiquette)
                {
                    m_panelSchema.ModeEdition = EModeEditeurSchema.Etiquette;
                    m_panelSchema.Focus();
                    Refresh();
                }*/

                m_panelSchema.AjouterEtiquette();
                m_btnModeSelection.Checked = true;

            }
        }

        private void m_btnModeEditLine_CheckedChanged(object sender, EventArgs e)
        {
            if (m_btnModeEditLine.Checked)
            {
                if (m_panelSchema.ModeEdition != EModeEditeurSchema.EditionLigne &&
                    m_panelSchema.ModeEdition != EModeEditeurSchema.EditionModificationPoint)
                {
                    if (m_panelSchema.Selection.Count == 1 &&
                        typeof(C2iLienDeSchemaReseau).IsAssignableFrom(m_panelSchema.Selection[0].GetType()))
                    {
                        m_panelSchema.EditeLine((C2iLienDeSchemaReseau)m_panelSchema.Selection[0]);
                    }
                }
            }
        }

        private void m_btnGraphe_Click(object sender, EventArgs e)
        {
            if (m_schemaReseau == null)
                return;
            CGrapheReseau graphe = new CGrapheReseau();
            CResultAErreur result = graphe.CalculeGraphe(m_schemaReseau, ESensAllerRetourLienReseau.Forward);
            if (!result)
            {
                CFormAlerte.Afficher(result.Erreur);
                return;
            }
            CArbreOperationnel arbre = new CArbreOperationnel();
            result = arbre.CalculArbreRedondanceAuto(m_schemaReseau, graphe);
            string strTexte = "";
            if (result)
            {
                strTexte = arbre.ElementRacine.ToString();
                Clipboard.SetText(strTexte);
                CFormTesteArbreElementDeGraphe.AfficheArbre(arbre);
            }
        }

        private void m_cmbVueDynamique_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CParametreVueSchemaDynamique parametre = m_cmbVueDynamique.ElementSelectionne as CParametreVueSchemaDynamique;
            if (parametre == null)
                m_panelSchema.ParametreDynamique = null;
            else
                m_panelSchema.ParametreDynamique = parametre.ParametreRepresentation;
            m_panelSchema.Refresh();
        }


    }
}
