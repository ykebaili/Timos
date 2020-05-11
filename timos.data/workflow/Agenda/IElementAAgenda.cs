using System;
using System.Reflection;

namespace sc2i.workflow
{
	/// <summary>
	/// Tout �l�ment qui est capable de pr�senter un agenda.
	/// </summary>
	/// <remarks>
	/// Une �l�ment � agenda pr�sente sont agenda et celui des ses fils ou parents.
	/// Par exemple, un lot pr�sente l'agenda de ses lot/batiment
	/// </remarks>
	public interface IElementAAgenda
	{
		//Retourne la liste des propri�t�s qui acc�dent aux �l�ments
		//pour lequel l'�l�ment � agenda pr�sente les entr�es d'agenda
		string[] GetProprietesAccessSousElementsAgenda();
	}
}
