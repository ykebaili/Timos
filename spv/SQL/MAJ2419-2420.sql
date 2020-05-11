--=======================================================================================--
--                                                                                       --
--                           FICHIER MAJ2419-2420.SQL                                    --
--                                                                                       --
-- Mise à jour de la BDD superviseur en production de la version 2.4.19 à 2.4.20           --
--										 	 --
--=======================================================================================--

create table routage
(
	routage_id number not null,
constraint pk_routage  primary key (routage_Id) using index tablespace &1,
	equip_id   number not null,
	Prog_id	   number not null,
	liai_id   number not null,
	site_id	   number not null
);

alter table routage
    add constraint fk1_routage foreign key (equip_id) references equip(equip_id); 
alter table routage
    add constraint fk2_routage foreign key (Prog_id) references prog(Prog_id);  
alter table routage
    add constraint fk3_routage foreign key (liai_id) references Liai(liai_id);  
alter table routage
    add constraint fk4_routage foreign key (site_id) references site(site_id);  


create index routage_fk1 on routage (equip_ID asc) tablespace &1;
create index routage_fk2 on routage (PROG_ID asc) tablespace &1;
create index routage_fk3 on routage (liai_ID asc) tablespace &1;
create index routage_fk4 on routage (site_ID asc) tablespace &1;

create sequence seq_routage;

create index liai_topsrc_topdst_i1 on liai_topsrc_topdst (Liai_ID asc) tablespace &1;

-----------------------------------------------prog-----------------------------------------------
update prog set prog_routage= null;
alter table prog modify (prog_routage  number);
update prog set prog_routage =0;
alter table prog modify (prog_routage default(0) not null);

--------------------------------------------prog_cab---------------------------------------------

alter table prog_cabl modify (prog_cabl_num null);

alter table prog_cabl add 
(
	nb_ref number default(1) not null
);

-----------------------------------------prog_cabl_tmp------------------------------------------------
--la table prog_cabl_tmp est utilisée pendant le calcule de equip_msk
create table prog_cabl_tmp
(
prog_cabl_tmp_id 	number not null,
constraint pk_prog_cabl_tmp  primary key (prog_cabl_tmp_id) using index tablespace &1,
prog_id			number not null,
cablequ_id		number not null,
site_id			number not null,
prog_cabl_num		number default(1) not null 
);

alter table prog_cabl_tmp
    add constraint prog_cabl_tmp_fk1 foreign key (Prog_id) references prog(Prog_id);  
alter table prog_cabl_tmp
    add constraint prog_cabl_tmp_fk2 foreign key (cablequ_id) references cablequ(cablequ_id);  
alter table prog_cabl_tmp
    add constraint prog_cabl_tmp_fk3 foreign key (site_id) references site(site_id);  

create sequence seq_prog_cabl_tmp;

--------equip_msk -----------------------------------------------------------------

alter table equip_msk add (prog_id number, site_id number);
alter table equip_msk
    add constraint equip_msk_fk4 foreign key (Prog_id) references prog(Prog_id);
alter table equip_msk
    add constraint equip_msk_fk5 foreign key (site_id) references site(site_id);

update equip_msk set site_id=(select site_id from cablequ where cablequ.cablequ_id=equip_msk.cablequ_id);
update equip_msk set prog_id=(select prog_id from prog_cabl where prog_cabl.cablequ_id=equip_msk.cablequ_id);

declare
	Cursor CablequProgNull is
		select * from equip_msk where prog_id is null;

	Cursor ProgCabl (cablId number) is
		select prog_id from prog_cabl where cablequ_id=cablId;
begin
	for rCablequProgNull in CablequProgNull loop
		for rProgCabl in ProgCabl (rCablequProgNull.cablequ_id) loop
			insert into equip_msk (equip_msk_id, equip_id, equip_bindingid, cablequ_id, prog_id, site_id) 
			values (seq_equip_msk.nextval, rCablequProgNull.equip_id, rCablequProgNull.equip_bindingid, rCablequProgNull.cablequ_id, rProgCabl.prog_id, rCablequProgNull.site_id);
		end loop;
	end loop;

	delete equip_msk where prog_id is null;
end;
/

alter table equip_msk modify (site_id not null);
alter table equip_msk modify (prog_id not null);
alter table equip_msk modify (cablequ_id  null);


--prog_usedsites contienne tous les sites (sans sites inclus) utilisés par le programme;
--nb_ref - numbre de fois que le site est dessiné dans la vue physique du programme où des ses topologies;
--nb_ref fasilite la suppression des sites du prog_usedsites.

create table prog_usedsites
(
	Prog_id	   number not null,
	site_id	   number not null,
	nb_ref	   number default(1) not null,
constraint pk_prog_usedsites  primary key (Prog_id, site_id) using index tablespace &1
);

alter table prog_usedsites
    add constraint fk1_prog_usedsites foreign key (Prog_id) references prog(Prog_id);  
alter table prog_usedsites
    add constraint fk2_prog_usedsites foreign key (site_id) references site(site_id); 


--prog_usedliais contienne tous les liaisons est leurs supports utilisés par le programme; 
--nb_ref numbre de  fois que la liaison est dessinée dans la vue physique du programme où des ses topologies;
--nb_ref fasilite la suppression des liaisons du prog_usedliais.


create table prog_usedliais
(
	Prog_id	   number not null,
	liai_id	   number not null,
	nb_ref	   number default(1) not null,
constraint pk_prog_usedliais  primary key (prog_id, liai_id ) using index tablespace &1
);

alter table prog_usedliais
    add constraint fk1_prog_usedliais foreign key (Prog_id) references prog(Prog_id);  
alter table prog_usedliais
    add constraint fk2_prog_usedliais foreign key (liai_id) references liai(liai_id); 



-------------------------------------------remplir prog_usedsites, prog_usedliais ------------------------
-------------------------------------------pour des programes pas routés ---------------------------------

delete prog_usedsites;
delete prog_usedliais;
delete prog_cabl;

delete top_liaitempu where liai_id not in 
(select liai_id from top_liai where top_liai.top_id=top_liaitempu.top_id);


create or replace procedure top_insert_used (progId number, topId number)
is

siteId number;
nbRef 	number;

cursor topsite is
  select * from top_site where top_id=topId;

cursor topliai is
  select * from top_liaitempu  where top_id=topId;

cursor topcablequ is
   select * from top_cablequ   where top_id=topId;

cursor toptop is
  select * from top_top  where top_id=topId;

Cursor curNbRef (progid number, cablId number) is 
	select nb_ref from prog_cabl where prog_id=progid and cablequ_id=cablId;

Cursor curNbRefSite (progid number, siteId number) is 
	select nb_ref from prog_usedsites where prog_id=progid and site_id=siteId;

Cursor curNbRefLiai (progid number, liaiId number) is 
	select nb_ref from prog_usedliais where prog_id=progid and liai_id=liaiId;


begin

  for rtopsite in topsite loop


    nbRef:=0;

    for rcurNbRefSite in curNbRefSite(progId, rtopsite .site_id) loop
	nbRef:=rcurNbRefSite.nb_ref;
    end loop;

    if(nbRef>0) then
	nbRef := nbRef+1;
	update prog_usedsites set nb_ref = nbRef where prog_id = progId and           		
site_id=rtopsite.site_id;
    else

       insert into prog_usedsites(prog_id, site_id) values( progId, rtopsite.site_id);

     end if;

  end loop;

  for rtopliai in topliai loop

    nbRef:=0;

    for rcurNbRefLiai in curNbRefLiai(progId, rtopliai.liai_id) loop
	nbRef:=rcurNbRefLiai.nb_ref;
    end loop;

    if(nbRef>0) then
	nbRef := nbRef+1;
	update prog_usedliais set nb_ref = nbRef where prog_id = progId and           		
liai_id=rtopliai.liai_id;

    else

    insert into prog_usedliais( prog_id, liai_id) values( progId, rtopliai.liai_id);

    end if;
  end loop;

 for rtopcablequ in topcablequ loop
    select site_id into siteId from cablequ where cablequ_id=rtopcablequ.cablequ_id;

    nbRef:=0;

    for rcurNbRef in curNbRef(progId, rtopcablequ.cablequ_id) loop
	nbRef:=rcurNbRef.nb_ref;
    end loop;

    if(nbRef>0) then
	nbRef := nbRef+1;
	update prog_cabl set nb_ref = nbRef where prog_id = progId and                      
cablequ_id=rtopcablequ.cablequ_id;
    else

    insert into prog_cabl( prog_id, cablequ_id, site_id, prog_cabl_grave) values
	(progId, rtopcablequ.cablequ_id, siteId,0);
    end if;

  end loop;

 for rtoptop in toptop loop
	 top_insert_used(progId, rtoptop.childtop_id);
 end loop;

end top_insert_used;
/

declare

siteId 	number;
nbRef 	number;

cursor progsite is
  select prog_site.prog_id, site_id from prog_site, prog where
	prog_site.prog_id=prog.prog_id and prog_routage=0 and prog_sitebound is null and prog_liaibound is null;

cursor progliai is
   select prog_liaitempu.prog_id, liai_id from prog_liaitempu, prog where
	prog_liaitempu.prog_id=prog.prog_id and prog_routage=0  and prog_sitebound is null and prog_liaibound is null;

cursor progcablequ is
   select prog_cablequ.prog_id, cablequ_id from prog_cablequ, prog where
	prog_cablequ.prog_id=prog.prog_id and prog_routage=0;

cursor progtop is
  select prog_top.prog_id, top_id from prog_top, prog where
	prog_top.prog_id=prog.prog_id and prog_routage=0;

Cursor allLiai is
	select * from prog_usedliais;

Cursor	liaicablequ (liaiId number) is
	select * from liai_cablequ where liai_id=liaiId;

Cursor curNbRef (progid number, cablId number) is 
	select nb_Ref from prog_cabl where prog_id=progid and cablequ_id=cablId;

Cursor curNbRefSite (progid number, siteId number) is 
	select nb_Ref from prog_usedsites where prog_id=progid and site_id=siteId;

Cursor curNbRefLiai (progid number, liaiId number) is 
	select nb_Ref from prog_usedliais where prog_id=progid and liai_id=liaiId;


  begin

  for rprogsite in progsite loop

    nbRef:=0;

    for rcurNbRefSite in curNbRefSite(rprogsite.prog_id, rprogsite.site_id) loop
	nbRef:=rcurNbRefSite.nb_ref;
    end loop;

    if(nbRef>0) then
	nbRef := nbRef+1;
	update prog_usedsites set nb_ref = nbRef where prog_id = rprogsite.prog_id and  site_id=rprogsite.site_id;
    else

    insert into prog_usedsites(prog_id, site_id) values(rprogsite.prog_id, rprogsite.site_id);

    end if;
  end loop;

  for rprogliai in progliai loop

    nbRef:=0;

    for rcurNbRefLiai in curNbRefLiai(rprogliai.prog_id, rprogliai.liai_id) loop
	nbRef:=rcurNbRefLiai.nb_ref;
    end loop;

    if(nbRef>0) then
	nbRef := nbRef+1;
	update prog_usedliais set nb_ref = nbRef where prog_id = rprogliai.prog_id and  liai_id=rprogliai.liai_id;
    else

    insert into prog_usedliais( prog_id, liai_id) values(rprogliai.prog_id, rprogliai.liai_id);

     end if;
  end loop;

  for rprogcablequ in progcablequ loop

    select site_id into siteId from cablequ where cablequ_id=rprogcablequ.cablequ_id;
    
    nbRef:=0;

    for rcurNbRef in curNbRef(rprogcablequ.prog_id, rprogcablequ.cablequ_id) loop
	     nbRef:=rcurNbRef.nb_ref;
    end loop;

    if(nbRef>0) then
	   nbRef := nbRef+1;
	   update prog_cabl set nb_ref = nbRef where prog_id = rprogcablequ.prog_id and  cablequ_id=rprogcablequ.cablequ_id;
    else
    	insert into prog_cabl(prog_id, cablequ_id, site_id, prog_cabl_grave) 	values(rprogcablequ.prog_id, rprogcablequ.cablequ_id, siteId,0);
    end if;
  end loop;


 for rprogtop in progtop loop
	top_insert_used (rprogtop.prog_id, rprogtop.top_id);
 end loop;

 for rallLiai in allLiai loop
	for rliaicablequ in liaicablequ ( rallLiai.liai_id) loop
		select site_id into siteId from cablequ where cablequ_id=rliaicablequ.cablequ_id;
		nbRef:=0;

    		for rcurNbRef in curNbRef(rallLiai.prog_id, rliaicablequ.cablequ_id) loop
			nbRef:=rcurNbRef.nb_ref;
    		end loop;

		if(nbRef>0) then
			nbRef := nbRef+1;
			update prog_cabl set nb_ref = nbRef where prog_id = rallLiai.prog_id and           				cablequ_id=rliaicablequ.cablequ_id;
    		else

			insert into prog_cabl(prog_id, cablequ_id, site_id, prog_cabl_grave) 				values( rallLiai.prog_id,rliaicablequ.cablequ_id, siteId,0);
		end if;
	end loop;
 end loop;


  end;
/

drop procedure top_insert_used;

-------------------------------------------------------------------------------------------------

-- les suppressions de procédure mises en commentaire le sont car elles ne sont pas nécessaires
-- dans le cadre de la mise à jour OPT à partir de la version 2.4.13. Ceci afin de minimiser
-- les erreurs ORA-xxx dans les fichiers de spool.

drop PROCEDURE ProgCablequOrder;
drop PROCEDURE ProgCOrder;
-- drop PROCEDURE ProgCOrderMain;
drop PROCEDURE SearchUp;
-- drop PROCEDURE IsLiaiUsedByProg;
drop PROCEDURE CreateCablageTopSuite;
drop PROCEDURE UpdateCablequOrder;
-- drop PROCEDURE RecursNum;
-- drop PROCEDURE CreEquipLiai;
drop PROCEDURE ProgMajCablequLinkWithTop;
-- drop PROCEDURE TsPrOperTop;
-- drop PROCEDURE TsPrOperTopLiai;
-- drop PROCEDURE TsPrOperLiai;
-- drop PROCEDURE UpdateProgOperTop;
-- drop PROCEDURE MajMask;
-- drop PROCEDURE TsPrOperMask;
-- drop PROCEDURE CreArchSiteRecurs;
-- drop PROCEDURE InsertMask; 
-- drop PROCEDURE UpdateProgOperLiai;
-- drop PROCEDURE IsUsedByProg;

--=======================================================================================--
-- FIN MAJ2419-2420.SQL
-- Aucune ligne ne doit suivre l'INSERT
--=======================================================================================--

INSERT INTO version (version_date, version_nom) 
	VALUES (SYSDATE, 'Version 2.4.20');

commit;
