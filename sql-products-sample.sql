
/*
-- Create table
CREATE TABLE Products(
    ProductId INT PRIMARY KEY IDENTITY(100000,1) NOT NULL,
    ProductName VARCHAR(255),
    ProductDescription VARCHAR(255),
    ProductVisible BIT,
    ProductQuantity INT,
    ProductPrice DECIMAL(6,4),
    ProductImages VARCHAR(255)
);
*/

/*
-- Get
CREATE PROC ProductsGet
	@ProductId INT = NULL
	AS BEGIN
		SET NOCOUNT ON;
		IF(@ProductId IS NOT NULL)
		BEGIN
			SELECT * FROM Products WHERE ProductId=@ProductId;
		END
        ELSE
            SELECT * FROM Products ORDER BY ProductId ASC;
	END
GO
*/
/*
-- Update
CREATE PROC ProductsPut
    @ProductId INT,
    @ProductName VARCHAR(255),
    @ProductDescription VARCHAR(255),
    @ProductPrice DECIMAL(6,4),
    @ProductQuantity INT,
    @ProductVisible BIT,
    @ProductImages VARCHAR(255)
AS BEGIN
    UPDATE Products SET
    ProductName=@ProductName,
    ProductDescription=@ProductDescription,
    ProductVisible=@ProductVisible,
    ProductQuantity=@ProductQuantity,
    ProductPrice=@ProductPrice,
    ProductImages=@ProductPrice
    WHERE ProductId=@ProductId
END
GO
*/
/*
-- Insert
CREATE PROC ProductsPost
    @ProductName VARCHAR(255),
    @ProductDescription VARCHAR(255),
    @ProductPrice DECIMAL(6,4),
    @ProductQuantity INT,
    @ProductVisible BIT,
    @ProductImages VARCHAR(255)
AS BEGIN
    INSERT INTO Products VALUES(
    @ProductName,
    @ProductDescription,
    @ProductVisible,
    @ProductQuantity,
    @ProductPrice,
    @ProductPrice
    );
END
GO
*/
/*
-- Delete
CREATE PROC ProductsDelete
    @ProductId INT
AS BEGIN
    DELETE FROM Products WHERE ProductId=@ProductId 
END
GO
*/
