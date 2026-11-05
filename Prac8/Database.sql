CREATE DATABASE InventoryDB;
GO
USE InventoryDB;
GO
CREATE TABLE Items (
    ItemId   INT IDENTITY(1,1) PRIMARY KEY,
    ItemName NVARCHAR(50) NOT NULL,
    Quantity INT NOT NULL,
    Price    DECIMAL(10,2) NOT NULL
);
INSERT INTO Items VALUES ('Keyboard', 25, 550.00), ('Mouse', 40, 299.50);
