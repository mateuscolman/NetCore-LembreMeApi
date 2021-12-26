DELIMITER $$

create procedure sp_despesa_baixar(
	pId varchar(50),
	pDataPagamento date	
)
begin
	declare jaBaixado int;
	set jaBaixado = (COALESCE(select id from despesa where id = pId, 0))
	if (jaBaixado <> 1)
	then
		if exists(select id from despesa where id = pId)
		then
			update despesa
			set 
				baixado = 1,
				dataPagamento = pDataPagamento
			where 
				id = pId;		
			select pId as id;
			return;
		else
			select '0' as id;
			return;
		end if;
	end if;	
	select '0' as id;
end $$

DELIMITER ;