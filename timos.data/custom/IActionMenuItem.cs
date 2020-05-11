using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.formulaire;
using sc2i.expression;
using sc2i.common;

namespace sc2i.custom
{
    public interface IMenuItem : I2iSerializable
    {
        int NumeroOrdre { get; set; }
        string Libelle { get; set; }
        
        C2iExpression FormuleCondition { get; set; }
    }

    public class CActionMenuItemComparer : IComparer<IMenuItem>
    {

        public int Compare(IMenuItem x, IMenuItem y)
        {
            if (x != null && y != null )
                return x.NumeroOrdre.CompareTo(y.NumeroOrdre);
            return 0;
        }


    }

}
