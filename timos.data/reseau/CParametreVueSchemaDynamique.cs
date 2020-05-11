using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using sc2i.data.dynamic;
using timos.securite;
using tiag.client;
using sc2i.doccode;
using timos.data.symbole.dynamique;
using System.IO;

namespace timos.data
{
    /// <summary>
    /// Un paramétrage de vue dynamique permet de définir des éléments graphiques<br/>
    /// qui viendront se superposer aux <see cref="CElementDeSchemaReseau">éléments de schéma réseau</see><br/>
    /// dans un <see cref="CSchemaReseau">schéma réseau</see>.
    /// </summary>
    [DynamicClass("Network diagram dynamic view setup")]
    [Table(CParametreVueSchemaDynamique.c_nomTable, CParametreVueSchemaDynamique.c_champId, true)]
    [ObjetServeurURI("CParametreVueSchemaDynamiqueServeur")]
    public class CParametreVueSchemaDynamique : CObjetDonneeAIdNumeriqueAuto
    {
        public const string c_nomTable = "NETWORK_DIAG_DYNAMIC";
        public const string c_champId = "NDD_ID";
        public const string c_champLibelle = "NDD_LABEL";
        public const string c_champData = "NDD_PARAMETERS";

        /// /////////////////////////////////////////////
		public CParametreVueSchemaDynamique( CContexteDonnee contexte)
			:base(contexte)
		{
		}

		/// /////////////////////////////////////////////
		public CParametreVueSchemaDynamique(DataRow row)
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
        // Decription du Type de lien réseau
		public override string DescriptionElement
		{
			get { return I.T( "Dynamic network diagram view: @1|20053", Libelle); }
		}


        /// /////////////////////////////////////////////
        protected override void MyInitValeurDefaut()
        {
        }

        /// /////////////////////////////////////////////
        public override string[] GetChampsTriParDefaut()
        {
            return new string[] { c_champLibelle };
        }

        /////////////////////////////////////////////
        /// <summary>
        /// Libellé de la vue dynamique
        /// </summary>
        [TableFieldProperty(c_champLibelle, 255)]
        [DynamicField("Label")]
        [TiagField("Label")]
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

        /////////////////////////////////////////////
        /// /////////////////////////////////////////////////////////
        /// Stocke le paramètre 
        [TableFieldProperty(CParametreVueSchemaDynamique.c_champData, NullAutorise = true)]
        public CDonneeBinaireInRow DataParametre
        {
            get
            {
                if (Row[c_champData] == DBNull.Value)
                {
                    CDonneeBinaireInRow donnee = new CDonneeBinaireInRow(ContexteDonnee.IdSession, Row, c_champData);
                    CContexteDonnee.ChangeRowSansDetectionModification(Row, c_champData, donnee);
                }
                object obj = Row[c_champData];
                return ((CDonneeBinaireInRow)obj).GetSafeForRow(Row.Row);
            }
            set
            {
                Row[c_champData] = value;
            }
        }

        /// /////////////////////////////////////////////////////////
        [BlobDecoder]
        public CParametreRepresentationSchema ParametreRepresentation
        {
            get
            {
                CDonneeBinaireInRow data = DataParametre;
                CParametreRepresentationSchema parametre = null;
                if (data != null && data.Donnees != null)
                {
                    Stream stream = new MemoryStream(data.Donnees);
                    BinaryReader reader = new BinaryReader(stream);
                    CSerializerReadBinaire serializer = new CSerializerReadBinaire(reader);
                    
                    CResultAErreur result = serializer.TraiteObject<CParametreRepresentationSchema>(ref parametre);
                    reader.Close();
                    stream.Close();
                    if ( !result )
                        parametre =  new CParametreRepresentationSchema();
                }
                return parametre;
            }
            set
            {
                CContexteDonnee.ChangeRowSansDetectionModification(Row.Row, c_champData, DBNull.Value);
                if (value == null)
                {
                    CDonneeBinaireInRow data = DataParametre;
                    data.Donnees = null;
                    DataParametre = data;

                }
                else
                {
                    MemoryStream stream = new MemoryStream();
                    BinaryWriter writer = new BinaryWriter(stream);
                    CSerializerSaveBinaire serializer = new CSerializerSaveBinaire(writer);
                    serializer.TraiteObject<CParametreRepresentationSchema>(ref value);
                    CDonneeBinaireInRow data = DataParametre;
                    data.Donnees = stream.GetBuffer();
                    writer.Close();
                    stream.Close();
                }
            }
        }
    }
}
