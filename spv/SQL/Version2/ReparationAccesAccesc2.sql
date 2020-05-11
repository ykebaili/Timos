declare
  CURSOR CAccesAccesc2 IS
    select acces_accesc_id from acces_accesc, acces_accesc2
    where acces_accesc2_id (+) = acces_accesc_id
    and acces_accesc2_id is null;
begin
  for rCAccesAccesc2 in CAccesAccesc2 loop
      insert into acces_accesc2 values (
        rCAccesAccesc2.acces_accesc_id, 0, 0, 0, 0, 0, 0, 0, null, 0, seq_acces_accesc2.nextval);
  end loop;
end;