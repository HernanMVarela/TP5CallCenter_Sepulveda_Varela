create database CallCenter
go 
use CallCenter
go

create table TipoCuenta(
	ID tinyint not null primary key identity(1,1),
	Tipo varchar(30) not null
)
go
create table Usuarios(
	ID int not null primary key identity(1,1), 
	NombreUsuario varchar(40) not null unique,
	Clave varchar(50) not null,
	IDTipo tinyint not null foreign key references TipoCuenta(ID),
	Nombre varchar(40) not null,
	Apellido varchar(50) not null,
	Telefono varchar(15) not null,
	Mail varchar(100) not null
)
go

create table Tecnicos(
	ID INT Not null primary key identity(1,1),
	Nombre varchar(40) not null,
	Apellido varchar(50) not null,
	Telefono varchar(15) not null,
	Mail varchar(100) not null
)
go

insert into TipoCuenta (Tipo) values 
('Administrador'),
('Supervisor'),
('Telefonista')

insert into Usuarios (NombreUsuario, Clave, IDTipo, Nombre, Apellido, Telefono, Mail) values
('hvarela','Talar.2021', 1, 'Hernan', 'Varela', '1234567','hernan@mail.com'),
('csepulveda', 'Talar.2021', 2, 'Christian', 'Sepulveda', '987645','christian@mail.com'),
('Empleado','Talar.2021', 3,'Umpa','Lumpa','123235','umpalumpa@mail.com')

select * from Usuarios