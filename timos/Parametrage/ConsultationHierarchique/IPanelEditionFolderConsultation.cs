using System;
using System.Collections.Generic;
using System.Text;
using timos.data.workflow.ConsultationHierarchique;
using sc2i.common;
using sc2i.win32.common;

namespace timos.Parametrage.ConsultationHierarchique
{
	public interface IPanelEditionFolderConsultation : IControlALockEdition
	{
		void InitChamps(CFolderConsultationHierarchique folder);
		CResultAErreur MajChamps();
	}
}
