DELIMITER $$
create procedure sp_usuario_deletar(
	in pEmail varchar(240),
    in pSenha varchar(240)
)
begin
	declare vId int;
    set vId =
		(select id from usuario where email = pEmail and senha = pSenha);
	delete from usuario where id = vId;
end$$
DELIMITER ;
