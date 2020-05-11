using System;
using System.Collections.Generic;
using System.Text;
using sc2i.common;
using sc2i.process;

namespace TimosProcess
{


	class Program
	{
		static int Main(string[] args)
		{
			CTimosProcessRegistre.SetIsLocalMachine(true);
			CTimosProcessRegistre registre = new CTimosProcessRegistre();
			string strURL = registre.GetFactoryURL();
			if (strURL[strURL.Length - 1] != '/')
				strURL = strURL + '/';
			ILanceurProcessCommandLine obj = Activator.GetObject(typeof(ILanceurProcessCommandLine), strURL + "ILanceurProcessCommandLine") as ILanceurProcessCommandLine;
			Console.WriteLine("Starting process...");
			CResultAErreur result = obj.StartProcess(args);
			if ( !result )
				Console.WriteLine(result.Erreur.ToString());
			if (result.Data is int)
				return (int)result.Data;
			return 0;
		}
	}
}
