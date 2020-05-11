using System;
using System.Drawing;
using System.IO;
using System.Drawing.Design;
using System.Collections.Generic;


using sc2i.expression;
using sc2i.common;
using sc2i.drawing;
using sc2i.formulaire;
using System.ComponentModel;
using futurocom.sig.cartography;


namespace futurocom.sig
{
	public enum EWndMapMode
	{
		Map = 0,
		Aerial = 1,
        Hybrid = 2
	}
	/// <summary>
	/// Description résumée de C2iLabel.
	/// </summary>
	[WndName("Map view")]
	[Serializable]
    [ReplaceClass("sc2i.formulaire.C2iWndMapView")]
	public class C2iWndMapView : C2iWndComposantFenetre, IDisposable
	{
		public const string c_strIdMouseUpOnMap = "MAP_MOUSEUP";

        private CConfigWndMapView m_config = new CConfigWndMapView();

        private bool m_bMarkerOnClick = false;

		/// ///////////////////////
		public C2iWndMapView()
		{
			Size = new Size(100, 60);
            LockMode = ELockMode.Independant;
		}

		/// ///////////////////////
		public void Dispose()
		{
			
		}

		/// ///////////////////////////////////////
		public override bool CanBeUseOnType(Type tp)
		{
			return true;
		}

		

		
		

        /////////////////////////////////////
        [Editor(typeof(CConfigWndMapViewEditor), typeof(UITypeEditor))]
        public CConfigWndMapView MapSetup
        {
            get
            {
                return m_config;
            }
            set
            {
                m_config = value;
            }
        }
		
		

#if PDA
#else
		/// ///////////////////////
		protected override void MyDraw( CContextDessinObjetGraphique ctx )
		{
            Graphics g = ctx.Graphic;
			Rectangle rect = new Rectangle ( Position , Size );
            Image img = Resource.MapViewDesignTime;
            g.DrawImage ( img, rect );
		}


        /// ///////////////////////
        public bool ShowMarkerOnClick
        {
            get
            {
                return m_bMarkerOnClick;
            }
            set
            {
                m_bMarkerOnClick = value;
            }
        }
		
#endif
		/// ///////////////////////////////////////
		private int GetNumVersion()
		{
			return 2;
            //Remplacement des parametres par un CConfigWndMapView
            //2 ajout de ShowMarkerOnClick
		}

		/// ///////////////////////////////////////
		protected override CResultAErreur MySerialize(C2iSerializer serializer)
		{
			int nVersion = GetNumVersion();
			CResultAErreur result = serializer.TraiteVersion(ref nVersion);
			if (!result)
				return result;
            if (m_config == null)
                m_config = new CConfigWndMapView();

            #region Compatibilité version 1
            if (nVersion < 1)
            {
                C2iExpression expression = m_config.FormuleLatitude;
                serializer.TraiteObject<C2iExpression>(ref expression);
                m_config.FormuleLatitude = expression;

                expression = m_config.FormuleLongitude;
                serializer.TraiteObject<C2iExpression>(ref expression);
                m_config.FormuleLongitude = expression;

                int nVal = (int)m_config.MapMode;
                serializer.TraiteInt(ref nVal);
                m_config.MapMode = (EWndMapMode)nVal;

                int nTmp = 4;
                serializer.TraiteInt(ref nTmp);
                m_config.FormuleZoomFactor = new C2iExpressionConstante(nTmp);
            }
            #endregion

            if (nVersion >= 1)
            {
                result = serializer.TraiteObject<CConfigWndMapView>(ref m_config);
                if (!result)
                    return result;
            }
            if (nVersion >= 2)
            {
                serializer.TraiteBool(ref m_bMarkerOnClick);
            }
			return result;
		}

		//-------------------------------------------------------------
		public override CDefinitionProprieteDynamique[] GetProprietesInstance()
		{
			List<CDefinitionProprieteDynamique> lst = new List<CDefinitionProprieteDynamique>();
			lst.AddRange(base.GetProprietesInstance());
			
			lst.Add ( new CDefinitionProprieteDynamiqueDeportee (
				"Latitude", "Latitude", 
				new CTypeResultatExpression(typeof(double), false ),
				false,
				false,
				""));
			lst.Add ( new CDefinitionProprieteDynamiqueDeportee (
				"Longitude", "Longitude", 
				new CTypeResultatExpression(typeof(double), false ),
				false,
				false,
				""));
			lst.Add ( new CDefinitionProprieteDynamiqueDeportee (
				"ZoomFactor", "ZoomFactor", 
				new CTypeResultatExpression(typeof(int), false ),
				false,
				false,
				""));
			lst.Add ( new CDefinitionProprieteDynamiqueDeportee(
				"MapMode", "MapMode",
				new CTypeResultatExpression(typeof(int), false ),
				false,
				false,
				""));

			lst.Add(new CDefinitionProprieteDynamiqueDeportee(
				"Last Latitude click", "LastLatitudeClick",
				new CTypeResultatExpression ( typeof(double), false ),
				false,
				true,
				""));
			lst.Add(new CDefinitionProprieteDynamiqueDeportee(
				"Last Longitude click", "LastLongitudeClick",
				new CTypeResultatExpression ( typeof(double), false ),
				false,
				true,
				""));

			lst.Add(new CDefinitionMethodeDynamique(
				"MarkPoint", "MarkPoint",
				new CTypeResultatExpression(typeof(void), false),
				false,
				I.T("Mark a point on the map|20008"),
				new string[]{
					I.T("Latitude|20009"),
					I.T("Longitude|20010"),
					I.T("Point label|20021")
				}
				)
				);
			lst.Add(new CDefinitionMethodeDynamique(
				"ClearPoints", "ClearPoints",
				new CTypeResultatExpression(typeof(void), false),
				false,
				I.T("Clear marked points|20011"),
				new string[0]));

            lst.Add(new CDefinitionMethodeDynamique(
                "DrawLine", "DrawLine",
                new CTypeResultatExpression(typeof(void), false),
                false,
                I.T("Draw a line on the map|20014"),
                new string[]{
                    I.T("Point 1 latitude|20015"),
                    I.T("Point 1 longitude|20016"),
                    I.T("Point 2 latitude|20017"),
                    I.T("Point 2 longitude|20018"),
                    I.T("Line color|20019")}));
            lst.Add(new CDefinitionMethodeDynamique(
                "ClearLines", "ClearLines",
                new CTypeResultatExpression(typeof(void), false),
                false,
                I.T("Clear lines on map|20020"),
                new string[0]));

            lst.Add(new CDefinitionMethodeDynamique(
                "RecalculateItems", "RecalculateItems",
                new CTypeResultatExpression(typeof(void), false),
                false,
                I.T("Recalculate map items from layers setup|20022"),
                new string[0]));

            lst.Add(new CDefinitionMethodeDynamique(
                "AddStaticMap", "AddStaticMap",
                new CTypeResultatExpression(typeof(void), false),
                false,
                I.T("Add a static map to the view|20030"),
                new string[]{I.T("Map to add|20033")}));

            lst.Add(new CDefinitionMethodeDynamique(
                "RemoveStaticMap", "RemoveStaticMap",
                new CTypeResultatExpression(typeof(void), false),
                false,
                I.T("Remove a static map from the view|20031"),
                new string[]{I.T("Map to remove|20034")}));
            lst.Add(new CDefinitionMethodeDynamique(
                "AutoZoomAndCenter", "AutoZoomAndCenter",
                new CTypeResultatExpression(typeof(void), false),
                false,
                I.T("Adjust zoom and center to fit content|20032"),
                new string[0]));

			return lst.ToArray();
		}

		//-------------------------------------------------------------
		public override CDescriptionEvenementParFormule[] GetDescriptionsEvenements()
		{
			List<CDescriptionEvenementParFormule> lst = new List<CDescriptionEvenementParFormule>(base.GetDescriptionsEvenements());
			lst.Add(new CDescriptionEvenementParFormule(
				c_strIdMouseUpOnMap, "OnClick",
				I.T("Occurs when user click on the map|20012")));
			return lst.ToArray();
		}

        //-------------------------------------------------------------
        public override void OnDesignSelect(Type typeEdite, object objetEdite, IFournisseurProprietesDynamiques fournisseurProprietes)
        {
            CConfigWndMapViewEditor.ObjetEdite = typeEdite;
            CConfigWndMapViewEditor.FournisseurProprietes = fournisseurProprietes;
            base.OnDesignSelect(typeEdite, objetEdite, fournisseurProprietes);
        }

	}
}
