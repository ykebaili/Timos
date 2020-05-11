using System;
using System.Collections;
using System.Data;
using System.IO;

using sc2i.data;
using sc2i.data.dynamic;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;

using timos.acteurs;
using timos.securite;

namespace sc2i.workflow
{
	/// <summary>
    /// Type de <see cref="CInstanceTableauPlanning">tableau de planning</see><br/>
    /// Un type de tableau de planning permet de définir le paramétrage pour<br/>
    /// un tableau de ce type.<br/>
    /// Un tableau de ce type présente en règle générale :<br/>
    /// <ul>
    /// <li>En ligne des entités organisationnelles</li>
    /// <li>En colonne des tranches horaires</li>
    /// <li>En intersection ligne/colonne (cellule), un acteur</li>
    /// </ul>
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    [DynamicClass("Schedule Table Type")]
    [Table(CTypeTableauPlanning.c_nomTable, CTypeTableauPlanning.c_champId, true)]
    [FullTableSync]
    [ObjetServeurURI("CTypeTableauPlanningServeur")]
    public class CTypeTableauPlanning : CObjetDonneeAIdNumeriqueAuto, IObjetALectureTableComplete
    {
        public const string c_nomTable = "PLANTAB_TYPE";

        public const string c_champId = "PLANTABTP_ID";
        public const string c_champLibelle = "PLANTABTP_LABEL";
        public const string c_champTypeElementsLigne = "PLANTABTP_ROWTYPE";
        public const string c_champFiltreElementsLigne = "PLANTABTP_ROWFILTER";
        public const string c_champTypeElementsData = "PLANTABTP_DATATYPE";
        public const string c_champFiltreElementsData = "PLANTABTP_DATAFILTER";
        public const string c_champNomPremiereColonne = "PLANTABTP_1STCOLNAME";

        /// /////////////////////////////////////////////
        public CTypeTableauPlanning(CContexteDonnee contexte)
            : base(contexte)
        {
        }

        /// /////////////////////////////////////////////
        public CTypeTableauPlanning(DataRow row)
            : base(row)
        {
        }

        /// /////////////////////////////////////////////
        public override string DescriptionElement
        {
            get
            {
                return I.T( "Schedule Table Type|") + " " + Libelle;
            }
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


        //-----------------------------------------------------------
        /// <summary>
        /// Libellé du type de tableau de planning
        /// </summary>
        [TableFieldProperty(c_champLibelle, 128)]
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


        
		//-----------------------------------------------------------
		/// <summary>
		/// Nom convivial correspondant aux éléments présentés
        /// en première colonne d'un tableau de ce type
        /// (exemple : Zone de maintenance).
		/// </summary>
		[TableFieldProperty ( c_champNomPremiereColonne, 128 )]
		[DynamicField("NomConvivial")]
		public string NomPremiereColonne
		{
			get
			{
				return (string)Row[c_champNomPremiereColonne];
			}
			set
			{
				Row[c_champNomPremiereColonne] = value;
			}
		}



        //-----------------------------------------------------------
        /// <summary>
        /// Type des élements présentés en ligne
        /// pour un tableau de ce type (en générale, des entités organisationnelles)
        /// </summary>
        [TableFieldProperty(c_champTypeElementsLigne, 1024)]
        [IndexField]
        [DynamicField("Row Elements Type")]
        public string StringTypeElementsLigne
        {
            get
            {
                return (string)Row[c_champTypeElementsLigne];
            }
            set
            {
                Row[c_champTypeElementsLigne] = value;
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        public Type TypeElementsLigne
        {
            get
            {
                return CActivatorSurChaine.GetType(StringTypeElementsLigne);
            }
            set
            {
                if (value != null)
                    StringTypeElementsLigne = value.ToString();
                else
                    StringTypeElementsLigne = "";
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// Type des élements "Data" pour un tableau de ce type
        /// (en générale, des acteurs)
        /// </summary>
        [TableFieldProperty(c_champTypeElementsData, 1024)]
        [IndexField]
        [DynamicField("Data Elements Type")]
        public string StringTypeElementsData
        {
            get
            {
                return (string)Row[c_champTypeElementsData];
            }
            set
            {
                Row[c_champTypeElementsData] = value;
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        public Type TypeElementsData
        {
            get
            {
                return CActivatorSurChaine.GetType(StringTypeElementsData);
            }
            set
            {
                if (value != null)
                    StringTypeElementsData = value.ToString();
                else
                    StringTypeElementsData = "";
            }
        }



        /// /////////////////////////////////////////////////////////
        [TableFieldProperty(c_champFiltreElementsData, NullAutorise = true)]
        public CDonneeBinaireInRow DonneeFiltreElementsData
        {
            get
            {
                if (Row[c_champFiltreElementsData] == DBNull.Value)
                {
                    CDonneeBinaireInRow donnee = new CDonneeBinaireInRow(ContexteDonnee.IdSession, Row, c_champFiltreElementsData);
                    CContexteDonnee.ChangeRowSansDetectionModification(Row, c_champFiltreElementsData, donnee);
                }
                object obj = Row[c_champFiltreElementsData];
                return ((CDonneeBinaireInRow)obj).GetSafeForRow(Row.Row);
            }
            set
            {
                Row[c_champFiltreElementsData] = value;
            }
        }

        /// /////////////////////////////////////////////////////////////
        /// <summary>
        /// Filtre les Type d'éléments "Data" (ou cellule du tableau)
        /// </summary>
        [BlobDecoder]
        public CFiltreDynamique FiltreDynamiqueElementsData
        {
            get
            {
                CFiltreDynamique filtre = null;
                if (DonneeFiltreElementsData.Donnees != null)
                {
                    filtre = new CFiltreDynamique(ContexteDonnee);
                    MemoryStream stream = new MemoryStream(DonneeFiltreElementsData.Donnees);
                    BinaryReader reader = new BinaryReader(stream);
                    CSerializerReadBinaire serializer = new CSerializerReadBinaire(reader);
                    CResultAErreur result = filtre.Serialize(serializer);
                    if (!result)
                    {
                        filtre = null;
                    }
                    reader.Close();
                    stream.Close();
                }

                return filtre;
            }
            set
            {
                if (value == null)
                {
                    CDonneeBinaireInRow data = DonneeFiltreElementsData;
                    data.Donnees = null;
                    DonneeFiltreElementsData = data;
                }
                else
                {
                    MemoryStream stream = new MemoryStream();
                    BinaryWriter writer = new BinaryWriter(stream);
                    CSerializerSaveBinaire serializer = new CSerializerSaveBinaire(writer);
                    CResultAErreur result = value.Serialize(serializer);
                    if (result)
                    {
                        CDonneeBinaireInRow data = DonneeFiltreElementsData;
                        data.Donnees = stream.GetBuffer();
                        DonneeFiltreElementsData = data;
                    }
                    writer.Close();
                    stream.Close();
                }
            }
        }




        /// /////////////////////////////////////////////////////////
        [TableFieldProperty(c_champFiltreElementsLigne, NullAutorise = true)]
        public CDonneeBinaireInRow DonneeFiltreElementsLigne
        {
            get
            {
                if (Row[c_champFiltreElementsLigne] == DBNull.Value)
                {
                    CDonneeBinaireInRow donnee = new CDonneeBinaireInRow(ContexteDonnee.IdSession, Row, c_champFiltreElementsLigne);
                    CContexteDonnee.ChangeRowSansDetectionModification(Row, c_champFiltreElementsLigne, donnee);
                }
                object obj = Row[c_champFiltreElementsLigne];
                return ((CDonneeBinaireInRow)obj).GetSafeForRow(Row.Row);
            }
            set
            {
                Row[c_champFiltreElementsLigne] = value;
            }
        }

        /// /////////////////////////////////////////////////////////////
        /// <summary>
        /// Filtre les Types d'éléments "Ligne"
        /// </summary>
        [BlobDecoder]
        public CFiltreDynamique FiltreDynamiqueElementsLigne
        {
            get
            {
                CFiltreDynamique filtre = null;
                if (DonneeFiltreElementsLigne.Donnees != null)
                {
                    filtre = new CFiltreDynamique(ContexteDonnee);
                    MemoryStream stream = new MemoryStream(DonneeFiltreElementsLigne.Donnees);
                    BinaryReader reader = new BinaryReader(stream);
                    CSerializerReadBinaire serializer = new CSerializerReadBinaire(reader);
                    CResultAErreur result = filtre.Serialize(serializer);
                    if (!result)
                    {
                        filtre = null;
                    }
                    reader.Close();
                    stream.Close();
                }

                return filtre;
            }
            set
            {
                if (value == null)
                {
                    CDonneeBinaireInRow data = DonneeFiltreElementsLigne;
                    data.Donnees = null;
                    DonneeFiltreElementsLigne = data;
                }
                else
                {
                    MemoryStream stream = new MemoryStream();
                    BinaryWriter writer = new BinaryWriter(stream);
                    CSerializerSaveBinaire serializer = new CSerializerSaveBinaire(writer);
                    CResultAErreur result = value.Serialize(serializer);
                    if (result)
                    {
                        CDonneeBinaireInRow data = DonneeFiltreElementsLigne;
                        data.Donnees = stream.GetBuffer();
                        DonneeFiltreElementsLigne = data;
                    }
                    writer.Close();
                    stream.Close();
                }
            }
        }



        //---------------------------------------------
        /// <summary>
        /// Retourne la liste des tranches horaires définies
        /// pour ce type de tableau
        /// </summary>
        [RelationFille(typeof(CTypeTableauPlanning_TrancheHoraire), "TypeTableauPlanning")]
        [DynamicChilds("Time Slots Relations", typeof(CTypeTableauPlanning_TrancheHoraire))]
        public CListeObjetsDonnees RelationsTranchesHoraires
        {
            get
            {
                return GetDependancesListe(CTypeTableauPlanning_TrancheHoraire.c_nomTable, c_champId);
            }
        }

        //---------------------------------------------
        public CHoraireJournalier_Tranche[] GetTranchesHoraires()
        {
            ArrayList listeTranches = new ArrayList();

            foreach (CTypeTableauPlanning_TrancheHoraire rel in RelationsTranchesHoraires)
            {
                listeTranches.Add(rel.TrancheHoraire);
            }

            return (CHoraireJournalier_Tranche[])listeTranches.ToArray(typeof(CHoraireJournalier_Tranche));
        }

    }
}
