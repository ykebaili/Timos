using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using sc2i.common;
using sc2i.common.memorydb;


namespace TimosInventory.data
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
    [DynamicClass("Coordinate system setting")]
	[MemoryTable(CParametrageSystemeCoordonnees.c_nomTable, CParametrageSystemeCoordonnees.c_champId )]
    public class CParametrageSystemeCoordonnees : CEntiteLieeATimos
	{
        #region [[ Constantes ]]

		public const string c_nomTable = "COORDINATE_SYS_SETTINGS";
        public const string c_champId = "COORSYSSET_ID";

        #endregion

		/// /////////////////////////////////////////////
		public CParametrageSystemeCoordonnees( CMemoryDb contexte)
			:base(contexte)
		{
		}

		/// /////////////////////////////////////////////
		public CParametrageSystemeCoordonnees(DataRow row)
			:base(row)
		{
		}

		

		/// /////////////////////////////////////////////
		public override void MyInitValeursParDefaut()
		{
		}

		


		#region Objets pouvant être liés

		/// <summary>
		/// Type Site
		/// </summary>
		[MemoryParent(true)]
		public CTypeSite TypeSite
		{
            get
            {
                return GetParent<CTypeSite>();
            }
			set
			{
                SetParent<CTypeSite>(value);
			}
		}

		/// <summary>
		/// Site
		/// </summary>
        [MemoryParent(true)]
		public CSite Site
		{
			get	{
                return GetParent<CSite>();
            }
			set
			{
                SetParent<CSite>(value);
			}
		}
		
		[MemoryParent(true)]
        public CEquipement Equipement
        {
            get{
                return GetParent<CEquipement>();
            }
            set{
                SetParent<CEquipement>(value);
            }
        }

        [MemoryParent(true)]
        public CTypeEquipement TypeEquipement
        {
            get{
                return GetParent<CTypeEquipement>();
            }
            set{
                SetParent<CTypeEquipement>(value);
            }
        }

        [MemoryParent(true)]
        public CStock Stock
        {
            get
            {
                return GetParent<CStock>();
            }
            set
            {
                SetParent<CStock>(value);
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
				if (TypeSite != null)
					return (IObjetASystemeDeCoordonnee)TypeSite;
/*				if (TypeEquipement != null)
					return (IObjetASystemeDeCoordonnee)TypeEquipement;
				if (Equipement != null)
					return (IObjetASystemeDeCoordonnee)Equipement;*/

				return null;
			}
			set
			{
				if (value is CSite)
					Site = (CSite)value;
				else
					Site = null;

				if (value is CTypeSite)
					TypeSite = (CTypeSite)value;
				else
					TypeSite = null;

                if (value is CStock)
                    Stock = (CStock)value;
                else
                    Stock = null;


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
		[MemoryChild()]
		[DynamicChilds("Parameterized levels", typeof(CParametrageNiveau))]
		public CListeEntitesDeMemoryDb<CParametrageNiveau> RelationParametragesNiveau
		{
			get { return GetFils<CParametrageNiveau>(); } 
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
        [MemoryParent(true)]
		public CSystemeCoordonnees SystemeCoordonnees
		{
            get
            {
                return GetParent<CSystemeCoordonnees>();
            }
            set
            {
                SetParent<CSystemeCoordonnees>(value);
            }
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

            if (strNiveaux.Length > RelationParametragesNiveau.Count())
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

				if (strNiveaux.Length > RelationParametragesNiveau.Count())
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

        //-------------------------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //-------------------------------------------------------------
        protected override CResultAErreur MySerialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            result = SerializeParent<CTypeSite>(serializer);
            if (result)
                result = SerializeParent<CTypeSite>(serializer);
            if (result)
                result = SerializeParent<CSite>(serializer);
            if (result)
                result = SerializeParent<CTypeEquipement>(serializer);
            if (result)
                result = SerializeParent<CStock>(serializer);
            if (result)
                result = SerializeParent<CEquipement>(serializer);
            if (result)
                result = SerializeParent<CSystemeCoordonnees>(serializer);
            return result;

        }
	}
}

/*
//public CParametrageSystemeCoordonnees operator +(CParametrageSystemeCoordonnees a)
//{
//}
*/
