create or replace
PACKAGE PACK_ALARME AS
    c_debordement CONSTANT VARCHAR2(11) := 'Debordement';
    SUBTYPE alarme_nature_t IS NUMBER(1);
    
    c_alarme_autonome CONSTANT alarme_nature_t := 0;
    c_alarme_mere     CONSTANT alarme_nature_t := 1;
    c_alarme_fille    CONSTANT alarme_nature_t := 2;
    
    PROCEDURE maj_oper (Id NUMBER, SiteId NUMBER, EquipId NUMBER,
                        LiaiId NUMBER, AlarmLocal NUMBER, AlarmGrave NUMBER,
                        is_commut spv_types.is_commut_t,
                        EltSiteId IN OUT NUMBER, EltSiteNom IN OUT NOCOPY VARCHAR2, 
                        EltTypeId IN OUT NUMBER, EltTypeNom IN OUT NOCOPY VARCHAR2, 
                        EltId IN OUT NUMBER, EltNom IN OUT NOCOPY VARCHAR2,
                        infos_diag_table IN OUT NOCOPY diagramme.infos_diag_t);
                        
    PROCEDURE mess_alrm (Mess IN OUT NOCOPY VARCHAR2,
                          IdEvt NUMBER, IdAlarmData NUMBER, AlarmIddeb NUMBER, AlGereeId NUMBER, SiteId NUMBER, EquipId NUMBER,
                          LiaiId NUMBER, AlarmNum NUMBER, AlarmCl VARCHAR2, AlarmNumObj NUMBER,
                          AlarmType NUMBER, AlarmDate VARCHAR2, AlarmGrave NUMBER, AlarmNseuil VARCHAR2,
                          AlarmVseuil	NUMBER, AlarmNumal VARCHAR2, AlarmTexte NUMBER, AlarmInfo VARCHAR2,
                          AlarmNomL VARCHAR2, AlarmComment VARCHAR2, is_commut spv_types.is_commut_t,
                          ProgNom VARCHAR2, ClientNom VARCHAR2, ProgOper VARCHAR2,
                          EltSiteNom VARCHAR2, EltTypeNom VARCHAR2, EltPosNom VARCHAR2, TsPrOper VARCHAR2,
                          Sonne NUMBER, Acquit NUMBER, Acquittee NUMBER, stBindingVarInfo VARCHAR2);
    
    PROCEDURE formate (infos_diag_table diagramme.infos_diag_t, 
                       CliConc IN OUT NOCOPY VARCHAR2, PrConc IN OUT NOCOPY VARCHAR2, 
                       PrConcAl3 IN OUT NOCOPY VARCHAR2, PrEtat IN OUT NOCOPY VARCHAR2,
                       TsPrOper IN OUT NOCOPY VARCHAR2);
    
    PROCEDURE post_alrm (IdEvt NUMBER, IdAlarmData NUMBER, AlGereeId NUMBER, SiteId NUMBER, EquipId NUMBER,
                        LiaiId NUMBER, AlarmNum NUMBER, AlarmCl VARCHAR2, AlarmNumObj NUMBER, 
                        AlarmType NUMBER, AlarmDate VARCHAR2, AlarmGrave NUMBER, AlarmNseuil VARCHAR2,
                        AlarmVseuil	NUMBER, AlarmNumal VARCHAR2, AlarmTexte NUMBER, AlarmInfo VARCHAR2,
                        AlarmNomL VARCHAR2, AlarmComment VARCHAR2, AlarmLocal NUMBER, 
                        is_commut spv_types.is_commut_t,
                        AlarmIddeb NUMBER, CablSId NUMBER, CablPId NUMBER, Sonne NUMBER, Acquit NUMBER,
                        Acquittee NUMBER, Iana NUMBER, ClasseObjetEnDefaut NUMBER); 
                        
    PROCEDURE start_alrm (IdEvt NUMBER, IdAlarmData NUMBER, AlGereeId NUMBER, SiteId NUMBER,
                          EquipId NUMBER, LiaiId NUMBER, AlarmNum NUMBER, AlarmCl VARCHAR2, AlarmNumObj NUMBER,
                          AlarmType NUMBER, AlarmDate VARCHAR2, AlarmGrave NUMBER, AlarmNseuil VARCHAR2,
                          AlarmVseuil	NUMBER, AlarmNumal VARCHAR2, AlarmTexte NUMBER, AlarmInfo VARCHAR2,
                          AlarmNomL VARCHAR2, AlarmComment VARCHAR2, AlarmLocal NUMBER, 
                          is_commut spv_types.is_commut_t,
                          AlarmIddeb NUMBER, CablSId NUMBER, CablPId NUMBER, Acquittee NUMBER, Iana NUMBER,
                          infos_diag_table IN OUT NOCOPY diagramme.infos_diag_t);
                          
    PROCEDURE stop_alrm (Mess IN OUT NOCOPY VARCHAR2, Id NUMBER, AlGereeId NUMBER,
                         SiteId NUMBER, EquipId NUMBER, LiaiId NUMBER,
                         AlarmCl VARCHAR2, AlarmNumObj NUMBER, AlarmNumal VARCHAR2, 
                         infos_diag_table IN OUT NOCOPY diagramme.infos_diag_t);
    
    FUNCTION correl_alrm (Mess IN OUT NOCOPY VARCHAR2,
                          IdEvt NUMBER, IdAlarmData NUMBER, SiteId NUMBER, EquipId NUMBER, LiaiId NUMBER, 
                          DateAlSec NUMBER, AlarmGrave NUMBER, AlarmIddeb NUMBER, 
                          infos_diag_table IN OUT NOCOPY diagramme.infos_diag_t) RETURN BOOLEAN;
                          
    PROCEDURE mask_alrm (Mess IN OUT NOCOPY VARCHAR2,
                         AlarmCl VARCHAR2, AlarmNumObj NUMBER, AlarmNumal VARCHAR2, AlarmGrave NUMBER,
                         SiteId NUMBER, EquipId NUMBER, LiaiId NUMBER,
                         infos_diag_table IN OUT NOCOPY diagramme.infos_diag_t);
                         
    FUNCTION AlarmNature (IdAlarmeData NUMBER) RETURN alarme_nature_t;

    FUNCTION IsMaskedLiai (LiaiId1 NUMBER, LiaiId2 NUMBER) RETURN BOOLEAN;
    
    FUNCTION IsMaskedBy (Id1 NUMBER, EquipId1 NUMBER, LiaiId1 NUMBER,
                         Id2 NUMBER, EquipId2 NUMBER, LiaiId2 NUMBER) RETURN BOOLEAN;
END PACK_ALARME;
