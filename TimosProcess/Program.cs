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

            if (args.Length == 0)
            {
                ShowUsage();
                return 0;
            }

            try
            {
                return RunProcess(args);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return 0;
        }

        private static int RunProcess(string[] args)
        {
            /*CTimosProcessRegistre.SetIsLocalMachine(true);
			CTimosProcessRegistre registre = new CTimosProcessRegistre();
			string strURL = registre.GetFactoryURL();*/

            string strURL = "tcp://" + args[0];
            if (strURL[strURL.Length - 1] != '/')
				strURL = strURL + '/';
			ILanceurProcessCommandLine obj = Activator.GetObject(typeof(ILanceurProcessCommandLine), strURL + "ILanceurProcessCommandLine") as ILanceurProcessCommandLine;
			Console.WriteLine("Starting process...");

            // On enlève le premier argument qui est le hostname ou URL, car plus besoin
            List<string> lstArgs = new List<string>();
            for (int i = 1; i < args.Length; i++)
            {
                lstArgs.Add(args[i]);
            }

            CResultAErreur result = obj.StartProcess(lstArgs.ToArray());
			if ( !result )
				Console.WriteLine(result.Erreur.ToString());
			if (result.Data is int)
				return (int)result.Data;
			return 0;
        }

        private static void ShowUsage()
        {
            Console.WriteLine("Usage : TimosProcess.exe HostName ProcessId=x [VariableName]=[VariableValue]");
        }
    }
}
