--POINT YOUR MOUSE HERE AND PRESS EXECUTE
CREATE DATABASE Farm;
GO
USE Farm;

GO
CREATE TABLE Cattle (
    id INT IDENTITY(1,1) PRIMARY KEY,
    Loai NVARCHAR(255) NOT NULL,
    SoCon INT NOT NULL,
    SoSua INT NOT NULL
);