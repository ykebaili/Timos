using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;

namespace timos.data
{

	/// <summary>
	/// Le Syst�me de Coordonn�es permet de cr�er des coordonn�es � multiples niveaux afin pouvoir adr�sser des entit�s en les imbriquants les unes les autres.<br/>
	/// Voici la liste des entit�s pouvant utiliser un Syst�me de Coordonn�es :<br/>
	/// <list type="bullet">
	///		<item><term><see cref="CTypeSite">		Types Site			</see></term></item>
	///		<item><term><see cref="CSite">			Sites				</see></term></item>
	///		<item><term><see cref="CStock">			Stocks				</see></term></item>
	///		<item><term><see cref="CTypeEquipement">Types Equipements	</see></term></item>
	///		<item><term><see cref="CEquipement">	Equipements			</see></term></item>
	///		<item><term><see cref="CTypeEntiteOrganisationnelle">	Types Entite Organisationnelle			</see></term></item>
	/// </list><br/><br/>
	/// Pour en savoir plus sur les 
	/// <see cref="CSystemeCoordonnees">Syst�me de Coordonn�es</see> vous pouvez vous r�f�rer
	/// aux multiples ressources.
	/// </summary>
    [sc2i.doccode.DocRefMenusOrMenuItems(CDocLabels.c_iCoordonnees)]
	//[sc2i.doccode.DocRefRessources(CDocLabels.c_pdfSystemeCoor,CDocLabels.c_docSystemeCoor,CDocLabels.c_urlSystemeCoor)]
    [DynamicClass("Coordinate setting")]
	[Table(CSystemeCoordonnees.c_nomTable, CSystemeCoordonnees.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CSystemeCoordonneesServeur")]
	[Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_SystemeCoor_ID)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_ParamSysCoord_ID)]
    public class CSystemeCoordonnees : 
		CObjetDonneeAIdNumeriqueAuto, 
		IObjetALectureTableComplete,
		IComparer
	{
        #region [[ Constantes ]]

		public const char c_separateurNumerotations = '.';

		public const string c_nomTable = "COORDINATE_SYSTEM";

        public const string c_champId = "COORSYS_ID";
		public const string c_champLibelle = "COORSYS_LABEL";


		public const string c_champModified = "COORSYS_MODIFIED";



        #endregion

		/// /////////////////////////////////////////////
		public CSystemeCoordonnees( CContexteDonnee contexte)
			:base(contexte)
		{
		}

		/// /////////////////////////////////////////////
		public CSystemeCoordonnees(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get { return I.T( "Coordinates System|126") + " " + Libelle; }
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champLibelle};
		}



		/// <summary>
		/// Label du Syst�me de Coordonn�es <br/>
		/// (obligatoire)
		/// </summary>
        [TableFieldProperty(c_champLibelle, 30)]
        [DynamicField("Label")]
        public string Libelle
        {
            get { return (string)Row[c_champLibelle]; }
            set	{ Row[c_champLibelle] = value; }
        }


		/// <summary>
		/// Indique que l'objet a �t� modifi� depuis la derni�re sauvegarde
		/// </summary>
		[TableFieldProperty(c_champModified, IsInDb=false)]
		[DynamicField("Modified")]
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


		/// <summary>
		/// Retourne le nombre de niveau(x) dans le Syst�me de Coordonn�es
		/// </summary>
		[DynamicField("Levels number")]
		public int NbNiveaux
		{
			get
			{
				CListeObjetsDonnees lstCRSCFN = this.RelationFormatsNumerotation;
				return lstCRSCFN.CountNoLoad;
			}
		}

		/// <summary>
        /// Retourne la liste des relations SystemeCoordonn�es / FormatNumerotation<br/>
		/// Ces objets permettent la configuration d'un niveau du Syst�me de Coordonn�es
		/// </summary>
		[RelationFille(typeof(CRelationSystemeCoordonnees_FormatNumerotation), "SystemeDeCoordonnees")]
		[DynamicChilds("Numbering formats", typeof(CRelationSystemeCoordonnees_FormatNumerotation))]
		public CListeObjetsDonnees RelationFormatsNumerotation
		{
			get	{ return GetDependancesListe(CRelationSystemeCoordonnees_FormatNumerotation.c_nomTable, c_champId);	}
		}

		/// <summary>
		/// Ajoute � la coordonn�e nNbToAdd et retourne la nouvelle
		/// coordonn�e (string dans le data), ou une erreur si ce n'est pas possible
		/// </summary>
		/// <param name="strCoordonnee"></param>
		/// <param name="nNbToAdd"></param>
		/// <returns></returns>
		public CResultAErreur AjouteDansNiveau(string strCoordonnee, int nNbToAdd)
		{
			CResultAErreur result = CResultAErreur.True;
			string[] strNiveaux = strCoordonnee.Split(c_separateurNumerotations);
			
			int nNiveauFinal = strNiveaux.Length-1;
			
			//r�cup�re le la syst�me de num�rotation de ce niveau
			CListeObjetsDonnees listeNiveaux = RelationFormatsNumerotation;
			listeNiveaux.Tri = CRelationSystemeCoordonnees_FormatNumerotation.c_champPosition;
			if (nNiveauFinal > listeNiveaux.Count)
			{
				//plus de param�trage pour ce niveau
				result.EmpileErreur(I.T("The coordinate has too many levels for the defined system|253"));
				return result;
			}

			//Ajoute le nombre au dernier niveau
			CRelationSystemeCoordonnees_FormatNumerotation rel = (CRelationSystemeCoordonnees_FormatNumerotation)listeNiveaux[nNiveauFinal];
			result = rel.Ajoute (strNiveaux[strNiveaux.Length - 1], nNbToAdd) ;
			
			if ( !result )
				return result;
			
			//Reconstruit la coordonn�e
			string strCoord = "";
			for ( int nNiveau = 0; nNiveau < nNiveauFinal; nNiveau++ )
				strCoord += strNiveaux[nNiveau]+c_separateurNumerotations;
			strCoord += (string)result.Data;
			result.Data = strCoord;

			return result;
		}


		/// <summary>
		/// Analyse une coordonn�e donn�e avec une unit� pour voir si le dernier niveau<br/>
		/// de la coordonn�e correspond bien avec fournie
		/// </summary>
		/// <param name="strCoordonnee">coordonn�e � v�rifier</param>
		/// <param name="unite">Unite</param>
		/// <returns>Retourne vrai ou faux avec des erreurs en cas de probl�me syntaxique ou autre sur la coordonn�e</returns>
		public CResultAErreur VerifieUnite(string strCoordonnee,CUniteCoordonnee unite)
		{
			CResultAErreur result = CResultAErreur.True;
			string[] strNiveaux = strCoordonnee.Split(c_separateurNumerotations);

			int nNiveauFinal = strNiveaux.Length - 1;

			//r�cup�re le la syst�me de num�rotation de ce niveau
			CListeObjetsDonnees listeNiveaux = RelationFormatsNumerotation;
			listeNiveaux.Tri = CRelationSystemeCoordonnees_FormatNumerotation.c_champPosition;
			if (nNiveauFinal > listeNiveaux.Count)
			{
				//plus de param�trage pour ce niveau
				result.EmpileErreur(I.T( "The coordinate has too many levels for the defined system|253"));
				return result;
			}
			CRelationSystemeCoordonnees_FormatNumerotation rel = (CRelationSystemeCoordonnees_FormatNumerotation)listeNiveaux[nNiveauFinal];
			return rel.VerifieUnite(unite);
		}

        public bool IsUsed()
        {
            ISystemeCoordonneesServeur sr = ContexteDonnee.GetTableLoader(GetNomTable()) as ISystemeCoordonneesServeur;
            return sr.IsUsed(Id);
        }

        public override CResultAErreur VerifieDonnees(bool bAuMomentDeLaSauvegarde)
        {

            CResultAErreur result = CResultAErreur.True;
            if ( CUtilSession.GetDonneeDroitForSession(ContexteDonnee.IdSession, CDroitDeBaseSC2I.c_droitAdministration) != null && IsUsed() )
            {
                result.EmpileErreur(new CErreurValidation(I.T("Warning, this system is in use. Be sure that your modification are compatible with existing coordinates|20126"), true));
            }
            if (!result)
                return result;

            return base.VerifieDonnees(bAuMomentDeLaSauvegarde);
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

		private int CompareAdresse ( string strAdresse1, string strAdresse2, int nNiveau, bool bEgalSiVide )
		{			
			CListeObjetsDonnees lstFormats = RelationFormatsNumerotation;
			if ( nNiveau >= lstFormats.Count  )
				return 0;

			CRelationSystemeCoordonnees_FormatNumerotation relFormat = (CRelationSystemeCoordonnees_FormatNumerotation)lstFormats[nNiveau];
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

    public interface ISystemeCoordonneesServeur : IObjetServeur
    {
        bool IsUsed ( int nId );
    }

    



}
