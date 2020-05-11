using System;
using System.Collections;
using System.Data;
using System.Collections.Generic;

using sc2i.common;
using sc2i.common.memorydb;

namespace TimosInventory.data
{

	/// <summary>
	/// Permet de configurer un format de num�rotation reposant sur une s�quence de caract�re<br/>
	/// personnalis�e ou Romaine.<br/><br/>
	/// 
	/// Les formats de num�rotation sont fortement li�s au fonctionnement des
	/// <see cref="CSystemeCoordonnees">Syst�me de Coordonn�es</see>.
	/// <br/><br/>
	/// Pour en savoir plus sur les 
	/// <see cref="CSystemeCoordonnees">Syst�me de Coordonn�es</see> vous pouvez vous r�f�rer
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
        /// Permet de limiter ou non (-1) la longueur (nb de caract�res)<br/>
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
		/// Label du format de num�rotation<br/>
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
		/// Cha�ne de caract�re repr�sentant la s�quence de num�rotation,<br/>
        /// c'est � dire la liste des caract�res utilisables dans la num�rotation.<br/>
		/// Cette cha�ne ne peut contenir plusieur fois le m�me caract�re ainsi<br/>
		/// que le caract�re de s�paration '.'<br/>
		/// Sa longueur doit �tre au minimum de 2
		/// </summary>
        [MemoryField(c_champSequence)]
        [DynamicField("Sequence")]
        public string Sequence
        {
            get { return (string)Row[c_champSequence]; }
            set { Row[c_champSequence] = value; }
        }

		/// <summary>
		/// Entier indiquant le nombre de caract�re des r�f�rences (des num�ros)<br/>
		/// Si ce nombre est � 0 il n'y aura pas de limite sur la taille
		/// </summary>
        [MemoryField(c_champLongueurReference)]
		[DynamicField("Reference length")]
		public int LongueurReference
		{
			get { return (int)Row[c_champLongueurReference]; }
			set	{ Row[c_champLongueurReference] = value; }
		}


		/// <summary>
		/// Indique que le format de num�rotation repose sur la num�rotation romaine<br/>
		/// Si ce mode est activ� la s�quence ne peut �tre �dit�e, ni la longueur de r�f�rence)
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
        /// L'index maximum est le rang du num�ro le plus grand pouvant �tre construit<br/>
        /// en fonction de la s�quence de caract�res et du nombre de caract�res choisi<br/>
        /// (nombre de num�ros pouvant �tre construits - 1).<br/>
		/// Pour les formats de num�rotation romain l'index maximum est fixe et egal � 5000<br/>
		/// Pour tous les autres formats si aucune longueur de r�f�rence n'est sp�cifi�e 
		/// l'index maximum support� est celui d'un Int32 : 2147483647<br/><br/>
		/// (avant la validation : retourne -1 quand la s�quence est nulle et -2 quand elle est trop courte)
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

				//Si la R�f�rence est Possible
				CResultAErreur result = GetIndex(ReferenceMax);
				if (result.Result)
					return (int)result.Data;
				else
					return int.MaxValue;
					
					
			}
		}

		/// <summary>
		/// Retourne la valeur de la r�f�rence maximum<br/>
		/// Pour les formats de num�rotation romain la r�f�rence maximum est fixe : MMMMM<br/><br/>
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

				//Pr�paration de la r�f�rence potentiellement la plus grande
				string strRefMax = "";
				for (int i = 0; i < LongueurReference; i++)
					strRefMax += Sequence.Substring(Sequence.Length - 1, 1);

				//V�rification de l'existance de la r�f�rence en fonction de
				//la limite int32
				CResultAErreur result = GetIndex(strRefMax);
				if (result.Result)
					return strRefMax;
				else
					return this.GetReference(int.MaxValue).Data.ToString();
					
					
			}
		}

        #endregion

        #region ~~ M�thodes ~~

		

		/// <summary>
		/// Permet la v�rification d'une r�f�rence sur sa normalisation
		/// </summary>
		/// <param name="strReferenceAVerifier">Reference � v�rifier</param>
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

			//Pas de s�quence d�termin�e
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
				//Reformatage si n�cessaire (Longueur sp�cifi�e)
				if (LongueurReference != 0)
				{
					int nDiff = LongueurReference - strReferenceAVerifier.Length;
					for (int i = 0; i != nDiff; i++)
						strReferenceAVerifier = Sequence.Substring(0, 1) + strReferenceAVerifier;
				}

				//Caract�re inexistant dans la s�quence
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
        /// Retourne la r�f�rence de l'index donn�<br/>
		/// En cas s'index n�gatif ou d'index trop grand une erreur est retourn�e<br/>
		/// (avant la validation retourne une erreur en cas se s�quence nulle ou trop courte)
        /// </summary>
		/// <param name="nIndex">index � r�f�rencer : doit �tre positif ou egal � 0 </param>
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
					//Si la limite et la longueur sont pr�cis�s �a va d�passer
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
        /// Retourne l'index de la r�f�rence donn�e<br/>
		/// Plusieurs erreurs potentielles peuvent �tre retourn�es :<br/>
		/// - la reference est vide<br/>
		/// - un ou plusieurs caract�res n'existent pas dans la s�quence<br/>
		/// - la longueur n'est pas adequate<br/>
		/// - l'index retourn� est en dehort des limites du format de num�rotation<br/>
		/// Avant validation :<br/>
		/// - la sequence est nulle<br/>
		/// - la s�quence est trop courte<br/>
        /// </summary>
		/// <param name="strReference">R�f�rence � indexer</param>
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

			//Verification de la reference donn�e
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
