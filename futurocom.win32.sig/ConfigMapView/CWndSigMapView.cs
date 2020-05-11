using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.data;
using futurocom.sig;
using sc2i.common.sig;
using sc2i.common;
using sc2i.win32.data.dynamic;
using sc2i.formulaire;
using sc2i.formulaire.win32;
using sc2i.expression;
using GMap.NET.WindowsForms;
using sc2i.win32.common;
using sc2i.formulaire.win32.editor;
using futurocom.sig.cartography;

namespace futurocom.win32.sig
{
    public partial class CWndSigMapView : sc2i.win32.common.CVEarthCtrl
    {
        private const string c_strCleRegistre = "MAP_STATES";
        private object m_objetSource = null;
        private CMapDatabase m_mapDatabase = new CMapDatabase();

        private string m_strPreserveStateKey = "";
        private CConfigWndMapView m_configAppliquee = null;

        private Dictionary<CDbKey, CRuntimeConfigMapView> m_dicRuntimes = new Dictionary<CDbKey,CRuntimeConfigMapView>();

        private ExecuteActionMapItemDelegate m_executeActionDelegate;

        private List<CGPSCarte> m_listeCartes = new List<CGPSCarte>();
            
        //-----------------------------------------------------------
        public CWndSigMapView()
        {
            InitializeComponent();
            m_executeActionDelegate  = new ExecuteActionMapItemDelegate(ExecuteAction);
        }

        //-----------------------------------------------------------
        private void m_btnCalques_Click(object sender, EventArgs e)
        {
            if ( m_menuCalques.Items.Count == 0 )
                FillMenuCalques();
            m_menuCalques.Show ( m_btnCalques, new Point ( 0, m_btnCalques.Height ));
        }

        //-----------------------------------------------------------
        public object ObjetSource
        {
            get
            {
                return m_objetSource;
            }
            set
            {
                m_objetSource = value;
            }
        }

        //-----------------------------------------------------------
        private CRuntimeConfigMapView GetRuntimeConfig ( CDbKey keyConfig )
        {
            //TESTDBKEYOK
            CRuntimeConfigMapView runtime = null;
            m_dicRuntimes.TryGetValue ( keyConfig, out runtime );
            return runtime;
        }

        //-----------------------------------------------------------
        private IEnumerable<CRuntimeConfigMapView> GetRuntimesOrdered()
        {
            List<CRuntimeConfigMapView> lst = new List<CRuntimeConfigMapView>();
            lst.AddRange(m_dicRuntimes.Values);
            lst.Sort((x, y) => x.ZOrder.CompareTo(y.ZOrder));
            return lst.AsReadOnly();
        }

        //-----------------------------------------------------------
        private CRuntimeConfigMapView GetOrCreateRuntimeConfig ( CConfigMapDatabase config )
        {
            if ( config == null )
                return null;
            //TESTDBKEYOK
            CRuntimeConfigMapView runtime = GetRuntimeConfig ( config.DbKey );
            if ( runtime == null )
            {
                //TESTDBKEYOK
                runtime = CRuntimeConfigMapView.CreateFromConfig ( config );
                m_dicRuntimes[config.DbKey] = runtime;
            }
            return runtime;
        }

        //-----------------------------------------------------------
        public void ApplyConfig(
            CConfigWndMapView config, 
            object source)
        {
            m_configAppliquee = config;
            CResultAErreur result = CResultAErreur.True;
            m_objetSource = source;
            CContexteEvaluationExpression contexteEval = new CContexteEvaluationExpression(source);
            if (config.FormuleLatitude != null)
            {
                result = config.FormuleLatitude.Eval(contexteEval);
                if (result && result.Data is double || result.Data is int)
                    CenterLatitude = Convert.ToDouble(result.Data);

            }
            if (config.FormuleLongitude != null)
            {
                result = config.FormuleLongitude.Eval(contexteEval);
                if (result && result.Data is double || result.Data is int)
                    CenterLongitude = Convert.ToDouble(result.Data);
            }
            if (config.FormuleZoomFactor != null)
            {
                result = config.FormuleZoomFactor.Eval(contexteEval);
                if (result && result.Data is double || result.Data is int)
                    Zoom = Convert.ToDouble(result.Data);
            }
            m_strPreserveStateKey = "";
            if (config.FormulePreserveStateKey != null)
            {
                result = config.FormulePreserveStateKey.Eval(contexteEval);
                if (result && result.Data != null)
                    m_strPreserveStateKey = result.Data.ToString();
            }

            foreach (CConfigCalqueMap calqueConf in config.ConfigsCalques)
            {
                CRuntimeConfigMapView runtime = null;
                //TESTDBKEYOK
                m_dicRuntimes.TryGetValue(calqueConf.KeyConfigMapDatabase, out runtime);
                if (runtime == null)
                {
                    runtime = new CRuntimeConfigMapView();
                    //TESTDBKEYOK
                    runtime.KeyConfigMapDatabase = calqueConf.KeyConfigMapDatabase;
                }
                if (runtime.Generator == null)
                {
                    CConfigMapDatabase configInDb = new CConfigMapDatabase(CContexteDonneeSysteme.GetInstance());
                    //TESTDBKEYOK
                    if (!configInDb.ReadIfExists(calqueConf.KeyConfigMapDatabase))
                        continue;//bizarre, mais ça peut arriver
                    runtime.Generator = configInDb.MapGenerator;
                }
                //TESTDBKEYOK
                m_dicRuntimes[runtime.KeyConfigMapDatabase] = runtime;
                runtime.IsVisible = true;
                runtime.Generator.ClearVariables();
                foreach (CFormuleNommee formule in calqueConf.ValeursVariablesFiltre)
                {
                    if (formule.Formule != null)
                    {
                        try
                        {
                            string strVal = formule.Id;
                            // TESTDBKEYOK
                            if (runtime.Generator.GetVariable(strVal) != null)
                            {
                                result = formule.Formule.Eval(contexteEval);
                                if (result)
                                    runtime.Generator.SetValeurChamp(strVal, result.Data);
                            }
                        }
                        catch { }
                    }
                }
                runtime.IsCalculated = false;
            }
            if (m_strPreserveStateKey != null && m_configAppliquee != null)
            {
                string strState = C2iRegistre.GetValueInRegistreApplication(c_strCleRegistre, m_strPreserveStateKey, "");
                if (strState != "")
                {
                    CStringSerializer serializer = new CStringSerializer(strState, ModeSerialisation.Lecture);
                    SerializeState(serializer);
                }
            }
            ShowLayers();
            if (config.FormuleLatitude == null || config.FormuleLongitude == null || config.FormuleZoomFactor == null)
                AutoZoomAndCenter();

            
        }
        

        //-----------------------------------------------------------
        private void FillMenuCalques()
        {
            CListeObjetDonneeGenerique<CConfigMapDatabase> liste = CConfigMapDatabase.GetConfigsFor(
                m_objetSource is IObjetAContexteDonnee?((IObjetAContexteDonnee)m_objetSource).ContexteDonnee:CContexteDonneeSysteme.GetInstance(),
                m_objetSource == null ? null : m_objetSource.GetType());
            foreach (CConfigMapDatabase config in liste)
            {
                ToolStripMenuItem item = new ToolStripMenuItem(config.Libelle);
                CRuntimeConfigMapView runtime = null;
                //TESTDBKEYOK
                m_dicRuntimes.TryGetValue(config.DbKey, out runtime);
                if ( runtime == null )
                    runtime = GetOrCreateRuntimeConfig(config);
                item.Tag = runtime;
                item.CheckedChanged += new EventHandler(item_CheckedChanged);
                item.MouseUp += new MouseEventHandler(item_MouseUp);
                item.ToolTipText = I.T("Right click to setup|20013");
                m_menuCalques.Items.Add(item);
            }
        }

        //-------------------------------------------------------------
        void item_MouseUp(object sender, MouseEventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
                menuItem.Checked = !menuItem.Checked;
            else if ((e.Button & MouseButtons.Right) == MouseButtons.Right)
            {
                SetupRuntime(menuItem.Tag as CRuntimeConfigMapView);
            }
        }


        //-------------------------------------------------------------
        private void SetupRuntime(CRuntimeConfigMapView runtime)
        {
            if (runtime == null)
                return;
            if (CFormFormulairePopup.EditeElement(runtime.Generator.Formulaire,
                runtime.Generator,
                I.T("Setup layer|20014")))
            {
                runtime.IsCalculated = false;
                ShowLayers();
            }
        }

        //-----------------------------------------------------------
        private bool m_bIsUpdatingMenu = false;
        void item_CheckedChanged(object sender, EventArgs e)
        {
            if (m_bIsUpdatingMenu)
                return;
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            CRuntimeConfigMapView runtime = item != null ? item.Tag as CRuntimeConfigMapView : null;
            if (runtime != null)
            {
                runtime.IsVisible = item.Checked;
                PutInFront(runtime);
                ShowLayers();
            }
        }

        //-----------------------------------------------
        private void PutInFront(CRuntimeConfigMapView runtime)
        {
            IEnumerable<CRuntimeConfigMapView> lst = GetRuntimesOrdered();
            if (lst.Count() > 0)
                runtime.ZOrder = lst.ElementAt(lst.Count() - 1).ZOrder + 1;
        }

        //-----------------------------------------------
        private void m_menuCalques_Opening(object sender, CancelEventArgs e)
        {
            m_bIsUpdatingMenu = true;
            foreach (ToolStripMenuItem item in m_menuCalques.Items)
            {
                CRuntimeConfigMapView runtime = item.Tag as CRuntimeConfigMapView;
                if (runtime != null)
                    item.Checked = runtime.IsVisible;
            }
            m_bIsUpdatingMenu = false;
        }

        //-----------------------------------------------
        private void ShowLayers()
        {
            int nZOrder = 0;
            foreach (CRuntimeConfigMapView runtime in GetRuntimesOrdered())
            {
                CMapLayer layer = m_mapDatabase.GetLayer(runtime.Generator.LayerId);
                if (runtime.IsVisible)
                {
                    if (!runtime.IsCalculated)
                    {
                        if ( layer != null )
                            layer.ClearItems();
                        using (sc2i.win32.common.CWaitCursor waiter = new sc2i.win32.common.CWaitCursor())
                        {
                            runtime.Generator.ElementEdite = m_objetSource;
                            runtime.Generator.FillMapDatabase(m_objetSource, m_mapDatabase, runtime.Generator.ContexteDonnee);
                            runtime.IsCalculated = true;
                            if (runtime.Generator.ExecuteurAction != m_executeActionDelegate)
                                runtime.Generator.ExecuteurAction = m_executeActionDelegate;
                        }
                    }
                    if (layer != null)
                        layer.IsVisible = true;
                }
                else if (layer != null)
                        layer.IsVisible = false;
                if (layer != null)
                    layer.ZOrder = nZOrder++;
            }
            foreach ( CGPSCarte carte in m_listeCartes )
            {
                carte.GenereItems(m_mapDatabase);
            }
            SetMapDatabase(m_mapDatabase);
        }

        //-----------------------------------------------
        public void ExecuteAction(CActionSur2iLink action, IMapItem item)
        {
            if (action != null && item != null)
                CExecuteurActionSur2iLink.ExecuteAction(this, action, item.Tag);
        }

        //-----------------------------------------------
        public void RecalculateItems()
        {
            foreach (CRuntimeConfigMapView runtime in m_dicRuntimes.Values)
                runtime.IsCalculated = false;
            ShowLayers();
        }

        //-----------------------------------------------
        private int GetNumVersionForState
        {
            get
            {
                return 0;
            }
        }

        //-----------------------------------------------
        public CResultAErreur SerializeState ( C2iSerializer serializer)
        {
            int nVersion = GetNumVersionForState;
            CResultAErreur result=  serializer.TraiteVersion ( ref nVersion );

            double fLat = 0;
            double fLong = 0;
            double fZoom = 4;
            int nMapMode = (int)EMapStyle.Road;
            if (serializer.Mode == ModeSerialisation.Ecriture && m_gMap != null)
            {
                fLat = m_gMap.Position.Lat;
                fLong = m_gMap.Position.Lng;
                fZoom = m_gMap.Zoom;
                nMapMode = (int)MapStyle;
            }
            serializer.TraiteDouble(ref fLat);
            serializer.TraiteDouble(ref fLong);
            serializer.TraiteDouble(ref fZoom);
            serializer.TraiteInt(ref nMapMode);
            int nNbRuntimes = m_dicRuntimes.Count();
            serializer.TraiteInt(ref nNbRuntimes);
            switch (serializer.Mode)
            {
                case ModeSerialisation.Ecriture:
                    foreach (CRuntimeConfigMapView runtime in m_dicRuntimes.Values)
                    {
                        result = runtime.Serialize(serializer);
                        if (!result)
                            return result;
                    }
                    break;
                case ModeSerialisation.Lecture:
                    for (int nRuntime = 0; nRuntime < nNbRuntimes; nRuntime++)
                    {
                        CRuntimeConfigMapView runtime = new CRuntimeConfigMapView();
                        result = runtime.Serialize(serializer);
                        if (!result)
                            return result;
                        if (m_configAppliquee.PreserveLayers)
                        {
                            //si le runtime existe, il est mis à jour
                            //TESTDBKEYOK
                            CRuntimeConfigMapView existant = GetRuntimeConfig(runtime.KeyConfigMapDatabase);
                            if (existant != null && existant.Generator != null)
                            {
                                existant.Generator.ClearVariables();
                                foreach (KeyValuePair<string, object> kv in runtime.Generator.ValeursVariables)
                                    existant.Generator.SetValeurChamp(kv.Key, kv.Value);
                                existant.IsVisible = runtime.IsVisible;
                                existant.ZOrder = runtime.ZOrder;
                            }
                            else if ( runtime.Generator != null )
                                //TESTDBKEYOK
                                m_dicRuntimes[runtime.KeyConfigMapDatabase] = runtime;
                        }
                    }
                    break;
            }
            if (serializer.Mode == ModeSerialisation.Lecture)
            {
                if ( m_configAppliquee.PreserveCenter )
                {
                    CenterLatitude = fLat;
                    CenterLongitude = fLong;
                }
                if ( m_configAppliquee.PreserveZoom )
                    Zoom = fZoom;
                if (m_configAppliquee.PreserveMapMode)
                    MapStyle = (EMapStyle)nMapMode;

            }
            return result;
        }

        //------------------------------------------------
        private void SaveStateInRegistre()
        {
            if (m_strPreserveStateKey != null && m_strPreserveStateKey.Length > 0)
            {
                CStringSerializer serializer = new CStringSerializer(ModeSerialisation.Ecriture);
                CResultAErreur result = SerializeState(serializer);
                string strVal = serializer.String;
                if (!result)
                    strVal = "";
                C2iRegistre.SetValueInRegistreApplication(c_strCleRegistre, m_strPreserveStateKey, strVal);
            }

        }

        //------------------------------------------------
        public void AddStaticMap(CGPSCarte carte )
        {
            if ( carte != null && !m_listeCartes.Contains(carte ))
            m_listeCartes.Add(carte);
            ShowLayers();
        }

        //------------------------------------------------
        public void RemoveStaticMap(CGPSCarte carte)
        {
            if (carte != null && m_listeCartes.Contains(carte))
            {
                m_mapDatabase.RemoveLayer(carte.IdUniversel);
                m_listeCartes.Remove(carte);
                ShowLayers();
            }
        }




    }
}
