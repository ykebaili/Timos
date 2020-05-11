using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.win32.common;
using sc2i.common;
using sc2i.data.dynamic;
using timos.data;

namespace timos.releve.CustomField
{
    public partial class CControleForCustomFieldReleve : UserControl, IControlALockEdition
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
                Control ctrl = CAllocateurControlChampCustom.GetNewControle(champ.TypeDonneeChamp.TypeDonnee);
                m_controleChamp = ctrl as IControlChampCustom;
                if (m_controleChamp != null)
                {
                    m_panelForChamp.Controls.Add(ctrl);
                    ctrl.Dock = DockStyle.Fill;
                    m_controleChamp.ChampCustom = champ;
                    m_controleChamp.OnValueChanged += new EventHandler(OnControlValueChanged);
                    m_extModeEdition.SetModeEdition(m_controleChamp, TypeModeEdition.EnableSurEdition);
                }
                m_lblNomChamp.Text = champ.Nom;
            }
        }

        //-----------------------------------------------------------
        public event EventHandler OnValueChanged;

        //-----------------------------------------------------------
        public void OnControlValueChanged(object sender, EventArgs args)
        {
            if (OnValueChanged != null && !LockEdition)
                OnValueChanged(this, args);
        }



        //-----------------------------------------------------------
        public void InitChamps(IElementAChamps eltAChamps)
        {
            if (m_controleChamp != null)
            {
                m_controleChamp.InitChamps(eltAChamps);
                CReleveEquipement rel = eltAChamps as CReleveEquipement;
                ((Control)m_controleChamp).BackColor = Color.LightGreen;
                if (rel != null && rel.Equipement != null)
                {
                    object v1 = rel.GetValeurChamp(m_champ.Id);
                    object v2 = rel.Equipement.GetValeurChamp(m_champ.Id);
                    if ( v1 != null && !v1.Equals ( v2 ) )
                        ((Control)m_controleChamp).BackColor = Color.LightSalmon;
                }
            }
        }

        //-----------------------------------------------------------
        public CResultAErreur MajChamp()
        {
            CResultAErreur result = CResultAErreur.True;
            if (m_controleChamp != null)
                result = m_controleChamp.MajChamps();
            return result;
        }

        //-----------------------------------------------------------
        public bool LockEdition
        {
            get
            {
                return !m_extModeEdition.ModeEdition;
            }
            set
            {
                m_extModeEdition.ModeEdition = !value;
                if (OnChangeLockEdition != null)
                    OnChangeLockEdition(this, new EventArgs());
            }
        }
        //-----------------------------------------------------------
        public event EventHandler OnChangeLockEdition;

        //-----------------------------------------------------------
        public Color ControlBackColor
        {
            get
            {
                if (m_controleChamp != null)
                    return ((Control)m_controleChamp).BackColor;
                else
                    return BackColor;
            }
            set
            {
                if (m_controleChamp != null)
                    ((Control)m_controleChamp).BackColor = value;
            }
        }
    }
}
