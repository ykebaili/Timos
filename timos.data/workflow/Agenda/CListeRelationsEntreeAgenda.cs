using System;

using System.Collections;

using sc2i.common;
using sc2i.data;
using sc2i.common.planification;
using timos.data;
using timos.acteurs;

namespace sc2i.workflow
{

	public delegate CVisuEntreeAgenda[] CompleteVisusForPeriodeDelegate ( CListeRelationsEntreeAgenda liste,
																	DateTime dateDebut,
																	DateTime dateFin );

	/// <summary>
	/// Stocke une liste d'entrées de Agenda pour une liste d'éléments donnés.
	/// Les éléments doivent impérativement être du même type
	/// </summary>
	public class CListeRelationsEntreeAgenda : CListeObjetsDonnees
	{
		
		public CObjetDonneeAIdNumerique[] m_elementsAAgenda = new CObjetDonneeAIdNumerique[0];
		
		//-------------------------------------------------------
		public CListeRelationsEntreeAgenda( CObjetDonneeAIdNumerique element )
			:base (element.ContexteDonnee, typeof(CRelationEntreeAgenda_ElementAAgenda) )
		{
			Init ( new CObjetDonneeAIdNumerique[]{element} );
		}

		//-------------------------------------------------------
		public CObjetDonneeAIdNumerique[] ElementsAAgenda
		{
			get
			{
				return m_elementsAAgenda;
			}
		}

		public CListeRelationsEntreeAgenda( CContexteDonnee contexte, CObjetDonneeAIdNumerique[] elements )
			:base (contexte, typeof(CRelationEntreeAgenda_ElementAAgenda) )
		{
			Init ( elements );
		}


		/// //////
		public void Init( CObjetDonneeAIdNumerique[] elements)
		{
			m_elementsAAgenda = elements;
			if ( elements.Length == 0 )
				m_filtrePrincipal = new CFiltreDataImpossible();
			else
			{
				//Type->id à voir
				Hashtable tableTypeToIds = new Hashtable();
				Type tp = m_elementsAAgenda[0].GetType();
				foreach ( CObjetDonneeAIdNumerique objet in m_elementsAAgenda )
				{
					AddElementAVoir ( objet, tableTypeToIds );
					if ( objet is IElementAAgenda )
					{
						foreach ( string strProp in ((IElementAAgenda)objet).GetProprietesAccessSousElementsAgenda() )
						{
							ArrayList lst = CInterpreteurTextePropriete.CreateListePlateFrom ( objet, strProp );
							foreach ( CObjetDonneeAIdNumerique objFils in lst )
								AddElementAVoir ( objFils, tableTypeToIds );
						}
					}
						
				}

				m_filtrePrincipal = new CFiltreData ( );
				string strFiltre = "";
				int nVariable = 1;
				foreach ( DictionaryEntry dic in tableTypeToIds )
				{
					if ( strFiltre != "" )
						strFiltre += " or ";
					strFiltre += "("+CRelationEntreeAgenda_ElementAAgenda.c_champTypeElementAAgenda+"=@"+nVariable.ToString()+" and "+
						CRelationEntreeAgenda_ElementAAgenda.c_champIdElementAAgenda+" in ("+dic.Value.ToString()+"))";
					m_filtrePrincipal.Parametres.Add ( dic.Key.ToString() );
					nVariable++;
				}
				m_filtrePrincipal.Filtre = strFiltre;
			}
		}

		////////////////////////////////////////////////////////////
		private void AddElementAVoir ( object obj, Hashtable tableTypeToIds )
		{
			if ( obj is CObjetDonneeAIdNumerique )
			{
				Type tp = obj.GetType();
				string strListeIds =(string)tableTypeToIds[tp];
				if ( strListeIds == null )
					strListeIds = ((CObjetDonneeAIdNumerique)obj).Id.ToString();
				else
					strListeIds += ","+((CObjetDonneeAIdNumerique)obj).Id.ToString();
				tableTypeToIds[tp] = strListeIds;
			}
			else if ( typeof(IList).IsAssignableFrom (obj.GetType() ))
			{
				foreach ( object objFils in (IList)obj )
					AddElementAVoir ( objFils, tableTypeToIds );
			}
		}


		////////////////////////////////////////////////////////////
		private int GetNumVersion()
		{
			return 1;
		}

		////////////////////////////////////////////////////////////
		public override CResultAErreur Serialize ( C2iSerializer serializer )
		{
			CResultAErreur result = CResultAErreur.True;
			int nVersion = GetNumVersion();
			result = serializer.TraiteVersion ( ref nVersion );
			if ( result )
				result = base.Serialize(serializer);
			if ( !result )
				return result;
			
			
			bool bHasElement;
			#region Version 0 : un seul élément
			if ( nVersion == 0 )
			{
				CObjetDonneeAIdNumerique objet = null;
				if ( m_elementsAAgenda.Length > 0 )
					objet = m_elementsAAgenda[0];
				switch ( serializer.Mode )
				{
					case ModeSerialisation.Ecriture :
						bHasElement = objet != null;
						serializer.TraiteBool ( ref bHasElement );
						if ( bHasElement )
						{
							Type tp = objet.GetType();
							serializer.TraiteType(ref tp);
							int nId = objet.Id;
							serializer.TraiteInt ( ref nId );
						}
						break;
					case ModeSerialisation.Lecture :
						bHasElement = false;
						serializer.TraiteBool ( ref bHasElement );
						if ( !bHasElement )
							objet = null;
						else
						{
							Type tp = null;
							serializer.TraiteType ( ref tp );
							objet = (CObjetDonneeAIdNumerique)Activator.CreateInstance(tp, new object[]{m_contexte});
							int nId = 0;
							serializer.TraiteInt ( ref nId );
							if ( !objet.ReadIfExists ( nId ) )
								objet = null;
						}
						if ( objet == null )
							m_elementsAAgenda = new CObjetDonneeAIdNumerique[0];
						else
							m_elementsAAgenda = new CObjetDonneeAIdNumerique[]{objet};
						break;
				}
			}
			#endregion	
			return result;
		}

		////////////////////////////////////////////////////////////
		public static CompleteVisusForPeriodeDelegate CompleteVisusForPeriode;

		////////////////////////////////////////////////////////////
		public CVisuEntreeAgenda[] GetVisusForPeriode ( DateTime dtDebut, DateTime dtFin )
		{
			ArrayList lst = new ArrayList();
			CFiltreData oldFiltre = Filtre;
			CFiltreData filtre = new CFiltreDataAvance ( CRelationEntreeAgenda_ElementAAgenda.c_nomTable,
				CEntreeAgenda.c_nomTable+"."+
				CEntreeAgenda.c_champDateDebut+"<=@1 and ("+
				CEntreeAgenda.c_nomTable+"."+
				CEntreeAgenda.c_champDateFin+">=@2 "+
				"or ("+
				CEntreeAgenda.c_nomTable+"."+CEntreeAgenda.c_champIsCyclique+"=@4 and ("+
				CEntreeAgenda.c_nomTable+"."+CEntreeAgenda.c_champDateFinCyclique+">=@2 or "+
				"HasNo("+CEntreeAgenda.c_nomTable+"."+CEntreeAgenda.c_champDateFinCyclique+") )))"+
				" and "+
				CRelationTypeEntreeAgenda_TypeElementAAgenda.c_nomTable+"."+
				CRelationTypeEntreeAgenda_TypeElementAAgenda.c_champMasquerSurAgenda+"=@3",
				dtFin,
				dtDebut,
				false,
				true);
			Filtre = CFiltreData.GetAndFiltre ( filtre, oldFiltre );
			ReadDependances("EntreeAgenda");
			foreach ( CRelationEntreeAgenda_ElementAAgenda rel in this )
			{
				CEntreeAgenda entree = rel.EntreeAgenda;
				if ( !entree.IsCyclique )
					lst.Add ( new CVisuEntreeAgenda ( rel ) );
				else
				{
					lst.AddRange ( entree.GetVisusBetween ( rel.ElementLie, rel.RelationTypeEntree_TypeElement.Role, dtDebut, dtFin, true ));
				}
			}
			Filtre = oldFiltre;
			if ( CompleteVisusForPeriode != null )
				lst.AddRange ( CompleteVisusForPeriode ( this, dtDebut, dtFin ) );

			//Ajoute les interventions
			string strIdsRessource = "";
			string strIdsActeurs = "";
			Hashtable tableIdsActeurs = new Hashtable();
			Hashtable tableIdsRessource = new Hashtable();
			foreach ( CObjetDonneeAIdNumerique objet in m_elementsAAgenda )
			{
				if ( objet is CActeur )
				{
					strIdsActeurs += objet.Id.ToString()+";";
					tableIdsActeurs[objet.Id]= true;
				}
				if ( objet is CRessourceMaterielle )
				{
					strIdsActeurs += objet.Id.ToString()+";";
					tableIdsRessource[objet.Id] = true;
				}
			}
			if ( strIdsRessource.Length > 0 )
				strIdsRessource = strIdsRessource.Substring(0, strIdsRessource.Length-1);
			if ( strIdsActeurs.Length > 0 )
				strIdsActeurs = strIdsActeurs.Substring(0, strIdsActeurs.Length-1 );
			CListeObjetsDonnees listeFractionsInter = new CListeObjetsDonnees(ContexteDonnee, typeof(CFractionIntervention));
			string strFiltre = "";
			CFiltreDataAvance filtreInter = new CFiltreDataAvance ( CFractionIntervention.c_nomTable, "" );
			if ( strIdsActeurs.Length > 0 )
			{
				strFiltre += "("+CIntervention.c_nomTable+"."+
					CIntervention_Intervenant.c_nomTable+"."+
					CActeur.c_champId+" in ("+strIdsActeurs+"))";
			}
			if ( strIdsRessource.Length > 0 )
			{
				if ( strFiltre.Length > 0 )
					strFiltre += " or ";
				strFiltre += "("+CIntervention.c_nomTable+"."+
					CIntervention_Ressource.c_nomTable+"."+
					CRessourceMaterielle.c_champId+" in ("+strIdsRessource+"))";
			}
			if ( strFiltre.Length > 0 )
			{
				strFiltre += " and (";
				strFiltre += "(HasNo("+CFractionIntervention.c_champDateDebut+") and "+
					CFractionIntervention.c_champDateDebutPlanifie +"<= @1 and "+
					CFractionIntervention.c_champDateFinPlanifiee+">=@2) or ("+
					CFractionIntervention.c_champDateDebut+"<=@1 and "+
					CFractionIntervention.c_champDateFin+">=@2))";
				filtreInter.Parametres.Add(dtFin);
				filtreInter.Parametres.Add(dtDebut);
				filtreInter.Filtre = strFiltre;
				listeFractionsInter.Filtre = filtreInter;
				foreach ( CFractionIntervention fraction in listeFractionsInter )
				{
					foreach ( CIntervention_Intervenant rel in fraction.Intervention.RelationsIntervenants    )
					{
						if ( tableIdsActeurs.Contains ( rel.Intervenant.Id ) )
								lst.Add ( new CVisuEntreeAgenda ( 
								fraction, 
								null,
								rel.Intervenant,
								fraction.DateDebut == null ? fraction.DateDebutPlanifie : (DateTime)fraction.DateDebut,
								fraction.DateFin == null ? fraction.DateFinPlanifiee : (DateTime)fraction.DateFin));
					}
					foreach ( CIntervention_Ressource relRes in fraction.Intervention.RelationsRessourcesMaterielles )
					{
						if ( relRes.Ressource != null && tableIdsRessource.Contains ( relRes.Ressource.Id ) )
							lst.Add ( new CVisuEntreeAgenda ( 
								fraction,
								null,
								relRes.RessourceMaterielle,
								fraction.DateDebut == null ? fraction.DateDebutPlanifie : (DateTime)fraction.DateDebut,
								fraction.DateFin == null ? fraction.DateFinPlanifiee : (DateTime)fraction.DateFin));
					}
				}
			}
			return (CVisuEntreeAgenda[])lst.ToArray(typeof(CVisuEntreeAgenda));
		}
	}
}
