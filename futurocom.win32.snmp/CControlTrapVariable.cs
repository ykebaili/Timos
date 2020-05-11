using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using futurocom.snmp;
using futurocom.snmp.Mib;
using sc2i.common;

namespace futurocom.win32.snmp
{
    public partial class CControlTrapVariable : UserControl
    {
        private IDefinition m_definition = null;
        private SnmpType m_typeAttendu = SnmpType.OctetString;

        //-----------------------------------------------------
        public CControlTrapVariable()
        {
            InitializeComponent();
        }

        //-----------------------------------------------------
        public void Init(IDefinition definition)
        {
            m_definition = definition;
            m_lblNomVariable.Text = m_definition.Name;
            ObjectType tp = m_definition.Entity as ObjectType;
            if (tp != null && tp.Syntax != null)
            {
                m_typeAttendu = tp.Syntax.SnmpType;
                m_lblTypeVariable.Text = m_typeAttendu.ToString();
            }
            if (tp != null && tp.DefaultValue != null)
                m_txtValeur.Text = tp.DefaultValue.ToString();
        }

        //-----------------------------------------------------
        public IDefinition Definition
        {
            get
            {
                return m_definition;
            }
        }

        //-----------------------------------------------------
        public CResultAErreurType<ISnmpData> GetValue()
        {
            CResultAErreurType<ISnmpData> result = new CResultAErreurType<ISnmpData>();
            if (m_txtValeur.Text.Trim().Length > 0)
            {
                try
                {
                    ISnmpData data = DataFactory.CreateSnmpDataFromStringUnsafe(m_typeAttendu, m_txtValeur.Text);
                    result.DataType = data;
                }
                catch (Exception e)
                {
                    result.EmpileErreur(new CErreurException(e));
                    result.EmpileErreur(I.T("Invalid value for @1|20114", m_lblNomVariable.Text));
                }
            }
            return result;
        }
    }
}
