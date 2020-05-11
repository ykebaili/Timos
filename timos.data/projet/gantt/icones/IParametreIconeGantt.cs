using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using sc2i.common;
using sc2i.expression;

namespace timos.data.projet.gantt
{
    [global::System.AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class NomConvivialParametreIconeGanttAttribute : Attribute
    {
        public readonly string Libelle;
        public readonly bool IsUnique;

        public NomConvivialParametreIconeGanttAttribute(string strLibelleEditeur, bool isUnique)
        {
            this.Libelle = strLibelleEditeur;
            this.IsUnique = isUnique;
        }

    }

    public interface IParametreIconeGantt : I2iSerializable
    {
        // Retourne l'image pour un élément de gantt donné
        CIconeGantt GetIcone(IElementDeGantt element);

        // Retourne l'image associé à ce paramètre
        Image Image { get; }
        // Retourne la formule de tooltip associée à l'image
        C2iExpression Tooltip { get; set; }
    }
}
