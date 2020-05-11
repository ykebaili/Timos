using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using sc2i.common;
using sc2i.win32.common;
using sc2i.data.dynamic;

using timos.data;
using sc2i.drawing;

namespace timos
{
	public partial class CPanEditWndLienDeProjet : UserControl, IControlALockEdition, IEditeurWndElementDeProjet
	{
		private CLienDeProjet m_lienDeProjet = null;
		private CFournisseurPropDynStd m_fournisseurPropDyn = new CFournisseurPropDynStd(true);
		private bool m_bInitialise = false;

		public event EventHandler ProprieteModifiee;


		private Hashtable m_idxTps;
		//------------------------------------------------
		public CPanEditWndLienDeProjet()
		{
			InitializeComponent();
		}

		//------------------------------------------------
		public void Init(I2iObjetGraphique wndLienProjet)
		{
			m_bInitialise = false;

			if (!(wndLienProjet is CWndLienDeProjet))
			{
				m_lienDeProjet = null;
				return;
			}
			
			m_lienDeProjet = ((CWndLienDeProjet)wndLienProjet).LienDeProjet;

			InitTypeLiens();

			m_wndFormule.Init(m_fournisseurPropDyn, typeof(CLienDeProjet));

			m_extLinkField.FillDialogFromObjet(m_lienDeProjet);


			m_txtTolerance.Visible = m_lienDeProjet.Tolerance != null;
			m_txtTolerance.Text = m_lienDeProjet.Tolerance == null ? "" : m_lienDeProjet.Tolerance.ToString();
			m_chkNoTol.Checked = !m_txtTolerance.Visible;

			ActualiserLabelTypeLiaison();
			MAJAnomalies();
			m_bInitialise = true;
		}


		private void ActualiserLabelTypeLiaison()
		{
			m_txtTypeLiaison.Text = (string)m_idxTps[m_lienDeProjet.TypeRelation.CodeInt];
		}

		private void MAJAnomalies()
		{
			m_ctrlAnomalies.Init(m_lienDeProjet);
			m_panAno.Visible = m_ctrlAnomalies.HasAnomalies;
		}
		private void InitTypeLiens()
		{
			List<CTypeLienDeProjet> tps = new List<CTypeLienDeProjet>();
			tps.Add(new CTypeLienDeProjet(ETypeLienDeProjet.DemarrentEnMemeTemps));
			tps.Add(new CTypeLienDeProjet(ETypeLienDeProjet.FinissentEnMemeTemps));
			tps.Add(new CTypeLienDeProjet(ETypeLienDeProjet.ElementADemarreQuandElementBTermine));
			tps.Add(new CTypeLienDeProjet(ETypeLienDeProjet.ElementBDemarreQuandElementATermine));

			m_idxTps = new Hashtable();
			//m_cmbTypeLiaison.Items.Clear();
			foreach (CTypeLienDeProjet t in tps)
			{
				string strTitre = "";
				switch (t.Code)
				{
					case ETypeLienDeProjet.DemarrentEnMemeTemps:
						strTitre = I.T("@1 and @2 begin at the same time|1367", m_lienDeProjet.ElementA.DescriptionElement, m_lienDeProjet.ElementB.DescriptionElement);
						break;
					case ETypeLienDeProjet.FinissentEnMemeTemps:
						strTitre = I.T("@1 and @2 finish at the same time|1368", m_lienDeProjet.ElementA.DescriptionElement, m_lienDeProjet.ElementB.DescriptionElement);
						break;
					case ETypeLienDeProjet.ElementADemarreQuandElementBTermine:
						strTitre = I.T("@1 begin when @2 finish|1369", m_lienDeProjet.ElementA.DescriptionElement, m_lienDeProjet.ElementB.DescriptionElement);
						break;
					case ETypeLienDeProjet.ElementBDemarreQuandElementATermine:
						strTitre = I.T("@1 begin when @2 finish|1369", m_lienDeProjet.ElementB.DescriptionElement, m_lienDeProjet.ElementA.DescriptionElement);
						break;
					default:
						break;
				}
				m_idxTps.Add(t.CodeInt, strTitre);
			}
			m_rbtDebutA.Checked = m_lienDeProjet.TypeAttacheElementA.Code == ETypeAttacheLienDeProjet.Debut ? true : false;
			m_rbtFinA.Checked = m_lienDeProjet.TypeAttacheElementA.Code == ETypeAttacheLienDeProjet.Fin ? true : false;

			m_rbtDebutB.Checked = m_lienDeProjet.TypeAttacheElementB.Code == ETypeAttacheLienDeProjet.Debut ? true : false;
			m_rbtFinB.Checked = m_lienDeProjet.TypeAttacheElementB.Code == ETypeAttacheLienDeProjet.Fin ? true : false;
		}

		public CLienDeProjet LienDeProjet
		{
			get
			{
				return m_lienDeProjet;
			}
		}

		public CResultAErreur MAJChamps()
		{
			if (!LockEdition)
			{
				m_lienDeProjet.TypeAttacheElementA = m_rbtDebutA.Checked ? ETypeAttacheLienDeProjet.Debut : ETypeAttacheLienDeProjet.Fin;
				m_lienDeProjet.TypeAttacheElementB = m_rbtDebutB.Checked ? ETypeAttacheLienDeProjet.Debut : ETypeAttacheLienDeProjet.Fin;
				//m_lienDeProjet.TypeRelation = (CTypeLienDeProjet)m_idxTps[m_cmbTypeLiaison.SelectedIndex];
				if (m_txtTolerance.Visible)
					m_lienDeProjet.Tolerance = m_txtTolerance.DoubleValue;
				else
					m_lienDeProjet.Tolerance = null;

				return m_extLinkField.FillObjetFromDialog(m_lienDeProjet);
			}
			else 
				return CResultAErreur.True;
		}

		#region IControlALockEdition Membres

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

		#endregion

		private void m_tbnTolerance_TextChanged(object sender, EventArgs e)
		{
			if(m_bInitialise)
				MAJAnomalies();
		}

		private void m_cmbTypeLiaison_SelectedIndexChanged(object sender, EventArgs e)
		{
			if(m_bInitialise)
				MAJAnomalies();
		}


		#region IEditeurWndElementDeProjet Membres
		
		public bool HasElementValide
		{
			get { return m_lienDeProjet != null && m_lienDeProjet.IsValide(); }
		}

		#endregion



		private void ChangementAttacheB(object sender, EventArgs e)
		{
			if (m_bInitialise)
			{
				m_lienDeProjet.TypeAttacheElementB = m_rbtDebutB.Checked ? ETypeAttacheLienDeProjet.Debut : ETypeAttacheLienDeProjet.Fin;
				ActualiserLabelTypeLiaison();
				if (ProprieteModifiee != null)
					ProprieteModifiee(this, new EventArgs());
			}
		}

		private void ChangementAttacheA(object sender, EventArgs e)
		{
			if(m_bInitialise)
			{
				m_lienDeProjet.TypeAttacheElementA = m_rbtDebutA.Checked ? ETypeAttacheLienDeProjet.Debut : ETypeAttacheLienDeProjet.Fin;
				ActualiserLabelTypeLiaison();
				if (ProprieteModifiee != null)
					ProprieteModifiee(this, new EventArgs());
			}
		}

		private void m_chkNoTol_CheckedChanged(object sender, EventArgs e)
		{
			if (m_bInitialise)
			{
				m_txtTolerance.Visible = !m_chkNoTol.Checked;
				if (m_txtTolerance.Visible)
					m_lienDeProjet.Tolerance = m_txtTolerance.DoubleValue;
				else
					m_lienDeProjet.Tolerance = null;
			}
		}
	}
}
