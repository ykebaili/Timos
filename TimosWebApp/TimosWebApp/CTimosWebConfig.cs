using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using System.IO;

namespace TimosWebApp
{
    public class CTimosWebConfig : I2iSerializable
    {
        private string m_strURL = "http://localhost/TimosWeb/TimosActionService.asmx";
        private CMemoryAction m_action = new CMemoryAction();
        private const string c_idFichier = "TIMOSWEBCONFIG"; 

        public CTimosWebConfig()
        {
        }

        public string URL
        {
            get
            {
                return m_strURL;
            }
            set
            {
                m_strURL = value;
            }
        }

        public CMemoryAction Action
        {
            get
            {
                return m_action;
            }
            set
            {
                m_action = value;
            }
        }
           

        private int GetNumVersion()
        {
            return 0;
        }

        public CResultAErreur Serialize(C2iSerializer serializer)
        {
            CResultAErreur result = CResultAErreur.True;
            int nVersion = GetNumVersion();
            
            result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;

            serializer.TraiteString(ref m_strURL);
            result = serializer.TraiteObject<CMemoryAction>(ref m_action);

            return result;
        }

        //----------------------------------------------------------------------------------
        public CResultAErreur ReadFromFile(string strNomFichier)
        {
            CResultAErreur result = CResultAErreur.True;
            FileStream stream = null;
            try
            {
                stream = new FileStream(strNomFichier, FileMode.Open, FileAccess.Read, FileShare.Read);
            }
            catch (Exception e)
            {
                result.EmpileErreur(new CErreurException(e));
                result.EmpileErreur(I.T("Error while opening file|109"));
            }
            try
            {
                BinaryReader reader = new BinaryReader(stream);
                string strId = reader.ReadString();
                if (strId != c_idFichier)
                {
                    result.EmpileErreur(I.T("The file doesn't contain a valid vizualisation parameter|20042"));
                    return result;
                }
                CSerializerReadBinaire serializer = new CSerializerReadBinaire(reader);
                result = Serialize(serializer);
                reader.Close();
            }
            catch (Exception e)
            {
                result.EmpileErreur(new CErreurException(e));
                result.EmpileErreur(I.T("Error while reading the file|110"));
            }
            finally
            {
                try
                {
                    stream.Close();
                }
                catch { }
            }
            return result;
        }

        //----------------------------------------------------------------------------------
        public CResultAErreur SaveToFile(string strNomFichier)
        {
            CResultAErreur result = CResultAErreur.True;
            FileStream stream = null;
            try
            {
                stream = new FileStream(strNomFichier, FileMode.Create, FileAccess.Write, FileShare.None);
            }
            catch (Exception e)
            {
                result.EmpileErreur(new CErreurException(e));
                result.EmpileErreur(I.T("Error while opening the file|109"));
            }
            try
            {
                BinaryWriter writer = new BinaryWriter(stream);
                writer.Write(c_idFichier);
                CSerializerSaveBinaire serializer = new CSerializerSaveBinaire(writer);
                result = Serialize(serializer);
                writer.Close();
            }
            catch (Exception e)
            {
                result.EmpileErreur(new CErreurException(e));
                result.EmpileErreur(I.T("Error while writing the file|112"));
            }
            finally
            {
                try
                {
                    stream.Close();
                }
                catch { }
            }
            return result;
        }

    }
}
