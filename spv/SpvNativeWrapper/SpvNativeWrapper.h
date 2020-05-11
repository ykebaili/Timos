// SpvNativeWrapper.h

#pragma once

#include "Mib.h"
#include "Adapter.h"

using namespace System;

namespace SpvNativeWrapper 
{

	public ref class CMibModuleWrapper:IDisposable
	{
	private:
		CMibModule * m_pMibModule;
		static const long c_classID = 12;
		String ^ m_connexionOracle;

	public:
		CMibModuleWrapper();
		~CMibModuleWrapper(void);

		int Compile ();

		void Init (String ^ connexionOracle, String ^ cheminFichier, String ^ nomModule, long moduleID);

		String ^ GetNextErrMess();

		bool AreCompileErrors();

		bool AreCompileLogs();

		String ^ GetCompileErrors();

		String ^ GetCompileLogs();
	};
}
