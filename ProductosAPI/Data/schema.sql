create database productos2;

use productos2;

create table Productos(
	Id int primary key identity(1,1),
	Nombre varchar(20),
	Estado varchar(1)
);

insert into Productos(Nombre, Estado) values ('Banana', 'A');