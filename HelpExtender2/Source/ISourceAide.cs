using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using sc2i.common;
namespace HelpExtender
{
	public interface ISourceAide
	{
		CHelpData GetHelp(Control ctrl, string strContexte);
		CHelpData GetHelp(Type tp, string strContexte);
		CHelpData GetHelp(string strCle, string strContexte);
		CHelpData GetHelp(string strCle);

		//Définit ou récupère le code HTML des styles (format css)
		string HtmlStyles { get;set;}

		CResultAErreur SaveHelp(CHelpData help);
		CResultAErreur DeleteHelp(CHelpData help);

		//Ajoute un fichier dans la base de fichiers de l'aide
		//Le data du result contient un CRessourceFichier
		CResultAErreur ReferenceFichier(string strFichier, CHelpData helpUtilisant);

		/// <summary>
		/// Retourne une ressource à partir de sa clé
		/// </summary>
		/// <param name="strCle"></param>
		/// <returns></returns>
		CRessourceFichier GetRessourceFichier(string strCle);
		
		//Indique qu'on n'a plus besoin de cette ressource en local
		void LibereRessourceFichierLocale(CRessourceFichier ressource);


		List<CHelpData> GetHelps();
		CResultAErreur SaveMenu();

		CMenuItem MenuRoot { get; set;}

		bool HasHelp(Control ctrl, string strContexte);
		bool HasHelp(Type typ, string strContexte);
		bool HasHelp(string strCle);

	}
}
