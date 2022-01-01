DELIMITER $$

create procedure sp_despesa_baixar(
	pId varchar(50),
	pDataPagamento date	
)
begin
	declare jaBaixado int;
	set jaBaixado = COALESCE((select baixado from despesa where id = pId limit 1), 0);        
	if (jaBaixado != 1)
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
			
		else
			select '0' as id;			 
		end if;
	else
	select '0' as id;
    end if;
end $$

DELIMITER ;