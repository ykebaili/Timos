using System;
using System.Data;
using sc2i.data;
using sc2i.common;

namespace spv.data
{
	[Table(CSpvParam.c_nomTable,CSpvParam.c_nomTableInDb,new string[]{ CSpvParam.c_champPARAM_ID})]
	[ObjetServeurURI("CSpvParamServeur")]
	[DynamicClass("Spv Parameters")]
	public class	CSpvParam : CObjetDonneeAIdNumeriqueAuto, IObjetSansVersion
	{
		public const string c_nomTable = "SPV_PARAM";
		public const string c_nomTableInDb = "PARAM";
		public const string c_champPARAM_ID ="PARAM_ID";
		public const string c_champPARAM_TYPE ="PARAM_TYPE";
		public const string c_champPARAM_VALEUR ="PARAM_VALEUR";
		public const string c_champPARAM_COMMENT ="PARAM_COMMENT";
		
		///////////////////////////////////////////////////////////////
		public CSpvParam( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public CSpvParam( DataRow row )
			:base(row)
		{
		}
		
		///////////////////////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
            CodeTypeParam = (int)ETypeSpvParam.Systeme;
		}
		
		///////////////////////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[] {c_champPARAM_ID};
		}
		
		///////////////////////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T("Parameter @1|30039",Id.ToString());
			}
		}
		

	
		
		///////////////////////////////////////////////////////////////

		///////////////////////////////////////////////////////////////

		[TableFieldProperty(c_champPARAM_TYPE)]
        [DynamicField("Parameter Type")]
		public int CodeTypeParam
		{
			get
			{
				return (int)Row[c_champPARAM_TYPE];
			}
			set
			{
				Row[c_champPARAM_TYPE,true]=value;
			}
		}


		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champPARAM_VALEUR,40)]
		[DynamicField("Parameter value")]
		public string ParamValeur

		{
			get
			{
				return (System.String)Row[c_champPARAM_VALEUR];
			}
			set
			{
				Row[c_champPARAM_VALEUR,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champPARAM_COMMENT,80)]
		[DynamicField("Comments")]
		public string Commentaire

		{
			get
			{
				if (Row[c_champPARAM_COMMENT] == DBNull.Value)
					return null;
				return (string)Row[c_champPARAM_COMMENT];
			}
			set
			{
				Row[c_champPARAM_COMMENT,true]=value;
			}
		}


        public string NomParam
        {
            get
            {
              if(!ParamValeur.Contains("="))
                return "";
              else
                 
                return  ParamValeur.Substring(0,ParamValeur.IndexOf("="));

            }
            set
            {
                if (ParamValeur.Contains("="))
                {
                    if (value != "")
                    {
                        string strValeur = ParamValeur.Substring(ParamValeur.IndexOf("="), ParamValeur.Length - ParamValeur.IndexOf("="));
                        ParamValeur = value + strValeur;
                    }
                    else
                    {
                        string strValeur = ParamValeur.Substring(ParamValeur.IndexOf("=")+1, ParamValeur.Length - ParamValeur.IndexOf("=")-1);
                        ParamValeur =  strValeur;
                    }
     
                }
                else if (value != "")
                {
                    if (ParamValeur == "")
                        ParamValeur = value + "=";
                    else
                    {
                        string strVal = ParamValeur;
                        ParamValeur = value + "=" + strVal; ;

                    }
                }
            }
        }


        public CTypeParametreSPV TypeParametre
        {

            get
            {
                return new CTypeParametreSPV((ETypeSpvParam)CodeTypeParam);
            }
            set
            {
                if (value != null)
                    CodeTypeParam = value.CodeInt;
            }

        }
        public string Valeur
        {
            get
            {
                if (!ParamValeur.Contains("="))
                    return ParamValeur;
                else

                    return ParamValeur.Substring(ParamValeur.IndexOf("=") + 1,ParamValeur.Length-ParamValeur.IndexOf("=")-1);
            }
            set
            {
                string strNomParam = "";
                if (NomParam == "")
                    ParamValeur = value;

                else
                {
                    if (ParamValeur.Contains("="))
                    {
                        strNomParam = ParamValeur.Substring(0, ParamValeur.IndexOf("="));
                        ParamValeur = strNomParam +"="+ value;
                                   
                    }                    

                 }
            }
        }
	}
}











