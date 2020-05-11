using System;
using System.Linq;
using System.Collections;

using System.Collections.Generic;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;

using tiag.client;

using timos.data;
using System.IO;
using System.Text;
using futurocom.snmp.Mib;
using timos.data.snmp;
using sc2i.data.dynamic;
using futurocom.supervision;
using sc2i.expression;
using futurocom.snmp.entitesnmp;
using futurocom.easyquery;
using futurocom.snmp.dynamic;
using sc2i.common.memorydb;
using timos.data.supervision;
using timos.data.snmp.polling;

namespace timos.data.snmp
{
	/// <summary>
	/// Un type d'entité SNMP permet principalement de définir :
    /// <ul>
    /// <li>le mapping entre des données de la MIB et des <see cref="sc2i.data.dynamic.CChampCustom">Champs personnalisés</see></li>
    /// <li>le formulaire permettant d'éditer les <see cref="CTypeEntiteSnmp">entités SNMP</see> de ce type</li>
    /// <li>la catégorie des éléments associés aux entités de ce type (<see cref="CEquipement">équipement</see>, <see cref="CLienReseau">lien réseau</see>, <see cref="CSite">site</see>)</li>
    /// <li>la formule permettant de donner un nom à une entité de ce type</li>
    /// <li>le symbole graphique permettant de représenter l'entité dans une vue de supervision</li>
    /// </ul>
	/// </summary>
    [DynamicClass("Snmp entity type")]
    [Table(CTypeEntiteSnmp.c_nomTable, CTypeEntiteSnmp.c_champId, true)]
	[ObjetServeurURI("CTypeEntiteSnmpServeur")]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModuleSNMP)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_ParametrageSnmp_ID)]
	public class CTypeEntiteSnmp : CObjetHierarchique,
        IDefinisseurChampCustomRelationObjetDonnee,
		IObjetALectureTableComplete,
        IElementADonneePourMediationSNMP,
        IDefinisseurSymbole
	{
		public const string c_nomTable = "SNMP_ENTITY_TYPE";
		public const string c_champId = "SNMPETTTP_ID";
        public const string c_champLibelle = "SNMPETTTP_LABEL";
        public const string c_champAllowAddDelete = "SNMPETTTP_ALLOW_ADD";
        public const string c_champReadOnly = "SNMPETTTP_READONLY";
        public const string c_champIdTableSource = "SNMPETTTP_SOURCE_ID";
        public const string c_champFormuleIndex = "SNMPETTTP_INDEX_FORMULA";
        public const string c_champCacheFormuleIndex = "SNMPETTTP_CACHE_INDEX";
        public const string c_champFormuleLibelle = "SNMPETTTP_LABEL_FORMULA";
        public const string c_champCacheFormuleLibelle = "SNMPETTTP_CACHE_LABEL";
        public const string c_champDisplayIndex = "SNMPETTP_INDEX";
        public const string c_champUpdateIndex = "SNMPETTTP_UPDATE_NDX";
        public const string c_champModeFormulaire = "SNMPETTP_FORM_MODE";
        public const string c_champTypeElementsSupervise = "SNMPETTP_TPELMENTSUP";
        public const string c_champFiltreElementsSupervise = "SNMPETTP_DATAFILTER";

        public const string c_champDataChampsSnmp = "SNMPAGTTP_SNMP_FIELDS";
        public const string c_champCacheChampsSnmp = "SNMPAGTTP_CACHE_SNMP_FIELDS";

        public const string c_champDataChampsPolling = "SNMPAGTTP_SNMP_POLL_FLDS";



        public const string c_champDonneesCalculeesPourMediation = "SNMPAGTTP_CALCULATED_FLDS";
        public const string c_champCacheDonneesCalculeesPourMediation = "SNMPAGTTP_CACHE_CALC_FLDS";

        public const string c_champIdTypeParent = "SNMPETTTP_PARENT_ID";
        public const string c_champCodeSystemePartiel = "SNMPETTTP_SYST_CODE";
        public const string c_champCodeSystemeComplet = "SNMPETTTP_FULL_SYST_CODE";
        public const string c_champNiveau = "SNMPETTTP_LEVEL";



		/// /////////////////////////////////////////////
		public CTypeEntiteSnmp( CContexteDonnee contexte)
			:base(contexte)
		{
		}
		
	/// /////////////////////////////////////////////
		public CTypeEntiteSnmp(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T("Snmp entity type : @1|20092",Libelle);
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
            ReadOnly = false;
            base.MyInitValeurDefaut();
            ModeFormulaireInt = (int)EModeFormulairePourTypeEntite.UnFormulaireParEntite;
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champDisplayIndex+","+c_champLibelle};
		}

        //-----------------------------------------------------
        /// <summary>
		/// Libellé du type d'entité SNMP
		/// </summary>
		[TableFieldProperty(c_champLibelle, 255)]
		[DynamicField("Label")]
		public override string Libelle
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

        //----------------------------------------------------
        /// <summary>
        /// Indicateur comme quoi les entités SNMP de ce type<br/>
        /// sont en lecture seule.
        /// </summary>
        [TableFieldProperty(c_champReadOnly)]
        [DynamicField("Read only")]
        public bool ReadOnly
        {
            get
            {
                return (bool)Row[c_champReadOnly];
            }
            set
            {
                Row[c_champReadOnly] = value;
            }
        }

        //----------------------------------------------------------
        /// <summary>
        /// Permet d'indiquer l'ordre dans lequel s'affichent les onglets des entités dans la 
        /// fenêtre de propriétés d'un agent SNMP
        /// </summary>
        [TableFieldProperty(c_champDisplayIndex)]
        [DynamicField("Display Index")]
        public int DisplayIndex
        {
            get
            {
                return (int)Row[c_champDisplayIndex];
            }
            set
            {
                Row[c_champDisplayIndex] = value;
            }
        }

        //----------------------------------------------------------
        /// <summary>
        /// Permet d'indiquer l'ordre dans lequel les entités SNMP sont envoyés à l'agent lors
        /// d'une opération de mise à jour
        /// </summary>
        [TableFieldProperty(c_champUpdateIndex)]
        [DynamicField("Update Index")]
        public int UpdateIndex
        {
            get
            {
                return (int)Row[c_champUpdateIndex];
            }
            set
            {
                Row[c_champUpdateIndex] = value;
            }
        }

        /// /////////////////////////////////////////////
        //-----------------------------------------------------------
        /// <summary>
        /// Code indiquant le mode de fonctionnement du formulaire associé :
        /// <ul>
        /// <li>0 : formulaire à appliquer aux entités SNMP de ce type</li>
        /// <li>1 : formulaire à appliquer à l'agent SNMP, parent des entités SNMP</li>
        /// </ul>
        /// </summary>
        [TableFieldProperty(c_champModeFormulaire)]
        [DynamicField("Form mode code")]
        public int ModeFormulaireInt
        {
            get
            {
                return (int)Row[c_champModeFormulaire];
            }
            set
            {
                Row[c_champModeFormulaire] = value;
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// Mode de fonctionnement du formulaire associé<br/>
        /// (cf. propriété 'Form mode code')
        /// </summary>
        [DynamicField("Form mode")]
        public CModeFormulairePourTypeEntite ModeFormulaire
        {
            get
            {
                return new CModeFormulairePourTypeEntite((EModeFormulairePourTypeEntite)ModeFormulaireInt);
            }
            set
            {
                if (value != null)
                    ModeFormulaireInt = value.CodeInt;
            }
        }

        //-------------------------------------------------------------------
        /// <summary>
        /// Dans le cas d'un mode de fonctionnement avec formulaire sur agent SNMP,<br/>
        /// Donne ou définit ce formulaire.
        /// </summary>
        [Relation(
            CFormulaire.c_nomTable,
            CFormulaire.c_champId,
            CFormulaire.c_champId,
            false,
            false,
            false)]
        [DynamicField("Unique form")]
        public CFormulaire FormulaireUnique
        {
            get
            {
                return (CFormulaire)GetParent(CFormulaire.c_champId, typeof(CFormulaire));
            }
            set
            {
                SetParent(CFormulaire.c_champId, value);
            }
        }

	



        /// /////////////////////////////////////////////
        //-------------------------------------------------------------------
        /// <summary>
        /// Type d'agent SNMP, parent de ce type d'entité SNMP
        /// </summary>
        [Relation(
            CTypeAgentSnmp.c_nomTable,
            CTypeAgentSnmp.c_champId,
            CTypeAgentSnmp.c_champId,
            true,
            true,
            false)]
        [DynamicField("Snmp Agent type")]
        public CTypeAgentSnmp TypeAgentSnmp
        {
            get
            {
                return (CTypeAgentSnmp)GetParent(CTypeAgentSnmp.c_champId, typeof(CTypeAgentSnmp));
            }
            set
            {
                SetParent(CTypeAgentSnmp.c_champId, value);
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// Réservé pour un usage futur
        /// </summary>
        [TableFieldProperty(c_champAllowAddDelete)]
        [DynamicField("Allow Add & delete")]
        public bool AllowAddAndDelete
        {
            get
            {
                return (bool)Row[c_champAllowAddDelete];
            }
            set
            {
                Row[c_champAllowAddDelete] = value;
            }
        }
        
        //-----------------------------------------------------------
        /// <summary>
        /// Donne ou définit la clé GUID associée à la table SNMP TIMOS,<br/>
        /// utilisée en tant que source de données pour ce type d'entité SNMP<br/>
        /// </summary>
        [TableFieldProperty(c_champIdTableSource, 255)]
        [DynamicField("Source query table GUID", CObjetDonnee.c_categorieChampSystème)]
        public string IdTableSource
        {
            get
            {
                return (string)Row[c_champIdTableSource];
            }
            set
            {
                Row[c_champIdTableSource] = value;
            }
        }


        /// <summary>
        /// Mutualise l'affectation des formules
        /// </summary>
        /// <param name="strChampCache"></param>
        /// <param name="data"></param>
        /// <param name="formule"></param>
        private void SetFormule(string strChampCache, ref CDonneeBinaireInRow data, C2iExpression formule)
        {
            Row[strChampCache] = DBNull.Value;
            if (formule == null)
            {
                data.Donnees = null;
            }
            else
            {
                MemoryStream stream = new MemoryStream();
                try
                {
                    BinaryWriter writer = new BinaryWriter(stream);
                    CSerializerSaveBinaire ser = new CSerializerSaveBinaire(writer);
                    CResultAErreur result = ser.TraiteObject<C2iExpression>(ref formule);
                    data.Donnees = stream.GetBuffer();
                    writer.Close();
                }
                catch
                {
                    data.Donnees = null;
                }
                stream.Close();
            }
        }

        /// <summary>
        /// mutualise la récupération des formules
        /// </summary>
        /// <param name="strChampCache"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        private C2iExpression GetFormule(string strChampCache, CDonneeBinaireInRow data)
        {
            C2iExpression formule = null;
            if (Row[strChampCache] != DBNull.Value)
                return (C2iExpression)Row[strChampCache];
            if (data != null && data.Donnees != null)
            {
                Stream stream = new MemoryStream(data.Donnees);
                try
                {
                    BinaryReader reader = new BinaryReader(stream);
                    CSerializerReadBinaire ser = new CSerializerReadBinaire(reader);
                    CResultAErreur result = ser.TraiteObject<C2iExpression>(ref formule);
                    if (!result)
                        formule = null;
                    else
                        CContexteDonnee.ChangeRowSansDetectionModification(Row.Row, strChampCache, formule);
                    reader.Close();
                    stream.Close();
                }
                catch
                {
                }
            }
            return formule;
        }

        /// /////////////////////////////////////////////////////////
        [TableFieldProperty(c_champCacheFormuleLibelle, IsInDb = false, NullAutorise = true)]
        [BlobDecoder]
        public C2iExpression FormuleCalculLibelle
        {
            get
            {
                return GetFormule(c_champCacheFormuleLibelle, DataFormuleLibelle);
            }
            set
            {
                CDonneeBinaireInRow data = DataFormuleLibelle;
                SetFormule(c_champCacheFormuleLibelle, ref data, value);
                DataFormuleLibelle = data;


            }
        }

        /// /////////////////////////////////////////////////////////
        [TableFieldProperty(c_champFormuleLibelle, NullAutorise = true)]
        public CDonneeBinaireInRow DataFormuleLibelle
        {
            get
            {
                if (Row[c_champFormuleLibelle] == DBNull.Value)
                {
                    CDonneeBinaireInRow donnee = new CDonneeBinaireInRow(ContexteDonnee.IdSession, Row, c_champFormuleLibelle);
                    CContexteDonnee.ChangeRowSansDetectionModification(Row, c_champFormuleLibelle, donnee);
                }
                object obj = Row[c_champFormuleLibelle];
                return ((CDonneeBinaireInRow)obj).GetSafeForRow(Row.Row);
            }
            set
            {
                Row[c_champFormuleLibelle] = value;
            }
        }

        /// /////////////////////////////////////////////////////////
        [TableFieldProperty(c_champCacheFormuleIndex, IsInDb = false, NullAutorise = true)]
        [BlobDecoder]
        public C2iExpression FormuleCalculIndex
        {
            get
            {
                return GetFormule(c_champCacheFormuleIndex, DataFormuleIndex);
            }
            set
            {
                CDonneeBinaireInRow data = DataFormuleIndex;
                SetFormule(c_champCacheFormuleIndex, ref data, value);
                DataFormuleIndex = data;


            }
        }

        /// /////////////////////////////////////////////////////////
        [TableFieldProperty(c_champFormuleIndex, NullAutorise = true)]
        public CDonneeBinaireInRow DataFormuleIndex
        {
            get
            {
                if (Row[c_champFormuleIndex] == DBNull.Value)
                {
                    CDonneeBinaireInRow donnee = new CDonneeBinaireInRow(ContexteDonnee.IdSession, Row, c_champFormuleIndex);
                    CContexteDonnee.ChangeRowSansDetectionModification(Row, c_champFormuleIndex, donnee);
                }
                object obj = Row[c_champFormuleIndex];
                return ((CDonneeBinaireInRow)obj).GetSafeForRow(Row.Row);
            }
            set
            {
                Row[c_champFormuleIndex] = value;
            }
        }

        //-----------------------------------------------------------
        public IEnumerable<CChampEntiteFromQueryToChampCustom> ChampsFromQuery
        {
            get
            {
                return ChampsFromQueryList.AsReadOnly();
            }
        }

        //-----------------------------------------------------------
        [TableFieldProperty(c_champCacheChampsSnmp, IsInDb = false, NullAutorise = true)]
        [BlobDecoder]
        public List<CChampEntiteFromQueryToChampCustom> ChampsFromQueryList
        {
            get
            {
                
                if (Row[c_champCacheChampsSnmp] != DBNull.Value)
                    return (List<CChampEntiteFromQueryToChampCustom>)Row[c_champCacheChampsSnmp];
                CDonneeBinaireInRow data = DataChampsFromQuery;
                List<CChampEntiteFromQueryToChampCustom> lstChamps = new List<CChampEntiteFromQueryToChampCustom>();
                if (data != null && data.Donnees != null)
                {
                    Stream stream = new MemoryStream(data.Donnees);
                    try
                    {
                        BinaryReader reader = new BinaryReader(stream);
                        CSerializerReadBinaire ser = new CSerializerReadBinaire(reader);

                        CResultAErreur result = ser.TraiteListe<CChampEntiteFromQueryToChampCustom>(lstChamps);
                        if (!result)
                            lstChamps.Clear();
                        reader.Close();
                        stream.Close();
                    }
                    catch
                    {
                    }
                }
                CContexteDonnee.ChangeRowSansDetectionModification(Row.Row, c_champCacheChampsSnmp, lstChamps);
                return lstChamps;
            }
        }

        //-----------------------------------------------------------
        public CChampEntiteFromQueryToChampCustom GetChamp(string strId)
        {
            return ChampsFromQueryList.FirstOrDefault(c => c.Champ.Id == strId);
        }

        /// /////////////////////////////////////////////////////////
        public void AddChampFromQuery(CChampEntiteFromQueryToChampCustom query)
        {
            ChampsFromQueryList.Add(query);
            CommitChampsFromQuery();
        }

        /// /////////////////////////////////////////////////////////
        public void RemoveChampFromQuery(CChampEntiteFromQueryToChampCustom champ)
        {
            ChampsFromQueryList.Remove(champ);
            CommitChampsFromQuery();
        }

        /// /////////////////////////////////////////////////////////
        public void CommitChampsFromQuery()
        {
            List<CChampEntiteFromQueryToChampCustom> lstChamps = ChampsFromQueryList;

            Row[c_champCacheChampsSnmp] = DBNull.Value;
            CDonneeBinaireInRow data = DataChampsFromQuery;
            if (lstChamps == null)
            {
                data.Donnees = null;
            }
            else
            {
                MemoryStream stream = new MemoryStream();
                try
                {
                    BinaryWriter writer = new BinaryWriter(stream);
                    CSerializerSaveBinaire ser = new CSerializerSaveBinaire(writer);
                    CResultAErreur result = ser.TraiteListe<CChampEntiteFromQueryToChampCustom>(lstChamps);
                    data.Donnees = stream.GetBuffer();
                    writer.Close();
                }
                catch
                {
                    data.Donnees = null;
                }
                stream.Close();
            }
            DataChampsFromQuery = data;
        }


        /// /////////////////////////////////////////////////////////
        [TableFieldProperty(c_champDataChampsSnmp, NullAutorise = true)]
        public CDonneeBinaireInRow DataChampsFromQuery
        {
            get
            {
                if (Row[c_champDataChampsSnmp] == DBNull.Value)
                {
                    CDonneeBinaireInRow donnee = new CDonneeBinaireInRow(ContexteDonnee.IdSession, Row, c_champDataChampsSnmp);
                    CContexteDonnee.ChangeRowSansDetectionModification(Row, c_champDataChampsSnmp, donnee);
                }
                object obj = Row[c_champDataChampsSnmp];
                return ((CDonneeBinaireInRow)obj).GetSafeForRow(Row.Row);
            }
            set
            {
                Row[c_champDataChampsSnmp] = value;
            }
        }



        //-----------------------------------------------------------
        public IEnumerable<CFormuleNommee> ChampsCalculesPourMediation
        {
            get
            {
                return ChampsCalculesPourMediationList.AsReadOnly();
            }
        }

        //-----------------------------------------------------------
        [TableFieldProperty(c_champCacheDonneesCalculeesPourMediation, IsInDb = false, NullAutorise = true)]
        [BlobDecoder]
        public List<CFormuleNommee> ChampsCalculesPourMediationList
        {
            get
            {

                if (Row[c_champCacheDonneesCalculeesPourMediation] != DBNull.Value)
                    return (List<CFormuleNommee>)Row[c_champCacheDonneesCalculeesPourMediation];
                CDonneeBinaireInRow data = DataChampsCalculesPourMediation;
                List<CFormuleNommee> lstChamps = new List<CFormuleNommee>();
                if (data != null && data.Donnees != null)
                {
                    Stream stream = new MemoryStream(data.Donnees);
                    try
                    {
                        BinaryReader reader = new BinaryReader(stream);
                        CSerializerReadBinaire ser = new CSerializerReadBinaire(reader);

                        CResultAErreur result = ser.TraiteListe<CFormuleNommee>(lstChamps);
                        if (!result)
                            lstChamps.Clear();
                        reader.Close();
                        stream.Close();
                    }
                    catch
                    {
                    }
                }
                CContexteDonnee.ChangeRowSansDetectionModification(Row.Row, c_champCacheDonneesCalculeesPourMediation, lstChamps);
                return lstChamps;
            }
        }

        //-----------------------------------------------------------
        public CFormuleNommee GetChampCalculePourMediation(string strId)
        {
            return ChampsCalculesPourMediationList.FirstOrDefault(c => c.Id == strId);
        }

        /// /////////////////////////////////////////////////////////
        public void AddChampCalculePourMediation(CFormuleNommee champ)
        {
            ChampsCalculesPourMediationList.Add(champ);
            CommitChampsCalculesPourMediation();
        }

        /// /////////////////////////////////////////////////////////
        public void RemoveCalculePourMediation(CFormuleNommee champ)
        {
            ChampsCalculesPourMediationList.Remove(champ);
            CommitChampsCalculesPourMediation();
        }

        /// /////////////////////////////////////////////////////////
        public void CommitChampsCalculesPourMediation()
        {
            List<CFormuleNommee> lstChamps = ChampsCalculesPourMediationList;

            Row[c_champCacheDonneesCalculeesPourMediation] = DBNull.Value;
            CDonneeBinaireInRow data = DataChampsCalculesPourMediation;
            if (lstChamps == null)
            {
                data.Donnees = null;
            }
            else
            {
                MemoryStream stream = new MemoryStream();
                try
                {
                    BinaryWriter writer = new BinaryWriter(stream);
                    CSerializerSaveBinaire ser = new CSerializerSaveBinaire(writer);
                    CResultAErreur result = ser.TraiteListe<CFormuleNommee>(lstChamps);
                    data.Donnees = stream.GetBuffer();
                    writer.Close();
                }
                catch
                {
                    data.Donnees = null;
                }
                stream.Close();
            }
            DataChampsFromQuery = data;
        }


        /// /////////////////////////////////////////////////////////
        [TableFieldProperty(c_champDonneesCalculeesPourMediation, NullAutorise = true)]
        public CDonneeBinaireInRow DataChampsCalculesPourMediation
        {
            get
            {
                if (Row[c_champDonneesCalculeesPourMediation] == DBNull.Value)
                {
                    CDonneeBinaireInRow donnee = new CDonneeBinaireInRow(ContexteDonnee.IdSession, Row, c_champDonneesCalculeesPourMediation);
                    CContexteDonnee.ChangeRowSansDetectionModification(Row, c_champDonneesCalculeesPourMediation, donnee);
                }
                object obj = Row[c_champDonneesCalculeesPourMediation];
                return ((CDonneeBinaireInRow)obj).GetSafeForRow(Row.Row);
            }
            set
            {
                Row[c_champDonneesCalculeesPourMediation] = value;
            }
        }


        /// /////////////////////////////////////////////////////////
        [TableFieldProperty(c_champDataChampsPolling, NullAutorise = true)]
        public CDonneeBinaireInRow DataChampsPolling
        {
            get
            {
                if (Row[c_champDataChampsPolling] == DBNull.Value)
                {
                    CDonneeBinaireInRow donnee = new CDonneeBinaireInRow(ContexteDonnee.IdSession, Row, c_champDataChampsPolling);
                    CContexteDonnee.ChangeRowSansDetectionModification(Row, c_champDataChampsPolling, donnee);
                }
                object obj = Row[c_champDataChampsPolling];
                return ((CDonneeBinaireInRow)obj).GetSafeForRow(Row.Row);
            }
            set
            {
                Row[c_champDataChampsPolling] = value;
            }
        }

        /// /////////////////////////////////////////////////////////
        [DynamicField("Polling fields")]
        [BlobDecoder]
        public CListeSnmpPollingFields PollingFields
        {
            get
            {
                CDonneeBinaireInRow data = DataChampsPolling;
                CListeSnmpPollingFields lstChamps = new CListeSnmpPollingFields();
                if (data != null && data.Donnees != null)
                {
                    Stream stream = new MemoryStream(data.Donnees);
                    try
                    {
                        BinaryReader reader = new BinaryReader(stream);
                        CSerializerReadBinaire ser = new CSerializerReadBinaire(reader);

                        CResultAErreur result = ser.TraiteObject<CListeSnmpPollingFields>(ref lstChamps);
                        if (!result)
                            lstChamps.Clear();
                        reader.Close();
                        stream.Close();
                        reader.Dispose();
                        stream.Dispose();
                    }
                    catch
                    {
                    }
                }
                return lstChamps;
            }
            set
            {
                CDonneeBinaireInRow data = DataChampsPolling;
                if (value == null)
                {
                    data.Donnees = null;
                }
                else
                {
                    MemoryStream stream = new MemoryStream();
                    try
                    {
                        BinaryWriter writer = new BinaryWriter(stream);
                        CSerializerSaveBinaire ser = new CSerializerSaveBinaire(writer);
                        CListeSnmpPollingFields lst = value;
                        CResultAErreur result = ser.TraiteObject<CListeSnmpPollingFields>(ref lst);
                        data.Donnees = stream.GetBuffer();
                        writer.Close();
                    }
                    catch
                    {
                        data.Donnees = null;
                    }
                    stream.Close();
                }
                DataChampsPolling = data;
            }
        }


        /// /////////////////////////////////////////////////////////
        public CTypeEntiteSnmpPourSupervision GetTypeEntitePourSupervision(CMemoryDb database, bool bAvecChilds)
        {
            if (database == null)
                database = CMemoryDbPourSupervision.GetMemoryDb(ContexteDonnee);
            CTypeEntiteSnmpPourSupervision typeEntite = new CTypeEntiteSnmpPourSupervision(database);
            if (!typeEntite.ReadIfExist(Id.ToString(), false))
                typeEntite.CreateNew(Id.ToString());
            else
                if (!typeEntite.IsToRead())
                    return typeEntite;
            typeEntite.Row[CMemoryDb.c_champIsToRead] = false;
            typeEntite.Libelle = Libelle;
            typeEntite.IdObjetDeQuerySource = IdTableSource;
            typeEntite.FormuleIndexParDefaut = FormuleCalculIndex;
            CTypeEntiteSnmpPourSupervision typeParent = null;
            if (TypeParent != null)
                typeParent = TypeParent.GetTypeEntitePourSupervision(database, false);
            typeEntite.TypeParent = typeParent;
            typeEntite.TypeAgent = TypeAgentSnmp.GetTypeAgentPourSupervision(database);
            HashSet<int> idsChampsEnvoyes = new HashSet<int>();
            foreach (CChampEntiteFromQueryToChampCustom champ in ChampsFromQuery)
            {
                if (champ.Champ != null)
                {
                    typeEntite.AddChamp(champ.Champ);
                    if (champ.IdChampCustom != null)
                        idsChampsEnvoyes.Add(champ.IdChampCustom.Value);
                }
            }
            //Envoie les champs custom qui n'ont pas étés envoyés
            foreach (CRelationTypeEntiteSnmp_ChampCustom rel in RelationsChampsCustomDefinis)
            {
                if (!idsChampsEnvoyes.Contains(rel.ChampCustom.Id))
                {
                    CChampEntiteSnmpStandard champ = new CChampEntiteSnmpStandard();
                    champ.Id = rel.ChampCustom.Id.ToString();
                    champ.NomChamp = rel.ChampCustom.Nom;
                    champ.Description = rel.ChampCustom.Description;
                    switch (rel.ChampCustom.TypeDonneeChamp.TypeDonnee)
                    {
                        case TypeDonnee.tBool:
                            champ.TypeChamp = ETypeChampBasique.Bool;
                            break;
                        case TypeDonnee.tDate:
                            champ.TypeChamp = ETypeChampBasique.Date;
                            break;
                        case TypeDonnee.tDouble:
                            champ.TypeChamp = ETypeChampBasique.Decimal;
                            break;
                        case TypeDonnee.tEntier:
                            champ.TypeChamp = ETypeChampBasique.Int;
                            break;
                        case TypeDonnee.tObjetDonneeAIdNumeriqueAuto:
                            champ.TypeChamp = ETypeChampBasique.Int;
                            champ.NomChamp += "_id";
                            break;
                        case TypeDonnee.tString:
                            champ.TypeChamp = ETypeChampBasique.String;
                            break;
                        default:
                            break;
                    }
                    typeEntite.AddChamp(champ);
                    idsChampsEnvoyes.Add(rel.ChampCustom.Id);
                }
            }

            foreach (CFormuleNommee champCalcule in ChampsCalculesPourMediation)
            {
                if (champCalcule.Formule != null)
                {
                    CTypeResultatExpression typeResulat = champCalcule.Formule.TypeDonnee;
                    if (typeResulat.IsArrayOfTypeNatif)
                        continue;

                    CChampEntiteSnmpStandard champ = new CChampEntiteSnmpStandard();
                    champ.Id = champCalcule.Id;
                    champ.NomChamp = champCalcule.Libelle;
                    champ.Description = "";
                    champ.TypeChamp = CTypeChampBasique.GetTypeChamp ( typeResulat.TypeDotNetNatif );;
                    if (typeof(CObjetDonneeAIdNumerique).IsAssignableFrom(typeResulat.TypeDotNetNatif))
                    {
                        champ.TypeChamp = ETypeChampBasique.Int;
                        champ.NomChamp += "_Id";
                    }
                    typeEntite.AddChamp(champ);
                }
            }


            if (bAvecChilds)
            {
                foreach (CTypeEntiteSnmp typeChild in TypesFils)
                {
                    CTypeEntiteSnmpPourSupervision typeFils = typeChild.GetTypeEntitePourSupervision(database, false);
                    typeFils.TypeParent = typeEntite;
                }
            }
            return typeEntite;
        }

        /// /////////////////////////////////////////////////////////
        public void FillFromTable(CODEQBase objetDeRequete)
        {
            CEasyQuery query = objetDeRequete.Query;
            if (query == null)
                return;
            IdTableSource = objetDeRequete.Id;
            HashSet<string> champsASupprimer = new HashSet<string>();
            List<CChampEntiteFromQueryToChampCustom> lstChamps = ChampsFromQueryList;
            foreach (CChampEntiteFromQueryToChampCustom champ in lstChamps)
            {
                champsASupprimer.Add ( champ.Champ.Id );
            }
            foreach (IColumnDeEasyQuery col in objetDeRequete.Columns)
            {
                CChampEntiteFromQueryToChampCustom champ = lstChamps.FirstOrDefault(c =>
                    c.Champ.ColonneSource.Id == col.Id );
                if ( champ == null )
                    champ = lstChamps.FirstOrDefault(c=>c.Champ.ColonneSource.ColumnName == col.ColumnName);
                if (champ == null)
                {
                    champ = new CChampEntiteFromQueryToChampCustom();
                    CChampEntiteFromQuery chpFromQuery = new CChampEntiteFromQuery();
                    champ.Champ = chpFromQuery;
                    lstChamps.Add(champ);
                }
                champ.Champ.InitFromColonneSource(col, objetDeRequete);
                champsASupprimer.Remove(champ.Champ.Id);
            }
            foreach (CChampEntiteFromQueryToChampCustom champ in new ArrayList(lstChamps))
            {
                if (champsASupprimer.Contains(champ.Champ.Id))
                    lstChamps.Remove(champ);
            }
            CommitChampsFromQuery();
        }

        /// /////////////////////////////////////////////////////////
        /// Retourne la requête utilisée pour populer les entités de ce type
        public CResultAErreurType<CEasyQuery> FindSourceQuery()
        {
            CResultAErreurType<CEasyQuery> result = new CResultAErreurType<CEasyQuery>();
            if (TypeAgentSnmp == null)
            {
                result.EmpileErreur(I.T("Entity type as no agent type|20100"));
                return result;
            }
            CEasyQuery query = TypeAgentSnmp.Queries.FirstOrDefault(q => q.GetObjet(IdTableSource) != null);
            if (query == null)
            {
                result.EmpileErreur(I.T("Can not find source query|20101"));
                return result;
            }
            result.DataType = query;
            return result;
        }


        /// /////////////////////////////////////////////////////////
        /// Retourne l'objet de EasyQuery servant à populer les entités de ce type
        public CResultAErreurType<IObjetDeEasyQuery> FindSourceObjetInQuery(CEasyQuery query)
        {
            CResultAErreurType<IObjetDeEasyQuery> result = new CResultAErreurType<IObjetDeEasyQuery>();
            if (query == null)
            {
                result.EmpileErreur(I.T("Can not find source query|20101"));
                return result;
            }
            IObjetDeEasyQuery objet = query.GetObjet(IdTableSource);
            if (objet == null)
            {
                result.EmpileErreur(I.T("Can not find source object in query|20102"));
                return result;
            } result.DataType = objet;
            return result;
        }

        /// /////////////////////////////////////////////////////////
        /// Retourne l'objet de EasyQuery servant à populer les entités de ce type
        public CResultAErreurType<IObjetDeEasyQuery> FindSourceObjetInQuery()
        {
            CResultAErreurType<IObjetDeEasyQuery> result = new CResultAErreurType<IObjetDeEasyQuery>();
            CResultAErreurType<CEasyQuery> resultQuery = FindSourceQuery();
            if (!resultQuery)
            {
                result.EmpileErreur(resultQuery.Erreur);
                return result;
            }
            return FindSourceObjetInQuery(resultQuery.DataType);
        }



        #region CObjetHierarchique

        //-----------------------------------------------------------
        /// <summary>
        /// Indique le code système complet de l'entité SNMP.<br/>
        /// Ce code système complet est la concaténation du code système partiel de l'entité<br/>
        /// avec le code système complet de son entité parente.<br/>
        /// Exemple : pour un code système complet tel que : 0012000A0034 :<br/>
        /// 0034 est le code partiel de l'entité courante<br/>
        /// 000A est le code partiel de l'entité parente<br/>
        /// 0012 est le code partiel de l'entité grand parente
        /// </summary>
        [TableFieldProperty(c_champCodeSystemeComplet, 400)]
        [DynamicField("Full system code")]
        public override string CodeSystemeComplet
        {
            get
            {
                return (string)Row[c_champCodeSystemeComplet];
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// Indique le code système de l'entité SNMP dans sa hiérarchie. Ce code est unique dans son parent.
        /// Ce code est exprimé sur 4 caractères alphanumériques.
        /// </summary>
        [TableFieldProperty(c_champCodeSystemePartiel, 4)]
        [DynamicField("Partial system code")]
        public override string CodeSystemePartiel
        {
            get
            {
                string strVal = "";
                if (Row[c_champCodeSystemePartiel] != DBNull.Value)
                    strVal = (string)Row[c_champCodeSystemePartiel];
                strVal = strVal.Trim().PadLeft(4, '0');
                return strVal;
            }
        }

        //----------------------------------------------------
        public override string ChampCodeSystemeComplet
        {
            get { return c_champCodeSystemeComplet; }
        }

        //----------------------------------------------------
        public override string ChampCodeSystemePartiel
        {
            get { return c_champCodeSystemePartiel; }
        }

        //----------------------------------------------------
        public override string ChampIdParent
        {
            get
            {
                return c_champIdTypeParent;
            }
        }

        //----------------------------------------------------
        public override string ChampLibelle
        {
            get { return c_champLibelle; }
        }


        //----------------------------------------------------
        public override string ChampNiveau
        {
            get { return c_champNiveau; }
        }


        //----------------------------------------------------
        public override int NbCarsParNiveau
        {
            get { return 2; }
        }

        //----------------------------------------------------
        /// Indique le niveau hiérarchique( nombre de parents ) de l'entité SNMP.
        /// Le niveau d'une entité SNMP sans parent est 0.
        /// Exemple, supposons la hiérarchie d'entités suivante : Châssis BTS -> Module alimentation -> Carte 12V :
        /// 'Châssis BTS' a pour niveau 0,
        /// 'Module alimentation' a pour niveau 1 (1 parent en remontant la hiérarchie)
        /// 'Carte 12V' a pour niveau 2 (2 parents en remontant la hiérachie)
        [TableFieldProperty(c_champNiveau)]
        [DynamicField("Level")]
        public override int Niveau
        {
            get
            {
                return (int)Row[c_champNiveau];
            }
        }

       
        //-------------------------------------------------------------------
        /// <summary>
        /// Type de l'entité SNMP parente dans la hiérarchie
        /// </summary>
        [Relation(
            CTypeEntiteSnmp.c_nomTable,
            CTypeEntiteSnmp.c_champId,
            CTypeEntiteSnmp.c_champIdTypeParent,
            false,
            true,
            false)]
        [DynamicField("Parent type")]
        public CTypeEntiteSnmp TypeParent
        {
            get
            {
                return (CTypeEntiteSnmp)ObjetParent;
            }
            set
            {
                ObjetParent = value;
            }
        }

        //---------------------------------------------
        /// <summary>
        /// Donne la liste des entités SNMP filles
        /// </summary>
        [RelationFille(typeof(CTypeEntiteSnmp), "TypeParent")]
        [DynamicChilds("Childs types", typeof(CTypeEntiteSnmp))]
        public CListeObjetsDonnees TypesFils
        {
            get
            {
                return ObjetsFils;
            }
        }

#endregion


        #region IDefinisseurChampCustomRelationObjetDonnee Membres

        //--------------------------------------------------------------------
        [RelationFille(typeof(CRelationTypeEntiteSnmp_ChampCustom), "Definisseur")]
        public CListeObjetsDonnees RelationsChampsCustomListe
        {
            get { return GetDependancesListe(CRelationTypeEntiteSnmp_ChampCustom.c_nomTable, c_champId); }
        }

        //--------------------------------------------------------------------
        [RelationFille(typeof(CRelationTypeEntiteSnmp_Formulaire), "Definisseur")]
        public CListeObjetsDonnees RelationsFormulairesListe
        {
            get { return GetDependancesListe(CRelationTypeEntiteSnmp_Formulaire.c_nomTable, c_champId); }
        }

        #endregion

        #region IDefinisseurChampCustom Membres

        /// /////////////////////////////////////////////
        public IRelationDefinisseurChamp_ChampCustom[] RelationsChampsCustomDefinis
        {
            get
            {
                return (IRelationDefinisseurChamp_ChampCustom[])RelationsChampsCustomListe.ToArray(typeof(IRelationDefinisseurChamp_ChampCustom));
            }
        }

        /// /////////////////////////////////////////////
        public IRelationDefinisseurChamp_Formulaire[] RelationsFormulaires
        {
            get
            {
                return (IRelationDefinisseurChamp_Formulaire[])RelationsFormulairesListe.ToArray(typeof(IRelationDefinisseurChamp_Formulaire));
            }
        }

        /// /////////////////////////////////////////////
        public CRoleChampCustom RoleChampCustomDesElementsAChamp
        {
            get
            {
                return CRoleChampCustom.GetRole(CEntiteSnmp.c_roleChampCustom);
            }
        }

        /// /////////////////////////////////////////////
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
            if (ModeFormulaire.Code == EModeFormulairePourTypeEntite.UnFormulaireParEntite)
            {
                foreach (IRelationDefinisseurChamp_Formulaire relation in RelationsFormulaires)
                {
                    foreach (CRelationFormulaireChampCustom relFor in relation.Formulaire.RelationsChamps)
                        tableChamps[relFor.Champ.Id] = relFor.Champ;
                }
            }
            else if (FormulaireUnique != null)
                    foreach (CRelationFormulaireChampCustom rel in FormulaireUnique.RelationsChamps)
                        tableChamps[rel.Champ.Id] = rel.Champ;
        }

        #endregion

        //------------------------------------------------------
        /// <summary>
        /// Mise à jour de tous les agents
        /// </summary>
        public int[] IdsProxysConcernesParDonneesMediation
        {
            get { return null; }
        }

        //------------------------------------------
        public int[] IdsProxysConcernesParConfigurationProxy
        {
            get
            {
                return new int[0];
            }
        }


        
		//-----------------------------------------------------------
		/// <summary>
		/// Donne ou définit le type de l'élément correspondant au type d'entité :
        /// <ul>
        /// <li><see cref="CSite">Site</see> ou</li>
        /// <li><see cref="CEquipement">Equipement</see> ou</li>
        /// <li><see cref="CLienReseau">Lien réseau</see> ou</li>
        /// <li>Indifférent</li>
        /// </ul>
		/// </summary>
		[TableFieldProperty ( c_champTypeElementsSupervise, 128 )]
		[DynamicField("Supervised Elements Type")]
		public string TypeElementsSuperviseString
		{
			get
			{
                return (string)Row[c_champTypeElementsSupervise];
			}
			set
			{
                Row[c_champTypeElementsSupervise] = value;
			}
		}


        public Type TypeElementsSupervise
        {
            get
            {
                return CActivatorSurChaine.GetType(TypeElementsSuperviseString, true);
            }
            set
            {
                if (value != null)
                    TypeElementsSuperviseString = value.ToString();
                else
                    TypeElementsSuperviseString = string.Empty;
            }
        }

        [TableFieldProperty(c_champFiltreElementsSupervise, NullAutorise = true)]
        public CDonneeBinaireInRow DataFiltreElementsSupervise
        {
            get
            {
                if (Row[c_champFiltreElementsSupervise] == DBNull.Value)
                {
                    CDonneeBinaireInRow donnee = new CDonneeBinaireInRow(ContexteDonnee.IdSession, Row, c_champFiltreElementsSupervise);
                    CContexteDonnee.ChangeRowSansDetectionModification(Row, c_champFiltreElementsSupervise, donnee);
                }
                object obj = Row[c_champFiltreElementsSupervise];
                return ((CDonneeBinaireInRow)obj).GetSafeForRow(Row.Row);
            }
            set
            {
                Row[c_champFiltreElementsSupervise] = value;
            }
        }

        /// /////////////////////////////////////////////////////////
        [BlobDecoder]
        public CFiltreDynamique FiltreElementsSupervise
        {
            get
            {
                CDonneeBinaireInRow data = DataFiltreElementsSupervise;
                CFiltreDynamique filtre = null;
                if (data != null && data.Donnees != null)
                {
                    MemoryStream stream = new MemoryStream(data.Donnees);
                    BinaryReader reader = new BinaryReader(stream);
                    CSerializerReadBinaire serializer = new CSerializerReadBinaire(reader);
                    serializer.AttacheObjet(typeof(CContexteDonnee), ContexteDonnee);
                    CResultAErreur result = serializer.TraiteObject<CFiltreDynamique>(ref filtre, new object[] { });
                    if (!result)
                        filtre = null;
                }
                return filtre;
            }
            set
            {
                if (value == null)
                {
                    CDonneeBinaireInRow data = DataFiltreElementsSupervise;
                    data.Donnees = null;
                    DataFiltreElementsSupervise = null;
                }
                else
                {
                    MemoryStream stream = new MemoryStream();
                    BinaryWriter writer = new BinaryWriter(stream);
                    CSerializerSaveBinaire serializer = new CSerializerSaveBinaire(writer);
                    CResultAErreur result = serializer.TraiteObject<CFiltreDynamique>(ref value, new object[] { });
                    if (result)
                    {
                        CDonneeBinaireInRow data = DataFiltreElementsSupervise;
                        data.Donnees = stream.GetBuffer();
                        DataFiltreElementsSupervise = data;
                    }
                    writer.Close();
                    stream.Close();
                }
            }
        }

        /// <summary>
        /// Renvoie la liste des formulaires associés au type de l'entité SNMP
        /// </summary>
        [DynamicChilds("Forms", typeof(CFormulaire))]
        public List<CFormulaire> Formulaires
        {
            get
            {
                List<CFormulaire> lstForms = new List<CFormulaire>();
                foreach (CRelationTypeEntiteSnmp_Formulaire formulaire in RelationsFormulaires)
                    lstForms.Add(formulaire.Formulaire);
                return lstForms;
            }
        }






        #region IDefinisseurSymbole Membres

        /// <summary>
        /// Le symbole de bibliothèque associé au type d'entité<br/>
        /// afin de représenter les entités SNMP de ce type<br/>
        /// dans les vues graphiques de supervision.
        /// </summary>
        [Relation(
            CSymboleDeBibliotheque.c_nomTable,
            CSymboleDeBibliotheque.c_champId,
            CSymboleDeBibliotheque.c_champId,
            false,
            false,
            false)]
        [DynamicField("Library symbol")]
        public CSymboleDeBibliotheque SymboleDeBibliotheque
        {
            get
            {
                return (CSymboleDeBibliotheque)GetParent(CSymboleDeBibliotheque.c_champId, typeof(CSymboleDeBibliotheque));
            }
            set
            {
                if (SymbolePropre != null)
                {
                    //SymbolePropre.Delete();
                    SymbolePropre = null;
                }
                SetParent(CSymboleDeBibliotheque.c_champId, value);

            }

        }

        /// <summary>
        /// Donne ou définit le symbole graphique propre au type d'entité SNMP
        /// </summary>
        [RelationFille(typeof(CSymbole), "TypeEntiteSnmp")]
        [DynamicField("Proper symbol")]
        public CSymbole SymbolePropre
        {

            get
            {
                CListeObjetsDonneesContenus liste = GetDependancesListe(CSymbole.c_nomTable, CTypeEntiteSnmp.c_champId);
                if (liste.Count > 0)
                    return (CSymbole)liste[0];
                else
                    return null;
            }

            set
            {


                Row[CSymboleDeBibliotheque.c_champId] = null;
                if (value == null)
                {
                    if (SymbolePropre != null)
                        SymbolePropre.Delete();
                }
                else
                {
                    value.TypeEntiteSnmp = this;
                }

            }

        }


        /// <summary>
        /// Renvoie le symbole graphique associé au type d'entité SNMP
        /// </summary>
        [DynamicField("Symbol")]
        public CSymbole Symbole
        {
            get
            {


                if (SymbolePropre == null)
                    if (SymboleDeBibliotheque != null)
                        return SymboleDeBibliotheque.Symbole;
                    else
                        return null;
                else
                    return SymbolePropre;

            }
        }

        //--------------------------------------
        public Type GetTypePourLequelOnSelectionneUnSymbole()
        {
            return typeof(CEntiteSnmp);
        }

        //--------------------------------------
        public C2iSymbole SymboleDefiniADessiner
        {
            get
            {
                C2iSymbole symbole = null;
                if (Symbole != null)
                    symbole = Symbole.Symbole;
                if (symbole == null)
                    symbole = CSymbole.GetSymboleParDefaut(typeof(CEntiteSnmp), ContexteDonnee);
                return symbole;
            }
        }

        #endregion
    }
}
