using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;


using sc2i.common;
using sc2i.win32.common;
using sc2i.drawing;
using timos.data;
using sc2i.data;


namespace timos
{
    public partial class CPanelSymboleType : UserControl , IControlALockEdition
    {
        private IDefinisseurSymbole m_objetEdite;

        private CSymboleDeBibliotheque m_symboleBib;

        private Type m_typeEdite;

        public CPanelSymboleType()
        {
            InitializeComponent();
        }


        public CResultAErreur InitChamps(IDefinisseurSymbole objetEdite)
        {
            CResultAErreur result = CResultAErreur.True;

          if (objetEdite==null)
                return CResultAErreur.False;

            m_objetEdite = objetEdite;
            m_typeEdite = objetEdite.GetType();

            if (objetEdite.SymbolePropre == null)
            {
                m_radioSymboleBib.Checked = true;
                m_radioSymbolePropre.Checked = false;
                m_linkEditSymbole.Enabled = false;
                m_cmbSymboleBib.Enabled = m_gestionnaireModeEdition.ModeEdition;
                InitSymbolesBibliotheque();
            }
            else
            {
                m_radioSymbolePropre.Checked = true;
                m_radioSymboleBib.Checked = false;
                m_cmbSymboleBib.Enabled = false;

            }
                 
         

            return result;
        }


         private void InitSymbolesBibliotheque()
        {

            if (m_radioSymboleBib.Checked)
            {
                string strFiltre;
                if(m_typeEdite == typeof(CTypeSite))
                  strFiltre = "timos.data.CSite";
                else 
                 strFiltre = "timos.data.CEquipementLogique";
                CFiltreData filtre = new CFiltreData(CSymboleDeBibliotheque.c_champTypeCible + " = @1", strFiltre);
                CFiltreData filtreRapide = CFournisseurFiltreRapide.GetFiltreRapideForType(typeof(CSymboleDeBibliotheque));

                filtre = CFiltreData.GetAndFiltre(filtreRapide, filtre);
                m_cmbSymboleBib.Init(typeof(CFormListeSymboleDeBibliotheque),
                   typeof(CFormEditionSymboleDeBibliotheque),
                   "Libelle",
                 filtre, false);

                if (m_objetEdite != null)
                    if (m_objetEdite.SymboleDeBibliotheque != null)
                    {
                        m_cmbSymboleBib.ElementSelectionne = m_objetEdite.SymboleDeBibliotheque;
                        m_symboleBib = m_objetEdite.SymboleDeBibliotheque;
                    }
            }
        }
        public CResultAErreur MAJ_Champs()
        {


            CResultAErreur result = CResultAErreur.True;

            if (m_radioSymboleBib.Checked)
            {
                m_objetEdite.SymboleDeBibliotheque = (CSymboleDeBibliotheque)m_cmbSymboleBib.ElementSelectionne;
                m_objetEdite.SymbolePropre = null;
            }

            return result;
        }

       

        private void m_panelDessin_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            CContextDessinObjetGraphique ctg = new CContextDessinObjetGraphique(g);
            if (m_objetEdite != null)
              
                if (m_objetEdite.SymboleADessiner != null)

                    m_objetEdite.SymboleADessiner.Draw(ctg);

             /*   if (m_objetEdite.SymbolePropre != null)
                {
                    if (m_objetEdite.SymbolePropre.Symbole != null)
                        m_objetEdite.SymbolePropre.Symbole.Draw(ctg);

                }
                else if (m_cmbSymboleBib.ElementSelectionne != null)
                {
                    CSymboleDeBibliotheque symboleBib = (CSymboleDeBibliotheque)m_cmbSymboleBib.ElementSelectionne;
                    if (symboleBib.Symbole != null)
                        if (symboleBib.Symbole.Symbole != null)
                            symboleBib.Symbole.Symbole.Draw(ctg);
                    / if (m_objetEdite.SymboleDeBibliotheque.Symbole != null)
                          if (m_objetEdite.SymboleDeBibliotheque.Symbole.Symbole != null)
                              m_objetEdite.SymboleDeBibliotheque.Symbole.Symbole.Draw(ctg);

                }
        */
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

        private void m_radioSymboleBib_CheckedChanged_1(object sender, EventArgs e)
        {
            m_cmbSymboleBib.Enabled = m_gestionnaireModeEdition.ModeEdition;
            InitSymbolesBibliotheque();
            m_linkEditSymbole.Enabled = false;
           
            m_panelDessin.Refresh();
        }

        private void m_radioSymbolePropre_CheckedChanged_1(object sender, EventArgs e)
        {
            m_cmbSymboleBib.Enabled = false;
            m_cmbSymboleBib.ElementSelectionne = null;
            m_linkEditSymbole.Enabled = m_gestionnaireModeEdition.ModeEdition;
        
            m_panelDessin.Refresh();
        }

       
        private void m_cmbSymboleBib_ElementSelectionneChanged_1(object sender, EventArgs e)
        {
            
            m_panelDessin.Refresh();


        }

        private void m_linkEditSymbole_LinkClicked(object sender, EventArgs e)
        {
            if (m_radioSymbolePropre.Checked)
            {

                if (m_objetEdite.SymbolePropre == null)
                {
                    m_objetEdite.SymboleDeBibliotheque = null;

                    CSymbole sym = new CSymbole(((CObjetDonnee)m_objetEdite).ContexteDonnee);
                    sym.CreateNewInCurrentContexte();
                    m_objetEdite.SymbolePropre = sym;


                }

                C2iSymbole symboleEdite = CFormEditeurSymbolePopup.EditeSymbole(m_objetEdite.SymbolePropre.Symbole, m_typeEdite, false);

                if (symboleEdite != null)
                    m_objetEdite.SymbolePropre.Symbole = symboleEdite;
            } 
        }
    }
}
