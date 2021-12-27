CREATE TABLE Despesa (
  id varchar(50) default (uuid()) PRIMARY KEY,
  dataPagamento date,
  titulo varchar(240),
  vencimento date,
  baixado int default 0,
  idUsuario varchar(50),
  FOREIGN KEY (idUsuario) REFERENCES Usuario(id)
)