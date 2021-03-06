using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

using sc2i.data;
using sc2i.common;
using sc2i.process;
using sc2i.multitiers.client;

using sc2i.data.dynamic;
using sc2i.common.planification;

using timos.securite;
using timos.acteurs;
using sc2i.expression;
using System.Drawing;
using sc2i.drawing;
using System.Drawing.Imaging;


namespace timos.data
{
    /// <summary>
    /// Relation entre types de projets. Exprime la hiérarchie entre types de projets.
    /// </summary>
    [DynamicClass("Project type hierarchy")]
	[ObjetServeurURI("CRelationTypeProjet_TypeProjetServeur")]
	[Table(CRelationTypeProjet_TypeProjet.c_nomTable, CRelationTypeProjet_TypeProjet.c_champId, true)]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IngeProjet_ID)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_TypeProjet_ID)]
    public partial class CRelationTypeProjet_TypeProjet : CObjetDonneeAIdNumeriqueAuto
	{
		#region Déclaration des constantes
		public const string c_nomTable = "PROJECTTYPE_HIERARCHY";
		public const string c_champId = "PJTPHI_ID";
        public const string c_champTypeParent = "PJTPHI_PARENT_ID";
        public const string c_champTypeFils = "PJTPHI_CHILD_ID";
		
		#endregion

		//-------------------------------------------------------------------
		public CRelationTypeProjet_TypeProjet(CContexteDonnee ctx)
			: base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationTypeProjet_TypeProjet(System.Data.DataRow row)
			: base(row)
		{
		}

		/// /////////////////////////////////////////////
        public override string DescriptionElement
        {
			get { return I.T( "Hierarchy link between @1 and @2|20083",
                TypeProjetParent != null?TypeProjetParent.Libelle:"?",
                TypeProjetFils != null?TypeProjetFils.Libelle:"?"); }
        }

        /// /////////////////////////////////////////////
        protected override void MyInitValeurDefaut()
        {
        }

        /// /////////////////////////////////////////////
        public override string[] GetChampsTriParDefaut()
        {
            return new string[] { c_champId };
        }
		

        //-------------------------------------------------------------------
        /// <summary>
        /// Type de projet parent
        /// </summary>
        [Relation(
            CTypeProjet.c_nomTable,
            CTypeProjet.c_champId,
            c_champTypeParent,
            true,
            true,
            false)]
        [DynamicField("Parent Project Type")]
        public CTypeProjet TypeProjetParent
        {
            get
            {
                return (CTypeProjet)GetParent(c_champTypeParent, typeof(CTypeProjet));
            }
            set
            {
                SetParent(c_champTypeParent, value);
            }
        }


        //-------------------------------------------------------------------
        /// <summary>
        /// Type de projet enfant
        /// </summary>
        [Relation(
            CTypeProjet.c_nomTable,
            CTypeProjet.c_champId,
            c_champTypeFils,
            true,
            true,
            false)]
        [DynamicField("Child project type")]
        public CTypeProjet TypeProjetFils
        {
            get
            {
                return (CTypeProjet)GetParent(c_champTypeFils, typeof(CTypeProjet));
            }
            set
            {
                SetParent(c_champTypeFils, value);
            }
        }

	


	

    }






}
