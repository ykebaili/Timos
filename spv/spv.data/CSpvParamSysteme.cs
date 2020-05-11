using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using sc2i.data;
using sc2i.common;


namespace spv.data
{
    [Table(CSpvParam.c_nomTable,CSpvParam.c_nomTableInDb,new string[]{ CSpvParam.c_champPARAM_ID})]
	[ObjetServeurURI("CSpvParamSystemeServeur")]
	[DynamicClass("System parameter")]
    public class CSpvParamSysteme : CSpvParam, IObjetALectureTableComplete
    {
        public const string c_nomTable = "SPV_PARAM_SYSTEME";


        public const string c_parametreAFF_ALPHA_FAMILLE="AFF_ALPHA_FAMILLE";
        public const string c_parametreALARM_ENGLOB="ALARM_ENGLOB";
        public const string c_parametreCALC_OBJ_OPER="CALC_OBJ_OPE";
        public const string c_parametreLANG_BDD="LANG_BDD";
        public const string c_parametreLIAI_MULTI_PREST="LIAI_MULTI_PREST";
        public const string c_parametreSEEK_EDC_IN_ALL_SITE="SEEK_EDC_IN_ALL_SITE";
        public const string c_parametreSPV_GLOBAL="SPV_GLOBAL";
        public const string c_parametreTYPE_E10 = "TYPE_E10";
        public const string c_parametreSNMP_TIMEOUT = "SNMP_TIMEOUT";
        public const string c_parametreSNMP_RETRY = "SNMP_RETRY";



        ///////////////////////////////////////////////////////////////
		public CSpvParamSysteme( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public CSpvParamSysteme( DataRow row )
			:base(row)
		{
		}

        protected override void MyInitValeurDefaut()
        {
            CodeTypeParam = (int)ETypeSpvParam.Systeme; 
        }


        public  CTypeParametreSPV TypeParametre
        {

            get
            {
                return new CTypeParametreSPV((ETypeSpvParam)CodeTypeParam);
            }
            set
            {

                CodeTypeParam = (int)ETypeSpvParam.Systeme;
            }
        }

        ///////////////////////////////////////////////////////////////
		/// <summary>
		/// récupère un paramètre système
		/// </summary>
		/// <param name="strParametre"></param>
		/// <returns></returns>
        public static string GetParametreSysteme ( string strParametre )
        {
            CSpvParamSysteme parametre = new CSpvParamSysteme ( CContexteDonneeSysteme.GetInstance() );
            if ( parametre.ReadIfExists ( new CFiltreData (c_champPARAM_VALEUR+" like @1",
                strParametre+"=%")))
            {
                return parametre.Valeur;
            }
            return "";
        }
    }
}
