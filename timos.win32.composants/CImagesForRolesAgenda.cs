using System;
using System.Windows.Forms;
using System.Drawing;	
using System.Collections;


using sc2i.workflow;
namespace timos.win32.composants
{
	/// <summary>
	/// Description résumée de CImagesForRolesAgenda.
	/// </summary>
	public class CImagesForRolesAgenda
	{
		private ImageList m_images = new ImageList();

		private Hashtable m_tableIdRoleToIndexImage = new Hashtable();

		/// ///////////////////////////////////////
		public CImagesForRolesAgenda()
		{
		}

		/// ///////////////////////////////////////
		public ImageList ImageList
		{
			get
			{
				return m_images;
			}
		}

		/// ///////////////////////////////////////
		public int GetIndexImageForRole ( IRoleSurEntreeAgenda role )
		{
			if ( role == null )
				return -1;
			object idImage = m_tableIdRoleToIndexImage[role.IdRole];
			if ( idImage != null && idImage is int)
				return (int)idImage;
			else
			{
				Image img = role.Image;
				if ( img != null )
				{
					m_images.Images.Add ( img );
					m_tableIdRoleToIndexImage[role.IdRole] = m_images.Images.Count-1;
					return m_images.Images.Count-1;
				}
				m_tableIdRoleToIndexImage[role.IdRole] = -1;
				return -1;
			}
		}


				

	}
}
