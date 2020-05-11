using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using sc2i.data.dynamic;
using timos.securite;
using tiag.client;


namespace timos.data
{

    /// <summary>
    /// Objet assurant la relation entre un <see cref="CTypeLienReseau">type de lien r�seau</see> support et un type de lien r�seau support�
    /// </summary>
    [DynamicClass("Supporting network link type / Supported network link type")] 
    [Table(CTypeLienReseauSupport.c_nomTable,CTypeLienReseauSupport.c_champId,true)]
    [FullTableSync]
    [ObjetServeurURI("CTypeLienReseauSupportServeur")]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_Liaisons_ID)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_Liaisons_ID)]
    [TiagClass("Network link support", "Id", true)]
    public class CTypeLienReseauSupport : CObjetDonneeAIdNumeriqueAuto
    {
        
		public const string c_nomTable = "NETWORK_LINK_SUPPORT";

		public const string c_champId = "NTW_LINK_SUP_ID";
		public const string c_champIdTypeSupportant = "NTWLNK_ID_SUPPORTING";
		public const string c_champIdTypeSupport� = "NTWLNK_ID_SUPPORTED";


        public CTypeLienReseauSupport(CContexteDonnee contexte)
            : base(contexte)
        {

        }

        public CTypeLienReseauSupport(DataRow row)
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
                return I.T("Supported Link Type|30089");
            }
        }

        //////////////////////////////////////////////////////////////////////////
        protected override void MyInitValeurDefaut()
        {
        }


        //-------------------------------------------------------------------
        /// <summary>
        /// Utilis� par TIAG pour affecter le type support� par ses cl�s
        /// </summary>
        /// <param name="lstCles"></param>
        public void TiagSetSupportedTypeKeys(object[] lstCles)
        {
            CTypeLienReseau typeLien = new CTypeLienReseau(ContexteDonnee);
            if (typeLien.ReadIfExists(lstCles))
                TypeSupport� = typeLien;
        }


        //---------------------------------------------------------------------------
        /// <summary>
        /// Obtient ou d�finit Le type de lien support� de la relation entre les deux types de liens
        /// </summary>
        /// 

        [RelationAttribute(
            CTypeLienReseau.c_nomTable,
            CTypeLienReseau.c_champId,
            CTypeLienReseauSupport.c_champIdTypeSupport�,
            true,
            true)]
        [DynamicField("Supported link type")]
        [TiagRelation(typeof(CTypeLienReseau), "TiagSetSupportedTypeKeys")]
        public CTypeLienReseau TypeSupport�
        {
            get
            {
                return (CTypeLienReseau)GetParent(c_champIdTypeSupport�, typeof(CTypeLienReseau));
            }
            set
            {
                SetParent(c_champIdTypeSupport�, value);
            }

        }


        //-------------------------------------------------------------------
        /// <summary>
        /// Utilis� par TIAG pour affecter le type supportant par ses cl�s
        /// </summary>
        /// <param name="lstCles"></param>
        public void TiagSetSupportingTypeKeys(object[] lstCles)
        {
            CTypeLienReseau typeLien = new CTypeLienReseau(ContexteDonnee);
            if (typeLien.ReadIfExists(lstCles))
                TypeSupportant = typeLien;
        }


        /// <summary>
        /// Obtient ou d�finit Le type de lien support de la relation entre les deux types de liens
        /// </summary>
        /// 

        [RelationAttribute(
            CTypeLienReseau.c_nomTable,
            CTypeLienReseau.c_champId,
            CTypeLienReseauSupport.c_champIdTypeSupportant,
            true,
            true)]
        [DynamicField("Supporting link type")]
        [TiagRelation(typeof(CTypeLienReseau), "TiagSetSupportingTypeKeys")]
        public CTypeLienReseau TypeSupportant
        {
            get
            {
                return (CTypeLienReseau)GetParent(c_champIdTypeSupportant, typeof(CTypeLienReseau));
            }
            set
            {
                SetParent(c_champIdTypeSupportant, value);
            }
        }
    }
}
