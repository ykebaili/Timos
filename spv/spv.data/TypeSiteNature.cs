using System;
using System.Collections.Generic;
using System.Text;

using sc2i.common;

namespace spv.data
{

	public enum ETypeSiteNature
	{
		NDEF	= 0,		// Non défini
        PS      = 1,		// "Point de service"(TDF) ou "Site Terrestre"(autres clients)
        GR      = 2,		// "Groupe de diffusion"(TDF) ou "Groupes de sites" (autres clients)
        IG		= 3 		// "Implantation géographique" (TDF) (inexistant pour autres clients
	}

	public class CTypeSiteNature : CEnumALibelle<ETypeSiteNature>
	{
        public CTypeSiteNature(ETypeSiteNature nature)
            : base(nature)
		{
		}


		public override string Libelle
		{
			get 
			{
				switch (Code)
				{
                    case ETypeSiteNature.NDEF:
						return I.T("Not defined|9");
                    case ETypeSiteNature.PS:
                        return I.T("Terrestrial sites|10");
                    case ETypeSiteNature.GR:
                        return I.T("Group of sites|11");
                    case ETypeSiteNature.IG:
                        return I.T("A physical site|12");
					default:
						break;
				}
				return "";
			}
			
		}
	}
}
