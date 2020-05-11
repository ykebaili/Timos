using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.win32.common.customizableList;
using timos.data;
using System.Drawing;

namespace timos.interventions.crintervention
{
    public class CItemOperation : CCustomizableListItemANiveau
    {

        //---------------------------------------------------
        public CItemOperation(COperation operation, CItemOperation itemParent)
            :base(itemParent)
        {
            Tag = operation;
        }

        //---------------------------------------------------
        public COperation Operation
        {
            get
            {
                return Tag as COperation;
            }
            set
            {
                Tag = value;
            }
        }

        //--------------------------------------------------------------------
        public override bool IsCollapse
        {
            get { return false; }
        }

        //--------------------------------------------------------------------
        public override bool OnChangeParent(CCustomizableListItemANiveau item)
        {
            if (Operation != null )
            {
                if (item != null && item.Tag is COperation)
                {
                    Operation.OperationParente = (COperation)item.Tag;
                    Operation.Niveau = ((COperation)item.Tag).Niveau + 1;
                    return true;
                }
                else
                {
                    Operation.OperationParente = null;
                    Operation.Niveau = 0;
                    return true;
                }
            }
            return false;
        }

        //--------------------------------------------------
        public override Color? ColorInactive
        {
            get
            {
                int nNiveau = Niveau;
                int nR = 255;
                int nG = 255;
                int nB = 255;
                //réduction des couleurs suivant les niveaux :
                /*0:1->5 : R et G
                 * 1:6->10 : R et B
                 * 2:11->15 : G et B
                 * 3:16->20 : R
                 * 4:21->25 : G
                 * 5:26->30 : B
                 * Au dela, reste blanc (ça permet de changer les couleurs sur 30 niveaux !
                 */
                int nTranche = (nNiveau) / 5;
                int nDec = ((nNiveau) % 5 + 1) * 25;
                switch (nTranche)
                {
                    case 0:
                        nR = 255 - nDec;
                        nG = 255 - nDec;
                        break;
                    case 1:
                        nR = 255 - nDec;
                        nB = 255 - nDec;
                        break;
                    case 2:
                        nG = 255 - nDec;
                        nB = 255 - nDec;
                        break;
                    case 3:
                        nR = 255 - nDec;
                        break;
                    case 4:
                        nG = 255 - nDec;
                        break;
                    case 5:
                        nB = 255 - nDec;
                        break;
                }
                return Color.FromArgb(nR, nG, nB);
            }
        }

        //--------------------------------------------
        public override int Index
        {
            get
            {
                return base.Index;
            }
            set
            {
                base.Index = value;
                if (Operation != null && Operation.IsValide())
                    Operation.Index = value;
            }
        }
    }
}
