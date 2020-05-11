--=======================================================================================--
--                                                                                       --
--                           FICHIER MAJ2420-2500_Dev.SQL                                --
--                                                                                       --
-- Mise à jour de la BDD superviseur en production de la version 2.4.20 à 2.5.0.0        --
-- Pour la version de développement uniquement; pour l'OPT, utiliser MAJ2420-2500.SQL    --
--											 --
--=======================================================================================--
-- Cette mise à jour rétablit la structure de EQUIP_REP
-- qui n'a pas à être à ID numérique auto (ceci pose pb pour la réplication)
-- Elle remet donc le trigger TI_EQUIP tel qu'il était au préalable

-- Cette mise à jour est nécessaire pour les base de données en cours de test
-- à ce jour. Elles ne seront pas nécessaires sur une BDD récupérée de l'OPT

alter table EQUIP_REP drop constraint pk_equip_rep;
drop index pk_equip_rep;

alter table EQUIP_REP drop (EQUIP_REP_ID);
drop sequence SEQ_EQUIP_REP;

alter table EQUIP_REP add constraint
	pk_equip_rep primary key (EQUIP_ID)
	using index tablespace &1;

drop index EQUIP_REP_FK1;

delete SYS_CHAMP_AUTO where table_name = 'EQUIP_REP';
commit;

create table TypeqIpTrouve
(
  typeq_id number not null,
  address_ip varchar2(16) not null
);
alter table TypeqIpTrouve 
    add constraint fk1_TypeqIpTrouve foreign key (typeq_id) references typeq(typeq_id); 
    
alter table alarmgeree modify (alarmgeree_typson number);
alter table alarmgeree modify (alarmgeree_grave number);

alter table ACCES_ACCESC2 add (ACCES_ACCESC2_AUTO_ID number);
update acces_accesc2 set ACCES_ACCESC2_AUTO_ID=ACCES_ACCESC2_ID;
alter table ACCES_ACCESC2 modify (ACCES_ACCESC2_AUTO_ID not null);
alter table acces_accesc2 drop constraint pk_acces_accesc2;
alter table acces_accesc2 add constraint pk_acces_accesc2
    primary key (ACCES_ACCESC2_AUTO_ID) using index tablespace &1;
    
alter table typeq add (SMTTYPEEQUIPEMENT_ID number);
alter table equip drop column fabric_id;

alter table ACCES_ACCESC modify (alarmgeree_grave number);
alter table ACCES_ACCESC_REP modify (alarmgeree_grave number);

alter table prog_rep modify (PROG_OPER number);
alter table equip_rep modify (EQUIP_OPER number);
alter table site_rep modify (SITE_OPER number);
alter table liai_rep modify (LIAI_OPER number);
alter table PROG_OPER modify (PROG_OPER_GRAVE number);
alter table PROG_OPER_REP modify (PROG_OPER_GRAVE number);
alter table PROG_OPER_REP modify (PROG_OPER_GRAVE number);
alter table PROG modify (PROG_PERM number);
alter table PROG modify (PROG_ADMIN number);
alter table PROG modify (PROG_USE number);
alter table PROG_CABL modify (PROG_CABL_GRAVE number);
alter table PROG_CABL_REP modify (PROG_CABL_GRAVE number);
alter table SALLE modify (SALLE_NBAIE number);
alter table SITE drop column  SITE_FT;
alter table SITE modify (SITE_ADMIN number);
alter table SITE modify (SITE_USE number);
alter table SITE modify (SITE_OPER number);
alter table LIAI modify (LIAI_DIR number);
alter table LIAI modify (LIAI_OPER number);
alter table LIAI modify (LIAI_ADMIN number);
alter table LIAI modify (LIAI_USE number);
alter table MESSALRM modify (MESSALRM_NATURE number);
alter table ACCES_ACCESC modify (MSKADM_HOW number) ;
alter table ACCES_ACCESC2 modify (MSKADM_HOW number) ;
alter table TYPEQ modify (TYPEQ_ADMIN number);
alter table TYPEQ modify (TYPEQ_USE number);
alter table alarm drop column ALARM_AENV;
alter table alarm drop column ALARM_ENV;
alter table alarm modify ( ALARM_GRAVE number) ;
alter table TYPLIAI modify ( TYPLIAI_ADMIN number) ;
alter table TYPLIAI modify ( TYPLIAI_USE number) ;
alter table TYPPROG modify ( TYPPROG_NATURE number) ;
alter table TYPSITE modify ( TYPSITE_NATURE number) ;
alter table CABLEQU modify ( CABLEQU_ADMIN number) ;
alter table CABLEQU modify ( CABLEQU_OPER number) ;
alter table CABLEQU_EQUIP modify ( CABLEQU_EQUIP_FRONTIERE   number) ;
alter table equip drop column equip_oper;
alter table equip modify ( EQUIP_ADMIN number) ;
alter table equip modify ( EQUIP_USAGE number) ;
alter table equip modify ( EQUIP_ADMIN number) ;
alter table equip modify ( EQUIP_ADMIN number) ;

---ALARMGEREE_PROPAGER must be number(1,0)
alter trigger tiub_alarmgeree disable;
alter table ALARMGEREE add (tmp number);
update ALARMGEREE set tmp=ALARMGEREE_PROPAGER;
update ALARMGEREE set ALARMGEREE_PROPAGER=null;
alter table ALARMGEREE modify(ALARMGEREE_PROPAGER number(1,0)) ;
update ALARMGEREE set ALARMGEREE_PROPAGER=tmp;
alter table ALARMGEREE drop column tmp;
alter trigger tiub_alarmgeree enable;

alter table site modify (site_ecran number);

create table sys_champ_auto
(
TABLE_NAME                     NVARCHAR2(25) NOT NULL ,                                                                                                                                                                                 
CHAMP_NAME                     NVARCHAR2(25) NOT NULL ,                                                                                                                                                                                 
TG_NAME                        NVARCHAR2(30) NOT NULL ,                                                                                                                                                                                 
SQ_NAME                        NVARCHAR2(30) NOT NULL  
);


--=======================================================================================--
-- FIN MAJ2420-2500.SQL
-- Aucune ligne ne doit suivre l'INSERT
--=======================================================================================--

INSERT INTO version (version_date, version_nom) 
	VALUES (SYSDATE, 'Version 2.5.0.0');

commit;
