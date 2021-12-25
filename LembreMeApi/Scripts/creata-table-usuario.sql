CREATE TABLE Usuario (
  id varchar(50) default (uuid()) PRIMARY KEY,
  nome varchar(240),
  email varchar(240),
  senha varchar(240)
)