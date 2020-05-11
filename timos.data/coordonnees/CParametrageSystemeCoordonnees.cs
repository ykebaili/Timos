using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using timos.securite;
using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;

namespace timos.data
{

	/// <summary>
	/// Est la configuration apportée à un 
	/// <see cref="CSystemeCoordonnees">Système de Coordonnées</see>;<br/>
	/// La configuration contient des 
	/// <see cref="CParametrageNiveau">parametrages niveaux</see>
	/// pour chacun des 
	/// <see cref="CRelationSystemeCoordonnees_FormatNumerotation">niveaux de numerotation</see>.
	/// <br/>
	/// 
	/// Elle permet à de multiples types d'entités d'utiliser le système de coordonnées relatif.<br/>
	/// <list type="bullet">
	///		<item><term><see cref="CTypeSite">		Types Site			</see></term></item>
	///		<item><term><see cref="CSite">			Sites				</see></term></item>
	///		<item><term><see cref="CStock">			Stocks				</see></term></item>
	///		<item><term><see cref="CTypeEquipement">Types Equipements	</see></term></item>
	///		<item><term><see cref="CEquipement">	Equipements			</see></term></item>
	///		<item><term><see cref="CTypeEntiteOrganisationnelle">	Types Entite Organisationnelle			</see></term></item>
	/// </list><br/><br/>
	/// 
	/// Pour en savoir plus sur les 
	/// <see cref="CSystemeCoordonnees">Système de Coordonnées</see> vous pouvez vous référer
	/// aux multiples ressources.
	/// </summary>
    [sc2i.doccode.DocRefMenusOrMenuItems(CDocLabels.c_iCoordonnees)]
    [DynamicClass("Coordinate system setting")]
	[Table(CParametrageSystemeCoordonnees.c_nomTable, CParametrageSystemeCoordonnees.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CParametrageSystemeCoordonneesServeur")]
	[Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_SystemeCoor_ID)]
    public class CParametrageSystemeCoordonnees : CObjetDonneeAIdNumeriqueAuto, IObjetALectureTableComplete
	{
        #region [[ Constantes ]]

		public const string c_nomTable = "COORDINATE_SYS_SETTINGS";
        public const string c_champId = "COORSYSSET_ID";
		public const string c_champModified = "COORSYSSET_MODIFIED";

        #endregion

		/// /////////////////////////////////////////////
		public CParametrageSystemeCoordonnees( CContexteDonnee contexte)
			:base(contexte)
		{
		}

		/// /////////////////////////////////////////////
		public CParametrageSystemeCoordonnees(DataRow row)
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get { return I.T( "Coordinates system setting @1 for object @2|176", SystemeCoordonnees != null?SystemeCoordonnees.Libelle:"", ObjetASystemeDeCoordonnees != null?ObjetASystemeDeCoordonnees.DescriptionElement:""); }
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


		/// <summary>
		/// Indique si le paramétrage a été modifié depuis la dernière sauvegarde
		/// </summary>
		[TableFieldProperty(c_champModified, IsInDb=false)]
		public bool ModifieDepuisLaDerniereSauvegarde
		{
			get
			{
				return (bool)Row[c_champModified];
			}
			set
			{
				Row[c_champModified] = value;
			}
		}

		#region Objets pouvant être liés

		/// <summary>
		/// Type Entite Organisationnelle
		/// </summary>
		[Relation(CTypeEntiteOrganisationnelle.c_nomTable, CTypeEntiteOrganisationnelle.c_champId, CTypeEntiteOrganisationnelle.c_champId, false, true)]
		public CTypeEntiteOrganisationnelle TypeEntiteOrganisationnelle
		{
			get { return (CTypeEntiteOrganisationnelle)GetParent(CTypeEntiteOrganisationnelle.c_champId, typeof(CTypeEntiteOrganisationnelle)); }
			set
			{
				if (value != null)
					ObjetASystemeDeCoordonnees = null;
				SetParent(CTypeEntiteOrganisationnelle.c_champId, value);
			}
		}

		/// <summary>
		/// Type Site
		/// </summary>
		[Relation(CTypeSite.c_nomTable, CTypeSite.c_champId, CTypeSite.c_champId, false, true)]
		public CTypeSite TypeSite
		{
			get { return (CTypeSite)GetParent(CTypeSite.c_champId, typeof(CTypeSite)); }
			set
			{
				if (value != null)
					ObjetASystemeDeCoordonnees = null;
				SetParent(CTypeSite.c_champId, value);
			}
		}

		/// <summary>
		/// Site
		/// </summary>
		[Relation(CSite.c_nomTable, CSite.c_champId, CSite.c_champId, false, true)]
		public CSite Site
		{
			get	{ return (CSite)GetParent(CSite.c_champId, typeof(CSite)); }
			set
			{
				if (value != null)
					ObjetASystemeDeCoordonnees = null;
				SetParent(CSite.c_champId, value);
			}
		}

		/// <summary>
		/// Stock
		/// </summary>
		[Relation(CStock.c_nomTable, CStock.c_champId, CStock.c_champId, false, true)]
		public CStock Stock
		{
			get	{ return (CStock)GetParent(CStock.c_champId, typeof(CStock)); }
			set
			{
				if (value != null)
					ObjetASystemeDeCoordonnees = null;
				SetParent(CStock.c_champId, value);
			}
		}
		
		/// <summary>
		/// Type Equipement
		/// </summary>
		[Relation(CTypeEquipement.c_nomTable, CTypeEquipement.c_champId, CTypeEquipement.c_champId, false, true)]
		public CTypeEquipement TypeEquipement
		{
			get	{ return (CTypeEquipement)GetParent(CTypeEquipement.c_champId, typeof(CTypeEquipement)); }
			set
			{
				if (value != null)
					ObjetASystemeDeCoordonnees = null;
				SetParent(CTypeEquipement.c_champId, value);
			}
		}

		/// <summary>
		/// Equipement
		/// </summary>
		[Relation(CEquipement.c_nomTable, CEquipement.c_champId, CEquipement.c_champId, false, true)]
		public CEquipement Equipement
		{
			get { return (CEquipement)GetParent(CEquipement.c_champId, typeof(CEquipement)); }
			set
			{
				if (value != null)
					ObjetASystemeDeCoordonnees = null;
				SetParent(CEquipement.c_champId, value);
			}
		}

		#endregion

		/// <summary>
		/// Retourne l'objet à Systeme de Coordonnées
		/// </summary>
		public IObjetASystemeDeCoordonnee ObjetASystemeDeCoordonnees
		{
			get
			{
				if (Site != null)
					return (IObjetASystemeDeCoordonnee)Site;
				if (Stock != null)
					return (IObjetASystemeDeCoordonnee)Stock;
				if (TypeSite != null)
					return (IObjetASystemeDeCoordonnee)TypeSite;
				if (TypeEquipement != null)
					return (IObjetASystemeDeCoordonnee)TypeEquipement;
				if (Equipement != null)
					return (IObjetASystemeDeCoordonnee)Equipement;
				if (TypeEntiteOrganisationnelle != null)
					return (IObjetASystemeDeCoordonnee)TypeEntiteOrganisationnelle;

				return null;
			}
			set
			{
				if (value is CSite)
					Site = (CSite)value;
				else
					Site = null;

				if (value is CStock)
					Stock = (CStock)value;
				else
					Stock = null;

				if (value is CTypeSite)
					TypeSite = (CTypeSite)value;
				else
					TypeSite = null;

				if (value is CTypeEntiteOrganisationnelle)
					TypeEntiteOrganisationnelle = (CTypeEntiteOrganisationnelle)value;
				else
					TypeEntiteOrganisationnelle = null;

				if (value is CTypeEquipement)
					TypeEquipement = (CTypeEquipement)value;
				else
					TypeEquipement = null;

				if (value is CEquipement)
					Equipement = (CEquipement)value;
				else
					Equipement = null;

			}
		}


		/// <summary>
        /// Retourne la liste des paramétrages de niveau du système de coordonnées relatif
		/// </summary>
		[RelationFille(typeof(CParametrageNiveau), "ParametrageSystemeCoordonnees")]
		[DynamicChilds("Parameterized levels", typeof(CParametrageNiveau))]
		public CListeObjetsDonnees RelationParametragesNiveau
		{
			get { return GetDependancesListe(CParametrageNiveau.c_nomTable, c_champId); } 
		}

		/// <summary>
		/// Retourne le tableau des paramétrages de niveaux, ordonné, suivant l'ordre<br/>
        /// défini dans le système de coordonnées.
		/// </summary>
		[DynamicField("Ordered parametrized levels")]
		public CParametrageNiveau[] ParametragesNiveauxOrdonnees
		{
			get
			{
				List<CParametrageNiveau> lst = new List<CParametrageNiveau>();
				foreach (CParametrageNiveau niveau in RelationParametragesNiveau)
					lst.Add(niveau);
				lst.Sort(new CParametrageNiveauPositionComparer());
				return lst.ToArray();
			}
		}


		/// <summary>
		/// Retourne le système de coordonnées relatif au paramétrage
		/// </summary>
		[RelationAttribute(
		  CSystemeCoordonnees.c_nomTable,
		  CSystemeCoordonnees.c_champId,
		  CSystemeCoordonnees.c_champId,
			true,
			false,
			false)]
		[DynamicField("Coordinate system")]
		public CSystemeCoordonnees SystemeCoordonnees
		{
			get	{ return (CSystemeCoordonnees)GetParent(CSystemeCoordonnees.c_champId, typeof(CSystemeCoordonnees)); }
			set	{ SetParent(CSystemeCoordonnees.c_champId, value); }
		}


		/// <summary>
		/// Cette méthode va vérifier que pour la coordonnee et son occupation il n'y a une interaction <br/>
		/// avec d'une liste d'objets à coordonnées
		/// </summary>
		/// <param name="strCoordonneeDebut">Coordonnée souhaité</param>
		/// <param name="strCoordonneeFin">Coordonnée de fin (Coordonnée Souhaité + Occupation)</param>
		/// <param name="lstobj">Liste des objets à tester pour savoir si il y a une interaction</param>
		/// <returns>Renvoi faux si aucune interaction</returns>
		public CResultAErreur Test_Interactions(
			string strCoordonneeDebut, 
			string strCoordonneeFin,
			List<IObjetACoordonnees> lstobj)
		{
			CResultAErreur result = CResultAErreur.True;

			List<IObjetACoordonnees> conflits = new List<IObjetACoordonnees>();

			foreach (IObjetACoordonnees obj in lstobj)
			{
				if (obj.Coordonnee != null && obj.Coordonnee != "")
				{
					string strCoorfilsdebut = obj.Coordonnee;
					string strCoorfilsfin = strCoorfilsdebut;

					//Il faut que la fin du fils soit avant le debut de la coor
					int compare1 = SystemeCoordonnees.CompareAdresse(strCoorfilsdebut, strCoordonneeDebut, true);
					//Ou que le debut du fils soit apres la fin de la coor
					int compare2 = SystemeCoordonnees.CompareAdresse(strCoorfilsfin, strCoordonneeFin, true);

					if (compare1 < 0 || compare2 > 0)
						continue;
					else
					{
						result.EmpileErreur(I.T( "@1 occupies a coordinate in conflict with the coordinate @2 (at @3)|180", obj.DescriptionElement, strCoordonneeDebut, strCoordonneeFin));
						conflits.Add(obj);
					}
				}
			}
			result.Data = conflits;

			return result;
		}

        public CNiveauCoordonnee[] DecodeCoordonnee(string strCoordonnee)
        {
            List<CNiveauCoordonnee> lst = new List<CNiveauCoordonnee>();
            if (strCoordonnee == null || strCoordonnee == "")
                return null;
            string[] strNiveaux = strCoordonnee.Split(CSystemeCoordonnees.c_separateurNumerotations);

            if (strNiveaux.Length > RelationParametragesNiveau.Count)
            {
                return null;
            }

            CParametrageNiveau[] parametragesNiveaux = ParametragesNiveauxOrdonnees;

            //On va remonter niveau par niveau
            int nI = 0;
            foreach ( CParametrageNiveau parametrageNiv in ParametragesNiveauxOrdonnees )
            {
                string strNiv = strNiveaux[nI];

                //Vérification syntaxique de la partie de coordonnée
                string strPrefixe = parametrageNiv.RelationSysCoor_FormatNum.IsolerPrefixe(strNiv);
                CResultAErreur result = parametrageNiv.RelationSysCoor_FormatNum.GetIndex(strNiv);
                if (!result)
                    return null;
                int nIndex = (int)result.Data;
                lst.Add ( new CNiveauCoordonnee ( strNiv, strPrefixe, nIndex ));
            }
            return lst.ToArray();
        }



		/// <summary>
		/// Verifie si la coordonnée existe syntaxiquement parlant
		/// </summary>
		/// <param name="strCoordonnee">Coordonnée à vérifier</param>
		/// <returns></returns>
		public CResultAErreur VerifieCoordonnee(string strCoordonnee)
		{
			CResultAErreur result = CResultAErreur.True;

			if (strCoordonnee == null || strCoordonnee == "")
				result.EmpileErreur(I.T("The coordinate cannot be empty|184"));
			else
			{
				string[] strNiveaux = strCoordonnee.Split(CSystemeCoordonnees.c_separateurNumerotations);

				if (strNiveaux.Length > RelationParametragesNiveau.Count)
				{
					result.EmpileErreur(I.T("Too many levels in the coordinate|251"));
					return result;
				}

				CParametrageNiveau[] parametragesNiveaux = ParametragesNiveauxOrdonnees;

				//On va remonter niveau par niveau
				for (int i = strNiveaux.Length; i > 0; i--)
				{
					CResultAErreur resulttmp = CResultAErreur.True;
					string Niv = strNiveaux[i - 1];

					CParametrageNiveau parametrageNiv = parametragesNiveaux[i - 1];

						//Vérification syntaxique de la partie de coordonnée
					resulttmp = parametrageNiv.RelationSysCoor_FormatNum.VerifieReference(Niv);

						//Vérification sur la plage paramétrée
					if(resulttmp.Result)
						resulttmp = parametrageNiv.ReferencePossible(Niv);

					if (!resulttmp.Result)
					{
						result.Erreur += resulttmp.Erreur;
						result.Result = false;
					}
				}

			}
			return result;
		}



		/// <summary>
		/// Vérifie si les éléments utilisant ce paramétrage vérifient bien ses modifications
		/// </summary>
		/// <returns></returns>
		public CResultAErreur IsModifValide()
		{
			CResultAErreur result=  CResultAErreur.True;
			string strProp = ((IObjetASystemeDeCoordonnee)ObjetASystemeDeCoordonnees).ProprieteVersObjetsAFilsACoordonneesUtilisantLeParametrage;
			List<IObjetAFilsACoordonnees> lstToTest = new List<IObjetAFilsACoordonnees>();
			if ( strProp != "" )
			{
				object val = CInterpreteurTextePropriete.GetValue ( ObjetASystemeDeCoordonnees, strProp );
				if ( val == null )
					return result;
				if ( val is IObjetAFilsACoordonnees )
					lstToTest.Add((IObjetAFilsACoordonnees)val);
				else
					if ( val is IEnumerable )
						foreach ( IObjetAFilsACoordonnees obj in (IEnumerable)val )
							lstToTest.Add ( obj );
			}
			else
				if ( ObjetASystemeDeCoordonnees is IObjetAFilsACoordonnees )
					lstToTest.Add((IObjetAFilsACoordonnees)ObjetASystemeDeCoordonnees);
			string strLib = this.ObjetASystemeDeCoordonnees.DescriptionElement;
			foreach ( IObjetAFilsACoordonnees obj in lstToTest )
			{
				result = obj.VerifieCoordonneesFils();
				if ( !result )
					return result;
			}
			return result;
		}


		/// <summary>
		/// Retourne le paramétrage pour le niveau demandé
		/// </summary>
		/// <param name="n">Niveau souhaité</param>
		/// <returns></returns>
		public CParametrageNiveau GetParametrageNiveau(int n)
		{
			CParametrageNiveau[] niveaux = ParametragesNiveauxOrdonnees;
			if (n >= 0 && n < niveaux.Length)
				return niveaux[n];
			return null;
		}
	}
}

/*
//public CParametrageSystemeCoordonnees operator +(CParametrageSystemeCoordonnees a)
//{
//}
*/
