using System;
using System.Collections.Generic;
using System.Text;
using sc2i.common;
using sc2i.data;

namespace timos.data.interventions
{
	/// <summary>
	/// Ajoute une méthode à CObjetDonneeAIdNumeriqueAuto, pour
	/// qu'il puisse retourner la valeur d'une variable
	/// </summary>
	[AutoExec("Autoexec")]
	public class CIntervention_MethodePourCVersion : CMethodeSupplementaire
	{
		protected CIntervention_MethodePourCVersion()
			: base(typeof(CObjetDonneeAIdNumerique))
		{
		}

		public static void Autoexec()
		{
			CGestionnaireMethodesSupplementaires.RegisterMethode(new CIntervention_MethodePourCVersion());
		}

		public override string Name
		{
			get
			{
				return "GetInterventions";
			}
		}

		public override string Description
		{
			get
			{
				return I.T("Returns linked interventions|20004");
			}
		}

		public override Type ReturnType
		{
			get
			{
				return typeof(CIntervention);
			}
		}

		public override bool ReturnArrayOfReturnType
		{
			get
			{
				return true;
			}
		}


		public override CInfoParametreMethodeDynamique[] InfosParametres
		{
			get
			{
				return new CInfoParametreMethodeDynamique[]
					{
					};
			}
		}

		public override object Invoke(object objetAppelle, params object[] parametres)
		{
			if (!(objetAppelle is CVersionDonnees))
				return new CIntervention[0];
			CListeObjetsDonnees liste = new CListeObjetsDonnees(((CObjetDonnee)objetAppelle).ContexteDonnee, typeof(CIntervention));
			liste.Filtre = new CFiltreData(CVersionDonnees.c_champId + "=@1",
				((CVersionDonnees)objetAppelle).Id);
			return liste.ToArray(typeof(CIntervention));
			
		}
	}
}
