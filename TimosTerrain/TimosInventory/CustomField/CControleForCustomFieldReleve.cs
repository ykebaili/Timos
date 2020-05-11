using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TimosInventory.data;
using sc2i.win32.common;
using sc2i.common;

namespace TimosInventory.CustomField
{
    public partial class CControleForCustomFieldReleve : UserControl
    {
        CChampCustom m_champ = null;
        IControlChampCustom m_controleChamp = null;
        public CControleForCustomFieldReleve()
        {
            InitializeComponent();
        }

        //-----------------------------------------------------------
        public void Init(CChampCustom champ)
        {
            m_panelForChamp.ClearAndDisposeControls();
            m_controleChamp = null;
            m_champ = champ;
            if (m_champ != null)
            {
                Control ctrl = CAllocateurControlChampCustom.GetNewControle(champ.TypeDonnee);
                m_controleChamp = ctrl as IControlChampCustom;
                if (m_controleChamp != null)
                {
                    m_panelForChamp.Controls.Add(ctrl);
                    ctrl.Dock = DockStyle.Fill;
                    m_controleChamp.ChampCustom = champ;
                    m_controleChamp.OnValueChanged += new EventHandler(OnControlValueChanged);
                }
                m_lblNomChamp.Text = champ.Nom;
            }
        }

        //-----------------------------------------------------------
        public event EventHandler OnValueChanged;

        //-----------------------------------------------------------
        public void OnControlValueChanged(object sender, EventArgs args)
        {
            if (OnValueChanged != null)
                OnValueChanged(this, args);
        }



        //-----------------------------------------------------------
        public void InitChamps(IElementAChamps eltAChamps)
        {
            if (m_controleChamp != null)
                m_controleChamp.InitChamps(eltAChamps);
        }

        //-----------------------------------------------------------
        public CResultAErreur MajChamp()
        {
            CResultAErreur result = CResultAErreur.True;
            if (m_controleChamp != null)
                result = m_controleChamp.MajChamps();
            return result;
        }
    }
}
