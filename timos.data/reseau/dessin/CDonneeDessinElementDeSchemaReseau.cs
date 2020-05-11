using System;
using System.Collections.Generic;
using System.Text;
using sc2i.common;

namespace timos.data
{
    public interface IDonneeDessinElementDeSchemaReseau : I2iSerializable
    {
        int IdObjetDeSchema { get;set;}

        /// <summary>
        /// Id du contexte de donnée si cet objet est mis en cache !
        /// </summary>
        int IdContexteDonnee{get;}

        bool ShouldSaveInBlob { get;}
    }

    //Permet de stocker des données complémentaires de dessin
    //pour les C2iObjetDeSchema
    public class CDonneeDessinElementDeSchemaReseau : IDonneeDessinElementDeSchemaReseau
    {
        private int m_nIdObjetDeSchema = -1;

        private int m_nIdContexteDonnee = -1;

        private bool m_bCollecterAlarmesDeFils = false;

        public CDonneeDessinElementDeSchemaReseau(int nIdContexteDonnee)
        {
            m_nIdContexteDonnee = nIdContexteDonnee;
        }

        public CDonneeDessinElementDeSchemaReseau()
            :base()
        {
        }

        public int IdContexteDonnee
        {
            get
            {
                return m_nIdContexteDonnee;
            }
        }

        private int GetNumVersion()
        {
            return 2;
            //2 : ajout de la collecte de alarmes filles
        }

        public virtual bool ShouldSaveInBlob
        {
            get
            {
                return false;
            }
        }

        public virtual bool CollectChildsAlarms
        {
            get
            {
                return m_bCollecterAlarmesDeFils;
            }
            set
            {
                m_bCollecterAlarmesDeFils = value;
            }
        }

        public int IdObjetDeSchema
        {
            get
            {
                return m_nIdObjetDeSchema;
            }
            set
            {
                m_nIdObjetDeSchema = value;
            }
        }

                

        public virtual CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion ( ref nVersion );
            if (!result)
                return result;
            if (nVersion >= 1)
                serializer.TraiteInt(ref m_nIdObjetDeSchema);
            if ( nVersion >= 2 )
                serializer.TraiteBool ( ref m_bCollecterAlarmesDeFils);

            return result;

        }

        public void CopyFrom(CDonneeDessinElementDeSchemaReseau donneeDessin)
        {
            if ( donneeDessin != null )
            {
                m_nIdObjetDeSchema = donneeDessin.m_nIdObjetDeSchema;
                m_nIdContexteDonnee = donneeDessin.m_nIdContexteDonnee;
                m_bCollecterAlarmesDeFils = donneeDessin.CollectChildsAlarms;
            }
        }

    }
}
