DELIMITER $$

create procedure sp_despesa_baixar(
	pId varchar(50),
	pDataPagamento date	
)
begin
	if exists(select id from despesa where id = pId)
	then
		update despesa
		set 
			baixado = 1,
			dataPagamento = pDataPagamento
		where 
			id = pId;		
		select pId as id
	else
		select '0' as id
	end if
end $$

DELIMITER ;