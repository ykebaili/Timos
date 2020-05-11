--==============================================================================
--                          MAJ2412-2413.sql
--==============================================================================

-- Modification du champ PROG_FONC à 4000 caractères.
ALTER TABLE PROG MODIFY (PROG_FONC VARCHAR2(4000));
  
 
-- Ajout du champ PROG_ACTIF à la table PROG.  
ALTER TABLE PROG ADD (PROG_ACTIF NUMBER(1) default 1);
  
-- Création de la table PROG_ACTIV. 
--ACTIV_TYPE - temporaire ou periodique
CREATE TABLE PROG_ACTIV
(
  PROG_ACTIV_ID     NUMBER NOT NULL,
  PROG_ID           NUMBER NOT NULL,
  DATE_DEBUT        DATE,
  DATE_FIN          DATE,
  ACTIV_TYPE        VARCHAR2(1) NOT NULL,
  CONSTRAINT pk_prog_activ PRIMARY KEY (PROG_ACTIV_ID),
  CONSTRAINT fk_prog_activ FOREIGN KEY (PROG_ID) REFERENCES PROG (PROG_ID),
  constraint ck_prog_activ check (ACTIV_TYPE in ('P','T'))
);

-- Création de la séquence pour la table PROG_ACTIV.
CREATE SEQUENCE SEQ_PROGACTIV;

--trace de modification du parameter ACTIVE_SERVISE.
--utilisée par la proc. VerifActifProg
create table param_histo
(
	alarm_service_changed NUMBER(1) default(0)
);

insert into param_histo values( 0);

--===========================================
-- Script de récupération de plages horaires.
--===========================================
DECLARE

  CURSOR curGetProgFonc IS
    select prog_id, prog_fonc
      from prog
      where prog_fonc is not null
      and ASCII(prog_fonc) = 9;
      
  strInter      VARCHAR2(200);
  numJour       NUMBER;
  Lundi         VARCHAR2(50);
  Mardi         VARCHAR2(50);
  Mercredi      VARCHAR2(50);
  Jeudi         VARCHAR2(50);
  Vendredi      VARCHAR2(50);
  Samedi        VARCHAR2(50);
  Dimanche      VARCHAR2(50);
      
BEGIN
  FOR valGetProgFonc IN curGetProgFonc LOOP
  
    IF (INSTR(valGetProgFonc.prog_fonc, '1', 1)<>0) THEN
      numJour := 1;
      strInter := SUBSTR(REPLACE(valGetProgFonc.prog_fonc, chr(9), '#'), 5);
      
      WHILE (numJour <= 7) LOOP
        IF (numJour = 1) THEN
          IF (SUBSTR(strInter, 1, 1) = '1') THEN
            Lundi := 'P:Lundi,'||SUBSTR(strInter, 3, 5)||',Lundi,'||SUBSTR(strInter, 9, 5)||';';
            strInter := SUBSTR(strInter, 15);
          ELSIF (SUBSTR(strInter, 1, 1) = '0') THEN
            strInter := SUBSTR(strInter, 5);
          END IF;
          
        ELSIF (numJour = 2) THEN
          IF (SUBSTR(strInter, 1, 1) = '1') THEN
            Mardi := 'P:Mardi,'||SUBSTR(strInter, 3, 5)||',Mardi,'||SUBSTR(strInter, 9, 5)||';';
            strInter := SUBSTR(strInter, 15);
          ELSIF (SUBSTR(strInter, 1, 1) = '0') THEN
            strInter := SUBSTR(strInter, 5);
          END IF;
          
        ELSIF (numJour = 3) THEN
          IF (SUBSTR(strInter, 1, 1) = '1') THEN
            Mercredi := 'P:Mercredi,'||SUBSTR(strInter, 3, 5)||',Mercredi,'||SUBSTR(strInter, 9, 5)||';';
            strInter := SUBSTR(strInter, 15);
          ELSIF (SUBSTR(strInter, 1, 1) = '0') THEN
            strInter := SUBSTR(strInter, 5);
          END IF;
          
        ELSIF (numJour = 4) THEN
          IF (SUBSTR(strInter, 1, 1) = '1') THEN
            Jeudi := 'P:Jeudi,'||SUBSTR(strInter, 3, 5)||',Jeudi,'||SUBSTR(strInter, 9, 5)||';';
            strInter := SUBSTR(strInter, 15);
          ELSIF (SUBSTR(strInter, 1, 1) = '0') THEN
            strInter := SUBSTR(strInter, 5);
          END IF;
          
        ELSIF (numJour = 5) THEN
          IF (SUBSTR(strInter, 1, 1) = '1') THEN
            Vendredi := 'P:Vendredi,'||SUBSTR(strInter, 3, 5)||',Vendredi,'||SUBSTR(strInter, 9, 5)||';';
            strInter := SUBSTR(strInter, 15);
          ELSIF (SUBSTR(strInter, 1, 1) = '0') THEN
            strInter := SUBSTR(strInter, 5);
          END IF;
          
        ELSIF (numJour = 6) THEN
          IF (SUBSTR(strInter, 1, 1) = '1') THEN
            Samedi := 'P:Samedi,'||SUBSTR(strInter, 3, 5)||',Samedi,'||SUBSTR(strInter, 9, 5)||';';
            strInter := SUBSTR(strInter, 15);
          ELSIF (SUBSTR(strInter, 1, 1) = '0') THEN
            strInter := SUBSTR(strInter, 5);
          END IF;
          
        ELSIF (numJour = 7) THEN
          IF (SUBSTR(strInter, 1, 1) = '1') THEN
            Dimanche := 'P:Dimanche,'||SUBSTR(strInter, 3, 5)||',Dimanche,'||SUBSTR(strInter, 9, 5)||';';
            strInter := SUBSTR(strInter, 15);
          ELSIF (SUBSTR(strInter, 1, 1) = '0') THEN
            strInter := SUBSTR(strInter, 5);
          END IF;
          
        END IF;
      
        numJour := numJour + 1;
      END LOOP;
      
      -- Mise à jour du champ PROG_FONC de la table PROG.
      UPDATE PROG SET PROG_FONC = Lundi||Mardi||Mercredi||Jeudi||Vendredi||Samedi||Dimanche
        WHERE PROG_ID = valGetProgFonc.prog_id;
        
    END IF;
    
  END LOOP;
END;
/

-- executer cette comande apres des modif. de prog_activ, à cause de trigger 
-- tiub_param
-- Ajout du paramètre "ALARM_SERVICE".
INSERT INTO PARAM (PARAM_ID, PARAM_TYPE, PARAM_VALEUR)
  VALUES (seq_param.nextval, 9, 'ALARM_SERVICE=0');

INSERT INTO version (version_date, version_nom) 
	VALUES (SYSDATE, 'Version 2.4.14');

commit;
