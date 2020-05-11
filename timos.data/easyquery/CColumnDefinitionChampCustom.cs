using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using futurocom.easyquery;
using sc2i.data.dynamic;
using sc2i.common;

namespace sc2i.data.dynamic.easyquery
{
    public class CColumnDefinitionChampCustom : IColumnDefinition
    {
        private ITableDefinition m_table = null;
        private int m_nIdChampCustom = -1;
        private Type m_typeDonnee = typeof(string);
        private string m_strNomColonne = "";

        //---------------------------------------------------
        public CColumnDefinitionChampCustom()
        {
        }

        //---------------------------------------------------
        public CColumnDefinitionChampCustom(ITableDefinition table,
            CChampCustom champ)
        {
            m_table = table;
            m_nIdChampCustom = champ != null ? champ.Id : -1;
            if (champ != null )
            {
                m_nIdChampCustom = champ.Id;
                m_strNomColonne = champ.Nom;
                m_typeDonnee = champ.TypeDonneeChamp.TypeDotNetAssocie;
            }
        }

        //---------------------------------------------------
        public int IdChampCustom
        {
            get
            {
                return m_nIdChampCustom;
            }
        }

        //---------------------------------------------------
        public string ColumnName
        {
            get
            {
                return m_strNomColonne;
            }
            set
            {
            }
        }

        //---------------------------------------------------
        public Type DataType
        {
            get
            {
                return m_typeDonnee;
            }
            set
            {
            }
        }

        //---------------------------------------------------
        public string Id
        {
            get 
            {
                return "#CHP_"+m_nIdChampCustom;
            }
        }

        //---------------------------------------------------
        public string ImageKey
        {
            get
            {
                return "";
            }
            set
            {
            }
        }

        //---------------------------------------------------
        public bool IsReadOnly
        {
            get
            {
                return true;
            }
            set
            {
            }
        }
        //---------------------------------------------------

        public ITableDefinition Table
        {
            get
            {
                return m_table;
            }
            set
            {
                m_table = value;
            }
        }

        //---------------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }


        //---------------------------------------------------
        public CResultAErreur Serialize(sc2i.common.C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion ( ref nVersion );
            if ( !result )
                return result;
            serializer.TraiteInt ( ref m_nIdChampCustom );
            serializer.TraiteString ( ref m_strNomColonne );
            serializer.TraiteType ( ref m_typeDonnee );
            return result;
        }
    }
}
