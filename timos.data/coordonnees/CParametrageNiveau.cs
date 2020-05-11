using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;

namespace timos.data
{

	/// <summary>
	/// Permet de configurer les niveaux de num�rotation dans un 
	/// <see cref="CSystemeCoordonnees">Syst�me de Coordonn�es</see> 
	/// en leurs imposant une plage (index de d�part et longueur).<br/><br/>
	/// Les �ditions des param�trages de niveaux ne sont valid�es que si aucune des coordonn�es<br/>
	/// des objets qui utilisent le param�trage n'entre en conflit avec la modification de la plage.
	/// <br/>
	/// 
	/// Pour en savoir plus sur les 
	/// <see cref="CSystemeCoordonnees">Syst�me de Coordonn�es</see> vous pouvez vous r�f�rer
	/// aux multiples ressources.
	/// </summary>
    [sc2i.doccode.DocRefMenusOrMenuItems(CDocLabels.c_iCoordonnees)]
    [DynamicClass("Numbering level parameter")]
	[Table(CParametrageNiveau.c_nomTable, CParametrageNiveau.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CParametrageNiveauServeur")]
	[Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_SystemeCoor_ID)]
    public class CParametrageNiveau : CObjetDonneeAIdNumeriqueAuto, IObjetALectureTableComplete
	{
        #region [[ Constantes ]]

		public const string c_nomTable = "NUMBERING_LEVEL_PARAMS";

        public const string c_champId = "NLVPARAMS_ID";
		public const string c_champTaille = "NLVPARAMS_SIZE";
		public const string c_champPremierIndice = "NLVPARAMS_FIRST";
        #endregion

		/// /////////////////////////////////////////////
		public CParametrageNiveau( CContexteDonnee contexte)
			:base(contexte)
		{
		}

		/// /////////////////////////////////////////////
		public CParametrageNiveau(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get { return I.T( "Level setting @1|191", Libelle); }
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
		/// Retourne la plage des coordonn�es possibles du niveau (avec ou sans pr�fixe)
		/// </summary>
		/// <param name="SansPrefixe">vrai pour masquer le prefixe</param>
		/// <returns>List de string</returns>
		public List<string> GetPlage(bool SansPrefixe)
		{
			List<string> result = new List<string>();
			string strTmp = string.Empty;

			for (int i = this.PremierIndice; i < (this.Taille + this.PremierIndice); i++)
			{
				strTmp = (string)this.FormatNumerotation.GetReference(i).Data;

				if (!SansPrefixe)
					strTmp = this.Prefixes + strTmp;

				result.Add(strTmp);
			}
			return result;
		}


		/// <summary>
		/// Permet de v�rifier la validit� d'un index
		/// </summary>
		/// <param name="nindex">index � valider</param>
		/// <returns>Vrai si l'index est possible</returns>
		public CResultAErreur IndexPossible(int nindex)
		{
			CResultAErreur result = CResultAErreur.True;

			if (nindex > DernierIndice)
				result.EmpileErreur(I.T("Index @1 is beyond the last index (@2)|192", nindex.ToString(), DernierIndice.ToString()));

			else if (nindex < PremierIndice)
				result.EmpileErreur(I.T( "Index @1 is in lower part of the first index (@2)|193", nindex.ToString(), PremierIndice.ToString()));

			return result;
			
		}
		/// <summary>
		/// Permet de v�rifier la validit� d'une r�f�rence
		/// </summary>
		/// <param name="strRef">r�f�rence � valider (la r�f�rence donn�e doit �tre une r�f�rence
		/// complete (avec les pr�fixes (et co) parametr�s par les 
		/// <see ref="CRelationSystemeCoordonnees_FormatNumerotation">Relation Systeme Coordonn�es / Format Num�rotation</see></param>
		/// <returns>Vrai si la r�f�rence est possible</returns>
		public CResultAErreur ReferencePossible(string strRef)
		{
			CResultAErreur result = CResultAErreur.True;

			strRef = RelationSysCoor_FormatNum.IsolerReference(strRef);

			result = FormatNumerotation.GetIndex(strRef);
			
			if (result.Result)
			{
				if ((int)result.Data > DernierIndice)
					result.EmpileErreur(I.T("Reference @1 is beyond the last reference (@2)|194", strRef, DerniereReference));
				else if((int)result.Data < PremierIndice)
					result.EmpileErreur(I.T( "Reference @1 is underneath first reference (@2)|195", strRef, PremiereReference));
			}
			return result;
		}


        #region >> Accesseurs <<
		/// <summary>
		/// Label du format de num�rotation<br/>
		/// (obligatoire)
		/// </summary>
        [DynamicField("Label")]
        public string Libelle
        {
            get { return RelationSysCoor_FormatNum.Libelle; }
		}

		/// <summary>
		/// Premier index de la plage configur�e
		/// Lors de la validation la coh�rence de l'index peut �tre sujette � plusieurs erreurs :
		/// <list type="bullet">
		///		<listheader>
		///			<term>Erreurs</term>
		///			<description>Liste des erreurs possibles renvoy�es au moment de la validation</description>
		///		</listheader>
		///		<item>
		///			<term>Index trop �lev�</term>
		///			<description>L'index au del� de l'index maximum du format de num�rotation</description>
		///		</item>
		///		<item>
		///			<term>Index negatif</term>
		///			<description>Les index des formats de num�rotations ne peuvent �tre n�gatif</description>
		///		</item>
		/// </list>
		/// </summary>
		[TableFieldProperty(c_champPremierIndice)]
		[DynamicField("First index")]
		public int PremierIndice
		{
			get	
			{
				if (Row[c_champPremierIndice] == DBNull.Value)
					return 0;
				else
					return (int)Row[c_champPremierIndice]; 
			}
			set
			{
				if (Row[c_champPremierIndice] is int &&
					(int)Row[c_champPremierIndice] != value &&
					ParametrageSystemeCoordonnees != null)
					ParametrageSystemeCoordonnees.ModifieDepuisLaDerniereSauvegarde = true;
				Row[c_champPremierIndice] = value;
			}
		}

		/// <summary>
		/// Retourne le dernier index : calcul� avec le premier index et la longueur de la 
		/// plage sp�cifi�e
		/// </summary>
		[DynamicField("Last index")]
		public int DernierIndice
		{
			get { return (PremierIndice + Taille - 1); }
		}

		/// <summary>
		/// Retourne la premi�re r�f�rence du param�trage <br/>
		/// La r�f�rence sera celle fournie par le format de num�rotation (sans prefixe)
		/// </summary>
		[DynamicField("First reference")]
		public string PremiereReference
		{
			get	{ return ((string)FormatNumerotation.GetReference((int)Row[c_champPremierIndice]).Data); }
		}

		/// <summary>
		/// Retourne la derniere r�f�rence du param�trage <br/>
		/// La r�f�rence sera celle fournie par le format de num�rotation (sans prefixe)		
		/// </summary>
		[DynamicField("Last reference")]
		public string DerniereReference
		{
			get { return ((string)FormatNumerotation.GetReference(PremierIndice + Taille - 1).Data); }
		}


		/// <summary>
		/// Sp�cifie la plage des index possibles
		/// </summary>
		[TableFieldProperty(c_champTaille)]
		[DynamicField("Size")]
		public int Taille
		{
			get { return (int)Row[c_champTaille]; }
			set
			{
				if (Row[c_champTaille] is int &&
					(int)Row[c_champTaille] != value &&
					ParametrageSystemeCoordonnees != null)
					ParametrageSystemeCoordonnees.ModifieDepuisLaDerniereSauvegarde = true;
				Row[c_champTaille] = value;
			}
		}

		/// <summary>
		/// Retourne la position du format de num�rotation dans le 
		/// <see cref="timos.data.CSystemeCoordonnees">Systeme de Coordonn�es</see>
		/// </summary>
		[DynamicField("Position")]
		public int PositionDuNiveau
		{
			get	{ return RelationSysCoor_FormatNum.Position; }
		}


		/// <summary>
		/// Retourne l'unit� du niveau utilis�
		/// </summary>
		[DynamicField("Level unit")]
		public CUniteCoordonnee UniteDuNiveau
		{
			get	{ return RelationSysCoor_FormatNum.Unite; }
		}

		/// <summary>
		/// Retourne la cha�ne de caract�re contenant les pr�fixes param�tr�s dans la
		/// <see cref="CRelationSystemeCoordonnees_FormatNumerotation">Relation Systeme Coordonn�es / Format Num�rotation</see>
		/// correspondant � ce niveau
		/// </summary>
		[DynamicField("Prefixs")]
		public string Prefixes
		{
			get	{ return RelationSysCoor_FormatNum.Prefixes; }
		}


		/// <summary>
		/// Retourne la liste des coordonn�es possibles param�tr�es par ce niveau.<br/>
		/// <remarks>Les r�f�rences retourn�es comportent les pr�fixes configur�s par la 
		/// <see cref="CRelationSystemeCoordonnees_FormatNumerotation">Relation Systeme Coordonn�es / Format Num�rotation</see>
		/// correspondant � ce niveau</remarks>
		/// </summary>
		[DynamicField("Level interval")]
		public List<string> PlageNiveau
		{
			get { return GetPlage(false); }
		}

		/// <summary>
		/// Retourne le format de num�rotation d�sign� par la 
		/// <see cref="CRelationSystemeCoordonnees_FormatNumerotation">Relation Systeme Coordonn�es / Format Num�rotation</see>
		/// correspondant � ce niveau
		/// </summary>
		[DynamicField("Numbering format")]
		public CFormatNumerotation FormatNumerotation
		{
			get	{ return RelationSysCoor_FormatNum.FormatNumerotation;	}
		}

		/// <summary>
		/// Retourne la 
		/// <see cref="CRelationSystemeCoordonnees_FormatNumerotation">Relation Systeme Coordonn�es / Format Num�rotation</see>
		/// correspondant � ce niveau
		/// </summary>
		[RelationAttribute(
		   CRelationSystemeCoordonnees_FormatNumerotation.c_nomTable,
		   CRelationSystemeCoordonnees_FormatNumerotation.c_champId,
		   CRelationSystemeCoordonnees_FormatNumerotation.c_champId,
			true,
			false,
			false)]
		[DynamicField("Coordinate system / Numbering format")]
		public CRelationSystemeCoordonnees_FormatNumerotation RelationSysCoor_FormatNum
		{
			get	{ return (CRelationSystemeCoordonnees_FormatNumerotation)GetParent(CRelationSystemeCoordonnees_FormatNumerotation.c_champId, typeof(CRelationSystemeCoordonnees_FormatNumerotation)); }
			set	{ SetParent(CRelationSystemeCoordonnees_FormatNumerotation.c_champId, value); }
		}


		/// <summary>
		/// Retourne l'entit� param�trage Syst�me Coordonn�es � laquelle est rattach� ce parametrage de niveau
		/// </summary>
		[RelationAttribute(
		   CParametrageSystemeCoordonnees.c_nomTable,
		   CParametrageSystemeCoordonnees.c_champId,
		   CParametrageSystemeCoordonnees.c_champId,
			true,
			true,
			false)]
		[DynamicField("Coordinate system settings")]
		public CParametrageSystemeCoordonnees ParametrageSystemeCoordonnees
		{
			get	{ return (CParametrageSystemeCoordonnees)GetParent(CParametrageSystemeCoordonnees.c_champId, typeof(CParametrageSystemeCoordonnees)); }
			set	{ SetParent(CParametrageSystemeCoordonnees.c_champId, value); }
		}

        #endregion

    }


	/// <summary>
	/// Comparer triant les Parametrages de Niveaux du plus petit au plus grand
	/// </summary>
	public class CParametrageNiveauPositionComparer : System.Collections.Generic.IComparer<CParametrageNiveau>
	{
		public int Compare(CParametrageNiveau x, CParametrageNiveau y)
		{
			if (x.PositionDuNiveau > y.PositionDuNiveau)
				return 1;
			else if (x.PositionDuNiveau == y.PositionDuNiveau)
				return 0;
			else
				return -1;
		}
	}
}
