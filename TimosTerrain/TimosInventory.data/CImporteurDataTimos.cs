using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using System.Data;
using sc2i.common.memorydb;
using System.Collections;

namespace TimosInventory.data
{

    
    
    public static class CImporteurDataTimos
    {
        internal class CDependanceAImporter
        {
            public readonly DataRelation Relation = null;
            public CIndexIdTimos<CEntiteLieeATimos> Index = null;

            public CDependanceAImporter(DataRelation relation,
                CIndexIdTimos<CEntiteLieeATimos> index)
            {
                Relation = relation;
                Index = index;
            }
        }

        /// <summary>
        /// Importe des données issues de Timos
        /// </summary>
        /// <remarks></remarks>
        /// Lorsqu'on exporte une table dans Timos, via le WS, les
        /// relations sont remplacées par les ids des éléments Timos, il faut
        /// recaler les dépendances sur les entités du db passé.
        /// Par exemple, le WS qui récupère un site, remplace l'id du Type de site
        /// par l'id du type de site dans Timos. IntegreTableDepuisTimos va remplacer
        /// ces ids par les ids des éléments trouvés dans le DB et importer les lignes
        /// </remarks>
        /// <param name="table"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static CResultAErreur IntegreTableDepuisTimos(DataTable table,
            CMemoryDb db)
        {
            if (table == null)
                return CResultAErreur.True;
            bool bOldEnforce = db.EnforceConstraints;
            db.EnforceConstraints = false;
            Type tpElements = db.GetTypeForTable(table.TableName);
            DataTable tableDest = db.GetTable(tpElements);
            List<CDependanceAImporter> lstDependances = new List<CDependanceAImporter>();
            //Identifie les dépendances
            foreach (DataRelation rel in tableDest.ParentRelations)
            {
                if (rel.ParentTable.TableName != tableDest.TableName)//Ne gère pas les autorefs
                {
                    if (table.Columns.Contains(rel.ChildColumns[0].ColumnName))
                    {
                        Type tp = db.GetTypeForTable(rel.ParentTable.TableName);
                        CDependanceAImporter dep = new CDependanceAImporter(
                            rel,
                            CIndexIdTimos<CEntiteLieeATimos>.GetIdTimosIndex(db, tp));
                        lstDependances.Add(dep);
                    }
                }
            }

            foreach ( DataRow row in table.Rows )
            {
                bool bAllDeps = true;
                foreach ( CDependanceAImporter dep in lstDependances )
                {
                    object depId = row[dep.Relation.ChildColumns[0].ColumnName];
                   if ( depId != DBNull.Value )
                   {
                       int? nIdTimos = null;
                       try{
                           nIdTimos = Int32.Parse ( depId.ToString() );
                       }
                       catch{}

                       if ( nIdTimos != null )
                       {
                           CEntiteLieeATimos ett = null;
                           if ( dep.Index.TryGetValue ( nIdTimos.Value, out ett ) )
                               row[dep.Relation.ChildColumns[0].ColumnName] = ett.Id;
                           else
                           {
                               row[dep.Relation.ChildColumns[0].ColumnName] = DBNull.Value;
                           }
                       }
                       
                   }
                }
                if ( bAllDeps )
                    tableDest.ImportRow ( row );
            }
            db.EnforceConstraints = bOldEnforce;
            return CResultAErreur.True;
                    
        }
    }
}
