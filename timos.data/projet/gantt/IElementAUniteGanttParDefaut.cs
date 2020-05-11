using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timos.data.projet.gantt
{
    public interface IElementAUniteGanttParDefaut
    {
        EGanttTimeUnit UniteParDefaut { get; set; }
        int PrecisionParDefault { get; set; }
    }
}
