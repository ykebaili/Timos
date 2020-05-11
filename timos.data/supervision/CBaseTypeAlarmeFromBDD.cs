using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using futurocom.supervision;
using sc2i.data;
using sc2i.common.memorydb;

namespace timos.data.supervision
{
    public class CBaseTypeAlarmeFromBDD : IBaseTypesAlarmes, IFournisseurElementsManquantsPourMemoryDb
    {
        private CMemoryDb m_database = null;
        private CContexteDonnee m_contexteDonnee = null;
        private Dictionary<string, CLocalTypeAlarme> m_dicTypesAlarmes = null;
        private List<CLocalTypeAlarme> m_listeTypes = new List<CLocalTypeAlarme>();

        //--------------------------------------------------------------
        public CBaseTypeAlarmeFromBDD(CContexteDonnee contexte,
            CMemoryDb database)
        {
            m_database = database;
            m_contexteDonnee = contexte;
        }

        //--------------------------------------------------------------
        private void AddType ( CLocalTypeAlarme tpSup )
        {
            m_listeTypes.Add ( tpSup );
            m_dicTypesAlarmes[tpSup.Id] = tpSup;
            foreach (CLocalTypeAlarme tpFils in tpSup.TypesFils )
                AddType(tpFils);
        }

        //--------------------------------------------------------------
        private void AssureTypes()
        {
            if ( m_dicTypesAlarmes != null )
                return;
            m_dicTypesAlarmes = new Dictionary<string, CLocalTypeAlarme>();
            CListeObjetDonneeGenerique<CTypeAlarme> lstTypes = new CListeObjetDonneeGenerique<CTypeAlarme>(m_contexteDonnee);
            lstTypes.Filtre = new CFiltreData ( CTypeAlarme.c_champIdTypeParent+" is null");
            foreach ( CTypeAlarme tp in lstTypes )
            {
                CLocalTypeAlarme tpSup = tp.GetTypeForSupervision(m_database, true);
                AddType ( tpSup );
            }
            m_listeTypes.Sort ( (t1,t2)=>t1.Libelle.CompareTo(t2.Libelle));
        }

        //--------------------------------------------------------------
        public IEnumerable<CLocalTypeAlarme> TypesAlarmes
        {
            get
            {
                AssureTypes();
                return m_listeTypes.AsReadOnly();
            }
        }

        //--------------------------------------------------------------
        public CLocalTypeAlarme GetTypeAlarme(string strIdTypeAlarme)
        {
            AssureTypes();
            CLocalTypeAlarme tp = null;
            m_dicTypesAlarmes.TryGetValue(strIdTypeAlarme, out tp);
            return tp;
        }

        //--------------------------------------------------------------
        public CEntiteDeMemoryDb GetEntite(Type typeEntite, string strId, CMemoryDb db)
        {
            if ( typeEntite == typeof(CLocalTypeAlarme) )
            {
                CLocalTypeAlarme ta = GetTypeAlarme ( strId );
                if ( ta != null )
                    ta = db.ImporteObjet(ta, true, false) as CLocalTypeAlarme;
                return ta;
            }
            return null;
        }

        //--------------------------------------------------------------
        public Type[] TypesFournis
        {
            get
            {
                return new Type[]{
            typeof(CLocalTypeAlarme)
            };
            }
        }

    }
}
