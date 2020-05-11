using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace timos.data.reseau.arbre_operationnel
{
    public class CElementDeArbreOperationnelTrue : CElementDeArbreOperationnel
    {
        public CElementDeArbreOperationnelTrue(CElementDeArbreOperationnel elementParent)
            : base(elementParent)
        {
        }

        public override void Simplifier()
        {
            return;
        }

        public override string GetKeyFactorisation()
        {
            return "TRUE";
        }

        public override string GetFullKey()
        {
            return GetKeyFactorisation();
        }

        protected override void MyRecalculeCoefOperationnelFromChilds()
        {
            SetCoeffOperationnel(1.0);
        }

        public override IEnumerable<CElementDeArbreOperationnel> Fils
        {
            get
            {
                return new CElementDeArbreOperationnel[0];
            }
        }
    }
}
