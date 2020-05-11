using System;
using System.Collections;
using System.Text;
using System.Data;

using sc2i.data;
using sc2i.common;


namespace timos.data
{
    /// <summary>
	/// Définit les Attributs possibles pour les <see cref="CContrainte">Contraintes</see>
	/// et les <see cref="CRessource">Ressources</see> en fonction du <see cref="CTypeContrainte">type de Contrainte</see>
    /// </summary>
    /// <remarks>
    /// Cette entité est utilisée par <br/>
    /// <list type="bullets">
	/// <item><term><see cref="CAttributContrainte">Les Attributs de Contrainte</see></term></item>
	/// <item><term><see cref="CAttributRessource">Les Attributs de Ressource</see></term></item>
    /// </list>
    /// </remarks>
    [sc2i.doccode.DocRefMenusOrMenuItems(CDocLabels.c_iContrainte)]
    [Table(CAttributTypeContrainte.c_nomTable, CAttributTypeContrainte.c_champId, true)]
    [ObjetServeurURI("CAttributTypeContrainteServeur")]
	[DynamicClass("Constraint Type Attribute")]
    [FullTableSync]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_TypeContrainte_ID)]
    public class CAttributTypeContrainte : CObjetDonneeAIdNumeriqueAuto
    {

        public const string c_nomTable = "CONSTRAINT_TYPE_ATTRIBUTE";
        public const string c_champId = "CONST_TYPE_ATTRIB_ID";

        public const string c_champLibelle = "CONST_TYPE_ATTRIB_LABEL";

        public CAttributTypeContrainte(CContexteDonnee contexte)
            : base(contexte)
        {
        }

        public CAttributTypeContrainte(DataRow row)
            : base(row)
        {
        }


        //////////////////////////////////////////////////////////////////////////
        public override string[] GetChampsTriParDefaut()
        {
            return new string[] { c_champId };
        }

        //////////////////////////////////////////////////////////////////////////
        public override string DescriptionElement
        {
            get
            {
                return I.T( "Constraint Type Attribute|122");
            }
        }

        //////////////////////////////////////////////////////////////////////////
        protected override void MyInitValeurDefaut()
        {
        }


        //------------------------------------------------ PROPRIETES ---------------------------------------------------------
        // /////////////////////////////////////////////
        /// <summary>
		/// Libellé de l'attribut
        /// </summary>
        [TableFieldProperty(c_champLibelle, 255)]
        [DynamicField("Label")]
        [RechercheRapide]
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
        /// Type de contrainte associé à l'attribut
        /// </summary>
        [Relation(
            CTypeContrainte.c_nomTable,
            CTypeContrainte.c_champId,
            CTypeContrainte.c_champId,
            true,
            true)]
        [DynamicField("Constraint type")]
        public CTypeContrainte TypeContrainte
        {
            get
            {
                return (CTypeContrainte)GetParent(CTypeContrainte.c_champId, typeof(CTypeContrainte));
            }

            set
            {
                SetParent(CTypeContrainte.c_champId, value);
            }
        }


    }
}
