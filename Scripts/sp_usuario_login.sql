DELIMITER $$
CREATE PROCEDURE sp_usuario_login(
	in pEmail varchar(240),
    in pSenha varchar(240)
)
begin
	select email, senha, id, nome 
	from usuario
	where email = pEmail
		and senha = pSenha;
end $$
DELIMITER;