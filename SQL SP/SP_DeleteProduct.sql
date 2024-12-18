USE [myMarketplace]
GO
/****** Object:  StoredProcedure [dbo].[DeleteProduct]    Script Date: 10/11/2024 22.18.42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[DeleteProduct]
    @product_id INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM products WHERE product_id = @product_id;
END;
