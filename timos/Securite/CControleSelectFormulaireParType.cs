using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using sc2i.data;
using sc2i.data.dynamic;
using sc2i.common;
using timos.securite;
using sc2i.win32.common;

namespace timos
{
	public partial class CControleSelectFormulaireParType : UserControl, IControlALockEdition
	{
		private Type m_typeAssocie;
		private CTypeEntiteOrganisationnelle m_typeEntiteOrganisationnelle;
		private CRelationTypeEO_FormulaireParType m_relationEditee = null;
		private bool m_bComboFormInit = false;

		public CControleSelectFormulaireParType()
		{
			InitializeComponent();
		}

		public void SetTypeAssocie(Type typeAssocie)
		{
			m_typeAssocie = typeAssocie;
			m_lblType.Text = DynamicClassAttribute.GetNomConvivial(typeAssocie);
		}

		public CResultAErreur InitChamps ( CTypeEntiteOrganisationnelle typeEntite )
		{
			CResultAErreur result = CResultAErreur.True;
			if (typeEntite != null)
			{
				Visible = true;
				if (!m_bComboFormInit)
				{
					CListeObjetsDonnees lste = new CListeObjetsDonnees(typeEntite.ContexteDonnee, typeof(CFormulaire));
                    lste.Filtre = CFormulaire.GetFiltreFormulairesForRole(CRelationElement_EO.c_roleChampCustom);
					//lste.Filtre = new CFiltreData(CFormulaire.c_champCodeRole + "=@1", CRelationElement_EO.c_roleChampCustom);
					m_comboFormulaire.Init(lste, "Libelle", false);
				}
				m_typeEntiteOrganisationnelle = typeEntite;
				CListeObjetsDonnees rels = typeEntite.RelationsFormulairesParType;
				rels.Filtre = new CFiltreData(CRelationTypeEO_FormulaireParType.c_champType + "=@1",
					m_typeAssocie.ToString());
				if (rels.Count == 1)
				{
					CRelationTypeEO_FormulaireParType rel = (CRelationTypeEO_FormulaireParType)rels[0];
					m_comboFormulaire.ElementSelectionne = rel.Formulaire;
					m_relationEditee = rel;
				}
				else
				{
					m_comboFormulaire.ElementSelectionne = null;
					m_relationEditee = null;
				}
			}
			else
			{
				Visible = false;
				m_typeEntiteOrganisationnelle = null;
				m_relationEditee = null;
			}
			return result;
		}

		public CResultAErreur MajChamps()
		{
			CResultAErreur result = CResultAErreur.True;
			if (m_relationEditee != null)
			{
				if (m_comboFormulaire.ElementSelectionne == null)
				{
					result = m_relationEditee.Delete();
					return result;
				}
			}
			if (m_comboFormulaire.ElementSelectionne is CFormulaire)
			{
				if (m_relationEditee == null)
				{
					m_relationEditee = new CRelationTypeEO_FormulaireParType(m_typeEntiteOrganisationnelle.ContexteDonnee);
					m_relationEditee.CreateNewInCurrentContexte();
					m_relationEditee.TypeEntiteOrganisationnelle = m_typeEntiteOrganisationnelle;
					m_relationEditee.TypeAssocie = m_typeAssocie;
				}
				m_relationEditee.Formulaire = (CFormulaire)m_comboFormulaire.ElementSelectionne;
			}
			return result;
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
	}
}
