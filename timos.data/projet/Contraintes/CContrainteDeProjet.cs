using System;
using System.Collections;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Data;

using sc2i.data;
using sc2i.data.dynamic;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;

using tiag.client;

using timos.data;
using timos.data.projet.gantt;
using timos.data.projet.Contraintes;

namespace timos.data.projet.Contraintes
{
	/// <summary>
	/// Définit une contrainte liée à un projet
	/// </summary>
    [DynamicClass("Project constraint")]
	[Table(CContrainteDeProjet.c_nomTable, CContrainteDeProjet.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CContrainteDeProjetServeur")]
	public class CContrainteDeProjet : CObjetDonneeAIdNumeriqueAuto,
		IObjetALectureTableComplete,
        IContrainteDeProjet
	{
		public const string c_nomTable = "PROJECT_CONSTRAINT";
		public const string c_champId = "PRJ_CONST_ID";
        public const string c_champDate = "PRJ_CONST_DATE";
        public const string c_champMode = "PRJ_CONST_MODE";
        public const string c_champCle = "PRJ_CONST_KEY";
        public const string c_champCommentaire = "PRJ_CONST_COMMENT";
        public const string c_champReadOnly = "PRJ_CONST_RO";

		/// /////////////////////////////////////////////
		public CContrainteDeProjet( CContexteDonnee contexte)
			:base(contexte)
		{
		}
		
	/// /////////////////////////////////////////////
		public CContrainteDeProjet(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
                return I.T("Project Constraint @1|10015", Commentaire);
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champDate};
		}


        //-------------------------------------------------------------------
        /// <summary>
        /// Le Projet lié à la contrainte
        /// </summary>
        [Relation(
            CProjet.c_nomTable,
            CProjet.c_champId,
            CProjet.c_champId,
            true,
            true,
            false)]
        [DynamicField("Project")]
        public CProjet Projet
        {
            get
            {
                return (CProjet)GetParent(CProjet.c_champId, typeof(CProjet));
            }
            set
            {
                SetParent(CProjet.c_champId, value);
            }
        }


        //-----------------------------------------------------------
        /// <summary>
        /// La date de la contrainte
        /// </summary>
        [TableFieldProperty(c_champDate)]
        [DynamicField("Constraint date")]
        public DateTime Date
        {
            get
            {
                return (DateTime)Row[c_champDate];
            }
            set
            {
                Row[c_champDate] = value;
            }
        }


		//-----------------------------------------------------------
		/// <summary>
		/// 
		/// </summary>
		[TableFieldProperty ( c_champCle, 255 )]
		public string Cle
		{
			get
			{
				return (string)Row[c_champCle];
			}
			set
			{
				Row[c_champCle] = value;
			}
		}

        
		//-----------------------------------------------------------
		/// <summary>
		/// 
		/// </summary>
		[TableFieldProperty ( c_champCommentaire, 2000 )]
		public string Commentaire
		{
			get
			{
				return (string)Row[c_champCommentaire];
			}
			set
			{
				Row[c_champCommentaire] = value;
			}
		}



        //-----------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        [TableFieldProperty(c_champMode)]
        [DynamicField("Mode Int")]
        public int ModeInt
        {
            get
            {
                return (int)Row[c_champMode];
            }
            set
            {
                Row[c_champMode] = value;
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        public CModeContrainteDeGantt Mode
        {
            get
            {
                return new CModeContrainteDeGantt((EModeContrainteDeGantt)ModeInt);
            }
            set
            {
                ModeInt = value.CodeInt;
            }
        }

        //--------------------------------------------------------------
        public bool ContraintePropre
        {
            get
            {
                return true;
            }
        }

        //----------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        [TableFieldProperty(c_champReadOnly)]
        [DynamicField("Read Only")]
        public bool ReadOnly
        {
            get
            {
                return (bool)Row[c_champReadOnly];
            }
            set
            {
                Row[c_champReadOnly] = value;
            }
        }


    }
}
