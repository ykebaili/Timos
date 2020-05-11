using System;
using System.Data;
using sc2i.data;
using sc2i.common;
using timos.data;

namespace spv.data
{
    /// <summary>
    /// Indique d'où viennent les CSpvEquip_Msk
    /// Pour chaque enregistrement de CSpvEquip_Msk, il y a autant d'enregistrements
    /// de CSpvEquip_Msk_Source qu'il y a de raison à la présence du masquage
    /// </summary>
    [Table(CSpvEquip_Msk_Source.c_nomTable, CSpvEquip_Msk_Source.c_nomTableInDb, new string[] { CSpvEquip_Msk_Source.c_champId })]
    [ObjetServeurURI("CSpvEquip_Msk_SourceServeur")]
    [DynamicClass("Equipment masking source")]
    public class CSpvEquip_Msk_Source : CObjetDonneeAIdNumeriqueAuto, IObjetSansVersion
    {
        public const string c_nomTable = "SPV_EQUIP_MSK_SRC";
        public const string c_nomTableInDb = "EQUIP_MSK_SRC";
        public const string c_champId = "EQMSSR_ID";
        public const string c_champMasquageParent1 = "EQMSSR_PARENT_MSK1";
        public const string c_champMasquageParent2 = "EQMSSR_PARENT_MSK2";

        ///////////////////////////////////////////////////////////////
        public CSpvEquip_Msk_Source(CContexteDonnee ctx)
            : base(ctx)
        {
        }

        ///////////////////////////////////////////////////////////////
        public CSpvEquip_Msk_Source(DataRow row)
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
            return new string[] { c_champId };
        }

        ///////////////////////////////////////////////////////////////
        public override string DescriptionElement
        {
            get
            {
                return I.T("Equimpent masking source @1|30018", Id.ToString());
            }
        }

        ///////////////////////////////////////////////////////////////
        //Masquage d'équipement lié à cette source
        [Relation(
            CSpvEquip_Msk.c_nomTable,
            CSpvEquip_Msk.c_champEQUIP_MSK_ID,
            CSpvEquip_Msk.c_champEQUIP_MSK_ID,
            true,
            false,
            true)]
        [DynamicField("Equimpent masking")]
        public CSpvEquip_Msk Equip_Msk
        {
            get
            {
                return (CSpvEquip_Msk)GetParent(CSpvEquip_Msk.c_champEQUIP_MSK_ID, typeof(CSpvEquip_Msk));
            }
            set
            {
                SetParent(CSpvEquip_Msk.c_champEQUIP_MSK_ID, value);
            }
        }

        ///////////////////////////////////////////////////////////////
        /// <summary>
        /// Masquage source de cette source de masquage
        /// </summary>
        [Relation(
            CSpvEquip_Msk.c_nomTable,
            CSpvEquip_Msk.c_champEQUIP_MSK_ID,
            CSpvEquip_Msk_Source.c_champMasquageParent1,
            false,
            true,
            false)]
        [DynamicField("Masking source 1")]
        public CSpvEquip_Msk Equip_MskSource1
        {
            get
            {
                return (CSpvEquip_Msk)GetParent(c_champMasquageParent1, typeof(CSpvEquip_Msk));
            }
            set
            {
                SetParent(c_champMasquageParent1, value);
            }
        }

        ///////////////////////////////////////////////////////////////
        /// <summary>
        /// Masquage source de cette source de masquage
        /// </summary>
        [Relation(
            CSpvEquip_Msk.c_nomTable,
            CSpvEquip_Msk.c_champEQUIP_MSK_ID,
            CSpvEquip_Msk_Source.c_champMasquageParent2,
            false,
            true,
            false)]
        [DynamicField("Masking source 2")]
        public CSpvEquip_Msk Equip_MskSource2
        {
            get
            {
                return (CSpvEquip_Msk)GetParent(c_champMasquageParent2, typeof(CSpvEquip_Msk));
            }
            set
            {
                SetParent(c_champMasquageParent2, value);
            }
        }

        ///////////////////////////////////////////////////////////////
        [Relation ( 
            CSpvLiai.c_nomTable,
            CSpvLiai.c_champLIAI_ID,
            CSpvLiai.c_champLIAI_ID,
            false,
            true)]
        [DynamicField("Source link")]
        public CSpvLiai LiaiSource
        {
            get
            {
                return (CSpvLiai)GetParent(CSpvLiai.c_champLIAI_ID, typeof(CSpvLiai));
            }
            set
            {
                SetParent(CSpvLiai.c_champLIAI_ID, value);
            }
        }

       
            

    }
}
