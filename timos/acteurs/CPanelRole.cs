using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using sc2i.data;
using sc2i.common;
using timos.acteurs;

namespace timos
{
	/// <summary>
	/// Description résumée de CPanelRole.
	/// </summary>
	public class CPanelRole : System.Windows.Forms.UserControl
	{
		protected CObjetDonnee m_objet;
		protected sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
		protected sc2i.win32.common.CExtLinkField m_extLinkField;
		/// <summary> 
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CPanelRole()
		{
			// Cet appel est requis par le Concepteur de formulaires Windows.Forms.
			InitializeComponent();
		}

		public CPanelRole(CObjetDonnee objet)
		{
			// Cet appel est requis par le Concepteur de formulaires Windows.Forms.
			InitializeComponent();

			m_objet = objet;
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

		#region Component Designer generated code
		/// <summary> 
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
			this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
			this.m_extLinkField = new sc2i.win32.common.CExtLinkField();
			// 
			// CPanelRole
			// 
			this.m_extLinkField.SetLinkField(this, "");
			this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
			this.Name = "CPanelRole";

		}
		#endregion

		/// <summary>
		/// Retourne l'objet édité. ATTENTION : Peut être null
		/// </summary>
		public CObjetDonnee ObjetEdite
		{
			get
			{
				if ( m_objet == null || !m_objet.IsValide() )
					return null;
				return m_objet;
			}
			set
			{
				if ( value == null )
				{
					m_objet = value;
					return;
				}
				if (  m_objet == null || !m_objet.IsValide() || m_objet != value || m_objet.ContexteDonnee != value.ContexteDonnee )
				{
					m_objet = value;
				}
				if ( m_objet != null )
					InitChamps();

			}
		}

		public sc2i.win32.common.CExtModeEdition GestionnaireModeEdition
		{
			get
			{
				return m_gestionnaireModeEdition;
			}
		}

		public virtual CResultAErreur MAJ_Champs()
		{
			CResultAErreur result = CResultAErreur.True;
			if ( m_objet == null )
				return result;
			m_extLinkField.FillObjetFromDialog(m_objet);
			return result;
		}

		public virtual void InitChamps()
		{
			m_extLinkField.FillDialogFromObjet(ObjetEdite);
			sc2i.win32.common.CWin32Traducteur.Translate(this);

		}

		public CResultAErreur VerifieDonnees()
		{
			if ( ObjetEdite == null )
				return CResultAErreur.True;
			return ObjetEdite.VerifieDonnees(true);
		}

		public virtual CRoleActeur RoleAssocie
		{
			get
			{
				return null;
			}
		}
	}
}
