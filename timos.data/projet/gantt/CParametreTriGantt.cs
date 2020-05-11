using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using sc2i.expression;

namespace timos.data.projet.gantt
{
    //Paramètre de tri Gantt
    public class CParametreTriGantt : I2iSerializable, IComparer<IElementDeGantt>
    {
        private IOptimiseurGetValueDynamic m_optimiseur = null;
        private bool m_bOptimiseurSet = false;
        private CDefinitionProprieteDynamique m_propriete = null;
        private bool m_bDecroissant = false;

        //Chainage de paramètres : tri sur le premier, puis sur celui contenu dans le premier
        //etc...
        private CParametreTriGantt m_parametreSuivant = null;

        public CParametreTriGantt()
        {
        }

        //----------------------------------------------------
        public CDefinitionProprieteDynamique Propriete
        {
            get
            {
                return m_propriete;
            }
            set
            {
                m_propriete = value;
                m_bOptimiseurSet = false;
                m_optimiseur = null;
            }
        }

        //----------------------------------------------------
        public CParametreTriGantt ParametreSuivant
        {
            get
            {
                return m_parametreSuivant;
            }
            set
            {
                m_parametreSuivant = value;
            }
        }

        //----------------------------------------------------
        public bool Decroissant
        {
            get
            {
                return m_bDecroissant;
            }
            set
            {
                m_bDecroissant = value;
            }
        }

        //----------------------------------------------------
        public int Compare(IElementDeGantt elt1, IElementDeGantt elt2)
        {
            int nResult = 0;
            if (m_propriete == null)
            {
                if (elt1 != null && elt2 != null)
                    nResult = elt1.IndexTri.CompareTo(elt2.IndexTri);
                if (nResult == 0)
                    nResult = elt1.DateDebut.CompareTo(elt2.DateDebut);
            }
            else
            {
                if (!m_bOptimiseurSet)
                {
                    m_optimiseur = CInterpreteurProprieteDynamique.GetOptimiseur(elt1.GetType(), m_propriete.NomPropriete);
                    m_bOptimiseurSet = true;
                }
                try
                {
                    object val1 = null;
                    object val2 = null;
                    if (m_optimiseur != null)
                    {
                        val1 = m_optimiseur.GetValue(elt1);
                        val2 = m_optimiseur.GetValue(elt2);
                    }
                    else
                    {
                        val1 = CInterpreteurProprieteDynamique.GetValue(elt1, m_propriete);
                        val2 = CInterpreteurProprieteDynamique.GetValue(elt2, m_propriete);
                    }
                    if (val1 == val2)
                    {
                        if (m_parametreSuivant != null)
                            return m_parametreSuivant.Compare(elt1, elt2);
                        return 0;
                    }
                    nResult = 0;
                    if (val1 is IComparable)
                        nResult = ((IComparable)val1).CompareTo(val2);
                }
                catch { }
            }
            if (m_bDecroissant)
                nResult = -nResult;
            return nResult;
        }

        //-------------------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //-------------------------------------------------------
        public CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            serializer.TraiteBool(ref m_bDecroissant);
            result = serializer.TraiteObject<CDefinitionProprieteDynamique>(ref m_propriete);
            if (!result)
                return result;

            result = serializer.TraiteObject<CParametreTriGantt>(ref m_parametreSuivant);
            if (!result)
                return result;

            return result;
        }
            
    }
}
