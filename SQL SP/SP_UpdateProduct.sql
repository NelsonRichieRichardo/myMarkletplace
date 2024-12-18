USE [myMarketplace]
GO
/****** Object:  StoredProcedure [dbo].[UpdateProduct]    Script Date: 10/11/2024 22.20.33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[UpdateProduct]
    @product_id INT,
    @product_name VARCHAR(20),
    @product_price INT,
    @product_stock INT,
    @product_description TEXT,
    @product_image VARBINARY(MAX)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE products
    SET 
        product_name = @product_name,
        product_price = @product_price,
        product_stock = @product_stock,
        product_description = @product_description,
        product_image = @product_image,
        updated_at = GETUTCDATE()  -- Menggunakan GETUTCDATE() untuk waktu UTC
    WHERE product_id = @product_id;
END