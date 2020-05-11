using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using sc2i.data;
using sc2i.common;
using sc2i.expression;

namespace timos.tables
{

	public class CDataGridViewColonneFilterTest : CDataGridViewColonneFilterComponent
	{
		public CDataGridViewColonneFilterTest(DataGridViewColumn col)
			:base(col)
		{
			m_operateur = new COperateurTestFiltre(EOperateurTestFiltre.Egal);
			m_valeur = "";
		}

		private object m_valeur;
		private COperateurTestFiltre m_operateur;

		public object Valeur
		{
			get
			{
				return m_valeur;
			}
			set
			{
				m_valeur = value;
			}
		}
		public COperateurTestFiltre Operateur
		{
			get
			{
				return m_operateur;
			}
			set
			{
				m_operateur = value;
			}
		}

		public override EOperateurElementAComposantFiltre? FilsOperateur
		{
			get { return null; }
		}
		public override bool Valider(bool supprimerFilsNonValide)
		{
			if (base.m_col != null && m_valeur != null)
				return true;
			else
				return false;
		}

		public List<COperateurTestFiltre> OperateursPossibles
		{
			get
			{ 
				List<COperateurTestFiltre> operateurs = new List<COperateurTestFiltre>();
				Type t = m_col.ValueType;

				operateurs.Add(new COperateurTestFiltre(EOperateurTestFiltre.Egal));
				operateurs.Add(new COperateurTestFiltre(EOperateurTestFiltre.Different));
				
				if(t == typeof(string))
				{
					operateurs.Add(new COperateurTestFiltre(EOperateurTestFiltre.Contient));
					operateurs.Add(new COperateurTestFiltre(EOperateurTestFiltre.NeContientPas));
					operateurs.Add(new COperateurTestFiltre(EOperateurTestFiltre.CommencePar));
					operateurs.Add(new COperateurTestFiltre(EOperateurTestFiltre.TerminePar));
					operateurs.Add(new COperateurTestFiltre(EOperateurTestFiltre.NeCommencePasPar));
					operateurs.Add(new COperateurTestFiltre(EOperateurTestFiltre.NeTerminePasPar));
				}
				else if (t == typeof(int) || t == typeof(double) || t == typeof(DateTime))
				{
					operateurs.Add(new COperateurTestFiltre(EOperateurTestFiltre.PlusGrand));
					operateurs.Add(new COperateurTestFiltre(EOperateurTestFiltre.PlusGrandOuEgal));
					operateurs.Add(new COperateurTestFiltre(EOperateurTestFiltre.PlusPetit));
					operateurs.Add(new COperateurTestFiltre(EOperateurTestFiltre.PlusPetitOuEgal));
				}
				//else if (t==typeof(DateTime))
				//{
				//    operateurs.Add(new COperateurTestFiltre(EOperateurTestFiltre.PlusGrand));
				//    operateurs.Add(new COperateurTestFiltre(EOperateurTestFiltre.PlusGrandOuEgal));
				//    operateurs.Add(new COperateurTestFiltre(EOperateurTestFiltre.PlusPetit));
				//    operateurs.Add(new COperateurTestFiltre(EOperateurTestFiltre.PlusPetitOuEgal));
				//}
				//else if (t == typeof(bool))
				//{
				//    //operateurs.Add(new COperateurTestFiltre(EOperateurTestFiltre.Egal));
				//    //operateurs.Add(new COperateurTestFiltre(EOperateurTestFiltre.Different));
				//}

				operateurs.Add(new COperateurTestFiltre(EOperateurTestFiltre.Null));
				operateurs.Add(new COperateurTestFiltre(EOperateurTestFiltre.NonNull));

				return operateurs;
			}
		}

		public override CComposantFiltre GetComposantFiltre()
		{
			string idOperateur = "";
			object val = m_valeur;
			switch (m_operateur.Code)
			{
				case EOperateurTestFiltre.Egal:
					idOperateur = CComposantFiltreOperateur.c_IdOperateurEgal;
					break;
				case EOperateurTestFiltre.Different:
					idOperateur = CComposantFiltreOperateur.c_IdOperateurDifferent;
					break;
				case EOperateurTestFiltre.PlusPetit:
					idOperateur = CComposantFiltreOperateur.c_IdOperateurInf;
					break;
				case EOperateurTestFiltre.PlusGrand:
					idOperateur = CComposantFiltreOperateur.c_IdOperateurSup;
					break;
				case EOperateurTestFiltre.PlusPetitOuEgal:
					idOperateur = CComposantFiltreOperateur.c_IdOperateurInfEgal;
					break;
				case EOperateurTestFiltre.PlusGrandOuEgal:
					idOperateur = CComposantFiltreOperateur.c_IdOperateurSuperieurOuEgal;
					break;
				case EOperateurTestFiltre.Contient:
					idOperateur = CComposantFiltreOperateur.c_IdOperateurLike;
					val = "%" + val.ToString() + "%";
					break;
				case EOperateurTestFiltre.NeContientPas:
					idOperateur = CComposantFiltreOperateur.c_IdOperateurNotLike;
					val = "%" + val.ToString() + "%";
					break;
				case EOperateurTestFiltre.CommencePar:
					idOperateur = CComposantFiltreOperateur.c_IdOperateurLike;
					val = val.ToString() + "%";
					break;
				case EOperateurTestFiltre.NeCommencePasPar:
					idOperateur = CComposantFiltreOperateur.c_IdOperateurNotLike;
					val = val.ToString() + "%";
					break;
				case EOperateurTestFiltre.TerminePar:
					idOperateur = CComposantFiltreOperateur.c_IdOperateurLike;
					val = "%" + val.ToString();
					break;
				case EOperateurTestFiltre.NeTerminePasPar:
					idOperateur = CComposantFiltreOperateur.c_IdOperateurDifferent;
					val = "%" + val.ToString();
					break;
				case EOperateurTestFiltre.Null:
					idOperateur = CComposantFiltreOperateur.c_IdOperateurNull;
					break;
				case EOperateurTestFiltre.NonNull:
					idOperateur = CComposantFiltreOperateur.c_IdOperateurIsNotNull;
					break;
				default:
					break;
			}

			CComposantFiltre filtre;
			if(idOperateur == CComposantFiltreOperateur.c_IdOperateurIsNotNull)
			{
				CComposantFiltreHas has = new CComposantFiltreHas();
				has.Parametres.Add(new CComposantFiltreChamp(m_col.DataPropertyName, ""));
				filtre = has;

			}
			else if(idOperateur == CComposantFiltreOperateur.c_IdOperateurNull)
			{
				CComposantFiltreHasNo hasnot = new CComposantFiltreHasNo();
				hasnot.Parametres.Add(new CComposantFiltreChamp(m_col.DataPropertyName, ""));
				filtre = hasnot;
			}
			else
			{
				CComposantFiltreOperateur compar = new CComposantFiltreOperateur(idOperateur);
				compar.Parametres.Add(new CComposantFiltreChamp(m_col.DataPropertyName, ""));
				compar.Parametres.Add(new CComposantFiltreConstante(val));
				filtre = compar;
			}
			return filtre;
		}

	}
}
