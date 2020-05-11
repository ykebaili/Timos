using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Drawing;

using sc2i.data;
using sc2i.data.dynamic;
using sc2i.common;
using sc2i.expression;


namespace sc2i.workflow
{
	/// <summary>
	/// Un modèle de texte, comme son nom l'indique, permet de définir un<br/>
    /// modèle pour présenter du texte (type de police de caractère, taille,<br/>
    /// cadrage, etc.). Ceci est exploité, entre autres choses, pour présenter<br/>
    /// la liste des contacts dans le cadre d'un <see cref="CTicket">ticket de maintenance</see>
	/// </summary>
    [sc2i.doccode.DocRefMenusOrMenuItems(timos.data.CDocLabels.c_iProcess)]
    [sc2i.doccode.DocRefMenusOrMenuItems(timos.data.CDocLabels.c_iSecurite)]
    [DynamicClass("Text template")]
	[ObjetServeurURI("CModeleTexteServeur")]
	[Table(CModeleTexte.c_nomTable, CModeleTexte.c_champId,true, IsGrandVolume = true)]
	[FullTableSync]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_ModelesTexte_ID)]
    public class CModeleTexte : CObjetDonneeAIdNumeriqueAuto
	{
		#region Déclaration des constantes
		public const string c_nomTable = "TEXT_TEMPLATE";
		public const string c_champId = "TXTTPL_ID";
		public const string c_champLibelle = "TXTTPL_LABEL";
		public const string c_champTypeAssocie = "TXTTPL_LINK_TYPE";
		public const string c_champDataModele = "TXTTPL_TEMPLATE";
		public const string c_champCouleurFond = "TXTTPL_BACK_COLOR";
		public const string c_champLargeur = "TXTTPL_WIDTH";
		public const string c_champHauteur = "TXTTPL_HEIGHT";
        public const string c_champTexteParametre = "TXTTPL_PARAM_TEXT";
		#endregion

		//-------------------------------------------------------------------
#if PDA
		public CModeleTexte()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CModeleTexte( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CModeleTexte( System.Data.DataRow row )
			:base(row)
		{
		}
		//-------------------------------------------------------------------
		protected override void MyInitValeurDefaut()
		{
			Hauteur = 100;
			Largeur = 150;
			CouleurFond = Color.White;
		}
		//-------------------------------------------------------------------
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champLibelle};
		}
		//-------------------------------------------------------------------
		public override string DescriptionElement
		{
			get
			{
				return I.T( "Text Model @1|217",Libelle);
			}
		}
		//-------------------------------------------------------------------
		/// <summary>
		/// Libellé du modèle de texte.
		/// </summary>
		[
		TableFieldProperty(c_champLibelle, 255),
		DynamicField("Label")
		]
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
		/// Type d'élément associé à ce modèle (exemple : Members)
		/// </summary>
		[TableFieldProperty(c_champTypeAssocie,2000)]
		[DynamicField("Associated type")]
		public string TypeAssocieString
		{
			get
			{
				return (string)Row[c_champTypeAssocie];
			}
			set
			{
				Row[c_champTypeAssocie] = value;
			}
		}

		//-----------------------------------------------------------
		public Type TypeAssocie
		{
			get
			{
				return CActivatorSurChaine.GetType(TypeAssocieString);
			}
			set
			{
				if (value != null)
					TypeAssocieString = value.ToString();
				else
					TypeAssocieString = "";
			}
		}

		//-----------------------------------------------------------
        /// <summary>
        /// Libellé du type d'élément associé au modèle
        /// </summary>
		[DynamicField("Associated type label")]
		public string LibelleTypeAssocie
		{
			get
			{
				Type tp = TypeAssocie;
				if (tp != null)
					return DynamicClassAttribute.GetNomConvivial(tp);
				return "";
			}
		}

		/// /////////////////////////////////////////////////////////////
		[TableFieldProperty(CModeleTexte.c_champDataModele, NullAutorise = true)]
		public CDonneeBinaireInRow DataModeleInTable
		{
			get
			{
				if ( Row[c_champDataModele] == DBNull.Value )
				{
					CDonneeBinaireInRow donnee = new CDonneeBinaireInRow(ContexteDonnee.IdSession ,Row, c_champDataModele);
					CContexteDonnee.ChangeRowSansDetectionModification(Row, c_champDataModele, donnee);
				}
				return ((CDonneeBinaireInRow)Row[c_champDataModele]).GetSafeForRow(Row.Row);
			}
			set
			{
				Row[c_champDataModele] = value;
			}
		}

		/// /////////////////////////////////////////////////////////////
		public byte[] DataModele
		{
			get
			{
				byte[] retour = null;
				if (DataModeleInTable.Donnees != null)
					retour = DataModeleInTable.Donnees;
				return retour;
			}				
			set
			{
				CDonneeBinaireInRow data = DataModeleInTable;
				data.Donnees = value;
				DataModeleInTable = data;
			}
		}


		
		//-----------------------------------------------------------
		[TableFieldProperty(c_champCouleurFond)]
		public int CouleurFondInt
		{
			get
			{
				return (int)Row[c_champCouleurFond];
			}
			set
			{
				Row[c_champCouleurFond] = value;
			}
		}

		//-----------------------------------------------------------
		public Color CouleurFond
		{
			get
			{
				Color c = Color.FromArgb(CouleurFondInt);
				if (c.A == 0)
					c = Color.FromArgb(255, c);
				return c;
			}
			set
			{
				CouleurFondInt = value.ToArgb();
			}
		}


		
		//-----------------------------------------------------------
		/// <summary>
		/// Largeur de la fenêtre d'affichage pour un élément (pixels)
		/// </summary>
		[TableFieldProperty(c_champLargeur)]
		[DynamicField("Width")]
		public int Largeur
		{
			get
			{
				return (int)Row[c_champLargeur];
			}
			set
			{
				Row[c_champLargeur] = value;
			}
		}
		
		//-----------------------------------------------------------
		/// <summary>
		/// Hauteur de la fenêtre d'affichage pour un élément (pixel)
		/// </summary>
		[TableFieldProperty(c_champHauteur)]
		[DynamicField("Height")]
		public int Hauteur
		{
			get
			{
				return (int)Row[c_champHauteur];
			}
			set
			{
				Row[c_champHauteur] = value;
			}
		}

        //-----------------------------------------------------------
        /// <summary>
        /// Formule permettant d'afficher le texte
        /// </summary>
        [TableFieldProperty(CModeleTexte.c_champTexteParametre, 3000)]
        [DynamicField("Text model")]
        public string ModeleEnTexte
        {
            get
            {
                return (string)Row[c_champTexteParametre];
            }
            set
            {
                Row[c_champTexteParametre] = value;
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// Renvoie le texte pour l'entité passée en paramètre
        /// </summary>
        /// <param name="sourceObject">L'entité</param>
        /// <returns>Le texte calculé suivant la formule</returns>
        [DynamicMethod("Convert model into text", "Model source")]
        public string GetText ( object sourceObject )
        {
            string strText = ModeleEnTexte;

            strText = strText.Replace("\n", "\r\n");

            if (sourceObject == null)
                return ModeleEnTexte;
            CResultAErreur result = CResultAErreur.True;

            CFournisseurPropDynStd fournisseur = new CFournisseurPropDynStd();
            CContexteAnalyse2iExpression contexteAnalyse = new CContexteAnalyse2iExpression(fournisseur, sourceObject.GetType());
            CAnalyseurSyntaxiqueExpression analyseur = new CAnalyseurSyntaxiqueExpression(contexteAnalyse);

            CContexteEvaluationExpression contexteEval = new CContexteEvaluationExpression(sourceObject);
            //recherche les zones de formule
            int nPosStart = strText.IndexOf('{');
            while (nPosStart >= 0)
            {
                int nPosFin = strText.IndexOf("}", nPosStart);
                if (nPosFin > 0)
                {
                    string strFormule = strText.Substring(nPosStart, nPosFin-nPosStart+1);
                    //Supprime les accolades
                    strFormule = strFormule.Substring(1, strFormule.Length - 2);
                    result = analyseur.AnalyseChaine(strFormule);
                    string strRemplace = "###";
                    if (result)
                    {
                        C2iExpression exp = (C2iExpression)result.Data;
                        if (exp != null)
                        {
                            result = exp.Eval(contexteEval);
                            if (result)
                            {
                                if (result.Data != null)
                                {
                                    strRemplace = result.Data.ToString();
                                }
                                else
                                    strRemplace = "#NULL DATA?#";
                            }
                            else
                                strRemplace = "#" + result.MessageErreur + "#";
                        }
                        else
                            strRemplace = "#NULL C2iExpression!#";
                    }
                    else
                        strRemplace = "#" + result.MessageErreur + "#";

                    strText = strText.Remove(nPosStart, nPosFin - nPosStart + 1);
                    strText = strText.Insert ( nPosStart, strRemplace );
                    nPosFin = nPosStart + strRemplace.Length;
                }
                if (nPosFin < strText.Length)
                    nPosStart = strText.IndexOf('{');
                else
                    nPosStart = -1;
            }
            return strText;
        }
	}
}
