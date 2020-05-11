using System;
using System.Collections.Generic;
using System.Text;
using timos.data.reseau.graphe;

namespace spv.data.VueAnimee
{
    /// <summary>
    /// Contient un site départ et un site Arrivée
    /// </summary>
    public class CPointAPointDeGraphe : IEquatable<CPointAPointDeGraphe>
    {
        private CNoeudDeGrapheReseau m_noeudDepart;
        private CNoeudDeGrapheReseau m_noeudArrivee;

        private int m_nHashCode = 0;

        public CPointAPointDeGraphe( 
            CNoeudDeGrapheReseau noeudDepart, 
            CNoeudDeGrapheReseau noeudArrive )
        {
            m_noeudArrivee = noeudArrive;
            m_noeudDepart = noeudDepart;
            m_nHashCode = (NoeudArrive.IdObjet.ToString() + "_" + NoeudDepart.IdObjet.ToString()).GetHashCode();
        }

        public CNoeudDeGrapheReseau NoeudDepart
        {
            get
            {
                return m_noeudDepart;
            }
        }

        public CNoeudDeGrapheReseau NoeudArrive
        {
            get
            {
                return m_noeudArrivee;
            }
        }


        public override int GetHashCode()
        {
            return m_nHashCode;
        }

        #region IEquatable<CPointAPointDeGraphe> Membres

        public bool Equals(CPointAPointDeGraphe other)
        {
            return other.GetHashCode() == GetHashCode();
        }

        #endregion
    }

    public class CBaseCheminsPointAPoint : Dictionary<CPointAPointDeGraphe, List<CCheminDeGrapheReseau>>
    {
        public void AddChemin ( CPointAPointDeGraphe pap, CCheminDeGrapheReseau chemin )
        {
            List<CCheminDeGrapheReseau> lst = null;
            if ( !TryGetValue ( pap, out lst ))
            {
                lst = new List<CCheminDeGrapheReseau>();
                this[pap] = lst;
            }
            lst.Add ( chemin );
        }

        public void AddChemins ( CPointAPointDeGraphe pap, List<CCheminDeGrapheReseau> lstToAdd )
        {
            List<CCheminDeGrapheReseau> lst = null;
            if ( !TryGetValue ( pap, out lst ) )
            {
                lst = new List<CCheminDeGrapheReseau>();
                this[pap] = lstToAdd;
            }
            lstToAdd.AddRange ( lstToAdd );
        }

        public CCheminDeGrapheReseau[] GetChemins ( CPointAPointDeGraphe pap )
        {
            List<CCheminDeGrapheReseau> lst = null;
            if ( !TryGetValue ( pap, out lst ) )
                return new CCheminDeGrapheReseau[0];
            return lst.ToArray();
        }
    }

}
