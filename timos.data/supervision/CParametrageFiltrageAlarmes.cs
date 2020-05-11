using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using sc2i.data;
using System.Data;
using System.Drawing;
using futurocom.supervision;
using sc2i.common.memorydb;
using timos.data.snmp;
using System.IO;
using futurocom.supervision.alarmes;


namespace timos.data.supervision
{
    /// <summary>
    /// Objet permettant de gérer le masquage d'<see cref="CAlarme">alarme</see>.<br/>
    /// Un masquage d'alarme permet de faire en sorte qu'une alarme ou un ensemble d'alarmes :
    /// <ul>
    /// <li>Ou bien ne soit pas enregistré en BDD (donc pas affiché non plus),</li>
    /// <li>Ou bien ne soit pas affiché,</li>
    /// </ul>
    /// et ce, en fonction de différents critères.
    /// </summary>
    /// <remarks>
    /// Il est possible de définir :
    /// <ul>
    /// <li>La catégorie de masquage (priorité associée)</li>
    /// <li>Les dates de début et de fin de validité globale</li>
    /// <li>Si le masque est à activer ou non</li>
    /// <li>Si les alarmes qui rentrent dans le masque sont enregistrées ou non</li>
    /// <li>Le filtre qui peut porter sur les types d'alarmes, les sites,<br/>
    /// les équipements logiques, les liens réseaux et les entités SNMP</li>
    /// <li>Des périodes de validité avec opérateurs logiques et/ou entre elles </li>
    /// </ul>
    /// </remarks>
    [DynamicClass("Alarm Filtering")]
    [Table(CParametrageFiltrageAlarmes.c_nomTable, CParametrageFiltrageAlarmes.c_champId, true)]
    [ObjetServeurURI("CParametrageFiltrageAlarmesServeur")]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModuleSupervision)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_ParametrageSupervision_ID)]
    public class CParametrageFiltrageAlarmes : 
        CObjetDonneeAIdNumeriqueAuto, 
        IElementADonneePourMediationSNMP,
        IParametrageFiltrageAlarmes
    {
        public const string c_nomTable = "ALARM_FILTER";
        public const string c_champId = "ALRMFILTER_ID";
        public const string c_champLibelle = "ALRMFILTER_LABEL";
        public const string c_champDataParametre = "ALRMFILTER_DATA";
        public const string c_champIsActif = "ALRMFILTER_ENABLED";
        public const string c_champIgnorerEnBase = "ALRMFILTER_IGNORE_DB";
        public const string c_champDateDebutValidite = "ALRMFILTER_STARTDATE";
        public const string c_champDateFinValidite = "ALRMFILTER_ENDDATE";
        public const string c_champInformation = "ALRM_INFORMATION";
        public const string c_champEstApplicableEnCeMoment = "ALRMF_ISFORNOW";


        public CParametrageFiltrageAlarmes(CContexteDonnee contexte)
            : base(contexte)
        {

        }

        public CParametrageFiltrageAlarmes(DataRow row)
            : base(row)
        {

        }

        //-----------------------------------------------------------
        public override string DescriptionElement
        {
            get
            {
                return I.T("Alarm Filtering @1|10024", Libelle);
            }
        }

        //-----------------------------------------------------------
        public override string[] GetChampsTriParDefaut()
        {
            return new string[] { c_champId };
        }

        //-----------------------------------------------------------
        protected override void MyInitValeurDefaut()
        {
            DateDebutValidite = DateTime.Now.Date;
            DateFinValidite = DateDebutValidite.AddDays(7);
            IsAppliquableEnCeMoment = false;
            Enabled = true;
        }


        //-----------------------------------------------------------
        /// <summary>
        /// Libellé du masquage
        /// </summary>
        [TableFieldProperty(c_champLibelle, 128)]
        [DynamicField("Label")]
        [DescriptionField]
        public string Libelle
        {
            get
            {
                return (string)Row[c_champLibelle];
            }
            set
            {
                Row[c_champLibelle] = value;
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// Information sur le masquage
        /// </summary>
        [TableFieldProperty(c_champInformation, 500)]
        [DynamicField("Information")]
        public string Information
        {
            get
            {
                return (string)Row[c_champInformation];
            }
            set
            {
                Row[c_champInformation] = value;
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// Indicateur comme quoi le masquage est activé (VRAI)<br/>
        /// ou non (FAUX)
        /// </summary>
        [TableFieldProperty(c_champIsActif)]
        [DynamicField("Enabled")]
        public bool Enabled
        {
            get
            {
                return (bool)Row[c_champIsActif];
            }
            set
            {
                Row[c_champIsActif] = value;
            }
        }


        //-----------------------------------------------------------
        /// <summary>
        /// Indique si le masquage se fait sur le service de médiation (si VRAI);<br/>
        /// dans ce cas, les alarmes filtrées ne sont pas enregistrées en BDD
        /// </summary>
        [TableFieldProperty(c_champIgnorerEnBase)]
        [DynamicField("Ignore in Database")]
        public bool IgnorerEnBase
        {
            get
            {
                return (bool)Row[c_champIgnorerEnBase];
            }
            set
            {
                Row[c_champIgnorerEnBase] = value;
            }
        }


        //-----------------------------------------------------------
        /// <summary>
        /// Date de début de validité du masquage
        /// </summary>
        [TableFieldProperty(c_champDateDebutValidite)]
        [DynamicField("Validity Start Date")]
        public DateTime DateDebutValidite
        {
            get
            {
                return (DateTime)Row[c_champDateDebutValidite];
            }
            set
            {
                Row[c_champDateDebutValidite] = value;
            }
        }


        //-----------------------------------------------------------
        /// <summary>
        /// Date de fin de validité du masquage
        /// </summary>
        [TableFieldProperty(c_champDateFinValidite)]
        [DynamicField("Validity End Date")]
        public DateTime DateFinValidite
        {
            get
            {
                return (DateTime)Row[c_champDateFinValidite];
            }
            set
            {
                Row[c_champDateFinValidite] = value;
            }
        }



        //---------------------------------------------------------------------------------
        /// <summary>
        /// Le Blob qui stock tout le paramétrage dont le Filtre d'Alarme
        /// </summary>
        [TableFieldProperty(c_champDataParametre, NullAutorise = true)]
        public CDonneeBinaireInRow DataParametre
        {
            get
            {
                if (Row[c_champDataParametre] == DBNull.Value)
                {
                    CDonneeBinaireInRow donnee = new CDonneeBinaireInRow(ContexteDonnee.IdSession, Row, c_champDataParametre);
                    CContexteDonnee.ChangeRowSansDetectionModification(Row, c_champDataParametre, donnee);
                }
                object obj = Row[c_champDataParametre];
                return ((CDonneeBinaireInRow)obj).GetSafeForRow(Row.Row);
            }
            set
            {
                Row[c_champDataParametre] = value;
            }
        }

        //--------------------------------------------------------------------
        /// <summary>
        /// Donne ou définit les paramètres de filtrage
        /// </summary>
        [DynamicField("Filter Setting")]
        [BlobDecoder]
        public CParametreFiltrageAlarmes Parametre
        {
            get
            {
                CDonneeBinaireInRow data = DataParametre;
                if (data != null && data.Donnees != null)
                {
                    MemoryStream stream = new MemoryStream(data.Donnees);
                    BinaryReader reader = new BinaryReader(stream);
                    CSerializerReadBinaire serializer = new CSerializerReadBinaire(reader);

                    CParametreFiltrageAlarmes param = null;
                    CResultAErreur result = serializer.TraiteObject<CParametreFiltrageAlarmes>(ref param, new object[] { });
                    reader.Close();
                    stream.Close();
                    if (result)
                        return param;
                }
                return null;
            }
            set
            {
                if (value == null)
                {
                    CDonneeBinaireInRow data = DataParametre;
                    data.Donnees = null;
                    DataParametre = data;
                }
                else
                {
                    MemoryStream stream = new MemoryStream();
                    BinaryWriter writer = new BinaryWriter(stream);
                    CSerializerSaveBinaire serializer = new CSerializerSaveBinaire(writer);
                    CResultAErreur result = serializer.TraiteObject<CParametreFiltrageAlarmes>(ref value, null);
                    if (result)
                    {
                        CDonneeBinaireInRow donnee = DataParametre;
                        donnee.Donnees = stream.ToArray();
                        DataParametre = donnee;
                    }
                    writer.Close();
                    stream.Close();
                }
            }
        }

        //-------------------------------------------------------------------
        /// <summary>
        /// Catégorie de masquage correspondante; dans le cas où différents<br/>
        /// masquages peuvent s'appliquer à une alarme, c'est celui dont<br/>
        /// la priorité de la catégorie est la plus élevée qui l'emporte.
        /// </summary>
        [Relation(
            CCategorieMasquageAlarme.c_nomTable,
            CCategorieMasquageAlarme.c_champId,
            CCategorieMasquageAlarme.c_champId,
            true,
            false,
            false)]
        [DynamicField("Masking Category")]
        public CCategorieMasquageAlarme CategorieMasquage
        {
            get
            {
                return (CCategorieMasquageAlarme)GetParent(CCategorieMasquageAlarme.c_champId, typeof(CCategorieMasquageAlarme));
            }
            set
            {
                SetParent(CCategorieMasquageAlarme.c_champId, value);
            }
        }

        //----------------------------------------------------------------------------------
        public CLocalParametrageFiltrageAlarmes GetLocalParametrageForSupervision(CMemoryDb database)
        {
            if (database == null)
                database = CMemoryDbPourSupervision.GetMemoryDb(ContexteDonnee);

            CLocalParametrageFiltrageAlarmes filtrage = new CLocalParametrageFiltrageAlarmes(database);
            if (!filtrage.ReadIfExist(Id.ToString(), false))
                filtrage.CreateNew(Id.ToString());
            else
                if (!filtrage.IsToRead())
                    return filtrage;
            filtrage.Row[CMemoryDb.c_champIsToRead] = false;
            filtrage.Libelle = Libelle;
            filtrage.Parametre = Parametre;
            filtrage.Enabled = Enabled;
            filtrage.IgnorerEnBase = IgnorerEnBase;
            filtrage.DateDebutValidite = DateDebutValidite;
            filtrage.DateFinValidite = DateFinValidite;
            if (CategorieMasquage != null)
                filtrage.CategorieMasquage = CategorieMasquage.GetLocalCategorieForSupervision(database);
            
            return filtrage;
        }

        //------------------------------------------------------
        /// <summary>
        /// Mise à jour de tous les agents
        /// </summary>
        public int[] IdsProxysConcernesParDonneesMediation
        {
            get { return null; }
        }

        //------------------------------------------
        public int[] IdsProxysConcernesParConfigurationProxy
        {
            get
            {
                return new int[0];
            }
        }

        //------------------------------------------------------
        /// <summary>
        /// Indique le dernier été traité
        /// par le gestionnaire de démasquage. Ce champ est interne
        /// et sert de mémoire au gestionnaire de démasquage pour
        /// savoir ce qu'il a appliqué la dernière fois qu'il a tourné
        /// </summary>
        [TableFieldProperty(c_champEstApplicableEnCeMoment)]
        public bool IsAppliquableEnCeMoment
        {
            get
            {
                return (bool)Row[c_champEstApplicableEnCeMoment];
            }
            set
            {
                Row[c_champEstApplicableEnCeMoment] = value;
            }
        }

    
        #region IParametrageFiltrageAlarmes Membres
        public int Priorite
        {
            get
            {
                CCategorieMasquageAlarme cat = CategorieMasquage;
                if (cat != null)
                    return cat.Priorite;
                return 0;
            }
        }

        //------------------------------------------------------
        public bool ShouldMask(IAlarme alarme, DateTime dateApplication)
        {
            if (dateApplication >= DateDebutValidite && dateApplication <= DateFinValidite &&
                Enabled)
            {
                return Parametre.ShouldMask(alarme, dateApplication);
            }
            return false;
        }

        #endregion

        //------------------------------------------------------
        public void RecalcIsApplicableEnCeMoment()
        {
            bool bVal = false;
            if (Enabled && DateTime.Now >= DateDebutValidite && DateTime.Now <= DateFinValidite )
            {
                bVal = Parametre.IsDateInPeriode(DateTime.Now);
            }
            IsAppliquableEnCeMoment = bVal;
        }
    }



}
