using System;
using sc2i.data;
using sc2i.win32.data;
using System.Collections.Generic;

namespace timos
{
	/// <summary>
	/// Description résumée de CFournisseurContexteDonnee.
	/// </summary>
	public class CFournisseurContexteDonnee : IFournisseurContexteDonnee
	{
		private static CFournisseurContexteDonnee m_instance = null;

        private Stack<CContexteDonnee> m_stackContextes = new Stack<CContexteDonnee>();

		/// ///////////////////////////////////////////////////////////////////
		private CFournisseurContexteDonnee()
		{
		}

		/// ///////////////////////////////////////////////////////////////////
		public static CFournisseurContexteDonnee GetInstance()
		{
			if ( m_instance == null )
				m_instance = new CFournisseurContexteDonnee();
			return m_instance;
		}

		/// ///////////////////////////////////////////////////////////////////
		public CContexteDonnee ContexteCourant
		{
			get
			{
                if( m_stackContextes.Count == 0 )
                {
                    CContexteDonnee ctx = new CContexteDonnee(CTimosApp.SessionClient.IdSession, true, true);
                    PushContexteCourant(ctx);
				}
				return m_stackContextes.Peek();
			}
		}


        #region IFournisseurContexteDonnee Membres


        public void PopContexteCourant()
        {
            m_stackContextes.Pop();
        }

        public void PushContexteCourant(CContexteDonnee contexte)
        {
            m_stackContextes.Push(contexte);
        }

        #endregion
    }
}
