using System;
using System.Collections.Generic;
using System.Text;

namespace timos.test.metier
{
	class CProgramme
	{

		[STAThread]
		static void Main()
		{
			//System.Threading.Thread.Sleep(20000);
			System.Console.WriteLine("Démarrage");
			//CTestDeBaseVersionning tst = new CTestDeBaseVersionning();
			//tst.Init();
			//tst.ModifDansV1PuisSuppression();
            //CTimosTestMetierMappageTypeTable tsts = new CTimosTestMetierMappageTypeTable();
            //tsts.Init();
            //tsts.TestValeurConstante();
            CTestCalendrierEtEOPlanifiees test = new CTestCalendrierEtEOPlanifiees();
            test.SetUptTest();
            //test.TestCalendrierTroisTranchesNonContigues();
            //test.TestCalendrierTroisTranchesContigues();
            //test.TestCalendrierTroisTranchesAvecRecouvrement();
            test.TestCalendrierQuatresTranchesAChevalSurDeuxJours();
            //test.TestTroisEOsPlanifieesLeMemeJour();
            //test.TestCombineEOsPlanifieesEtCalendrier();
		}
	}
}
