// This is the main DLL file.

#include "stdafx.h"

#include "SpvNativeWrapper.h"

namespace SpvNativeWrapper 
{
	CMibModuleWrapper::CMibModuleWrapper()
	{
		m_pMibModule = new CMibModule ();
	}

	CMibModuleWrapper::~CMibModuleWrapper(void)
	{
		if (m_pMibModule)
			delete m_pMibModule;
		m_pMibModule = NULL;
	}

	void CMibModuleWrapper::Init 
	(
	 String ^ connexionOracle, 
	 String ^ cheminFichier, 
	 String ^ nomModule, 
	 long moduleID
	)
	{
		m_pMibModule->SetPath (CAdapter::ConvertStringToSTR(cheminFichier));
		m_pMibModule->SetInfo(moduleID, CAdapter::ConvertStringToSTR(nomModule), c_classID);
		m_connexionOracle = connexionOracle;
	}


	///
	int CMibModuleWrapper::Compile () 
	{
		return m_pMibModule->ConnectAndCompile(CAdapter::ConvertStringToSTR(m_connexionOracle));
	}

	String ^ CMibModuleWrapper::GetNextErrMess()
	{
		return CAdapter::ConvertPSTRToString(m_pMibModule->GetNextErrMess());
	}

	bool CMibModuleWrapper::AreCompileErrors()
	{
		return m_pMibModule->AreCompileErrors();
	}

	bool CMibModuleWrapper::AreCompileLogs()
	{
		return m_pMibModule->AreCompileLogs();
	}

	String ^ CMibModuleWrapper::GetCompileErrors()
	{
		return CAdapter::ConvertPSTRToString(m_pMibModule->GetCompileErrors());
	}

	String ^ CMibModuleWrapper::GetCompileLogs()
	{
		return CAdapter::ConvertPSTRToString(m_pMibModule->GetCompileLogs());
	}
}