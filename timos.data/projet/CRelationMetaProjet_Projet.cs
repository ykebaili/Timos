using System;
using System.Data;

using sc2i.common;
using sc2i.data;

namespace timos.data.projet
{
	
	/// <summary>
	/// Lien entre un meta-projet et un projet
	/// </summary>
    /// <remarks>
    /// Les liens entre meta-projet et projet sont statiques.
    /// Ils sont recalculés lorsqu'on demande à un meta projet
    /// de rafraichir ses liens.
    /// </remarks>
	[Table(CRelationMetaProjet_Projet.c_nomTable, 
		 CRelationMetaProjet_Projet.c_champId,
		 true)]
	[ObjetServeurURI("CRelationMetaProjet_ProjetServeur")]
	[DynamicClass("Meta project/project")]
	public class CRelationMetaProjet_Projet : CObjetDonneeAIdNumeriqueAuto, IObjetALectureTableComplete
	{
		public const string c_nomTable = "META_PROJECT_PROJECT";

		public const string c_champId = "MEPRJPRJ_ID";
        public const string c_champIsAutoAdded = "MEPRJPRJ_AUTOADDED";

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ctx"></param>
		public CRelationMetaProjet_Projet( CContexteDonnee ctx)
			:base(ctx)
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="row"></param>
		public CRelationMetaProjet_Projet ( DataRow row )
			:base(row)
		{
		}

		/// <summary>
		/// 
		/// </summary>
		public override string DescriptionElement
		{
			get
			{
                string strInfo = I.T("Link between  @1 and @2|194",
                    MetaProjet != null ? MetaProjet.Libelle : "?",
                    Projet != null ? Projet.Libelle : "?");
                return strInfo;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champId};
		}

		/// <summary>
		/// 
		/// </summary>
		protected override void MyInitValeurDefaut()
		{
            IsAutoAdded = false;
		}

		/// <summary>
		/// Meta projet concerné par le lien
		/// </summary>
		[Relation(CMetaProjet.c_nomTable, CMetaProjet.c_champId, CMetaProjet.c_champId, true, true, true)]
        [DynamicField("Meta project")]
		public CMetaProjet MetaProjet
		{
			get
			{
				return (CMetaProjet)GetParent ( CMetaProjet.c_champId, typeof(CMetaProjet));
			}
			set
			{
				SetParent ( CMetaProjet.c_champId, value );
			}
		}

        
        //-------------------------------------------------------------------
        /// <summary>
        /// Projet concerné par le lien
        /// </summary>
        [Relation(
            CProjet.c_nomTable,
            CProjet.c_champId,
            CProjet.c_champId,
            true,
            true,
            true)]
        [DynamicField("Project")]
        public CProjet Projet
        {
            get
            {
                return (CProjet)GetParent(CProjet.c_champId, typeof(CProjet));
            }
            set
            {
                SetParent(CProjet.c_champId, value);
            }
        }

        /// <summary>
        /// Indique si le projet a été ajouté manuellement (false) 
        /// au méta projet, ou s'il a été ajouté dynamiquement, via
        /// le filtre du méta projet
        /// </summary>
        [TableFieldProperty(c_champIsAutoAdded)]
        [DynamicField("Is auto added")]
        public bool IsAutoAdded
        {
            get
            {
                return Row.Get<bool>(c_champIsAutoAdded);
            }
            set
            {
                Row[c_champIsAutoAdded] = value;
            }
        }

	


	}
}
