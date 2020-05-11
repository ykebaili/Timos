--==============================================================================
--                          MAJ2414-2415.sql
--==============================================================================

delete cablequ_cablequl where CABLEQU_CABLEQUL_ABOUT = 0;

alter table cablequ_cablequl add ( ACCES_ACCESC_ID number );

alter table cablequ_cablequl
    add constraint fk4_cablequ_cablequl foreign key (acces_accesc_Id) references acces_accesc(ACCES_ACCESC_ID);

--------------------------------------remplire ACCES_ACCESC_ID------------------------------
create or replace function  FIND_ACCESACCESCID
RETURN BOOLEAN
IS

    F1		NUMBER;
    F2		NUMBER;
    ENTREE_IS_1	BOOLEAN; -- l'acces d'entree d'equipement de connection est libre dans 
                        -- le cablage 1
    AC1		NUMBER;  -- acces_id d'equipement de connection dans le cablage1
    AC2		NUMBER;  -- acces_id d'equipement de connection dans le cablage2
    Error	BOOLEAN;
    CablId	NUMBER;
    nbCount	NUMBER;
    Liai1	NUMBER;
    Msg		VARCHAR2(1000);
    AccAcc NUMBER;
    
    CURSOR CCabl  IS 	select* from cablequ_cablequl where acces_accesc_id is null;
    CURSOR CCurAC (nom VARCHAR2, equipId NUMBER) is 
      select acces_id from acces where equip_id = equipId and acces_nom like nom;
    CURSOR CCablAcc (cablequ1 NUMBER, cablequ2 NUMBER)is
      select cablequ_id from prog_cabl where cablequ_id = cablequ1 or
  		cablequ_id = cablequ2
  		union
  		select cablequ_id from top_cablequ where cablequ_id = cablequ1 or
  		cablequ_id = cablequ2;

      
  
begin
    Error := FALSE;
    for vCabl in CCabl loop
	select CABLEQU_EQUIP_FRONTIERE into F1 from cablequ_equip where cablequ_id = vCabl.cablequ1_id
	and equip_id = vCabl.equip_id;
	
	select CABLEQU_EQUIP_FRONTIERE into F2 from cablequ_equip where cablequ_id = vCabl.cablequ2_id
	and equip_id = vCabl.equip_id;

	if(F1=1 or (F1=3 and F2=2)) then
		ENTREE_IS_1 := TRUE;
	else
		ENTREE_IS_1 := FALSE;
	end if;

	AC1:=0;
	AC2:=0;
	
	--recherche des acces de vCabl.equip_id connectés
	if(ENTREE_IS_1) then -- 
  	--	select acces_id into AC1 from acces where equip_id = vCabl.equip_id and acces_nom like '%ENTRE%';
  		for vCurAC in CCurAC ('%ENTRE%', vCabl.equip_id) loop
  		  AC1 := vCurAC.acces_id;
  		end loop;
  	--	select acces_id into AC2 from acces where equip_id = vCabl.equip_id and acces_nom like '%SORTI%';
  		for vCurAC in CCurAC ('%SORTI%', vCabl.equip_id) loop
  		  AC2 := vCurAC.acces_id;
  		end loop;
  		
  		if(AC1=0) then
  		 -- select acces_id into AC1 from acces where equip_id = vCabl.equip_id and acces_nom like '%ET%';
  		    for vCurAC in CCurAC ('%ET%', vCabl.equip_id) loop
  		      AC1 := vCurAC.acces_id;
  		    end loop;
  		end if;
  		if(AC2=0) then
  		 --  select acces_id into AC2 from acces where equip_id = vCabl.equip_id and acces_nom like '%ST%';
  		  for vCurAC in CCurAC ('%ST%', vCabl.equip_id) loop
  		    AC2 := vCurAC.acces_id;
  		  end loop;
  		end if;
	else
  		--select acces_id into AC1 from acces where equip_id = vCabl.equip_id and acces_nom like '%SORTI%';
  		for vCurAC in CCurAC ('%SORTI%', vCabl.equip_id) loop
  		  AC1 := vCurAC.acces_id;
  		end loop;
  	--	select acces_id into AC2 from acces where equip_id = vCabl.equip_id and acces_nom like '%ENTRE%';
  		for vCurAC in CCurAC ('%ENTRE%', vCabl.equip_id) loop
  		  AC2 := vCurAC.acces_id;
  		end loop;
  		
  		if(AC1=0) then
  		 --  select acces_id into AC1 from acces where equip_id = vCabl.equip_id and acces_nom like '%ST%';
  		    for vCurAC in CCurAC ('%ST%', vCabl.equip_id) loop
  		      AC1 := vCurAC.acces_id;
  		    end loop;
  		end if;
  		if(AC2=0) then
  		 --  select acces_id into AC2 from acces where equip_id = vCabl.equip_id and acces_nom like '%ET%';
  		  for vCurAC in CCurAC ('%ET%', vCabl.equip_id) loop
  		    AC2 := vCurAC.acces_id;
  		  end loop;
  		end if;
	end if;

	if(AC1=0 or AC2=0) then
		Error:=TRUE;
	else
		CablId:=0;
		for vCablAcc in CCablAcc (vCabl.cablequ1_id, vCabl.cablequ2_id) loop
		  CablId:=vCablAcc.cablequ_id;
		end loop;

		if(CablId=0) then --support/supportée
			Liai1 := 0;
			select liai_id into Liai1 from liai_cablequ where cablequ_id = vCabl.cablequ1_id;
			select count(*) into nbCount from liai_liaic where LIAI_BINDINGID=Liai1;
			if(nbCount>0) then -- vCabl.cablequ1_id est support
				CablId := vCabl.cablequ2_id ;
			else
				CablId := vCabl.cablequ1_id ;
			end if;
 		end if;--support/supportée
		insert into acces_accesc (acces_accesc_id, acces1_id, acces2_id, acces_bindingid, 		acces_bindingclassid ) values (seq_acces_accesc.NEXTVAL, AC1, AC2, CablId, 1016);
		select seq_acces_accesc.CURRVAL into AccAcc from dual AccAcc;
		update cablequ_cablequl set ACCES_ACCESC_ID = AccAcc
      where cablequ_cablequl_id= vCabl.cablequ_cablequl_id;
	end if;--(AC1=0 or AC2=0)
	
  end loop;

  if(Error) then
   	Msg := 'Impossible de trouver des acces connectées pour sertaine cablequ_cablequl.
  	Retrouvez les manuelement. Créez l''eregistrement correspondant dans acces_accesc avec acces_bindingid = 
  	cablequ_id de la prestation, ou de la topologie, ou de la liaison supportée et avec acces_bindingclassid 		= 1016.
  	Eregistrez ce nouveau acces_accesc_id dans cablequ_cablequl.acces_accesc_id';
  
  	dbms_output.put_line (Msg);
  	SetTrace(Msg);
  	return FALSE;
  end if;
	
	return TRUE;
end;
/


declare
	res boolean;
begin
	res:=FIND_ACCESACCESCID();
end;
/

drop function FIND_ACCESACCESCID;

alter table cablequ_cablequl modify (ACCES_ACCESC_ID not null);
alter table cablequ_cablequl modify (EQUIP_ID NULL);
alter table cablequ_cablequl modify (CABLEQU_CABLEQUL_ABOUT NULL);
--------------------------------------------------------------------------------------

---information supplementaire pour des liaisons abbouties dans une topologie
create table liai_topsrc_topdst
(	
	father_id	number not null,---------Prog ou top Id (item dans la vue physique du quelle la
					--------- liaison est desinée
	fatherclass_id	number not null,---------CPROG_ID ou CTOP_ID
	liai_id		number not null,
	topsrc_id	number,
	topdst_id	number,
constraint ck_liai_topsrc_topdst check (fatherclass_id in (1006, 1049))----PROG ou TOP
);

alter table liai_topsrc_topdst
    add constraint fk1_liai_topsrc_topdst foreign key (liai_id) references Liai(liai_id);  
alter table liai_topsrc_topdst
    add constraint fk2_liai_topsrc_topdst foreign key (topsrc_id) references top(top_id);  
alter table liai_topsrc_topdst
    add constraint fk3_liai_topsrc_topdst foreign key (topdst_id) references top(top_id); 



create table top_top
(
	Top_Id		Number not null,
	ChildTop_Id	Number not null,
constraint pk_top_top  primary key (Top_Id, ChildTop_Id) using index tablespace &1
);

alter table top_top  
    add constraint fk1_top_top foreign key (Top_Id) references top (top_id);
alter table top_top
    add constraint fk2_top_top foreign key (ChildTop_Id) references Top (Top_id);


update dessin set dessin_param9=0 where dessin_param9=-1 and DESSIN_CLASSID = 2010;
update dessin set dessin_param10=0 where dessin_param10=-1 and DESSIN_CLASSID = 2010;
update dessin set dessin_param5=0  where dessin_param5=-1 and DESSIN_CLASSID = 2015;





alter table WRKFHISTOETAT add
(
      WRKFHISTOETAT_USERL    VARCHAR2(40)
);



alter table valeurs add
(
	USERL_ID	NUMBER
);

alter table WRKFTRANS add
(
	PRIV_ID		NUMBER
);

create table USERP
(
	USERP_WRKFVALDEF	NUMBER  constraint UN_VAL1 check (USERP_WRKFVALDEF in (0,1))
);


--=======================================================================================--
-- FIN MAJ
-- Aucune ligne ne doit suivre l'INSERT
--=======================================================================================--

INSERT INTO version (version_date, version_nom) 
	VALUES (SYSDATE, 'Version 2.4.15');

commit;

	
