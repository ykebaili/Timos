using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using sc2i.data.dynamic;
using timos.securite;
using tiag.client;
using sc2i.doccode;
using timos.data;


namespace timos.data
{
    /// <summary>
    /// Chaque instance de cette classe permet d'indiquer qu'un 
    /// <see cref="CLienReseau">lien</see> est lié à son extremité, en empruntant un chemin particulier.
    /// Le chemin permet, lorsque l'extrémité du lien est dans un sous-schéma lui même éventuellement<br/>
    /// dans un autre sous-schéma, etc., d'indiquer par quel(s) sous-schéma(s) il faut passer pour<br/>
    /// atteindre l'extrémité.<br/>
    /// Lorsque plusieurs sous-schémas sont à traverser pour atteindre une extrémité du lien,<br/>
    /// il y aura plusieurs chemins de liens réseau chaînés les uns aux autres,<br/>
    /// chaque chemin exprimant la pénétration dans un sous-schéma.
    /// </summary>
    [DynamicClass("Network link path")]
    [Table(CCheminLienReseau.c_nomTable, CCheminLienReseau.c_champId, true)]
    [ObjetServeurURI("CCheminLienReseauServeur")]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_Liaisons_ID)]
    public class CCheminLienReseau : CObjetDonneeAIdNumeriqueAuto,
        IObjetDonneeAutoReference
    {
        public const string c_nomTable = "NETWORK_LINK_PATH";
        public const string c_champId = "NTLNKPTH_ID";
        public const string c_champIdCheminParent = "NTLNKPTH_PARENT_ID";
        /*public const string c_champIdLienReseauAsEx1 = "NTLNKPTH_LINK_AS_1";
        public const string c_champIdLienReseauAsEx2 = "NTLNKPTH_LINK_AS_2";*/
        public const string c_champExtremiteConcernee = "NTLNKPTH_CNCRD_EXT";

         /// /////////////////////////////////////////////
        public CCheminLienReseau(CContexteDonnee contexte)
            : base(contexte)
        {
        }

        /// /////////////////////////////////////////////
        public CCheminLienReseau(DataRow row)
            : base(row)
        {
        }

        /// /////////////////////////////////////////////
        public override string DescriptionElement
        {
            get
            {
                return I.T("The Network link path @1|20028", Id.ToString());

            }
        }

        /// /////////////////////////////////////////////
        public override string[]  GetChampsTriParDefaut()
        {
 	         return new string[] { c_champId };
        }

        /// /////////////////////////////////////////////
        protected override void  MyInitValeurDefaut()
        {
        }

 
        //-------------------------------------------------------------------
        /// <summary>
        /// <see cref="CElementDeSchemaReseau">Elément de schéma réseau</see> concerné par ce chemin de lien réseau
        /// </summary>
        [Relation(
            CElementDeSchemaReseau.c_nomTable,
            CElementDeSchemaReseau.c_champId,
            CElementDeSchemaReseau.c_champId,
            true,
            true,
            false,
            DeleteEnCascadeManuel=true)]
        [DynamicField("Network diagram element")]
        public CElementDeSchemaReseau ElementDeSchemaConcerne
        {
            get
            {
                return (CElementDeSchemaReseau)GetParent(CElementDeSchemaReseau.c_champId, typeof(CElementDeSchemaReseau));
            }
            set
            {
                SetParent(CElementDeSchemaReseau.c_champId, value);
            }
        }

        /// <summary>
        /// Numéro d'extrémité du lien réseau concernée par ce chemin (1 ou 2)
        /// </summary>
        [TableFieldProperty(CCheminLienReseau.c_champExtremiteConcernee)]
        [DynamicField("Concerned extremity")]
        [IndexField]
        public int NumeroExtremiteConcernee
        {
            get
            {
                int nVal = (int)Row[c_champExtremiteConcernee];
                if ( nVal == 0 )
                    return 1;
                return nVal;
            }
            set
            {
                Row[c_champExtremiteConcernee] = value;
            }
        }


        //-----------------------------------
        public CExtremiteLienReseau ExtremiteConcernee
        {
            get{
                return new CExtremiteLienReseau((EExtremiteLienReseau)NumeroExtremiteConcernee);
            }
            set
            {
                NumeroExtremiteConcernee = value.CodeInt;
            }
        }


        //-----------------------------------
        public string ChampParent
        {
            get { return c_champIdCheminParent; }
        }

        //-----------------------------------
        public string ProprieteListeFils
        {
            get { return "CheminsFils"; }
        }

        //-------------------------------------------------------------------
        /// <summary>
        /// Chemin parent, lorsque plusieurs chemins sont nécessaires
        /// </summary>
        [Relation(
            CCheminLienReseau.c_nomTable,
            CCheminLienReseau.c_champId,
            CCheminLienReseau.c_champIdCheminParent,
            false,
            true,
            true,
            DeleteEnCascadeManuel=true)]
        [DynamicField("Parent path")]
        public CCheminLienReseau CheminParent
        {
            get
            {
                return (CCheminLienReseau)GetParent(CCheminLienReseau.c_champIdCheminParent, typeof(CCheminLienReseau));
            }
            set
            {
                SetParent(CCheminLienReseau.c_champIdCheminParent, value);
            }
        }


        //---------------------------------------------
        /// <summary>
        /// Chemin fils, lorsque plusieurs chemins sont nécessaires
        /// </summary>
        [RelationFille(typeof(CCheminLienReseau), "CheminParent")]
        [DynamicChilds("Childs paths", typeof(CCheminLienReseau))]
        public CListeObjetsDonnees CheminsFils
        {
            get
            {
                return GetDependancesListe(CCheminLienReseau.c_nomTable, c_champIdCheminParent);
            }
        }

        public CCheminLienReseau CheminFils
        {
            get
            {
                if ( CheminsFils.Count == 0 )
                    return null;
                return CheminsFils[0] as CCheminLienReseau;
            }
        }

        //-------------------------------------------------------------------
        /// <summary>
        /// Schéma réseau utilisé comme chemin pour atteindre l'élément final
        /// </summary>
        [Relation(
            CSchemaReseau.c_nomTable,
            CSchemaReseau.c_champId,
            CSchemaReseau.c_champId,
            false,
            true,
            false)]
        [DynamicField("Used Network diagram")]
        public CSchemaReseau SchemaReseauUtilise
        {
            get
            {
                return (CSchemaReseau)GetParent(CSchemaReseau.c_champId, typeof(CSchemaReseau));
            }
            set
            {
                SetParent(CSchemaReseau.c_champId, value);
            }
        }

        public IEtapeLienReseau EtapeFinale
        {
            get
            {
                if (CheminFils == null)
                    return Etape;
                return CheminFils.EtapeFinale;
            }
        }

        /// <summary>
        /// Etape utilisée pour le chemin
        /// </summary>
        [DynamicField ("Path step")]
        public IEtapeLienReseau Etape
        {
            get
            {
                IEtapeLienReseau etape = SchemaReseauUtilise;
                return etape;
            }
            set
            {
                if (value is CSchemaReseau)
                    SchemaReseauUtilise = value as CSchemaReseau;
            }
        }

        public bool ContientChemin(CCheminLienReseau chemin)
        {
            if (chemin.SchemaReseauUtilise == null &&
                SchemaReseauUtilise != null)
                return true;
            if (chemin.SchemaReseauUtilise.Id == SchemaReseauUtilise.Id)
            {
                if (chemin.CheminsFils.Count == 0)
                    return true;
                if (CheminsFils.Count == 0)//Il reste des chemins au testé, mais pas au contenant potentiel
                    return false;
                CCheminLienReseau cheminFilsThis = CheminsFils[0] as CCheminLienReseau;
                CCheminLienReseau cheminFilsTest = chemin.CheminsFils[0] as CCheminLienReseau;
                return cheminFilsThis.ContientChemin(cheminFilsTest);
            }
            return false;
        }
                
                    
    }

}
 