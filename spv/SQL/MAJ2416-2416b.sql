--==============================================================================================--
--                                                                                      	--
--                           FICHIER MAJ2416-2416b.SQL                               		--
--                                                                                    		--
-- Mise à jour de la BDD superviseur en production de la version MAJ2416 à la version 2416b   	--
--										      		--
--==============================================================================================--

alter table EQUIP_REP
    add (EQUIP_COMMUT		number(2)	default 0);  
alter table EQUIP_REP
    modify (EQUIP_COMMUT	not null);  

update equip_rep set equip_rep.equip_commut= (select equip.equip_commut
	from equip where equip_rep.equip_id=equip.equip_id);

--=======================================================================================--
-- FIN MAJ2416-2416b.SQL
-- Aucune ligne ne doit suivre l'INSERT
--=======================================================================================--

INSERT INTO version (version_date, version_nom) 
	VALUES (SYSDATE, 'Version 2.4.16b');

commit;
