using System;
using System.Collections.Generic;
using System.Text;
using sc2i.data;
using sc2i.common;
using sc2i.expression;
using System.Data;

namespace spv.data
{
    public interface IObjetSPVAvecObjetTimos
    {
        CObjetDonneeAIdNumerique ObjetTimosSansGenerique { get;}
        Type GetTypeObjetsTimos();
        Type GetTypeObjetsSpv();
        string GetChampIdObjetTimos();
    }
    /// <summary>
    /// Tout objet qui peut être mappé avec un objet Timos, via l'id auto de Timos
    /// </summary>
    /// <typeparam name="TypeTimos"></typeparam>
    /// <typeparam name="TypeSpv"></typeparam>
    public interface IMappableAvecObjetTimos<TypeTimos> : IObjetSPVAvecObjetTimos
        where TypeTimos : class, IObjetDonneeAIdNumerique
    {

        TypeTimos ObjetTimosAssocie { get;set;}

        void CopyFromObjetTimos(TypeTimos objetTimos);


    }

    public abstract class CMappableAvecTimos<TypeTimos, TypeSpv> : CObjetDonneeAIdNumeriqueAuto,
        IMappableAvecObjetTimos<TypeTimos>
        where  TypeTimos : class, IObjetDonneeAIdNumerique
        where  TypeSpv : class, IMappableAvecObjetTimos<TypeTimos>, IObjetDonneeAIdNumeriqueAuto
    {
        ///////////////////////////////////////////////////////////////
        public CMappableAvecTimos(CContexteDonnee contexte )
            :base ( contexte )
        {
        }

        ///////////////////////////////////////////////////////////////
        public CMappableAvecTimos(DataRow row )
            :base(row)
        {
        }

        ///////////////////////////////////////////////////////////////
		public static void CompleteProprietesObjetTimos(string strNomChampPourTimos)
		{
			CGestionnaireProprietesAjoutees.RegisterDynamicField(
				typeof(TypeTimos),
				strNomChampPourTimos,
				new CTypeResultatExpression(typeof(TypeSpv), false),
				new GetDynamicValueDelegate(GetObjetSpvFromObjetTimosPrivate),
				new SetDynamicValueDelegate(SetObjetSpvFromObjetTimosPrivate), "");
		}

        //-------------------------------------------------
        private static object GetObjetSpvFromObjetTimosPrivate(object objet)
		{
            return new CMappeurTimos<TypeTimos, TypeSpv>()
                .GetObjetSpvFromObjetTimos(objet as TypeTimos);
	    }

        //-------------------------------------------------
		private static CResultAErreur SetObjetSpvFromObjetTimosPrivate(object objet, object valeur)
		{
            return new CMappeurTimos<TypeTimos, TypeSpv>()
                .SetObjetSpvFromObjetTimos(objet as TypeSpv,
                valeur as TypeTimos);
		}

        //-------------------------------------------------
        public CObjetDonneeAIdNumerique ObjetTimosSansGenerique
        {
            get{
                return ObjetTimosAssocie as CObjetDonneeAIdNumerique;
            }
        }

        //-------------------------------------------------
        public static TypeSpv GetObjetSpvFromObjetTimos(TypeTimos objetTimos)
        {
            return GetObjetSpvFromObjetTimosPrivate(objetTimos) as TypeSpv;
        }
       
        //-------------------------------------------------
        public abstract string GetChampIdObjetTimos();

        //-------------------------------------------------
        public CMappeurTimos<TypeTimos, TypeSpv> GetMappeur()
        {
            return new CMappeurTimos<TypeTimos,TypeSpv>();
        }

        //-------------------------------------------------
        /// <summary>
        /// Retourne l'objet Timos associé
        /// </summary>
        protected TypeTimos ObjetTimosAssocieProtected
        {
            get
            {
                return GetParent(GetChampIdObjetTimos(), typeof(TypeTimos)) as TypeTimos;
            }
            set
            {
                SetParent(GetChampIdObjetTimos(), value as CObjetDonnee);
            }
        }

        //-------------------------------------------------
        /// <summary>
        /// Cette propriété est abstraite pour qu'on n'oublie pas
        /// de l'implémenter. Elle peut se contenter de rappeller ObjetTimosAssocieProtected,
        /// mais il faut surtout penser à l'attribut Relation
        /// </summary>
        public abstract TypeTimos ObjetTimosAssocie { get;set;}

        //-------------------------------------------------
        public abstract void CopyFromObjetTimos(TypeTimos objetTimos);

        //-------------------------------------------------
        public static TypeSpv GetObjetSpvFromObjetTimosAvecCreation(TypeTimos objetTimos)
        {
            return new CMappeurTimos<TypeTimos, TypeSpv>().GetObjetSpvFromObjetTimosAvecCreation(objetTimos) as TypeSpv;
        }

        //-------------------------------------------------
        public Type GetTypeObjetsTimos()
        {
            return typeof(TypeTimos);
        }

        //-------------------------------------------------
        public Type GetTypeObjetsSpv()
        {
            return typeof(TypeSpv);
        }
    }

    //---------------------------------------------------------------------------
    public interface IMappeurTimosNonGenerique
    {
        object GetObjetSpvFromObjetTimosAvecCreationSansGenerique(object objetTimos);
    }

    //---------------------------------------------------------------------------
    public class CMappeurTimos<TypeTimos, TypeSpv> : IMappeurTimosNonGenerique
        where TypeSpv : class, IMappableAvecObjetTimos<TypeTimos>, IObjetDonneeAIdNumeriqueAuto
        where TypeTimos : class, IObjetDonneeAIdNumerique
    {
        //Retourne l'objet SPV à partir de l'objet Timos
        public TypeSpv GetObjetSpvFromObjetTimos(TypeTimos objetTimos)
        {
			if (objetTimos != null)
			{
                TypeSpv objetSpv = Activator.CreateInstance(typeof(TypeSpv), objetTimos.ContexteDonnee) as TypeSpv;
                if (objetSpv.ReadIfExists(new CFiltreData(((IObjetSPVAvecObjetTimos)objetSpv).GetChampIdObjetTimos() + "=@1",
                    objetTimos.Id)))
                    return objetSpv;
			}
            return null;
        }

        public CResultAErreur SetObjetSpvFromObjetTimos(IMappableAvecObjetTimos<TypeTimos> objetSpv, TypeTimos objetTimos )
        {
            if ( objetSpv != null )
                objetSpv.ObjetTimosAssocie = objetTimos;
            return CResultAErreur.True;
        }

        public object GetObjetSpvFromObjetTimosAvecCreationSansGenerique(object objetTimos)
        {
            TypeTimos objetTimosType = objetTimos as TypeTimos;
            if ( objetTimosType != null )
                return GetObjetSpvFromObjetTimosAvecCreation(objetTimosType);
            return null;
        }

        public TypeSpv GetObjetSpvFromObjetTimosAvecCreation(TypeTimos objetTimos)
        {
            TypeSpv objetSpv = GetObjetSpvFromObjetTimos(objetTimos);
            if (objetSpv == null)
            {
                objetSpv = Activator.CreateInstance(typeof(TypeSpv), new object[]{objetTimos.ContexteDonnee}) as TypeSpv;
                objetSpv.CreateNewInCurrentContexte();
                objetSpv.ObjetTimosAssocie = objetTimos;
                objetSpv.CopyFromObjetTimos(objetTimos);
            }
            return objetSpv;
        }

    }
}
