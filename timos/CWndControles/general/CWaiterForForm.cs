using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;

namespace timos
{
	public class CWaiterForForm : Component
	{
		private IFormAChargement m_formAChargement;
		internal IFormAChargement FormulaireAChargement
		{
			get
			{
				return m_formAChargement;
			}
		}

		private Form m_form;
		public Form Formulaire
		{
			get
			{
				return m_form;
			}
			set
			{
				if (m_form != value) 
				{
					if (m_form != null)
					{
						DettacheForm();
					}
					m_form = value;
					AttacheForm();
				}
			}
		}

		

		private double m_dbOldOpacity;

		internal virtual void AttacheForm()
		{
			if (typeof(IFormAChargement).IsAssignableFrom(Formulaire.GetType()))
			{
				m_formAChargement = (IFormAChargement)Formulaire;
				m_dbOldOpacity = Formulaire.Opacity;
				Formulaire.Opacity = 0;
				FormulaireAChargement.DebutChargement += new EventHandler(FormulaireAChargement_DebutChargement);
				FormulaireAChargement.FinChargement += new EventHandler(FormulaireAChargement_FinChargement);
			}
		}

				
		internal virtual void DettacheForm()
		{
			m_formAChargement = null;
			Formulaire.Opacity = m_dbOldOpacity;
			FormulaireAChargement.DebutChargement -= FormulaireAChargement_DebutChargement;
			FormulaireAChargement.FinChargement -= FormulaireAChargement_FinChargement;
		}

		private void FormulaireAChargement_FinChargement(object sender, EventArgs e)
		{
			FinChargement();
		}

		private void FormulaireAChargement_DebutChargement(object sender, EventArgs e)
		{
			DebutChargement();
		}


		internal virtual void DebutChargement()
		{
		}
		internal virtual void FinChargement()
		{
			Formulaire.Opacity = m_dbOldOpacity;
		}

	}

	public interface IFormAChargement
	{
		event EventHandler DebutChargement;
		event EventHandler FinChargement;
		int DureeAproximativeChargement { get;}
	}

	public delegate void HandlerVoid();
	public class CWaiteurPourFormTimos : CWaiterForForm
	{

		internal override void DebutChargement()
		{
			base.DebutChargement();
			//if (m_frm.InvokeRequired)
			//{
			//    HandlerVoid d = m_frm.Show;
			//    m_frm.Invoke(d);
			//}
			//else
			//{
			//    m_frm.Show();
			//}
			m_frm.FormClosed += new FormClosedEventHandler(m_frm_FormClosed);
			Thread th = new Thread(new ThreadStart(Go));
			th.Start();


		}
		private void Go()
		{
			m_frm.ShowDialog();
		}

		private void m_frm_FormClosed(object sender, FormClosedEventArgs e)
		{
			FinChargement();
		}

		private CFormWaiting m_frm;

		internal override void FinChargement()
		{
			base.FinChargement();
			if (m_frm != null)
			{
				m_frm.FormClosed -= m_frm_FormClosed;
				m_frm.Close();
			}
		}

		internal override void AttacheForm()
		{
			//Control.CheckForIllegalCrossThreadCalls = false;
			base.AttacheForm();
			if (FormulaireAChargement != null)
			{
				m_frm = new CFormWaiting(FormulaireAChargement.DureeAproximativeChargement);
			}
		}

	}
}
