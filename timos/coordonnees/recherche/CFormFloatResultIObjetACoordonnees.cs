using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using sc2i.win32.common;
using sc2i.win32.navigation;
using sc2i.win32.data.navigation;
using sc2i.common;

using timos.data;
using timos.securite;
using sc2i.data;

namespace timos.coordonnees
{
	public partial class CFormFloatResultIObjetACoordonnees : CFloatingFormBase
	{
		private bool m_bInitialise = false;
		private List<IObjetACoordonnees> m_lstObjs = null;
		
		protected CFormFloatResultIObjetACoordonnees()
		{
			m_bInitialise = false;
			InitializeComponent();

		}
		public void Init(List<IObjetACoordonnees> lstObjs)
		{
			m_lstObjs = lstObjs;
			foreach (IObjetACoordonnees o in m_lstObjs)
			{
				ListViewItem itm = new ListViewItem();
				itm.Tag = o;
                
				if (o is CEntiteOrganisationnelle)
					itm.Text = I.T( "Organizational Entities|53");
				else if (o is CSite)
					itm.Text = I.T( "Site|175");
				else if (o is CStock)
					itm.Text = I.T( "Stock|206");
				else if (o is CEquipement)
                    itm.Text = I.T( "Equipment|195");

				itm.SubItems.Add(o.DescriptionElement);
				lv_results.Items.Add(itm);
			}
			m_bInitialise = true;
		}


		public static void AfficherResultats(List<IObjetACoordonnees> lstObjs)
		{
			CFormFloatResultIObjetACoordonnees frm = new CFormFloatResultIObjetACoordonnees();
			frm.Init(lstObjs);
			frm.Show();
		}


		private void lv_results_DoubleClick(object sender, EventArgs e)
		{
			if (m_bInitialise && lv_results.SelectedItems.Count == 1)
				NaviguerVersObjetACoordonnee((IObjetACoordonnees)lv_results.SelectedItems[0].Tag);

		}

		public static void NaviguerVersObjetACoordonnee(IObjetACoordonnees obj)
		{
			Type t = typeof(string);
            
            CReferenceTypeForm refTypeForm = null;
			if (obj is CEntiteOrganisationnelle)
				//t = CFormFinder.GetTypeFormToEdit(typeof(CEntiteOrganisationnelle));
                refTypeForm = CFormFinder.GetRefFormToEdit(typeof(CEntiteOrganisationnelle));
			else if (obj is CSite)
				//t = CFormFinder.GetTypeFormToEdit(typeof(CSite));
                refTypeForm = CFormFinder.GetRefFormToEdit(typeof(CSite));
			else if (obj is CStock)
				//t = CFormFinder.GetTypeFormToEdit(typeof(CStock));
                refTypeForm = CFormFinder.GetRefFormToEdit(typeof(CStock));
			else if (obj is CEquipement)
				//t = CFormFinder.GetTypeFormToEdit(typeof(CEquipement));
                refTypeForm = CFormFinder.GetRefFormToEdit(typeof(CEquipement));

            //if (typeof(IFormNavigable).IsAssignableFrom(t))
            //{
            //    IFormNavigable iformnav = (IFormNavigable)Activator.CreateInstance(t, new object[] { obj });
            //    CTimosApp.Navigateur.AffichePage(iformnav);
            //}
            if (refTypeForm != null)
            {
                IFormNavigable iformnav = refTypeForm.GetForm((CObjetDonneeAIdNumeriqueAuto)obj) as IFormNavigable;
                if (iformnav != null)
                    CTimosApp.Navigateur.AffichePage(iformnav);
            }


		}

        private void CFormFloatResultIObjetACoordonnees_Load(object sender, EventArgs e)
        {
            sc2i.win32.common.CWin32Traducteur.Translate(this);
        }

		

	}
}