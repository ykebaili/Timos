using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;

namespace timos.data
{
	/// <summary>
    /// L'Attribut fournit la possibilité d'associer une information propre à une <see cref="CRessourceMaterielle">Ressource</see>.<br/> 
    /// L'Attribut peut être soit un champ texte libre, soit choisi parmis une liste d'Attributs donnés par un <see cref="CTypeContrainte">Type de Contrainte</see> donné .<br/>
    /// De façon générale les Attributs d'une Ressource vont servir à évaluer si celle-ci peut lever certaines <see cref="CContrainte">Contraintes</see>.
    /// </summary>
    [sc2i.doccode.DocRefMenusOrMenuItems(CDocLabels.c_iContrainte)]
    [DynamicClass("Resource attribute")]
	[Table(CAttributRessource.c_nomTable, CAttributRessource.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CAttributRessourceServeur")]
	public class CAttributRessource : CObjetDonneeAIdNumeriqueAuto, IObjetALectureTableComplete
	{
		public const string c_nomTable = "RESOURCE_ATTRIBUT";

        public const string c_champId = "RESOURCE_ATTRIB_ID";
        public const string c_champLibelle = "RESOURCE_ATTRIB_LABEL";


		/// /////////////////////////////////////////////
		public CAttributRessource( CContexteDonnee contexte)
			:base(contexte)
		{
		}

		/// /////////////////////////////////////////////
		public CAttributRessource(DataRow row )
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
				return I.T( "Resource Attribute @1|244",Libelle);
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
        /// Si l'Attribut n'est pas choisi parmi une liste d'Attributs possibles donnés par le Type de la Contrainte,<br/> 
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

        /// <summary>
        /// Retourne le nom de l'Attribut qu'il soit libre ou<br/>
        /// pris dans la liste des Attributs définis par le Type de Contrainte.
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
        /// Donne ou définit l'Attribut pris dans la liste des Attributs du Type de la Contrainte liée.
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
        /// Définit la Ressource parente de l'Attribut
        /// </summary>
        [Relation(CRessourceMaterielle.c_nomTable, CRessourceMaterielle.c_champId, CRessourceMaterielle.c_champId, true, true)]
        [DynamicField("Resource")]
        public CRessourceMaterielle Ressource
        {
            get
            {
                return (CRessourceMaterielle)GetParent(CRessourceMaterielle.c_champId, typeof(CRessourceMaterielle));
            }
            set
            {
                SetParent(CRessourceMaterielle.c_champId, value);
            }
        }

    
    }
}
