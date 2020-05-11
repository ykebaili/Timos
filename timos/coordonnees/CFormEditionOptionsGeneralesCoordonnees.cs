using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.win32.common;
using sc2i.data;
using timos.data;
using timos.data.coordonnees;

namespace timos.coordonnees
{
    public partial class CFormEditionOptionsGeneralesCoordonnees : Form
    {
        private CContexteDonnee m_contexteDonnee = new CContexteDonnee();
        private CSite m_site = null;
        private CEquipement m_equipement = null;
        private CStock m_stock = null;
        public CFormEditionOptionsGeneralesCoordonnees()
        {
            InitializeComponent();
            m_contexteDonnee = new CContexteDonnee(CTimosApp.SessionClient.IdSession, true, false);
            m_site = new CSite(m_contexteDonnee);
            m_site.CreateNewInCurrentContexte();
            m_site.OptionsControleCoordonneesPropre = COptionCoordonnéeGlobale.GetOptionType(CTimosApp.SessionClient.IdSession, typeof(CSite));
            m_equipement = new CEquipement(m_contexteDonnee);
            m_equipement.CreateNewInCurrentContexte();
            m_equipement.OptionsControleCoordonneesPropre = COptionCoordonnéeGlobale.GetOptionType(CTimosApp.SessionClient.IdSession, typeof(CEquipement));
            m_stock = new CStock(m_contexteDonnee);
            m_stock.CreateNewInCurrentContexte();
            m_stock.OptionsControleCoordonneesPropre = COptionCoordonnéeGlobale.GetOptionType(CTimosApp.SessionClient.IdSession, typeof(CStock));
        }

        private void m_optionsSite_Load(object sender, EventArgs e)
        {

        }

        private void CFormEditionOptionsGeneralesCoordonnees_Load(object sender, EventArgs e)
        {
            CWin32Traducteur.Translate(this);
            m_optionsSite.Init(m_site);
            m_optionsSite.LockEdition = false;
            m_panelOptionsEquipement.Init(m_equipement);
            m_panelOptionsEquipement.LockEdition = false;
            m_panelOptionsStock.Init(m_stock);
            m_panelOptionsStock.LockEdition = false;
        }

        private void m_btnAnnuler_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void m_btnOk_Click(object sender, EventArgs e)
        {
            m_optionsSite.MajChamps();
            m_panelOptionsEquipement.MajChamps();
            m_panelOptionsStock.MajChamps();
            if ( m_site.OptionsControleCoordonneesPropre != null )
                COptionCoordonnéeGlobale.SetOptionType(CTimosApp.SessionClient.IdSession, typeof(CSite), m_site.OptionsControleCoordonneesPropre.Value);
            else
                COptionCoordonnéeGlobale.SetOptionType(CTimosApp.SessionClient.IdSession, typeof(CSite), EOptionControleCoordonnees.IgnorerLesFilsSansCoordonnees);

            if (m_equipement.OptionsControleCoordonneesPropre != null )
                COptionCoordonnéeGlobale.SetOptionType(CTimosApp.SessionClient.IdSession, typeof(CEquipement), m_equipement.OptionsControleCoordonneesPropre.Value);
            else
                COptionCoordonnéeGlobale.SetOptionType(CTimosApp.SessionClient.IdSession, typeof(CEquipement), EOptionControleCoordonnees.IgnorerLesFilsSansCoordonnees);
            if ( m_site.OptionsControleCoordonneesPropre != null )
                COptionCoordonnéeGlobale.SetOptionType(CTimosApp.SessionClient.IdSession, typeof(CStock), m_stock.OptionsControleCoordonneesPropre.Value);
            else
                COptionCoordonnéeGlobale.SetOptionType(CTimosApp.SessionClient.IdSession, typeof(CStock), EOptionControleCoordonnees.IgnorerLesFilsSansCoordonnees);
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
