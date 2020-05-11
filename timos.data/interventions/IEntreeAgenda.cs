using System;


namespace sc2i.workflow
{
	/// <summary>
	/// Description résumée de IEntreeAgenda.
	/// </summary>
	public interface IEntreeAgenda
	{
		string Libelle{get;}
		DateTime DateDebut { get;set;}
		DateTime DateFin { get;set;}
		bool SansHoraire{get;}
		CEtatEntreeAgenda Etat{get;}
		string Commentaires{get;}

		string IdAppliExterne{get;}
		string IdExterne{get;}
	}
}
