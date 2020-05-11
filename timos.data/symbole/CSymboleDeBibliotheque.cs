using System;
using System.Collections;
using System.Text;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using sc2i.data.dynamic;
using timos.securite;

namespace timos.data
{
    /// <summary>
    /// Cette classe représente un symbole graphique de la bibilothèque de symboles
    /// </summary>
    //[DocRefMenusOrMenuItems(CDocLabels.c_iSymbole)]
    [DynamicClass("Library symbol")]
    [Table(CSymboleDeBibliotheque.c_nomTable, CSymboleDeBibliotheque.c_champId, true)]
    [FullTableSync]
    [ObjetServeurURI("CSymboleDeBibliothequeServeur")]
    public class CSymboleDeBibliotheque : CObjetDonneeAIdNumeriqueAuto 
    {
        public const string c_nomTable = "LIBRARY_SYMBOL";
        public const string c_champId = "LIBRARY_SYMBOL_ID";
        public const string c_champLibelle = "LIBRARY_SYMBOL_LABEL";
        public const string c_champTypeCible = "LIBRARY_SYMBOL_TYPECIBLE";


        /// /////////////////////////////////////////////
		public CSymboleDeBibliotheque( CContexteDonnee contexte)
			:base(contexte)
		{
		}
		
	/// /////////////////////////////////////////////
        public CSymboleDeBibliotheque(DataRow row)
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T("Library Symbol @1|30034",Libelle);
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champLibelle};
		}


        /// <summary>
        /// Le libellé du symbole de bibliothèque
        /// </summary>
        [TableFieldProperty(c_champLibelle, 30)]
        [DynamicField("Label")]
        public string Libelle
        {
            get
            {
                return (string)Row[c_champLibelle];
            }
            set
            {
                Row[c_champLibelle] = value;
            }
        }

        /// <summary>
        /// La famille à laquelle appartient ce symbole
        /// </summary>
        [Relation(
            CFamilleSymbole.c_nomTable,
           CFamilleSymbole.c_champId,
           CFamilleSymbole.c_champId,
            false,
            false,
            false)]
        [DynamicField("Family")]
        public CFamilleSymbole Famille
        {
            get
            {
                return (CFamilleSymbole)GetParent(CFamilleSymbole.c_champId,typeof(CFamilleSymbole));
                   
            }
            set
            {
                SetParent(CFamilleSymbole.c_champId, value);
            }
        }



        [TableFieldProperty(c_champTypeCible, 255)]
        [DynamicField("Target type")]
        public string TypeCibleString
        {
            get
            {
                return (string)Row[c_champTypeCible];
            }

            set
            {
                Row[c_champTypeCible] = value;
            }
        }




        public Type TypeCible
        {
            get
            {
                return CActivatorSurChaine.GetType(TypeCibleString);
            }

            set
            {
                TypeCibleString = value.ToString();
            }

        }


        [RelationFille(typeof(CSymbole),"SymboleDeBibliotheque")]
        [DynamicField("Symbol")]
        public CSymbole Symbole
        {

            get
            {
                CListeObjetsDonneesContenus liste = GetDependancesListe(CSymbole.c_nomTable, CSymboleDeBibliotheque.c_champId);
                if(liste.Count>0)

                   return (CSymbole)liste[0];
                else
                    return null;
            }

            set
            {
                if(value!=null)
                value.SymboleDeBibliotheque = this;
            }
           
        }
        

        
    }
}
