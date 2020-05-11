using System;
using System.Collections;
using System.Linq;

using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;

using tiag.client;

using timos.data;
using System.IO;
using timos.data.workflow.ConsultationHierarchique;
using timos.data.projet.gantt;
using sc2i.data.dynamic;
using System.Collections.Generic;
using System.Text;

namespace timos.data.projet.gantt
{
	/// <summary>
	/// Définit une consultation hiérarchique qui permet de 
	/// naviguer parmis les éléments de la base de données
	/// de manière hiérarchique
	/// </summary>
    [DynamicClass("Gantt settings")]
	[Table(CParametrageGantt.c_nomTable, CParametrageGantt.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CParametrageGanttServeur")]
	public class CParametrageGantt : CObjetDonneeAIdNumeriqueAuto,
		IObjetALectureTableComplete
	{
		public const string c_nomTable = "GANTT_SETTINGS";
		public const string c_champId = "GANT_ID";
		public const string c_champLibelle = "GANT_LABEL";
		public const string c_champDataGroupe = "GANT_DATA";
        public const string c_champFiltre = "GANT_FILTER";

		/// /////////////////////////////////////////////
		public CParametrageGantt( CContexteDonnee contexte)
			:base(contexte)
		{
		}
		
	/// /////////////////////////////////////////////
		public CParametrageGantt(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T("Gantt settings @1|20056",Libelle);
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champLibelle};
		}


		

		/// <summary>
		/// Le libellé du parametrage Gantt
		/// </summary>
		[TableFieldProperty(c_champLibelle, 255)]
		[DynamicField("Label")]
		[TiagField("Label")]
		public string Libelle
		{
			get
			{
				return (string)Row[c_champLibelle];
			}
			set
			{
				Row[c_champLibelle] = value;
			}
		}

		// /////////////////////////////////////////////////////////
		[TableFieldProperty(CParametrageGantt.c_champDataGroupe, NullAutorise = true)]
		public CDonneeBinaireInRow DataGroupe
		{
			get
			{
				if (Row[c_champDataGroupe] == DBNull.Value)
				{
					CDonneeBinaireInRow donnee = new CDonneeBinaireInRow(ContexteDonnee.IdSession, Row, c_champDataGroupe);
					CContexteDonnee.ChangeRowSansDetectionModification(Row, c_champDataGroupe, donnee);
				}
				object obj = Row[c_champDataGroupe];
				return ((CDonneeBinaireInRow)obj).GetSafeForRow(Row.Row);
			}
			set
			{
				Row[c_champDataGroupe] = value;
			}
		}

        
		// /////////////////////////////////////////////////////////
        [BlobDecoder]
        public CParametreNiveauArbreGanttGroupe GroupeRacine
		{
			get
			{
				CDonneeBinaireInRow data = DataGroupe;
				if (data != null && data.Donnees != null)
				{
					MemoryStream stream = new MemoryStream ( data.Donnees );
					BinaryReader reader = new BinaryReader(stream);
					CSerializerReadBinaire serializer = new CSerializerReadBinaire(reader);

                    CParametreNiveauArbreGanttGroupe parametre = null;
                    CResultAErreur result = serializer.TraiteObject<CParametreNiveauArbreGanttGroupe>(ref parametre, new object[] { });
                    reader.Close();
                    stream.Close();
					if (result)
                        return parametre;
				}
                return null;
			}
			set
			{
				if (value == null)
				{
					CDonneeBinaireInRow data = DataGroupe;
					data.Donnees = null;
					DataGroupe = data;
				}
				else
				{
					MemoryStream stream = new MemoryStream();
					BinaryWriter writer = new BinaryWriter ( stream );
					CSerializerSaveBinaire serializer = new CSerializerSaveBinaire (writer);
                    CResultAErreur result = serializer.TraiteObject<CParametreNiveauArbreGanttGroupe>(ref value, null);
                    if (result)
                    {
                        CDonneeBinaireInRow donnee = DataGroupe;
                        donnee.Donnees = stream.ToArray();
                        DataGroupe = donnee;
                    }
                    writer.Close();
                    stream.Close();
				}
			}
		}

        // /////////////////////////////////////////////////////////
        [TableFieldProperty(CParametrageGantt.c_champFiltre, NullAutorise = true)]
        public CDonneeBinaireInRow DataFiltre
        {
            get
            {
                if (Row[c_champFiltre] == DBNull.Value)
                {
                    CDonneeBinaireInRow donnee = new CDonneeBinaireInRow(ContexteDonnee.IdSession, Row, c_champFiltre);
                    CContexteDonnee.ChangeRowSansDetectionModification(Row, c_champFiltre, donnee);
                }
                object obj = Row[c_champFiltre];
                return ((CDonneeBinaireInRow)obj).GetSafeForRow(Row.Row);
            }
            set
            {
                Row[c_champFiltre] = value;
            }
        }


        // /////////////////////////////////////////////////////////
        [BlobDecoder]
        public CFiltreDynamique FiltreElements
        {
            get
            {
                CDonneeBinaireInRow data = DataFiltre;
                if (data != null && data.Donnees != null)
                {
                    MemoryStream stream = new MemoryStream(data.Donnees);
                    BinaryReader reader = new BinaryReader(stream);
                    CSerializerReadBinaire serializer = new CSerializerReadBinaire(reader);

                    CFiltreDynamique filtre = null;
                    CResultAErreur result = serializer.TraiteObject<CFiltreDynamique>(ref filtre, new object[] { ContexteDonnee });
                    reader.Close();
                    stream.Close();
                    if (result)
                        return filtre;
                }
                CFiltreDynamique filtreDefaut = new CFiltreDynamique(ContexteDonnee);
                filtreDefaut.TypeElements = typeof(CProjet);
                return filtreDefaut;
            }
            set
            {
                if (value == null)
                {
                    CDonneeBinaireInRow data = DataFiltre;
                    data.Donnees = null;
                    DataFiltre = data;
                }
                else
                {
                    MemoryStream stream = new MemoryStream();
                    BinaryWriter writer = new BinaryWriter(stream);
                    CSerializerSaveBinaire serializer = new CSerializerSaveBinaire(writer);
                    CResultAErreur result = serializer.TraiteObject<CFiltreDynamique>(ref value, null);
                    if (result)
                    {
                        CDonneeBinaireInRow donnee = DataFiltre;
                        donnee.Donnees = stream.ToArray();
                        DataFiltre = donnee;
                    }
                    writer.Close();
                    stream.Close();
                }
            }
        }


        // /////////////////////////////////////////////////////////
        /// <summary>
        /// Le data du result contient un IBaseGantt
        /// </summary>
        /// <returns></returns>
        public static CResultAErreur CreateGantt ( 
            CProjet projet, 
            CParametreNiveauArbreGanttGroupe groupeRacine,
            CFiltreData filtreElements )
        {
            CResultAErreur result = CResultAErreur.True;
            if (projet == null)
                return result;
            CElementDeGanttProjet elementRacine = new CElementDeGanttProjet(null, projet);
            if (!result)
                return result;
            List<CProjet> lstProjets = new List<CProjet>();
            if (!projet.IsNew())//Si le projet est nouveau, on ne peut pas filtrer
                //car les éléments ne sont pas encore en base
            {
                CFiltreData filtre = result.Data as CFiltreData;
                filtre = CFiltreData.GetAndFiltre(filtreElements,
                    new CFiltreData(CProjet.c_champCodeSystemeComplet + " like @1 and " +
                        CProjet.c_champId + "<>@2",
                        projet.CodeSystemeComplet + "%",
                        projet.Id));
                CListeObjetsDonnees lstObjetProjets = new CListeObjetsDonnees(projet.ContexteDonnee, typeof(CProjet), filtre);

                lstObjetProjets.PreserveChanges = true;
                lstObjetProjets.ModeSansTri = true;
                lstProjets.AddRange(lstObjetProjets.ToList<CProjet>());


                lstObjetProjets.ReadDependances("ProjetsFils","LiensEnTantQueProjetA", "LiensEnTantQueProjetB", "ContraintesPropres", "AnomaliesDuProjet");
                CUtilElementAChamps.ReadChampsCustom(lstObjetProjets);
            }
            //Il faut ajouter les projets qui ne sont pas encore en base et qui n'ont donc pas de code system
            List<CProjet> lstALire = new List<CProjet>();
            lstALire.Add(projet);
            DataRelation relation = null;
            foreach ( DataRelation rel in projet.ContexteDonnee.Tables[CProjet.c_nomTable].ChildRelations )
            {
                if ( rel.ChildTable.TableName == CProjet.c_nomTable )
                {
                    relation = rel;
                    break;
                }
            }
            while (lstALire.Count > 0 && relation != null)
            {
                List<CProjet> prochaineGeneration = new List<CProjet>();
                foreach (CProjet test in lstALire)
                {
                    DataRow[] rowsDeps = test.Row.Row.GetChildRows(relation);
                    foreach (DataRow row in rowsDeps)
                    {
                        if (row.RowState != DataRowState.Deleted)
                        {
                            CProjet prj = new CProjet(row);
                            if (prj.IsNew() && !lstProjets.Contains(prj) )
                            {
                                lstProjets.Add(prj);
                                
                            }
                            prochaineGeneration.Add(prj);
                        }
                    }
                }
                lstALire = prochaineGeneration;
            }
           
            

            
            //Comme on est passé par un filtre Avancé, les nouveaux éléments ne sont
            //pas dans la liste. On les ajoute donc !
            //Vérifie qu'il y a des éléments dont l'id est négatif
            CListeObjetsDonnees lstTmp = new CListeObjetsDonnees(projet.ContexteDonnee,
                typeof(CProjet));
            lstTmp.Filtre = new CFiltreData(CProjet.c_champId + "<@1", 0);
            lstTmp.InterditLectureInDB = true;
            if (lstTmp.Count > 0)//Il y a des projets tous neufs dans le contexte
            {
                foreach (CProjet projetTmp in new ArrayList(lstProjets))
                {
                    //N'utilise pas ProjetsFils pour ne pas lire dans la base
                    CListeObjetsDonnees lstFils = new CListeObjetsDonnees(projet.ContexteDonnee,
                        typeof(CProjet),
                        new CFiltreData(CProjet.c_champIdParent + "=@1", projetTmp.Id));
                    lstFils.InterditLectureInDB = true;
                    lstFils.Filtre = new CFiltreData(CProjet.c_champId + "<0");
                    foreach (CProjet projetFils in lstFils)
                        if (!lstProjets.Contains(projetFils))
                            lstProjets.Add(projetFils);
                }
                //Les nouveaux sous projet du projet principal doivent également être ajoutés
                CListeObjetsDonnees lstFilsPrincipal = projet.ProjetsFils;
                lstFilsPrincipal.Filtre = new CFiltreData(CProjet.c_champId + "<0");
                foreach (CProjet projetFils in lstFilsPrincipal)
                    if (!lstProjets.Contains(projetFils))
                        lstProjets.Add(projetFils);
            }
            CContexteDonnee contexteDeTravail = projet.ContexteDonnee;

            return PrepareGantt(groupeRacine,result, elementRacine, lstProjets, contexteDeTravail);
        }

        // /////////////////////////////////////////////////////////
        /// <summary>
        /// Le data du result contient un IBaseGantt
        /// </summary>
        /// <returns></returns>
        public static CResultAErreur CreateGantt(
            CMetaProjet metaProjet,
            CParametreNiveauArbreGanttGroupe groupeRacine,
            CFiltreData filtreElements)
        {
            CResultAErreur result = CResultAErreur.True;
            if (metaProjet == null)
                return result;
            CElementDeGanttMetaProjet elementRacine = new CElementDeGanttMetaProjet(null, metaProjet);
            if (!result)
                return result;
            List<CProjet> lstProjets = new List<CProjet>();

            bool bLectureDansContexteCourant = false;
            //S'il y a des éléments modifiés, ajoutés ou supprimés dans
            //les relations, charge manuellement
            DataTable table = metaProjet.ContexteDonnee.GetTableSafe(CRelationMetaProjet_Projet.c_nomTable);
            if ( table != null )
            {
                if ( table.Select ( "", "", DataViewRowState.Added | DataViewRowState.Deleted | DataViewRowState.ModifiedCurrent ).Length > 0 )
                {
                    bLectureDansContexteCourant = true;
                    //Il y a des modifs, on ne peut donc pas appliquer le filtre,
                    //et on doit aller chercher les projets manuellement
                    foreach ( CRelationMetaProjet_Projet rel in metaProjet.RelationsProjets )
                    {
                        List<CProjet> lstTmp = new List<CProjet>();
                        lstTmp.Add ( rel.Projet );
                        while ( lstTmp.Count > 0 )
                        {
                            List<CProjet> lstSuivante = new List<CProjet>();
                            foreach ( CProjet prj in lstTmp )
                            {
                                lstProjets.Add ( prj );
                                lstSuivante.AddRange ( prj.ProjetsFils.ToList<CProjet>());
                            }
                            lstTmp = lstSuivante;
                        }
                    }
                }
            }
            if (!bLectureDansContexteCourant)
            {
                CFiltreData filtre = result.Data as CFiltreData;
                filtre = CFiltreData.GetAndFiltre(filtreElements,
                    new CFiltreDataAvance(
                        CProjet.c_nomTable,
                        CRelationMetaProjet_Projet.c_nomTable + "." +
                        CMetaProjet.c_champId + "=@1",
                        metaProjet.Id));

                filtre.IntegrerFilsHierarchiques = !metaProjet.HideChildProjects;
                CListeObjetsDonnees lstObjetProjets = new CListeObjetsDonnees(metaProjet.ContexteDonnee, typeof(CProjet), filtre);
                lstObjetProjets.PreserveChanges = true;
                lstObjetProjets.ModeSansTri = true;
                lstProjets.AddRange(lstObjetProjets.ToList<CProjet>());
                if ( metaProjet.HideChildProjects )
                    lstObjetProjets.ReadDependances("LiensEnTantQueProjetA.ProjetB", "LiensEnTantQueProjetB.ProjetA", "ContraintesPropres", "AnomaliesDuProjet");
                else
                    lstObjetProjets.ReadDependances("ProjetsFils", "LiensEnTantQueProjetA.ProjetB", "LiensEnTantQueProjetB.ProjetA", "ContraintesPropres", "AnomaliesDuProjet");
                CUtilElementAChamps.ReadChampsCustom(lstObjetProjets);
            }

            CContexteDonnee contexteDeTravail = metaProjet.ContexteDonnee;

            return PrepareGantt(groupeRacine, result, elementRacine, lstProjets, contexteDeTravail);
        }

        //--------------------------------------------------------------------------------------
        private static CResultAErreur PrepareGantt(
            CParametreNiveauArbreGanttGroupe groupeRacine, 
            CResultAErreur result, 
            CElementDeGantt elementRacine, 
            List<CProjet> lstProjets, 
            CContexteDonnee contexteDeTravail)
        {
            //Isole tous les projets qui n'ont pas leur parent dans la liste des sélectionnés
            HashSet<int> dicsIds = new HashSet<int>();
            foreach (CProjet prj in lstProjets)
                dicsIds.Add(prj.Id);

            /*IEnumerable<CProjet> lstSansRacine = from p in lstProjets
                                                 where
                                                 p.Row[CProjet.c_champIdParent] == DBNull.Value ||
                                                 !dicsIds.Contains((int)p.Row[CProjet.c_champIdParent])
                                                 select p;*/
            List<CProjet> lstSansRacine = new List<CProjet>();
            foreach (CProjet p in lstProjets)
            {
                if (p.Row[CProjet.c_champIdParent] == DBNull.Value ||
                   !dicsIds.Contains((int)p.Row[CProjet.c_champIdParent]))
                    lstSansRacine.Add(p);
            }
            //Crée tous les éléments projet(avant regroupement)           
            List<CElementDeGanttProjet> lstRacines = new List<CElementDeGanttProjet>();
            Dictionary<int, List<CProjet>> dicIdProjetToChild = new Dictionary<int, List<CProjet>>();
            foreach (CProjet projetTest in lstProjets)
            {
                if (projetTest.Row[CProjet.c_champIdParent] != DBNull.Value)
                {
                    int nId = (int)projetTest.Row[CProjet.c_champIdParent];
                    List<CProjet> lstChilds = null;
                    if (!dicIdProjetToChild.TryGetValue(nId, out lstChilds))
                    {
                        lstChilds = new List<CProjet>();
                        dicIdProjetToChild[nId] = lstChilds;
                    }
                    lstChilds.Add(projetTest);
                }
            }
            foreach (CProjet prj in lstSansRacine)
            {
                CElementDeGanttProjet eltProjet = new CElementDeGanttProjet(elementRacine, prj);
                eltProjet.AddChildsTrouvesParmis(dicIdProjetToChild);
                lstRacines.Add(eltProjet);
            }

            CParametreNiveauArbreGanttGroupe groupe = groupeRacine;
            if (groupe != null)
                groupe.RangeProjets(lstRacines, elementRacine);

            elementRacine.RegroupeBarresEnMulti();


            CBaseGantt baseGantt = new CBaseGantt(elementRacine);
            result.Data = baseGantt;
            //Création des liens
            StringBuilder blIdsProjets = new StringBuilder();
            Dictionary<int, CElementDeGantt> dicIdProjetToElements = new Dictionary<int, CElementDeGantt>(baseGantt.GetElements().Count());
            HashSet<CLienDeProjet> lstLiensConcernes = new HashSet<CLienDeProjet>();

            //IDentifie les relations vers les liens
            List<DataRelation> lstRelationsToLien = new List<DataRelation>();
            foreach (DataRelation rel in contexteDeTravail.Tables[CProjet.c_nomTable].ChildRelations)
            {
                if (rel.ChildTable.TableName == CLienDeProjet.c_nomTable)
                    lstRelationsToLien.Add(rel);
            }

            foreach ( IElementDeGantt elt in baseGantt.GetElements() )
            {
                foreach (IElementDeGantt eltDraw in elt.ElementsADessinerSurLaLigne)
                {
                    CElementDeGanttProjet eltPrj = eltDraw as CElementDeGanttProjet;
                    if (eltPrj != null)
                    {
                        int nId = eltPrj.ProjetAssocie.Id;
                        dicIdProjetToElements[nId] = eltPrj;
                        blIdsProjets.Append(nId);
                        blIdsProjets.Append(",");
                        foreach ( DataRelation rel in lstRelationsToLien )
                        {
                            DataRow[] rows = eltPrj.ProjetAssocie.Row.Row.GetChildRows ( rel );
                            foreach ( DataRow row in rows )
                                lstLiensConcernes.Add ( new CLienDeProjet ( row ));
                        }
                    }
                }
            }

            /*CListeObjetsDonnees lstLiensConcernes = new CListeObjetsDonnees(contexteDeTravail, typeof(CLienDeProjet));
            if (blIdsProjets.Length > 0)
            {
                blIdsProjets.Remove(blIdsProjets.Length - 1, 1);
                lstLiensConcernes.Filtre = new CFiltreData(CLienDeProjet.c_champPrjA + " in (" +
                    blIdsProjets.ToString() + ") or " +
                    CLienDeProjet.c_champPrjB + " in (" +
                    blIdsProjets.ToString() + ")");
            }
            else
                lstLiensConcernes.Filtre = new CFiltreDataImpossible();
            lstLiensConcernes.InterditLectureInDB = true;
            lstLiensConcernes.AssureLectureFaite();*/
            foreach (CLienDeProjet lien in lstLiensConcernes)
            {
                CElementDeGantt eltPredecesseur = null;
                CElementDeGantt eltSuccesseur = null;
                if (dicIdProjetToElements.TryGetValue(lien.ProjetA.Id, out eltPredecesseur) &&
                    dicIdProjetToElements.TryGetValue(lien.ProjetB.Id, out eltSuccesseur))
                {
                    eltSuccesseur.AddPredecesseurSansCreation(eltPredecesseur);
                }
            }
            

            
            try
            {
                elementRacine.RecalculAvancement();
            }
            catch (Exception e)
            {
            }
            return result;
        }


	}
}
