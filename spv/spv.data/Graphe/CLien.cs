using System;
using System.Collections.Generic;
using System.Text;

namespace spv.data.Graphe
{
    public class CLien
    {
        private CSpvLiai m_liaison = null;
        private CNoeud m_noeudDepart = null;
        private CNoeud m_noeudArrivee = null;

        public CLien(CSpvLiai liaison, CNoeud noeudDepart, CNoeud noeudArrivee)
        {
            m_liaison = liaison;
            m_noeudArrivee = noeudArrivee;
            m_noeudDepart = noeudDepart;
        }

        public override int GetHashCode()
        {
            return m_liaison.Id;
        }

        public CSpvLiai Liaison
        {
            get
            {
                return m_liaison;
            }
        }

        public CNoeud NoeudDepart
        {
            get
            {
                return m_noeudDepart;
            }
        }

        public CNoeud NoeudArrivee
        {
            get
            {
                return m_noeudArrivee;
            }
        }

        public override bool Equals(object obj)
        {
            CLien lien = obj as CLien;
            if (lien != null)
                return lien.m_liaison.Id == m_liaison.Id;
            return false;
        }
    }
}
