using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common.unites;
using sc2i.common;
using timos.data.equipement.consommables;
using sc2i.data;

namespace timos.data.projet.besoin
{
    [Serializable]
    public class CDonneeBesoinTypeConsommable : IDonneeBesoin
    {
        private CValeurUnite m_valeurQuantite;
        private CValeurUnite m_valeurCU;
        private int? m_nIdTypeConsommable = null;
        private bool m_bIsCoutTarif = true;

        //--------------------------------------------------------------
        public void InitFrom(CBesoin besoin, IDonneeBesoin donnee)
        {
            CDonneeBesoinTypeEquipement dT = donnee as CDonneeBesoinTypeEquipement;
            if (dT != null)
            {
                if (dT.Quantite != null)
                    Quantite = new CValeurUnite(dT.Quantite, "");
                if (dT.CoutUnitaire != null)
                    CoutUnitaire = new CValeurUnite(dT.CoutUnitaire.Value, "");
                return;
            }
            CDonneeBesoinQuantiteCU dQ = donnee as CDonneeBesoinQuantiteCU;
            if (dQ != null)
            {
                Quantite = dQ.Quantite;
                CoutUnitaire = dQ.CoutUnitaire;
                return;
            }
        }

        //--------------------------------------------------------------
        public double? CalculeCout(CBesoin besoin)
        {
            double? fValeur = null;
            CValeurUnite fCU = CoutUnitaire;
            if (m_valeurQuantite != null && fCU != null)
            {
                try
                {
                    CValeurUnite v = m_valeurQuantite * fCU;
                    fValeur = v.Valeur;
                }
                catch { }
            }
            return fValeur;
        }

        //--------------------------------------------------------------
        public CValeurUnite Quantite
        {
            get
            {
                return m_valeurQuantite;
            }
            set
            {
                m_valeurQuantite = value;
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
        public CTypeConsommable GetTypeConsommable(CContexteDonnee ctx)
        {
            if (m_nIdTypeConsommable != null)
            {
                CTypeConsommable tp = new CTypeConsommable(ctx);
                if (tp.ReadIfExists(m_nIdTypeConsommable.Value))
                    return tp;
            }
            return null;
        }

        //--------------------------------------------------------------
        public void SetTypeConsommable(CTypeConsommable tp)
        {
            if (tp == null)
                m_nIdTypeConsommable = null;
            else
                m_nIdTypeConsommable = tp.Id;

            if (tp != null && tp.Unite != null && m_valeurQuantite != null)
            {
                if (m_valeurQuantite.IUnite == null || 
                    m_valeurQuantite.IUnite.Classe.GlobalId !=
                    tp.Unite.Classe.GlobalId)
                {
                    m_valeurQuantite = new CValeurUnite(
                        m_valeurQuantite.Valeur,
                        tp.Unite.LibelleCourt);
                }
            }
            if (m_bIsCoutTarif)
                m_valeurCU = null;
        }

        //--------------------------------------------------------------
        public CValeurUnite CoutUnitaire
        {
            get
            {
                if (m_valeurCU == null)
                {
                    CTypeConsommable tp = GetTypeConsommable(CContexteDonneeSysteme.GetInstance());
                    if (tp != null)
                    {
                        m_valeurCU = new CValeurUnite(tp.GetValuationForDate(DateTime.Now, new CValeurUnite(1,"")), "/"+tp.Unite.LibelleCourt);
                    }
                }
                return m_valeurCU;
            }
            set
            {
                m_valeurCU = value;
            }
        }

        //---------------------------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //---------------------------------------------------------------
        public CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            result = serializer.TraiteObject<CValeurUnite>(ref m_valeurQuantite);
            if (result)
                result = serializer.TraiteObject<CValeurUnite>(ref m_valeurCU);
            serializer.TraiteIntNullable(ref m_nIdTypeConsommable);
            serializer.TraiteBool(ref m_bIsCoutTarif);
            return result;
        }

        //---------------------------------------------------------
        public virtual string LibelleStatique
        {
            get { return I.T("Consumable|20175"); }
        }

        //---------------------------------------------------------
        public virtual bool CanApplyOn(CBesoin besoin)
        {
            return !besoin.HasChildren;
        }

        //---------------------------------------------------------
        public virtual ETypeDonneeBesoin TypeDonnee
        {
            get
            {
                return ETypeDonneeBesoin.TypeConsommable;
            }
        }

        //---------------------------------------------------------
        public virtual char? ShortKey
        {
            get
            {
                string str = I.T("C|20187").ToUpper();
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
