using System;
using System.Collections;

using System.Collections.Generic;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;

using tiag.client;

using timos.data;
using System.IO;
using System.Text;
using futurocom.snmp.Mib;
using timos.data.snmp;
using sc2i.data.dynamic;
using futurocom.supervision;
using sc2i.expression;
using sc2i.common.memorydb;
using System.Drawing;
using sc2i.drawing;
using System.Drawing.Imaging;

namespace timos.data.supervision
{
    

	/// <summary>
    /// Type d'alarme. Permet de définir le comportement pour les <see cref="CAlarme">alarmes</see> de ce type.<br/>
    /// Les types d'alarmes sont des éléments hiérarchiques qui peuvent donc avoir<br/>
    /// des types d'alarmes fils.
    /// <br/>
    /// <br/>
    /// Le type d'alarme permet essentiellement, pour les alarmes de ce type :
    /// <ul>
    /// <li>de définir la <see cref="CSeveriteAlarme">sévérité</see> (donc la couleur)</li>
    /// <li>de définir une icône associée pour affichage dans les listes</li>
    /// <li>de définir le comportement initial, ainsi que le comportement à la fermeture en fonction des alarmes filles</li>
    /// <li>de gérer les formulaires personnalisés</li>
    /// <li>de préciser les champs personnalisés à renseigner par la médiation</li>
    /// <li>de définir la catégorie d'objet associée (<see cref="CEntiteSnmp">entité SNMP</see>, <see cref="CSite">site</see>, <see cref="CEquipementLogique">équipement logique</see>, <see cref="CLienReseau">lien réseau</see>)</li>
    /// </ul>
	/// </summary>
    [DynamicClass("Alarm type")]
    [Table(CTypeAlarme.c_nomTable, CTypeAlarme.c_champId, true)]
	[ObjetServeurURI("CTypeAlarmeServeur")]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModuleSupervision)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_ParametrageSupervision_ID)]
    [TiagClass("Alarm type","Id", true)]
    [AutoExec("Autoexec")]
    public class CTypeAlarme : CObjetHierarchique,
        IDefinisseurChampCustomRelationObjetDonnee,
		IObjetALectureTableComplete,
        IElementADonneePourMediationSNMP,
        IObjetDonneeAChamps
	{
        public const string c_roleChampCustom = "ALARM_TYPE";

		public const string c_nomTable = "ALARM_TYPE";
		public const string c_champId = "ALRMTP_ID";
        public const string c_champLibelle = "ALRMTP_LABEL";
        public const string c_champDescription = "ALRMTP_DESC";
        public const string c_champModeClotureSelonFils = "ALRMTP_CLOSE_MODE";
        public const string c_champFormuleLibelle = "ALRMTP_LABEL_FORMULA";
        public const string c_champFormulActionsSurParent = "ALRMTP_ACTION_SUR_PARENT";
        public const string c_champEtatInitial = "ALRMTP_INIT_STATE";
        public const string c_champLastModif = "ALRMTP_LAST_UPDATED";

        public const string c_champTypeElementSuperviseAssocie = "ALRMTP_SUPERVISED_TYPE";

        public const string c_champIdTypeParent = "ALRMTP_PARENT_ID";
        public const string c_champCodeSystemePartiel = "ALRMTP_SYST_CODE";
        public const string c_champCodeSystemeComplet = "ALRMTP_FULL_SYST_CODE";
        public const string c_champNiveau = "ALRMTP_LEVEL";
        public const string c_champRegrouperSurLaCle = "ALRMTP_GROUP_ON_KEY";
        public const string c_champAAcquitter = "ALRMTP_TO_ACK";
        public const string c_champImage = "ALRMTP_IMAGE";

        public const string c_champCacheFormuleLibelle = "CACH_FRM_LABEL";
        public const string c_champCacheFormuleActionsSurParent = "CACH_FRM_PARENT";
        public const string c_champCacheImage = "CACHE_IMAGE";

		/// /////////////////////////////////////////////
		public CTypeAlarme( CContexteDonnee contexte)
			:base(contexte)
		{
		}
		
	/// /////////////////////////////////////////////
		public CTypeAlarme(DataRow row )
			:base(row)
		{
		}

        /// /////////////////////////////////////////////
        public static void Autoexec()
        {
            CRoleChampCustom.RegisterRole(c_roleChampCustom,
                I.T("Alarm type|20246"),
                typeof(CTypeAlarme),
                typeof(CDefinisseurChampsPourTypeSansDefinisseur));
        }


		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T("Alarm type : @1|20090",Libelle);
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
            base.MyInitValeurDefaut();
            ModeCalculEtatParentInt = (int)EModeCalculEtatParent.AllChildsClosed;
            RegrouperSurLaCle = true;
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champLibelle};
		}

        /// <summary>
        /// Utiliser pour connaitre les services de médiation à 
        /// mettre à jour
        /// </summary>
        [TableFieldProperty(c_champLastModif, NullAutorise = true)]
        public CDateTimeEx LastUpdated
        {
            get
            {
                if (Row[c_champLastModif] == DBNull.Value)
                    return null;
                return new CDateTimeEx ((DateTime)Row[c_champLastModif]);
            }
            set
            {
                if (value == null)
                    Row[c_champLastModif] = DBNull.Value;
                else
                    Row[c_champLastModif] = value.DateTimeValue;
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// Code donnant la nature de l'élément supervisé associé :
        /// <ul>
        /// <li>0 : Aucun</li>
        /// <li>1 : Site</li>
        /// <li>3 : Equipement logique</li>
        /// <li>4 : Lien réseau</li>
        /// <li>9 : Entité SNMP</li>
        /// </ul>
        /// </summary>
        [TableFieldProperty(c_champTypeElementSuperviseAssocie)]
        [DynamicField("Supervised type code")]
        [TiagField("Supervised type code")]
        public int TypeElementSuperviseAssocieCode
        {
            get
            {
                return (int)Row[c_champTypeElementSuperviseAssocie];
            }
            set
            {
                Row[c_champTypeElementSuperviseAssocie] = value;
            }
        }

        //-----------------------------------------------------------
        public CTypeElementSupervise TypeElementSupervise
        {
            get
            {
                return new CTypeElementSupervise((ETypeElementSupervise)TypeElementSuperviseAssocieCode);
            }
            set
            {
                if (value != null)
                    TypeElementSuperviseAssocieCode = value.CodeInt;
                else
                    TypeElementSuperviseAssocieCode = (int)ETypeElementSupervise.Aucun;
            }
        }


        /// /////////////////////////////////////////////
        /// <summary>
		/// Libellé du type d'alarme
		/// </summary>
		[TableFieldProperty(c_champLibelle, 255)]
		[DynamicField("Label")]
        [TiagField("Label")]
		public override string Libelle
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
        /// Description du type d'alarme
        /// </summary>
        [TableFieldProperty(c_champDescription, 1024)]
        [DynamicField("Description")]
        [TiagField("Description")]
        public string Description
        {
            get
            {
                return (string)Row[c_champDescription];
            }
            set
            {
                Row[c_champDescription] = value;
            }
        }

        //------------------------------------------------------------
        /// <summary>
        /// Indicateur de groupement sur la clé (si VRAI).<br/>
        /// Grouper sur la clé signifie que si une alarme est déjà présente<br/>
        /// et qu'elle survient de nouveau, on ne la fera pas monter de nouveau;<br/>
        /// dans le cas contraire, on la fait monter chaque fois qu'elle survient.
        /// </summary>
        [TableFieldProperty(c_champRegrouperSurLaCle)]
        [DynamicField("Group on key")]
        [TiagField("Group on key")]
        public bool RegrouperSurLaCle
        {
            get
            {
                if (TypesFils.Count != 0)
                    return true;
                return (bool)Row[c_champRegrouperSurLaCle];
            }
            set
            {
                if (TypesFils.Count != 0)
                    Row[c_champRegrouperSurLaCle] = true;
                else
                    Row[c_champRegrouperSurLaCle] = value;
            }
        }


        //---------------------------------------------
        /// <summary>
        /// Mode de fonctionnement à la fermeture :
        /// <ul>
        /// <li>0 : fermeture si toutes les filles sont fermées</li>
        /// <li>1 : fermeture si une fille quelconque est fermée</li>
        /// <li>2 : manuelle</li>
        /// </ul>
        /// Pour une alarme feuille (sans fille), c'est toujours 'manuelle'.
        /// </summary>
        [DynamicField("Closure calculate mode int")]
        [TableFieldProperty(c_champModeClotureSelonFils)]
        [TiagField("Closure calculate mode int")]
        public int ModeCalculEtatParentInt
        {
            get
            {
                return (int)Row[c_champModeClotureSelonFils];
            }
            set
            {
                Row[c_champModeClotureSelonFils] = value;
            }
        }

        //---------------------------------------------
        /// <summary>
        /// Mode de fonctionnement à la fermeture (cf. 'Closure calculate mode int')
        /// </summary>
        [DynamicField("Closure calculate mode")]
        public CModeCalculEtatParent ModeCalculEtatParent
        {
            get
            {
                return new CModeCalculEtatParent((EModeCalculEtatParent)ModeCalculEtatParentInt);
            }
            set
            {
                if (value != null)
                    ModeCalculEtatParentInt = (int)value.Code;
            }
        }

        //---------------------------------------------
        /// <summary>
        /// Etat initial lorsque survient une alarme de ce type :
        /// <ul>
        /// <li> 0 : inconnu; c'est le cas pour les alarmes parentes, l'état est calculé par TIMOS</li>
        /// <li>20 : ouvert lorsque survient l'alarme</li>
        /// <li>40 : fermé lorsque survient l'alarme</li>
        /// </ul>
        /// </summary>
        [DynamicField("Initial state int")]
        [TableFieldProperty(c_champEtatInitial)]
        [TiagField("Initial state int")]
        public int EtatInitialInt
        {
            get
            {
                return (int)Row[c_champEtatInitial];
            }
            set
            {
                Row[c_champEtatInitial] = value;
            }
        }

        //---------------------------------------------
        /// <summary>
        /// Etat initial lorsque survient une alarme de ce type.
        /// </summary>
        [DynamicField("Initial state")]
        public CEtatAlarme EtatInitial
        {
            get
            {
                return new CEtatAlarme((EEtatAlarme)EtatInitialInt);
            }
            set
            {
                if (value != null)
                    EtatInitialInt = (int)value.Code;
            }
        }



        //-----------------------------------------------------------
        /// <summary>
        /// Indicateur d'alarme à acquitter (si VRAI)
        /// </summary>
        [TableFieldProperty(c_champAAcquitter)]
        [DynamicField("To Acknowledge")]
        [TiagField("To acknowledge")]
        public bool AAcquitter
        {
            get
            {
                return (bool)Row[c_champAAcquitter];
            }
            set
            {
                Row[c_champAAcquitter] = value;
            }
        }

        // /////////////////////////////////////////////////////////
        [TableFieldProperty(CTypeAlarme.c_champImage, NullAutorise = true)]
        public CDonneeBinaireInRow DataImage
        {
            get
            {
                if (Row[c_champImage] == DBNull.Value)
                {
                    CDonneeBinaireInRow donnee = new CDonneeBinaireInRow(ContexteDonnee.IdSession, Row, c_champImage);
                    CContexteDonnee.ChangeRowSansDetectionModification(Row, c_champImage, donnee);
                }
                object obj = Row[c_champImage];
                return ((CDonneeBinaireInRow)obj).GetSafeForRow(Row.Row);
            }
            set
            {
                Row[c_champImage] = value;
            }
        }


        // /////////////////////////////////////////////////////////
        [TableFieldProperty(CTypeAlarme.c_champCacheImage, IsInDb = false, NullAutorise = true)]
        [BlobDecoder]
        public Image Image
        {
            get
            {
                if (Row[c_champCacheImage] != DBNull.Value)
                    return (Image)Row[c_champCacheImage];
                CDonneeBinaireInRow data = DataImage;
                if (data != null && data.Donnees != null)
                {
                    MemoryStream stream = new MemoryStream(data.Donnees);
                    {
                        try
                        {
                            Image img = Image.FromStream(stream);
                            CContexteDonnee.ChangeRowSansDetectionModification(Row.Row, c_champCacheImage, img);
                            return img;
                        }
                        catch { }
                    }
                }
                return null;
            }
            set
            {
                Row[c_champCacheImage] = DBNull.Value;
                if (value == null)
                {
                    CDonneeBinaireInRow data = DataImage;
                    data.Donnees = null;
                    DataImage = data;

                }
                else
                {
                    Image img = CUtilImage.CreateImageImageResizeAvecRatio(value, new Size(16, 16), Color.White);
                    MemoryStream stream = new MemoryStream();
                    img.Save(stream, ImageFormat.Png);
                    CDonneeBinaireInRow donnee = DataImage;
                    donnee.Donnees = stream.ToArray();
                    DataImage = donnee;
                }
            }
        }

        /// <summary>
        /// Mutualise l'affectation des formules
        /// </summary>
        /// <param name="strChampCache"></param>
        /// <param name="data"></param>
        /// <param name="formule"></param>
        private void SetFormule(string strChampCache, ref CDonneeBinaireInRow data, C2iExpression formule)
        {
            CContexteDonnee.ChangeRowSansDetectionModification(Row.Row, strChampCache, DBNull.Value);
            if (formule == null)
            {
                data.Donnees = null;
            }
            else
            {
                MemoryStream stream = new MemoryStream();
                try
                {
                    BinaryWriter writer = new BinaryWriter(stream);
                    CSerializerSaveBinaire ser = new CSerializerSaveBinaire(writer);
                    CResultAErreur result = ser.TraiteObject<C2iExpression>(ref formule);
                    data.Donnees = stream.GetBuffer();
                    writer.Close();
                }
                catch
                {
                    data.Donnees = null;
                }
                stream.Close();
            }
        }

        /// <summary>
        /// mutualise la récupération des formules
        /// </summary>
        /// <param name="strChampCache"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        private C2iExpression GetFormule(string strChampCache, CDonneeBinaireInRow data)
        {
            C2iExpression formule = null;
            if (Row[strChampCache] != DBNull.Value)
                return (C2iExpression)Row[strChampCache];
            if (data != null && data.Donnees != null)
            {
                Stream stream = new MemoryStream(data.Donnees);
                try
                {
                    BinaryReader reader = new BinaryReader(stream);
                    CSerializerReadBinaire ser = new CSerializerReadBinaire(reader);
                    CResultAErreur result = ser.TraiteObject<C2iExpression>(ref formule);
                    if (!result)
                        formule = null;
                    else
                        CContexteDonnee.ChangeRowSansDetectionModification(Row.Row, strChampCache, formule);
                    reader.Close();
                    stream.Close();
                }
                catch
                {
                }
            }
            return formule;
        }

        /// /////////////////////////////////////////////////////////
        [TableFieldProperty(c_champCacheFormuleLibelle, IsInDb=false, NullAutorise=true)]
        [BlobDecoder]
        public C2iExpression FormuleCalculLibelle
        {
            get
            {
                return GetFormule(c_champCacheFormuleLibelle, DataFormuleLibelle);
            }
            set
            {
                CDonneeBinaireInRow data = DataFormuleLibelle;
                SetFormule(c_champCacheFormuleLibelle, ref data, value);
                DataFormuleLibelle = data;

                
            }
        }
        
        /// /////////////////////////////////////////////////////////
        [TableFieldProperty(c_champFormuleLibelle, NullAutorise = true)]
        public CDonneeBinaireInRow DataFormuleLibelle
        {
            get
            {
                if (Row[c_champFormuleLibelle] == DBNull.Value)
                {
                    CDonneeBinaireInRow donnee = new CDonneeBinaireInRow(ContexteDonnee.IdSession, Row, c_champFormuleLibelle);
                    CContexteDonnee.ChangeRowSansDetectionModification(Row, c_champFormuleLibelle, donnee);
                }
                object obj = Row[c_champFormuleLibelle];
                return ((CDonneeBinaireInRow)obj).GetSafeForRow(Row.Row);
            }
            set
            {
                Row[c_champFormuleLibelle] = value;
            }
        }

        /// /////////////////////////////////////////////////////////
        [TableFieldProperty(c_champCacheFormuleActionsSurParent, IsInDb = false, NullAutorise = true)]
        [BlobDecoder]
        public C2iExpression FormuleCalculActionsSurParent
        {
            get
            {
                return GetFormule(c_champCacheFormuleActionsSurParent, DataFormuleActionsSurParent);
            }
            set
            {
                CDonneeBinaireInRow data = DataFormuleActionsSurParent;
                SetFormule(c_champCacheFormuleActionsSurParent, ref data, value);
                DataFormuleActionsSurParent = data;


            }
        }

        /// /////////////////////////////////////////////////////////
        [TableFieldProperty(c_champFormulActionsSurParent, NullAutorise = true)]
        public CDonneeBinaireInRow DataFormuleActionsSurParent
        {
            get
            {
                if (Row[c_champFormulActionsSurParent] == DBNull.Value)
                {
                    CDonneeBinaireInRow donnee = new CDonneeBinaireInRow(ContexteDonnee.IdSession, Row, c_champFormulActionsSurParent);
                    CContexteDonnee.ChangeRowSansDetectionModification(Row, c_champFormulActionsSurParent, donnee);
                }
                object obj = Row[c_champFormulActionsSurParent];
                return ((CDonneeBinaireInRow)obj).GetSafeForRow(Row.Row);
            }
            set
            {
                Row[c_champFormulActionsSurParent] = value;
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// Indique le code système complet du type d'alarme.<br/>
        /// Ce code système complet est la concaténation du code système partiel du type d'alarme<br/>
        /// avec le code système partiel de tous ses parents en remontant la hiérarchie.<br/>
        /// Exemple : pour un code système complet tel que : 0012000A0034 :<br/>
        /// 0034 est le code partiel du type d'alarme courant<br/>
        /// 000A est le code partiel du type d'alarme père<br/>
        /// 0012 est le code partiel du type d'alarme grand père
        /// </summary>
        [TableFieldProperty(c_champCodeSystemeComplet, 400)]
        [DynamicField("Full system code")]
        public override string CodeSystemeComplet
        {
            get
            {
                return (string)Row[c_champCodeSystemeComplet];
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// Indique le code système du type d'alarme dans sa hiérarchie. Ce code est unique dans son parent.
        /// Ce code est exprimé sur 4 caractères alphanumériques.
        /// </summary>
        [TableFieldProperty(c_champCodeSystemePartiel, 4)]
        [DynamicField("Partial system code")]
        public override string CodeSystemePartiel
        {
            get
            {
                string strVal = "";
                if (Row[c_champCodeSystemePartiel] != DBNull.Value)
                    strVal = (string)Row[c_champCodeSystemePartiel];
                strVal = strVal.Trim().PadLeft(4, '0');
                return strVal;
            }
        }

        //----------------------------------------------------
        public override string ChampCodeSystemeComplet
        {
            get { return c_champCodeSystemeComplet; }
        }

        //----------------------------------------------------
        public override string ChampCodeSystemePartiel
        {
            get { return c_champCodeSystemePartiel; }
        }

        //----------------------------------------------------
        public override string ChampIdParent
        {
            get
            {
                return c_champIdTypeParent;
            }
        }

        //----------------------------------------------------
        public override string ChampLibelle
        {
            get { return c_champLibelle; }
        }


        //----------------------------------------------------
        public override string ChampNiveau
        {
            get { return c_champNiveau; }
        }


        //----------------------------------------------------
        public override int NbCarsParNiveau
        {
            get { return 2; }
        }

        //----------------------------------------------------
        /// <summary>
        /// Indique le niveau hiérarchique( nombre de parents ) du type d'alarme.
        /// Le niveau d'un type d'alarme sans parent est 0.
        /// Exemple : Intrusion site -> Porte -> Ouverture :
        /// 'Intrusion site' a pour niveau 0,
        /// 'Porte' a pour niveau 1 (1 parent en remontant la hiérarchie)
        /// 'Ouverture' a pour niveau 2 (2 parents en remontant la hiérachie)
        /// </summary>
        [TableFieldProperty(c_champNiveau)]
        [DynamicField("Level")]
        public override int Niveau
        {
            get
            {
                return (int)Row[c_champNiveau];
            }
        }

       
        //-------------------------------------------------------------------
        /// <summary>
        /// Type d'alarme parent
        /// </summary>
        [Relation(
            CTypeAlarme.c_nomTable,
            CTypeAlarme.c_champId,
            CTypeAlarme.c_champIdTypeParent,
            false,
            true,
            false)]
        [DynamicField("Parent type")]
        [TiagRelation(typeof(CTypeAlarme), CAssociationTiag.c_methodeUseDelegate)]
        public CTypeAlarme TypeParent
        {
            get
            {
                return (CTypeAlarme)ObjetParent;
            }
            set
            {
                ObjetParent = value;
            }
        }

        //---------------------------------------------
        /// <summary>
        /// Retourne la liste des types d'alarme fils
        /// </summary>
        [RelationFille(typeof(CTypeAlarme), "TypeParent")]
        [DynamicChilds("Childs types", typeof(CTypeAlarme))]
        public CListeObjetsDonnees TypesFils
        {
            get
            {
                return ObjetsFils;
            }
        }

	


        #region IDefinisseurChampCustomRelationObjetDonnee Membres

        //--------------------------------------------------------------------
        [RelationFille(typeof(CRelationTypeAlarme_ChampCustom), "Definisseur")]
        public CListeObjetsDonnees RelationsChampsCustomListe
        {
            get { return GetDependancesListe(CRelationTypeAlarme_ChampCustom.c_nomTable, c_champId); }
        }

        //--------------------------------------------------------------------
        [RelationFille(typeof(CRelationTypeAlarme_Formulaire), "Definisseur")]
        public CListeObjetsDonnees RelationsFormulairesListe
        {
            get { return GetDependancesListe(CRelationTypeAlarme_Formulaire.c_nomTable, c_champId); }
        }

        #endregion

        #region IDefinisseurChampCustom Membres

        /// /////////////////////////////////////////////
        public IRelationDefinisseurChamp_ChampCustom[] RelationsChampsCustomDefinis
        {
            get
            {
                return (IRelationDefinisseurChamp_ChampCustom[])RelationsChampsCustomListe.ToArray(typeof(IRelationDefinisseurChamp_ChampCustom));
            }
        }

        /// /////////////////////////////////////////////
        public IRelationDefinisseurChamp_Formulaire[] RelationsFormulaires
        {
            get
            {
                return (IRelationDefinisseurChamp_Formulaire[])RelationsFormulairesListe.ToArray(typeof(IRelationDefinisseurChamp_Formulaire));
            }
        }

        /// /////////////////////////////////////////////
        public CRoleChampCustom RoleChampCustomDesElementsAChamp
        {
            get
            {
                return CRoleChampCustom.GetRole(CAlarme.c_roleChampCustom);
            }
        }

        /// /////////////////////////////////////////////
        public CChampCustom[] TousLesChampsAssocies
        {
            get
            {
                Hashtable tableChamps = new Hashtable();
                FillHashtableChamps(tableChamps);
                CChampCustom[] liste = new CChampCustom[tableChamps.Count];
                int nChamp = 0;
                foreach (CChampCustom champ in tableChamps.Values)
                    liste[nChamp++] = champ;
                return liste;
            }
        }

        //-------------------------------------------------------------------
        /// <summary>
        /// Remplit une hashtable IdChamp->Champ
        /// avec tous les champs liés.(hiérarchique)
        /// </summary>
        /// <param name="tableChamps">HAshtable à remplir</param>
        private void FillHashtableChamps(Hashtable tableChamps)
        {
            foreach (IRelationDefinisseurChamp_ChampCustom relation in RelationsChampsCustomDefinis)
                tableChamps[relation.ChampCustom.Id] = relation.ChampCustom;
            foreach (IRelationDefinisseurChamp_Formulaire relation in RelationsFormulaires)
            {
                foreach (CRelationFormulaireChampCustom relFor in relation.Formulaire.RelationsChamps)
                    tableChamps[relFor.Champ.Id] = relFor.Champ;
            }
            if (TypeParent != null)
                TypeParent.FillHashtableChamps(tableChamps);
        }

        #endregion


        //-------------------------------------------------------------
        public CLocalTypeAlarme GetTypeForSupervision(CMemoryDb database, bool bWithChilds)
        {
            if (database == null)
                database = CMemoryDbPourSupervision.GetMemoryDb(ContexteDonnee);
            CLocalTypeAlarme typeParent = null;
            if (TypeParent != null)
            {
                typeParent = TypeParent.GetTypeForSupervision(database, false);
            }
            CLocalTypeAlarme typeAlarme = new CLocalTypeAlarme(database);
            if (!typeAlarme.ReadIfExist(Id.ToString(), false))
                typeAlarme.CreateNew(Id.ToString());
            else
                if (!typeAlarme.IsToRead())
                    return typeAlarme;
            typeAlarme.Row[CMemoryDb.c_champIsToRead] = false;
            typeAlarme.Libelle = Libelle;
            typeAlarme.ModeCalculEtat = ModeCalculEtatParent.Code;
            typeAlarme.ActionsSurParent = FormuleCalculActionsSurParent;
            typeAlarme.EtatDefaut = EtatInitial.Code;
            typeAlarme.TypeParent = typeParent;
            typeAlarme.RegrouperSurLaCle = RegrouperSurLaCle;
            typeAlarme.FormuleLibelle = FormuleCalculLibelle;
            typeAlarme.ActionsSurParent = FormuleCalculActionsSurParent;
            typeAlarme.AAcquitter = AAcquitter;
            typeAlarme.TypeElementSupervise = TypeElementSupervise.Code;

            CLocalSeveriteAlarme severite = null;
            if (Severite != null)
            {
                severite = Severite.GetTypeForSupervision(database);
            }
            typeAlarme.Severite = severite;

            foreach (CRelationTypeAlarme_ChampCustom rel in RelationsChampsCustomDefinis)
            {
                if (rel.ChampCustom != null && rel.ChampCustom.Id > 0)
                {
                    CLocalChampTypeAlarme champ = GetChampTypeAlarme ( database, rel.ChampCustom );
                    CLocalRelationTypeAlarmeChampAlarme relLocale = new CLocalRelationTypeAlarmeChampAlarme(database);
                    if (!relLocale.ReadIfExist(rel.Id.ToString()))
                    {
                        relLocale.CreateNew(rel.Id.ToString());
                        relLocale.Champ = champ;
                        relLocale.TypeAlarme = typeAlarme;
                        relLocale.IsKey = rel.IsKey;
                    }

                }
            }
            if (bWithChilds)
            {
                foreach (CTypeAlarme typeChild in TypesFils)
                {
                    CLocalTypeAlarme typeFils = typeChild.GetTypeForSupervision(database, true);
                    typeFils.TypeParent = typeAlarme;
                }
            }
            return typeAlarme;
        }

        public static CLocalChampTypeAlarme GetChampTypeAlarme(CMemoryDb database, CChampCustom champCustom)
        {
            CLocalChampTypeAlarme champ = new CLocalChampTypeAlarme(database);
            if (champ.ReadIfExist(champCustom.Id.ToString()))
            {
                if (!champ.IsToRead())
                    return champ;
                champ.Row[CMemoryDb.c_champIsToRead] = false;
            }
            else
                champ.CreateNew(champCustom.Id.ToString());
            champ.NomChamp = champCustom.Nom;
            switch (champCustom.TypeDonneeChamp.TypeDonnee)
            {
                case TypeDonnee.tBool:
                    champ.TypeDonnee = ETypeChampBasique.Bool;
                    break;
                case TypeDonnee.tDate:
                    champ.TypeDonnee = ETypeChampBasique.Date;
                    break;
                case TypeDonnee.tDouble:
                    champ.TypeDonnee = ETypeChampBasique.Decimal;
                    break;
                case TypeDonnee.tEntier:
                    champ.TypeDonnee = ETypeChampBasique.Int;
                    break;
                case TypeDonnee.tObjetDonneeAIdNumeriqueAuto:
                    champ.TypeDonnee = ETypeChampBasique.Int;
                    champ.NomChamp += "_id";
                    break;
                case TypeDonnee.tString:
                default:
                    champ.TypeDonnee = ETypeChampBasique.String;
                    break;
            }
            return champ;
        }

        //-------------------------------------------------------------
        public static IBaseTypesAlarmes GetBaseTypesAlarmes(CContexteDonnee ctx)
        {
            return new CBaseTypeAlarmeFromBDD(ctx, new CMemoryDb());
        }



        //-------------------------------------------------------------------
        /// <summary>
        /// Détermine la sévérité d'alarme liée au Type d'alarme
        /// </summary>
        [Relation(
            CSeveriteAlarme.c_nomTable,
            CSeveriteAlarme.c_champId,
            CSeveriteAlarme.c_champId,
            true,
            false,
            false)]
        [DynamicField("Alarm Severity")]
        [TiagRelation(typeof(CSeveriteAlarme), CAssociationTiag.c_methodeUseDelegate)]
        public CSeveriteAlarme Severite
        {
            get
            {
                return (CSeveriteAlarme)GetParent(CSeveriteAlarme.c_champId, typeof(CSeveriteAlarme));
            }
            set
            {
                SetParent(CSeveriteAlarme.c_champId, value);
            }
        }





        #region IElementADonneePourMediationSNMP Membres

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

        #endregion

        #region IElementAChamps Membres

        //------------------------------------------------------------
        public IDefinisseurChampCustom[] DefinisseursDeChamps
        {
            get
            {
                return new IDefinisseurChampCustom[]{
                    new CDefinisseurChampsPourTypeSansDefinisseur(
                        ContexteDonnee, 
                        CRoleChampCustom.GetRole(CTypeAlarme.c_roleChampCustom) )};
            }
        }

        //------------------------------------------------------------
        public CChampCustom[] GetChampsHorsFormulaire()
        {
            return new CChampCustom[0];
        }

        //------------------------------------------------------------
        public CFormulaire[] GetFormulaires()
        {
            return CUtilElementAChamps.GetFormulaires(this);
        }

        //------------------------------------------------------------
        [DynamicField("Custom fields relations")]
        [RelationFille ( typeof(CRelationTypeAlarme_ChampCustomValeur), "ElementAChamps")]
        public CListeObjetsDonnees RelationsChampsCustom
        {
            get
            {
                return GetDependancesListe(CRelationTypeAlarme_ChampCustomValeur.c_nomTable, c_champId);
            }
        }

        //------------------------------------------------------------
        public CRoleChampCustom RoleChampCustomAssocie
        {
            get { return CRoleChampCustom.GetRole(c_roleChampCustom); }
        }

        #endregion

        //----------------------------------------------------------------------------
        public object GetValeurChamp(int nIdChamp)
        {
            return CUtilElementAChamps.GetValeurChamp(this, nIdChamp);
        }

        //-----------------------------------------------------------------------------
        public object GetValeurChamp(int nIdChamp, DataRowVersion version)
        {
            return CUtilElementAChamps.GetValeurChamp(this, nIdChamp, version);
        }

        public object GetValeurChamp(string strIdVariable)
        {
            return CUtilElementAChamps.GetValeurChamp(this, strIdVariable);
        }

        //-----------------------------------------------------------------------------
        public object GetValeurChamp(IVariableDynamique variable)
        {
            if (variable == null)
                return null;
            return GetValeurChamp(variable.IdVariable);
        }

        //---------------------------------------------
        public CResultAErreur SetValeurChamp(string strIdVariable, object valeur)
        {
            return CUtilElementAChamps.SetValeurChamp(this, strIdVariable, valeur);
        }

        //---------------------------------------------
        public CResultAErreur SetValeurChamp(IVariableDynamique variable, object valeur)
        {
            if (variable == null)
                return CResultAErreur.True;
            return SetValeurChamp(variable.IdVariable, valeur);
        }

        //-------------------------------------------------------------------
        public CResultAErreur SetValeurChamp(int nIdChamp, object valeur)
        {
            return CUtilElementAChamps.SetValeurChamp(this, nIdChamp, valeur);
        }

        //------------------------------------------------------------
        public CRelationElementAChamp_ChampCustom GetNewRelationToChamp()
        {
            return new CRelationTypeAlarme_ChampCustomValeur(ContexteDonnee);
        }

        //------------------------------------------------------------
        public string GetNomTableRelationToChamps()
        {
            return CRelationTypeAlarme_ChampCustomValeur.c_nomTable;
        }

        //------------------------------------------------------------
        public CListeObjetsDonnees GetRelationsToChamps(int nIdChamp)
        {
            CListeObjetsDonnees liste = RelationsChampsCustom;
            liste.InterditLectureInDB = true;
            liste.Filtre = new CFiltreData(CChampCustom.c_champId + " = @1", nIdChamp);
            return liste;
        }

        
    }
}
