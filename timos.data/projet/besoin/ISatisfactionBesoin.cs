using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.data;
using sc2i.common;

namespace timos.data.projet.besoin
{
    

    //-------------------------------------------------------------------
    public interface ISatisfactionBesoin : IElementACout
    {
        /// <summary>
        /// Libellé de la satisfaction
        /// </summary>
        [DynamicField("Full Satisfaction label")]
        string LibelleSatisfactionComplet { get; }

        [DynamicField("Label")]
        string Libelle { get; }

        /// <summary>
        /// Liste des besoins satisfaits
        /// </summary>
        [DynamicChilds("Satisfied needs", typeof(CBesoin))]
        CBesoin[] BesoinsSolutionnes { get;}

        //ISatisfactionBesoinAvecSousBesoins SatisfactionParente { get; }

        /// <summary>
        /// Liste des relations aux besoins satisfaits
        /// </summary>
        [DynamicChilds("Satisfied needs relations", typeof(CRelationBesoin_Satisfaction))]
        CListeObjetsDonnees RelationsSatisfaits { get; }

        /// <summary>
        /// Indique si cette satisfaction peut satisfaire un certain besoin
        /// </summary>
        /// <param name="besoin"></param>
        /// <returns></returns>
        bool CanSatisfaire(CBesoin besoin);

        /// <summary>
        /// Retourne vrai si la satisfaction est une satisfaction du besoin direct demandé
        /// </summary>
        /// <param name="need"></param>
        /// <returns></returns>
        [DynamicMethod("Returns true if satisfaction is a direct satisfaction to the need")]
        bool IsDirectSatisfactionFor(CBesoin need);

        /// <summary>
        /// Retourne vrai si la satisfaction est d'une manière ou d'une autre une satisfaction du besoin demandé
        /// </summary>
        /// <param name="need"></param>
        /// <returns></returns>
        [DynamicMethod("Returns true if satisfaction is a direct or indirect satisfaction to the need")]
        bool IsRecursiveSatisfactionFor(CBesoin need);



        

    }


    //-------------------------------------------------------------------
    public interface ISatisfactionBesoinAvecSousBesoins : ISatisfactionBesoin
    {
        CBesoin[] GetSousBesoinsDeSatisfaction();
        CBesoin[] GetSousBesoinsDeSatisfactionDirects();
        ISatisfactionBesoin[] GetSousSatisfactions();
        void FillSetBesoins(HashSet<CBesoin> setBesoins, HashSet<ISatisfactionBesoinAvecSousBesoins> setSousElementsFaits);

        /// <summary>
        /// Retourne toutes les satisfactions liées à cette satisfaction, y compris elle même
        /// </summary>
        /// <returns></returns>
        [DynamicMethod("Returns all satisfactions linked to this satisfaction, including itself")]
        ISatisfactionBesoin[] GetFlattenSatisfactionsHierarchy();

    }
}
