using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using futurocom.supervision;

namespace timos.supervision
{
    public partial class CControleSelectNiveauMasquageAlarme : UserControl
    {
        private Dictionary<int, CLocalCategorieMasquageAlarme> m_dicValeurCategorie = new Dictionary<int, CLocalCategorieMasquageAlarme>();

        public CControleSelectNiveauMasquageAlarme()
        {
            InitializeComponent();
        }


        public void Init(IEnumerable<CLocalCategorieMasquageAlarme> listeSource, CLocalCategorieMasquageAlarme elementSelectionne)
        {
            int nCount = listeSource.Count();

            m_trackBar.Minimum = 0;
            m_trackBar.Maximum = nCount;

            int i = 0;
            m_dicValeurCategorie[i] = null;
            i++;
            foreach (CLocalCategorieMasquageAlarme item in listeSource)
            {
                if (elementSelectionne != null && item.Id == elementSelectionne.Id)
                    m_trackBar.Value = i;
                m_dicValeurCategorie[i] = item;
                i++;

            }

            EcrireLesLibellesEnFaceDesGraduations();

        }

        private void EcrireLesLibellesEnFaceDesGraduations()
        {
            ArrayList lstControles = new ArrayList(m_panelLibelles.Controls);
            foreach (Control ctrl in lstControles)
            {
                m_panelLibelles.Controls.Remove(ctrl);
            }

            int nb = m_dicValeurCategorie.Count;

            int nHauteurLabel = 25;

            int nPas = nb < 2  ? 0 : (int)(Height - nHauteurLabel) / (nb - 1);

            foreach (KeyValuePair<int, CLocalCategorieMasquageAlarme> couple in m_dicValeurCategorie)
            {
                int nOfsset = nPas * couple.Key;

                Label label = new Label();
                if (couple.Value != null)
                    label.Text = couple.Value.Libelle + " [" + couple.Value.Priorite + "]";
                else
                    label.Text = "Ne pas afficher les alarmes masquées";
                label.Size = new Size(m_panelLibelles.Width, nHauteurLabel);
                m_panelLibelles.Controls.Add(label);
                label.TextAlign = ContentAlignment.MiddleLeft;
                label.Location = new Point(0, m_panelLibelles.Height - (nHauteurLabel + nOfsset));
            }

        }


        public CLocalCategorieMasquageAlarme ElementSelectionne
        {
            get
            {
                CLocalCategorieMasquageAlarme element = null;
                if (m_dicValeurCategorie.TryGetValue(m_trackBar.Value, out element))
                    return element;

                return null;
            }
        }

        private void CControleSelectNiveauMasquageAlarme_Resize(object sender, EventArgs e)
        {
            EcrireLesLibellesEnFaceDesGraduations();
        }

    }
}
