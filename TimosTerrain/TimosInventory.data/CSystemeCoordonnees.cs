using System;
using System.Collections;
using System.Linq;
using System.Data;


using sc2i.common;
using sc2i.common.memorydb;


namespace TimosInventory.data
{

	/// <summary>
	/// Le Système de Coordonnées permet de créer des coordonnées à multiples niveaux afin pouvoir adrésser des entités en les imbriquants les unes les autres.<br/>
	/// Voici la liste des entités pouvant utiliser un Système de Coordonnées :<br/>
	/// <list type="bullet">
	///		<item><term><see cref="CTypeSite">		Types Site			</see></term></item>
	///		<item><term><see cref="CSite">			Sites				</see></term></item>
	///		<item><term><see cref="CStock">			Stocks				</see></term></item>
	///		<item><term><see cref="CTypeEquipement">Types Equipements	</see></term></item>
	///		<item><term><see cref="CEquipement">	Equipements			</see></term></item>
	///		<item><term><see cref="CTypeEntiteOrganisationnelle">	Types Entite Organisationnelle			</see></term></item>
	/// </list><br/><br/>
	/// Pour en savoir plus sur les 
	/// <see cref="CSystemeCoordonnees">Système de Coordonnées</see> vous pouvez vous référer
	/// aux multiples ressources.
	/// </summary>
    [DynamicClass("Coordinate setting")]
	[MemoryTable(CSystemeCoordonnees.c_nomTable, CSystemeCoordonnees.c_champId)]
    public class CSystemeCoordonnees :
        CEntiteLieeATimos, 
		IComparer
	{
        #region [[ Constantes ]]

		public const char c_separateurNumerotations = '.';

		public const string c_nomTable = "COORDINATE_SYSTEM";

        public const string c_champId = "COORSYS_ID";
		public const string c_champLibelle = "COORSYS_LABEL";
        #endregion

		/// /////////////////////////////////////////////
		public CSystemeCoordonnees( CMemoryDb contexte)
			:base(contexte)
		{
		}

		/// /////////////////////////////////////////////
		public CSystemeCoordonnees(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override void MyInitValeursParDefaut()
		{
		}

		



		/// <summary>
		/// Label du Système de Coordonnées <br/>
		/// (obligatoire)
		/// </summary>
        [MemoryField(c_champLibelle)]
        [DynamicField("Label")]
        public string Libelle
        {
            get
            {
                return Row.Get<string>(c_champLibelle);
            }
            set
            {
                Row[c_champLibelle] = value;
            }
        }


		/// <summary>
		/// Retourne le nombre de niveau(x) dans le Système de Coordonnées
		/// </summary>
		[DynamicField("Levels number")]
		public int NbNiveaux
		{
			get
			{
                return RelationFormatsNumerotation.Count();
			}
		}

		/// <summary>
        /// Retourne la liste des relations SystemeCoordonnées / FormatNumerotation<br/>
		/// Ces objets permettent la configuration d'un niveau du Système de Coordonnées
		/// </summary>
        [MemoryChild()]
        public CListeEntitesDeMemoryDb<CRelationSystemeCoordonnees_FormatNumerotation> RelationFormatsNumerotation
        {
            get
            {
                return GetFils<CRelationSystemeCoordonnees_FormatNumerotation>();
            }
        }

		


		/// <summary>
		/// Analyse une coordonnée donnée avec une unité pour voir si le dernier niveau<br/>
		/// de la coordonnée correspond bien avec fournie
		/// </summary>
		/// <param name="strCoordonnee">coordonnée à vérifier</param>
		/// <param name="unite">Unite</param>
		/// <returns>Retourne vrai ou faux avec des erreurs en cas de problème syntaxique ou autre sur la coordonnée</returns>
		public CResultAErreur VerifieUnite(string strCoordonnee,CUniteCoordonnee unite)
		{
			CResultAErreur result = CResultAErreur.True;
			string[] strNiveaux = strCoordonnee.Split(c_separateurNumerotations);

			int nNiveauFinal = strNiveaux.Length - 1;

			//récupère le la système de numérotation de ce niveau
			CListeEntitesDeMemoryDb<CRelationSystemeCoordonnees_FormatNumerotation> listeNiveaux = RelationFormatsNumerotation;
			listeNiveaux.Sort = CRelationSystemeCoordonnees_FormatNumerotation.c_champPosition;
			if (nNiveauFinal > listeNiveaux.Count())
			{
				//plus de paramétrage pour ce niveau
				result.EmpileErreur(I.T( "The coordinate has too many levels for the defined system|253"));
				return result;
			}
			CRelationSystemeCoordonnees_FormatNumerotation rel = (CRelationSystemeCoordonnees_FormatNumerotation)listeNiveaux.ElementAt(nNiveauFinal);
			return rel.VerifieUnite(unite);
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
            CResultAErreur result = serializer.TraiteVersion ( ref nVersion );
            if (!result)
                return result;
            result = SerializeChamps(serializer, c_champIdTimos, c_champLibelle);
            /*if (result)
                result = SerializeChilds<CRelationSystemeCoordonnees_FormatNumerotation>(serializer);
            */
            return result;
        }

        

		#region IComparer Membres

		public int Compare(object x, object y)
		{
			if ( !(x is string) | !(y is string) )
				return 0;

			string strAdresse1 = (string)x;
			string strAdresse2 = (string)y;
			return CompareAdresse ( strAdresse1, strAdresse2, 0, false );
		}

		public int CompareAdresse(string strAdresse1, string strAdresse2, bool bEgalSiVide)
		{
			return CompareAdresse(strAdresse1, strAdresse2, 0, bEgalSiVide);
		}

        /// <summary>
        /// Ajoute à la coordonnée nNbToAdd et retourne la nouvelle
        /// coordonnée (string dans le data), ou une erreur si ce n'est pas possible
        /// </summary>
        /// <param name="strCoordonnee"></param>
        /// <param name="nNbToAdd"></param>
        /// <returns></returns>
        public CResultAErreur AjouteDansNiveau(string strCoordonnee, int nNbToAdd)
        {
            CResultAErreur result = CResultAErreur.True;
            string[] strNiveaux = strCoordonnee.Split(c_separateurNumerotations);

            int nNiveauFinal = strNiveaux.Length - 1;

            //récupère le la système de numérotation de ce niveau
            CListeEntitesDeMemoryDb<CRelationSystemeCoordonnees_FormatNumerotation> listeNiveaux = RelationFormatsNumerotation;
            listeNiveaux.Sort = CRelationSystemeCoordonnees_FormatNumerotation.c_champPosition;
            if (nNiveauFinal > listeNiveaux.Count())
            {
                //plus de paramétrage pour ce niveau
                result.EmpileErreur(I.T("The coordinate has too many levels for the defined system|253"));
                return result;
            }

            //Ajoute le nombre au dernier niveau
            CRelationSystemeCoordonnees_FormatNumerotation rel = (CRelationSystemeCoordonnees_FormatNumerotation)listeNiveaux.ElementAt(nNiveauFinal);
            result = rel.Ajoute(strNiveaux[strNiveaux.Length - 1], nNbToAdd);

            if (!result)
                return result;

            //Reconstruit la coordonnée
            string strCoord = "";
            for (int nNiveau = 0; nNiveau < nNiveauFinal; nNiveau++)
                strCoord += strNiveaux[nNiveau] + c_separateurNumerotations;
            strCoord += (string)result.Data;
            result.Data = strCoord;

            return result;
        }

		private int CompareAdresse ( string strAdresse1, string strAdresse2, int nNiveau, bool bEgalSiVide )
		{			
			CListeEntitesDeMemoryDb<CRelationSystemeCoordonnees_FormatNumerotation> lstFormats = RelationFormatsNumerotation;
			if ( nNiveau >= lstFormats.Count()  )
				return 0;

			CRelationSystemeCoordonnees_FormatNumerotation relFormat = (CRelationSystemeCoordonnees_FormatNumerotation)lstFormats.ElementAt(nNiveau);
			if (strAdresse2 == "" || strAdresse1 == "")
				if (bEgalSiVide)
					return 0;
				else
					return strAdresse1.CompareTo ( strAdresse2 );

			int nPos1 = strAdresse1.IndexOf(c_separateurNumerotations);
			int nPos2 = strAdresse2.IndexOf(c_separateurNumerotations);
			string strDebut1, strFin1;
			string strDebut2, strFin2;
			if ( nPos1 > 0 )
			{
				strDebut1 = strAdresse1.Substring(0, nPos1);
				strFin1 = strAdresse1.Substring ( nPos1+1 );
			}
			else
			{
				strDebut1 = strAdresse1;
				strFin1 = "";
			}
			if ( nPos2 > 0 )
			{
				strDebut2 = strAdresse2.Substring(0, nPos2 );
				strFin2 = strAdresse2.Substring( nPos2+1 );
			}
			else
			{
				strDebut2 = strAdresse2;
				strFin2 = "";
			}
			int nResult = relFormat.Compare ( strDebut1, strDebut2 );
			if ( nResult != 0 )
				return nResult;

			return CompareAdresse(strFin1, strFin2, nNiveau+1,bEgalSiVide);
		}

		#endregion
	}


    



}
