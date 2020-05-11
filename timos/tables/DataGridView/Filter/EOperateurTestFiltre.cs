using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using sc2i.data;
using sc2i.common;

namespace timos.tables
{
	public enum EOperateurTestFiltre
	{
		Egal,
		Different,
		PlusPetit,
		PlusGrand,
		PlusPetitOuEgal,
		PlusGrandOuEgal,
		Contient,
		NeContientPas,
		CommencePar,
		NeCommencePasPar,
		TerminePar,
		NeTerminePasPar,
		Null,
		NonNull,
	}


	public class COperateurTestFiltre : CEnumALibelle<EOperateurTestFiltre>
	{
		/// //////////////////////////////////////////////////////
		public COperateurTestFiltre(EOperateurTestFiltre ope)
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
					case EOperateurTestFiltre.Egal:
						result = I.T( "Equal|90");
						break;
					case EOperateurTestFiltre.Different:
						result = I.T( "Different|95");
						break;
					case EOperateurTestFiltre.PlusPetit:
						result = I.T( "Lesser|91");
						break;
					case EOperateurTestFiltre.PlusGrand:
						result = I.T( "Greater|92");
						break;
					case EOperateurTestFiltre.PlusPetitOuEgal:
						result = I.T( "Lesser or equal|93");
						break;
					case EOperateurTestFiltre.PlusGrandOuEgal:
						result = I.T( "Greater or equal|94");
						break;
					case EOperateurTestFiltre.Contient:
						result = I.T( "Like|74");
						break;
					case EOperateurTestFiltre.NeContientPas:
						result = I.T( "Not like|75");
						break;
					case EOperateurTestFiltre.CommencePar:
						result = I.T( "Starts with|72");
						break;
					case EOperateurTestFiltre.NeCommencePasPar:
						result = I.T( "Does not starts with|73");
						break;
					case EOperateurTestFiltre.TerminePar:
						result = I.T( "Ends with|76");
						break;
					case EOperateurTestFiltre.NeTerminePasPar:
						result = I.T( "Does not end with|77");
						break;
					case EOperateurTestFiltre.Null:
						result = I.T( "Is Null|96");
						break;
					case EOperateurTestFiltre.NonNull:
						result = I.T( "Is Not Null|97");
						break;
					default:
						break;
				}
				return result;
			}
		}
	}
}
