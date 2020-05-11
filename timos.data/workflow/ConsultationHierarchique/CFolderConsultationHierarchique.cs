using System;
using System.Collections.Generic;
using System.Text;
using sc2i.common;
using sc2i.data;
using sc2i.expression;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using sc2i.drawing;
using sc2i.formulaire;

namespace timos.data.workflow.ConsultationHierarchique
{
	[Serializable]
	public abstract class CFolderConsultationHierarchique : I2iSerializable, IDisposable, IElementAVariableInstance
	{
        public const string c_strProprieteValue = "Value";

		private CFolderConsultationHierarchique m_folderParent = null;
		private List<CFolderConsultationHierarchique> m_listeSousFolders = new List<CFolderConsultationHierarchique>();
		private string m_strLibelle = I.T("Elements|20024");
		private C2iExpression m_expressionLibelle = null;
        private Image m_image = null;

        private Color m_couleur = Color.White;

		public CFolderConsultationHierarchique( CFolderConsultationHierarchique folderParent )
		{
			m_folderParent = folderParent;
		}

        public void Dispose()
        {
            if (m_image != null)
            {
                m_image.Dispose();
            }
            m_image = null;
        }

		public string Libelle
		{
			get
			{
				return m_strLibelle;
			}
			set
			{
				m_strLibelle = value;
			}
		}

        public virtual string GetLibelleNode(object source)
        {
            CContexteEvaluationExpression ctx = new CContexteEvaluationExpression(source);
            if (FormuleAffichage != null)
            {
                CResultAErreur result = FormuleAffichage.Eval(ctx);
                if (!result)
                    return result.Erreur.ToString();
                if (result.Data == null)
                    return "!!";
                return result.Data.ToString();
            }
            return "??";
        }

        //---------------------------------------------------------------
        public Color Couleur
        {
            get
            {
                return m_couleur;
            }
            set
            {
                m_couleur = value;
            }
        }

        //---------------------------------------------------------------
        public Image Image
        {
            get
            {
                if (m_image == null)
                    return null;
                return (Image)m_image.Clone();
            }
            set
            {
                if (m_image != null)
                    m_image.Dispose();
                m_image = null;
                if ( value != null )
                    m_image = CUtilImage.CreateImageImageResizeAvecRatio(value, new Size(16, 16), Color.White);
            }
        }

		public abstract object[] GetObjets ( CNodeConsultationHierarchique nodeParent, CContexteDonnee contexteDonnee);

		//---------------------------------------------------------------
		public void AddFolder(CFolderConsultationHierarchique folder)
		{
			if (!m_listeSousFolders.Contains(folder))
				m_listeSousFolders.Add(folder);
		}

		//---------------------------------------------------------------
		public void RemoveFolder(CFolderConsultationHierarchique folder)
		{
			m_listeSousFolders.Remove(folder);
		}

		//---------------------------------------------------------------
		public CFolderConsultationHierarchique[] SousFolders
		{
			get
			{
				return m_listeSousFolders.ToArray();
			}
		}

		//---------------------------------------------------------------
		public abstract Type TypeElements { get;}

		//---------------------------------------------------------------
		public C2iExpression FormuleAffichage
		{
			get
			{
				return m_expressionLibelle;
			}
			set
			{
				m_expressionLibelle = value;
			}
		}

		//---------------------------------------------------------------
		public CFolderConsultationHierarchique FolderParent
		{
			get
			{
				return m_folderParent;
			}
		}

		//---------------------------------------------------------------
		#region I2iSerializable Membres

		private int GetNumVersion()
		{
			return 2;
            //2 : ajout de l'image
		}

		public virtual CResultAErreur Serialize(C2iSerializer serializer)
		{
			int nVersion = GetNumVersion();
			CResultAErreur result = serializer.TraiteVersion(ref nVersion);
			if (!result)
				return result;

			serializer.TraiteString(ref m_strLibelle);
			result = serializer.TraiteListe<CFolderConsultationHierarchique>(m_listeSousFolders, this);
			if (!result)
				return result;
			result = serializer.TraiteObject<C2iExpression>(ref m_expressionLibelle);
			if (!result)
				return result;

            if (nVersion >= 1)
            {
                int nColor = m_couleur.ToArgb();
                serializer.TraiteInt(ref nColor);
                m_couleur = Color.FromArgb(nColor);
            }
            if (nVersion >= 2)
            {
                bool bHasImage = m_image != null;
                serializer.TraiteBool(ref bHasImage);
                if (bHasImage)
                {
                    byte[] data = null;
                    MemoryStream stream = null;
                    switch (serializer.Mode)
                    {
                        case ModeSerialisation.Ecriture:
                            stream = new MemoryStream();
                            m_image.Save(stream, ImageFormat.Png);
                            data = stream.ToArray();
                            serializer.TraiteByteArray(ref data);
                            stream.Close();
                            break;
                        case ModeSerialisation.Lecture:
                            serializer.TraiteByteArray(ref data);
                            try
                            {
                                stream = new MemoryStream(data);
                                Image = (Bitmap)Bitmap.FromStream(stream);
                            }
                            catch 
                            {
                            }
                            break;
                    }
                }
            }

			return result;

		}

		#endregion

        public CDefinitionProprieteDynamique[] GetProprietesInstance()
        {
            List<CDefinitionProprieteDynamique> lst = new List<CDefinitionProprieteDynamique>();
            if ( FolderParent != null )
            {
                if ( FolderParent.TypeElements != null )
                    lst.Add(new CDefinitionProprieteDynamiqueFolderHierarchiqueParent(FolderParent));
            }
            if ( TypeElements != null )
            {
                lst.Add(new CDefinitionProprieteDynamiqueDeportee(c_strProprieteValue, c_strProprieteValue,
                    new CTypeResultatExpression( TypeElements, false), true, true, "" ));
            }
            return lst.ToArray();
        }

        public abstract string FolderTypeName { get; }
        
    }
}
