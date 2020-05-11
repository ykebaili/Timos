using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using timos.acteurs;
using timos.data.projet.besoin;

namespace timos.data.projet.besoin
{
    public interface IDonneeBesoin : I2iSerializable
    {
        /// <summary>
        /// Permet d'initialiser une données à partir d'une autre
        /// </summary>
        /// <param name="donnee"></param>
        void InitFrom(CBesoin besoin, IDonneeBesoin donnee);

        double? CalculeCout(CBesoin besoin);

        string LibelleStatique { get; }
        bool CanApplyOn(CBesoin besoin);

        ETypeDonneeBesoin TypeDonnee { get; }

        /// <summary>
        /// Touche raccourci pour ce type de besoin
        /// </summary>
        char? ShortKey { get; }

        /// <summary>
        /// Indique si les données de ce type peuvent être parentes
        /// </summary>
        bool PeutEtreParent { get; }

    }

}
