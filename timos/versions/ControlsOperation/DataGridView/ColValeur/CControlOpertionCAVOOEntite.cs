using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using timos.data.version;

using sc2i.data;
using sc2i.win32.data.navigation;

namespace timos.version
{
	public partial class CControlOpertionCAVOOEntite : UserControl,IControlVivant
	{
		public CControlOpertionCAVOOEntite()
		{
			InitializeComponent();
			DoubleBuffered = true;
		}


		#region IControlVivant Membres

		public Control Controle
		{
			get { return this; }
		}

		private bool m_bMustBeRedraw = true;
		public bool MustBeRedraw
		{
			get
			{
				return m_bMustBeRedraw;
			}
			set
			{
				m_bMustBeRedraw = value;
			}
		}

		public Bitmap ScreenShot
		{
			get { return CUtilControlVivant.GetScreenShot(this); }
		}

		public bool Initialiser(object valeur)
		{
			m_lnk.Text = "";
			try
			{
				if (valeur == null || valeur == DBNull.Value)
				{
					m_entite = null;
				}
				else
				{
					m_entite = (CControlListeOperationsSurCAVO.CValeurCAVOOEntite)valeur;
				}
			}
			catch
			{
				return false;
			}
			m_lnk.Text = m_entite.DescriptionEntite;
			m_lnk.Enabled = m_entite.ElementAccessible;
		
			return true;
		}
		private CControlListeOperationsSurCAVO.CValeurCAVOOEntite m_entite;
		public object Valeur
		{
			get
			{
				return m_entite;
			}
			set
			{
				try
				{
					if (value == null || value == DBNull.Value)
					{
						m_entite = null;
					}
					else
					{
						m_entite = (CControlListeOperationsSurCAVO.CValeurCAVOOEntite)value;
					}
				}
				catch
				{
				}
			}
		}

		#endregion

		private void m_lnk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (m_entite.ElementAccessible)
			{
				CObjetDonneeAIdNumerique obj = m_entite.Entite;
                //Type typeForm = CFormFinder.GetTypeFormToEdit(m_entite.Entite.GetType());
                //if (typeForm != null)
                //{
                //    CFormEditionStandard form = (CFormEditionStandard)Activator.CreateInstance(
                //        typeForm,
                //        new object[] { obj });
                //    CSc2iWin32DataNavigation.Navigateur.AffichePage(form);
                //}
                CReferenceTypeForm refTypeForm = CFormFinder.GetRefFormToEdit(obj.GetType());
                if (refTypeForm != null)
                {
                    CFormEditionStandard form = refTypeForm.GetForm((CObjetDonneeAIdNumeriqueAuto)obj) as CFormEditionStandard;
                    if (form != null)
                        CSc2iWin32DataNavigation.Navigateur.AffichePage(form);
                }


			}
		}
	}
}
