using System;
using System.Collections;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Data;

using sc2i.data;
using sc2i.data.dynamic;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;

using tiag.client;

using timos.data;
using timos.data.workflow.ConsultationHierarchique;
using timos.data.projet.gantt;
using futurocom.supervision.alarmes;
using sc2i.documents;

namespace timos.data.supervision
{
	/// <summary>
	/// Définit la manière d'Afficher la liste des Alarmes dans la fenêtre de supervision.<br/>
    /// Il est possible de définir autant de listes que nécessaire<br/>
    /// C'est chaque exploitant, en final, qui choisit quels listes il veut activer en supervision.
	/// </summary>
    /// <remarks>
    /// Il est possible de définir les éléments principaux suivants :
    /// <ul>
    /// <li>Les colonnes à afficher et l'aspect de ces colonnes</li>
    /// <li>Le délai de persistance des alarmes retombées, dans la liste correspondante</li>
    /// <li>Le fichier son à activer lorsqu'apparaît une alarme</li>
    /// <li>La formule de filtrage des alarmes qui seront affichées dans cette liste</li>
    /// <li>La formule pour déclencher un événement sur arrivée d'une nouvelle alarme</li>
    /// <li>Le paramétrage de l'aspect des lignes</li>
    /// </ul>
    /// </remarks>
    [DynamicClass("Alarm List Setting")]
	[Table(CParametrageAffichageListeAlarmes.c_nomTable, CParametrageAffichageListeAlarmes.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CParametrageAffichageListeAlarmesServeur")]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModuleSupervision)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_ParametrageSupervision_ID)]
    public class CParametrageAffichageListeAlarmes : CObjetDonneeAIdNumeriqueAuto,
		IObjetALectureTableComplete
	{
		public const string c_nomTable = "ALARM_LIST_SETTINGS";
		public const string c_champId = "ALRMLST_SETTING_ID";
        public const string c_champLibelle = "ALRMLST_SETTING_LABEL";
        public const string c_champCode = "ALRMLST_SETTING_CODE";
        public const string c_champDataParametrage = "ALRMLST_SETTING_DATA";

		/// /////////////////////////////////////////////
		public CParametrageAffichageListeAlarmes( CContexteDonnee contexte)
			:base(contexte)
		{
		}
		
	/// /////////////////////////////////////////////
		public CParametrageAffichageListeAlarmes(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
                return I.T("Alarms Display Setting @1|10020", Libelle);
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

        //---------------------------------------------------------------------------------
		/// <summary>
		/// Le libellé du paramétrage
		/// </summary>
		[TableFieldProperty(c_champLibelle, 255)]
		[DynamicField("Label")]
        [DescriptionField]
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

        //---------------------------------------------------------------------------------
        /// <summary>
        /// Le Code du paramétrage
        /// </summary>
        [TableFieldProperty(c_champCode, 255)]
        [DynamicField("Code")]
        public string Code
        {
            get
            {
                return (string)Row[c_champCode];
            }
            set
            {
                Row[c_champCode] = value;
            }
        }

        //-------------------------------------------------------------------------
        /// <summary>
        /// Fichier son qui doit être activé lorque survient une alarme
        /// </summary>
        [Relation(
            CDocumentGED.c_nomTable,
            CDocumentGED.c_champId,
            CDocumentGED.c_champId,
            false,
            false,
            false)]
        [DynamicField("Sound File Document")]
        public CDocumentGED DocumentFichierSon
        {
            get
            {
                return (CDocumentGED)GetParent(CDocumentGED.c_champId, typeof(CDocumentGED));
            }
            set
            {
                if (value != null)
                    value.IsFichierSysteme = true;
                SetParent(CDocumentGED.c_champId, value);
            }
        }

        //---------------------------------------------------------------------------------
        /// <summary>
        /// Le Blob qui stock la tout le Parametrage en base
        /// </summary>
		[TableFieldProperty(CParametrageAffichageListeAlarmes.c_champDataParametrage, NullAutorise = true)]
		public CDonneeBinaireInRow DataParametres
		{
			get
			{
				if (Row[c_champDataParametrage] == DBNull.Value)
				{
					CDonneeBinaireInRow donnee = new CDonneeBinaireInRow(ContexteDonnee.IdSession, Row, c_champDataParametrage);
					CContexteDonnee.ChangeRowSansDetectionModification(Row, c_champDataParametrage, donnee);
				}
				object obj = Row[c_champDataParametrage];
				return ((CDonneeBinaireInRow)obj).GetSafeForRow(Row.Row);
			}
			set
			{
				Row[c_champDataParametrage] = value;
			}
		}
        
		// /////////////////////////////////////////////////////////
        [BlobDecoder]
        public CParametreAffichageListeAlarmes ParametreAffichageAlarmes
		{
			get
			{
				CDonneeBinaireInRow data = DataParametres;
				if (data != null && data.Donnees != null)
				{
					MemoryStream stream = new MemoryStream ( data.Donnees );
					BinaryReader reader = new BinaryReader(stream);
					CSerializerReadBinaire serializer = new CSerializerReadBinaire(reader);

                    CParametreAffichageListeAlarmes parametre = null;
                    CResultAErreur result = serializer.TraiteObject<CParametreAffichageListeAlarmes>(ref parametre, new object[] { });
                    reader.Close();
                    stream.Close();
					if (result)
                        return parametre;
				}
                return CParametreAffichageListeAlarmes.ParametreParDefaut;
			}
			set
			{
				if (value == null)
				{
					CDonneeBinaireInRow data = DataParametres;
					data.Donnees = null;
					DataParametres = data;
				}
				else
				{
					MemoryStream stream = new MemoryStream();
					BinaryWriter writer = new BinaryWriter ( stream );
					CSerializerSaveBinaire serializer = new CSerializerSaveBinaire (writer);
                    CResultAErreur result = serializer.TraiteObject<CParametreAffichageListeAlarmes>(ref value, null);
                    if (result)
                    {
                        CDonneeBinaireInRow donnee = DataParametres;
                        donnee.Donnees = stream.ToArray();
                        DataParametres = donnee;
                    }
                    writer.Close();
                    stream.Close();
				}
			}
		}


	}
}
