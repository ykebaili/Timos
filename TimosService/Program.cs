using System.Collections.Generic;
using System.ServiceProcess;
using System.Text;

namespace TimosService
{
	static class Program
	{
		/// <summary>
		/// Point d'entrée principal de l'application.
		/// </summary>
		static void Main()
		{
			ServiceBase[] ServicesToRun;

			// Plusieurs services utilisateur s'exécutent dans le même processus. Pour ajouter
			// un autre service à ce processus, modifiez la ligne suivante
			// pour créer un second objet service. Par exemple,
			//
			//   ServicesToRun = new ServiceBase[] {new Service1(), new MySecondUserService()};
			//
			ServicesToRun = new ServiceBase[] { new TimosService() };

			ServiceBase.Run(ServicesToRun);
		}
	}
}