DELIMITER $$
create PROCEDURE sp_despesa_inserir(
	pTitulo varchar(240),
	pVencimento date,
	pValor decimal(10,2),
	pIdUsuario varchar(50))
begin
	declare vId varchar(50);
	set vId = uuid();
	if not exists(select id from despesa where titulo = pTitulo and valor = pValor and vencimento = pVencimento)
	then
		insert into despesa(id, titulo, valor, vencimento, dataPagamento, idUsuario)
		values(vId, pTitulo, pValor, pVencimento, '1999-01-01', pIdUsuario);
		select vId as id;
	else
		select '0' as id;
	end if;
end$$ 
DELIMITER ;


