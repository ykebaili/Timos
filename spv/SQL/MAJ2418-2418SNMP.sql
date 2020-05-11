--==============================================================================================--
--                                                                                      	--
--                           FICHIER MAJ2418-2418SNMP.SQL                               		--
--                                                                                    		--
-- Mise à jour de la BDD superviseur en production de la version 2418  à la version -- 2418SNMP   	
--										      		--
--==============================================================================================--

CREATE TABLE MANAGER
(
  MANAGER_ID NUMBER NOT NULL,
  MANAGER_ADDRIP VARCHAR2(15),
  CONSTRAINT PK_MANAGER PRIMARY KEY(MANAGER_ID) USING INDEX  TABLESPACE &1
);

CREATE SEQUENCE SEQ_MANAGER START WITH 1;

CREATE TABLE MANAGER_OBJ
(
  	MANAGER_OBJ_ID NUMBER NOT NULL,
     	EQUIP_ID NUMBER, 
 	TYPEQ_ID NUMBER, 
	FABRIC_ID NUMBER,
     CONSTRAINT PK_MANAGER_OBJ PRIMARY KEY(MANAGER_OBJ_ID) USING INDEX  TABLESPACE &1, 
     CONSTRAINT FK1_MANAGER_OBJ FOREIGN KEY(EQUIP_ID) REFERENCES EQUIP(EQUIP_ID), 
     CONSTRAINT FK2_MANAGER_OBJ FOREIGN KEY(TYPEQ_ID) REFERENCES TYPEQ(TYPEQ_ID),
     CONSTRAINT FK3_MANAGER_OBJ FOREIGN KEY(FABRIC_ID) REFERENCES FABRIC(FABRIC_ID)     
);

CREATE SEQUENCE SEQ_MANAGER_OBJ START WITH 1;

CREATE TABLE MIBSCALVAR
(
	MIBSCALVAR_ID NUMBER NOT NULL,
 MIBOBJ_ID NUMBER NOT NULL,
 MIBVARSCAL_VAL VARCHAR2(4000),
 CONSTRAINT PK_MIBSCALVAR PRIMARY KEY(MIBSCALVAR_ID) USING INDEX TABLESPACE &1,
 CONSTRAINT FK_MIBSCALVAR FOREIGN KEY(MIBOBJ_ID) REFERENCES MIBOBJ(MIBOBJ_ID) 
);

CREATE SEQUENCE SEQ_MIBVARSCAL START WITH 1;

 
-----------------------------------------------------------------------------------------
create table trapalarm
(
	trapalarm_id 	number not null,
	alarm_id 	number not null,
	alarm_date 	varchar2(20) not null,
	alarm_grave 	number not null,
	alarmgeree_id 	number not null,
	alarmgeree_name varchar2(40) not null,
	equip_id 	number not null,
	trapalarm_sent  number(1) default (0) not null,
	constraint pk_trapalarm primary key (trapalarm_id) 
	using index tablespace &1,
	constraint ck_trapalarm_sent check (trapalarm_sent in (0,1))
);

alter table trapalarm
    add constraint fk1_trapalarm foreign key (alarm_id)
       references alarm (alarm_id);

alter table trapalarm
    add constraint fk2_trapalarm foreign key (alarmgeree_id)
       references alarmgeree (alarmgeree_id);

alter table trapalarm
    add constraint fk3_trapalarm foreign key (equip_id)
       references equip (equip_id);


create sequence seq_trapalarm;

insert into param values(seq_param.nextval, 9, 'FillTrapAlarm = 0', null);

--=======================================================================================--
-- FIN MAJ2418-2418SNMP.SQL
-- Aucune ligne ne doit suivre l'INSERT
--=======================================================================================--

INSERT INTO version (version_date, version_nom) 
	VALUES (SYSDATE, 'Version 2.4.18 SNMP');

commit;
