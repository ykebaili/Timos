using System;
using System.Collections.Generic;
using System.Text;

using sc2i.multitiers.server;

using timos.client;

namespace timos.serveur
{
	public class CAuthentificateurParSupportAmovible : C2iObjetServeur, IAuthentificateurParSupportAmovible
	{

		public CAuthentificateurParSupportAmovible(int nIdSession)
			:base(nIdSession)
		{

		}

		#region IAuthentificateurParSupportAmovible Membres

		public List<string> GetDrivesValide(List<string> idsDrivesPossibles)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		public Dictionary<string, bool> GetUsersPossibles(string strIdDrive)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		#endregion
	}
}
