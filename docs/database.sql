create database my_finance;
use my_finance

create table plano_contas(
	id int identity(1,1) not null,
	descricao varchar(50) not null,
	tipo char(1) not null,
	primary key(id)
);

create table pagamento(
	id int identity(1,1) not null,
	pagamento varchar(50) not null,
	primary key(id)
);

create table transacao(
	id bigint identity(1,1) not null,
	data datetime not null,
	valor decimal(18,2) not null,
	tipo char(1) not null,
	historico text null,
	id_plano_conta int not null,
	id_pagamento int,
	primary key(id),
	foreign key(id_plano_conta) references plano_contas
	foreign key(id_pagamento) references pagamento
);

insert into plano_contas(descricao, tipo) values('Salário','R');
insert into plano_contas(descricao, tipo) values('Aluguel','D');
insert into plano_contas(descricao, tipo) values('Alimentação','D');
insert into plano_contas(descricao, tipo) values('Combustivel','D');
insert into plano_contas(descricao, tipo) values('Viagens','D');
insert into plano_contas(descricao, tipo) values('Luz','D');
insert into plano_contas(descricao, tipo) values('Água','D');
insert into plano_contas(descricao, tipo) values('Internet','D');

insert into pagamento(pagamento) values('Dinheiro');
insert into pagamento(pagamento) values('Débito');
insert into pagamento(pagamento) values('Crédito');
insert into pagamento(pagamento) values('Pix');
insert into pagamento(pagamento) values('Boleto');
insert into pagamento(pagamento) values('');


-- exemplo insert na tabela  transacao
insert into transacao(data, valor, tipo, historico,id_plano_conta, id_pagamento)
values('2022-08-11 21:35:00', 100.47, 'D', 'Gasolina para Viagem', 3, 2);