strComputer = "."
Set objWMIService = GetObject("winmgmts:" _
& "{impersonationLevel=impersonate}!\\" & strComputer & "\root\cimv2")
Set colListOfServices = objWMIService.ExecQuery _
("Select * from Win32_Service ")
For Each objService in colListOfServices
	if ( instr(objService.PathName, "FileUpdaterClientService.exe") > 0 ) then
		objService.StopService()
		objService.Delete()
	end if
Next