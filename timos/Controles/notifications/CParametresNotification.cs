using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using System.Media;
using System.IO;
using timos.Properties;

namespace timos.Controles.notifications
{
    public class CParametresNotification : I2iSerializable
    {
        private int m_nDureeAffichage = 10;
        private bool m_bPlaySound = true;
        private string m_strSoundFile = "";
        private SoundPlayer m_soundPlayer = null;

        private static CParametresNotification m_instance = null;

        //-------------------------------------------
        protected CParametresNotification()
        {
            Init();
            InitSoundPlayer();
        }

        //-------------------------------------------
        protected string ProtectedSoundFile
        {
            get{
                return m_strSoundFile;
            }
            set{
                m_strSoundFile = value;
                InitSoundPlayer();
            }
        }

        //-------------------------------------------
        private void InitSoundPlayer()
        {
            if ( m_soundPlayer != null )
            {
                m_soundPlayer.Dispose();
            }
            if ( File.Exists ( m_strSoundFile ) )
                m_soundPlayer = new SoundPlayer(m_strSoundFile);
            else
            {
                Stream str = Resources.NotifDefault;
                m_soundPlayer = new SoundPlayer(str);
            }
        }

        //-------------------------------------------
        private void Init()
        {
            CTimosAppRegistre.FillParametreNotifications(this);
        }

        //-------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //-------------------------------------------
        public CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            serializer.TraiteInt(ref m_nDureeAffichage);
            serializer.TraiteBool(ref m_bPlaySound);
            serializer.TraiteString(ref m_strSoundFile);
            return result;
        }

        //-------------------------------------------
        public static CParametresNotification Instance
        {
            get
            {
                if (m_instance == null)
                    m_instance = new CParametresNotification();
                return m_instance;
            }
        }

        //-------------------------------------------
        public static int DureeAffichage
        {
            get
            {
                return Instance.m_nDureeAffichage;
            }
            set
            {
                Instance.m_nDureeAffichage = Math.Max(value,2);
            }
        }

        //-------------------------------------------
        public static bool ShouldPlaySound
        {
            get
            {
                return Instance.m_bPlaySound;
            }
            set
            {
                Instance.m_bPlaySound = value;
            }
        }

        //-------------------------------------------
        public static string SoundFile
        {
            get
            {
                return Instance.ProtectedSoundFile;
            }
            set
            {
                Instance.ProtectedSoundFile = value;
            }
        }

        //-------------------------------------------
        public static void SavePreferences()
        {
            CTimosAppRegistre.SaveParametreNotifications(Instance);
        }

        //-------------------------------------------
        public static void PlaySound()
        {
            if (ShouldPlaySound && Instance.m_soundPlayer != null)
            {
                try
                {
                    Instance.m_soundPlayer.Play();
                }
                catch
                {
                }
            }
                    
                    
        }
    }
}
