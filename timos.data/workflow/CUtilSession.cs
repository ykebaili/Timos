using System;
using sc2i.multitiers.client;

using sc2i.data;
using timos.acteurs;
using timos.securite;
using System.Collections.Generic;
using sc2i.process.workflow;

namespace sc2i.workflow
{
	/// <summary>
	/// Description résumée de CSession.
	/// </summary>
	public class CUtilSession
	{
		public static string c_champIsSessionDeconnectee = "MODE_DECONNECTE";

		public static bool IsDeconnecte ( int nIdSession )
		{
			CSessionClient session = CSessionClient.GetSessionForIdSession ( nIdSession );
			return IsDeconnecte ( session );
		}

		public static bool IsDeconnecte ( CSessionClient session )
		{
			if ( session != null )
			{
				object val = session.GetPropriete(c_champIsSessionDeconnectee);
				if ( val is bool && (bool)val )
					return true;
			}
			return false;
		}

		public static CDonneesActeurUtilisateur GetUserForSession ( CContexteDonnee contexte )
		{
			CSessionClient session  = CSessionClient.GetSessionForIdSession ( contexte.IdSession );
			if ( session == null )
				return null;
			CDonneesActeurUtilisateur user = new CDonneesActeurUtilisateur ( contexte );
			try
			{
                //TESTDBKEYOK
				if ( user.ReadIfExists ( session.GetInfoUtilisateur().KeyUtilisateur ) )
					return user;
			}
			catch{}
			return null;
		}	

		public static IDonneeDroitUtilisateur GetDonneeDroitForSession ( int nIdSession, string strCodeDroit )
		{
			try
			{
				CSessionClient session = CSessionClient.GetSessionForIdSession ( nIdSession );
				if ( session == null )
					return null;
				IInfoUtilisateur info = session.GetInfoUtilisateur();
				if ( info == null )
					return null;
				return info.GetDonneeDroit ( strCodeDroit );
			}
			catch
			{
			}
			return null;
		}

        public static string[] GetCodesAffectationsEtapeConcernant(CContexteDonnee contexteDonnee)
        {
            CDonneesActeurUtilisateur user = GetUserForSession(contexteDonnee);
            List<string> strCodes = new List<string>();
            if (user != null)
            {
                CActeur acteur = user.Acteur;
                strCodes.AddRange( acteur.GetListeCodesAffectationEtape());
            }
            return strCodes.ToArray();
        }
		

		
				
	}
}
