using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using futurocom.supervision.alarmes;

namespace futurocom.supervision
{
    public interface IParametrageFiltrageAlarmes
    {
        bool Enabled { get; }
        DateTime DateDebutValidite { get; }
        DateTime DateFinValidite { get; }
        int Priorite { get; }
        CParametreFiltrageAlarmes Parametre { get; }

        bool ShouldMask(IAlarme alarme, DateTime dateApplication);
    }


    public static class CUtilMasquageAlarmes
    {
        public static IParametrageFiltrageAlarmes GetParametreAAppliquer(
            IAlarme alarme,
            DateTime dateApplication,
            IEnumerable<IParametrageFiltrageAlarmes> parametrages)
        {
            IParametrageFiltrageAlarmes parametreRetenu = null;
            foreach (IParametrageFiltrageAlarmes parametre in parametrages)
            { 
                if (parametre.ShouldMask(alarme, dateApplication))
                {
                    if (parametreRetenu == null ||
                        parametre.Priorite < parametre.Priorite)
                        parametreRetenu = parametre;
                }
            }
            return parametreRetenu;
        }
    }

}
