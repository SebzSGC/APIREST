# Base de Datos DBpruebas1 y Procedimientos Almacenados en T-SQL

Este repositorio contiene instrucciones para crear una base de datos llamada DBpruebas1 en Transact-SQL (T-SQL), junto con una tabla llamada TBuser y varios procedimientos almacenados para administrar usuarios en la tabla.

## Creación de la Base de Datos y la Tabla

```sql
CREATE DATABASE DBpruebas1
GO
USE DBpruebas1
GO
CREATE TABLE TBuser(
    IdUser INT PRIMARY KEY IDENTITY(1,1),
    Documentation VARCHAR(60),
    Names VARCHAR(60),
    PhoneNumber VARCHAR(60),
    Mail VARCHAR(60),
    City VARCHAR(60),
    DateRegister DATETIME DEFAULT GETDATE()
)
GO

##Inserción de Datos de Ejemplo en la Tabla
INSERT INTO TBuser (Documentation, Names, PhoneNumber, Mail, City)
VALUES 
('1234567890', 'John Doe', '123-456-7890', 'john.doe@example.com', 'New York'),
('9876543210', 'Jane Smith', '987-654-3210', 'jane.smith@example.com', 'Los Angeles'),
('5678901234', 'Michael Johnson', '567-890-1234', 'michael.johnson@example.com', 'Chicago'),
('0123456789', 'Emily Williams', '012-345-6789', 'emily.williams@example.com', 'Houston');

##Procedimientos Almacenados
#Insertar un Nuevo Usuario
CREATE PROCEDURE InsertUser
    @Documentation VARCHAR(60),
    @Names VARCHAR(60),
    @PhoneNumber VARCHAR(60),
    @Mail VARCHAR(60),
    @City VARCHAR(60)
AS
BEGIN
    INSERT INTO TBuser (Documentation, Names, PhoneNumber, Mail, City)
    VALUES (@Documentation, @Names, @PhoneNumber, @Mail, @City)
END
GO
#Eliminar un Usuario por IdUser
CREATE PROCEDURE DeleteUser
    @IdUser INT
AS
BEGIN
    DELETE FROM TBuser WHERE IdUser = @IdUser
END
GO
#Actualizar un Usuario por IdUser
CREATE PROCEDURE UpdateUser
    @IdUser INT,
    @Documentation VARCHAR(60),
    @Names VARCHAR(60),
    @PhoneNumber VARCHAR(60),
    @Mail VARCHAR(60),
    @City VARCHAR(60)
AS
BEGIN
    UPDATE TBuser
    SET Documentation = @Documentation,
        Names = @Names,
        PhoneNumber = @PhoneNumber,
        Mail = @Mail,
        City = @City
    WHERE IdUser = @IdUser
END
GO
#Obtener Todos los Usuarios
CREATE PROCEDURE GetAllUsers
AS
BEGIN
    SELECT * FROM TBuser
END
GO
