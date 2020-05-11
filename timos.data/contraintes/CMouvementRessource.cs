using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using timos.securite;
using timos.acteurs;

namespace timos.data
{
    /// <summary>
    /// Le mouvement d'une <see cref="CRessourceMaterielle">Ressource</see> d'un emplacement à un autre est enregistré par cette<br/>
	/// entité, afin d'en conserver une trace.<br/>
    /// Tous les mouvements d'une Ressource constituent son Historique.
    /// </summary>
    [sc2i.doccode.DocRefMenusOrMenuItems(CDocLabels.c_iContrainte)]
    [DynamicClass("Resource movement")]
    [Table(CMouvementRessource.c_nomTable, CMouvementRessource.c_champId, true)]
    [FullTableSync]
    [ObjetServeurURI("CMouvementRessourceServeur")]
    public class CMouvementRessource : CObjetDonneeAIdNumeriqueAuto
    {
        public const string c_nomTable = "RESOURCE_MOUVEMENT";

        public const string c_champId = "RESRC_MVT_ID";
        public const string c_champInfo = "RESRC_MVT_INFO";
        public const string c_champDateMouvement = "RESRC_MVT_DATE";

        /// /////////////////////////////////////////////
        public CMouvementRessource(CContexteDonnee contexte)
            : base(contexte)
        {
        }

        /// /////////////////////////////////////////////
        public CMouvementRessource(DataRow row)
            : base(row)
        {
        }

        /// /////////////////////////////////////////////
        public override string DescriptionElement
        {
            get
            {
                return I.T( "The equipment movement @1 |112",Info);
            }
        }

        /// /////////////////////////////////////////////
        protected override void MyInitValeurDefaut()
        {
            DateMouvement = DateTime.Now;
        }

        /// /////////////////////////////////////////////
        public override string[] GetChampsTriParDefaut()
        {
            return new string[] { c_champId + " desc" };
        }

        /// <summary>
        /// Commentaire sur le déplacement (champ texte de 1024 caractères maximum)
        /// </summary>
        [TableFieldProperty(c_champInfo, 1024)]
        [DynamicField("Info")]
        [RechercheRapide]
        public string Info
        {
            get
            {
                return (string)Row[c_champInfo];
            }
            set
            {
                Row[c_champInfo] = value;
            }
        }

        //------------------------------------------------------------
        /// <summary>
        /// Date du déplacement de la ressource
        /// </summary>
        [TableFieldProperty(CMouvementRessource.c_champDateMouvement)]
        [DynamicField("Movement date")]
        public DateTime DateMouvement
        {
            get
            {
                return (DateTime)Row[c_champDateMouvement];
            }
            set
            {
                Row[c_champDateMouvement] = value;
            }
        }

        //------------------------------------------------------------
        /// <summary>
        /// La Ressource concernée par le déplacement
        /// </summary>
        [Relation(
            CRessourceMaterielle.c_nomTable,
            CRessourceMaterielle.c_champId,
            CRessourceMaterielle.c_champId,
            true,
            true,
            true)]
        [DynamicField("Moved resource")]
        public CRessourceMaterielle RessourceDeplace
        {
            get
            {
                return (CRessourceMaterielle)GetParent(CRessourceMaterielle.c_champId, typeof(CRessourceMaterielle));
            }
            set
            {
                SetParent(CRessourceMaterielle.c_champId, value);
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// Site où se trouvait la Ressource avant le mouvement<br/>
        /// (dans le cas où la ressource était sur un site avant le mouvement)
        /// </summary>
        [Relation(
            CSite.c_nomTable,
            CSite.c_champId,
            CSite.c_champId,
            false,
            false,
            false)]
        [DynamicField("Original site")]
        public CSite SiteOrigine
        {
            get
            {
                return (CSite)GetParent(CSite.c_champId, typeof(CSite));
            }
            set
            {
                if (value != null)
                    EmplacementOrigine = value;
                else
                    SetParent(CSite.c_champId, value);
            }
        }


        //---------------------------------------------
        /// <summary>
        /// Acteur qui détenait la ressource avant le mouvememnt<br/>
        /// (dans le cas où la ressource était sur un acteur avant le mouvement)
        /// </summary>
        [Relation(
            CActeur.c_nomTable,
            CActeur.c_champId,
            CActeur.c_champId,
            false,
            false,
            false)]
        [DynamicField("Original member")]
        public CActeur ActeurOrigine
        {
            get
            {
                return (CActeur)GetParent(CActeur.c_champId, typeof(CActeur));
            }
            set
            {
                if (value != null)
                    EmplacementOrigine = value;
                else
                    SetParent(CActeur.c_champId, value);
            }
        }

        /// <summary>
        /// Emplacement d'origine de la ressource (Site ou Acteur)
        /// </summary>
        [DynamicField("Original Place")]
        public IPossesseurRessource EmplacementOrigine
        {
            get
            {
                IPossesseurRessource emplacement = SiteOrigine;
                if (emplacement == null)
                    emplacement = ActeurOrigine;
                return emplacement;
            }
            set
            {
                if (value is CSite)
                    SetParent(CSite.c_champId, (CObjetDonnee)value);
                if (value is CActeur)
                    SetParent(CActeur.c_champId, (CObjetDonnee)value);
                if (value != null)
                {
                    if (!(value is CSite))
                        SiteOrigine = null;
                    if (!(value is CActeur))
                        ActeurOrigine = null;
                }
            }
        }


        //---------------------------------------------
        /// <summary>
        /// Utilisateur ayant réalisé le mouvement
        /// </summary>
        [Relation(
            CDonneesActeurUtilisateur.c_nomTable,
            CDonneesActeurUtilisateur.c_champId,
            CDonneesActeurUtilisateur.c_champId,
            true,
            false,
            false)]
        [DynamicField("User")]
        public CDonneesActeurUtilisateur Utilisateur
        {
            get
            {
                return (CDonneesActeurUtilisateur)GetParent(CDonneesActeurUtilisateur.c_champId, typeof(CDonneesActeurUtilisateur));
            }
            set
            {
                SetParent(CDonneesActeurUtilisateur.c_champId, value);
            }
        }
    }
}
