using System;
using sc2i.workflow;

using sc2i.data;

namespace timos.win32.composants
{
	/// <summary>
	/// Description résumée de IControlAgenda.
	/// </summary>
	public delegate void DemandeAffichageEntreeAgendaEventHandler ( IEntreeAgenda entree );
	public interface IControlAgenda
	{
		event DemandeAffichageEntreeAgendaEventHandler OnAfficherEntreeAgenda;
		event EventHandler OnDemandeCreationEntreeAgenda;
		void SetElementAAgenda ( CObjetDonneeAIdNumerique element );
		void SetElementsAAgenda ( CObjetDonneeAIdNumerique[] elements );
		DateTime DateEnCours{get;set;}
		CFiltreData FiltreAAppliquer{set;}

		void OnChangeDonnees ();

	}
}
