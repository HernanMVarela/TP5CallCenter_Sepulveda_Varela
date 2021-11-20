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

CREATE TABLE ESPECIALIDADES(
	ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	NOMBRE VARCHAR(30) NOT NULL
)
GO

CREATE TABLE TECNICOS(
	ID INT Not null primary key identity(1,1),
	Nombre varchar(40) not null,
	Apellido varchar(50) not null,
	Telefono varchar(15) not null,
	Mail varchar(100) not null,
	IDESP INT NOT NULL FOREIGN KEY REFERENCES ESPECIALIDADES(ID)
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

CREATE TABLE ESTADOS(
	ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	NOMBRE VARCHAR(20) NOT NULL
)
GO

CREATE TABLE TICKETS(
	ID BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
	TITULO VARCHAR(75) NOT NULL,
	COMENTARIO VARCHAR(250) NULL,
	IDESTADO INT NOT NULL FOREIGN KEY REFERENCES ESTADOS(ID),
	IDUSUARIO INT NOT NULL FOREIGN KEY REFERENCES USUARIOS(ID),
	IDCLIENTE INT NOT NULL FOREIGN KEY REFERENCES CLIENTES(ID),
	FECHA_CREACION DATE NOT NULL CHECK(FECHA_CREACION<GETDATE()),
	FECHA_CIERRE DATE NOT NULL
)
GO

CREATE TABLE INCIDENCIAS(
	ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	DESCRIPCION VARCHAR(300) NOT NULL,
	IDTICKET BIGINT NULL FOREIGN KEY REFERENCES TICKETS(ID),
	IDCATEGORIA INT NOT NULL FOREIGN KEY REFERENCES CATEGORIASINCIDENCIAS(ID),
	IDTECNICO INT NOT NULL FOREIGN KEY REFERENCES TECNICOS(ID),
	MODIFICACION DATE NOT NULL
)
GO

insert into TipoCuenta (Tipo) values 
('Administrador'),
('Supervisor'),
('Telefonista')

insert into Usuarios (NombreUsuario, Clave, IDTipo, Nombre, Apellido, Telefono, Mail) values
('hvarela','Segura2021', 1, 'Hernan', 'Varela', '1234567','hernan@mail.com'),
('csepulveda', 'Segura2021', 2, 'Christian', 'Sepulveda', '987645','christian@mail.com'),
('Empleado','Segura2021', 3,'Umpa','Lumpa','123235','umpalumpa@mail.com')

INSERT INTO ESPECIALIDADES (NOMBRE) VALUES 
('Licenciamiento'),
('Sistema Operativo'),
('Hardware'),
('Infraestructura'),
('Servidor'),
('Network'),
('Comunicaciones'),
('Administración de usuarios')

INSERT INTO TECNICOS (Nombre, Apellido, Mail, Telefono, IDESP) VALUES
('Courtney','Beard','Courtney.Beard@mail.com','1135021688',8),
('Bailey','Scott','Bailey.Scott@mail.com','1164919711',3),
('Luke','Nguyen','Luke.Nguyen@mail.com','1115228084',5),
('Erika','Wilson','Erika.Wilson@mail.com','1139653875',7),
('Nicholas','Davis','Nicholas.Davis@mail.com','1191608377',8),
('James','Hernandez','James.Hernandez@mail.com','1136963020',3),
('Christine','Lin','Christine.Lin@mail.com','1184653852',2),
('Brandon','Harvey','Brandon.Harvey@mail.com','1118907236',6),
('Aaron','Brooks','Aaron.Brooks@mail.com','1146367448',1),
('Debra','White','Debra.White@mail.com','1161519196',4),
('Crystal','Werner','Crystal.Werner@mail.com','1138221650',7),
('Colin','Scott','Colin.Scott@mail.com','1197306270',4),
('Jeremy','Cowan','Jeremy.Cowan@mail.com','1141621585',8),
('Matthew','Jensen','Matthew.Jensen@mail.com','1181652242',2)

INSERT INTO TIPOCLIENTES(NOMBRE) VALUES
('Persona'),
('Empresa')

INSERT INTO CLIENTES (NOMBRE, CUIT, EMAIL, TELEFONO, IDTIPO) VALUES
('Jessica Acosta','20-24351277-2','Jessica.Acosta@mail.com','1150578892',1),
('Austin Walker','20-37201514-2','Austin.Walker@mail.com','1110754741',2),
('Jamie James','20-23957982-2','Jamie.James@mail.com','1139560884',1),
('Michael Williams','20-36634654-2','Michael.Williams@mail.com','1192280451',2),
('Amber Davis','20-33140617-2','Amber.Davis@mail.com','1146033207',2),
('Anthony Becker','20-24429888-2','Anthony.Becker@mail.com','1195080029',1),
('Rebecca Bates','20-22259275-2','Rebecca.Bates@mail.com','1183942351',2),
('Aaron Reynolds','20-31504374-2','Aaron.Reynolds@mail.com','1147047891',1),
('Alyssa Bell','20-25932600-2','Alyssa.Bell@mail.com','1191027342',1),
('Kevin Miller','20-34296645-2','Kevin.Miller@mail.com','1175328555',1),
('Elizabeth Miller','20-35463432-2','Elizabeth.Miller@mail.com','1149490118',2),
('Rachel Garcia','20-23653704-2','Rachel.Garcia@mail.com','1190683718',1),
('Suzanne Tucker','20-28260036-2','Suzanne.Tucker@mail.com','1195636923',1),
('Katherine Smith','20-29494344-2','Katherine.Smith@mail.com','1143756936',2)

INSERT INTO ESTADOS (NOMBRE) VALUES
('Abierto'),
('En Análisis'),
('Cerrado'),
('Reabierto'),
('Asignado'),
('Resuelto')

INSERT INTO TICKETS(TITULO,COMENTARIO,IDESTADO,IDUSUARIO,IDCLIENTE,FECHA_CREACION,FECHA_CIERRE) VALUES
('TICKET 1','COMENTARIO DE PRUEBA',1,1,1000,'10/10/2021','9/11/2021'),
('TICKET 2','COMENTARIO DE PRUEBA',2,1,1003,'10/10/2021','9/11/2021'),
('TICKET 3','COMENTARIO DE PRUEBA',6,1,1003,'10/10/2021','9/11/2021'),
('TICKET 4','COMENTARIO DE PRUEBA',3,1,1004,'10/10/2021','9/11/2021'),
('TICKET 5','COMENTARIO DE PRUEBA',4,2,1005,'10/10/2021','9/11/2021'),
('TICKET 6','COMENTARIO DE PRUEBA',5,2,1006,'10/10/2021','9/11/2021'),
('TICKET 7','COMENTARIO DE PRUEBA',1,2,1007,'10/10/2021','9/11/2021'),
('TICKET 8','COMENTARIO DE PRUEBA',3,3,1008,'10/10/2021','9/11/2021'),
('TICKET 9','COMENTARIO DE PRUEBA',5,3,1009,'10/10/2021','9/11/2021'),
('TICKET 10','COMENTARIO DE PRUEBA',6,3,1009,'10/10/2021','9/11/2021')

INSERT INTO CATEGORIASINCIDENCIAS(NOMBRE) VALUES
('Software'),
('Hardware'),
('Licenciamiento'),
('Control de usuarios'),
('Network')

INSERT INTO INCIDENCIAS(DESCRIPCION,IDTICKET,IDCATEGORIA,IDTECNICO,MODIFICACION) VALUES
('Mensaje de error en windows',1,1,1,'2021-08-08'),
('Problema de conexión',2,5,2,'2021-07-07'),
('La PC no enciende',3,2,6,'2021-06-06'),
('La impresora no anda',4,2,5,'2021-05-05'),
('Cuenta de usuario bloqueada',5,4,7,'2021-04-04'),
('No llegan los correos',6,1,1,'2021-03-03'),
('No funciona la letra A',7,2,4,'2021-02-02'),
('No se ve nada en pantalla',8,2,1,'2021-08-08'),
('La PC esta lenta',9,1,9,'2021-08-08'),
('Mensaje de error en windows',10,1,1,'2021-08-08'),
('Mensaje de error en windows',6,1,1,'2021-05-05')
GO

SELECT T.ID as TID, T.TITULO AS TTitulo, T.COMENTARIO AS TComentario, T.FECHA_CREACION AS FCreacion, T.FECHA_CIERRE as FCierre, 
I.ID as IID, I.DESCRIPCION AS IDescripcion, I.MODIFICACION AS FModificacion,
CI.NOMBRE AS ICategoria, 
U.Nombre AS UNombre, U.Apellido as UApellido, U.NombreUsuario as UUser, 
C.NOMBRE AS CNombre, TC.NOMBRE as CTipo, C.CUIT as CCuit, C.EMAIL as CMail, C.TELEFONO as CTelefono,
TE.Nombre AS TENombre, TE.Apellido AS TEApellido, TE.Mail AS TEMail, TE.Telefono AS TETelefono,
ES.NOMBRE AS TEEspecialidad, E.NOMBRE AS ENombre 
FROM TICKETS T INNER JOIN INCIDENCIAS I ON T.ID=I.IDTICKET 
INNER JOIN CATEGORIASINCIDENCIAS CI ON CI.ID=I.IDCATEGORIA 
INNER JOIN ESTADOS E ON E.ID=T.IDESTADO 
INNER JOIN Usuarios U ON U.ID=T.IDUSUARIO 
INNER JOIN CLIENTES C ON C.ID=T.IDCLIENTE 
INNER JOIN TIPOCLIENTES TC ON TC.ID=C.IDTIPO 
INNER JOIN TECNICOS TE ON TE.ID=I.IDTECNICO 
INNER JOIN ESPECIALIDADES ES ON ES.ID=TE.IDESP
--select * from TECNICOS

SELECT * FROM INCIDENCIAS

SELECT I.ID AS IID, I.IDTICKET AS IIDT, I.DESCRIPCION AS IDescripcion, MODIFICACION AS FModificacion ,C.ID AS CID, C.NOMBRE AS ICategoria, T.Nombre AS TNombre, T.Apellido AS TApellido, T.Mail AS TMail, T.Telefono AS TTelefono, E.ID AS EID, E.NOMBRE AS Especialidad FROM INCIDENCIAS I INNER JOIN CATEGORIASINCIDENCIAS C ON I.IDCATEGORIA=C.ID INNER JOIN TECNICOS T ON I.IDTECNICO=T.ID INNER JOIN ESPECIALIDADES E ON E.ID=T.IDESP

SELECT * FROM INCIDENCIAS

SELECT T.ID, T.TITULO, T.FECHA_CREACION, T.FECHA_CIERRE, C.NOMBRE, C.CUIT, E.NOMBRE FROM TICKETS T INNER JOIN ESTADOS E ON T.IDESTADO=E.ID INNER JOIN CLIENTES C ON T.IDCLIENTE=C.ID

SELECT T.ID AS TID, T.TITULO AS TTitulo, T.FECHA_CREACION as TFCreacion, T.FECHA_CIERRE as TFCierre, E.NOMBRE AS TEstado, T.IDCLIENTE as TIDCliente, T.IDUSUARIO AS TIDUsuario FROM TICKETS T INNER JOIN ESTADOS E ON T.IDESTADO=E.ID WHERE T.ID=6