using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;
using System.Data;

using sc2i.common;
using sc2i.multitiers.client;
using sc2i.data.serveur;
using sc2i.data;

using Microsoft.Win32;

using Lys.Licence;
using Lys.Licence.Types;
using timos.client.licence;
using System.Reflection;
using timos.client.Licence;
using sc2i.data.dynamic;

namespace timos.serveur
{

    ///////////////////////////////////////////////////////////////////////////////
    public class CLicenceCheckElementNb : I2iSerializable
    {
        /// <summary>
        /// La méthode GetNbRestantsFromBase est sans paramètres et retourne le nombre
        /// d'éléments utilisés dans la base.
        /// Tout élément qui a l'attribute LicenceCount doit implémenter cette méthode statique si la méthode
        /// de comptage n'est pas classique (nombre d'éléments de la table, or éléments de version (SC2I_VERSION non null)
        /// </summary>
        public static string c_MethodeCompteElementsInBase = "GetNbUsedInDbForLicenceCount";
        public static string c_MethodeCompteElementsInDataTable = "GetNbComptabilisesDansLaLicence";

        private static Dictionary<string, List<Type>> m_dicIdTypeToListeTypesLicenceCount = new Dictionary<string, List<Type>>();
        
        private CLicenceLogicielPrtct m_LicenceLogiciel;
        private List<CNombreUtilisePourTypeLicence> m_listRecords;                //contenu de m_stSaveFileFullName
        Dictionary<int, CLicenceCheckElementNbPourSession> m_DictionarySessions;//int - sessionId
        private static CLicenceCheckElementNb m_instance = null;
        private Dictionary<string, int> m_CreationsEnCours;             //modifications pas encore commitées

        //Nom de table->bool si limité
        private Dictionary<string, bool> m_dicTablesLimitees = new Dictionary<string, bool>();

        //True si la licence possède des types limités
        private bool m_bHasTypesLimites = false;
               
        public bool AccepteTransactionsImbriquees { get { return true; } }


        private static Dictionary<string, string> m_dicNomTableToIdTypeLimite = new Dictionary<string, string>();

        public CLicenceCheckElementNb()//pour serialisation
        {
            m_LicenceLogiciel = null;
            m_listRecords = new List<CNombreUtilisePourTypeLicence>();
            m_DictionarySessions = new Dictionary<int, CLicenceCheckElementNbPourSession>();
            m_CreationsEnCours = new Dictionary<string, int>();
        }

        //----------------------------------------------------------------
        public static string GetIdTypeLimiteFromNomTable(string strTable)
        {
            string strIdType = null;
            if (!m_dicNomTableToIdTypeLimite.TryGetValue(strTable, out strIdType))
            {
                Type tp = CContexteDonnee.GetTypeForTable(strTable);
                if (tp != null)
                {
                    object[] attribs = tp.GetCustomAttributes(typeof(LicenceCountAttribute), true);
                    if (attribs.Length > 0)
                        strIdType = ((LicenceCountAttribute)attribs[0]).CountTypeName;
                    m_dicNomTableToIdTypeLimite[strTable] = strIdType;
                }
            }
            return strIdType;
        }


        //----------------------------------------------------------------
        private bool IsLimite ( string strTable )
        {
            bool bResult = false;
            string strIdType = GetIdTypeLimiteFromNomTable(strTable);
            if (strIdType != null)
            {
                if (!m_dicTablesLimitees.TryGetValue(strIdType, out bResult))
                {
                    bResult = m_LicenceLogiciel.GetTypeProtege(strIdType) != null;
                    m_dicTablesLimitees[strTable] = bResult;
                }
            }
            return bResult;
        }

        //----------------------------------------------------------------
        public CLicenceCheckElementNb(CLicenceLogicielPrtct licenceLogiciel)
        {
            Init(licenceLogiciel);
        }

        //----------------------------------------------------------------
        public IEnumerable<CNombreUtilisePourTypeLicence> GetNombreRestantParType()
        {
            return m_listRecords.AsReadOnly();
        }


        //----------------------------------------------------------------
        public static void RegisterTypeLicenceCount ( Type tp )
        {
            
            
        }

        //----------------------------------------------------------------
        private static int GetNbUsedInDbForType ( Type tp )
        {
            MethodInfo info = tp.GetMethod ( c_MethodeCompteElementsInBase );
            if ( info != null )
                return (int)info.Invoke ( null, new object[0] );
            C2iRequeteAvancee requete = new C2iRequeteAvancee();
            CStructureTable structure = CStructureTable.GetStructure ( tp );
            requete.TableInterrogee = structure.NomTable;
            C2iChampDeRequete champ = new C2iChampDeRequete ( structure.ChampsId[0].NomChamp, 
                new CSourceDeChampDeRequete ( structure.ChampsId[0].NomChamp ),
                typeof(int),
                OperationsAgregation.Number,
                false);
            requete.ListeChamps.Add(champ);
            requete.FiltreAAppliquer = new CFiltreData ( CSc2iDataConst.c_champIdVersion+" is null" );
            requete.FiltreAAppliquer.IgnorerVersionDeContexte = true;
            requete.FiltreAAppliquer.IntegrerLesElementsSupprimes = false;
            CResultAErreur  result = requete.ExecuteRequete(0);
            if (!result)
                return 0;
            DataTable table = result.Data as DataTable;
            return (int)table.Rows[0][0];
        }

        //----------------------------------------------------------------
        private static int GetNbComptabilisesDansLaLicence(DataTable table)
        {
            int nNbNew = 0;
            //Lignes nouvelles
            DataTable tableNewRows = table.GetChanges(DataRowState.Added);
            if (tableNewRows != null && tableNewRows.Rows.Count > 0)
            {
                nNbNew = tableNewRows.Rows.Count;
                if (tableNewRows.Columns.Contains(CSc2iDataConst.c_champIdVersion))
                {
                    DataRow[] rows = tableNewRows.Select(CSc2iDataConst.c_champIdVersion + " is null");
                    nNbNew = rows.Length;
                }
            }
            //Lignes inclues dans le référentiel.
            //règle avec les versions : tout ce qui est dans une version prévisionnelle
            //n'est pas une nouvelle ligne. Quand un élément passe d'une version prévisionnelle
            //au référentiel, il est compté comme nouveau.
            if (table.Columns.Contains(CSc2iDataConst.c_champIdVersion))
            {
                DataRow[] rows = table.Select(CSc2iDataConst.c_champIdVersion + " is not null", "", DataViewRowState.ModifiedOriginal);
                foreach (DataRow row in rows)
                {
                    if (row.RowState == DataRowState.Modified && row[CSc2iDataConst.c_champIdVersion] == DBNull.Value)
                        nNbNew++;
                }
            }
            return nNbNew;
        }

        //----------------------------------------------------------------
        public class CLockerNbUsed
        {
        }

        //----------------------------------------------------------------
        public void RefreshNombreUtilises()
        {
            lock (typeof(CLockerNbUsed))
            {
                m_listRecords = new List<CNombreUtilisePourTypeLicence>();
                Dictionary<string, int?> dicUsed = new Dictionary<string, int?>();

                foreach (Type tp in CContexteDonnee.GetAllTypes())
                {
                    if (m_LicenceLogiciel is CLicenceDemo)
                    {
                        if (!typeof(CRelationElementAChamp_ChampCustom).IsAssignableFrom(tp))
                        {
                            string strNomType = DynamicClassAttribute.GetNomConvivial(tp);
                            dicUsed[strNomType] = GetNbUsedInDbForType(tp);
                            Attribute attr = tp.GetCustomAttribute(typeof(TableAttribute), true);
                            if (attr != null)
                            {
                                string strNomTable = ((TableAttribute)attr).NomTable;
                                m_dicNomTableToIdTypeLimite[strNomTable] = strNomType;
                                m_dicTablesLimitees[strNomTable] = true;
                            }
                        }
                    }
                    else
                    {

                        object[] attribs = tp.GetCustomAttributes(typeof(LicenceCountAttribute), true);
                        if (attribs != null && attribs.Length > 0)
                        {
                            LicenceCountAttribute counter = attribs[0] as LicenceCountAttribute;
                            int? nNb = null;
                            if (!dicUsed.TryGetValue(counter.CountTypeName, out nNb))
                                nNb = 0;
                            nNb += GetNbUsedInDbForType(tp);
                            dicUsed[counter.CountTypeName] = nNb;
                        }
                    }
                }
                foreach (KeyValuePair<string, int?> kv in dicUsed)
                {
                    CNombreUtilisePourTypeLicence nb = new CNombreUtilisePourTypeLicence(kv.Key, kv.Value.Value);
                    m_listRecords.Add(nb);
                }
            }
        }

        //----------------------------------------------------------------
        private static bool m_bRegistrerTraitementAvecSauvegardeFait = false;
        public void Init(CLicenceLogicielPrtct licenceLogiciel)
        {
            m_LicenceLogiciel = licenceLogiciel;
            m_listRecords = new List<CNombreUtilisePourTypeLicence>();
            m_DictionarySessions = new Dictionary<int, CLicenceCheckElementNbPourSession>();
            m_CreationsEnCours = new Dictionary<string, int>();

            RefreshNombreUtilises();

            /*Dictionary<string,int?> dicUsed = new Dictionary<string,int?>();



            foreach (Type tp in CContexteDonnee.GetAllTypes())
            {

                object[] attribs = tp.GetCustomAttributes(typeof(LicenceCountAttribute), true);
                if (attribs != null && attribs.Length > 0)
                {
                    LicenceCountAttribute counter = attribs[0] as LicenceCountAttribute;
                    int? nNb = null;
                    if (!dicUsed.TryGetValue(counter.CountTypeName, out nNb))
                        nNb = 0;
                    nNb += GetNbUsedInDbForType(tp);
                    dicUsed[counter.CountTypeName] = nNb;
                }
            }
            foreach (KeyValuePair<string, int?> kv in dicUsed)
            {
                CNombreUtilisePourTypeLicence nb = new CNombreUtilisePourTypeLicence(kv.Key, kv.Value.Value);
                m_listRecords.Add(nb);
            }*/

            if (!m_bRegistrerTraitementAvecSauvegardeFait)
            {
                if (m_LicenceLogiciel.Types.Count != 0 || m_LicenceLogiciel is CLicenceDemo)
                {
                    m_bRegistrerTraitementAvecSauvegardeFait = true;
                    CContexteDonneeServeur.AddTraitementAvantSauvegarde ( new TraitementSauvegardeExterne(TraitementAvantSauvegarde));
                    m_bHasTypesLimites = true;
                }
            }


        }

        //----------------------------------------------------------------
        public CLicenceLogicielPrtct LicenceLogiciel
        {
            get { return m_LicenceLogiciel; }
            set { m_LicenceLogiciel = value; }
        }

        //-----------------------------------------------------------------------
        public CLicenceCheckElementNbPourSession GetLicenceCheckElementNbPourSession(int nIdSession)
        {
            CLicenceCheckElementNbPourSession licenceCheckElementNbPourSession;
            if(m_DictionarySessions.TryGetValue(nIdSession, out licenceCheckElementNbPourSession))
                return licenceCheckElementNbPourSession;
            else
            {
                licenceCheckElementNbPourSession = new CLicenceCheckElementNbPourSession(this, nIdSession);
                m_DictionarySessions.Add(nIdSession, licenceCheckElementNbPourSession);
                return licenceCheckElementNbPourSession;
            }            
        }

        //-----------------------------------------------------------------------
        /// <summary>
        /// Appellé par le CLicenceCheckNbelementsPourSession llors
        /// du détachement de la session
        /// </summary>
        /// <param name="nIdsession"></param>
        internal static void OnCloseSession(int nIdsession)
        {
            if (GetInstance().m_DictionarySessions.ContainsKey(nIdsession))
                GetInstance().m_DictionarySessions.Remove(nIdsession);
        }

        //-----------------------------------------------------------------------
        public CResultAErreur CanCreate(string strType, int nNbDemande)
        {
            CResultAErreur result = CResultAErreur.True;
            
            CLicenceTypePrtct type = m_LicenceLogiciel.GetTypeProtege(strType);

            int nNbUsed = 0;

            if (type != null)
            {
                foreach (CNombreUtilisePourTypeLicence record in m_listRecords)
                {
                    if (record.IdType.ToUpper() == strType.ToUpper() )
                    {
                        nNbUsed += record.NombreUtilise;
                    }
                }


				int nEnCours = 0;
                m_CreationsEnCours.TryGetValue(strType, out nEnCours);

                if (nNbUsed + nNbDemande + nEnCours > type.Nombre)
                {
                    int nbPossibleToCreate = type.Nombre - nNbUsed - nEnCours;
                    result.EmpileErreur(I.T("Impossible to create @1 elements. Your licence allows you to create @2 ones |9",
                        nNbDemande.ToString(), nbPossibleToCreate.ToString()));
                    
                    return result;
                }
            }

            return result;
        }

        
        private CNombreUtilisePourTypeLicence FindExistingRecord(string strNom)
        {
            foreach (CNombreUtilisePourTypeLicence record in m_listRecords)
            {
                if (record.IdType.ToUpper() == strNom.ToUpper() )
                    return record;
            }

            return null;
        }

        
        //-----------------------------------------------------------------------------------------
        //write m_listRecords into the file m_stSaveFileFullName
        public CResultAErreur Save(Dictionary<string, int> dictionary)
        {
            CResultAErreur result = CResultAErreur.True;
            if (!m_bHasTypesLimites)
                return result;
            DateTime dateNow = DateTime.Now;

            foreach (KeyValuePair<string, int> kvp in dictionary)
            {
                CLicenceTypePrtct type = m_LicenceLogiciel.GetTypeProtege(kvp.Key);

                if (type != null)//on sauvegarde que des types limités par la licence
                {
                    CNombreUtilisePourTypeLicence record = FindExistingRecord(type.Nom);
                    if (record == null)
                    {
                        CNombreUtilisePourTypeLicence addRecord = new CNombreUtilisePourTypeLicence(kvp.Key, kvp.Value);
                        m_listRecords.Add(addRecord);
                    }
                    else
                    {
                        int indx = m_listRecords.IndexOf(record);
                        m_listRecords.RemoveAt(indx);
                        record.NombreUtilise += kvp.Value;
                        m_listRecords.Add(record);
                    }
                    FreeElements(kvp.Key, kvp.Value);//les modif. sont commitées, on les efface de m_CreationsEnCours
                }
            }

            
                return result;
        }
        /*
		class CLockerFichier { }
        private CResultAErreur WriteSaveFile()
        {
            CResultAErreur result = CResultAErreur.True;

			lock (typeof(CLockerFichier))
			{

				///Sérialize l'objet en mémoire
				MemoryStream stream = new MemoryStream();
				BinaryWriter writer = new BinaryWriter(stream);
				CSerializerSaveBinaire serializer = new CSerializerSaveBinaire(writer);
				I2iSerializable iTmp = this;
				result = serializer.SerializeObjet(ref iTmp);
				if (!result)
					return result;
				writer.Close();

				//Ecrit le fichier crypté
				byte[] buffer = stream.GetBuffer();

				try
				{
					byte[] encrypted = Cryptage.Encrypt(buffer, defPassword);
					FileStream fileStream = new FileStream(m_stSaveFileFullName, FileMode.Truncate);
					writer = new BinaryWriter(fileStream);
					writer.Write(encrypted, 0, encrypted.Length);
					writer.Close();

					WriteCRC(m_stSaveFileFullName);
                    fileStream.Close();
				}
				catch (Exception e)
				{
					result.EmpileErreur(new CErreurException(e));
				}
                stream.Close();
			}

            return result;        
        }*/

        //---------------------------------------------------------------------------------------
        public CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;

            ArrayList lst = new ArrayList(m_listRecords);
            result = serializer.TraiteArrayListOf2iSerializable(lst);
            if (!result)
                return result;
            if (serializer.Mode == ModeSerialisation.Lecture)
            {
                m_listRecords.Clear();
                foreach (CNombreUtilisePourTypeLicence record in lst)
                    m_listRecords.Add(record);
            }

            return result; 
        }

        private int GetNumVersion()
        {
            return 0;
        }

        //----------------------------------------------------------------------------
		public static CResultAErreur TraitementAvantSauvegarde(CContexteDonnee contexte, Hashtable tableData)
        {
            CResultAErreur result = CResultAErreur.True;

            ArrayList lstTables = new ArrayList(contexte.Tables);
            foreach (DataTable table in lstTables)
            {
                if (GetInstance().IsLimite(table.TableName))
                {
                    int nNbNew = GetNbComptabilisesDansLaLicence(table);
                    if (nNbNew > 0)
                    {
                        string strTypeLimite = GetIdTypeLimiteFromNomTable(table.TableName);
                        if (strTypeLimite != null)
                            result += GetInstance().GetLicenceCheckElementNbPourSession(contexte.IdSession).AddElements(strTypeLimite, nNbNew);
                    }
                    if (!result)
                        break;
                }
            }
            return result;
        }

        public IEnumerable<CAlerteLicence> GetAlertes()
        {
            List<CAlerteLicence> lst = new List<CAlerteLicence>();

            foreach (CNombreUtilisePourTypeLicence restant in GetNombreRestantParType())
            {
                CLicenceTypePrtct type = m_LicenceLogiciel.GetTypeProtege(restant.IdType);
                if (type != null && type.Nombre != 0)
                {
                    double fRatio = ((double)(type.Nombre - restant.NombreUtilise) / ((double)type.Nombre)) * 100;
                    if (fRatio < type.SeuilAlertePourcent ||
                        fRatio < type.SeuilCritiquePourcent)
                    {
                        CAlerteLicence alerte = new CAlerteLicence(
                            I.T("You will soon reach elements '@1' limit : @2% left|20004",
                            type.Nom, fRatio.ToString("0")),
                            fRatio < type.SeuilCritiquePourcent ? EGraviteAlerte.Critique : EGraviteAlerte.Info);
                        lst.Add(alerte);
                    }
                }
            }
            return lst;
        }

        //----------------------------------------------------------------------------
        public static CLicenceCheckElementNb GetInstance()
        {
            if (m_instance == null)
                m_instance = new CLicenceCheckElementNb(CTimosServeur.GetInstance().LicenceLogiciel);

            return m_instance;
        }

        //---------------------------------------------------------------------------------
        private bool HasTypesLimites
        {
            get
            {
                return m_bHasTypesLimites;
            }
        }

        //---------------------------------------------------------------------------------
        public void AddElements(string strType, int nAdd)
        {
            int nNB;

            
            if (m_LicenceLogiciel.GetTypeProtege ( strType )!= null)
            {
                if (m_CreationsEnCours.TryGetValue(strType, out nNB))
                {
                    nNB += nAdd;
                    m_CreationsEnCours[strType] = nNB;
                }
                else
                    m_CreationsEnCours.Add(strType, nAdd);
            }
        }

        //---------------------------------------------------------------------------------
        public void FreeElements(string strType, int nFree)
        {
            int nNB;

            if (m_CreationsEnCours.TryGetValue(strType, out nNB))
            {
                nNB -= nFree;
                m_CreationsEnCours[strType] = nNB;              
            }

        }
        /*
        //--------------------------------------------------------------------------------------
        private bool CheckCRC(string fileName)
        {
            uint crc;
            uint crcSaved;
            
           //calcule CRC du fichier licence
            using (FileStream file = new FileStream(fileName, FileMode.Open))
            {
                using (CrcStream stream = new CrcStream(file))
                {
                    //Use the file somehow -- in this case, read it as a string
                    StreamReader reader = new StreamReader(stream);
                    string text = reader.ReadLine();

                    crc = stream.ReadCrc;
                    file.Close();
                }
            }

            //lecture de CRC
            RegistryKey key = Registry.LocalMachine.OpenSubKey(c_cleRegistrePath);
            if (key == null)
                return false;

            try
            {
                crcSaved = Convert.ToUInt32(key.GetValue(c_cleRegistre).ToString());
                return crc == crcSaved;
            }
            catch 
            {
                return false;
            }                       

        }//CheckCRC

        //---------------------------------------------------------------------------------------------
        private void WriteCRC(string fileName)
        {
            uint crc;

            //calcule CRC du fichier licence
            using (FileStream file = new FileStream(fileName, FileMode.Open))
            {
                using (CrcStream stream = new CrcStream(file))
                {
                    //Use the file somehow -- in this case, read it as a string
                    StreamReader reader = new StreamReader(stream);
                    string text = reader.ReadLine();

                    crc = stream.ReadCrc;
                    file.Close();
                }
            }
            
            RegistryKey key = Registry.LocalMachine.OpenSubKey(c_cleRegistrePath,true);
			if (key == null )
			{
				string[] strSubs = c_cleRegistrePath.Split('\\');
				key = Registry.LocalMachine;
				RegistryKey subKey;
				for ( int nNum = 0; nNum < strSubs.Length; nNum++ )
				{
					subKey = key.OpenSubKey(strSubs[nNum], true);
					if ( subKey == null )
						subKey = key.CreateSubKey ( strSubs[nNum]);
					key = subKey;
				}
			}
            key.SetValue(c_cleRegistre, crc);
        }//WriteCRC

        //-----------------------------------------------------------------------------------
        private bool SaveFileSecurity()
        {
            if (!File.Exists(m_stSaveFileFullName))
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey(c_cleRegistrePath);
                if (key != null)
                {
                    string[] names = key.GetValueNames();
                    for (int i = 0; i < names.Length; i++)
                    {
                        if (names[i] == c_cleRegistre)
                        {
                            //fichier m_stSaveFileFullName était supprimé par l'utilisateur
                            Punition();
                            return false;
                        }
                    }
                }
            }
            else
            {
                if (!CheckCRC(m_stSaveFileFullName))
                {
                    Punition();
                    return false;
                }
            }

            return true;

        }//SaveFileSecurity()
        
        //-------------------------------------------------------------------------------
        //rempit m_stSaveFileFullName 
        //pour chaque type mentioné dans m_LicenceLogiciel on met son nombre maximal 
        private void Punition()
        {
            DateTime dateNow = DateTime.Now;
            DateTime dateBeginningPreviousPeriod;
                        
            foreach (CLicenceTypePrtct type in m_LicenceLogiciel.Types)
            {
                dateBeginningPreviousPeriod = type.GetPreviousPeriodStart(dateNow);

                CNombreRestantPourTypeLicence recordCur = new CNombreRestantPourTypeLicence(dateNow, type.Nom, type.Nombre);
                CNombreRestantPourTypeLicence recordPrev = new CNombreRestantPourTypeLicence(dateBeginningPreviousPeriod, type.Nom, type.Nombre);
                m_listRecords.Add(recordCur);
                m_listRecords.Add(recordPrev);
            }

            if (!File.Exists(m_stSaveFileFullName))
            {
                StreamWriter sw = File.CreateText(m_stSaveFileFullName);
                sw.Close();
            }

            WriteSaveFile();
        }//Punition()

        public IEnumerable<CAlerteLicence> GetAlertes()
        {
            List<CAlerteLicence> lst = new List<CAlerteLicence>();

            foreach (CNombreRestantPourTypeLicence restant in GetNombreRestantParType())
            {
                CLicenceTypePrtct type = m_LicenceLogiciel.GetTypeProtege(restant.IdType);
                if (type != null && type.Nombre != 0)
                {
                    double fRatio = ((double)(type.Nombre-restant.NombreUtilise) / ((double)type.Nombre))*100;
                    if (fRatio < type.SeuilAlertePourcent ||
                        fRatio < type.SeuilCritiquePourcent)
                    {
                        CAlerteLicence alerte = new CAlerteLicence(
                            I.T("You will soon reach elements '@1' limit : @2% left|20004",
                            type.Nom, fRatio.ToString("0")),
                            fRatio < type.SeuilCritiquePourcent ? EGraviteAlerte.Critique : EGraviteAlerte.Info);
                        lst.Add(alerte);
                    }
                }
            }
            return lst;
        }
                    
        */
            

    }    
}
