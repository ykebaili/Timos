using System;

using sc2i.common;


namespace timos.data
{
	public enum EFaceVueDynamique
	{
		Front = 0,
        Left = 1,
        Top = 2,
        Rear = 3,
        Right = 4,
        Bottom = 5
	}

	public class CFaceVueDynamique : CEnumALibelle<EFaceVueDynamique>
	{
		/// //////////////////////////////////////////////////////
		public CFaceVueDynamique(EFaceVueDynamique ope)
			: base(ope)
		{
		}

		/// //////////////////////////////////////////////////////
		public override string Libelle
		{
			get
			{
				string result = "";
                switch (Code)
                {
                    case EFaceVueDynamique.Front:
                        return I.T("Front|20062");
                    case EFaceVueDynamique.Left:
                        return I.T("Top|20063");
                    case EFaceVueDynamique.Top:
                        return I.T("Top|20064");
                    case EFaceVueDynamique.Rear:
                        return I.T("Rear|20065");
                    case EFaceVueDynamique.Right:
                        return I.T("Right|20066");
                    case EFaceVueDynamique.Bottom: 
                        return I.T("Bottom|20067");
                    default:
                        break;
                }
				return result;
			}
		}
	}
}
