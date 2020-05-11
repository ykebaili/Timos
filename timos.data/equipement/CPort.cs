using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

using sc2i.data;
using sc2i.common;
using sc2i.multitiers.client;
using sc2i.data.dynamic;

using sc2i.process;

using sc2i.workflow;
using timos.data;
using timos.securite;
using tiag.client;
using System.Data;
using timos.data.equipement;


namespace timos.data
{
    /// <summary>
    /// Modélise un port d'accès pour un <see cref="CTypeEquipement">type d'équipement</see> ou un <see cref="CEquipement">équipement</see>.
    /// </summary>
    /// <remarks>
    /// Les ports d'accès peuvent être exploités dans les <see cref="CLienReseau">liens réseaux</see>inter-équipements<br/>
    /// comme objets extrémités du lien
    /// </remarks>
    [DynamicClass("Port")]
    [ObjetServeurURI("CPortServeur")]
    [Table(CPort.c_nomTable, CPort.c_champId, true)]
    [FullTableSync]
    [TiagClass("Port","Id", true)]
    public class CPort : CObjetDonneeAIdNumeriqueAuto, 
        IDefinisseurSymbole, 
        IElementASymbolePourDessin,
        IComplementElementALiensReseau
    {

        public const string c_nomTable = "PORT";
        public const string c_champId = "PORT_ID";
        public const string c_champLibelle = "PORT_LABEL";
        public const string c_champCode = "PORT_CODE";
        public const string c_champPosX = "PORT_POSX";
        public const string c_champPosY = "PORT_POSY";


        public CPort( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CPort( System.Data.DataRow row )
			:base(row)
		{
		}



        protected override void MyInitValeurDefaut()
        {
            PosX = 0;
            PosY = 0;
        }

        public override string GetNomTable()
        {
            return c_nomTable;
        }
        //-------------------------------------------------------------------
        public override string GetChampId()
        {
            return c_champId;
        }


        /// <summary>
        /// Libellé du Porc <br/>
        /// (obligatoire)
        /// </summary>
        [DescriptionField]
        [TableFieldProperty(c_champLibelle, 255)]
        [DynamicField("Label")]
        [TiagField("Label")]
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



        /// <summary>
        /// Code du port
        /// </summary>
        //[DescriptionField] en double avec le Libelle
        [TableFieldProperty(c_champCode, 255)]
        [DynamicField("Code")]
        [TiagField("Code")]
        public string Code 
        {
            get
            {
                return (string)Row[c_champCode];
            }
            set
            {
                Row[c_champCode] = value;
            }
        }

        /// <summary>
        /// Position en X du symbole du port (représentation graphique)<br/>
        /// </summary>
        [TableFieldProperty(c_champPosX)]
        [DynamicField("Position X")]
        [TiagField("Symbol X Position")]
        public int PosX
        {
            get
            {
                return (int)Row[c_champPosX];
            }
            set
            {
                Row[c_champPosX] = value;
            }
        }

        /// <summary>
        /// Position en Y du symbole du port (représentation graphique)<br/>
        /// </summary>
        [TableFieldProperty(c_champPosY)]
        [DynamicField("Position Y")]
        [TiagField("Symbol Y position")]
        public int PosY
        {
            get
            {
                return (int)Row[c_champPosY];
            }
            set
            {
                Row[c_champPosY] = value;
            }
        }

        //-------------------------------------------------------------------
        public void TiagSetEquipmentTypeKeys(object[] lstKeys)
        {
            CTypeEquipement typeEq = new CTypeEquipement(ContexteDonnee);
            if (typeEq.ReadIfExists(lstKeys))
                TypeEquipement = typeEq;
        }
        /// <summary>
        /// <see cref="CTypeEquipement">Type de l'équipement</see> auquel le port est attaché
        /// </summary>
        [Relation(
            CTypeEquipement.c_nomTable,
            CTypeEquipement.c_champId,
            CTypeEquipement.c_champId,
            true,
            true,
            false)]
        [DynamicField("Equipment type")]
        [TiagRelation(typeof(CTypeEquipement), "TiagSetEquipmentTypeKeys")]
        public CTypeEquipement TypeEquipement
        {
            get
            {
                return (CTypeEquipement)GetParent(CTypeEquipement.c_champId, typeof(CTypeEquipement));
            }
            set
            {
                SetParent(CTypeEquipement.c_champId, value);
            }
        }


        //----------------------------------------------
        public C2iSymbole SymboleADessiner
        {
            get
            {
                C2iSymbole symbole = null;
                if (Symbole != null)
                    symbole = Symbole.Symbole;
                if (symbole == null)
                    symbole = CSymbole.GetSymboleParDefaut(typeof(CPort), ContexteDonnee);
                if (symbole != null)
                {
                    symbole = symbole.GetCloneSymbole();
                    symbole.ElementASymbole = this;
                    symbole.LockElementASymbole = true;
                }
                return symbole;
            }
        }

        public C2iSymbole SymboleDefiniADessiner
        {
            get
            {
                return SymboleADessiner;
            }

        }

        //--------------------------------------
        public Type GetTypePourLequelOnSelectionneUnSymbole()
        {
            return typeof(CPort);
        }


        

        //-------------------------------------------------------------------
        public override string DescriptionElement
        {
            get
            {
                return I.T("Port  @1|30086", Libelle);
            }
        }

        /// ///////////////////////////////////////////////////////
        public override string[] GetChampsTriParDefaut()
        {
            return new string[] { c_champLibelle };
        }

        //-------------------------------------------------------------------
        public void TiagSetTypePortKeys(object[] lstKeys)
        {
            CTypePort typePort = new CTypePort(ContexteDonnee);
            if (typePort.ReadIfExists(lstKeys))
                TypePort = typePort;
        }

        //----------------------------------------------------------
        /// <summary>
        /// <see cref="CTypePort">Type du port</see>
        /// </summary>
        [Relation(

            CTypePort.c_nomTable,
            CTypePort.c_champId,
            CTypePort.c_champId,
            false,
            false)]
        [DynamicField("Port type")]
        [TiagRelation(typeof(CTypePort), "TiagSetTypePortKeys")]
        public CTypePort TypePort
        {
            get
            {
                return (CTypePort)GetParent(CTypePort.c_champId, typeof(CTypePort));
            }
            set
            {
                SetParent(CTypePort.c_champId, value);
            }
        }




        #region IElementASymbole Membres

        //-----------------------------------------------------------
        /// <summary>
        /// Le symbole de bibliothèque associé au port<br/>
        /// (Dans le cas où ce n'est pas un symbole propre qui est choisi)
        /// </summary>
        [Relation(
            CSymboleDeBibliotheque.c_nomTable,
           CSymboleDeBibliotheque.c_champId,
          CSymboleDeBibliotheque.c_champId,
            false,
            false,
            false)]
        [DynamicField("Library Symbol")]
        public CSymboleDeBibliotheque SymboleDeBibliotheque
        {
            get
            {
                return (CSymboleDeBibliotheque)GetParent(CSymboleDeBibliotheque.c_champId, typeof(CSymboleDeBibliotheque));
            }
            set
            {
                if (SymbolePropre != null)
                {
                    SymbolePropre = null;
                }
                SetParent(CSymboleDeBibliotheque.c_champId, value);

            }

        }

        /// <summary>
        /// Le symbole propre associé au port <br/>
        /// (dans le cas où ce n'est pas un symbole de bibliothèque qui est choisi)
        /// </summary>
        [RelationFille(typeof(CSymbole), "Port")]
        [DynamicField("Proper Symbol")]
        public CSymbole SymbolePropre
        {
            get
            {
                CListeObjetsDonneesContenus liste = GetDependancesListe(CSymbole.c_nomTable, CPort.c_champId);
                if (liste.Count > 0)
                    return (CSymbole)liste[0];
                else
                    return null;
            }
            set
            {

                Row[CSymboleDeBibliotheque.c_champId] = null;
                if (value == null)
                {
                    if (SymbolePropre != null)
                        SymbolePropre.Delete();
                }
                else
                {
                    value.Port = this;
                }
            }
        }

        /// <summary>
        /// Symbole graphique associé
        /// </summary>
        [DynamicField("Symbol")]
        public CSymbole Symbole
        {
            get
            {
                if (SymbolePropre == null)
                {
                    if (SymboleDeBibliotheque != null)
                        return SymboleDeBibliotheque.Symbole;
                }
                return SymbolePropre;
            }

        }

       #endregion

        #region IComplementElementALien Membres


        /// <summary>
        /// Liste des <see cref="CLienReseau">liens réseau</see> auxquels le port est attaché
        /// </summary>
        [DynamicChilds("Links", typeof(CLienReseau))]
        public CLienReseau[] Liens
        {
            get
            {
                List<CLienReseau> lst = new List<CLienReseau>();
                foreach (CLienReseau lien in LiensEnTantQueComplement1)
                    lst.Add(lien);
                foreach (CLienReseau lien in LiensEnTantQueComplement2)
                    lst.Add(lien);
                return lst.ToArray();
            }
        }


        /// <summary>
        /// Liste des <see cref="CLienReseau">liens réseau</see> auxquels le port est attaché<br/>
        /// en tant que port 1
        /// </summary>
        [RelationFille(typeof(CLienReseau), "Port1")]
        [DynamicChilds("Link as port 1", typeof(CLienReseau))]
        public CListeObjetsDonnees LiensEnTantQueComplement1
        {
            get
            {
                return GetDependancesListe(CLienReseau.c_nomTable, CLienReseau.c_champPort1);
            }
        }

        /// <summary>
        /// Liste des <see cref="CLienReseau">liens réseau</see> auxquels le port est attaché<br/>
        /// en tant que port 2
        /// </summary>
        [RelationFille(typeof(CLienReseau), "Port2")]
        [DynamicChilds("Link as port 2", typeof(CLienReseau))]
        public CListeObjetsDonnees LiensEnTantQueComplement2
        {
            get
            {
                return GetDependancesListe(CLienReseau.c_nomTable, CLienReseau.c_champPort2);
            }
        }

        

        #endregion
    }
}
