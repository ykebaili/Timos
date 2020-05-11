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
    public partial class CControleEditeGpsPoint : UserControl, IEditeurItemCarte
    {
        CGPSPoint m_pointEdite = null;
        //---------------------------------------------------------
        public CControleEditeGpsPoint()
        {
            InitializeComponent();
            if (m_cmbMarkerType.ListDonnees == null )
            {
                CEnumALibelle<EMapMarkerType>[] valeurs = CEnumALibelle<EMapMarkerType>.GetValeursEnumPossibleInEnumALibelle(typeof(CMapMarkerType));
                List<CEnumALibelle<EMapMarkerType>> lst = new List<CEnumALibelle<EMapMarkerType>>(valeurs);
                lst.Remove(new CMapMarkerType(EMapMarkerType.none));
                m_cmbMarkerType.ListDonnees = lst.ToArray();
                m_cmbMarkerType.ProprieteAffichee = "Libelle";
            }
            m_txtLatitude.DefaultFormat = "° ' ''";
            m_txtLongitude.DefaultFormat = "° ' ''";
        }

        //---------------------------------------------------------
        public static void Autoexec()
        {
            CGestionnaireEditionItemCarte.RegisterEditeur(typeof(CGPSPoint), typeof(CControleEditeGpsPoint));
        }

        //---------------------------------------------------------
        private bool m_bIsInInit = false;
        public void Init(object item)
        {
            m_bIsInInit = true;
            m_pointEdite = item as CGPSPoint;
            m_txtTypePoint.Init(typeof(CGPSTypePoint), "Libelle", false);

            if (m_pointEdite == null)
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
            if (m_pointEdite != null)
            {
                m_txtLibelle.Text = m_pointEdite.Libelle;
                m_txtLatitude.UnitValue = new CValeurUnite(m_pointEdite.Latitude, "°");
                m_txtLongitude.UnitValue = new CValeurUnite(m_pointEdite.Longitude, "°");
                m_cmbMarkerType.SelectedValue = new CMapMarkerType(m_pointEdite.MarkerType);
                m_chkPermanentTooltip.Checked = m_pointEdite.PermanentToolTip;
                m_txtTypePoint.SelectedObject = m_pointEdite.TypePoint;
                UpdateVisuel();
            }
        }

        //---------------------------------------------------------
        public CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;
            if (m_gestionnaireModeEdition.ModeEdition && m_pointEdite != null)
            {
                try
                {
                    UpdateVisuel();
                    m_pointEdite.Libelle = m_txtLibelle.Text;
                    if ( m_txtLongitude.UnitValue != null )
                        m_pointEdite.Latitude = m_txtLatitude.UnitValue.ConvertTo("°").Valeur;
                    if ( m_txtLatitude.UnitValue != null )
                        m_pointEdite.Longitude = m_txtLongitude.UnitValue.ConvertTo("°").Valeur;
                    m_pointEdite.PermanentToolTip = m_chkPermanentTooltip.Checked;
                    if (m_cmbMarkerType.SelectedValue is CMapMarkerType)
                        m_pointEdite.MarkerType = ((CMapMarkerType)m_cmbMarkerType.SelectedValue).Code;
                    m_pointEdite.TypePoint = m_txtTypePoint.ElementSelectionne as CGPSTypePoint;
                }
                catch ( Exception e )
                {
                    result.EmpileErreur(new CErreurException(e));
                }
            }
            return result;
        }


        //---------------------------------------------------------
        private void UpdateVisuel()
        {
            m_panelPointType.Visible = m_txtTypePoint.ElementSelectionne == null;
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
                    m_pointEdite != null;
            }
        }

        private void m_txtLibelle_Validated(object sender, EventArgs e)
        {
            if (ShouldTraiteModification && 
                m_txtLibelle.Text != m_pointEdite.Libelle)
                DoOnModification();
        }

        private void m_cmbMarkerType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if ( ShouldTraiteModification )
            {
                CMapMarkerType type = m_cmbMarkerType.SelectedValue as CMapMarkerType;
                if (type != null && type.Code != m_pointEdite.MarkerType)
                    DoOnModification();

            }
        }

        private void m_chkPermanentTooltip_CheckedChanged(object sender, EventArgs e)
        {
            if ( ShouldTraiteModification)
                DoOnModification();
        }

        private void m_txtLatitude_Validated(object sender, EventArgs e)
        {
            if (ShouldTraiteModification &&
                m_txtLatitude.UnitValue != null &&
                m_txtLatitude.UnitValue.ConvertTo("°").Valeur != m_pointEdite.Latitude)
                DoOnModification();
        }

        private void m_txtLongitude_Validated(object sender, EventArgs e)
        {
            if (ShouldTraiteModification &&
                m_txtLongitude.UnitValue != null &&
                m_txtLongitude.UnitValue.ConvertTo("°").Valeur != m_pointEdite.Longitude)
                DoOnModification();
        }

        private void m_txtTypePoint_ElementSelectionneChanged(object sender, EventArgs e)
        {
            if (ShouldTraiteModification &&
                m_txtTypePoint.ElementSelectionne != m_pointEdite.TypePoint)
                DoOnModification();
        }
    }
}
