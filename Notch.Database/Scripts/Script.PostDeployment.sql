/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

INSERT INTO Track(Name, Length, BPM)
VALUES('Swerve', 500, 87);

INSERT INTO Track(Name, Length, BPM)
VALUES('Short Stop', 300, 123);

IF NOT EXISTS(SELECT 1 FROM [Product] WHERE Id = 1)
    INSERT INTO Product(Id, Name, Price, Discount)
    VALUES(1, 'Car', 1000, 5);

IF NOT EXISTS(SELECT 1 FROM [Product] WHERE Id = 2)
    INSERT INTO Product(Id, Name, Price, Discount)
    VALUES(2, 'Hammer', 20, 1);

IF NOT EXISTS(SELECT 1 FROM [Order] WHERE Id = 1)
    INSERT INTO [Order](Id, Total)
    VALUES (1, 1000);

IF NOT EXISTS(SELECT 1 FROM [OrderProduct] WHERE OrderId = 1 AND ProductId = 1)
    INSERT INTO OrderProduct(OrderId, ProductId)
    VALUES(1, 1);