using System;
using System.Collections;
using System.Data;
using System.Collections.Generic;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;

namespace timos.data
{
	public interface IElementATableParametrable
	{
		string DescriptionElement { get;}
		CListeObjetsDonnees TablesParametrables { get;}

		CListeObjetsDonnees TypesTableParametrablePossibles { get;}
	}
}
