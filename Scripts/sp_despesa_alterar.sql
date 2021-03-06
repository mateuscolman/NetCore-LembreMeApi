DELIMITER $$

create procedure sp_despesa_alterar(
	pCampo varchar(50),
	pValor varchar(240),
	pId varchar(50)
)
begin
	case pCampo
		when 'dataPagamento' then
		   update despesa
		   set dataPagamento = str_to_date(pValor, '%Y-%m-%d')
		   where id = pId;
		   
		   select pId as id;
		when 'titulo' then
		   update despesa
		   set titulo = pValor
		   where id = pId;
		   
		   select pId as id;
		WHEN 'vencimento' THEN
		   update despesa
		   set vencimento = str_to_date(pValor, '%Y-%m-%d')
		   where id = pId;
		   
		   select pId as id;
		WHEN 'baixado' THEN
		   update despesa
		   set baixado = cast(pValor as unsigned)
			   and dataPagamento = '1999-01-01'
		   where id = pId;
		   
		   select pId as id;
		WHEN 'valor' THEN
		   update despesa
		   set valor = cast(pValor as decimal(10,2))
		   where id = pId;
		   
		   select pId as id;
		ELSE
		   select '0' as id;
	END CASE;
end $$

DELIMITER ;