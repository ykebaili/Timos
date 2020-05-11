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
    public class CDonneeBesoinTypeOperation: IDonneeBesoin
    {
        private int m_nQuantite = 1;
        private int? m_nIdTypeOperation = null;
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
        public CTypeOperation GetTypeOperation(CContexteDonnee ctx)
        {
            if (m_nIdTypeOperation != null)
            {
                CTypeOperation tp = new CTypeOperation(ctx);
                if (tp.ReadIfExists(m_nIdTypeOperation.Value))
                    return tp;
            }
            return null;
        }

        //--------------------------------------------------------------
        public void SetTypeOperation(CTypeOperation tp)
        {
            if (tp == null)
                m_nIdTypeOperation = null;
            else
                m_nIdTypeOperation = tp.Id;
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
                    CTypeOperation tp = GetTypeOperation(CContexteDonneeSysteme.GetInstance());
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
            serializer.TraiteIntNullable(ref m_nIdTypeOperation);
            serializer.TraiteBool(ref m_bIsCoutTarif);
            return result;
        }

        //---------------------------------------------------------
        public string LibelleStatique
        {
            get { return I.T("Operation|20181"); }
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
                return ETypeDonneeBesoin.Operation;
            }
        }

        //---------------------------------------------------------
        public char? ShortKey
        {
            get
            {
                string str = I.T("O|20189").ToUpper();
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
                return true;
            }
        }
    }
}
