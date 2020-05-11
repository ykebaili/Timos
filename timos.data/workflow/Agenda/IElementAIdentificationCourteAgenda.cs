using System;

namespace sc2i.workflow
{
	/// <summary>
	/// Un élément qui peut retourner un identification courte
	/// à afficher dans les agendas (par exemple, les initiales du technicien)
	/// </summary>
	public interface IElementAIdentificationCourteAgenda
	{
		string IdentificationCourte{get;}
	}
}
