drop view ProductCompanyOrder;
drop view ProductCompanySearch;

drop table delivery;
drop table metricHistory;
drop table predictedorderquantity;
drop table predictedorder;
drop table chemistrypop;
drop table orderproducts;
drop table orders;
drop table chemistry;
drop table productshistory;
drop table productscodes;
drop table products;
drop table categories;
drop table users; 
drop table deliverycompanies;
drop table metrics;



create table users
(
    id serial primary key,
    CompanyName text,
	OwnerSurname text,
    login text,
    password text
);

create table categories
(
    id serial primary key,
    idparent int references categories (id),
    name text
);

create table deliverycompanies
(
	id serial primary key,
	name text
);

create table products
(
    id serial primary key,
    name text,
    manufacturer text,
    reference text
);

create table delivery
(
	id serial primary key,
	idproducts int references products (id),
	iddeliverycompany int references deliverycompanies (id),
	price real
);


create table productscodes
(
    id serial primary key,
    idproducts int references products (id),
    code int
);

create table productshistory
(
    id serial primary key,
	iddeletedproduct int references products (id),
    name text,
    manufacturer text,
    reference text,
	iddeletedproductscodes int references productscodes (id),
	code int,
	dateofdeletion timestamp default now()
);

create table chemistry
(
    id serial primary key,
    idcategories int references categories (id),
    quantity int,
    idproducts int references products (id) 
);

create table orders
(
	id serial primary key,
	date timestamp default now(),
	status int,
	iddeliverycompany int references deliverycompanies (id)
);

create table orderproducts
(
    id serial primary key,
    idorder int references orders (id),
	status int,
    idcategories int references categories (id),
    quantity int,
    idproducts int references products (id),
	price real
);

create table metrics
(
	id serial primary key,
	metric int,
	algorithm int
);

create table predictedorder
(
	id serial primary key,
	idproducts int references products (id),
	idorder int references orders (id)
);

create table predictedorderquantity
(
	id serial primary key,
	idmetric int references metrics (id),
	quantity int,
	idpredictedorder int references predictedorder (id)
);

create table chemistrypop
(
    id serial primary key,
    idproducts int references products (id), -- dane towaru (idproduct % 8)
    quantity int, -- 3
    date timestamp default now(), -- 30,06,2021
    idusers int references users(id) -- info o zalogowanym pracowniku / firmie
);



create table metricHistory
(
	id serial primary key,
	date timestamp default now(),
	idorders int references orders (id),
	idmetrics int references metrics (id),
	metric int
);


create or replace view ProductCompanySearch as
select delivery.idproducts, delivery.iddeliverycompany, products.name, products.manufacturer, products.reference, 
productscodes.code, deliverycompanies.name as companyname, delivery.price
from delivery 
join products on products.id = delivery.idproducts
join productscodes on products.id = productscodes.idproducts
join deliverycompanies on delivery.iddeliverycompany = delivery.id;

create or replace view ProductCompanyOrder as
select products.id as ProductId, products.name as ProductName, chemistry.quantity as CurrentQuantity, deliverycompanies.name as DeliveryCompany, delivery.price
from products 
join chemistry on products.id = chemistry.idproducts
join delivery on products.id = delivery.idproducts
join deliverycompanies on delivery.iddeliverycompany = deliverycompanies.id;

delete from orders where id = 61;

delete from orderproducts where idorder = 61;

select * from ProductCompanyOrder;
select * from ProductCompanySearch;
update orders set status = 2 where date < '2021-07-05';
select * from deliverycompanies;
update deliverycompanies set name='dupa' where id=7;
select * from delivery;
select * from users;
select * from products;
select * from productscodes;
select * from chemistrypop;
select * from orderproducts;
select * from orders order by date;
update deliverycompanies set name='dupa' where id=7;

