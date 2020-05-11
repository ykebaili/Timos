using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using futurocom.sig;
using sc2i.formulaire;
using sc2i.common.sig;
using sc2i.formulaire.win32;
using sc2i.data;

namespace futurocom.win32.sig
{
    public class CRuntimeConfigMapView : I2iSerializable
    {
        private CDbKey m_keyConfigMapDatabase = null;
        private bool m_bIsVisible = false;
        private int m_nZOrder = 0;

        private bool m_bIsCalculated = false;

        //Non serializé
        private CMapDatabaseGenerator m_generator = null;

        //-------------------------------------------------
        public CRuntimeConfigMapView()
        {
        }

        //-------------------------------------------------
        public int ZOrder
        {
            get
            {
                return m_nZOrder;
            }
            set
            {
                m_nZOrder = value;
            }
        }

        //-------------------------------------------------
        [ExternalReferencedEntityDbKey(typeof(CConfigMapDatabase))]
        public CDbKey KeyConfigMapDatabase
        {
            get
            {
                return m_keyConfigMapDatabase;
            }
            set
            {
                m_keyConfigMapDatabase = value;
            }
        }

        //-------------------------------------------------
        public bool IsCalculated
        {
            get
            {
                return m_bIsCalculated;
            }
            set
            {
                m_bIsCalculated = value;
            }
        }

        //-------------------------------------------------
        public CMapDatabaseGenerator Generator
        {
            get
            {
                return m_generator;
            }
            set
            {
                m_generator = value;
            }
        }

        //-------------------------------------------------
        public bool IsVisible
        {
            get
            {
                return m_bIsVisible;
            }
            set
            {
                m_bIsVisible = value;
            }
        }
        
        //-------------------------------------------------
        public static CRuntimeConfigMapView CreateFromConfig(CConfigMapDatabase config)
        {
            if (config == null)
                return null;
            CRuntimeConfigMapView runtime = new CRuntimeConfigMapView();
            //TESTDBKEYTOK
            runtime.m_keyConfigMapDatabase = config.DbKey;
            runtime.m_generator = config.MapGenerator;
            return runtime;
        }

        #region I2iSerializable Membres
        private int GetNumVersion()
        {
            return 1;
            //1 : passsage de la config MapDatabase en DbKey
        }

        //----------------------------------------------------------
        public CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;

            //TESTDBKEYOK
            if (nVersion < 1)
                serializer.ReadDbKeyFromOldId(ref m_keyConfigMapDatabase, typeof(CConfigMapDatabase));
            else
                serializer.TraiteDbKey(ref m_keyConfigMapDatabase);
            if ( serializer.Mode == ModeSerialisation.Lecture )
            {
                CConfigMapDatabase db = new CConfigMapDatabase ( CContexteDonneeSysteme.GetInstance() );
                //TESTDBKEYOK
                if ( !db.ReadIfExists(m_keyConfigMapDatabase) )
                    m_generator = null;
                else
                    m_generator = db.MapGenerator;
            }
            serializer.TraiteInt(ref m_nZOrder);
            serializer.TraiteBool(ref m_bIsVisible);
            List<KeyValuePair<string, object>> valeurs= new List<KeyValuePair<string, object>>();
            if (m_generator != null)
            {
                foreach (KeyValuePair<string, object> kv in m_generator.ValeursVariables)
                {
                    if (kv.Value != null && C2iSerializer.GetTypeSimple(kv.Value.GetType()) != C2iSerializer.EnumTypeSimple.Inconnu)
                        valeurs.Add(kv);
                }
            }
            int nNbValeurs = valeurs.Count();
            serializer.TraiteInt(ref nNbValeurs);
            switch (serializer.Mode)
            {
                case ModeSerialisation.Ecriture :
                    foreach ( KeyValuePair<string, object> kv in valeurs )
                    {
                        string strIdVar = kv.Key;
                        object value = kv.Value;
                        //TESTDBKEYOK
                        serializer.TraiteString(ref strIdVar);
                        result = serializer.TraiteObjetSimple ( ref value );
                        if ( !result )
                            return result;
                    }
                    break;
                case ModeSerialisation.Lecture :
                    if (m_generator != null)
                        m_generator.ClearVariables();
                    for (int nVar = 0; nVar < nNbValeurs; nVar++)
                    {
                        string strIdVar = "";
                        object value = null;
                        if (nVersion < 1)
                        {
                            int nIdTemp = -1;
                            serializer.TraiteInt(ref nIdTemp);
                            strIdVar = nIdTemp.ToString();
                        }
                        else
                            serializer.TraiteString(ref strIdVar);

                        result = serializer.TraiteObjetSimple(ref value);
                        if (!result)
                            return result;
                        if (m_generator != null)
                            m_generator.SetValeurChamp(strIdVar, value);
                    }
                    break;
            }
            return result;
        }

        #endregion
    }
}
