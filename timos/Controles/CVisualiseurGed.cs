using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;

namespace timos
{
	/// <summary>
	/// Description résumée de CVisualiseurGed.
	/// </summary>
	public class CVisualiseurGed : System.Windows.Forms.UserControl
	{
		private sc2i.win32.common.C2iImageViewer m_wndImageViewer;
		private CrystalDecisions.Windows.Forms.CrystalReportViewer m_viewerCrystal;
		/// <summary> 
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CVisualiseurGed()
		{
			// Cet appel est requis par le Concepteur de formulaires Windows.Forms.
			InitializeComponent();

			// TODO : ajoutez les initialisations après l'appel à InitializeComponent

		}

		/// <summary> 
		/// Nettoyage des ressources utilisées.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		private bool VerifieSignature ( string strNomFichier, char[] signature )
		{
			try
			{
				FileStream stream = new FileStream(strNomFichier, FileMode.Open);
				byte[] buffer = new byte[signature.Length];
				bool bReadOk = stream.Read(buffer, 0, signature.Length) == signature.Length;
				stream.Close();
				if (bReadOk)
				{
					for (int nChar = 0; nChar < buffer.Length; nChar++)
						if ((char)buffer[nChar] != signature[nChar])
							return false;
				}
				return true;
			}
			catch
			{
				return false;
			}
		}



		#region Code généré par le Concepteur de composants
		/// <summary> 
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
			this.m_wndImageViewer = new sc2i.win32.common.C2iImageViewer();
			this.m_viewerCrystal = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.SuspendLayout();
			// 
			// m_wndImageViewer
			// 
			this.m_wndImageViewer.BackColor = System.Drawing.Color.White;
			this.m_wndImageViewer.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_wndImageViewer.Image = null;
			this.m_wndImageViewer.Location = new System.Drawing.Point(32, 40);
			this.m_wndImageViewer.Name = "m_wndImageViewer";
			this.m_wndImageViewer.Size = new System.Drawing.Size(72, 24);
			this.m_wndImageViewer.TabIndex = 2;
			this.m_wndImageViewer.Zoom = 1;
			// 
			// m_viewerCrystal
			// 
			this.m_viewerCrystal.ActiveViewIndex = -1;
			this.m_viewerCrystal.BackColor = System.Drawing.Color.White;
			this.m_viewerCrystal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_viewerCrystal.Location = new System.Drawing.Point(210, 40);
			this.m_viewerCrystal.Name = "m_viewerCrystal";
			this.m_viewerCrystal.SelectionFormula = "";
			this.m_viewerCrystal.Size = new System.Drawing.Size(225, 167);
			this.m_viewerCrystal.TabIndex = 3;
			this.m_viewerCrystal.ViewTimeSelectionFormula = "";
			this.m_viewerCrystal.Visible = false;
			// 
			// CVisualiseurGed
			// 
			this.Controls.Add(this.m_viewerCrystal);
			this.Controls.Add(this.m_wndImageViewer);
			this.Name = "CVisualiseurGed";
			this.Size = new System.Drawing.Size(496, 304);
			this.ResumeLayout(false);

		}
		#endregion
		public bool ShowDocument ( string strNomFichierLocal )
		{
			//Masque tous les contrôles de visualisation
			foreach ( Control ctrl in this.Controls )
				ctrl.Hide();

			if ( File.Exists ( strNomFichierLocal ) )
			{
				try
				{
					//PDF
					//Un fichier PDF commence par '%PDF'
					if ( VerifieSignature ( strNomFichierLocal, new char[]{'%','P','D','F'} ) )
					{
						//A implémenter : le pdf
						return false;
					}
				}
				catch{}
				try
				{
					//RPT
					//Un rpt commence par 00 CF 11 e0 a1 b1 1a e1
					//mais je n'en suis pas sûr !
					char[] sgn = new char[] { '\xD0', '\xCF', '\x11', '\xe0', '\xa1', '\xb1', '\x1a', '\xe1' };
					if ( VerifieSignature ( strNomFichierLocal, sgn ) )
					{
						ReportDocument document = new ReportDocument();
						document.Load ( strNomFichierLocal );
						m_viewerCrystal.Dock = DockStyle.Fill;
						m_viewerCrystal.Visible = true;
						m_viewerCrystal.ReportSource = document;
						m_viewerCrystal.Refresh();
						return true;
					}
				}
				catch{}
				try
				{
					//Image 
					Image img = Image.FromFile ( strNomFichierLocal );
					if ( img != null )
					{
						m_wndImageViewer.Dock = DockStyle.Fill;
						m_wndImageViewer.Image = img;
						m_wndImageViewer.Visible = true;
						return true;
					}
				}
				catch
				{}
			}

			return false;
		}

	}
}
