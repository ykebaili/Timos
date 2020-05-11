using System;
using System.Collections.Generic;
using System.Text;
using sc2i.common;
using timos.data;
using sc2i.drawing;


namespace timos
{
	public interface IEditeurWndElementDeProjet
	{
		event EventHandler ProprieteModifiee;

		void Init(I2iObjetGraphique elt);
		CResultAErreur MAJChamps();
		bool HasElementValide { get;}
	}
}
