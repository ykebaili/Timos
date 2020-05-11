using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using sc2i.common;
using sc2i.expression;
using futurocom.easyquery.snmp;
using futurocom.easyquery;
using futurocom.snmp.easyquery;

namespace futurocom.snmp.entitesnmp
{
    [Serializable]
    public class CChampEntiteFromQuery : I2iSerializable, IChampEntiteSNMP
    {
        private IColumnDeEasyQuery m_colonneSource = null;
        private bool m_bIsReadOnly = false;
        private string m_strDescription = "";
        private bool m_bNoUpdate = false;//Indique que ce champ n'est jamais relu depuis SNMP

        private C2iExpression m_formuleIndex = null;

        //------------------------------------
        public CChampEntiteFromQuery()
        {
        }

        //------------------------------------
        public IColumnDeEasyQuery ColonneSource
        {
            get
            {
                return m_colonneSource;
            }
        }

        //------------------------------------
        public string NomChamp
        {
            get
            {
                if ( m_colonneSource != null )
                    return m_colonneSource.ColumnName;
                return "";
            }
            set
            {
            }
        }

        //------------------------------------
        public string Description
        {
            get
            {
                return m_strDescription;
            }
            set
            {
                m_strDescription = value;
            }
        }

        //------------------------------------
        public bool IsReadOnly
        {
            get{
                return m_bIsReadOnly;
            }
            set{
                m_bIsReadOnly = value;
            }
        }

        //------------------------------------
        public bool NoUpdateFromSnmp
        {
            get
            {
                return m_bNoUpdate;
            }
            set
            {
                m_bNoUpdate = value;
            }
        }
        
        //------------------------------------
        public ETypeChampBasique TypeChamp
        {
            get
            {
                if (m_colonneSource != null)
                    return CTypeChampBasique.GetTypeChamp(m_colonneSource.DataType);
                return ETypeChampBasique.String;

            }
            set
            {
                
            }
        }

        //------------------------------------
        public string Id
        {
            get
            {
                if (m_colonneSource != null)
                    return m_colonneSource.Id;
                return "";
            }
        }

       
        //------------------------------------
        public C2iExpression FormuleIndex
        {
            get
            {
                return m_formuleIndex;
            }
            set
            {
                m_formuleIndex = value;
            }
        }

        
        //------------------------------------
        private int GetNumVersion()
        {
            return 1;
        }

        //------------------------------------
        public CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;

            result = serializer.TraiteObject<IColumnDeEasyQuery>(ref m_colonneSource);

            serializer.TraiteString(ref m_strDescription);

            serializer.TraiteBool ( ref m_bIsReadOnly );

            result = serializer.TraiteObject<C2iExpression>(ref m_formuleIndex);

            if (nVersion >= 1)
                serializer.TraiteBool(ref m_bNoUpdate);
            else
                m_bNoUpdate = false;

            if (!result)
                return result;
            return result;
        }

        public void InitFromColonneSource(IColumnDeEasyQuery colonne, CODEQBase objetDeQuery)
        {
            m_colonneSource = colonne;

            CEasyQuery query = objetDeQuery.Query;
            if (query != null)
            {
                //cherche la source
                ITableDefinition tableDef = null;
                IColumnDefinition colDef = null;
                IsReadOnly = true;
                Description = "";
                if (query.FindSource(colonne, objetDeQuery, out tableDef, out colDef))
                {
                    CColumnDefinitionSNMP colSnmp = colDef as CColumnDefinitionSNMP;
                    if (colSnmp != null)
                    {
                        if (tableDef is CTableDefinitionSNMP ||
                            tableDef is CTableDefinitionSnmpOfScalar)
                        {
                            Description = colSnmp.Description;
                            IsReadOnly = colSnmp.IsReadOnly;
                        }
                    }
                }
            }
        }

        //---------------------------------------------
        public CResultAErreur VerifieDonnees()
        {
            CResultAErreur result = CResultAErreur.True;
            if ( NomChamp.Length == 0 )
                result.EmpileErreur (I.T("Please, type a field name|20093") );
            return result;
        }
    }
}
