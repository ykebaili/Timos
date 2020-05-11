using System;
using System.Collections;
using System.Text;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;

namespace timos.data
{
    /// <summary>
    /// Description résumée de CRelationTypeSite_TypeSite.
    /// Cet objet de relation permet de définir pour un <see cref="CTypeSite">type de site</see> donné,
    /// quels sont ceux qui peuvent y être inclus.
    /// Exemples : un type de site 'Batiment' peut être inclus dans un type de site 'POP'.
    /// Un type de site 'Salle' peut être inclus dans un type de site 'Batiment'.
    /// </summary>
    [DynamicClass("Site type relations")]
    [Table(CRelationTypeSite_TypeSite.c_nomTable, CRelationTypeSite_TypeSite.c_champId, true)]
    [ObjetServeurURI("CRelationTypeSite_TypeSiteServeur")]
    public class CRelationTypeSite_TypeSite : CObjetDonneeAIdNumeriqueAuto, IObjetALectureTableComplete
    {
        public const string c_nomTable = "SITETYPE_SITETYPE";
        public const string c_champId = "SITTP_SITTP_ID";

		public const string c_champTypeContenantId = "SITTP_SITTP_CONTAINER_ID";
		public const string c_champTypeContenuId = "SITTP_SITTP_INCLUDED_ID";


        /// /////////////////////////////////////////////
		public CRelationTypeSite_TypeSite( CContexteDonnee contexte)
			:base(contexte)
		{
		}

		/// /////////////////////////////////////////////
		public CRelationTypeSite_TypeSite(DataRow row)
			:base(row)
		{
		}

        //----------------------------------------- PROPRIETES -------------------------------------------
 		/// /////////////////////////////////////////////
        // Propriété de la classe 
		public override string DescriptionElement
		{
			get
			{
				return I.T("Relation between Site Types|274");
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
            return new string[] {c_champTypeContenantId};
		}

        //---------------------------------------------------------------
        /// <summary>
        /// <see cref="CTypeSite">Type de site</see> contenant, objet de la relation
        /// </summary>
        [Relation(CTypeSite.c_nomTable, CTypeSite.c_champId, c_champTypeContenantId, true, true)]
        [DynamicField("Container site type")]
        public CTypeSite TypeSiteContenant
        {
            get
            {
                return (CTypeSite)GetParent(c_champTypeContenantId, typeof(CTypeSite));
            }
            set
            {
                SetParent(c_champTypeContenantId, value);
            }
        }

        //----------------------------------------------------------
        /// <summary>
        /// <see cref="CTypeSite">Type de site</see> contenu, objet de la relation
        /// </summary>
        [Relation(CTypeSite.c_nomTable, CTypeSite.c_champId, c_champTypeContenuId, true, true)]
        [DynamicField("Included site type")]
        public CTypeSite TypeSiteContenu
        {
            get
            {
                return (CTypeSite)GetParent(c_champTypeContenuId, typeof(CTypeSite));
            }
            set
            {
                SetParent(c_champTypeContenuId, value);
            }
        }

    }
}
