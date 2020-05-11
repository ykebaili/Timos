using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using sc2i.expression;
using sc2i.data;

namespace timos.securite
{
    [Serializable]
    public class CParametreDroitEditionType : I2iSerializable
    {
        [Serializable]
        public class CCoupleFormuleToGroupeRestrictions : I2iSerializable
        {
            private int m_nIdGroupeRestriction = -1;
            private C2iExpression m_formule = null;

            //--------------------------------------------------------
            public CCoupleFormuleToGroupeRestrictions()
            {
            }

            //--------------------------------------------------------
            public CCoupleFormuleToGroupeRestrictions(C2iExpression formule, int nIdGroupeRestrictions)
            {
                m_nIdGroupeRestriction = nIdGroupeRestrictions;
                m_formule = formule;
            }

            //--------------------------------------------------------
            public C2iExpression Formule
            {
                get
                {
                    return m_formule;
                }
                set
                {
                    m_formule = value;
                }
            }

            //--------------------------------------------------------
            public int IdGroupeRestriction
            {
                get
                {
                    return m_nIdGroupeRestriction;
                }
                set
                {
                    m_nIdGroupeRestriction = value;
                }
            }

            //--------------------------------------------------------
            public CGroupeRestrictionSurType GetGroupeRestrictions(CContexteDonnee contexte)
            {
                CGroupeRestrictionSurType groupe = new CGroupeRestrictionSurType(contexte);
                if (!groupe.ReadIfExists(m_nIdGroupeRestriction))
                    groupe = null;
                return groupe;
            }

            //--------------------------------------------------------
            public void SetGroupeRestrictions(CGroupeRestrictionSurType groupe)
            {
                if (groupe == null)
                    m_nIdGroupeRestriction = -1;
                else
                    m_nIdGroupeRestriction = groupe.Id;
            }


            //--------------------------------------------------------
            private int GetNumVersion()
            {
                return 0;
            }

            //--------------------------------------------------------
            public CResultAErreur Serialize(C2iSerializer serializer)
            {
                int nVersion = GetNumVersion();
                CResultAErreur result = serializer.TraiteVersion(ref nVersion);
                if (!result)
                    return result;
                serializer.TraiteInt(ref m_nIdGroupeRestriction);
                result = serializer.TraiteObject<C2iExpression>(ref m_formule);
                return result;
            }

            //--------------------------------------------------------
            public CResultAErreur VerifieDonnees()
            {
                CResultAErreur result=  CResultAErreur.True;
                if ( m_formule == null || m_formule.TypeDonnee == null)
                {
                    result.EmpileErreur(I.T("Restriction should have an activation formula|20192"));
                    return result;
                }
                if ( Formule.TypeDonnee.TypeDotNetNatif != typeof(bool) ||
                    Formule.TypeDonnee.IsArrayOfTypeNatif )
                {
                    result.EmpileErreur(I.T("Restriction formula must returns a boolean|20193"));
                    return result;
                }
                if ( m_nIdGroupeRestriction < 0 )
                {
                    result.EmpileErreur("Restriction must be associated to a restriction group|20194");
                    return result;
                }
                return result;
            }

        }

        private List<CCoupleFormuleToGroupeRestrictions> m_listeCouples = new List<CCoupleFormuleToGroupeRestrictions>();

        //--------------------------------------------------------
        public CParametreDroitEditionType()
        {
        }

        //--------------------------------------------------------
        public void AddFormule(C2iExpression formule, int nIdGroupeRestrictions)
        {
            AddFormule(new CCoupleFormuleToGroupeRestrictions(formule, nIdGroupeRestrictions));
        }

        //--------------------------------------------------------
        public void AddFormule(CCoupleFormuleToGroupeRestrictions couple)
        {
            m_listeCouples.Add(couple);
        }

        //--------------------------------------------------------
        public void Reset()
        {
            m_listeCouples.Clear();
        }

        //--------------------------------------------------------
        public void RemoveCouple(CCoupleFormuleToGroupeRestrictions couple)
        {
            m_listeCouples.Remove(couple);
        }

        //--------------------------------------------------------
        public IEnumerable<CCoupleFormuleToGroupeRestrictions> CouplesFormuleGroupe
        {
            get{
                return m_listeCouples.AsReadOnly();
            }
        }

        //--------------------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //--------------------------------------------------------
        public CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result) return result;
            result = serializer.TraiteListe<CCoupleFormuleToGroupeRestrictions>(m_listeCouples);
            return result;
        }

        //--------------------------------------------------------
        public CResultAErreur VerifieDonnees()
        {
            CResultAErreur result = CResultAErreur.True;
            foreach ( CCoupleFormuleToGroupeRestrictions couple in m_listeCouples )
            {
                result &= couple.VerifieDonnees();
                if ( !result )
                    return result;
            }
            return result;
        }


        //--------------------------------------------------------
        public CListeRestrictionsUtilisateurSurType GetRestrictions(CObjetDonnee objet)
        {
            CContexteEvaluationExpression ctx = new CContexteEvaluationExpression(objet);
            CListeRestrictionsUtilisateurSurType restrictions = new CListeRestrictionsUtilisateurSurType();
            foreach (CCoupleFormuleToGroupeRestrictions couple in m_listeCouples)
            {
                if (couple.Formule != null)
                {
                    CResultAErreur result = couple.Formule.Eval(ctx);
                    if (result && result.Data is bool)
                    {
                        if ((bool)result.Data)
                        {
                            CGroupeRestrictionSurType groupe = new CGroupeRestrictionSurType(objet.ContexteDonnee);
                            if (groupe.ReadIfExists(couple.IdGroupeRestriction))
                            {
                                restrictions.Combine(groupe.ListeRestrictions);
                            }
                        }
                    }
                }
            }
            return restrictions;
        }
                
    }
}
