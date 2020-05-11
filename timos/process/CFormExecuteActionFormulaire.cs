using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Resources;
using System.Windows.Forms;

using sc2i.common;
using sc2i.data.dynamic;
using sc2i.formulaire;
using sc2i.multitiers.client;
using sc2i.win32.common;
using sc2i.win32.data.dynamic;
using sc2i.process;
using sc2i.formulaire.win32;
using System.Threading;
using System.Runtime.Remoting.Lifetime;
using sc2i.expression;

namespace timos.process
{
	/// <summary>
	/// Description résumée de CFormExecuteActionFormulaire.
	/// </summary>
	public class CFormExecuteActionFormulaire : Form
	{
		private CActionFormulaire m_actionFormulaire = null;
		private Panel m_panelFormulaire;
		private ToolTip m_tooltip;
		private Button m_btnAnnuler;
		private Button m_btnOk;
		private IContainer components;

		public CFormExecuteActionFormulaire()
		{
			//
			// Requis pour la prise en charge du Concepteur Windows Forms
			//
			InitializeComponent();

			//
			// TODO : ajoutez le code du constructeur après l'appel à InitializeComponent
			//
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

		#region Code généré par le Concepteur Windows Form
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormExecuteActionFormulaire));
            this.m_panelFormulaire = new System.Windows.Forms.Panel();
            this.m_tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.m_btnAnnuler = new System.Windows.Forms.Button();
            this.m_btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_panelFormulaire
            // 
            this.m_panelFormulaire.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelFormulaire.Location = new System.Drawing.Point(0, 0);
            this.m_panelFormulaire.Name = "m_panelFormulaire";
            this.m_panelFormulaire.Size = new System.Drawing.Size(452, 327);
            this.m_panelFormulaire.TabIndex = 0;
            // 
            // m_btnAnnuler
            // 
            this.m_btnAnnuler.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.m_btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnAnnuler.ForeColor = System.Drawing.Color.White;
            this.m_btnAnnuler.Image = ((System.Drawing.Image)(resources.GetObject("m_btnAnnuler.Image")));
            this.m_btnAnnuler.Location = new System.Drawing.Point(234, 333);
            this.m_btnAnnuler.Name = "m_btnAnnuler";
            this.m_btnAnnuler.Size = new System.Drawing.Size(40, 40);
            this.m_btnAnnuler.TabIndex = 5;
            this.m_btnAnnuler.Click += new System.EventHandler(this.m_btnAnnuler_Click);
            // 
            // m_btnOk
            // 
            this.m_btnOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.m_btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnOk.ForeColor = System.Drawing.Color.White;
            this.m_btnOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btnOk.Image")));
            this.m_btnOk.Location = new System.Drawing.Point(178, 333);
            this.m_btnOk.Name = "m_btnOk";
            this.m_btnOk.Size = new System.Drawing.Size(40, 40);
            this.m_btnOk.TabIndex = 4;
            this.m_btnOk.Click += new System.EventHandler(this.m_btnOk_Click);
            // 
            // CFormExecuteActionFormulaire
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(453, 373);
            this.ControlBox = false;
            this.Controls.Add(this.m_btnAnnuler);
            this.Controls.Add(this.m_btnOk);
            this.Controls.Add(this.m_panelFormulaire);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CFormExecuteActionFormulaire";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form|555";
            this.Load += new System.EventHandler(this.CFormExecuteActionFormulaire_Load);
            this.ResumeLayout(false);

		}
		#endregion

		public CResultAErreur ExecuteAction ( CActionFormulaire action )
		{
			using (C2iSponsor sponsor = new C2iSponsor())
			{
                //sponsor.Label = "3 - Execute Action";
                
                sponsor.Register(action.Process);
				CResultAErreur result = CResultAErreur.True;
				m_actionFormulaire = action;

                DialogResult dialogResult = DialogResult.Cancel;

                CTimosApp.Navigateur.Invoke((MethodInvoker)delegate
                {
                    result = SafeExecuteAction(sponsor, ref result, ref dialogResult);
                });
                return result;
			}
			
		}

        private CResultAErreur SafeExecuteAction(C2iSponsor sponsor, ref CResultAErreur result, ref DialogResult dialogResult)
        {
            bool bBoucle = true;

            while (bBoucle)
            {
                bBoucle = false;
                CCreateur2iFormulaireV2 createur = new CCreateur2iFormulaireV2();
                //Fait passer le formulaire par le réseau
                byte[] dataFormulaire = m_actionFormulaire.GetDataSerialisationFormulairePourClient();
                MemoryStream stream = new MemoryStream(dataFormulaire);
                BinaryReader reader = new BinaryReader(stream);
                CSerializerReadBinaire serializer = new CSerializerReadBinaire(reader);
                serializer.AttacheObjet(typeof(IElementAVariablesDynamiquesBase), m_actionFormulaire.Process);
                I2iSerializable formulaireSer = null;
                result = serializer.TraiteObject(ref formulaireSer);

                reader.Close();
                stream.Close();

                if (!result)
                {
                    result.EmpileErreur(I.T("Error while retrieving the form|30253"));
                    return result;
                }
                C2iWnd formulaire = (C2iWnd)formulaireSer;

                createur.CreateControlePrincipalEtChilds(m_panelFormulaire, formulaire, m_actionFormulaire.Process);
                createur.ControleValeursAvantValidation = true;
                CProxyElementAVariables proxy = m_actionFormulaire.Process.GetProxyElementAVariables(sponsor);
                proxy.ContexteDonneeLocal = sc2i.win32.data.CSc2iWin32DataClient.ContexteCourant;

                createur.ElementEdite = proxy;

                foreach (IVariableDynamique varDyn in m_actionFormulaire.Process.ListeVariables)
                {
                    sponsor.Register(varDyn);
                }

                Size szFormulaire = formulaire.Size;
                Size szOldPanel = m_panelFormulaire.Size;
                Size newSizeThis = Size;
                newSizeThis.Width = Size.Width - szOldPanel.Width + szFormulaire.Width;
                newSizeThis.Height = Size.Height - szOldPanel.Height + szFormulaire.Height;
                Size = newSizeThis;
                m_panelFormulaire.Size = szFormulaire;

                m_btnAnnuler.Visible = m_actionFormulaire.CanCancel;
                this.Text = m_actionFormulaire.Descriptif;
                dialogResult = ShowDialog(CTimosApp.Navigateur);
                if (dialogResult == DialogResult.OK)
                {
                    CResultAErreur resultTmp = createur.MAJ_Champs();
                    if (!resultTmp)
                    {
                        CFormAlerte.Afficher(resultTmp.Erreur);
                        bBoucle = true;
                    }
                }

            }
            result.Data = C2iDialogResult.Get2iDialogResultFromDialogResult(dialogResult);
            return result;
        }

		///////////////////////////////////////////////
		private void m_btnOk_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

		///////////////////////////////////////////////
		private void m_btnAnnuler_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

        private void CFormExecuteActionFormulaire_Load(object sender, EventArgs e)
        {
            sc2i.win32.common.CWin32Traducteur.Translate(this);
        }
	}

	///////////////////////////////////////////////
	[AutoExec("Autoexec")]
	public class CServiceActionFormulaire : CServiceSurClient
	{
		///////////////////////////////////////////////
		public static void Autoexec()
		{
			CSessionClient.RegisterServiceSurClient ( new CServiceActionFormulaire() );
		}

		///////////////////////////////////////////////
		public override string IdService
		{
			get
			{
				return CActionFormulaire.c_idServiceClientFormulaire;
			}
		}


        //----------------------------------------------------------------------------
        private CActionFormulaire m_actionToExecute = null;
        private CResultAErreur m_resultAction = CResultAErreur.True;
        public void ShowFormulaire()
        {
            using (C2iSponsor sponsor = new C2iSponsor())
            {
                //sponsor.Label = "2 - Show Formulaire";
                sponsor.Register(m_actionToExecute);
                CFormExecuteActionFormulaire form = new CFormExecuteActionFormulaire();
                m_resultAction = form.ExecuteAction(m_actionToExecute);
            }
        }


        //----------------------------------------------------------------------------
        public override CResultAErreur RunService(object parametre)
		{
			CResultAErreur result = CResultAErreur.True;

            CActionFormulaire action = parametre as CActionFormulaire;
			if (action == null)
			{
				result.EmpileErreur( I.T("Incompatible parameter type|30254"));
				return result;
			}
            using (C2iSponsor sponsor = new C2iSponsor())
            {
                m_actionToExecute = action;
                sponsor.Register(m_actionToExecute);
                
                Thread th = new Thread(new ThreadStart(ShowFormulaire));
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
                th.Join();
                return m_resultAction;
            }
		}
	}

}
