CREATE TABLE pruebaAbankBD
GO
USE pruebaAbankBD
GO
CREATE TABLE Usuarios(
id int identity primary key not null,
nombres varchar(200) not null,
apellidos varchar(200) not null,
fechanacimiento datetime,
direccion varchar(250) not null,
contraseña varchar(120) not null,
telefono varchar(9) not null,
email varchar(100)not null,
fechacreacion datetime not null,
fechamodificacion datetime)