using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.win32.common;
using sc2i.formulaire;
using sc2i.expression;
using sc2i.common;

namespace timos.Controles.ActionsSurLink
{
    public partial class CFormEditActionSurLink : Form
    {
        private CActionSur2iLink m_actionOriginale = null;
        private CActionSur2iLink m_actionFinale = null;
        private CObjetPourSousProprietes m_objetPourSousProprietes = null;

        private IEditeurUneActionSur2iLink m_editeur = null;

        public CFormEditActionSurLink()
        {
            InitializeComponent();
        }

        //---------------------------------------------------------------------
        private void CFormEditeActionSurLink_Load(object sender, EventArgs e)
        {
            CWin32Traducteur.Translate(this);
            FillComboActionsPossibles();


            SelectTypeAction(m_actionOriginale != null ?
                m_actionOriginale.GetType() :
                null);
           
            
            m_actionFinale = m_actionOriginale;
            UpdateVisuel();

        }

        //---------------------------------------------------
        private void SelectTypeAction(Type tp)
        {
            if (tp == null)
                m_cmbTypeAction.SelectedItem = null;
            else
            {
                foreach (CGestionnaireEditeursActionsSur2iLink.CInfoTypeActionSur2iLink info in m_cmbTypeAction.ListDonnees)
                {
                    if (info.TypeAction == tp)
                    {
                        m_cmbTypeAction.SelectedValue = info;
                        break;
                    }
                }
            }
        }

        //--------------------------------------------------------------------
        private void FillComboActionsPossibles()
        {
            m_cmbTypeAction.ListDonnees = CGestionnaireEditeursActionsSur2iLink.GetTypesActionPossibles();
            m_cmbTypeAction.ProprieteAffichee = "NomAction";
            m_cmbTypeAction.AssureRemplissage();
        }

        //---------------------------------------------------------------------
        public static CActionSur2iLink EditeAction(CActionSur2iLink action,
            CObjetPourSousProprietes objetPourSousProprietes)
        {
            using (CFormEditActionSurLink frm = new CFormEditActionSurLink())
            {
                frm.m_actionOriginale = action;
                frm.m_objetPourSousProprietes = objetPourSousProprietes;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    return frm.m_actionFinale;
                }
                return action;
            }
        }

        //----------------------------------------------------------------------------------
        private void m_cmbTypeAction_SelectionChangeCommitted(object sender, EventArgs e)
        {
            UpdateVisuel();
        }

        //----------------------------------------------------------------------------------
        private void UpdateVisuel()
        {
            CGestionnaireEditeursActionsSur2iLink.CInfoTypeActionSur2iLink info = m_cmbTypeAction.SelectedValue as CGestionnaireEditeursActionsSur2iLink.CInfoTypeActionSur2iLink;
            m_panelDetailAction.SuspendDrawing();
            if (info != null)
            {
                if (m_editeur != null && m_editeur.GetType() != info.TypeEditeur)
                {
                    m_panelDetailAction.Controls.Remove((Control)m_editeur);
                    m_editeur.Dispose();
                    m_editeur = null;
                }
                if (m_editeur == null)
                {
                    m_editeur = Activator.CreateInstance(info.TypeEditeur, new object[0]) as IEditeurUneActionSur2iLink;
                    Control ctrl = m_editeur as Control;
                    ctrl.Parent = m_panelDetailAction;
                    ctrl.Dock = DockStyle.Fill;
                    CWin32Traducteur.Translate(ctrl);
                }
                if (m_actionFinale == null || m_actionFinale.GetType() != info.TypeAction)
                {
                    m_actionFinale = Activator.CreateInstance(info.TypeAction, new object[0]) as CActionSur2iLink;

                }
                m_editeur.InitChamps(m_actionFinale, m_objetPourSousProprietes);
            }
            m_panelDetailAction.ResumeDrawing();
        }

        //----------------------------------------------------------------------------------
        private void m_btnAnnuler_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        //----------------------------------------------------------------------------------
        private void m_btnOk_Click(object sender, EventArgs e)
        {
            if (m_editeur != null)
            {
                CResultAErreur result = m_editeur.MajChamps();
                if (!result)
                {
                    CFormAlerte.Afficher(result.Erreur);
                    return;
                }
            }
            DialogResult = DialogResult.OK;
            Close();

        }

        //----------------------------------------------------------------------------------
        private void m_btnCopy_Click(object sender, EventArgs e)
        {
            if (m_actionFinale != null)
            {
                CResultAErreur result = CSerializerObjetInClipBoard.Copy(m_actionFinale, CActionSur2iLink.c_idFichier);
                if (!result)
                {
                    CFormAlerte.Afficher(result);
                }
            }
        }

        //----------------------------------------------------------------------------------
        private void m_btnPaste_Click(object sender, EventArgs e)
        {
            I2iSerializable objet = null;
            CResultAErreur result = CSerializerObjetInClipBoard.Paste(ref objet, CActionSur2iLink.c_idFichier);
            if (!result)
            {
                CFormAlerte.Afficher(result);
                return;
            }
            if (CFormAlerte.Afficher(I.T("Action data will be replaced, continue|20866"),
                EFormAlerteType.Question) == DialogResult.No)
                return;
            m_actionFinale = (CActionSur2iLink)objet;
            SelectTypeAction ( m_actionFinale != null?
                m_actionFinale.GetType() :
                null);
            UpdateVisuel();
        }

        private class CActionSaver : I2iSerializable
        {
            private CActionSur2iLink m_action = null;
            public CActionSaver()
            {
            }

            public CActionSaver(CActionSur2iLink action)
            {
                m_action = action;
            }

            public CActionSur2iLink Action
            {
                get
                {
                    return m_action;
                }
            }
            private int GetNumVersion()
            {
                return 0;
            }

            #region I2iSerializable Membres

            public CResultAErreur Serialize(C2iSerializer serializer)
            {
                int nVersion = GetNumVersion();
                CResultAErreur result = serializer.TraiteVersion(ref nVersion);
                if (result)
                    result = serializer.TraiteObject<CActionSur2iLink>(ref m_action);
                return result;
            }

            #endregion
        }

        //----------------------------------------------------------------------------------
        private void m_btnSave_Click(object sender, EventArgs e)
        {
            if (m_actionFinale != null)
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = I.T("Action (*.2iAction)|*.2iAction|All files (*.*)|*.*|20867");
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string strNomFichier = dlg.FileName;
                    CActionSaver saver = new CActionSaver(m_actionFinale);
                    CResultAErreur result = CSerializerObjetInFile.SaveToFile(saver, CActionSur2iLink.c_idFichier, strNomFichier);
                    if (!result)
                        CFormAlerte.Afficher(result);
                    else
                        CFormAlerte.Afficher(I.T("Save successful|20868"));
                }
            }
        }

        private void m_btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = I.T("Action (*.2iAction)|*.2iAction|All files (*.*)|*.*|20867");
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (CFormAlerte.Afficher(I.T("Action data will be replaced, continue|20866"),
                    EFormAlerteType.Question) == DialogResult.No)
                    return;
                CActionSaver saver = new CActionSaver();
                CResultAErreur result = CSerializerObjetInFile.ReadFromFile(saver, CActionSur2iLink.c_idFichier, dlg.FileName);
                if (!result)
                    CFormAlerte.Afficher(result);
                else
                {
                    m_actionFinale = saver.Action;
                    SelectTypeAction(m_actionFinale != null ?
                        m_actionFinale.GetType() :
                        null);
                    UpdateVisuel();
                }
            }
        }

        //----------------------------------------------------------------------------------

    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// 
    /// </summary>
    [AutoExec("Autoexec")]
    public class CEditeurActionSur2iLink : IEditeurActionSur2iLink
    {
        private CObjetPourSousProprietes m_objetPourSousProprietes = null;

        //---------------------------------------
        public CEditeurActionSur2iLink()
        {
        }

        //---------------------------------------
        public static void Autoexec()
        {
            CActionSur2iLinkEditor.SetTypeEditeur(typeof(CEditeurActionSur2iLink));
        }

        //---------------------------------------
        public CEditeurActionSur2iLink(CObjetPourSousProprietes objetEdite)
        {
            m_objetPourSousProprietes = objetEdite;
        }

        //---------------------------------------
        public Type TypeEdite
        {
            get
            {
                return m_objetPourSousProprietes.TypeAnalyse;
            }
        }

        //---------------------------------------
        public CObjetPourSousProprietes ObjetEdite
        {
            get
            {
                return m_objetPourSousProprietes;
            }
            set
            {
                m_objetPourSousProprietes = value;
            }
        }

        //---------------------------------------
        public void EditeAction(ref CActionSur2iLink action)
        {
            action = CFormEditActionSurLink.EditeAction(action, m_objetPourSousProprietes);

        }
    }
}
