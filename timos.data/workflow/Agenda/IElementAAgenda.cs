using System;
using System.Reflection;

namespace sc2i.workflow
{
	/// <summary>
	/// Tout élément qui est capable de présenter un agenda.
	/// </summary>
	/// <remarks>
	/// Une élément à agenda présente sont agenda et celui des ses fils ou parents.
	/// Par exemple, un lot présente l'agenda de ses lot/batiment
	/// </remarks>
	public interface IElementAAgenda
	{
		//Retourne la liste des propriétés qui accèdent aux éléments
		//pour lequel l'élément à agenda présente les entrées d'agenda
		string[] GetProprietesAccessSousElementsAgenda();
	}
}
