using System;
using System.Collections;

using sc2i.common;
using sc2i.data;

namespace timos.acteurs
{
	/// <summary>
	/// Role d'Acteur
	/// </summary>
	public class CRoleActeur : IComparable
	{
		//Tables associant les Id de roles aux roles
		private static Hashtable m_tableRoles = new Hashtable();

		private string m_strCodeRole = "";
		private string m_strLibelleRole = "";
		private Type   m_typeDonneeActeur = null;

		/// ////////////////////////////////////////////////////////
		private CRoleActeur(string strCodeRole, string strLibelleRole, Type typeDonneeActeur)
		{
			m_strCodeRole = strCodeRole;
			m_strLibelleRole = strLibelleRole;
			m_typeDonneeActeur = typeDonneeActeur;
		}

		/// ////////////////////////////////////////////////////////
		public static CRoleActeur GetRole ( string strCodeRole )
		{
			return (CRoleActeur)m_tableRoles[strCodeRole];
		}

		/// ////////////////////////////////////////////////////////
		public static string GetLibelleRole ( string strCodeRole )
		{
			CRoleActeur role = GetRole ( strCodeRole );
			if ( role != null )
				return role.Libelle;
			return "";
		}

		/// ////////////////////////////////////////////////////////
		public static Type GetTypeDonneesActeurRole ( string strCodeRole )
		{
			CRoleActeur role = GetRole ( strCodeRole );
			if ( role != null )
				return role.TypeDonneeActeur;
			return null;
		}
		/// ////////////////////////////////////////////////////////
		public override string ToString()
		{
			return m_strLibelleRole;
		}


		/// ////////////////////////////////////////////////////////
		public int CompareTo(object obj)
		{
			if (! (obj is CRoleActeur) ) 
				return 1;

			return ( this.Libelle.CompareTo( ((CRoleActeur)obj).Libelle) );
		}

		/// ////////////////////////////////////////////////////////
		[DynamicField("Label")]
		public string Libelle
		{
			get
			{
				return ToString();
			}
		}

		/// ////////////////////////////////////////////////////////
		[DynamicField("Code")]
		public string CodeRole
		{
			get
			{
				return (m_strCodeRole);
			}
		}

		/// /////////////////////////////////////////////////////////
		public Type TypeDonneeActeur
		{
			get
			{
				return m_typeDonneeActeur;
			}
		}

		/// /////////////////////////////////////////////////////////
		public string NomTableDonneesActeur
		{
			get
			{
				object[] attribs = TypeDonneeActeur.GetCustomAttributes ( typeof ( TableAttribute ), true );
				if ( attribs.Length == 0 )
					return "";
				return ((TableAttribute)attribs[0]).NomTable;
			}
		}
		
		
		/// /////////////////////////////////////////////////////////
		public override int GetHashCode()
		{
			return m_strCodeRole.GetHashCode();
		}

		/// /////////////////////////////////////////////////////////
		public override bool Equals ( object obj )
		{
			return CompareTo ( obj ) == 0;
		}

		///////////////////////////////////////////////////////////////
		public static CRoleActeur[] Roles
		{
			get
			{
				ArrayList lst = new ArrayList();
				foreach ( CRoleActeur role in m_tableRoles.Values )
				{
					lst.Add ( role );
				}
				lst.Sort();
				return (CRoleActeur[])lst.ToArray(typeof(CRoleActeur));
			}
		}

		///////////////////////////////////////////////////////////////
		public static void RegisterRole ( string strCodeRole, string strLibelleRole, Type typeDonneeActeur )
		{
			CRoleActeur role = GetRole(strCodeRole);
			if ( role != null && (role.Libelle != strLibelleRole || role.TypeDonneeActeur != role.TypeDonneeActeur ))
				throw new Exception(I.T( "The role '@1' id is not unique !|420",strCodeRole));
			role = new CRoleActeur ( strCodeRole, strLibelleRole, typeDonneeActeur );
			m_tableRoles[role.CodeRole] = role;
		}	
						
	}
}
