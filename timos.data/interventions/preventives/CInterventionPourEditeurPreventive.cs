using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using sc2i.data.dynamic;

namespace timos.data.preventives
{
	public class CInterventionPourEditeurPreventive
	{
		public CInterventionPourEditeurPreventive(CIntervention inter)
		{
			m_listeOp = new List<CListeOperations>();
			foreach(CIntervention_ListeOperations rel in inter.RelationsListesOperations)
				m_listeOp.Add(rel.ListeOperations);

			m_inter = inter;
			m_bRemove = false;
		}
		public CInterventionPourEditeurPreventive(string label, CSite site, List<CListeOperations> listeOp, DateTime dateDebut, DateTime dateFin, CTypeIntervention typeinter)
		{
			m_dateFin = dateFin;
			m_dateDebut = dateDebut;
			m_label = label;
			m_site = site;
			m_listeOp = listeOp;
			m_typeInter = typeinter;
			m_inter = null;
			m_bRemove = false;
		}


		private bool m_bRemove;
		public bool Deleted
		{
			get
			{
				return m_bRemove;
			}
			set
			{
				m_bRemove = value;
			}
		}

		public bool IsInDB
		{
			get
			{
				return InterventionInDB != null;
			}
		}

		private CIntervention m_inter;
		public CIntervention InterventionInDB
		{
			get
			{
				return m_inter;
			}
			set
			{
				m_inter = value;
			}
		}

		private CTypeIntervention m_typeInter;
		public CTypeIntervention TypeIntervention
		{
			get
			{
				if (IsInDB)
					return InterventionInDB.TypeIntervention;
				return m_typeInter;
			}
		}

		private DateTime m_dateDebut;
		public DateTime DateDebut
		{
			get
			{
				if (IsInDB)
					return InterventionInDB.DateDebutPrePlanifiee.Value;
				return m_dateDebut;
			}
		}
		private DateTime m_dateFin;
		public DateTime DateFin
		{
			get
			{
				if (IsInDB)
					return InterventionInDB.DateFinPrePlanifiee.Value;
				return m_dateFin;
			}
		}

		private CSite m_site;
		public CSite Site
		{
			get
			{
				if (IsInDB)
					return InterventionInDB.Site;
				return m_site;
			}
		}

		private string m_label;
		public string Label
		{
			get
			{
				if (IsInDB)
					return InterventionInDB.Libelle;
				return m_label;
			}
		}
		private List<CListeOperations> m_listeOp;
		public List<CListeOperations> ListesOperations
		{
			get
			{
				return m_listeOp;
			}
		}


		public CResultAErreur MAJChamps(CContexteDonnee ctx, string labelContrat)
		{
			CResultAErreur result = CResultAErreur.True;

			if (IsInDB)
			{
				if (Deleted)
					return InterventionInDB.Delete();
			}
			else
			{
				if (!Deleted)
				{
					CIntervention inter = new CIntervention(ctx);
					inter.CreateNewInCurrentContexte();
					inter.DateDebutPrePlanifiee = DateDebut;
					inter.DateFinPrePlanifiee = DateFin;
					inter.Libelle = Label;
					inter.TypeIntervention = TypeIntervention;
					inter.Site = Site;

					foreach (CListeOperations listeOp in ListesOperations)
					{
						CIntervention_ListeOperations rel = new CIntervention_ListeOperations(ctx);
						rel.CreateNewInCurrentContexte();
						rel.ListeOperations = listeOp;
						rel.Intervention = inter;
						rel.Libelle = I.T("@1 for contract @2|540", rel.ListeOperations.Libelle, labelContrat);
					}
					InterventionInDB = inter;
				}
			}
			return result;
		}

		private static bool IsNull(CInterventionPourEditeurPreventive inter)
		{
			try
			{
				bool b = inter.Deleted;
				return false;
			}
			catch
			{
				return true;
			}
		}

		public static bool operator ==(CInterventionPourEditeurPreventive inter, CInterventionPourEditeurPreventive inter2)
		{
			bool bInterNull = IsNull(inter);
			bool bInter2Null = IsNull(inter2);

			if (bInterNull && bInter2Null)
				return true;
			else if (bInterNull)
				return false;
			else if (bInter2Null)
				return false;
			else if (inter.IsInDB && inter2.IsInDB)
				return inter.InterventionInDB.Id == inter2.InterventionInDB.Id;
			else if (!inter.IsInDB && !inter2.IsInDB)
				return inter.Deleted == inter2.Deleted
					&& inter.Label == inter2.Label
					&& inter.Site.Id == inter2.Site.Id
					&& inter.TypeIntervention.Id == inter2.TypeIntervention.Id
					&& inter.DateDebut == inter2.DateDebut
					&& inter.DateFin == inter2.DateFin;
			else
				return false;

		}
		public static bool operator !=(CInterventionPourEditeurPreventive inter, CInterventionPourEditeurPreventive inter2)
		{
			return !(inter == inter2);
		}

        //---------------------------------------------------
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        //---------------------------------------------------
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        
	}
}
