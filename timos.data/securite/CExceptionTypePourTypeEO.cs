using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using sc2i.data.dynamic;

using timos.data;


namespace timos.securite
{

    /// <summary>
    /// Permet de rendre invisibles les EO de certains, dans l'interface utilisateur
    /// </summary>
    [DynamicClass("Type Exclusion for OE Type")]
    [Table(CExceptionTypePourTypeEO.c_nomTable, CExceptionTypePourTypeEO.c_champId, true)]
    [FullTableSync]
    [ObjetServeurURI("CExceptionTypePourTypeEOServeur")]
    public class CExceptionTypePourTypeEO : CObjetDonneeAIdNumeriqueAuto, IObjetALectureTableComplete
    {
        public const string c_nomTable = "OETYPE_EXCEPTION";

        public const string c_champId = "OETYPE_EXCPTN_ID";
        public const string c_champTypeElement = "OETYPE_EXCPTN_TYPELT";


        /// <summary>
		/// 
		/// </summary>
		/// <param name="ctx"></param>
		public CExceptionTypePourTypeEO(CContexteDonnee ctx)
			: base(ctx)
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="row"></param>
        public CExceptionTypePourTypeEO(DataRow row)
			: base(row)
		{
		}

        /// <summary>
        /// 
        /// </summary>
        public override string DescriptionElement
        {
            get
            {
                string strInfo = I.T("Exception for EO Type @1 |");
               
                return strInfo;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string[] GetChampsTriParDefaut()
        {
            return new string[] { c_champId };
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void MyInitValeurDefaut()
        {
        }



        //-------------------------------------------------------------------
        /// <summary>
        /// Le Type d'entité organisationnelle pour laquelle s'applique cette restriction
        /// </summary>
        [Relation(
            CTypeEntiteOrganisationnelle.c_nomTable,
            CTypeEntiteOrganisationnelle.c_champId,
            CTypeEntiteOrganisationnelle.c_champId,
            true,
            true,
            false)]
        [DynamicField("Organisational entity type")]
        public CTypeEntiteOrganisationnelle TypeEntiteOrganisationnelle
        {
            get
            {
                return (CTypeEntiteOrganisationnelle)GetParent(CTypeEntiteOrganisationnelle.c_champId, typeof(CTypeEntiteOrganisationnelle));
            }
            set
            {
                SetParent(CTypeEntiteOrganisationnelle.c_champId, value);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public Type TypeElement
        {
            get
            {
                return CActivatorSurChaine.GetType(StringTypeElement);
            }
            set
            {
                StringTypeElement = value.ToString();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [TableFieldProperty(c_champTypeElement, 1024)]
        [IndexField]
        public string StringTypeElement
        {
            get
            {
                return (string)Row[c_champTypeElement];
            }
            set
            {
                Row[c_champTypeElement] = value;
            }
        }
    }
}
