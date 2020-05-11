using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;

using tiag.client;

using timos.data;
using System.IO;

namespace timos.securite
{
	/// <summary>
	/// Permet de définir des droits d'édition (geré uniquement dans le fenêtre et non pas
    /// au niveau serveur) pour un type spécifique
	/// </summary>
    [DynamicClass("Type edition rights")]
	[Table(CDroitEditionType.c_nomTable, CDroitEditionType.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CDroitEditionTypeServeur")]
	public class CDroitEditionType : CObjetDonneeAIdNumeriqueAuto,
		IObjetALectureTableComplete
	{
		public const string c_nomTable = "TYPE_EDITION_RIGHTS";
		public const string c_champId = "TERIGT_ID";
        public const string c_champTypeElements = "TERIGT_TYPE";
        public const string c_champDataDroits = "TERIGT_RIGHTS_DATA";

        public const string c_champCacheDroits = "TERIGT_RIGHTS_CACHE";

		/// /////////////////////////////////////////////
		public CDroitEditionType( CContexteDonnee contexte)
			:base(contexte)
		{
		}
		
	/// /////////////////////////////////////////////
		public CDroitEditionType(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
                Type tp = TypeElements;
				return I.T("Type right edition for @1",
                    tp != null?DynamicClassAttribute.GetNomConvivial(tp):"?"
                    );
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champTypeElements};
		}


        /// <summary>
        /// type of elements concerned by this rights definition
        /// </summary>
        [TableFieldProperty(c_champTypeElements, 1024)]
        [DynamicField("Elements type string")]
        public string TypeElementsString
        {
            get
            {
                return (string)Row[c_champTypeElements];
            }
            set
            {
                Row[c_champTypeElements] = value;
            }
        }

        /// /////////////////////////////////////////////////////////////
        public Type TypeElements
        {
            get
            {
                return CActivatorSurChaine.GetType(TypeElementsString);
            }
            set
            {
                if (value != null)
                    TypeElementsString = value.ToString();
                else
                    TypeElementsString = "";
            }
        }

        /// /////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champDataDroits, NullAutorise = true)]
        public CDonneeBinaireInRow Data
        {
            get
            {
                if (Row[c_champDataDroits] == DBNull.Value)
                {
                    CDonneeBinaireInRow donnee = new CDonneeBinaireInRow(ContexteDonnee.IdSession, Row, c_champDataDroits);
                    CContexteDonnee.ChangeRowSansDetectionModification(Row, c_champDataDroits, donnee);
                }
                return ((CDonneeBinaireInRow)Row[c_champDataDroits]).GetSafeForRow(Row.Row);
            }
            set
            {
                Row[c_champDataDroits] = value;
            }
        }

        /// /////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champCacheDroits, NullAutorise = true, IsInDb = false)]
        [BlobDecoder]
        public CParametreDroitEditionType ParametreDroits
        {
            get{
				CParametreDroitEditionType parametre = Row[c_champCacheDroits] as CParametreDroitEditionType;
                if ( parametre != null )
                    return parametre;
				if ( Data.Donnees != null )
				{
					MemoryStream stream = new MemoryStream(Data.Donnees);
					BinaryReader reader = new BinaryReader(stream);
					CSerializerReadBinaire serializer = new CSerializerReadBinaire(reader);
					CResultAErreur result = serializer.TraiteObject<CParametreDroitEditionType>(ref parametre);
					if ( !result )
					{
						parametre = new CParametreDroitEditionType();
					}
                    CContexteDonnee.ChangeRowSansDetectionModification(Row, c_champCacheDroits, parametre);
                    reader.Close();
                    stream.Close();

				}
                if (parametre == null)
                    parametre = new CParametreDroitEditionType();
				return parametre;
			}
			set
			{
				if ( value == null )
				{
					CDonneeBinaireInRow data = Data;
					data.Donnees = null;
					Data = data;
				}
				else
				{
					MemoryStream stream = new MemoryStream();
					BinaryWriter writer = new BinaryWriter(stream);
					CSerializerSaveBinaire serializer = new CSerializerSaveBinaire(writer);
                    CParametreDroitEditionType parametre = value;
					CResultAErreur result = serializer.TraiteObject<CParametreDroitEditionType> ( ref parametre );
					if ( result )
					{
						CDonneeBinaireInRow data = Data;
						data.Donnees = stream.GetBuffer();
						Data = data;
					}
                    writer.Close();
                    stream.Close();
				}
                CContexteDonnee.ChangeRowSansDetectionModification ( Row, c_champCacheDroits, DBNull.Value );
			}
        }

        /// /////////////////////////////////////////////////////////////
        public static CListeRestrictionsUtilisateurSurType GetDroits(CObjetDonnee objet)
        {
            CListeRestrictionsUtilisateurSurType liste = new CListeRestrictionsUtilisateurSurType();
            if (objet == null)
                return liste;
            CListeObjetsDonnees lst = new CListeObjetsDonnees(objet.ContexteDonnee, typeof(CDroitEditionType));
            lst.Filtre = new CFiltreData(CDroitEditionType.c_champTypeElements + "=@1",
                objet.GetType().ToString());

            foreach (CDroitEditionType droit in lst)
            {
                CParametreDroitEditionType parametre = droit.ParametreDroits;
                if (parametre != null)
                {
                    CListeRestrictionsUtilisateurSurType lstTmp = parametre.GetRestrictions(objet);
                    liste.Combine(lstTmp);
                }
            }
            return liste;
        }

	}
}
