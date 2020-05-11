using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using futurocom.supervision;

namespace TestSnmp
{
    public partial class CFormEditeTypeAlarme : Form
    {
        private ITypeAlarme m_typeAlarme = null;
        private List<IChampAlarme> m_listeChampsHerites = new List<IChampAlarme>();
        
        public CFormEditeTypeAlarme()
        {
            InitializeComponent();
        }

        public static bool EditeTypeAlarme(ITypeAlarme type)
        {
            CFormEditeTypeAlarme form = new CFormEditeTypeAlarme();
            form.m_typeAlarme = type;
            bool bResult = false;
            if (form.ShowDialog() == DialogResult.OK)
                bResult = true;
            form.Dispose();
            return bResult;
        }

        private void CFormEditeTypeAlarme_Load(object sender, EventArgs e)
        {
            m_txtNom.Text = m_typeAlarme.Libelle;
            m_lblTypeParent.Text = m_typeAlarme.TypeParent == null ? "" : m_typeAlarme.TypeParent.Libelle;
            m_txtFormuleSurParent.Visible = m_typeAlarme.TypeParent != null;
            m_txtFormuleSurParent.Init ( m_typeAlarme, typeof(IAlarme));
            m_txtFormuleSurParent.Formule = m_typeAlarme.ActionsSurParent;
            m_txtFormuleLibelleAlarme.Init(m_typeAlarme, typeof(IAlarme));
            m_txtFormuleLibelleAlarme.Formule = m_typeAlarme.FormuleLibelle;
            FillListeChamps();
            m_cmbEtatCreation.Items.Clear();
            foreach (EEtatAlarme etat in Enum.GetValues(typeof(EEtatAlarme)))
            {
                m_cmbEtatCreation.Items.Add(etat);
            }
            m_cmbEtatCreation.SelectedItem = m_typeAlarme.EtatDefaut;

            foreach ( EModeCalculEtatParent mode in Enum.GetValues(typeof(EModeCalculEtatParent)))
            {
                m_cmbModeCaluclEtat.Items.Add(mode);
            }
            m_cmbModeCaluclEtat.SelectedItem = m_typeAlarme.ModeCalculEtat;

        }

        private void FillListeChamps()
        {
            m_wndListeChamps.BeginUpdate();
            m_wndListeChamps.Items.Clear();
            m_listeChampsHerites.Clear();
            if (m_typeAlarme.TypeParent != null)
                foreach (IChampAlarme champ in m_typeAlarme.TypeParent.TousLesChamps)
                    m_listeChampsHerites.Add(champ);
            foreach ( IChampAlarme champ in m_typeAlarme.TousLesChamps )
            {
                ListViewItem item = new ListViewItem(champ.NomChamp);
                FillItem(item, champ);
                m_wndListeChamps.Items.Add(item);
            }
            m_wndListeChamps.EndUpdate();

        }

        private void FillItem(ListViewItem item, IChampAlarme champ)
        {
            item.Text = champ.NomChamp;
            item.Tag = champ;
            item.BackColor = champ.IsKey?Color.FromArgb(0,255,0):Color.FromArgb(255,255,255);
        }

        private void m_lnkAjouterChamp_LinkClicked(object sender, EventArgs e)
        {
            CChampAlarmeTest champ = new CChampAlarmeTest();
            if (CFormEditeChampAlarme.EditeChamp(champ))
            {
                if (m_typeAlarme.AddChamp(champ))
                    FillListeChamps();
            }
        }

        private void m_lnkSupprimerChamp_LinkClicked(object sender, EventArgs e)
        {
            if (m_wndListeChamps.SelectedItems.Count == 1)
            {
                IChampAlarme champ = m_wndListeChamps.SelectedItems[0].Tag as IChampAlarme;
                if (champ != null)
                {
                    m_typeAlarme.RemoveChamp(champ);
                    FillListeChamps();
                }
            }
        }

        //--------------------------------------
        private void m_wndListeChamps_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = m_wndListeChamps.HitTest(e.X, e.Y);
            if (info != null && info.Item != null)
            {
                IChampAlarme champ = info.Item.Tag as IChampAlarme;
                if (champ != null)
                {
                    if (CFormEditeChampAlarme.EditeChamp(champ))
                        FillItem(info.Item, champ);
                }
            }
        }

        private void m_btnOk_Click(object sender, EventArgs e)
        {
            if (m_txtNom.Text == "")
            {
                MessageBox.Show("LE NOM !");
                return;
            }
            m_typeAlarme.ClearChamps();
            foreach (ListViewItem item in m_wndListeChamps.Items)
            {
                IChampAlarme champ = item.Tag as IChampAlarme;
                if (m_listeChampsHerites.FirstOrDefault(c => c.NomChamp == champ.NomChamp) == null)
                {
                    if (champ != null)
                        m_typeAlarme.AddChamp(champ);
                }
            }
            if (m_typeAlarme.TypeParent != null)
                m_typeAlarme.ActionsSurParent = m_txtFormuleSurParent.Formule;
            m_typeAlarme.Libelle = m_txtNom.Text;
            m_typeAlarme.FormuleLibelle = m_txtFormuleLibelleAlarme.Formule;
            m_typeAlarme.EtatDefaut = (EEtatAlarme)m_cmbEtatCreation.SelectedItem;
            m_typeAlarme.ModeCalculEtat = (EModeCalculEtatParent)m_cmbModeCaluclEtat.SelectedItem;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void m_btnAnnuler_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

                    

    }
}
