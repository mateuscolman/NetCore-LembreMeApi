DELIMITER $$
CREATE PROCEDURE sp_usuario_cadastrar(	
	in pNome varchar(240),
    in pSenha varchar(240),
    in pEmail varchar(240)
)
begin
	declare vId text;
    set vId = uuid();
	if not exists (select id from usuario where email = pEmail)
    then
    insert IGNORE usuario(nome, email, senha, id) 
    values(pNome, pEmail, pSenha, vId);
    select vId as id;    
    else
    select '0' as id;
    end if;     
end $$ 
DELIMITER ;