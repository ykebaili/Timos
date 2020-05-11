using System;
using System.Collections;
using System.Data;

using sc2i.common;
using System.Text;
using sc2i.common.memorydb;

namespace TimosInventory.data
{

	/// <summary>
	/// Relation entre un <see cref="CSystemeCoordonnees">Syst�me de Coordonn�es</see>
	/// et un <see cref="CFormatNumerotation">Format de Num�rotation</see>.<br/>
	/// Permet de d�terminer un niveau de coordonn�e avec un format de num�rotation en lui 
	/// associant un pr�fixe et une <see cref="CUniteCoordonnee">unit�</see>
	/// </summary>
    [DynamicClass("Coordinate system / Numbering format")]
	[MemoryTable(CRelationSystemeCoordonnees_FormatNumerotation.c_nomTable, CRelationSystemeCoordonnees_FormatNumerotation.c_champId)]
    public class CRelationSystemeCoordonnees_FormatNumerotation :
        CEntiteLieeATimos,
		IComparer
	{
		#region [[ Constantes ]]
		public const string c_nomTable = "COOR_SYS_NUMBERING_FORMAT";
		public const string c_champId = "COOSYS_NUMF_ID";

		public const string c_champPosition = "SYSCOO_NUMF_POSITION";
		public const string c_champLibelle = "SYSCOO_NUMF_LABEL";
		public const string c_champPrefixe = "SYSCOO_NUMF_PREFIXE";

		#endregion

		#region ++ Constructeurs ++
		//-------------------------------------------------------------------
		public CRelationSystemeCoordonnees_FormatNumerotation(CMemoryDb ctx)
			: base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationSystemeCoordonnees_FormatNumerotation(DataRow row)
			: base(row)
		{
		} 
		#endregion


		#region ~~ M�thodes ~~
		
		//////////////////////////////////////////////////////////////////////////
		public override void MyInitValeursParDefaut()
		{
		}

		

		#endregion


		#region >> Accesseurs <<
		/// <summary>
		/// Position du format de num�rotation dans le syst�me de coordonn�es
		/// </summary>
		[MemoryField(c_champPosition)]
		[DynamicField("Position")]
		public int Position
		{
			get	{ return (int)Row[c_champPosition];	}
			set	{ 
				Row[c_champPosition] = value;	
			}
		}

		/// <summary>
		/// Label de la relation Syst�me de Coordonn�es / Format de Num�rotation
		/// </summary>
		[MemoryField(c_champLibelle)]
		[DynamicField("Label")]
		public string Libelle
		{
			get { return (string)Row[c_champLibelle]; }
			set	{ Row[c_champLibelle] = value; }
		}

        /// <summary>
        /// Pr�fixes d�finis pour cette relation Syst�me de Coordonnn�es / Format de num�rotation<br/>
        /// Les pr�fixes sont s�par�s les uns des autres par le caract�re ";"<br/>
        /// Exemple : ANM;AAN;AAT;etc.
        /// </summary>
		[MemoryField(c_champPrefixe)]
		[DynamicField("Prefixs")]
		public string Prefixes
		{
			get	{ return (string)Row[c_champPrefixe]; }
            set
            {
                Row[c_champPrefixe] = value;
            }
		}
		
		//---------------------------------------------------------------------------
		public string[] PrefixesPossibles
		{
			get
			{
				string strPrefixes = Prefixes.Trim();
				if (strPrefixes.Length == 0)
					return new string[0];
				return Prefixes.Split(';');
			}
			set
			{
				StringBuilder bl = new StringBuilder();
				foreach (string strPrefixe in value)
				{
					if (strPrefixe != "")
					{
						bl.Append(strPrefixe);
						bl.Append(";");
					}
				}
				if (bl.ToString().Length > 0)
					bl.Remove(bl.Length - 1, 1);
				Prefixes = bl.ToString();
			}
		}

		/// <summary>
		/// Syst�me de Coordonn�es, objet de la relation
		/// </summary>
		[MemoryParent(true)]
		[DynamicField("Coordinate system")]
		public CSystemeCoordonnees SystemeDeCoordonnees
		{
			get	{
                return GetParent<CSystemeCoordonnees>();
            }
            set{
            SetParent<CSystemeCoordonnees>(value);
            }
        }

		/// <summary>
		/// Unit� relative � ce niveau de Coordonn�e
		/// </summary>
		[MemoryParent(true)]
		[DynamicField("Unit")]
		public CUniteCoordonnee Unite
		{
			get	{
                return GetParent<CUniteCoordonnee>();
            }
            set{
            SetParent<CUniteCoordonnee>(value);
            }
        }



		/// <summary>
		/// Format de num�rotation, objet de la relation
		/// </summary>
        [MemoryParent(true)]
		[DynamicField("Numbering format")]
		public CFormatNumerotation FormatNumerotation
		{
            get
            {
                return GetParent<CFormatNumerotation>();
            }
            set
            {
                SetParent<CFormatNumerotation>(value);
            }
		}
		#endregion

		/// <summary>
		/// Compare deux Adresses
		/// </summary>
		/// <param name="val1"></param>
		/// <param name="val2"></param>
		/// <returns></returns>
		public int Compare(object val1, object val2)
		{
			if (!(val1 is string) || !(val2 is string))
				return 0;
			string strVal1 = (string)val1;
			string strVal2 = (string)val2;
			string strPrefixe1 = IsolerPrefixe(strVal1);
			string strPrefixe2 = IsolerPrefixe(strVal2);
			if (strPrefixe1.ToUpper() != strPrefixe2)
				return strPrefixe1.CompareTo(strPrefixe2);
			strVal1 = IsolerReference(strVal1);
			strVal2 = IsolerReference(strVal2);
			if (FormatNumerotation != null)
				return FormatNumerotation.Compare(strVal1, strVal2);
			return 0;
		}

		/// <summary>
		/// V�rifie les erreurs faites sur une r�f�rence
		/// </summary>
		/// <param name="reference"></param>
		/// <returns></returns>
		public CResultAErreur VerifieReference(string reference)
		{
			CResultAErreur result = CResultAErreur.True;
			string strRefIsolee = IsolerReference(reference);
			if (reference == "" || reference == null)
				result.EmpileErreur(I.T( "The level @1 of the coordinate cannot be empty|185", Libelle));
			else if (PrefixesPossibles.Length > 0 &&  strRefIsolee == reference)
				result.EmpileErreur(I.T( "@1 : @2 prefixes missing for the level @3|186", reference, Prefixes, Libelle));

			else if (strRefIsolee.Length == 0 )
				result.EmpileErreur(I.T( "The level @1 of the coordinate does not have a value after the prefix|187", Libelle));


			return result;
		}


		/// <summary>
		/// Fourni l'index d'une reference complete (avec suffixe, prefixe)
		/// Attention ne v�rifi pas si l'index donn� est en dehors du parametrage niveau!
		/// </summary>
		/// <param name="reference"></param>
		/// <returns></returns>
		public CResultAErreur GetIndex(string strReference)
		{
			CResultAErreur result = CResultAErreur.True;
			string strRefIsolee = IsolerReference(strReference); ;
			if (Prefixes.Length > 0)
			{
				if (strReference == strRefIsolee )
					result.EmpileErreur(I.T( "Reference @1 is not valid|175", strReference));
			}

			if (result)
				result = FormatNumerotation.GetIndex(strRefIsolee);

			return result;
		}

		/// <summary>
		/// Supprime les Suffixes et autres pr�fixes qui peuvent �tre ajout�s aux coordonn�es
		/// </summary>
		/// <param name="referencecomplete"></param>
		/// <returns></returns>
		public string IsolerReference(string referencecomplete)
		{
			foreach (string strPrefixe in PrefixesPossibles)
			{
				if (referencecomplete.Length > strPrefixe.Length &&
					referencecomplete.Substring(0, strPrefixe.Length).ToUpper() == strPrefixe.ToUpper())
					return referencecomplete.Substring(strPrefixe.Length);
			}
			return referencecomplete;
		}

		//----------------------------------------------------------------
		public string IsolerPrefixe(string strReferenceComplete)
		{
			string strRefIsolee = IsolerReference(strReferenceComplete);
			if (strRefIsolee != strReferenceComplete)
				return strReferenceComplete.Substring(0, strReferenceComplete.Length - strRefIsolee.Length);
			return "";
		}


		/// <summary>
		/// Ajoute � la r�f�rence demand�e le nombre d'unit�s souhait� et <br/>
		/// retourne la nouvelle r�f�rence dans le data du result.
		/// </summary>
		/// <param name="strReference"></param>
		/// <param name="nNbToAdd"></param>
		/// <returns></returns>
		public CResultAErreur Ajoute(string strReference, int nNbToAdd)
		{
			CResultAErreur result = GetIndex(strReference);
			if (!result)
				return result;
			int nIndex = (int)result.Data + nNbToAdd;
			result = FormatNumerotation.GetReference(nIndex);
			if ( result) 
				result.Data = IsolerPrefixe ( strReference )+(string)result.Data;
			return result;
		}

		/// <summary>
		/// V�rifie que l'unit� correspond � l'unit� attendue
		/// </summary>
		/// <param name="unite"></param>
		/// <returns></returns>
		public CResultAErreur VerifieUnite(CUniteCoordonnee unite)
		{
			CResultAErreur result = CResultAErreur.True;
			if (Unite == null)
			{
				if (unite == null)
					return result;
			}
			else
			{
				if (unite == null || unite.Equals(Unite))
					return result;
			}
			result.EmpileErreur(I.T("The unit (@1) does not correspond to the expected unit (@2)|252",
				unite == null ? "null" : unite.Libelle,
				Unite == null ? "null" : Unite.Libelle));
			return result;
		}

        private int GetNumVersion()
        {
            return 0;
        }

        protected override CResultAErreur MySerialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            result = SerializeChamps(serializer,
                c_champIdTimos,
                c_champPosition,
                c_champLibelle,
                c_champPrefixe);
            if ( result )
                result = SerializeParent<CSystemeCoordonnees>(serializer);
            if (result)
                result = SerializeParent<CUniteCoordonnee>(serializer);
            if (result)
                result = SerializeParent<CFormatNumerotation>(serializer);
            return result;
        }
	}


	/// <summary>
	/// Trie les Relation SystemeCoordonnees / FormatNumerotation en fonction de leurs positions
	/// </summary>
	public class CRelationSystemeCoordonnees_FormatNumerotationPositionComparer : System.Collections.Generic.IComparer<CRelationSystemeCoordonnees_FormatNumerotation>
	{
		public int Compare(CRelationSystemeCoordonnees_FormatNumerotation x, CRelationSystemeCoordonnees_FormatNumerotation y)
		{
			if (x.Position > y.Position)
				return -1;
			else if (x.Position == y.Position)
				return 0;
			else
				return 1;
		}
	}

}
