using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using timos.data;

namespace timos.data.projet.gantt
{
    public class CBaseGantt : IBaseGantt
    {
        private List<IElementDeGantt> m_elements = new List<IElementDeGantt>();

        
        public CBaseGantt(CElementDeGantt elementRacine)
        {
            AddElement(elementRacine);
        }

        private void AddElement(CElementDeGantt element)
        {
            if ( !m_elements.Contains ( element ) )
                m_elements.Add(element);
            foreach (CElementDeGantt elt in element.ElementsFils)
                AddElement(elt);
        }

        public IEnumerable<IElementDeGantt> GetElements()
        {
            return m_elements.AsReadOnly();
        }

        public void AppliqueParametreDessin(CParametreDessinLigneGantt parametre)
        {
            foreach (CElementDeGantt elt in GetElements())
                elt.AppliqueParametrageDessin(parametre);
        }

        private void RefreshDates()
        {
            foreach (IElementDeGantt elt in m_elements)
                elt.DatesAreDirty = true;
        }

        

    }
}
