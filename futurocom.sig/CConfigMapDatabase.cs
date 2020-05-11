using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.multitiers.client;

using System.IO;
using sc2i.expression;


namespace futurocom.sig
{
	/// <summary>
	/// Configure la génération d'une carte géogaphique à partir d'entités
	/// </summary>
    [DynamicClass("Map view setup")]
	[Table(CConfigMapDatabase.c_nomTable, CConfigMapDatabase.c_champId, true )]
	[FullTableSync]
    [ObjetServeurURI("CConfigMapDatabaseServeur")]
	public class CConfigMapDatabase : CObjetDonneeAIdNumeriqueAuto
	{
		public const string c_nomTable = "MAP_SETUP";
		public const string c_champId = "MAPSET_ID";
		public const string c_champLibelle = "MAPSET_LABEL";
        public const string c_champConfigData = "MAPSET_SETUP";
        public const string c_champTypeSource = "MAPSET_SOURCE_TYPE";

		/// /////////////////////////////////////////////
		public CConfigMapDatabase( CContexteDonnee contexte)
			:base(contexte)
		{
		}
		
	/// /////////////////////////////////////////////
		public CConfigMapDatabase(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T("Map setup @1|20000",Libelle);
			}
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



        /// /////////////////////////////////////////////
		/// <summary>
		/// Libellé de la configuration
		/// </summary>
		[TableFieldProperty(c_champLibelle, 30)]
		[DynamicField("Label")]
		public string Libelle
		{
			get
			{
				return (string)Row[c_champLibelle];
			}
			set
			{
				Row[c_champLibelle] = value;
			}
		}

        /// /////////////////////////////////////////////////////////
        [TableFieldProperty(c_champTypeSource, 1024)]
        [DynamicField("Source type string")]
        public string TypeSourceString
        {
            get
            {
                return Row.Get<string>(c_champTypeSource);
            }
            set
            {
                Row[c_champTypeSource] = value;
            }
        }

        /// /////////////////////////////////////////////////////////
        public Type SourceType
        {
            get
            {
                return CActivatorSurChaine.GetType(TypeSourceString);
            }
            set
            {
                if (value == null)
                    TypeSourceString = "";
                else
                    TypeSourceString = value.ToString();
            }
        }

        /// /////////////////////////////////////////////////////////
        [TableFieldProperty(c_champConfigData, NullAutorise = true)]
        public CDonneeBinaireInRow DataConfig
        {
            get
            {
                if (Row[c_champConfigData] == DBNull.Value)
                {
                    CDonneeBinaireInRow donnee = new CDonneeBinaireInRow(ContexteDonnee.IdSession, Row, c_champConfigData);
                    CContexteDonnee.ChangeRowSansDetectionModification(Row, c_champConfigData, donnee);
                }
                object obj = Row[c_champConfigData];
                return ((CDonneeBinaireInRow)obj).GetSafeForRow(Row.Row);
            }
            set
            {
                Row[c_champConfigData] = value;
            }
        }

        /// /////////////////////////////////////////////////////////
        public static CListeObjetDonneeGenerique<CConfigMapDatabase> GetConfigsFor(CContexteDonnee ctxDonnee, CObjetPourSousProprietes objet)
        {
            CListeObjetDonneeGenerique<CConfigMapDatabase> lst = new CListeObjetDonneeGenerique<CConfigMapDatabase>(ctxDonnee);
            if (objet == null || objet.TypeAnalyse == null)
                lst.Filtre = new CFiltreData(c_champTypeSource + "=@1", "");
            else
                lst.Filtre = new CFiltreData(c_champTypeSource + "=@1 or " +
                    c_champTypeSource + "=@2",
                    "",
                    objet.TypeAnalyse.ToString());
            return lst;
        }

        /// /////////////////////////////////////////////////////////
        [BlobDecoder]
        public CMapDatabaseGenerator MapGenerator
        {
            get
            {
                CDonneeBinaireInRow data = DataConfig;
                CMapDatabaseGenerator parametre = null;
                if (data != null && data.Donnees != null)
                {
                    Stream stream = new MemoryStream(data.Donnees);
                    BinaryReader reader = new BinaryReader(stream);
                    CSerializerReadBinaire serializer = new CSerializerReadBinaire(reader);

                    CResultAErreur result = serializer.TraiteObject<CMapDatabaseGenerator>(ref parametre);
                    reader.Close();
                    stream.Close();
                    if (!result)
                        parametre = null;
                }
                if (parametre == null)
                    parametre = new CMapDatabaseGenerator();
                parametre.ContexteDonnee = ContexteDonnee;
                return parametre;
            }
            set
            {
                CContexteDonnee.ChangeRowSansDetectionModification(Row.Row, c_champConfigData, DBNull.Value);
                if (value == null)
                {
                    CDonneeBinaireInRow data = DataConfig;
                    data.Donnees = null;
                    DataConfig = data;
                    SourceType = null;
                }
                else
                {
                    MemoryStream stream = new MemoryStream();
                    BinaryWriter writer = new BinaryWriter(stream);
                    CSerializerSaveBinaire serializer = new CSerializerSaveBinaire(writer);
                    serializer.TraiteObject<CMapDatabaseGenerator>(ref value);
                    CDonneeBinaireInRow data = DataConfig;
                    data.Donnees = stream.GetBuffer();
                    writer.Close();
                    stream.Close();
                    SourceType = value.TypeSource;
                }
            }
        }

	}
}
