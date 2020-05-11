using sc2i.common;
using sc2i.data;
using sc2i.data.dynamic;
using sc2i.documents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using timos.data;

namespace ImportDocsMyanmar
{
    public partial class CFormMain : Form
    {
        private CRepertoire m_dossierRacine = null;
        private Dictionary<string, CProjet> m_dicNominalCodeToProjet = new Dictionary<string, CProjet>();

        public CFormMain()
        {
            InitializeComponent();

            if (CImportMyanmarConst.SessionClient != null)
            {
                CListeObjetDonneeGenerique<CProjet> lst = new CListeObjetDonneeGenerique<CProjet>(CImportMyanmarConst.ContexteDonnee);
                lst.Filtre = new CFiltreData(
                    CTypeProjet.c_champId + "=@1", 4);
                CUtilElementAChamps.ReadChampsCustom(lst, 2567);
                foreach (CProjet projet in lst)
                {
                    string strVal = projet.GetValeurChamp(2567) as string;
                    if (strVal != null && strVal.Length > 0)
                        m_dicNominalCodeToProjet[strVal] = projet;
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        
        private void m_btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string strRepRacine = dlg.SelectedPath;
                m_dossierRacine = new CRepertoire();
                m_dossierRacine.FillFrom(strRepRacine);
                FillTree();
            }
        }

        private void FillTree()
        {

            m_arbre.BeginUpdate();
            m_arbre.Nodes.Clear();
            TreeNode node = new TreeNode();
            FillNode(node, m_dossierRacine);
            
            m_arbre.Nodes.Add(node);
            node.Expand();
            m_arbre.EndUpdate();
        }

        private void FillNode(TreeNode node, CRepertoire dossier)
        {
            node.Text = dossier.Nom;
            node.ImageIndex = GetIndexImageDossier(dossier);
            node.SelectedImageIndex = node.ImageIndex;
            node.Tag = dossier;
            if ( node.Nodes.Count == 0 && dossier.GetChilds<CRepertoire>().Count() > 0)
                node.Nodes.Add(new TreeNode());
        }

        private void FillFichiers(CRepertoire dossier)
        {
            m_wndListeFichiers.BeginUpdate();
            m_wndListeFichiers.Items.Clear();
            List<CRepertoire> dossiers = new List<CRepertoire>(from e in dossier.ElementsContenus
                                                         where e is CRepertoire
                                                         select e as CRepertoire);
            dossiers.Sort((x, y) => x.Nom.CompareTo(y.Nom));
            foreach (CRepertoire dossierFils in dossiers)
            {
                if (ShoudSeeDossier(dossierFils))
                {
                    ListViewItem item = new ListViewItem();
                    FillItem(item, dossierFils);
                    m_wndListeFichiers.Items.Add(item);
                }
            }

            List<CFichier> fichiers = new List<CFichier>(from e in dossier.ElementsContenus
                                                         where e is CFichier
                                                         select e as CFichier);
            fichiers.Sort((x, y) => x.Nom.CompareTo(y.Nom));
            foreach (CFichier fichier in fichiers)
            {
                ListViewItem item = new ListViewItem();
                FillItem(item, fichier);
                m_wndListeFichiers.Items.Add(item);
            }
            m_wndListeFichiers.EndUpdate();
        }

        private void FillItem(ListViewItem item, CRepertoire dossier)
        {
            item.Text = dossier.Nom;
            item.ImageIndex = GetIndexImageDossier(dossier);
            item.StateImageIndex = item.ImageIndex;
            item.Tag = dossier;
        }

        private void FillItem(ListViewItem item, CFichier fichier)
        {
            item.Text = fichier.Nom;
            item.SubItems.Add(fichier.Size.ToString());
            item.SubItems.Add(fichier.LastModifDate.ToString("G"));
            item.ImageIndex = GetIndexImageFichier(fichier);
            item.StateImageIndex = item.ImageIndex;
            item.Tag = fichier;
        }

        //-----------------------------------------------------------------------------------------
        private void RefreshNode ( TreeNode node )
        {
            CRepertoire dossier = node.Tag as CRepertoire;
            if (dossier != null)
                FillNode(node, dossier);
            foreach (TreeNode child in node.Nodes)
                RefreshNode(child);
        }

        //-----------------------------------------------------------------------------------------
        public int GetIndexImageDossier ( CRepertoire repertoire )
        {
            if (!repertoire.ImportDone)
                return 0;
            else if (repertoire.HasErreurImport())
                return 4;
            return 2;
        }

        private int GetIndexImageFichier ( CFichier fichier )
        {
            if (fichier.HasErreurImport())
                return 5;
            else if (fichier.KeyObjetAssocie != null)
                return 3;
            else
                return 1;
        }

        //-----------------------------------------------------------------------------------------
        private Thread m_threadImport = null;
        private bool m_bCancelThreadRequest = false;
        private void ImportAllInThread()
        {
            if (m_threadImport != null)
                return;
            m_bCancelThreadRequest = false;
            m_progressBar.Visible = true;
            m_threadImport = new Thread(ImportInThread);
            m_threadImport.Start();
        }

        private void ImportInThread(object state)
        {
            if ( m_arbre.Nodes.Count == 1 )
            {
                Invoke((MethodInvoker)delegate
                { m_progressBar.Minimum = 0;
                m_progressBar.Maximum = m_arbre.Nodes[0].Nodes.Count;
                });
                int nNbDone = 0;
                foreach (TreeNode node in m_arbre.Nodes[0].Nodes)
                {
                    if (m_bCancelThreadRequest)
                        break;
                    ImportNode(node, true);
                    nNbDone++;
                    Invoke((MethodInvoker)delegate
                    {
                        m_progressBar.Value = nNbDone;
                    });
                }
            }
            Invoke((MethodInvoker)delegate
            {
                m_progressBar.Visible = false;
            });
            m_threadImport = null;
        }


        //-----------------------------------------------------------------------------------------
        private void m_arbre_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node != null && e.Node.Nodes.Count == 1 && e.Node.Nodes[0].Tag == null)
            {
                FillChildrens(e.Node);
            }
        }

        private void FillChildrens(TreeNode nodeToFill)
        {
            m_arbre.BeginUpdate();
            nodeToFill.Nodes.Clear();
            CRepertoire dossier = nodeToFill.Tag as CRepertoire;
            List<CRepertoire> dossiers = new List<CRepertoire>(dossier.GetChilds<CRepertoire>());
            dossiers.Sort((x, y) => x.Nom.CompareTo(y.Nom));
            foreach (CRepertoire dossierFils in dossiers)
            {
                if (ShoudSeeDossier(dossierFils))
                {
                    TreeNode node = new TreeNode();
                    FillNode(node, dossierFils);
                    nodeToFill.Nodes.Add(node);
                }
            }
            m_arbre.EndUpdate();
        }

        private void m_arbre_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            
        }

        private bool ShoudSeeDossier ( CRepertoire dossier )
        {
            bool bResult = true;
            if (m_chkHideDirsWithoutFiles.Checked)
                bResult  &= dossier.HasFiles;
            if (m_chkShowErrors.Checked)
                bResult &= (dossier.HasErreurImport());
            return bResult;
        }

        private void m_wndListeFichiers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = m_wndListeFichiers.HitTest(e.X, e.Y);
            if (info.Item != null)
            {
                CRepertoire dossier = info.Item.Tag as CRepertoire;
                TreeNode node = m_arbre.SelectedNode;
                if (node != null)
                {
                    node.Expand();
                    foreach (TreeNode child in node.Nodes)
                        if (child.Tag == dossier)
                        {
                            m_arbre.SelectedNode = child;
                            break;
                        }
                }
            }
        }

        private void m_btnSave_Click(object sender, EventArgs e)
        {
            if (m_arbre.Nodes.Count == 0)
                return;
            CRepertoire dossier = m_arbre.Nodes[0].Tag as CRepertoire;
            if (dossier != null)
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "External explorer file|*.extExp|All files|*.*";
                if (dlg.ShowDialog() == DialogResult.OK)
                {

                    CResultAErreur result = CSerializerObjetInFile.SaveToFile(dossier,
                        "EXTERNAL_EXPLORER",
                        dlg.FileName
                        );
                    if (result)
                        MessageBox.Show("Save ok");
                    else
                        MessageBox.Show(result.Erreur.ToString());
                }
            }
        }

        private void m_btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "External explorer file|*.extExp|All files|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                DateTime dt = DateTime.Now;
                CRepertoire dossier = new CRepertoire();
                CResultAErreur result = CSerializerObjetInFile.ReadFromFile(dossier,
                    "EXTERNAL_EXPLORER",
                    dlg.FileName);
                TimeSpan sp = DateTime.Now - dt;
                
                if (result)
                {
                    m_dossierRacine = dossier;
                    FillTree();
                }
                else
                    MessageBox.Show(result.Erreur.ToString());

            }
        }

        private void m_arbre_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null && e.Node.Tag is CRepertoire)
                FillFichiers(e.Node.Tag as CRepertoire);
            ShowInfos(e.Node.Tag as CRepertoire);
        }

        private void m_chkHideDirsWithoutFiles_CheckedChanged(object sender, EventArgs e)
        {
            FillTree();
        }

        private void m_menuImporterRepertoire_Click(object sender, EventArgs e)
        {
            TreeNode node = m_arbre.SelectedNode;
            if (node.Parent == null)
                ImportAllInThread();
            else
                ImportNode(node, false);
        }

        private CResultAErreur ImportNode(TreeNode node, bool bOnlyNonFaits)
        {
            CResultAErreur result = CResultAErreur.True;
            if (node != null && node.Tag is CRepertoire)
            {
                CRepertoire repertoire = node.Tag as CRepertoire;
                if (!bOnlyNonFaits || !repertoire.ImportDone)
                {
                    CProjet projetNominal = null;
                    if (m_dicNominalCodeToProjet.TryGetValue(repertoire.Nom, out projetNominal))
                    {
                        CImporteurGED importeur = new CImporteurGED();
                        projetNominal.BeginEdit();
                        CDocumentGED.DesactiverControleDocumentsALaSauvegarde(projetNominal.ContexteDonnee, true);
                        result = importeur.ImporteDossierProjet(
                            projetNominal,
                            repertoire,
                            "2014\\8\\IMPORT\\" + repertoire.Nom);
                        if (result)
                            result = projetNominal.CommitEdit();
                        Invoke((MethodInvoker)delegate
                        {
                            RefreshNode(node);
                        });
                        if (!result)
                        {
                            projetNominal.CancelEdit();
                            return result;
                        }
                    }
                }

            }
            return result;
        }

        private void m_menuArbre_Opening(object sender, CancelEventArgs e)
        {
            ContextMenuStrip strip = sender as ContextMenuStrip;
            m_menuImporterRepertoire.Enabled = false;
            m_menuCancelImport.Visible = m_threadImport != null;
            m_menuClearImportInformations.Enabled = false;
            if ( strip != null && strip.SourceControl == m_arbre && m_lastNodeClicked != null)
            {
                
                TreeNode node = m_lastNodeClicked;
                m_arbre.SelectedNode = m_lastNodeClicked;
                m_menuImporterRepertoire.Enabled = node != null && node.Parent != null &&
                    node.Parent.Parent == null || node.Parent == null;
                m_menuClearImportInformations.Enabled = m_menuImporterRepertoire.Enabled;

            }
            
            
        }

        private TreeNode m_lastNodeClicked = null;
        private void m_arbre_MouseDown(object sender, MouseEventArgs e)
        {
            if ( e.Button == System.Windows.Forms.MouseButtons.Right )
            {
                TreeViewHitTestInfo info = m_arbre.HitTest(e.X,e.Y);
                m_lastNodeClicked = info.Node;
            }
        }

        private void m_wndListeFichiers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_wndListeFichiers.SelectedItems.Count == 1)
                ShowInfos(m_wndListeFichiers.SelectedItems[0].Tag);
        }

        private void ShowInfos( object obj)
        {
            if (obj == null)
                m_panelInfo.Visible = false;
            CRepertoire repertoire = obj as CRepertoire;
            if (repertoire != null)
            {
                m_imageErreur.Image = m_imagesFichiers.Images[GetIndexImageDossier(repertoire)];
                m_lblTitreErreur.Text = repertoire.Nom;
                m_txtErreur.Text = repertoire.InfoImport;
            }
            CFichier fichier = obj as CFichier;
            if (fichier != null)
            {
                m_imageErreur.Image = m_imagesFichiers.Images[GetIndexImageFichier(fichier)];
                m_lblTitreErreur.Text = fichier.Nom;
                if (fichier.KeyObjetAssocie != null && fichier.TypeObjetAssocie != null)
                {
                    m_txtErreur.Text = "Imported to ";
                    CObjetDonneeAIdNumerique objet = null;
                    if (CImportMyanmarConst.ContexteDonnee != null)
                    {
                        try
                        {
                            objet = Activator.CreateInstance(fichier.TypeObjetAssocie, new object[] { CImportMyanmarConst.ContexteDonnee }) as CObjetDonneeAIdNumerique;
                            if (obj != null && objet.ReadIfExists(fichier.KeyObjetAssocie))
                                m_txtErreur.Text += objet.DescriptionElement;
                        }
                        catch { }
                    }
                    if (objet == null && fichier.TypeObjetAssocie != null)
                        m_txtErreur.Text += DynamicClassAttribute.GetNomConvivial(fichier.TypeObjetAssocie);
                    else
                        m_txtErreur.Text += " ? ";
                }
                else
                    m_txtErreur.Text = fichier.InfoImport;
            }
        }

        private void m_menuCancelImport_Click(object sender, EventArgs e)
        {
            m_bCancelThreadRequest = true;
        }

        private void m_chkShowErrors_CheckedChanged(object sender, EventArgs e)
        {
            FillTree();
        }

        private void m_menuClearImportInformations_Click(object sender, EventArgs e)
        {
            TreeNode node = m_arbre.SelectedNode;
            ClearImportInformations(node);
        }

        private void ClearImportInformations(TreeNode node)
        {
            if (node == null)
                return;
            CRepertoire rep = node.Tag as CRepertoire;
            if (rep == null)
                return;
            m_arbre.BeginUpdate();
            rep.ClearDataImport();
            RefreshNode(node);
            m_arbre.EndUpdate();
        }

        public CRepertoire GetRepertoireSel()
        {
            CRepertoire rep = null;
            Invoke((MethodInvoker)delegate
            {
                if (m_arbre.SelectedNode != null)
                    rep = m_arbre.SelectedNode.Tag as CRepertoire;
            });
            return rep;
        }

        public CFichier GetFichierSel()
        {
            CFichier fichier = null;
            Invoke((MethodInvoker)delegate
            {
                if (m_wndListeFichiers.SelectedItems.Count > 0)
                    fichier = m_wndListeFichiers.SelectedItems[0].Tag as CFichier;
            });
            return fichier;
        }

       /* public bool FindNext ( string strDirPattern, string strFilePattern )
        {
            TreeNode node = m_arbre.SelectedNode;
            if (node == null && m_arbre.Nodes.Count > 0)
                node = m_arbre.Nodes[0];
            if (node == null)
                return false;
            Regex regDir = CPatternMatch.Convert(strDirPattern);
            Regex regFile = CPatternMatch.Convert(strFilePattern);
            CRepertoire repertoireSel = node.Tag as CRepertoire;
            CFichier fichierSel = null;
            if ( m_wndListeFichiers.SelectedItems.Count > 0 )
            {
                fichierSel = m_wndListeFichiers.SelectedItems[0].Tag as CFichier;
            }
            CFichier fichier = repertoireSel.FindNext(true, null, fichierSel, regDir, regFile);
            if (fichier != null)
            {
                SelectFichier(fichier);
                return true;
            }
            else
            {
                MessageBox.Show("Pattern not found");
                return false;
            }

        }*/

        public void SelectFichier(CFichier fichier)
        {
            Invoke((MethodInvoker)delegate
            {
                List<CRepertoire> lstReps = new List<CRepertoire>();
                CRepertoire rep = fichier.RepertoireContenant;
                while (rep != null)
                {
                    lstReps.Add(rep);
                    rep = rep.RepertoireContenant;
                }
                lstReps.Reverse();
                TreeNodeCollection nodes = m_arbre.Nodes;
                TreeNode nodeParent = null;
                foreach (CRepertoire childRep in lstReps)
                {
                    nodeParent = FindNode(childRep, nodes);
                    if (nodeParent == null)
                        break;
                    nodeParent.Expand();
                    nodes = nodeParent.Nodes;
                }
                if (nodeParent != null)
                {
                    m_arbre.SelectedNode = nodeParent;
                    nodeParent.EnsureVisible();
                    foreach (ListViewItem item in m_wndListeFichiers.Items)
                        if (item.Tag == fichier)
                        {
                            item.Selected = true;
                            item.EnsureVisible();
                            break;
                        }
                }
            });
        }

    
        private TreeNode FindNode ( CRepertoire rep, TreeNodeCollection nodes )
        {
            foreach ( TreeNode child in nodes )
            {
                if (child.Tag == rep)
                    return child;
            }
            return null;
        }
        

       

        private void m_btnSearch_Click(object sender, EventArgs e)
        {
            CFormSearchFiles.Show(this);
        }



        private void m_btnSummary_Click(object sender, EventArgs e)
        {
            CResume resume = new CResume();
            resume.Create(m_dossierRacine);
            Clipboard.SetText(resume.GetString());
            MessageBox.Show("Summary is in clipboard");
        }

        private void m_btnLogs_Click(object sender, EventArgs e)
        {
            StringBuilder bl = new StringBuilder();
            FillLogs(m_dossierRacine, bl);
            Clipboard.SetText(bl.ToString());
            MessageBox.Show("Log is in clipboard");
        }

        private void FillLogs ( CRepertoire repertoire, StringBuilder bl )
        {
            if ( repertoire.InfoImport.Length > 0 )
            {
                bl.Append(repertoire.FullName);
                bl.Append("\t");
                bl.Append(repertoire.InfoImport);
                bl.Append(Environment.NewLine);
            }
            foreach (CFichier fichier in repertoire.GetChilds<CFichier>())
            {
                if (fichier.InfoImport.Length > 0)
                {
                    bl.Append(repertoire.FullName);
                    bl.Append("/");
                    bl.Append(fichier.Nom);
                    bl.Append("\t");
                    bl.Append(fichier.InfoImport);
                    bl.Append(Environment.NewLine);
                }
            }
            foreach (CRepertoire rep in repertoire.GetChilds <CRepertoire>())
                FillLogs(rep, bl);

        }
    }
}
