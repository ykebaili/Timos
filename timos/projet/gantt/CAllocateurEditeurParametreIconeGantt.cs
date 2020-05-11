using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using sc2i.win32.common;
using sc2i.common;
using sc2i.data.dynamic;
using sc2i.expression;

using timos.data;
using timos.data.projet.gantt;

namespace timos.projet.gantt
{
    /// <summary>
    /// Doit être implémentée par tout control d'édition de parametre d'icone de Gantt
    /// </summary>
    public interface IEditeurParametreIconeGantt: IControlALockEdition
    {
        IParametreIconeGantt ParametreIconeGantt { get; set; }
        event EventHandler DeleteIconeEventHendler;
        void Init(IParametreIconeGantt p);
        CResultAErreur MajChamps();
    }


    public class CAllocateurEditeurParametreIconeGantt
    {
        static Dictionary<Type, Type> m_dicTypeParametreIcone_TypeEditeur = new Dictionary<Type, Type>();

        public static void RegisterEditeur(Type typeParametreIcone, Type typeEditeur)
        {
            m_dicTypeParametreIcone_TypeEditeur[typeParametreIcone] = typeEditeur;
        }

        public static IEditeurParametreIconeGantt GetEditeurForType(Type tp)
        {
            Type tpControl;
            if (!m_dicTypeParametreIcone_TypeEditeur.TryGetValue(tp, out tpControl))
            {
                return null;
            }
            object objControl = Activator.CreateInstance(tpControl);
            IEditeurParametreIconeGantt control = objControl as IEditeurParametreIconeGantt;
            if (control == null)
                return null;
            
            return control;
        }

        public static List<Type> GetTousLesTypesDeParametresIconeGanttEditables()
        {
            return m_dicTypeParametreIcone_TypeEditeur.Keys.ToList<Type>();
        }

    }
}
