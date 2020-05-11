using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.data;
using sc2i.common;

namespace timos.data.sites.releve
{
    [Serializable]
    public abstract class CActionTraitementReleveEquipement : I2iSerializable
    {
        private CReleveEquipement m_releveEquipement = null;

        private CEquipement m_equipementParentPourFilsLorsDeLExecution = null;

        private string m_strInfo = "";
        
        //----------------------------------------------------------------------------------
        public  CActionTraitementReleveEquipement(
            CReleveEquipement releveEquipement
            )
        {
            m_releveEquipement = releveEquipement;
        }

        //----------------------------------------------------------------------------------
        public virtual string Info
        {
            get
            {
                return m_strInfo;
            }
            set
            {
                m_strInfo = value;
            }
        }

        //----------------------------------------------------------------------------------
        internal CEquipement EquipementParentPourTraitementsFils
        {
            get
            {
                if (m_equipementParentPourFilsLorsDeLExecution == null)
                    return ReleveEquipement.Equipement;
                return m_equipementParentPourFilsLorsDeLExecution;
            }
            set
            {
                m_equipementParentPourFilsLorsDeLExecution = value;
            }
        }

        //----------------------------------------------------------------------------------
        public abstract string Libelle { get; }

        //----------------------------------------------------------------------------------
        /// <summary>
        /// Indique s'il s'agit d'un action qui peut agir ou d'une action intermédiaire
        /// </summary>
        public abstract bool IsExecutable{get;}
        

        //----------------------------------------------------------------------------------
        public CReleveEquipement ReleveEquipement
        {
            get
            {
                return m_releveEquipement;
            }
            set
            {
                m_releveEquipement = value;
            }
        }

        //----------------------------------------------------------------------------------
        protected CListeObjetDonneeGenerique<CEquipement> ListeAvecMemeSerial
        {
            get
            {
                CListeObjetDonneeGenerique<CEquipement> lst = new CListeObjetDonneeGenerique<CEquipement>(ReleveEquipement.ContexteDonnee);
                if (ReleveEquipement.NumSerie.Trim().Length > 0)
                {
                    lst.Filtre = new CFiltreData(CEquipement.c_champNumSerie + " like @1",
                        ReleveEquipement.NumSerie.Trim());
                    if (ReleveEquipement.Equipement != null)
                        lst.Filtre = CFiltreData.GetAndFiltre(
                           lst.Filtre,
                           new CFiltreData(CEquipement.c_champId + "<>@1",
                               ReleveEquipement.Equipement.Id));
                }
                else
                    lst.Filtre = new CFiltreDataImpossible();
                return lst;
            }
        }

        //----------------------------------------------------------------------------------
        public abstract IEnumerable<CActionTraitementReleveEquipement> GetSousActionsPossibles();

        //----------------------------------------------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //----------------------------------------------------------------------------------
        public CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            serializer.TraiteString(ref m_strInfo);
            result = MySerialize(serializer);
            return result;
        }

        //----------------------------------------------------------------------------------
        protected abstract CResultAErreur MySerialize ( C2iSerializer serializer );

        //----------------------------------------------------------------------------------
        public abstract CResultAErreur ExecuteAction(
            CTraitementReleveEquipement traitementExecutant,
            CEquipement equipementParent,
            CContexteDonnee ctxDonnee);
    }

}
