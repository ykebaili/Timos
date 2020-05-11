--=======================================================================================--
--                                                                                       --
--                           FICHIER MAJ24173-24175.SQL                                    --
--                                                                                       --
-- Mise à jour de la BDD superviseur en production de la version 2.4.17.3 à 2.4.17.5           --
--										 	 --
--=======================================================================================--

-- correction de l'erreur de tablespace pour la clé primaire de la table CONTROLDIST

alter table CONTROLDIST drop constraint PK_CONTROLDIST;

alter table CONTROLDIST add constraint PK_CONTROLDIST primary key (CONTROLDIST_ID) using index tablespace &1;





commit;

--=======================================================================================--
-- FIN MAJ24173-24175.SQL
-- Aucune ligne ne doit suivre l'INSERT
--=======================================================================================--

INSERT INTO version (version_date, version_nom) 
	VALUES (SYSDATE, 'Version 2.4.17.5');

commit;
