using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using timos.data.coordonnees;

namespace timos.data
{

	/// <summary>
	/// Classe statique correspondant � l'interface IObjetAvecFilsAvecCoordonnees fournissant des m�thodes
	/// souvent redondantes des classes qui impl�mentent cette interface
	/// </summary>
	static public class SObjetAvecFilsAvecCoordonnees
	{

		/// <summary>
		/// V�rifie que la coordonn�e demand�e est valide pour le fils demand� dans le
		/// parent demand�
		/// </summary>
		/// <param name="parent"></param>
		/// <param name="fils"></param>
		/// <param name="strCoordonnee"></param>
		/// <returns></returns>
		public static CResultAErreur VerifieCoordonneeFils(IObjetAFilsACoordonnees parent, IObjetACoordonnees fils, string strCoordonnee)
		{
			CResultAErreur result = CResultAErreur.True;

			///V�rifie qu'on a ce qu'il faut pour bosser !!
			if (parent == null)
			{
				result.EmpileErreur(I.T("Impossible to check the coordinates of an object which is not positioned|259"));
				return result;
			}
			if (fils == null)
			{
				return result;
			}
			CParametrageSystemeCoordonnees parametrage = parent.ParametrageCoordonneesApplique;
			if (parametrage == null || parametrage.SystemeCoordonnees == null)
			{
				return result;
			}

			EOptionControleCoordonnees? optionControle = parent.OptionsControleCoordonneesApplique;
            if (optionControle == null)
                optionControle = COptionCoordonn�eGlobale.GetOptionType(fils.ContexteDonnee.IdSession, parent.GetType());

            if(!IsAppliquable (optionControle.Value, fils ) )
                return result;

			//Test Coordonn�e vide
			if (strCoordonnee == "")
			{
				if ((optionControle & EOptionControleCoordonnees.IgnorerLesFilsSansCoordonnees) == EOptionControleCoordonnees.IgnorerLesFilsSansCoordonnees)
					return result;
				else
				{
					result.EmpileErreur(I.T("Mandatory coordinate|258"));
					return result;
				}
			}

			///V�rifie que la coordonn�e  a le bon format
			result = parametrage.VerifieCoordonnee(strCoordonnee);
			if (!result)
				return result;
			string strCoordonneeFin = strCoordonnee;

			COccupationCoordonnees occupation = fils.OccupationCoordonneeAppliquee;
			
			//Prend en compte l'occupation
			if ((optionControle & EOptionControleCoordonnees.IgnorerLoccupation) != EOptionControleCoordonnees.IgnorerLoccupation)
			{
				if (occupation == null)
				{
					result.EmpileErreur(I.T("No occupation defined : control is impossible|256"));
					return result;
				}
				if (occupation.NbUnitesOccupees < 1)
				{
                    result.EmpileErreur(I.T("Incorrect number of occupied units|257"));
					return result;
				}
				if (occupation.NbUnitesOccupees != 1)//1->coord fin = coord d�but !
				{
					result = parametrage.SystemeCoordonnees.AjouteDansNiveau(strCoordonnee, occupation.NbUnitesOccupees-1);
					if (!result)
						return result;
					strCoordonneeFin = (string)result.Data;
					//V�rifie que la coordonn�e de fin est correcte
					result = parametrage.VerifieCoordonnee(strCoordonneeFin);
					if (!result)
						return result;
				}
			}

			//V�rifie que l'unit� est coh�rente
			if ((optionControle & EOptionControleCoordonnees.IgnorerLesUnites) != EOptionControleCoordonnees.IgnorerLesUnites &&
				 !fils.IgnorerUnite )
			{
				if (occupation == null)
				{
					result.EmpileErreur(I.T("No occupation defined  : control is impossible|256"));
					return result;
				}
				result = parametrage.SystemeCoordonnees.VerifieUnite(strCoordonnee, occupation.Unite);
				if (!result)
					return result;
			}

			//V�rifie que la coordonn�e n'est pas d�j� occup�e
			if ((optionControle & EOptionControleCoordonnees.AutoriserPlusieursFilsSurLaMemeCoordonnee) != EOptionControleCoordonnees.AutoriserPlusieursFilsSurLaMemeCoordonnee)
			{
				List<IObjetACoordonnees> lstobj = new List<IObjetACoordonnees>();
				lstobj = parent.FilsACoordonnees;

				//On exclu l'objet actuel si il est d�j� pr�sent car il ne peut pas rentrer en conflit avec lui m�me
				if (lstobj.Contains(fils))
					lstobj.Remove(fils);

				result = parametrage.Test_Interactions(strCoordonnee, strCoordonneeFin, lstobj);
			}
			result.Data = null;
			return result;

				
		}

		public static CResultAErreur VerifieCoordonneesFils(IObjetAFilsACoordonnees parent)
		{
			CResultAErreur result = CResultAErreur.True;
			foreach (IObjetACoordonnees fils in parent.FilsACoordonnees)
			{
				result = VerifieCoordonneeFils(parent, fils, fils.Coordonnee);
				if (!result)
				{
					result.EmpileErreur(I.T("Element '@1' doesn't respect the Coordinate constrainte|255", fils.DescriptionElement));
					return result;
				}
			}
			return result;
		}

        public static bool IsAppliquable(EOptionControleCoordonnees optionControle, IObjetACoordonnees fils)
        {
            if (fils.GetType() == typeof(CEquipement))
            {
                if ((optionControle & EOptionControleCoordonnees.IgnorerLesEquipements) == EOptionControleCoordonnees.IgnorerLesEquipements)
                    return false;
            }
            if (fils.GetType() == typeof(CSite))
            {
                if ((optionControle & EOptionControleCoordonnees.IgnorerLesSites) == EOptionControleCoordonnees.IgnorerLesSites)
                    return false;
            }
            if (fils.GetType() == typeof(CStock))
            {
                if ((optionControle & EOptionControleCoordonnees.IgnorerLesStocks) == EOptionControleCoordonnees.IgnorerLesStocks)
                    return false;
            }
            return true;

        }


	}
}
