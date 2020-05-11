using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using sc2i.data;
using sc2i.common;
using sc2i.data.serveur;
using spv.data;



namespace spv.data.serveur
{
    public class CSpvParamSystemeServeur :CSpvParamServeur
    {
        

        
        public CSpvParamSystemeServeur ( int nIdSession )
			:base(nIdSession)
		{
		}


        protected override CFiltreData GetMyFiltreSysteme()
        {
            CFiltreData filtre = new CFiltreData(CSpvParamSysteme.c_champPARAM_TYPE +"=9");
            return filtre;
        }


    }
}
