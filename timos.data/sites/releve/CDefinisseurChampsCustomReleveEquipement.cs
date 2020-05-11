using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.data.dynamic;
using sc2i.data;

namespace timos.data.sites.releve
{
    public class CDefinisseurChampsCustomReleveEquipement : IDefinisseurChampCustom
    {
        private CContexteDonnee m_contexte = null;

        //----------------------------------------------------------------------
        public CDefinisseurChampsCustomReleveEquipement(CContexteDonnee ctx)
        {
            m_contexte = ctx;
        }

        //----------------------------------------------------------------------
        public CContexteDonnee ContexteDonnee
        {
            get { return m_contexte; }
        }

        //----------------------------------------------------------------------
        public string DescriptionElement
        {
            get
            {
                return "";
            }
        }

        //----------------------------------------------------------------------
        public int Id
        {
            get { return 0; }
        }

        //----------------------------------------------------------------------
        public IRelationDefinisseurChamp_ChampCustom[] RelationsChampsCustomDefinis
        {
            get 
            { 
                CListeObjetDonneeGenerique<CChampCustom> lst = new CListeObjetDonneeGenerique<CChampCustom>(m_contexte);
                lst.Filtre = CChampCustom.GetFiltreChampsForRole ( CReleveEquipement.c_roleChampCustom );
                List<IRelationDefinisseurChamp_ChampCustom> lstDefs = new List<IRelationDefinisseurChamp_ChampCustom>();
                foreach ( CChampCustom champ in lst )
                {
                    lstDefs.Add ( new CRelationDefinisseurReleveEquipement_ChampCustom ( this, champ ));
                }
                return lstDefs.ToArray();

            }
        }

        //----------------------------------------------------------------------
        public IRelationDefinisseurChamp_Formulaire[] RelationsFormulaires
        {
            get { return new IRelationDefinisseurChamp_Formulaire[0]; }
        }

        //----------------------------------------------------------------------
        public CRoleChampCustom RoleChampCustomDesElementsAChamp
        {
            get { return CRoleChampCustom.GetRole(CReleveEquipement.c_roleChampCustom); }
        }

        //----------------------------------------------------------------------
        public CChampCustom[] TousLesChampsAssocies
        {
            get { 
                List<CChampCustom> lst = new List<CChampCustom>();
                foreach ( IRelationDefinisseurChamp_ChampCustom rel in RelationsChampsCustomDefinis )
                    lst.Add ( rel.ChampCustom );
                return lst.ToArray();
            }
        }

    }

    //----------------------------------------------------------------------
    public class CRelationDefinisseurReleveEquipement_ChampCustom : IRelationDefinisseurChamp_ChampCustom
    {
        private CChampCustom m_champ = null;
        private IDefinisseurChampCustom m_definisseur = null;

        //---------------------------------------------------------------------------
        public CRelationDefinisseurReleveEquipement_ChampCustom(IDefinisseurChampCustom definisseur, CChampCustom champ)
        {
            m_definisseur = definisseur;
            m_champ = champ;
        }

        //---------------------------------------------------------------------------
        public CChampCustom ChampCustom
        {
            get
            {
                return m_champ;
            }
            set
            {
                m_champ = value;
            }
        }

        //---------------------------------------------------------------------------
        public IDefinisseurChampCustom Definisseur
        {
            get
            {
                return m_definisseur;
            }
            set
            {
                m_definisseur = value;
            }
        }

        //---------------------------------------------------------------------------
        public int Ordre
        {
            get
            {
                return 0;
            }
            set
            {
                
            }
        }

        //---------------------------------------------------------------------------
        public int CompareTo(object obj)
        {
            IRelationDefinisseurChamp_ChampCustom rel = obj as IRelationDefinisseurChamp_ChampCustom;
            if ( rel == null )
                return -1;
            if ( rel.ChampCustom == ChampCustom && rel.Definisseur == Definisseur )
                return 0;
            return -1;
        }

        
    }



}
