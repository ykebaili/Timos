using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Runtime.InteropServices;
using System.IO;
using System.Media;
using sc2i.common;

namespace spv.win32
{
    public static class CSonneurDeSonnerieAlarme
    {
        private static bool m_bSonnerieEnCours = false;

        private static int m_nIdNextSonnerie = 0;
        private static int? m_nIdSonnerieEnCours = null;

        [DllImport("WinMM.dll")]
        public static extern bool PlaySound(string strFichier, int nMod, int nFlag);

        private static int SND_FILENAME = 0x00020000;
        private static int SND_PURGE = 0x0040;


        //Si retourne un entier, c'est que le système 
        //joue la sonnerie, sinon, c'est qu'il est occupé par une autre
        //sonnerie.
        //L'entier retourné doit être passé à StopSound pour
        //l'arrêt de l'alarme
        public static int? StartSonnerie(string strFichierWav)
        {
            lock (typeof(CSonneurDeSonnerieAlarme))
            {
                if (m_bSonnerieEnCours)
                    return null;
                m_bSonnerieEnCours = true;
            }
            PlaySoundBackgroundDelegate delegue = new PlaySoundBackgroundDelegate(PlaySoundBackground);
            delegue.BeginInvoke(strFichierWav, null, null);
            m_nIdSonnerieEnCours = m_nIdNextSonnerie++;
            return m_nIdSonnerieEnCours;
        }

        private delegate void PlaySoundBackgroundDelegate(string strFichier);

        private static void PlaySoundBackground(string strFichier)
        {
            try
            {
                if (strFichier != "")
                {
                    using (CFichierLocalTemporaire temp = new CFichierLocalTemporaire("WAV"))
                    {
                        temp.CreateNewFichier();
                        File.Copy(strFichier, temp.NomFichier);
                        while (true)
                        {
                            PlaySound(temp.NomFichier, 0, SND_FILENAME);
                            if (m_nIdSonnerieEnCours == null)
                            {
                                PlaySound(null, 0, SND_PURGE);
                                break;
                            }
                        }
                    }
                }
                else
                {
                    while (true)
                    {
                        Console.Beep(1000, 100);
                        if (m_nIdSonnerieEnCours == null)
                            break;
                    }
                }

            }
            catch
            {
                
            }
            finally
            {
                m_nIdSonnerieEnCours = null;
                m_bSonnerieEnCours = false;
            }
        }

        public static void StopSonnerie(int nIdSonnerie)
        {
            if (nIdSonnerie == m_nIdSonnerieEnCours)
            {
                m_nIdSonnerieEnCours = null;
            }
        }
    }
}