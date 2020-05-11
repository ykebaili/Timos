using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common.unites;
using sc2i.common;
using sc2i.data;

namespace timos.data.projet.besoin
{
    [Serializable]
    public class CDonneeBesoinTypeEquipement: IDonneeBesoin
    {
        private int m_nQuantite = 1;
        private int? m_nIdTypeEquipement = null;
        private bool m_bIsCoutTarif = true;
        private double? m_fCoutUnitaire = null;

        //--------------------------------------------------------------
        public void InitFrom(CBesoin besoin, IDonneeBesoin donnee)
        {
            CDonneeBesoinQuantiteCU dCU = donnee as CDonneeBesoinQuantiteCU;
            if (dCU != null)
            {
                if (dCU.Quantite != null)
                    Quantite = (int)dCU.Quantite.Valeur;
                if (dCU.CoutUnitaire != null)
                {
                    m_bIsCoutTarif = false;
                    CoutUnitaire = dCU.CoutUnitaire.Valeur;
                }
            }
        }

        //--------------------------------------------------------------
        public CTypeEquipement GetTypeEquipement(CContexteDonnee ctx)
        {
            if (m_nIdTypeEquipement != null)
            {
                CTypeEquipement tp = new CTypeEquipement(ctx);
                if (tp.ReadIfExists(m_nIdTypeEquipement.Value))
                    return tp;
            }
            return null;
        }

        //--------------------------------------------------------------
        public void SetTypeEquipement(CTypeEquipement tp)
        {
            if (tp == null)
                m_nIdTypeEquipement = null;
            else
                m_nIdTypeEquipement = tp.Id;
            if ( m_bIsCoutTarif )
                m_fCoutUnitaire = null;
        }

        //--------------------------------------------------------------
        public double? CalculeCout(CBesoin besoin)
        {
            double? fCU = CoutUnitaire;
            if (fCU != null)
            {
                return fCU * (double)m_nQuantite;
            }
            return null;
        }

        //--------------------------------------------------------------
        public int Quantite
        {
            get
            {
                return m_nQuantite;
            }
            set
            {
                m_nQuantite = value;
            }
        }

        //--------------------------------------------------------------
        //Indique si le coût unitaire vient d'un tarif
        //ou s'il est propre à ce besoin
        public bool IsCoutTarif
        {
            get
            {
                return m_bIsCoutTarif;
            }
            set
            {
                m_bIsCoutTarif = value;
            }
        }

        //--------------------------------------------------------------
        public double? CoutUnitaire
        {
            get
            {
                if (m_fCoutUnitaire == null)
                {
                    CTypeEquipement tp = GetTypeEquipement(CContexteDonneeSysteme.GetInstance());
                    if (tp != null)
                    {
                        m_fCoutUnitaire = tp.GetValuationForDate(DateTime.Now);
                    }
                }
                return m_fCoutUnitaire;
            }
            set
            {
                if (!IsCoutTarif)
                    m_fCoutUnitaire = value;
            }
        }

        

        //---------------------------------------------------------------
        private int GetNumVersion()
        {
            return 1;
        }

        //---------------------------------------------------------------
        public CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            serializer.TraiteInt(ref m_nQuantite);
            serializer.TraiteDoubleNullable(ref m_fCoutUnitaire);
            serializer.TraiteIntNullable(ref m_nIdTypeEquipement);
            serializer.TraiteBool(ref m_bIsCoutTarif);
            return result;
        }

        //---------------------------------------------------------
        public string LibelleStatique
        {
            get { return I.T("Equipment|20163"); }
        }

        //---------------------------------------------------------
        public bool CanApplyOn(CBesoin besoin)
        {
            return !besoin.HasChildren;
        }

        //---------------------------------------------------------
        public ETypeDonneeBesoin TypeDonnee
        {
            get
            {
                return ETypeDonneeBesoin.TypeEquipement;
            }
        }

        //---------------------------------------------------------
        public char? ShortKey
        {
            get
            {
                string str = I.T("E|20188").ToUpper();
                if (str.Length > 0)
                    return str[0];
                return null;
            }
        }

        //---------------------------------------------------------
        public bool PeutEtreParent
        {
            get
            {
                return false;
            }
        }
    }
}
