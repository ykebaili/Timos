using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using sc2i.drawing;

namespace timos.data.symbole.dynamique
{
    /// <summary>
    /// Paramètre de représentation dynamique d'un schéma de réseau
    /// </summary>
    public class CParametreRepresentationSchema : I2iSerializable
    {
        private Dictionary<Type, CParametreRepresentationSymbole> m_dicSymbolesParType = new Dictionary<Type, CParametreRepresentationSymbole>();

        //----------------------------------------------------------------
        public CParametreRepresentationSchema()
        {
        }

        //----------------------------------------------------------------
        public CParametreRepresentationSymbole this[Type tp]
        {
            get
            {
                CParametreRepresentationSymbole tmp = null;
                m_dicSymbolesParType.TryGetValue(tp, out tmp);
                return tmp;
            }
            set
            {
                if (value == null && m_dicSymbolesParType.ContainsKey(tp))
                    m_dicSymbolesParType.Remove(tp);
                else
                    m_dicSymbolesParType[tp] = value;
            }
        }

        //----------------------------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //----------------------------------------------------------------
        public CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            int nNbKeys = m_dicSymbolesParType.Count();
            serializer.TraiteInt(ref nNbKeys);
            switch (serializer.Mode)
            {
                case ModeSerialisation.Ecriture:
                    foreach (KeyValuePair<Type, CParametreRepresentationSymbole> kv in m_dicSymbolesParType)
                    {
                        Type tp = kv.Key;
                        CParametreRepresentationSymbole parametre = kv.Value;
                        serializer.TraiteType(ref tp);
                        result = serializer.TraiteObject<CParametreRepresentationSymbole>(ref parametre);
                        if (!result)
                            return result;
                    }
                    break;
                case ModeSerialisation.Lecture:
                    Dictionary<Type, CParametreRepresentationSymbole> dic = new Dictionary<Type, CParametreRepresentationSymbole>();
                    for (int nParametre = 0; nParametre < nNbKeys; nParametre++)
                    {
                        Type tp = null;
                        CParametreRepresentationSymbole parametre = null;
                        serializer.TraiteType(ref tp);
                        result = serializer.TraiteObject<CParametreRepresentationSymbole>(ref parametre);
                        if (!result)
                            return result;
                        if (parametre != null)
                            dic[tp] = parametre;
                    }
                    m_dicSymbolesParType = dic;
                    break;
            }
            return result;
        }

        public void AttacheToContexte(CContextDessinObjetGraphique ctx)
        {
            ctx.FonctionDessinSupplementaireApresObjet = new DessinSupplementaireDelegate(AfterDrawElement);
        }

        public bool AfterDrawElement(CContextDessinObjetGraphique ctx, C2iObjetGraphique objetGraphique)
        {
            C2iObjetDeSchema objetDessine = objetGraphique as C2iObjetDeSchema;
            if (objetDessine == null || objetDessine.ElementDeSchema == null)
                return true;
            IElementDeSchemaReseau elementDeSchema = objetDessine.ElementDeSchema.ElementAssocie;
            if (elementDeSchema == null)
                return true;
            Type tp = elementDeSchema.GetType();
            CParametreRepresentationSymbole parametre = this[tp];
            if (parametre == null)
                return true;
            parametre.Draw(ctx, elementDeSchema, objetGraphique);
            return true;
        }
    }
}
