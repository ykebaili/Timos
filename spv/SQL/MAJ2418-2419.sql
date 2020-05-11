--=======================================================================================--
--                                                                                       --
--                           FICHIER MAJ2418-2419.SQL                                    --
--                                                                                       --
-- Mise à jour de la BDD superviseur en production de la version 2.4.18 à 2.4.19           --
--										 	 --
--=======================================================================================--

create index acces_accesc_i6 on acces_accesc (acces_bindingid asc) tablespace &1;
create index acces_accesc_i7 on acces_accesc (alarmgeree_id asc) tablespace &1;

-- Ajout des données, permettant la présentation du tableau TIM_FH national,
-- à la table IQ

/* Cette table n'existe pas dans le contexte OPT
alter table IQ add 
(
 NB_FH		NUMBER,
 TOTAL_UAS	NUMBER,
 TOTAL_DUREE	NUMBER
);
*/



 

--=======================================================================================--
-- FIN MAJ2418-2419.SQL
-- Aucune ligne ne doit suivre l'INSERT
--=======================================================================================--

INSERT INTO version (version_date, version_nom) 
	VALUES (SYSDATE, 'Version 2.4.19');

commit;
