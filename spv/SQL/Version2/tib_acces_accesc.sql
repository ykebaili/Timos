create or replace
TRIGGER tib_acces_accesc before insert on acces_accesc for each row
begin
    -- S'il cela concerne un équipement de médiation, il faut mettre à jour
    -- le bindingid
    if (:new.acces1_id = 0 and :new.acces2_id = 0 and :new.acces_bindingclassid = 8 and
        :new.equip_id is not null and :new.alarmgeree_id = 1) then
        :new.acces_bindingid := :new.equip_id;
    end if;
end;
