using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common.memorydb;

namespace TimosInventory.data
{

    public class CIndexIdTimos<T> : Dictionary<int, T>
        where T : CEntiteLieeATimos
    {

        //------------------------------------------------------------------------
        public T GetSafe(int? nIdTimos)
        {
            T entite = null;
            if ( nIdTimos != null )
                TryGetValue(nIdTimos.Value, out entite);
            return entite;
        }

        //------------------------------------------------------------------------
        public static CIndexIdTimos<T> GetIdTimosIndex(CMemoryDb db)
        {
            CIndexIdTimos<T> dic = new CIndexIdTimos<T>();
            CListeEntitesDeMemoryDb<T> lst = new CListeEntitesDeMemoryDb<T>(db);
            foreach (T entite in lst)
            {
                if (entite.IdTimos != null)
                {
                    dic[entite.IdTimos.Value] = entite;
                }
            }
            return dic;
        }

        //------------------------------------------------------------------------
        public static CIndexIdTimos<CEntiteLieeATimos> GetIdTimosIndex(
            CMemoryDb db,
            Type typeObjets)
        {
            CIndexIdTimos<CEntiteLieeATimos> dic = new CIndexIdTimos<CEntiteLieeATimos>();
            CListeEntitesDeMemoryDbBase liste = new CListeEntitesDeMemoryDbBase(db, typeObjets);
            foreach (CEntiteLieeATimos entite in liste)
            {
                if (entite.IdTimos != null)
                    dic[entite.IdTimos.Value] = entite;
            }
            return dic;
        }


        
    }
}
