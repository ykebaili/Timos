using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using sc2i.common.memorydb;
using System.Data;
using sc2i.data;
using tiag.client;

namespace timos.data.projet.besoin
{
    /// <summary>
    /// Quantité (détail) définie par le besoin.
    /// </summary>
    /// <remarks>
    /// Une quantité peut être décomposée en sous quantités dans ce cas,
    /// sa valeur est la somme des valeurs des quantités filles.
    /// </remarks>
    [Table(CBesoinQuantite.c_nomTable, CBesoinQuantite.c_champId, true)]
    [ObjetServeurURI("CBesoinQuantiteServeur")]
    [TiagClass(CBesoinQuantite.c_nomTiag, "Id", true)]
    [DynamicClass("Need quantity")]
    public class CBesoinQuantite : 
        CObjetDonneeAIdNumeriqueAuto, 
        IObjetDonneeAutoReference
    {
        public const string c_nomTiag = "Need_Quantity";

        public const string c_nomTable = "NEED_QUANTITY";
        public const string c_champId = "NEEDQ_ID";
        public const string c_champLibelle = "NEEDQ_LABEL";
        public const string c_champNb = "NEEDQ_NB";
        public const string c_champIdQteParente = "NEEDQ_PARENT_ID";
        public const string c_champIndex = "NEEDQ_INDEX";
        public const string c_champTypeEntiteAssociee = "NEEDQ_ELEMENTS_TYPE";

        //-----------------------------------------------
        public CBesoinQuantite(CContexteDonnee ctx)
            : base(ctx)
        {
        }

        //-----------------------------------------------
        public CBesoinQuantite(DataRow row)
            : base(row)
        {
        }

        //-----------------------------------------------
        public override string DescriptionElement
        {
            get
            {
                return I.T("Quantity @1 for need @2|20158",
                    Libelle,
                    Besoin != null ? Besoin.Libelle : "?");
            }
        }

        //-----------------------------------------------
        /// <summary>
        /// Position de la quantité dans son parent
        /// </summary>
        [TableFieldProperty(c_champIndex)]
        [DynamicField("Index")]
        public int Index
        {
            get
            {
                return Row.Get<int>(c_champIndex);
            }
            set
            {
                Row[c_champIndex] = value;
            }
        }

        //-----------------------------------------------
        public override string[] GetChampsTriParDefaut()
        {
            return new string[] { c_champIndex, c_champLibelle };
        }

        //-----------------------------------------------
        protected override void MyInitValeurDefaut()
        {
            Quantite = 1;
            Index = 0;
        }

        //-----------------------------------------------------------
        /// <summary>
        /// Type d'entité associé à la quantité (Champ système)
        /// </summary>
        [TableFieldProperty(c_champTypeEntiteAssociee, 1024)]
        [DynamicField("Associated Entity type string", CObjetDonnee.c_categorieChampSystème)]
        public string TypeEntiteAssocieeString
        {
            get
            {
                return (string)Row[c_champTypeEntiteAssociee];
            }
            set
            {
                Row[c_champTypeEntiteAssociee] = value;
            }
        }

        //-----------------------------------------------------------
        public Type TypeEntiteAssocie
        {
            get
            {
                return CActivatorSurChaine.GetType(TypeEntiteAssocieeString);
            }
            set
            {
                if (value == null)
                    TypeEntiteAssocieeString = "";
                else
                    TypeEntiteAssocieeString = value.ToString();
            }
        }

        //-----------------------------------------------------------
        public int Niveau
        {
            get
            {
                if (QuantiteParente != null)
                    return QuantiteParente.Niveau + 1;
                return 0;
            }
        }




        //-----------------------------------------------
        /// <summary>
        /// Libellé de la quantité
        /// </summary>
        [TableFieldProperty(c_champLibelle, 64)]
        [DynamicField("Label")]
        [TiagField("Label")]
        public string Libelle
        {
            get
            {
                return Row.Get<string>(c_champLibelle);
            }
            set
            {
                Row[c_champLibelle] = value;
            }
        }

        //-----------------------------------------------
        /// <summary>
        /// Quantité définie
        /// </summary>
        [TableFieldProperty(c_champNb)]
        [DynamicField("Quantity")]
        [TiagField("Quantity")]
        public double Quantite
        {
            get
            {
                return Row.Get<double>(c_champNb);
            }
            set
            {
                Row[c_champNb] = value;
                if (Besoin != null)
                {
                    IEnumerable<IElementACout> besoins = from b in Besoin.GetTousLesBesoinsDontLeCoutDependDeMesQuantites()
                                                   select b as IElementACout;
                    CUtilElementACout.OnChangeCout(besoins, true, false);
                    CUtilElementACout.OnChangeCout(besoins, false, false);
                }
            }
        }

        //-------------------------------------------------------------------
        /// <summary>
        /// Quantité parente de cette quantité
        /// </summary>
        [Relation(
            CBesoinQuantite.c_nomTable,
            CBesoinQuantite.c_champId,
            c_champIdQteParente,
            false,
            true,
            false)]
        [DynamicField("Parent quantity")]
        public CBesoinQuantite QuantiteParente
        {
            get
            {
                return (CBesoinQuantite)GetParent(c_champIdQteParente, typeof(CBesoinQuantite));
            }
            set
            {
                SetParent(c_champIdQteParente, value);
            }
        }

        //---------------------------------------------
        /// <summary>
        /// Quantités filles de cette quantité
        /// </summary>
        [RelationFille(typeof(CBesoinQuantite), "QuantiteParente")]
        [DynamicChilds("Children quantities", typeof(CBesoinQuantite))]
        public CListeObjetsDonnees QuantitesFilles
        {
            get
            {
                return GetDependancesListe(CBesoinQuantite.c_nomTable, c_champIdQteParente);
            }
        }


        //-----------------------------------------------
        /// <summary>
        /// Besoin auquel appartient cette quantité
        /// </summary>
        [Relation(
            CBesoin.c_nomTable,
            CBesoin.c_champId,
            CBesoin.c_champId,
            true,
            true,
            false)]
        public CBesoin Besoin
        {
            get
            {
                return GetParent(CBesoin.c_champId, typeof(CBesoin)) as CBesoin;
            }
            set
            {
                SetParent(CBesoin.c_champId, value);
            }
        }


        //--------------------------------
        public string ChampParent
        {
            get { return c_champIdQteParente; }
        }

        //--------------------------------
        public string ProprieteListeFils
        {
            get { return "QuantitesFilles"; }
        }


        //---------------------------------------------
        /// <summary>
        /// Relatinos vers les éléments sélectionnés pour cette quantités, dans le cas
        /// où cette quantité correspond à une sélectino d'éléments
        /// </summary>
        [RelationFille(typeof(CRelationBesoinQuantite_Element), "BesoinQuantite")]
        [DynamicChilds("Selected elements relatinos", typeof(CRelationBesoinQuantite_Element))]
        public CListeObjetsDonnees RelationsElementsSelectionnes
        {
            get
            {
                return GetDependancesListe(CRelationBesoinQuantite_Element.c_nomTable, c_champId);
            }
        }

        //---------------------------------------------
        public void ClearSelections()
        {
            CListeObjetsDonnees lst = RelationsElementsSelectionnes;
            CObjetDonneeAIdNumerique.Delete(lst, true );
        }

        //---------------------------------------------
        public void AddSelectedEntity(CObjetDonneeAIdNumerique objet)
        {
            if (objet != null && (objet.GetType() == TypeEntiteAssocie || TypeEntiteAssocie == null))
            {
                TypeEntiteAssocie = objet.GetType();
                //Vérifie que l'entité n'est pas déjà associée
                CListeObjetsDonnees lst = RelationsElementsSelectionnes;
                lst.Filtre = new CFiltreData(CRelationBesoinQuantite_Element.c_champIdElement + "=@1",
                    objet.Id);
                if (lst.Count == 0)
                {
                    CRelationBesoinQuantite_Element rel = new CRelationBesoinQuantite_Element(ContexteDonnee);
                    rel.CreateNewInCurrentContexte();
                    rel.BesoinQuantite = this;
                    rel.Element = objet;
                }
            }
        }

        //---------------------------------------------
        public void RemoveSelectedEntity(CObjetDonneeAIdNumerique objet)
        {
            if (objet != null)
            {
                //Vérifie que l'entité n'est pas déjà associée
                CListeObjetsDonnees lst = RelationsElementsSelectionnes;
                lst.Filtre = new CFiltreData(CRelationBesoinQuantite_Element.c_champIdElement + "=@1",
                    objet.Id);
                if (lst.Count > 0)
                {
                    CObjetDonneeAIdNumerique.Delete(lst, true);
                }
            }
        }

        //---------------------------------------------
        internal void CopyFromTemplate(
            CBesoinQuantite qTemplate, 
            Dictionary<string, string> mapIdQuantiteOriginaleToNew)
        {
            Libelle = qTemplate.Libelle;
            Quantite = qTemplate.Quantite;
            Index = qTemplate.Index;
            TypeEntiteAssocie = qTemplate.TypeEntiteAssocie;
            mapIdQuantiteOriginaleToNew[qTemplate.IdUniversel] = IdUniversel;
            foreach (CBesoinQuantite fille in qTemplate.QuantitesFilles)
            {
                CBesoinQuantite newQ = new CBesoinQuantite(ContexteDonnee);
                newQ.CreateNewInCurrentContexte();
                newQ.Besoin = Besoin;
                newQ.QuantiteParente = this;
                newQ.CopyFromTemplate(fille, mapIdQuantiteOriginaleToNew);
            }
        }
    }
}