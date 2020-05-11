using System;
using System.Collections.Generic;
using System.Text;
using sc2i.workflow;
using sc2i.data;

namespace timos.data
{

	public interface IElementAContacts : IObjetDonneeAIdNumeriqueAuto
	{
		ITypeElementAContacts TypeElementAContactPossible { get; }
	}
}
