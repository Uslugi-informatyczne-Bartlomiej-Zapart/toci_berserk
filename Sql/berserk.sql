drop table metricHistory;
drop table metrics;
drop table chemistrypop;
drop table orderproducts;
drop table orders;
drop table chemistry;
drop table productscodes;
drop table products;
drop table categories;
drop table users;


create table users
(
    id serial primary key,
    name text,
    login text,
    password text
);

create table categories(
    id serial primary key,
    idparent int references categories (id),
    name text
);

create table products(
    id serial primary key,
    name text,
    manufacturer text,
    reference int
);

create table productscodes
(
    id serial primary key,
    idproducts int references products (id),
    code int
);

create table chemistry(
    id serial primary key,
    idcategories int references categories (id),
    quantity int,
    idproducts int references products (id) 
);

create table orders
(
	id serial primary key,
	date timestamp default now()
);

create table orderproducts(
    id serial primary key,
    idorder int references orders (id),
	status int,
    idcategories int references categories (id),
    quantity int,
    idproducts int references products (id)
);

create table chemistrypop
(
    id serial primary key,
    idproducts int references products (id), -- dane towaru (idproduct % 8)
    quantity int, -- 3
    date timestamp default now(), -- 30,06,2021
    idusers int references users(id) -- info o zalogowanym pracowniku / firmie
);

create table metrics
(
	id serial primary key,
	metric int,
	algorithm int
);

create table metricHistory
(
	id serial primary key,
	date timestamp default now(),
	idorders int references orders (id),
	idmetrics int references metrics (id),
	metric int
);
