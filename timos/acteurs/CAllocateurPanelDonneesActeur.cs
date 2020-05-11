using System;
using sc2i.data;

using timos.acteurs;
using timos.securite;
using timos.data;
namespace timos
{
	/// <summary>
	/// Description résumée de CAllocateurPanelDonneesActeur.
	/// </summary>
	public class CAllocateurPanelDonneesActeur
	{
		public CAllocateurPanelDonneesActeur()
		{
		}

		public static CPanelRole GetPanelFromRole(CObjetDonnee objet, CRoleActeur role)
		{
			switch(role.CodeRole)
			{
				case CDonneesActeurUtilisateur.c_codeRole : 
					return new CPanelRoleUtilisateur((CDonneesActeurUtilisateur)objet);
				case CDonneesActeurClient.c_codeRole :
					return new CPanelRoleClient((CDonneesActeurClient)objet);
				default : return null;
			}
		}
	}
}
