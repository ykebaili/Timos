using System;
using System.Drawing;
using System.Collections.Generic;

namespace timos.data
{
	public interface IWndElementDeProjetPlanifiable
	{
		bool Detacher { get; set;}
		Point Position { get;set;}
		Size Size { get;set;}
		Point[] GetPolygoneDessin();
		Rectangle RectangleAbsolu { get;}
		IElementDeProjetPlanifiable ElementDuProjet { get; set;}
	}
}
