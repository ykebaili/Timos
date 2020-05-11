using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using sc2i.common;
using timos.data.projet.Contraintes;

namespace timos.data.projet.gantt
{
     /// <summary>
    /// element pouvant s'afficher dans une barre de Gantt
    /// </summary>
    public interface IElementDeGantt
    {
        [DynamicField("Label")]
        string Libelle { get; }//Libellé dans l'arbre

        string LibelleBarre { get; }
        string LibelleGauche { get; }
        string LibelleDroite { get; }

        CIconeGantt[] IconesGauche { get; }
        CIconeGantt[] IconesDroite { get; }
        CIconeGantt[] IconesBarre { get; }

        Color CouleurFondBarre1 { get; }
        Color CouleurFondBarre2 { get; }
        Color CouleurTexteBarre { get; }
        Color CouleurTexteGauche { get; }
        Color CouleurTexteDroite { get; }

        bool DatesAreDirty { get; set; }
        
        [DynamicField("Start date")]
        DateTime DateDebut { get; set; }
        
        [DynamicField("End date")]
        DateTime DateFin { get; set; }

        DateTime DateDebutPourParent { get; }

        DateTime DateFinPourParent { get; }

        [DynamicField("Actual start date")]
        DateTime? DateDebutReelle { get; set; }

        [DynamicField("Actual end date")]
        DateTime? DateFinReelle { get; set; }
        
        [DynamicField("Has warnings")]
        bool HasWarnings { get; }

        [DynamicField("Is ended")]
        bool EstTermine { get; }

        [DynamicField("Automatic dates")]
        bool DatesAuto { get; }

        [DynamicField("Progress")]
        double PctAvancement { get; }
        
        [DynamicField("Weight")]
        double Poids { get; }

        // Expose les Predecesseurs
        IEnumerable<IElementDeGantt> Predecesseurs { get; }

        bool RespectePredecesseur(IElementDeGantt predecesseur);

        CResultAErreur AddPredecesseur(IElementDeGantt element);
        void RemovePredecesseur(IElementDeGantt element);

        // Expose les Contraintes
        IEnumerable<IContrainteDeGantt> Contraintes { get; }
        
        [DynamicField("Childs elements")]
        IEnumerable<IElementDeGantt> ElementsFils { get; }

        [DynamicField("Parent element")]
        IElementDeGantt ElementParent { get; set; }

        void Draw ( Rectangle rct, IFournisseurXGantt fournisseurX, Graphics g );

        /// <summary>
        /// déplace la date de début de l'élément
        /// </summary>
        /// <param name="dateDebut"></param>
        void Move(
            TimeSpan spDeplacement, 
            TimeSpan ? duree,
            EModeDeplacementProjet modeDeplacement,
            bool bForceForThisElement);

        [DynamicField("Key")]
        string ElementKey { get; }

        [DynamicField("Bar Id")]
        string GanttBarId { get; }

        /// <summary>
        /// Image associée à l'élément
        /// </summary>
        Image Image { get; set; }

        void AppliqueParametrageDessin(CParametreDessinLigneGantt parametre);

        /// <summary>
        /// Si true, indique que l'élément a un index lui permettant d'être
        /// trié dans son parent
        /// </summary>
        bool CanBeSortedInParent { get; }

        /// <summary>
        /// Index de l'élément dans son parent;
        /// </summary>
        [DynamicField("Sort index")]
        int IndexTri { get; set; }

        void SortChilds(CParametreTriGantt parametreTri);

        // Retourne la projet associé 
        [DynamicField("Associated project")]
        CProjet ProjetAssocie { get; }

        /// <summary>
        /// Retourne true si on a le droit de déplacer cet élément
        /// </summary>
        bool MoveAutorise { get; }


        void RegroupeBarresEnMulti();

        IEnumerable<IElementDeGantt> ElementsADessinerSurLaLigne { get; }
    }


}
