using System;

using System.Collections;

using sc2i.data;
using sc2i.multitiers.client;
using sc2i.multitiers.server;
using timos.acteurs;
using timos.securite;


#if !PDA_DATA

namespace timos.acteurs.serveur
{
	/// <summary>
	/// Description résumée de CDonneeDroitForUserServer.
	/// </summary>
	public class CDonneeDroitForUserServer : C2iObjetServeur, IDonneeDroitForUserServer
	{
		//Id session->Contexte de cache pour la session
		private static Hashtable m_tableContextesCachesForSessions = new Hashtable();
		
		private CContexteDonnee m_contexteCache;

		/// ///////////////////////////////////////////////////////////////
		public CDonneeDroitForUserServer(int nIdSession)
			:base ( nIdSession )
		{
			nIdSession = 0;
			m_contexteCache = (CContexteDonnee)m_tableContextesCachesForSessions[nIdSession];
			if ( m_contexteCache == null )
			{
				m_contexteCache = new CContexteDonnee ( nIdSession,true, true );
				m_tableContextesCachesForSessions[nIdSession] = m_contexteCache;
			}
		}

		/// ///////////////////////////////////////////////////////////////
		public CDonneeDroitForUser GetDonneeDroit ( int nIdDonneActeurUtilisateur, string strCode )
		{
			CDonneesActeurUtilisateur user = new CDonneesActeurUtilisateur ( m_contexteCache );
			user.Id = nIdDonneActeurUtilisateur;

			CDroitUtilisateur droit = new CDroitUtilisateur ( m_contexteCache );
			droit.PointeSurLigne(strCode);
			string strListeCodes = "'"+strCode+"'";
			while ( droit.DroitParent != null )
			{
				strListeCodes+=",'"+droit.DroitParent.Code+"'";
				droit = droit.DroitParent;
			}
			//Recherche les relations de droit de cet utilisateur
			/*CFiltreData filtre = new CFiltreData ( CDonneesActeurUtilisateur.c_champId+"=@1 and "+
				CDroitUtilisateur.c_champCode+" in ("+strListeCodes+")");
			filtre.Parametres.Add ( nIdDonneActeurUtilisateur );*/
			CListeObjetsDonnees liste = user.GetDependancesListe(CRelationActeurUtilisateur_Droit.c_nomTable, CDonneesActeurUtilisateur.c_champId );
			liste.Filtre = new CFiltreData( CDroitUtilisateur.c_champCode+" in ("+strListeCodes+")");
			//CListeObjetsDonnees liste = new CListeObjetsDonnees(m_contexteCache, typeof(CRelationActeurUtilisateur_Droit));
			//liste.Filtre = filtre;
			CDonneeDroitForUser donneeRetour = null;
			if ( liste.Count > 0 )
			{
				donneeRetour = new CDonneeDroitForUser ( strCode, OptionsDroit.Aucune );
				foreach ( CRelationActeurUtilisateur_Droit rel in liste )
				{
					donneeRetour.CombineOptions ( rel.Options );
					CObjetDonneeAIdNumerique[] listeOptions = rel.ListeObjetsOption;
					if ( listeOptions != null )
						foreach ( CObjetDonnee obj in rel.ListeObjetsOption )
							donneeRetour.AddObjetDonneeOption( obj );
				}
			}
			///RECHERCHE DANS LES GROUPES DE L'utilisateur
			string strGroupes = "";
			foreach ( CGroupeActeur groupe in  user.Acteur.TousLesGroupes()) //user.Acteur.HierarchieGroupes)
				strGroupes += groupe.Id.ToString()+",";
			if ( strGroupes.Length == 0 )
				return donneeRetour;
			strGroupes = strGroupes.Substring(0, strGroupes.Length-1);
			CFiltreData filtre;
			
			filtre = new CFiltreData(
				CGroupeActeur.c_champId+" in ("+strGroupes+") and "+
				CDroitUtilisateur.c_champCode+" in ("+strListeCodes+")");

			/*liste = new CListeObjetsDonnees(m_contexteCache, typeof(CRelationGroupe_Droit));
			liste.Filtre = filtre;
			if ( liste.Count > 0 )
			{
				if ( donneeRetour == null )
					donneeRetour = new CDonneeDroitForUser ( strCode, OptionsDroit.Aucune );
				foreach ( CRelationGroupe_Droit rel in liste )
				{
					donneeRetour.CombineOptions ( rel.Options );
					CObjetDonneeAIdNumeriqueAuto[] listeOptions = rel.ListeObjetsOption;
					if ( listeOptions != null )
						foreach ( CObjetDonnee obj in rel.ListeObjetsOption )
							donneeRetour.AddObjetDonneeOption( obj );
				}
			}*/
			return donneeRetour;
		}
	}
}
#endif