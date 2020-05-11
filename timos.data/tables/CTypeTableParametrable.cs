using System;
using System.Collections;
using System.Data;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;

using sc2i.data;
using sc2i.data.dynamic;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using sc2i.data.Excel;

namespace timos.data
{
    /// <summary>
    /// Type de <see cref="CTableParametrable">table paramétrable</see>.<br/>
    /// Le type de table paramétrable permet de définir la structure d'une table<br/>
    /// paramétrable et d'associer éventuellement des formulaires personnalisés.
    /// </summary>
    [DynamicClass("Custom Table Type")]
    [Table(CTypeTableParametrable.c_nomTable, CTypeTableParametrable.c_champId, true)]
    [FullTableSync]
    [ObjetServeurURI("CTypeTableParametrableServeur")]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_TablesParam_ID)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_TypesTables_ID)]
    [AutoExec("Autoexec")]
    public class CTypeTableParametrable : CElementAChamp,
                                          IObjetALectureTableComplete,
                                          IDefinisseurChampCustomRelationObjetDonnee
    {
        public const string c_nomTable = "CUSTOM_TABLE_TYPE";

        public const string c_champId = "TBTYPE_ID";
        public const string c_champLibelle = "TBTYPE_LABEL";
        public const string c_champParametrageImport = "TABLE_CSVIMPORTBLOB";
        public const string c_champParametrage = "TABLE_CSVIMPORT";
        public const string c_champParametrageImportXLS = "TABLE_XLSIMPORTBLOB";
        public const string c_champParametrageXLS = "TABLE_XLSIMPORT";

        public const string c_roleChampCustom = "CUTOM_TABLE_TYPE";

        /// /////////////////////////////////////////////
        public CTypeTableParametrable(CContexteDonnee contexte)
            : base(contexte)
        {
        }

        /// /////////////////////////////////////////////
        public CTypeTableParametrable(DataRow row)
            : base(row)
        {
        }

        //-------------------------------------------------------------------
        public static void Autoexec()
        {
            CRoleChampCustom.RegisterRole(c_roleChampCustom, "Custom Table type", typeof(CTypeTableParametrable), typeof(CDefinisseurChampsPourTypeSansDefinisseur));
        }

        /// /////////////////////////////////////////////
        public override string DescriptionElement
        {
            get { return I.T("Custom Table Type @1|436", Libelle); }
        }

        /// <summary>
        /// Libellé du type de table paramétrable<br/>
        /// (obligatoire)
        /// </summary>
        [TableFieldProperty(c_champLibelle, 255)]
        [DynamicField("Label")]
        public string Libelle
        {
            get { return (string)Row[c_champLibelle]; }
            set { Row[c_champLibelle] = value; }
        }


        /// <summary>
        /// Retourne la liste des colonnes déclarées pour le type de table
        /// </summary>
        [RelationFille(typeof(CColonneTableParametrable), "TypeTable")]
        [DynamicChilds("Columns", typeof(CColonneTableParametrable))]
        public CListeObjetsDonnees Colonnes
        {
            get { return GetDependancesListe(CColonneTableParametrable.c_nomTable, c_champId); }
        }


        /// <summary>
        /// Retourne la liste des colonnes entrant dans la clé primaire
        /// </summary>
        [DynamicChilds("Primary keys Columns", typeof(CColonneTableParametrable))]
        public CListeObjetsDonnees ColonnesClePrimaires
        {
            get
            {
                CListeObjetsDonnees lstCols = Colonnes;
                lstCols.Filtre = new CFiltreData(CColonneTableParametrable.c_champPKId + " is not null");
                lstCols.Tri = CColonneTableParametrable.c_champPKId;
                return lstCols;
            }
        }

        /// <summary>
        /// Retourne la liste des types de sites associés à ce type de table
        /// </summary>
        [RelationFille(typeof(CRelationTypeSite_TypeTableParametrable), "TypeTableParametrable")]
        [DynamicChilds("Site Types Associated", typeof(CRelationTypeSite_TypeTableParametrable))]
        public CListeObjetsDonnees RelationsTypesSites
        {
            get { return GetDependancesListe(CRelationTypeSite_TypeTableParametrable.c_nomTable, c_champId); }
        }

        /// <summary>
        /// Retourne la liste des types d'équipements associés à ce type de table
        /// </summary>
        [RelationFille(typeof(CRelationTypeEquipement_TypeTableParametrable), "TypeTableParametrable")]
        [DynamicChilds("Equipment Types Associated", typeof(CRelationTypeEquipement_TypeTableParametrable))]
        public CListeObjetsDonnees RelationsTypesEquipements
        {
            get { return GetDependancesListe(CRelationTypeEquipement_TypeTableParametrable.c_nomTable, c_champId); }
        }

        #region Paramétrage import CSV
        [TableFieldProperty(c_champParametrageImport, NullAutorise = true)]
        public CDonneeBinaireInRow ParametrageCSVBlob
        {
            get
            {
                if (Row[c_champParametrageImport] == DBNull.Value)
                {
                    CDonneeBinaireInRow donnee = new CDonneeBinaireInRow(ContexteDonnee.IdSession, Row, c_champParametrageImport);
                    CContexteDonnee.ChangeRowSansDetectionModification(Row, c_champParametrageImport, donnee);
                }
                object obj = Row[c_champParametrageImport];
                return ((CDonneeBinaireInRow)obj).GetSafeForRow(Row.Row);
            }
            set
            {
                if (value != null)
                    Row[c_champParametrageImport] = value;
                else
                    Row[c_champParametrageImport] = DBNull.Value;
            }
        }

        [TableFieldProperty(c_champParametrage, IsInDb = false)]
        [BlobDecoder]
        public CParametreLectureCSV ParametrageCSV
        {
            get
            {

                CDonneeBinaireInRow data = ParametrageCSVBlob;
                if (data != null && data.Donnees != null)
                {
                    try
                    {
                        MemoryStream stream = new MemoryStream(data.Donnees);
                        BinaryReader reader = new BinaryReader(stream);
                        CSerializerReadBinaire serializer = new CSerializerReadBinaire(reader);
                        CParametreLectureCSV parametre = new CParametreLectureCSV();
                        CResultAErreur result = parametre.Serialize(serializer);
                        reader.Close();
                        stream.Close();
                        if (result)
                            return parametre;
                    }
                    catch
                    {
                    }
                }
                return null;

            }
            set
            {
                if (value == null)
                {
                    CDonneeBinaireInRow data = ParametrageCSVBlob;
                    data.Donnees = null;
                    ParametrageCSVBlob = data;
                }
                else
                {
                    MemoryStream stream = new MemoryStream();
                    try
                    {
                        BinaryWriter writer = new BinaryWriter(stream);
                        CSerializerSaveBinaire serializer = new CSerializerSaveBinaire(writer);
                        CResultAErreur result = value.Serialize(serializer);
                        if (result)
                        {
                            CDonneeBinaireInRow data = ParametrageCSVBlob;
                            data.Donnees = stream.GetBuffer(); ;
                            ParametrageCSVBlob = data;
                        }
                        writer.Close();
                    }
                    catch
                    {
                        CDonneeBinaireInRow data = ParametrageCSVBlob;
                        data.Donnees = null;
                        ParametrageCSVBlob = data;
                    }
                    stream.Close();
                }
            }
        }
        #endregion

        #region Paramétrage import XLS
        [TableFieldProperty(c_champParametrageImportXLS, NullAutorise = true)]
        public CDonneeBinaireInRow ParametrageXLSBlob
        {
            get
            {
                if (Row[c_champParametrageImportXLS] == DBNull.Value)
                {
                    CDonneeBinaireInRow donnee = new CDonneeBinaireInRow(ContexteDonnee.IdSession, Row, c_champParametrageImportXLS);
                    CContexteDonnee.ChangeRowSansDetectionModification(Row, c_champParametrageImportXLS, donnee);
                }
                object obj = Row[c_champParametrageImportXLS];
                return ((CDonneeBinaireInRow)obj).GetSafeForRow(Row.Row);
            }
            set
            {
                if (value != null)
                    Row[c_champParametrageImportXLS] = value;
                else
                    Row[c_champParametrageImportXLS] = DBNull.Value;
            }
        }

        [TableFieldProperty(c_champParametrageXLS, IsInDb = false)]
        [BlobDecoder]
        public CParametreLectureExcel ParametrageXLS
        {
            get
            {
                CDonneeBinaireInRow data = ParametrageXLSBlob;
                if (data != null && data.Donnees != null)
                {
                    try
                    {
                        MemoryStream stream = new MemoryStream(data.Donnees);
                        BinaryReader reader = new BinaryReader(stream);
                        CSerializerReadBinaire serializer = new CSerializerReadBinaire(reader);
                        CParametreLectureExcel parametre = new CParametreLectureExcel();
                        CResultAErreur result = parametre.Serialize(serializer);
                        reader.Close();
                        stream.Close();
                        if (result)
                            return parametre;
                    }
                    catch
                    {
                    }
                }
                return null;

            }
            set
            {
                if (value == null)
                {
                    CDonneeBinaireInRow data = ParametrageXLSBlob;
                    data.Donnees = null;
                    ParametrageXLSBlob = data;
                }
                else
                {
                    MemoryStream stream = new MemoryStream();
                    try
                    {
                        BinaryWriter writer = new BinaryWriter(stream);
                        CSerializerSaveBinaire serializer = new CSerializerSaveBinaire(writer);
                        CResultAErreur result = value.Serialize(serializer);
                        if (result)
                        {
                            CDonneeBinaireInRow data = ParametrageXLSBlob;
                            data.Donnees = stream.GetBuffer();
                            ParametrageXLSBlob = data;
                        }
                        writer.Close();
                    }
                    catch
                    {
                        CDonneeBinaireInRow data = ParametrageXLSBlob;
                        data.Donnees = null;
                        ParametrageXLSBlob = data;
                    }
                    stream.Close();
                }
            }
        }
        #endregion


        //Cle Primaire
        public void MonterOrdreClePrimaire(CColonneTableParametrable col)
        {
            if (col.PrimaryKeyPosition == 0)
                return;

            foreach (CColonneTableParametrable c in ColonnesClePrimaires)
                if (c.PrimaryKeyPosition == col.PrimaryKeyPosition - 1)
                    c.PrimaryKeyPosition = col.PrimaryKeyPosition;

            col.PrimaryKeyPosition--;

        }
        public void DescendreOrdreClePrimaire(CColonneTableParametrable col)
        {
            if (col.PrimaryKeyPosition == ColonnesClePrimaires.CountNoLoad - 1)
                return;

            foreach (CColonneTableParametrable c in ColonnesClePrimaires)
                if (c.PrimaryKeyPosition == col.PrimaryKeyPosition + 1)
                    c.PrimaryKeyPosition = col.PrimaryKeyPosition;

            col.PrimaryKeyPosition++;
        }
        public bool ColonneExiste(CColonneTableParametrable col)
        {
            foreach (CColonneTableParametrable c in Colonnes)
                if (col == c)
                    return true;

            return false;
        }
        public void DefinirEnClePrimaire(CColonneTableParametrable col)
        {
            if (!ColonneExiste(col))
                return;

            if (col.PrimaryKeyPosition == null)
                col.PrimaryKeyPosition = ColonnesClePrimaires.Count;
        }
        public void DefinirSansClePrimaire(CColonneTableParametrable col)
        {
            if (!ColonneExiste(col))
                return;

            foreach (CColonneTableParametrable c in ColonnesClePrimaires)
                if (c.PrimaryKeyPosition < col.PrimaryKeyPosition)
                    MonterOrdreClePrimaire(c);

            col.PrimaryKeyPosition = null;
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

        /// /////////////////////////////////////////////
        public DataTable GetNewDataTable(string strNomTable)
        {
            DataTable dt = new DataTable(strNomTable);
            dt.Columns.Add("ID");
            dt.Columns[0].AutoIncrement = true;

            CListeObjetsDonnees lstcol = Colonnes;
            for (int i = 0; i < lstcol.Count; i++)
                foreach (CColonneTableParametrable col in lstcol)
                    if (col.Position == i)
                    {
                        dt.Columns.Add(col.GetDataColumn());
                        break;
                    }

            lstcol = ColonnesClePrimaires;
            if (lstcol.Count > 0)
            {
                List<DataColumn> colPks = new List<DataColumn>();
                foreach (CColonneTableParametrable col in lstcol)
                    foreach (DataColumn c in dt.Columns)
                        if (c.ColumnName == col.Libelle)
                        {
                            colPks.Add(c);
                            break;
                        }
                dt.PrimaryKey = colPks.ToArray();
            }

            CTableParametrable.PrepareToForUse(dt, null);

            return dt;
        }

        #region IDefinisseurChampCustomRelationObjetDonnee Membres
        [RelationFille(typeof(CRelationTypeTableParametrable_ChampCustom), "Definisseur")]
        public CListeObjetsDonnees RelationsChampsCustomListe
        {
            get { return GetDependancesListe(CRelationTypeTableParametrable_ChampCustom.c_nomTable, c_champId); }
        }

        [RelationFille(typeof(CRelationTypeTableParametrable_Formulaire), "Definisseur")]
        public CListeObjetsDonnees RelationsFormulairesListe
        {
            get { return GetDependancesListe(CRelationTypeTableParametrable_Formulaire.c_nomTable, c_champId); }
        }

        #endregion

        #region IDefinisseurChampCustom Membres


        public IRelationDefinisseurChamp_ChampCustom[] RelationsChampsCustomDefinis
        {
            get
            {
                return (IRelationDefinisseurChamp_ChampCustom[])RelationsChampsCustomListe.ToArray(typeof(IRelationDefinisseurChamp_ChampCustom));
            }
        }

        public IRelationDefinisseurChamp_Formulaire[] RelationsFormulaires
        {
            get
            {
                return (IRelationDefinisseurChamp_Formulaire[])RelationsFormulairesListe.ToArray(typeof(IRelationDefinisseurChamp_Formulaire));
            }
        }

        public CRoleChampCustom RoleChampCustomDesElementsAChamp
        {
            get
            {
                return CRoleChampCustom.GetRole(CTableParametrable.c_roleChampCustom);
            }
        }

        public CChampCustom[] TousLesChampsAssocies
        {
            get
            {
                Hashtable tableChamps = new Hashtable();
                FillHashtableChamps(tableChamps);
                CChampCustom[] liste = new CChampCustom[tableChamps.Count];
                int nChamp = 0;
                foreach (CChampCustom champ in tableChamps.Values)
                    liste[nChamp++] = champ;
                return liste;
            }
        }
        //-------------------------------------------------------------------
        /// <summary>
        /// Remplit une hashtable IdChamp->Champ
        /// avec tous les champs liés.(hiérarchique)
        /// </summary>
        /// <param name="tableChamps">HAshtable à remplir</param>
        private void FillHashtableChamps(Hashtable tableChamps)
        {
            foreach (IRelationDefinisseurChamp_ChampCustom relation in RelationsChampsCustomDefinis)
                tableChamps[relation.ChampCustom.Id] = relation.ChampCustom;
            foreach (IRelationDefinisseurChamp_Formulaire relation in RelationsFormulaires)
            {
                foreach (CRelationFormulaireChampCustom relFor in relation.Formulaire.RelationsChamps)
                    tableChamps[relFor.Champ.Id] = relFor.Champ;
            }
        }

        #endregion

        public override IDefinisseurChampCustom[] DefinisseursDeChamps
        {
            get
            {
                return new IDefinisseurChampCustom[]{
                    new CDefinisseurChampsPourTypeSansDefinisseur(
                        ContexteDonnee, 
                        CRoleChampCustom.GetRole(CTypeTableParametrable.c_roleChampCustom) )};
            }
        }

        public override CRelationElementAChamp_ChampCustom GetNewRelationToChamp()
        {
            return new CRelationTypeTableParametrable_ChampCustomValeur(ContexteDonnee);
        }

        [RelationFille(typeof(CRelationTypeTableParametrable_ChampCustomValeur), "ElementAChamps")]
        public override CListeObjetsDonnees RelationsChampsCustom
        {
            get
            {
                return GetDependancesListe(CRelationTypeTableParametrable_ChampCustomValeur.c_nomTable, c_champId);
            }
        }

        public override CRoleChampCustom RoleChampCustomAssocie
        {
            get
            {
                return CRoleChampCustom.GetRole(CTypeTableParametrable.c_roleChampCustom);
            }
        }

    }
}
