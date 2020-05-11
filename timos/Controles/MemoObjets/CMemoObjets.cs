using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.data;
using timos.Properties;
using sc2i.win32.navigation;
using sc2i.win32.data.navigation;
using sc2i.win32.data;
using sc2i.common;
using System.Drawing.Imaging;

namespace timos.Controles.MemoObjets
{
    public partial class CMemoObjets : UserControl
    {
        public class CReferenceObjetDonneeAvecLibelle : I2iSerializable
        {
            private CReferenceObjetDonnee m_reference = null;
            private string m_strLibelle = null;


            public CReferenceObjetDonneeAvecLibelle()
            {
            }

            public CReferenceObjetDonneeAvecLibelle(CReferenceObjetDonnee reference)
            {
                m_reference = reference;
            }
            public static implicit operator CReferenceObjetDonnee(CReferenceObjetDonneeAvecLibelle refe)
            {
                return refe.m_reference;
            }

            

            public string Libelle
            {
                get
                {
                    if (m_strLibelle == null)
                    {
                        CObjetDonnee objet = m_reference.GetObjet(CSc2iWin32DataClient.ContexteCourant);
                        if (objet != null)
                            m_strLibelle = objet.DescriptionElement;
                        else
                            m_strLibelle = "??";
                    }
                    return m_strLibelle;
                }
            }

            public CReferenceObjetDonnee ReferenceObjet
            {
                get
                {
                    return m_reference;
                }
            }

            private int GetNumVersion()
            {
                return 0;
            }

            public CResultAErreur Serialize(C2iSerializer serializer)
            {
                int nVersion = GetNumVersion();
                CResultAErreur result = serializer.TraiteVersion(ref nVersion);
                if (!result)
                    return result;
                result = serializer.TraiteObject<CReferenceObjetDonnee>(ref m_reference);
                if (!result)
                    return result;
                string strLibelle = "";
                if ( serializer.Mode == ModeSerialisation.Ecriture && m_strLibelle == null)
                    //S'assure que le libellé est bien chargé
                    strLibelle = Libelle;
                serializer.TraiteString(ref m_strLibelle);
                return result;
            }

        }
        private List<CReferenceObjetDonneeAvecLibelle> m_listeObjets = null;
        private bool m_bVolatile = false;
        private bool m_bActiveOnMouseMove = false;

        public CMemoObjets()
        {
            InitializeComponent();
        }

        //----------------------------------------------------
        private List<CReferenceObjetDonneeAvecLibelle> ListeObjets
        {
            get
            {
                if (m_listeObjets == null)
                {
                    m_listeObjets = new List<CReferenceObjetDonneeAvecLibelle>();
                    Read();
                }
                return m_listeObjets;
            }
        }

        //----------------------------------------------------
        private void UpdateBackground()
        {
            if (Volatile)
                BackgroundImage = Resources.Briefcase;
            else
                BackgroundImage = Resources.memo;
        }

        //----------------------------------------------------
        public bool Volatile
        {
            get
            {
                return m_bVolatile;
            }
            set
            {
                m_bVolatile = value;
            }
        }

        //----------------------------------------------------
        public bool ActiveOnMouseMove
        {
            get
            {
                return m_bActiveOnMouseMove;
            }
            set
            {
                m_bActiveOnMouseMove = value;
            }
        }

        private bool TestAccept(IDataObject data)
        {
            return data.GetDataPresent(typeof(CReferenceObjetDonnee));
        }

        private void CMemoObjets_DragDrop(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.None;
            CReferenceObjetDonnee obj = e.Data.GetData(typeof(CReferenceObjetDonnee)) as CReferenceObjetDonnee;
            if (obj != null)
            {
                bool bExiste = false;
                foreach (CReferenceObjetDonneeAvecLibelle refe in ListeObjets)
                    if (((CReferenceObjetDonnee)refe).Equals(obj))
                    {
                        bExiste = true;
                        break;
                    }
                if (!bExiste)
                {
                    ListeObjets.Add(new CReferenceObjetDonneeAvecLibelle(obj));
                    e.Effect = DragDropEffects.Link;
                }
            }
            UpdateLook();
            Save();
        }

        private delegate void SaveDelegate();

        private void CMemoObjets_DragEnter(object sender, DragEventArgs e)
        {
            if (TestAccept(e.Data))
                e.Effect = DragDropEffects.Link;
        }

        private void CMemoObjets_DragOver(object sender, DragEventArgs e)
        {
            if (TestAccept(e.Data))
                e.Effect = DragDropEffects.Link;
        }


        private class CMenuItemARefObj : ToolStripMenuItem
        {
            private CReferenceObjetDonneeAvecLibelle m_referenceObjet = null;
            private bool m_bFonctionDelete = false;
            private bool m_bVolatile = false;
            private CMemoObjets m_memo = null;

            private Point? m_ptStartDrag = null;

            public CMenuItemARefObj(
                CReferenceObjetDonneeAvecLibelle refObjet, 
                CMemoObjets memo,
                bool bVolatile,
                bool bDelete)
                : base(refObjet.Libelle)
            {
                m_referenceObjet = refObjet;
                m_bFonctionDelete = bDelete;
                m_memo = memo;
                m_bVolatile = bVolatile;
                if (bDelete)
                    Image = Resources.delete;
                MouseDown += new MouseEventHandler(CMenuItemARefObj_MouseDown);
                MouseMove += new MouseEventHandler(CMenuItemARefObj_MouseMove);
                MouseUp += new MouseEventHandler(CMenuItemARefObj_MouseUp);
            }

            void CMenuItemARefObj_MouseUp(object sender, MouseEventArgs e)
            {
                m_ptStartDrag = null;
            }

            void CMenuItemARefObj_MouseMove(object sender, MouseEventArgs e)
            {
                if (m_ptStartDrag != null)
                {
                    Point pt = m_ptStartDrag.Value;
                    if (Math.Abs(e.X - pt.X) > 3 || Math.Abs(e.Y - pt.Y) > 3)
                    {
                        BackColor = Color.LightGreen;
                        DragDropEffects effect = DoDragDrop(m_referenceObjet.ReferenceObjet, DragDropEffects.Link | DragDropEffects.Copy);
                        if (Parent != null)
                            Parent.Visible = false;
                        if (m_bVolatile && effect != DragDropEffects.None)
                        {
                            m_memo.RemoveObjet(m_referenceObjet);
                        }
                        m_ptStartDrag = null;
                    }
                }
            }



            void CMenuItemARefObj_MouseDown(object sender, MouseEventArgs e)
            {
                m_ptStartDrag = new Point(e.X, e.Y);
            }

            public bool FonctionDelete
            {
                get
                {
                    return m_bFonctionDelete;
                }
            }

            public CReferenceObjetDonneeAvecLibelle ReferenceObjet
            {
                get
                {
                    return m_referenceObjet;
                }
            }
        }

        private void RemoveObjet(CReferenceObjetDonneeAvecLibelle reference)
        {
            m_listeObjets.Remove(reference);
            UpdateLook();
            Save();
        }

        //------------------------------------------------------
        private void UpdateLook()
        {
            if (ListeObjets.Count > 0)
                m_lblNb.Text = ListeObjets.Count.ToString();
            else
                m_lblNb.Text = "";
        }

        //-----------------------------------------------------
        void item_Click(object sender, EventArgs e)
        {
            CMenuItemARefObj item = sender as CMenuItemARefObj;
            if (item != null)
            {
                if (item.FonctionDelete)
                {
                    ListeObjets.Remove(item.ReferenceObjet);
                    UpdateLook();
                    Save();
                }
                else
                {
                    CObjetDonneeAIdNumeriqueAuto obj = item.ReferenceObjet.ReferenceObjet.GetObjet(CSc2iWin32DataClient.ContexteCourant) as CObjetDonneeAIdNumeriqueAuto;
                    if (obj != null)
                    {
                        CReferenceTypeForm refForm = CFormFinder.GetRefFormToEdit(obj.GetType());
                        if (refForm != null)
                        {
                            IFormNavigable frm = refForm.GetForm(obj) as IFormNavigable;
                            if (frm != null)
                            {
                                CTimosApp.Navigateur.AffichePage(frm);
                                return;
                            }
                        }
                    }
                }
            }
        }

        //----------------------------------------------------------------
        private void m_picBox_MouseUp(object sender, MouseEventArgs e)
        {
            ShowMenu(e.Button == MouseButtons.Right);
        }

        //----------------------------------------------------------------
        private void ShowMenu(bool bDelete)
        {
            m_menu.Items.Clear();
            foreach (CReferenceObjetDonneeAvecLibelle refe in ListeObjets)
            {
                CMenuItemARefObj item = new CMenuItemARefObj(refe, this, m_bVolatile, bDelete);
                item.Click += new EventHandler(item_Click);
                m_menu.Items.Add(item);
            }
            m_menu.Show(this, new Point(Width, Height));//(new Point(e.X, e.Y)));
        }

        //----------------------------------------------------------------
        public void Read()
        {
            if (Volatile)
                return;
            List<CReferenceObjetDonneeAvecLibelle> lst = new List<CReferenceObjetDonneeAvecLibelle>();
            if (new CTimosAppRegistre().ReadMemoUser(ref lst))
            {
                m_listeObjets = lst;
                UpdateLook();
            }
        }

        //----------------------------------------------------------------
        private void Save()
        {
            if (!Volatile && ListeObjets != null)
            {
                CStringSerializer ser = new CStringSerializer(ModeSerialisation.Ecriture);
                if (ser.TraiteListe<CReferenceObjetDonneeAvecLibelle>(m_listeObjets))
                    C2iRegistre.SetValueInRegistreApplication("Preferences", "UserMemo", ser.String);
            }
        }

        //----------------------------------------------------------------
        private void m_lblNb_MouseEnter(object sender, EventArgs e)
        {
            if (ActiveOnMouseMove)
                ShowMenu(false);
        }
    }
}
