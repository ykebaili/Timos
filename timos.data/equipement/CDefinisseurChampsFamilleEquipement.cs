using System;
using System.Collections.Generic;
using System.Text;
using sc2i.data.dynamic;
using sc2i.data;
using sc2i.common;

namespace timos.data.equipement
{
	public class CDefinisseurChampsFamilleEquipement : IDefinisseurChampCustomRelationObjetDonnee, IObjetAContexteDonnee
	{
		private CFamilleEquipement m_famille = null;
		private string m_strCodeRole = "";
		internal CDefinisseurChampsFamilleEquipement(CFamilleEquipement famille, string strCodeRole)
		{
			m_famille = famille;
			m_strCodeRole = strCodeRole;
		}

		//-------------------------------------------------------------
		public CFamilleEquipement Famille
		{
			get
			{
				return m_famille;
			}
		}

		//-------------------------------------------------------------
		public CListeObjetsDonnees RelationsChampsCustomListe
		{
			get 
			{
				CListeObjetsDonnees lst = m_famille.RelationsChampsCustomListe;
				lst.FiltrePrincipal = CFiltreData.GetAndFiltre ( lst.FiltrePrincipal,
					new CFiltreDataAvance(lst.NomTable, CChampCustom.c_nomTable+"."+CChampCustom.c_champCodeRole + "=@1",
					m_strCodeRole));
				return lst;
			}
		}

		//-------------------------------------------------------------
		public CListeObjetsDonnees RelationsFormulairesListe
		{
			get 
			{ 
				CListeObjetsDonnees lst = m_famille.RelationsFormulairesListe;
				StringBuilder blIds = new StringBuilder();
				foreach ( CRelationFamilleEquipement_Formulaire rel in lst )
					if (rel.Formulaire != null && rel.Formulaire.CodeRole == m_strCodeRole)
					{
						blIds.Append(rel.Id);
						blIds.Append(",");
					}
				if (blIds.Length != 0)
				{
					blIds.Remove(blIds.Length - 1,1);
					lst.Filtre = new CFiltreData ( CRelationFamilleEquipement_Formulaire.c_champId+" in ("+
						blIds.ToString()+")");
				}
				else
					lst.Filtre = new CFiltreDataImpossible();
				return lst;
			}
		}

		//-------------------------------------------------------------
		public sc2i.data.CContexteDonnee ContexteDonnee
		{
			get { return m_famille.ContexteDonnee; }
		}

        //-------------------------------------------------------------
        public IContexteDonnee IContexteDonnee
        {
            get
            {
                return ContexteDonnee;
            }
        }

		//-------------------------------------------------------------
		public string DescriptionElement
		{
			get { return m_famille.DescriptionElement; }
		}
		
		//-------------------------------------------------------------
		public int Id
		{
			get { return m_famille.Id; }
		}

		//---------------------------------------------------------------------------
		public IRelationDefinisseurChamp_ChampCustom[] RelationsChampsCustomDefinis
		{
			get
			{

				return (IRelationDefinisseurChamp_ChampCustom[])RelationsChampsCustomListe.ToArray(typeof(IRelationDefinisseurChamp_ChampCustom));
			}
		}

		//-------------------------------------------------------------------------
		public IRelationDefinisseurChamp_Formulaire[] RelationsFormulaires
		{
			get
			{
				return (IRelationDefinisseurChamp_Formulaire[])RelationsFormulairesListe.ToArray(typeof(IRelationDefinisseurChamp_Formulaire));
			}

		}

		//-------------------------------------------------------------
		public CRoleChampCustom RoleChampCustomDesElementsAChamp
		{
			get 
			{
				return CRoleChampCustom.GetRole(m_strCodeRole);
			}
		}

		//-------------------------------------------------------------
		public CChampCustom[] TousLesChampsAssocies
		{
			get 
			{
				return m_famille.GetTousLesChampsAssocies(m_strCodeRole);
			}
		}

		//-------------------------------------------------------------
		public static implicit operator CObjetDonneeAIdNumeriqueAuto(CDefinisseurChampsFamilleEquipement definisseur)
		{
			return definisseur.m_famille;
		}

		#region IObjetAContexteDonnee Membres

		CContexteDonnee IObjetAContexteDonnee.ContexteDonnee
		{
			get { return m_famille.ContexteDonnee; }
		}

		#endregion
	}
}
