using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using sc2i.common.periodeactivation;

namespace futurocom.supervision.alarmes
{
    public class CParametreFiltrageAlarmes : I2iSerializable
    {

        IFiltreAlarme m_filtre = new CFiltreAlarme();
        IPeriodeActivation m_periode;

        public IFiltreAlarme Filtre
        {
            get
            {
                return m_filtre;
            }
            set
            {
                m_filtre = value;
            }
        }

        public IPeriodeActivation Periode
        {
            get
            {
                return m_periode;
            }
            set
            {
                m_periode = value;
            }
        }

        public bool ShouldMask(IAlarme alarme, DateTime dt)
        {
            if (m_filtre.IsInFiltre(alarme))
            {
                return IsDateInPeriode(dt);
            }
            return false;
        }

        public bool IsDateInPeriode(DateTime dt)
        {
            if (m_periode == null || m_periode.IsInPeriode(dt))
                return true;
            return false;
        }

        public int GetNumVersion()
        {
            return 0;
        }

        public CResultAErreur Serialize(C2iSerializer serializer)
        {
            CResultAErreur result = CResultAErreur.True;

            int nVersion = GetNumVersion();
            result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;

            result = serializer.TraiteObject<IFiltreAlarme>(ref m_filtre);
            if (result)
                result = serializer.TraiteObject<IPeriodeActivation>(ref m_periode);


            return result;
        }
    }
}
