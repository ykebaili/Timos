using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using sc2i.expression;
using System.Drawing.Design;
using sc2i.data;

namespace futurocom.sig
{
    public class CConfigCalqueMap : I2iSerializable
    {
        private CDbKey m_keyConfigMapDatabase = null;
        private List<CFormuleNommee> m_valeursVariablesConfig = new List<CFormuleNommee>();

        //Non serialize
        private CMapDatabaseGenerator m_mapGenerator = null;

        //----------------------------------------------
        public CConfigCalqueMap()
        {
        }

        //----------------------------------------------
        public CMapDatabaseGenerator generator
        {
            get
            {
                return m_mapGenerator;
            }
            set
            {
                m_mapGenerator = value;
            }
        }
        
        //----------------------------------------------
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

        /// ////////////////////////////////////////////////////////////////
        public CFormuleNommee[] ValeursVariablesFiltre
        {
            get
            {
                return m_valeursVariablesConfig.ToArray();
            }
            set
            {
                if (value != null)
                {
                    m_valeursVariablesConfig.Clear();
                    m_valeursVariablesConfig.AddRange(value);
                }
            }
        }

        //----------------------------------------------
        private int GetNumVersion()
        {
            return 1;
            //1 : Passage de l'id de config en DbKey de config
        }

        //----------------------------------------------
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
            result = serializer.TraiteListe<CFormuleNommee>(m_valeursVariablesConfig);
            if (!result)
                return result;
            return result;
        }
    }


    public class CConfigWndMapView :  I2iSerializable
    {
        private C2iExpression m_formuleLongitude = null;
        private C2iExpression m_formuleLatitude = null;
        private C2iExpression m_formuleZoom = null;
        private C2iExpression m_formulePreserveStateKey = null;
        private EWndMapMode m_mapMode = EWndMapMode.Map;

        private List<CConfigCalqueMap> m_listeConfigs = new List<CConfigCalqueMap>();

        private bool m_bPreserveCenter = true;
        private bool m_bPreserveZoom = true;
        private bool m_bPreserveLayers = true;
        private bool m_bPreserveMapMode = true;
        
        //-------------------------------------------------------------------
        public CConfigWndMapView()
        {
        }

        //-------------------------------------------------------------------
        public C2iExpression FormuleLongitude
        {
            get
            {
                return m_formuleLongitude;
            }
            set
            {
                m_formuleLongitude = value;
            }
        }

        //-------------------------------------------------------------------
        public C2iExpression FormuleLatitude
        {
            get
            {
                return m_formuleLatitude;
            }
            set
            {
                m_formuleLatitude = value;
            }
        }

        //-------------------------------------------------------------------
        public C2iExpression FormuleZoomFactor
        {
            get
            {
                return m_formuleZoom;
            }
            set
            {
                m_formuleZoom = value;
            }
        }

        /////////////////////////////////////
        public EWndMapMode MapMode
        {
            get
            {
                return m_mapMode;
            }
            set
            {
                m_mapMode = value;
            }
        }

        //-------------------------------------------------------------------
        public bool PreserveCenter
        {
            get
            {
                return m_bPreserveCenter;
            }
            set
            {
                m_bPreserveCenter = value;
            }
        }

        //-------------------------------------------------------------------
        public bool PreserveZoom
        {
            get
            {
                return m_bPreserveZoom;
            }
            set
            {
                m_bPreserveZoom = value;
            }
        }

        //-------------------------------------------------------------------
        public bool PreserveMapMode
        {
            get
            {
                return m_bPreserveMapMode;
            }
            set
            {
                m_bPreserveMapMode = value;
            }
        }

        //-------------------------------------------------------------------
        public bool PreserveLayers
        {
            get
            {
                return m_bPreserveLayers;
            }
            set
            {
                m_bPreserveLayers = value;
            }
        }

        //-------------------------------------------------------------------
        public C2iExpression FormulePreserveStateKey
        {
            get
            {
                return m_formulePreserveStateKey;
            }
            set
            {

                m_formulePreserveStateKey = value;
            }
        }

        //-------------------------------------------------------------------
        public CConfigCalqueMap[] ConfigsCalques
        {
            get
            {
                return m_listeConfigs.ToArray();
            }
            set
            {
                m_listeConfigs.Clear();
                if (value != null)
                {
                    foreach (CConfigCalqueMap config in value)
                        m_listeConfigs.Add(config);
                }
            }
        }

        //-------------------------------------------------------------------
        public CConfigCalqueMap GetConfigForCalque(CDbKey keyConfigMapDatabase)
        {
            //TESTDBKEYOK
            foreach (CConfigCalqueMap config in m_listeConfigs)
                if (config.KeyConfigMapDatabase == keyConfigMapDatabase)
                {
                    //Pour compatibilité des DbKey : réaffecte la clé
                    config.KeyConfigMapDatabase = keyConfigMapDatabase;
                    return config;
                }
            return null;
        }

        //-------------------------------------------------------------------
        private int GetNumVersion()
        {
            return 1;
            //Remplacement zoom par formule
            //ajoute des options de conservation de config
        }

        //-------------------------------------------------------------------
        public CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;

            result = serializer.TraiteObject<C2iExpression>(ref m_formuleLatitude);
            if (result)
                result = serializer.TraiteObject<C2iExpression>(ref m_formuleLongitude);
            if (result)
            {
                if (nVersion < 1)
                {
                    int nZoom = 0;
                    serializer.TraiteInt(ref nZoom);
                    m_formuleZoom = new C2iExpressionConstante(nZoom);
                }
            }
            if (result)
                result = serializer.TraiteListe<CConfigCalqueMap>(m_listeConfigs);
            if (!result )
                return result;
            if (nVersion >= 1)
            {
                serializer.TraiteBool(ref m_bPreserveCenter);
                serializer.TraiteBool(ref m_bPreserveLayers);
                serializer.TraiteBool(ref m_bPreserveMapMode);
                serializer.TraiteBool(ref m_bPreserveZoom);
                result = serializer.TraiteObject<C2iExpression>(ref m_formuleZoom);
                if (result)
                    result = serializer.TraiteObject<C2iExpression>(ref m_formulePreserveStateKey);
                if (!result)
                    return result;
            }
            return result;
        }
    }

    public interface IEditeurConfigWndMapView
	{
		CConfigWndMapView EditeConfig ( 
            CConfigWndMapView config, 
            CObjetPourSousProprietes objetEdite,
            IFournisseurProprietesDynamiques fournisseur );
		
	}

    //-------------------------------------------------------------------
    public class CConfigWndMapViewEditor : UITypeEditor
    {
        private static IEditeurConfigWndMapView m_editeur = null;
        private static CObjetPourSousProprietes m_objetEdite = null;
        private static IFournisseurProprietesDynamiques m_fournisseurProprietes = null;
        /// ///////////////////////////////////////////
        public CConfigWndMapViewEditor()
        {
        }

        /// ///////////////////////////////////////////
        public static void SetEditeur(IEditeurConfigWndMapView editeur)
        {
            m_editeur = editeur;
        }



        /// ///////////////////////////////////////////
        public static CObjetPourSousProprietes ObjetEdite
        {
            get
            {
                return m_objetEdite;
            }
            set
            {
                m_objetEdite = value;
            }
        }

        /// ///////////////////////////////////////////
        public static IFournisseurProprietesDynamiques FournisseurProprietes
        {
            get
            {
                return m_fournisseurProprietes;
            }
            set
            {
                m_fournisseurProprietes = value;
            }
        }

        /// ///////////////////////////////////////////
        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context,
            System.IServiceProvider provider,
            object value)
        {
            IEditeurConfigWndMapView editeur = m_editeur;
            object retour = editeur.EditeConfig(
                (CConfigWndMapView)value, 
                m_objetEdite,
                m_fournisseurProprietes);
            if (m_editeur == null && editeur is IDisposable)
                ((IDisposable)editeur).Dispose();
            return retour;
        }

        /// ///////////////////////////////////////////
        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            if (m_editeur == null)
                return UITypeEditorEditStyle.None;
            return UITypeEditorEditStyle.Modal;
        }
    }
}
