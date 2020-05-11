using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.data.serveur;
using CamusatQowisioClientPlugin;
using sc2i.common;
using sc2i.data;
using System.Threading;
using sc2i.multitiers.client;
using sc2i.process;
using System.Xml;
using timos.data;
using sc2i.data.dynamic;
using System.IO;
using sc2i.multitiers.server;

namespace CamusatQowisioServerPlugin
{

    public class CCamusatQowisioDataServeur : CObjetServeur
    {


        public CCamusatQowisioDataServeur(int nIdSession)
            : base(nIdSession)
        {
        }


        public override string GetNomTable()
        {
            return CCamusatQowisioData.c_nomTable;
        }

        public override Type GetTypeObjets()
        {
            return typeof(CCamusatQowisioData);
        }

        public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
        {
            CResultAErreur resutl = CResultAErreur.True;

            CCamusatQowisioData data = objet as CCamusatQowisioData;
            if (data != null)
            {

            }

            return resutl;
        }

        public override CResultAErreur TraitementAvantSauvegarde(CContexteDonnee contexte)
        {
            return base.TraitementAvantSauvegarde(contexte);
        }


    }
}
