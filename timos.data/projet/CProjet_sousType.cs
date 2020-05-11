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
using sc2i.expression;

using timos.securite;
using timos.acteurs;
using tiag.client;


namespace timos.data
{
    /// <summary>
    /// Un projet a toujours un type principal, qui détermine ses formulaires
    /// et ses évenements. <BR></BR>
    /// En plus de son type principal, il peut avoir des sous-types qui
    /// permettent de lui ajouter d'autres formulaires.
    /// </summary>
    [DynamicClass("Project Sub type")]
	[ObjetServeurURI("CProjet_SousTypeServeur")]
	[Table(CProjet_SousType.c_nomTable, CProjet_SousType.c_champId, true)]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IngeProjet_ID)]
    [TiagClass(CProjet_SousType.c_nomTiag, "Id", true)]
    public partial class CProjet_SousType : 
        CObjetDonneeAIdNumeriqueAuto
	{
		#region Déclaration des constantes
        public const string c_nomTiag = "Project Sub type";

        public const string c_nomTable = "PROJECT_SUB_TYPE";
		public const string c_champId = "PRJSTP_ID";
		#endregion

		//-------------------------------------------------------------------
		public CProjet_SousType(CContexteDonnee ctx)
			: base(ctx)
		{
		}

		//-------------------------------------------------------------------
		public CProjet_SousType(System.Data.DataRow row)
			: base(row)
		{
		}

        //-------------------------------------------------------------------
        public object[] TiagKeys
        {
            get { return new object[] { Id }; }
        }

        public string TiagType
        {
            get { return c_nomTiag; }
        }

        //-------------------------------------------------------------------
        public override string DescriptionElement
        {
			get 
			{
                return I.T("Projet Sub type @1 for @2|20153",
                    SousType == null ? "?" : SousType.Libelle,
                    Projet == null ? "?" : Projet.Libelle);
			}
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
        /// Projet pour lequel le sous-type s'applique
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


        //-------------------------------------------------------------------
        /// <summary>
        /// Le sous type du projet
        /// </summary>
        [Relation(
            CTypeProjet.c_nomTable,
            CTypeProjet.c_champId,
            CTypeProjet.c_champId,
            true,
            false,
            true)]
        [DynamicField("Sub Type")]
        public CTypeProjet SousType
        {
            get
            {
                return (CTypeProjet)GetParent(CTypeProjet.c_champId, typeof(CTypeProjet));
            }
            set
            {
                SetParent(CTypeProjet.c_champId, value);
            }
        }

	


	

               
    }
}
