using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using sc2i.common.sig;
using sc2i.common;
using futurocom.sig.cartography;
using sc2i.common.unites;
using sc2i.common.unites.standard;

namespace futurocom.win32.sig.cartography
{
    [AutoExec("Autoexec")]
    public partial class CControleEditeGpsSegment : UserControl, IEditeurItemCarte
    {
        CGPSLineSegment m_segmentEdite = null;
        //---------------------------------------------------------
        public CControleEditeGpsSegment()
        {
            InitializeComponent();
           
            m_txtLatitude.DefaultFormat = "° ' ''";
            m_txtLongitude.DefaultFormat = "° ' ''";
        }

        //---------------------------------------------------------
        public static void Autoexec()
        {
            CGestionnaireEditionItemCarte.RegisterEditeur(typeof(CGPSLineSegment), typeof(CControleEditeGpsSegment));
        }

        //---------------------------------------------------------
        private bool m_bIsInInit = false;
        public void Init(object item)
        {
            m_bIsInInit = true;
            m_segmentEdite = item as CGPSLineSegment;
            m_txtTypeLigne.Init(typeof(CGPSTypeLigne), "Libelle", false);
            if (m_segmentEdite == null)
                Visible = false;
            else
            {
                RefreshData();
            }
            m_bIsInInit = false;
        }

        //---------------------------------------------------------
        public void RefreshData()
        {
            if (m_segmentEdite != null)
            {
                m_txtLibelle.Text = m_segmentEdite.Libelle;
                m_txtLatitude.UnitValue = new CValeurUnite(m_segmentEdite.PointDestination.Latitude, "°");
                m_txtLongitude.UnitValue = new CValeurUnite(m_segmentEdite.PointDestination.Longitude, "°");
                m_selectLineColor.SelectedColor = m_segmentEdite.Couleur;
                m_wndLineWidth.Value = m_segmentEdite.Width;
                m_txtTypeLigne.ElementSelectionne = m_segmentEdite.TypeLigne;
                UpdateVisuel();
            }
        }

        //---------------------------------------------------------
        private void UpdateVisuel()
        {
            m_panelColor.Visible = m_txtTypeLigne.ElementSelectionne == null;
            m_panelWidth.Visible = m_txtTypeLigne.ElementSelectionne == null;
        }

        //---------------------------------------------------------
        public CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;
            if (m_gestionnaireModeEdition.ModeEdition && m_segmentEdite != null)
            {
                try
                {
                    UpdateVisuel();
                    m_segmentEdite.Libelle = m_txtLibelle.Text;
                    SLatLong pt = m_segmentEdite.PointDestination;
                    if ( m_txtLongitude.UnitValue != null )
                        pt.Latitude = m_txtLatitude.UnitValue.ConvertTo("°").Valeur;
                    if ( m_txtLatitude.UnitValue != null )
                        pt.Longitude = m_txtLongitude.UnitValue.ConvertTo("°").Valeur;
                    m_segmentEdite.PointDestination = pt;
                    m_segmentEdite.TypeLigne = m_txtTypeLigne.ElementSelectionne as CGPSTypeLigne;
                    if (m_segmentEdite.TypeLigne != null)
                    {
                        m_segmentEdite.Couleur = m_segmentEdite.TypeLigne.DefaultColor;
                        m_segmentEdite.Width = m_segmentEdite.TypeLigne.DefaultWidth;
                    }
                    else
                    {
                        m_segmentEdite.Couleur = m_selectLineColor.SelectedColor;
                        m_segmentEdite.Width = (int)m_wndLineWidth.Value;
                    }
                }
                catch ( Exception e )
                {
                    result.EmpileErreur(new CErreurException(e));
                }
            }
            return result;
        }

        


        //---------------------------------------------------------
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

        //---------------------------------------------------------
        public event EventHandler OnModification;

        //---------------------------------------------------------
        private void DoOnModification()
        {
            MajChamps();
            if (OnModification != null)
                OnModification(this, new EventArgs());
        }

        //---------------------------------------------------------
        private bool ShouldTraiteModification
        {
            get
            {
                return !m_bIsInInit &&
                    m_gestionnaireModeEdition.ModeEdition &&
                    m_segmentEdite != null;
            }
        }

        private void m_txtLibelle_Validated(object sender, EventArgs e)
        {
            if (ShouldTraiteModification && 
                m_txtLibelle.Text != m_segmentEdite.Libelle)
                DoOnModification();
        }

      

        private void m_txtLatitude_Validated(object sender, EventArgs e)
        {
            if (ShouldTraiteModification &&
                m_txtLatitude.UnitValue != null &&
                m_txtLatitude.UnitValue.ConvertTo("°").Valeur != m_segmentEdite.PointDestination.Latitude)
                DoOnModification();
        }

        private void m_txtLongitude_Validated(object sender, EventArgs e)
        {
            if (ShouldTraiteModification &&
                m_txtLongitude.UnitValue != null &&
                m_txtLongitude.UnitValue.ConvertTo("°").Valeur != m_segmentEdite.PointDestination.Longitude)
                DoOnModification();
        }

        private void m_selectLineColor_OnChangeSelectedColor(object sender, EventArgs e)
        {
            if (ShouldTraiteModification &&
                m_selectLineColor.SelectedColor != m_segmentEdite.Couleur)
                DoOnModification();
                
        }

        private void m_wndLineWidth_Validated(object sender, EventArgs e)
        {
            if (ShouldTraiteModification &&
                (int)m_wndLineWidth.Value != m_segmentEdite.Width)
                DoOnModification();
        }

        private void m_txtTypeLigne_OnSelectedObjectChanged(object sender, EventArgs e)
        {
            if (ShouldTraiteModification &&
               m_txtTypeLigne.ElementSelectionne != m_segmentEdite.TypeLigne)
                DoOnModification();
        }
    }
}
