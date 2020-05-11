using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using timos.data.workflow.ConsultationHierarchique;
using sc2i.win32.data;
using timos.data;
using sc2i.data;
using sc2i.win32.common;
using sc2i.common;
using sc2i.documents;
using System.IO;


namespace timos.Elements_communs
{
    public partial class CControlGED : UserControl, IControlALockEdition
    {
        private IObjetDonneeAIdNumerique m_elementEdite;
        private IObjetDonneeAIdNumerique m_elementSelectionne;
        private CListeObjetsDonnees m_listeDocuments;

        private CFiltreData m_filtreCategories = null;

        public CControlGED()
        {
            InitializeComponent();
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
            }
        }



        public event EventHandler OnChangeLockEdition;

        #endregion


        public void Init(IObjetDonneeAIdNumerique element)
        {
            m_elementEdite = element;

            m_cmbModeStockage.NullAutorise = false;
            m_cmbModeStockage.ProprieteAffichee = "Libelle";
            CDocumentGED dummyDoc = new CDocumentGED(CSc2iWin32DataClient.ContexteCourant);
            m_cmbModeStockage.ListDonnees = dummyDoc.TypesAutorisesPourLesUtilisateurs;
            m_cmbModeStockage.SelectedValue = dummyDoc.TypesAutorisesPourLesUtilisateurs[0];
            m_panelModeStockage.Visible = dummyDoc.TypesAutorisesPourLesUtilisateurs.Length > 1;


            ReactualiserArbre();
            FillCategoriesForElement(m_elementEdite);
            InitPanelList();
        }

        private void InitPanelList()
        {
            InitPanelList(m_elementEdite);
        }

 
        private void InitPanelList(IObjetDonneeAIdNumerique element)
        {
            m_elementSelectionne = element;
            if (element == null)
            {
                m_lnkDissocierElementEnCours.Visible = false;
                m_lblDragExisting.Visible = false;
                m_listeDocuments = new CListeObjetsDonnees(CSc2iWin32DataClient.ContexteCourant, typeof(CDocumentGED));
                if (!m_chkTousDocuments.Checked)
                {
                    m_labelElementSelectionne.Text = I.T("Documents not related to any Element|10331");
                    m_panelListDocumentsGED.FiltreDeBase = new CFiltreDataAvance(
                        CDocumentGED.c_nomTable,
                        "hasno(" + CRelationElementToDocument.c_nomTable + "." +
                        CRelationElementToDocument.c_champId + ")");
                }
                else
                {
                    m_labelElementSelectionne.Text = I.T("All documents|10332");
                    m_panelListDocumentsGED.FiltreDeBase = null;
                }
                m_chkTousDocuments.Visible = true;
            }
            else
            {
                m_lnkDissocierElementEnCours.Visible = true;
                m_lblDragExisting.Visible = true;

                m_labelElementSelectionne.Text = element.DescriptionElement;
                m_listeDocuments = CDocumentGED.GetListeDocumentsForElement(element);
                m_panelListDocumentsGED.FiltreDeBase = CDocumentGED.GetListeDocumentsForElement(element).Filtre;
                m_chkTousDocuments.Visible = false;
            }

            CFiltreData filtre = m_filtreCategories;
            m_listeDocuments.FiltrePrincipal = CFiltreData.GetAndFiltre(m_listeDocuments.FiltrePrincipal, m_filtreCategories);
            /*

            if (filtre != null)
            {
                m_panelListDocumentsGED.FiltreDeBase = CFiltreData.GetAndFiltre(
                    m_panelListDocumentsGED.FiltreDeBase,
                    filtreSpplementaire);
            }*/

            m_panelListDocumentsGED.ControlFiltreStandard = new CPanelFiltreDocumentGed();

            m_panelListDocumentsGED.InitFromListeObjets(
                m_listeDocuments,
                typeof(CDocumentGED),
                typeof(CFormEditionDocumentGED),
                null,
                "");

            m_panelListDocumentsGED.RemplirGrille();
        }

        //------------------------------------------------------------------------------
        private void FillCategoriesForElement(IObjetDonneeAIdNumerique element)
        {
            
            CFiltreData filtreCategories;

            if (element != null && !m_chkToutesCategories.Checked)
            {
                filtreCategories = new CFiltreDataAvance(
                    CCategorieGED.c_nomTable,
                    CRelationDocumentGED_Categorie.c_nomTable + "." +
                    CDocumentGED.c_nomTable + "." +
                    CRelationElementToDocument.c_nomTable + "." +
                    CRelationElementToDocument.c_champIdElement + " = @1 AND "+
                    CRelationDocumentGED_Categorie.c_nomTable + "." +
                    CDocumentGED.c_nomTable + "." +
                    CRelationElementToDocument.c_nomTable + "." +
                    CRelationElementToDocument.c_champTypeElement + " = @2",
                    element.Id,
                    element.GetType().ToString()
                    );
            }
            else
            {
                filtreCategories = null;
            }

            m_arbreCategories.AddRootForAll = true;
            m_arbreCategories.RootLabel = I.T("All categories|20246");
            CTreeViewNodeKeeper keeper = new CTreeViewNodeKeeper(m_arbreCategories);
            m_arbreCategories.Init(
                typeof(CCategorieGED),
                "CategoriesFilles",
                CCategorieGED.c_champIdParent,
                "Libelle",
                filtreCategories,
                null);

            m_arbreCategories.CheckBoxes = false;
            keeper.Apply(m_arbreCategories);

        }

        private bool m_bCmbArbreInitialisee = false;
        //------------------------------------------------------------------------------
        public void ReactualiserArbre()
        {

            m_bCmbArbreInitialisee = false;
            Type typeConsulte = null;
            CListeObjetsDonnees lst = new CListeObjetsDonnees(CSc2iWin32DataClient.ContexteCourant, typeof(CConsultationHierarchique));
            if (m_elementEdite != null)
            {
                lst.Filtre = new CFiltreData(CConsultationHierarchique.c_champTypeSource + " = @1",
                    m_elementEdite.GetType().ToString());
                typeConsulte = m_elementEdite.GetType();
            }
            else
            {
                lst.Filtre = new CFiltreData(CConsultationHierarchique.c_champTypeSource + " = @1", "");
            }
            m_cmbArbreHierarchique.Init(lst, "Libelle", true);
            m_cmbArbreHierarchique.AssureRemplissage();
            int nIdLastConsultationUtilisee = new CTimosAppRegistre().GetLastIdConsultationHierarchiqueForGED(typeConsulte);
            if (nIdLastConsultationUtilisee >= 0)
            {
                CConsultationHierarchique cslt = new CConsultationHierarchique(CSc2iWin32DataClient.ContexteCourant);
                if (cslt.ReadIfExists(nIdLastConsultationUtilisee))
                    m_cmbArbreHierarchique.ElementSelectionne = cslt;
            }
            if (m_cmbArbreHierarchique.ElementSelectionne == null && m_cmbArbreHierarchique.Items.Count > 0)
                m_cmbArbreHierarchique.SelectedIndex = 0;
            m_bCmbArbreInitialisee = true;
            m_panelConsultationHierarchique.Visible = lst.Count > 0;
        }

        private void m_cmbArbreHierarchique_SelectedValueChanged(object sender, EventArgs e)
        {
            CConsultationHierarchique consultation = m_cmbArbreHierarchique.ElementSelectionne as CConsultationHierarchique;
            if (consultation != null)
            {
                CFolderConsultationHierarchique racine = consultation.FolderRacine;
                if (m_elementEdite != null)
                {
                    CFolderConsultationRacineFromElement racineElt = racine as CFolderConsultationRacineFromElement;
                    racineElt.InitConsultation(m_elementEdite);
                }
                CTreeViewNodeKeeper keeper = new CTreeViewNodeKeeper(m_arbreConsultation);
                m_arbreConsultation.InitChamps(racine, CSc2iWin32DataClient.ContexteCourant, true);
                keeper.Apply(m_arbreConsultation);
                if (m_bCmbArbreInitialisee)
                {
                    Type typeConsulte = null;
                    if(m_elementEdite != null)
                        typeConsulte = m_elementEdite.GetType();
                    new CTimosAppRegistre().SetLastIdConsultationHierarchiqueForGED(typeConsulte, consultation.Id);
                }
            }
        }

        private void m_arbreConsultation_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Met à jour la liste des documents de GED de l'élmément sélectionné dans la hiérarchie

            CNodeConsultationHierarchique nodeHierarchique = e.Node.Tag as CNodeConsultationHierarchique;

            if (nodeHierarchique != null)
            {
                IObjetDonneeAIdNumerique donnee = nodeHierarchique.ObjetLie as IObjetDonneeAIdNumerique;

                if (donnee != null)
                {
                    if (!m_chkToutesCategories.Checked)
                        FillCategoriesForElement(donnee);
                    InitPanelList(donnee);

                }
                else
                    InitPanelList(m_elementEdite);

            }

        }

        private void m_chkTousDocuments_CheckedChanged(object sender, EventArgs e)
        {
            InitPanelList(m_elementSelectionne);
        }

        private void m_arbreCategories_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Quand on selectionne une catégorie de GED il faut filtrer la liste de documents sur la Categorie
            CCategorieGED categorieSelectionnee = m_arbreCategories.GetObjetInNode(e.Node) as CCategorieGED;
            if (categorieSelectionnee != null)
            {
                CFiltreData filtreSurCategorie = new CFiltreDataAvance(CDocumentGED.c_nomTable,
                    CRelationDocumentGED_Categorie.c_nomTable + "." +
                    CCategorieGED.c_nomTable + "." +
                    CCategorieGED.c_champCodeSystemeComplet + " LIKE @1",
                    categorieSelectionnee.CodeSystemeComplet + "%");
                m_filtreCategories = filtreSurCategorie;

                InitPanelList(m_elementSelectionne);

            }
            else
            {
                m_filtreCategories = null;
                InitPanelList(m_elementSelectionne);
            }

        }

        private void m_panelListDocumentsGED_AfterCreateFormEdition(object sender, sc2i.win32.data.navigation.CFormEditionStandard form)
        {
            if (form is CFormEditionDocumentGED)
                ((CFormEditionDocumentGED)form).ObjetAuquelAttacher = (CObjetDonneeAIdNumerique)m_elementSelectionne;
        }

        private void m_chkToutesCategories_CheckedChanged(object sender, EventArgs e)
        {
            FillCategoriesForElement(m_elementSelectionne);
        }


        //-------------------------------------------
        private void UpdateLabelDragDrop()
        {
            string strCategorie = I.T("None|20247");
            string strElement = I.T("None|20248");
            if (m_elementSelectionne != null)
                strElement = m_elementSelectionne.DescriptionElement;
            CCategorieGED categorie = m_arbreCategories.ElementSelectionne as CCategorieGED;
            if (categorie != null)
                strCategorie = categorie.Libelle;

            m_lblInfoDragDrop.Text = I.T("Documents will be associated to element '@1' in category '@2'|20249",
                strElement, strCategorie);

        }
                

        private void m_panelListDocumentsGED_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                UpdateLabelDragDrop();
                m_lblInfoDragDrop.Visible = true;
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void m_panelListDocumentsGED_DragLeave(object sender, EventArgs e)
        {
            m_lblInfoDragDrop.Visible = false;
        }

        private void m_panelListDocumentsGED_DragDrop(object sender, DragEventArgs e)
        {
            if ( e.Data.GetDataPresent ( DataFormats.FileDrop ) )
            {
                DragDropFiles((string[])e.Data.GetData(DataFormats.FileDrop), m_elementSelectionne as CObjetDonneeAIdNumerique, m_arbreCategories.ElementSelectionne as CCategorieGED);
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void DragDropFiles(string[] strFichiers, CObjetDonneeAIdNumerique objet, CCategorieGED categorie)
        {
            CContexteDonnee ctxAppli = CSc2iWin32DataClient.ContexteCourant;
            using (CContexteDonnee contexte = ctxAppli.GetContexteEdition())
            {
                if (MessageBox.Show(m_lblInfoDragDrop.Text, "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    foreach (string strFichier in strFichiers)
                    {
                        if (File.Exists(strFichier))
                        {
                            string strTitre = Path.GetFileName(strFichier);
                            string strExt = Path.GetExtension(strFichier);
                            if (strExt.Length > 0)
                                strTitre = strTitre.Remove(strTitre.Length - strExt.Length);
                            CDocumentGED document = new CDocumentGED(contexte);
                            document.CreateNewInCurrentContexte();
                            document.Libelle = strTitre;
                            if (objet != null)
                                document.AssocieA(objet);
                            if (categorie != null)
                            {
                                CRelationDocumentGED_Categorie rel = new CRelationDocumentGED_Categorie(contexte);
                                rel.CreateNewInCurrentContexte();
                                rel.Categorie = categorie;
                                rel.Document = document;
                            }
                            CTypeReferenceDocument typeRef = m_cmbModeStockage.SelectedValue as CTypeReferenceDocument;
                            if (typeRef == null)
                                typeRef = new CTypeReferenceDocument(CTypeReferenceDocument.TypesReference.Fichier);
                            CProxyGED proxy = new CProxyGED(contexte.IdSession, typeRef.Code);
                            proxy.AttacheToLocal(strFichier);
                            CResultAErreur result = proxy.UpdateGed();
                            document.ReferenceDoc = result.Data as CReferenceDocument;
                        }
                    }
                    contexte.CommitEdit();
                    Init(m_elementEdite);
                }
            }
            m_lblInfoDragDrop.Visible = false;
        }

        
        //-------------------------------------------------------------------------
        private void m_arbreCategories_DragEnter(object sender, DragEventArgs e)
        {
            if (DragDataHasDocGed(e.Data))
            {
                if ((e.KeyState & 8)==8)//control
                    e.Effect = DragDropEffects.Copy;
                else
                    e.Effect = DragDropEffects.Move;
            }
            else
                e.Effect = DragDropEffects.None;
        }

        //-------------------------------------------------------------------------
        private bool DragDataHasDocGed(IDataObject iDataObject)
        {
            CReferenceObjetDonnee[] refs = iDataObject.GetData(typeof(CReferenceObjetDonnee[])) as CReferenceObjetDonnee[];
            if ( refs != null && refs.FirstOrDefault(o=>o.TypeObjet == typeof(CDocumentGED))!=null )
                return true;
            return false;
        }

        //-------------------------------------------------------------------------
        private void m_arbreCategories_DragLeave(object sender, EventArgs e)
        {
            HightlightCategorie(null);
        }

        //-------------------------------------------------------------------------
        TreeNode m_lastNodeCategorie = null;
        private void HightlightCategorie(TreeNode node)
        {
            if (m_lastNodeCategorie != null)
            {
                try
                {
                    m_lastNodeCategorie.BackColor = m_arbreCategories.BackColor; ;
                }
                catch { }
            }
            m_lastNodeCategorie = node;
            if (node != null)
            {
                node.BackColor = Color.LightBlue;
            }
        }

        //-------------------------------------------------------------------------
        private void m_arbreCategories_DragOver(object sender, DragEventArgs e)
        {
            if (DragDataHasDocGed(e.Data))
            {
                if ((e.KeyState & 8) == 8)//control
                    e.Effect = DragDropEffects.Copy;
                else
                    e.Effect = DragDropEffects.Move;
                 TreeViewHitTestInfo info = m_arbreCategories.HitTest(m_arbreCategories.PointToClient(new Point(e.X, e.Y)));
                 if (info != null && info.Node != null && m_arbreCategories.GetObjetInNode ( info.Node ) is CCategorieGED)
                     HightlightCategorie(info.Node);
                 else
                 {
                     HightlightCategorie(null);
                     e.Effect = DragDropEffects.None;
                 }
                     
            }
            else
                e.Effect = DragDropEffects.None;
        }

        //-------------------------------------------------------------------------
        private void m_arbreCategories_DragDrop(object sender, DragEventArgs e)
        {
            if (DragDataHasDocGed(e.Data))
            {
                using (CContexteDonnee ctx = CSc2iWin32DataClient.ContexteCourant.GetContexteEdition())
                {
                    bool bAddCategorie = (e.KeyState & 8) == 8;
                    TreeViewHitTestInfo info = m_arbreCategories.HitTest(m_arbreCategories.PointToClient(new Point(e.X, e.Y)));
                    TreeNode node = info.Node;
                    if (info != null && info.Node != null && m_arbreCategories.GetObjetInNode(info.Node) is CCategorieGED)
                    {
                        CCategorieGED categorie = m_arbreCategories.GetObjetInNode(info.Node) as CCategorieGED;
                        foreach (CReferenceObjetDonnee refDoc in (CReferenceObjetDonnee[])e.Data.GetData(typeof(CReferenceObjetDonnee[])))
                        {
                            CDocumentGED doc = refDoc.GetObjet(ctx) as CDocumentGED;
                            if (doc != null)
                            {
                                if (!bAddCategorie)//Supprime les anciennes catégories
                                {
                                    CListeObjetsDonnees lst = doc.RelationsCategories;
                                    CObjetDonneeAIdNumerique.Delete(lst, true);
                                }
                                bool bDedans = false;
                                foreach (CRelationDocumentGED_Categorie rel in doc.RelationsCategories)
                                {
                                    if (rel.Categorie.Id == categorie.Id)
                                    {
                                        bDedans = true;
                                        break;
                                    }

                                }
                                if (!bDedans)
                                {
                                    CRelationDocumentGED_Categorie newRel = new CRelationDocumentGED_Categorie(ctx);
                                    newRel.CreateNewInCurrentContexte();
                                    newRel.Categorie = categorie;
                                    newRel.Document = doc;
                                }
                            }
                        }
                    }
                    CResultAErreur result = ctx.CommitEdit();
                    if (!result)
                        CFormAfficheErreur.Show(result.Erreur);
                    else
                        InitPanelList(m_elementSelectionne);
                }
            }
            HightlightCategorie(null);
        }

        private void m_arbreConsultation_DragEnter(object sender, DragEventArgs e)
        {
            if (DragDataHasDocGed(e.Data))
            {
                if ((e.KeyState & 8) == 8)//control
                    e.Effect = DragDropEffects.Copy;
                else
                    e.Effect = DragDropEffects.Move;
            }
            else
                e.Effect = DragDropEffects.None;
        }

        private void m_arbreConsultation_DragLeave(object sender, EventArgs e)
        {
            HightlightElementDeArbre(null);
        }

        private void m_arbreConsultation_DragOver(object sender, DragEventArgs e)
        {
            if (DragDataHasDocGed(e.Data))
            {
                if ((e.KeyState & 8) == 8)//control
                    e.Effect = DragDropEffects.Copy;
                else
                    e.Effect = DragDropEffects.Move;
                TreeViewHitTestInfo info = m_arbreConsultation.HitTest(m_arbreConsultation.PointToClient(new Point(e.X, e.Y)));
                if (info != null && info.Node != null && info.Node.Tag is CNodeConsultationHierarchique &&
                        ((CNodeConsultationHierarchique)info.Node.Tag).ObjetLie is CObjetDonneeAIdNumerique)
                    HightlightElementDeArbre(info.Node);
                else
                {
                    HightlightElementDeArbre(null);
                    e.Effect = DragDropEffects.None;
                }

            }
            else
                e.Effect = DragDropEffects.None;
        }

        private void m_arbreConsultation_DragDrop(object sender, DragEventArgs e)
        {
            if (DragDataHasDocGed(e.Data))
            {
                using (CContexteDonnee ctx = CSc2iWin32DataClient.ContexteCourant.GetContexteEdition())
                {
                    bool bAddElement = (e.KeyState & 8) == 8;
                    TreeViewHitTestInfo info = m_arbreConsultation.HitTest(m_arbreConsultation.PointToClient(new Point(e.X, e.Y)));
                    TreeNode node = info.Node;
                    if (info != null && info.Node != null && info.Node.Tag is CNodeConsultationHierarchique && 
                        ((CNodeConsultationHierarchique)info.Node.Tag).ObjetLie is CObjetDonneeAIdNumerique)
                    {
                        CObjetDonneeAIdNumerique objetAId = ((CNodeConsultationHierarchique)info.Node.Tag).ObjetLie as CObjetDonneeAIdNumerique;
                        foreach (CReferenceObjetDonnee refDoc in (CReferenceObjetDonnee[])e.Data.GetData(typeof(CReferenceObjetDonnee[])))
                        {
                            CDocumentGED doc = refDoc.GetObjet(ctx) as CDocumentGED;
                            if (doc != null)
                            {
                                if (!bAddElement)//Supprime les anciennes catégories
                                {
                                    StringBuilder bl = new StringBuilder();
                                    foreach (CRelationElementToDocument rel in doc.RelationsElements)
                                    {
                                        if (rel.ElementLie != null)
                                        {
                                            bl.Append("-");
                                            bl.Append(rel.ElementLie.DescriptionElement);
                                            bl.Append(System.Environment.NewLine);
                                        }
                                    }
                                    if (bl.Length > 0)
                                    {
                                        if (CFormAlerte.Afficher(I.T("This operation will remove association to \r\n@1 and add an association to @2. Continue ?|20475",
                                            bl.ToString(),
                                            objetAId.DescriptionElement), EFormAlerteType.Question) == DialogResult.No)
                                        {
                                            HightlightElementDeArbre(null); 
                                            e.Effect = DragDropEffects.None;
                                            return;
                                        }
                                    }


                                    CListeObjetsDonnees lst = doc.RelationsElements;
                                    CObjetDonneeAIdNumerique.Delete(lst, true);
                                }
                                doc.AssocieA(objetAId);
                            }
                        }
                    }
                    CResultAErreur result = ctx.CommitEdit();
                    if (!result)
                        CFormAlerte.Afficher(result.Erreur);
                    else
                        InitPanelList(m_elementSelectionne);
                }
            }
            HightlightElementDeArbre(null);
        }

        //-------------------------------------------------------------------------
        TreeNode m_lastNodeElementDeArbre = null;
        private void HightlightElementDeArbre(TreeNode node)
        {
            if (m_lastNodeElementDeArbre != null)
            {
                try
                {
                    m_lastNodeElementDeArbre.BackColor = m_arbreConsultation.BackColor; ;
                }
                catch { }
            }
            m_lastNodeElementDeArbre = node;
            if (node != null)
            {
                node.BackColor = Color.LightBlue;
            }
        }

        private void m_lnkDissocierElementEnCours_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (m_elementSelectionne != null)
            {
                List<string> listeIdsDocuments = new List<string>();
                foreach (CDocumentGED document in m_panelListDocumentsGED.ElementsSelectionnes)
                {
                    listeIdsDocuments.Add(document.Id.ToString());   
                }
                int nbSelectionne = listeIdsDocuments.Count();
                if (nbSelectionne == 0)
                    CFormAlerte.Afficher(I.T("No Document selected to dissociate|10334"));
                else
                {
                    DialogResult reponse = CFormAlerte.Afficher(I.T("Dissociate @1 document(s) from '@2'. Do you Confirm?|10335", nbSelectionne.ToString(), m_elementSelectionne.DescriptionElement), EFormAlerteType.Question);
                    if (reponse == DialogResult.Yes)
                    {
                        using (CContexteDonnee ctx = CSc2iWin32DataClient.ContexteCourant.GetContexteEdition())
                        {
                            CListeObjetsDonnees listeRelationsASupprimer = new CListeObjetsDonnees(ctx, typeof(CRelationElementToDocument));
                            listeRelationsASupprimer.Filtre = new CFiltreData(
                                    CRelationElementToDocument.c_champTypeElement + " = @1 AND " +
                                    CRelationElementToDocument.c_champIdElement + " = @2 AND " +
                                    CDocumentGED.c_champId + " in (" + string.Join(",", listeIdsDocuments.ToArray()) + ")",
                                    m_elementSelectionne.GetType().ToString(),
                                    m_elementSelectionne.Id);
                            
                            if (listeRelationsASupprimer.Count > 0)
                                CObjetDonneeAIdNumerique.Delete(listeRelationsASupprimer, true);

                            CResultAErreur result = ctx.CommitEdit();
                            if (!result)
                                CFormAlerte.Afficher(result.Erreur);
                            else
                                InitPanelList(m_elementSelectionne);

                        }
                    }
                }

            }

        }

        //--------------------------------------------------------------------------
        private void m_lblDragExisting_DragEnter(object sender, DragEventArgs e)
        {
            CReferenceObjetDonnee[] refs = e.Data.GetData(typeof(CReferenceObjetDonnee[]))as CReferenceObjetDonnee[];
            CReferenceObjetDonnee ref1 = e.Data.GetData(typeof(CReferenceObjetDonnee)) as CReferenceObjetDonnee;
            if (ref1 != null)
            {
                List<CReferenceObjetDonnee> lst = new List<CReferenceObjetDonnee>();
                lst.Add(ref1);
                refs = lst.ToArray();
            }
            if ( refs!= null && refs.Length > 0 )
            {
                foreach ( CReferenceObjetDonnee refO in refs )
                {
                    if (refO.TypeObjet == typeof(CDocumentGED))
                    {
                        e.Effect = DragDropEffects.Link;
                        return;
                    }
                }
            }
            e.Effect = DragDropEffects.None;
        }

        //--------------------------------------------------------------------------
        private void m_lblDragExisting_DragDrop(object sender, DragEventArgs e)
        {
            if (m_elementEdite != null)
            {
                CReferenceObjetDonnee[] refs = e.Data.GetData(typeof(CReferenceObjetDonnee[])) as CReferenceObjetDonnee[];
                CReferenceObjetDonnee ref1 = e.Data.GetData(typeof(CReferenceObjetDonnee)) as CReferenceObjetDonnee;
                if (ref1 != null)
                {
                    List<CReferenceObjetDonnee> lst = new List<CReferenceObjetDonnee>();
                    lst.Add(ref1);
                    refs = lst.ToArray();
                }
                CObjetDonneeAIdNumerique obj = m_elementEdite as CObjetDonneeAIdNumerique;
                if (obj != null && refs != null)
                {
                    using (CContexteDonnee ctx = new CContexteDonnee(obj.ContexteDonnee.IdSession, true, false))
                    {
                        obj = obj.GetObjetInContexte(ctx) as CObjetDonneeAIdNumerique;
                        foreach (CReferenceObjetDonnee refObj in refs)
                        {
                            CDocumentGED doc = refObj.GetObjet(ctx) as CDocumentGED;
                            if (doc != null)
                            {
                                doc.AssocieA(obj);
                            }
                        }
                        CResultAErreur result = ctx.SaveAll(true);
                        if (!result)
                            CFormAlerte.Afficher(result.Erreur);
                        else
                        {
                            Init(m_elementEdite);
                        }
                    }
                }
            }


        }



    }
}
