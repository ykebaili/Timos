-- Cette mise � jour r�tablit la structure de EQUIP_REP
-- qui n'a pas � �tre � ID num�rique auto (ceci pose pb pour la r�plication)
-- Elle remet donc le trigger TI_EQUIP tel qu'il �tait au pr�alable

-- Cette mise � jour est n�cessaire pour les base de donn�es en cours de test
-- � ce jour. Elles ne seront pas n�cessaires sur une BDD r�cup�r�e de l'OPT

alter table EQUIP_REP drop constraint pk_equip_rep;
drop index pk_equip_rep;

alter table EQUIP_REP drop (EQUIP_REP_ID);
drop sequence SEQ_EQUIP_REP;

alter table EQUIP_REP add constraint
	pk_equip_rep primary key (EQUIP_ID)
	using index tablespace &1;

drop index EQUIP_REP_FK1;

delete SYS_CHAMP_AUTO where table_name = 'EQUIP_REP';
commit;



--========================================================================================
--
-- Modifi� X.L. 14/04/99 envoi d'alerte � l'�quipement de m�diation pour prise en compte
-- du param�tre alarme fr�quente lorsque l'�quipement est une IS
--
-- Modifi� X.L. 28/04/99 afin d'ajouter le contr�le de coh�rence entre le site de l'�quipement
-- et le site de la baie.
--
-- Modifi� X.L. 19/07/99 pour transformer l'envoi d'alerte ORACLE qui fonctionne mal,
-- en insertion dans la table MESSALRM; A charge ensuite au process serveur EmessAlrm2 
-- d'envoyer un message correspondant � l'�quipement de m�diation par socket TCP/IP.
--
-- Modifi� X.L. 05/01/00 remplac� le libell� 'IS' par 'SATURNE IS' et dans le IF correspondant
-- equip_ref par un extrait de site_equip_comment
--
-- Modifi� X.L. 20/04/01 : introduction des modules (ou cartes) occupant un ou plusieurs slots.
-- On v�rifie que le num�ro de slot est saisi.
-- On v�rifie que le slot choisi est compatible avec l'�quipement p�re.
-- Rappel : un �quipement qui occupe plusieurs slots est ins�r� dans la table EQUIP autant de 
-- fois que le nombre de slots le n�cessite.
--
-- Modifi� JPB le 02/09/02 : s�paration alarmes / structure
-- 18/09/03 : JPB : Modification du message MESSALRM, pour introduire le nb. de # envoy�s
--
-- X.L. Modif. le 12/02/04 : lorsqu'un �quipement voit sa case "� surveiller" passer de
-- d�coch�e � coch�e ou l'inverse, on g�n�re un message dans la table EmessEM.
--
-- JPB  Modif le 26/01/05  : v�rification que les champs SITE_EQUIP_COMMENT et BAIE_ID
-- ne sont pas nuls simultan�ment
--
-- Modif. X.L. le 02/02/05 : le contr�le de saisie obligatoire sur au moins BAIE_ID
-- ou SITE_EQUIP_COMMENT n'est valable que pour un �quipement (pas une antenne),
-- on ajoute donc le CLASSID = 1018 comme crit�re suppl�mentaire.
--
--
-- Modif Y.C. le 23/07/07 : v�rification que la r�f�rence, le commentaire , l'adresse IP et la 
-- position de la baie ne sont pas nuls (et non pas seulement le commentaire et la baie)

--========================================================================================
create or replace trigger ti_equip after insert on EQUIP for each row

declare
    integrity_error  exception;
    errno            integer;
    errmsg           char(200);
    Mess     VARCHAR2 (1800);/* taille max. du message autoris� par Oracle : 1800 octets */
    MessId           integer;

    strTypeqNom	     typeq.typeq_nom%TYPE;

begin

    /* traitement � effectuer sur les DEUX serveurs (s�paration alarme/structure) */
    if (:new.equip_commut = 0) then
    insert into EQUIP_REP (equip_id, equip_oper)
	values (:new.equip_id, 0);
    else
	insert into EQUIP_REP (equip_id, equip_oper, equip_commut)
		values (:new.equip_id, 0, :new.equip_commut);
    end if;

    /* Si le trigger est d�clench� par suite d'un enregistrement cr�� par r�plication,
       on ne fait pas le traitement */
    if dbms_reputil.from_remote=TRUE then
		return;
    end if;

   if (:new.SITE_EQUIP_COMMENT is NULL and :new.BAIE_ID is NULL  and :new.EQUIP_REF is null and :new.EQUIP_ADDRIP is null and :new.EQUIP_CLASSID = 1018) then
	raise_application_error (-20000, 'Cet �quipement n''a pas de position g�ographique !');
    end if;

    if (:new.EQUIP_EQUIPID is not null) then
	-- Enregistrements pour occuper les diff�rents slots, lorsque plusieurs slots
	-- sont d�finis dans le type d'�quipement. On ne fait pas les contr�les, car les
	-- messages d'erreurs �ventuels seraient donn�s autant de fois que de slots d�finis.
	return;
    end if;

--    CMS_EltGere (Mess, 1, :new.EQUIP_ID, :new.SITE_ID, 1);

    -- Envoi � l'�quipement de m�diation du param�tre alarme fr�quente lorsque l'�quipement
    -- est une IS
    SELECT typeq_nom INTO strTypeqNom FROM typeq WHERE typeq_id = :new.typeq_id;

    IF strTypeqNom = 'SATURNE IS' THEN
	select SEQ_MESSALRM.NEXTVAL into MessId from dual;
	Mess := '6#';				-- Code du message
	Mess := CONCAT (Mess, '8#');		-- Nb. de #
	Mess := CONCAT (Mess, '0#');		/* Alarm_Id */
    	Mess := CONCAT (Mess, MessId);
	Mess := CONCAT (Mess, '#'); 		/* stockage dans MESSALRM */
    	Mess := CONCAT (Mess, '0#');		/* Alarmgeree_Id */
    	Mess := CONCAT (Mess, '0#');		/* BindingId */
   	Mess := CONCAT (Mess, '0#');		/* BindingTyp */
	Mess := Mess || 'D' || LTRIM (SUBSTR (:new.site_equip_comment, 3)) || '/' 
		|| TO_CHAR (:new.equip_freqe) || '/#';

--insert into test values (seq_test.nextval, 'ti_equip' || Mess);

	insert into MESSALRM (MESSALRM_ID, MESSALRM_MESS, MESSALRM_SENT, MESSALRM_NATURE)
	    values (MessId, Mess, 0, 0);

	/*
	dbms_alert.signal ('Mediation', 
		'D' || :new.equip_ref || '/' || TO_CHAR (:new.equip_freqe) || '/');
	*/
    END IF;

    -- V�rification que la baie appartient bien au site
    VerfSiteBaieEquip (:new.baie_id, :new.site_id);

    -- V�rification de la saisie des slots
    VerfSlotEquip (:new.TYPEQ_BINDINGID, :new.TYPEQ_ID, :new.BAIE_EQUIP_CARTE);

    -- On cr�e le message demandant la surveillance de l'�quipement dans la table MESSEM
    if (:new.EQUIP_TOSURV > 0) THEN
	insert into MESSEM (MESSEM_ID, MESSEM_MESS)
	values (SEQ_MESSEM.nextval, '#9#6#1#C#' || to_char (:new.equip_id) || '#');
    end if;

--  gestion des erreurs
exception
    when integrity_error then
       raise_application_error (errno, errmsg);
end ti_equip;
/
