using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common.memorydb;
using System.Data;
using sc2i.common;
using sc2i.expression;
using sc2i.data.dynamic;

namespace TimosInventory.data
{
    [MemoryTable(CChampCustom.c_nomTable, CChampCustom.c_champId)]
    public class CChampCustom : CEntiteLieeATimos
    {
        #region Déclaration des constantes
        public const string c_nomTable = "CUSTOM_FIELD";
        public const string c_champId = "CUSTFLD_ID";
        public const string c_champNom = "CUSTFLD_NAME";
        public const string c_champType = "CUSTFLD_TYPE";
        public const string c_champValeurDefaut = "CUSTFLD_DEFAULT";
        public const string c_champPrecision = "CUSTFLD_PRECISION";
        public const string c_champFormuleValidation = "CUSTFLD_VALIDATION_FORMUL";
        public const string c_champInfoErreurFormat = "CUSTFLD_ERROR_TEXT";
        public const string c_champCodeRole = "CUSTFLD_ROLE";
        public const string c_champCodesRolesSecondaires = "CUSTFLD_SECONDARY_ROLES";


        #endregion


        /// ///////////////////////////////////////////////////////
        public CChampCustom(CMemoryDb db)
            : base(db)
        {
        }

        /// ///////////////////////////////////////////////////////
        public CChampCustom(DataRow row)
            : base(row)
        {
        }
        /// ///////////////////////////////////////////////////////
        public override void MyInitValeursParDefaut()
        {
            TypeDonnee = ETypeChampBasique.String;
            ValeurParDefautString = "";
            Precision = 0;
        }

        
        /// ///////////////////////////////////////////////////////
        public bool IsChoixParmis()
        {
            return ListeValeurs.Count() > 0;
        }


        /// ///////////////////////////////////////////////////////
        public bool IsChoixUtilisateur()
        {
            return true;
        }

        /// ///////////////////////////////////////////////////////
        public CResultAErreur VerifieValeur(object valeur)
        {
            return TesteValeur(valeur);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Le nom du champ personnalisé. Ce nom doit être unique dans toute la base de données
        /// </summary>
        [MemoryField(c_champNom)]
        public string Nom
        {
            get
            {
                return (string)Row[c_champNom];
            }
            set
            {
                Row[c_champNom] = value;
            }
        }

        ////////////////////////////////////////////////////////////
        [MemoryFieldAttribute(c_champType)]
        public int TypeDonneeCode
        {
            get
            {
                return Row.Get<int>(c_champType);
            }
            set
            {
                Row[c_champType] = value;
            }
        }

        ////////////////////////////////////////////////////////////
        public ETypeChampBasique TypeDonnee
        {
            get
            {
                return (ETypeChampBasique)TypeDonneeCode;
            }
            set
            {
                TypeDonneeCode = (int)value;
            }
        }


        /// ///////////////////////////////////////////////////////
        [MemoryField(c_champCodeRole)]
        public string CodeRole
        {
            get
            {
                return Row.Get<string>(c_champCodeRole);
            }
            set
            {
                Row[c_champCodeRole] = value;
            }
        }

        //-----------------------------------------------------------
        [MemoryField(c_champCodesRolesSecondaires)]
        public string CodesRolesSecondairesString
        {
            get
            {
                return (string)Row[c_champCodesRolesSecondaires];
            }
            set
            {
                Row[c_champCodesRolesSecondaires] = value;
            }
        }

        //-----------------------------------------------------------
        public bool HasRoleSecondaire(string strCodeRole)
        {
            return CodesRolesSecondairesString.Contains("~" + strCodeRole + "~");
        }

        //-----------------------------------------------------------
        public string[] CodesRolesSecondaires
        {
            get
            {
                string[] strCodes = CodesRolesSecondairesString.Split('~');
                List<string> lstCodes = new List<string>();
                foreach (string strCode in strCodes)
                {
                    if (strCode.Length > 0)
                        lstCodes.Add(strCode);
                }
                return lstCodes.ToArray();
            }
            set
            {
                if (value != null)
                {
                    StringBuilder bl = new StringBuilder();
                    foreach (string strCode in value)
                    {
                        bl.Append("~");
                        bl.Append(strCode);
                    }
                    if (bl.Length > 0)
                        bl.Append("~");
                    CodesRolesSecondairesString = bl.ToString();
                }
                else
                    CodesRolesSecondairesString = "";
            }
        }

        //------------------------------------------------------------------------
        public static CFiltreMemoryDb GetFiltreChampsForRole(string strCodeRole)
        {
            return new CFiltreMemoryDb(c_champCodeRole + "=@1 or " +
                c_champCodesRolesSecondaires + " like @2",
                strCodeRole,
                "%~" + strCodeRole + "~%");
        }

        ////////////////////////////////////////////////////////////
        [MemoryField(c_champValeurDefaut)]
        public string ValeurParDefautString
        {
            get
            {
                return (string)Row[c_champValeurDefaut];
            }
            set
            {
                Row[c_champValeurDefaut] = value;
            }
        }

        ////////////////////////////////////////////////////////////
        public object ValeurParDefaut
        {
            get
            {
                C2iExpression formuleDefaut = FormuleValeurParDefaut;
                if (formuleDefaut == null)
                    return null;
                CContexteEvaluationExpression ctx = new CContexteEvaluationExpression(null);
                CResultAErreur result = formuleDefaut.Eval(ctx);
                if (!result)
                    return CTypeChampBasique.StringToType(TypeDonnee, "0");
                if (result.Data == null)
                    return null;
                return CTypeChampBasique.StringToType (TypeDonnee, result.Data.ToString());
            }
        }


        ////////////////////////////////////////////////////////////
        public C2iExpression FormuleValeurParDefaut
        {
            get
            {
                if (ValeurParDefautString == "")
                    return null;
                C2iExpression exp = C2iExpression.FromPseudoCode(ValeurParDefautString);
                if (exp == null)
                    exp = new C2iExpressionConstante(ValeurParDefautString);
                return exp;
            }
            set
            {
                if (value == null)
                    ValeurParDefautString = "";
                else
                    ValeurParDefautString = C2iExpression.GetPseudoCode(value);
            }
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Indique une valeur de précision pour ce champ.
        /// </summary>
        /// <remark>
        /// Pour un champ de type "Décimal", cette valeur indique le nombre de chiffres qui seront présentés après la virgule.<BR>
        /// Pour un champ de type "Texte", cette valeur indique le nombre maximum de caractères qui seront autorisés lors de la saisie d'une 
        /// valeur pour ce champ.
        /// </remark>
        [
        MemoryField(c_champPrecision),
        DynamicField("Precision")
        ]
        public int Precision
        {
            get
            {
                return (int)Row[c_champPrecision];
            }
            set
            {
                Row[c_champPrecision] = value;
            }
        }


        /// ///////////////////////////////////////////////////////
        [MemoryField(c_champFormuleValidation)]
        public string FormuleValidationString
        {
            get
            {
                return Row.Get<string>(c_champFormuleValidation);
            }
            set
            {
                Row[c_champFormuleValidation] = value;
            }
        }

        /// ///////////////////////////////////////////////////////
        public C2iExpression FormuleValidation
        {
            get
            {
                if (FormuleValidationString == "")
                    return null;
                CStringSerializer str = new CStringSerializer(FormuleValidationString, ModeSerialisation.Lecture);
                C2iExpression exp = null;
                CResultAErreur result = str.TraiteObject<C2iExpression>(ref exp);
                if (result)
                    return exp;
                return null;
            }
            set
            {
                if (value == null)
                    FormuleValidationString = "";
                else
                {
                    CStringSerializer str = new CStringSerializer(ModeSerialisation.Ecriture);
                    C2iExpression exp = value;
                    CResultAErreur result = str.TraiteObject<C2iExpression>(ref exp);
                    if (result)
                        FormuleValidationString = str.String;
                }
            }
        }



        ////////////////////////////////////////////////////////////
        [MemoryField(c_champInfoErreurFormat)]
        public string TexteErreurFormat
        {
            get
            {
                return (string)Row[c_champInfoErreurFormat];
            }
            set
            {
                Row[c_champInfoErreurFormat] = value;
            }
        }


        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Indique la liste des valeurs possibles pour ce champ.
        /// </summary>
        [MemoryChild]
        public CListeEntitesDeMemoryDb<CValeurChampCustom> ListeValeurs
        {
            get
            {
                return GetFils<CValeurChampCustom>();
            }
        }

        ////////////////////////////////////////////////////////////
        public object ValueFromDisplay(string strDisplay)
        {
            foreach (CValeurChampCustom valeur in this.ListeValeurs)
            {
                if (valeur.Display == strDisplay)
                    return valeur.Value;
            }

            return null;
        }

        /// ///// ///// ///// ///// ///// ///// ///// ///// //
        public string DisplayFromValue(object value)
        {
            foreach (CValeurChampCustom valeur in this.ListeValeurs)
            {
                if (valeur.ValueString == CTypeChampBasique.TypeToString(value))
                    return valeur.Display;
            }

            return null;
        }

        ////////////////////////////////////////////////////////////
        public CResultAErreur IsCorrectValue(object value)
        {
            CResultAErreur result = CResultAErreur.True;

            if (value != null && !new CTypeChampBasique(TypeDonnee).IsDuBonType(value))
                return CResultAErreur.False;

            if (result)
                result = TesteValeur(value);

            if (!result)
                return result;

            if (this.ListeValeurs.Count() == 0)
                return result;


            if (DisplayFromValue(value) != null)
                return result;
            if (value != null)
                result.EmpileErreur(I.T("The value '@1' isn't a possible value|20002", value != null ? value.ToString() : "NULL"));
            return result;
        }

        /// ///// ///// ///// ///// ///// ///// ///// ///// //
        public override string ToString()
        {
            return Nom;
        }

        

       


        /// ///// ///// ///// ///// ///// ///// ///// ///// //
        protected CResultAErreur TesteValeur(object valeur)
        {
            CResultAErreur result = CResultAErreur.True;

            object obj = CObjetForTestValeurChampCustom.GetNewFor(this, valeur);
            if (obj == null)
            {
                result.EmpileErreur(I.T("Impossible to test the value '@1'|10008", valeur.ToString()));
                return result;
            }
            CContexteEvaluationExpression contexte = new CContexteEvaluationExpression(obj);
            result = FormuleValidation.Eval(contexte);
            if (!result)
                return result;
            if ((result.Data is bool && (bool)result.Data) || result.Data.ToString() == "1")
                return CResultAErreur.True;
            else
            {
                result.Data = null;
                if (TexteErreurFormat != string.Empty)
                    result.EmpileErreur(TexteErreurFormat);
                else
                    result.EmpileErreur(I.T("Incorect value in the field '@1'|244", this.Nom));
            }
            return result;
        }

        //------------------------------------------------------------------------------
        public void ClearAllCustomFieldValues()
        {

        }

        //------------------------------------------------------------------------------
        public string GetDisplayValue(object valeur)
        {
            if (valeur == null)
                return "";
            foreach (CValeurChampCustom v in ListeValeurs)
            {
                if (v != null)
                {
                    if (v.Value.Equals(valeur))
                    {
                        return v.Display;
                    }
                }
            }
            return "";
        }

        //-----------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //-----------------------------------------
        protected override CResultAErreur MySerialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            result = SerializeChamps(serializer, 
                c_champIdTimos,
                c_champNom, 
                c_champType,
                c_champValeurDefaut, 
                c_champPrecision, 
                c_champFormuleValidation, 
                c_champInfoErreurFormat,
                c_champCodeRole,
                c_champCodesRolesSecondaires);
            return result;
        }

        //-----------------------------------------
        public CChampCustom GetChampInMemoryDb(CMemoryDb db)
        {
            CChampCustom copie = new CChampCustom(db);
            if (!copie.ReadIfExist(Id))
            {
                copie = CCloner2iSerializable.Clone(this, null, new object[] { db }) as CChampCustom;
            }
            return copie;
        }


       

        
    }



}

