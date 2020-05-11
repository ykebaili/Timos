using System;
using System.Collections.Generic;
using System.Text;

using sc2i.common;

namespace spv.data
{
    public enum EEtatOperationnelService
	{
		OK =0,
        Min=1,
        Maj=2,
        KO =3,
        Plus=4
    }

    //" OK"
    //" min
    //" maj
    //" KO"

    public class CEtatOperationnelService : CEnumALibelle<EEtatOperationnelService>
    {
        public CEtatOperationnelService(EEtatOperationnelService alNature)
            : base(alNature)
		{
		}
        
		public override string Libelle
		{
			get 
			{
				switch (Code)
				{
                    case EEtatOperationnelService.OK:
                        return "OK";
                    case EEtatOperationnelService.Min:
                        return "min";
                    case EEtatOperationnelService.Maj:
                        return "maj";
                    case EEtatOperationnelService.KO:
                        return "KO";
                    case EEtatOperationnelService.Plus:
                        return "+";
                    default:
						break;
				}
				return "";
			}            
		}
	}
}

            		