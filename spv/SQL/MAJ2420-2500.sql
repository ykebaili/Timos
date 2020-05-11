--=======================================================================================--
--                                                                                       --
--                           FICHIER MAJ2420-2500.SQL                                    --
--                                                                                       --
-- Mise à jour de la BDD superviseur en production de la version 2.4.20 à 2.5.0.0        --
--										 	 --
--=======================================================================================--

-- Cette mise à jour rétablit la structure de EQUIP_REP
-- qui n'a pas à être à ID numérique auto (ceci pose pb pour la réplication)
-- Elle remet donc le trigger TI_EQUIP tel qu'il était au préalable

-- Cette mise à jour est nécessaire pour les base de données en cours de test
-- à ce jour. Elles ne seront pas nécessaires sur une BDD récupérée de l'OPT

/*
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
*/


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
drop index pk_acces_accesc2;
alter table acces_accesc2 add constraint pk_acces_accesc2
    primary key (ACCES_ACCESC2_AUTO_ID) using index tablespace &1;

-- Mise à jour de la séquence sur acces_accesc2 en conséquence
-- dans SPV, cette séquence n'était pas exploitée
drop sequence seq_acces_accesc2;

declare
  valeur number;
  requete varchar2(256);
begin
  select max (acces_accesc2_auto_id) + 1 into valeur from acces_accesc2;
  requete := 'create sequence seq_acces_accesc2 start with ' || to_char (valeur);
  execute immediate requete;
end;
/


-- Mise à jour de la table famille
alter table FAMILLE add 
(
 famille_full_syscode		NVARCHAR2 (64),
 famille_partial_syscode	NVARCHAR2 (2),
 famille_level			NUMBER
);


-- Mise à jour des nouveaux champs FAMILLE_FULL_SYSCODE, FAMILLE_PARTIAL_SYSCODE, FAMILLE_LEVEL
-- pour les familles de MIB.
-- Ce script doit être appelé une fois les nouveaux champs créés

create or replace
PROCEDURE MajMibFamilleLevel (ParentFullCode varchar2, ParentLevel number, ParentId number) IS

	CURSOR cFamille IS
		SELECT * FROM famille 
		WHERE famille_classid = 14 AND (
                      (ParentId IS NULL AND famille_bindingid IS NULL) OR
		      (ParentId IS NOT NULL AND famille_bindingid = ParentId))
		ORDER BY famille_nom;

	Code		number;
	PartialCode	famille.famille_partial_syscode%TYPE;
	FamilleLevel	famille.famille_level%TYPE;
	FullCode	famille.famille_full_syscode%TYPE;

BEGIN
	-- Calcul du niveau dans la hiérarchie
	IF (ParentId IS NULL) THEN
		FamilleLevel := 1;
	ELSE
		FamilleLevel := TO_NUMBER (ParentLevel) + 1;
	END IF;


	Code := 0;

	FOR rcFamille IN cFamille LOOP

		Code := Code + 1;

		IF Code < 10 THEN
			PartialCode := LTRIM (TO_CHAR (Code, '09'));
		ELSIF Code + 55 < 91 THEN	-- correspond à Z
			PartialCode := '0' || CHR (Code + 55);
		ELSE
			raise_application_error (-20002, 'Code hors bornes');
		END IF;

		IF (ParentId IS NULL) THEN
			FullCode := PartialCode;
		ELSE
			FullCode := ParentFullCode || PartialCode;
		END IF;

		UPDATE famille SET famille_level 		= FamilleLevel, 
				   famille_partial_syscode	= PartialCode,
				   famille_full_syscode		= FullCode
		WHERE famille_id = rcFamille.famille_id;

		MajMibFamilleLevel (FullCode, FamilleLevel, rcFamille.famille_id);
	END LOOP;

END;
/

execute MajMibFamilleLevel (null, null, null);
commit;

drop procedure MajMibFamilleLevel;

    
-- alter table typeq add (SMTTYPEEQUIPEMENT_ID number);		fait dans CMiseAJourStructureBase
alter table equip drop column fabric_id;

alter table ACCES_ACCESC modify (alarmgeree_grave number);
alter table ACCES_ACCESC_REP modify (alarmgeree_grave number);

alter table prog_rep modify (PROG_OPER number);
alter table equip_rep modify (EQUIP_OPER number);
alter table EQUIP_REP
    add constraint fk1_equip_rep foreign key (EQUIP_ID)
       references EQUIP (EQUIP_ID);
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
/* Fait dans CMiseAJourStructureBase
alter trigger tiub_alarmgeree disable;
alter table ALARMGEREE add (tmp number);
update ALARMGEREE set tmp=ALARMGEREE_PROPAGER;
update ALARMGEREE set ALARMGEREE_PROPAGER=null;
alter table ALARMGEREE modify(ALARMGEREE_PROPAGER number(1,0)) ;
update ALARMGEREE set ALARMGEREE_PROPAGER=tmp;
alter table ALARMGEREE drop column tmp;
alter trigger tiub_alarmgeree enable;
*/

alter table site modify (site_ecran number);

create table sys_champ_auto
(
TABLE_NAME                     NVARCHAR2(25) NOT NULL ,                                                                                                                                                                                 
CHAMP_NAME                     NVARCHAR2(25) NOT NULL ,                                                                                                                                                                                 
TG_NAME                        NVARCHAR2(30) NOT NULL ,                                                                                                                                                                                 
SQ_NAME                        NVARCHAR2(30) NOT NULL  
);

alter table acces modify (ACCES_ETAT default 0);
update alarmgeree set alarmgeree_freqd = 1 where alarmgeree_freqd is null;
commit;
alter table alarmgeree modify (ALARMGEREE_FREQD not null);

--=======================================================================================--
-- FIN MAJ2420-2500.SQL
-- Aucune ligne ne doit suivre l'INSERT
--=======================================================================================--

INSERT INTO version (version_date, version_nom) 
	VALUES (SYSDATE, 'Version 2.5.0.0');

commit;
