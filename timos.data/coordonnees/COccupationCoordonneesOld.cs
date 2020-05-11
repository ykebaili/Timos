using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;

namespace timos.data
{

	/// <summary>
	/// Description résumée de COccupationCoordonnees.
	/// </summary>
	public class COccupationCoordonneesOld
	{
		#region ++ Constructeurs ++
		public COccupationCoordonneesOld()
		{
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Occupation">Occupation de l'objet dans le systeme de coordonnee</param>
		/// <param name="Unite">Unite d'occupation de l'objet</param>
		public COccupationCoordonneesOld(int? Occupation, CUniteCoordonnee Unite)
		{
			this.m_occupation = Occupation;
			this.m_unite = Unite;
		}

		#endregion

		#region :: Propriétés ::
		private int? m_occupation;
		private CUniteCoordonnee m_unite; 
		#endregion

        #region >> Accesseurs <<

		/// /////////////////////////////////////////////
        [DynamicField("Occupation")]
        public int? Occupation
        {
            get { return this.m_occupation; }
            set { this.m_occupation = value; }
        }

		/// /////////////////////////////////////////////
        [DynamicField("Unit")]
		public CUniteCoordonnee Unite
        {
            get { return this.m_unite; }
            set { this.m_unite = value; }
        }

        #endregion

	}
}
