using System;
using System.Data;

using sc2i.data;
using sc2i.common;
using timos.data;
using sc2i.expression;
using timos.acteurs;
using sc2i.data.dynamic;


namespace spv.data
{
	[Table(CSpvChampCustomSNMP.c_nomTable,CSpvChampCustomSNMP.c_nomTableInDb,new string[]{ CSpvChampCustomSNMP.c_champId})]
	[ObjetServeurURI("CSpvChampCustomSNMPServeur")]
	[DynamicClass("SNMP custom field")]
    public class CSpvChampCustomSNMP : CMappableAvecTimos<CChampCustom,  CSpvChampCustomSNMP>
	{
		public const string c_nomTable = "SPV_SNMP_CUSTFLD";
		public const string c_nomTableInDb = "SNMP_CUSTFLD";
		public const string c_champId ="SNMPCSTFLD_ID";
        public const string c_champOId = "SNMPCSTFLD_OID";
        public const string c_champFormuleIndex = "SNMPCSTFLD_INDEX";
        public const string c_champIdChampCustomTimos = "SNMP_TIMOS_ID";
        public const string c_champGetOnly = "SNMP_GET_ONLY";

        /// <summary>
        /// L'affecation de valeurs de champ via SNMP se fait dans ce contexte
        /// (pour éviter de réaffecter à SNMP la valeur du champ)
        /// </summary>
        public const string c_contexteModificationRefreshFromSNMP = "SYSTEM_REFRESH_SNMP";
		
		///////////////////////////////////////////////////////////////
		public CSpvChampCustomSNMP( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public CSpvChampCustomSNMP( DataRow row )
			:base(row)
		{
		}
		
		///////////////////////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
		}

		///////////////////////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[] {c_champId};
		}
		
		///////////////////////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
                return I.T("Custom SNMP field|20019");
			}
		}
		
			
		///////////////////////////////////////////////////////////////
        [TableFieldProperty(CSpvChampCustomSNMP.c_champOId, 2000)]
        [DynamicField("OID")]
        public string OID
        {
            get
            {
                return (string)Row[c_champOId];
            }
            set
            {
                Row[c_champOId] = value;
            }
        }

        ///////////////////////////////////////////////////////////////
        [TableFieldProperty(CSpvChampCustomSNMP.c_champFormuleIndex, 4000)]
        [DynamicField("Formula")]
        public string FormuleIndexString
        {
            get
            {
                return (string)Row[c_champFormuleIndex];
            }
            set
            {
                Row[c_champFormuleIndex] = value;
            }
        }

        ///////////////////////////////////////////////////////////////
        public C2iExpression FormuleIndex
        {
            get
            {
                return C2iExpression.FromPseudoCode(FormuleIndexString);
            }
            set
            {
                if (value == null)
                    FormuleIndexString = "";
                else
                    FormuleIndexString = C2iExpression.GetPseudoCode(value);
            }
        }


        public override string GetChampIdObjetTimos()
        {
            return c_champIdChampCustomTimos;
        }

        [Relation ( 
            CChampCustom.c_nomTable,
            CChampCustom.c_champId,
            CSpvChampCustomSNMP.c_champIdChampCustomTimos,
            true,
            true,
            IsInDb=false)]
        [DynamicField("Custom field")]
        public override CChampCustom ObjetTimosAssocie
        {
            get
            {
                return ObjetTimosAssocieProtected;
            }
            set
            {
                ObjetTimosAssocieProtected = value;
            }
        }

        /// <summary>
        /// Indique si on fait une mise  à jour de la valeur SNMP,
        /// ou si ce champ est uniquement en consultation SNMP et pas
        /// MAJ
        /// </summary>
        [TableFieldProperty(CSpvChampCustomSNMP.c_champGetOnly)]
        [sc2i.common.DynamicField("GetOnly")]
        public bool GetOnly
        {
            get
            {
                return (bool)Row[c_champGetOnly];
            }
            set
            {
                Row[c_champGetOnly] = value;
            }
        }


        public override void CopyFromObjetTimos(CChampCustom objetTimos)
        {
            
        }
    }
}
