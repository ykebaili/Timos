using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using sc2i.data.dynamic;

namespace timos.data.preventives
{
	public interface IElementADessiner
	{
		void Refresh();
		Image CacheDessin { get;}
		void Draw(Graphics g, Rectangle rect);
	}

	
}
