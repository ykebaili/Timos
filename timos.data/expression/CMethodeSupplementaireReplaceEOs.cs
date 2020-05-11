using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using timos.data;
using sc2i.data;
using timos.securite;

namespace CamusatQowisioClientPlugin
{
    [AutoExec("Autoexec")]
    public class CMethodeSupplementaireReplaceEOs : CMethodeSupplementaire
    {

        public CMethodeSupplementaireReplaceEOs()
            :base(typeof(IElementAEO))
        {
        }

        public static void Autoexec()
        {
            CGestionnaireMethodesSupplementaires.RegisterMethode(new CMethodeSupplementaireReplaceEOs());
        }

        public override string Description
        {
            get 
            {
                return "Replace OE with Eos from another element";    
            }
        }

        public override CInfoParametreMethodeDynamique[] InfosParametres
        {
            get
            {
                return new CInfoParametreMethodeDynamique[] 
                {
                    new CInfoParametreMethodeDynamique("Source", "", typeof(IElementAEO)),
                    new CInfoParametreMethodeDynamique("OE root", "", typeof(string))
                };
            }
        }

        public override object Invoke(object objetAppelle, params object[] parametres)
        {
            IElementAEO elt = objetAppelle as IElementAEO;
            IElementAEO source = parametres[0] as IElementAEO;
            string strRacine = parametres.Length > 1 && parametres[1] != null? parametres[1].ToString() : "";
            CUtilElementAEO.CopyAndReplaceEOS(elt, source, strRacine);
            return true;
        }
           

        public override string Name
        {
            get { return "ReplaceEOs"; }
        }

        public override bool ReturnArrayOfReturnType
        {
            get { return false; }
        }

        public override Type ReturnType
        {
            get { return typeof(bool); }
        }
    }
}
