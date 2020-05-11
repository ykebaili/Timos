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

namespace timos.data
{
    [Table(CLienReseauSupport.c_nomTable, CLienReseauSupport.c_champId, true)]
    [FullTableSync]
    [ObjetServeurURI("CLienReseauSupportServeur")]    
    public class CLienReseauSupport : CObjetDonneeAIdNumeriqueAuto
    {
        public const string c_nomTable = "NTWLNK_SUPPORT";
        public const string c_champId = "NTWLNK_SUP_ID";
		public const string c_champIdSupporte = "NTWLN_ID_SUPPORTED";
		public const string c_champIdEstSupporte = "NTWLN_ID_SUPPORTING";


         public CLienReseauSupport(CContexteDonnee contexte)
            : base(contexte)
        {

        }

        public CLienReseauSupport(DataRow row)
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
                return I.T("Support Network Links|30090");
            }
        }



        //////////////////////////////////////////////////////////////////////////
        protected override void MyInitValeurDefaut()
        {
        }


        //---------------------------------------------------------------------------



        /// <summary>
        /// Le lien parent de la relation entre les deux liens
        /// </summary>
        /// 

        [RelationAttribute(
            CLienReseau.c_nomTable,
            CLienReseau.c_champId,
            CLienReseauSupport.c_champIdEstSupporte,
            true,
            true,
            false)]
        [DynamicField("Supported link")]
        public CLienReseau EstSupporte
        {
            get
            {
                return (CLienReseau)GetParent(c_champIdEstSupporte, typeof(CLienReseau));
            }
            set
            {
                SetParent(c_champIdEstSupporte, value);
            }

        }


        /// <summary>
        /// Le lien fils de la relation entre les deux liens
        /// </summary>
        /// 

        [RelationAttribute(
            CLienReseau.c_nomTable,
            CLienReseau.c_champId,
            CLienReseauSupport.c_champIdSupporte,
            true,
            true,
            false)]
        [DynamicField("Supporting link")]
        public CLienReseau Supporte
        {
            get
            {
                return (CLienReseau)GetParent(c_champIdSupporte, typeof(CLienReseau));
            }
            set
            {
                SetParent(c_champIdSupporte, value);
            }
        }

    }
}
