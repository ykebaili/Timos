--=======================================================================================--
--                                                                                       --
--                           FICHIER MAJ2416c-24173.SQL                                    --
--                                                                                       --
-- Mise à jour de la BDD superviseur en production de la version 2.4.16c à 2.4.17.3           --
--										 	 --
--=======================================================================================--

-- Ajout du champ relatif au nombre d'utilisateurs connectés dans la table JCXION

alter table JCXION add
(
JCXION_NBCONN	NUMBER	DEFAULT	0
);

commit;

--=======================================================================================--
-- FIN MAJ2416c-24173.SQL
-- Aucune ligne ne doit suivre l'INSERT
--=======================================================================================--

INSERT INTO version (version_date, version_nom) 
	VALUES (SYSDATE, 'Version 2.4.17.3');

commit;
