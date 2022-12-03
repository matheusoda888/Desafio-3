
create database AtosEntity3

create login AtosEntity3 with password='Atos_Entity_3';
create user AtosEntity3 from login AtosEntity3;



exec sp_addrolemember 'DB_DATAREADER', 'AtosEntity3';
exec sp_addrolemember 'DB_DATAWRITER', 'AtosEntity3';

create table Produtos(
	id integer primary key identity,
	nome varchar(100),
	idFornecedor integer,
	foreign key (idFornecedor) references Fornecedores(id)
	)

create table Clientes(
	id integer primary key identity,
	nome varchar(20)	
)


create table Fornecedores(
	id integer primary key identity,
	nome varchar(20)
)

create table ClientesProdutos(
	id integer primary key identity,
	idCliente integer not null,
	idProduto integer not null,
	foreign key (idCliente) references Clientes(id),
	foreign key (idProduto) references Produtos(id)
)

