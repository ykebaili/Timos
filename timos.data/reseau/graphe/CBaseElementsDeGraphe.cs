
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace timos.data.reseau.graphe
{
    public class CBaseElementsDeGraphe<TypeObjets> : IEnumerable<TypeObjets>
        where TypeObjets : CComposantDeGrapheReseau
    {
        //Hashcode de l'objet ->object
        private Dictionary<int, TypeObjets> m_dicObjets = new Dictionary<int, TypeObjets>();
        private List<TypeObjets> m_listeObjets = new List<TypeObjets>();

        public void Add(TypeObjets objet)
        {
            if (!m_dicObjets.ContainsKey(objet.GetHashCode()))
            {
                m_listeObjets.Add(objet);
                m_dicObjets[objet.GetHashCode()] = objet;
            }
        }

        public TypeObjets GetObjet(Type typeNoeud, int nIdObjet, int nIdSchemaReseau)
        {
            TypeObjets objet = null;
            if (m_dicObjets.TryGetValue(CComposantDeGrapheReseau.CalcHashCode(typeNoeud, nIdObjet, nIdSchemaReseau), out objet))
                return objet;
            return objet;
        }

        public bool Contains(TypeObjets objet)
        {
            return m_dicObjets.ContainsKey(objet.GetHashCode());
        }

        public TypeObjets[] Objets
        {
            get
            {
                return m_listeObjets.ToArray();
            }
        }

        public void IntegreBase(CBaseElementsDeGraphe<TypeObjets> autreBase)
        {
            foreach (TypeObjets objet in autreBase.Objets)
                Add(objet);
        }

        public TypeObjets this[int nIndex]
        {
            get
            {
                return m_listeObjets[nIndex];
            }
            set
            {
                m_listeObjets[nIndex] = value;
            }
        }

        public int Count
        {
            get
            {
                return m_listeObjets.Count;
            }
        }

        public void Clear()
        {
            m_dicObjets.Clear();
            m_listeObjets.Clear();
        }

        internal void Remove(TypeObjets objet)
        {
            if (m_dicObjets.ContainsKey(objet.GetHashCode()))
                m_dicObjets.Remove(objet.GetHashCode());
            m_listeObjets.Remove(objet);
        }

        public void AddRange(IEnumerable<TypeObjets> lst)
        {
            foreach (TypeObjets obj in lst)
                Add(obj);
        }

        public TypeObjets[] ToArray()
        {
            return m_listeObjets.ToArray();
        }

        #region IEnumerable<TypeObjets> Membres

        public IEnumerator<TypeObjets> GetEnumerator()
        {
            return m_listeObjets.GetEnumerator();
        }

        #endregion

        #region IEnumerable Membres

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return m_listeObjets.GetEnumerator();
        }

        #endregion
    }
}
