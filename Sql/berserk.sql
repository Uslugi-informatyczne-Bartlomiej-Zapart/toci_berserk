drop table orderproducts;
drop table chemistry;
drop table products;
drop table categories;

create table categories(
	id serial primary key,
	idparent int references categories (id),
	name text
);

create table products(
	id serial primary key,
	name text,
	manufacturer text,
	code int,
	reference int
);

create table chemistry(
	id serial primary key,
	idcategories int references categories (id),
	quantity int,
	idproducts int references products (id) 
);

create table orderproducts(
	id serial primary key,
	orderid int,
	idcategories int references categories (id),
	quantity int,
	idproducts int references products (id)
);