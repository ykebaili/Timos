using System;
using System.Collections.Generic;
using System.Text;

using sc2i.data;

namespace timos.data
{
	public interface IElementAOperationPrevisionnelle : IObjetDonneeAIdNumeriqueAuto
	{
		string Libelle { get;}
        CListeObjetsDonnees Operations { get;}
        IFournisseurListeTypeOperation FournisseurListeTypeOperation { get;}
	}

    public interface IFournisseurListeTypeOperation
    {
        CListeObjetsDonnees GetListeTypesOperations( CContexteDonnee contexte );
    }

    /// <summary>
    /// Classe avec une instance unique
    /// </summary>
    public class CFournisseurListeTousTypesOperations : IFournisseurListeTypeOperation
    {
        private static CFournisseurListeTousTypesOperations m_instanceUnique = null;

        public static CFournisseurListeTousTypesOperations InstanceUnique
        {
            get
            {
                if (m_instanceUnique == null)
                    m_instanceUnique = new CFournisseurListeTousTypesOperations();
                return m_instanceUnique;
            }
        }


        public CListeObjetsDonnees GetListeTypesOperations( CContexteDonnee contexte)
        {
            CListeObjetsDonnees liste = new CListeObjetsDonnees(
                contexte,
                typeof(CTypeOperation));

            liste.Filtre = new CFiltreData(CTypeOperation.c_champNiveau + " = @1", 0);
            return liste;
        }

    }
}
