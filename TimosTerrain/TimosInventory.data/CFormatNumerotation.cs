using System;
using System.Collections;
using System.Data;
using System.Collections.Generic;

using sc2i.common;
using sc2i.common.memorydb;

namespace TimosInventory.data
{

	/// <summary>
	/// Permet de configurer un format de numérotation reposant sur une séquence de caractère<br/>
	/// personnalisée ou Romaine.<br/><br/>
	/// 
	/// Les formats de numérotation sont fortement liés au fonctionnement des
	/// <see cref="CSystemeCoordonnees">Système de Coordonnées</see>.
	/// <br/><br/>
	/// Pour en savoir plus sur les 
	/// <see cref="CSystemeCoordonnees">Système de Coordonnées</see> vous pouvez vous référer
	/// aux multiples ressources.
	/// </summary>
    [DynamicClass("Numbering format")]
	[MemoryTable(CFormatNumerotation.c_nomTable, CFormatNumerotation.c_champId )]
    public class CFormatNumerotation : CEntiteLieeATimos
	{
        #region [[ Constantes ]]
        public const string c_nomTable = "NUMBERING_FORMAT";

        public const string c_champId = "NUMF_ID";
        public const string c_champLibelle = "NUMF_LABEL";

        /// <summary>
        /// Permet de limiter ou non (-1) la longueur (nb de caractères)<br/>
        /// Base 0
        /// </summary>
        public const string c_champLongueurReference = "NUMF_REF_LENGHT";

        /// <summary>
        /// Chaine de texte indiquant la sequence (abcde : a,b,c,d,e)
        /// </summary>
        public const string c_champSequence = "NUMF_SEQUENCE";

		public const string c_champRomain = "NUMF_ROMAN";
        #endregion

		/// /////////////////////////////////////////////
		public CFormatNumerotation( CMemoryDb contexte)
			:base(contexte)
		{
		}

		/// /////////////////////////////////////////////
		public CFormatNumerotation(DataRow row )
			:base(row)
		{
		}

		
		/// /////////////////////////////////////////////
        public override void MyInitValeursParDefaut()
        {
        }

		
        #region >> Accesseurs <<

		/// <summary>
		/// Label du format de numérotation<br/>
		/// (obligatoire)
		/// </summary>
		[MemoryField(c_champLibelle)]
        [DynamicField("Label")]
        public string Libelle
        {
            get { return (string)Row[c_champLibelle]; }
            set { Row[c_champLibelle] = value; }
        }

		/// <summary>
		/// Chaîne de caractère représentant la séquence de numérotation,<br/>
        /// c'est à dire la liste des caractères utilisables dans la numérotation.<br/>
		/// Cette chaîne ne peut contenir plusieur fois le même caractère ainsi<br/>
		/// que le caractère de séparation '.'<br/>
		/// Sa longueur doit être au minimum de 2
		/// </summary>
        [MemoryField(c_champSequence)]
        [DynamicField("Sequence")]
        public string Sequence
        {
            get { return (string)Row[c_champSequence]; }
            set { Row[c_champSequence] = value; }
        }

		/// <summary>
		/// Entier indiquant le nombre de caractère des références (des numéros)<br/>
		/// Si ce nombre est à 0 il n'y aura pas de limite sur la taille
		/// </summary>
        [MemoryField(c_champLongueurReference)]
		[DynamicField("Reference length")]
		public int LongueurReference
		{
			get { return (int)Row[c_champLongueurReference]; }
			set	{ Row[c_champLongueurReference] = value; }
		}


		/// <summary>
		/// Indique que le format de numérotation repose sur la numérotation romaine<br/>
		/// Si ce mode est activé la séquence ne peut être éditée, ni la longueur de référence)
		/// </summary>
        [MemoryField(c_champRomain)]
		[DynamicField("Roman number")]
		public bool Romain
		{
			get	{ return (bool)Row[c_champRomain]; }
			set	{ Row[c_champRomain] = value; }
		}


		/// /////////////////////////////////////////////
        public int Base
        {
            get { return Sequence.Length; }
        }

		/// <summary>
		/// Retourne l'index maximum<br/>
        /// L'index maximum est le rang du numéro le plus grand pouvant être construit<br/>
        /// en fonction de la séquence de caractères et du nombre de caractères choisi<br/>
        /// (nombre de numéros pouvant être construits - 1).<br/>
		/// Pour les formats de numérotation romain l'index maximum est fixe et egal à 5000<br/>
		/// Pour tous les autres formats si aucune longueur de référence n'est spécifiée 
		/// l'index maximum supporté est celui d'un Int32 : 2147483647<br/><br/>
		/// (avant la validation : retourne -1 quand la séquence est nulle et -2 quand elle est trop courte)
		/// </summary>
		public int IndexMax
		{
			get 
			{
				if (Romain)
					return 5000;

				if (Sequence.Length == 0)
					return -1;
				if (Sequence.Length == 1)
					return -2; //A Traduire
				if (LongueurReference == 0)
					return int.MaxValue;

				//Si la Référence est Possible
				CResultAErreur result = GetIndex(ReferenceMax);
				if (result.Result)
					return (int)result.Data;
				else
					return int.MaxValue;
					
					
			}
		}

		/// <summary>
		/// Retourne la valeur de la référence maximum<br/>
		/// Pour les formats de numérotation romain la référence maximum est fixe : MMMMM<br/><br/>
		/// (avant la validation : retourne un message d'erreur pour une sequence trop courte ou nulle)
		/// </summary>
		public string ReferenceMax
		{
			get 
			{
				if (Romain)
					return ("MMMMM");
				if (Sequence.Length == 0)
					return I.T("Undefined sequence|216");
				if (Sequence.Length == 1)
					return I.T( "The sequence must have a minimum of 2 characters|169");
					
				if (LongueurReference == 0)
					return this.GetReference(int.MaxValue).Data.ToString();

				//Préparation de la référence potentiellement la plus grande
				string strRefMax = "";
				for (int i = 0; i < LongueurReference; i++)
					strRefMax += Sequence.Substring(Sequence.Length - 1, 1);

				//Vérification de l'existance de la référence en fonction de
				//la limite int32
				CResultAErreur result = GetIndex(strRefMax);
				if (result.Result)
					return strRefMax;
				else
					return this.GetReference(int.MaxValue).Data.ToString();
					
					
			}
		}

        #endregion

        #region ~~ Méthodes ~~

		

		/// <summary>
		/// Permet la vérification d'une référence sur sa normalisation
		/// </summary>
		/// <param name="strReferenceAVerifier">Reference à vérifier</param>
		/// <returns></returns>
		public CResultAErreur VerifierNormalisation(string strReferenceAVerifier)
		{
			CResultAErreur result = CResultAErreur.True;

			if (Romain)
			{
				try
				{
					CNombreRomain.IntFromRomain(strReferenceAVerifier);
					return result;
				}
				catch (Exception e)
				{
					result.EmpileErreur(new CErreurException(e));
				}
			}
				

			strReferenceAVerifier = strReferenceAVerifier.Trim().ToUpper();

			//Pas de séquence déterminée
			if (this.Sequence.Length == 0)
				result.EmpileErreur(I.T( "The sequence is empty|133"));

				//Sequence trop courte
			else if (this.Sequence.Length == 1)
				result.EmpileErreur(I.T( "The sequence must have a minimum of 2 characters|169"));

			//Valeur Nulle
			else if (strReferenceAVerifier == "" || strReferenceAVerifier == string.Empty)
				result.EmpileErreur(I.T( "Reference of @1 cannot be null|134", this.Libelle), this.LongueurReference.ToString());

			//Trop longue
			else if ((LongueurReference != 0) && strReferenceAVerifier.Length > LongueurReference)
				result.EmpileErreur(I.T( "Reference must have @1 character length|130"), this.LongueurReference.ToString());

			else
			{
				//Reformatage si nécessaire (Longueur spécifiée)
				if (LongueurReference != 0)
				{
					int nDiff = LongueurReference - strReferenceAVerifier.Length;
					for (int i = 0; i != nDiff; i++)
						strReferenceAVerifier = Sequence.Substring(0, 1) + strReferenceAVerifier;
				}

				//Caractère inexistant dans la séquence
				string strSequenceUp = Sequence.ToUpper();
				foreach (char c in strReferenceAVerifier.ToCharArray())
				{
					if (strSequenceUp.IndexOf(c) == -1)
						result.EmpileErreur(I.T( "Character @1 does not exist in the sequence (@2)|129"), c.ToString(),Sequence);
				}

				result.Data = strReferenceAVerifier;
			}

			return result;
		}

        /// <summary>
        /// Retourne la référence de l'index donné<br/>
		/// En cas s'index négatif ou d'index trop grand une erreur est retournée<br/>
		/// (avant la validation retourne une erreur en cas se séquence nulle ou trop courte)
        /// </summary>
		/// <param name="nIndex">index à référencer : doit être positif ou egal à 0 </param>
        /// <returns></returns>
        public CResultAErreur GetReference(int nIndex)
        {
            CResultAErreur result = CResultAErreur.True;
			if (Romain)
			{
				try
				{
					string strRomain = CNombreRomain.RomainFromInt(nIndex);
					result.Data = strRomain;
					return result;
				}
				catch (Exception e)
				{
					result.EmpileErreur(new CErreurException(e));
					return result;
				}
			}


			if (Sequence.Length == 0)
				result.EmpileErreur(I.T( "The sequence is empty|133"));
			else if (Sequence.Length == 1)
				result.EmpileErreur(I.T( "The sequence must have a minimum of 2 characters|169"));
            else if (nIndex < 0)
                result.EmpileErreur(I.T( "The index can't be negative|132"));
            else
            {
				string strReference = "";
				int nModulo = 0;

				if (nIndex == 0)
					strReference = Sequence.Substring(0, 1);

				while (nIndex != 0)
				{
					//Si la limite et la longueur sont précisés ça va dépasser
					if (this.LongueurReference != 0 && (strReference.Length == this.LongueurReference))
					{
						result.EmpileErreur(I.T( "This index is out of range|131"));
						nIndex = 0;
					}
					else
					{
						nModulo = nIndex % Base;
						strReference = Sequence.Substring(nModulo, 1) + strReference;
						nIndex = (nIndex - nModulo) / Base;
					}
				}

				if (result.Result && LongueurReference != 0)
				{
					int nDiff = LongueurReference - strReference.Length;
					for (int i = 0; i != nDiff; i++)
						strReference = Sequence.Substring(0, 1) + strReference;
				}

                result.Data = strReference.ToUpper();
            }
            return result;
        }

        /// <summary>
        /// Retourne l'index de la référence donnée<br/>
		/// Plusieurs erreurs potentielles peuvent être retournées :<br/>
		/// - la reference est vide<br/>
		/// - un ou plusieurs caractères n'existent pas dans la séquence<br/>
		/// - la longueur n'est pas adequate<br/>
		/// - l'index retourné est en dehort des limites du format de numérotation<br/>
		/// Avant validation :<br/>
		/// - la sequence est nulle<br/>
		/// - la séquence est trop courte<br/>
        /// </summary>
		/// <param name="strReference">Référence à indexer</param>
        /// <returns></returns>
        public CResultAErreur GetIndex(string strReference)
        {
            CResultAErreur result = CResultAErreur.True;

			if (Romain)
			{
				try
				{
					int nVal = CNombreRomain.IntFromRomain(strReference);
					nVal = Math.Max(nVal, 0);
					result.Data = nVal;
					return result;
				}
				catch (Exception e)
				{
					result.EmpileErreur(new CErreurException(e));
					return result;
				}
			}

			//Verification de la reference donnée
			result = VerifierNormalisation(strReference);
			
			if(result.Result)
            {
                int nIndex = 0;
                int nCpt = strReference.Length - 1;
                char[] lstChars = strReference.ToUpper().ToCharArray();
				string strSequenceUp = Sequence.ToUpper();

                foreach (char c in lstChars)
                {
					int nPosDansSec = strSequenceUp.IndexOf(c);

					if (nPosDansSec == -1)
					{
						result.EmpileErreur(I.T( "The char '@1' is not in the sequence", c.ToString()));
						return result;
					}

					double nTmp = (double)nIndex;
					nTmp += (double)nPosDansSec * Math.Pow((double)Base, (double)nCpt);

					if (nTmp > (double) int.MaxValue)
					{
						result.EmpileErreur(I.T( "Reference out of range|128"), c.ToString());
						break;
					}
					else
						nIndex = (int)nTmp;

                    nCpt--;
                }

                result.Data = nIndex;
            }
            return result;
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
            result = SerializeChamps(serializer,
                c_champIdTimos,
                c_champLibelle,
                c_champLongueurReference,
                c_champSequence,
                c_champRomain);
            return result;
        }


        

		#region IComparer Membres
		
		//------------------------------------------------------------
		/// <summary>
		/// Compare deux adresses
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public int  Compare(object x, object y)
		{
 			if ( !(x is string ) || !(y is string) )
				return 0;
			string strAdresse1 = (string)x;
			string strAdresse2 = (string)y;
			
			int nVal1 = 0;
			int nVal2 = 0;
			CResultAErreur result = GetIndex(strAdresse1);
			if (!result)
				return 0;
			nVal1 = (int)result.Data;
			result = GetIndex(strAdresse2);
			nVal2 = (int)result.Data;
			if (nVal1 < nVal2)
				return -1;
			if (nVal2 < nVal1)
				return 1;
			return 0;
		}

		

		#endregion
        #endregion
    

	}
}
