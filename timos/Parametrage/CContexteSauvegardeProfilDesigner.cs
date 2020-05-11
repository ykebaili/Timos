using System.Windows.Forms;

using sc2i.win32.common;

namespace timos
{

	public class CContexteSauvegardeProfilDesigner
	{
		public CContexteSauvegardeProfilDesigner(CPanelEditionObjetGraphique editeur)
		{
			m_editeur = editeur;
            //TESTDBKEYOK
			m_key = sc2i.multitiers.client.CSessionClient.GetSessionUnique().GetInfoUtilisateur().KeyUtilisateur.StringValue
				+ "_" + editeur.Name;
			Control ctrlParent = editeur;
			bool bExit = false;
			while (!bExit)
			{
				if (ctrlParent.GetType().IsSubclassOf(typeof(Form)))
				{
					bExit = true;
				}
				else
				{
					ctrlParent = ctrlParent.Parent;
					if (ctrlParent == null || ctrlParent.GetType() == typeof(MdiClient))
						bExit = true;
					else
						m_key += "_" + ctrlParent.Name;
				}
			}
		}
		private string m_key;
		public string Cle
		{
			get
			{
				return m_key;
			}
			set
			{
				m_key = value;
			}
		}

		public CProfilEditeurObjetGraphique Profil
		{
			get
			{
				return m_editeur.Profil;
			}
		}

		private CPanelEditionObjetGraphique m_editeur;
		public CPanelEditionObjetGraphique Designer
		{
			get
			{
				return m_editeur;
			}
		}
	}
}