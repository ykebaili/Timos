--==============================================================================================--
--                                                                                      	--
--                           FICHIER MAJ2416b-2416c.SQL                               		--
--                                                                                    		--
-- Mise à jour de la BDD superviseur en production de la version MAJ2416b à la version 2416c   	--
--										      		--
--==============================================================================================--


ALTER TABLE CONTROL ADD
(
	CONTROL_COMMANDE	VARCHAR2(512)
);


CREATE TABLE CONTROLDIST
(
	CONTROLDIST_ID			NUMBER	NOT NULL,
	CONTROL_ID			NUMBER  NOT NULL,
	CONTROLDIST_MACHINE		VARCHAR2(40),
	CONTROLDIST_USER		VARCHAR2(40),
	CONTROLDIST_MDP			VARCHAR2(40),
	CONTROLDIST_PYTHONPATH 		VARCHAR2(256),
	CONTROLDIST_PYTHONWINPATH	VARCHAR2(256),
	CONTROLDIST_SCRIPTPATH		VARCHAR2(256),
	constraint PK_CONTROLDIST primary key (CONTROLDIST_ID)
);

ALTER TABLE CONTROLDIST ADD CONSTRAINT FK1_CONTROLDIST FOREIGN KEY (CONTROL_ID)
	REFERENCES CONTROL (CONTROL_ID);


CREATE SEQUENCE SEQ_CONTROLDIST START WITH 1;

--=======================================================================================--
-- FIN MAJ2416b-2416c.SQL
-- Aucune ligne ne doit suivre l'INSERT
--=======================================================================================--

INSERT INTO version (version_date, version_nom) 
	VALUES (SYSDATE, 'Version 2.4.16c');

commit;


