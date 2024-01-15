-------------------------------
--Entity Framework SQL SERVER
-------------------------------
CREATE DATABASE BDBILLETERA
go
use BDBILLETERA
go
CREATE SCHEMA BILLETERA 
go
DROP TABLE BILLETERA.ObjetivosCompra;
DROP TABLE BILLETERA.Pagos;
DROP TABLE BILLETERA.Deudas;
DROP TABLE BILLETERA.Usuarios;
go
-- Tabla de Usuarios
CREATE TABLE BILLETERA.Usuarios (
    ID uniqueidentifier PRIMARY KEY,
    Nombre VARCHAR(100),
    Email VARCHAR(100),
    Contrasena VARCHAR(100)
);

-- Tabla de Deudas
CREATE TABLE BILLETERA.Deudas (
    ID uniqueidentifier PRIMARY KEY,
    UsuarioID uniqueidentifier,
    Monto DECIMAL(10, 2),
    Descripcion VARCHAR(255),
    FechaDeuda DATE,
    FOREIGN KEY (UsuarioID) REFERENCES BILLETERA.Usuarios(ID)
);

-- Tabla de Pagos
CREATE TABLE BILLETERA.Pagos (
    ID uniqueidentifier PRIMARY KEY,
    DeudaID uniqueidentifier,
    Monto DECIMAL(10, 2),
    FechaPago DATE,
    FOREIGN KEY (DeudaID) REFERENCES BILLETERA.Deudas(ID)
);

-- Tabla de Objetivos de Compra
CREATE TABLE BILLETERA.ObjetivosCompra (
    ID uniqueidentifier PRIMARY KEY,
    UsuarioID uniqueidentifier,
    Producto VARCHAR(100),
    Precio DECIMAL(10, 2),
    FechaObjetivo DATE,
    FOREIGN KEY (UsuarioID) REFERENCES BILLETERA.Usuarios(ID)
);
go
insert into BILLETERA.Usuarios (ID,Nombre,Email,Contrasena)values(NEWID(),'Guido Espinoza','galespinoza9@gmail.com','12345')
select * from BILLETERA.Usuarios

-------------------------------
--Entity Framework ORACLE
-------------------------------

ALTER SESSION SET "_ORACLE_SCRIPT"=true;
-- Crear un nuevo usuario (esquema)
CREATE USER BILLETERA IDENTIFIED BY BILLETERA;
-- Crear un tablespace para los datos
CREATE TABLESPACE teBILLETERAData DATAFILE 'teBILLETERAData.dat' SIZE 10M;
-- Crear un tablespace para los índices
CREATE TABLESPACE teBILLETERAIndex DATAFILE 'teBILLETERAIndex.dat' SIZE 10M;
-- Asignar los tablespaces al usuario (esquema)
ALTER USER BILLETERA DEFAULT TABLESPACE teBILLETERAData TEMPORARY TABLESPACE temp;
-- Dar permisos al usuario (esquema)
GRANT CONNECT, RESOURCE TO BILLETERA;
GRANT ALL PRIVILEGES ON BILLETERA.Usuarios TO billetera;
ALTER USER BILLETERA QUOTA 100M ON TEBILLETERADATA;
GRANT INSERT, UPDATE, DELETE ON BILLETERA.Usuarios TO billetera
ALTER USER billetera QUOTA UNLIMITED ON tablespace;


DROP TABLE BILLETERA.ObjetivosCompra;
DROP TABLE BILLETERA.Pagos;
DROP TABLE BILLETERA.Deudas;
DROP TABLE BILLETERA.Usuarios;


-- Tabla de Usuarios
CREATE TABLE BILLETERA.Usuarios (
    ID RAW(16) PRIMARY KEY,
    Nombre VARCHAR(100),
    Email VARCHAR(100),
    Contrasena VARCHAR(100)
);

-- Tabla de Deudas
CREATE TABLE BILLETERA.Deudas (
    ID RAW(16) PRIMARY KEY,
    UsuarioID RAW(16),
    Monto DECIMAL(10, 2),
    Descripcion VARCHAR(255),
    FechaDeuda DATE,
    FOREIGN KEY (UsuarioID) REFERENCES BILLETERA.Usuarios(ID)
);

-- Tabla de Pagos
CREATE TABLE BILLETERA.Pagos (
    ID RAW(16) PRIMARY KEY,
    DeudaID RAW(16),
    Monto DECIMAL(10, 2),
    FechaPago DATE,
    FOREIGN KEY (DeudaID) REFERENCES BILLETERA.Deudas(ID)
);

-- Tabla de Objetivos de Compra
CREATE TABLE BILLETERA.ObjetivosCompra (
    ID RAW(16) PRIMARY KEY,
    UsuarioID RAW(16),
    Producto VARCHAR(100),
    Precio DECIMAL(10, 2),
    FechaObjetivo DATE,
    FOREIGN KEY (UsuarioID) REFERENCES BILLETERA.Usuarios(ID)
);


select * from BILLETERA.Usuarios
insert into BILLETERA.Usuarios(ID,Nombre,Email,Contrasena)values(SYS_GUID(),'Guido Espinoza','galespinoza9@gmail.com','12345')

-------------------------------
--Entity Framework MYSQL
-------------------------------
CREATE SCHEMA BILLETERA 

DROP TABLE BILLETERA.ObjetivosCompra;
DROP TABLE BILLETERA.Pagos;
DROP TABLE BILLETERA.Deudas;
DROP TABLE BILLETERA.Usuarios;

-- Tabla de Usuarios
CREATE TABLE BILLETERA.Usuarios (
    ID CHAR(36) PRIMARY KEY,
    Nombre VARCHAR(100),
    Email VARCHAR(100),
    Contrasena VARCHAR(100)
);

-- Tabla de Deudas
CREATE TABLE BILLETERA.Deudas (
    ID CHAR(36) PRIMARY KEY,
    UsuarioID CHAR(36),
    Monto DECIMAL(10, 2),
    Descripcion VARCHAR(255),
    FechaDeuda DATE,
    FOREIGN KEY (UsuarioID) REFERENCES BILLETERA.Usuarios(ID)
);

-- Tabla de Pagos
CREATE TABLE BILLETERA.Pagos (
    ID CHAR(36) PRIMARY KEY,
    DeudaID CHAR(36),
    Monto DECIMAL(10, 2),
    FechaPago DATE,
    FOREIGN KEY (DeudaID) REFERENCES BILLETERA.Deudas(ID)
);

-- Tabla de Objetivos de Compra
CREATE TABLE BILLETERA.ObjetivosCompra (
    ID CHAR(36) PRIMARY KEY,
    UsuarioID CHAR(36),
    Producto VARCHAR(100),
    Precio DECIMAL(10, 2),
    FechaObjetivo DATE,
    FOREIGN KEY (UsuarioID) REFERENCES BILLETERA.Usuarios(ID)
);


-------------------------------
--Entity Framework POSTGRES
-------------------------------

CREATE DATABASE BDBILLETERA
CREATE SCHEMA BILLETERA 

DROP TABLE BILLETERA.ObjetivosCompra;
DROP TABLE BILLETERA.Pagos;
DROP TABLE BILLETERA.Deudas;
DROP TABLE BILLETERA.Usuarios;

CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

-- Tabla de Usuarios
CREATE TABLE BILLETERA.Usuarios (
    ID uuid PRIMARY KEY,
    Nombre VARCHAR(100),
    Email VARCHAR(100),
    Contrasena VARCHAR(100)
);

-- Tabla de Deudas
CREATE TABLE BILLETERA.Deudas (
    ID uuid PRIMARY KEY,
    UsuarioID uuid,
    Monto DECIMAL(10, 2),
    Descripcion VARCHAR(255),
    FechaDeuda DATE,
    FOREIGN KEY (UsuarioID) REFERENCES BILLETERA.Usuarios(ID)
);

-- Tabla de Pagos
CREATE TABLE BILLETERA.Pagos (
    ID uuid PRIMARY KEY,
    DeudaID uuid,
    Monto DECIMAL(10, 2),
    FechaPago DATE,
    FOREIGN KEY (DeudaID) REFERENCES BILLETERA.Deudas(ID)
);

-- Tabla de Objetivos de Compra
CREATE TABLE BILLETERA.ObjetivosCompra (
    ID uuid PRIMARY KEY,
    UsuarioID uuid,
    Producto VARCHAR(100),
    Precio DECIMAL(10, 2),
    FechaObjetivo DATE,
    FOREIGN KEY (UsuarioID) REFERENCES BILLETERA.Usuarios(ID)
);



INSERT INTO BILLETERA.Usuarios (ID, Nombre, Email, Contrasena)
VALUES (uuid_generate_v4(),'Guido Espinoza','galespinoza9@gmail.com','12345')


