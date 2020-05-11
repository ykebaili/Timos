using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.data;
using sc2i.common;
using timos.data;
using System.Data;
using timos.data.reseau.arbre_operationnel;
using timos.data.reseau.graphe;

namespace spv.data
{
    public class CSpvElementDeGrapheSousSchema : CSpvElementDeGraphe
    {
        

        public CSpvElementDeGrapheSousSchema(CContexteDonnee ctx)
            : base(ctx)
        {
        }

        public CSpvElementDeGrapheSousSchema(DataRow row)
            : base(row)
        {
        }

        protected override void MyInitValeurDefaut()
        {
            SetType(ETypeElementDeGrapheSpv.SousSchema);
        }

        public override CFiltreData FiltreStandard
        {
            get
            {
                return new CFiltreData(c_champType + "=@1",
                    (int)ETypeElementDeGrapheSpv.SousSchema);
            }
        }

        public CSchemaReseau SmtSchema
        {
            get
            {
                return _sys_SmtSchema;
            }
            set
            {
                _sys_SmtSchema = value;
            }
        }

        //-----------------------------------------------------------
        protected override CResultAErreur MyFillFromElementDeGraphe(CElementDeArbreOperationnel element)
        {
            CResultAErreur result = CResultAErreur.True;
            CElementDeArbreOperationnelSousSchema eltSousSchema = element as CElementDeArbreOperationnelSousSchema;
            if ( eltSousSchema == null)
            {
                result.EmpileErreur(I.T("Bad element type|20030"));
                return result;
            }
            CSchemaReseau schema = new CSchemaReseau(ContexteDonnee);
            if ( !schema.ReadIfExists ( eltSousSchema.IdSchema ) )
            {
                result.EmpileErreur(I.T("Can not find schema @1|20032", eltSousSchema.IdSchema.ToString()));
                return result;
            }
            SmtSchema = schema;
            _sys_CleNoeudArrivee = GetKeyNoeud(eltSousSchema.NoeudArrive);
            _sys_CleNoeudDepart = GetKeyNoeud(eltSousSchema.NoeudDepart);
            return result;
        }

        //-----------------------------------------------------------
        public string GetKeyNoeud(CNoeudDeGrapheReseau noeud)
        {
            if (noeud == null)
                return "";
            string strKey = noeud.GetType().ToString();
            strKey += "/" + noeud.IdSchemaReseau.ToString();
            strKey += "/" + noeud.IdObjet.ToString();
            return strKey;
        }

        //-----------------------------------------------------------
        private CNoeudDeGrapheReseau GetNoeudFromKey ( string strKey )
        {
            string[] strDatas = strKey.Split('/');
            if ( strDatas.Length != 3 )
                return null;
            Type tp = CActivatorSurChaine.GetType ( strDatas[0] );
            if ( tp == null )
                return null;
            try{
                int nIdSchema = Int32.Parse ( strDatas[1] );
                int nIdObjet = Int32.Parse ( strDatas[2] );
                CNoeudDeGrapheReseau noeud = Activator.CreateInstance ( tp, new object[]{nIdObjet, nIdSchema, false} ) as CNoeudDeGrapheReseau;
                return noeud;
            }
            catch ( Exception e )
            {
            }
            return null;
        }
        //-----------------------------------------------------------
        public CNoeudDeGrapheReseau NoeudDepart
        {
            get
            {
                return GetNoeudFromKey ( _sys_CleNoeudDepart );
            }
        }

        //-----------------------------------------------------------
        public CNoeudDeGrapheReseau NoeudArrive
        {
            get
            {
                return GetNoeudFromKey(_sys_CleNoeudArrivee);
            }
        }

        //-----------------------------------------------------------
        public override string GetStringDebugDescription()
        {
            string strTxt = "Sous schéma " + SmtSchema.Id + "/";
            CNoeudDeGrapheReseau noeud = NoeudDepart;
            if ( noeud == null )
                strTxt += "?";
            else
                strTxt += noeud.GetType().ToString()+"_"+noeud.IdObjet;
            noeud = NoeudArrive;
            strTxt += "->";
            if ( noeud == null )
                strTxt+="?";
            else
                strTxt += noeud.GetType().ToString()+"_"+noeud.IdObjet;
            return strTxt;           

        }

    }
}
