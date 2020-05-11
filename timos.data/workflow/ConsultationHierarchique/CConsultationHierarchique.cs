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

namespace timos.data.workflow.ConsultationHierarchique
{
	/// <summary>
	/// Définit une consultation hiérarchique qui permet de 
	/// naviguer parmi les éléments de la base de données
	/// de manière hiérarchique (explorateur)
	/// </summary>
    [DynamicClass("Hierarchic consultation")]
	[Table(CConsultationHierarchique.c_nomTable, CConsultationHierarchique.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CConsultationHierarchiqueServeur")]
	public class CConsultationHierarchique : CObjetDonneeAIdNumeriqueAuto,
		IObjetALectureTableComplete
    {

        #region Enum Cas d'Utilisation
        /// <summary>
        /// 
        /// </summary>
        [Flags]
        public enum ECasUtilisation
        {
            Rien = 0,
            GED = 1,
            Schema = 2
        }

        #endregion

        public const string c_nomTable = "HIERARC_CONSULT";
		public const string c_champId = "HICO_ID";
		public const string c_champLibelle = "HICO_LABEL";
		public const string c_champDataConsultation = "HICO_DATA";
        public const string c_champTypeSource = "HICO_SOURCE_TYPE";
        public const string c_champUtilisation = "HICO_USE_CASE";

		/// /////////////////////////////////////////////
		public CConsultationHierarchique( CContexteDonnee contexte)
			:base(contexte)
		{
		}
		
	/// /////////////////////////////////////////////
		public CConsultationHierarchique(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T("Hierarchic consultation @1|20025",Libelle);
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
            CasUtilisationInt = 0; // Tout
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champLibelle};
		}
        		

		/// <summary>
		/// Le libellé de la consultation hiérarchique
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

		// /////////////////////////////////////////////////////////
		[TableFieldProperty(CConsultationHierarchique.c_champDataConsultation, NullAutorise = true)]
		public CDonneeBinaireInRow DataConsultation
		{
			get
			{
				if (Row[c_champDataConsultation] == DBNull.Value)
				{
					CDonneeBinaireInRow donnee = new CDonneeBinaireInRow(ContexteDonnee.IdSession, Row, c_champDataConsultation);
					CContexteDonnee.ChangeRowSansDetectionModification(Row, c_champDataConsultation, donnee);
				}
				object obj = Row[c_champDataConsultation];
				return ((CDonneeBinaireInRow)obj).GetSafeForRow(Row.Row);
			}
			set
			{
				Row[c_champDataConsultation] = value;
			}
		}

        //----------------------------------------------------
        /// <summary>
        /// Donne ou définit le type d'objet TIMOS à partir duquel
        /// la consultation hiérarchique est conçue pour être utilisée.
        /// Exemple :  timos.data.CEquipement
        /// </summary>
        [TableFieldProperty ( CConsultationHierarchique.c_champTypeSource, 1024)]
        [DynamicField("Source type string")]
        public string StringTypeCible
        {
            get
            {
                return (string)Row[c_champTypeSource];
            }
            set
            {
                Row[c_champTypeSource] = value;
            }
        }

        // /////////////////////////////////////////////////////////
        public Type TypeSource
        {
            get{
                if ( StringTypeCible != "" )
                    return CActivatorSurChaine.GetType ( StringTypeCible );
                return null;
            }
            set{
                if ( value == null )
                    StringTypeCible = "";
                else
                    StringTypeCible = value.ToString();
            }
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// Donne ou définit les Cas d'utilisation possibles de cette consultation :
        /// <ul>
        /// <li>0 - Nulle part</li>
        /// <li>1 - Sur la Gestion Electronique de Document</li>
        /// <li>2 - Sur les Schémas réseau</li>
        /// <li>3 - Sur la GED et les schémas réseau</li>
        /// </ul>
        /// </summary>
        [TableFieldProperty(c_champUtilisation)]
        [DynamicField("Use Case code")]
        public int CasUtilisationInt
        {
            get
            {
                return (int)Row[c_champUtilisation];
            }
            set
            {
                Row[c_champUtilisation] = value;
            }
        }
        //------------------------------------------------------------------------------
        /// <summary>
        /// Donne ou définit la combinaison des Cas d'utilisation possibles
        /// </summary>
        [DynamicField("Use Case")]
        public ECasUtilisation CasUtilisation
        {
            get
            {
                return (ECasUtilisation) CasUtilisationInt;
            }
            set
            {
                CasUtilisationInt = (int)value;
            }
        }

		// /////////////////////////////////////////////////////////
        [BlobDecoder]
        public CFolderConsultationHierarchique FolderRacine
		{
			get
			{
				CDonneeBinaireInRow data = DataConsultation;
				if (data != null && data.Donnees != null)
				{
					MemoryStream stream = new MemoryStream ( data.Donnees );
					BinaryReader reader = new BinaryReader(stream);
					CSerializerReadBinaire serializer = new CSerializerReadBinaire(reader);

					CFolderConsultationHierarchique folder = null;
                    CResultAErreur result = serializer.TraiteObject<CFolderConsultationHierarchique>(ref folder, new object[] { null });
                    reader.Close();
                    stream.Close();
					if (result)
						return folder;
				}
				CFolderConsultationHierarchique newFolder = new CFolderConsultationFolder(null);
				newFolder.Libelle = "Root";
				return newFolder;
			}
			set
			{
				if (value == null)
				{
					CDonneeBinaireInRow data = DataConsultation;
					data.Donnees = null;
					DataConsultation = data;
                    TypeSource = null;
				}
				else
				{
					MemoryStream stream = new MemoryStream();
					BinaryWriter writer = new BinaryWriter ( stream );
					CSerializerSaveBinaire serializer = new CSerializerSaveBinaire (writer);
					CResultAErreur result = serializer.TraiteObject<CFolderConsultationHierarchique>(ref value, null);
                    if (result)
                    {
                        CDonneeBinaireInRow donnee = DataConsultation;
                        donnee.Donnees = stream.ToArray();
                        DataConsultation = donnee;
                        CFolderConsultationRacineFromElement racineType = value as CFolderConsultationRacineFromElement;
                        if (racineType != null)
                            TypeSource = racineType.TypeRacine;
                        else
                            TypeSource = null;
                    }
                    writer.Close();
                    stream.Close();
				}
			}
		}

        public static Type[] TypesFoldersParametrables
        {
            get
            {
                return new Type[]{
                typeof(CFolderConsultationFolder),
                typeof(CFolderConsultationFromFiltre),
                typeof(CFolderConsultationFromFormula)
                };
            }
        }

	}
}
