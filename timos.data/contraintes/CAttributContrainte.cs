using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;

namespace timos.data
{
	/// <summary>
    /// L'Attribut fournit la possibilité d'associer une information propre à une <see cref="CContrainte">Contrainte</see>.<br/> 
    /// L'Attribut peut être soit un champ texte libre, soit choisi parmi une liste d'Attributs donnés par le <see cref="CTypeContrainte">Type de la Contrainte</see><br/>
    /// De façon générale les Attributs d'une Contrainte vont servir à l'évaluation des <see cref="CRessourceMaterielle">Ressources</see> et/ou <see cref="CActeur">Acteurs</see> 
    /// pouvants lever la Contrainte.
	/// </summary>
    [sc2i.doccode.DocRefMenusOrMenuItems(CDocLabels.c_iContrainte)]
    [DynamicClass("Constraint attribute")]
	[Table(CAttributContrainte.c_nomTable, CAttributContrainte.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CAttributContrainteServeur")]
	public class CAttributContrainte : CObjetDonneeAIdNumeriqueAuto, IObjetALectureTableComplete
	{
        public const string c_nomTable = "CONSTRAINT_ATTRIBUTE";
        public const string c_champId = "CONSTRAINT_ATTRIB_ID";

		public const string c_champLibelle = "CONSTRAINT_ATTRIB_LABEL";


		/// /////////////////////////////////////////////
		public CAttributContrainte( CContexteDonnee contexte)
			:base(contexte)
		{
		}

		/// /////////////////////////////////////////////
		public CAttributContrainte(DataRow row )
			:base(row)
		{
		}

		////////////////////////////////////////////////
        /// <summary>
        /// Description brêve
        /// </summary>
		public override string DescriptionElement
		{
			get
			{
				return I.T( "Constraint Attribute @1 |245", Libelle);
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

		////////////////////////////////////////////////
        /// <summary>
        /// Si l'Attribut n'est pas choisi parmi une liste d'Attributs possibles donnés par le Type de la Contrainte, 
        /// un libellé doit lui être obligatoirement attribué (champ texte de 30 caractères maximum).
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

        //--------------------------------------------------------------------
        /// <summary>
        /// Retourne le nom de l'Atribut qu'il soit libre ou pris dans la liste de Attributs définit par Type de Contrainte.
        /// </summary>
        [DynamicField("String attribute")]
        public string AttributString
        {
            get 
            {
                if (AttributTypeContrainte != null)
                    return AttributTypeContrainte.Libelle;
                else return Libelle;
            }
        }


        //-------------------------------------------------------------------
        
        /// <summary>
        /// Définit l'Attribut pris dans la liste de Attributs du Type de la Contrainte liée.
        /// </summary>
        [Relation(CAttributTypeContrainte.c_nomTable,
            CAttributTypeContrainte.c_champId,
            CAttributTypeContrainte.c_champId,
            false,
            false)]
        [DynamicField("Constraint type attribute")]
        public CAttributTypeContrainte AttributTypeContrainte
        {
            get
            {
                return (CAttributTypeContrainte)GetParent(
                                                CAttributTypeContrainte.c_champId,
                                                typeof(CAttributTypeContrainte));
            }
            set
            {
                SetParent(CAttributTypeContrainte.c_champId, value);
            }
        }



        //-------------------------------------------------------------------
        /// <summary>
        /// Definit la Contrainte parente de l'Attribut.
        /// </summary>
        [Relation(CContrainte.c_nomTable, CContrainte.c_champId, CContrainte.c_champId, true, true)]
        [DynamicField("Constraint")]
        public CContrainte Contrainte
        {
            get
            {
                return (CContrainte)GetParent(CContrainte.c_champId, typeof(CContrainte));
            }
            set
            {
                SetParent(CContrainte.c_champId, value);
            }
        }


    

    }
}
