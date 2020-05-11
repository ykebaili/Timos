using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using timos.data.projet.besoin;
using sc2i.common.unites;
using sc2i.data;
using timos.data.equipement.consommables;
using sc2i.common.unites.standard;

namespace timos.projet.besoin.editeur.donneebesoin
{
    public class CEditeurDonneeBesoinTemps : CEditeurDonneeBesoinConsommable
    {
        public CEditeurDonneeBesoinTemps()
        {
            InitializeComponent();
            m_lblTypeConsommable.Text = I.T("Time rate|20676");
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // m_lblTypeConsommable
            // 
            this.m_lblTypeConsommable.Text = "Time rate|20716";
            this.m_lblTypeConsommable.Click += new System.EventHandler(this.m_lblTypeConsommable_Click);
            // 
            // m_txtSelectTypeConsommable
            // 
            // 
            // CEditeurDonneeBesoinTemps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "CEditeurDonneeBesoinTemps";
            this.ResumeLayout(false);

        }

       
        //-----------------------------------------------
        protected override void InitTypeConsommable()
        {
            //Supprime les consommables temps
            m_txtSelectTypeConsommable.InitAvecFiltreDeBase(
                typeof(CTypeConsommable),
                "Libelle",
                new CFiltreData(CTypeConsommable.c_champClasseUniteString + "=@1",
                    CClasseUniteTemps.c_idClasse),
                    false);
        }

        private void m_lblTypeConsommable_Click(object sender, EventArgs e)
        {

        }

        
    }
}
