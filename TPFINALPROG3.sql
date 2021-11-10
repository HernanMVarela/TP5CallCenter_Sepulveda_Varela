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

CREATE TABLE TIPOCLIENTES(
	ID TINYINT NOT NULL PRIMARY KEY IDENTITY(1,1),
	NOMBRE VARCHAR(15) NOT NULL
)
GO

CREATE TABLE CLIENTES(
	ID INT NOT NULL PRIMARY KEY IDENTITY(1000,1),
	NOMBRE VARCHAR(100) NOT NULL,
	CUIT VARCHAR(25) NOT NULL,
	EMAIL VARCHAR(100) NOT NULL,
	TELEFONO VARCHAR(20) NOT NULL,
	IDTIPO TINYINT NOT NULL FOREIGN KEY REFERENCES TIPOCLIENTES(ID)
)
GO

CREATE TABLE CATEGORIASINCIDENCIAS(
	ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	NOMBRE VARCHAR(40) NOT NULL
)
GO

CREATE TABLE INCIDENCIAS(
	ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	TIPO VARCHAR(20) NOT NULL,
	DESCRIPCION VARCHAR(300) NOT NULL,
	IDCATEGORIA INT NOT NULL FOREIGN KEY REFERENCES CATEGORIASINCIDENCIAS(ID)
)
GO

CREATE TABLE ESTADOS(
	ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	NOMBRE VARCHAR(20) NOT NULL
)
GO

CREATE TABLE TICKETS(
	ID BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
	IDESTADO INT NOT NULL FOREIGN KEY REFERENCES ESTADOS(ID),
	IDUSUARIO INT NOT NULL FOREIGN KEY REFERENCES USUARIOS(ID),
	IDTECNICO INT NOT NULL FOREIGN KEY REFERENCES TECNICOS(ID),
	IDCLIENTE INT NOT NULL FOREIGN KEY REFERENCES CLIENTES(ID),
	IDINCIDENCIAS INT NOT NULL FOREIGN KEY REFERENCES INCIDENCIAS(ID),
	FECHA_CREACION DATE NOT NULL CHECK(FECHA_CREACION<GETDATE()),
	FECHA_CIERRE DATE NOT NULL
)
GO


insert into TipoCuenta (Tipo) values 
('Administrador'),
('Supervisor'),
('Telefonista')

insert into Usuarios (NombreUsuario, Clave, IDTipo, Nombre, Apellido, Telefono, Mail) values
('hvarela','Talar.2021', 1, 'Hernan', 'Varela', '1234567','hernan@mail.com'),
('csepulveda', 'Talar.2021', 2, 'Christian', 'Sepulveda', '987645','christian@mail.com'),
('Empleado','Talar.2021', 3,'Umpa','Lumpa','123235','umpalumpa@mail.com')