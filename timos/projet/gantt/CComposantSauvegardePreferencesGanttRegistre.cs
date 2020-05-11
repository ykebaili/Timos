using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using sc2i.win32.data.navigation;


namespace timos.projet.gantt
{
    public class CComposantSauvegardePreferencesGanttRegistre : Component
    {

        private CControlGanttProjet m_controlGantt;

        public CComposantSauvegardePreferencesGanttRegistre()
        {

        }

        //------------------------------------------------------------------
        public CControlGanttProjet ControlGantt
        {
            get
            {
                return m_controlGantt;
            }
            set
            {
                m_controlGantt = value;
            }
        }

        //--------------------------------------------------------------
        public void InitFromRegistre()
        {
            new CContextPreferencesGantt(m_controlGantt).LirePreferencesDuRegistre();
        }

        //--------------------------------------------------------------------
        public void SaveToRegistre()
        {
            // Sauver les préférences dans le registre
            new CContextPreferencesGantt(m_controlGantt).SauvegarderPreferencesDansRegistre();
        }


        /////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 
        /// </summary>
        private class CContextPreferencesGantt
        {
            public readonly string CleParametrageGroupement = "";
            public readonly string CleParametrageDessin = "";

            CControlGanttProjet m_control;

            public CContextPreferencesGantt(CControlGanttProjet control)
            {
                m_control = control;
                // La clé est contituée du type de la fenêtre (Form) dans laquelle s'ouvre le Gantt
                string cleRacine = control.FindForm().GetType().ToString() + "_" + control.Name;
                CleParametrageGroupement = cleRacine + "_groupement";
                CleParametrageDessin = cleRacine + "_dessin";
            }

            /// <summary>
            /// Le spréférences sauvegardées sont :
            /// L'Id du Parametre de groupement
            /// L'Id du parametre de dessin
            /// </summary>
            public void SauvegarderPreferencesDansRegistre()
            {
                if (m_control != null)
                {
                    if (m_control.ParametrageGroupement != null)
                        new CTimosAppRegistre().SetDataParametreGantt(CleParametrageGroupement, m_control.ParametrageGroupement.Id.ToString());
                    else
                        new CTimosAppRegistre().SetDataParametreGantt(CleParametrageGroupement, "");


                    if (m_control.ParametrageDessin != null)
                        new CTimosAppRegistre().SetDataParametreGantt(CleParametrageDessin, m_control.ParametrageDessin.Id.ToString());
                    else
                        new CTimosAppRegistre().SetDataParametreGantt(CleParametrageDessin, "");
                }

            }

            public void LirePreferencesDuRegistre()
            {
                if (m_control != null)
                {
                    int idParamGroupe = -999;
                    int idParamDessin = -999;

                    try
                    {
                        idParamGroupe = Int32.Parse(new CTimosAppRegistre().GetDataParametreGantt(CleParametrageGroupement));
                    }
                    catch{}
                    try
                    {
                        idParamDessin = Int32.Parse(new CTimosAppRegistre().GetDataParametreGantt(CleParametrageDessin));
                    }
                    catch{}

                    m_control.SetPreferencesParametres(idParamGroupe, idParamDessin);
               
                }
            }

        }
    }


}
