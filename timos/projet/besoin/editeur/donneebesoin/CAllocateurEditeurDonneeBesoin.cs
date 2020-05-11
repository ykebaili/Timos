using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using sc2i.win32.common;
using timos.data.projet.besoin;

namespace timos.projet.besoin
{
    public interface IEditeurDonneeBesoin : IControlALockEdition
    {
        IDonneeBesoin DonneeBesoin { get; }
        void Init(IDonneeBesoin donnee, CBesoin besoin, CItemBesoin itemBesoin, IEnumerable<CItemBesoin> items);
        CResultAErreur MajChamps();
        event EventHandler OnCoutChanged;

        event EventHandler OnDataChanged;
        void RefreshFromExternalChangeOnDonnee();
    }

    public enum ETypeEditeurBesoin
    {
        EditeurCout,
        EditeurDonnees
    }


    //----------------------------------------------------------------------
    public class CAllocateurEditeurDonneeBesoin
    {
        private static Dictionary<Type, Type> m_dicTypesEditeursCout = new Dictionary<Type, Type>();
        private static Dictionary<Type, Type> m_dicTypesEditeursDonnees = new Dictionary<Type, Type>();

        //----------------------------------------------------------------------
        public static void RegisterEditeur(ETypeEditeurBesoin kindEditeur, Type typeBesoin, Type typeEditeur)
        {
            GetDic(kindEditeur)[typeBesoin] = typeEditeur;
        }

        //----------------------------------------------------------------------
        private static Dictionary<Type, Type> GetDic(ETypeEditeurBesoin kindEditeur)
        {
            switch (kindEditeur)
            {
                case ETypeEditeurBesoin.EditeurCout:
                    return m_dicTypesEditeursCout;
                    break;
                case ETypeEditeurBesoin.EditeurDonnees:
                    return m_dicTypesEditeursDonnees;
                    break;
            }
            return m_dicTypesEditeursCout;
        }

        /// <summary>
        /// Récupère un éditeur
        /// </summary>
        /// <param name="donnee"></param>
        /// <param name="bEditeurDetail">Indique si on veut l'éditeur détaillé (en bas de la fenêtre besoin), ou l'éditeur de cout</param>
        /// <returns></returns>
        public static IEditeurDonneeBesoin GetEditeurDonnee(IDonneeBesoin donnee, ETypeEditeurBesoin typeEditeur)
        {
            if (donnee == null)
                return null;
            Type tpEditeur = null;
            if (GetDic(typeEditeur).TryGetValue(donnee.GetType(), out tpEditeur))
            {
                IEditeurDonneeBesoin editeur = Activator.CreateInstance(tpEditeur, new object[0] ) as IEditeurDonneeBesoin;
                return editeur;
            }
            return null;
        }

    }
}
