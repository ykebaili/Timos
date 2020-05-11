using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace timos
{
	public class CBitmapStandards : IDisposable
	{
		private Bitmap m_imageLoupe = null;

		private static CBitmapStandards m_instance = null;

		private CBitmapStandards()
		{
		}

		private static CBitmapStandards GetInstance()
		{
			if (m_instance == null)
				m_instance = new CBitmapStandards();
			return m_instance;
		}


		public static Bitmap ImageLoupe
		{
			get
			{
				if (GetInstance().m_imageLoupe == null)
				{
					GetInstance().m_imageLoupe = new Bitmap(typeof(CCustomiseurFenetresStandard), "loupe2.bmp");
				}
				return GetInstance().m_imageLoupe;
			}
		}

		#region IDisposable Membres

		public void Dispose()
		{
			if (m_imageLoupe != null)
			{
				m_imageLoupe.Dispose();
				m_imageLoupe = null;
			}

		}

		#endregion
	}
}
