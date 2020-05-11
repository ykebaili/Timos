using System;
using System.Collections;
using System.Text;
using System.Data;

using sc2i.data;
using sc2i.common;


namespace timos.data
{
    /// <summary>
    /// Indique les ressources correspondant aux 
	/// <see cref="CContrainte">Contraintes d'Accès</see>
    /// </summary>
    [DynamicClass("Constraint / Resource")]
    [Table(CRelationContrainte_Ressource.c_nomTable, CRelationContrainte_Ressource.c_champId, true)]
    [ObjetServeurURI("CRelationContrainte_RessourceServeur")]
    [FullTableSync]
    [Unique(false,
        "Another association already exist for the relation Constraint/Resource|142",
        CContrainte.c_champId,
        CRessourceMaterielle.c_champId)]
    public class CRelationContrainte_Ressource : CObjetDonneeAIdNumeriqueAuto
    {

        public const string c_nomTable = "CONSTRAINT_RESOURCE";
        public const string c_champId = "CONSTRAINT_RESOURCE_ID";


        //////////////////////////////////////////////////////////////////////////
		public CRelationContrainte_Ressource( CContexteDonnee contexte)
			:base(contexte)
		{
		}

		//////////////////////////////////////////////////////////////////////////
        public CRelationContrainte_Ressource(DataRow row)
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
                return I.T( "Constraint/Resource relation|118");
			}
		}

		//////////////////////////////////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
		}


        //------------------------------------------------ PROPRIETES ---------------------------------------------------------

      
        /// <summary>
        /// Contrainte d'accès, objet de la relation<br/>
		/// (obligatoire)
        /// </summary>
        [Relation(
            CContrainte.c_nomTable,
            CContrainte.c_champId,
            CContrainte.c_champId,
            true,
            false)]
        [DynamicField("Constraint")]
        public CContrainte Contrainte
        {
            get
            {
                return (CContrainte) GetParent(CContrainte.c_champId, typeof(CContrainte));
            }

            set
            {
                SetParent(CContrainte.c_champId, value);
            }
        }

        /// <summary>
        /// Ressource, objet de la relation<br/>
		/// (obligatoire)
        /// </summary>
        [Relation(
            CRessourceMaterielle.c_nomTable,
            CRessourceMaterielle.c_champId,
            CRessourceMaterielle.c_champId,
            true,
            false)]
        [DynamicField("Resource")]
        public CRessourceMaterielle Ressource
        {
            get
            {
                return (CRessourceMaterielle) GetParent(CRessourceMaterielle.c_champId, typeof(CRessourceMaterielle));
            }

            set
            {
                SetParent(CRessourceMaterielle.c_champId, value);
            }
        }

    }
}
