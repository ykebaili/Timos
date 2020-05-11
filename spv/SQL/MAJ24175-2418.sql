--=======================================================================================--
--                                                                                       --
--                           FICHIER MAJ24175-2418.SQL                                    --
--                                                                                       --
-- Mise à jour de la BDD superviseur en production de la version 2.4.17.5 à 2.4.18           --
--										 	 --
--=======================================================================================--

-- La réplication impose une clé primaire par table répliquée
alter table LIAI_TOPSRC_TOPDST
add constraint pk_liai_topsrc_topdst primary key (FATHER_ID, FATHERCLASS_ID, LIAI_ID, TOPSRC_ID, TOPDST_ID)
using index tablespace &1;

---------------------------------------------
--
-- Création de la table PREMAIL
-- Permet de stocker des données avant de les expédier par mail
--
---------------------------------------------

create table PREMAIL
(
    PREMAIL_ID			NUMBER			not null,
    CLASS_ID			NUMBER			not null,
    BDD_ID			NUMBER			not null,
    constraint pk_premail primary key (PREMAIL_ID) 
	using index tablespace &1
);

create sequence SEQ_PREMAIL;


create table PREMAILDATA
(
    PREMAILDATA_ID		NUMBER			not null,
    PREMAIL_ID			NUMBER			not null,
    CH				VARCHAR2 (256)			,
    LIB				VARCHAR2 (80)			,
        constraint pk_premaildata primary key (PREMAILDATA_ID) 
	using index tablespace &1
);

create sequence SEQ_PREMAILDATA;

alter table PREMAILDATA
    add constraint fk1_premaildata foreign key (PREMAIL_ID)
       references PREMAIL (PREMAIL_ID);

alter table PREMAIL add (PREMAIL_OBJETNOM	VARCHAR2(40));

alter table PREMAIL modify (PREMAIL_OBJETNOM	not null);

alter table PREMAIL add (PREMAIL_EVT	NUMBER(2));

alter table PREMAIL modify (PREMAIL_EVT		not null);

alter table USERL add (USERL_MAILADDRESS	VARCHAR2(40));

alter table PREMAIL add (PREMAIL_SENT NUMBER(1)	DEFAULT 0
			 constraint ck_premail_premail_sent check (PREMAIL_SENT in (0,1)));

CREATE TABLE erreurapp
(
 erreurapp_id		NUMBER,
 erreurapp_date		DATE,
 erreurapp_traitement	VARCHAR2(80),
 erreurapp_message	VARCHAR2(512),
	constraint pk_erreurapp primary key (erreurapp_id)
		using index tablespace &1
);

CREATE SEQUENCE seq_erreurapp;
 

--=======================================================================================--
-- FIN MAJ24175-2418.SQL
-- Aucune ligne ne doit suivre l'INSERT
--=======================================================================================--

INSERT INTO version (version_date, version_nom) 
	VALUES (SYSDATE, 'Version 2.4.18');

commit;
