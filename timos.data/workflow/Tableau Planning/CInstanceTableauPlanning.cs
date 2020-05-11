using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;

using sc2i.multitiers.client;
using sc2i.data;
using sc2i.common;
using sc2i.workflow;

using timos.data;
using timos.securite;
using timos.acteurs;


namespace sc2i.workflow
{
    /// <summary>
    /// Sert à éditer un planning entre une date de début et une date de fin
    /// </summary>
    public class CInstanceTableauPlanning
    {
        public const string c_strDatePourColonne = "DATE";
        public const string c_strTrancheHorairePourColonne = "TRANCHE";
        public const string c_strCouleurPourColonne = "COULEUR";
        private DateTime m_dateDebut = DateTime.Now.Date;
        private DateTime m_dateFin = DateTime.Now.Date.AddDays(6);
        private Dictionary<int, IElementLigneDeTableauPlanning> m_elementsLignes = new Dictionary<int, IElementLigneDeTableauPlanning>();
    
        ArrayList m_listeEOplanifiees = new ArrayList();
        private CTypeTableauPlanning m_typeTableauPlanning;
                
        public CInstanceTableauPlanning(CTypeTableauPlanning typeTableau)
        {
            m_typeTableauPlanning = typeTableau;
            InitializeData(m_dateDebut, m_dateFin);
        }


        //----------------------------------------------------------------------
        public CResultAErreur InitializeData(DateTime dateDebut, DateTime dateFin)
        {
            CResultAErreur result = CResultAErreur.True;

            // Par défaut on visualise uen semaine à partir d'aujourd'hui
            m_dateDebut = dateDebut.Date;
            m_dateFin = dateFin.Date;

            if(m_dateFin > m_dateDebut.AddDays(30))
            {
                result.EmpileErreur(I.T( "Display limited to 31 days|455"));
                return result;
            }

            // Init la liste des Eo planifiées/Acteurs
            CListeObjetsDonnees listeEOplanifiees =
                new CListeObjetsDonnees(m_typeTableauPlanning.ContexteDonnee, typeof(CEOplanifiee_Acteur));
            listeEOplanifiees.Filtre = new CFiltreData(
                CEOplanifiee_Acteur.c_champDate + " >= @1 and " +
                CEOplanifiee_Acteur.c_champDate + " <= @2 ",
                m_dateDebut,
                m_dateFin);

            m_listeEOplanifiees = listeEOplanifiees.ToArrayList();
            

            // Remplissage des éléments de ligne
            CListeObjetsDonnees listeElementsLignes = null;
            if (m_typeTableauPlanning != null)
            {
                if (m_typeTableauPlanning.TypeElementsLigne != null)
                    listeElementsLignes = new CListeObjetsDonnees(m_typeTableauPlanning.ContexteDonnee, m_typeTableauPlanning.TypeElementsLigne);
                if (m_typeTableauPlanning.FiltreDynamiqueElementsLigne != null)
                    listeElementsLignes.Filtre = (CFiltreData)m_typeTableauPlanning.FiltreDynamiqueElementsLigne.GetFiltreData().Data;
            }
            if (listeElementsLignes != null)
            {
                int i = 0;
                foreach (IElementLigneDeTableauPlanning obj in listeElementsLignes)
                {
                    m_elementsLignes[i++] = obj;
                }
            }

            return result;
        }


        //----------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        public DateTime DateDebut
        {
            get { return m_dateDebut; }
            set { m_dateDebut = value; }
        }


        //----------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        public DateTime DateFin
        {
            get { return m_dateFin; }
            set { m_dateFin = value; }
        }



        //------------------------------------------------------------------------
        public Dictionary<int, IElementLigneDeTableauPlanning> ElementsLignes
        {
            get
            {
                return m_elementsLignes; 
            }
        }


        //------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable()
        {
            DataTable tableau = new DataTable();

            if (m_typeTableauPlanning == null)
                return new DataTable();

            CListeObjetsDonnees relTranchesHoraires = m_typeTableauPlanning.RelationsTranchesHoraires;

            // Ajout de la première colonne EO
            string nomCol1 = m_typeTableauPlanning.NomPremiereColonne;
            if (nomCol1 == String.Empty)
                nomCol1 = DynamicClassAttribute.GetNomConvivial(typeof(CEntiteOrganisationnelle));
            DataColumn colonne0 = new DataColumn(nomCol1);
            colonne0.DataType = typeof(string);
            tableau.Columns.Add(colonne0);
            
            // Construction des colonnes / Date / tranche
            for (DateTime date = DateDebut; date <= DateFin; date = date.AddDays(1))
            {
                foreach (CTypeTableauPlanning_TrancheHoraire rel in relTranchesHoraires)
                {
                    if (rel.EvaluerFormuleConditionnelle(date))
                    {
                        string nomColone = date.ToShortDateString() + "\n" + rel.Libelle;
                        DataColumn colonne = new DataColumn(nomColone);
                        colonne.ExtendedProperties.Add(c_strDatePourColonne, date);
                        colonne.ExtendedProperties.Add(c_strTrancheHorairePourColonne, rel.TrancheHoraire);
                        if(rel.TrancheHoraire.TypeOccupationHoraireAppliquee != null)
                            colonne.ExtendedProperties.Add(c_strCouleurPourColonne, Color.FromArgb(rel.TrancheHoraire.TypeOccupationHoraireAppliquee.Couleur));
                        colonne.DataType = typeof(CDataPlanning);
                        tableau.Columns.Add(colonne);
                    }
                }
            }

            // Construction des lignes du DataTable
            int i;
            for (i = 0; i < ElementsLignes.Count; i++)
            {
                DataRow row = tableau.NewRow();
                tableau.Rows.Add(row);

                object obj = ElementsLignes[i];
                if (obj is CEntiteOrganisationnelle)
                {
                    CEntiteOrganisationnelle eo = (CEntiteOrganisationnelle)obj;
                    int j;
                    for (j = 0; j < tableau.Columns.Count; j++)
                    {
                        if (j == 0)
                        {
                            // La première colonne contient les Elements de ligne (des EO)
                            row[0] = (ElementsLignes[i]).Libelle;
                        }
                        else
                        {

                            CEOplanifiee_Acteur planif = new CEOplanifiee_Acteur(m_typeTableauPlanning.ContexteDonnee);
                            
                            if(planif.ReadIfExists(new CFiltreData(
                                CEntiteOrganisationnelle.c_champId + " =@1 and " +
                                CEOplanifiee_Acteur.c_champDate + " =@2 and " +
                                CHoraireJournalier_Tranche.c_champId + " =@3",
                                eo.Id,
                                ((DateTime)(tableau.Columns[j]).ExtendedProperties[c_strDatePourColonne]).Date,
                                ((CHoraireJournalier_Tranche)(tableau.Columns[j]).ExtendedProperties[c_strTrancheHorairePourColonne]).Id
                                ), false))
                            {
                                row[(tableau.Columns[j])] = new CDataPlanning(typeof(CActeur), planif.Acteur);
                            }
                            else
                                row[(tableau.Columns[j])] = null;

                        }
                    }
                }
            }
            


            return tableau;

        }

        //-------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableau"></param>
        public CResultAErreur SetDataTable(DataTable tableau)
        {
            CResultAErreur result = CResultAErreur.True;
            if (tableau.Rows.Count != ElementsLignes.Count)
            {
                result.EmpileErreur("Error");
                return result;
            }

            int i;
            for (i=0; i< tableau.Rows.Count; i++)
            {
                DataRow row = tableau.Rows[i];
                CEntiteOrganisationnelle eo = (CEntiteOrganisationnelle) ElementsLignes[i];

                foreach (DataColumn col in tableau.Columns)
                {
                    if (row[col] is CDataPlanning)
                    {
                        CDataPlanning data = (CDataPlanning)row[col];
                        CEOplanifiee_Acteur planif = new CEOplanifiee_Acteur(m_typeTableauPlanning.ContexteDonnee);

                        if (planif.ReadIfExists(new CFiltreData(
                            CEntiteOrganisationnelle.c_champId + " =@1 and " +
                            CEOplanifiee_Acteur.c_champDate + " =@2 and " +
                            CHoraireJournalier_Tranche.c_champId + " =@3",
                            eo.Id,
                            ((DateTime)col.ExtendedProperties[c_strDatePourColonne]).Date,
                            ((CHoraireJournalier_Tranche)col.ExtendedProperties[c_strTrancheHorairePourColonne]).Id
                            ), false))
                        {
                            planif.Acteur = (CActeur)data.Element;
							if (planif.Acteur == null && planif.IsValide())
							{
								result = planif.Delete();
								if (!result)
									return result;
							}
                        }
                        else
                        {
                            if (data.Element != null)
                            {
                                planif.CreateNewInCurrentContexte();
                                planif.Acteur = (CActeur)data.Element;
                                planif.EntiteOrganisationnelle = eo;
                                planif.TrancheHoraire = (CHoraireJournalier_Tranche)col.ExtendedProperties[c_strTrancheHorairePourColonne];
                                planif.Date = ((DateTime)col.ExtendedProperties[c_strDatePourColonne]).Date;
                            }
                        }

                    }
                }

            }

            return result;
        }

     }



    ////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TypeElementEdite"></typeparam>
    public class CDataPlanning
    {
        private IElementDataDeTableauPlanning m_element = null;
        private Type m_typeElement;

        public Type TypeElement
        {
            get { return m_typeElement; }
        }

        public IElementDataDeTableauPlanning Element
        {
            get { return m_element; }
            set { m_element = value; }
        }

        //------------------------------------------------------------------------------
        public CDataPlanning(Type typeElement, IElementDataDeTableauPlanning element)
        {
            m_typeElement = typeElement;
            m_element = element;
        }

        //------------------------------------------------------------------------------
        public CDataPlanning(Type typeElement, int nIdElement, CContexteDonnee ctx)
        {
            m_typeElement = typeElement;

            try
            {
                CObjetDonneeAIdNumerique element = (CObjetDonneeAIdNumeriqueAuto)Activator.CreateInstance(typeElement, new object[] {ctx});
                if (element.ReadIfExists(nIdElement))
                    m_element = (IElementDataDeTableauPlanning) element;
                else
                    m_element = null;
            }
            catch 
            {
                m_element = null;                
            }
        }

    }

    /////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// 
    /// </summary>
    public interface IElementLigneDeTableauPlanning
    {
        string Libelle { get;}
        int Id { get;}
    }

    /////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// 
    /// </summary>
    public interface IElementDataDeTableauPlanning
    {
        string Libelle { get;}
        int Id { get;}
    }
}
