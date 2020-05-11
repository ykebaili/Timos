using System;
using System.Collections.Generic;
using System.Text;

using sc2i.common;

namespace spv.data
{
    public enum EProtocole
	{
		IS_GTR,
		IS_SEM,
		GSITE,
		DOMO20,
		SPY_SAT,
        SNMP
	}
   
    public class CProtocole : CEnumALibelle<EProtocole>
    {
        public CProtocole(EProtocole protocole)
            : base(protocole)
		{
		}
        
		public override string Libelle
		{
			get 
			{
				switch (Code)
				{
                    case EProtocole.IS_GTR:
						return "IS-GTR";
                    case EProtocole.IS_SEM:
						return "IS-SEM";
                    case EProtocole.GSITE:
						return "GSITE";
                    case EProtocole.DOMO20:
						return "DOMO20";
                    case EProtocole.SPY_SAT:
						return "SPY-SAT";
                    case EProtocole.SNMP:
                        return "SNMP";
					default:
						break;
				}
				return "";
			}            
		}
	}
}
