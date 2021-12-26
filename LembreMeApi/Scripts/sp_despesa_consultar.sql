DELIMITER $$

create procedure sp_despesa_consultar(
	pIdUsuario varchar(50),
	pBaixado int,
    pVencimento date
)
begin
	if (pBaixado = 1)
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
		idUsuario = pIdUsuario	
        and month(vencimento) = month(pVencimento);
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
        and month(vencimento) = month(pVencimento)
		and baixado = pBaixado;
	end if;
end $$

DELIMITER ;
