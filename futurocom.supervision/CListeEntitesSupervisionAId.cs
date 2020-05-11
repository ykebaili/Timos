using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;

namespace futurocom.supervision
{
    [Serializable]
    public class CListeEntitesSupervisionAId<T> 
        where T : IEntiteSupervisionAId
    {
        private List<T> m_listeEntites = new List<T>();
        private Dictionary<string, T> m_dicIdToEntite = new Dictionary<string,T>();

        //--------------------------------------------------------
        public CListeEntitesSupervisionAId()
        {
        }

        //----------------------------------------------------------
        public T GetEntite(string strId)
        {
            T entite = default(T);
            m_dicIdToEntite.TryGetValue(strId, out entite);
            return entite;
        }

        //----------------------------------------------------------
        public IEnumerable<T> Entites
        {
            get
            {
                return m_listeEntites.AsReadOnly();
            }
        }

        //----------------------------------------------------------
        /// <summary>
        /// Met à jour ou crée un type d'agent
        /// </summary>
        /// <param name="typeAgent"></param>
        /// <returns></returns>
        public CResultAErreur UpdateEntite(T entite)
        {
            T oldEntite = GetEntite(entite.Id);
            if (oldEntite != null)
            {
                m_listeEntites.Remove(oldEntite);
            }

            m_listeEntites.Add(entite);
            m_dicIdToEntite[entite.Id] = entite;
            return CResultAErreur.True;
        }

        //----------------------------------------------------------
        public CResultAErreur RemoveEntite(T entite)
        {
            CResultAErreur result = CResultAErreur.True;
            m_listeEntites.Remove(entite);
            if (m_dicIdToEntite.ContainsKey(entite.Id))
                m_dicIdToEntite.Remove(entite.Id);
            return result;
        }

        //----------------------------------------------------------
        public CResultAErreur RemoveEntite(string strIdEntite)
        {
            CResultAErreur result = CResultAErreur.True;
            T entite = GetEntite(strIdEntite);
            if (entite != null)
                return RemoveEntite(entite);
            return result;
        }

    }
}
