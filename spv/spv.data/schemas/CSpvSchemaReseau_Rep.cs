using System;
using System.Data;
using sc2i.data;
using sc2i.common;

namespace spv.data
{
    [Table(CSpvSchemaReseau_Rep.c_nomTable, CSpvSchemaReseau_Rep.c_nomTableInDb, new string[] { CSpvSchemaReseau.c_champId }, ModifiedByTrigger = true)]
    [ObjetServeurURI("CSpvSchemaReseau_RepServeur")]
    [DynamicClass("Service operational state")]
    public class CSpvSchemaReseau_Rep : CObjetDonneeAIdNumerique, IObjetSansVersion
    {
        public const string c_nomTable = "SPV_NTWDIAG_REP";
        public const string c_nomTableInDb = "NTWDIAG_REP";
        public const string c_champCoefOper = "NTWDREP_COEF";

        ///////////////////////////////////////////////////////////////
        public CSpvSchemaReseau_Rep(CContexteDonnee ctx)
            : base(ctx)
        {
        }

        ///////////////////////////////////////////////////////////////
        public CSpvSchemaReseau_Rep(DataRow row)
            : base(row)
        {
        }

        ///////////////////////////////////////////////////////////////
        protected override void MyInitValeurDefaut()
        {
            CoefficientOperationnel = 1;
        }

        ///////////////////////////////////////////////////////////////
        public override string[] GetChampsTriParDefaut()
        {
            return new string[] { CSpvSchemaReseau.c_champId };
        }

        ///////////////////////////////////////////////////////////////
        public override string DescriptionElement
        {
            get
            {
                return I.T("Service operational state @1|30042", SpvSchema != null?SpvSchema.Libelle:"");
            }
        }

 
        ///////////////////////////////////////////////////////////////
        /// <summary>
        /// Coefficient opérationnel, compris entre 0 et 1
        /// </summary>
        [TableFieldProperty(c_champCoefOper)]
        [DynamicField("Service operational coefficient")]
        public double CoefficientOperationnel
        {
            get
            {
                return (double)Row[c_champCoefOper];
            }
            set
            {
                Row[c_champCoefOper] = Math.Max(0, Math.Min(1.0, value));
            }
        }


        ///////////////////////////////////////////////////////////////
        [Relation(CSpvSchemaReseau.c_nomTable, 
            CSpvSchemaReseau.c_champId,
            CSpvSchemaReseau.c_champId,
            true, 
            true,
            true
            )]
        [DynamicField("Spv network diagram")]
        public CSpvSchemaReseau SpvSchema
        {
            get
            {
                return (CSpvSchemaReseau)GetParent(CSpvSchemaReseau.c_champId, typeof(CSpvSchemaReseau));
            }
            set
            {
                SetParent(new string[] { CSpvSchemaReseau.c_champId }, value);
            }
        }

        ///////////////////////////////////////////////////////////////
        [DynamicField("Working state")]
        public CEtatOperationnelService EtatOperationnel
        {
            get
            {
                if ( CoefficientOperationnel < 0.001 )
                    return new CEtatOperationnelService (EEtatOperationnelService.KO);
                if (CoefficientOperationnel > 0.9999)
                    return new CEtatOperationnelService(EEtatOperationnelService.OK);
                return new CEtatOperationnelService(EEtatOperationnelService.Maj);
            }
        }
    }
}
