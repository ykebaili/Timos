using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.win32.data.navigation;
using timos.data.projet.besoin;

namespace timos.projet.besoin
{
    public partial class CFormMapBesoinsPopup : Form
    {
        private static CFormMapBesoinsPopup m_instance = null;

        private CFormEditionStandard m_formMaitresse = null;

        private EventHandler m_eventChangeModeEdition;
        private FormClosedEventHandler m_eventClose;

        //-------------------------------------------
        private CFormMapBesoinsPopup()
        {
            InitializeComponent();
            m_eventChangeModeEdition = new EventHandler(OnChangeMaitresseModeEdition);
            m_eventClose = new FormClosedEventHandler(OnCloseMaitresse);
        }

        //-------------------------------------------
        public static CFormMapBesoinsPopup Instance
        {
            get
            {
                if (m_instance == null)
                    m_instance = new CFormMapBesoinsPopup();
                return m_instance;
            }
        }

        //-------------------------------------------
        private void OnChangeMaitresseModeEdition(object sender, EventArgs args )
        {
            Masquer();
        }

        //-------------------------------------------
        private void OnCloseMaitresse ( object sender, FormClosedEventArgs args )
        {
            Masquer();
        }

        //-------------------------------------------
        public void Masquer()
        {
            Hide();
            m_formMaitresse = null;
        }

        //-------------------------------------------
        public static void Show(CFormEditionStandard formMaitresse, CPhaseSpecifications phase)
        {
            Instance.SetFormMaitresse(formMaitresse);
            Instance.m_panelMap.Init(phase);
            Instance.Show();
            Instance.Focus();
        }

        //-------------------------------------------
        public static void Show(CFormEditionStandard formMaitresse, ISatisfactionBesoin satisfaction)
        {
            Instance.SetFormMaitresse(formMaitresse);
            Instance.m_panelMap.Init(satisfaction);
            Instance.Show();
            Instance.Focus();
        }

        //-------------------------------------------
        private void SetFormMaitresse(CFormEditionStandard formMaitresse)
        {
            if (formMaitresse != null)
            {
                formMaitresse.OnChangeModeEdition -= Instance.m_eventChangeModeEdition;
                formMaitresse.FormClosed -= Instance.m_eventClose;

                if (formMaitresse.ModeEdition)
                {
                    formMaitresse.OnChangeModeEdition += Instance.m_eventChangeModeEdition;
                    formMaitresse.FormClosed += Instance.m_eventClose;
                }
            }
        }


        //-------------------------------------------
        private void CFormMapBesoinPopup_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Masquer();
        }

    }
}
