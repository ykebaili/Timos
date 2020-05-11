using System;
using System.Collections.Generic;
using System.Text;

using sc2i.common;


namespace timos.data
{
    //Mode de gestion de l'�tat op�rationnel d'un sch�ma
    public enum EModeOperationnelSchema
    {
        AllMandatory = 0, //D�s qu'un �l�ment d'un sch�ma est HS, le sch�ma est HS
        AutomaticRedundancy = 1, //Si un chemin entre une entr�e et une sortie est coup�, le sch�ma est HS. S'il existe des redondances, il n'est pas HS
        Custom = 2, // l'utilisateur d�finit manuellement le mode op�rationnel de chaque chemin
        
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
        /// Libell� du mode op�rationnel :
        /// <ul>
        /// <li>Tous chemins requis</li>
        /// <li>Redondance automatique</li>
        /// <li>Personnalis�</li>
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
