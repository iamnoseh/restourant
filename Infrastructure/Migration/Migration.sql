create database restourant_db;

create  table  customers
       (
           id serial primary key ,
           name varchar(100) not null ,
           phonenumber varchar(20)
       );
create  table  tables
        (
            id serial primary key ,
            tablenumber int ,
            isoccupied varchar(20)
        );      
create  table  menultems
        (
            id serial primary key,
            name varchar(100) not null ,
            price decimal,
            category varchar(20)
        );
create  table  orders
        (
            id serial primary key ,
            customerid int references customers(id) on delete cascade ,
            tableid int references  tables(id) on delete cascade ,
            status varchar(50)
        );
create  table  orderitems
        (
            id serial primary key ,
            orderid int references  orders(id) on delete  cascade ,
            menultemid int references menultems(id) on delete cascade 
        );  