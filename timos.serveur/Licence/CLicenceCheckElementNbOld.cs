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

/*
 * STEF JANVIER 2011 : suppression du comptage des éléments
 * avec gestion de période. Conserve le code pour historique, ça peut reservir

namespace timos.serveur
{
    


    ///////////////////////////////////////////////////////////////////////////////
    public class CLicenceCheckElementNb : I2iSerializable
    {
        private string m_stSaveFileFullName;                        //fichier de sauvegarde des nombres des types créés;
        private CLicenceLogicielPrtct m_LicenceLogiciel;
        private List<CNombreRestantPourTypeLicence> m_listRecords;                //contenu de m_stSaveFileFullName
        private const string c_stDefSaveFileName = "ConfigEN.prtct";// le nom pas parlant pour bien cacher l'information secrète
        static string defPassword = "anotheremptypwd";
        Dictionary<int, CLicenceCheckElementNbPourSession> m_DictionarySessions;//int - sessionId
        private static CLicenceCheckElementNb m_instance = null;
        private Dictionary<string, int> m_CreationsEnCours;             //modifications pas encore commitées
        private const string c_cleRegistrePath = "Software\\Controls\\";//sauvagerde de CRC
        private const string c_cleRegistre = "cscontrol";               //sauvagerde de CRC

        //Nom de table->bool si limité
        private Dictionary<string, bool> m_dicTablesLimitees = new Dictionary<string, bool>();

        //True si la licence possède des types limités
        private bool m_bHasTypesLimites = false;
               
        public bool AccepteTransactionsImbriquees { get { return true; } }


        private static Dictionary<string, string> m_dicNomTableToIdTypeLimite = new Dictionary<string, string>();

        public CLicenceCheckElementNb()//pour serialisation
        {
            m_LicenceLogiciel = null;
            m_listRecords = new List<CNombreRestantPourTypeLicence>();
            m_DictionarySessions = new Dictionary<int, CLicenceCheckElementNbPourSession>();
            m_CreationsEnCours = new Dictionary<string, int>();
        }


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

        public CLicenceCheckElementNb(CLicenceLogicielPrtct licenceLogiciel)
        {
            Init(licenceLogiciel, AppDomain.CurrentDomain.BaseDirectory + c_stDefSaveFileName);
        }

        public CLicenceCheckElementNb(CLicenceLogicielPrtct licenceLogiciel, string stSaveFileFullName)
        {
            Init(licenceLogiciel, stSaveFileFullName);            
        }

        public IEnumerable<CNombreRestantPourTypeLicence> GetNombreRestantParType()
        {
            return m_listRecords.AsReadOnly();
        }

        private static bool m_bRegistrerTraitementAvecSauvegardeFait = false;
        void Init(CLicenceLogicielPrtct licenceLogiciel, string stSaveFileFullName)
        {
            m_stSaveFileFullName = stSaveFileFullName;
            m_LicenceLogiciel = licenceLogiciel;
            m_listRecords = new List<CNombreRestantPourTypeLicence>();
            m_DictionarySessions = new Dictionary<int, CLicenceCheckElementNbPourSession>();
            m_CreationsEnCours = new Dictionary<string, int>();

            if(SaveFileSecurity())//si non m_listRecords est deja remplit par la Punition()
            {
                //lire le fichier m_stSaveFileFullName , remplir m_listRecords
                //Lecture du fichier
                if (!File.Exists(m_stSaveFileFullName))
                {
                    StreamWriter sw = File.CreateText(m_stSaveFileFullName);
                    sw.Close();

                    WriteCRC(m_stSaveFileFullName);
                }
                else
                {
                    FileStream stream = new FileStream(m_stSaveFileFullName, FileMode.Open);
                    byte[] buffer = new byte[stream.Length];
                    stream.Read(buffer, 0, (int)stream.Length);
                    stream.Close();

                    if (buffer.Length == 0)
                        return;

                    //Décryptage
                    byte[] decrypted = Cryptage.Decrypt(buffer, defPassword);

                    //Désérialisation du fichier décrypté
                    MemoryStream memStream = new MemoryStream(decrypted, false);
                    BinaryReader reader = new BinaryReader(memStream);
                    CSerializerReadBinaire serializer = new CSerializerReadBinaire(reader);

                    I2iSerializable iTmp = null;
                    CResultAErreur result = serializer.SerializeObjet(ref iTmp);
                    if (!result)
                    {
                        throw new CExceptionErreur(result.Erreur);
                    }
                    else if (iTmp != null)
                    {
                        CLicenceCheckElementNb checkElemNb = (CLicenceCheckElementNb)iTmp;

                        foreach (CNombreRestantPourTypeLicence record in checkElemNb.m_listRecords)
                            m_listRecords.Add(record);
                    }
                    reader.Close();
                    memStream.Close();
                }
            }
            if (!m_bRegistrerTraitementAvecSauvegardeFait)
            {
                if (m_LicenceLogiciel.Types.Count != 0)
                {
                    m_bRegistrerTraitementAvecSauvegardeFait = true;
                    CContexteDonneeServeur.DoTraitementExterneAvantSauvegarde += new TraitementSauvegardeExterne(TraitementAvantSauvegarde);
                    m_bHasTypesLimites = true;
                }
            }
        }

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
            
            DateTime dateNow = System.DateTime.Now;
            DateTime dateBeginningCurrentPeriod;
            DateTime dateBeginningPreviousPeriod;
            int nExist;     //nombre des éléments créé pendant le période en cours 
            int nRestPrev;  //rest des éléments = type.LicenceTypeNb - numéraux d'éléments créé pendant le période precedant;

            CLicenceTypePrtct type = m_LicenceLogiciel.GetTypeProtege(strType);

            if (type != null)
            {
                dateBeginningCurrentPeriod = type.GetPeriodStart(dateNow);
                dateBeginningPreviousPeriod = type.GetPreviousPeriodStart(dateNow);

                nExist = 0;
                if (dateBeginningCurrentPeriod == dateBeginningPreviousPeriod)
                    nRestPrev = 0;
                else
                    nRestPrev = type.Nombre;

                foreach (CNombreRestantPourTypeLicence record in m_listRecords)
                {
                    if (record.What.ToUpper() == strType.ToUpper() )
                    {
                        if (record.When >= dateBeginningCurrentPeriod)
                            nExist += record.HowMuch;
                        else if (record.When >= dateBeginningPreviousPeriod)
                            nRestPrev -= record.HowMuch;
                        else //correspond to very old period
                            record.ToDelete = true;
                    }
                }

                nRestPrev = Math.Max(0, nRestPrev);

				//delete old records
                m_listRecords.RemoveAll(ToBeDeleted);

                int nRestToUse = Math.Min(type.ReconductionMax, nRestPrev);
                int nEnCours = 0;
                m_CreationsEnCours.TryGetValue(strType, out nEnCours);

                if (nExist + nNbDemande + nEnCours > type.Nombre + nRestToUse)
                {
                    int nbPossibleToCreate = type.Nombre + nRestToUse - nExist - nEnCours;
                    DateTime periodEnd = type.GetPeriodEnd(dateBeginningCurrentPeriod);
                    result.EmpileErreur(I.T("Impossible to create @1 elements. Your licence allows you to create @2 ones till the @3|9",
                        nNbDemande.ToString(), nbPossibleToCreate.ToString(), periodEnd.ToShortDateString()));
                    
                    return result;
                }
            }

            return result;
        }

        private bool ToBeDeleted(CNombreRestantPourTypeLicence record)
        {
            return record.ToDelete == true;
        }

        
        private CNombreRestantPourTypeLicence FindExistingRecord(string strNom, DateTime dateLimite)
        {
            foreach (CNombreRestantPourTypeLicence record in m_listRecords)
            {
                if (record.What.ToUpper() == strNom.ToUpper() && record.When >= dateLimite )
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
            DateTime dateBeginningCurrentPeriode;
            bool bHasChange = false;

            foreach (KeyValuePair<string, int> kvp in dictionary)
            {
                CLicenceTypePrtct type = m_LicenceLogiciel.GetTypeProtege(kvp.Key);

                if (type != null)//on sauvegarde que des types limités par la licence
                {
                    dateBeginningCurrentPeriode = type.GetPeriodStart(dateNow);
                    CNombreRestantPourTypeLicence record = FindExistingRecord(type.Nom, dateBeginningCurrentPeriode);
                    bHasChange = true;
                    if (record == null)
                    {
                        CNombreRestantPourTypeLicence addRecord = new CNombreRestantPourTypeLicence(dateNow, kvp.Key, kvp.Value);
                        m_listRecords.Add(addRecord);
                    }
                    else
                    {
                        int indx = m_listRecords.IndexOf(record);
                        m_listRecords.RemoveAt(indx);
                        record.HowMuch += kvp.Value;
                        m_listRecords.Add(record);
                    }
                    FreeElements(kvp.Key, kvp.Value);//les modif. sont commitées, on les efface de m_CreationsEnCours
                }
            }

            if(result && bHasChange)
                return WriteSaveFile();
            else
                return result;
        }

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
        }

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
                foreach (CNombreRestantPourTypeLicence record in lst)
                    m_listRecords.Add(record);
            }

            return result; 
        }

        private int GetNumVersion()
        {
            return 0;
        }

        //----------------------------------------------------------------------------
		public static void TraitementAvantSauvegarde(CContexteDonnee contexte, Hashtable tableData, ref CResultAErreur result)
        {
			if (!result)
				return;

            ArrayList lstTables = new ArrayList(contexte.Tables);
            foreach (DataTable table in lstTables)
            {
                if (GetInstance().IsLimite(table.TableName))
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
                CLicenceTypePrtct type = m_LicenceLogiciel.GetTypeProtege(restant.What);
                if (type != null && type.Nombre != 0)
                {
                    double fRatio = ((double)(type.Nombre-restant.HowMuch) / ((double)type.Nombre))*100;
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
                    

            

    }    
}
*/