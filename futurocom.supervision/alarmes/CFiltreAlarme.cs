using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;

namespace futurocom.supervision
{

    public class CFiltreAlarme : IFiltreAlarme
    {
        private HashSet<CDbKey> m_listeIdTypesAlarmes = new HashSet<CDbKey>();
        private HashSet<CDbKey> m_listeIdSites = new HashSet<CDbKey>();
        private HashSet<CDbKey> m_listeIdEquipementsLogiques = new HashSet<CDbKey>();
        private HashSet<CDbKey> m_listeIdLiensReseau = new HashSet<CDbKey>();
        private HashSet<CDbKey> m_listeIdEntitesSnmp = new HashSet<CDbKey>();


        public bool IsInFiltre(IAlarme alarme)
        {
            if (alarme == null)
                return false;

            bool bFiltrer = false;

            // Applique filtre Type d'Alarme
            if (m_listeIdTypesAlarmes.Count > 0)
            {
                if (m_listeIdTypesAlarmes.Contains(alarme.TypeAlarmeId))
                    bFiltrer = true;
                else
                    return false;
            }
            // Applique filtre Site
            if (m_listeIdSites.Count > 0 && alarme.SiteId != null)
            {
                if (m_listeIdSites.Contains(alarme.SiteId))
                    bFiltrer = true;
                else
                    return false;
            }
            // Applique filre Equipement Logique
            if (m_listeIdEquipementsLogiques.Count > 0 && alarme.EquipementId != null)
            {
                if (m_listeIdEquipementsLogiques.Contains(alarme.EquipementId))
                    bFiltrer = true;
                else
                    return false;
            }
            // Applique filre Liens Reseau
            if (m_listeIdLiensReseau.Count > 0 && alarme.LienId != null)
            {
                if (m_listeIdLiensReseau.Contains(alarme.LienId))
                    bFiltrer = true;
                else
                    return false;
            }
            // Applique filre Entité SNMP
            if (m_listeIdEntitesSnmp.Count > 0 && alarme.EntiteSnmpId != null)
            {
                if (m_listeIdEntitesSnmp.Contains(alarme.EntiteSnmpId))
                    bFiltrer = true;
                else
                    return false;
            }
            
            return bFiltrer;
        }

        public HashSet<CDbKey> ListeIdsTypesAlarmes
        {
            get
            {
                return m_listeIdTypesAlarmes;
            }
            set
            {
                m_listeIdTypesAlarmes = value;
            }
        }

        public HashSet<CDbKey> ListeIdsSites
        {
            get
            {
                return m_listeIdSites;
            }
            set
            {
                m_listeIdSites = value;
            }
        }


        public HashSet<CDbKey> ListeIdsEquipementsLogiques
        {
            get
            {
                return m_listeIdEquipementsLogiques;
            }
            set
            {
                m_listeIdEquipementsLogiques = value;
            }
        }

        public HashSet<CDbKey> ListeIdsLiensReseau
        {
            get
            {
                return m_listeIdLiensReseau;
            }
            set
            {
                m_listeIdLiensReseau = value;
            }
        }

        public HashSet<CDbKey> ListeIdsEntiesSnmp
        {
            get
            {
                return m_listeIdEntitesSnmp;
            }
            set
            {
                m_listeIdEntitesSnmp = value;
            }
        }

        //----------------------------------------------------------------------
        private int GetNumVersion()
        {
            //return 0;
            return 1; // Passage des listes d'Ids en listes de DbKey
        }

        //-----------------------------------------------------------------------
        public CResultAErreur Serialize(sc2i.common.C2iSerializer serializer)
        {
            CResultAErreur result = CResultAErreur.True;
            int nVersion = GetNumVersion();

            result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;

            // Traite la liste des Ids de Types d'Alarmes
            int nNbTypeAlarme = m_listeIdTypesAlarmes.Count;
            serializer.TraiteInt(ref nNbTypeAlarme);
            switch (serializer.Mode)
            {
                case ModeSerialisation.Ecriture:
                    foreach (CDbKey dbKey in m_listeIdTypesAlarmes)
                    {
                        CDbKey dbKeyTmp = dbKey;
                        serializer.TraiteDbKey(ref dbKeyTmp);
                    }
                    break;
                case ModeSerialisation.Lecture:
                    m_listeIdTypesAlarmes.Clear();
                    for (int nVal = 0; nVal < nNbTypeAlarme; nVal++)
                    {
                        CDbKey dbKeyTmp = null;
                        serializer.TraiteDbKey(ref dbKeyTmp);
                        m_listeIdTypesAlarmes.Add(dbKeyTmp);
                    }
                    break;
            }

            // Traite la liste des Ids de Site
            int nNbSites = m_listeIdSites.Count;
            serializer.TraiteInt(ref nNbSites);
            switch (serializer.Mode)
            {
                case ModeSerialisation.Ecriture:
                    foreach (CDbKey dbKey in m_listeIdSites)
                    {
                        CDbKey dbKeyTmp = dbKey;
                        serializer.TraiteDbKey(ref dbKeyTmp);
                    }
                    break;
                case ModeSerialisation.Lecture:
                    m_listeIdSites.Clear();
                    for (int nVal = 0; nVal < nNbSites; nVal++)
                    {
                        CDbKey dbKeyTmp = null;
                        if (nVersion < 1)
                            serializer.ReadDbKeyFromOldId(ref dbKeyTmp, null);
                        else
                            serializer.TraiteDbKey(ref dbKeyTmp);
                        m_listeIdSites.Add(dbKeyTmp);
                    }
                    break;
            }

            // Traite la liste des Ids d'Equipements Logiques
            int nNbEqpt = m_listeIdEquipementsLogiques.Count;
            serializer.TraiteInt(ref nNbEqpt);
            switch (serializer.Mode)
            {
                case ModeSerialisation.Ecriture:
                    foreach (CDbKey dbKey in m_listeIdEquipementsLogiques)
                    {
                        CDbKey dbKeyTemp = dbKey;
                        serializer.TraiteDbKey(ref dbKeyTemp);
                    }
                    break;
                case ModeSerialisation.Lecture:
                    m_listeIdEquipementsLogiques.Clear();
                    for (int nVal = 0; nVal < nNbEqpt; nVal++)
                    {
                        CDbKey dbKeyTmp = null;
                        if (nVersion < 1)
                            serializer.ReadDbKeyFromOldId(ref dbKeyTmp, null);
                        else
                            serializer.TraiteDbKey(ref dbKeyTmp);
                        m_listeIdEquipementsLogiques.Add(dbKeyTmp);
                    }
                    break;
            }

            // Traite la liste des Ids de Liens Résaux
            int nNbLiens = m_listeIdLiensReseau.Count;
            serializer.TraiteInt(ref nNbLiens);
            switch (serializer.Mode)
            {
                case ModeSerialisation.Ecriture:
                    foreach (CDbKey dbKey in m_listeIdLiensReseau)
                    {
                        CDbKey dbKeyTmp = dbKey;
                        serializer.TraiteDbKey(ref dbKeyTmp);
                    }
                    break;
                case ModeSerialisation.Lecture:
                    m_listeIdLiensReseau.Clear();
                    for (int nVal = 0; nVal < nNbLiens; nVal++)
                    {
                        CDbKey dbKeyTmp = null;
                        if (nVersion < 1)
                            serializer.ReadDbKeyFromOldId(ref dbKeyTmp, null);
                        else
                            serializer.TraiteDbKey(ref dbKeyTmp);
                        m_listeIdLiensReseau.Add(dbKeyTmp);
                    }
                    break;
            }

            // Traite la liste des Ids d'Entité SNMP
            int nNbEntites = m_listeIdEntitesSnmp.Count;
            serializer.TraiteInt(ref nNbEntites);
            switch (serializer.Mode)
            {
                case ModeSerialisation.Ecriture:
                    foreach (CDbKey dbKey in m_listeIdEntitesSnmp)
                    {
                        CDbKey dbKeyTmp = dbKey;
                        serializer.TraiteDbKey(ref dbKeyTmp);
                    }
                    break;
                case ModeSerialisation.Lecture:
                    m_listeIdEntitesSnmp.Clear();
                    for (int nVal = 0; nVal < nNbEntites; nVal++)
                    {
                        CDbKey dbKeyTmp = null;
                        if (nVersion < 1)
                            serializer.ReadDbKeyFromOldId(ref dbKeyTmp, null);
                        else
                            serializer.TraiteDbKey(ref dbKeyTmp);
                        m_listeIdEntitesSnmp.Add(dbKeyTmp);
                    }
                    break;
            }


            return result;
        }



    }
}
