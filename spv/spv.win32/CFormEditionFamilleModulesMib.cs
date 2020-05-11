using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using sc2i.win32.navigation;
using sc2i.win32.data.navigation;
using sc2i.win32.common;
using sc2i.common;
using sc2i.data;
using timos.data;
using spv.data;

namespace spv.win32
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CSpvFamilleMibmodule))]
    public partial class CFormEditionFamilleModulesMib : CFormEditionStandard, IFormNavigable
	{
		public CFormEditionFamilleModulesMib()
            : base()
		{
			InitializeComponent();
		}

		//-------------------------------------------------------------------------
        public CFormEditionFamilleModulesMib(CSpvFamilleMibmodule famille)
            : base(famille)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
        public CFormEditionFamilleModulesMib(CSpvFamilleMibmodule famille, CListeObjetsDonnees liste)
            : base(famille, liste)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}

		//-------------------------------------------------------------------------
        public CSpvFamilleMibmodule Famille
		{
			get
			{
                return ObjetEdite as CSpvFamilleMibmodule;
			}
		}


		//-------------------------------------------------------------------------
        private CSpvFamilleMibmodule m_lastMother = null;
		protected override CResultAErreur InitChamps()
		{
            if (Famille.IsNew() &&
                Famille.FamilleParente == null)
                Famille.FamilleParente = m_lastMother;
            m_lastMother = (CSpvFamilleMibmodule)Famille.FamilleParente;

            m_arbreHierarchie.AfficheHierarchie(Famille);

			CResultAErreur result = base.InitChamps();

            AffecterTitre(I.T("Mib module family @1|50061", Famille.Libelle));

			return result;
		}

		//-------------------------------------------------------------------------
		protected override CResultAErreur MAJ_Champs()
		{

			CResultAErreur result = base.MAJ_Champs();

			return result;
		}

        private CResultAErreur CFormEditionFamilleModulesMib_OnInitPage(object page)
        {
            CResultAErreur result = CResultAErreur.True;
            using (CWaitCursor waiter = new CWaitCursor())
            {
                if (page == m_pageEntitesFilles)
                {
                    m_panelFilles.InitFromListeObjets(
                    Famille.FamillesFilles,
                    typeof(CSpvFamilleMibmodule),
                    typeof(CFormEditionFamilleModulesMib),
                    Famille,
                    "FamilleParente");
                }
            }
            return result;
        }

        private CResultAErreur CFormEditionFamilleModulesMib_OnMajChampsPage(object page)
        {
            CResultAErreur result = CResultAErreur.True;
            return result;
        }
	}
}