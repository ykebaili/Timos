using System;
using System.Collections.Generic;
using System.Text;
using sc2i.data.dynamic;
using sc2i.data;
using sc2i.common;

namespace timos.data.equipement
{
	public class CDefinisseurChampsTypeEquipement : IDefinisseurChampCustomRelationObjetDonnee, IObjetAContexteDonnee
	{
		private CTypeEquipement m_typeEquipement = null;
		private string m_strCodeRole = "";
		internal CDefinisseurChampsTypeEquipement(CTypeEquipement typeEquipement, string strCodeRole)
		{
			m_typeEquipement = typeEquipement;
			m_strCodeRole = strCodeRole;
		}

		//-------------------------------------------------------------
		public CTypeEquipement TypeEquipement
		{
			get
			{
				return m_typeEquipement;
			}
		}

		//-------------------------------------------------------------
		public CListeObjetsDonnees RelationsChampsCustomListe
		{
			get 
			{
				CListeObjetsDonnees lst = m_typeEquipement.RelationsChampsCustomListe;
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
				CListeObjetsDonnees lst = m_typeEquipement.RelationsFormulairesListe;
				StringBuilder blIds = new StringBuilder();
				foreach ( CRelationTypeEquipement_Formulaire rel in lst )
					if (rel.Formulaire != null && rel.Formulaire.CodeRole == m_strCodeRole)
					{
						blIds.Append(rel.Id);
						blIds.Append(",");
					}
				if (blIds.Length != 0)
				{
					blIds.Remove(blIds.Length - 1,1);
					lst.Filtre = new CFiltreData ( CRelationTypeEquipement_Formulaire.c_champId+" in ("+
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
			get { return m_typeEquipement.ContexteDonnee; }
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
			get { return m_typeEquipement.DescriptionElement; }
		}
		
		//-------------------------------------------------------------
		public int Id
		{
			get { return m_typeEquipement.Id; }
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
				return m_typeEquipement.GetTousLesChampsAssocies(m_strCodeRole);
			}
		}

		//-------------------------------------------------------------
		public static implicit operator CObjetDonneeAIdNumeriqueAuto(CDefinisseurChampsTypeEquipement definisseur)
		{
			return definisseur.m_typeEquipement;
		}

		#region IObjetAContexteDonnee Membres

		CContexteDonnee IObjetAContexteDonnee.ContexteDonnee
		{
			get { return m_typeEquipement.ContexteDonnee; }
		}

		#endregion
	}
}
