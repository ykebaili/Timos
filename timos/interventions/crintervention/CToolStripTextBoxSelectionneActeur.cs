using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;


using sc2i.win32.common;
using sc2i.data;
using sc2i.win32.data;
using timos.data;
using timos.acteurs;

using sc2i.common;
using sc2i.win32.data.navigation;
using sc2i.multitiers.client;
using sc2i.data.dynamic;
using sc2i.workflow;

namespace timos
{

    public partial class CToolStripTextBoxSelectionneActeur : ToolStripControlHost
    {
        public CToolStripTextBoxSelectionneActeur()
            : base(new C2iTextBoxSelectionne())
        {
            //InitializeComponent();
        }

        public C2iTextBoxSelectionne C2iTextBoxSelectionneControl
        {
            get
            {
                return Control as C2iTextBoxSelectionne;
            }
        }

        // Expose the C2iTextBoxSelectionne.FirstDayOfWeek as a property.
        public CActeur Acteur
        {
            get
            {
                return C2iTextBoxSelectionneControl.ElementSelectionne as CActeur;
            }
            set
            {
                C2iTextBoxSelectionneControl.ElementSelectionne = value;
            }
        }


        // Subscribe and unsubscribe the control events you wish to expose.
        protected override void OnSubscribeControlEvents(Control c)
        {
            // Call the base so the base events are connected.
            base.OnSubscribeControlEvents(c);

            // Cast the control to a C2iTextBoxSelectionne control.
            C2iTextBoxSelectionne C2iTextBoxSelectionneControl = (C2iTextBoxSelectionne)c;

            // Add the event.
            C2iTextBoxSelectionneControl.ElementSelectionneChanged +=
                new EventHandler(ElementSelectionneChanged);
        }

        //-------------------------------------------------------------------------
        protected override void OnUnsubscribeControlEvents(Control c)
        {
            // Call the base method so the basic events are unsubscribed.
            base.OnUnsubscribeControlEvents(c);

            // Cast the control to a C2iTextBoxSelectionne control.
            C2iTextBoxSelectionne C2iTextBoxSelectionneControl = (C2iTextBoxSelectionne)c;

            // Remove the event.
            C2iTextBoxSelectionneControl.ElementSelectionneChanged -=
                new EventHandler(ElementSelectionneChanged);
        }

        //----------------------------------------------------------------------------------------
        public event ActeurSelectionneChangedEventHandler OnElementSelectionneChanged;

        void ElementSelectionneChanged(object sender, EventArgs e)
        {
            if (OnElementSelectionneChanged != null)
                OnElementSelectionneChanged(this, new ActeurSelectionneChangedEventArgs(e, Acteur));
        }


    }

    public delegate void ActeurSelectionneChangedEventHandler(object sender, ActeurSelectionneChangedEventArgs e);

    public class ActeurSelectionneChangedEventArgs
    {
        public readonly EventArgs E;
        public readonly CActeur Acteur;

        public ActeurSelectionneChangedEventArgs(EventArgs e, CActeur acteur)
        {
            E = e;
            Acteur = acteur;
        }

    }

  }
