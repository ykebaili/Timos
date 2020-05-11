using System;
using System.Collections.Generic;
using System.Text;

namespace spv.test
{
    class CProgramme
    {

        [STAThread]
        static void Main()
        {
            System.Console.WriteLine("Démarrage");

            CStefTestLiaisonsEtSchemas test = new CStefTestLiaisonsEtSchemas();
            test.Init();
            //test.TestSchemaEtService();
          
           
        }
    }
}
