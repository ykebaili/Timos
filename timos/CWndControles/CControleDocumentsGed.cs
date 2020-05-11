using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.documents;
using sc2i.win32.common;
using sc2i.common;
using sc2i.data;
using System.IO;
using timos.Properties;
using System.Collections;
using sc2i.formulaire;
using sc2i.expression;

namespace timos.CWndControles
{
    public partial class CControleDocumentsGed : UserControl, IControlALockEdition
    {
        private List<CDocumentGED> m_listeDocuments = new List<CDocumentGED>();
        private List<CNouveauDoc> m_listeNouveauxDocs = new List<CNouveauDoc>();
        private List<CDocumentGED> m_listeDocsToRemove = new List<CDocumentGED>();
        private C2iWndDocumentsGed m_wndDocuments = null;
        private CContexteDonnee m_contexteDonnee = null;
        private CObjetDonnee m_source = null;
        private IFournisseurProprietesDynamiques m_fournisseurProprietes = null;

        //-------------------------------------------
        private class CNouveauDoc
        {
            public CDocumentGED Document { get; set; }
            public string NomFichier { get; set; }

            //-------------------------------------------
            public CNouveauDoc(CDocumentGED document, string strNomFichier)
            {
                Document = document;
                NomFichier = strNomFichier;
            }
        }

        //-------------------------------------------
        public CControleDocumentsGed()
        {
            InitializeComponent();
        }

        //-------------------------------------------
        public void Init(C2iWndDocumentsGed wndDoc, CObjetDonnee source, IFournisseurProprietesDynamiques fournisseurProprietes)
        {
            m_wndDocuments = wndDoc;
            m_listeDocuments.Clear();
            m_listeNouveauxDocs.Clear();
            m_listeDocsToRemove.Clear();
            m_source = source;
            m_fournisseurProprietes = fournisseurProprietes;
            if (m_wndDocuments != null && source != null)
            {
                m_contexteDonnee = source.ContexteDonnee;
                IEnumerable<CDocumentGED> lstDocs = m_wndDocuments.GetDocuments(source);
                m_listeDocuments.AddRange(lstDocs);
            }
            UpdateVisuel();
        }

        //-------------------------------------------
        private CProxyGED m_proxyVisu = null;
        private void UpdateVisuel()
        {
            m_picDocument.Visible = !m_wndDocuments.HideHeader;
            this.SuspendDrawing();
            bool bPreviewVisible = false;
            if ( m_listeDocuments.Count == 1 && m_wndDocuments.DisplayDocuments )
            {
                CDocumentGED doc = m_listeDocuments[0];
                if ( m_proxyVisu != null )
                {
                    m_proxyVisu.Dispose();
                    m_proxyVisu = null;
                }
                m_proxyVisu = new CProxyGED(doc.ContexteDonnee.IdSession, doc.ReferenceDoc);
                if ( !m_proxyVisu.CopieFichierEnLocal() )
                {
                    m_proxyVisu.Dispose();
                    m_proxyVisu = null;
                }
                else
                {
                    if ( m_visualiseurGed.ShowDocument ( m_proxyVisu.NomFichierLocal ) )
                    {
                        
                        m_lblDocument.Visible = false;
                        m_visualiseurGed.Dock = DockStyle.Fill;
                        m_visualiseurGed.Visible = true;
                        bPreviewVisible = true;
                    }
                }

            }
            if (!bPreviewVisible)
            {
                m_visualiseurGed.Visible = false;
                m_lblDocument.Visible = true;
                bool bShowLabel = m_listeDocuments.Count == 1 && m_listeDocuments[0].Libelle.Length > 0;
                if (bShowLabel)
                    m_lblDocument.Text = m_listeDocuments[0].Libelle;
                else
                {
                    if (m_listeDocuments.Count == 0)
                        m_lblDocument.Text = I.T("No document|20758");
                    else m_lblDocument.Text = I.T("@1 document(s)|20759", m_listeDocuments.Count.ToString());
                }
            }
            this.ResumeDrawing();
        }

        #region IControlALockEdition Membres
        //-------------------------------------------
        public bool LockEdition
        {
            get
            {
                return !m_extModeEdition.ModeEdition;
            }
            set
            {
                m_extModeEdition.ModeEdition = !value;
                m_btnAttacher.Visible = !value;
                if (OnChangeLockEdition != null)
                    OnChangeLockEdition(this, null);
            }
        }

        //-------------------------------------------
        public event EventHandler OnChangeLockEdition;

        #endregion

        //--------------------------------------------------------------------------------
        public CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;
            foreach (CNouveauDoc nouveau in m_listeNouveauxDocs.ToArray())
            {
                CProxyGED proxy = new CProxyGED(nouveau.Document.ContexteDonnee.IdSession, CTypeReferenceDocument.TypesReference.Fichier);
                proxy.AttacheToLocal(nouveau.NomFichier);
                result = proxy.UpdateGed();
                if (!result)
                    return result;
                CReferenceDocument refDoc = result.Data as CReferenceDocument;
                nouveau.Document.ReferenceDoc = refDoc;
                m_listeNouveauxDocs.Remove(nouveau);
            }
            foreach (CDocumentGED doc in m_listeDocsToRemove)
            {
                doc.Delete(true);
            }
            return result;
        }

        //-------------------------------------------------------------------------------
        private string m_strFileToAdd = "";
        private void AddFile(string strNomFichier)
        {
            if (m_extModeEdition.ModeEdition && m_wndDocuments != null)
            {
                m_strFileToAdd = strNomFichier;
                IEnumerable<CCategorieGED> lstCats = m_wndDocuments.GetListeCategories(m_source);
                if ( lstCats.Count() == 1 && m_wndDocuments.IncludeSubCategories )
                {
                    ContextMenuStrip menu = new ContextMenuStrip();
                    AddMenuCategorie ( lstCats.ElementAt(0), menu.Items );
                    if ( menu.Items.Count >= 1 )
                    {
                        menu.Show (this, new Point ( 0, this.Height/2 ) );
                        return;
                    }
                }
                AddDoc(strNomFichier, lstCats);
            }
        }

        //--------------------------------------------------------------------------------
        private void AddMenuCategorie ( CCategorieGED cat, ToolStripItemCollection items )
        {
            ToolStripMenuItem menuCategorie = new ToolStripMenuItem ( cat.Libelle);
            menuCategorie.Tag = cat;
            menuCategorie.MouseDown += new MouseEventHandler(menuCategorie_MouseDown);
            items.Add ( menuCategorie );
            if (cat.CategoriesFilles.Count > 0)
                menuCategorie.ToolTipText = I.T("Right clic to affect to @1|20870", cat.Libelle);
            foreach ( CCategorieGED subCat in cat.CategoriesFilles )
                AddMenuCategorie ( subCat, menuCategorie.DropDownItems );

        }

        //------------------------------------------------------------------------------
        void  menuCategorie_MouseDown(object sender, MouseEventArgs e)
        {
 	        ToolStripMenuItem item = sender as ToolStripMenuItem;
            CCategorieGED cat = item != null ? item.Tag as CCategorieGED : null;
            if (cat != null)
            {
                if (item.DropDownItems.Count == 0 || (e.Button & MouseButtons.Right) == MouseButtons.Right)
                {
                    if (item.DropDown != null)
                        item.DropDown.Close();

                    AddDoc(m_strFileToAdd, new CCategorieGED[] { cat });
                }
            }
        }

        //--------------------------------------------------------------------------------
        private void AddDoc(string strNomFichier, IEnumerable<CCategorieGED> lstCats )
        {
            CDocumentGED doc = new CDocumentGED(m_contexteDonnee);
            doc.CreateNewInCurrentContexte();
            doc.Libelle = Path.GetFileName(strNomFichier);
            foreach (CObjetDonneeAIdNumerique objet in m_wndDocuments.GetListeAssociations(m_source))
                doc.AssocieA(objet);
            foreach (CCategorieGED categorie in lstCats)
                doc.AddCategory(categorie);

            C2iWndDocumentsGed.CInfoAffectationDocumentToGed info = new C2iWndDocumentsGed.CInfoAffectationDocumentToGed(strNomFichier, m_source);
            CContexteEvaluationExpression ctx = new CContexteEvaluationExpression(info);
            foreach (CAffectationsProprietes aff in m_wndDocuments.Affectations)
            {
                CResultAErreur result = CResultAErreur.True;
                result.Data = true;
                if (aff.FormuleCondition != null)
                {
                    result = aff.FormuleCondition.Eval(ctx);
                }
                if (result && result.Data is bool && (bool)result.Data)
                {
                    result = aff.AffecteProprietes(doc, info, m_fournisseurProprietes);
                    if (!result)
                    {
                        result.EmpileErreur(I.T("Some values cannot be assigned to EDM Document"));
                        CFormAfficheErreur.Show(result.Erreur);
                    }
                }
            }

            CNouveauDoc nouveauDoc = new CNouveauDoc(doc, strNomFichier);
            m_listeDocuments.Add(doc);
            m_listeNouveauxDocs.Add(nouveauDoc);
            UpdateVisuel();
        }

        //----------------------------------------------------------------------------------
        private void InitAffectations(CDocumentGED document)
        {
            

        }

        //----------------------------------------------------------------------------------
        private void m_lblDocument_DragEnter(object sender, DragEventArgs e)
        {
            if (m_extModeEdition.ModeEdition && e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        //----------------------------------------------------------------------------------
        private void m_lblDocument_DragDrop(object sender, DragEventArgs e)
        {
            if (m_extModeEdition.ModeEdition && e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] strFiles = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string strFile in strFiles)
                {
                    AddFile(strFile);
                }
            }
        }

        //-------------------------------------------
        private bool m_bAvecDelete = false;
        private void ShowMenu(bool bAvecDelete)
        {
            m_bAvecDelete = bAvecDelete;
            foreach (ToolStripMenuItem item in new ArrayList(m_menu.Items))
            {
                m_menu.Items.Remove(item);
                item.Dispose();
            }
            foreach (CDocumentGED document in m_listeDocuments)
            {
                ToolStripMenuItem itemDocument = new ToolStripMenuItem(document.Libelle);
                itemDocument.Tag = document;
                if (!LockEdition && bAvecDelete)
                    itemDocument.Image = Resources.delete;
                m_menu.Items.Add(itemDocument);
                itemDocument.MouseUp += new MouseEventHandler(itemDocument_MouseUp);
            }
            if (m_menu.Items.Count > 0)
                m_menu.Show(m_lblDocument, new Point(0, m_lblDocument.Height));

        }

        void itemDocument_MouseUp(object sender, MouseEventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            CDocumentGED document = item != null ? item.Tag as CDocumentGED : null;
            if (document == null)
                return;
            if (LockEdition || !m_bAvecDelete)
            {
                if (document.IsNew())
                    return;
                CTimosApp.Navigateur.EditeElement(document, false, "");
            }
            else
            {
                if (CFormAlerte.Afficher(I.T("Delete document @1?|20761",document.Libelle),
                    EFormAlerteBoutons.OuiNon, EFormAlerteType.Question) == DialogResult.Yes)
                {
                    m_listeDocsToRemove.Add(document);
                    m_listeDocuments.Remove(document);
                    foreach (CNouveauDoc nouveau in m_listeNouveauxDocs.ToArray())
                    {
                        if (nouveau.Document == document)
                            m_listeNouveauxDocs.Remove(nouveau);
                    }
                    UpdateVisuel();
                }
            }
        }

        //-------------------------------------------
        private void m_lblDocument_MouseUp(object sender, MouseEventArgs e)
        {
            ShowMenu(e.Button == MouseButtons.Right);
        }

        private void m_btnAttacher_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = I.T("All files|*.*|20760");

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                AddFile(dlg.FileName);
            }
        }
    }
}
