using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.data;
using sc2i.common;
using System.Data;
using timos.data.commandes;

namespace timos.data.equipement.consommables
{
    /// <summary>
    /// Le Conditionnement représente la manière dont certains Consommables sont livrés par un <see cref="CDonneesActeurFournisseur"> Fournisser </see> donné,
    /// permettant la manutention, la conservation et le stockage des produits.
    /// </summary>
    [DynamicClass("Consumable Packaging")]
    [ObjetServeurURI("CConditionnementConsommableServeur")]
    [Table(CConditionnementConsommable.c_nomTable, CConditionnementConsommable.c_champId, true)]
    public class CConditionnementConsommable : 
        CObjetDonneeAIdNumeriqueAuto,
        IReferenceElementCommandable
    {
        public const string c_nomTable = "CONSUMABLE_PACKAGING";
        public const string c_champId = "CONSUMPACKAG_ID";
        public const string c_champReference = "CONSUMPACKAG_REF";
        public const string c_champNombreUnites = "CONSUMPACKAG_NBUNIT";

        public CConditionnementConsommable(CContexteDonnee context)
            : base(context)
        {
        }

        public CConditionnementConsommable(DataRow row)
            : base(row)
        {
        }

        public override string DescriptionElement
        {
            get { return I.T("Packaging @1|10031", Reference); }
        }

        public override string[] GetChampsTriParDefaut()
        {
            return new string[] { c_champReference };
        }

        protected override void MyInitValeurDefaut()
        {

        }

        //-----------------------------------------------------------
        /// <summary>
        /// Obtient ou définit la référence de ce Conditionnement
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

        //----------------------------------------------------------------------
        /// <summary>
        /// Libellé : est normalement constitué du libellé du type de consommable/
        /// de l'identité complète du fournisseur/de la référence chez le fournisseur
        /// </summary>
        [DynamicField("Label")]
        public string Libelle
        {
            get
            {
                StringBuilder bl = new StringBuilder();
                if (TypeConsommable != null)
                {
                    bl.Append(TypeConsommable.Libelle);
                }
                if (Fournisseur != null)
                {
                    bl.Append("/");
                    bl.Append(Fournisseur.Acteur.IdentiteComplete);
                }
                bl.Append("/");
                bl.Append(Reference);
                return bl.ToString();
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// Obtient ou définit le nombre d'unité du produit consommable contenu dans ce Conditionnement
        /// </summary>
        [TableFieldProperty(c_champNombreUnites)]
        [DynamicField("Unit Count")]
        public int NombreUnites
        {
            get
            {
                return (int)Row[c_champNombreUnites];
            }
            set
            {
                Row[c_champNombreUnites] = value;
            }
        }

        //-------------------------------------------------------------------
        /// <summary>
        /// Obtient ou définit le Fournisseur associé à ce Conditionnement
        /// </summary>
        [Relation(
            CDonneesActeurFournisseur.c_nomTable,
            CDonneesActeurFournisseur.c_champId,
            CDonneesActeurFournisseur.c_champId,
            false,
            false,
            false)]
        [DynamicField("Supplier")]
        public CDonneesActeurFournisseur Fournisseur
        {
            get
            {
                return (CDonneesActeurFournisseur)GetParent(CDonneesActeurFournisseur.c_champId, typeof(CDonneesActeurFournisseur));
            }
            set
            {
                SetParent(CDonneesActeurFournisseur.c_champId, value);
            }
        }

        //-------------------------------------------------------------------
        /// <summary>
        /// Obtient ou définit le Type de Consommable associé à ce Conditionnement
        /// </summary>
        [Relation(
            CTypeConsommable.c_nomTable,
            CTypeConsommable.c_champId,
            CTypeConsommable.c_champId,
            true,
            true,
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


        #region IReferenceElementCommandable Membres
        //----------------------------------------------------------
        public IElementCommandable ElementCommandable
        {
            get
            {
                return TypeConsommable;
            }
        }

        #endregion
    }
}
