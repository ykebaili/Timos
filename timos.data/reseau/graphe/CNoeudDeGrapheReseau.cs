using System;
using System.Collections.Generic;
using System.Text;
using sc2i.data;

namespace timos.data.reseau.graphe
{

    //--------------------------------------------
    //--------------------------------------------
    //--------------------------------------------
    //--------------------------------------------
    /// <summary>
    /// Classe de base pour les noeuds de graphe
    /// </summary>
    public abstract class CNoeudDeGrapheReseau : CComposantDeGrapheReseau, IEquatable<CNoeudDeGrapheReseau>
    {
        public CNoeudDeGrapheReseau(int nIdElement, int nIdSchema)
            : base(nIdElement, nIdSchema)
        {
        }



        public bool Equals(CNoeudDeGrapheReseau other)
        {
            return other.GetType() == GetType() && other.IdObjet == IdObjet;
        }
    }


    //--------------------------------------------
    //--------------------------------------------
    //--------------------------------------------
    //--------------------------------------------
    /// <summary>
    /// Noeud de graphe représentant un site
    /// </summary>
    public class CNoeudDeGrapheReseauSite : CNoeudDeGrapheReseau, IEquatable<CNoeudDeGrapheReseauSite>
    {
        bool m_bIsCable = false;

        public CNoeudDeGrapheReseauSite(int nIdElement, int nIdSchema, bool bIsCable)
            :base ( nIdElement, nIdSchema )
        {
            m_bIsCable = bIsCable;
        }


        public int IdSite
        {
            get
            {
                return IdObjet;
            }
        }


        #region IEquatable<CNoeudDeGrapheReseau> Membres

        public bool Equals(CNoeudDeGrapheReseauSite other)
        {
            return IdSchemaReseau == other.IdSchemaReseau && IdSite == other.IdSite;
        }

        #endregion

        public override IElementDeSchemaReseau GetElementAssocie(CContexteDonnee contexte)
        {
            CSite site = new CSite(contexte);
            if (site.ReadIfExists(IdSite))
                return site;
            return null;
        }

        /// <summary>
        /// Indique si le site a un cablage
        /// </summary>
        public bool IsCable
        {
            get
            {
                return m_bIsCable;
            }
            set
            {
                m_bIsCable = value;
            }
        }
    }


    //--------------------------------------------
    //--------------------------------------------
    //--------------------------------------------
    //--------------------------------------------
    /// <summary>
    /// Noeud de graphe représentant un équipement
    /// </summary>
    public class CNoeudDeGrapheReseauEquipement : CNoeudDeGrapheReseau, IEquatable<CNoeudDeGrapheReseauEquipement>
    {
        public CNoeudDeGrapheReseauEquipement(int nIdEquipement, int nIdSchemaReseau)
            : base(nIdEquipement, nIdSchemaReseau)
        {
        }

        public int IdEquipement
        {
            get
            {
                return IdObjet;
            }
        }

        #region IEquatable<CNoeudDeGrapheReseauEquipement> Membres

        public bool Equals(CNoeudDeGrapheReseauEquipement other)
        {
            return IdSchemaReseau == other.IdSchemaReseau && IdEquipement == other.IdEquipement;
        }

        #endregion

        public override IElementDeSchemaReseau GetElementAssocie(CContexteDonnee contexte)
        {
            CEquipementLogique eqpt = new CEquipementLogique(contexte);
            if (eqpt.ReadIfExists(IdEquipement))
                return eqpt;
            return null;
        } 
    }
}
