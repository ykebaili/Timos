using System.ComponentModel;
using System.Windows.Forms;

using sc2i.common;
using sc2i.win32.common;

namespace timos
{

	public class CCtrlSauvegardeProfilDesigner : Component
	{

		private Form m_formulaire;
		public Form Formulaire
		{
			get
			{
				return m_formulaire;
			}
			set
			{
				if (value != null)
				{
					m_formulaire = value;
					m_formulaire.Load += new System.EventHandler(Load);
					m_formulaire.FormClosed += new FormClosedEventHandler(Closed);
				}
			}
		}

		private void Load(object sender, System.EventArgs e)
		{
			if (Designer != null)
			{
				CContexteSauvegardeProfilDesigner ctx = new CContexteSauvegardeProfilDesigner(Designer);
				CUtilASauvegardeProfilDesigner.InitialiserProfil(ctx);
			}
		}
		private void Closed(object sender, FormClosedEventArgs e)
		{
			if (Designer != null)
			{
				CContexteSauvegardeProfilDesigner ctx = new CContexteSauvegardeProfilDesigner(Designer);
				CUtilASauvegardeProfilDesigner.SauvegarderDansRegistre(ctx);
			}
		}

		
		private CPanelEditionObjetGraphique m_designer;
		public CPanelEditionObjetGraphique Designer
		{
			get
			{
				return m_designer;
			}
			set
			{
				m_designer = value;
			}
		}
	}


	public static class CUtilASauvegardeProfilDesigner
	{
		public static CResultAErreur SauvegarderDansRegistre(CContexteSauvegardeProfilDesigner ctx)
		{
			CResultAErreur result = CResultAErreur.True;
			CStringSerializer serializer = new CStringSerializer(ModeSerialisation.Ecriture);
			CProfilEditeurObjetGraphique prof = ctx.Profil;
			result = prof.Serialize(serializer);
			if (result)
			{
				new CTimosAppRegistre().SetDataProfilDesigner(ctx.Cle, serializer.String);
			}

			return result;
		}
		public static CResultAErreur InitialiserProfil(CContexteSauvegardeProfilDesigner ctx)
		{
			CResultAErreur result = CResultAErreur.True;
			string strData = new CTimosAppRegistre().GetDataProfilDesigner(ctx.Cle);
			if (strData != "")
			{
				try
				{
					CProfilEditeurObjetGraphique prof = ctx.Profil;
					CStringSerializer serializer = new CStringSerializer(strData, ModeSerialisation.Lecture);
					result = prof.Serialize(serializer);
					ctx.Designer.Profil = prof;
				}
				catch
				{
				}
			}
			return result;
		}
	}

}