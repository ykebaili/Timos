using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using futurocom.supervision.alarmes;
using timos.data.supervision;
using sc2i.data;
using sc2i.win32.common;
using sc2i.common;

namespace timos.supervision.Masquage
{
    public partial class CFormMasquageAlarmeManuel : Form
    {
        CParametrageFiltrageAlarmes m_parametre = null;
        CAlarme m_alarme;

        public CFormMasquageAlarmeManuel()
        {
            InitializeComponent();
        }

        private void m_btnOK_Click(object sender, EventArgs e)
        {
            if (m_alarme != null)
            {
                if (m_txtLibelle.Text.Trim() == string.Empty)
                {
                    CFormAlerte.Afficher(I.T("Please enter a Label for the Masking Setting|10321"));
                    return;
                }
                if (m_cmbSelecCategorieMasquage.ElementSelectionne == null)
                {
                    CFormAlerte.Afficher(I.T("Please select a Masking Category|10322"));
                    return;
                }
                m_parametre = new CParametrageFiltrageAlarmes(m_alarme.ContexteDonnee);
                m_parametre.CreateNewInCurrentContexte();
                m_parametre.Libelle = m_txtLibelle.Text;
                m_parametre.CategorieMasquage = (CCategorieMasquageAlarme)m_cmbSelecCategorieMasquage.ElementSelectionne;
                m_parametre.DateDebutValidite = m_dtPickerDateDebutValidite.Value;
                m_parametre.DateFinValidite = m_dtPickerDateFinValidite.Value;
                m_parametre.Enabled = true;
                
                CParametreFiltrageAlarmes parametreFiltrage = new CParametreFiltrageAlarmes();
                foreach (Control ctrl in m_panelOptions.Controls)
                {
                    try
                    {
                        CheckBox chkbx = ctrl as CheckBox;
                        if (chkbx != null && chkbx.Checked)
                        {
                            ETypeElementPourFiltreAlarme typeElement = (ETypeElementPourFiltreAlarme)chkbx.Tag;
                            switch (typeElement)
                            {
                                case ETypeElementPourFiltreAlarme.AlarmType:
                                    parametreFiltrage.Filtre.ListeIdsTypesAlarmes = new HashSet<CDbKey> { m_alarme.TypeAlarme.DbKey };
                                    break;
                                case ETypeElementPourFiltreAlarme.Site:
                                    parametreFiltrage.Filtre.ListeIdsSites = new HashSet<CDbKey> { m_alarme.Site.DbKey };
                                    break;
                                case ETypeElementPourFiltreAlarme.LogicalEquipment:
                                    parametreFiltrage.Filtre.ListeIdsEquipementsLogiques = new HashSet<CDbKey> { m_alarme.EquipementLogique.DbKey };
                                    break;
                                case ETypeElementPourFiltreAlarme.NetworkLink:
                                    parametreFiltrage.Filtre.ListeIdsLiensReseau = new HashSet<CDbKey> { m_alarme.LienReseau.DbKey };
                                    break;
                                case ETypeElementPourFiltreAlarme.SnmpEntity:
                                    parametreFiltrage.Filtre.ListeIdsEntiesSnmp = new HashSet<CDbKey> { m_alarme.EntiteSnmp.DbKey };
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        CFormAlerte.Afficher(ex.Message, EFormAlerteType.Erreur);
                        return;
                    }
                }
                m_parametre.Parametre = parametreFiltrage;

                DialogResult = DialogResult.OK;
                Close();
                Dispose();
            }
        }

        private void m_btnAnnuler_Click(object sender, EventArgs e)
        {
            m_parametre = null;
            DialogResult = DialogResult.Cancel;
        }

        public static CParametrageFiltrageAlarmes EditParametre(CAlarme alarme)
        {
            CFormMasquageAlarmeManuel form = new CFormMasquageAlarmeManuel();

            form.m_alarme = alarme;

            if (form.ShowDialog() == DialogResult.OK)
            {
                return form.m_parametre;
            }

            return null;
        }

        private void CFormMasquageAlarmeManuel_Load(object sender, EventArgs e)
        {
            CWin32Traducteur.Translate(this);

            m_cmbSelecCategorieMasquage.Init(typeof(CCategorieMasquageAlarme), "Libelle", true);
            m_dtPickerDateDebutValidite.Value = DateTime.Now.Date;
            m_dtPickerDateFinValidite.Value = DateTime.Now.Date.AddDays(7);

            // Gestion des options de filtre
            if (m_alarme.TypeAlarme != null)
                AddChekBoxOption(ETypeElementPourFiltreAlarme.AlarmType,
                    I.T("Alarm Type is : @1|10323", m_alarme.TypeAlarme.Libelle), true);
            if (m_alarme.Site != null)
                AddChekBoxOption(ETypeElementPourFiltreAlarme.Site,
                    I.T("Related Site is : @1|10324", m_alarme.Site.Libelle), false);
            if (m_alarme.EquipementLogique != null)
                AddChekBoxOption(ETypeElementPourFiltreAlarme.LogicalEquipment,
                    I.T("Related Logical Equipment is : @1|10325", m_alarme.EquipementLogique.Libelle), false);
            if (m_alarme.LienReseau != null)
                AddChekBoxOption(ETypeElementPourFiltreAlarme.NetworkLink,
                    I.T("Related Network Link is : @1|10326", m_alarme.LienReseau.Libelle), false);
            if (m_alarme.EntiteSnmp != null)
                AddChekBoxOption(ETypeElementPourFiltreAlarme.SnmpEntity,
                    I.T("Related SNMP Entity is : @1|10327", m_alarme.EntiteSnmp.Libelle), false);
 
        }


        private void AddChekBoxOption(ETypeElementPourFiltreAlarme typeElement, string texte, bool bCheckedDefault)
        {
            CheckBox chkCritereFiltre = new CheckBox();
            chkCritereFiltre.Text = texte;
            chkCritereFiltre.TextAlign = ContentAlignment.MiddleLeft;
            chkCritereFiltre.Height = 22;
            chkCritereFiltre.Tag = typeElement;
            chkCritereFiltre.Checked = bCheckedDefault;
            chkCritereFiltre.Dock = DockStyle.Top;
            chkCritereFiltre.BringToFront();

            m_panelOptions.Controls.Add(chkCritereFiltre);
        }

        public static CParametrageFiltrageAlarmes CreateMasquage(CAlarme Alarme, bool bEditerEtSauvegarder)
        {
            CParametrageFiltrageAlarmes masque = null;
            CAlarme alrm = Alarme;
            CResultAErreur result = CResultAErreur.True;
            if (bEditerEtSauvegarder)
                alrm.BeginEdit();
            try
            {
                masque = CFormMasquageAlarmeManuel.EditParametre(alrm);
                if (masque != null)
                {
                    alrm.MasquagePropre = masque;

                }
                else
                    return masque;
            }
            catch (Exception e)
            {
                result.EmpileErreur(new CErreurException(e));
            }
            finally
            {
                if (bEditerEtSauvegarder && result)
                {
                    result = alrm.CommitEdit();
                }
                if (!result)
                    alrm.CancelEdit();
            }
            if (!result)
            {
                CFormAlerte.Afficher(result.Erreur);
            }
            return masque;
        }
    }
}
