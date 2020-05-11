using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;

using tiag.client;

using timos.data;
using timos.securite;
using timos.data.securite;
using timos.acteurs;

namespace timos.data.securite
{

    /// <summary>
    /// toute entité qui permet de modifier les restrictions d'un utilisateur,
    /// par exemple, les acteurs, les groupes d'acteurs et les profils
    /// sont des IElementDonnantDesRestrictions
    /// </summary>
    public interface IElementDonnantDesRestrictions : IObjetDonneeAIdNumerique
    {
    }

	/// <summary>
	/// Indique à qui (<see cref="CActeur">acteur</see>, 
    /// <see cref="CGroupeActeur"> groupe d'acteur</see>, 
    /// <see cref="CProfilUtilisateur">profil utilisateur</see>) s'applique
    /// une restriction spécifique
	/// </summary>
    [DynamicClass("Element / Right / Application")]
	[Table(CRelationElement_RestrictionSpecifique_Application.c_nomTable, CRelationElement_RestrictionSpecifique_Application.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CRelationElement_RestrictionSpecifique_ApplicationServeur")]
	public class CRelationElement_RestrictionSpecifique_Application : CObjetDonneeAIdNumeriqueAuto
	{
        public const string c_nomTable = "ELEMENT_RESTRICT_APPLY";
		public const string c_champId = "ELTRSTAPP_ID";

		/// /////////////////////////////////////////////
		public CRelationElement_RestrictionSpecifique_Application( CContexteDonnee contexte)
			:base(contexte)
		{
		}
		
	/// /////////////////////////////////////////////
		public CRelationElement_RestrictionSpecifique_Application(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
                return I.T("Right apply|20140");
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champId};
		}

        //-------------------------------------------------------------------

        //-------------------------------------------------------------------
        /// <summary>
        /// Association entre un élément spécifique et une restriction
        /// auquel s'applique cette relation
        /// </summary>
        [Relation(
            CRelationElement_RestrictionSpecifique.c_nomTable,
            CRelationElement_RestrictionSpecifique.c_champId,
            CRelationElement_RestrictionSpecifique.c_champId,
            true,
            true,
            true)]
        [DynamicField("Element rights relation")]
        public CRelationElement_RestrictionSpecifique RelationElement_Restriction
        {
            get
            {
                return (CRelationElement_RestrictionSpecifique)GetParent(CRelationElement_RestrictionSpecifique.c_champId, typeof(CRelationElement_RestrictionSpecifique));
            }
            set
            {
                SetParent(CRelationElement_RestrictionSpecifique.c_champId, value);
            }
        }

	


        //-------------------------------------------------------------------
        /// <summary>
        /// Indique l'acteur qui a les restrictions spécifiques reférencés
        /// </summary>
        [Relation(
            CActeur.c_nomTable,
            CActeur.c_champId,
            CActeur.c_champId,
            false,
            true,
            true)]
        [DynamicField("Member")]
        public CActeur Acteur
        {
            get
            {
                return (CActeur)GetParent(CActeur.c_champId, typeof(CActeur));
            }
            set
            {
                SetParent(CActeur.c_champId, value);
                if (value != null)
                {
                    GroupeActeur = null;
                    ProfilUtilisateur = null;
                }
            }
        }


        //-------------------------------------------------------------------
        /// <summary>
        /// Indique le profil utilisateur qui a les restrictions spécifiques référencés
        /// </summary>
        [Relation(
            CProfilUtilisateur.c_nomTable,
            CProfilUtilisateur.c_champId,
            CProfilUtilisateur.c_champId,
            false,
            true,
            true)]
        [DynamicField("User profile")]
        public CProfilUtilisateur ProfilUtilisateur
        {
            get
            {
                return (CProfilUtilisateur)GetParent(CProfilUtilisateur.c_champId, typeof(CProfilUtilisateur));
            }
            set
            {
                SetParent(CProfilUtilisateur.c_champId, value);
                if (value != null)
                {
                    Acteur = null;
                    GroupeActeur = null;
                }
            }
        }


        //-------------------------------------------------------------------
        /// <summary>
        /// Groupe d'acteur qui a les restrictions spécifiques référencés
        /// </summary>
        [Relation(
            CGroupeActeur.c_nomTable,
            CGroupeActeur.c_champId,
            CGroupeActeur.c_champId,
            false,
            true,
            true)]
        [DynamicField("Member group")]
        public CGroupeActeur GroupeActeur
        {
            get
            {
                return (CGroupeActeur)GetParent(CGroupeActeur.c_champId, typeof(CGroupeActeur));
            }
            set
            {
                SetParent(CGroupeActeur.c_champId, value);
                if (value != null)
                {
                    Acteur = null;
                    ProfilUtilisateur = null;
                }
            }
        }

        //-------------------------------------------------------------------
        public IElementDonnantDesRestrictions ElementARestrictions
        {
            get
            {
                IElementDonnantDesRestrictions element = Acteur;
                if (element == null)
                    element = GroupeActeur;
                if (element == null)
                    element = ProfilUtilisateur;
                return element;
            }
            set
            {
                if (value is CActeur)
                    Acteur = (CActeur)value;
                if (value is CProfilUtilisateur)
                    ProfilUtilisateur = (CProfilUtilisateur)value;
                if (value is CGroupeActeur)
                    GroupeActeur = (CGroupeActeur)value;
            }
        }

	


	




	



		


	}
}
