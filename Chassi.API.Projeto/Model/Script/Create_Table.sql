use db_grl;
drop table tb_pessoa;
create table if not exists Pessoa (
Id BIGINT NOT NULL AUTO_INCREMENT primary key,
Primeiro_Nome VARCHAR(80) NOT NULL,
Segundo_Nome VARCHAR(80) NOT NULL,
Genero VARCHAR(10) NOT NULL,
Endereco VARCHAR(100) NOT NULL
);
