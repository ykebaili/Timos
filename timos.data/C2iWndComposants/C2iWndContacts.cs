using System;
using System.Drawing;
using System.Collections;
using System.Drawing.Design;

using sc2i.common;
using sc2i.formulaire;
using System.Collections.Generic;
using timos.data;

namespace sc2i.formulaire
{
    /// <summary>
    /// Description résumée de C2iWndContacts.
    /// </summary>
    [WndName("Contacts")]
    public class C2iWndContacts : C2iWndLabel
    {

        public C2iWndContacts()
        {
            Font = new Font("Arial", 8, FontStyle.Underline);
            ForeColor = Color.Blue;
        }

        /// ///////////////////////////////////////
        public override bool CanBeUseOnType(Type tp)
        {
            if (tp != null)
            {
                if (typeof(CIntervention).Equals(tp) ||
                    typeof(CPhaseTicket).Equals(tp))
                    return true;
            }
            return false;
        }

        /// ////////////////////////////////////
        private int GetNumVersion()
        {
            return 0;
        }

        /// ////////////////////////////////////
        protected override CResultAErreur MySerialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (result)
                result = base.MySerialize(serializer);
            if (!result)
                return result;
            

            return result;
        }

 


        /////////////////////////////////////////////////////////////////
        public override void OnDesignSelect(
            Type typeEdite,
            object objetEdite,
            sc2i.expression.IFournisseurProprietesDynamiques fournisseurProprietes)
        {
            base.OnDesignSelect(typeEdite, objetEdite, fournisseurProprietes);
        }


        public override CDescriptionEvenementParFormule[] GetDescriptionsEvenements()
        {
            List<CDescriptionEvenementParFormule> lst = new List<CDescriptionEvenementParFormule>();
            lst.AddRange(base.GetDescriptionsEvenements());
            
            return lst.ToArray();
        }


    }

 
}
