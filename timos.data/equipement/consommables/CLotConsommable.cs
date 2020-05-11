using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.data;
using System.Data;
using sc2i.common;
using sc2i.common.unites;
using sc2i.data.dynamic;

namespace timos.data.equipement.consommables
{
    [DynamicClass("Consumable Lot")]
    [ObjetServeurURI("CLotConsommableServeur")]
    [Table(CLotConsommable.c_nomTable, CLotConsommable.c_champId, true)]
    [AutoExec("RegisterRole")]
    public class CLotConsommable : CElementAChamp
    {
        public const string c_roleChampCustom = "CONSUMABLE_LOT";

        public const string c_nomTable = "CONSUMABLE_LOT";
        public const string c_champId = "CONSUMABLELOT_ID";
        public const string c_champReference = "CONSUMLOT_REF";
        public const string c_champNombreInitial = "CONSUMLOT_NBUNIT";

        public CLotConsommable(CContexteDonnee context)
            : base(context)
        {
        }

        public CLotConsommable(DataRow row)
            : base(row)
        {
        }

        //-------------------------------------------------------------------
        public static void RegisterRole()
        {
            CRoleChampCustom.RegisterRole(CLotConsommable.c_roleChampCustom, I.T("Consumable Lot|20172"), typeof(CLotConsommable), typeof(CTypeConsommable));
        }

        public override string DescriptionElement
        {
            get { return I.T("Consumable Lot @1|10032", Reference); }
        }

        public override string[] GetChampsTriParDefaut()
        {
            return new string[] { c_champReference };
        }

        protected override void MyInitValeurDefaut()
        {

        }

        //--------------------------------------------------------------------------
        /// <summary>
        /// Obtient ou définit la référence de ce Lot
        /// </summary>
        [TableFieldProperty(c_champReference, 128)]
        [DynamicField("Reference")]
        public string Reference
        {
            get
            {
                return (string)Row[c_champReference];
            }
            set
            {
                Row[c_champReference] = value;
            }
        }

        //------------------------------------------------------------------------
        /// <summary>
        /// Obtient ou définit le nombre d'unité du produit consommable contenu dans ce Lot
        /// </summary>
        [TableFieldProperty(c_champNombreInitial)]
        [DynamicField("Initial Count")]
        public int NombreInitial
        {
            get
            {
                return (int)Row[c_champNombreInitial];
            }
            set
            {
                Row[c_champNombreInitial] = value;
            }
        }

        //-------------------------------------------------------------------
        /// <summary>
        /// Relation vers le <see cref="CTypeConsommable"> Type de Consommable </see> associé à ce Lot
        /// </summary>
        [Relation(
            CTypeConsommable.c_nomTable,
            CTypeConsommable.c_champId,
            CTypeConsommable.c_champId,
            true,
            false,
            true)]
        [DynamicField("Consumable Type")]
        public CTypeConsommable TypeConsommable
        {
            get
            {
                return (CTypeConsommable)GetParent(CTypeConsommable.c_champId, typeof(CTypeConsommable));
            }
            set
            {
                SetParent(CTypeConsommable.c_champId, value);
            }
        }



        //---------------------------------------------------------------------
        public override IDefinisseurChampCustom[] DefinisseursDeChamps
        {
            get
            {
                if (TypeConsommable != null)
                    return new IDefinisseurChampCustom[] { TypeConsommable };
                else
                    return new IDefinisseurChampCustom[0];
            }
        }

        //---------------------------------------------------------------------
        public override CRelationElementAChamp_ChampCustom GetNewRelationToChamp()
        {
            return new CRelationLotConsommable_ChampCustom(ContexteDonnee);
        }

        //---------------------------------------------------------------------
        /// <summary>
        /// Liste des valeurs de champs personnalisés
        /// </summary>
        [RelationFille(typeof(CRelationLotConsommable_ChampCustom), "ElementAChamps")]
        public override CListeObjetsDonnees RelationsChampsCustom
        {
            get { return GetDependancesListe(CRelationLotConsommable_ChampCustom.c_nomTable, c_champId); }
        }

        //---------------------------------------------------------------------
        public override CRoleChampCustom RoleChampCustomAssocie
        {
            get { return CRoleChampCustom.GetRole(c_roleChampCustom); }
        }
    }
}
