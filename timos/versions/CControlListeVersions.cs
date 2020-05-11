using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using sc2i.data;

namespace timos.version
{
	public partial class CControlListeVersions : UserControl
	{
		private CObjetDonneeAIdNumerique m_objet;

		public CControlListeVersions()
		{
			InitializeComponent();
		}

		public void AffichePourObjet(CObjetDonneeAIdNumerique objet)
		{
			m_objet = objet;
			FillListe();
		}

		public void FillListe()
		{
			CFiltreDataAvance filtre = new CFiltreDataAvance(CVersionDonnees.c_nomTable,
				CVersionDonneesObjet.c_nomTable + "." +
				CVersionDonneesObjet.c_champIdElement + "=@1 and " +
				CVersionDonneesObjet.c_champTypeElement + "=@2",
				m_objet.Id,
				m_objet.GetType().ToString());
			CListeObjetsDonnees liste = new CListeObjetsDonnees(m_objet.ContexteDonnee,
				typeof(CVersionDonnees));
			m_panelListeVersions.InitFromListeObjets(liste,
				typeof(CVersionDonneesObjet),
				null,
				null,
				"");
		}
			


	}
}
