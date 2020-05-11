using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


using sc2i.multitiers.client;
using sc2i.win32.data;
using sc2i.data;
using sc2i.common;
using sc2i.win32.common;
using sc2i.win32.navigation;
using sc2i.win32.data.navigation;
using sc2i.workflow;

using timos.data;


namespace timos
{
    public partial class CFormTestEditionNouveauTicket : Form
    {
        public CFormTestEditionNouveauTicket()
        {
            InitializeComponent();
        }

        CContexteDonnee m_contexte;
        CTicket m_nouveauTicket;


        public void Init()
        {

            m_contexte = sc2i.win32.data.CSc2iWin32DataClient.ContexteCourant;
            m_nouveauTicket = new CTicket(m_contexte);
            m_nouveauTicket.CreateNew();

            m_panelEditionTicket.InitPanel(m_nouveauTicket);

        }

        //----------------------------------------------------------------------------------
        private void m_btnValider_Click(object sender, EventArgs e)
        {
            CResultAErreur result =  m_panelEditionTicket.MAJ_Champs();
            if (result)
            {
                if(m_nouveauTicket.IsNew())
                    result = m_nouveauTicket.CommitEdit();
            }
            Init();
        }

        //----------------------------------------------------------------------------------
        private void m_btnAnnuler_Click(object sender, EventArgs e)
        {
            if (m_nouveauTicket.IsNew())
                m_nouveauTicket.CancelEdit();
            
            // Ferme le formulaire
            this.Close();
        }

 
    }
}