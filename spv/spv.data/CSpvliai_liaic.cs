using System;
using System.Data;
using sc2i.data;
using sc2i.common;
using sc2i.expression;
using timos.data;

namespace spv.data
{
    [Table(CSpvLiai_Liaic.c_nomTable, CSpvLiai_Liaic.c_nomTableInDb, new string[] { CSpvLiai_Liaic.c_champIdLiaisonSupportée, CSpvLiai_Liaic.c_champIdLiaisonSupportant })]
    [ObjetServeurURI("CSpvLiai_LiaicServeur")]
    [DynamicClass("Supporting link")]
    public class CSpvLiai_Liaic : CObjetDonnee, IObjetSansVersion
    {
        public const string c_nomTable = "SPV_LIAI_LIAIC";
        public const string c_nomTableInDb = "LIAI_LIAIC";
        public const string c_champIdLiaisonSupportée = "LIAI_ID";
        public const string c_champIdLiaisonSupportant = "LIAI_BINDINGID";

        ///////////////////////////////////////////////////////////////
        public CSpvLiai_Liaic(CContexteDonnee ctx)
            : base(ctx)
        {
        }

        ///////////////////////////////////////////////////////////////
        public CSpvLiai_Liaic(DataRow row)
            : base(row)
        {
        }

        ///////////////////////////////////////////////////////////////
        protected override void MyInitValeurDefaut()
        {
            //TODO : Insérer ici le code d'initalisation
        }

        ///////////////////////////////////////////////////////////////
        public override string[] GetChampsTriParDefaut()
        {
            return new string[] { c_champIdLiaisonSupportée };
        }

        ///////////////////////////////////////////////////////////////
        public override string DescriptionElement
        {
            get
            {
                return I.T("Link support @1|", LiaisonSupportee.Id.ToString());
            }
        }


        ///////////////////////////////////////////////////////////////
        [Relation(CSpvLiai.c_nomTable, new string[] { CSpvLiai.c_champLIAI_ID }, new string[] { CSpvLiai_Liaic.c_champIdLiaisonSupportée }, true, true)]
        [DynamicField("Supported link")]
        public CSpvLiai LiaisonSupportee
        {
            get
            {
                return (CSpvLiai)GetParent(new string[] { c_champIdLiaisonSupportée }, typeof(CSpvLiai));
            }
            set
            {
                SetParent(new string[] { c_champIdLiaisonSupportée }, value);
            }
        }

        ///////////////////////////////////////////////////////////////
        [Relation(CSpvLiai.c_nomTable, new string[] { CSpvLiai.c_champLIAI_ID }, new string[] { CSpvLiai_Liaic.c_champIdLiaisonSupportant }, true, true)]
        [DynamicField("Supporting link")]
        public CSpvLiai LiaisonSupportant
        {
            get
            {
                return (CSpvLiai)GetParent(new string[] { c_champIdLiaisonSupportant }, typeof(CSpvLiai));
            }
            set
            {
                SetParent(new string[] { c_champIdLiaisonSupportant }, value);
            }
        }
    }
}
