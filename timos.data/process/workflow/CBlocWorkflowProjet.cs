using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.expression;
using sc2i.data.dynamic;
using sc2i.common;
using System.Drawing;
using sc2i.process.workflow.dessin;
using sc2i.drawing;
using System.Drawing.Drawing2D;
using timos.data;
using sc2i.formulaire;
using sc2i.workflow;
using timos.data.process.workflow;
using sc2i.data;
using timos.data.projet;

namespace sc2i.process.workflow.blocs
{
    
    /// TODO :
    /// Gérer des projets sans ittérations
    /// Gérer des affectation pour itération 0 et pour ittération 1
    /// Gérer des formules s'executant en fin d'ittération 0 et pour ittération 1

    public class CBlocWorkflowProjet : CBlocWorkflowWorkflow
    {
        public const string c_constIdLienProjetForce = "PROJECT_LINK";
        private CDbKey m_dbKeyTypeProjet = null;
        private bool m_bGererIterations = true;

        private List<CAffectationsProprietes> m_listeAffectations = new List<CAffectationsProprietes>();
        
        //Id du champ qui permet de stocker le projet lié à l'étape
        private int? m_nIdChampProjet = null;

        private C2iExpression m_formuleGanttId = null;


        //-----------------------------------------------------
        public CBlocWorkflowProjet()
            : base()
        {
            
        }

        //-----------------------------------------------------
        public CBlocWorkflowProjet(CTypeEtapeWorkflow typeEtape)
            : base(typeEtape)
        {
        }

        //---------------------------------------------------
        public override Size DefaultSize
        {
            get
            {
                return new Size(120, 50);
            }
        }

        //---------------------------------------------------
        public CDbKey DbKeyTypeProjet
        {
            get
            {
                return m_dbKeyTypeProjet;
            }
            set
            {
                m_dbKeyTypeProjet = value;
            }
        }

        //---------------------------------------------------
        public bool GererIteration
        {
            get
            {
                return m_bGererIterations;
            }
            set
            {
                m_bGererIterations = value;
            }
        }

        //---------------------------------------------------
        public int? IdChampProjet
        {
            get
            {
                return m_nIdChampProjet;
            }
            set
            {
                m_nIdChampProjet = value;
            }
        }

        //---------------------------------------------------
        public IEnumerable<CAffectationsProprietes> AffectationsCreationEtDemarrage
        {
            get
            {
                if (m_listeAffectations.Count == 0)
                    m_listeAffectations = GetAffectationsParDefaut();
                return m_listeAffectations.AsReadOnly();
            }
            set
            {
                m_listeAffectations.Clear();
                if ( value != null )
                    m_listeAffectations.AddRange(value);
            }
        }

        //---------------------------------------------------
        public List<CAffectationsProprietes> GetAffectationsParDefaut()
        {
            List<CAffectationsProprietes> lst = new List<CAffectationsProprietes>();
            return lst;
        }

        //---------------------------------------------------
        public C2iExpression FormuleGanttId
        {
            get
            {
                return m_formuleGanttId;
            }
            set
            {
                m_formuleGanttId = value;
            }
        }

        //---------------------------------------------------
        public string GetGanttId(CEtapeWorkflow etape)
        {
            if (FormuleGanttId == null)
                return etape.UniversalId;
            CContexteEvaluationExpression ctx = new CContexteEvaluationExpression(etape);
            CResultAErreur result = FormuleGanttId.Eval(ctx);
            if (!result || result.Data == null || result.Data.ToString() == "")
                return etape.UniversalId;
            return result.Data.ToString();
        }

        //---------------------------------------------------
        private int GetNumVersion()
        {
            //return 2; //2 : Ajout de GererIteration
            return 3; // Pasaeg de Id Type Projet et Champ Projet en DbKey
        }

        //---------------------------------------------------
        public override CResultAErreur MySerialize(sc2i.common.C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            result = base.MySerialize(serializer);
            if (!result)
                return result;

            if (nVersion < 3)
            {
                // TESTDBKEYTODO
                serializer.ReadDbKeyFromOldId(ref m_dbKeyTypeProjet, typeof(CTypeProjet));
            }
            else
            {
                serializer.TraiteDbKey(ref m_dbKeyTypeProjet);
            }

            int nId = m_nIdChampProjet == null ? -1 : m_nIdChampProjet.Value;
            serializer.TraiteInt(ref nId);
            if (serializer.Mode == ModeSerialisation.Lecture)
                m_nIdChampProjet = nId >= 0 ? (int?)nId : null;

            result = serializer.TraiteListe<CAffectationsProprietes>(m_listeAffectations);
            if (!result)
                return result;

            if (nVersion >= 1)
                result = serializer.TraiteObject<C2iExpression>(ref m_formuleGanttId);
            if (!result)
                return result;
            if (nVersion >= 2 )
                serializer.TraiteBool(ref m_bGererIterations);
            
            return result;
        }


        //---------------------------------------------------
        public override Point[] GetPolygoneDessin(CWorkflowEtapeDessin donneesDessin)
        {
            Rectangle rct = donneesDessin.RectangleAbsolu;
            return new Point[]{
                new Point(rct.Left, rct.Top),
                new Point(rct.Right, rct.Top ),
                new Point ( rct.Right, rct.Bottom ),
                new Point ( rct.Left, rct.Bottom )};
        }

        //---------------------------------------------------
        protected override void MyDraw(CContextDessinObjetGraphique contexte, CWorkflowEtapeDessin donneesDessin)
        {
            Rectangle rct = donneesDessin.RectangleAbsolu;
            Brush br = new SolidBrush(Color.FromArgb(64, 0, 0, 0));
            rct.Size = new Size(rct.Width - 4, rct.Height - 4);
            contexte.Graphic.FillRectangle(br,
                rct.Left + 4,
                rct.Top + 4,
                rct.Width,
                rct.Height);

            br.Dispose();
            br = new SolidBrush(donneesDessin.BackColor);
            Pen pen = new Pen(donneesDessin.ForeColor);
            Font ft = donneesDessin.Font;
            if (ft == null)
                ft = new Font("Arial", 8);

            contexte.Graphic.FillRectangle(br, rct);
            contexte.Graphic.DrawRectangle(pen, rct);
            if (rct.Size.Width > BlocImage.Size.Width &&
                rct.Size.Height > BlocImage.Size.Height)
            {
                Rectangle rctImage = new Rectangle(rct.Left, rct.Top, BlocImage.Width, BlocImage.Height);
                contexte.Graphic.DrawImage(BlocImage, rctImage);
                Brush brTrans = new SolidBrush(Color.FromArgb(128, donneesDessin.BackColor));
                contexte.Graphic.FillRectangle(brTrans, rctImage);
                brTrans.Dispose();
            }

            if (TypeEtape != null && ft != null)
            {
                br.Dispose();
                br = new SolidBrush(donneesDessin.ForeColor);
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                contexte.Graphic.DrawString(TypeEtape.Libelle, ft, br, rct, sf);
                sf.Dispose();
            }
            if (donneesDessin.Font == null)
                ft.Dispose();
            pen.Dispose();
            br.Dispose();
        }

        //---------------------------------------------------
        public override string BlocName
        {
            get { return I.T("Project|20141"); }
        }

        //---------------------------------------------------
        public override string BlocTypeCode
        {
            get { return "PROJECT"; }
        }

        //---------------------------------------------------
        public override Image BlocImage
        {
            get { return Resource.project_open; }
        }

        //---------------------------------------------------
        //S'assure que le projet est bien créé
        internal CResultAErreurType<CProjet> GetOrCreateProjetInCurrentContexte(CEtapeWorkflow etape, CProjet projetParent, IEnumerable<CProjet> predecesseurs)
        {
            CResultAErreurType<CProjet> resProjet = new CResultAErreurType<CProjet>();
            CWorkflow workflow = GetOrCreateWorkflowInCurrentContexte(etape);
            if (workflow == null)
            {
                resProjet.EmpileErreur(I.T("Can not create workflow for step @1|20143", etape.Libelle));
                return resProjet;
            }
            if (m_nIdChampProjet == null)
            {
                resProjet.EmpileErreur(I.T("Workflow step @1 doesn't define a field to store associated project|20142", etape.Libelle));
                return resProjet;
            }
            CProjet projet = workflow.GetValeurChamp(m_nIdChampProjet.Value) as CProjet;

            //SC 8/5/2013 : s'assure que le projet a le bon parent !
            if (projetParent != null && projet != null &&
                projetParent != projet.Projet)
                projet = null;
            string strGanttId = GetGanttId(etape);
            if ( projet == null )
            {
                //Création du projet
                projet = new CProjet(etape.ContexteDonnee);
                CTypeProjet typeProjet = null;
                if (m_dbKeyTypeProjet != null) //s'il est null, pas d'erreur ça peut être les formules d'initialisation qui le remplissent
                {
                    typeProjet = new CTypeProjet(etape.ContexteDonnee);
                    if (!typeProjet.ReadIfExists(m_dbKeyTypeProjet))
                    {
                        resProjet.EmpileErreur(I.T("Project type @1 for step @2 doesn't exists|20144", m_dbKeyTypeProjet.StringValue, etape.Libelle));
                        return resProjet;
                    }
                }
                projet.CreateNewInCurrentContexte();
                projet.TypeProjet = typeProjet;
                projet.GanttId = strGanttId;
                DateTime? dateDebut = null;
                foreach (CProjet pred in predecesseurs)
                {
                    if (dateDebut == null || pred.DateFinGantt > dateDebut.Value)
                        dateDebut = pred.DateFinGantt;
                }
                if (dateDebut == null)
                    dateDebut = DateTime.Now;
                projet.DateDebutPlanifiee = dateDebut;
                if (typeProjet != null)
                    projet.DateFinPlanifiee = projet.DateDebutPlanifiee.Value.AddHours(typeProjet.DureeDefautHeures);
                projet.Projet = projetParent;
                projet.Libelle = etape.Libelle;
                CContexteEvaluationExpression ctxEval = new CContexteEvaluationExpression(etape);
                foreach (CAffectationsProprietes affectation in AffectationsCreationEtDemarrage)
                {
                    bool bAppliquer = affectation.FormuleCondition == null || affectation.FormuleCondition is C2iExpressionVrai;
                    if (affectation.FormuleCondition != null)
                    {
                        CResultAErreur res = affectation.FormuleCondition.Eval(ctxEval);
                        if (res && res.Data != null && CUtilBool.BoolFromString(res.Data.ToString()) == true)
                            bAppliquer = true;
                    }
                    if (bAppliquer)
                        affectation.AffecteProprietes(projet, etape, new CFournisseurPropDynStd());
                }
                foreach (CProjet predecesseur in predecesseurs)
                {
                    projet.AddPredecessor(predecesseur);
                }
                CResultAErreur result = workflow.SetValeurChamp(m_nIdChampProjet.Value, projet);
                if (!result)
                {
                    resProjet.EmpileErreur(result.MessageErreur);
                    return resProjet;
                }
            }
            resProjet.DataType = projet;
            return resProjet;
        }

        
        //--------------------------------------------------------------------------
        public override CResultAErreur RunAndSaveIfOk(CEtapeWorkflow etape)
        {
            CResultAErreur result = CResultAErreur.True;

            System.Console.WriteLine("Démarrage étape " + etape.Libelle);

            return base.RunAndSaveIfOk(etape);
        }

        //--------------------------------------------------------------------------
        protected override CResultAErreur PrepareToStartWorkflow(CEtapeWorkflow etape)
        {
            StartOrRestartProjet(etape);
            return base.PrepareToStartWorkflow(etape);
        }

        //--------------------------------------------------------------------------
        private CResultAErreur StartOrRestartProjet(CEtapeWorkflow etape)
        {
            CResultAErreur result = CResultAErreur.True;
            CResultAErreurType<CProjet> resProjet = CGestionnaireProjetsDeWorkflow.AssureProjetRunnable(etape, this);
            if (!resProjet)
            {
                result.EmpileErreur(resProjet.Erreur);
                return result;
            }
            CProjet projet = resProjet.DataType;
            if (projet == null)
                return result;

            if (etape.DateDebut == null)
                etape.DateDebut = DateTime.Now;

            if (projet.ProjetsFils.Count == 0)
            {
                if (projet.DateDebutReel == null || GererIteration)
                {
                    projet.DateDebutReel = etape.DateDebut.Value;
                    projet.DateFinRelle = null;
                }
                else if (!projet.HasOptionLienEtape(EOptionLienProjetEtape.StepKeepDates))
                {
                    projet.DateDebutReel = etape.DateDebut.Value;
                    projet.DateFinRelle = null;
                }
            }
            CContexteEvaluationExpression ctxEval = new CContexteEvaluationExpression(etape);
            foreach (CAffectationsProprietes affectation in AffectationsCreationEtDemarrage)
            {
                bool bAppliquer = affectation.FormuleCondition == null || affectation.FormuleCondition is C2iExpressionVrai;
                if (affectation.FormuleCondition != null)
                {
                    CResultAErreur res = affectation.FormuleCondition.Eval(ctxEval);
                    if (res && res.Data != null && CUtilBool.BoolFromString(res.Data.ToString()) == true)
                        bAppliquer = true;
                }
                if (bAppliquer)
                    affectation.AffecteProprietes(projet, etape, new CFournisseurPropDynStd());
            }
            System.Console.WriteLine("Démarrage projet " + projet.Libelle);
            return result;
        }

        //---------------------------------------------------
        public override CResultAErreur OnBlocRedemarréParUneEtapeDuSousWorkflow(CEtapeWorkflow etape)
        {
            CResultAErreur result = base.OnBlocRedemarréParUneEtapeDuSousWorkflow(etape);
            if (result)
            {
                result = StartOrRestartProjet(etape);
                
            }
            return result;
        }

        //---------------------------------------------------
        public override CResultAErreur  EndEtapeNoSave(CEtapeWorkflow etape)
        {
            CResultAErreur result = CResultAErreur.True;

            CResultAErreurType<CProjet> resProjet = GetOrCreateProjetInCurrentContexte(etape,
                CGestionnaireProjetsDeWorkflow.FindProjetParent(etape),
                CGestionnaireProjetsDeWorkflow.FindPredecesseurs(etape));
            if (!resProjet)
            {
                result.EmpileErreur(resProjet.Erreur);
                return result;
            }
            CProjet projet = resProjet.DataType;
            if (projet == null)
                return result;
            System.Console.WriteLine("Fin projet " + projet.Libelle);
            DateTime dt = etape.DateFin == null ?DateTime.Now:etape.DateFin.Value;
            if (projet.ProjetsFils.Count == 0)
            {
                if (!projet.HasOptionLienEtape(EOptionLienProjetEtape.StepKeepDates) ||
                    projet.DateFinRelle == null)
                    projet.DateFinRelle = dt;
            }

            if (projet.HasOptionLienEtape(EOptionLienProjetEtape.ResetFlagOnEndStep))
                projet.OptionLienEtapeCode = (int)EOptionLienProjetEtape.Standard;

            return base.EndEtapeNoSave(etape);
        }

        public override string[] CodesRetourPossibles
        {
            get
            {
                return new string[]{"",c_constIdLienProjetForce};
            }
        }
    }
}
