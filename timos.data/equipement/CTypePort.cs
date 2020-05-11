using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

using sc2i.data;
using sc2i.common;
using sc2i.multitiers.client;
using sc2i.data.dynamic;

using sc2i.process;

using sc2i.workflow;
using timos.data;
using timos.securite;
using tiag.client;
using System.Data;
using timos.data.equipement;


namespace timos.data
{
    /// <summary>
    /// Type de port. Permet de définir le comportement des ports de ce type,
    /// sachant qu'un port correspond aux accès d'un <see cref="CEquipement">équipement</see> ou d'un <see cref="CTypeEquipement">type d'équipement</see>
    /// </summary>
    [DynamicClass("Port type")]
    [ObjetServeurURI("CTypePortServeur")]
    [Table(CTypePort.c_nomTable, CTypePort.c_champId, true)]
    [FullTableSync]
    [TiagClass("Port","Id", true)]
    public class CTypePort : CObjetDonneeAIdNumeriqueAuto
    {

        public const string c_nomTable = "PORT_TYPE";
        public const string c_champId = "PORT_TP_ID";
        public const string c_champLibelle = "PORT_TP_LABEL";


        public CTypePort( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CTypePort( System.Data.DataRow row )
			:base(row)
		{
		}

        //-------------------------------------------------------------------
        public override string DescriptionElement
        {
            get
            {
                return I.T("Port type @1|50000", Libelle);
            }
        }

        //-------------------------------------------------------------------
        public override string[] GetChampsTriParDefaut()
        {
            return new string[]{c_champLibelle};
        }


        protected override void MyInitValeurDefaut()
        {
        }

        public override string GetNomTable()
        {
            return c_nomTable;
        }
        //-------------------------------------------------------------------
        public override string GetChampId()
        {
            return c_champId;
        }


        /// <summary>
        /// Libellé du type de Port <br/>
        /// (obligatoire)
        /// </summary>
        [DescriptionField]
        [TableFieldProperty(c_champLibelle, 255)]
        [DynamicField("Label")]
        [TiagField("Label")]
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



        
    }
}
