create database my_finance;
use my_finance

create table plano_contas(
	id int identity(1,1) not null,
	descricao varchar(50) not null,
	tipo char(1) not null,
	primary key(id)
);

create table transacao(
	id bigint identity(1,1) not null,
	data datetime not null,
	valor decimal(18,2) not null,
	tipo char(1) not null,
	historico text null,
	id_plano_conta int not null,
	primary key(id),
	foreign key(id_plano_conta) references plano_contas
);

select * from plano_contas;

insert into plano_contas(descricao, tipo) values('Aluguel','C');
insert into plano_contas(descricao, tipo) values('Alimentação','D');
insert into plano_contas(descricao, tipo) values('Combustivel','D');
insert into plano_contas(descricao, tipo) values('Viagens','D');
insert into plano_contas(descricao, tipo) values('Salário','C');

delete from plano_contas where id = 4;
update plano_contas set tipo = 'D' where id = 1;

select * from transacao;

insert into transacao(data, valor, tipo, historico,id_plano_conta)
values('2022-08-11 21:35:00', 100.47, 'D', 'Gasolina para Viagem', 3);

insert into transacao(data, valor, tipo, historico,id_plano_conta)
values(GETDATE(), 48.42, 'D', 'Almoço', 2);

insert into transacao(data, valor, tipo, historico,id_plano_conta)
values(GETDATE()-1, 35.87, 'D', 'Almoço', 2);

insert into transacao(data, valor, tipo, historico,id_plano_conta)
values(GETDATE()-10, 3000000, 'D', 'Salario Empresa X', 6);
update transacao set tipo = 'C' where id = 8;


-- TODAS AS TRANSAÇÕES MENORES DO QUE 50 REAIS

select * from transacao where valor < 50

select SUM(valor) as total from transacao where tipo = 'D'

select data, valor, t.tipo, historico, p.descricao as 'plano_conta'
from transacao as t inner join plano_contas p
on p.id = t.id_plano_conta
where t.tipo = 'D'
order by valor