using System;
using System.Collections.Generic;
using System.Text;

using sc2i.common;

namespace spv.data
{
    public enum ETypeSon
	{
		Normal
	}

    public class CTypeSon : CEnumALibelle<ETypeSon>
    {
        public CTypeSon(ETypeSon alEvent)
            : base(alEvent)
		{
		}
        
		public override string Libelle
		{
			get 
			{
				switch (Code)
				{
                    case ETypeSon.Normal:
						return I.T("Normal|112");
                    default:
						break;
				}
				return "";
			}            
		}
	}
}

            		