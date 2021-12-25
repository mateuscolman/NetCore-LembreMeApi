DELIMITER $$

create procedure sp_despesa_consultar(
	pVencimento date,
	pIdUsuario varchar(50),
	baixado int
)
begin
	if (baixado = 1)
	then
	select 
		id, 
		dataPagamento, 
		titulo, 
		vencimento, 
		valor
	from 
		despesa
	where
		idUsuario = pIdUsuario;	
	else
	select 
		id, 
		titulo, 
		vencimento, 
		valor
	from 
		despesa
	where
		idUsuario = pIdUsuario	
		baixado = 0;
	end if
end $$

DELIMITER ;