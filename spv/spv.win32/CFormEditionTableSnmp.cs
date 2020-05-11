using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using sc2i.win32.navigation;
using sc2i.win32.data.navigation;
using sc2i.common;
using sc2i.data;
using timos.data;
using spv.data;

namespace spv.win32
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CSpvTypeqinc))]
    public partial class CFormEditionTableSnmp : CFormEditionStandard, IFormNavigable
	{
		public CFormEditionTableSnmp()
            : base()
		{
			InitializeComponent();
		}

		//-------------------------------------------------------------------------
        public CFormEditionTableSnmp(CSpvTypeqinc tableSnmp)
            : base(tableSnmp)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
        public CFormEditionTableSnmp(CSpvTypeqinc tableSnmp, CListeObjetsDonnees liste)
            : base(tableSnmp, liste)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}

		//-------------------------------------------------------------------------
        public CSpvTypeqinc TableSnmp
		{
			get
			{
                return ObjetEdite as CSpvTypeqinc;
			}
		}


		//-------------------------------------------------------------------------
		protected override CResultAErreur InitChamps()
		{
			CResultAErreur result = base.InitChamps();

            AffecterTitre(I.T("Snmp Table @1|50008", TableSnmp.Libelle));

            InitComboTypeEquipement();

			return result;
		}

		//-------------------------------------------------------------------------
		protected override CResultAErreur MAJ_Champs()
		{

			CResultAErreur result = base.MAJ_Champs();

            if (m_cmbTypeEquipement.SelectedValue != null)
                TableSnmp.TypeEquipementAttache = (CSpvTypeq)m_cmbTypeEquipement.SelectedValue;

			return result;
		}

        
        private void InitComboTypeEquipement()
        {
            CListeObjetsDonnees liste = new CListeObjetsDonnees(ContexteDonnee, typeof(CSpvTypeq));
            m_cmbTypeEquipement.Fill(liste, "Libelle", false);

            if (TableSnmp.TypeEquipementAttache != null)
                m_cmbTypeEquipement.SelectedValue = TableSnmp.TypeEquipementAttache;
            /*
            m_SelectTypeEquipement.Init(
                typeof(CFormListeTypesEquipements),
                "Libelle",
                CFournisseurFiltreRapide.GetFiltreRapideForType(typeof(CTypeEquipement)));
            m_SelectTypeEquipement.ElementSelectionne = TableSnmpEdite.TypeEquipementAttache;*/
        }
	}
}