using System;
using System.Collections;
using System.Text;
using System.Data;

using sc2i.data;
using sc2i.common;


namespace timos.data
{
    /// <summary>
	/// Relation entre un <see cref="CTypeRessource">Type de Ressource</see> et
	/// un <see cref="CTypeContrainte">Type de Contrainte</see>.
    /// </summary>
    [DynamicClass("Resource type / Constraint type")]
    [Table(CRelationTypeContrainte_TypeRessource.c_nomTable, CRelationTypeContrainte_TypeRessource.c_champId, true)]
    [ObjetServeurURI("CRelationTypeContrainte_TypeRessourceServeur")]
    [FullTableSync]
	[Unique ( false,
	"Another association exists for this constraint type/resource type|141",
	CTypeContrainte.c_champId,
	CTypeRessource.c_champId)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_TypeContrainte_ID)]
    public class CRelationTypeContrainte_TypeRessource : CObjetDonneeAIdNumeriqueAuto
    {

        public const string c_nomTable = "CONST_TYPE_RES_TYPE";
        public const string c_champId = "CONST_TYPE_RES_TYPE_ID";


        //////////////////////////////////////////////////////////////////////////
		public CRelationTypeContrainte_TypeRessource( CContexteDonnee contexte)
			:base(contexte)
		{
		}

		//////////////////////////////////////////////////////////////////////////
        public CRelationTypeContrainte_TypeRessource(DataRow row)
			:base(row)
		{
		}

		//////////////////////////////////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[] {c_champId};
		}

		//////////////////////////////////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
                return I.T( "Constraint Type/Resource Type relation|117");
			}
		}

		//////////////////////////////////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
		}


        //------------------------------------------------ PROPRIETES ---------------------------------------------------------

      
        /// <summary>
        /// Type de contrainte d'accès, objet de la relation<br/>
		/// (obligatoire)
        /// </summary>
        [Relation(
            CTypeContrainte.c_nomTable,
            CTypeContrainte.c_champId,
            CTypeContrainte.c_champId,
            true,
            false)]
        [DynamicField("Contraint type")]
        public CTypeContrainte TypeContrainte
        {
            get
            {
                return (CTypeContrainte) GetParent(CTypeContrainte.c_champId, typeof(CTypeContrainte));
            }

            set
            {
                SetParent(CTypeContrainte.c_champId, value);
            }
        }

        /// <summary>
        /// Type de ressource, objet de la relation<br/>
		/// (obligatoire)
        /// </summary>
        [Relation(
            CTypeRessource.c_nomTable,
            CTypeRessource.c_champId,
            CTypeRessource.c_champId,
            true,
            false)]
        [DynamicField("Resource type")]
        public CTypeRessource TypeRessource
        {
            get
            {
                return (CTypeRessource) GetParent(CTypeRessource.c_champId, typeof(CTypeRessource));
            }

            set
            {
                SetParent(CTypeRessource.c_champId, value);
            }
        }

    }
}
