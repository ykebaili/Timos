using System;
using System.Collections;
using System.Data;
using System.Collections.Generic;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;

namespace timos.data.version
{
	public interface IElementATypeStructurant<TypeStructurant> : IElementATypeStructurantBase
	{
		TypeStructurant ElementStructurant { get;}
	}

	public interface IElementATypeStructurantBase
	{
		int IdTypeStructurant {get;}
	}
}
