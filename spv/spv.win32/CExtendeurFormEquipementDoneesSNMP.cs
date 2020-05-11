using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using sc2i.win32.data.navigation;
using spv.data;
using timos.data;
using sc2i.common;
using sc2i.data;
using spv.data.SNMP;
using sc2i.win32.data;
using sc2i.win32.navigation;

namespace spv.win32
{
	public partial class CExtendeurFormEquipementDoneesSNMP : CExtendeurFormEditionStandardTabPage
	{
        private CSpvEquip m_spvEquip = null;

        private class CVarTableItem
        {
            public List<CSpvMibobj> m_lstMibObj;
            public string index;            
        }

        public CExtendeurFormEquipementDoneesSNMP()
		{
			InitializeComponent();
            Title = I.T("SNMP data|60066");
            m_listSnmpValues.OnGetDonneesObjet += new GetDonneesLigneEventHandler(GetDonneesObjetSnmpValues);
            m_lstTables.OnGetDonneesObjet += new GetDonneesLigneEventHandler(GetDonneesObjetSnmpTables);
            m_lstTableVariables.OnGetDonneesObjet += new GetDonneesLigneEventHandler(GetDonneesObjetSnmpTableVariables);
		}

		public override Type TypeObjetEtendu
		{
			get
			{
                return typeof(CEquipementLogique);
			}
		}

        protected CEquipementLogique Equipement
        {
            get
            {
                return ObjetEdite as CEquipementLogique;
            }
        }

        

        public override sc2i.common.CResultAErreur MyInitChamps()
        {            
            CResultAErreur result = base.MyInitChamps();
            if (!result)
                return result;
           
            if (ObjetEdite is CEquipementLogique)
            {
                m_spvEquip = CSpvEquip.GetSpvEquipFromEquipement(ObjetEdite as CEquipementLogique) as CSpvEquip;
            }
            else
                return result;

            InitListSNMPTables();
            result = InitListSnmpVariables();
            if (!result)
                return result;

            return result;
            
        }

        private sc2i.common.CResultAErreur InitListSNMPTables()
        {
            CResultAErreur result = CResultAErreur.True;

            if (m_spvEquip == null && ObjetEdite is CEquipementLogique)
            {
                m_spvEquip = CSpvEquip.GetSpvEquipFromEquipement(ObjetEdite as CEquipementLogique) as CSpvEquip;
            }
            if (m_spvEquip == null)
                return result;

            List<string> lstNomColonnes = new List<string>();
            List<CSpvMibobj> lstSpvMibobj = new List<CSpvMibobj>();
            lstNomColonnes.Add(I.T("Name|134"));
            
          /*  select #l#MIBOBJ_ID, #129S#MIBOBJ_NOM, #l#MIBOBJ_CLASSID, #i#0, #i#127, #l#0 \
			from EQUIP, TYPEQ_MIBMODULE, MIBOBJ	\
			where  EQUIP_ID = #l#:m_BddId and	\
				   EQUIP.TYPEQ_ID = TYPEQ_MIBMODULE.TYPEQ_ID and	\
				   TYPEQ_MIBMODULE.MIBMODULE_ID = MIBOBJ.MIBMODULE_ID and \
				   MIBOBJ_TYPE = 'TAB' and MIBOBJ_VISIBLE = 1 \
			order by MIBOBJ_NOM*/
            CListeObjetsDonnees objlstMibObj = new CListeObjetsDonnees(m_spvEquip.ContexteDonnee, typeof(CSpvMibobj));
            objlstMibObj.Filtre = new CFiltreDataAvance(CSpvMibobj.c_nomTable, "ModuleMib.SpvTypeq_Mibmodules."
                + CSpvTypeq_Mibmodule.c_champTYPEQ_ID + "= @1 and " +
                CSpvMibobj.c_champMIBOBJ_TYPE + " = 'TAB' and " +
                CSpvMibobj.c_champMIBOBJ_VISIBLE + " = 1 ", m_spvEquip.TypeEquipement.Id);
            objlstMibObj.Tri = CSpvMibobj.c_champMIBOBJ_NOM;

            foreach (CSpvMibobj mibobj in objlstMibObj)
                lstSpvMibobj.Add(mibobj);

            m_lstTables.Init(lstNomColonnes.ToArray(), lstSpvMibobj.ToArray());

            if (m_lstTables.Columns.Count > 0)
            {
                int width = (int)((m_lstTables.Width-4) / m_lstTables.Columns.Count);

                foreach (ColumnHeader header in m_lstTables.Columns)
                    header.Width = width;
            }
                        
            return result;
        }

        private sc2i.common.CResultAErreur InitListSnmpVariables()
        {
            CResultAErreur result = CResultAErreur.True;

            if (m_spvEquip == null && ObjetEdite is CEquipementLogique)
            {
                m_spvEquip = CSpvEquip.GetSpvEquipFromEquipement(ObjetEdite as CEquipementLogique) as CSpvEquip;
            }
            if (m_spvEquip == null)
                return result;

            List<string> lstNomColonnes = new List<string>();
            List<CSpvMibobj> lstSpvMibobj;
            lstNomColonnes.Add("OID");
            lstNomColonnes.Add(I.T("Name|134"));
            lstNomColonnes.Add(I.T("Value|60029"));

            // "select #l#MIBMODULE_ID from EQUIP, TYPEQ_MIBMODULE \
            //						where EQUIP_ID = #l#:Id and	\
            //							  EQUIP.TYPEQ_ID = TYPEQ_MIBMODULE.TYPEQ_ID"

            //  "select #129S#MIBOBJ_NOM, #257S#MIBOBJ_OID from  MIBOBJ \
            //						where MIBMODULE_ID = #l#:Id and \
            //							  MIBOBJ_TYPE = 'VS' and	\
            //							  MIBOBJ_VISIBLE = 1"

            CListeObjetsDonnees lstMibObj = new CListeObjetsDonnees(m_spvEquip.ContexteDonnee, typeof(CSpvMibobj));
            lstMibObj.Filtre = new CFiltreDataAvance(CSpvMibobj.c_nomTable, "ModuleMib.SpvTypeq_Mibmodules."
                + CSpvTypeq_Mibmodule.c_champTYPEQ_ID + "= @1 and " + 
                CSpvMibobj.c_champMIBOBJ_TYPE + " = 'VS' and " +
                CSpvMibobj.c_champMIBOBJ_VISIBLE + " = 1 ", m_spvEquip.TypeEquipement.Id);

            lstSpvMibobj = FillListMibobjToDisplay(lstMibObj);

            m_listSnmpValues.Init(lstNomColonnes.ToArray(), lstSpvMibobj.ToArray());

            if (m_listSnmpValues.Columns.Count > 0)
            {
                int width = (int)((m_listSnmpValues.Width-4) / m_listSnmpValues.Columns.Count);

                foreach (ColumnHeader header in m_listSnmpValues.Columns)
                    header.Width = width;
            }
            
            return result;
        }

       
        void GetDonneesObjetSnmpValues(object obj, ref object[] datas)
        {
            CSpvMibobj mibobj = obj as CSpvMibobj;
            if (mibobj == null)
                return;
            ArrayList lst = new ArrayList();
            string stValue="";

            if (m_spvEquip.AdresseIP.Length > 0 && m_spvEquip.CommunauteSnmp.Length > 0)
            {
                CRequeteSnmpOID requeteSnmp = new CRequeteSnmpOID(
                        m_spvEquip.AdresseIP, m_spvEquip.CommunauteSnmp, mibobj.GetOID());
                using (CContexteDonnee ctx = new CContexteDonnee(CSc2iWin32DataClient.ContexteCourant.IdSession, true, false))
                {
                    CResultAErreur resultSnmp = requeteSnmp.GetValueSNMP(ctx);
                    if (resultSnmp != null && resultSnmp.Data != null)
                        stValue = resultSnmp.Data.ToString();
                    else
                    {
                        if (!resultSnmp)
                            MessageBox.Show(resultSnmp.MessageErreur.ToString(), "Timos", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                        lst.Add(I.T("Not found|60074"));
                    }
                }
            }

            lst.Add(mibobj.OidObjet);
            lst.Add(mibobj.NomObjetUtilisateur);
            lst.Add(stValue);
            datas = lst.ToArray();
        }

        void GetDonneesObjetSnmpTables(object obj, ref object[] datas)
        {
            CSpvMibobj mibobj = obj as CSpvMibobj;
            if (mibobj == null)
                return;
            ArrayList lst = new ArrayList();
            lst.Add(mibobj.NomObjetUtilisateur);
            datas = lst.ToArray();
        }

        void GetDonneesObjetSnmpTableVariables(object obj, ref object[] datas)
        {
            CVarTableItem varTableItem = obj as CVarTableItem;
            if (varTableItem == null)
                return;

            ArrayList lst = new ArrayList();
            lst.Add(varTableItem.index);
            foreach (CSpvMibobj mibobj in varTableItem.m_lstMibObj)
            {
                string stOid = mibobj.OidObjet.TrimEnd('.');
                string stIndex = varTableItem.index.TrimStart('.');

                CRequeteSnmpOID requeteSnmp = new CRequeteSnmpOID(
                        m_spvEquip.AdresseIP, m_spvEquip.CommunauteSnmp, stOid + "." + stIndex);
                using (CContexteDonnee ctx = new CContexteDonnee(CSc2iWin32DataClient.ContexteCourant.IdSession, true, false))
                {
                    CResultAErreur resultSnmp = requeteSnmp.GetValueSNMP(ctx);
                    if (resultSnmp != null && resultSnmp.Data != null)
                    {
                        string stValue = resultSnmp.Data.ToString();
                        lst.Add(stValue);
                    }
                    else
                    {
                        lst.Add(I.T("Not found|60074"));
                    }

                }
            }

            datas = lst.ToArray();

            return;
        }

        
        private void MajListTableVariables(CSpvMibobj mibobjTable)
        {
            List<string> lstNomColonnes = new List<string>();
            List<CSpvMibobj> lstSpvMibobj;
            List<CVarTableItem> lstItems = new List<CVarTableItem>();
            List<string> lstIndex = new List<string>();
            List<CVariableSNMPResultat> lstResult;
            string stIndexOID;

         //   select #129S#MIBOBJ_NOM, #257S#MIBOBJ_OID from  MIBOBJ \
            //						where MIBOBJ_FATHERNAME = #129S#:Name and \ 
		//							  MIBOBJ_TYPE = 'VT' and	\
		//							  MIBOBJ_VISIBLE = 1

            CListeObjetsDonnees lstMibObj = new CListeObjetsDonnees(m_spvEquip.ContexteDonnee, typeof(CSpvMibobj));
            lstMibObj.Filtre = new CFiltreData(CSpvMibobj.c_champMIBOBJ_TYPE + " = 'VT' and " +
                CSpvMibobj.c_champMIBOBJ_VISIBLE + " = 1 and " + CSpvMibobj.c_champMIBOBJ_FATHERNAME +
                "= @1", mibobjTable.NomObjetOfficiel);

            lstSpvMibobj = FillListMibobjToDisplay(lstMibObj);

            //fill lstIndex
            if(lstMibObj.Count>0 && m_spvEquip.AdresseIP != null && m_spvEquip.AdresseIP.Length > 0 &&
                m_spvEquip.CommunauteSnmp != null && m_spvEquip.CommunauteSnmp.Length >= 0)
            {
                CRequeteSNMPDansTable requeteDansTable = new CRequeteSNMPDansTable(m_spvEquip.AdresseIP,
                    m_spvEquip.CommunauteSnmp, mibobjTable.ModuleMib.Id, mibobjTable.NomObjetOfficiel,
                    ((CSpvMibobj)(lstMibObj[0])).NomObjetOfficiel, -1);

                using (CContexteDonnee ctx = new CContexteDonnee(CSc2iWin32DataClient.ContexteCourant.IdSession, true, false))
                {
                    CResultAErreur resultSNMP = requeteDansTable.GetTableSNMP(ctx);
                    if (resultSNMP != null && resultSNMP.Data != null)
                    {
                        lstResult = resultSNMP.Data as List<CVariableSNMPResultat>;

                        foreach (CVariableSNMPResultat varRes in lstResult)
                        {
                            lstIndex.Add(varRes.Index);                        
                        }
                    }
                }
            }

            foreach (string index in lstIndex)
            {
                CVarTableItem varTableItem = new CVarTableItem();
                varTableItem.index = index;
                varTableItem.m_lstMibObj = lstSpvMibobj;
                lstItems.Add(varTableItem);
            }


            lstNomColonnes.Add("Index");
            foreach (CSpvMibobj mibobj in lstMibObj)
            {
                lstNomColonnes.Add(mibobj.NomObjetUtilisateur);
            }

            m_lstTableVariables.Init(lstNomColonnes.ToArray(), lstItems.ToArray());
        }


        private List<CSpvMibobj> FillListMibobjToDisplay(CListeObjetsDonnees lstMibObj)
        {
            List<CSpvMibobj> lstSpvMibobj = new List<CSpvMibobj>();

            int cnt = lstMibObj.Count;

            if (cnt > 0 && (m_spvEquip.AdresseIP == null || m_spvEquip.AdresseIP.Length == 0))
            {
                // result.EmpileErreur(I.T("Unknown equipment IP address|60067")) ;
                MessageBox.Show(I.T("Unknown equipment IP address|60067"), "Timos", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
            }
            else if (cnt > 0 && (m_spvEquip.CommunauteSnmp == null || m_spvEquip.CommunauteSnmp.Length == 0))
            {
                // result.EmpileErreur(I.T("Unknown equipment SNMP community|60068"));
                MessageBox.Show(I.T("Unknown equipment SNMP community|60068"), "Timos", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
            }
            else
            {
                foreach (CSpvMibobj mibobj in lstMibObj)
                {
                    lstSpvMibobj.Add(mibobj);
                }
            }

            return lstSpvMibobj;
        }

        private void m_lstTables_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (m_lstTables.SelectedIndices.Count > 0)
            {
                int index = m_lstTables.SelectedIndices[0];
                CSpvMibobj mibobj = (CSpvMibobj)m_lstTables.GetObjectFromList(index);

                IFormNavigable frm =((CReferenceTypeForm)(typeof(CFormEditionObjetMib))).GetForm(mibobj) as IFormNavigable;
                this.FormEdition.Navigateur.AffichePage(frm);
                
            }
        }

        private void m_btnTableValues_Click(object sender, EventArgs e)
        {
            if (m_lstTables.SelectedIndices.Count > 0)
            {
                int index = m_lstTables.SelectedIndices[0];
                CSpvMibobj mibobj = (CSpvMibobj)m_lstTables.GetObjectFromList(index);
                MajListTableVariables(mibobj);
            }
            else
            {
                MessageBox.Show(I.T("No selected table|60073"), "Timos", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
            }

        }

        private void m_listSnmpValues_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (m_listSnmpValues.SelectedIndices.Count > 0)
            {
                int index = m_listSnmpValues.SelectedIndices[0];
                CSpvMibobj mibobj = (CSpvMibobj)m_listSnmpValues.GetObjectFromList(index);

                IFormNavigable frm = ((CReferenceTypeForm)(typeof(CFormEditionObjetMib))).GetForm(mibobj) as IFormNavigable;
                this.FormEdition.Navigateur.AffichePage(frm);

            }
        }
	}
}
