using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using System.Data;
using sc2i.data;

namespace timos.data.projet.besoin
{
    /// <summary>
    /// Liens de dépendance entre deux besoins. Par exemple, lorsque le besoin
    /// se calcule via un pourcentage sur d'autres besoins, une dépendance
    /// est créé pour chaque besoin source du calcul de pourcentage
    /// </summary>
    [Table(CBesoinDependance.c_nomTable, CBesoinDependance.c_champId, true)]
    [ObjetServeurURI("CBesoinDependanceServeur")]
    [DynamicClass("Need dependancy")]
    public class CBesoinDependance : CObjetDonneeAIdNumeriqueAuto
    {
        public const string c_nomTable = "NEED_DEPENDANCY";
        public const string c_champId = "NEEDDEP_ID";
        public const string c_champIdBesoinReference = "NEEDDEP_REF_ID";
        public const string c_champIdBesoinDependant = "NEEDDEP_DEP_ID";

        //-----------------------------------------------
        public CBesoinDependance(CContexteDonnee ctx)
            : base(ctx)
        {
        }

        //-----------------------------------------------
        public CBesoinDependance(DataRow row)
            : base(row)
        {
        }

        //-----------------------------------------------
        public override string DescriptionElement
        {
            get
            {
                return I.T("Dependancy relation between @1 and @2|20157",
                    BesoinDependant != null ? BesoinDependant.Libelle : "?",
                    BesoinReference != null ? BesoinReference.Libelle : "?");
            }
        }

        //-----------------------------------------------
        protected override void MyInitValeurDefaut()
        {
        }

        public override string[] GetChampsTriParDefaut()
        {
            return new string[]{c_champId};
        }

        //-----------------------------------------------
        /// <summary>
        /// Besoin référencé par la dépendance (référent)
        /// </summary>
        [Relation(
            CBesoin.c_nomTable,
            CBesoin.c_champId,
            c_champIdBesoinReference,
            true,
            true,
            true)]
        [DynamicField("Referenced need")]
        public CBesoin BesoinReference
        {
            get
            {
                return GetParent ( c_champIdBesoinReference, typeof(CBesoin)) as CBesoin;
            }
            set
            {
                SetParent(c_champIdBesoinReference, value);
            }
        }

        //-----------------------------------------------
        /// <summary>
        /// Besoin dépendant du lien référence
        /// </summary>
        [Relation(
            CBesoin.c_nomTable,
            CBesoin.c_champId,
            c_champIdBesoinDependant,
            true,
            true,
            true)]
        [DynamicField("Dependant need")]
        public CBesoin BesoinDependant
        {
            get
            {
                return GetParent ( c_champIdBesoinDependant, typeof( CBesoin)) as CBesoin;
            }
            set
            {
                SetParent(c_champIdBesoinDependant,value);
            }
        }

    }
}