using System;
using System.Collections.Generic;
using System.Text;

using sc2i.common;

namespace spv.data
{
    public enum EMaskedBy
	{
		Administrateur,
        Brigadier        
	}

    public class CMaskedBy : CEnumALibelle<EMaskedBy>
    {
        public CMaskedBy(EMaskedBy mask)
            : base(mask)
		{
		}
        
		public override string Libelle
		{
			get 
			{
				switch (Code)
				{
                    case EMaskedBy.Administrateur:
						return ("ADM");
                    case EMaskedBy.Brigadier:
						return ("BRI");
                    default:
						break;
				}
				return "";
			}            
		}
	}
}

            		