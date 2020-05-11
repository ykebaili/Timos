using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.expression;
using sc2i.common;

namespace futurocom.snmp.expression
{
    [AutoExec("RegisterAllInAssembly")]
    public class CFormulesSupervision
    {
        /// ///////////////////////////////////////////////////////////
        public static void RegisterAllInAssembly()
        {
            foreach (Type tp in typeof(CFormulesSupervision).Assembly.GetTypes())
            {
                if (tp.IsSubclassOf(typeof(C2iExpression)) && !tp.IsAbstract)
                {
#if PDA
					C2iExpression exp = (C2iExpression)Activator.CreateInstance(tp);
#else
                    C2iExpression exp = (C2iExpression)Activator.CreateInstance(tp, new object[0]);
#endif
                    CAllocateur2iExpression.Register2iExpression(exp.IdExpression, tp);
                }
            }
        }
    }
}
