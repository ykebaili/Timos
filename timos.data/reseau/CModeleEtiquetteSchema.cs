using System;
using System.Collections.Generic;
using System.Data;
using System.Text;


using sc2i.data;
using sc2i.common;
using sc2i.expression;

namespace timos.data
{
    /// <summary>
    /// Permet de définir des modèles d'étiquette à associer aux objets entrant dans les <see cref="CSchemaReseau">schémas réseau</see>.
    /// Un tel modèle d'étiquette peut ensuite être associé à un objet de schéma, en général pour afficher
    /// directement le nom de l'objet dans le schéma.
    /// </summary>
    [DynamicClass("Network diagram label model")]
    [Table(CModeleEtiquetteSchema.c_nomTable, CModeleEtiquetteSchema.c_champId, true)]
    [FullTableSync]
    [ObjetServeurURI("CModeleEtiquetteSchemaServeur")]


    
    public class CModeleEtiquetteSchema : CObjetDonneeAIdNumeriqueAuto
    {

        public const string c_nomTable = "NTW_LABEL_MDL";
        public const string c_champId = "NTWLABELMDL_ID";
        public const string c_champLibelle = "NTWLABELMDL_LABEL";
        public const string c_champTypeCible = "NTWLABELMDL_TARGETTYPE";
        public const string c_champFormule = "NTWLABELMDL_FORMULA";


        //////////////////////////////////////////////////
        public CModeleEtiquetteSchema(CContexteDonnee contexte)
            : base(contexte)
        {

        }


        /// /////////////////////////////////////////////
		public CModeleEtiquetteSchema(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T("Diagram label model @1|30097",Libelle.ToString());
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
        /// Le libellé du modèle d'étiquette
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
        /// Catégorie d'objet auquel s'applique ce modèle d'étiquette (Site, Lien réseau, etc.)
        /// </summary>
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


        /// //////////////////////////////////////////////////
        [TableFieldProperty(c_champFormule, 3000)]
        public string FormuleString
        {
            get
            {
                return (string)Row[c_champFormule];
            }
            set
            {
                Row[c_champFormule] = value;
            }
        }




        public C2iExpression Formule
        {
            get
            {
                C2iExpression expression = C2iExpression.FromPseudoCode(FormuleString);
                if (expression == null)
                    expression = new C2iExpressionConstante("");
                return expression;

            }
            set
            {
                if (value == null)
                    FormuleString = "";
                else
                    FormuleString = C2iExpression.GetPseudoCode(value);
               
            }
        }


    }
}
