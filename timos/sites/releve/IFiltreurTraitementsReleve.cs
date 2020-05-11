using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using timos.data;

namespace timos.sites.releve
{
    public interface IFiltreurTraitementsReleve
    {
       bool IsVisible(CTraitementReleveEquipement traitement);
    }
}
