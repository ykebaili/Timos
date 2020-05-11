using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using sc2i.drawing;
using sc2i.data.dynamic;
using sc2i.data;
using sc2i.win32.navigation;
using sc2i.win32.data.navigation;
using sc2i.common;
using sc2i.win32.data;
using sc2i.win32.common;
using sc2i.win32.data.dynamic;

using timos.data;

namespace timos
{
	public class CFormDeleteIElementDeProjet : Form
	{


		#region Designer generated code

		private Button m_btnOk;
		private Button m_btnAnnuler;
		private RadioButton m_rbtSuppression;
		private RadioButton m_rbtnDetacher;
		private System.ComponentModel.IContainer components = null;

		//-------------------------------------------------------------------------
		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.m_btnOk = new System.Windows.Forms.Button();
            this.m_btnAnnuler = new System.Windows.Forms.Button();
            this.m_rbtSuppression = new System.Windows.Forms.RadioButton();
            this.m_rbtnDetacher = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // m_btnOk
            // 
            this.m_btnOk.Location = new System.Drawing.Point(17, 88);
            this.m_btnOk.Name = "m_btnOk";
            this.m_btnOk.Size = new System.Drawing.Size(75, 23);
            this.m_btnOk.TabIndex = 0;
            this.m_btnOk.Text = "Ok|10";
            this.m_btnOk.UseVisualStyleBackColor = true;
            this.m_btnOk.Click += new System.EventHandler(this.m_btnOk_Click);
            // 
            // m_btnAnnuler
            // 
            this.m_btnAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnAnnuler.Location = new System.Drawing.Point(118, 88);
            this.m_btnAnnuler.Name = "m_btnAnnuler";
            this.m_btnAnnuler.Size = new System.Drawing.Size(75, 23);
            this.m_btnAnnuler.TabIndex = 0;
            this.m_btnAnnuler.Text = "Annuler|11";
            this.m_btnAnnuler.UseVisualStyleBackColor = true;
            this.m_btnAnnuler.Click += new System.EventHandler(this.m_btnAnnuler_Click);
            // 
            // m_rbtSuppression
            // 
            this.m_rbtSuppression.AutoSize = true;
            this.m_rbtSuppression.Location = new System.Drawing.Point(12, 23);
            this.m_rbtSuppression.Name = "m_rbtSuppression";
            this.m_rbtSuppression.Size = new System.Drawing.Size(135, 17);
            this.m_rbtSuppression.TabIndex = 1;
            this.m_rbtSuppression.Text = "Remove definitely|1235";
            this.m_rbtSuppression.UseVisualStyleBackColor = true;
            // 
            // m_rbtnDetacher
            // 
            this.m_rbtnDetacher.AutoSize = true;
            this.m_rbtnDetacher.Checked = true;
            this.m_rbtnDetacher.Location = new System.Drawing.Point(12, 46);
            this.m_rbtnDetacher.Name = "m_rbtnDetacher";
            this.m_rbtnDetacher.Size = new System.Drawing.Size(162, 17);
            this.m_rbtnDetacher.TabIndex = 1;
            this.m_rbtnDetacher.TabStop = true;
            this.m_rbtnDetacher.Text = "Detach from the project|1236";
            this.m_rbtnDetacher.UseVisualStyleBackColor = true;
            // 
            // CFormDeleteIElementDeProjet
            // 
            this.AcceptButton = this.m_btnOk;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.m_btnAnnuler;
            this.ClientSize = new System.Drawing.Size(215, 117);
            this.Controls.Add(this.m_rbtnDetacher);
            this.Controls.Add(this.m_rbtSuppression);
            this.Controls.Add(this.m_btnAnnuler);
            this.Controls.Add(this.m_btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CFormDeleteIElementDeProjet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Delete|828";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CFormDeleteIElementDeProjet_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion


		public CFormDeleteIElementDeProjet()
		{
			InitializeComponent();
		}

		public static DialogResult AfficherDialog(List<I2iObjetGraphique> objs)
		{
			CFormDeleteIElementDeProjet frm = new CFormDeleteIElementDeProjet();
			frm.Init(objs);
			CWin32Traducteur.Translate(frm);
			return frm.ShowDialog();
		}



		public void Init(List<I2iObjetGraphique> objs)
		{
			foreach(I2iObjetGraphique obj in objs)
				if(!(CUtilProjet.GetTypeElement(obj).HasValue))
					DialogResult = DialogResult.Abort;
			
			m_objsGraphiques = objs;//.ConvertAll<IElementDeProjet>(CUtilProjet.GetIElementDeProjet);// new Converter<I2iObjetGraphique, IElementDeProjet>(CUtilProjet.GetIElementDeProjet));// delegate(I2iObjetGraphique obj) { return (IWndElementDeProjetPlanifiable)obj; });

			string strDescrip = CUtilProjet.GetIElementDeProjet( m_objsGraphiques[0]).DescriptionElement;
			if (objs.Count == 1)
				Text = I.T("@1 removing...|1237", strDescrip);
			else
			{
				bool bOnlyOnType = false;
				for(int n = 1; n < m_objsGraphiques.Count ; n++)
					if (CUtilProjet.GetIElementDeProjet( m_objsGraphiques[n]).DescriptionElement != strDescrip)
					{
						bOnlyOnType = false;
						break;
					}

				if (bOnlyOnType)
					Text = I.T("@1 removing...|1237", strDescrip);
				else
					Text = I.T("Removing...|30409");
			}
		}

		
		private List<I2iObjetGraphique> m_objsGraphiques;


		private void m_btnOk_Click(object sender, EventArgs e)
		{
			CResultAErreur result = CResultAErreur.True;

			CContexteDonnee ctx = null;
			int? nIDProj = null;
			CFiltreData filtreLiens = new CFiltreData();
			CFiltreData filtreProjets = new CFiltreData();
			CFiltreData filtreInters = new CFiltreData();
			bool bFiltreLiens = false;
			bool bFiltreProjets = false;
			bool bFiltreInters = false;

			foreach (I2iObjetGraphique objGraph in m_objsGraphiques)
			{
				IElementDeProjet ele = CUtilProjet.GetIElementDeProjet(objGraph);
				if (!(ele is CObjetDonnee))
					return;
				CObjetDonnee obj = (CObjetDonnee)ele;
				if (!obj.IsValide())
					return;
				if (ctx == null)
					ctx = obj.ContexteDonnee;
				if (ele.Projet == null)
					return;
				if (!nIDProj.HasValue)
					nIDProj = ele.Projet.Id;
				
				CFiltreData filtreBase = filtreLiens;

				CFiltreData filtreTmp;

				if (m_rbtnDetacher.Checked)
				{
					bFiltreLiens = true;

					if(objGraph is IWndElementDeProjetPlanifiable)
						((IWndElementDeProjetPlanifiable)objGraph).Detacher = true;

					string strRqt = "";
					switch (ele.TypeElementDeProjet.Code)
					{
						case ETypeElementDeProjet.Projet:
							strRqt = CLienDeProjet.c_champPrjA + " = @1 OR " + CLienDeProjet.c_champPrjB + " = @1";
							break;
						case ETypeElementDeProjet.Intervention:
							strRqt = CLienDeProjet.c_champInterA + " = @1 OR " + CLienDeProjet.c_champInterB + " = @1";
							break;
						case ETypeElementDeProjet.Lien:
							strRqt = CLienDeProjet.c_champId + " =@1";
							break;
						default:
							return;
					}
					ele.Projet = null;
					filtreTmp = new CFiltreData( strRqt, ele.Id);
				}
				else
				{
					switch (ele.TypeElementDeProjet.Code)
					{
						case ETypeElementDeProjet.Intervention:
							bFiltreInters = true;
							filtreBase = filtreInters;
							break;
						case ETypeElementDeProjet.Lien:
							bFiltreLiens = true;
							filtreBase = filtreLiens;
							break;
						case ETypeElementDeProjet.Projet:
							bFiltreProjets = true;
							filtreBase = filtreProjets;
							break;
						default:
						 break;
					}
					filtreTmp = new CFiltreData(CUtilProjet.GetChampIDElement(objGraph) + " =@1", ele.Id);
				}

				if (filtreBase.Filtre != "")
					filtreBase = CFiltreData.GetOrFiltre(filtreBase, filtreTmp);
				else
					filtreBase = filtreTmp;

				if (m_rbtnDetacher.Checked)
					filtreLiens = filtreBase;
				else
					switch (ele.TypeElementDeProjet.Code)
					{
						case ETypeElementDeProjet.Projet:
							filtreProjets = filtreTmp;
							break;
						case ETypeElementDeProjet.Intervention:
							filtreInters = filtreTmp;
							break;
						case ETypeElementDeProjet.Lien:
							filtreLiens = filtreTmp;
							break;
						default:
							break;
					}
			}
			CFiltreData filtreSurProjet = new CFiltreData(CProjet.c_champId + " =@1", nIDProj.Value);
			if (bFiltreLiens )
			{
				filtreLiens = CFiltreData.GetAndFiltre(filtreLiens, filtreSurProjet);
				result = CObjetDonneeAIdNumerique.Delete(new CListeObjetsDonnees(ctx, typeof(CLienDeProjet), filtreLiens));
			}
			if(result && bFiltreInters)
			{
				filtreInters = CFiltreData.GetAndFiltre(filtreInters, filtreSurProjet);
				result = CObjetDonneeAIdNumerique.Delete(new CListeObjetsDonnees(ctx, typeof(CIntervention), filtreInters));				
			}
			if (result && bFiltreProjets)
			{
				filtreSurProjet = new CFiltreData(CProjet.c_champIdParent + " =@1", nIDProj);
				filtreProjets = CFiltreData.GetAndFiltre(filtreProjets, filtreSurProjet);
				result = CObjetDonneeAIdNumerique.Delete(new CListeObjetsDonnees(ctx, typeof(CProjet), filtreProjets));
			}

			if (!result)
			{
				CFormAlerte.Afficher(result.Erreur);
				return;
			}

			DialogResult = DialogResult.OK;
		}
		private void m_btnAnnuler_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		private void CFormDeleteIElementDeProjet_FormClosing(object sender, FormClosingEventArgs e)
		{
			if(DialogResult != DialogResult.OK)
				DialogResult = DialogResult.Cancel;
		}
	
	}
}

