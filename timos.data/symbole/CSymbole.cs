using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using sc2i.data.dynamic;

using timos;
using timos.data.snmp;





namespace timos.data
{
    /// <summary>
    /// Un élément qui est représenté par un symbole
    /// </summary>
    public interface IElementASymbolePourDessin : IObjetDonneeAIdNumerique
    {
        /// <summary>
        /// Retourne le symbole à utiliser pour représenter l'élément
        /// </summary>
        C2iSymbole SymboleADessiner { get;}
    }
 
    /// <summary>
    /// Un élément qui définit un symbole, soit à partir de la bibliothèque,
    /// soit il s'agit d'un symbole propre à l'élément
    /// </summary>
    public interface IDefinisseurSymbole
    {
        //Retourne le symbole associé. IL s'agit soit du symbole de bibliothèque,
        //soit du symbole propre
        CSymbole Symbole { get;}

        /// <summary>
        /// Symbole propre à l'élément
        /// </summary>
        CSymbole SymbolePropre { get;set;}

        /// <summary>
        /// symbole de bibliothèque associé à l'élément
        /// </summary>
        CSymboleDeBibliotheque SymboleDeBibliotheque { get;set;}

        C2iSymbole SymboleDefiniADessiner { get;}

        Type GetTypePourLequelOnSelectionneUnSymbole();
    }



    [DynamicClass("Symbol")]
    [Table(CSymbole.c_nomTable, CSymbole.c_champId, true)]
    [FullTableSync]
    [ObjetServeurURI("CSymboleServeur")]
    public class CSymbole : CObjetDonneeAIdNumeriqueAuto
    {
        public const string c_nomTable = "SYMBOL";
        public const string c_champId = "SYMBOL_ID";
        public const string c_champData = "SYMBOL_DATA";

        public const string c_cleSymboleParDefault = "DEF_SYMB_";
       

      
		public CSymbole( CContexteDonnee contexte)
			:base (contexte)
		{
		}

		
		public CSymbole ( DataRow row )
			:base ( row) 
		{
		}

        public override string DescriptionElement
        {
            get
            {
                return I.T("Symbol @1|30035",Id.ToString());
            }
        }

        public override string[] GetChampsTriParDefaut()
        {
            return new string[] { c_champId.ToString() };
        }

        
        protected override void MyInitValeurDefaut()
        {

        }

        [TableFieldProperty(c_champData, NullAutorise = true)]
        public CDonneeBinaireInRow Data
        {
            get
            {
                if (Row[c_champData] == DBNull.Value)
                {
                    CDonneeBinaireInRow donnee = new CDonneeBinaireInRow(ContexteDonnee.IdSession, Row, c_champData);
                    CContexteDonnee.ChangeRowSansDetectionModification(Row, c_champData, donnee);
                }
                return ((CDonneeBinaireInRow)Row[c_champData]).GetSafeForRow(Row.Row);
            }
            set
            {
                Row[c_champData] = value;
            }


        }



        [BlobDecoder]
        public C2iSymbole Symbole
        {
            get
            {
                C2iSymbole symb = new C2iSymbole();
             
                if (Data.Donnees != null)
                {
                    MemoryStream stream = new MemoryStream(Data.Donnees);
                    BinaryReader reader = new BinaryReader(stream);
                    CSerializerReadBinaire serializer = new CSerializerReadBinaire(reader);
                    serializer.AttacheObjet(typeof(CContexteDonnee), ContexteDonnee);
                    CResultAErreur result = symb.Serialize(serializer);
                    serializer.DetacheObjet(typeof(CContexteDonnee), ContexteDonnee);
                    if (!result)
                    {
                        symb = new C2iSymbole();
                       
                    }
                    reader.Close();
                    stream.Close();
                }
                return symb;
            }
            set
            {
                if (value == null)
                {
                    CDonneeBinaireInRow data = Data;
                    data.Donnees = null;
                    Data = data;
                    
                }
                else
                {
                    MemoryStream stream = new MemoryStream();
                    BinaryWriter writer = new BinaryWriter(stream);
                    CSerializerSaveBinaire serializer = new CSerializerSaveBinaire(writer);
                    CResultAErreur result = value.Serialize(serializer);
                    if (result)
                    {
                        CDonneeBinaireInRow data = Data;
                        data.Donnees = stream.GetBuffer();
                        Data = data;
                    }
                    writer.Close();
                    stream.Close();
                }
            }
        }



        /// <summary>
        /// Le symbole de bibliotheque associé au symbole graphique
        /// </summary>
        [Relation(
            CSymboleDeBibliotheque.c_nomTable,
           CSymboleDeBibliotheque.c_champId,
           CSymboleDeBibliotheque.c_champId,
            false,
            true,
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
                SetParent(CSymboleDeBibliotheque.c_champId, value);
            }

        }

        /// <summary>
        /// Le type d'équipement associé au symbole graphique
        /// </summary>
        [Relation(
            CTypeEquipement.c_nomTable,
           CTypeEquipement.c_champId,
           CTypeEquipement.c_champId,
            false,
            true,
            false)]
        [DynamicField("Equipment type")]
        public CTypeEquipement TypeEquipement
        {
            get
            {
                return (CTypeEquipement) GetParent(CTypeEquipement.c_champId, typeof(CTypeEquipement));
            }
            set
            {
                SetParent(CTypeEquipement.c_champId, value);
            }

        }

        /// <summary>
        /// L'équipement logique associé au symbole graphique
        /// </summary>
        [Relation(
            CEquipementLogique.c_nomTable,
           CEquipementLogique.c_champId,
           CEquipementLogique.c_champId,
           false,
           true,
           false)]
        [DynamicField("Logical Equipement")]
        public CEquipementLogique EquipementLogique
        {
            get
            {
                return (CEquipementLogique)GetParent(CEquipementLogique.c_champId, typeof(CEquipementLogique));
            }
            set
            {
                SetParent(CEquipementLogique.c_champId, value);
            }

        }
        



        /// <summary>
        /// Le type de site associé au symbole graphique
        /// </summary>
        [Relation(
            CTypeSite.c_nomTable,
           CTypeSite.c_champId,
           CTypeSite.c_champId,
           false,
           true,
           false)]
        [DynamicField("Site type")]
        public CTypeSite TypeSite
        {
            get
            {
                return (CTypeSite)GetParent(CTypeSite.c_champId, typeof(CTypeSite));
            }
            set
            {
                SetParent(CTypeSite.c_champId, value);
            }

        }



        /// <summary>
        /// Le site associé au symbole graphique
        /// </summary>
        [Relation(
            CSite.c_nomTable,
           CSite.c_champId,
           CSite.c_champId,
           false,
           true,
           false)]
        [DynamicField("Site")]
        public CSite Site
        {
            get
            {
                return (CSite)GetParent(CSite.c_champId, typeof(CSite));
            }
            set
            {
                SetParent(CSite.c_champId, value);
            }

        }

        /// <summary>
        /// Le type de Schema Reseau associé au symbole graphique
        /// </summary>
        [Relation(
            CTypeSchemaReseau.c_nomTable,
           CTypeSchemaReseau.c_champId,
           CTypeSchemaReseau.c_champId,
           false,
           true,
           false)]
        [DynamicField("Network diagram type")]
        public CTypeSchemaReseau TypeSchemaReseau
        {
            get
            {
                return (CTypeSchemaReseau)GetParent(CTypeSchemaReseau.c_champId, typeof(CTypeSchemaReseau));
            }
            set
            {
                SetParent(CTypeSchemaReseau.c_champId, value);
            }

        }



        /// <summary>
        /// Le Schéma Réseau associé au symbole graphique
        /// </summary>
        [Relation(
            CSchemaReseau.c_nomTable,
           CSchemaReseau.c_champId,
           CSchemaReseau.c_champId,
           false,
           true,
           false)]
        [DynamicField("Network diagram")]
        public CSchemaReseau SchemaReseau
        {
            get
            {
                return (CSchemaReseau)GetParent(CSchemaReseau.c_champId, typeof(CSchemaReseau));
            }
            set
            {
                SetParent(CSchemaReseau.c_champId, value);
            }

        }

        
        /// <summary>
        /// Le port associé au symbole graphique
        /// </summary>
        [Relation(
            CPort.c_nomTable,
           CPort.c_champId,
           CPort.c_champId,
           false,
           true,
           false)]
        [DynamicField("Port")]
        public CPort Port
        {
            get
            {
                return (CPort)GetParent(CPort.c_champId, typeof(CPort));
            }
            set
            {
                SetParent(CPort.c_champId, value);
            }

        }

        //---------------------------------------------------------------

        //-------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        [Relation(
            CTypeEntiteSnmp.c_nomTable,
            CTypeEntiteSnmp.c_champId,
            CTypeEntiteSnmp.c_champId,
            false,
            true,
            false)]
        [DynamicField("Snmp entity type")]
        public CTypeEntiteSnmp TypeEntiteSnmp
        {
            get
            {
                return (CTypeEntiteSnmp)GetParent(CTypeEntiteSnmp.c_champId, typeof(CTypeEntiteSnmp));
            }
            set
            {
                SetParent(CTypeEntiteSnmp.c_champId, value);
            }
        }

	


        //---------------------------------------------------------------
        private static string GetCleRegistreSymboleDefaut(Type type)
        {
            return c_cleSymboleParDefault + "_" + type.ToString();
        }

        public static int GetIdSymboleParDefaut(Type typeElement, CContexteDonnee contexte)
        {
            string strCle = GetCleRegistreSymboleDefaut(typeElement);
            CDataBaseRegistrePourClient reg = new CDataBaseRegistrePourClient(contexte.IdSession);
            int nId = (int)reg.GetValeurLong(strCle, -1);
            return nId;
        }

        /// <summary>
        /// Retourne le symbole par défaut à utiliser pour un type d'élément
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static C2iSymbole GetSymboleParDefaut(Type typeElement, CContexteDonnee contexte)
        {
            int nId = GetIdSymboleParDefaut(typeElement, contexte);
            C2iSymbole symboleADessiner = null;
            if (nId >= 0)
            {
                CSymbole symbole = new CSymbole(contexte);
                if (symbole.ReadIfExists(nId))
                    symboleADessiner = symbole.Symbole;
            }
            if (symboleADessiner == null)
            {
                symboleADessiner = new C2iSymbole();
                symboleADessiner.Size = new Size(40, 40);
                C2iSymboleLabel label = new C2iSymboleLabel();
                label.Size = new Size(40, 40);
                label.Parent = symboleADessiner;
                symboleADessiner.AddChild(label);
                label.Text = DynamicClassAttribute.GetNomConvivial(typeElement);
                label.Position = new Point(0, 0);
            }
            return symboleADessiner;
        }

        public static void SetSymboleParDefaut ( Type typeElement, CSymbole symbole )
        {
            if ( symbole == null )
                return;
            string strCle = GetCleRegistreSymboleDefaut(typeElement);
            CDataBaseRegistrePourClient reg = new CDataBaseRegistrePourClient(symbole.ContexteDonnee.IdSession);
            reg.SetValeur(strCle, symbole.Id.ToString());
        }
    }
}
