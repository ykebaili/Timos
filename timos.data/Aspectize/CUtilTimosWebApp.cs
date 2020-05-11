using sc2i.process.workflow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timos.data.Aspectize
{
    /// <summary>
    /// Utilisateures de l'application web Timos
    /// </summary>
    public class CUtilTimosUser
    {
        /// <summary>
        /// Déclaration des constantes
        /// </summary>
        public const string c_champUserName = "TIMOS_USER_NAME";
        public const string c_champUserKey = "TIMOS_USER_KEY";
        public const string c_champUserLogin = "TIMOS_USER_LOGIN";
        public const string c_champSessionId = "TIMOS_SESSION_ID";
    }


    /// <summary>
    /// 
    /// </summary>
    public class CUtilTimosTodos
    {
        public const string c_nomTable = "TIMOS_TODOS";

        public const string c_champId = "TODO_ID";
        public const string c_champDateDebut = "TODO_START_DATE";
        public const string c_champLibelle = "TODO_LABEL";
        public const string c_champInstructions = "TODO_INSTRUCTIONS";
        public const string c_champTypeElementEdite = "TODO_ELEMENT_TYPE";
        public const string c_champIdElementEdite = "TODO_ELEMENT_ID";
        public const string c_champElementDescription = "TODO_ELEMENT_DESCRIPTION";

    }
}
