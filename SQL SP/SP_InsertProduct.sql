USE [myMarketplace]
GO
/****** Object:  StoredProcedure [dbo].[InsertProduct]    Script Date: 10/11/2024 22.20.16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[InsertProduct]
    @product_name VARCHAR(20),
    @product_price INT,
    @product_stock INT,
    @product_description TEXT,
    @product_image VARBINARY(MAX)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO products (
        product_name, 
        product_price, 
        product_stock, 
        product_description, 
        product_image,
        created_at,
        updated_at
    )
    VALUES (
        @product_name, 
        @product_price, 
        @product_stock, 
        @product_description, 
        @product_image,
        GETUTCDATE(),  -- Menggunakan GETUTCDATE() untuk waktu UTC
        GETUTCDATE()
    )
END