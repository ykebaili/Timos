using System;
using System.Collections.Generic;
using System.Text;

using sc2i.common;


namespace timos.data
{
    //Mode de gestion de l'état opérationnel d'un schéma
    public enum EModeOperationnelSchema
    {
        AllMandatory = 0, //Dés qu'un élément d'un schéma est HS, le schéma est HS
        AutomaticRedundancy = 1, //Si un chemin entre une entrée et une sortie est coupé, le schéma est HS. S'il existe des redondances, il n'est pas HS
        Custom = 2, // l'utilisateur définit manuellement le mode opérationnel de chaque chemin
        
    }

    public class CModeOperationnelSchema : CEnumALibelle<EModeOperationnelSchema>
    {
        /// //////////////////////////////////////////////////////
        public CModeOperationnelSchema(EModeOperationnelSchema mode)
            : base(mode)
        {
        }

        //----------------------------------------------------------------------
        /// <summary>
        /// Libellé du mode opérationnel :
        /// <ul>
        /// <li>Tous chemins requis</li>
        /// <li>Redondance automatique</li>
        /// <li>Personnalisé</li>
        /// </ul>
        /// </summary>
        [DynamicField("Label")]
        public override string Libelle
        {
            get
            {
                switch (Code)
                {
                    case EModeOperationnelSchema.AllMandatory:
                        return I.T("All mandatory|20046");
                    case EModeOperationnelSchema.AutomaticRedundancy:
                        return I.T("Automatic redundancy|20047");
                    case EModeOperationnelSchema.Custom :
                        return I.T("Custom|20048");
                   
                }
                return "";
            }
        }
    }
}
