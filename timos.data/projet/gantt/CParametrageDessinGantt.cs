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

namespace timos.data.projet.gantt
{
	/// <summary>
	/// Définit la manière de dessiner les éléments dans un diagramme de gantt
	/// </summary>
    [DynamicClass("Gantt drawing settings")]
	[Table(CParametrageDessinGantt.c_nomTable, CParametrageDessinGantt.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CParametrageDessinGanttServeur")]
	public class CParametrageDessinGantt : CObjetDonneeAIdNumeriqueAuto,
		IObjetALectureTableComplete
	{
		public const string c_nomTable = "GANTT_DRAWING_SETTINGS";
		public const string c_champId = "GANTDR_ID";
		public const string c_champLibelle = "GANTDR_LABEL";
		public const string c_champDataParametrage = "GANT_DATA";

		/// /////////////////////////////////////////////
		public CParametrageDessinGantt( CContexteDonnee contexte)
			:base(contexte)
		{
		}
		
	/// /////////////////////////////////////////////
		public CParametrageDessinGantt(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T("Gantt drawing settings @1|20056",Libelle);
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


		

		/// <summary>
		/// Le libellé du paramétrage Gantt
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
		[TableFieldProperty(CParametrageDessinGantt.c_champDataParametrage, NullAutorise = true)]
		public CDonneeBinaireInRow DataGroupe
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
        public CParametreDessinLigneGantt ParametreDessin
		{
			get
			{
				CDonneeBinaireInRow data = DataGroupe;
				if (data != null && data.Donnees != null)
				{
					MemoryStream stream = new MemoryStream ( data.Donnees );
					BinaryReader reader = new BinaryReader(stream);
					CSerializerReadBinaire serializer = new CSerializerReadBinaire(reader);

                    CParametreDessinLigneGantt parametre = null;
                    CResultAErreur result = serializer.TraiteObject<CParametreDessinLigneGantt>(ref parametre, new object[] { });
                    reader.Close();
                    stream.Close();
					if (result)
                        return parametre;
				}
                return CParametreDessinLigneGantt.ParametreParDefaut;
			}
			set
			{
				if (value == null)
				{
					CDonneeBinaireInRow data = DataGroupe;
					data.Donnees = null;
					DataGroupe = data;
				}
				else
				{
					MemoryStream stream = new MemoryStream();
					BinaryWriter writer = new BinaryWriter ( stream );
					CSerializerSaveBinaire serializer = new CSerializerSaveBinaire (writer);
                    CResultAErreur result = serializer.TraiteObject<CParametreDessinLigneGantt>(ref value, null);
                    if (result)
                    {
                        CDonneeBinaireInRow donnee = DataGroupe;
                        donnee.Donnees = stream.ToArray();
                        DataGroupe = donnee;
                    }
                    writer.Close();
                    stream.Close();
				}
			}
		}

        




	}
}
