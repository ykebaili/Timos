using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using sc2i.data;

namespace timos.data.projet.besoin
{

    [Flags]
    public enum ETypeCout
    {
        Aucun = 0,
        Prévisionnel = 1,
        réel = 2,
        Tous = 255
    }

    //-------------------------------------------------------------------
    /// <summary>
    /// Element qui gère un cout prévisionnel et un cout réel.
    /// Par ailleurs, son cout peut être dépendant d'autres éléments à cout ( SourcesDeCout )
    /// et peut alimenter d'autres couts (UtilisateursDeCout)
    /// </summary>
    public interface IElementACout : IObjetDonneeAIdNumeriqueAuto
    {
        [DynamicField("Estimated cost")]
        double CoutPrevisionnel { get; }

        [DynamicField("Actual cost")]
        double CoutReel { get; }

        void SetCoutSansCalculDesParents(double fValeur, bool bCoutReel);
        void SetCoutAvecCalculDesParents(double fValeur, bool bCoutReel);

        /// <summary>
        /// Indique si le cout est calculé à partir des sources de cout, ou si l'élément le calcul lui même
        /// </summary>
        bool IsCoutFromSources(bool bCoutReel);

        /// <summary>
        /// Lorsque IsCoutPrevisionnel est false, l'élément doit être capable de recalculer sont cout prévisionnel tout seul
        /// dans tout autre cas, c'est le CUtilElementACout qui fait le calcul
        /// </summary>
        double CalculeTonCoutPuisqueTuNeCalculePasAPartirDesSourcesDeCout(bool bCoutReel);

        /// <summary>
        /// Lorsque l'élément a un cout propre en plus du cout de ses sources, retourne true
        /// </summary>
        /// <returns></returns>
        bool ShouldAjouterCoutPropreAuCoutDesSource(bool bCoutReel);



        /// <summary>
        /// Liste des éléments qui alimentent cet élément pour le calcul de son cout (réél ou prévisionnel)
        /// </summary>
        IElementACout[] GetSourcesDeCout(bool bCoutReel);

        /// <summary>
        /// Liste des imputations à faire sur les utilisateurs de cout
        /// </summary>
        CImputationsCouts GetImputationsAFaireSurUtilisateursDeCout();


        /// <summary>
        /// Retourne l'imputation à appliquer à un élément utilisateur (calculée)
        /// </summary>
        /// <param name="besoin"></param>
        /// <param name="bCoutReel"></param>
        /// <returns></returns>
        double CalcImputationAFaireSur(IElementACout elementACout, bool bCoutReel);

        /// <summary>
        /// codage des imputations faites par cet élément à coûts, usage interne
        /// </summary>
        string ImputationsSurUtilisateursString { get; set; }

        /// <summary>
        /// codage des imputations faites par les sources, usage interne
        /// </summary>
        string ImputationsDeSourcesString { get; set; }

        /// <summary>
        /// Libellé de l'élément
        /// </summary>
        string Libelle { get; }

        
        /// <summary>
        /// Interne : indique si les couts parents Doivent être recalculés
        /// </summary>
        ETypeCout TypesCoutsParentsARecalculer { get; set; }

        /// <summary>
        /// si l'objet n'est pas directement éditable, permet
        /// de spécifier l'objet à éditer pour voir cet élément
        /// </summary>
        /// <returns></returns>
        CObjetDonneeAIdNumerique ObjetPourEditionElementACout { get; }
    }


    public class CImputationsCouts
    {
        public readonly IElementACout ElementSource;

        private double m_fPoidsTotal = 0;
        private List<CImputationCout> m_listImputations = new List<CImputationCout>();
        private Dictionary<IElementACout, CImputationCout> m_dicImputations = new Dictionary<IElementACout,CImputationCout>();

        //Liste des éléments qui utilisent ce cout, mais pas sous forme d'imputation, par exemple, un besoin
        //pourcentage est un utilisateur de cout qui utilise le cout, sans pour autant l'enlever d'un autre utilisateur de cout
        private HashSet<IElementACout> m_listeElementsUtilisantCeCout = new HashSet<IElementACout>();

        //---------------------------------------------------------
        public CImputationsCouts(IElementACout element)
        {
            ElementSource = element;
        }

        //---------------------------------------------------------
        public void AddUtilisateurNonImputé(IElementACout elt)
        {
            m_listeElementsUtilisantCeCout.Add(elt);
        }

        //---------------------------------------------------------
        public IElementACout[] UtilisateursNonImputés
        {
            get
            {
                return m_listeElementsUtilisantCeCout.ToArray();
            }
        }

        //---------------------------------------------------------
        public void AddImputation ( IElementACout elt, double fRatio, CRelationBesoin_Satisfaction relationAssociée )
        {
            if ( elt != null )
                AddImputation ( new CImputationCout ( elt, fRatio, relationAssociée ));
        }

        //---------------------------------------------------------
        public void AddImputation ( CImputationCout imputation )
        {
            CImputationCout old = null;
            if (imputation.UtilisateurDeCout.Row.RowState == System.Data.DataRowState.Deleted)
                return;
            if ( m_dicImputations.TryGetValue ( imputation.UtilisateurDeCout, out old ) )
            {
                if ( old.Poids == 0 )
                    m_listImputations.Remove ( old );
                else
                    return;
            }
            m_dicImputations[imputation.UtilisateurDeCout] = imputation;
            m_listImputations.Add ( imputation );
            m_fPoidsTotal += imputation.Poids;
        }

        //---------------------------------------------------------
        public IEnumerable<CImputationCout> Imputations
        {
            get{
                return m_listImputations.AsReadOnly();
            }
        }

        //---------------------------------------------------------
        public double PoidsTotal
        {
            get
            {
                return m_fPoidsTotal;
            }
        }

        //---------------------------------------------------------
        public CImputationCout GetImputation(IElementACout elt)
        {
            if (elt == null)
                return null;
            CImputationCout imputation = null;
            m_dicImputations.TryGetValue(elt, out imputation);
            return imputation;
        }

        //---------------------------------------------------------
        public double GetCoutImputéeA(IElementACout elt, bool bCoutReel)
        {
            double fCout = bCoutReel?ElementSource.CoutReel:ElementSource.CoutPrevisionnel;
            if ( fCout == 0 )
                return 0;
            CImputationCout imputation = null;
            if (m_dicImputations.TryGetValue(elt, out imputation))
            {
                if (PoidsTotal > 0)
                    return imputation.Poids / PoidsTotal * fCout;

            }
            return 0;
        }
    }

    //---------------------------------------------------------
    public class CImputationCout
    {
        public readonly IElementACout UtilisateurDeCout;
        public readonly double Poids;
        public readonly CRelationBesoin_Satisfaction RelationAssociee = null;

        public CImputationCout(IElementACout utilisateurDeCout, double fPoids, CRelationBesoin_Satisfaction relationAssociée)
        {
            UtilisateurDeCout = utilisateurDeCout;
            Poids = fPoids;
            RelationAssociee = relationAssociée;
        }
    }
}
