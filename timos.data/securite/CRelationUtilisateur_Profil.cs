using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;

namespace timos.securite
{
	/// <summary>
    /// Relation entre un <see cref="CDonneesActeurUtilisateur">Utilisateur</see> et un <see cref="CProfilUtilisateur">Profil</see>
	/// </summary>
	[DynamicClass("User / Profile")]
	[Table(CRelationUtilisateur_Profil.c_nomTable, CRelationUtilisateur_Profil.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CRelationUtilisateur_ProfilServeur")]
    public class CRelationUtilisateur_Profil : CObjetDonneeAIdNumeriqueAuto, IObjetDonneeAutoReference
	{
		public const string c_nomTable = "USER_PROFIL_USE";
		
		public const string c_champId = "USRPRF_USE_ID";
		public const string c_champIdUtProfParent = "USRPRF_USE_PARENT_ID";

		/// /////////////////////////////////////////////
		public CRelationUtilisateur_Profil( CContexteDonnee contexte)
			:base(contexte)
		{
		}

		/// /////////////////////////////////////////////
		public CRelationUtilisateur_Profil(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
                return I.T("Relation User / Profile @1|298", ToString());
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champId};
		}


		////////////////////////////////////////////////
		/// <summary>
		/// Profil associé à la relation.<br/>
		/// La relation est associée soit à un profil, soit à un profil/Inclusion
		/// </summary>
		[Relation ( 
			CProfilUtilisateur.c_nomTable,
			CProfilUtilisateur.c_champId,
			CProfilUtilisateur.c_champId,
			false,
			false,
			true )]
		[DynamicField("Profile")]
		public CProfilUtilisateur Profil
		{
			get
			{
				return (CProfilUtilisateur)GetParent(CProfilUtilisateur.c_champId, typeof(CProfilUtilisateur));
			}
			set
			{
				SetParent(CProfilUtilisateur.c_champId, value);
			}
		}

		////////////////////////////////////////////////
		/// <summary>
		/// Profil/Inclusion associée à la relation%.<br/>
        /// La relation est associée soit à un profil, soit à un profil/Inclusion
		/// </summary>
		[Relation ( 
			CProfilUtilisateur_Inclusion.c_nomTable,
			CProfilUtilisateur_Inclusion.c_champId,
			CProfilUtilisateur_Inclusion.c_champId,
			false,
			false,
			true )]
		public CProfilUtilisateur_Inclusion Profil_Inclusion
		{
			get
			{
				return (CProfilUtilisateur_Inclusion)GetParent(CProfilUtilisateur_Inclusion.c_champId, typeof(CProfilUtilisateur_Inclusion));
			}
			set
			{
				SetParent(CProfilUtilisateur_Inclusion.c_champId, value);
			}
		}

		//---------------------------------------------------------
        /// <summary>
        /// Utilisateur de l'application, objet de la relation
        /// </summary>
		[Relation ( 
			CDonneesActeurUtilisateur.c_nomTable,
			CDonneesActeurUtilisateur.c_champId,
			CDonneesActeurUtilisateur.c_champId,
			false,
			true,
			true )]
		[DynamicField("User")]
		public CDonneesActeurUtilisateur Utilisateur
		{
			get
			{
				return (CDonneesActeurUtilisateur)GetParent(CDonneesActeurUtilisateur.c_champId, typeof(CDonneesActeurUtilisateur));
			}
			set
			{
				SetParent(CDonneesActeurUtilisateur.c_champId, value);
				if (value != null)
					Profil_Inclusion = null;
			}
		}

		
		///////////////////////////////////////////////
		/// <summary>
		/// Relation Utilisateur/Profil parente de cette relation
		/// </summary>
		[Relation(
			CRelationUtilisateur_Profil.c_nomTable,
			CRelationUtilisateur_Profil.c_champId,
			CRelationUtilisateur_Profil.c_champIdUtProfParent,
			false,
			true,
			true )]
		[DynamicField("Parent relation")]
		public CRelationUtilisateur_Profil RelationParente
		{
			get
			{
				return (CRelationUtilisateur_Profil)GetParent(c_champIdUtProfParent, typeof(CRelationUtilisateur_Profil));
			}
			set
			{
				SetParent(c_champIdUtProfParent, value);
				if (value != null)
					Utilisateur = null;
			}
		}

		///////////////////////////////////////////////
		/// <summary>
		/// Retourne la liste des relations filles à des profils
		/// </summary>
		[RelationFille(typeof(CRelationUtilisateur_Profil), "RelationParente")]
		[DynamicChilds ("Childs relations", typeof ( CRelationUtilisateur_Profil) )]

		public CListeObjetsDonnees  RelationFilles
		{
			get
			{
				return GetDependancesListe(c_nomTable, c_champIdUtProfParent);
			}
		}

		//-------------------------------------------------
        /// <summary>
        /// Retourne la liste des relations avec des entités organisationnelles
        /// </summary>
		[RelationFille ( typeof ( CRelationUtilisateur_Profil_EO ), "UtilisateurProfil")]
		[DynamicChilds("Organisationnal entities relations", typeof ( CRelationUtilisateur_Profil_EO))]
		public CListeObjetsDonnees RelationsEntiteOrganisationnelles
		{
			get
			{
				return GetDependancesListe(CRelationUtilisateur_Profil_EO.c_nomTable, c_champId);
			}
		}

		////////////////////////////////////////////////
		/// <summary>
		/// Liste des entités explicitement liées à cette relation
		/// </summary>
		public List<CEntiteOrganisationnelle> EntitesLiesExplicites
		{
			get
			{
				CListeObjetsDonnees liste = RelationsEntiteOrganisationnelles;
				List<CEntiteOrganisationnelle> lstRetour = new List<CEntiteOrganisationnelle>();
				foreach (CRelationUtilisateur_Profil_EO rel in liste)
					lstRetour.Add(rel.EntiteOrganisationnelle);
				return lstRetour;
			}
		}

		////////////////////////////////////////////////
		public List<CEntiteOrganisationnelle> EntitesLieesImplicites
		{
			get
			{
				List<CEntiteOrganisationnelle> lstRetour = EntitesLiesExplicites;
				if ( lstRetour.Count == 0 )
				{
					CEntiteOrganisationnelle entite = null;
					if (entite == null && Profil != null)
					entite = Profil.EntiteOrganisationnelle;
					if (entite == null && Profil_Inclusion != null)
					entite = Profil_Inclusion.ProfilFils.EntiteOrganisationnelle;
					if (entite != null )
						lstRetour.Add ( entite );
				}
				return lstRetour;
			}
		}

		////////////////////////////////////////////////
		public void ClearEntitesLiees()
		{
			foreach (CRelationUtilisateur_Profil_EO rel in RelationsEntiteOrganisationnelles.ToArrayList())
				rel.Delete();
		}

		////////////////////////////////////////////////
		/// <summary>
		/// Met à jour les entités liées à partir d'une liste d'entités à lier
		/// </summary>
		/// 
		/// <param name="entite"></param>
		/// <returns></returns>
		public void SetEntitesLiees(CEntiteOrganisationnelle[] listeEntites)
		{
			//Simplifie la liste
			ArrayList lstLiees = new ArrayList(listeEntites);
			Hashtable tableToKeep = new Hashtable();
			foreach (CEntiteOrganisationnelle entite in lstLiees)
				tableToKeep[entite.CodeSystemeComplet] = true;

			foreach (CEntiteOrganisationnelle entite in lstLiees.ToArray())
			{
				foreach (string strCodeParent in entite.CodesSystemesCompletsParents)
					if (tableToKeep[strCodeParent] != null)
					{
						tableToKeep[strCodeParent] = false;
						lstLiees.Remove(entite);
					}
			}

			//table entite->Relation
			Hashtable tableExistants = new Hashtable();

			//Table relation->True s'il faut la supprimer
			Hashtable tableRelationsToDelete = new Hashtable();

			foreach (CRelationUtilisateur_Profil_EO rel in RelationsEntiteOrganisationnelles)
			{
				tableExistants[rel.EntiteOrganisationnelle] = rel;
				tableRelationsToDelete[rel] = true;
			}

			foreach (CEntiteOrganisationnelle entite in lstLiees)
			{
				CRelationUtilisateur_Profil_EO relEx = (CRelationUtilisateur_Profil_EO)tableExistants[entite];
				if (relEx != null)
					tableRelationsToDelete[relEx] = false;
				else
				{
					//Création de la relatino
					relEx = new CRelationUtilisateur_Profil_EO(ContexteDonnee);
					relEx.CreateNewInCurrentContexte();
					relEx.UtilisateurProfil = this;
					relEx.EntiteOrganisationnelle = entite;
				}
			}

			foreach (DictionaryEntry entry in tableRelationsToDelete )
			{
				if ((bool)entry.Value)
				{
					CRelationUtilisateur_Profil_EO rel = (CRelationUtilisateur_Profil_EO)entry.Key;
					rel.Delete();
				}
			}
		}




		////////////////////////////////////////////////
		public string GetFiltreEO(int? nIdVersion, Type typeElements)
		{
			string strFiltre = "";
			CProfilUtilisateur profilLie = Profil;
			if (profilLie == null && Profil_Inclusion != null)
			{
				if (!Profil_Inclusion.ShouldApply(nIdVersion))
					return "";
				profilLie = Profil_Inclusion.ProfilFils;
			}
			if (profilLie == null)
				return "";
			string strTmp="";

            if (profilLie.ShouldFiltrerSur(typeElements))
            {
                CEntiteOrganisationnelle entite = profilLie.EntiteOrganisationnelle;
                CEntiteOrganisationnelle racine = entite;
                if (racine == null)
                    return "";
                while (racine.EntiteParente != null)
                    racine = racine.EntiteParente;
                if ( !profilLie.MasquerLesHorsBranche )
                {
                    strFiltre = CUtilElementAEO.c_champEO + " not like '%~" + racine.CodeSystemeComplet + "%'";
                }
                if (!profilLie.Affinable || RelationsEntiteOrganisationnelles.Count == 0)//Pas de lien spécifique
                {
                    if (strFiltre != "")
                        strFiltre += " or ";
                    strFiltre += CUtilElementAEO.c_champEO + " like '%~" + entite.CodeSystemeComplet + "%'";
                }
                if (profilLie.Affinable)
                {
                    foreach (CEntiteOrganisationnelle entiteLiee in EntitesLiesExplicites)
                    {
                        if (strTmp != "")
                            strTmp += " or ";
                        strTmp += CUtilElementAEO.c_champEO + " like '%~" + entiteLiee.CodeSystemeComplet + "%'";
                    }
                    if (strTmp != "")
                    {
                        if (strFiltre != "")
                            strFiltre += " or ";
                        strFiltre += strTmp;
                    }
                    if (strFiltre != "")
                        strFiltre = "(" + strFiltre + ")";
                }
            }

			string strSousFiltres = "";
			foreach (CRelationUtilisateur_Profil relSousProfil in RelationFilles)
			{
				strTmp = relSousProfil.GetFiltreEO(nIdVersion, typeElements);
				if (strTmp != "")
				{
					if (strSousFiltres != "")
						strSousFiltres += " or ";
					strSousFiltres += "(" + strTmp + ")";
				}
			}
			if (strSousFiltres != "")
			{
				if (strFiltre != "")
					strFiltre += " and ";
				strFiltre += "(" + strSousFiltres + ")";
			}
			return strFiltre;
		}

		////////////////////////////////////////////////
		public void CompleteRestriction(IElementAEO element, CRestrictionUtilisateurSurType restriction)
		{
            DataRowVersion originalVersion = ((CObjetDonnee)element).VersionToReturn;
            try
            {
                if (element.Row.RowState == DataRowState.Deleted)
                    ((CObjetDonnee)element).VersionToReturn = DataRowVersion.Original;

                string strCodesEO = element.CodesEntitesOrganisationnelles;
                int? nIdVersion = element.ContexteDonnee.IdVersionDeTravail;
                if (nIdVersion < 0)
                {
                    //On ne travaille ni dans le référentiel, ni dans une version,
                    //Il faut donc prendre les droits pour l'objet dans sa propre version
                    if (element.Row.Table.Columns[CSc2iDataConst.c_champIdVersion] != null)
                        nIdVersion = (int?)element.Row[CSc2iDataConst.c_champIdVersion, true];
                    else
                        nIdVersion = null;
                }
                CProfilUtilisateur profil = Profil;
                if (profil == null)
                {
                    if (Profil_Inclusion != null)
                    {
                        if (!Profil_Inclusion.ShouldApply(nIdVersion))
                            return;
                        profil = Profil_Inclusion.ProfilFils;
                    }
                }

                bool bApplique = false;
                //Si pas de relations EO sur l'utilisateur, on applique si
                //-Le profil n'est pas lié à une EO, ou si l'élément appartient à cette EO
                if (RelationsEntiteOrganisationnelles.Count == 0 || !profil.Affinable)
                {
                    if (profil.EntiteOrganisationnelle != null)
                        bApplique = strCodesEO.IndexOf("~" + profil.EntiteOrganisationnelle.CodeSystemeComplet) >= 0;
                    else
                        bApplique = true;//Pas d'EO, donc, on applique
                }

                if (profil.Affinable)
                {
                    foreach (CRelationUtilisateur_Profil_EO rel in RelationsEntiteOrganisationnelles)
                        if (rel.EntiteOrganisationnelle != null && strCodesEO.IndexOf("~" + rel.EntiteOrganisationnelle.CodeSystemeComplet) >= 0)
                        {
                            bApplique = true;
                            break;
                        }
                }
                if (bApplique)
                {

                    if (profil != null)
                    {
                        foreach (CProfilUtilisateur_Restriction relRes in profil.RelationsRestrictions)
                        {
                            CListeRestrictionsUtilisateurSurType lstRes = relRes.Restrictions.ListeRestrictions;
                            CRestrictionUtilisateurSurType newRes = lstRes.GetRestriction(element.GetType());
                            restriction.Combine(newRes);
                        }
                    }
                    foreach (CRelationUtilisateur_Profil sousRel in RelationFilles)
                        sousRel.CompleteRestriction(element, restriction);
                }
            }
            finally
            {
                ((CObjetDonnee)element).VersionToReturn = originalVersion;
            }
		}

		#region IObjetDonneeAutoReference Membres

		public string ChampParent
		{
			get { return c_champIdUtProfParent; }
		}

		public string ProprieteListeFils
		{
			get { return "RelationFilles"; }
		}

		#endregion

		internal void AddTypesARestrictionsSurObjets(Dictionary<Type, bool> dicTypesARestrictionsSurObjets, int? nIdVersion)
		{
			if (Profil != null)
				Profil.AddTypesARestrictionsSurObjets(dicTypesARestrictionsSurObjets, nIdVersion, false);
			if (Profil_Inclusion != null && Profil_Inclusion.ProfilFils != null )
				Profil_Inclusion.AddTypesARestrictionsSurObjets(dicTypesARestrictionsSurObjets, nIdVersion, false);
		}
	}
}
