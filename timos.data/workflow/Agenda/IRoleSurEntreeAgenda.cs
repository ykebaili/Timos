using System;
using System.Drawing;

namespace sc2i.workflow
{
	/// <summary>
	/// Description résumée de IRoleSurEntreeAgenda.
	/// </summary>
	public interface IRoleSurEntreeAgenda
	{
		string IdRole{get;}
		Bitmap Image{get;}
		string Libelle{get;}
	}
}
