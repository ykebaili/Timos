using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using sc2i.win32.data.navigation;
using spv.data;
using sc2i.common;
using sc2i.data;
namespace spv.win32
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CSpvSchemaReseau))]
	public partial class CFormEditSpvProg : CFormEditionStandard
	{
		public CFormEditSpvProg()
		{
			InitializeComponent();
		}

		//-------------------------------------------------------------------------
        public CFormEditSpvProg(CSpvSchemaReseau prog)
			:base(prog)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
        public CFormEditSpvProg(CSpvSchemaReseau prog, CListeObjetsDonnees liste)
			:base(prog, liste)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}

		//-------------------------------------------------------------------------
        public CSpvSchemaReseau ProgEdite
		{
			get
			{
                return ObjetEdite as CSpvSchemaReseau;
			}
		}


		//-------------------------------------------------------------------------
		protected override CResultAErreur InitChamps()
		{
			CResultAErreur result = base.InitChamps();
            
            AffecterTitre(I.T("SPV service @1|30012", ProgEdite.Libelle));
			return result;
		}

		//-------------------------------------------------------------------------
		protected override CResultAErreur MAJ_Champs()
		{

			CResultAErreur result = base.MAJ_Champs();
			return result;
		}
	}
}