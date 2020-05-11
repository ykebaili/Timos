using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using timos.data.projet.gantt;

namespace timos.data.projet.gantt
{
    public interface IPositionneurGantt
    {
    }

    /// <summary>
    /// fournit la position verticale d'une barre de gantt
    /// </summary>
    public interface IFournisseurYGantt : IPositionneurGantt
    {
        int[] GetYBounds(IElementDeGantt element);
    }

    //Fournit la position horizontale d'une barre de gantt
    public interface IFournisseurXGantt : IPositionneurGantt
    {
        int[] GetXBounds(IElementDeGantt element);


        //Retourne la date correspondant au début de la cellule contenant le point
        DateTime GetDateCell(int nX);
        int GetX(DateTime dt);
        void Highlight(int nXStart, int nXEnd);

        /// <summary>
        /// Retourne la date d'un élément en lui ajoutant un certain nombre de cellules
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="nNbCells"></param>
        /// <returns></returns>
        DateTime AddCells(DateTime dateTime, int nNbCells);
    }
}
