using System;

namespace sc2i.workflow
{
	/// <summary>
	/// Un �l�ment qui peut retourner un identification courte
	/// � afficher dans les agendas (par exemple, les initiales du technicien)
	/// </summary>
	public interface IElementAIdentificationCourteAgenda
	{
		string IdentificationCourte{get;}
	}
}
