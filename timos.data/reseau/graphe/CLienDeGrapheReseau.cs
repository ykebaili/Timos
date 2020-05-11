using System;
using System.Collections.Generic;
using System.Text;
using sc2i.data;

namespace timos.data.reseau.graphe
{
    public class CLienDeGrapheReseau : CComposantDeGrapheReseau, IEquatable<CLienDeGrapheReseau>
    {
        private CEtapesExtremiteLienDeGraphe m_etapesNoeudDepart = null;
        private CNoeudDeGrapheReseau m_noeudDepart = null;

        private CEtapesExtremiteLienDeGraphe m_etapesNoeudArrivee = null;
        private CNoeudDeGrapheReseau m_noeudArrive = null;


        public CLienDeGrapheReseau(
            int nIdLienReseau, int 
            nIdSchemaReseau, 
            CNoeudDeGrapheReseau noeudDepart, 
            CNoeudDeGrapheReseau noeudArrivee,
            CEtapesExtremiteLienDeGraphe etapesDepart,
            CEtapesExtremiteLienDeGraphe etapesArrivee)
            :base ( nIdLienReseau, nIdSchemaReseau )
        {
            m_noeudDepart = noeudDepart;
            m_noeudArrive = noeudArrivee;
            m_etapesNoeudArrivee = etapesArrivee;
            m_etapesNoeudDepart = etapesDepart;
        }

        public int IdLienReseau
        {
            get
            {
                return IdObjet;
            }
        }

        

        public CNoeudDeGrapheReseau NoeudDepart
        {
            get
            {
                return m_noeudDepart;
            }
        }

        public CEtapesExtremiteLienDeGraphe EtapesNoeudDepart
        {
            get
            {
                return m_etapesNoeudDepart;
            }
        }

        public CNoeudDeGrapheReseau NoeudArrive
        {
            get
            {
                return m_noeudArrive;
            }
        }

        public CEtapesExtremiteLienDeGraphe EtapesNoeudArrivee
        {
            get
            {
                return m_etapesNoeudArrivee;
            }
        }

        public override IElementDeSchemaReseau GetElementAssocie(CContexteDonnee contexte)
        {
            CLienReseau lien = new CLienReseau(contexte);
            if (lien.ReadIfExists(Math.Abs(IdObjet)))
                return lien;
            return null;
        }






        #region IEquatable<CLienDeGrapheReseau> Membres

        public bool Equals(CLienDeGrapheReseau other)
        {
            return IdSchemaReseau == other.IdSchemaReseau && IdLienReseau == other.IdLienReseau;
        }

        #endregion
    }
}
