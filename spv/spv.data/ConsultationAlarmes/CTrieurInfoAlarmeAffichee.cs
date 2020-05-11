using System;
using System.Collections.Generic;
using System.Text;

namespace spv.data.ConsultationAlarmes
{
    public class CTrieurInfoAlarmeAffichee : IComparer<CInfoAlarmeAffichee>
    {
        private bool m_bCroissant = true;

        public CTrieurInfoAlarmeAffichee(bool bCroissant)
        {
            m_bCroissant = bCroissant ;
        }

        public int Compare(CInfoAlarmeAffichee x, CInfoAlarmeAffichee y)
        {
            int nCompare = x.AlarmDate.CompareTo(y.AlarmDate);

            if (!m_bCroissant)
                nCompare = -nCompare;
            return nCompare;
        }

    }
}
