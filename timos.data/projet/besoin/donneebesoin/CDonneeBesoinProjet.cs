using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using sc2i.data;
using sc2i.expression;

namespace timos.data.projet.besoin
{
    [Serializable]
    public class CDonneeBesoinProjet : IDonneeBesoin
    {
        private int? m_nIdTypeProjet = null;
        private double? m_fCoutSaisi = 0;
        private double m_fDureeJours = 1;
        private string m_strCleProjetTemplate = "";
        private C2iExpression m_formuleInitialisation = null;

        //---------------------------------------------------------------
        public CDonneeBesoinProjet()
        {
        }

        //---------------------------------------------------------
        public void InitFrom(CBesoin besoin, IDonneeBesoin donnee)
        {
            CoutSaisi = donnee.CalculeCout(besoin);
        }

        //---------------------------------------------------------
        public double DureeJours
        {
            get
            {
                return m_fDureeJours;
            }
            set
            {
                m_fDureeJours = value;
            }
        }

        //---------------------------------------------------------
        public C2iExpression FormuleInitialisation
        {
            get
            {
                return m_formuleInitialisation;
            }
            set
            {
                m_formuleInitialisation = value;
            }
        }


        //--------------------------------------------------------------
        public CTypeProjet GetTypeProjet(CContexteDonnee ctx)
        {
            if (m_nIdTypeProjet != null)
            {
                CTypeProjet tp = new CTypeProjet(ctx);
                if (tp.ReadIfExists(m_nIdTypeProjet.Value))
                    return tp;
            }
            return null;
        }

        //--------------------------------------------------------------
        public void SetTypePRojet(CTypeProjet tp)
        {
            if (tp == null)
                m_nIdTypeProjet = null;
            else
                m_nIdTypeProjet = tp.Id;
        }

        //---------------------------------------------------------------
        public double? CoutSaisi
        {
            get
            {
                return m_fCoutSaisi;
            }
            set
            {
                m_fCoutSaisi = value;
            }
        }

        //---------------------------------------------------------
        //Permet de retrouver un projet issu de ce besoin dans un projet parent
        public string CleProjetTemplate
        {
            get
            {
                return m_strCleProjetTemplate;
            }
            set
            {
                m_strCleProjetTemplate = value;
            }
        }

        //---------------------------------------------------------------
        public double? CalculeCout(CBesoin besoin)
        {
            if (besoin.HasChildren)
            {
                double fTotal = 0;
                foreach (CBesoin b in besoin.BesoinsFils)
                {
                    double? fCout = b.CoutSaisiTotalSansRegroupement;
                    if (fCout != null)
                        fTotal += fCout.Value;
                }
                return fTotal;
            }
            return CoutSaisi;
        }

        //---------------------------------------------------------------
        private int GetNumVersion()
        {
            return 2;
            //2 : ajout de la formule d'initialisation
        }

        //---------------------------------------------------------------
        public CResultAErreur Serialize(sc2i.common.C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            serializer.TraiteDoubleNullable(ref m_fCoutSaisi);
            serializer.TraiteIntNullable(ref m_nIdTypeProjet);
            serializer.TraiteDouble(ref m_fDureeJours);
            if ( nVersion >= 1 )
                serializer.TraiteString(ref m_strCleProjetTemplate);
            if (nVersion >= 2)
                serializer.TraiteObject<C2iExpression>(ref m_formuleInitialisation);
            return result;
        }

        //---------------------------------------------------------
        public string LibelleStatique
        {
            get { return I.T("Projet|20191"); }
        }

        //---------------------------------------------------------
        public bool CanApplyOn(CBesoin besoin)
        {
            return true;
        }

        //---------------------------------------------------------
        public ETypeDonneeBesoin TypeDonnee
        {
            get
            {
                return ETypeDonneeBesoin.Projet;
            }
        }

        //---------------------------------------------------------
        public char? ShortKey
        {
            get
            {
                string str = I.T("P|20190").ToUpper();
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
