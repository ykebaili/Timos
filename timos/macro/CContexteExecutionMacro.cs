using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.data;

namespace sc2i.data.dynamic.Macro
{
    public class CContexteExecutionMacro
    {
        private CContexteDonnee m_contexteDonnee;
        private CObjetDonnee m_cible;

        //---------------------------------------------------
        public CContexteExecutionMacro(CObjetDonnee cible)
            : this(cible, cible != null ? cible.ContexteDonnee : null)
        {
        }
            

        //---------------------------------------------------
        public CContexteExecutionMacro(CObjetDonnee cible,
            CContexteDonnee contexteDonnee)
        {
            m_cible = cible;
            m_contexteDonnee = contexteDonnee;
        }

        //---------------------------------------------------
        public CObjetDonnee Cible
        {
            get
            {
                return m_cible;
            }
        }

        //---------------------------------------------------
        public CContexteDonnee ContexteDonnee
        {
            get
            {
                return m_contexteDonnee;
            }
        }
    }
}
